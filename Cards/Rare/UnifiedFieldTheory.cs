using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Rare;

public class UnifiedFieldTheory() : SpiritsCard(0, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Innate
        // TODO: Void
        // TODO: At start of turn, randomly gain Flash 1, Stone Remnants 2, or Static Remnants 4
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: upgrade effect
    }
}
