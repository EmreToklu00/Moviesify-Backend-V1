using Business.Abstract;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet(template: "getbyid")]
        public ActionResult GetById(Guid publisherId)
        {
            var result = _publisherService.GetById(publisherId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public ActionResult GetList()
        {
            var result = _publisherService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public ActionResult Add(PublisherDTO publisher)
        {
            var result = _publisherService.Add(publisher);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut(template: "update")]
        public ActionResult Update(PublisherDTO publisher)
        {
            var result = _publisherService.Update(publisher);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete(template: "delete")]
        public ActionResult Delete(Guid publisherId)
        {
            var result = _publisherService.Delete(publisherId);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
