using System;
using System.Linq;
using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Models;

namespace Spirits.Diagnostics;

public static class Introspection
{
    public static void Run()
    {
        try
        {
            var hookType = typeof(Hook);
            var hookMethods = hookType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(m => $"{m.Name}({string.Join(", ", m.GetParameters().Select(p => p.ParameterType.Name))})");
            foreach (var m in hookMethods.OrderBy(s => s))
            {
                MainFile.Logger.Info($"HOOK:{m}");
            }
        }
        catch (Exception e)
        {
            MainFile.Logger.Warn($"Hook introspection failed: {e.GetType().Name}: {e.Message}");
        }
        try
        {
            var powerBaseAsm = typeof(PowerModel).Assembly;
            var powerTypes = powerBaseAsm.GetTypes().Where(t => t.Namespace == "MegaCrit.Sts2.Core.Entities.Powers" && !t.IsAbstract && t.IsSubclassOf(typeof(PowerModel)));
            var method = typeof(ModelDb).GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(mi => mi.IsGenericMethodDefinition && mi.Name == "Power");
            foreach (var pt in powerTypes)
            {
                string id = "";
                try
                {
                    if (method != null)
                    {
                        var pm = method.MakeGenericMethod(pt).Invoke(null, null) as PowerModel;
                        id = pm?.Id.Entry ?? "";
                    }
                }
                catch { }
                if (pt.Name.Contains("Weak", StringComparison.OrdinalIgnoreCase)
                    || pt.Name.Contains("Vulner", StringComparison.OrdinalIgnoreCase)
                    || pt.Name.Contains("Intang", StringComparison.OrdinalIgnoreCase)
                    || pt.Name.Contains("Plated", StringComparison.OrdinalIgnoreCase)
                    || pt.Name.Contains("Dex", StringComparison.OrdinalIgnoreCase)
                    || pt.Name.Contains("Strength", StringComparison.OrdinalIgnoreCase))
                {
                    MainFile.Logger.Info($"POWER:{pt.FullName}|{id}");
                }
            }
        }
        catch (Exception e)
        {
            MainFile.Logger.Warn($"Power introspection failed: {e.GetType().Name}: {e.Message}");
        }
    }
}
