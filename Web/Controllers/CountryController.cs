using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly WebApiRegionDbContext dataBase;
        private readonly ICountryRepository _repository;
        public CountryController(WebApiRegionDbContext context, ICountryRepository repository)
        {
            dataBase = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountryList()
        {
            return await _repository.CountryList();
        }

        [HttpGet("{id}", Name = "idCountry")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await dataBase.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);

        }

        [HttpPost]

        public async Task<IActionResult> CreateCountry([FromBody] Country model)
        {
            if (ModelState.IsValid)
            {
                dataBase.Add(model);
                await dataBase.SaveChangesAsync();
                return new CreatedAtRouteResult("idCountry", new { id = model.Id }, model);
            }

            return BadRequest(ModelState);
        }
    }
}
