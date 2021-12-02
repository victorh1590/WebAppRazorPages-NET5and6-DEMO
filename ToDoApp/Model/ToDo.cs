using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Model
{
    public class ToDo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public bool Done { get; set; }
    }
}