using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Position
    {
        // Atributos
        double x; // coordenada X (2D)
        double y; // coordenada Y (2D)

        // Constructores

        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        public Position suma(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }
        public Position resta(Position a, Position b)
        {
            return new Position(a.x - b.x, a.y - b.y);
        }
        public Position mult(Position a, double scalar)
        {
            return new Position(a.x * scalar, a.y * scalar);
        }
        public Position mult(double scalar, Position a)
        {
            return new Position(a.x * scalar, a.y * scalar);
        }
        public Position div(Position a, double scalar)
        {
            return new Position(a.x / scalar, a.y / scalar);
        }
        // per a la v3
        /*public static Position operator +(Position a, Position b)
        {
            return new Position(a.x + b.x, a.y + b.y);
        }
        public static Position operator -(Position a, Position b)
        {
            return new Position(a.x - b.x, a.y - b.y);
        }
        public static Position operator *(Position a, double scalar)
        {
            return new Position(a.x * scalar, a.y * scalar);
        }
        public static Position operator *(double scalar, Position a)
        {
            return a*scalar;
        }
        public static Position operator /(Position a, double scalar)
        {
            return new Position(a.x / scalar, a.y / scalar);
        }*/
        /*
        public static bool operator ==(Position a, int b)
        {
            return a.x == b && a.y == b;
        }
        public static bool operator !=(Position a, int b)
        {
            return !(a == b);
        }*/
        
        public bool igual(Position a, double b)
        {
            return a.x == b && a.y == b;
        }
        
        public double mult(Position a, Position b)
        {
            return a.x * b.x + a.y * b.y;
        }
        /*
        public static double operator *(Position a, Position b)
        {
            return a.x * b.x + a.y * b.y;
        }   */  
        public double mod()
        {
            return Math.Sqrt(x * x + y * y);
        }

        // Metodos

        public double GetX()
        // getter del atributo x
        { return x; }

        public double GetY()
        // getter del atributo y
        { return y; }
        
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }

        public double Distancia(Position b)
        // retorna la distancia entre los dos Position
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return resultado;
        }
    }
}
