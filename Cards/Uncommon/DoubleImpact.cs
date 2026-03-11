using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Commands;
using Spirits.Powers;
using System.Linq;

namespace Spirits.Cards.Uncommon;

public class DoubleImpact() : SpiritsCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(15, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        CardPile discard = PileType.Discard.GetPile(Owner);
        var attacks = discard.Cards.Where(c => c.Type == CardType.Attack).ToList();
        if (attacks.Count > 0)
        {
            var pick = Owner.RunState.Rng.CombatCardSelection.NextItem(attacks);
            await CardPileCmd.Add(pick, PileType.Hand);
        }
        await PowerCmd.Apply<Flash>(Owner.Creature, 2, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3m);
    }
}
