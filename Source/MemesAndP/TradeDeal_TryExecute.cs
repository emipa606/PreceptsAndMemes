using HarmonyLib;
using RimWorld;
using Verse;

namespace MemesAndP;

[HarmonyPatch(typeof(TradeDeal), nameof(TradeDeal.TryExecute))]
public static class TradeDeal_TryExecute
{
    public static void Postfix(ref bool actuallyTraded)
    {
        //Whenever you accept a trade, it gets if you actually traded, if true then it saves the tick you traded at.
        if (actuallyTraded)
        {
            PandM.History.lastTickTraded = Find.TickManager.TicksGame;
        }
    }
}

//Creates a thought worker based on the raiding precept one.