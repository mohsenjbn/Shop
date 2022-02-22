using _01_framework.Domain;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount:EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscoiuntRate { get; private set; }
        public bool IsRemove { get; private set; }

        public ColleagueDiscount(long productId, int discoiuntRate)
        {
            ProductId = productId;
            DiscoiuntRate = discoiuntRate;
            IsRemove = false;
        }

        public void Edit(long productId, int discoiuntRate)
        {
            ProductId = productId;
            DiscoiuntRate = discoiuntRate;
        }

        public void Active()
        {
            IsRemove = false;    
        }

        public void Remove()
        {
            IsRemove = true;
        }
    }
}
