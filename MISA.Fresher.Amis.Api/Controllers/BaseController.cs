using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.InterFace.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        private readonly IBaseService<TEntity> _baseService;
        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _baseService.GetAll();
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            try
            {
                var result = _baseService.GetById(entityId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Insert([FromBody] TEntity entity)
        {
          
                var reuslt = _baseService.Insert(entity);
                return Ok(reuslt);
            
        }
        [HttpPut("{entityId}")]
        public IActionResult Update(Guid entityId, [FromBody] TEntity entity)
        {
            var reuslt = _baseService.Update(entityId, entity);
            return Ok(reuslt);
        }
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var reuslt = _baseService.Delete(entityId);
                return Ok(reuslt);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
