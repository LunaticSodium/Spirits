using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class Entanglement() : SpiritsCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Dex", 1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Void
        // TODO: Whenever you gain Flash/Stone/Static, also gain temporary Dex equal to DynamicVars["Dex"].BaseValue
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Dex"].UpgradeValueBy(1m);
    }
}
