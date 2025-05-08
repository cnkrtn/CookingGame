using Core.ToolsAndActionsService.Data;
using Core.ToolsAndActionsService.Enums;
using UnityEngine;

namespace Core.MidArchtypeService.Data
{
    [CreateAssetMenu(menuName = "Cooking/MidArchetype")]
    public class MidArchetypeSO : ScriptableObject
    {
        [Header("Core Info")]
        public string           archetypeName;
        public ToolSO           requiredTool;
        public ActionSO[]       requiredActions;

        [Header("Input Filters")]
        public IngredientType[]   allowedIngredientTypes;
        public PhysicalStateTag[] allowedPhysicalStates;

        [Header("Prerequisites")]
        public MidArchetypeSO[]   requiredMidArchetypes;

        [Header("Resulting Process Tags")]
        public PrepareProcessTag[]  resultingPrepareTags;
        public CookingProcessTag[]  resultingCookingTags;
        public AssemblyProcessTag[] resultingAssemblyTags;

        [Header("Composition")]
        public bool               allowMultipleIngredients;

        [Header("Physical State")]
        public PhysicalStateTag   resultingPhysicalState;
    }

}