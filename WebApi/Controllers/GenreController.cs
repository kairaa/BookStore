using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.CreateGenre;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.Application.GenreOperations.GetGenreDetail;
using WebApi.Application.GenreOperations.GetGenres;
using WebApi.Application.GenreOperations.UpdateGenre;
using WebApi.DBOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]

    public class GenreController : ControllerBase
    {
      private readonly IMapper _mapper;
      private readonly BookStoreDBContext _context;

    public GenreController(BookStoreDBContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
      GetGenresQuery query = new GetGenresQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      GenreDetailViewModel result;
      GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
      query.GenreId = id;

      GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
      validator.ValidateAndThrow(query);

      result = query.Handle();
      return Ok(result);
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreModel newAuthor)
    {
      CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);

      command.Model = newAuthor;

      CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok(); 
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
    {
      UpdateGenreCommand command = new UpdateGenreCommand(_context);
      command.Model = updatedGenre;
      command.GenreId = id;

      UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok(); 
    }

    [HttpDelete]
    public IActionResult DeleteAuthor(int id)
    {
      DeleteGenreCommand command = new DeleteGenreCommand(_context);
      command.GenreId = id;

      DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      
      return Ok();
    }
  }
}