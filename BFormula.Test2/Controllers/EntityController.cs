using Microsoft.AspNetCore.Mvc;

namespace BFormula.Test2.Controllers;

[ApiController]
[Route("[controller]")]
public class EntityController : ControllerBase
{
    private readonly IEntityRepository _repository;
    private readonly ILogger<EntityController> _logger;

    public EntityController(IEntityRepository repository,
        ILogger<EntityController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet(Name = "{id}")]
    public ActionResult<Entity?> Get(Guid id)
    {
        try
        {
            return Ok(_repository.Get(id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{id}");
            throw;
        }
    }

    [HttpPost]
    public ActionResult Set([FromBody]Entity entity)
    {
        try
        {
            return _repository.Set(entity) ? Ok() : BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{entity?.Id}");
            throw;
        }
    }
}