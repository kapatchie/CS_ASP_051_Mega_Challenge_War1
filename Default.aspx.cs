using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CS_ASP_051_Mega_Challenge_War
{
    public partial class Default : System.Web.UI.Page
    {
       
        protected void ButtonStart_Click(object sender, EventArgs e)
        {
            // Clearing previous Screen
            resultLable.Text = "";


            //Card Initilazation
            List<String> NewGameCards = new List<string>()
        {
            "Ace of Clubs","2 of Clubs","3 of Clubs","4 of Clubs","5 of Clubs","6 of Clubs","7 of Clubs","8 of Clubs","9 of Clubs","10 of Clubs",
            "Jack of Clubs","Queen of Clubs","King of Clubs","Ace of Diamonds","2 of Diamonds","3 of Diamonds","4 of Diamonds","5 of Diamonds","6 of Diamonds",
            "7 of Diamonds","8 of Diamonds","9 of Diamonds","10 of Diamonds","Jack of Diamonds","Queen of Diamonds","King of Diamonds","Ace of Hearts",
            "2 of Hearts","3 of Hearts","4 of Hearts","5 of Hearts","6 of Hearts","7 of Hearts","8 of Hearts","9 of Hearts","10 of Hearts","Jack of Hearts",
            "Queen of Hearts","King of Hearts","Ace of Spades","2 of Spades","3 of Spades","4 of Spades","5 of Spades","6 of Spades","7 of Spades","8 of Spades",
            "9 of Spades","10 of Spades","Jack of Spades","Queen of Spades","King of Spades",
        };
            Cards card = new Cards();


            //Draw Cards for Player 1
            List<String> Player1Cards = new List<String>();
            Player1Cards.AddRange(card.ShuffelCards(NewGameCards));

            //Remove Drawn Cards from Initial List
            for (int i = 0; i < NewGameCards.Count; i++)
            {
                for (int y = 0; y < Player1Cards.Count; y++)
                {
                    if (NewGameCards[i].Contains(Player1Cards[y]))
                    {
                        NewGameCards.RemoveAt(i);
                    }
                }
            }

            // Output  Drawn Cards to  Screen

            for (int i = 0; i < 26; i++)
            {
                DisplayToScreen(Player1Cards[i], 1);
                DisplayToScreen(NewGameCards[i], 2);
            }

            // Battle Logic
            int TurnLimt = 0;

            while (TurnLimt < 20)
            {
                string Player1DrawnCard = DrawCards(Player1Cards);
                string Player2DrawnCard = DrawCards(NewGameCards);
                int player1Score = DetermineScore(Player1DrawnCard);
                int player2Score = DetermineScore(Player2DrawnCard);

                DisplayToScreen(Player1DrawnCard, player1Score, 1);
                DisplayToScreen(Player2DrawnCard, player2Score, 2);


                //Determine Winner
                if (player1Score > player2Score)
                {
                    NewGameCards.Remove(Player2DrawnCard);
                    Player1Cards.Add(Player2DrawnCard);
                    DisplayToScreen(Player1Cards.Count, 1);
                }
                if (player2Score > player1Score)
                {
                    NewGameCards.Add(Player1DrawnCard);
                    Player1Cards.Remove(Player1DrawnCard);
                    DisplayToScreen(NewGameCards.Count, 2);
                }
                //War

                while (player1Score == player2Score)
                {
                    DisplayToScreen();
                    List<string> player1Bounties = new List<string>();
                    List<string> player2Bounties = new List<string>();

                    for (int i = 0; i < 3; i++)
                    {
                        Player1Cards.Remove(Player1DrawnCard);
                        NewGameCards.Remove(Player2DrawnCard);
                        player1Bounties.Add(Player1DrawnCard);
                        player2Bounties.Add(Player2DrawnCard);
                        Player1DrawnCard = DrawCards(Player1Cards);
                        Player2DrawnCard = DrawCards(NewGameCards);
                    }


                    DisplayToScreen(player1Bounties, 1);
                    DisplayToScreen(player2Bounties, 2);

                    player1Score = DetermineScore(Player1DrawnCard);
                    player2Score = DetermineScore(Player2DrawnCard);

                    if (player1Score > player2Score)
                    {
                        NewGameCards.RemoveRange(0, player2Bounties.Count);
                        Player1Cards.AddRange(player2Bounties);
                        Player1Cards.AddRange(player1Bounties);
                        DisplayToScreen(Player1Cards.Count, 1);
                    }
                    else if (player2Score > player1Score)
                    {
                        Player1Cards.RemoveRange(0, player1Bounties.Count);
                        NewGameCards.AddRange(player2Bounties);
                        NewGameCards.AddRange(player1Bounties);
                        DisplayToScreen(NewGameCards.Count, 2);
                    }
                    else
                        resultLable.Text += "Tie<br/>";
                }

                TurnLimt++;
            }

            //Determine Winner
            if (Player1Cards.Count > NewGameCards.Count)
            {
                DisplayToScreen(1, Player1Cards.Count, 2, NewGameCards.Count);
            }
            if (Player1Cards.Count < NewGameCards.Count)
            {
                DisplayToScreen(2, NewGameCards.Count, 1, Player1Cards.Count);
            }

        }


        // Card Values
        public int DetermineScore(String givenCard)
        {

            if (givenCard.StartsWith("Ace"))
                return 13;
            else if (givenCard.StartsWith("2"))
                return 1;
            else if (givenCard.StartsWith("3"))
                return 2;
            else if (givenCard.StartsWith("4"))
                return 3;
            else if (givenCard.StartsWith("5"))
                return 4;
            else if (givenCard.StartsWith("6"))
                return 5;
            else if (givenCard.StartsWith("7"))
                return 6;
            else if (givenCard.StartsWith("8"))
                return 7;
            else if (givenCard.StartsWith("9"))
                return 8;
            else if (givenCard.StartsWith("10"))
                return 9;
            else if (givenCard.StartsWith("Jack"))
                return 10;
            else if (givenCard.StartsWith("Queen"))
                return 11;
            else if (givenCard.StartsWith("King"))
                return 12;
            else
                return 0;



        }
        // Draw Cards
        Random random = new Random();
        public string DrawCards(List<string> playerDeck)
        {
            return playerDeck.ElementAt(random.Next(0, playerDeck.Count));
        }



        // Display To Screen 
        public void DisplayToScreen(string DrawnCard, int score, int playerTurn)
        {
            resultLable.Text += String.Format("Player {0} has Drawn : {1} Value of {2}<br/>", playerTurn, DrawnCard, score);
        }
        public void DisplayToScreen(string DrawnCard, int playerTurn)
        {
            resultLable.Text += String.Format("Playet {0} has Drawn {1}<br/>", playerTurn, DrawnCard);

        }
        public void DisplayToScreen(int CardCount, int playerTurn)
        {
            resultLable.Text += String.Format("Player {0} is the Winner Player {0} Total Cards {1} <br/><br/> ", playerTurn, CardCount);

        }
        public void DisplayToScreen(List<String> playerBounties, int playerTurn)
        {
            foreach (var String in playerBounties)
            {
                resultLable.Text += String.Format("Player {0} Bounties Are: {1}<br/>", playerTurn, String);
            }
        }
        public void DisplayToScreen(int WinningPlayer, int winningCardCount, int LosingPlayer, int losingCardCount)
        {
            resultLable.Text += String.Format("Player {0} is the winner of war Total Card Count is : {1} <br/> Player {2} Card Count is {3}",
                WinningPlayer, winningCardCount, LosingPlayer, losingCardCount);
        }
        public void DisplayToScreen()
        {
            resultLable.Text += "<h2>".PadRight(70, '#') + "</h2><br/>";
            resultLable.Text += "_".PadLeft(25, '_') + "War".PadRight(25, '_') + "<br/><br/>";
        }
    }
}
