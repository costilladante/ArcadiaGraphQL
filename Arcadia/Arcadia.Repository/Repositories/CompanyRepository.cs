using System.Linq;
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

        public async Task<Company> AddAsync(Company newCompany)
        {
            await _db.Companies.AddAsync(newCompany);
            _db.SaveChanges();
            return newCompany;
        }

        public Company Update(int companyId, Company company)
        {   
            var companyToUpdate = _db.Companies.FirstOrDefault(c => c.Id == companyId);
            companyToUpdate.Name = company.Name;
            _db.Companies.Attach(companyToUpdate);
            _db.SaveChanges();
            return company;
        }
    }
}
