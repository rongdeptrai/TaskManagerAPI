namespace TaskManagerAPI.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public bool? Status { get; set; }
        public Guid TaskId { get; set; }

        //public List<TodoProgress> Progress { get; set; }

    }
}
