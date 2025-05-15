using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Model
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<TaskComment> Comments { get; set; } = new List<TaskComment>();
    }

}
