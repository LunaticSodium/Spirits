using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class Craving() : SpiritsCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("HpLoss", 3),
        new DynamicVar("Cards", 2),
        new DynamicVar("Energy", 1)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Lose DynamicVars["HpLoss"].BaseValue HP
        await CommonActions.Draw(this, choiceContext);
        // TODO: gain Energy equal to DynamicVars["Energy"].BaseValue
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
