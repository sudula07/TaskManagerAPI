using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Model
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
