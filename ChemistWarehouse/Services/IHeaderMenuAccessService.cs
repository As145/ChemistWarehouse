using ChemistWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Services
{
    public interface IHeaderMenuAccessService
    {
        Task<List<Category>> GetHeaderMenu();
    }
}
