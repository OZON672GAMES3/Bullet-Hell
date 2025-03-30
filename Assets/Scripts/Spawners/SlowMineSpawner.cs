using Interactables.NegativeInteractables;

namespace Spawners
{
    public class SlowMineSpawner : GenericSpawner<SlowMine>
    {
        protected override void InitObject(SlowMine slowMine)
        {
            slowMine.Init(GetObjectPool());
        }
    }
}