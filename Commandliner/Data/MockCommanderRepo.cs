using Commandliner.Models;
using System;
using System.Collections.Generic;

namespace Commandliner.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "get knife", Platform = "Knife & Chopping board" },
                new Command { Id = 2, HowTo = "Make cup of tea", Line = "place teabag in cup", Platform = "Kettle & Cup" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            // You can initialize properties in curly braces without a constructor! Neat!
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "boil water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
