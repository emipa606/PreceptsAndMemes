using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MemesAndP
{
	//For a later date for now. The purpose of this is to make all ideo related moodlets be multiplied by you orthodoxy. If you know how to finish this you're free to do it yourself or send it back to me.
	/*[HarmonyPatch(typeof(MemoryThoughtHandler), "TryGainMemory", new Type[]
	{
		typeof(Thought_Memory),
		typeof(Pawn)
	})]
	public static class MemoryPatch
    {
		private static void Prefix(ref Thought_Memory newThought, Pawn otherPawn = null)
        {
			bool flag = newThought.sourcePrecept != null;
			if(flag)
            {
				newThought.moodPowerFactor *= 2f;
				Log.Message("hello");
            }
        }
    }

	[HarmonyPatch(typeof(ThoughtWorker), "MoodMultiplier")]
	public static class ThoughtworkerPatch
    {
		private static void Postfix (ref float __result, ThoughtWorker __instance, Pawn p)
        {
			if (__instance is ThoughtWorker_Precept)
			{
				__result *= 2;
				Log.Message("hello2");
			}
			return;
        }
    }

	[HarmonyPatch(typeof(Thought), "MoodOffset")]
	public static class ThoughtSituationalPatch
	{
		private static void Postfix(ref float __result, Thought __instance)
		{
			if (__instance is Thought_Situational)
			{
				__result *= 2;
			}
			return;
		}
	}*/


}
