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
    internal class PenisGunMod
    {
        [StaticConstructorOnStartup]
        public class MinorChangesModStartup
        {
            static MinorChangesModStartup()
            {
            }
        }
        public class MinorChangesMod : Verse.Mod
        {
            public MinorChangesMod(ModContentPack content) : base(content)
            {

            }
            public override string SettingsCategory() => "Penis Gun";

            public override void DoSettingsWindowContents(Rect inRect)
            {
                GetSettings<PenisGunSettings>().DoSettingsWindowContents(inRect);
            }
        }
    }
}
