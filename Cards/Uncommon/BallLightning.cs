using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Spirits.Cards.Uncommon;

public class BallLightning() : SpiritsCard(-1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DamageVar(0, ValueProp.Move),
        new DynamicVar("Cards", 0)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Deal 3X damage (X = energy spent)
        // TODO: Draw X cards
        // TODO: Refund 1 Energy per Attack card drawn
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: each scales by X+1 (deal 3*(X+1), draw X+1)
    }
}
