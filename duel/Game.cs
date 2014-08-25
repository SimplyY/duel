using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace duel
{
    public class Game
    {
        public bool hasError;
        public int timesAmount;

        public int speakPlayer { get; set; }

        public int player1Life;
        public int player2Life;

        public static Card recentDuelCardAttack;
        public static Card recentDuelCardAttacked;

        public CardsFactory cardFactory1 { get; private set; }
        public CardsFactory cardFactory2 { get; private set; }

        public CardsManager cardManager1 { get; private set; }
        public CardsManager cardManager2 { get; private set; }

        public CardsDuel cardDuel1;
        public CardsDuel cardDuel2;

        //rule1: player1 get factoy1's cards.player2 get factoy2's cards.
        //rule2: the amount of cards is limited.
        public void PickACard(int playerButton)
        {

            if (playerButton == speakPlayer)
            {
                if (playerButton == 1 && cardManager1.cards.Count <= 4 && cardFactory1.cards.Count >= 1)
                {
                    SendACardToManager();
                }
                else if (playerButton == 2 && cardManager2.cards.Count <= 4 && cardFactory2.cards.Count >= 1)
                {
                    SendACardToManager();
                }
            }
        }

        public void TransformSpeakerPlayer()
        {

            if (speakPlayer == 1)
            {
                cardFactory2.enableToPickCardsAmount = 1;
                speakPlayer = 2;
            }
            else if (speakPlayer == 2)
            {
                cardFactory1.enableToPickCardsAmount = 1;
                speakPlayer = 1;
            }
        }

        public Game()
        {
            InitializeGame();
        }

        public void ShowPlayersLife()
        {
            DuelTextBoxs.ShowPlayersLife(player1Life, player2Life);
        }

        public bool IsGameOver()
        {
            if (player1Life <= 0)
            {
                GameStatus.SetErrorInfo("玩家2取得胜利");
                return true;
            }
            if (player2Life <= 0)
            {
                GameStatus.SetErrorInfo("玩家1取得胜利");
                return true;
            }
            return false;
        }

        private void InitializeGame()
        {
            GameStatus.SetStatusInfo("游戏已经开始");

            player1Life = 4000;
            player2Life = 4000;

            cardFactory1 = new CardsFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt", 1);
            cardFactory2 = new CardsFactory("C:\\Users\\yuwei\\Desktop\\编程文件\\c++&c#\\duel\\duel\\duelInfo.txt", 2);

            cardManager1 = new CardsManager(1);
            cardManager2 = new CardsManager(2);

            cardDuel1 = new CardsDuel(1);
            cardDuel2 = new CardsDuel(2);

            cardFactory1.ShowCardsAmount();
            cardFactory2.ShowCardsAmount();

            InitStart();
            speakPlayer = 1;
            timesAmount = 1;
        }

        private void InitStart()
        {
            for (int i = 0; i < 5; i++)
            {
                Card sendedCard;
                sendedCard = cardFactory1.PopACard();
                cardManager1.PushACard(sendedCard);

                sendedCard = cardFactory2.PopACard();
                cardManager2.PushACard(sendedCard);
            }
            cardFactory1.enableToPickCardsAmount = 0;
            cardFactory2.enableToPickCardsAmount = 0;
        }

        private void SendACardToManager()
        {
            Card sendedCard;
            if (speakPlayer == 1 && cardFactory1.enableToPickCardsAmount >= 1)
            {
                sendedCard = cardFactory1.PopACard();
                cardManager1.PushACard(sendedCard);
            }
            else if (speakPlayer == 2 && cardFactory2.enableToPickCardsAmount >= 1)
            {
                sendedCard = cardFactory2.PopACard();
                cardManager2.PushACard(sendedCard);
            }
            else
            {
                sendedCard = new Card();
            }
        }

        public void SendACardToDuel(int cardIndex, int duelNumber)
        {
            Card sendedCard;
            if (speakPlayer == 1 && duelNumber == 1)
            {
                if (cardIndex <= (cardManager1.cards.Count - 1))
                {
                    sendedCard = cardManager1.SendACard(cardIndex);
                    sendedCard.status = "攻击表示";
                    cardDuel1.PushACard(sendedCard);
                }
            }
            else if (speakPlayer == 2 && duelNumber == 2)
            {
                if (cardIndex <= (cardManager2.cards.Count - 1))
                {
                    sendedCard = cardManager2.SendACard(cardIndex);
                    sendedCard.status = "攻击表示";
                    cardDuel2.PushACard(sendedCard);
                }
            }
            else
            {
                sendedCard = new Card();
            }
        }

        public void Duel()
        {
            if (speakPlayer == 1)
            {
                if (recentDuelCardAttacked.status == "攻击表示")
                {
                    int difference = Convert.ToInt32(recentDuelCardAttack.attack) - Convert.ToInt32(recentDuelCardAttacked.attack);
                    if (difference > 0)
                    {
                        player2Life -= difference;
                        cardDuel2.RemoveCard(ref recentDuelCardAttacked);
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (difference == 0)
                    {
                        cardDuel1.RemoveCard(ref recentDuelCardAttack);
                        cardDuel2.RemoveCard(ref recentDuelCardAttacked);
                    }
                    if (difference < 0)
                    {
                        player1Life += difference;
                        cardDuel1.RemoveCard(ref recentDuelCardAttack);
                    }
                }

                else if (recentDuelCardAttacked.status == "防守表示")
                {
                    int differnece = Convert.ToInt32(recentDuelCardAttack.attack) - Convert.ToInt32(recentDuelCardAttacked.defend);
                    if (differnece > 0)
                    {
                        cardDuel2.RemoveCard(ref recentDuelCardAttacked);
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (differnece == 0)
                    {
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (differnece < 0)
                    {
                        cardDuel1.RemoveCard(ref recentDuelCardAttack);
                    }
                }
            }
            else if (speakPlayer == 2)
            {
                if (recentDuelCardAttacked.status == "攻击表示")
                {
                    int difference = Convert.ToInt32(recentDuelCardAttack.attack) - Convert.ToInt32(recentDuelCardAttacked.attack);
                    if (difference > 0)
                    {
                        player1Life -= difference;
                        cardDuel1.RemoveCard(ref recentDuelCardAttacked);
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (difference == 0)
                    {
                        cardDuel1.RemoveCard(ref recentDuelCardAttacked);
                        cardDuel2.RemoveCard(ref recentDuelCardAttack);
                    }
                    if (difference < 0)
                    {
                        player2Life += difference;
                        cardDuel2.RemoveCard(ref recentDuelCardAttack);
                    }
                }

                else if (recentDuelCardAttacked.status == "防守表示")
                {
                    int differnece = Convert.ToInt32(recentDuelCardAttack.attack) - Convert.ToInt32(recentDuelCardAttacked.defend);
                    if (differnece > 0)
                    {
                        cardDuel1.RemoveCard(ref recentDuelCardAttacked);
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (differnece == 0)
                    {
                        recentDuelCardAttack.hasAttacked = true;
                    }
                    if (differnece < 0)
                    {
                        cardDuel2.RemoveCard(ref recentDuelCardAttack);
                    }
                }
            }
        }

    }
}
