// Assets/Editor/ToolImporter.cs

using System;
using System.IO;
using System.Linq;
using Core.ToolsAndActionsService.Data;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public static class ToolImporter
    {
        private static readonly string JsonPath = Path.Combine(Application.dataPath, "StreamingAssets", "tools.json");
        private const string AssetRoot  = "Assets/Cooking/SOs/Tools/";

        [MenuItem("Cooking/Import Tools")]
        public static void Import()
        {
            if (!File.Exists(JsonPath))
            {
                Debug.LogError($"Tool JSON not found at: {JsonPath}");
                return;
            }

            // Read and parse JSON
            var text = File.ReadAllText(JsonPath);
            var container = JsonUtility.FromJson<Container>(text);
            if (container?.tools == null || container.tools.Length == 0)
            {
                Debug.LogWarning("No tools found in JSON.");
                return;
            }

            // Ensure target folder exists
            if (!Directory.Exists(AssetRoot))
                Directory.CreateDirectory(AssetRoot);

            foreach (var t in container.tools)
            {
                var so = ScriptableObject.CreateInstance<ToolSO>();
                so.toolId          = t.id;
                so.displayName     = t.name;
                so.speedModifier   = t.speedModifier;
                so.qualityModifier = t.qualityModifier;

                // Wire up allowed actions
                so.allowedActions = t.allowedActions
                    .Select(FindActionSO)
                    .Where(a => a != null)
                    .ToArray();

                // Safely parse ingredient-type enums
                so.allowedIngredientTypes = t.allowedIngredientTypes
                    .Select(s =>
                    {
                        if (Enum.TryParse<IngredientType>(s, true, out var it)) 
                            return (IngredientType?)it;
                        Debug.LogWarning($"Unknown IngredientType '{s}' in tool '{t.id}'");
                        return null;
                    })
                    .Where(e => e.HasValue)
                    .Select(e => e.Value)
                    .ToArray();

                // Safely parse physical-state enums
                so.allowedPhysicalStates = t.allowedPhysicalStates
                    .Select(s =>
                    {
                        if (Enum.TryParse<PhysicalStateTag>(s, true, out var ps)) 
                            return (PhysicalStateTag?)ps;
                        Debug.LogWarning($"Unknown PhysicalStateTag '{s}' in tool '{t.id}'");
                        return null;
                    })
                    .Where(e => e.HasValue)
                    .Select(e => e.Value)
                    .ToArray();

                // Save asset
                var assetPath = $"{AssetRoot}{t.id}SO.asset";
                AssetDatabase.CreateAsset(so, assetPath);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"Imported {container.tools.Length} tools to {AssetRoot}");
        }

        // Helper: find ActionSO by its actionId
        private static ActionSO FindActionSO(string actionId)
        {
            var guids = AssetDatabase.FindAssets($"t:ActionSO {actionId}");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var action = AssetDatabase.LoadAssetAtPath<ActionSO>(path);
                if (action != null && action.actionId.Equals(actionId, StringComparison.OrdinalIgnoreCase))
                    return action;
            }
            Debug.LogWarning($"ActionSO not found for id: {actionId}");
            return null;
        }

        // JSON container classes
        [Serializable]
        private class Container
        {
            public ToolJson[] tools;
        }

        [Serializable]
        private class ToolJson
        {
            public string   id;
            public string   name;
            public string[] allowedActions;
            public float    speedModifier   = 1f;
            public float    qualityModifier = 0f;
            public string[] allowedIngredientTypes;
            public string[] allowedPhysicalStates;
        }
    }
}
