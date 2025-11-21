using System;
using System.IO;
using System.Collections.Generic;

namespace FlightLib
{
    public class FlightPlanList
    {
        //Canviat el vector de 10 per una llista dinàmica
        List<FlightPlan> vectorFP = new List<FlightPlan>();
        int numeroFlightPlans = 0;    //Ahora numeroFlightPlans es redundante, no?

        //Constructors de FlightPlanList buit.
        public FlightPlanList()
        {

        }

        // Afegeix un FlightPlan a la llista, sempre que no sigui null
        public void AddFlightPlan(FlightPlan flightPlan) 
        {
            if (flightPlan != null)
            {
                vectorFP.Add(flightPlan);
                numeroFlightPlans++;
            }
        }

        // Recorre tots els FlightPlans d’una altra llista i els afegeix un per un
        public void AddFlightPlans(FlightPlanList flightPlanList)
        {
            for (int i = 0; i < flightPlanList.GetNumeroFlightPlans(); i++)
            {
                AddFlightPlan(flightPlanList.GetFlightPlan(i));
            }
        }

        // Retorna el FlightPlan a la posició indicada, o null si el número és incorrecte
        public FlightPlan GetFlightPlan(int numeroFlightPlan)
        {
            if (numeroFlightPlan < 0 || numeroFlightPlan > numeroFlightPlans)
            {
                return null;
            }
            return vectorFP[numeroFlightPlan];
        }

        // Mou tots els FlightPlans que encara no han arribat al final
        public void Moure(int tempsCicle)
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                if (!vectorFP[i].EstaAlFinal())
                {
                    vectorFP[i].Moure(tempsCicle);
                }
            }
        }

        // Escriu per consola els FlightPlans que encara estan en moviment.
        public void EscriureConsola()
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                if (!vectorFP[i].EstaAlFinal())
                {
                    vectorFP[i].EscribeConsola();
                }
            }
        }
        // Reinicia totes les posicions actuals dels avions a les seves posicions inicials
        public void RestartAll()
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                vectorFP[i].Restart();
            }
        }

        // Per portar la contabilitat del número de FlightPlans
        public int GetNumeroFlightPlans()
        {
            return numeroFlightPlans;
        }

        // Guarda l'estat actual de la llista de FlightPlans en un fitxer
        public void SaveToFile(string filePath, int cicles, double securityDistance, bool simulating = false, int currentCicle = 0)
        {
            StreamWriter writer = new StreamWriter(filePath);

            try
            {
                string header;
                header = simulating.ToString();
                header += Environment.NewLine;

                if (simulating)
                {
                    header += currentCicle.ToString();
                    header += Environment.NewLine;
                }
                header += string.Format("{0},{1}", cicles, securityDistance);
                header += Environment.NewLine;
                writer.Write(header);

                // Si la simulació està en marxa, escriu totes les dades
                if (simulating)
                {
                    for (int i = 0; i < numeroFlightPlans; i++)
                    {
                        FlightPlan fp = vectorFP[i];
                        string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                            fp.GetId(),
                            fp.GetCompany(),
                            fp.GetInitialPosition().GetX(),
                            fp.GetInitialPosition().GetY(),
                            fp.GetPosition().GetX(),
                            fp.GetPosition().GetY(),
                            fp.GetFinalPosition().GetX(),
                            fp.GetFinalPosition().GetY(),
                            fp.GetSpeed());
                        writer.WriteLine(line);
                    }
                }

                // Si la simulació no està en marxa, escriu només les dades inicials
                else
                {
                    for (int i = 0; i < numeroFlightPlans; i++)
                    {
                        FlightPlan fp = vectorFP[i];
                        string line = string.Format("{0},{1},{2},{3},{4},{5},{6}",
                            fp.GetId(),
                            fp.GetCompany(),
                            fp.GetPosition().GetX(),
                            fp.GetPosition().GetY(),
                            fp.GetFinalPosition().GetX(),
                            fp.GetFinalPosition().GetY(),
                            fp.GetSpeed());
                        writer.WriteLine(line);
                    }
                }

                writer.Close();
            }

            catch (Exception ex)
            {
                writer.Close();
                throw new Exception("Error al guardar el archivo: " + ex.Message);
            }
        }

        // Retorna una còpia del FlightPlanList
        public FlightPlanList copy()
        {
            FlightPlanList copyFPL = new FlightPlanList();
            for (int i = 0; i < this.numeroFlightPlans; i++)
            {
                copyFPL.AddFlightPlan(this.vectorFP[i].copy());
            }
            
            return copyFPL;
        }
    }
}

