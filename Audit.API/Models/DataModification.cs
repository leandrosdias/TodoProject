namespace Audit.API.Models
{
    public class DataModification
    {
        public string Key { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

    }
}
