using BaseLib.Abstracts;
using BaseLib.Extensions;
using GamblerMod.GamblerModCode.Extensions;
using Godot;

namespace GamblerMod.GamblerModCode.Powers;

public abstract class GamblerModPower : CustomPowerModel
{
    //Loads from GamblerMod/images/powers/your_power.png
    public override string CustomPackedIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".PowerImagePath();
        }
    }

    public override string CustomBigIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".BigPowerImagePath();
        }
    }
}