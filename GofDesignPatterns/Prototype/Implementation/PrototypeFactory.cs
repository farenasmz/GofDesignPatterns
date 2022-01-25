namespace Prototype.Implementation
{
    public class PrototypeFactory
    {
        private static Dictionary<string, IPrototype> Prototype = new();

        public static IPrototype GetPrototype(string prototypeName)
        {
            return Prototype[prototypeName].DeepClone();
        }

        public static void AddPrototype(string prototypeName, IPrototype prototype)
        {
            Prototype.Add(prototypeName, prototype);
        }
    }
}
