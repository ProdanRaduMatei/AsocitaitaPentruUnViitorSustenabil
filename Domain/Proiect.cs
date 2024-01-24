using System.Xml.Serialization;

namespace AsocitaitaPentruUnViitorSustenabil.Domain
{
    [XmlRoot("Proiecte")]
    public class Proiecte
    {
        [XmlElement("Proiect")]
        public List<Proiect> Proiect { get; set; }
    }

    public class Proiect
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string toString()
        {
            return Id + " " + Nume;
        }
    }
}
