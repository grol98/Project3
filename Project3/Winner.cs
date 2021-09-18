namespace Project3
{
    class Winner
    {
        public static int CheckWinner(int playerStep, int computerStep, int maxStepsHalfed)
        {
            if (playerStep == computerStep)
                return 0;
            if (playerStep > computerStep)
            {
                if ((playerStep - computerStep) > maxStepsHalfed) return -1;
                else return 1;
            }
            else
            {
                if ((computerStep - playerStep) > maxStepsHalfed) return 1;
                else return -1;
            }
        }
    }
}
