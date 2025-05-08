using System;
using UnityEngine;

/// <summary>
/// Core simulation inputs for flavor and texture modeling.
/// Values typically range 0–1 (but can exceed 1 for very intense cases).
/// </summary>
[Serializable]
public struct SimValues
{
    [Tooltip("Perceived sweetness level.")]
    public float sweetness;  

    [Tooltip("Perceived sour/tart level.")]
    public float sourness;   

    [Tooltip("Perceived bitterness level.")]
    public float bitterness; 

    [Tooltip("Perceived saltiness level.")]
    public float saltiness;  

    [Tooltip("Perceived savory/umami depth.")]
    public float savoury;      

    [Tooltip("Overall aromatic intensity.")]
    public float aroma;      

    [Tooltip("Perceived spiciness/heat.")]
    public float spice;      

    [Tooltip("Perceived richness/fat content.")]
    public float fat;        

    [Tooltip("Perceived crispness or crunch.")]
    public float crunch;     

    [Tooltip("Perceived juiciness or moisture.")]
    public float moisture;   
}