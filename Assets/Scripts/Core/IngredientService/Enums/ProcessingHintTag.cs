
/// <summary>Processing hints for how an ingredient should be handled or prepared.</summary>
public enum ProcessingHintTag
{
    Raw,            // Can be eaten as-is
    Fresh,  
    Dried,         // Best used just-harvested

    // Cutting & slicing
    ToBePeeled,     // Remove skin or rind first
    ToBeChopped,    // Rough chop into pieces
    ToBeSliced,     // Cut into slices
    ToBeDiced,      // Cut into uniform cubes
    ToBeMinced,     // Chop very finely
    ToBeJulienned,  // Cut into matchsticks

    // Flavor infusions & finishing
    ToBeMarinated,  // Pre-soak before cooking
    ToBeGarnish,    // Hold back for plating/finish

    // Mortar & pestle / bowl actions
    ToBeCrushed,     // Coarsely break into fragments
    ToBeGround,      // Pulverize into granules
    ToBePowderized,  // Mill into fine powder
    ToBePureed,      // Smooth into a paste
    ToBeMashed,      // Break down into soft lumps

   
}
