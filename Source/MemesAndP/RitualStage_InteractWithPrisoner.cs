using RimWorld;
using Verse;

namespace MemesAndP;

public class RitualStage_InteractWithPrisoner : RitualStage
{
    public override TargetInfo GetSecondFocus(LordJob_Ritual ritual)
    {
        return ritual.assignments.Participants.FirstOrDefault(p => p.IsColonist);
    }
}