using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Shared {
    public class Like {
        public int Id { get; set; }

        public Todo? Todo { get; set; }

        public int Likes { get; set; }

        public string TodoId { get; set; } = string.Empty;
    }
}
