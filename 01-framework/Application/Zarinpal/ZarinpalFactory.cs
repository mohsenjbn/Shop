using Dto.Payment;
using Microsoft.Extensions.Configuration;
using ZarinPal.Class;

namespace _01_framework.Application.Zarinpal;

public class ZarinpalFactory : IZarinpalFactory
{
    public string MerchantId { get; set; }
    public string SiteUrl { get; set; }
    public string Mode { get; set; }
    private readonly IConfiguration _configuration;
    public ZarinpalFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        MerchantId = _configuration.GetSection("payment")["merchant"];
        SiteUrl = _configuration.GetSection("payment")["siteUrl"];
        Mode = _configuration.GetSection("payment")["method"];
    }
    public PaymentResponse CreatePayment(string phoneNumber, string email, string describtion, string amount, long orderId)
    {

        var expose = new Expose();
        var payment = expose.CreatePayment();


        amount = amount.Replace(",", "");
        var finalAmount = int.Parse(amount);

        var result = payment.Request(new DtoRequest()
        {
            Mobile = phoneNumber,
            CallbackUrl = $"https://{SiteUrl}/CheckOut?handler=CallBack&orderId={orderId}",
            Description = describtion,
            Email = email,
            Amount = finalAmount,
            MerchantId = MerchantId,
        }, Mode == "sandbox" ? Payment.Mode.sandbox : Payment.Mode.zarinpal);

        var response = new PaymentResponse(result.Result.Status, result.Result.Authority, Mode);


        return response;
    }

    public VerificationResponse CreateVerificationRequest(string authority, string amount)
    {
        var expose = new Expose();
        var payment = expose.CreatePayment();
        var verification = payment.Verification(new DtoVerification
        {
            Amount = int.Parse(amount),
            MerchantId = MerchantId,
            Authority = authority
        },  Mode == "sandbox" ? Payment.Mode.sandbox : Payment.Mode.zarinpal);

        var result = new VerificationResponse(verification.Result.Status,verification.Result.RefId);

        return result;
    }
}