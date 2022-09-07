namespace TodoProject.Models
{
    public class AuditModel
    {
        public string User { get; set; }
        public string Operation { get; set; }
        public int Entity { get; set; }
        public List<Field> Fields { get; set; }
    }
}
