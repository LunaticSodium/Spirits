using MegaCrit.Sts2.Core.Entities.Powers;

namespace Spirits.Powers;

public sealed class FireRemnant : SpiritsPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
}
