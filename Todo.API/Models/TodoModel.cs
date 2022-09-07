using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.API.Models
{
    [Table("TODO")]
    public class TodoModel : BaseModel
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
