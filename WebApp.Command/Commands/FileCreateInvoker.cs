using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Command.Commands
{
    public class FileCreateInvoker
    {
        private  ITableActionCommand _actionCommand;
        private List<ITableActionCommand> tableActionCommands = new List<ITableActionCommand>();

        public void SetCommand(ITableActionCommand tableActionCommand)
        {
            _actionCommand = tableActionCommand;
        }

        public void AddCommand(ITableActionCommand tableActionCommand)
        {
            tableActionCommands.Add(tableActionCommand);
        }

        public List<IActionResult> CreateFile()
        {
             return tableActionCommands.Select(x => x.Execute()).ToList();
        }
    }
}
