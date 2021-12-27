using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Services
{
    public interface ISave : IServices
    {
        Task SaveChanges(Dictionary<float, int> items);
    }
}
