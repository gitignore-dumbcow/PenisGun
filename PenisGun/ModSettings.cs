using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using UnityEngine;
using Verse;

namespace PenisGun
{
    public class PenisGunModSetting : ModSettings
    {
        public static bool usingSFWContent;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref usingSFWContent, "usingSFWContent");
        }
    }

    [StaticConstructorOnStartup]
    public class OnDefsLoaded
    {
        static OnDefsLoaded()
        {
            ApplySettingsToDefs();
        }

        public static void ApplySettingsToDefs()
        {

            //string targetTexPath = useSFWContent ? "Things/Penis_B" : "Things/Penis_A";
            //string label = useSFWContent ? "Artifical Inseminator" : "Penis Gun";

            //DefDatabase<ThingDef>.GetNamed("DC_Penis_Gun").label = label;
            //DefDatabase<ThingDef>.GetNamed("DC_Penis_Gun").graphic.path = targetTexPath;
        }
        }

    

    public class PenisGunMod : Mod
    {
        public override string SettingsCategory() => "Penis Gun";

        public PenisGunMod(ModContentPack content) : base(content)
        {
            Log.Warning("PenisGun Settings loaded");
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();

            listing_Standard.Begin(inRect);
            listing_Standard.CheckboxLabeled("Enable SFW Content", ref PenisGunModSetting.usingSFWContent, "Alternative content for family use");
            listing_Standard.End();

            OnDefsLoaded.ApplySettingsToDefs();
            base.DoSettingsWindowContents(inRect);
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            OnDefsLoaded.ApplySettingsToDefs();
            Log.Warning("PenisGun Settings saved! Current state: " + PenisGunModSetting.usingSFWContent);
        }
        
    }
    
}
