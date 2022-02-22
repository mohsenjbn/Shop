using _01_framework.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagment.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Apolication
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Active(long id)
        {
            var Operation = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.GetBy(id);

            if (ColleagueDiscount == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);



            ColleagueDiscount.Active();
            _colleagueDiscountRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public OperationResult Define(Define command)
        {
            var Operation=new OperationResult();
            if (_colleagueDiscountRepository.IsExist(p => p.ProductId == command.ProductId && p.DiscoiuntRate == command.DiscountRate))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var ColleagueDiscount=new ColleagueDiscount(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.Create(ColleagueDiscount);
            _colleagueDiscountRepository.Savechanges();

            return Operation.IsSucssed();
        }

        public OperationResult Edit(Edit command)
        {
            var Operation = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.GetBy(command.Id);

            if(ColleagueDiscount == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_colleagueDiscountRepository.IsExist(p => p.ProductId == command.ProductId && p.DiscoiuntRate == command.DiscountRate && p.Id != ColleagueDiscount.Id))
                return Operation.Failed(ResultMessage.IsDoblicated);

            ColleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Savechanges();

            return Operation.IsSucssed();


        }

        public List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearch search)
        {
            return _colleagueDiscountRepository.GetAll(search);
        }

        public Edit GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var Operation = new OperationResult();
            var ColleagueDiscount = _colleagueDiscountRepository.GetBy(id);

            if (ColleagueDiscount == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            

            ColleagueDiscount.Remove();
            _colleagueDiscountRepository.Savechanges();

            return Operation.IsSucssed();
        }
    }
}
