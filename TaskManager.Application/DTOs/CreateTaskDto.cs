using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace TaskManager.Application.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
