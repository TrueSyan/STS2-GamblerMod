using MegaCrit.Sts2.Core.Entities.Powers;

namespace GamblerMod.GamblerModCode.Powers;

public class DicePlaceholderPower : GamblerModPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
}