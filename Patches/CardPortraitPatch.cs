using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Cards;
using Spirits.Cards;

namespace Spirits.Patches;

/// <summary>
/// Forces the portrait TextureRect to KeepAspectCovered (fills + centers, crops edges)
/// for Spirits cards, so custom PNG art fills the full portrait zone instead of letterboxing.
/// </summary>
[HarmonyPatch(typeof(NCard), "Reload")]
class CardPortraitFillPatch
{
    static readonly System.Reflection.FieldInfo PortraitField =
        AccessTools.Field(typeof(NCard), "_portrait");

    static readonly System.Reflection.FieldInfo AncientPortraitField =
        AccessTools.Field(typeof(NCard), "_ancientPortrait");

    [HarmonyPostfix]
    static void FillPortrait(NCard __instance)
    {
        if (__instance.Model is not SpiritsCard) return;

        if (PortraitField?.GetValue(__instance) is TextureRect portrait)
            portrait.StretchMode = TextureRect.StretchModeEnum.KeepAspectCovered;

        if (AncientPortraitField?.GetValue(__instance) is TextureRect ancientPortrait)
            ancientPortrait.StretchMode = TextureRect.StretchModeEnum.KeepAspectCovered;
    }
}
