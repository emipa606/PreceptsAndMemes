using RimWorld;

namespace MemesAndP;

[DefOf]
public static class ThoughtDefOfDeath
{
    public static ThoughtDef ColonistDied_Revered; //I think I didn't use this one. I'm leaving it in just in case.
    public static HistoryEventDef ColonistDied; //Event of colonist dying.

    static ThoughtDefOfDeath()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
    }
}