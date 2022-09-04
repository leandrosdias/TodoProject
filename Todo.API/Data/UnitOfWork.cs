namespace Todo.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(DataContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Commit()
        {
            _logger.LogInformation("Commit", DateTime.UtcNow.ToLongTimeString());
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //por padrão já é efetuado rollback pelo context
            _logger.LogInformation("Rollback", DateTime.UtcNow.ToLongTimeString());
        }
    }
}
