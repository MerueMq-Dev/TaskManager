using TaskManager.Entities;

namespace TaskManager.Services
{
    public interface IProjectTaskService
    {

        public IResult ChangeTaskById(long projectid, long taskid, TaskEntity taskData);

        public IResult GetTaskById(long projectId, long taskId);

        public IResult RemoveTaskById(long projectid, long taskid);

        public IResult AddTaskToProject(long id, TaskEntity dataTask);
    }
}
