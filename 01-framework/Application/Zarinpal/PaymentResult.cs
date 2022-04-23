namespace _01_framework.Application.Zarinpal
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string issueTrackingNo { get; set; }


        public PaymentResult Success(string message, string issueTrakingNo)
        {
            IsSuccess = true;
            Message= message;
            issueTrackingNo = issueTrakingNo;
            return this;
        }

        public PaymentResult Faild(string message)
        {
            IsSuccess = false;
            Message= message;
            return this;
        }
    }
}
