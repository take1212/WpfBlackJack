using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBlackJack
{
    class Util
    { 

        internal static Card DrawCommon(PlayerBase player, List<Card> decks)
        {

            // カードを引く
            Random random = new Random();

            var drawcard = decks[random.Next(decks.Count)];

            // 手札に追加
            player.Hand.Add(drawcard);

            // デッキから引いた手札を削除
            decks.Remove(drawcard);

            int score = 0;

            // スコアに追加
            foreach (var hand in player.Hand)
            {
                score += hand.Point;
            }
            player.Score = score;

            // バースト判定
            if (player.Score > 21)
            {

                player.Burst = true;
                foreach (var hand in player.Hand)
                {
                    if (hand.No == 1)
                    {
                        player.Score -= 10;

                        if (player.Score <= 21)
                        {
                            player.Burst = false;
                        }
                        break;
                    }
                }
                
            }

            return drawcard;
        }
    }
}
