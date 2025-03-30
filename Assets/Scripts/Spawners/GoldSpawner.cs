using Interactables.PositiveInteractables;

namespace Spawners
{
    public class GoldSpawner : GenericSpawner<BonusGold>
    {
        protected override void InitObject(BonusGold bonusGold)
        {
            bonusGold.Init(GetObjectPool());
        }
    }
}