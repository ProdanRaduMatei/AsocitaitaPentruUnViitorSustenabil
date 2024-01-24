using System.Xml.Serialization;

namespace AsocitaitaPentruUnViitorSustenabil.Domain
{
    [XmlRoot("Membri")]
    public class Membri
    {
        [XmlElement("Membru")]
        public List<Membru> Membru { get; set; }
    }

    public class Membru
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }

        public string toString()
        {
            return Id + " " + Nume + " " + Email;
        }
    }
}
