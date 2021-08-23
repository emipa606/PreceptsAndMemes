using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using HarmonyLib;

namespace MemesAndP
{
    public class PandM : Mod
    {
        public PandM(ModContentPack pack) : base(pack)
        {

        }
        public static int GetPopulation()
        {
                                                                                                    //Counts all the pawns belonging to your faction.
            return PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists.Count();    //The mod is more oriented to one colony only. But if I wanted to make it more compatible with
                                                                                                    //multiple colonies I would make it check the map of every colonist individually. Counting caravans
                                                                                                    //is intentional for balancing purposes.
        }
        public static int LastTickTraded = -9999999;
    }

    [StaticConstructorOnStartup]
    internal static class HarmonyInit
    {
        static HarmonyInit()
        {
            new Harmony("Zezz.PreceptsAndMemes").PatchAll(); //Applies all harmony patches.
        }
    }

    [DefOf]
    public static class PreceptDefOfDeath
    {
        static PreceptDefOfDeath()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PreceptDefOf));
        }
        //Death cancelling precepts
        public static PreceptDef Death_DontCare;
        public static PreceptDef Death_Revered;
    }

    [DefOf]
    public static class ThoughtDefOfDeath
    {
        static ThoughtDefOfDeath()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
        }

        public static ThoughtDef ColonistDied_Revered; //I think I don't use this one. I'm leaving it in just in case.
        public static HistoryEventDef ColonistDied;//Event of colonist dying.
    }
}
