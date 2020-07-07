using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class MatchHandler
    {
        private readonly List<Player> r_Players = new List<Player>();
        private const int k_MaxPlayers = 2;
        private int m_IndexCurrentPlayer = 0;

        public List<Player> Players
        {
            get
            {
                return r_Players;
            }
        }

        public bool IsMatchConfigured()
        {
            return r_Players.Count == k_MaxPlayers;
        }

        public void AddPlayer(string i_Name = null)
        {
            if (IsMatchConfigured())
            {
                throw new ArgumentException("Maximum number of player is configured");
            }

            if (i_Name == null)
            {
                r_Players.Add(new Player());
            }
            else
            {
                r_Players.Add(new Player(i_Name));
            }
        }

        public Player CurrentPlayer()
        {
            return r_Players[m_IndexCurrentPlayer];
        }

        public Player CurrentWinner()
        {
            Player currentWinner = null;
            int maxScore = 0;
            foreach (Player player in r_Players)
            {
                if (player.Score == maxScore)
                {
                    currentWinner = null;
                }
                else if (player.Score >= maxScore)
                {
                    currentWinner = player;
                    maxScore = player.Score;
                }
            }

            return currentWinner;
        }

        public void NextPlayer()
        {
            if (m_IndexCurrentPlayer == 1)
            {
                m_IndexCurrentPlayer = 0;
            }
            else
            {
                m_IndexCurrentPlayer = 1;
            }
        }

        public void AddScoreToCurrentPlayer()
        {
            CurrentPlayer().AddScore();
        }

        public void Clear()
        {
            foreach(Player player in Players)
            {
                player.ResetScore();
            }

            m_IndexCurrentPlayer = 0;
        }
    }
}
