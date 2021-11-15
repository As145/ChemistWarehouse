using ChemistWarehouse.Data;
using ChemistWarehouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Services
{
    public class HeaderMenuAccessService:IHeaderMenuAccessService
    {
        private readonly ApplicationDbContext _context;

        public HeaderMenuAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetHeaderMenu()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
