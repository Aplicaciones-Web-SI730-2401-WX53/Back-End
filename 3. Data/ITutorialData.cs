using _3._Data.Models;

namespace _3._Data;

public interface ITutorialData
{
    Boolean Save(Tutorial data);
    Boolean Update(Tutorial data);
    Boolean Delete(int id);
    List<Tutorial> getAll();
    Tutorial getById(int Id);
}