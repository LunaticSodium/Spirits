using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Uncommon;

public class ThousandCrags() : SpiritsCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: At end of turn, gain 1 Stone Remnants (2 when upgraded)
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        // TODO: end-of-turn gain becomes 2 Stone Remnants
    }
}
