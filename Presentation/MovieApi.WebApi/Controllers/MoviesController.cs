using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetMovieWithCategoryQueryHandler _getMovieWithCategoryQueryHandler;


        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, GetMovieWithCategoryQueryHandler getMovieWithCategoryQueryHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieWithCategoryQueryHandler = getMovieWithCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        => Ok(await _getMovieQueryHandler.Handle());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
            => Ok(await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Film güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Film silme işlemi başarılı");
        }

        [HttpGet("with-category")]
        public async Task<IActionResult> GetMovieWithCategory()
            => Ok(await _getMovieWithCategoryQueryHandler.Handle());
    }
}

