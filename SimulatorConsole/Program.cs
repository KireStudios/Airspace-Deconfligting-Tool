using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            FlightPlanList llista = new FlightPlanList();

            string input;
            
            Console.WriteLine("Escriu l'identificador");
            string identificador = Console.ReadLine();

            Console.WriteLine("Escriu la velocitat");
            input = Console.ReadLine();
            double velocitat;
            while (!double.TryParse(input, out velocitat))
            {
                Console.WriteLine("La velocitat ha de ser un nombre... Torna-ho a provar ^-^");
                input = Console.ReadLine();
            }

            Console.WriteLine("Escriu les coordenades de la posició inicial, separades per un espai en blanc");
            string[] coords;
            double ix;
            double iy;
            while (true)
            {
                input = Console.ReadLine();
                while (input == null)
                {
                    Console.WriteLine("Entrada buida... Torna-ho a provar ^-^");
                    input = Console.ReadLine();
                }
                coords = input.Split(' ');
                if (coords.Length == 2 && double.TryParse(coords[0], out ix) && double.TryParse(coords[1], out iy))
                {
                    break;
                }
                Console.WriteLine("Entra unicament 2 coordenades (que son numeros...), la x i la y, separades per un espai en blanc, si us plau ^-^");
            }

            Console.WriteLine("Escriu les coordenades de la posició final, separades per un espai en blanc");
            double fx;
            double fy;
            while (true)
            {
                input = Console.ReadLine();
                while (input == null)
                {
                    Console.WriteLine("Entrada buida... Torna-ho a provar ^-^");
                    input = Console.ReadLine();
                }
                coords = input.Split(' ');
                if (coords.Length == 2 && double.TryParse(coords[0], out fx) && double.TryParse(coords[1], out fy))
                {
                    break;
                }
                Console.WriteLine("Entra unicament 2 coordenades (que son numeros...), la x i la y, separades per un espai en blanc, si us plau ^-^");
            }
            
            FlightPlan plan_a = new FlightPlan(identificador, ix, iy, fx, fy, velocitat);
            llista.AddFlightPlan(plan_a);
            
            Console.WriteLine("Escriu l'identificador");
            identificador = Console.ReadLine();

            Console.WriteLine("Escriu la velocitat");
            input = Console.ReadLine();
            while (!double.TryParse(input, out velocitat))
            {
                Console.WriteLine("La velocitat ha de ser un nombre... Torna-ho a provar ^-^");
                input = Console.ReadLine();
            }

            Console.WriteLine("Escriu les coordenades de la posició inicial, separades per un espai en blanc");
            while (true)
            {
                input = Console.ReadLine();
                while (input == null)
                {
                    Console.WriteLine("Entrada buida... Torna-ho a provar ^-^");
                    input = Console.ReadLine();
                }
                coords = input.Split(' ');
                if (coords.Length == 2 && double.TryParse(coords[0], out ix) && double.TryParse(coords[1], out iy))
                {
                    break;
                }
                Console.WriteLine("Entra unicament 2 coordenades (que son numeros...), la x i la y, separades per un espai en blanc, si us plau ^-^");
            }

            Console.WriteLine("Escriu les coordenades de la posició final, separades per un espai en blanc");
            while (true)
            {
                input = Console.ReadLine();
                while (input == null)
                {
                    Console.WriteLine("Entrada buida... Torna-ho a provar ^-^");
                    input = Console.ReadLine();
                }
                coords = input.Split(' ');
                if (coords.Length == 2 && double.TryParse(coords[0], out fx) && double.TryParse(coords[1], out fy))
                {
                    break;
                }
                Console.WriteLine("Entra unicament 2 coordenades (que son numeros...), la x i la y, separades per un espai en blanc, si us plau ^-^");
            }
            
            FlightPlan plan_b = new FlightPlan(identificador, ix, iy, fx, fy, velocitat);
            llista.AddFlightPlan(plan_b);
            
            // Simulació

            int cicles = 10;
            int tempsCicle = 60;
            double distanciaSeguretat = 10;

            for (int i = 0; i < cicles; i++)
            {
                llista.Moure(tempsCicle);
                llista.EscriureConsola();

                llista.GetFlightPlan(0).Conflicte(llista.GetFlightPlan(1), distanciaSeguretat);
                llista.GetFlightPlan(1).Conflicte(llista.GetFlightPlan(0), distanciaSeguretat);
            }
        }
    }
}
