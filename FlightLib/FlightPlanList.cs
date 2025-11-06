using System.Collections.Generic;

namespace FlightLib
{
    public class FlightPlanList
    {
        //Cambiado el vector de 10 por una lista dinámica.
        List<FlightPlan> vectorFP = new List<FlightPlan>();
        int numeroFlightPlans = 0;    //Ahora numeroFlightPlans es redundante, no?

        //Constructors de FlightPlanList buit.
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
    }
}