using _3._Data.Context;
using _3._Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3._Data;

public class TutorialMySqlData : ITutorialData
{
    private readonly LearningCenterDBContext _learningCenterDbContext;

    public TutorialMySqlData(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }

    public async Task<int> SaveAsync(Tutorial data)
    {
        data.IsActive = true;

        using (var transaction = await _learningCenterDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _learningCenterDbContext.Tutorials.Add(data);
                //_learningCenterDbContext.Sections.AddRange(data.Sections); /// BBDD cae
                await _learningCenterDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        return data.Id;
    }

    public async Task<bool> UpdateAsync(Tutorial data, int id)
    {
        using (var transaction = await _learningCenterDbContext.Database.BeginTransactionAsync())
        {
            var tutorialTpUpdate = _learningCenterDbContext.Tutorials.Where(t => t.Id == id).FirstOrDefault();
            tutorialTpUpdate.Name = data.Name;
            tutorialTpUpdate.Description = data.Description;

            _learningCenterDbContext.Tutorials.Update(tutorialTpUpdate);
            await _learningCenterDbContext.SaveChangesAsync(); // confirmar cambios
            await transaction.CommitAsync();
        }

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using (var transaction = await _learningCenterDbContext.Database.BeginTransactionAsync())
        {
            var tutorialToDelete = _learningCenterDbContext.Tutorials.Where(t => t.Id == id).FirstOrDefault();

            //_learningCenterDbContext.Tutorials.Remove(tutorialToDelete); Eliminacion fisica
            tutorialToDelete.IsActive = false;
            // tutorialToDelete.IsDeleted = false;

            await _learningCenterDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }


        return true;
    }

    public async Task<List<Tutorial>> getAllAsync()
    {
        return await _learningCenterDbContext.Tutorials.Where(t => t.IsActive)
            .Include(t => t.Sections).ToListAsync();
    }

    public async Task<List<Tutorial>> getSearchedAsync(string name, string description, int? year)
    {
        return await _learningCenterDbContext.Tutorials
            .Where(t => t.IsActive && t.Name.Contains(name) && t.Year >= year)
            .Include(t => t.Sections).ToListAsync();
    }

    public async Task<Tutorial> GetByIdAsync(int Id)
    {
        return await _learningCenterDbContext.Tutorials.Where(t => t.IsActive && t.Id == Id)
            .Include(t => t.Sections).FirstOrDefaultAsync();
    }

    public async Task<Tutorial> GetByNameAsync(string Name)
    {
        return await _learningCenterDbContext.Tutorials.Where(t => t.IsActive && t.Name == Name)
            .FirstOrDefaultAsync();
    }
}