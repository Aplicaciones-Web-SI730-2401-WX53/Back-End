using System.Runtime.InteropServices.JavaScript;
using _3._Data.Models;

namespace _2._Domain;

public interface ITutorialDomain
{
    Task<Boolean> SaveAsync(Tutorial data);
    Task<Boolean> UpdateAsync(Tutorial data,int id);
    Boolean Delete(int id);
}