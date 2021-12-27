using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slitting.Services
{
    public class SaveUnits
    {
        public SaveUnits(ISave saveKnifes, ISave saveSpacers)
        {
            _saveKnifes = saveKnifes;
            _saveSpacers = saveSpacers;
        }

        private readonly ISave _saveKnifes;
        private readonly ISave _saveSpacers;

        public async Task SaveChanges(Dictionary<float, int> knifes, Dictionary<float, int> spacers)
        {
            await _saveKnifes.SaveChanges(knifes);
            await _saveSpacers.SaveChanges(spacers);
        }
    }
}
