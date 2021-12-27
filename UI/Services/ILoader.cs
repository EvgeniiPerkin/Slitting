using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Services
{
    public interface ILoader : IServices
    {
        Task<Dictionary<float, int>> Load();
    }
}
