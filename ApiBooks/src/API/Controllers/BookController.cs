
using BookStore.Application.Books.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController: ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBooksQuery());

        return Ok(result);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBookByIdQuery{BookId = id});

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand bookCommand)
    {
        await _mediator.Send(bookCommand);

        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Create(Guid id,
                                            [FromBody] UpdateBookCommand bookCommand)
    {
        if (id != bookCommand.BookId)
            return BadRequest();
        
        await _mediator.Send(bookCommand);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteBookCommand { BookId = id });
        return NoContent();
    }

}