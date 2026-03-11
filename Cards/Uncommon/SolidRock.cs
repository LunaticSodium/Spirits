using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Spirits.Cards.Uncommon;

public class SolidRock() : SpiritsCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("PlatedArmor", 6),
        new BlockVar(8, ValueProp.Move)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        await CommonActions.CardBlock(this, play);
        // TODO: gain Plated Armor 6
        // TODO: [Block 16] Stone Remnant enhanced branch
    }

    protected override void OnUpgrade()
    {
        DynamicVars["PlatedArmor"].UpgradeValueBy(2m);
        DynamicVars.Block.UpgradeValueBy(8m);
    }
}
