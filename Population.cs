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
    //The buffs and debuffs have no cap. This is sort of intentional, as it makes insanely big colonies (30+) easier to manage.
    public class Thought_Situational_Precept_PopulationHigh : Thought_Situational
    {
        // Multiplies the base values of mood by the population - 5
        public override float MoodOffset()
        {
            return this.BaseMoodOffset * (PandM.GetPopulation() - 5);
        }

    }
    public class ThoughtWorker_Precept_PopulationHigh : ThoughtWorker_Precept
    {
        //Becomes active when population is greater than 5
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && PandM.GetPopulation() > 5;
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
        //Becomes active when population is lesser than 5
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && PandM.GetPopulation() < 5;
        }

    }

}
