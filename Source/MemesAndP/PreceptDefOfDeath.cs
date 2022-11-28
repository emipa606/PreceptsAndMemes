using RimWorld;

namespace MemesAndP;

[DefOf]
public static class PreceptDefOfDeath
{
    //Death cancelling precepts
    public static PreceptDef Death_DontCare;
    public static PreceptDef Death_Revered;
    public static PreceptDef Orthodoxy;

    static PreceptDefOfDeath()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(PreceptDefOf));
    }
}