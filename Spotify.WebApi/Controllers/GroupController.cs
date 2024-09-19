using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Groups.Queries.GetGroupDetails;
using Spotify.Application.Groups.Queries.GetGroupList;
using Spotify.Application.Groups.Commands.DeleteCommand;
using Spotify.Application.Groups.Commands.UpdateGroup;
using Spotify.WebApi.Models;
using Spotify.Application.Groups.Commands.CreateGroup;

namespace Spotify.WebApi.Controllers;

[Route("[controller]")]
public class GroupController : BaseController
{
    private readonly IMapper _mapper;

    public GroupController(IMapper mapper) => _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<GroupListVM>> GetAll(GetGroupListQuery query)
    {
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GroupDetailsVM>> Get(int id)
    {
        var query = new GetGroupDetailsQuery
        {
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createNoteDto)
    {
        var command = _mapper.Map<CreateGroupCommand>(createNoteDto);
        var noteId = await Mediator.Send(command);
        return Ok(noteId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGroupDto updateNoteDto)
    {
        var command = _mapper.Map<UpdateGroupCommand>(updateNoteDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteGroupCommand
        {
            Id = id,
        };
        await Mediator.Send(command);
        return NoContent();
    }
}