namespace WorkoutApplicationServices.Commands
{
    public class ValidateExerciseType
    {
        private Dictionary<string,object> payload;
        public Dictionary<string, List<string>> Errors {get; private set;}

        public ValidateExerciseType(Dictionary<string, object> payload)
        {
            this.payload = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("Id", new List<string>());
            Errors.Add("ExerciseName", new List<string>());
        }

        public bool HasErrors()
        {
            bool answer = false;

            if (Errors["Id"].Count > 0)
            {
                answer = true;
            }

            if (Errors["ExerciseName"].Count > 0)
            {
                answer = true;
            }

            return answer;
        }

        public bool NoErrors()
        {
            return !HasErrors();
        }

        public void Run()
        {
            if (!payload.ContainsKey("ExerciseName"))
            {
                Errors["ExerciseName"].Add("Enter the Type of Exercise");
            }
        }
    }
}
