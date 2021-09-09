using Commandliner.Models;
using System.Collections.Generic;

namespace Commandliner.Data
{
    public interface ICommanderRepo
    {
        // This method must be called to save any changes from Create/Update methods
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
