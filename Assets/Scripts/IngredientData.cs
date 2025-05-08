using System;

/// <summary>
/// 1-to-1 match with the JSON produced for IngredientSO creation.
/// </summary>
[Serializable]
public class IngredientData
{
    // ─── Identity ────────────────────────────────────────────────
    public string   iD;                 // "carrot"  ← EXACT match
    public string   ingredientName;     // "Carrot"

    // ─── Classification ─────────────────────────────────────────
    public string   type;               // IngredientType enum name
    public string[] physicalStates;     // PhysicalStateTag enum names
    public string[] hints;              // ProcessingHintTag enum names
    public string[] flavorings;         // FlavoringTag enum names

    // ─── Flavour simulation values ──────────────────────────────
    public SimValues        baseSimValues;   // 10-dim struct
    public FlavorTagData[]  flavorTags;      // sparse tags

    // ─── Cooking-timing data ────────────────────────────────────
    public string cookCategory;          // CookTimeCategory enum name
    public float  cookTimeScale;         // 1.0, 0.75, etc.
    public float  underFrac;             // e.g. 0.2
    public float  overFrac;              // e.g. 1.2
}