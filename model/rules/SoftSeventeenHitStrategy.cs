using System.Collections.Generic;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int SEVENTEEN = 17;
        
        public bool DoHit(Player dealer)
        {
            int dealersScore = dealer.CalcScore();
            List<Card> list = (List<Card>)dealer.GetHand();

            if (dealersScore == SEVENTEEN)
            {
                bool aceExists = false;
                foreach (Card card in list)
                {
                    if (card.GetValue() == Card.Value.Ace)
                    {
                        aceExists = true;
                    }
                }
                return aceExists;
            }
            else
            {
                return dealersScore < SEVENTEEN;
            }
        }
    }
}
