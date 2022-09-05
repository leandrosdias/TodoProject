namespace TodoProject.Models
{
    public class AuditModel
    {
        public string User { get; set; }
        public string Operation { get; set; }
        public int Entity { get; set; }
        public IEnumerable<DataModification> DataModifications { get; set; }
    }
}
