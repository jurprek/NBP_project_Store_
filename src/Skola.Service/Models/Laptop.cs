using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Skola.Service.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PredmetId { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("processor")]
        public Processor Processor { get; set; }

        [BsonElement("ram")]
        public RAM Ram { get; set; }

        [BsonElement("screen")]
        public Screen Screen { get; set; }

        [BsonElement("storage")]
        public Storage Storage { get; set; }

        [BsonElement("os")]
        public string OS { get; set; }

        [BsonElement("graphics")]
        public Graphics Graphics { get; set; }

        [BsonElement("network")]
        public Network Network { get; set; }

        [BsonElement("ports")]
        public Ports Ports { get; set; }

        [BsonElement("weight_kg")]
        public double WeightKg { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("warranty_months")]
        public int WarrantyMonths { get; set; }

        [BsonElement("additional_features")]
        public List<string> AdditionalFeatures { get; set; }
    }

    public class Processor
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("cores")]
        public int Cores { get; set; }

        [BsonElement("max_speed_GHz")]
        public double MaxSpeedGHz { get; set; }
    }

    public class RAM
    {
        [BsonElement("size_GB")]
        public int SizeGB { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }

    public class Screen
    {
        [BsonElement("size_inches")]
        public double SizeInches { get; set; }

        [BsonElement("resolution")]
        public string Resolution { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }

    public class Storage
    {
        [BsonElement("size_GB")]
        public int SizeGB { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }

    public class Graphics
    {
        [BsonElement("type")]
        public string Type { get; set; }
    }

    public class Network
    {
        [BsonElement("wifi")]
        public string Wifi { get; set; }

        [BsonElement("ethernet")]
        public string Ethernet { get; set; }

        [BsonElement("bluetooth")]
        public bool Bluetooth { get; set; }
    }

    public class Ports
    {
        [BsonElement("usb_2_0")]
        public int USB2_0 { get; set; }

        [BsonElement("usb_3_1")]
        public int USB3_1 { get; set; }

        [BsonElement("hdmi")]
        public bool HDMI { get; set; }

        [BsonElement("usb_type_c")]
        public bool USBTypeC { get; set; }
    }
}
