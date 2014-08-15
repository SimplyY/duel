using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace duel
{
    public class Game
    {
        public int speakPlayer { get; set; }

        CardFactory cardFactory1;
        CardFactory cardFactory2;

        public CardManager cardManager1 { get; private set; }
        public CardManager cardManager2 { get; private set; }

        CardDuel cardDuel1;
        CardDuel cardDuel2;


        Player player1;
        Player player2;

        public Game()
        {
            InitializeGame();
        }

        public void PickACard(int playerButton)
        {

            if (playerButton == speakPlayer)
            {
                if (playerButton == 1 && cardManager1.cards.Count <= 4)
                {
                    SendACardToManager();
                }
                else if (playerButton == 2 && cardManager2.cards.Count <= 4)
                {
                    SendACardToManager();
                }
            }
        }
        public void TransformSpeakerPlayer()
        {
            if (speakPlayer != 1 && speakPlayer != 2)
            {
                speakPlayer = -1;
                GameStatus.SetStatusInfo("speakPlayerValueWrong");
            }

            if (speakPlayer == 1)
            {
                speakPlayer = 2;
            }
            else if (speakPlayer == 2)
            {
                speakPlayer = 1;
            }
        }


        private void InitializeGame()
        {
            GameStatus.SetStatusInfo("游戏已经开始");

            cardFactory1 = new CardFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt");
            cardFactory2 = new CardFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt");

            cardManager1 = new CardManager();
            cardManager2 = new CardManager();

            cardDuel1 = new CardDuel();
            cardDuel2 = new CardDuel();

            player1 = new Player();
            player2 = new Player();

            speakPlayer = 1;
        }

        private void SendACardToManager()
        {
            Card sendedCard;
            if (speakPlayer == 1)
            {
                sendedCard = cardFactory1.PopACard();
                cardManager1.PushACard(sendedCard);
            }
            else if (speakPlayer == 2)
            {
                sendedCard = cardFactory2.PopACard();
                cardManager2.PushACard(sendedCard);
            }
            else
            {
                sendedCard = new Card();
            }
        }


    }
}
