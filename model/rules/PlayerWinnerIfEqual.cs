namespace BlackJack.model.rules
{
    class PlayerWinnerIfEqual : IEqualResultWinner
    {
        private const int TWENTY_ONE = 21;

        public bool IsDealerWinner(Player dealer, Player player)
        {
            int playersScore = player.CalcScore();
            int dealersScore = dealer.CalcScore();

            if (playersScore > TWENTY_ONE)
            {
                return true;
            }
            else if (dealersScore > TWENTY_ONE)
            {
                return false;
            }
            else if (dealersScore == playersScore)
            {
                return false;
            }

            return dealersScore > playersScore;
        }
    }
}