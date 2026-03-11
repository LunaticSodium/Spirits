using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Spirits.Cards.Rare;

public class EverFirm() : SpiritsCard(3, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("PlatedArmor", 7)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: gain Plated Armor equal to DynamicVars["PlatedArmor"].BaseValue
        // TODO: immediately gain Block equal to current Plated Armor value
        await Task.CompletedTask;
    }

    protected override void OnUpgrade()
    {
        DynamicVars["PlatedArmor"].UpgradeValueBy(2m);
    }
}
