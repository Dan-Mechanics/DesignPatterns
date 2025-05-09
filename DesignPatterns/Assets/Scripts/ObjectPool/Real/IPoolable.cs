namespace DesignPatterns 
{
    public interface IPoolable
    {
        bool Active { get; set; }
        void Enable();
        void Disable();
        void Dump();
    }
}