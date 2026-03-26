using MegaCrit.Sts2.Core.Random;

namespace GamblerMod.GamblerModCode.Mechanics;

public static class DiceRoll
{
    
    public static int Get()
    {
        return Rng.Chaotic.NextInt(0, 6) + 1;
    }
}