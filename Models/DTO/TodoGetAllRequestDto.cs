using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Models.DTO
{
    public class TodoGetAllRequestDto
    {
        private List<TodoProgressGetAllRequestDto> todoPgList;

        public TodoGetAllRequestDto(Guid id, string name, bool? status, Guid taskId, List<TodoProgressGetAllRequestDto> todoPgList)
        {
            Id = id;
            Name = name;
            Status = status;
            TaskId = taskId;
            this.todoPgList = todoPgList;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public Guid TaskId { get; set; }
        public List<TodoProgressGetAllRequestDto> Listprops { get; set; }
    }
}
