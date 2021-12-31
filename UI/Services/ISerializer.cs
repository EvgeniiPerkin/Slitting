using System.Threading.Tasks;
using UI.ViewModels.Realization;

namespace UI.Services
{
    public interface ISerializer : IServices
    {
        Task Serialize(ParametsViewModel paramets);
        Task<ParametsViewModel> DeSerialize();
    }
}
