using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;

namespace GamblerMod.GamblerModCode.Mechanics;

public class DiceVar: DynamicVar
{
    public const string defaultName = "Dice";
    public ValueProp Props { get; set; }
    
    public DiceVar(Decimal amount, ValueProp props)
        : base("Dice", amount)
    {
        this.Props = props;
    }

    public DiceVar(string name, Decimal amount, ValueProp props)
        : base(name, amount)
    {
        this.Props = props;
    }
    
    public override void UpdateCardPreview(
        CardModel card,
        CardPreviewMode previewMode,
        Creature? target,
        bool runGlobalHooks)
    {
        this.PreviewValue = -1;
    }
}