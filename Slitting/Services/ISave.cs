using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slitting.Services
{
    public interface ISave
    {
        Task SaveChanges(Dictionary<float, int> items);
    }
}
