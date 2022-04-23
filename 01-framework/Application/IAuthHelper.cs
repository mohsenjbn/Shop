namespace _01_framework.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();
        void Singin(AuthviewModel model);
        void Singout();
        string GetCurrentRoleId();
        AuthviewModel GetCurrentUserInfo();
        List<int> GetCurrentPermissions();
        long GetCurrentAccountId();
        
    }
}
