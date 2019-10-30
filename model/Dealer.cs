using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IEqualResultWinner winnerIfEqual;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            winnerIfEqual = a_rulesFactory.GetWinnerIfEqualRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                NotifySubs();

                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c = m_deck.GetCard();
                a_player.showAndAdd(c, true);

                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                this.ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    Card c = m_deck.GetCard();
                    // If it's hit add card.
                    this.showAndAdd(c, true);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDealerWinner(Player a_player)
        {
            return winnerIfEqual.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool HiddenHit(Player player)
        {
            Card c;
            c = m_deck.GetCard();
            player.showAndAdd(c, false);
            return false;
        }
    }
}
