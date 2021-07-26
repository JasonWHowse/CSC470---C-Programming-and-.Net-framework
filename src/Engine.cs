using System;
using System.Linq;
using System.Collections.Generic;
using Project4.src.Models;

namespace Project4.src {
    class Engine {
        private readonly List<Part> parts;
        private readonly List<Supplier> suppliers;
        private readonly List<Shipment> shipments;

        public Engine(List<Part> parts, List<Supplier> suppliers, List<Shipment> shipments) {
            this.parts = parts;
            this.suppliers = suppliers;
            this.shipments = shipments;
        }//public Engine(List<Part> parts, List<Supplier> suppliers, List<Shipment> shipments) {

        public static bool ContinueClrQuit {
            get {
                Console.WriteLine("Press Q to quit, C to clear the console, or any other key to continue");
                char key = Console.ReadKey(true).Key.ToString().ToUpper()[0];
                if (key == 'Q') {
                    return true;
                }//if (key == 'Q') {
                if (key == 'C') {
                    Console.Clear();
                    return false;
                }//if (key == 'C') {
                return false;
            }//get {
        }//public static bool ContinueClrQuit {

        public void ColorQuery() {
            string color = this.GetColor();
            var citiesInColorQuery = from partsTable in this.parts orderby partsTable.City where partsTable.Color.Equals(color) select partsTable.City;
            Console.WriteLine((citiesInColorQuery.Distinct().Count() == 1 ? "City" : "Cities") + " that have parts matching the color " + color.ToLower() + ":");
            foreach (string city in citiesInColorQuery.Distinct()) {
                Console.WriteLine(city);
            }//foreach (string city in citiesInColorQuery.Distinct()) {
        }//public void ColorQuery() {

        public void GetPartNameAndQTYBySupplierFromShipment() {
            string SNumber = this.GetSNumber();
            var PNameQTYQuery = (from shipmentRow in this.shipments join partRow in this.parts on shipmentRow.PN equals partRow.PN orderby partRow.PName where shipmentRow.SN.Equals(SNumber) select new { partRow.PName, shipmentRow.QTY }).Distinct();
            Console.WriteLine("Part" + (PNameQTYQuery.Count() == 1 ? "" : "s") + " in shipments with supplier number " + SNumber);
            foreach (var row in PNameQTYQuery) {
                Console.WriteLine("Part Name: " + row.PName + ", Quantity: " + row.QTY);
            }//foreach (var row in PNameQTYQuery) {
        }//public void GetPartNameAndQTYBySupplierFromShipment() {

        public void DisplayParts() => this.parts.OrderBy(c => c.PN).ToList().ForEach(Console.WriteLine);

        public void DisplayShipments() => this.shipments.OrderBy(c => c.PN).OrderBy(c => c.SN).ToList().ForEach(Console.WriteLine);

        public void DisplaySuppliers() => this.suppliers.OrderBy(c => c.SN).ToList().ForEach(Console.WriteLine);

        public void ListAllSupplierNames() => this.suppliers.Select(c => c.SName).OrderBy(c => c).ToList().ForEach(Console.WriteLine);

        private string GetColor() {
            while (true) {
                Console.WriteLine("Enter a color to query by color and get city names");
                string color = this.NormalizeInput(Console.ReadLine().ToString());
                if (color.Length == 0) {
                    Console.WriteLine("You must enter a color");
                } else if ((from partsTable in this.parts where partsTable.Color.Equals(color) select partsTable.Color).Count() == 0) {//if (color.Length == 0) {
                    Console.WriteLine(color + " is not a color of a part please select a color from the following list:");
                    foreach (var row in (from partsTable in this.parts orderby partsTable.Color select partsTable.Color).Distinct()) {
                        Console.WriteLine(row.ToString());
                    }//foreach (var row in (from partsTable in this.parts orderby partsTable.Color select partsTable.Color).Distinct()) {
                } else {//else if ((from partsTable in this.parts where partsTable.Color.Equals(color) select partsTable.Color).Count() == 0) {
                    return color;
                }//else {
            }//while (true) {
        }//private string GetColor() {

        private string GetSNumber() {
            while (true) {
                Console.WriteLine("Enter a supplier number to query by supplier number and get corresponding part names.");
                string SNumber = Console.ReadLine().ToString().ToUpper();
                if (SNumber.Length == 0) {
                    Console.WriteLine("You must enter a supplier number.");
                } else if ((from shipmentRow in this.shipments where shipmentRow.SN.Equals(SNumber) select shipmentRow.PN).Count() == 0) {//if (SNumber.Length == 0) {
                    Console.WriteLine(SNumber + " has no parts matching that supplier number please select a supplier number from the following list:");
                    foreach (var supNum in (from shipmentsRow in this.shipments orderby shipmentsRow.SN select shipmentsRow.SN).Distinct()) {
                        Console.WriteLine(supNum.ToString());
                    }//foreach (var supNum in (from shipmentsRow in this.shipments orderby shipmentsRow.SN select shipmentsRow.SN).Distinct()) {
                } else {//else if ((from shipmentRow in this.shipments where shipmentRow.SN.Equals(SNumber) select
                    return SNumber;
                }//else {
            }//while (true) {
        }//private string GetSNumber() {

        private string NormalizeInput(string input) => input == null || input.Equals("") ? "" : input[0].ToString().ToUpper() + input[1..].ToString().ToLower();
    }//class Engine {
}//namespace Project4.src {