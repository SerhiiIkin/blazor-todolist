using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Shared {
    public class Todo {
        public Guid Id { get; set; }

        public  string Description { get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}
