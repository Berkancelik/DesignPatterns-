using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Command.Commands
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}
