using _3._Data;
using _3._Data.Models;

namespace _2._Domain;

public class TutorialDomain : ITutorialDomain
{
    private ITutorialData _tutorialData;
    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    public bool Save(Tutorial data)
    {
        if (data.Name.Contains('a'))
            throw new Exception("Contains a");

        return true;
    }

    public bool Update(Tutorial data)
    {
        //TutorialMySqlData tutorialMySqlData = new TutorialMySqlData();
        return _tutorialData.Save(data);
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}