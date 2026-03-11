using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Uncommon;

public class Ionization() : SpiritsCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        // TODO: After Static Remnants trigger, gain 4 Static Remnants
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: upgrade effect
    }
}
