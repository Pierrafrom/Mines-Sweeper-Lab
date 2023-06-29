namespace Minesweeper_Lab
{
    public partial class frmMain : Form
    {
        // constants
        private const int EASY_SIZE_CELL = 50;
        private const int MEDIUM_SIZE_CELL = 41;
        private const int HARD_SIZE_CELL = 33;

        private const int EASY_BOARD = 10;
        private const int MEDIUM_BOARD = 12;
        private const int HARD_BOARD = 15;

        private const int NB_BOMBS_EASY = 10;
        private const int NB_BOMBS_MEDIUM = 40;
        private const int NB_BOMBS_HARD = 99;

        private const int EASY_SIZE_BUTTON = 12;
        private const int MEDIUM_SIZE_BUTTON = 10;
        private const int HARD_SIZE_BUTTON = 8;

        private const int EASY = 0;
        private const int MEDIUM = 1;
        private const int HARD = 2;

        // variables
        private int currentBoard;
        private int nbBombs;
        private int nbActiveButtons;
        private int[,] matrixBoard;
        private Button[,] buttons;
        private Label[,] labels;
        private int difficulty;
        private int sizeCell;
        private bool state;
        private int buttonFontSize;

        public frmMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set the state to true
            state = true;
            // initialize the cbxDifficulty
            cbxDifficulty.Items.Add("Easy");
            cbxDifficulty.Items.Add("Medium");
            cbxDifficulty.Items.Add("Hard");
            cbxDifficulty.SelectedIndex = EASY;
            cbxDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            initializeNewGame();
            // set the state to false
            state = false;
        }

        private void initializeNewGame()
        {
            // get the difficulty
            difficulty = cbxDifficulty.SelectedIndex;

            if (difficulty == EASY)
            {
                currentBoard = EASY_BOARD;
                nbBombs = NB_BOMBS_EASY;
                sizeCell = EASY_SIZE_CELL;
                buttonFontSize = EASY_SIZE_BUTTON;
            }
            else if (difficulty == MEDIUM)
            {
                currentBoard = MEDIUM_BOARD;
                nbBombs = NB_BOMBS_MEDIUM;
                sizeCell = MEDIUM_SIZE_CELL;
                buttonFontSize = MEDIUM_SIZE_BUTTON;
            }
            else if (difficulty == HARD)
            {
                currentBoard = HARD_BOARD;
                nbBombs = NB_BOMBS_HARD;
                sizeCell = HARD_SIZE_CELL;
                buttonFontSize = HARD_SIZE_BUTTON;
            } 

            // initialize the board
            tlpBoard.RowCount = currentBoard;
            tlpBoard.ColumnCount = currentBoard;
            tlpBoard.Controls.Clear();
            tlpBoard.RowStyles.Clear();
            tlpBoard.ColumnStyles.Clear();
            lblNbBombs.Text = nbBombs.ToString();

            for (int i = 0; i < currentBoard; i++)
            {
                tlpBoard.RowStyles.Add(new RowStyle(SizeType.Absolute, sizeCell));
                tlpBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, sizeCell));
            }
                
            // create a panel for each cell
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    Panel pnl = new Panel
                    {
                        Dock = DockStyle.Fill
                    };

                    tlpBoard.Controls.Add(pnl, i, j);
                }
            }

            // create the buttons
            createButtons();
            tlpBoard.Update();

            // set the timer to 0
            lblSeconds.Text = "0";
            tmrSeconds.Start();
        }

        private void createButtons()
        {
            // initialize the buttons
            nbActiveButtons = currentBoard * currentBoard;
            lblButtonNumber.Text = nbActiveButtons.ToString();
            buttons = new Button[currentBoard, currentBoard];

            // we create a button for each cell
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    Button btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Tag = new Point(i, j),
                        Visible = true
                    };

                    // we add the button to the panel
                    tlpBoard.GetControlFromPosition(i, j).Controls.Add(btn);
                    btn.Click += btn_Click;
                    btn.MouseDown += btn_MouseDown;
                    buttons[i, j] = btn;
                }
            }

        }

        private void createLabels()
        {
            // initialize the labels
            labels = new Label[currentBoard, currentBoard];

            // we create a label for each cell
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    Label lbl = new Label
                    {
                        Dock = DockStyle.Fill,
                        Visible = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                    };

                    if (matrixBoard[i, j] > 0)
                    {
                        lbl.Text = matrixBoard[i, j].ToString();
                    }
                    else if (matrixBoard[i, j] == 0)
                    {
                        lbl.Text = "";
                    }
                    else
                    {
                        lbl.Text = "*";
                    }


                    if (matrixBoard[i, j] == -1)
                    {
                        lbl.ForeColor = Color.Red;
                    }
                    else if (matrixBoard[i, j] == 1)
                    {
                        lbl.ForeColor = Color.Blue;
                    }
                    else if (matrixBoard[i, j] == 2)
                    {
                        lbl.ForeColor = Color.Green;
                    }
                    else if (matrixBoard[i, j] == 3)
                    {
                        lbl.ForeColor = Color.Orange;
                    }
                    else if (matrixBoard[i, j] == 4)
                    {
                        lbl.ForeColor = Color.Purple;
                    }
                    else if (matrixBoard[i, j] == 5)
                    {
                        lbl.ForeColor = Color.Maroon;
                    }
                    else if (matrixBoard[i, j] == 6)
                    {
                        lbl.ForeColor = Color.Turquoise;
                    }
                    else if (matrixBoard[i, j] == 7)
                    {
                        lbl.ForeColor = Color.Black;
                    }
                    else if (matrixBoard[i, j] == 8)
                    {
                        lbl.ForeColor = Color.Gray;
                    }

                    // we add the label to the panel
                    tlpBoard.GetControlFromPosition(i, j).Controls.Add(lbl);
                    labels[i, j] = lbl;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // get the button position
            Button clickedButton = (Button)sender;
            Point index = (Point)clickedButton.Tag;
            int x = index.X;
            int y = index.Y;

            // Check if it is the first click, if yes, call startShow
            if (nbActiveButtons == currentBoard * currentBoard)
            {
                createMatrixBoard(x, y);
                createLabels();
                recursiveShow(x, y);
            }
            else
            {
                // if the player click a 0 button, call recursiveShow
                if (matrixBoard[x, y] == 0)
                {
                    recursiveShow(x, y);
                }
                else
                {
                    // decrement the number of active buttons
                    nbActiveButtons--;
                    lblButtonNumber.Text = nbActiveButtons.ToString();

                    // set the button invisible and the label visible
                    clickedButton.Visible = false;
                    labels[x, y].Visible = true;

                    // check if the player won
                    if (nbActiveButtons == nbBombs && allBombsFounded())
                    {
                        // ask the player if he wants to play again
                        DialogResult result = MessageBox.Show("You won ! Do you want to play again ?", "Congratulations !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            initializeNewGame();
                        }
                        else
                        {
                            // if he doesn't want to play again, we close the application
                            Application.Exit();
                        }
                    }

                    // if the button is a bomb, call endGame
                    if (matrixBoard[x, y] == -1)
                    {
                        endGame();
                    }
                }
            }

            ActiveControl = null;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = (Button)sender;
                Point index = (Point)clickedButton.Tag;
                int x = index.X;
                int y = index.Y;
                // set the size of the font of the button
                clickedButton.Font = new Font("Arial", buttonFontSize, FontStyle.Regular);
                clickedButton.ForeColor = Color.Red;
                
                if (clickedButton.Text == "")
                {
                    clickedButton.Text = "B";
                    lblNbBombs.Text = (Int32.Parse(lblNbBombs.Text) - 1).ToString();
                }
                else if (clickedButton.Text == "B")
                {
                    clickedButton.Text = "";
                    (Int32.Parse(lblNbBombs.Text) + 1).ToString();
                }
            }
        }

        private void createMatrixBoard(int x, int y)
        {
            matrixBoard = new int[currentBoard, currentBoard];
            // put a 0 in each cell to initialize the matrixBoard
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    matrixBoard[i, j] = 0;
                }
            }
            // create a 3D array to store the excluded area
            // we won't put bombs in the excluded area
            // the excluded area is the area around the first clicked cell
            int[,,] excludedArea = new int[3, 3, 2];
            for (int i = 0; i < 3; i++)
            {
                int row = x - 1 + i;
                for (int j = 0; j < 3; j++)
                {
                    int col = y - 1 + j;
                    if (row >= 0 && row < currentBoard && col >= 0 && col < currentBoard)
                    {
                        excludedArea[i, j, 0] = row;
                        excludedArea[i, j, 1] = col;
                    }
                    else
                    {
                        excludedArea[i, j, 0] = -1;
                        excludedArea[i, j, 1] = -1;
                    }
                }
            }
            // fill the matrixBoard with bombs
            // we add a -1 to the matrixBoard for each bomb
            // the other numbers are the number of bombs around the cell
            // we add 1 to the cells around the bomb
            // we exclude every cell in the excluded area for the bombs placement
            Random rnd = new Random();
            for (int i = 0; i < nbBombs; i++)
            {
                int row, col;
                do
                {
                    row = rnd.Next(0, currentBoard);
                    col = rnd.Next(0, currentBoard);
                } while (matrixBoard[row, col] == -1 || isInExcludedArea(row, col, excludedArea));

                matrixBoard[row, col] = -1;
                // we add 1 to the cells around the bomb
                for (int j = row - 1; j <= row + 1; j++)
                {
                    for (int k = col - 1; k <= col + 1; k++)
                    {
                        if (j >= 0 && j < currentBoard && k >= 0 && k < currentBoard && matrixBoard[j, k] != -1)
                        {
                            matrixBoard[j, k]++;
                        }
                    }
                }
            }
        }

        private bool isInExcludedArea(int row, int col, int[,,] excludedArea)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (excludedArea[i, j, 0] == row && excludedArea[i, j, 1] == col)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void recursiveShow(int x, int y)
        {
            // check if the button is visible
            if (!buttons[x, y].Visible)
                return;

            // set the button invisible and the label visible
            buttons[x, y].Visible = false;
            labels[x, y].Visible = true;

            // decrement the number of active buttons
            nbActiveButtons--;
            lblButtonNumber.Text = nbActiveButtons.ToString();

            // check the adjacent cells
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    // check if the cell is in the matrixBoard
                    if (i >= 0 && i < currentBoard && j >= 0 && j < currentBoard)
                    {
                        // check if the cell is visible
                        if (!buttons[i, j].Visible)
                            continue;

                        // show the cell if it's a 0
                        if (matrixBoard[i, j] == 0)
                        {
                            recursiveShow(i, j);
                        }
                        else
                        {
                            // set the button invisible and the label visible
                            buttons[i, j].Visible = false;
                            labels[i, j].Visible = true;

                            // decrement the number of active buttons
                            nbActiveButtons--;
                            lblButtonNumber.Text = nbActiveButtons.ToString();
                        }
                    }
                }
            }
        }

        private void endGame()
        {
            // show all the bombs
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    if (matrixBoard[i, j] == -1)
                    {
                        buttons[i, j].Visible = false;
                        labels[i, j].Visible = true;
                    }
                }
            }
            // inform the player that he lost and ask him if he wants to play again
            DialogResult result = MessageBox.Show("You lost ! Do you want to play again ?", "Game over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // if he wants to play again, we reset the game
                initializeNewGame();
            }
            else
            {
                // if he doesn't want to play again, we close the application
                Application.Exit();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // ask the player if he wants to play again and prevent him that he will lose his current game
            DialogResult result = MessageBox.Show("You will lose your current game. Do you want to play again ?", "New game", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // if he wants to play again, we reset the game
                tmrSeconds.Stop();
                initializeNewGame();
            }
        }

        private bool allBombsFounded()
        {
             // check if the player has found all the bombs
            for (int i = 0; i < currentBoard; i++)
            {
                for (int j = 0; j < currentBoard; j++)
                {
                    if (matrixBoard[i, j] == -1 && buttons[i, j].Text != "B")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void cbxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (state)
                return;
            // ask the player if he wants to play again and prevent him that he will lose his current game
            DialogResult result = MessageBox.Show("You will lose your current game. Do you want to play again with another difficulty ?", "Change difficulty", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // if he wants to play again, we reset the game
                initializeNewGame();
            }
            else
            {
                // if he doesn't want to play again, we reset the difficulty to the previous one
                cbxDifficulty.SelectedIndex = difficulty;
            }
        }

        private void tmrSeconds_Tick(object sender, EventArgs e)
        {
            // increment the number of seconds
            lblSeconds.Text = (int.Parse(lblSeconds.Text) + 1).ToString();
        }
    }
}
