using _0_Framework.Application;
using _01_framework.Application;
using _01_framework.Application.PasswordHashing.PasswordHashingService;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploder _fileUploder;
        private readonly IPasswordHashingService _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IFileUploder fileUploder, IPasswordHashingService passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploder = fileUploder;
            _passwordHasher = passwordHasher;
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

        public OperationResult CreateAccount(Create command)
        {
            var operation = new OperationResult();

            if (_accountRepository.IsExist(p => p.UserName == command.UserName || p.PhoneNumber == command.PhoneNumber))
                return operation.Failed(ResultMessage.IsDoblicated);

            var password = _passwordHasher.HashPassword(command.PassWord);
            var path = $"Accountprofiles";
            var picture = _fileUploder.Upload(command.Profile, path);

            var Account=new Account(command.FullName,command.UserName,command.PhoneNumber,password,picture,command.RoleId);
            _accountRepository.Savechanges();

            return operation.IsSucssed();
        }

        public OperationResult EditAccount(Edit command)
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

        public Edit GetDetails(long Id)
        {
           return _accountRepository.GetDetails(Id);
        }
    }
}