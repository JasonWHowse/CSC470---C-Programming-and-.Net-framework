using Project4.src;
using System;
using static Project4.src.ListBuilder;

namespace Project4 {
    class Program {
        static void Main(string[] args) {
            DoTasks();
        }//static void Main(string[] args) {

        private static void DoTasks() {
            Engine engine = new Engine(GeneratePartsList, GenerateSuppliersList, GenerateShipmentList);
            switch (Engine.ChooseTask) {
                case 'S':
                    Console.Clear();
                    Console.WriteLine("Suppliers List:");
                    engine.DisplaySuppliers();
                    break;
                case 'P':
                    Console.Clear();
                    Console.WriteLine("Parts List:");
                    engine.DisplayParts();
                    break;
                case 'H':
                    Console.Clear();
                    Console.WriteLine("Shipment List:");
                    engine.DisplayShipments();
                    break;
                case 'N':
                    Console.Clear();
                    Console.WriteLine("List of the names of all suppliers:");
                    engine.ListAllSupplierNames();
                    break;
                case 'I':
                    Console.Clear();
                    engine.ColorQuery();
                    break;
                case 'U':
                    Console.Clear();
                    engine.GetPartNameAndQTYBySupplierFromShipment();
                    break;
                case 'Q':
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection");
                    break;
            }//switch (Engine.ChooseTask) {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            DoTasks();
        }//private static void DoTasks() {
    }//class Program {
}//namespace Project4 {