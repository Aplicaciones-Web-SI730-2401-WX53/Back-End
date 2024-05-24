using _3._Data.Models;

namespace _3._Data;

public interface ITutorialData
{
    Task<int> SaveAsync(Tutorial data);
    Task<bool> UpdateAsync(Tutorial data, int id);
    Task<bool> DeleteAsync(int id);
    Task<List<Tutorial>> getAllAsync();
    Task<List<Tutorial>> getSearchedAsync(string name, string description, int? year);
    Task<Tutorial> GetByIdAsync(int Id);
    Task<Tutorial> GetByNameAsync(string Name);
}