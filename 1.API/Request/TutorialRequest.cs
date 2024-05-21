using _3._Data;

namespace _1.API.Request;

public class TutorialRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<SectionRequest> Sections { get; set; }
}