using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BlackJack.model;
using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame : IObserver
    {
        private Game game;
        private IView theView;
        private const int TIMER = 1500;
        public PlayGame(Game game, IView theView)
        {
            theView.DisplayWelcomeMessage();
            this.theView = theView;
            this.game = game;
            this.game.SubscribeToObservable(this);
        }
        public void update()
        {
            Thread.Sleep(TIMER);
            showWelcomeAndHands();
        }

        public void showWelcomeAndHands()
        {
            theView.DisplayWelcomeMessage();
            theView.DisplayDealerHand(game.GetDealerHand(), game.GetDealerScore());
            theView.DisplayPlayerHand(game.GetPlayerHand(), game.GetPlayerScore());
        }
        
        public bool PlayTheGame()
        {
            if (game.IsGameOver())
            {
                update();
                theView.DisplayGameOver(game.IsDealerWinner());
            }

            Actions input = theView.GetInput();

            if (input == view.Actions.Play)
            {
                game.NewGame();
            }
            else if (input == view.Actions.Quit)
            {
                return false;
            }
            else if (input == view.Actions.Hit)
            {
                game.Hit();
            }
            else if (input == view.Actions.Stand)
            {
                game.Stand();
            }
            else if (input == view.Actions.NoAction)
            {
                return true;
            }
            return true;
        }

    }
}
