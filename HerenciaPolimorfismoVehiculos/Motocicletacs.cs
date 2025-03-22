using System;

namespace HerenciaPolimorfismoVehiculos
{
    internal class Motocicleta : Vehiculo
    {
        private bool frenoDeMano;
        private bool frenoDePie;
        private bool arrancarConPata;
        private int nivelReserva;
        private bool usandoReserva;

        public bool FrenoDeMano
        {
            get { return frenoDeMano; }
            private set { frenoDeMano = value; }
        }

        public bool FrenoDePie
        {
            get { return frenoDePie; }
            private set { frenoDePie = value; }
        }

        public bool ArrancarConPata
        {
            get { return arrancarConPata; }
            private set { arrancarConPata = value; }
        }

        public Motocicleta(int anio, string elColor, string elModelo, string tipoGasolina, int capacidadTanque, int nivelReserva)
            : base(anio, elColor, elModelo, tipoGasolina, 2, capacidadTanque)
        {
          
            this.nivelReserva = nivelReserva;
        }

        public void UsarReserva()
        {
            if (usandoReserva)
            {
                Console.WriteLine("Ya se está usando la reserva.");
            }
            else if (nivelReserva > 0)
            {
                usandoReserva = true;
                RecargarCombustible(nivelReserva);
                nivelReserva = 0;
                Console.WriteLine("Se ha activado la reserva y se ha añadido al tanque principal.");
            }
            else
            {
                Console.WriteLine("No hay combustible en la reserva.");
            }
        }

        public void ArrancarConPataMetodo()
        {
            if (!arrancarConPata)
            {
                arrancarConPata = true;
                encendido = true;
                Console.WriteLine("Moto encendida con arranque de pata.");
            }
            else
            {
                Console.WriteLine("La moto ya está encendida.");
            }
        }

public override void Frenar(int decremento)
{
    Console.WriteLine("Cómo deseas frenar? 1. Ambos 2. Freno de mano 3. Freno de pie");
    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Opción no válida, frenando con el freno de pie.");
        FrenoDeMano = false;
        FrenoDePie = true;
    }
    else
    {
        int opcion = int.Parse(input);

        switch (opcion)
        {
            case 1:
                FrenoDeMano = true;
                FrenoDePie = true;
                break;
            case 2:
                FrenoDeMano = true;
                FrenoDePie = false;
                break;
            case 3:
                FrenoDeMano = false;
                FrenoDePie = true;
                break;
            default:
                Console.WriteLine("Opción no válida, frenando con el freno de pie.");
                FrenoDeMano = false;
                FrenoDePie = true;
                break;
        }
    }

    if (FrenoDeMano && FrenoDePie)
    {
        DecrementarVelocidad(2);
    }
    else
    {
        DecrementarVelocidad(1);
    }

    Console.WriteLine($"Frenando... Ahora vas a {Velocidad} KM/H.");
}

        public void ApagarMoto()
        {
            Console.WriteLine("Moto apagada.");
            arrancarConPata = false;
        }
        public override void Acelerar(int incremento)
        {
            if (encendido)
            {
                base.Acelerar(incremento);

                if (NivelCombustible > 1)
                {
                    IncrementarVelocidad(incremento);
                    DecrementarCombustible(1);
                    CambiarMarcha();
                }
                else
                {
                    Console.WriteLine("No hay suficiente combustible para acelerar.");
                }
            }
            else
            {
                Console.WriteLine("La moto está apagada.");
            }
        }
    }
}