using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models.Domain
{
    public class Task
    {
        public Guid Id
        {get; set;
        }
        public string Name { get; set; }
        public int Seq { get; set; }
        public string Executor { get; set; }   
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Attachment { get; set; }
        public string Priority { get; set; }
        public Guid TaskListId { get; set; }
        //public List<Todo> Todos { get; set; }

    }
}
