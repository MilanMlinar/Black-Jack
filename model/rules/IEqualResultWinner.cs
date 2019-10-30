namespace BlackJack.model.rules
{
    interface IEqualResultWinner
    {
        bool IsDealerWinner(Player dealer, Player player);
    }
}