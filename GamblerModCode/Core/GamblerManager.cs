using GamblerMod.GamblerModCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Random;

namespace GamblerMod.GamblerModCode.Core;

public static class GamblerManager
{
    public static async Task DiceRoll(Player player)
    {
        int d6 = 1 + player.RunState.Rng.CombatCardGeneration.NextInt(0, 6);
        await PowerCmd.SetAmount<DicePlaceholderPower>(player.Creature, d6, player.Creature, (CardModel) null);
    }
}