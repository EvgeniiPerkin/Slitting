using System.IO;
using System.Xml.Serialization;
using UI.ViewModels.Realization;

namespace UI.Services
{
    public class Serializer : ISerializer
    {
        public Serializer()
        {
            formatter = new XmlSerializer(typeof(ParametsViewModel));
        }
        private XmlSerializer formatter;
        public ParametsViewModel DeSerialize()
        {
            using (FileStream fs = new FileStream("Paramets.xml", FileMode.OpenOrCreate))
            {
                return (ParametsViewModel)formatter.Deserialize(fs);
            }
        }
        public void Serialize(ParametsViewModel paramets)
        {
            using (FileStream fs = new FileStream("Paramets.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, paramets);
            }
        }
    }
}
