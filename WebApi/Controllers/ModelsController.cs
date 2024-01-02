//using Application.Features.Models.Commands.Create;
//using Application.Features.Models.Commands.Delete;
//using Application.Features.Models.Commands.Update;
//using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Application.Features.Models.Queries.GetListByDynamicByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    //[HttpPost]
    //public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
    //{
    //    CreatedModelResponse response = await Mediator.Send(createModelCommand);
    //    return Ok(response);
    //}

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListModelQuery);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? DynamicQuery = null)
    {
        GetListByDynamicModelQuery getListByDynamicModelQuery = new() { PageRequest = pageRequest, DynamicQuery = DynamicQuery };
        GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(getListByDynamicModelQuery);
        return Ok(response);
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById([FromRoute] Guid id)
    //{
    //    GetByIdModelQuery getByIdModelQuery = new() { Id = id };
    //    GetByIdModelResponse response = await Mediator.Send(getByIdModelQuery);
    //    return Ok(response);
    //}

    //[HttpPut]
    //public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
    //{
    //    UpdatedModelResponse response = await Mediator.Send(updateModelCommand);
    //    return Ok(response);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete([FromRoute] Guid id)
    //{
    //    DeletedModelResponse response = await Mediator.Send(new DeleteModelCommand { Id = id });
    //    return Ok(response);
    //}
}
