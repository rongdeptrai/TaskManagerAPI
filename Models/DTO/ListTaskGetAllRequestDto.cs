namespace TaskManagerAPI.Models.DTO
{
    public class ListTaskGetAllRequestDto
    {
 

        public ListTaskGetAllRequestDto(Guid id, string name, List<TasksGetAllRequestDto> cards)
        {
            Id = id;
            Name = name;
            Cards = cards;
        }

        public Guid Id
        {
            get; set;
        }
        public string Name { get; set; }
        public List<TasksGetAllRequestDto>? Cards { get; set; }


    }
}
