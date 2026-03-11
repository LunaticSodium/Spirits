using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Uncommon;

public class DrunkenFist() : SpiritsCard(-1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("HpLoss", 1),
        new DynamicVar("Dex", 2),
        new DynamicVar("Str", 2)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: X times: Lose 1 HP, gain 2 Dex, gain 2 Str
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: X+1 times instead
    }
}
