using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels.Realization;

namespace UI.Services
{
    public class Serializer : ISerializer
    {
        public async Task<ParametsViewModel> DeSerialize()
        {
            try
            {
                using (FileStream fs = new FileStream("Paramets.json", FileMode.OpenOrCreate))
                {
                    return await JsonSerializer.DeserializeAsync<ParametsViewModel>(fs);
                }
            }
            catch
            {
                return new ParametsViewModel();
            }
        }
        public async Task Serialize(ParametsViewModel paramets)
        {
            using (FileStream fs = new FileStream("Paramets.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<ParametsViewModel>(fs, paramets);
            }
        }
    }
}
