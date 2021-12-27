using Slitting.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slitting
{
    public class BaseUnits
    {
        public BaseUnits(SaveUnits save, LoadUnits loader)
        {
            _save = save;
            _loader = loader;
        }

        #region fields
        private readonly SaveUnits _save;
        private readonly LoadUnits _loader;
        private Dictionary<float, int> Knifes = new Dictionary<float, int>();
        private Dictionary<float, int> Spacers = new Dictionary<float, int>();
        #endregion

        public async Task SaveChanges()
        {
            await _save.SaveChanges(Knifes, Spacers);
        }
        public async Task Load()
        {
            this.Knifes = await _loader.LoadKnifes();
            this.Spacers = await _loader.LoadSpacers();
        }
        public float GetMaxKnife()
        {
            return Knifes.Keys.Max();
        }
        public float GetMaxSpacer()
        {
            return Spacers.Keys.Max();
        }
        public void ReturnKnife(Knife knife)
        {

        }
        public void ReturnSpacer(Spacer knife)
        {

        }
        public Knife ExtracKnife()
        {

        }
        public Spacer ExtracSpacer()
        {

        }
    }
}
