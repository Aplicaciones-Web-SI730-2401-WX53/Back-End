using _3._Data;
using _3._Data.Models;
using _4._Shared;

namespace _2._Domain;

public class TutorialDomain : ITutorialDomain
{
    private ITutorialData _tutorialData;
    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }
    public async Task<int> SaveAsync(Tutorial data)
    {
        if (data.Name == "" ) throw new Exception("Name is empty");
        if(data.Year > 1990 )throw new Exception("year have tobe mor than 1990");
        
        //Bussiness rules
        var existingTutorial = await _tutorialData.GetByNameAsync(data.Name);
        if (existingTutorial != null)
            throw new Exception("Name already registered");
        
        var allTutorials = await _tutorialData.getAllAsync();
        if (allTutorials.Count() >= CONSTANTS.MAX_TUTORIALS)
            throw new Exception("limited achived");
        
        return await _tutorialData.SaveAsync(data);
    }

    public async Task<Boolean> UpdateAsync(Tutorial data,int id)
    {
        var existingTutorial = await _tutorialData.GetByIdAsync(id);

       /* if (TutuorialExts.Description != data.Description)
            throw new Exception("Update description is not allowed");*/
        
        //Bussiness rules
        return  await _tutorialData.UpdateAsync(data,id);
    }

    public  async Task<Boolean> DeleteAsync(int id)
    {
        //Bussiness rules
        return await _tutorialData.DeleteAsync(id);
    }
}