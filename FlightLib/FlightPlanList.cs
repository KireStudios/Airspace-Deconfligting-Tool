using System;
using System.IO;
using System.Collections.Generic;

namespace FlightLib
{
    public class FlightPlanList
    {
        //Cambiado el vector de 10 por una lista dinámica.
        List<FlightPlan> vectorFP = new List<FlightPlan>();
        int numeroFlightPlans = 0;    //Ahora numeroFlightPlans es redundante, no?

        //Constructors de FlightPlanList a partir d'una llista de FlightPlans i vacío.
        public FlightPlanList(List<FlightPlan> FlightPlans)
        {
            int i = 0;
            while (i < FlightPlans.Count)
            {
                AddFlightPlan(FlightPlans[i]);
                i++;
            }
        }
        public FlightPlanList()
        {

        }
        public int AddFlightPlan(FlightPlan flightPlan)
        {
            if (flightPlan != null)
            {
                vectorFP.Add(flightPlan);
                numeroFlightPlans++;
                return 0;
            }
            else
            {
                return -1;
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

        public void SaveToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);

            try
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

                writer.Close();
            }
            catch (Exception ex)
            {
                writer.Close();
                throw new Exception("Error al guardar el archivo: " + ex.Message);
            }
        }
    }
}

