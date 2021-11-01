using System;

namespace BlackJack
{

    class Program
    {

        static void Main(string[] args)
        {


            BlackJackGame game = StartNewGame();
            Console.WriteLine("New game started");

            while (true)
            {
                Console.WriteLine("Your hand has " + game.GetMyTotalPoints()+ " points.");
                Console.WriteLine("Computer's hand has " + game.GetComputersTotalPoints() + " points.");

                // Type your username and press enter
                Console.WriteLine("Do you want to add another card to your hand? (yes or no)");

                // Create a string variable and get user input from the keyboard and store it in the variable
                string input = Console.ReadLine();
                if (input.Equals("no"))
                {
                    break;
                }
                else
                {
                    game.AddNextCardToMyHand();
                }
            }
            while (game.DoesComputerNeedAnotherCard())
            {
                Console.WriteLine("Computers hand has " + game.GetComputersTotalPoints() + " points.  Computer's hand requires another card.");
                game.AddNextCardToComputerHand();
            }

            if (game.AmITheWinner())
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You lose");
            }

        }


        public static BlackJackGame StartNewGame()
        {
            BlackJackGame game = new BlackJackGame();
            //Next card to be delt to me.
            game.AddNextCardToMyHand();

            //Next card to be dealt to computer
            game.AddNextCardToComputerHand();

            //Next card to be delt to me.
            game.AddNextCardToMyHand();

            //Next card to be dealt to computer
            game.AddNextCardToComputerHand();

            return game;
        }

    }


    class BlackJackGame
    {
        //index for the next card to be dealt from the deck of cards.
        private int nextCardIndex;

        //Dealer's cards will consist of 2+ ints each game.
        private int[] computerCards;
        //My cards will consist of 2+ ints each game
        private int[] myCards;

        //Array of ints to represent a deck of cards (52 cards)
        private int[] deckOfCards;

        public BlackJackGame()
        {
            //Create new deck of cards
            this.deckOfCards = CreateDeckOfCards();
            //Shuffle deck of cards by sorting int array in random order.
            ShuffleDeckOfCards();
        }
        public int GetMyTotalPoints()
        {
            return GetSumOfCards(this.myCards);
        }
        public int GetComputersTotalPoints()
        {
            return GetSumOfCards(this.computerCards);
        }
        private int[] CreateDeckOfCards()
        {
            //52 cards in a deck
            int[] cards = new int[52];

            int cardsCount = 0;

            //4 suits per deck
            for (int suit = 1; suit <= 4; suit++)
            {
                //13 cards per suit
                for (int cardValue = 1; cardValue <= 13; cardValue++)
                {

                    if (cardValue >= 11)
                    {
                        //Jack, Queen, King uses value of 10
                        cards[cardsCount++] = 10;

                    }
                    else if (cardValue == 1)
                    {
                        //Ace uses value of 11
                        cards[cardsCount++] = 11;

                    }
                    else
                    {
                        //Cards 2-10 are assigned a face value
                        cards[cardsCount++] = cardValue;

                    }
                }

            }

            return cards;
        }

        private int GetNextCardFromDeck()
        {
            return deckOfCards[nextCardIndex++];
        }

        public void AddNextCardToComputerHand()
        {
            //Dummy array to preserve original value of cards
            int[] tempCards = this.computerCards;

            //If hand has 0 cards
            if (tempCards == null)
            {
                tempCards = new int[1];
            }

            //If hand has more than 0 cards
            else
            {
                //Increase array size by one for the next card
                tempCards = new int[this.computerCards.Length + 1];

                //Populate temp cards array with original cards
                for (int i = 0; i < this.computerCards.Length; i++)
                {
                    tempCards[i] = this.computerCards[i];
                }
            }
            //Assign new card value to last index of array
            tempCards[tempCards.Length - 1] = GetNextCardFromDeck();
            //Assign hand cards to temp cards array
            this.computerCards = tempCards;
        }
        public void AddNextCardToMyHand()
        {
            //Dummy array to preserve original value of cards
            int[] tempCards = this.myCards;

            //If hand has 0 cards
            if (tempCards == null)
            {
                tempCards = new int[1];
            }

            //If hand has more than 0 cards
            else
            {
                //Increase array size by one for the next card
                tempCards = new int[this.myCards.Length + 1];

                //Populate temp cards array with original cards
                for (int i = 0; i < this.myCards.Length; i++)
                {
                    tempCards[i] = this.deckOfCards[i];
                }
            }
            //Assign new card value to last index of array
            tempCards[tempCards.Length - 1] = GetNextCardFromDeck();
            //Assign hand cards to temp cards array
            this.myCards = tempCards;
        }

        public Boolean IsComputerTheWinner()
        {
            if (IsBust(myCards))
            {
                //Computer always wins when I have to many points.
                return true;
            }
            /*
             * Computer wins if they do not have too many points 
             * and if their cards sum total is greater than or equal to my cards some total.
             */
            else if (!IsBust(computerCards) && GetSumOfCards(computerCards) >= GetSumOfCards(myCards))
            {
                return true;
            }

            //computer did not win.
            return false;
        }

        public Boolean AmITheWinner()
        {
            if (IsComputerTheWinner())
            {
                //I am not the winner when the computer wins
                return false;
            }
            else
            {
                //I am the winner when the computer does not win.
                return true;
            }
        }
        public Boolean IsBust(int[] cards)
        {
            //total sum of hand's cards. return true if hand's sum is > 21.
            if (GetSumOfCards(cards) > 21)
            {
                return true;
            }
            return false;
        }
        public Boolean DoesComputerNeedAnotherCard()
        {
            //total sum of points. return true if sum is < 16.
            //Computer always needs another card if their sum is less than 16
            if (GetSumOfCards(computerCards) < 16)
            {
                return true;
            }
            return false;
        }
        private int GetSumOfCards(int[] cards)
        {
            int total = 0;
            for (int i= 0; i < cards.Length; i++)
            {
                total = total + cards[i];
            }
            return total;
        }
        /**
        * Shuffle the given array of cards.
        * Sorts the given array of ints in random order and returns the sorted array.
        */
        private void ShuffleDeckOfCards()
        {
            Random rand = new Random();

            // For each spot in the array, picka random item to swap into that spot.
            for (int i = 0; i < this.deckOfCards.Length - 1; i++)
            {
                int j = rand.Next(i, deckOfCards.Length);
                //We need temp value to store current value at index i.
                int temp = deckOfCards[i];
                //Replace value at index i with value from index j.
                deckOfCards[i] = deckOfCards[j];
                //Replace value at index j with value that was stored at index i.
                deckOfCards[j] = temp;
            }
        }

        public int[] GetDeckOfCards()
        {
            return this.deckOfCards;
        }
    }

}
