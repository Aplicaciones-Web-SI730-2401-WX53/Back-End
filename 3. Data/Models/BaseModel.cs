namespace _3._Data.Models;

public class BaseModel
{
    public int Id {get;set; }
    public int CreatedUser { get; set; }
    public int UpdatedUser { get; set; }
    public DateTime CreatedDate  { get; set; }
    public DateTime UpdatedDate  { get; set; }
    public Boolean IsActive  { get; set; }
}