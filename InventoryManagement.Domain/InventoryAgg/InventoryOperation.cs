namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Describtion { get;private set; }
        public long OrderId { get;private set; }
        public long InventoryId { get;private set; }

        public Inventory inventory { get; private set; }
        protected InventoryOperation() { }
       
        public InventoryOperation(bool operation, long count, long operatorId, long currentCount, string describtion, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Describtion = describtion;
            OrderId = orderId;
            InventoryId = inventoryId;
            CreationDate=DateTime.Now;
        }
    }

}
