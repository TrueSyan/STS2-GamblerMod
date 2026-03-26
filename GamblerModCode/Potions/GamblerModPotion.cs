using BaseLib.Abstracts;
using BaseLib.Utils;
using GamblerMod.GamblerModCode.Character;

namespace GamblerMod.GamblerModCode.Potions;

[Pool(typeof(GamblerModPotionPool))]
public abstract class GamblerModPotion : CustomPotionModel;