using _3._Data.Models;

namespace _3._Data;

public class TutorialOracleData :ITutorialData
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

    public Task<List<Tutorial>> getAllAsync()
    {
        var list = new List<Tutorial>();
        
        list.Add(new Tutorial(){Name = "Tutrial 1 ORacle"});
        list.Add(new Tutorial(){Name = "Tutrial 2 ORacle"});
        list.Add(new Tutorial(){Name = "Tutrial 3 ORacle"});

        return null;
    }

    public Task<Tutorial> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }
}