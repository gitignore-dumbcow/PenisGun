using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;

namespace PenisGun
{
    [StaticConstructorOnStartup]
    public class PenisGunModStartup
    {
        static PenisGunModStartup()
        {
        }
    }
    public class PenisGunMod : Mod
    {
        public PenisGunMod(ModContentPack content) : base(content)
        {

        }
        public override string SettingsCategory() => "Penis Gun";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<PenisGunSettings>().DoSettingsWindowContents(inRect);
        }
    }
    
}
