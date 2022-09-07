using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Todo.API.Models
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotAudit]
        public int Id { get; set; }
        [NotAudit]
        public DateTime InsertedAt { get; set; }
        [NotAudit]
        public DateTime UpdatedAt { get; set; }
    }
}
