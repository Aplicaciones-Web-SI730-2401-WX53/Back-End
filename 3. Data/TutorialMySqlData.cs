using _3._Data.Context;
using _3._Data.Models;

namespace _3._Data;

public class TutorialMySqlData :ITutorialData
{

    private LearningCenterDBContext _learningCenterDbContext;

    public TutorialMySqlData(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    public bool Save(Tutorial data)
    {
        throw new NotImplementedException();
    }

    public bool Update(Tutorial data)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Tutorial> getAll()
    {
        /*var list = new List<Tutorial>();
        
        list.Add(new Tutorial(){Name = "Tutrial 1 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 2 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 3 Mysql"});*/

        return _learningCenterDbContext.Tutorials.Where(t =>t.IsActive).ToList();
    }

    public Tutorial getById(int Id)
    {
        return _learningCenterDbContext.Tutorials.Where(t =>t.IsActive && t.Id==Id).FirstOrDefault();
    }
}