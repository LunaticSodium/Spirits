using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Rare;

public class WindFillsTower() : SpiritsCard(0, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("StaticGain", 10)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        // TODO: Consume
        // TODO: gain Static Remnants equal to DynamicVars["StaticGain"].BaseValue
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["StaticGain"].UpgradeValueBy(3m);
    }
}
