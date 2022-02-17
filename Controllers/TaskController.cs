using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.Services;

namespace TaskManager.Controllers
{

    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskAppContext _appContext;
        private readonly IProjectTaskService _projectTaskService;

        public TaskController(TaskAppContext appContext, IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
            _appContext = appContext;
        }


        //change one task from the project
        [HttpPut("/{projectid}/{taskid}")]
        public IResult PutTask(long projectid, long taskid, TaskEntity taskData)
        {
            return _projectTaskService.ChangeTaskById(projectid, taskid, taskData);
        }


        //get one task from the project
        [HttpGet("/{projectId}/{taskId}")]
        public IResult GetTask(long projectId, long taskId)
        {

            return _projectTaskService.GetTaskById(projectId, taskId);
        }

        //get all tasks from the project

        [HttpGet("project/{projectid}")]
        public IResult GetAllTask(long projectid)
        {
            return _projectTaskService.GetAllTaskFromProject(projectid);
        }


        //delete one task from the project
        [HttpDelete("/{projectid}/{taskid}")]
        public IResult DeleteTask(long projectid, long taskid)
        {

            return _projectTaskService.RemoveTaskById(projectid, taskid);


        }

        //Add task to the project
        [HttpPut("{id}")]
        public IResult Put(long id, TaskEntity dataTask)
        {
            return _projectTaskService.AddTaskToProject(id, dataTask);
        }


    }

}
