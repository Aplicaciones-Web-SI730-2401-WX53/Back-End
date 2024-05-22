using System.Runtime.InteropServices.JavaScript;
using _3._Data.Models;

namespace _2._Domain;

public interface ITutorialDomain
{
    Task<int> SaveAsync(Tutorial data);
    Task<Boolean> UpdateAsync(Tutorial data,int id);
    Task<Boolean> DeleteAsync(int id);
}