using BaseLib.Abstracts;
using GamblerMod.GamblerModCode.Patches;
using Godot;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Nodes.GodotExtensions;

namespace GamblerMod.GamblerModCode.Core;

public class GamblerModel() : CustomSingletonModel(receiveCombatHooks: true, receiveRunHooks: false)
{
    // public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    // {
    //     // if (DiceTrayPatch.diceTray != null)
    //     // {
    //     //     Roll the dice on screen
    //     //     DiceTrayPatch.diceTray.Visible = true;
    //     //     foreach (RigidBody3D dice in DiceTrayPatch.diceTray.GetChildrenRecursive<RigidBody3D>())
    //     //     {
    //     //         dice.Call("roll");
    //     //     }
    //     // }
    //     GamblerManager.DiceRoll(player);   
    //     return base.AfterPlayerTurnStart(choiceContext, player);
    // }

    public override Task BeforeHandDraw(Player player, PlayerChoiceContext choiceContext, CombatState combatState)
    {
        if (combatState.RoundNumber > 1)
        {
            GamblerManager.diceTray.Remove(player, 1);
            return base.BeforeHandDraw(player, choiceContext, combatState);
        }
        
        GamblerManager.diceTray.Populate(player);
        return base.BeforeHandDraw(player, choiceContext, combatState);
    }
}