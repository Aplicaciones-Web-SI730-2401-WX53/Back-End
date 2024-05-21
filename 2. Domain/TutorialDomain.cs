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
    public async Task<Boolean> SaveAsync(Tutorial data)
    {
        //if (data.Name.Contains('a'))
        //    throw new Exception("Contains a");
        
        //Bussiness rules
        return await _tutorialData.SaveAsync(data);
    }

    public async Task<Boolean> UpdateAsync(Tutorial data,int id)
    {
        
        //Bussiness rules
        return  await _tutorialData.UpdateAsync(data,id);
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}