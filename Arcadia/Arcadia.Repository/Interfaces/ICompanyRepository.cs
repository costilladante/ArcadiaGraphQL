using Arcadia.Repository.Models;
using System.Threading.Tasks;

namespace Arcadia.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> Get(int id);
        Task<Company> AddAsync(Company newCompany);
        Company Update(int companyId, Company company);
    }
}
