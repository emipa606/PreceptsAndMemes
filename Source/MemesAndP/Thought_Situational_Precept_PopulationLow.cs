using RimWorld;

namespace MemesAndP;

public class Thought_Situational_Precept_PopulationLow : Thought_Situational
{
    // Divides the base values of mood by the population
    public override float MoodOffset()
    {
        return BaseMoodOffset / PandM.GetPopulation();
    }
}