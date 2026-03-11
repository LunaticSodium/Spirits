using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Spirits.Cards.Uncommon;

public class Magnetize() : SpiritsCard(-1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: Consume all Stone Remnants. For each stack: gain X Plated Armor, gain 1 Energy.
    }

    protected override void OnUpgrade()
    {
        // TODO: each stack gives X+1 Plated Armor
    }
}
