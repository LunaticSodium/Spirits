using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Spirits.Cards.Token;

public class ReturnItInKind() : SpiritsCard(0, CardType.Skill, CardRarity.Token, TargetType.AnyEnemy, showInCardLibrary: false)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SpiritsKeywords.Void];
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("WeakAmount", 2),
        new DynamicVar("VulnAmount", 2),
        new DynamicVar("BlockMult", 2)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        if (play.Target == null || Owner?.Creature == null) return;
        // TODO: Strength→Weak and Dex→Vulnerable branches
        if (play.Target.Block > 0)
        {
            int bonus = play.Target.Block * DynamicVars["BlockMult"].IntValue;
            await CreatureCmd.Damage(choiceContext, play.Target, bonus, ValueProp.Move, Owner.Creature, this);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars["WeakAmount"].UpgradeValueBy(1m);
        DynamicVars["VulnAmount"].UpgradeValueBy(1m);
        DynamicVars["BlockMult"].UpgradeValueBy(1m);
    }
}
