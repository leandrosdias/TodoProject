using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todo.API.Domain.Commands.Responses;

namespace Todo.API.Domain.Commands.Requests
{
    public class TodoUpdateModel : IRequest<TodoUpdateResponse>
    {
        [Required(ErrorMessage = "Necessário informar o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Necessário se a tarefa está completa ou não")]
        public bool Completed { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt => DateTime.Now.ToUniversalTime();
        [JsonIgnore]
        public int Id { get; set; }
    }
}
