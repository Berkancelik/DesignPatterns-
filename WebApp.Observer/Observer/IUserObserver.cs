using BaseProject.Web.Models;

namespace WebApp.Observer.Web.Observer
{
    public interface IUserObserver
    {
        void UserCreated(AppUser appUser);
    }
}
