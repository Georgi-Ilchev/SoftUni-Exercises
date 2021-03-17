using System.Xml.Serialization;

namespace CarDealer.DTO.Output
{
    [XmlType("suplier")]
    public class LocalSuppliersOutputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
