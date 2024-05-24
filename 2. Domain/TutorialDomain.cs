using _3._Data;
using _3._Data.Models;
using _4._Shared;

namespace _2._Domain;

public class TutorialDomain : ITutorialDomain
{
    private readonly ITutorialData _tutorialData;

    public TutorialDomain(ITutorialData tutorialData)
    {
        _tutorialData = tutorialData;
    }

    public async Task<int> SaveAsync(Tutorial data)
    {
        //Bussiness rules
        var existingTutorial = await _tutorialData.GetByNameAsync(data.Name);
        if (existingTutorial != null)
            throw new Exception("Tutorial already exists");

        var allTutorials = await _tutorialData.getAllAsync();
        if (allTutorials.Count() >= CONSTANTS.MAX_TUTORIALS)
            throw new Exception("Max tutorials reached");

        return await _tutorialData.SaveAsync(data);
    }

    public async Task<bool> UpdateAsync(Tutorial data, int id)
    {
        var existingTutorial = await _tutorialData.GetByIdAsync(id);

        if (existingTutorial.Description != data.Description)
            throw new Exception("Description can't be changed");

        return await _tutorialData.UpdateAsync(data, id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        //Bussiness rules
        var existingTutorial = await _tutorialData.GetByIdAsync(id);
        if (existingTutorial == null)
            throw new Exception("Tutorial not found");

        return await _tutorialData.DeleteAsync(id);
    }
}