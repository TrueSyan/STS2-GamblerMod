using GamblerMod.GamblerModCode.Formatters;
using HarmonyLib;
using MegaCrit.Sts2.Core.Localization;
using SmartFormat;
using SmartFormat.Core.Extensions;

namespace GamblerMod.GamblerModCode.Patches;

[HarmonyPatch(typeof(LocManager), "LoadLocFormatters")]
public class LocManagerPatch
{
    static SmartFormatter _smartFormatterRef = Traverse.Create(typeof(LocManager)).Field("_smartFormatter").GetValue() as SmartFormatter;
    static void Postfix(LocManager __instance)
    {
        _smartFormatterRef?.AddExtensions((IFormatter)new DiceIconsFormatter());
    }
}