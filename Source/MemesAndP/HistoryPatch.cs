using HarmonyLib;

namespace MemesAndP;

[HarmonyPatch(typeof(RimWorld.History), "ExposeData")]
public static class HistoryPatch
{
    public static void Postfix()
    {
        PandM.history.ExposeData();
    }
}