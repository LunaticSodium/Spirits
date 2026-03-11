using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Rare;

public class BoulderForm() : SpiritsCard(3, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Etherealize (gain Intangible 1)
        // TODO: Immune to Vulnerable/Frail/Weak
        // TODO: Consume all Stone Remnants
        // TODO: gain Block = 8x Stone Remnants, PlatedArmor = 4x, Str = 2x
        // TODO: Retain
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: upgrade effect
    }
}
