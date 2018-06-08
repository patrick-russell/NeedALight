using RimWorld;
using Verse;

namespace FireOnDemand
{
    class Projectile_FireStarterSpark : Bullet
    {
        public ThingDef_FireStarterSpark Def
        {
            get
            {
                return def as ThingDef_FireStarterSpark;
            }
        }

        protected override void Impact(Thing hitThing)
        {
            // This works. so if I check they are a pawn, I should be able to make them the hit thing and be done with it
            var roll = Rand.Value;
            bool BurnsSelf = roll <= Def.ChanceToBurnSelf ? true : false;
            Map map = base.Map;
            if (BurnsSelf && base.launcher is Pawn)
            {
                Messages.Message($"{base.launcher.Label} was burned by {base.equipmentDef.label}", MessageTypeDefOf.NegativeHealthEvent);
                base.Impact(base.launcher);
            }
            else
            {
                base.Impact(hitThing);
            }
            FireUtility.TryStartFireIn(base.Position, map, 0.05f);
        }
    }
}