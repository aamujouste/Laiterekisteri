using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Laitekirjasto
{
    // Yleinen laiteluokka, yliluokka tietokoneille, tableteille ja puhelimille
    // ------------------------------------------------------------------------
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
        // ----------------------------------------------------------------
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

        // Yliluokan metodit
        // -----------------
        public void ShowPurchaseInfo()
        {
            // Luetaan laitteen ostotiedot sen kentistä, huom! this
            Console.WriteLine("Laitteen nimi: " + this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        public void ShowBasicTechnicalInfo()
        {
            // Luetaan laitteen yleiset tekniset tiedot ominaisuuksista, huom! iso alkukirjain
            Console.WriteLine("Laitteen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);
        }
    }

    // --------------------------------------------------------------------------
    class Computer : Device
    // Tietokoneiden luokka, perii ominaisuuksia ja metodeja laiteluokasta Device
    {
        // Konstruktorit
        public Computer() : base()
            { }

        public Computer(string name) : base(name)
            { }

        // Muut metodit
        
    }

    // -------------------------------------------
    class Tablet : Device
    // Tablettien luokka, perii laiteluokan Device
    {
        // Kentät ja ominaisuudet
        // ----------------------
        string operatingSystem;
        public string OperatingSystem { get {  return operatingSystem; } set {  operatingSystem = value; } }
       
        bool stylusEnabled = false;
        public bool StylusEnabled { get {  return stylusEnabled; } set {  stylusEnabled = value; } }

        // Konstruktorit
        // -------------
        public Tablet() : base() { }
        
        public Tablet(string name) : base(name) { }

        // Tablet-luokan erikoismetodit
        // ----------------------------
        public void TabletInfo()
        {
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }
    }

    // -------------------------------------------
    internal class Program
    // Pääohjelman luokka, josta tulee Program.exe
    {
        static void Main(string[] args)
        {
            // Ohjelman varsinaiset toiminnot tapahtuvat täällä
            // Ohjelma kysyy käyttäjältä tietoja laitteista
            // Vastaamalla kysymyksiin tiedot tallennetaan muuttujiin.

            // Luodaan uusi tietokone, joka perii laiteluokan (Device) ominaisuudet ja metodit
            // -------------------------------------------------------------------------------
            Computer tietokone1 = new Computer();

            // Asetetaan Prosessori-ominaisuuden arvo
            tietokone1.ProcessorType = "Intel I7";
            tietokone1.AmountRam = 16;
            tietokone1.PurchaseDate = "15.02.2024";
            tietokone1.Price = 850.00d;
            tietokone1.Warranty = 36;

            Console.WriteLine("Tietokone 1:n hankintatiedot");
            Console.WriteLine("----------------------------");
            tietokone1.ShowPurchaseInfo();
            Console.WriteLine("");

            // Luodaan uusi nimetty tietokone toisella konstruktorilla
            Computer tietokone2 = new Computer("Aamun PC");
            tietokone2.ProcessorType = "Intel Core I9";
            tietokone2.AmountRam = 32;

            Console.WriteLine("Tietokone 2:n tekniset tiedot");
            Console.WriteLine("----------------------------");
            tietokone2.ShowBasicTechnicalInfo();
            Console.WriteLine("");

            // Luodaan testiolio tableteille
            Tablet tabletti1 = new Tablet("Aamun iPad");
            tabletti1.PurchaseDate = "1.10.2022";
            tabletti1.Price = 380.00d;
            tabletti1.OperatingSystem = "IOS";
            tabletti1.StylusEnabled = true;
            Console.WriteLine("");

            // Näytetään tietoja metodien avulla
            Console.WriteLine("Tabletti 1: hankintatiedot tiedot");
            Console.WriteLine("---------------------------");
            tabletti1.ShowPurchaseInfo();
            Console.WriteLine("");

            Console.WriteLine("Tabletti 1: tekniset tiedot");
            Console.WriteLine("---------------------------");
            tabletti1.ShowBasicTechnicalInfo();
            Console.WriteLine("");

            Console.WriteLine("Tabletti 1: erityistiedot");
            Console.WriteLine("---------------------------");
            tabletti1.TabletInfo();

            // Pitää ikkunaa auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}
