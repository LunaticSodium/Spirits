using BaseLib.Abstracts;
using Godot;

namespace Spirits.Character;

public partial class SpiritsCardPool : CustomCardPoolModel
{
    public override string Title => "spirits";

    public override string EnergyColorName => "spirits";

    public override float H => 0.95f;
    public override float S => 0.98f;
    public override float V => 0.7f;

    public override Color DeckEntryCardColor => new("840240");
    public override Color EnergyOutlineColor => new("651565");

    public override bool IsColorless => false;
}
