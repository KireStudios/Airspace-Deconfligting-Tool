using System;



namespace FlightLib
{
    public class FlightPlan
    {
        // Atributs

        string id; // Identificador
        string company; // Companyia
        Position initialPosition; //Posició inicial
        Position currentPosition; // Posicion actual
        Position finalPosition; // Posició final
        double velocidad;
        private double velocitatInicial;

        // Constructors
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
            this.velocitatInicial = velocidad;
        }

        // Mètodes

        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public void Moure(double tiempo)
        // Mou el vol a la posició corresponent al temps rebut com a paràmetre
        {
            // Si ja és al final, no cal fer res
            if (EstaAlFinal())
            {
                return;
            }

            // Calcular la distància recorreguda en el temps donat
            double distancia = tiempo * this.velocidad / 60;

            // Calcular la distància restant fins al destí (hipotenusa)
            double hipotenusa = Math.Sqrt(
                (finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) +
                (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY())
            );

            // Si la hipotenusa és 0, ja hem arribat al destí
            if (hipotenusa == 0)
            {
                return;
            }

            // Calcular les components del moviment segons cosinus i sinus
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            // Calcular la nova posició del vol
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            // Comprovar que no ens passem del destí
            if ((x - currentPosition.GetX()) * (x - finalPosition.GetX()) > 0 ||
                (y - currentPosition.GetY()) * (y - finalPosition.GetY()) > 0)
            {
                x = finalPosition.GetX();
                y = finalPosition.GetY();
                EstaAlFinal();
            }

            currentPosition = new Position(x, y);
        }

        // Setter de la posició actual
        public void SetPosition(double x, double y)
        {
            this.currentPosition = new Position(x, y);
        }

        // Comprova si l'avió ha arribat al seu destí
        public bool EstaAlFinal()
        {
            if (currentPosition.GetX() == finalPosition.GetX() && currentPosition.GetY() == finalPosition.GetY())
            {
                Console.WriteLine("L'avio " + id + " ha arribat al seu desti");
                return true;
            }
            return false;
        }

        // Comprova si hi ha conflicte amb un altre avió
        public bool Conflicte(FlightPlan plane, double distanciaSeguretat)
        {
            double distanciaMinima = distanciaSeguretat * 2;
            
            if (this.currentPosition.Distancia(plane.currentPosition) < distanciaMinima)
            {
                Console.WriteLine("L'avio " + id + " te un conflicte amb l'avio " + plane.id + "!!!");
                return true;
            }
            return false;
        }

        // Fase 10: Calcula la distància mínima futura entre aquest avió i un altre
        public double CalcularDistanciaMinimaFutura(FlightPlan otroAvion)
        {
            // Obtenir posicions actuals
            double x1 = this.currentPosition.GetX();
            double y1 = this.currentPosition.GetY();
            double x2 = otroAvion.currentPosition.GetX();
            double y2 = otroAvion.currentPosition.GetY();

            // Obtenir posicions finals
            double fx1 = this.finalPosition.GetX();
            double fy1 = this.finalPosition.GetY();
            double fx2 = otroAvion.finalPosition.GetX();
            double fy2 = otroAvion.finalPosition.GetY();

            // Calcular distàncies fins al destí
            double dist1 = Math.Sqrt((fx1 - x1) * (fx1 - x1) + (fy1 - y1) * (fy1 - y1));
            double dist2 = Math.Sqrt((fx2 - x2) * (fx2 - x2) + (fy2 - y2) * (fy2 - y2));

            // Si algun avió ja ha arribat, utilitzar la distància actual
            if (dist1 < 0.01 || dist2 < 0.01)
            {
                return this.currentPosition.Distancia(otroAvion.currentPosition);
            }

            // Vectors de direcció normalitzats multiplicats per la velocitat
            double vx1 = (fx1 - x1) / dist1 * this.velocidad;
            double vy1 = (fy1 - y1) / dist1 * this.velocidad;
            double vx2 = (fx2 - x2) / dist2 * otroAvion.velocidad;
            double vy2 = (fy2 - y2) / dist2 * otroAvion.velocidad;

            // Calcular la velocitat relativa
            double dvx = vx1 - vx2;
            double dvy = vy1 - vy2;

            // Posició relativa
            double dx = x1 - x2;
            double dy = y1 - y2;

            // Calcular el temps fins al punt més proper t = -(dx*dvx + dy*dvy) / (dvx^2 + dvy^2)
            double velocitatRelativaQuadrat = dvx * dvx + dvy * dvy;

            if (velocitatRelativaQuadrat < 0.0001)
            {
                // Velocitats iguals o paral·leles: la distància no canvia apreciablement
                return Math.Sqrt(dx * dx + dy * dy);
            }

            double t = -(dx * dvx + dy * dvy) / velocitatRelativaQuadrat;

            // Limitar t al temps màxim de vol de cada avió
            double tempsMaxim1 = dist1 / this.velocidad;
            double tempsMaxim2 = dist2 / otroAvion.velocidad;
            double tempsMaxim = Math.Min(tempsMaxim1, tempsMaxim2);

            if (t < 0)
                t = 0;
            else if (t > tempsMaxim)
                t = tempsMaxim;

            // Calcular posicions en el temps t
            double px1 = x1 + vx1 * t;
            double py1 = y1 + vy1 * t;
            double px2 = x2 + vx2 * t;
            double py2 = y2 + vy2 * t;

            // Distància mínima
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

        // Reinicia la posició actual a la inicial
        public void Restart()
        {
            currentPosition = initialPosition;
            velocidad = velocitatInicial;
        }

        // Calcula la distància entre aquest avió i un altre
        public double Distancia(FlightPlan avio)
        {
            return this.currentPosition.Distancia(avio.currentPosition);
        }

        // Escriu en consola els dades del FlightPlan
        public void EscribeConsola()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            Console.WriteLine("******************************");
        }

        // Retorna una còpia del FlightPlanList
        public FlightPlan copy()
        {
            return new FlightPlan(this.id, this.company, this.initialPosition.GetX(), this.initialPosition.GetY(), this.finalPosition.GetX(), this.finalPosition.GetY(), this.velocidad, this.currentPosition.GetX(), this.currentPosition.GetY());
        }
    }
}
