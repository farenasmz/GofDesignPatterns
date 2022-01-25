namespace Prototype.Implementation
{
    public interface IPrototype
    {
        IPrototype Clone();
        IPrototype DeepClone();
    }
}
