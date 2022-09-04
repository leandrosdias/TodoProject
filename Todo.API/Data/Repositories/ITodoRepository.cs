using Todo.API.Domain.Commands.Requests;
using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public interface ITodoRepository
    {
        void Save(TodoModel todo);
        IEnumerable<TodoModel> Get(TodoGetModel request);
        void Delete(int id);
        TodoModel Update(TodoModel todo);
        TodoModel FindById(int? id);
    }
}
