using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;
using System.Linq;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Models.DTO;

namespace TaskManagerAPI.Repositories.TaskList
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly TaskManagementDbContext dbContext;

        public TaskListRepository(TaskManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public   List<Models.Domain.Task> GetAllTask (Guid id)
        {
            var taskListR = dbContext.Tasks.Where(x => x.TaskListId == id).ToList();

            return taskListR;
        }
        public  List<Todo> GetAllTodo(Guid id)
        {
            var toDoR = dbContext.Todo.Where(x => x.TaskId == id).ToList();


                return toDoR;

        }
        public  List<TodoProgress> GetAllTodoPr(Guid id)
        {
            var toDoPgR =  dbContext.TodoProgress.Where(x => x.TodoId == id).ToList();


                return toDoPgR;


        }
        public List<ListTaskGetAllRequestDto> GetAllListTask ()
        {
            var listTask = new List<ListTaskGetAllRequestDto>();
            var listR =  dbContext.TaskLists.ToList ();
            if (listR != null)
            {
                foreach (var item in listR)
                {
                    var taskList = new List<TasksGetAllRequestDto>();
                    var taskListR =  GetAllTask (item.Id);
                    if (taskListR != null)
                    {
                        foreach (var item1 in taskListR)
                        {
                            var todoList= new List<TodoGetAllRequestDto>();
                            var todoListR =  GetAllTodo (item1.Id);
                            if (todoListR != null)
                            {
                                foreach(var item2 in  todoListR)
                                {
                                    var todoPgList = new List<TodoProgressGetAllRequestDto>();
                                    var todoPgListR=  GetAllTodoPr (item2.Id);
                                    if(todoPgListR != null)
                                    {
                                        foreach (var item3 in todoPgListR)
                                        {
                                            todoPgList.Add(new TodoProgressGetAllRequestDto(item3.Id, item3.Seq, item3.Status, item3.TodoId));
                                        }
                                        todoList.Add(new TodoGetAllRequestDto(item2.Id, item2.Name, item2.Status, item2.TaskId, todoPgList));
                                    }
                                    else
                                    {
                                        todoList.Add(new TodoGetAllRequestDto(item2.Id, item2.Name, item2.Status, item2.TaskId, todoPgList));
                                    }
                                }
                                taskList.Add(new TasksGetAllRequestDto(item1.Id, item1.Name, item1.Seq, item1.Executor, item1.Description, item1.Deadline, item1.Attachment, item1.Priority, item1.TaskListId, todoList));
                            }
                            else
                            {
                                taskList.Add(new TasksGetAllRequestDto(item1.Id, item1.Name, item1.Seq, item1.Executor, item1.Description, item1.Deadline, item1.Attachment, item1.Priority, item1.TaskListId, todoList));
                            }

                        }

                        listTask.Add(new ListTaskGetAllRequestDto(item.Id, item.Content, taskList));
                    }
                    else {
                        listTask.Add(new ListTaskGetAllRequestDto( item.Id, item.Content, taskList)) ;
                    }

                }
            }

            return  listTask.ToList(); }
        

    }
}
