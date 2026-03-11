using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Common;

public class EmberBrew() : SpiritsCard(0, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("HpLoss", 4),
        new DynamicVar("FlashGain", 1),
        new DynamicVar("StrGain", 2)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Lose HP equal to DynamicVars["HpLoss"].BaseValue
        // TODO: gain Flash equal to DynamicVars["FlashGain"].BaseValue
        // TODO: gain Strength equal to DynamicVars["StrGain"].BaseValue
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: upgrade effect (reduce hp cost or increase gains)
    }
}
