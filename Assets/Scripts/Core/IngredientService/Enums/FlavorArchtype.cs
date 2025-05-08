namespace Core.IngredientService.Enums
{
    /// <summary>
    /// All flavor archetypes—atomic and composite—mapped to sim-value rules
    /// </summary>
    public enum FlavorArchetype
    {
        // —— Primary tastes ——  
        Sweet,      // v.Sweetness ≥ 0.30  
        Salty,      // v.Saltiness ≥ 0.25  
        Sour,       // v.Sourness ≥ 0.30  
        Bitter,     // v.Bitterness ≥ 0.20  
        Savory,     // v.Umami ≥ 0.40  

        // —— Heat & aroma ——  
        Spicy,      // v.Spice ≥ 0.20  
        Aromatic,   // v.Aroma ≥ 0.35  

        // —— Texture & mouthfeel ——  
        Crunchy,    // v.Crunch ≥ 0.20  
        Juicy,      // v.Moisture ≥ 0.60  
        Creamy,     // v.Fat ≥ 0.30 && v.Moisture ≥ 0.70  

        // —— Composite descriptors ——  
        Hearty,       // v.Umami ≥ 0.40 && v.Moisture ≥ 0.60  
        Comforting,   // Creamy && Savory && Juicy  
        Indulgent,    // v.Fat ≥ 0.35 && v.Moisture ≥ 0.70 && v.Aroma ≥ 0.45  
        Zesty,        // v.Sourness ≥ 0.30 && v.Spice ≥ 0.20 && v.Aroma ≥ 0.35  
        Refreshing,   // v.Moisture ≥ 0.60 && v.Sourness ≥ 0.25 && v.Bitterness ≤ 0.10  
        Crisp,        // v.Crunch ≥ 0.25 && v.Moisture ≤ 0.40  
        Silky,        // v.Fat ≥ 0.30 && v.Moisture ≥ 0.80 && v.Crunch < 0.10  
        Bold,         // v.Spice ≥ 0.30 && v.Aroma ≥ 0.40 && v.Umami ≥ 0.40  
        Smoky         // v.Aroma ≥ 0.45 && v.Bitterness ≥ 0.10  
    }
}