using RimWorld;
using Verse;

namespace MemesAndP;

public class ThoughtWorker_Precept_PopulationLow : ThoughtWorker_Precept
{
    //Becomes active when population is lesser than the Threshold
    protected override ThoughtState ShouldHaveThought(Pawn p)
    {
        return p.IsColonist && PandM.GetPopulation() < Settings.colonistThreshold;
    }
}