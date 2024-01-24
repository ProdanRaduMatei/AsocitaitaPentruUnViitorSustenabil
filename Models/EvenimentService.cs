using System.Xml.Serialization;
using AsocitaitaPentruUnViitorSustenabil.Domain;

namespace AsocitaitaPentruUnViitorSustenabil.Models
{
    public class EvenimentService
    {
        private readonly string _filePath = @"App_Data\Evenimente.xml";
        private List<Eveniment> evenimente = new List<Eveniment>();
        public List<Eveniment> GetEvents()
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(Evenimente));
                var evenimenteXml = (Evenimente)serializer.Deserialize(stream);
                evenimente = evenimenteXml.Eveniment;
            }
            return evenimente;
        }

        public void AddEvent(Eveniment eveniment)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                // Load the existing events
                var serializer = new XmlSerializer(typeof(Evenimente));
                var evenimenteXml = (Evenimente)serializer.Deserialize(stream);

                // Add the new event
                if (evenimenteXml.Eveniment != null)
                    evenimenteXml.Eveniment.Add(eveniment);

                // Write the updated list back to the XML file
                stream.SetLength(0); // Clear the file
                serializer.Serialize(stream, evenimenteXml);

            }
            DeleteEvent(0);
        }

        public void EditEvent(Eveniment eveniment)
        {
            DeleteEvent(eveniment.Id);
            AddEvent(eveniment);
        }

        public void DeleteEvent(int id)
        {
            // Load the XML file
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                var serializer = new XmlSerializer(typeof(Evenimente));
                var evenimenteXml = (Evenimente)serializer.Deserialize(stream);

                // Find the event with the specified ID and remove it
                var eveniment = evenimenteXml.Eveniment.FirstOrDefault(e => e.Id == id);
                if (eveniment != null)
                {
                    evenimenteXml.Eveniment.Remove(eveniment);

                    // Write the updated list back to the XML file
                    stream.SetLength(0); // Clear the file
                    serializer.Serialize(stream, evenimenteXml);
                }
            }
        }

        public String FindEvent(string nume)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // Load the existing events
                var serializer = new XmlSerializer(typeof(Evenimente));
                var evenimenteXml = (Evenimente)serializer.Deserialize(stream);

                // Find the event with the specified ID and remove it
                var eveniment = evenimenteXml.Eveniment.FirstOrDefault(e => e.Nume == nume);
                if (eveniment != null)
                {
                    return eveniment.toString();
                }
                return null;
            }
        }
    }
}
