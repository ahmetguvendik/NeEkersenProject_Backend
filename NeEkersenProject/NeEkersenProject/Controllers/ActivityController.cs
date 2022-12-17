using Microsoft.AspNetCore.Mvc;
using NeEkersenProject.Data.Entities;
using NeEkersenProject.Interfaces;
using NeEkersenProject.Models;

namespace NeEkersenProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivity _activity;
        public ActivityController(IActivity activity)
        {
            _activity = activity;
        }
        [HttpGet]

        public async Task<IActionResult> getAllActivity()
        {
            var activity = await _activity.GetActivities();
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public ActionResult<Activity> CreateActivity(CreateActivity activity)
        {
            _activity.AddActivity(activity);
            return Ok();
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateActivity(UpdateActivity activity, Guid id)
        {

            var updateActivity = await _activity.GetById(id);
            if (updateActivity != null)
            {
                await _activity.UpdateActivity(activity, id);
                return Ok(updateActivity);
            }
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _activity.DeleteActivity(id);
            return Ok();

        }
    }
}
