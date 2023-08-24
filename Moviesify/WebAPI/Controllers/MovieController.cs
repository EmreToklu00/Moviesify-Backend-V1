using Business.Abstract;
using Entity.DTO;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(template: "getbyid")]

        public ActionResult GetById(Guid movieId)
        {
            var result = _movieService.GetById(movieId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public ActionResult GetList()
        {
            var result = _movieService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet(template: "getlistbycategory")]

        public ActionResult GetListByCategory(Guid categoryId)
        {
            var result = _movieService.GetListByCategory(categoryId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "add")]
        public ActionResult Add(MovieDTO movie)
        {
            var result = _movieService.Add(movie);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut(template: "update")]
        public ActionResult Update(MovieDTO movie)
        {
            var result = _movieService.Update(movie);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete(template: "delete")]
        public ActionResult Delete(Guid movieId)
        {
            var result = _movieService.Delete(movieId);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
