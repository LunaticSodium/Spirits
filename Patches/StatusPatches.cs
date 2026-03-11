using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Models;
using Spirits.Powers;
using System.Linq;
using System.Threading.Tasks;

namespace Spirits.Patches;

[HarmonyPatch(typeof(PowerCmd), nameof(PowerCmd.ModifyAmount))]
public static class StoneRemnantCapPatch
{
    [HarmonyPostfix]
    public static async void EnforceCap(PowerModel power)
    {
        if (power == null) return;
        if (power.Id != ModelDb.Power<StoneRemnants>().Id) return;
        const int cap = 7;
        if (power.Amount > cap)
        {
            await PowerCmd.ModifyAmount(power, cap - power.Amount, null, null);
        }
        else if (power.Amount < 0)
        {
            await PowerCmd.ModifyAmount(power, -power.Amount, null, null);
        }
    }
}

[HarmonyPatch(typeof(Hook), nameof(Hook.BeforeCardPlayed))]
public static class OverloadOnSkillPatch
{
    [HarmonyPostfix]
    public static async void GainOverload(CombatState combatState, CardPlay cardPlay)
    {
        if (cardPlay?.Card == null) return;
        if (cardPlay.Card.Type != CardType.Skill) return;
        Creature owner = cardPlay.Card.Owner?.Creature;
        if (owner == null) return;
        await PowerCmd.Apply<Overload>(owner, 1, owner, cardPlay.Card);
    }
}

[HarmonyPatch(typeof(Hook), nameof(Hook.BeforeCardPlayed))]
public static class OverloadAttackTriggerPatch
{
    [HarmonyPostfix]
    public static async void GainStaticOnAttack(CombatState combatState, CardPlay cardPlay)
    {
        if (cardPlay?.Card == null) return;
        if (cardPlay.Card.Type != CardType.Attack) return;
        Creature owner = cardPlay.Card.Owner?.Creature;
        if (owner == null) return;
        PowerModel overload = owner.Powers.FirstOrDefault(p => p.Id == ModelDb.Power<Overload>().Id);
        if (overload == null || overload.Amount <= 0) return;
        await PowerCmd.Apply<StaticRemnants>(owner, overload.Amount * 4, owner, cardPlay.Card);
    }
}
