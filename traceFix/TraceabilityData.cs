using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace traceFix
{
    [XmlRoot]
    public class TraceabilityData
    {
        [XmlAttribute("puDmyHandlingMode")]
        public string puDmyHandingMode { get; set; } = string.Empty;

        [XmlAttribute("errorLabel")]
        public string errorLabel { get; set; } = string.Empty;

        [XmlAttribute("dateComplete")]
        public string dateComplete { get; set; } = string.Empty;

        [XmlAttribute("dateBegin")]
        public string dateBegin { get; set; } = string.Empty;

        [XmlAttribute("boardID")]
        public string boardID { get; set; } = string.Empty;

        [XmlAttribute("machineID")]
        public string machineID { get; set; } = string.Empty;

        [XmlAttribute("station")]
        public string station { get; set; } = string.Empty;

        [XmlAttribute("sublane")]
        public string sublane { get; set; } = string.Empty;

        [XmlAttribute("lane")]
        public string lane { get; set; } = string.Empty;

        [XmlAttribute("line")]
        public string line { get; set; } = string.Empty;

        [XmlAttribute("accuracy")]
        public string accuracy { get; set; } = string.Empty;

        [XmlAttribute("basetype")]
        public string basetype { get; set; } = string.Empty;

        [XmlAttribute("version")]
        public string version { get; set; } = string.Empty;

        [XmlArrayItem("job", typeof(job123))]
        public job123[] jobs { get; set; }

        [XmlArrayItem("panel", typeof(panel))]
        public panel[] panels { get; set; }

        [XmlArrayItem("componentType", typeof(componentType))]
        public componentType[] componentTypes { get; set; }

        [XmlArrayItem("location", typeof(location))]
        public location[] locations { get; set; }

    }

    [XmlRoot]
    public class location 
    {
        [XmlAttribute("tableID")]
        public string tableID { get; set; } = string.Empty;

        [XmlAttribute("loc")]
        public string loc { get; set; } = string.Empty;


        //[XmlArrayItem("position", typeof(position))]
        [XmlElement("position")]
        public position[] positions { get; set; }

    }

    [XmlRoot]
    public class position
    {

        [XmlAttribute("div")]
        public string div { get; set; } = string.Empty;


        [XmlAttribute("track")]
        public string track { get; set; } = string.Empty;


        [XmlElement]
        public packagingUnit packagingUnit { get; set; }

    }

    [XmlRoot]
    public class packagingUnit
    {

        [XmlAttribute("id")]
        public string id { get; set; } = string.Empty;

        [XmlAttribute("active")]
        public string active { get; set; } = string.Empty;

        [XmlAttribute("msdOpenDate")]
        public string msdOpenDate { get; set; } = string.Empty;

        [XmlAttribute("msdLevel")]
        public string msdLevel { get; set; } = string.Empty;

        [XmlAttribute("expiryDate")]
        public string expiryDate { get; set; } = string.Empty;

        [XmlAttribute("verifiedDate")]
        public string verifiedDate { get; set; } = string.Empty;

        [XmlAttribute("quantity")]
        public string quantity { get; set; } = string.Empty;

        [XmlAttribute("extra5")]
        public string extra5 { get; set; } = string.Empty;

        [XmlAttribute("extra4")]
        public string extra4 { get; set; } = string.Empty;

        [XmlAttribute("extra3")]
        public string extra3 { get; set; } = string.Empty;

        [XmlAttribute("extra1")]
        public string extra1 { get; set; } = string.Empty;

        [XmlAttribute("supplier")]
        public string supplier { get; set; } = string.Empty;

        [XmlAttribute("manufacturer")]
        public string manufacturer { get; set; } = string.Empty;

        [XmlAttribute("componentBarcode")]
        public string componentBarcode { get; set; } = string.Empty;

        [XmlAttribute("originalQuantity")]
        public string originalQuantity { get; set; } = string.Empty;

        [XmlAttribute("batchID")]
        public string batchID { get; set; } = string.Empty;

        [XmlAttribute("packagingID")]
        public string packagingID { get; set; } = string.Empty;

        [XmlAttribute("componentTypeID")]
        public string componentTypeID { get; set; } = string.Empty;

    }

    [XmlRoot]
    public class componentType
    {

        [XmlAttribute("name")]
        public string name { get; set; } = string.Empty;

        [XmlAttribute("packForm")]
        public string packForm { get; set; } = string.Empty;

        [XmlAttribute("id")]
        public string id { get; set; } = string.Empty;
    }

    [XmlRoot]
    public class job123
    {
        [XmlAttribute("boardSide")]
        public string boardSide { get; set; } = string.Empty;

        [XmlAttribute("boardName")]
        public string boardName { get; set; } = string.Empty;

        [XmlAttribute("orderID")]
        public string orderID { get; set; } = string.Empty;

        [XmlAttribute("setup")]
        public string setup { get; set; } = string.Empty;

        [XmlAttribute("recipe")]
        public string recipe { get; set; } = string.Empty;

    }

    [XmlRoot]
    public class panel
    {

        [XmlAttribute("omit")]
        public string omit { get; set; } = string.Empty;

        [XmlAttribute("panelID")]
        public string panelID { get; set; } = string.Empty;

        [XmlAttribute("name")]
        public string name { get; set; } = string.Empty;

        [XmlElement("id")]
        public Refid[] id { get; set; }

    }

    [XmlRoot]
    public class Refid
    {

        [XmlAttribute("ref")]
        public string rid { get; set; } = string.Empty;


        [XmlElement("RefDes")]
        public RefDesdis[] RefDes { get; set; }

    }

    [XmlRoot]
    public class RefDesdis
    {

        [XmlAttribute("name")]
        public string name { get; set; } = string.Empty;
    }




}