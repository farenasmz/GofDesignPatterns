using AbstractFactory.Rest;
using AbstractFactory.WebService;

namespace AbstractFactory.Factory
{
    public class AbstractFactory
    {
        readonly ServiceType ServiceType;

        public AbstractFactory(ServiceType serviceType)
        {
            ServiceType = serviceType;
        }

        public IAbstractFactory CreateFactory()
        {
            switch (ServiceType)
            {
                case ServiceType.Rest:
                    return new RestServiceImplementation();
                case ServiceType.WebService:
                    return new WSServiceImplementation();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
