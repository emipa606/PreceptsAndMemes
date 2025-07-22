using System.Reflection;
using HarmonyLib;
using Verse;

namespace MemesAndP;

[StaticConstructorOnStartup]
internal static class HarmonyInit
{
    static HarmonyInit()
    {
        new Harmony("Zezz.PreceptsAndMemes").PatchAll(Assembly.GetExecutingAssembly()); //Applies all harmony patches.
    }
}