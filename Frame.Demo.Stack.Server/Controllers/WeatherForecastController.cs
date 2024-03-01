using AutoMapper;
using Frame.Demo.Stack.DBContext;
using Frame.Demo.Stack.Server.ViewModels;
using MassTransit.Initializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frame.Demo.Stack.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController(FrameContext dbContext, IMapper mapper) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType<TemperatureSampleDTOv1>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(
                (await dbContext
                .TemperatureSamples.OrderByDescending(x => x.Time)
                .Take(100)
                .AsNoTracking()
                .ToListAsync())
                .Select(x => mapper.Map<TemperatureSampleDTOv1>(x)
                ));
        }
    }
}
