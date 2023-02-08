using System.Net.Http.Json;
using System.Text.Json;

namespace TodoList.Client.Services.TodoListService {
	public class TodoListServices : ITodoListServices {
		private readonly HttpClient _http;

		public TodoListServices(HttpClient http) {
			_http = http;
		}
		

		public async Task<Todo> GetTodo(string Id) {
			var todo = await _http.GetFromJsonAsync<Todo>($"api/todo/{Id}");

			if (todo != null) {
                return todo;
            }

			throw new Exception("Not founded!");

		}

		public async Task<List<Todo>> GetTodos() {
			var todos = await _http.GetFromJsonAsync<List<Todo>>("api/todo");

			if (todos != null) {
				
				return todos;
			}
			return new List<Todo>();			
			
		}
		

		public async Task<Todo> CreateTodo(Todo todo) {
			var result = await _http.PostAsJsonAsync("api/todo", todo);
			var response = await result.Content.ReadFromJsonAsync<Todo>();
			
			if (response != null) {
				return response;

			}

			return todo;

		}

		public async Task DeleteTodo(Guid Id) {
			var result = await _http.DeleteAsync($"api/todo/{Id}");
			var response = await result.Content.ReadFromJsonAsync<string>();
		}

		public async Task UpdateTodo(Todo todo) {
			var result = await _http.PutAsJsonAsync($"api/todo/{todo.Id}", todo);
			var response = await result.Content.ReadFromJsonAsync<Todo>();
		}

		
	}
}
