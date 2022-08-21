using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles {
    public class CommandsProfile: Profile {
        public CommandsProfile()
        {
            //Source -> Target (Database -> Client)
            CreateMap<Command,CommandReadDto>();
            //Create Target -> Source  (Client -> Databasase)
            CreateMap<CommandCreateDto,Command>();
            //Put
            CreateMap<CommandUpdateDto, Command>();
            //patch - no need for all properties
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}