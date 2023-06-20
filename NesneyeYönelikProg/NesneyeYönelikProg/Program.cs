using System;

namespace NesneyeYönelikProg
{
    class Program
    {
        static void Main(string[] args) 
        {
            //int say1 = 10;
            //int say2 = 20;
            //say1= say2;
            //say2 = 50;
            //Console.WriteLine(say1);

            // Çıktısı 20 dir.

            //CreditManager creditManager = new CreditManager();
            //creditManager.Calculate();
            //creditManager.Save();


            //Customer customer = new Customer();
            //customer.Id = 1;
            //customer.City = "İstanbul";


            //CustomerManager customerManager = new CustomerManager(customer);
            //customerManager.Save();
            //customerManager.Delete();


            //Company company = new Company();
            //company.TaxNumber = "123";
            //company.CompanyName = "Arçelik";
            //company.Id  = 100;

            //CustomerManager customerManager2 = new CustomerManager(new Company());
            
            //Person person = new Person();
            //person.NationalIdentity = "12345678910";


            //Customer c1 = new Customer(); 
            //Customer c2 = new Person();
            //Customer c3 = new Company();

            //IOC CONTAINER !!!!
            CustomerManager customerManager = new CustomerManager(new Customer(),new TeacherCreditManager());
            customerManager.GiveCredit();


            Console.ReadLine();

        }
    }

    class CreditManager
    {
        public void Calculate(int creditType) // method
        {
            if (creditType == 1) // esnaf 
            {
                
            }
            if (creditType == 2) // öğretmen
            {

            }

            Console.WriteLine("Hesaplandı.");           
        }

        public void Save() // method
        {
            Console.WriteLine("Kredi Verildi.");
        }

    }


    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate(); //tamamlanmamış           //Ortak operasyonları tutar ama bu operasyonların tamamlanmış ve tamamlanmamış olanları örnekteki gibi tutacaktır

        public virtual void Save()   // tamamlanmış
        {
            Console.WriteLine("Kaydedildi.");
        }
    }


    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()  //override = üstüne yaz.
        {
            //hesaplamalar
            Console.WriteLine("Öğretmen Kredisi Hesaplandı.");
        }

        public override void Save()
        {

            //
            base.Save();
            //
        }
    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {         
            Console.WriteLine("Asker Kredisi Hesaplandı.");
        }
    }



    // SOLID

    class Customer
    {
        //prop(özellikleri) // verileri burda tutar. // okuma ve yazma.

        public Customer()
        {
            Console.WriteLine("Müşteri Nesnesi Başlatıldı.");
        }
        public int Id { get; set; }

        public string City { get; set; }

    }

    class Person : Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalIdentity { get; set; }
    }

    class Company : Customer    //inherit
    {
        public string CompanyName { get; set; }

        public string TaxNumber { get; set; }
    }



    //Katmanlı Mimariler
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;                                      // sadece bu class içerisinde kullanılabilir.
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }

        public void Save()              //encapsulation
        {
            Console.WriteLine("Müşteri Kaydedildi.");
        }

                                                                             //interfaceler referans tiptir. Bağımlılıklrı engelleme ve if lerden kurtulma.
        public void Delete()              //encapsulation
        {
            Console.WriteLine("Müşteri Silindi.");
        }
        
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi Verildi.");
        }
    }
      
}
