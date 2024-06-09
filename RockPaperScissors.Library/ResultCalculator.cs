namespace RockPaperScissors.Library
{
    public class ResultCalculator
    {
        private readonly int _count;

        public ResultCalculator(int count)
        {
            _count = count;
        }

        public Result CalculateResult(int aiTurn, int userTurn)
        {
            bool isUserWin = (userTurn > aiTurn && userTurn - aiTurn <= _count / 2) || (userTurn < aiTurn && aiTurn - userTurn > _count / 2);

            return aiTurn == userTurn ? Result.Draw : isUserWin ? Result.Win : Result.Lose;
        }
    }
}