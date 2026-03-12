using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;
using Spirits.Diagnostics;

namespace Spirits;

[ModInitializer(nameof(Initialize))]
public class MainFile
{
    public const string ModID = "Spirits";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } = new(ModID, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        Harmony harmony = new(ModID);

        harmony.PatchAll();

        Introspection.Run();
    }
}
