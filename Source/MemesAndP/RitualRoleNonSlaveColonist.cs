using RimWorld;
using Verse;

namespace MemesAndP;

//To select a colonist but not a slave.
public class RitualRoleNonSlaveColonist : RitualRole
{
    private WorkTypeDef requiredWorkType;

    public override bool AppliesToPawn(Pawn p, out string reason, TargetInfo selectedTarget,
        LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null,
        bool skipReason = false)
    {
        reason = null;
        if (!p.RaceProps.Humanlike)
        {
            if (!skipReason)
            {
                reason = "MessageRitualRoleMustBeHumanlike".Translate(Label);
            }

            return false;
        }

        if (requiredWorkType != null && p.WorkTypeIsDisabled(requiredWorkType))
        {
            if (!skipReason)
            {
                reason = "MessageRitualRoleMustBeCapableOfGeneric".Translate(LabelCap, requiredWorkType.gerundLabel);
            }

            return false;
        }

        if (p.IsFreeNonSlaveColonist) //I just needed to change this from the vanilla one
        {
            return true;
        }

        if (!skipReason)
        {
            reason = "MessageRitualRoleMustBeColonist".Translate(Label);
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
        Scribe_Defs.Look(ref requiredWorkType, "requiredWorkType");
    }
}