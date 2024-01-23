using System;

namespace exam
{
    class Program
    {
        public static void Main(string[] args)
        {
            MiniMunchMachine machine = new MiniMunchMachine();
            Produkt pepsi = new Produkt("Pepsi",150, new DateTime(5125,02,02));
            Produkt produkcik = new Produkt("Czekolada", 112337, new DateTime(5125, 02, 02));
            Produkt skurwysyn = new Produkt("Marek", 5,new DateTime(2024,01,31));
            machine.AddProdukt(produkcik);
            machine.AddProdukt(pepsi, 'F');
            machine.AddProdukt(skurwysyn, 'S');

            machine.ToString();
            machine.AddMoney(5);
            machine.AddMoney(5);
            machine.Buyprodukt('S');
            machine.ReturnCoins();


            machine.ShowProdukt();

        }
    }

    public class MiniMunchMachine : IVendingMachine
    {
        private const int pojemnoscMaszyny = 20;
        private int kasetkaMaszyny = 0;
        String nazwaAutomatu;
        String wymiaryAutomatu;

        private Dictionary<char, Produkt> produkty = new Dictionary<char, Produkt>();
        
        public MiniMunchMachine()
        {
           nazwaAutomatu = "MiniMunchMachine";
           wymiaryAutomatu = "szer. 74 cm, gł. 87 cm, wys. 94 cm";
        }
        public void AddMoney(int hajs)
        {
            if(hajs == 1 || hajs == 2 || hajs == 5)
            {
                kasetkaMaszyny += hajs;
            }
            else
            {
                throw new ArgumentException("Nie moze byc ujemne");
            }
        }

        public void AddProdukt(Produkt produkt)
        {
            if(produkty.Count >= pojemnoscMaszyny)
            {
                throw new ArgumentException("Maszyna jest pełna!");
            }

            char kodProduktu = 'A';
            while(produkty.ContainsKey(kodProduktu))
            {
                kodProduktu++;
                if(kodProduktu > 'Z')
                {
                    kodProduktu = 'A';
                }
            }
            produkty.Add(kodProduktu, produkt);
        }

        public void AddProdukt(Produkt produkt, char kodProduktu)
        {
            if (produkty.Count >= pojemnoscMaszyny)
            {
                throw new ArgumentException("Maszyna jest pełna!");
            }

            if(!char.IsLetter(kodProduktu) || produkty.ContainsKey(kodProduktu)) 
            {
                throw new ArgumentException("Nieprawidłowy kod produktu");
            }
            produkty.Add(kodProduktu, produkt);
        }

        public void Buyprodukt(char kodProduktu)
        {
            if (produkty.TryGetValue(kodProduktu, out Produkt product))
            {
                if (kasetkaMaszyny >= product.getCena())
                {
                    Console.WriteLine($"Produkt zakupiony: {product.getNazwa()}");
                    kasetkaMaszyny -= product.getCena();
                    produkty.Remove(kodProduktu);
                }
                else
                {
                    Console.WriteLine("Niewystarczająca ilość pieniędzy w kasetce maszyny.");
                }
            }
            else
            {
                Console.WriteLine("Produkt o podanym kodzie nie istnieje.");
            }
        }

        public void ReturnCoins()
        {
            Console.WriteLine($"Zwrócono {kasetkaMaszyny} monet.");
            kasetkaMaszyny = 0;
        }

        public void ShowProdukt()
        {
            foreach(var kvp in produkty)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.getNazwa()} {kvp.Value.getCena()} EUR");
            }
        }
        public override string ToString()
        {
            return $"{nazwaAutomatu} - {wymiaryAutomatu}";
        }
    }

    public class Produkt
    {
        String nazwa;
        int cena;
        DateTime dataWaznosci;

        public Produkt() { }

        public Produkt(string nazwa, int cena, DateTime dataWaznosci)
        {
            setNazwa(nazwa);
            setCena(cena);
            setDataWaznosci(dataWaznosci);
        }

        public String getNazwa()
        {
            return nazwa;
        }
        public int getCena() 
        { 
        return cena;
        }
        public DateTime getDataWaznosci() 
        {
            return dataWaznosci;
        }

        public void setNazwa(string nazwa)
        {
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                throw new ArgumentException("Nazwa nie może być pusta ani zawierać tylko białych znaków");
            }
            this.nazwa = nazwa;
        }
        public void setDataWaznosci(DateTime dataWaznosci)
        {
            if (dataWaznosci < DateTime.MinValue)
            {
                throw new ArgumentException("Data ważności musi być w przyszłości");
            }
            this.dataWaznosci = dataWaznosci;
        }

        public void setCena(int cena)
        {
            try
            {
                if(cena > 0)
                {
                    this.cena = cena;
                }
            }
            catch
            {
                throw new ArgumentException("Cena nie moze byc ujemna lub równa zero");
            }
        }

        public override string ToString()
        {
            return $"Nazwa: {nazwa}, Cena: {cena}, Data ważności: {dataWaznosci.ToString("yyyy-MM-dd")}";
        }
    }

    public interface IVendingMachine
    {
        void AddProdukt(Produkt produkt);
        void AddMoney(int hajs);
        public void Buyprodukt(char kodProduktu);
        public void ReturnCoins();
   
    }
}