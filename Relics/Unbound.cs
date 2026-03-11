using MegaCrit.Sts2.Core.Entities.Relics;

namespace Spirits.Relics;

public class Unbound : SpiritsRelic
{
    public override RelicRarity Rarity => RelicRarity.Rare; // TODO: RelicRarity.Boss/BossReward does not exist — using Rare as placeholder
    // TODO: implement Unbound effect (Boss Reward relic — use RelicRarity.BossReward if it exists)
}
