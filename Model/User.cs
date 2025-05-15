using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<TaskComment> TaskComments { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
    public class CreateTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }


}
