// Assets/Editor/MidArchetypeSOImporter.cs

using System.IO;
using System.Linq;
using Core.MidArchtypeService.Data;
using Core.ToolsAndActionsService.Data;
using Core.ToolsAndActionsService.Enums;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MidArchetypeSOImporter : AssetPostprocessor
    {
        private static readonly string JSON_PATH = 
            Path.Combine(Application.dataPath, "StreamingAssets", "midArchetypes.json");

        private const string OUTPUT_FOLDER  = "Assets/Cooking/SOs/MidArchetypes/";
        private const string TOOLS_FOLDER   = "Assets/Cooking/SOs/Tools/";
        private const string ACTIONS_FOLDER = "Assets/Cooking/SOs/Actions/";
    
        [MenuItem("Tools/Import MidArchetype SOs")]
        public static void ImportAll()
        {
            if (!File.Exists(JSON_PATH))
            {
                Debug.LogError($"MidArchetype JSON not found at: {JSON_PATH}");
                return;
            }

            if (!Directory.Exists(OUTPUT_FOLDER))
                Directory.CreateDirectory(OUTPUT_FOLDER);

            var json    = File.ReadAllText(JSON_PATH);
            var wrapper = JsonUtility.FromJson<Wrapper>(json);

            foreach (var def in wrapper.archetypes)
            {
                var path = $"{OUTPUT_FOLDER}{def.archetypeName}.asset";
                var so   = AssetDatabase.LoadAssetAtPath<MidArchetypeSO>(path)
                           ?? ScriptableObject.CreateInstance<MidArchetypeSO>();

                // Core Info
                so.archetypeName   = def.archetypeName;
                so.requiredTool    = AssetDatabase.LoadAssetAtPath<ToolSO>(
                    $"{TOOLS_FOLDER}{def.requiredTool}.asset");
                so.requiredActions = def.requiredActions
                    .Select(name => AssetDatabase.LoadAssetAtPath<ActionSO>(
                        $"{ACTIONS_FOLDER}{name}.asset"))
                    .Where(a => a != null)
                    .ToArray();

                // Filters
                so.allowedIngredientTypes = def.allowedIngredientTypes
                    .Select(s => (IngredientType)System.Enum.Parse(typeof(IngredientType), s))
                    .ToArray();
                so.allowedPhysicalStates  = def.allowedPhysicalStates
                    .Select(s => (PhysicalStateTag)System.Enum.Parse(typeof(PhysicalStateTag), s))
                    .ToArray();

                // Prerequisites
                so.requiredMidArchetypes = def.requiredMidArchetypes
                    .Select(name => AssetDatabase.LoadAssetAtPath<MidArchetypeSO>(
                        $"{OUTPUT_FOLDER}{name}.asset"))
                    .Where(m => m != null)
                    .ToArray();

                // Results
                so.resultingPrepareTags  = def.resultingPrepareTags
                    .Select(s => (PrepareProcessTag)System.Enum.Parse(typeof(PrepareProcessTag), s))
                    .ToArray();
                so.resultingCookingTags  = def.resultingCookingTags
                    .Select(s => (CookingProcessTag)System.Enum.Parse(typeof(CookingProcessTag), s))
                    .ToArray();
                so.resultingAssemblyTags = def.resultingAssemblyTags
                    .Select(s => (AssemblyProcessTag)System.Enum.Parse(typeof(AssemblyProcessTag), s))
                    .ToArray();

                // Composition + State
                so.allowMultipleIngredients = def.allowMultipleIngredients;
                so.resultingPhysicalState   = (PhysicalStateTag)System.Enum.Parse(
                    typeof(PhysicalStateTag), def.resultingPhysicalState);

                // Create or update asset
                if (AssetDatabase.Contains(so))
                    EditorUtility.SetDirty(so);
                else
                    AssetDatabase.CreateAsset(so, path);
            }

            AssetDatabase.SaveAssets();
            Debug.Log($"Imported {wrapper.archetypes.Count} MidArchetypeSO assets.");
        }

        // JSON helper classes
        [System.Serializable]
        private class Wrapper
        {
            public System.Collections.Generic.List<Def> archetypes;
        }

        [System.Serializable]
        private class Def
        {
            public string archetypeName;
            public string requiredTool;
            public System.Collections.Generic.List<string> requiredActions;
            public string[] allowedIngredientTypes;
            public string[] allowedPhysicalStates;
            public System.Collections.Generic.List<string> requiredMidArchetypes;
            public string[] resultingPrepareTags;
            public string[] resultingCookingTags;
            public string[] resultingAssemblyTags;
            public bool   allowMultipleIngredients;
            public string resultingPhysicalState;
        }
    }
}
