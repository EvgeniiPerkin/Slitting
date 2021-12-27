using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slitting.Services
{
    public interface ILoader
    {
        Task<Dictionary<float, int>> Load();
    }
}
