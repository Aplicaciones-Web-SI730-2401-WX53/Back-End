namespace _3._Data.Models;

public class Tutorial : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Boolean IsDeleted { get; set; }

    private List<Section> Sections { get; set; } //0 to  many
    //private Section Sections { get; set; } // 1 - 1
}