using BaseLib.Abstracts;
using GamblerMod.GamblerModCode.Patches;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace GamblerMod.GamblerModCode.Core;

public class GamblerModel() : CustomSingletonModel(receiveCombatHooks: true, receiveRunHooks: false)
{
    public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (DiceTrayPatch.diceTray != null) DiceTrayPatch.diceTray.Visible = true;
        return base.AfterPlayerTurnStart(choiceContext, player);
    }
}