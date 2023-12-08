using MicroserviceProject.Models;

namespace MicroserviceProject.Repository
{
    public interface ITodoRepository 
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemByIdAsync(int id);
        Task CreateTodoItemAsync(TodoItem todoItem);
        Task UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(int id);
    }

}
