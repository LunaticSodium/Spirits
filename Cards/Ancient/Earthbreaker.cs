using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Spirits.Cards.Ancient;

public class Earthbreaker() : SpiritsCard(0, CardType.Attack, CardRarity.Ancient, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DamageVar(6, ValueProp.Move),
        new BlockVar(4, ValueProp.Move),
        new DynamicVar("PlatedArmor", 2),
        new DynamicVar("VulnAmount", 1)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        await CommonActions.CardBlock(this, play);
        // TODO: apply PlatedArmor equal to DynamicVars["PlatedArmor"].BaseValue
        // TODO: apply Vulnerable equal to DynamicVars["VulnAmount"].BaseValue
        // TODO: draw 1 card
        // TODO: [Repeat once] — repeat entire sequence once
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(1m);
        DynamicVars.Block.UpgradeValueBy(1m);
        DynamicVars["PlatedArmor"].UpgradeValueBy(1m);
    }
}
