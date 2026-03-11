using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class ThousandCrags() : SpiritsCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("StoneGain", 1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: At end of turn, gain StoneGain Stone Remnants
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["StoneGain"].UpgradeValueBy(1m);
    }
}
