using HarmonyLib;
using Verse;

namespace MemesAndP;

[StaticConstructorOnStartup]
internal static class HarmonyInit
{
    static HarmonyInit()
    {
        new Harmony("Zezz.PreceptsAndMemes").PatchAll(); //Applies all harmony patches.
    }
}