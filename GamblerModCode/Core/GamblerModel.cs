using BaseLib.Abstracts;
using BaseLib.Utils;
using GamblerMod.GamblerModCode.Patches;
using Godot;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Nodes.GodotExtensions;

namespace GamblerMod.GamblerModCode.Core;

public class GamblerModel() : CustomSingletonModel(receiveCombatHooks: true, receiveRunHooks: false)
{
    public static readonly SpireField<Player, DiceTray> DiceTray = new (player => new DiceTray(player));
    
    public override Task BeforeHandDraw(Player player, PlayerChoiceContext choiceContext, CombatState combatState)
    {
        if (combatState.RoundNumber > 1)
        {
            DiceTray.Get(player)?.Remove();
            return base.BeforeHandDraw(player, choiceContext, combatState);
        }
        
        DiceTray.Get(player)?.Repopulate();
        return base.BeforeHandDraw(player, choiceContext, combatState);
    }
}