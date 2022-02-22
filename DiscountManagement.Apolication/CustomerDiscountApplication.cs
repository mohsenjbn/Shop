using _0_Framework.Application;
using _01_framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Apolication
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepositpry _customerDiscountRepositpry;

        public CustomerDiscountApplication(ICustomerDiscountRepositpry customerDiscountRepositpry)
        {
            _customerDiscountRepositpry = customerDiscountRepositpry;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var Operation=new OperationResult();

            if (_customerDiscountRepositpry.IsExist(p => p.ProductId == command.ProductId && p.DiscountRate == command.DiscountRate))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            var discount =new CustomerDiscount(command.ProductId,command.DiscountRate,startDate,endDate,command.Reason);
            _customerDiscountRepositpry.Create(discount);
            _customerDiscountRepositpry.Savechanges();
            return Operation.IsSucssed();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var Operation = new OperationResult();
            var customerdiscount = _customerDiscountRepositpry.GetBy(command.Id);

            if(customerdiscount == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_customerDiscountRepositpry.IsExist(x => x.ProductId == command.ProductId
             && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerdiscount.Edit(command.ProductId, command.DiscountRate, startDate, endDate, command.Reason);
            _customerDiscountRepositpry.Savechanges();

            return Operation.IsSucssed();
        }

        public List<CustomerDiscountViewModel> GetAll(SearchCustomerDiscunt searchmodel)
        {
            return _customerDiscountRepositpry.GetAll(searchmodel);
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepositpry.GetDetails(id);
        }
    }
}