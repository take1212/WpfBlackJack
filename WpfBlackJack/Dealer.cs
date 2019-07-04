using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfBlackJack
{
    class Dealer : PlayerBase
    {
        public Dealer(List<Card> hand, int score, bool burst) : base (hand, score, burst) { }

        public System.Windows.Controls.Image image2;


        public override void Draw(List<Card> decks, Window1 window1)
        {
            var drawcard = Util.DrawCommon(this, decks);


            // コントロール作成
            System.Windows.Controls.Image image = new System.Windows.Controls.Image
            {
                Name = "dealearhand" + Hand.Count,
                Width = 65,
                Height = 77
            };


            // 追加
            window1.dealerhands.Children.Add(image);

            


            // 表示
            if (Hand.Count == 2)
            {
                image2 = image;
                image.Source = new BitmapImage(new Uri( CommonConstants.RESOURCES_PASS + "card_back.png", UriKind.Relative));
            }
            else
            {
                image.Source = new BitmapImage(new Uri( CommonConstants.RESOURCES_PASS + "card_" + drawcard.Mark + "_" + String.Format(CommonConstants.IMAGE_NUMBER_FORMAT, drawcard.No) + ".png", UriKind.Relative));
            }
            
        }
    }
}
