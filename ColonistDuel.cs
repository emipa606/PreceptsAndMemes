using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;


namespace MemesAndP
{
	public class RitualRoleColonistGladiator : RitualRole
	{
		//A compy paste of the ritual role for the vanilla duel, except for one change.
		public override bool AppliesToPawn(Pawn p, out string reason, LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null, bool skipReason = false)
		{
			reason = null;
			if (!p.IsColonist)//This here changes. Instead of asking if the pawn is a prisoner or slave of the colony, it asks if it's a colonists (Includes slaves too)
			{
				if (!skipReason)
				{
					reason = "MessageRitualRoleMustBeColonist".Translate(base.LabelCap);
				}
				return false;
			}
			if (this.mustBeCapableToFight && (p.WorkTagIsDisabled(WorkTags.Violent) || !p.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation)))
			{
				if (!skipReason)
				{
					reason = "MessageRitualRoleMustBeCapableOfFighting".Translate(p);
				}
				return false;
			}
			return true;
		}

		public override bool AppliesToRole(Precept_Role role, out string reason, Precept_Ritual ritual = null, Pawn p = null, bool skipReason = false)
		{
			reason = null;
			return false;
		}

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<bool>(ref this.mustBeCapableToFight, "mustBeCapableToFight", false, false);
		}

		public bool mustBeCapableToFight;
	}

	//I use this whe I want to carry colonists to rituals as if they were prisoners. 
	public class RitualStage_InteractWithPrisoner : RitualStage
	{
		// Token: 0x06005D0B RID: 23819 RVA: 0x00203875 File Offset: 0x00201A75
		public override TargetInfo GetSecondFocus(LordJob_Ritual ritual)
		{
			return ritual.assignments.Participants.FirstOrDefault((Pawn p) => p.IsColonist);
		}
	}

}
