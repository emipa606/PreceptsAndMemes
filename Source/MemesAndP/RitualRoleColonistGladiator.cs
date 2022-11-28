using RimWorld;
using Verse;

namespace MemesAndP;

public class RitualRoleColonistGladiator : RitualRole
{
    public bool mustBeCapableToFight;

    //A compy paste of the ritual role for the vanilla duel, except for one change.
    public override bool AppliesToPawn(Pawn p, out string reason, TargetInfo selectedTarget,
        LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null,
        bool skipReason = false)
    {
        reason = null;
        if (!p.IsColonist) //This here changes. Instead of asking if the pawn is a prisoner or slave of the colony, it asks if it's a colonists (Includes slaves too)
        {
            if (!skipReason)
            {
                reason = "MessageRitualRoleMustBeColonist".Translate(LabelCap);
            }

            return false;
        }

        if (!mustBeCapableToFight || !p.WorkTagIsDisabled(WorkTags.Violent) &&
            p.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation))
        {
            return true;
        }

        if (!skipReason)
        {
            reason = "MessageRitualRoleMustBeCapableOfFighting".Translate(p);
        }

        return false;
    }

    public override bool AppliesToRole(Precept_Role role, out string reason, Precept_Ritual ritual = null,
        Pawn p = null, bool skipReason = false)
    {
        reason = null;
        return false;
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref mustBeCapableToFight, "mustBeCapableToFight");
    }
}

//I use this whe I want to carry colonists to rituals as if they were prisoners. 