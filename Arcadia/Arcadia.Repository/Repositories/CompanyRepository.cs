﻿using Arcadia.Repository.Interfaces;
using Arcadia.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arcadia.Repository.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ArcadiaContext _db { get; }

        public CompanyRepository(ArcadiaContext db)
        {
            _db = db;
        }

        public Task<Company> Get(int id)
        {
            return _db.Companies.FirstOrDefaultAsync(comp => comp.Id == id);
        }
    }
}
