using Microsoft.AspNetCore.Mvc;


namespace TodoList.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {
		private readonly DataContext _context;

		public TodoController(DataContext context) {
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetTodos() {
             var todos = await _context.Todos.ToListAsync();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(Guid Id) {
            var todo = await _context.Todos
                .FirstOrDefaultAsync(todo => todo.Id == Id);

            if(todo == null) {
                return NotFound("Todo was not founded!");
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo) {
            if(todo == null) {
                return BadRequest("Cant create todo!");
            }

             _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

		[HttpPut("{id}")]
		public async Task<ActionResult<Todo>> UpdateTodo(Todo todo) {

			var dbTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == todo.Id);

			if (dbTodo == null) {
				return NotFound("Cant found todo!");
			}

            dbTodo.Description = todo.Description;
            dbTodo.IsDone = todo.IsDone;
			
			await _context.SaveChangesAsync();

			return Ok(dbTodo);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Todo>> DeteleTodo(Guid Id) {

            var dbTodo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == Id);

			if (dbTodo == null) {
				return NotFound("Cant found todo!");
			}

			

			_context.Todos.Remove(dbTodo);
			await _context.SaveChangesAsync();

			return Ok("Todo was deleted!");
		}
	}
}
