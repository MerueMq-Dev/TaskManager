using TaskManager.Entities;

namespace TaskManager.Services
{
    public interface IProjectService
    {
        public IResult AddProject(ProjectEntity dataProject);

        public IResult GetAllProjects();

        public IResult GetProjectById(long id);

        public IResult ChangeProjectById(long id, ProjectEntity projectData);

        public IResult RemoveProjectById(long id);
    }
}
