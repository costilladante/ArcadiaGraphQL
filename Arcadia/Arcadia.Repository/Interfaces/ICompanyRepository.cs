using System.Collections;
using System.Collections.Generic;
using Arcadia.Repository.Models;
using System.Threading.Tasks;

namespace Arcadia.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAll();
        Task<Company> Get(int id);
        Task<Company> AddAsync(Company newCompany);
        Company Update(int companyId, Company company);
        Company Delete(int companyId);
    }
}
