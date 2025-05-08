using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Core.IngredientService.Data;
using Core.IngredientService.Enums;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class IngredientSoImporter
    {
        private const string JsonPath         = "Assets/StreamingAssets/Ingredients.json";
        private const string IngredientFolder = "Assets/Cooking/SOs/Ingredients/";

        [MenuItem("Tools/Cooking/Import Ingredients From JSON")]
        public static void ImportFromJson()
        {
            // 1) Load JSON
            if (!File.Exists(JsonPath))
            {
                Debug.LogError($"[Importer] JSON not found at: {JsonPath}");
                return;
            }

            // Read raw text and wrap if needed
            string raw = File.ReadAllText(JsonPath).Trim();
            string toParse = raw.StartsWith("[")
                ? $"{{\"ingredients\":{raw}}}"
                : raw;

            var container = JsonUtility.FromJson<IngredientDataList>(toParse);
            if (container?.ingredients == null)
            {
                Debug.LogError("[Importer] Failed to parse IngredientDataList.");
                return;
            }

            // Ensure folder exists
            Directory.CreateDirectory(IngredientFolder);

            // 2) Process each entry
            foreach (var data in container.ingredients)
            {
                if (string.IsNullOrWhiteSpace(data.iD))
                {
                    Debug.LogWarning("Ingredient entry without ID skipped.");
                    continue;           // skip this broken element
                }
                
                // Load or create SO
                string assetPath = $"{IngredientFolder}{data.iD}.asset";
                IngredientSO ingredient = AssetDatabase
                    .LoadAssetAtPath<IngredientSO>(assetPath)
                    ?? ScriptableObject.CreateInstance<IngredientSO>();

                // Identity & classification
                ingredient.iD             = data.iD;
                ingredient.ingredientName = data.ingredientName;

                if (!Enum.TryParse(data.type, true, out IngredientType itype))
                    Debug.LogError($"Unknown IngredientType '{data.type}' for {data.iD}");
                ingredient.type = itype;

                ingredient.physicalStates = data.physicalStates?
                    .Select(s =>
                    {
                        if (!Enum.TryParse(s, true, out PhysicalStateTag pst))
                            Debug.LogError($"Unknown PhysicalStateTag '{s}' for {data.iD}");
                        return pst;
                    })
                    .ToArray() ?? new PhysicalStateTag[0];

                // ingredient.hints = data.hints?
                //     .Select(s =>
                //     {
                //         if (!Enum.TryParse(s, true, out ProcessingHintTag pht))
                //             Debug.LogError($"Unknown ProcessingHintTag '{s}' for {data.iD}");
                //         return pht;
                //     })
                //     .ToArray() ?? new ProcessingHintTag[0];

                ingredient.flavorings = data.flavorings?
                    .Select(s =>
                    {
                        if (!Enum.TryParse(s, true, out FlavoringTag ftag))
                            Debug.LogError($"Unknown FlavoringTag '{s}' for {data.iD}");
                        return ftag;
                    })
                    .ToArray() ?? new FlavoringTag[0];

                // Base SimValues
                ingredient.baseSimValues = data.baseSimValues;

                // Cooking timing
                if (!Enum.TryParse(data.cookCategory ?? CookTimeCategory.Standard.ToString(),
                                   true, out CookTimeCategory cat))
                {
                    Debug.LogError($"Unknown CookTimeCategory '{data.cookCategory}' for {data.iD}");
                    cat = CookTimeCategory.Standard;
                }
                ingredient.cookCategory  = cat;
                ingredient.cookTimeScale = data.cookTimeScale > 0
                    ? data.cookTimeScale
                    : GetDefaultScale(cat);
                ingredient.underFrac      = data.underFrac > 0
                    ? data.underFrac
                    : 0.2f;
                ingredient.overFrac       = data.overFrac > 0
                    ? data.overFrac
                    : 1.2f;

                // Flavor tags (sparse)
                ingredient.flavorTags = BuildFlavorTags(data.flavorTags, data.iD);

                // Save or update IngredientSO
                if (!AssetDatabase.Contains(ingredient))
                    AssetDatabase.CreateAsset(ingredient, assetPath);
                else
                    EditorUtility.SetDirty(ingredient);
            }

            // 3) Finalize
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[Importer] Imported {container.ingredients.Length} ingredients.");
        }

        private static float GetDefaultScale(CookTimeCategory cat)
        {
            switch (cat)
            {
                case CookTimeCategory.Fast:     return 0.7f;
                case CookTimeCategory.Standard: return 1.0f;
                case CookTimeCategory.Slow:     return 1.3f;
                default:                        return 1.0f;
            }
        }

        private static FlavorTag[] BuildFlavorTags(FlavorTagData[] tagsData, string id)
        {
            if (tagsData == null) return new FlavorTag[0];
            var list = new List<FlavorTag>(tagsData.Length);
            foreach (var ft in tagsData)
            {
                if (!Enum.TryParse(ft.archetype, true, out FlavorArchetype arc))
                {
                    Debug.LogError($"Unknown FlavorArchetype '{ft.archetype}' for {id}");
                    continue;
                }
                var lvl = IntensityLevel.Low;
                if (ft.intensity >= 0 && ft.intensity <= (int)IntensityLevel.High)
                    lvl = (IntensityLevel)ft.intensity;
                else
                    Debug.LogError($"Invalid intensity {ft.intensity} for '{ft.archetype}' on {id}");

                list.Add(new FlavorTag { archetype = arc, intensity = lvl });
            }
            return list.ToArray();
        }
    }
}
