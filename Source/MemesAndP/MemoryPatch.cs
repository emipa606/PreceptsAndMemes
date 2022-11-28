using HarmonyLib;
using RimWorld;
using Verse;

namespace MemesAndP;

//For a later date for now. The purpose of this is to make all ideo related moodlets be multiplied by you orthodoxy. If you know how to finish this you're free to do it yourself or send it back to me.
[HarmonyPatch(typeof(MemoryThoughtHandler), "TryGainMemory", typeof(Thought_Memory), typeof(Pawn))]
public static class MemoryPatch
{
    private static void Prefix(ref MemoryThoughtHandler __instance, ref Thought_Memory newThought)
    {
        if (newThought.sourcePrecept == null)
        {
            return;
        }

        if (!__instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Orthodoxy))
        {
            return;
        }

        newThought.moodPowerFactor *= 2f;
        //Log.Message("hello");
    }
}