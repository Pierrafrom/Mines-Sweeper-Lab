namespace Minesweeper_Lab
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpBoard = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRemainigButtons = new System.Windows.Forms.Label();
            this.lblButtonNumber = new System.Windows.Forms.Label();
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.lblBombsLabel = new System.Windows.Forms.Label();
            this.lblNbBombs = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrSeconds = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tlpBoard
            // 
            this.tlpBoard.ColumnCount = 2;
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoard.Location = new System.Drawing.Point(11, 193);
            this.tlpBoard.Name = "tlpBoard";
            this.tlpBoard.RowCount = 2;
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBoard.Size = new System.Drawing.Size(500, 500);
            this.tlpBoard.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(200, 728);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(119, 48);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(91, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 65);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Mines sweeper";
            // 
            // lblRemainigButtons
            // 
            this.lblRemainigButtons.AutoSize = true;
            this.lblRemainigButtons.Location = new System.Drawing.Point(131, 143);
            this.lblRemainigButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemainigButtons.Name = "lblRemainigButtons";
            this.lblRemainigButtons.Size = new System.Drawing.Size(177, 25);
            this.lblRemainigButtons.TabIndex = 3;
            this.lblRemainigButtons.Text = "Remainging buttons:";
            // 
            // lblButtonNumber
            // 
            this.lblButtonNumber.AutoSize = true;
            this.lblButtonNumber.Location = new System.Drawing.Point(307, 145);
            this.lblButtonNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblButtonNumber.Name = "lblButtonNumber";
            this.lblButtonNumber.Size = new System.Drawing.Size(42, 25);
            this.lblButtonNumber.TabIndex = 4;
            this.lblButtonNumber.Text = "100";
            // 
            // cbxDifficulty
            // 
            this.cbxDifficulty.FormattingEnabled = true;
            this.cbxDifficulty.Location = new System.Drawing.Point(156, 87);
            this.cbxDifficulty.Name = "cbxDifficulty";
            this.cbxDifficulty.Size = new System.Drawing.Size(182, 33);
            this.cbxDifficulty.TabIndex = 0;
            this.cbxDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbxDifficulty_SelectedIndexChanged);
            // 
            // lblBombsLabel
            // 
            this.lblBombsLabel.AutoSize = true;
            this.lblBombsLabel.Location = new System.Drawing.Point(11, 95);
            this.lblBombsLabel.Name = "lblBombsLabel";
            this.lblBombsLabel.Size = new System.Drawing.Size(78, 25);
            this.lblBombsLabel.TabIndex = 5;
            this.lblBombsLabel.Text = "bombs :";
            // 
            // lblNbBombs
            // 
            this.lblNbBombs.AutoSize = true;
            this.lblNbBombs.Location = new System.Drawing.Point(91, 95);
            this.lblNbBombs.Name = "lblNbBombs";
            this.lblNbBombs.Size = new System.Drawing.Size(32, 25);
            this.lblNbBombs.TabIndex = 6;
            this.lblNbBombs.Text = "10";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(489, 95);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(22, 25);
            this.lblSeconds.TabIndex = 7;
            this.lblSeconds.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(384, 95);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 25);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time :";
            // 
            // tmrSeconds
            // 
            this.tmrSeconds.Interval = 1000;
            this.tmrSeconds.Tick += new System.EventHandler(this.tmrSeconds_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 797);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblNbBombs);
            this.Controls.Add(this.lblBombsLabel);
            this.Controls.Add(this.cbxDifficulty);
            this.Controls.Add(this.lblButtonNumber);
            this.Controls.Add(this.lblRemainigButtons);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.tlpBoard);
            this.Name = "frmMain";
            this.Text = "Mines sweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tlpBoard;
        private Button btnNewGame;
        private Label lblTitle;
        private Label lblRemainigButtons;
        private Label lblButtonNumber;
        private ComboBox cbxDifficulty;
        private Label lblBombsLabel;
        private Label lblNbBombs;
        private Label lblSeconds;
        private Label lblTime;
        private System.Windows.Forms.Timer tmrSeconds;
    }
}