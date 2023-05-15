namespace TaskManagerAPI.Models.DTO
{
    public class TasksGetAllRequestDto
    {
       
        public TasksGetAllRequestDto(Guid id, string name, int seq, string executor, string description, DateTime deadline, string attachment, string priority, Guid taskListId, List<TodoGetAllRequestDto> todoLists)
        {
            Id = id;
            Name = name;
            Seq = seq;
            Executor = executor;
            Description = description;
            Deadline = deadline;
            Attachment = attachment;
            Priority = priority;
            TaskListId = taskListId;
            TodoLists = todoLists;
        }

        public Guid Id
        {
            get; set;
        }
        public string Name { get; set; }
        public int Seq { get; set; }
        public string Executor { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Attachment { get; set; }
        public string Priority { get; set; }
        public Guid TaskListId { get; set; }
        public List<TodoGetAllRequestDto> TodoLists { get; set; }
    }

}
