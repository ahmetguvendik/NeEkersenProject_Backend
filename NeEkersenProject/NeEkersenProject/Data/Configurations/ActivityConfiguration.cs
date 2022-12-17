using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeEkersenProject.Data.Entities;

namespace NeEkersenProject.Data.Configurations
{
    public class ActivityConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(new Activity[]
            {
                //new Activity(){Title="Past Activity 1",Date=DateTime.Now,Description="Activity 2 months ago",Category="drinks",City="London",Venue="Pub"},
                //new Activity(){Title="Past Activity 4",Date=DateTime.Now,Description="Activity 4 months ago",Category="drinks",City="London",Venue="Pub"},
                //new Activity(){Title="Past Activity 8",Date=DateTime.Now,Description="Activity 8 months ago",Category="film",City="London",Venue="Cinema"},
                //new Activity(){Title="Past Activity 5",Date=DateTime.Now,Description="Activity 5 months ago",Category="drinks",City="London",Venue="Pub"},
            });
        }
    }
}
