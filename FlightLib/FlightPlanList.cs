using System;
using System.IO;
using System.Collections.Generic;

namespace FlightLib
{
    public class FlightPlanList
    {
        //Cambiado el vector de 10 por una lista dinamica.
        List<FlightPlan> vectorFP = new List<FlightPlan>();
        int numeroFlightPlans = 0;    //Ahora numeroFlightPlans es redundante, no?

        //Constructors de FlightPlanList buit.
        public FlightPlanList()
        {

        }
        
        public void AddFlightPlan(FlightPlan flightPlan) 
        {
            if (flightPlan != null)
            {
                vectorFP.Add(flightPlan);
                numeroFlightPlans++;
            }
        }

        public void AddFlightPlans(FlightPlanList flightPlanList)
        {
            for (int i = 0; i < flightPlanList.GetNumeroFlightPlans(); i++)
            {
                AddFlightPlan(flightPlanList.GetFlightPlan(i));
            }
        }

        public FlightPlan GetFlightPlan(int numeroFlightPlan)
        {
            if (numeroFlightPlan < 0 || numeroFlightPlan > numeroFlightPlans)
            {
                return null;
            }
            return vectorFP[numeroFlightPlan];
        }

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

        // Per portar la contabilitat del numero de FlightPlans
        public int GetNumeroFlightPlans()
        {
            return numeroFlightPlans;
        }

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
                header += string.Format("{0}.{1}", cicles, securityDistance);
                header += Environment.NewLine;
                writer.Write(header);
                
                if (simulating)
                {
                    for (int i = 0; i < numeroFlightPlans; i++)
                    {
                        FlightPlan fp = vectorFP[i];
                        string line = string.Format("{0}.{1}.{2}.{3}.{4}.{5}.{6}.{7}.{8}",
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
                else
                {
                    for (int i = 0; i < numeroFlightPlans; i++)
                    {
                        FlightPlan fp = vectorFP[i];
                        string line = string.Format("{0}.{1}.{2}.{3}.{4}.{5}.{6}",
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

        // return a copy of the flight plan list, not a reference
        public FlightPlanList copy()
        {
            // returns a copy of this FlightPlanList
            FlightPlanList copyFPL = new FlightPlanList();
            for (int i = 0; i < this.numeroFlightPlans; i++)
            {
                copyFPL.AddFlightPlan(this.vectorFP[i].copy());
            }
            
            return copyFPL;
        }
    }
}

