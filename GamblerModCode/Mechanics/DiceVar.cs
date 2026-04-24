using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;

namespace GamblerMod.GamblerModCode.Mechanics;

public class DiceVar(string name, int dice) : DynamicVar(name, (Decimal) dice)
{
    public const string defaultName = "Dice";
    
    public DiceVar(int dice)
        : this("Dice", dice)
    {
    }
}