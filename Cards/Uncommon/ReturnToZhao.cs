using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Commands;
using Spirits.Powers;

namespace Spirits.Cards.Uncommon;

public class ReturnToZhao() : SpiritsCard(3, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DamageVar(24, ValueProp.Move),
        new BlockVar("BranchBlock", 16, ValueProp.Move),
        new DynamicVar("StoneGain", 3)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        if (play.Target != null && play.Target.IsDead)
        {
            await PowerCmd.Apply<StoneRemnants>(Owner.Creature, DynamicVars["StoneGain"].BaseValue, Owner.Creature, this);
        }
        else
        {
            await CommonActions.CardBlock(this, (BlockVar) DynamicVars["BranchBlock"], play);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(6m);
        DynamicVars["BranchBlock"].UpgradeValueBy(4m);
        DynamicVars["StoneGain"].UpgradeValueBy(1m);
    }
}
