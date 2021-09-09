using AutoMapper;
using Commandliner.Dtos;
using Commandliner.Models;

namespace Commandliner.Profiles
{
    public class CommandsProfile : Profile
    {
        // Mapper profiles are what tell AutoMapper what types it can map between
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
