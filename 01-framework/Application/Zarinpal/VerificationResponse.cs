namespace _01_framework.Application.Zarinpal
{
    public class VerificationResponse
    {
        
        public int Status { get; set; }
        public int RefId { get; set; }

        public VerificationResponse(int status,int refId)
        {
            Status = status;
            RefId= refId;
        }
    }
}
