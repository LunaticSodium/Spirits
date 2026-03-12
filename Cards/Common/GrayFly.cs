using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Spirits.Powers;

namespace Spirits.Cards.Common;

public class GrayFly() : SpiritsCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("Cards", 4),
        new DynamicVar("FlashGain", 2)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.Draw(this, choiceContext);
        await PowerCmd.Apply<Flash>(Owner.Creature, DynamicVars["FlashGain"].IntValue, Owner.Creature, this);
        // TODO: Consume
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Cards"].UpgradeValueBy(2m);
    }
}
