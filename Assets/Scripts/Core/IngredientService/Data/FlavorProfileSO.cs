using UnityEngine;

[CreateAssetMenu(menuName = "Cooking/FlavorProfileSO")]
public class FlavorProfileSO : ScriptableObject
{
    [Tooltip("Intensity matrix [group, element] – 5 groups x 5 elements")]
    public IntensityLevel[,] Levels = new IntensityLevel[5,5];

    public string[] groupNames   = { "Taste", "Texture", "Richness", "Aroma", "Finish" };
    public string[][] ElementNames = {
        new[]{ "Sweet","Salty","Sour","Bitter","Savory" },
        new[]{ "Crunchy","Chewy","Soft","Gritty","Smooth" },
        new[]{ "Fatty","Heavy","Light","Creamy","Oily" },
        new[]{ "Earthy","Spicy","Herbal","Pungent","Fragrant" },
        new[]{ "Lingering","Sharp","Clean","Numbing","Astringent" }
    };
}