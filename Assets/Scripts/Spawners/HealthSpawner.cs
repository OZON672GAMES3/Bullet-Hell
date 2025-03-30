using Interactables.PositiveInteractables;

namespace Spawners
{
    public class HealthSpawner : GenericSpawner<BonusHealthKit>
    {
        protected override void InitObject(BonusHealthKit bonusHealthKit)
        {
            bonusHealthKit.Init(GetObjectPool());
        }
    }
}