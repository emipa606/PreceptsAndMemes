using HarmonyLib;
using RimWorld;
using Verse;

namespace MemesAndP;

[HarmonyPatch(typeof(StatsRecord), "Notify_ColonistKilled")]
public static class Notify_ColonistKilled_Patch
{
    //Whenever one of your colonists is added to your colonists killed list in the stats, it also creates the memory of ColonistDied.
    private static void Postfix()
    {
        Find.HistoryEventsManager.RecordEvent(new HistoryEvent(ThoughtDefOfDeath.ColonistDied));
    }
}