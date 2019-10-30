using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            // Note to self: American rules, player, dealer, player, dealer but hidden.
    
            a_dealer.Hit(a_player);
            a_dealer.Hit(a_dealer);
            a_dealer.Hit(a_player);
            a_dealer.HiddenHit(a_dealer);

            return true;
        }
    }
}
