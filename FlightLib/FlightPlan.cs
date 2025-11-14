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

        string id; // identificador
        string company; // companyia
        Position initialPosition; //Posició inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, string comp, double ipx, double ipy, double fpx, double fpy, double velocidad, double cpx = Double.PositiveInfinity, double cpy = Double.PositiveInfinity)
        {
            this.id = id;
            this.company = comp;
            this.initialPosition = new Position(ipx, ipy);
            if (cpx == Double.PositiveInfinity && cpy == Double.PositiveInfinity)
            {
                this.currentPosition = new Position(ipx, ipy);
            }
            else
            {
                this.currentPosition = new Position(cpx, cpy);
            }
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
            // Si ya está al final, no hacer nada
            if (EstaAlFinal())
            {
                return;
            }

            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            
            // Si la hipotenusa es 0, ya estamos en el destino
            if (hipotenusa == 0)
            {
                return;
            }
            
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

        public void SetPosition(double x, double y)
        {
            this.currentPosition = new Position(x, y);
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
            // CORRECCIÓN: distanciaSeguretat es el RADIO, comparar con la SUMA de radios
            double distanciaMinima = distanciaSeguretat * 2;
            
            if (this.currentPosition.Distancia(plane.currentPosition) < distanciaMinima)
            {
                Console.WriteLine("L'avio " + id + " te un conflicte amb l'avio " + plane.id + "!!!");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fase 10: Calcula la distancia mínima entre este avión y otro considerando sus trayectorias y velocidades en función del tiempo
        /// </summary>
        public double CalcularDistanciaMinimaFutura(FlightPlan otroAvion)
        {
            // Obtener posiciones actuales
            double x1 = this.currentPosition.GetX();
            double y1 = this.currentPosition.GetY();
            double x2 = otroAvion.currentPosition.GetX();
            double y2 = otroAvion.currentPosition.GetY();
            
            // Obtener posiciones finales
            double fx1 = this.finalPosition.GetX();
            double fy1 = this.finalPosition.GetY();
            double fx2 = otroAvion.finalPosition.GetX();
            double fy2 = otroAvion.finalPosition.GetY();
            
            // Calcular distancias a los destinos
            double dist1 = Math.Sqrt((fx1 - x1) * (fx1 - x1) + (fy1 - y1) * (fy1 - y1));
            double dist2 = Math.Sqrt((fx2 - x2) * (fx2 - x2) + (fy2 - y2) * (fy2 - y2));
            
            // Si algún avión ya llegó, usar distancia actual
            if (dist1 < 0.01 || dist2 < 0.01)
            {
                return this.currentPosition.Distancia(otroAvion.currentPosition);
            }
            
            // Vectores de dirección normalizados multiplicados por velocidad
            double vx1 = (fx1 - x1) / dist1 * this.velocidad;
            double vy1 = (fy1 - y1) / dist1 * this.velocidad;
            double vx2 = (fx2 - x2) / dist2 * otroAvion.velocidad;
            double vy2 = (fy2 - y2) / dist2 * otroAvion.velocidad;
            
            // Calcular velocidad relativa
            double dvx = vx1 - vx2;
            double dvy = vy1 - vy2;
            
            // Posición relativa
            double dx = x1 - x2;
            double dy = y1 - y2;
            
            // Calcular tiempo al punto más cercano: t = -(dx*dvx + dy*dvy) / (dvx^2 + dvy^2)
            double velocidadRelativaCuadrado = dvx * dvx + dvy * dvy;
            
            if (velocidadRelativaCuadrado < 0.0001) 
            {
                // Velocidades paralelas o iguales, distancia se mantiene constante
                return Math.Sqrt(dx * dx + dy * dy);
            }
            
            double t = -(dx * dvx + dy * dvy) / velocidadRelativaCuadrado;
            
            // Limitar t al tiempo máximo de vuelo de cada avión
            double tiempoMaximo1 = dist1 / this.velocidad;
            double tiempoMaximo2 = dist2 / otroAvion.velocidad;
            double tiempoMaximo = Math.Min(tiempoMaximo1, tiempoMaximo2);
            
            if (t < 0)
                t = 0;
            else if (t > tiempoMaximo)
                t = tiempoMaximo;
            
            // Calcular posiciones en el tiempo t
            double px1 = x1 + vx1 * t;
            double py1 = y1 + vy1 * t;
            double px2 = x2 + vx2 * t;
            double py2 = y2 + vy2 * t;
            
            // Distancia mínima
            double distanciaMinima = Math.Sqrt((px1 - px2) * (px1 - px2) + (py1 - py2) * (py1 - py2));
            
            return distanciaMinima;
        }

        //Getters
        public string GetId()
        {
            return id;
        }
        public Position GetPosition()
        {
            return currentPosition;
        }

        public double GetSpeed()
        {
            return velocidad;
        }

        public Position GetInitialPosition()
        {
            return initialPosition;
        }

        public Position GetFinalPosition()
        {
            return finalPosition;
        }
        
        public string GetCompany()
        {
            return company;
        }


        public void Restart()
        {
            currentPosition = initialPosition;
        }
        
        public double Distancia(FlightPlan avio)
        {
            return this.currentPosition.Distancia(avio.currentPosition);
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

        // return a copy of the flight plan, not a reference
        public FlightPlan copy()
        {
            return new FlightPlan(this.id, this.company, this.initialPosition.GetX(), this.initialPosition.GetY(), this.finalPosition.GetX(), this.finalPosition.GetY(), this.velocidad, this.currentPosition.GetX(), this.currentPosition.GetY());
        }
    }
}
