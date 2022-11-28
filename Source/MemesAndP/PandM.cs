using System.Linq;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace MemesAndP;

public class PandM : Mod
{
    public static History history = new History();
    private static string currentVersion;
    private Settings settings;

    public PandM(ModContentPack pack) : base(pack)
    {
        settings = GetSettings<Settings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.PreceptsAndMemes"));
    }


    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Label("MaP.colonistThreshold".Translate(Settings.colonistThreshold));
        listingStandard.IntAdjuster(ref Settings.colonistThreshold, 1, 1);
        listingStandard.GapLine();
        listingStandard.Label("MaP.dayForTradeThreshold".Translate(Settings.dayForTradeThreshold));
        listingStandard.IntAdjuster(ref Settings.dayForTradeThreshold, 1, 1);
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("MaP.currentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Precepts And Memes";
    }


    public static int GetPopulation()
    {
        //Counts all the pawns belonging to your faction.
        return PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists
            .Count(); //The mod is more oriented to one colony only. But if I wanted to make it more compatible with
        //multiple colonies I would make it check the map of every colonist individually. Counting caravans
        //is intentional for balancing purposes.
    }
}