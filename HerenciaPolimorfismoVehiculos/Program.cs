using System;
using HerenciaPolimorfismoVehiculos;

namespace HerenciaPolimorfismoVehiculos
{
    class Program
    {
        static void Main()
        {
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            int opcion;
            do
            {
                MostrarOpcionesMenuPrincipal();
                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                ProcesarOpcionMenuPrincipal(opcion);
            } while (opcion != 4);
        }

        static void MostrarOpcionesMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("==========================  Menú Principal ===========================");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("1. Auto de Combustión");
            Console.WriteLine("2. Camión");
            Console.WriteLine("3. Moto");
            Console.WriteLine("4. Salir");
            Console.Write("Elija el vehículo que desea usar hoy: ");
        }

        static void ProcesarOpcionMenuPrincipal(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    UsarAutoDeCombustion();
                    break;
                case 2:
                    UsarCamion();
                    break;
                case 3:
                    UsarMoto();
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar nuestro sistema. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        static void UsarAutoDeCombustion()
        {
            AutoDeCombustion auto = new AutoDeCombustion(2023, "Rojo", "Toyota", "Gasolina", 4, 50, true, true);
            MostrarMenuVehiculo(auto);
        }

        static void UsarCamion()
        {
            Camion camion = new Camion("Rojo", "Volvo FH16", 2022, 5000, "Grande", true);
            MostrarMenuVehiculo(camion);
        }

        static void UsarMoto()
        {
            Motocicleta moto = new Motocicleta(2022, "Roja", "Yamaha YZF-R1", "Superior", 50, 5);
            MostrarMenuVehiculo(moto);
        }

        static void MostrarMenuVehiculo(Vehiculo vehiculo)
        {
            int opcionVehiculo;
            do
            {
                MostrarOpcionesMenuVehiculo(vehiculo);
                if (!int.TryParse(Console.ReadLine(), out opcionVehiculo))
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                ProcesarOpcionMenuVehiculo(vehiculo, opcionVehiculo);
            } while (true);
        }

        static void MostrarOpcionesMenuVehiculo(Vehiculo vehiculo)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"====================  Menú del {vehiculo.GetType().Name} =====================");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("1. Ver Información del Vehículo");
            Console.WriteLine("2. Encender");
            Console.WriteLine("3. Apagar");
            Console.WriteLine("4. Acelerar");
            Console.WriteLine("5. Frenar");
            Console.WriteLine("6. Recargar Combustible");

            if (vehiculo is AutoDeCombustion auto)
            {
                Console.WriteLine("7. Descapotar");
                Console.WriteLine("8. Usar Maletero");
                Console.WriteLine("9. Bloquear Puertas");
                Console.WriteLine("10. Desbloquear Puertas");
                Console.WriteLine("11. Cambiar Aceite");
                Console.WriteLine("12. Salir del Auto");
            }
            else if (vehiculo is Camion camion)
            {
                Console.WriteLine("7. Cargar");
                Console.WriteLine("8. Descargar");
                Console.WriteLine("9. Cambiar Aceite");
                Console.WriteLine("10. Salir del Camión");
            }
            else if (vehiculo is Motocicleta moto)
            {
                Console.WriteLine("7. Arrancar con Pata");
                Console.WriteLine("8. Cambiar Aceite");
                Console.WriteLine("9. Salir de la Moto");
            }
            Console.Write("Elija una opción: ");
        }

        static void ProcesarOpcionMenuVehiculo(Vehiculo vehiculo, int opcionVehiculo)
        {
            switch (opcionVehiculo)
            {
                case 1:
                    vehiculo.InformacionDelVehiculo();
                    break;
                case 2:
                    vehiculo.Encender();
                    break;
                case 3:
                    vehiculo.Apagar();
                    break;
                case 4:
                    Console.Write("¿Cuántos kilómetros por hora quieres acelerar?: ");
                    if (int.TryParse(Console.ReadLine(), out int acelerar))
                    {
                        vehiculo.Acelerar(acelerar);
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida.");
                    }
                    break;
                case 5:
                    Console.Write("¿Cuántos kilómetros por hora quieres frenar?: ");
                    if (int.TryParse(Console.ReadLine(), out int frenar))
                    {
                        vehiculo.Frenar(frenar);
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida.");
                    }
                    break;
                case 6:
                    Console.Write("¿Cuántos quetzales deseas recargar?: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidad))
                    {
                        vehiculo.RecargarCombustible(cantidad);
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida.");
                    }
                    break;
                case 7:
                    if (vehiculo is AutoDeCombustion)
                    {
                        ((AutoDeCombustion)vehiculo).Descapotar();
                    }
                    else if (vehiculo is Camion)
                    {
                        Console.Write("¿Cuánto peso deseas cargar?: ");
                        if (double.TryParse(Console.ReadLine(), out double cargar))
                        {
                            ((Camion)vehiculo).Cargar(cargar);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                    }
                    else if (vehiculo is Motocicleta)
                    {
                        ((Motocicleta)vehiculo).ArrancarConPataMetodo();
                    }
                    break;
                case 8:
                    if (vehiculo is AutoDeCombustion)
                    {
                        ((AutoDeCombustion)vehiculo).UsarMaletero();
                    }
                    else if (vehiculo is Camion)
                    {
                        Console.Write("¿Cuánto peso deseas descargar?: ");
                        if (double.TryParse(Console.ReadLine(), out double descargar))
                        {
                            ((Camion)vehiculo).Descargar(descargar);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                    }
                    else if (vehiculo is Motocicleta)
                    {
                        ((Motocicleta)vehiculo).CambiarAceite();
                    }
                    break;
                case 9:
                    if (vehiculo is AutoDeCombustion)
                    {
                        ((AutoDeCombustion)vehiculo).BloquearPuertas();
                    }
                    else if (vehiculo is Camion)
                    {
                        ((Camion)vehiculo).CambiarAceite();
                    }
                    else if (vehiculo is Motocicleta)
                    {
                        Console.WriteLine("Has salido de la moto.");
                        return;
                    }
                    break;
                case 10:
                    if (vehiculo is AutoDeCombustion)
                    {
                        ((AutoDeCombustion)vehiculo).DesbloquearPuertas();
                    }
                    else if (vehiculo is Camion)
                    {
                        Console.WriteLine("Has salido del camión.");
                        return;
                    }
                    break;
                case 11:
                    if (vehiculo is AutoDeCombustion)
                    {
                        ((AutoDeCombustion)vehiculo).CambiarAceite();
                    }
                    break;
                case 12:
                    if (vehiculo is AutoDeCombustion)
                    {
                        Console.WriteLine("Has salido del auto.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}