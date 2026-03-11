using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Common;

public class SpotTheOpening() : SpiritsCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("Dex", 3),
        new DynamicVar("FlashGain", 1)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: If an enemy intends to attack, gain Dex equal to DynamicVars["Dex"].BaseValue and Flash equal to DynamicVars["FlashGain"].BaseValue
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Dex"].UpgradeValueBy(1m);
    }
}
