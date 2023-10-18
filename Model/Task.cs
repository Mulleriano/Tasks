using System.Text.Json.Serialization;
namespace Tasks.Model
{
    public class Task
    {
        public int Uid { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<object> Tasks { get; set; }
    }
}
