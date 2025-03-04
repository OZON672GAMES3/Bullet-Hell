namespace Interactables
{
    public interface IPoolable
    {
        void OnGet();
        void OnRelease();
    }
}