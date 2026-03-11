using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using System.Linq;
using Spirits.Powers;

namespace Spirits.Cards.Common;

public class PulseCard() : SpiritsCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(6, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        var owner = Owner?.Creature;
        if (owner == null || play.Target == null) return;
        var staticRemnants = owner.Powers.FirstOrDefault(p => p.Id == ModelDb.Power<StaticRemnants>().Id)?.Amount ?? 0;
        if (staticRemnants > 0)
        {
            await CreatureCmd.Damage(choiceContext, play.Target, staticRemnants, ValueProp.Move, owner, this);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3m);
    }
}
