using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Common;

public class Energize() : SpiritsCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("Cards", 2),
        new DynamicVar("StaticGain", 7)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.Draw(this, choiceContext);
        // TODO: gain Static Remnants equal to DynamicVars["StaticGain"].BaseValue
    }

    protected override void OnUpgrade()
    {
        DynamicVars["StaticGain"].UpgradeValueBy(2m);
        // TODO: Cards count unchanged on upgrade
    }
}
