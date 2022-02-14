using TaskManager.Entities;

namespace TaskManager.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly TaskAppContext _appContext;
        public ProjectTaskService(TaskAppContext appContext)
        {
            _appContext = appContext;
        }



        // The method takes as parameters a project ID , a task ID and
        // a task object and will change the task if it and the project exist
        public IResult ChangeTaskById(long projectid, long taskid, TaskEntity taskData)
        {
            var listOfTasks = _appContext.Tasks.ToList();
            var project = _appContext.Projects.FirstOrDefault(p => p.Id == projectid);
            if (project == null) return Results.NotFound(new { message = "Project Not Found" });
            var resultTask = project.ProjectTasks.FirstOrDefault(t => t.Id == taskid);

            if (resultTask != null)
            {
                resultTask.Name = taskData.Name;
                resultTask.stateTask = taskData.stateTask;
                resultTask.Desciption = taskData.Desciption;
                resultTask.Priority = taskData.Priority;
                _appContext.SaveChanges();


                return Results.Json(resultTask);

            }
            else

            {
                return Results.NotFound(new { message = "Task Not Found" });
            }
        }




        //The method takes as parameters project Id and task Id.
        //return task if it exists
        public IResult GetTaskById(long projectId, long taskId)
        {

            var listOfTasks = _appContext.Tasks.ToList();
            var projectResult = _appContext.Projects.FirstOrDefault(p => p.Id == projectId);
            if (projectResult == null) return Results.NotFound(new { message = "Project Not Found" });
            var task = projectResult.ProjectTasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return Results.NotFound(new { message = "Task Not Found" });


            return Results.Json(task);
        }


        // The method takes a project ID and a task ID as parameters
        //and removes the task from the project if it exists
        public IResult RemoveTaskById(long projectid, long taskid)
        {

            var listOfTasks = _appContext.Tasks.ToList();
            var projectResult = _appContext.Projects.FirstOrDefault(p => p.Id == projectid);
            if (projectResult == null) return Results.NotFound(new { message = "Project Not Found" });
            var taskToDelete = projectResult.ProjectTasks.FirstOrDefault(t => t.Id == taskid);
            if (taskToDelete == null) return Results.NotFound(new { message = "Task Not Found" });
            _appContext.Tasks.Remove(taskToDelete);
            _appContext.SaveChanges();

            return Results.Json(taskToDelete);

        }

        //The method takes a project id and a task object as parameters
        //and adds the task to the project if it exists
        public IResult AddTaskToProject(long id, TaskEntity dataTask)
        {
            var listOfTasks = _appContext.Tasks.ToList();
            var project = _appContext.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return Results.NotFound(new { message = "Project Not Found" });
            var list = project.ProjectTasks.ToList();
            if (list == null || list.Count == 0)
            {
                project.ProjectTasks = new List<TaskEntity>();
                project.ProjectTasks.Add(dataTask);

            }
            else
            {
                project.ProjectTasks.Add(dataTask);
            }

            _appContext.SaveChanges();

            return Results.Json(project);
        }
    }
}
