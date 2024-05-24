using _3._Data.Models;

namespace _2._Domain;

public interface ITutorialDomain
{
    Task<int> SaveAsync(Tutorial data);
    Task<bool> UpdateAsync(Tutorial data, int id);
    Task<bool> DeleteAsync(int id);
}