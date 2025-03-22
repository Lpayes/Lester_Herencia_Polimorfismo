using System;

namespace HerenciaPolimorfismoVehiculos
{
    internal class Vehiculo
    {
        public string Color { get; set; }
        public string Modelo { get; }
        public int Year { get; }
        public string TipoGasolina { get; private set; }
        protected int NumeroRuedas { get; }
        protected int CapacidadTanque { get; set; }
        protected int NivelCombustible { get; set; }
        protected int Velocidad { get; set; }
        protected bool encendido;
        protected int VelocidadMaxima { get; set; }
        public int MarchaActual { get; set; }

        public Vehiculo(int year, string color, string modelo, string tipoGasolina, int numeroRuedas, int capacidadTanque)
        {
            Year = year;
            Color = color;
            Modelo = modelo;
            TipoGasolina = tipoGasolina;
            NumeroRuedas = numeroRuedas;
            CapacidadTanque = capacidadTanque;
            NivelCombustible = capacidadTanque;
            Velocidad = 0;
            encendido = false;
        }

        public virtual void Acelerar(int incremento)
        {
            if (encendido)
            {
                if (NivelCombustible > 1)
                {
                    Velocidad += incremento;
                    DecrementarCombustible(1);
                    CambiarMarcha();
                    Console.WriteLine($"Acelerando... Velocidad actual: {Velocidad} KM/H. Combustible restante: {NivelCombustible} . Marcha actual: {MarchaActual}.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente combustible para acelerar.");
                }
            }
            else
            {
                Console.WriteLine("No se puede acelerar. El vehículo está apagado.");
            }
        }

        public virtual void CambiarMarcha()
        {
            if (encendido)
            {
                if (Velocidad >= 0 && Velocidad < 20)
                {
                    MarchaActual = 1;
                }
                else if (Velocidad >= 20 && Velocidad < 40)
                {
                    MarchaActual = 2;
                }
                else if (Velocidad >= 40 && Velocidad < 70)
                {
                    MarchaActual = 3;
                }
                else if (Velocidad >= 70 && Velocidad < 100)
                {
                    MarchaActual = 4;
                }
                else if (Velocidad >= 100 && Velocidad < 140)
                {
                    MarchaActual = 5;
                }
                else
                {
                    MarchaActual = 6;
                }
            }
            else
            {
                Console.WriteLine("No se puede cambiar de marcha. El vehículo está apagado.");
            }
        }

        public virtual void Frenar(int decremento)
        {
            if (encendido)
            {
                Velocidad -= decremento;
                if (Velocidad < 0)
                {
                    Velocidad = 0;
                }
                
            }
            else
            {
                Console.WriteLine("No se puede frenar, el vehículo está apagado.");
            }
        }

        public virtual void RecargarCombustible(int cantidad)
        {
            if (NivelCombustible + cantidad <= CapacidadTanque)
            {
                NivelCombustible += cantidad;
                Console.WriteLine($"Recargando combustible... Nivel actual: {NivelCombustible} qtz.");
            }
            else
            {
                Console.WriteLine("No se puede exceder la capacidad del tanque.");
            }
        }

        public virtual void Encender()
        {
            if (!encendido)
            {
                encendido = true;
                Console.WriteLine("El vehículo ha sido encendido.");
            }
            else
            {
                Console.WriteLine("El vehículo ya está encendido.");
            }
        }

        public void Apagar()
        {
            if (encendido)
            {
                encendido = false;
                Console.WriteLine("El vehículo ha sido apagado.");
            }
            else
            {
                Console.WriteLine("El vehículo ya está apagado.");
            }
        }


        public virtual void CambiarAceite()
        {
            Console.WriteLine("Cambiando el aceite del vehículo...");
        }

        public virtual void InformacionDelVehiculo()
        {
            Console.WriteLine("=== Información del Vehículo ===");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Modelo y marca: {Modelo}");
            Console.WriteLine($"Año: {Year}");
            Console.WriteLine($"Tipo de gasolina: {TipoGasolina}");
            Console.WriteLine($"Número de ruedas: {NumeroRuedas}");
            Console.WriteLine($"Velocidad actual: {Velocidad} KM/H");
            Console.WriteLine($"Capacidad del tanque: {CapacidadTanque} ");
            Console.WriteLine($"Nivel de combustible: {NivelCombustible}");
            Console.WriteLine($"Estado: {(encendido ? "Encendido" : "Apagado")}");
        }

        protected void IncrementarVelocidad(int incremento)
        {
            Velocidad += incremento;
        }

        protected void DecrementarVelocidad(int decremento)
        {
            Velocidad -= decremento;
        }

        protected void IncrementarCombustible(int cantidad)
        {
            NivelCombustible += cantidad;
        }

        protected void DecrementarCombustible(int cantidad)
        {
            NivelCombustible -= cantidad;
        }
    }
}