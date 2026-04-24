using BaseLib.Utils;
using GamblerMod.GamblerModCode.Cards;
using GamblerMod.GamblerModCode.Character;
using GamblerMod.GamblerModCode.Core;
using GamblerMod.GamblerModCode.Mechanics;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace GamblerMod.GamblerModCode.Cards;

[Pool(typeof(GamblerModCardPool))]
public class GamblerStrike() : GamblerModCard(1,
    CardType.Attack, CardRarity.Basic,
    TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new CalculationBaseVar(4M),
        new ExtraDamageVar(1M),
        new DiceVar(1),
        new CalculatedDamageVar(ValueProp.Move).WithMultiplier((Func<CardModel, Creature, Decimal>) ((card, _) => (decimal) GamblerModel.DiceTray.Get(card.Owner).Peek(card.DynamicVars["Dice"].IntValue)))
    ];
    
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay cardPlay)
    {
        GamblerStrike card = this;
        ArgumentNullException.ThrowIfNull((object) cardPlay.Target, "cardPlay.Target");
        AttackCommand attackCommand = await DamageCmd.Attack(card.DynamicVars.CalculatedDamage).FromCard((CardModel) card)
            .Targeting(cardPlay.Target)
            .WithHitFx("vfx/vfx_attack_slash")
            .WithHitCount(1)
            .Execute(choiceContext);
    }

    
    protected override void OnUpgrade()
    {
        this.DynamicVars.CalculationBase.UpgradeValueBy(3M);
        this.DynamicVars["Dice"].UpgradeValueBy(1);
    }
}