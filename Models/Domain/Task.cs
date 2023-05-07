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
        public string Description { get; set; }
    }
}
