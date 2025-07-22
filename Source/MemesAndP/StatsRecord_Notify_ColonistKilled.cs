using HarmonyLib;
using RimWorld;
using Verse;

namespace MemesAndP;

[HarmonyPatch(typeof(StatsRecord), nameof(StatsRecord.Notify_ColonistKilled))]
public static class StatsRecord_Notify_ColonistKilled
{
    //Whenever one of your colonists is added to your colonists killed list in the stats, it also creates the memory of ColonistDied.
    private static void Postfix()
    {
        Find.HistoryEventsManager.RecordEvent(new HistoryEvent(ThoughtDefOfDeath.ColonistDied));
    }
}