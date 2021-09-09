using AutoMapper;
using Commandliner.Data;
using Commandliner.Dtos;
using Commandliner.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Commandliner.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase // ControllerBase has no View support, unlike Controller
    {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")] // id from route is bound to id parameter in the GetCommandById method
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null) return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            // Allows us to pass back the resource that was created, and the location where
            // it was created + 201 Created response code
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }


        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) return NotFound();

            // Here we're mapping from an object that already exists to another object that already exists
            // NOT an empty object like before
            // This code takes care of updating the object, that's why our current _repository.UpdateCommand() implementation
            // does nothing. But we're still calling it in case we swap out our implementation for something that does have code in it
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // Why are we passing in the instance that already exists in our DB?.. Shouldn't it be a Command cmd  object mapped
            // from the commandUpdateDto?
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) return NotFound();

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
