using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly TaskAppContext _appContext;
        private readonly IProjectService _projectService;


        public ProjectController(TaskAppContext appContext, IProjectService projectService)
        {
            _appContext = appContext;
            _projectService = projectService;
        }


        //Add project
        [HttpPost]
        public IResult Post(ProjectEntity dataProject)
        {

            return _projectService.AddProject(dataProject);

        }


        //get all projects
        [HttpGet]
        public IResult GetAll()
        {
            return _projectService.GetAllProjects();
        }


        //get project by id
        [HttpGet("{id}")]
        public IResult Get(long id)
        {

            return _projectService.GetProjectById(id);
        }



        //change one project
        [HttpPut("{id}")]
        public IResult Put(long id, ProjectEntity projectData)
        {
            return _projectService.ChangeProjectById(id, projectData);
        }



        //delete one project by id
        [HttpDelete("{id}")]
        public IResult Delete(long id)
        {
            return _projectService.RemoveProjectById(id);
        }

    }
}
