using TaskManager.Enums;

namespace TaskManager.Entities
{
    public class TaskEntity
    {
            public long Id { get; set; }

            public string Name { get; set; }

            public StateTask stateTask { get; set; }

            public string Desciption { get; set; }

            public long Priority { get; set; }


            [Newtonsoft.Json.JsonIgnore]
            [System.Text.Json.Serialization.JsonIgnore]
            public long? ProjectEntityId { get; set; }

            [Newtonsoft.Json.JsonIgnore]
            [System.Text.Json.Serialization.JsonIgnore]
            public ProjectEntity? ProjectEntity { get; set; }

        
    }
}
