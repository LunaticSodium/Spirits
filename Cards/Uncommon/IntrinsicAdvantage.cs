using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class IntrinsicAdvantage() : SpiritsCard(0, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Heal", 3)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        // TODO: Gain 1 Energy and heal DynamicVars["Heal"].BaseValue HP
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Heal"].UpgradeValueBy(3m);
    }
}
