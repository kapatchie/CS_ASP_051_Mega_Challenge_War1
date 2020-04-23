using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_Mega_Challenge_War
{
    public class Cards
    {

        public Random random = new Random();
        

        public List<String> ShuffelCards(List<String> cards) 
        {
            List<String> cardsOut = new List<string>() { };
            while (cards.Count > 26)
            {
                int i =   random.Next(0, cards.Count);
                string chosenCard = cards.ElementAt(i);
                cards.RemoveAt(i);
                cardsOut.Add(chosenCard);
            }
            return cardsOut;
        }
    }
}