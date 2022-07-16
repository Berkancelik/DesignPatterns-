using BaseProject.Web.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace WebApp.Observer.Web.Observer
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();

            var context = _serviceProvider.GetRequiredService<Context>();
            context.Discounts.Add(new Models.Discount { Rate = 10, UserId = appUser.Id });
            context.SaveChanges();
            logger.LogInformation("Discount Created");

            throw new System.NotImplementedException();
        }
    }
}
