using System.Xml.Serialization;
using AsocitaitaPentruUnViitorSustenabil.Domain;

namespace AsocitaitaPentruUnViitorSustenabil.Models
{
    public class MembruService
    {
        private readonly string _filePath = @"App_Data/Membri.xml";
        private List<Membru> membri = new List<Membru>();
        public List<Membru> GetMembers()
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(Membri));
                var membriXml = (Membri)serializer.Deserialize(stream);
                membri = membriXml.Membru;
            }
            return membri;
        }

        public void AddMember(Membru membru)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                // Load the existing events
                var serializer = new XmlSerializer(typeof(Membri));
                var membriXml = (Membri)serializer.Deserialize(stream);

                // Add the new event
                if (membriXml.Membru != null)
                    membriXml.Membru.Add(membru);

                // Write the updated list back to the XML file
                stream.SetLength(0); // Clear the file
                serializer.Serialize(stream, membriXml);

            }
            DeleteMember(0);
        }

        public void EditMember(Membru membru)
        {
            DeleteMember(membru.Id);
            AddMember(membru);
        }

        public void DeleteMember(int id)
        {
            // Load the XML file
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                var serializer = new XmlSerializer(typeof(Membri));
                var membriXml = (Membri)serializer.Deserialize(stream);

                // Find the event with the specified ID and remove it
                var membru = membriXml.Membru.FirstOrDefault(e => e.Id == id);
                if (membru != null)
                {
                    membriXml.Membru.Remove(membru);

                    // Write the updated list back to the XML file
                    stream.SetLength(0); // Clear the file
                    serializer.Serialize(stream, membriXml);
                }
            }
        }

        public String FindMember(string nume)
        {
            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new XmlSerializer(typeof(Membri));
                var membriXml = (Membri)serializer.Deserialize(stream);
                var membru = membriXml.Membru.FirstOrDefault(e => e.Nume == nume);
                if (membru != null)
                {
                    return membru.ToString();
                }
                return null;
            }
        }
    }
}
