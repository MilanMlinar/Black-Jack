using System;

namespace BlackJack.view
{
    public class ViewInputs
    {
        public Actions CheckForInput()
        {
            char PlayersInput = Console.ReadKey().KeyChar;

            if (PlayersInput == 'p')
            {
                return Actions.Play;
            }
            else if (PlayersInput == 'h')
            {
                return Actions.Hit;
            }
            else if (PlayersInput == 's')
            {
                return Actions.Stand;
            }
            else if (PlayersInput == 'q')
            {
                return Actions.Quit;
            }
            else
            {
                return Actions.NoAction;
            }
        }
    }
}