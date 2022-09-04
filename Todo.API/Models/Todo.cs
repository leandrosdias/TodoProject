namespace Todo.API.Models
{
    public class Todo : BaseModel
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
