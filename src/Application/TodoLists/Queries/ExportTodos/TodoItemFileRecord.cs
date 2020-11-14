using SoIoT.Application.Common.Mappings;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
