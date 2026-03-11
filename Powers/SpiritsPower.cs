using BaseLib.Abstracts;
using BaseLib.Extensions;

namespace Spirits.Powers;

public abstract class SpiritsPower : CustomPowerModel
{
    public override string CustomPackedIconPath => "res://images/spirits/powers/" + Id.Entry.RemovePrefix().ToLowerInvariant() + ".png";
    public override string CustomBigIconPath => "res://images/spirits/powers/big/" + Id.Entry.RemovePrefix().ToLowerInvariant() + ".png";
}
