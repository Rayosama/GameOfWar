using System;

namespace CardDeck
{
    public struct Card : IComparable<Card> //This will allow us to overload the operators
    {
        CardSuit Suit { get; set; } //This is like a variable
        CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}"; //This will print out the value of the card
        }

        public int CompareTo(Card otherCard) //This is comparing the card. If they're the same, return 0, if one is greater return 1
        {
            if(this.Value == otherCard.Value) //Doesn't compare suits, only the face value
                return 0;
            return (this.Value > otherCard.Value) ? 1 : -1;
        }

        public override bool Equals(object otherCard)
        {
            if(otherCard == null)
                return false;
            return ((Card)otherCard).Value == this.Value;
        }

        public override int GetHashCode() //returns the memory address. Added this to get rid of a warning error. This is apart of object
        {
            return base.GetHashCode();
        }

        public static bool operator >  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) == 1; //This is calling the CompareTo, stated on line 21
        }
        
        public static bool operator <  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        public static bool operator >=  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }
        
        public static bool operator <=  (Card operand1, Card operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
        
        public static bool operator ==  (Card operand1, Card operand2)
        {
            return operand1.Equals(operand2);
        }

        public static bool operator !=  (Card operand1, Card operand2)
        {
            return !operand1.Equals(operand2);
        }
    }
}