using System;
using System.Collections.Generic;
using System.Text;

namespace opp__04
{
    public class StandardShipment : Shipment, ITrackable, IInsurable
    {
        public StandardShipment(string trackingCode) : base(trackingCode) { }

        public StandardShipment(string trackingCode, string description, decimal weight,
                                decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination) { }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() { return StatusMessage(); }

        public decimal CalculateInsurance() { return EstimatedCost * 0.05m; }
    }

    public class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        public decimal ExtraFee { get; private set; }

        public ExpressShipment(string trackingCode) : base(trackingCode)
        {
            ExtraFee = 30;
        }

        public ExpressShipment(string trackingCode, string description, decimal weight,
                               decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            if (extraFee >= 0) ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() { return StatusMessage(); }

        public decimal CalculateInsurance() { return EstimatedCost * 0.08m; }
    }

    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        public string DestinationCountry { get; private set; }
        public decimal CustomsFee { get; private set; }

        public InternationalShipment(string trackingCode) : base(trackingCode)
        {
            DestinationCountry = "Unknown";
            CustomsFee = 100;
        }

        public InternationalShipment(string trackingCode, string description, decimal weight,
                                     decimal deliveryFee, DeliveryAddress destination,
                                     string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            if (!string.IsNullOrWhiteSpace(destinationCountry)) DestinationCountry = destinationCountry;
            if (customsFee >= 0) CustomsFee = customsFee;
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + CustomsFee; }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine($"Tracking Code       : {TrackingCode}");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Estimated Cost      : {EstimatedCost} EGP");
        }

        public string GetTrackingStatus() { return StatusMessage(); }

        public decimal CalculateInsurance() { return EstimatedCost * 0.12m; }
    }
}
