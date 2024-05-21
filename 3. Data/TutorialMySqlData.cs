using _3._Data.Context;
using _3._Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace _3._Data;

public class TutorialMySqlData :ITutorialData
{

    private LearningCenterDBContext _learningCenterDbContext;

    public TutorialMySqlData(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    public async Task<Boolean> SaveAsync(Tutorial data)
    {
        data.IsActive = true;
        _learningCenterDbContext.Tutorials.Add(data);
         await _learningCenterDbContext.SaveChangesAsync();
         return true;
    }

    public async Task<Boolean> UpdateAsync(Tutorial data,int id)
    {
        var tutorialTpUpdate =  _learningCenterDbContext.Tutorials.Where(t => t.Id == id).FirstOrDefault();
        tutorialTpUpdate.Name = data.Name;
        tutorialTpUpdate.Description = data.Description;

        _learningCenterDbContext.Tutorials.Update(tutorialTpUpdate);
        await _learningCenterDbContext.SaveChangesAsync();// confirmar cambios

        return true;
        
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Tutorial>> getAllAsync()
    {
        /*var list = new List<Tutorial>();
        
        list.Add(new Tutorial(){Name = "Tutrial 1 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 2 Mysql"});
        list.Add(new Tutorial(){Name = "Tutrial 3 Mysql"});*/

        return await _learningCenterDbContext.Tutorials.Where(t =>t.IsActive).ToListAsync();
    }

    public async Task<Tutorial> GetByIdAsync(int Id)
    {
        return await _learningCenterDbContext.Tutorials.Where(t =>t.IsActive && t.Id==Id).FirstOrDefaultAsync();
    }
}