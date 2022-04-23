namespace _01_framework.Application.Zarinpal
{
    public interface IZarinpalFactory
    {
        PaymentResponse CreatePayment(string phoneNumber, string email, string describtion, string amount, long orderId);
        VerificationResponse CreateVerificationRequest(string authority, string amount);
    }
}
