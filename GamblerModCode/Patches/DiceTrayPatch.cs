using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Assets;
using MegaCrit.Sts2.Core.Nodes.Rooms;

namespace GamblerMod.GamblerModCode.Patches;

[HarmonyPatch(typeof(NCombatRoom), nameof(NCombatRoom._Ready))]
public static class DiceTrayPatch
{
    // private static readonly string _scenePath = $"res://{MainFile.ModId}/images/dice/dice_tray_ui.tscn";
    // // private static readonly string _scenePath = "GamblerMod/images/dice/dice_tray_ui.tscn";
    // public static Control? diceTray;
    //
    // [HarmonyPostfix]
    // public static void Postfix(NCombatRoom __instance)
    // {
    //     diceTray = PreloadManager.Cache.GetScene(_scenePath).Instantiate<Control>();
    //     diceTray.Visible = false;
    //     __instance.AddChild(diceTray);
    // }
}

