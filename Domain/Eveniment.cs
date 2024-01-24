using System.Xml.Serialization;

namespace AsocitaitaPentruUnViitorSustenabil.Domain
{
    [XmlRoot("Evenimente")]
    public class Evenimente
    { 
        [XmlElement("Eveniment")]
        public List<Eveniment> Eveniment { get; set; }
    }

    public class Eveniment
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string toString()
        {
            return Id + " " + Nume;
        }
    }
}
