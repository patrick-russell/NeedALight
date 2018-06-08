using RimWorld;
using Verse;

namespace FireOnDemand
{
    class ThingDef_FireStarterSpark : ThingDef
    {
        public float ChanceToBurnSelf = .07f;
        public HediffDef HediffToAdd = HediffDefOf.Burn;

    }
}