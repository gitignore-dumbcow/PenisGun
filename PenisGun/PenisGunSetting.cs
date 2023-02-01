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
    public class PenisGunSettings : ModSettings
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref useNSFWContent, "useNSFWContent", true);
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            Rect rectWeCanSee = inRect.ContractedBy(10f);
            rectWeCanSee.height -= 100f; // "close" button
            bool scrollBarVisible = totalContentHeight > rectWeCanSee.height;
            Rect rectThatHasEverything = new Rect(0f, 0f, rectWeCanSee.width -
                                                (scrollBarVisible ? ScrollBarWidthMargin : 0), totalContentHeight);
            Widgets.BeginScrollView(rectWeCanSee, ref scrollPosition, rectThatHasEverything);
            float curY = 0f;
            Rect r = new Rect(0, curY, rectThatHasEverything.width, LabelHeight);

            MakeBoolButton(ref curY, rectThatHasEverything.width, "Enable NSFW Content", "Disable to use family friendly content.", ref useNSFWContent);

            Widgets.EndScrollView();
            totalContentHeight = curY + 50f;
        }
        private static Vector2 scrollPosition = new Vector2(0f, 0f);
        private static float totalContentHeight = 1000f;
        private const float ScrollBarWidthMargin = 18f;
        private const float LabelHeight = 22f;

        // Make the button/handle the setting change:
        void MakeBoolButton(ref float curY, float width, string lable, string description, ref bool setting)
        {
            Rect r = new Rect(0, curY, width, LabelHeight);
            Widgets.CheckboxLabeled(r, lable, ref setting);
            TooltipHandler.TipRegion(r, description);
            if (Mouse.IsOver(r)) Widgets.DrawHighlight(r);
            curY += LabelHeight + 1f;
        }

        //Variables
        public bool useNSFWContent = true;

    }
}
