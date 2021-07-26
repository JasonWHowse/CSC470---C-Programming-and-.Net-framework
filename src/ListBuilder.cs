using Project4.src.Models;
using System.Collections.Generic;

namespace Project4.src {
    static class ListBuilder {
        public static List<Shipment> GenerateShipmentList => new List<Shipment>{
            new Shipment { SN = "S1", PN = "P1", QTY = 300 },
            new Shipment { SN = "S1", PN = "P2", QTY = 200 },
            new Shipment { SN = "S1", PN = "P3", QTY = 400 },
            new Shipment { SN = "S1", PN = "P4", QTY = 200 },
            new Shipment { SN = "S1", PN = "P5", QTY = 100 },
            new Shipment { SN = "S4", PN = "P2", QTY = 200 },
            new Shipment { SN = "S1", PN = "P6", QTY = 100 },
            new Shipment { SN = "S2", PN = "P1", QTY = 300 },
            new Shipment { SN = "S2", PN = "P2", QTY = 400 },
            new Shipment { SN = "S3", PN = "P2", QTY = 200 },
            new Shipment { SN = "S4", PN = "P4", QTY = 300 },
            new Shipment { SN = "S4", PN = "P5", QTY = 400 }
        };

        public static List<Supplier> GenerateSuppliersList => new List<Supplier>{
            new Supplier(){ City = "London", SN = "S1", SName = "Smith", Status = 20},
            new Supplier(){ City = "Paris", SN = "S3", SName = "Blake", Status = 30},
            new Supplier(){ City = "Paris", SN = "S2", SName = "Jones", Status = 10},
            new Supplier(){ City = "London", SN = "S4", SName = "Clark", Status = 20},
            new Supplier(){ City = "Athens", SN = "S5", SName = "Adams", Status = 30}
        };

        public static List<Part> GeneratePartsList => new List<Part> {
            new Part { PN = "P1", PName = "Nut", Color = "Red", Weight = 12, City = "London" },
            new Part { PN = "P2", PName = "Bolt", Color = "Green", Weight = 17, City = "Paris" },
            new Part { PN = "P3", PName = "Screw", Color = "Blue", Weight = 17, City = "Rome" },
            new Part { PN = "P4", PName = "Screw", Color = "Red", Weight = 14, City = "London" },
            new Part { PN = "P6", PName = "Cog", Color = "Red", Weight = 19, City = "London" },
            new Part { PN = "P5", PName = "Cam", Color = "Blue", Weight = 12, City = "Paris" }
        };
    }//static class ListBuilder {
}//namespace Project4.src {