using System.Security.AccessControl;

namespace _01_framework.Application.Zarinpal
{
    public class PaymentResponse
    {
       
        public int Status { get; set; }
        public string Authority { get; set; }
        public string Mode { get; set; }

        public PaymentResponse(int status, string authority,string mode)
        {
            Status = status;
            Authority = authority;
            Mode = mode;
        }
    }
}
