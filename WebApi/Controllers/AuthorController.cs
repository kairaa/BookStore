using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Common;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using WebApi.AuthorOperations.GetAuthors;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.AuthorOperations.DeleteAuthor;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.AuthorOperations.UpdateAuthor;

namespace WebApi.AddControllers
{
  [ApiController]
  [Route("[controller]s")]
  public class AuthorController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly AuthorDBContext _context;

    public AuthorController(AuthorDBContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
      GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      AuthorDetailViewModel result;
      GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
      query.AuthorId = id;

      GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
      validator.ValidateAndThrow(query);

      result = query.Handle();
      return Ok(result);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
    {
      CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

      command.Model = newAuthor;

      CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok(); 
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateAuthorModel updatedAuthor)
    {
      UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
      command.Model = updatedAuthor;
      command.AuthorId = id;

      UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok(); 
    }

    [HttpDelete]
    public IActionResult DeleteAuthor(int id)
    {
      DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
      command.AuthorId = id;

      DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      
      return Ok();
    }
  }
}