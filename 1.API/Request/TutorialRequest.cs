using System.ComponentModel.DataAnnotations;

namespace _1.API.Request;

public class TutorialRequest
{
    [Required] public string Name { get; set; }

    [Required] public string Description { get; set; }

    [Required] [Range(1990, 2024)] public int Year { get; set; }

    [Range(1, 100)] public int Quantity { get; set; }

    public List<SectionRequest> Sections { get; set; }
}