using TaskManagerAPI.Models.DTO;

namespace TaskManagerAPI.Repositories.TaskList
{
    public interface ITaskListRepository
    {
        List<ListTaskGetAllRequestDto> GetAllListTask();
    }
}
