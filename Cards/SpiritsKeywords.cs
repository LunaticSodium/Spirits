using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;

namespace Spirits.Cards;

public static class SpiritsKeywords
{
    [CustomEnum]
    public static CardKeyword Woven; //WovenPatches to Shuffle/ShuffleIfNecessary
    [CustomEnum]
    public static CardKeyword Stitch;
    [CustomEnum]
    public static CardKeyword Stitched; //applied to cards to mark them as being stitched already
    [CustomEnum]
    public static CardKeyword StoneRemnants;
    [CustomEnum]
    public static CardKeyword Flash;
    [CustomEnum]
    public static CardKeyword StaticRemnants;
    [CustomEnum]
    public static CardKeyword FireRemnant;
    [CustomEnum]
    public static CardKeyword Overload;
    [CustomEnum]
    public static CardKeyword Etherealize;
    [CustomEnum]
    public static CardKeyword Void;

    
    public static bool IsStitch(this CardModel card)
    {
        return card.Keywords.Contains(Stitch);
    }

    public static bool IsWoven(this CardModel card)
    {
        return card.Keywords.Contains(Woven);
    }

}
