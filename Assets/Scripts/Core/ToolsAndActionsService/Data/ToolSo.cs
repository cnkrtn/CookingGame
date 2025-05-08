using UnityEngine;

namespace Core.ToolsAndActionsService.Data
{
    [CreateAssetMenu(menuName = "Cooking/Tool")]
    public class ToolSO : ScriptableObject
    {
        [Header("Identity")] public string toolId;
        public string displayName;
        public Sprite icon;

        [Header("Speed & Quality")] 
        public float speedModifier = 1f;
        public float qualityModifier = 0f;

        [Header("Allowed Actions")] 
        public ActionSO[] allowedActions;

        [Header("Ingredient Exception")] 
        public IngredientSO[] exceptionIngredients;

        [Header("Input Filters")] 
        public IngredientType[] allowedIngredientTypes;
        public PhysicalStateTag[] allowedPhysicalStates;
    }
}


