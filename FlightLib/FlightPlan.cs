using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        public string id; // identificador
        Position initialPosition; //Posició inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // Metodos

        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public void Moure(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;
            
            //Comprovem que no ens passem
            if ((x - currentPosition.GetX()) * (x - finalPosition.GetX()) > 0 || (y - currentPosition.GetY()) * (y - finalPosition.GetY()) > 0)
            {
                x = finalPosition.GetX();
                y = finalPosition.GetY();
                EstaAlFinal();
            }

            currentPosition = new Position(x, y);
        }

        public bool EstaAlFinal()
        {
            if (currentPosition.GetX() == finalPosition.GetX() && currentPosition.GetY() == finalPosition.GetY())
            {
                Console.WriteLine("L'avio " + id + " ha arribat al seu desti");
                return true;
            }
            return false;
        }
        
        public bool Conflicte(FlightPlan plane, double distanciaSeguretat)
        {
            if (this.currentPosition.Distancia(plane.currentPosition) < distanciaSeguretat)
            {
                Console.WriteLine("L'avio " + id + " te un conflicte amb l'avio " + plane.id + "!!!");
                return true;
            }
            return false;
        }

        public Position GetPosition()
        {
            return currentPosition;
        }

        public void Restart()
        {
            currentPosition = initialPosition;
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            Console.WriteLine("******************************");
        }
    }
}
