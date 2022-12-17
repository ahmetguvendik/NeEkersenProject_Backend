using Microsoft.EntityFrameworkCore;
using NeEkersenProject.Data.Contexts;
using NeEkersenProject.Data.Entities;
using NeEkersenProject.Interfaces;
using NeEkersenProject.Models;

namespace NeEkersenProject.Repositories
{
    public class ActivityRepository : IActivity
    {
        private readonly ActivityContext _context;
        public ActivityRepository(ActivityContext context)
        {
            _context = context; 
        }
        public async Task AddActivity(CreateActivity createActivity)
        {
            var activity = _context.Activities.SingleOrDefault(X => X.Title == createActivity.Title);
            if (activity == null)
            {
                var activityMapper = new Activity();
                activityMapper.Title = createActivity.Title;
                activityMapper.City = createActivity.City;
                activityMapper.Category = createActivity.Category;
                activityMapper.Description = createActivity.Description;
                activityMapper.Date = createActivity.Date;
                activityMapper.Venue = createActivity.Venue;
                await _context.Activities.AddAsync(activityMapper);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteActivity(Guid id)
        {
            var deleteActivity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(deleteActivity);
            await _context.SaveChangesAsync();
        }

        public Task<List<Activity>> GetActivities()
        {
            return _context.Activities.ToListAsync();
        }

        public async Task UpdateActivity(UpdateActivity updateActivity,Guid id)
        {
            var activities = await _context.Activities.FindAsync(id);
            if (activities != null)
            {
                activities.Title = updateActivity.Title != default ? activities.Title : updateActivity.Title;
                activities.City = updateActivity.City != default ? activities.City : updateActivity.City;
                activities.Category = updateActivity.Category != default ? activities.Category : updateActivity.Category;
                activities.Description = updateActivity.Category != default ? activities.Category : updateActivity.Category;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Activity> GetById(Guid id)
        {
            // var data = await _context.Books.FindAsync(id);
            var activityFind = _context.Activities.SingleOrDefault(x => x.Id == id);
            if (activityFind == null)
            {
                return null;
            }
            return activityFind;
        }

    }
}
