// Assets/Editor/ActionImporter.cs

using System;
using System.IO;
using System.Linq;
using Core.ToolsAndActionsService.Data;
using Core.ToolsAndActionsService.Enums;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public static class ActionImporter
    {
        private static readonly string JsonPath  = Path.Combine(Application.streamingAssetsPath, "actions.json");
        private const string AssetRoot = "Assets/Cooking/SOs/Actions/";

        [MenuItem("Cooking/Import Actions")]
        public static void Import()
        {
            if (!File.Exists(JsonPath))
            {
                Debug.LogError($"[ActionImporter] JSON not found → {JsonPath}");
                return;
            }

            var jsonText  = File.ReadAllText(JsonPath);
            var container = JsonUtility.FromJson<Container>(jsonText);
            if (container?.actions == null || container.actions.Length == 0)
            {
                Debug.LogWarning("[ActionImporter] No actions found in JSON.");
                return;
            }

            if (!Directory.Exists(AssetRoot))
                Directory.CreateDirectory(AssetRoot);

            foreach (var a in container.actions)
            {
                var assetPath = $"{AssetRoot}{a.id}SO.asset";
                var so = AssetDatabase.LoadAssetAtPath<ActionSO>(assetPath)
                         ?? ScriptableObject.CreateInstance<ActionSO>();

                // Identity
                so.actionId    = a.id;
                so.displayName = a.name;
                // so.icon    = ...  // optional: assign manually or add logic here

                // Process tags
                so.prepareTags   = ParseEnumArray<PrepareProcessTag>(a.prepareTags);
                so.cookingTags   = ParseEnumArray<CookingProcessTag>(a.cookingTags);
                so.assemblyTags  = ParseEnumArray<AssemblyProcessTag>(a.assemblyTags);

                // Flavor simulation
                so.simValueModifiers = a.simModifiers;

                // Save or update asset
                if (!AssetDatabase.Contains(so))
                    AssetDatabase.CreateAsset(so, assetPath);

                EditorUtility.SetDirty(so);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"[ActionImporter] Imported/updated {container.actions.Length} ActionSO assets.");
        }

        private static T[] ParseEnumArray<T>(string[] src) where T : struct
        {
            if (src == null || src.Length == 0) return Array.Empty<T>();
            return src
                .Select(s =>
                {
                    if (Enum.TryParse<T>(s, ignoreCase: true, out var val))
                        return (T?)val;
                    Debug.LogWarning($"[ActionImporter] Failed to parse '{s}' as {typeof(T).Name}");
                    return null;
                })
                .Where(v => v.HasValue)
                .Select(v => v.Value)
                .ToArray();
        }

        [Serializable]
        private class Container { public ActionJson[] actions; }

        [Serializable]
        private class ActionJson
        {
            public string      id;
            public string      name;
            public string[]    prepareTags;
            public string[]    cookingTags;
            public string[]    assemblyTags;
            public SimValues   simModifiers;
        }
    }
}
