using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using MemesAndP;

namespace MemesAndP
{
    //Based on vanillas slavery classes
    public class Thought_Situational_Precept_PopulationHigh : Thought_Situational
    {
        // Multiplies the base values of mood by the population - threshold. Caps at 15 colonists
        public override float MoodOffset()
        {
            return this.BaseMoodOffset * (PandM.GetPopulation() - Settings.colonistThreshold > 15?15: PandM.GetPopulation() - Settings.colonistThreshold);
        }

    }
    public class ThoughtWorker_Precept_PopulationHigh : ThoughtWorker_Precept
    {
        //Becomes active when population is greater than the Threshold
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && PandM.GetPopulation() > Settings.colonistThreshold;
        }

    }

    public class Thought_Situational_Precept_PopulationLow : Thought_Situational
    {
        // Divides the base values of mood by the population
        public override float MoodOffset()
        {
            return this.BaseMoodOffset / PandM.GetPopulation();
        }

    }
    public class ThoughtWorker_Precept_PopulationLow : ThoughtWorker_Precept
    {
        //Becomes active when population is lesser than the Threshold
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && PandM.GetPopulation() < Settings.colonistThreshold;
        }

    }



}
