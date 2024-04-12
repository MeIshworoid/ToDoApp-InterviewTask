using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DataAccess.Layer.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Task title is required.")]
        [Column(TypeName ="varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Due date is required.")]
        [Column(TypeName ="datetime")]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
