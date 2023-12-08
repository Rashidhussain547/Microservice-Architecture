using System.ComponentModel.DataAnnotations;

namespace MicroserviceProject.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get ; set; }
        public bool IsCompleted { get; set; }
    }
}


