using Project4.src;
using System;
using static Project4.src.ListBuilder;

namespace Project4 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Engine engine = new Engine(GeneratePartsList, GenerateSuppliersList, GenerateShipmentList);
                Console.WriteLine("Parts List:");
                engine.DisplayParts();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
                Console.WriteLine("Suppliers List:");
                engine.DisplaySuppliers();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
                Console.WriteLine("Shipment List:");
                engine.DisplayShipments();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
                engine.ColorQuery();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
                Console.WriteLine("List of the names of all suppliers:");
                engine.ListAllSupplierNames();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
                engine.GetPartNameAndQTYBySupplierFromShipment();
                if (Engine.ContinueClrQuit) {
                    break;
                }//if (Engine.ContinueClrQuit) {
            }//while (true) {
        }//static void Main(string[] args) {
    }//class Program {
}//namespace Project4 {