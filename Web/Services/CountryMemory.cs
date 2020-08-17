using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class CountryMemory : ICountryRepository
    {
        private readonly WebApiRegionDbContext dataBase;
        public CountryMemory(WebApiRegionDbContext context)
        {
            dataBase = context;
        }
        public async Task<IEnumerable<Country>> CountryList()
        {
            return await dataBase.Countries.ToListAsync();
        }
    }
}
