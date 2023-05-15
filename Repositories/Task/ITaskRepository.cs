using System.Drawing;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Models.DTO;

namespace TaskManagerAPI.Repositories.Task
{
    public interface ITaskRepository
    {
        List<ListTaskGetAllRequestDto> GetAllAsync();
    }
}
