using BaseLib.Abstracts;
using Godot;

namespace Spirits.Character;

public class SpiritsPotionPool : CustomPotionPoolModel
{
    public override string EnergyColorName => "spirits";
    public override Color LabOutlineColor => Spirits.Color;
}
