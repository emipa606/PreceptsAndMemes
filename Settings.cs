using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace MemesAndP
{
    public class Settings : ModSettings
    {

        public static int dayForTradeThreshold = 5;
        public static int colonistThreshold = 5;


        public override void ExposeData()
        {
            Scribe_Values.Look(ref dayForTradeThreshold, "DaysForTradeThershold", 5);
            Scribe_Values.Look(ref colonistThreshold, "ColonistThreshold", 5);
            base.ExposeData();
        }
    }
}
