using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Laitekirjasto
{
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille
    class Device
    {
        // Luodaan kenttä (field) name, esitellään (define) ja annetaan arvo (set initial value)
        string name = "Uusi laite";
        // Luodaan kenttää vastaava ominaisuus (property) Name ja sille asetusmetodi (set) ja lukumetodi (get). Ne voi kirjoittaa joko yhdelle tai useammalle riville
        public string Name { get { return name; } set { name = value; } }

        string purchaseDate = "1.1.1900";
        public string PurchaseDate { get {  return purchaseDate; } set {  purchaseDate = value; } }

        // Huomaa jälkiliite d (suffix)
        double price = 0.0d;
        public double Price { get { return price; } set { price = value; } }

        int warranty = 12;
        public int Warranty { get { return warranty; } set { warranty = value; } }


        string processorType = "N/A";
        public string ProcessorType { get { return processorType; } set { processorType = value; } }

        int amountRAM = 0;
        public int AmountRam { get { return amountRAM; } set { amountRAM = value; } }

        int storageCapacity = 0;
        public int StorageCapacity { get { return storageCapacity; } set { storageCapacity = value; } }

        // Konstruktori eli olionmuodostin (constructor) ilman argumentteja
        public Device() 
        { 

        }

        // Konstruktori nimi-argumentilla
        public Device(string name) 
        {
            this.name = name;
        }

        // Konstruktori kaikilla argumenteilla
        public Device(string name, string purchaseDate, double price, int warranty)
        {
            this.name = name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }
    }

    // Tietokoneiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device
    class Computer : Device
    {
        // Konstruktorit
        public Computer() : base()
            { }

        public Computer(string name) : base(name)
            { }

        // Muut metodit
        public void ShowInfo()
        {
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);
        }
    }

    // Tablettien luokka, perii laiteluokan 
    class Tablet : Device
    {
        // Kentät
        string operatingSystem;
        public string OperatingSystem { get {  return operatingSystem; } set {  operatingSystem = value; } }
       
        bool stylusEnabled = false;
        public bool StylusEnabled { get {  return stylusEnabled; } set {  stylusEnabled = value; } }

    }

    // Pääohjelman luokka, josta tulee Program.exe
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ohjelman varsinaiset toiminnot tapahtuvat täällä
            // Ohjelma kysyy käyttäjältä tietoja laitteista
            // Vastaamalla kysymyksiin tiedot tallennetaan muuttujiin.

            // Luodaan uusi laite Device-luokasta
            Device laite = new Device("Opekone");
            Console.WriteLine("Laitteen nimi on: " + laite.Name);
            Console.WriteLine("Ostopäivä oli: " + laite.PurchaseDate);

            // Luodaan uusi tietokone, joka perii laiteluokan (Device) ominaisuudet ja metodit
            Computer tietokone1 = new Computer();

            // Asetetaan Prosessori-ominaisuuden arvo
            tietokone1.ProcessorType = "Intel I7";
            tietokone1.AmountRam = 16;

            Console.WriteLine("Uuden tietokoneen nimi on: " + tietokone1.Name + " ja siinä on " + tietokone1.ProcessorType + " -prosessori ja " + tietokone1.AmountRam + " GB keskusmuistia");

            // Luodaan uusi nimetty tietokone toisella konstruktorilla
            Computer tietokone2 = new Computer("Aamun PC");
            tietokone2.ProcessorType = "Intel Core I9";
            tietokone2.AmountRam = 32;
            tietokone2.ShowInfo();


            // Pitää ikkunaa auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}
