using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Commands;

namespace Spirits.Cards.Uncommon;

public class ShatteringStrike() : SpiritsCard(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SpiritsKeywords.Void];
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(15, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        // TODO: Void keyword (currently using Exhaust, needs Void)

        CardPile hand = PileType.Hand.GetPile(Owner);
        List<CardModel> candidates = hand.Cards.Where(c => c != this).ToList();
        int toConsume = 2;
        for (int i = 0; i < toConsume && candidates.Count > 0; ++i)
        {
            CardModel pick = Owner.RunState.Rng.CombatCardSelection.NextItem(candidates);
            candidates.Remove(pick);
            await CardPileCmd.Add(pick, PileType.Exhaust);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(5m);
    }
}
