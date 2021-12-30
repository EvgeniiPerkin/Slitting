using UI.ViewModels.Realization;

namespace UI.Services
{
    public interface ISerializer : IServices
    {
        void Serialize(ParametsViewModel paramets);
        ParametsViewModel DeSerialize();
    }
}
