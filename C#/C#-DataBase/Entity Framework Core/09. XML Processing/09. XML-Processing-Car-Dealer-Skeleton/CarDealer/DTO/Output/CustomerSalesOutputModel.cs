using System.Xml.Serialization;

namespace CarDealer.DTO.Output
{
    [XmlType("customer")]
    public class CustomerSalesOutputModel
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCarsCount { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
