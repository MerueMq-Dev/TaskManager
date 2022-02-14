using TaskManager.Entities;

namespace TaskManager.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TaskAppContext _appContext;

        public ProjectService(TaskAppContext appContext)
        {
            _appContext = appContext;
        }



        //The method takes a project object and adds it to the database and then returns it
        public IResult AddProject(ProjectEntity dataProject)
        {
            if (dataProject != null)
            {
                _appContext.Projects.Add(dataProject);
                _appContext.SaveChanges();

                return Results.Json(dataProject);
            }
            else
            {
                return Results.NoContent();
            }

        }


        //The method takes no parameters and returns all existing projects
        public IResult GetAllProjects()
        {
            var result = _appContext.Projects.ToList();
            var listOfTasks = _appContext.Tasks.ToList();


            if (result == null || result.Count == 0)
            {
                return Results.NotFound(new { message = "Projects Not Found" });
            }
            else
            {
                return Results.Json(result);
            }
        }

        // The method takes a project ID and returns the corresponding project if it exists.
        public IResult GetProjectById(long id)
        {

            var result = _appContext.Projects.ToList();
            var listOfTasks = _appContext.Tasks.ToList();

            if (result == null || result.Count == 0)
            {
                return Results.NotFound(new { message = "Project Not Found" });

            }
            else
            {

                var temp = result.FirstOrDefault(x => x.Id == id);
                return Results.Json(temp);
            }
        }


        // 
        public IResult ChangeProjectById(long id, ProjectEntity projectData)
        {
            var listOfTasks = _appContext.Tasks.ToList();
            var resultProject = _appContext.Projects.FirstOrDefault(t => t.Id == id);
            if (resultProject == null) return Results.NotFound(new { message = "Project Not Found" });

            resultProject.State = projectData.State;
            resultProject.Priority = projectData.Priority;
            resultProject.EndOfProject = projectData.EndOfProject;
            resultProject.Name = projectData.Name;

            _appContext.SaveChanges();

            return Results.Json(resultProject);
        }


        //The method takes a project ID and removes the corresponding project from the database, and
        //then returns the project that was deleted, if it existed
        public IResult RemoveProjectById(long id)
        {
            var project = _appContext.Projects.FirstOrDefault(t => t.Id == id);
            var listOfTasks = _appContext.Tasks.ToList();

            if (project == null) return Results.NotFound(new { message = "Project Not Found" });

            _appContext.Projects.Remove(project);

            _appContext.SaveChanges();
            return Results.Json(project);
        }
    }
}
