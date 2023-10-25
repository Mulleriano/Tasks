namespace Tasks.Model
{
    public class TaskModel
    {
        public int Uid { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<TasksModel> Tasks { get; set; }
    }

    public class TasksModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
