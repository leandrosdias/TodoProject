using Todo.API.Models;
using TodoProject.Models;

namespace Todo.API.Mappers
{
    public class AuditMapper
    {
        public static AuditModel GetAuditModel(TodoModel todo, string operation, TodoModel oldTodo)
        {
            var audit = GetAuditModel(todo.Id, operation);
            audit.DataModifications = GetDiffProps(todo, oldTodo);
            return audit;
        }

        private static List<DataModification> GetDiffProps(TodoModel todo, TodoModel oldTodo)
        {
            var result = new List<DataModification>();
            foreach (var prop in oldTodo.GetType().GetProperties())
            {
                if (prop.GetCustomAttributes(typeof(NotAudit), true).Length > 0)
                {
                    continue;
                }

                if (!prop.GetValue(oldTodo).Equals(prop.GetValue(todo)))
                {
                    result.Add(new DataModification
                    {
                        Key = prop.Name,
                        OldValue = prop.GetValue(oldTodo).ToString(),
                        NewValue = prop.GetValue(todo).ToString()
                    });
                }
            }

            return result;
        }

        public static AuditModel GetAuditModel(TodoModel todo, string operation)
        {
            return GetAuditModel(todo.Id, operation);
        }

        public static AuditModel GetAuditModel(int id, string operation)
        {
            return new AuditModel
            {
                User = Guid.NewGuid().ToString(),
                Entity = id,
                Operation = operation,

            };
        }
    }
}
