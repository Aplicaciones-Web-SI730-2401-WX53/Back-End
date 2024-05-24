using Microsoft.Build.Framework;

namespace _1.API.Request;

public class SectionRequest
{
    [Required] public string Title { get; set; }
}