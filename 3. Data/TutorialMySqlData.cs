using _3._Data.Models;

namespace _3._Data;

public class TutorialMySqlData :ITutorialData
{
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
        var list = new List<Tutorial>();
        
        list.Add(new Tutorial(){Name = "Tutrial 1 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 2 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 3 Mysql"});

        return list;
    }

    public Tutorial getById(int Id)
    {
        throw new NotImplementedException();
    }
}