namespace TaskManagerAPI.Models.Domain
{
    public class TodoProgress
    {
        public Guid Id { get; set; }
        public int Seq { get; set; }
        public bool? Status { get; set; }
        public Guid TodoId { get; set; }
    }
}
