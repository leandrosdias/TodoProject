using MediatR;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var todo = _context.TodoList.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                throw new ArgumentException("Todo não encontrado!");
            }

            _context.TodoList.Remove(todo);
        }

        public TodoModel FindById(int? id) => _context.TodoList.FirstOrDefault(x => x.Id == id);

        public IEnumerable<TodoModel> Get(TodoGetModel request) => _context.TodoList;

        public void Save(TodoModel todo)
        {
            _context.TodoList.Add(todo);
        }

        public TodoModel Update(TodoModel todo)
        {
            var todoDb = _context.TodoList.FirstOrDefault(x => x.Id == todo.Id);

            if (todoDb == null)
            {
                throw new ArgumentException("Todo não encontrado!");
            }

            todoDb.Name = todo.Name;
            todoDb.Completed = todo.Completed;
            todoDb.UpdatedAt = todo.UpdatedAt;
            return todoDb;
        }
    }
}
