namespace Facade.Implementation
{
    public interface IPaymentFacade
    {
        PaymentResponse Pay(PaymentRequest request);
    }
}
