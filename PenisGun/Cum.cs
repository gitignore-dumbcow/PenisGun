using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PenisGun
{
    public class CumShot : Bullet
    {
        public ModExtension_CumShot Extenstion => def.GetModExtension<ModExtension_CumShot>();

        HediffDef hediffType;
        ThoughtDef shooterThought;
        ThoughtDef victimThought;

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            hediffType = Extenstion.hediffToAdd;
            shooterThought = Extenstion.shooterThought;
            victimThought = Extenstion.victimThought;

            base.Impact(hitThing, blockedByShield);

            if (Extenstion != null && hitThing != null && hitThing is Pawn pawn)
            {
                float rand = Rand.Value;
                if (rand <= Extenstion.addHediffChance)
                {
                    Hediff pawnAvailable = pawn.health?.hediffSet?.GetFirstHediffOfDef(Extenstion.hediffToAdd);

                    float randomSeverity = Rand.Range(0.15f, 0.30f);
                    if (pawnAvailable == null)
                    {
                        //Add Hediff
                        Hediff hediff = HediffMaker.MakeHediff(hediffType, pawn);
                        hediff.Severity = randomSeverity;
                        pawn.health.AddHediff(hediff);

                        //Add Thought
                        pawn.needs.mood.thoughts.memories.TryGainMemory(victimThought, launcher as Pawn);
                        Pawn shooter = launcher as Pawn;
                        shooter.needs.mood.thoughts.memories.TryGainMemory(shooterThought);
                    }
                    else return;
                }
            }
        }
    }
}
