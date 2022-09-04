using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todo.API.Domain.Commands.Responses;

namespace Todo.API.Domain.Commands.Requests
{
    public class TodoCreateModel : IRequest<TodoCreateResponse>
    {
        [Required(ErrorMessage = "Necessário informar o nome")]
        public string Name { get; set; }
        [JsonIgnore]
        public DateTime InsertedAt => DateTime.Now.ToUniversalTime();
        [JsonIgnore]
        public DateTime UpdatedAt => DateTime.Now.ToUniversalTime();
    }
}
