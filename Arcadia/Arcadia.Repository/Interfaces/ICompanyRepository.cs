using Arcadia.Repository.Models;
using System.Threading.Tasks;

namespace Arcadia.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> Get(int id);
    }
}
