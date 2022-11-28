using Verse;

namespace MemesAndP;

public class History : IExposable
{
    public int lastTickTraded = -9999999;

    public void ExposeData()
    {
        Scribe_Values.Look(ref lastTickTraded, "lastTickTraded", -9999999);
    }
}