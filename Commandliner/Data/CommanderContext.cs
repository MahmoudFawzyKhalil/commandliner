using Commandliner.Models;
using Microsoft.EntityFrameworkCore;

namespace Commandliner.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }

        // Maps our Command.cs model to a table Commands in the SQL database
        public DbSet<Command> Commands { get; set; }

    }
}
