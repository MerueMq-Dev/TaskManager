using TaskManager.Enums;

namespace TaskManager.Entities
{
    public class ProjectEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public StateProject State { get; set; }

        public DateTime StartProject { get; set; } = DateTime.Now;

        public DateTime? EndOfProject { get; set; }

        public List<TaskEntity>? ProjectTasks { get; set; }

        public long Priority { get; set; }
    }
}
