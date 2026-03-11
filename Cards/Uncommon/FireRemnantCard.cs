using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

// NOTE: class name is FireRemnantCard to avoid clash with FireRemnant power status
public class FireRemnantCard() : SpiritsCard(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("FireGain", 1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: gain Fire Remnant equal to DynamicVars["FireGain"].BaseValue
        // TODO: If no Activate Fire Remnant in hand, add one to hand
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["FireGain"].UpgradeValueBy(1m);
    }
}
