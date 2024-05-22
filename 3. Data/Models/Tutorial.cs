using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace _3._Data.Models;

public class Tutorial : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int Year { get; set; }
    
    public int Quantity { get; set; }
    public List<Section> Sections { get; set; } //0 to  many
    //private Section Sections { get; set; } // 1 - 1
}