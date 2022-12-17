using NeEkersenProject.Data.Entities;
using NeEkersenProject.Models;

namespace NeEkersenProject.Interfaces
{
    public interface IActivity
    {
        public Task<List<Activity>> GetActivities();
        public Task AddActivity(CreateActivity createActivity);
        public Task UpdateActivity(UpdateActivity updateActivity,Guid id);
        public Task DeleteActivity(Guid id);
        public Task<Activity> GetById(Guid id);
    }
}
