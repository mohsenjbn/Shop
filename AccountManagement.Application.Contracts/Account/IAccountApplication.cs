using _01_framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public interface  IAccountApplication
    {
        OperationResult CreateAccount(Create command);
        OperationResult EditAccount(Edit command);
        List<AccountViewModel> GetAccounts(AccountSearchModel accountSearch);
        Edit GetDetails(long Id);
        OperationResult Login(Login command);
        OperationResult Logout();
        OperationResult ChanagePassword(ChangePassword command);

    }
}
