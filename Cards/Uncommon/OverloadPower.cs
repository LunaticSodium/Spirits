using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Uncommon;

// NOTE: class name is OverloadPower to avoid clash with Overload power status in Powers/
public class OverloadPower() : SpiritsCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        // TODO: After using a Skill, gain 1 Overload
        // TODO: Overload cap = Overload stacks (self-scaling cap)
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: upgrade effect
    }
}
