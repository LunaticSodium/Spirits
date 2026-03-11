using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using System.Linq;
using Spirits.Powers;

namespace Spirits.Cards.Token;

public class ActivateFireRemnant() : SpiritsCard(1, CardType.Skill, CardRarity.Token, TargetType.Self, showInCardLibrary: false)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Retain];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        var owner = Owner?.Creature;
        if (owner == null) return;

        PowerModel fr = owner.Powers.FirstOrDefault(p => p.Id == ModelDb.Power<FireRemnant>().Id);
        int stacks = fr?.Amount ?? 0;
        if (stacks > 0)
        {
            await PowerCmd.Apply<Flash>(owner, stacks, owner, this);
            await PowerCmd.ModifyAmount(fr, -stacks, owner, this);
        }
    }
}
