using BaseLib.Abstracts;
using Godot;

namespace Spirits.Character;

public class SpiritsRelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => "spirits";
    public override Color LabOutlineColor => Spirits.Color;
}
