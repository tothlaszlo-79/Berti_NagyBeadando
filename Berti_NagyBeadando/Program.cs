using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

 
public enum Megnevezes  {Puszta, Zold, Mocsar }
public enum Idojaras { Napos, Felhos, Esos }

class Terulet {
    public string Nev { get; set; }
    public Megnevezes Megnevezes { get; set; }
    public int Tarolt_viz { get; set; }

    private double _paratartalom;

    public Idojaras idojaras { get; set; }

    public Terulet(string nev, Megnevezes megnevezes, int tarolt_viz, double paratartalom)
    {
        Nev = nev;
        Megnevezes = megnevezes;
        Tarolt_viz = tarolt_viz;
        _paratartalom = paratartalom;
    }

    public void Valzotas()
    {
       

        switch (Megnevezes)
        {
            case Megnevezes.Puszta:
                _paratartalom = _paratartalom * 1.03 ;
                
                break;
            case Megnevezes.Zold:
                _paratartalom = _paratartalom * 1.07;
                break;
            case Megnevezes.Mocsar:
                _paratartalom = _paratartalom * 1.1;
                break;
        }

        switch (_paratartalom) {
            case double n when (n > 70.0):
                _paratartalom = 30.0;
                idojaras = Idojaras.Esos;
                break;
            case double n when (n < 70.0 && n >= 40.0):
                _paratartalom = (_paratartalom - 40.0) * 1.033;
                if (_paratartalom > 70.0)
                {
                    idojaras = Idojaras.Esos;
                }
                else
                {
                    idojaras = Idojaras.Felhos;
                }
                break;

            case double n when (n < 40.0):
                idojaras = Idojaras.Napos;
                break;
        }


        switch (Megnevezes)
        {
            case Megnevezes.Puszta:
                switch (idojaras)
                {
                    case Idojaras.Napos:
                        Tarolt_viz = Tarolt_viz - 3;
                        break;
                    case Idojaras.Felhos:
                        Tarolt_viz = Tarolt_viz - 1;
                        break;
                    case Idojaras.Esos:
                        Tarolt_viz = Tarolt_viz + 5;
                        break;
                }

                if (Tarolt_viz < 15)
                {
                    Megnevezes = Megnevezes.Zold;
                }

                break;

            case Megnevezes.Zold:
                switch (idojaras)
                {
                    case Idojaras.Napos:
                        Tarolt_viz = Tarolt_viz - 6;
                        break;
                    case Idojaras.Felhos:
                        Tarolt_viz = Tarolt_viz - 2;
                        break;
                    case Idojaras.Esos:
                        Tarolt_viz = Tarolt_viz + 10;
                        break;
                }

                if (Tarolt_viz > 50)
                {
                    Megnevezes = Megnevezes.Mocsar;
                }
                if (Tarolt_viz < 15)
                {
                    Megnevezes = Megnevezes.Puszta;
                }
                break;


            case Megnevezes.Mocsar:
                switch (idojaras)
                {
                    case Idojaras.Napos:
                        Tarolt_viz = Tarolt_viz - 10;
                        break;
                    case Idojaras.Felhos:
                        Tarolt_viz = Tarolt_viz - 3;
                        break;
                    case Idojaras.Esos:
                        Tarolt_viz = Tarolt_viz + 15;
                        break;
                }

                if (Tarolt_viz < 50)
                {
                    Megnevezes = Megnevezes.Zold;
                }
                break;
            
        }

    }

};

class Program
{
    static void Main()
    {

        List<Terulet> teruletek = new List<Terulet>();

        teruletek.Add(new Terulet("Beant", Megnevezes.Mocsar, 86, 98.0));
        teruletek.Add(new Terulet("Green", Megnevezes.Zold, 26, 98.0));
        teruletek.Add(new Terulet("Dean", Megnevezes.Puszta, 12, 98.0));
        teruletek.Add(new Terulet("Teen", Megnevezes.Zold, 35, 98.0));


        for (int i = 0; i < 5; i++)
        {
            foreach (var terulet in teruletek)
            {
                terulet.Valzotas();
                Console.WriteLine("Terulet neve: {0}, Megnevezes: {1}, Tarolt viz: {2}, Időjárás: {3}", terulet.Nev, terulet.Megnevezes, terulet.Tarolt_viz, terulet.idojaras);
            }
        }
        



    }
}



