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
        public bool hasError;

        public CardsFactory cardFactory1 { get; private set; }
        public CardsFactory cardFactory2 { get; private set; }

        public CardsManager cardManager1 { get; private set; }
        public CardsManager cardManager2 { get; private set; }

        CardsDuel cardDuel1;
        CardsDuel cardDuel2;

        //rule1: player1 get factoy1's cards.player2 get factoy2's cards.
        //rule2: the amount of cards is limited.
        public void PickACard(int playerButton)
        {

            if (playerButton == speakPlayer)
            {
                if (playerButton == 1 && cardManager1.cards.Count <= 4 && cardFactory1.cards.Count > 0)
                {
                    SendACardToManager();
                }
                else if (playerButton == 2 && cardManager2.cards.Count <= 4 && cardFactory2.cards.Count > 0)
                {
                    SendACardToManager();
                }
            }
        }

        public void TransformSpeakerPlayer()
        {

            if (speakPlayer == 1)
            {
                speakPlayer = 2;
            }
            else if (speakPlayer == 2)
            {
                speakPlayer = 1;
            }
        }

        public Game()
        {
            InitializeGame();
        }
        private void InitializeGame()
        {
            GameStatus.SetStatusInfo("游戏已经开始");

            cardFactory1 = new CardsFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt", 1);
            cardFactory2 = new CardsFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt", 2);

            cardManager1 = new CardsManager(1, 0);
            cardManager2 = new CardsManager(2, 15);

            cardDuel1 = new CardsDuel(1, 5);
            cardDuel2 = new CardsDuel(2, 10);

            cardFactory1.ShowCardsAmount();
            cardFactory2.ShowCardsAmount();

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
        
        private void SendACardToDuel()
        {
            Card sendedCard;
            if (speakPlayer == 1)
            {
                sendedCard = cardManager1.PopACard();
                cardDuel1.PushACard(sendedCard);
            }
            else if (speakPlayer == 2)
            {
                sendedCard = cardManager2.PopACard();
                cardDuel2.PushACard(sendedCard);
            }
            else
            {
                sendedCard = new Card();
            }
        }


    }
}
