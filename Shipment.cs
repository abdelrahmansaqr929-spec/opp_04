

    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace opp__04
    {
        public enum ShipmentStatus { Ready, OutForDelivery, Delivered }

        public abstract class Shipment
        {
            private string trackingCode;
            private string description;
            private decimal weight;
            private decimal deliveryFee;

            public DeliveryAddress Destination { get; set; }

            public ShipmentStatus Status { get; set; } = ShipmentStatus.Ready;

            public string TrackingCode
            {
                get { return trackingCode; }
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        trackingCode = value;
                }
            }

            public string Description
            {
                get { return description; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        description = value;
                }
            }

            public decimal Weight
            {
                get { return weight; }
                set
                {
                    if (value > 0)
                        weight = value;
                }
            }

            public decimal DeliveryFee
            {
                get { return deliveryFee; }
                private set
                {
                    if (value > 0)
                        deliveryFee = value;
                }
            }

            public abstract decimal EstimatedCost { get; }

            public Shipment(string trackingCode)
            {
                this.trackingCode = "DEFAULT";
                this.description = "Unknown";
                this.weight = 1;
                this.deliveryFee = 50;
                Destination = new DeliveryAddress();
                TrackingCode = trackingCode;
            }

            public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            {
                this.trackingCode = "DEFAULT";
                this.description = "Unknown";
                this.weight = 1;
                this.deliveryFee = 50;

                TrackingCode = trackingCode;
                Description = description;
                Weight = weight;
                DeliveryFee = deliveryFee;
                Destination = destination;
            }

            public void UpdateWeight(decimal newWeight)
            {
                if (newWeight > 0)
                {
                    Weight = newWeight;
                }
            }

            public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
            {
                if (newWeight > 0 && extraPackingWeight >= 0)
                {
                    Weight = newWeight + extraPackingWeight;
                }
            }

            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                {
                    DeliveryFee = newFee;
                }
            }

            public abstract void PrintShipment();

            protected string StatusMessage()
            {
                switch (Status)
                {
                    case ShipmentStatus.Ready:
                        return $"Shipment {TrackingCode} is Ready.";
                    case ShipmentStatus.OutForDelivery:
                        return $"Shipment {TrackingCode} is Out for Delivery.";
                    default:
                        return $"Shipment {TrackingCode} has been Delivered.";
                }
            }
        }
    }
