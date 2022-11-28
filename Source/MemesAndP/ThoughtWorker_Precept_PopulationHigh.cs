using RimWorld;
using Verse;

namespace MemesAndP;

public class ThoughtWorker_Precept_PopulationHigh : ThoughtWorker_Precept
{
    //Becomes active when population is greater than the Threshold
    protected override ThoughtState ShouldHaveThought(Pawn p)
    {
        return p.IsColonist && PandM.GetPopulation() > Settings.colonistThreshold;
    }
}