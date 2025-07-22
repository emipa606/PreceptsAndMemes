using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MemesAndP;

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
        var thing = map.listerThings.ThingsInGroup(ThingRequestGroup.Grave)
            .FirstOrDefault(t => ((Building_Grave)t).Corpse != null);

        if (thing != null)
        {
            yield return thing;
        }
    }

    protected override RitualTargetUseReport CanUseTargetInternal(TargetInfo target, RitualObligation obligation)
    {
        Building_Grave buildingGrave;
        return target.HasThing && (buildingGrave = target.Thing as Building_Grave) != null &&
               buildingGrave.Corpse != null;
    }

    public override bool ObligationTargetsValid(RitualObligation obligation)
    {
        return obligation.targetA is { HasThing: true, ThingDestroyed: false };
    }

    public override IEnumerable<string> GetTargetInfos(RitualObligation obligation)
    {
        if (obligation == null)
        {
            yield return "RitualTargetGraveInfoAbstract".Translate(parent.ideo.Named("IDEO"));
            yield break;
        }

        var innerPawn = ((Corpse)obligation.targetA.Thing).InnerPawn;
        var taggedString = "RitualTargetGraveInfo".Translate(innerPawn.Named("PAWN"));
        if (obligation.targetA.Thing.ParentHolder is not Building_Grave)
        {
            taggedString += " (" + "RitualTargetGraveInfoMustBeBuried".Translate(innerPawn.Named("PAWN")) + ")";
        }

        yield return taggedString;
    }

    public override string LabelExtraPart(RitualObligation obligation)
    {
        return ((Corpse)obligation.targetA.Thing).InnerPawn.LabelShort;
    }
}