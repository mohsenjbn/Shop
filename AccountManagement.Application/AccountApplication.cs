using _01_framework.Application;
using _01_framework.Application.PasswordHashing.PasswordHashingService;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploder _fileUploder;
        private readonly IPasswordHashingService _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _rolerepository;

        public AccountApplication(IAccountRepository accountRepository, IFileUploder fileUploder, IPasswordHashingService passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _fileUploder = fileUploder;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _rolerepository = roleRepository;
        }

        public OperationResult ChanagePassword(ChangePassword command)
        {
            var operation=new OperationResult();
            var Account=_accountRepository.GetBy(command.Id);
            if (Account == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (command.Password != command.Repassword)
                return operation.Failed(ResultMessage.PasswordsNotMatch);

            var password=_passwordHasher.HashPassword(command.Password);
            Account.ChangePassword(password);
            _accountRepository.Savechanges();

            return operation.IsSucssed();


        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public OperationResult CreateAccount(Contracts.Account.Create command)
        {
            var operation = new OperationResult();

            if (_accountRepository.IsExist(p => p.UserName == command.UserName || p.PhoneNumber == command.PhoneNumber))
                return operation.Failed(ResultMessage.IsDoblicated);

            var password = _passwordHasher.HashPassword(command.PassWord);
            var path = $"Accountprofiles";
            var picture = _fileUploder.Upload(command.Profile, path);

            var Account=new Account(command.FullName,command.UserName,command.PhoneNumber,password,picture,command.RoleId);
            _accountRepository.Create(Account);
            _accountRepository.Savechanges();

            return operation.IsSucssed();
        }

        public OperationResult EditAccount(Contracts.Account.Edit command)
        {
            var operation = new OperationResult();
            var account=_accountRepository.GetBy(command.Id);

            if (account == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_accountRepository.IsExist(p => (p.UserName == command.UserName || p.PhoneNumber == command.PhoneNumber) && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            var path = $"Accountprofiles";
            var picture = _fileUploder.Upload(command.Profile, path);
            account.Edit(command.FullName, command.UserName, command.PhoneNumber, picture, command.RoleId);
            _accountRepository.Savechanges();

            return operation.IsSucssed();
        }

        public List<AccountViewModel> GetAccounts(AccountSearchModel accountSearch)
        {
           return _accountRepository.GetAccounts(accountSearch);
        }

        public Contracts.Account.Edit GetDetails(long Id)
        {
           return _accountRepository.GetDetails(Id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ResultMessage.WrongRegisteOrLogin);
            
            var password=_passwordHasher.VerifyHashedPassword(account.PassWord,command.Password);
            if(password!=true)
            {
                return operation.Failed(ResultMessage.WrongRegisteOrLogin);

            }
            var Promissions=_rolerepository.GetBy(account.RoleId).Permossions.Select(p=>p.Code).ToList();
            var authModel = new AuthviewModel(account.Id, account.FullName, account.UserName, account.PhoneNumber, account.RoleId, account.Role.Name,Promissions);
            _authHelper.Singin(authModel);

            return operation.IsSucssed();
        }

        public OperationResult Logout()
        {
            var operation = new OperationResult();
            _authHelper.Singout();

          return  operation.IsSucssed();
            
        }
    }
}