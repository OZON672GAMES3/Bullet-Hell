using Interactables.NegativeInteractables;

namespace Spawners
{
    public class MinesSpawner : GenericSpawner<DamageMine>
    {
        protected override void InitObject(DamageMine damageMine)
        {
            damageMine.Init(GetObjectPool());
        }
    }
}
