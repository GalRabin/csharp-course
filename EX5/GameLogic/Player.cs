﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Player
    {
        private string m_Name;
        private int m_Score;
        private bool m_IsComputer;

        public Player(string i_Name)
        {
            if (IsValidName(i_Name))
            {
                m_Name = i_Name;
            }
            else
            {
                throw new ArgumentException("Given player name is not valid, Should be not empty and at most 20 characters.");
            }
        }

        public Player()
        {
            m_Name = "Computer";
            m_IsComputer = true;
        }

        public bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public static bool IsValidName(string i_Str)
        {
            bool valid = true;

            // Check length of the given name
            if (i_Str.Length == 0 || i_Str.Length > 20)
            {
                valid = false;
            }
            else
            {
                // Check if all chars is letters
                foreach (char c in i_Str)
                {
                    if (char.IsLetter(c))
                    {
                        continue;
                    }

                    valid = false;
                    break;
                }
            }

            return valid;
        }

        public void AddScore()
        {
            m_Score++;
        }

        public void ResetScore()
        {
            m_Score = 0;
        }
    }
}