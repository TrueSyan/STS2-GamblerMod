using BaseLib.Abstracts;
using GamblerMod.GamblerModCode.Extensions;
using Godot;

namespace GamblerMod.GamblerModCode.Character;

public class GamblerModPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => GamblerMod.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}