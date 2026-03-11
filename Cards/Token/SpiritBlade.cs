using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using System.Linq;
using Spirits.Powers;
using BaseLib.Utils;

namespace Spirits.Cards.Token;

public class SpiritBlade() : SpiritsCard(0, CardType.Attack, CardRarity.Token, TargetType.AnyEnemy, showInCardLibrary: false)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Retain];
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DamageVar(8, ValueProp.Move),
        new DynamicVar("StaticGain", 4)
        ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);

        var owner = Owner?.Creature;
        if (owner == null) return;

        int gain = DynamicVars["StaticGain"].IntValue;
        await PowerCmd.Apply<StaticRemnants>(owner, gain, owner, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(2m);
        DynamicVars["StaticGain"].UpgradeValueBy(1m);
    }
}
