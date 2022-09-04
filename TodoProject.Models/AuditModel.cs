namespace TodoProject.Models
{
    public class AuditModel
    {
        public Guid User { get; set; }
        public DateTime Timestamp { get; set; }
        public string Operation { get; set; }
        public string Entity { get; set; }
        public IEnumerable<DataModification> DataModifications { get; set; }
    }
}
