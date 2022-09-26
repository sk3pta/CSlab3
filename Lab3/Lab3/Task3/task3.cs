
/*
 * Создайте базовый класс Currency со свойством Value.
 * Создайте 3 производных от Currency класса – CurrencyUSD, CurrencyEUR и CurrencyRUB со свойствами
 * , соответствующими обменному курсу. В каждом из производных классов переопределите операторы преобразования типов таким образом, 
 * чтобы можно было явно и неявно преобразовать одну валюту в другую по курсу, заданному пользователем при запуске программы.
 * */

namespace Lab3.Task3
{





    public class Program

    {

        public abstract class Currency
        {
            protected double value;
        }


        public class CurrencyUSD : Currency
        {



            public CurrencyUSD(double value)
            {
                this.value = value;
            }

            
            public static implicit operator CurrencyRUB(CurrencyUSD cur)
            {
                return new CurrencyRUB(cur.Value/CurrencyRUB.ExchangeRate);
            }

            public static implicit operator CurrencyEUR(CurrencyUSD cur)
            {
                return new CurrencyEUR(cur.Value/CurrencyEUR.ExchangeRate);
            }
            
            public double Value
            {
                get { return this.value; }
            }
        }


        public class CurrencyEUR : Currency
        {

            public static double ExchangeRate { get; set; }


            public static implicit operator CurrencyUSD(CurrencyEUR cur)
            {
                return new CurrencyUSD(cur.Value * CurrencyEUR.ExchangeRate);
            }

            public static implicit operator CurrencyRUB(CurrencyEUR cur)
            {
                return new CurrencyRUB(cur.Value * CurrencyEUR.ExchangeRate / CurrencyRUB.ExchangeRate);
            }


            public CurrencyEUR(double value)
            {
                this.value = value;
            }
            public double Value
            {
                get { return this.value; }
            }
        }

        public class CurrencyRUB : Currency {

            public static double ExchangeRate { get; set; }

            public static implicit operator CurrencyUSD(CurrencyRUB cur)
            {
                return new CurrencyUSD(cur.Value / CurrencyRUB.ExchangeRate);
            } 

            public static implicit operator CurrencyEUR(CurrencyRUB cur)
            {
                return new CurrencyEUR(cur.Value / CurrencyRUB.ExchangeRate / CurrencyEUR.ExchangeRate);
            }


            public CurrencyRUB(double value)
            {
                this.value = value;
            }

            public double Value
            {
                get { return this.value; }
            }
        }

        public static void Main(string[] args)
        {

            CurrencyRUB.ExchangeRate = 0.016;
            CurrencyEUR.ExchangeRate = 0.8;


            CurrencyUSD cur = new CurrencyUSD(500);
            Console.WriteLine($"There are $500 in your pocket");
            CurrencyEUR eur = cur;
            Console.WriteLine($"It's {eur.Value} EUR");
            CurrencyRUB rub = eur;
            Console.WriteLine($"It's {rub.Value} RUB");
        }
    }
}