﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.WordMemory
{
    public partial class frmGame : Form
    {
        string consonants = "BCÇDFGĞHJKLMNPRSŞTVYZ";
        string vowels = "AEIİOÖUÜ";
        HashSet<char> letters = new HashSet<char>();
        Random r = new Random();
        //ğşıöüç
        public frmGame()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tmrPicker.Start();
            btnRefresh.Enabled = false;
            letters.Clear();
            ClearLetters();
        }
        int counter = 0;
        private void tmrPicker_Tick(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                Thread.Sleep(2000);
            }
            if (letters.Count == 8)
            {
                tmrPicker.Stop();
                btnRefresh.Enabled = true;
                return;
            }

            char letter = char.MinValue;
            if (letters.Count < 6)
            {
                //sessiz harf seç
                var countOfConsonants = consonants.Length;
                letter = consonants[r.Next(0, countOfConsonants - 1)];
                lblPicker.Text = letter.ToString();
            }
            else
            {
                //sesli harf seç
                var countOfVowels = vowels.Length;
                letter = vowels[r.Next(0, countOfVowels - 1)];
                lblPicker.Text = letter.ToString();
            }
            counter++;
            if (counter == 20)
            {
                counter = 0;
                tmrPicker.Stop();
                letters.Add(letter);
                lblPicker.Text = letter.ToString();
                SetLetters(letter);
                tmrPicker.Start();
            }
        }

        private void SetLetters(char letter)
        {
            grbLetters.Controls[letters.Count - 1].Text = letter.ToString();
        }

        private void ClearLetters()
        {
            foreach (Control label in grbLetters.Controls)
            {
                label.Text = "-";
            }
        }
    }
}
