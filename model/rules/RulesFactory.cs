using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new SoftSeventeenHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IEqualResultWinner GetWinnerIfEqualRule()
        {
            return new PlayerWinnerIfEqual();
        }
    }
}
