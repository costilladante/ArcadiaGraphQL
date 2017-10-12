using Arcadia.Repository.Interfaces;
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

        public async Task<Company> Get(int id)
        {
            var company = await _db.Companies.FirstOrDefaultAsync(comp => comp.Id == id);
            return company;
        }

        public Company Add(Company newCompany)
        {   
            _db.Companies.Add(newCompany);
            _db.SaveChanges();
            return newCompany;
        }
    }
}
