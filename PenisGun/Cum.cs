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
        public ModExtension_PenisGun Extenstion => def.GetModExtension<ModExtension_PenisGun>();

        HediffDef hediffType;
        ThoughtDef specialThought;
        ThoughtDef basicThought;
        ThoughtDef shooterThought;

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            hediffType = Extenstion.hediffToAdd;
            specialThought = Extenstion.specialThought;
            basicThought = Extenstion.basicThought;
            shooterThought = Extenstion.shooterThought;

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
                        //Create thought
                        pawn.needs.mood.thoughts.memories.TryGainMemory(specialThought);
                        pawn.needs.mood.thoughts.memories.TryGainMemory(basicThought);

                        Pawn shooter = launcher as Pawn;
                        shooter.needs.mood.thoughts.memories.TryGainMemory(shooterThought);

                        //Create HeDiff
                        Hediff hediff = HediffMaker.MakeHediff(hediffType, pawn);
                        hediff.Severity = randomSeverity;
                        pawn.health.AddHediff(hediff);
                    }

                    return;
                }
            }
        }
    }
}
