using BaseLib.Extensions;
using GamblerMod.GamblerModCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;

namespace GamblerMod.GamblerModCode.Core;

/// <summary>
/// The Dice Tray acts like a queue of Dice, with the top being the first element in the queue and bottom being last
/// When expending Dice, they are removed from the top, and new Dice are added so long as there are less Dice than the max size of the Tray
/// </summary>
/// <param name="maxSize"></param>
public class DiceTray(Player player, int maxSize = 5)
{
    private readonly List<int> _diceTray = [];
    private int MaxSize { get; } = maxSize;

    
    /// <summary>
    /// Fill up the Dice Tray to its maximum size
    /// </summary>
    public async Task Populate()
    {
        while (_diceTray.Count < MaxSize)
        {
            int die = DiceRoll(6);
            _diceTray.Add(die);
            await PowerCmd.Apply<DicePlaceholderPower>(player.Creature, die, player.Creature, null);
        }
    }
    
    
    /// <summary>
    /// Clear the Dice Tray and reroll new dice its place
    /// </summary>
    public async Task Repopulate()
    {
        // Remove all dice from queue
        _diceTray.Clear();
        
        // Remove all dice visually
        while (player.HasPower<DicePlaceholderPower>())
        {
            await PowerCmd.Remove<DicePlaceholderPower>(player.Creature);
        }
        
        await Populate();
    }

    
    /// <summary>
    /// Remove dice from the top of the Dice Tray
    /// </summary>
    public async Task Remove(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            if (_diceTray.Count <= 0)
                break;
            _diceTray.RemoveAt(0);
            await PowerCmd.Remove<DicePlaceholderPower>(player.Creature);
        }
        await Populate();
    }

    public int Peek(int amount = 1)
    {
        int value = 0;
        for (int i = 0; i < amount; i++)
        {
            if (_diceTray.Count <= 0)
                break;
            value += _diceTray[i];
        }
        return value;
    }


    public int DiceRoll(int dieSize)
    {
        return 1 + player.RunState.Rng.CombatCardGeneration.NextInt(0, dieSize);
    }
}