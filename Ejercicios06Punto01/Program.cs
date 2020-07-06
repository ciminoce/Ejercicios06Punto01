using System;

namespace Ejercicios06Punto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicios 06 Punto 01";
            int cantidadX = 0;
            int mayorEdad = -1;
            int menorEdad = 200;
            string mayorPersona=""; 
            string menorPersona="";
            int sumaEdades = 0;
            int cantidadPersonasEntre25y40=0;

            bool hayError = true;
            do
            {
                Console.Write("Ingrese la cantidad de personas a evaluar:");
                if (!int.TryParse(Console.ReadLine(), out cantidadX))
                {
                    Console.WriteLine("Cantidad no válida");
                }else if (cantidadX<=0)
                {
                    Console.WriteLine("La cantidad debería ser superior a 0");
                }
                else
                {
                    hayError = false;
                }

            } while (hayError);

            for (int i = 1; i <= cantidadX; i++)
            {
                //Ciclo de control del ingreso del nombre
                hayError = true;
                var nombrePersona = "";
                do
                {
                    Console.Write("Ingrese el nombre de la persona:");
                    nombrePersona = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nombrePersona.Trim()) 
                        && !string.IsNullOrWhiteSpace(nombrePersona.Trim()))
                    {
                        hayError = false;
                    }
                    else
                    {
                        Console.WriteLine("El nombre es requerido");
                    }
                } while (hayError);

                //Ciclo de control del ingreso de la fecha de nacimiento
                hayError = true;
                DateTime fechaNacimiento;
                do
                {
                    Console.Write("Ingrese la fecha de nacimiento:");
                    if (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                    {
                        Console.WriteLine("Fecha mal ingresada");
                    }else if (fechaNacimiento>DateTime.Today)
                    {
                        Console.WriteLine("Fecha superior a la actual");
                    }
                    else
                    {
                        hayError = false;
                    }
                    
                } while (hayError);

                var edad = CalcularEdad(fechaNacimiento);
                Console.WriteLine($"{nombrePersona} su edad es {edad}");

                if (edad>mayorEdad)
                {
                    mayorPersona = nombrePersona;
                    mayorEdad = edad;
                }

                if (edad<menorEdad)
                {
                    menorPersona = nombrePersona;
                    menorEdad = edad;
                }

                sumaEdades += edad;
                if (VerEdad(edad))
                {
                    cantidadPersonasEntre25y40++;
                }

                //if (edad >= 25 && edad <= 40)
                //{
                //     cantidadPersonasEntre25y40++;
                   
                //}

            }

            double promedioEdades = sumaEdades / cantidadX;
            Console.WriteLine($"La persona de más edad es {mayorPersona} con {mayorEdad} años");
            Console.WriteLine($"La persona de menos edad es {menorPersona} con {menorEdad} años");
            Console.WriteLine($"La cantidad de personas entre 25 y 40 años es {cantidadPersonasEntre25y40}");
            Console.WriteLine($"El promedio de edades es {promedioEdades}");
            Console.ReadLine();
        }

        private static bool VerEdad(int edad)
        {
            return edad >= 25 && edad <= 40;
        }

        private static int CalcularEdad( DateTime fechaNacimiento)
        {
           return (int) Math.Truncate(DateTime.Today.Subtract(fechaNacimiento).TotalDays / 365.25);
        }
    }
}
