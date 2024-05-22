using System.Runtime.InteropServices.JavaScript;
using _3._Data.Models;

namespace _3._Data;

public interface ITutorialData
{
    Task<int> SaveAsync(Tutorial data);
    Task<Boolean> UpdateAsync(Tutorial data,int id);
    Task<Boolean> DeleteAsync(int id);
    Task<List<Tutorial>> getAllAsync();
    Task<Tutorial> GetByIdAsync(int Id);    
    Task<Tutorial> GetByNameAsync(string Name);
}