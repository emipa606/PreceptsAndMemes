using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MemesAndP
{


	//to select a grave with a corpse for a ritual, without the need of it being an expected one.
	public class RitualObligationTargetWorker_GraveWithCorpse : RitualObligationTargetFilter
	{
		public RitualObligationTargetWorker_GraveWithCorpse()
		{
		}

		public RitualObligationTargetWorker_GraveWithCorpse(RitualObligationTargetFilterDef def) : base(def)
		{
		}

		public override IEnumerable<TargetInfo> GetTargets(RitualObligation obligation, Map map)
		{
			Thing thing = map.listerThings.ThingsInGroup(ThingRequestGroup.Grave).FirstOrDefault((Thing t) => ((Building_Grave)t).Corpse !=null);

			if (thing != null)
			{
				yield return thing;
			}
			yield break;

			
		}

		protected override RitualTargetUseReport CanUseTargetInternal(TargetInfo target, RitualObligation obligation)
		{
			Building_Grave building_Grave;
			return target.HasThing && (building_Grave = (target.Thing as Building_Grave)) != null && building_Grave.Corpse !=null;
		}

		public override bool ObligationTargetsValid(RitualObligation obligation)
		{
			return obligation.targetA.HasThing && !obligation.targetA.ThingDestroyed;
		}

		public override IEnumerable<string> GetTargetInfos(RitualObligation obligation)
		{
			if (obligation == null)
			{
				yield return "RitualTargetGraveInfoAbstract".Translate(this.parent.ideo.Named("IDEO"));
				yield break;
			}
			bool flag = obligation.targetA.Thing.ParentHolder is Building_Grave;
			Pawn innerPawn = ((Corpse)obligation.targetA.Thing).InnerPawn;
			TaggedString taggedString = "RitualTargetGraveInfo".Translate(innerPawn.Named("PAWN"));
			if (!flag)
			{
				taggedString += " (" + "RitualTargetGraveInfoMustBeBuried".Translate(innerPawn.Named("PAWN")) + ")";
			}
			yield return taggedString;
			yield break;
		}

		public override string LabelExtraPart(RitualObligation obligation)
		{
			return ((Corpse)obligation.targetA.Thing).InnerPawn.LabelShort;
		}
	}
}
