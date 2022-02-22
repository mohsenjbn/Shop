using _01_framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool Instock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Instock = false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;

        }

        public long CurrentCountInventory()
        {
            var plus = Operations.Where(p => p.Operation).Sum(p => p.Count);
            var minus = Operations.Where(p => p.Operation==false).Sum(p => p.Count);
            return plus - minus;
        }

        public void Increase(long count, long operatorId, string describtion)
        {
            var currentcunt = CurrentCountInventory() + count;
            var Operation = new InventoryOperation(true, count, operatorId, currentcunt, describtion, 0, Id);
            Operations.Add(Operation);
            Instock = currentcunt > 0;
        }

        public void Reduce(long count, long operatorId, string describtion, long orderid)
        {
            var currentcunt = CurrentCountInventory() - count;
            var Operation = new InventoryOperation(false, count, operatorId, currentcunt, describtion, orderid, Id);
            Operations.Add(Operation);
            Instock = currentcunt > 0;


        }

      
    }

}
