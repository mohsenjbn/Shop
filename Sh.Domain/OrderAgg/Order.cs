using _01_framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public long AccountId { get; private set; }
        public int PaymentMethod { get;private set; }
        public double PayAmount { get; private set; }
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public bool IsPayed { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }
        public List<OrderItem> Items { get;private set; }

        public Order(long accountId,int paymentMethod, double payAmount, double totalAmount, double discountAmount)
        {
            AccountId = accountId;
            PaymentMethod = paymentMethod;
            PayAmount = payAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            IsCanceled = false;
            IsPayed = false;
            Items = new List<OrderItem>();
            RefId = 0;
        }

        public void IsSuccessPayment(long refId)
        {
            IsPayed = true;
            if (refId != 0)
                RefId = refId;
        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }

        public void Add(OrderItem item)
        {
            Items.Add(item);
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
