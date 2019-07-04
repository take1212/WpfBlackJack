using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBlackJack
{
    abstract class PlayerBase
    {
        public List<Card> Hand { get; set; }

        public int Score { get; set; }

        public bool Burst { get; set; }



        protected PlayerBase(List<Card> hand, int score, bool burst)
        {
            Hand = hand;
            Score = score;
            Burst = burst;
        }

        public abstract void Draw(List<Card> decks, Window1 window1);
    }
}
