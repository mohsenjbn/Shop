namespace _01_framework.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();
        void Singin(AuthviewModel model);
        void Singout();
    }
}
