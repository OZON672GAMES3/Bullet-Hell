using Interactables.PositiveInteractables;

namespace Spawners
{
    public class ShieldSpawner : GenericSpawner<BonusShield>
    {
        protected override void InitObject(BonusShield bonusShield)
        {
            bonusShield.Init(GetObjectPool());
        }
    }
}