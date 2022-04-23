using _0_Framework.Application;
using _01_framework.Infrastracture;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastracture.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }
        public List<AccountViewModel> GetAccounts(AccountSearchModel accountSearch)
        {
            var query = _context.Accounts.Include(p => p.Role).Select(p => new AccountViewModel
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
                Role = p.Role.Name,
                CreationDate = p.CreationDate.ToFarsi(),
                FullName = p.FullName,
                Profile = p.Profile,
                RoleId = p.RoleId,
                UserName = p.UserName
            });

            if (!string.IsNullOrWhiteSpace(accountSearch.UserName))
                query = query.Where(p => p.UserName == accountSearch.UserName);

            if (!string.IsNullOrWhiteSpace(accountSearch.FullName))
                query = query.Where(p => p.UserName == accountSearch.FullName);

            if (accountSearch.ReleId > 0)
                query = query.Where(p => p.RoleId == accountSearch.ReleId);

            return query.OrderByDescending(p => p.Id).ToList();

        }

        public Account GetBy(string username)
        {
            return _context.Accounts.Include(p => p.Role).FirstOrDefault(p => p.UserName == username);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(p =>new AccountViewModel
            {
                Id = p.Id,
                FullName = p.FullName
            }).ToList();
        }

        public Edit GetDetails(long Id)
        {
            return _context.Accounts.Include(p => p.Role).Select(p => new Edit
            {

                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
                FullName = p.FullName,
                RoleId = p.RoleId,
                UserName = p.UserName

            }).FirstOrDefault(p => p.Id == Id);
        }
    }
}
