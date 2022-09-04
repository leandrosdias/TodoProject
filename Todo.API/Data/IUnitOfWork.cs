namespace Todo.API.Data
{
    public interface IUnitOfWork
    {
        public void Commit();
        public void Rollback();
    }
}
