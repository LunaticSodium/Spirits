using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class SmokeClears() : SpiritsCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("FlashGain", 1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Gain Flash equal to DynamicVars["FlashGain"].BaseValue, then double Flash
        // TODO: Consume
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["FlashGain"].UpgradeValueBy(1m);
    }
}
