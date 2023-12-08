using MicroserviceProject.Models;
using MicroserviceProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await _todoRepository.GetTodoItemsAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(int id)
        {
            var todoItem = await _todoRepository.GetTodoItemByIdAsync(id);
            if (todoItem == null)
                return NotFound();

            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
        {
            await _todoRepository.CreateTodoItemAsync(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                Console.WriteLine($"Mismatched id values: {id} (route) and {todoItem.Id} (payload)");
                return BadRequest("Mismatched id values");
            }

            try
            {
                await _todoRepository.UpdateTodoItemAsync(todoItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating TodoItem: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            await _todoRepository.DeleteTodoItemAsync(id);
            return NoContent();
        }

    }

}
