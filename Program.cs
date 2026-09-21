namespace opp__04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region answer_1
            // Abstraction is the OOP principle of hiding complex implementation details and exposing only the essential features that a user of an object needs
            // It lets you focus on what an object does rather than how it does it.
            //Abstraction is considered a pillar because it addresses the central problem OOP was created to solve: managing complexity in large software systems
            //The other three pillars (encapsulation, inheritance, polymorphism) are largely the means by which abstraction is put into practice
            #endregion
            #region answer_02
            //Abstraction is considered a pillar because it addresses the central problem OOP was created to solve: managing complexity in large software systems
            //The other three pillars(encapsulation, inheritance, polymorphism) are largely the means by which abstraction is put into practice
            // choose an interface when you're defining a capability (what something can do),
            // and an abstract class when you're defining a base type(what something is) that shares state or code.
            //Multiple abstract class : No , sMultiple interfaces: yes
            #endregion
            #region answer_03
 
                DeliveryAddress address = new DeliveryAddress("Cairo", "Tahrir St", "Egypt");

                // a, b, c: إنشاء الشحنات الثلاثة
                StandardShipment standard = new StandardShipment("SH001", "Laptop", 3, 80, address);

                ExpressShipment express = new ExpressShipment("SH002", "Documents", 4, 50, address, 30);
                express.Status = ShipmentStatus.OutForDelivery;

                InternationalShipment international = new InternationalShipment("SH003", "Machine", 10, 100, address, "Germany", 110);
                international.Status = ShipmentStatus.Delivered;

                // d: إضافتهم للـ DeliveryCenter
                DeliveryCenter center = new DeliveryCenter();
                center.AddShipment(standard);
                center.AddShipment(express);
                center.AddShipment(international);

                DeliveryReport report = new DeliveryReport();

                // e: طباعة تفاصيل الشحنات
                Console.WriteLine("==========================================");
                Console.WriteLine("Delivery Center");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                center.PrintAllShipments();

                // f: حالة التتبع عن طريق DeliveryCenter
                Console.WriteLine("==========================================");
                Console.WriteLine("Tracking Status");
                Console.WriteLine();
                center.PrintTrackingStatuses();
                Console.WriteLine();

                // g: التأمين عن طريق DeliveryReport
                Console.WriteLine("==========================================");
                Console.WriteLine("Insurance");
                Console.WriteLine();
                report.PrintInsurance(standard);
                report.PrintInsurance(express);
                report.PrintInsurance(international);
                Console.WriteLine();

                // h: ITrackable[] array
                ITrackable[] trackables = { standard, express, international };
                foreach (ITrackable t in trackables)
                    report.PrintShipment(t);

                // i: IInsurable[] array
                IInsurable[] insurables = { standard, express, international };
                foreach (IInsurable i in insurables)
                    report.PrintInsurance(i);

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");

                Console.ReadKey();
            #endregion
        }
    
            

    }
}
