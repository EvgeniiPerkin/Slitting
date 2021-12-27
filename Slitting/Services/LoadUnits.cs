using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slitting.Services
{
    public class LoadUnits
    {
        private readonly ILoader loaderKnifes;
        private readonly ILoader loaderSpacers;

        public LoadUnits(ILoader loaderKnifes, ILoader loaderSpacers)
        {
            if (loaderKnifes is null)
            {
                throw new ArgumentNullException(nameof(loaderKnifes));
            }

            if (loaderSpacers is null)
            {
                throw new ArgumentNullException(nameof(loaderSpacers));
            }

            this.loaderKnifes = loaderKnifes;
            this.loaderSpacers = loaderSpacers;
        }

        public async Task<Dictionary<float, int>> LoadKnifes()
        {
            return await loaderKnifes.Load();
        }
        public async Task<Dictionary<float, int>> LoadSpacers()
        {
            return await loaderSpacers.Load();
        }
    }
}
