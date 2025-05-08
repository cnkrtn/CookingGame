using System;
using Core.IngredientService.Enums;

namespace Core.IngredientService.Data
{
    [Serializable]
    public struct FlavorTag
    {
        public FlavorArchetype archetype;
        public IntensityLevel  intensity;
    }
}