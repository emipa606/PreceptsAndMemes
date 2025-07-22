using HarmonyLib;

namespace MemesAndP;

[HarmonyPatch(typeof(RimWorld.History), nameof(RimWorld.History.ExposeData))]
public static class History_ExposeData
{
    public static void Postfix()
    {
        PandM.History.ExposeData();
    }
}