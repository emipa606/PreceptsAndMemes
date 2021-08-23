using HarmonyLib;
using MemesAndP;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace MemesAndP
{
	[HarmonyPatch(typeof(StatsRecord), "Notify_ColonistKilled")]
	public static class Notify_ColonistKilled_Patch
	{
		//Whenever one of your colonists is added to your colonists killed list in the stats, it also creates the memory of ColonistDied.
		private static void Postfix()
        {
			Find.HistoryEventsManager.RecordEvent(new HistoryEvent(ThoughtDefOfDeath.ColonistDied));
		}
	}




	[HarmonyPatch(typeof(MemoryThoughtHandler), "TryGainMemory", new Type[]
	{
		typeof(Thought_Memory),
		typeof(Pawn)
	})]
	public static class TryGainMemory_Patch
	{
		// This cancels the though related to death for any of the pawns that belong to an Ideo that has the two death precepts. This works because when
		// a prefix returns a "false", it skips the rest of the prefixes and the original method.
		// Some credit goes to Vanilla Traits Expanded, as I learned how to do this part thanks to that mod.
		private static bool Prefix(MemoryThoughtHandler __instance, Thought_Memory newThought, Pawn otherPawn)
		{
			//Checks if the pawn that's about to get one of the thoughts contained in deathThoughts belongs to an Ideo that has the death cancelling precepts.
			
			if ((__instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Death_DontCare) || __instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Death_Revered)) && deathThoughts.Contains(newThought.def.defName))
			{
				return false;
			}
			return true;
		}

		public static HashSet<string> deathThoughts = new HashSet<string>
		{

			"KnowGuestExecuted",
			"KnowColonistExecuted",
			"KnowPrisonerDiedInnocent",
			"KnowColonistDied",
			"BondedAnimalDied",
			"PawnWithGoodOpinionDied",
			"PawnWithBadOpinionDied",
			"MySonDied",
			"MyDaughterDied",
			"MyHusbandDied",
			"MyWifeDied",
			"MyFianceDied",
			"MyFianceeDied",
			"MyLoverDied",
			"MyBrotherDied",
			"MySisterDied",
			"MyGrandchildDied",
			"MyFatherDied",
			"MyMotherDied",
			"MyNieceDied",
			"MyNephewDied",
			"MyHalfSiblingDied",
			"MyAuntDied",
			"MyUncleDied",
			"MyGrandparentDied",
			"MyCousinDied",
			"MyKinDied",
			"WitnessedDeathAlly",
			"WitnessedDeathNonAlly",
			"WitnessedDeathFamily",
			"KilledMyFriend",
			"KilledMyRival",
			"KilledMyLover",
			"KilledMyFiance",
			"KilledMySpouse",
			"KilledMyFather",
			"KilledMyMother",
			"KilledMySon",
			"KilledMyDaughter",
			"KilledMyBrother",
			"KilledMySister",
			"KilledMyKin",
			"KilledMyBondedAnimal",
			"ExecutedPrisoner",
			"KilledColonist",
			"KilledColonyAnimal",
			"OtherTravelerDied"
		};

	}
}
