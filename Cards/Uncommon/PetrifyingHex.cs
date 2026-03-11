using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Spirits.Powers;

namespace Spirits.Cards.Uncommon;

public class PetrifyingHex() : SpiritsCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.AllEnemies)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("Weak", 3),
        new DynamicVar("Vuln", 3),
        new DynamicVar("StoneGain", 3)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        // TODO: apply Weak to all enemies equal to DynamicVars["Weak"].BaseValue
        // TODO: apply Vulnerable to all enemies equal to DynamicVars["Vuln"].BaseValue
        await PowerCmd.Apply<StoneRemnants>(Owner.Creature, DynamicVars["StoneGain"].IntValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Weak"].UpgradeValueBy(2m);
        DynamicVars["Vuln"].UpgradeValueBy(2m);
        DynamicVars["StoneGain"].UpgradeValueBy(1m);
    }
}
