using System;
using System.Collections.Generic;
using System.Text;

namespace opp__04
{
    public class DeliveryReport
    {
        public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }

        public void PrintInsurance(IInsurable shipment)
        {
            string name = shipment.GetType().Name.Replace("Shipment", " Shipment");
            Console.WriteLine($"{name} Insurance : {shipment.CalculateInsurance():F2} EGP");
        }
    }
}
