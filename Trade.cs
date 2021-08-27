using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;

namespace MemesAndP
{
    /*[HarmonyPatch(typeof(Faction), "Notify_PlayerTraded")]
    public static class TradedPatch
    {
        public static void Postfix()
        {
            //gets last tick you traded, no mater which colonist or distance. Saves it to an attribute in the main class.
            PandM.LastTickTraded = Find.TickManager.TicksGame;
        }
    }*/

    [HarmonyPatch(typeof(TradeDeal), "TryExecute")]
    public static class TradedDealPatch
    {
        public static void Postfix(ref bool actuallyTraded)
        {
            //Whenever you accept a trade, it gets if you actually traded, if true then it saves the tick you traded at.
            if (actuallyTraded == true)
            {
                PandM.LastTickTraded = Find.TickManager.TicksGame;
            }
        }
    }

    //Creates a thought worker based on the raiding precept one.
    public class ThoughtWorker_Precept_Trading : ThoughtWorker_Precept, IPreceptCompDescriptionArgs
    {
        private float DaysSinceLastTrade
        {
            //Gets the last tick you traded and divides it into days.
            get
            {
                return (float)(Find.TickManager.TicksGame - PandM.LastTickTraded) / 60000f;
            }
        }

        //This is for the interface, purely aesthetic. 
        public IEnumerable<NamedArgument> GetDescriptionArgs()
        {
            yield return this.DaysSinceLastTradedThreshold.Named("DAYSSINCELASTTRADETHRESHOLD");
            yield break;
        }
        //Checks if the pawn should have the thought.
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (!p.IsColonist)
            {
                //only for colonists
                return false;
            }
            if (p.IsSlave)
            {
                //Slaves cannot get it
                return false;
            }
            //get the last day you traded. If it's more than the threshold it activates the thought at stage 1 (negative mood in this case).
            //If it's less it activates it at stage 0.
            int num = (this.DaysSinceLastTrade > (float)this.DaysSinceLastTradedThreshold) ? 1 : 0;
            if (num == 1 && (float)Find.TickManager.TicksGame < 600000f) //Gives you 10 days before the negative mood can become active
            {
                return false;
            }
            return ThoughtState.ActiveAtStage(num);
        }


        public override float MoodMultiplier(Pawn p) //Gets the mood multiplier from a curve. Using the day since the last trade as a parameter.
        {
            return ThoughtWorker_Precept_Trading.MoodMultiplierCurve.Evaluate(this.DaysSinceLastTrade);
        }

        //This curve is relatively simple. When days since last trade are 0, the multipier is x1. It then gets reduced linealy to 0 by the fifth day.
        //Once you reach the sixth day, the ShouldHaveThought metod makes the thought stage change, and in this case it now becomes a negative thought.
        //We slowly increase the multiplier linealy, until it's back a x1 at 10 days without trade.
        //After this, it increases linealy to x1.5 in the next five days, and then stops.
        private static readonly SimpleCurve MoodMultiplierCurve = new SimpleCurve
        {
            {
                new CurvePoint(0f, 1f),
                true
            },
            {
                new CurvePoint(Settings.dayForTradeThreshold, 0f),
                true
            },
            {
                new CurvePoint(Settings.dayForTradeThreshold*2, 1f),
                true
            },
            {
                new CurvePoint(Settings.dayForTradeThreshold*3, 1.5f),
                true
            }
        };

        //Threshold of days from last trade in which the thought will be a possitive one.
        private int DaysSinceLastTradedThreshold = Settings.dayForTradeThreshold;
    }

}
