using _01_framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long,Account>
    {
        List<AccountViewModel> GetAccounts(AccountSearchModel accountSearch);
        Edit GetDetails(long Id);
    }
}
