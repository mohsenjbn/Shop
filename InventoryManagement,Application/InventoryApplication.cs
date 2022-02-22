using _01_framework.Application;
using InventoryManagement.Domain.InventoryAgg;
using Invertory.Application.Contracts.Inventory;

namespace InventoryManagement.Application

{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var Operation = new OperationResult();

            if (_inventoryRepository.IsExist(p => p.ProductId == command.ProductId))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var Inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(Inventory);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult Edit(UpdateInventory command)
        {
            var Operation = new OperationResult();

            var inventory=_inventoryRepository.GetBy(command.Id);
            if (inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_inventoryRepository.IsExist(p => p.ProductId == command.Id && p.Id != command.Id))
                return Operation.Failed(ResultMessage.IsDoblicated);

            inventory.Edit(command.ProductId,command.UnitPrice);
            _inventoryRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public List<InventoryViewModel> GetAll(InventorySeacrModel seacrhModel)
        {
            return _inventoryRepository.GetAll(seacrhModel);
        }

        public UpdateInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public OperationResult Increase(Increase command)
        {
            var Operation=new OperationResult();

            var inventory=_inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);
            const long operatorId= 1;
            inventory.Increase(command.Count, operatorId, command.Describtion);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public List<InventoryOperationViewModel> InventoryOperations(long InventoryId)
        {
            return _inventoryRepository.InventoryOperations(InventoryId);
        }

        public OperationResult Reduce(Reduce command)
        {
            var Operation = new OperationResult();

            var inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);
            const long operatorId = 1;
            inventory.Reduce(command.Count, operatorId, command.Describtion, 0);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult Reduce(List<Reduce> command)
        {
            var Operation=new OperationResult();
            const long operatorId = 0;

            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.InventoryId);
                inventory.Reduce(item.Count, operatorId, item.Describtion, item.OrderId);
            }

            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }
    }
}