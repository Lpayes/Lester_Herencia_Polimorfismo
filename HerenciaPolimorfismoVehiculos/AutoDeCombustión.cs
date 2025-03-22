using System;

namespace HerenciaPolimorfismoVehiculos
{
    internal class AutoDeCombustion : Vehiculo
    {
        private bool EsDescapotable { get; set; }
        private bool TieneMaletero { get; set; }
        public bool[] PuertasBloqueadas { get; private set; } = new bool[4];

        public AutoDeCombustion(int year, string color, string modelo, string tipoGasolina, int numeroRuedas,
                                int capacidadTanque, bool esDescapotable, bool tieneMaletero)
            : base(year, color, modelo, tipoGasolina, numeroRuedas, capacidadTanque)
        {
            EsDescapotable = esDescapotable;
            TieneMaletero = tieneMaletero;
        }

        public void Descapotar()
        {
            if (encendido)
            {
                if (EsDescapotable)
                {
                    Console.WriteLine("El auto se ha descapotado.");
                }
                else
                {
                    Console.WriteLine("Este auto no es descapotable.");
                }
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public void UsarMaletero()
        {
            if (encendido)
            {
                if (TieneMaletero)
                {
                    Console.WriteLine("El maletero está siendo utilizado.");
                }
                else
                {
                    Console.WriteLine("Este auto no tiene maletero.");
                }
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public void BloquearPuertas()
        {
            if (encendido)
            {
                for (int i = 0; i < PuertasBloqueadas.Length; i++)
                {
                    PuertasBloqueadas[i] = true;
                }
                Console.WriteLine("Las 4 puertas del auto han sido bloqueadas.");
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public void DesbloquearPuertas()
        {
            if (encendido)
            {
                for (int i = 0; i < PuertasBloqueadas.Length; i++)
                {
                    PuertasBloqueadas[i] = false;
                }
                Console.WriteLine("Las 4 puertas del auto han sido desbloqueadas.");
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public override void Acelerar(int incremento)
        {
            if (encendido)
            {
                if (NivelCombustible > 2)
                {
                    Velocidad += incremento;
                    DecrementarCombustible(2);
                    CambiarMarcha();
                    Console.WriteLine($"Acelerando Auto de Combustión... Velocidad actual: {Velocidad} KM/H. Combustible restante: {NivelCombustible} quetzales. Marcha actual: {MarchaActual}.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente combustible para acelerar.");
                }
            }
            else
            {
                Console.WriteLine("No se puede acelerar. El autode combustión está apagado.");
            }
        }

        public override void Frenar(int decremento)
        {
            base.Frenar( decremento);
            if (encendido)
            {
                DecrementarVelocidad(decremento);
                if (Velocidad < 0) Velocidad = 0;
                Console.WriteLine($"Frenando Auto de Combustión... Velocidad actual: {Velocidad} KM/H. Combustible restante: {NivelCombustible} Marcha actual: {MarchaActual}.");
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public override void RecargarCombustible(int cantidad)
        {
            if (encendido)
            {
                if (NivelCombustible + cantidad <= CapacidadTanque)
                {
                    IncrementarCombustible(cantidad);
                    Console.WriteLine($"Recargando combustible... Nivel actual: {NivelCombustible}");
                }
                else
                {
                    Console.WriteLine("No se puede exceder la capacidad del tanque.");
                }
            }
            else
            {
                Console.WriteLine("El auto de combustión está apagado.");
            }
        }

        public void InformacionAutoDeCombustion()
        {
            Console.WriteLine("=== Información del Auto de Combustión ===");
            Console.WriteLine($"Es descapotable: {EsDescapotable}");
            Console.WriteLine($"Tiene maletero: {TieneMaletero}");
        }
        public override void CambiarMarcha()
        {
            if (encendido)
            {
                if (Velocidad >= 0 && Velocidad <= 20)
                {
                    MarchaActual = 1;
                }
                else if (Velocidad >= 21 && Velocidad <= 40)
                {
                    MarchaActual = 2;
                }
                else if (Velocidad >= 41 && Velocidad <= 70)
                {
                    MarchaActual = 3;
                }
                else if (Velocidad >= 71 && Velocidad <= 100)
                {
                    MarchaActual = 4;
                }
                else if (Velocidad >= 101 && Velocidad <= 130)
                {
                    MarchaActual = 5;
                }
                else if (Velocidad >= 131)
                {
                    MarchaActual = 6;
                }

                Console.WriteLine($"Marcha actual: {MarchaActual}");
            }
            else
            {
                Console.WriteLine("El carro está apagado.");
            }
        }
    }
}