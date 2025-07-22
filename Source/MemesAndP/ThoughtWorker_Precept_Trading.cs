using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MemesAndP;

public class ThoughtWorker_Precept_Trading : ThoughtWorker_Precept, IPreceptCompDescriptionArgs
{
    //This curve is relatively simple. When days since last trade are 0, the multipier is x1. It then gets reduced linealy to 0 by the fifth day.
    //Once you reach the sixth day, the ShouldHaveThought metod makes the thought stage change, and in this case it now becomes a negative thought.
    //We slowly increase the multiplier linealy, until it's back a x1 at 10 days without trade.
    //After this, it increases linealy to x1.5 in the next five days, and then stops.
    private static readonly SimpleCurve MoodMultiplierCurve =
    [
        new CurvePoint(0f, 1f),
        new CurvePoint(Settings.dayForTradeThreshold, 0f),
        new CurvePoint(Settings.dayForTradeThreshold * 2, 1f),
        new CurvePoint(Settings.dayForTradeThreshold * 3, 1.5f)
    ];

    //Threshold of days from last trade in which the thought will be a possitive one.
    private readonly int DaysSinceLastTradedThreshold = Settings.dayForTradeThreshold;

    private float DaysSinceLastTrade =>
        //Gets the last tick you traded and divides it into days.
        (Find.TickManager.TicksGame - PandM.History.lastTickTraded) / 60000f;

    //This is for the interface, purely aesthetic. 
    public IEnumerable<NamedArgument> GetDescriptionArgs()
    {
        yield return DaysSinceLastTradedThreshold.Named("DAYSSINCELASTTRADETHRESHOLD");
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
        var num = DaysSinceLastTrade > DaysSinceLastTradedThreshold ? 1 : 0;
        if (num == 1 &&
            Find.TickManager.TicksGame < 600000f) //Gives you 10 days before the negative mood can become active
        {
            return false;
        }

        return ThoughtState.ActiveAtStage(num);
    }


    public override float
        MoodMultiplier(Pawn p) //Gets the mood multiplier from a curve. Using the day since the last trade as a parameter.
    {
        return MoodMultiplierCurve.Evaluate(DaysSinceLastTrade);
    }
}