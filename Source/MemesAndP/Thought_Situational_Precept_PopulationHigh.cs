using RimWorld;

namespace MemesAndP;

//Based on vanillas slavery classes
public class Thought_Situational_Precept_PopulationHigh : Thought_Situational
{
    // Multiplies the base values of mood by the population - threshold. Caps at 15 colonists
    public override float MoodOffset()
    {
        return BaseMoodOffset * (PandM.GetPopulation() - Settings.colonistThreshold > 15
            ? 15
            : PandM.GetPopulation() - Settings.colonistThreshold);
    }
}