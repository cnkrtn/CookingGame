using Core.IngredientService.Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Cooking/IngredientSO")]
public class IngredientSO : ScriptableObject
{
    // — Identity —
    [Header("Identity")]
    [Tooltip("Unique key, e.g. \"Carrot\"")]
    public string ingredientId;
    public string displayName;
    public Sprite icon;

    // — Classification —
    [Header("Classification")]
    [Tooltip("High-level category: Vegetable, Meat, Grain, etc.")]
    public IngredientType categoryTag;
    [Tooltip("Physical form: Liquid, Solid, Starch, Flour")]
    public PhysicalStateTag[] physicalStateTags;
    [Tooltip("Special‐case processing hints (e.g. Pickleable, Smokeable)")]
    public ProcessingHintTag[] processingHints;

    // — Flavor Simulation —
    [Header("Flavor Simulation")]
    [Tooltip("Base sim values: sweet, sour, bitter, salt, umami, aroma, spice, fat, crunch, moisture")]
    public SimValues baseSimValues;

    // — Default Flavor Tags (computed from baseSimValues) —
    [Header("Default Flavor Tags")]
    [Tooltip("Auto-computed badges like Sweet, Crunchy, Juicy…")]
    public FlavorArchetype[] defaultFlavorTags;

    // — Cook-Time Scaling —
    [Header("Timing")]
    [Tooltip("Multiplier on every ActionSO.BaseDurationTU for this ingredient")]
    public float hardnessFactor = 1f;
}