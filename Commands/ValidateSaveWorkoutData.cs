namespace WorkoutApplicationServices.Commands
{
    public class ValidateWorkoutData
    {
        private Dictionary<string, object> payload;
        public Dictionary<string, List<string>> Errors { get; private set; }

        public ValidateWorkoutData(Dictionary<string, object> payload)
        {
            this.payload = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("id", new List<string>());
            Errors.Add("exerciseType", new List<string>());
            Errors.Add("date", new List<string>());
            Errors.Add("startTimeResult", new List<string>());
            Errors.Add("endTimeResult", new List<string>());
            Errors.Add("caloriesBurnedResult", new List<string>());
            Errors.Add("caloriesGoalResult", new List<string>());
        }

        public bool MayError()
        {
            bool sagot = false;

            if (Errors["id"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["exerciseType"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["date"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["startTimeResult"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["endTimeResult"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["caloriesBurnedResult"].Count > 0)
            {
                sagot = true;
            }

            if (Errors["caloriesGoalResult"].Count > 0)
            {
                sagot = true;
            }

            return sagot;
        }


        public bool WalangError()
        {
            return !MayError();
        }

        public void Tapusin()
        {
            int id = int.Parse(payload["id"].ToString());

            if (!payload.ContainsKey("exerciseType"))
            {
                Errors["exerciseType"].Add("Enter your type of Exercise");
            }

            if (!payload.ContainsKey("date"))
            {
                Errors["date"].Add("Enter Your Exercise Date!");
            }

            if (!payload.ContainsKey("startTimeResult"))
            {
                Errors["startTimeResult"].Add("Enter Your Exercise Start Time!");
            }

            if (!payload.ContainsKey("endTimeResult"))
            {
                Errors["endTimeResult"].Add("Enter Your Exercise End Time");
            }


            if (!payload.ContainsKey("caloriesBurnedResult"))
            {
                Errors["caloriesBurnedResult"].Add("Enter Your Total Calories Burned");
            }
            else
            {
                try
                {
                    int caloriesBurnedResult = int.Parse(payload["caloriesBurnedResult"].ToString());

                    if (caloriesBurnedResult <= 0)
                    {
                        Errors["caloriesBurnedResult"].Add("Oi, wrong input ka, nag - exercise ka ba?");
                    }
                }
                catch (FormatException e)
                {
                    Errors["caloriesBurnedResult"].Add("Oi, number ilagay mo boi, halatang pagkain na naman iniisip mo");
                }
            }

            if (!payload.ContainsKey("caloriesGoalResult"))
            {
                Errors["caloriesGoalResult"].Add("Enter Your Total Calories Burned");
            }
            else
            {
                try
                {
                    int caloriesGoalResult = int.Parse(payload["caloriesGoalResult"].ToString());

                    if (caloriesGoalResult <= 0)
                    {
                        Errors["caloriesGoalResult"].Add("Oi, wrong input ka, nag - exercise ka ba?");
                    }
                }
                catch (FormatException f)
                {
                    Errors["caloriesGoalResult"].Add("Oi, number ilagay mo boi, halatang pagkain na naman iniisip mo");
                }
            }
        }
    }
}