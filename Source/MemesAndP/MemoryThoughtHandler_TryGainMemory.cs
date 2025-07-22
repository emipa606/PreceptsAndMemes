using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MemesAndP;

//For a later date for now. The purpose of this is to make all ideo related moodlets be multiplied by you orthodoxy. If you know how to finish this you're free to do it yourself or send it back to me.
[HarmonyPatch(typeof(MemoryThoughtHandler), nameof(MemoryThoughtHandler.TryGainMemory), typeof(Thought_Memory),
    typeof(Pawn))]
public static class MemoryThoughtHandler_TryGainMemory
{
    private static readonly HashSet<string> deathThoughts =
    [
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
    ];

    // This cancels the though related to death for any of the pawns that belong to an Ideo that has the two death precepts. This works because when
    // a prefix returns a "false", it skips the rest of the prefixes and the original method.
    // Some credit goes to Vanilla Traits Expanded, as I learned how to do this part thanks to that mod.
    private static bool Prefix(MemoryThoughtHandler __instance, ref Thought_Memory newThought)
    {
        if (newThought.sourcePrecept != null)
        {
            if (__instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Orthodoxy))
            {
                newThought.moodPowerFactor *= 2f;
            }
        }

        //Checks if the pawn that's about to get one of the thoughts contained in deathThoughts belongs to an Ideo that has the death cancelling precepts.
        try
        {
            return !__instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Death_DontCare) &&
                   !__instance.pawn.Ideo.HasPrecept(PreceptDefOfDeath.Death_Revered) ||
                   !deathThoughts.Contains(newThought.def.defName);
        }
        catch (Exception)
        {
            return true;
        }
    }
}