using System;
using System.Collections.Generic;
using System.Text;

namespace NewTodoist
{
    public class Items
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
       
        public string Status = "not started";
        public Guid UserId { get; set; }
    }
}
