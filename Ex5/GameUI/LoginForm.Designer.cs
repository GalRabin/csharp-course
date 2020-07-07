﻿namespace GameUI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.TextBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonBoardSize = new System.Windows.Forms.Button();
            this.ButtonAgainst = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second Player Name:";
            // 
            // TextBoxFirstPlayerName
            // 
            this.TextBoxFirstPlayerName.Location = new System.Drawing.Point(130, 6);
            this.TextBoxFirstPlayerName.Name = "TextBoxFirstPlayerName";
            this.TextBoxFirstPlayerName.Size = new System.Drawing.Size(106, 20);
            this.TextBoxFirstPlayerName.TabIndex = 1;
            // 
            // TextBoxSecondPlayerName
            // 
            this.TextBoxSecondPlayerName.Location = new System.Drawing.Point(130, 32);
            this.TextBoxSecondPlayerName.Name = "TextBoxSecondPlayerName";
            this.TextBoxSecondPlayerName.ReadOnly = true;
            this.TextBoxSecondPlayerName.Size = new System.Drawing.Size(106, 20);
            this.TextBoxSecondPlayerName.TabIndex = 3;
            this.TextBoxSecondPlayerName.Text = "- Computer -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board Size:";
            // 
            // ButtonBoardSize
            // 
            this.ButtonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ButtonBoardSize.FlatAppearance.BorderSize = 2;
            this.ButtonBoardSize.Location = new System.Drawing.Point(17, 77);
            this.ButtonBoardSize.Name = "ButtonBoardSize";
            this.ButtonBoardSize.Size = new System.Drawing.Size(105, 70);
            this.ButtonBoardSize.TabIndex = 6;
            this.ButtonBoardSize.Text = "4x4";
            this.ButtonBoardSize.UseVisualStyleBackColor = false;
            this.ButtonBoardSize.Click += new System.EventHandler(this.ButtonBoardSize_Click);
            // 
            // ButtonAgainst
            // 
            this.ButtonAgainst.Location = new System.Drawing.Point(242, 30);
            this.ButtonAgainst.Name = "ButtonAgainst";
            this.ButtonAgainst.Size = new System.Drawing.Size(107, 23);
            this.ButtonAgainst.TabIndex = 4;
            this.ButtonAgainst.Text = "Against a Freind";
            this.ButtonAgainst.UseVisualStyleBackColor = true;
            this.ButtonAgainst.Click += new System.EventHandler(this.ButtonAgainst_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonStart.FlatAppearance.BorderSize = 2;
            this.ButtonStart.Location = new System.Drawing.Point(258, 121);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(91, 23);
            this.ButtonStart.TabIndex = 7;
            this.ButtonStart.Text = "Start!";
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 148);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonAgainst);
            this.Controls.Add(this.ButtonBoardSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxSecondPlayerName);
            this.Controls.Add(this.TextBoxFirstPlayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxFirstPlayerName;
        private System.Windows.Forms.TextBox TextBoxSecondPlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonBoardSize;
        private System.Windows.Forms.Button ButtonAgainst;
        private System.Windows.Forms.Button ButtonStart;
    }
}