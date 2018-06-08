using RimWorld;
using System.Collections.Generic;
using Verse;

namespace FireOnDemand
{
    class Verb_FlickLighter : Verb_LaunchProjectile
    {
        
        public bool SuccessfulFlick()
        {
            float ChanceToSpark = 0.74f;
            var roll = Rand.Value;
            if (roll <= ChanceToSpark)
            {

                return true;

            }
            MoteMaker.ThrowText(base.caster.PositionHeld.ToVector3(), base.CasterPawn.MapHeld, $"Lighter failed to light");
            return false;
        }

        protected override bool TryCastShot()
        {
            bool flag = base.TryCastShot();
            bool flick = SuccessfulFlick();
           
            return flag && flick;
        }
    }
}
