using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class GermanView : IView 
    {
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hallo Black Jack Welt");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Tippe 'p' zum Spielen, 'h' für eine neue Karte, 's', und 'q' zu Beenden\n");
        }
        public Actions GetInput()
        {
            ViewInputs inputs = new ViewInputs();
            return inputs.CheckForInput();
        }

        public void DisplayCard(model.Card a_card)
        {
            if (a_card.GetColor() == model.Card.Color.Hidden)
            {
                System.Console.WriteLine("Versteckte Karte");
            }
            else
            {
                String[] colors = new String[(int)model.Card.Color.Count]
                    { "Herzen", "Spaten", "Diamanten", "Kreuz" };
                String[] values = new String[(int)model.Card.Value.Count] 
                    { "Zwei", "Drei", "Vier", "Fünf", "Sechs", "Sieben", "Acht", "Neun", "Zehn", "Bauer", "Dame", "König", "Ass" };
                System.Console.WriteLine("{0} {1}", colors[(int)a_card.GetColor()], values[(int)a_card.GetValue()]);
            }
        }
        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spieler", a_hand, a_score);
        }
        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Kartenhändler", a_hand, a_score);
        }
        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("Das Resultat: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Der Kartenhändler hast gewonnen!");
            }
            else
            {
                System.Console.WriteLine("Du hast gewonnen!");
            }
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Hast: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Der Spielstand: {0}", a_score);
            System.Console.WriteLine("");
        }
    }
}
