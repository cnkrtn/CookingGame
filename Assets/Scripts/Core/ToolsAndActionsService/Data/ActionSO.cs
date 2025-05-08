using Core.ToolsAndActionsService.Enums;
using UnityEngine;

namespace Core.ToolsAndActionsService.Data
{
    [CreateAssetMenu(menuName = "Cooking/Action")]
    public class ActionSO : ScriptableObject
    {
        [Header("Identity")]
        public string            actionId;
        public string            displayName;
        public Sprite            icon;

        [Header("Process Tags (results)")]
        public PrepareProcessTag[]  prepareTags;
        public CookingProcessTag[]  cookingTags;
        public AssemblyProcessTag[] assemblyTags;

        [Header("Validation Rules")]
        [Tooltip("These tags must NOT be present on the input or we skip this action")]
        public PrepareProcessTag[]  forbiddenPrepareTags;
        public CookingProcessTag[]  forbiddenCookingTags;
        public AssemblyProcessTag[] forbiddenAssemblyTags;

        [Header("Simulation Modifiers")]
        public SimValues           simValueModifiers;
    }
}