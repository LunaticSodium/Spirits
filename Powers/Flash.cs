using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using System.Threading.Tasks;

namespace Spirits.Powers;

public sealed class Flash : SpiritsPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        if (Amount < 4) return;

        await PowerCmd.Apply<IntangiblePower>(Owner, 1, null, null);
        await PowerCmd.ModifyAmount(this, -4, null, null);

        if (Owner.IsPlayer)
        {
            PlayerCmd.EndTurn(Owner.Player, false);
        }
    }
}
