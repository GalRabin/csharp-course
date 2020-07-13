using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace GameUI
{
    partial class FormGame
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
            this.labelCurrentPlayer = new System.Windows.Forms.Label();
            this.tableLayoutPanelBoard = new System.Windows.Forms.TableLayoutPanel();
            this.labelFirstScore = new System.Windows.Forms.Label();
            this.labelSecondScore = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // tableLayoutPanelBoard
            // 
            this.tableLayoutPanelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelBoard.Location = new System.Drawing.Point(26, 12);
            this.tableLayoutPanelBoard.Name = "tableLayoutPanelBoard";
            this.tableLayoutPanelBoard.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanelBoard.Size = new System.Drawing.Size(1007, 573);
            this.tableLayoutPanelBoard.TabIndex = 3;
            //
            // labelCurrentPlayer
            // 
            this.labelCurrentPlayer.AutoSize = true;
            this.labelCurrentPlayer.Location = new System.Drawing.Point(40, this.tableLayoutPanelBoard.Top +
                this.tableLayoutPanelBoard.Height + 50);
            this.labelCurrentPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentPlayer.Name = "labelCurrentPlayer";
            this.labelCurrentPlayer.Size = new System.Drawing.Size(0, 17);
            this.labelCurrentPlayer.TabIndex = 0;
            // 
            // labelFirstScore
            // 
            this.labelFirstScore.AutoSize = true;
            this.labelFirstScore.Location = new System.Drawing.Point(40, this.labelCurrentPlayer.Top + 
                this.labelCurrentPlayer.Height + 10);
            this.labelFirstScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstScore.Name = "labelFirstScore";
            this.labelFirstScore.Size = new System.Drawing.Size(0, 17);
            this.labelFirstScore.TabIndex = 1;
            // 
            // labelSecondScore
            // 
            this.labelSecondScore.AutoSize = true;
            this.labelSecondScore.Location = new System.Drawing.Point(40, this.labelFirstScore.Top +
                this.labelFirstScore.Height + 10);
            this.labelSecondScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecondScore.Name = "labelSecondScore";
            this.labelSecondScore.Size = new System.Drawing.Size(0, 17);
            this.labelSecondScore.TabIndex = 2;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 737);
            this.Controls.Add(this.tableLayoutPanelBoard);
            this.Controls.Add(this.labelSecondScore);
            this.Controls.Add(this.labelFirstScore);
            this.Controls.Add(this.labelCurrentPlayer);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCurrentPlayer;
        private System.Windows.Forms.Label labelFirstScore;
        private System.Windows.Forms.Label labelSecondScore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBoard;
    }
}