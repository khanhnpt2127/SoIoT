using SoIoT.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace SoIoT.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
