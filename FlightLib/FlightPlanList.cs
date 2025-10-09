namespace FlightLib
{
    public class FlightPlanList
    {
        FlightPlan[] vector = new FlightPlan[10];
        int numeroFlightPlans = 0;
        
        public int AddFlightPlan(FlightPlan flightPlan) 
        {
            if (numeroFlightPlans == 10)
            {
                return -1;
            }
            vector[numeroFlightPlans] = flightPlan;
            numeroFlightPlans++;
            return 0;
        }

        public FlightPlan GetFlightPlan(int numeroFlightPlan)
        {
            if (numeroFlightPlan < 0 || numeroFlightPlan > numeroFlightPlans)
            {
                return null;
            }
            return vector[numeroFlightPlan];
        }

        public void Moure(int tempsCicle)
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                if (!vector[i].EstaAlFinal())
                {
                    vector[i].Moure(tempsCicle);
                }
            }
        }

        public void EscriureConsola()
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                if (!vector[i].EstaAlFinal())
                {
                    vector[i].EscribeConsola();
                }
            }
        }
        // Reinicia totes les posicions actuals dels avions a les seves posicions inicials
        public void RestartAll()
        {
            for (int i = 0; i < numeroFlightPlans; i++)
            {
                vector[i].Restart();
            }
        }

        // Per portar la contabilitat del numero de FlightPlans
        public int GetNumeroFlightPlans()
        {
            return numeroFlightPlans;
        }
    }
}