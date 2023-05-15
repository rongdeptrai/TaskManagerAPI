namespace TaskManagerAPI.Models.DTO
{
    public class TodoProgressGetAllRequestDto
    {
        public TodoProgressGetAllRequestDto(Guid id, int seq, bool? status, Guid todoId)
        {
            Id = id;
            Seq = seq;
            Status = status;
            TodoId = todoId;
        }

        public Guid Id { get; set; }
        public int Seq { get; set; }
        public bool? Status { get; set; }
        public Guid TodoId { get; set; }

    }
}
