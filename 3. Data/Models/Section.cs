using System.ComponentModel.DataAnnotations;
using _3._Data.Models;

namespace _3._Data;

public class Section : BaseModel
{
    [Required] [MaxLength(90)] public string Title { get; set; }

    [Required] [Range(1, int.MaxValue)] public int Chapter { get; set; }

    public int TutorialId { get; set; }
    public Tutorial Tutorial { get; set; }
}