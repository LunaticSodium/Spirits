using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Rare;

public class Bulwark() : SpiritsCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("StaticGain", 7)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: gain Static Remnants equal to DynamicVars["StaticGain"].BaseValue
        // TODO: gain Block equal to current Static Remnants total
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["StaticGain"].UpgradeValueBy(3m);
    }
}
