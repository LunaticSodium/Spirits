using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Spirits.Cards.Rare;

public class EverFirm() : SpiritsCard(3, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new BlockVar(30, ValueProp.Move),
        new DynamicVar("PlatedArmor", 6),
        new DynamicVar("BlockBonus", 10)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: gain Plated Armor equal to DynamicVars["PlatedArmor"].IntValue
        // TODO: gain Block equal to DynamicVars.Block.IntValue [DynamicVars.Block.IntValue + DynamicVars["BlockBonus"].IntValue if Stone Remnant consumed]
        // TODO: at start of next turn, return this card to hand
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(10m);
        DynamicVars["PlatedArmor"].UpgradeValueBy(2m);
    }
}
