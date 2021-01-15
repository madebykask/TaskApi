using System.ComponentModel.DataAnnotations;

namespace TaskWeb.Models
{
    public class TaskModel
    {
        [Display(Name = "TaskId")]
        public int TaskId { get; set; }

        [Display(Name = "Task")]
        public string Task { get; set; }

        [Display(Name = "Completed")]
        public bool Completed { get; set; }
    }
}