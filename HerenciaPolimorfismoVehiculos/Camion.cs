using System;
using System.Text.RegularExpressions;

namespace HerenciaPolimorfismoVehiculos
{
    internal class Camion : Vehiculo
    {
        public double CapacidadCarga { get; private set; }
        private double CargaActual { get; set; }
        private string TamañoPlataforma { get; set; }
        private bool TieneContenedor { get; set; }

        public Camion(string marca, string modelo, int año, double capacidadCarga, string tamañoPlataforma, bool tieneContenedor)
            : base(año, marca, modelo, "Diésel", 6, 200)
        {
            CapacidadCarga = capacidadCarga;
            CargaActual = 0;
            TamañoPlataforma = tamañoPlataforma;
            TieneContenedor = tieneContenedor;
            VelocidadMaxima = 150;
        }

        public override void Acelerar(int incremento)
        {
            if (encendido)
            {
                base.Acelerar(incremento);

                if (NivelCombustible > 3)
                {
                    IncrementarVelocidad(incremento);
                    DecrementarCombustible(3);
                    CambiarMarcha();

                }
                else
                {
                    Console.WriteLine("No hay suficiente combustible para acelerar.");
                }
            }
            else
            {
                Console.WriteLine("El camión está apagado.");
            }
        }

        public override void Frenar(int decremento)
        {
            Velocidad -= decremento;
            if (Velocidad < 0) Velocidad = 0;
            DecrementarCombustible(3);
            CambiarMarcha();
            Console.WriteLine($"Frenando Camión... Velocidad actual: {Velocidad} KM/H. Combustible restante: {NivelCombustible} Marcha actual: {MarchaActual}.");
        }

        public void Cargar(double peso)
        {
            if (CargaActual + peso <= CapacidadCarga)
            {
                CargaActual += peso;
                Console.WriteLine($"Carga añadida. Carga actual: {CargaActual} KG.");
            }
            else
            {
                Console.WriteLine("No se puede cargar más peso, la capacidad máxima ha sido alcanzada.");
            }
        }

        public void Descargar(double peso)
        {
            if (peso <= CargaActual)
            {
                CargaActual -= peso;
                Console.WriteLine($"Carga descargada. Carga actual: {CargaActual} KG.");
            }
            else
            {
                Console.WriteLine("No hay suficiente carga para descargar.");
            }
        }

        public override void Encender()
        {
            encendido = true;
            Console.WriteLine("El camión ha sido encendido.");
        }

        public override void CambiarMarcha()
        {
            if (Velocidad >= 0 && Velocidad < 10)
                MarchaActual = 1;
            else if (Velocidad >= 10 && Velocidad < 30)
                MarchaActual = 2;
            else if (Velocidad >= 30 && Velocidad < 50)
                MarchaActual = 3;
            else if (Velocidad >= 50 && Velocidad < 70)
                MarchaActual = 4;
            else if (Velocidad >= 70 && Velocidad < 90)
                MarchaActual = 5;
            else if (Velocidad >= 90 && Velocidad < 110)
                MarchaActual = 6;
            else if (Velocidad >= 110 && Velocidad < 130)
                MarchaActual = 7;
            else if (Velocidad >= 130)
                MarchaActual = 8;
        }


        public override void InformacionDelVehiculo()
        {
            base.InformacionDelVehiculo();
            Console.WriteLine($"Capacidad de Carga: {CapacidadCarga} KG");
            Console.WriteLine($"Tamaño de Plataforma: {TamañoPlataforma}");
            Console.WriteLine($"Tiene Contenedor: {TieneContenedor}");
            Console.WriteLine($"Velocidad Máxima: {VelocidadMaxima} KM/H");
        }
    }
}