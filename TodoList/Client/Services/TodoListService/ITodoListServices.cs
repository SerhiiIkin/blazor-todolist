

namespace TodoList.Client.Services.TodoListService {
	public interface ITodoListServices {
		Task<List<Todo>> GetTodos();

		Task<Todo> GetTodo(string id);

		Task<Todo> CreateTodo(Todo todo);
		Task DeleteTodo(Guid id);

		Task UpdateTodo(Todo todo);
	}
}
