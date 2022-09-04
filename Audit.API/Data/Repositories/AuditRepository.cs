using Audit.API.Data.Configuration;
using MongoDB.Driver;
using TodoProject.Models;

namespace Audit.API.Data.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly IMongoCollection<AuditModel> _audits;

        public AuditRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _audits = database.GetCollection<AuditModel>("audits");
        }

        public void Insert(AuditModel audit)
        {
            _audits.InsertOne(audit);
        }
    }
}
