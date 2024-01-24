using System.Xml.Serialization;
using AsocitaitaPentruUnViitorSustenabil.Domain;

namespace AsocitaitaPentruUnViitorSustenabil.Models
{
    public class ProiectService
    {
        private readonly string _filePath = @"App_Data/Proiecte.xml";
        private List<Proiect> proiecte = new List<Proiect>();
        public List<Proiect> GetProjects()
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(Proiecte));
                var proiecteXml = (Proiecte)serializer.Deserialize(stream);
                proiecte = proiecteXml.Proiect;
            }
            return proiecte;
        }

        public void AddProject(Proiect proiect)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                // Load the existing events
                var serializer = new XmlSerializer(typeof(Proiecte));
                var proiecteXml = (Proiecte)serializer.Deserialize(stream);

                // Add the new event
                if (proiecteXml.Proiect != null)
                    proiecteXml.Proiect.Add(proiect);

                // Write the updated list back to the XML file
                stream.SetLength(0); // Clear the file
                serializer.Serialize(stream, proiecteXml);

            }
            DeleteProject(0);
        }

        public void EditProject(Proiect proiect)
        {
            DeleteProject(proiect.Id);
            AddProject(proiect);
        }

        public void DeleteProject(int id)
        {
            // Load the XML file
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                var serializer = new XmlSerializer(typeof(Proiecte));
                var proiecteXml = (Proiecte)serializer.Deserialize(stream);

                // Find the event with the specified ID and remove it
                var proiect = proiecteXml.Proiect.FirstOrDefault(e => e.Id == id);
                if (proiect != null)
                {
                    proiecteXml.Proiect.Remove(proiect);

                    // Write the updated list back to the XML file
                    stream.SetLength(0); // Clear the file
                    serializer.Serialize(stream, proiecteXml);
                }
            }
        }

        public String FindProject(string nume)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(Proiecte));
                var proiecteXml = (Proiecte)serializer.Deserialize(stream);
                var proiect = proiecteXml.Proiect.FirstOrDefault(e => e.Nume == nume);
                if (proiect != null)
                {
                    return proiect.ToString();
                }
                return null;
            }
        }
    }
}
