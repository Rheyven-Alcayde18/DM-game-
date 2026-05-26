using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Laro
{
    public partial class frmLec4 : Form
    {
    	private Panel overlayPanel;
        private Panel chalkboardPanel;
        private Label questionLabel;
        private Button[] answerButtons;
        private Button nextButton;
        private int currentQuestion = 0;
        private int score = 0;                  // tracks correct answers
        private const int PASS_SCORE = 6;       // minimum score to unlock next room (out of 9)

        // ── Question data ─────────────────────────────────────────────
        private string[] questionTexts = new string[]
        {
            "_ is the basic building blocks of logic.",
            "_ focuses on correct reasoning and relation.",
            "This proposition uses " + @"""AND""" + "as a keyword.",
            "_ quantified statements use phrases like " +  @"""FOR SOME"""+ @""", FOR ATLEAST ONE""" + "as keywords.",
            "What symbol is used for conjunction ('AND')?",
            "What symbol represents disjunction ('OR')?",
            "What symbol is used for negation ('NOT')?",
            "What symbol represents implication ('IF…THEN')?",
            "What symbol is used for biconditional ('IF AND ONLY IF')?"
        };

        private string[][] answerChoices = new string[][]
        {
            new string[] { "Proposition", "Logic", "Statement", "Gossip" },
            new string[] { "Proposition", "Logic", "Statement", "Argument" },
            new string[] { "Disjunction", "Biconditional", "Conjunction", "Insection" },
            new string[] { "Universally", "Existentially", "Critically", "Magically" },
            new string[] { "∨", "¬", "∧", "→" },
            new string[] { "∨", "↔", "∧", "→" },
            new string[] { "→", "¬", "∃", "∀" },
            new string[] { "↔", "∨", "→", "-|==>" },
            new string[] { "↔", "→", "∧", "|" }
        };

        // Zero-based index of the correct answer for each question
        private int[] correctAnswers = new int[] { 0, 1, 2, 1, 2, 0, 1, 2, 0};

        // ── Constructor ───────────────────────────────────────────────
        public frmLec4()
        {
            InitializeComponent();
        }

        // ── Existing handlers ─────────────────────────────────────────
        private async void label2_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
            await Task.Delay(500);
            frmMainHall exitLec4 = new frmMainHall();
            exitLec4.Show();
            this.Close();
        }

        private void lblClue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hint: The topics are from Module 1 of Discrete Mathematics Lesson 1", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void LblBoardClick(object sender, EventArgs e)
        {
            ShowChalkboardOverlay();
        }

        // ── Overlay ───────────────────────────────────────────────────
        private void ShowChalkboardOverlay()
        {
            currentQuestion = 0;
            score = 0;              // reset score each time the quiz is opened

            // OVERLAY
            overlayPanel = new Panel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.BackColor = Color.FromArgb(150, 0, 0, 0);

            // CHALKBOARD PANEL
            chalkboardPanel = new Panel();
            chalkboardPanel.Size = new Size(620, 480);
            chalkboardPanel.Location = new Point(
                (this.ClientSize.Width  - 620) / 2,
                (this.ClientSize.Height - 480) / 2);
            chalkboardPanel.BackColor = Color.FromArgb(45, 90, 60);
            chalkboardPanel.Paint += new PaintEventHandler(ChalkboardPanel_Paint);

            // CLOSE BUTTON
            Button closeBtn = new Button();
            closeBtn.Text = "X";
            closeBtn.Size = new Size(35, 35);
            closeBtn.Location = new Point(chalkboardPanel.Width - 45, 10);
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.ForeColor = Color.White;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.FlatAppearance.BorderColor = Color.White;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 255, 255, 255);
            closeBtn.Click += new EventHandler(CloseBtn_Click);

            // QUESTION NUMBER LABEL
            Label questionNumLabel = new Label();
            questionNumLabel.Name = "lblQuestionNum";
            questionNumLabel.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            questionNumLabel.ForeColor = Color.FromArgb(180, 255, 255, 255);
            questionNumLabel.AutoSize = true;
            questionNumLabel.Location = new Point(30, 18);

            // SCORE LABEL
            Label scoreLbl = new Label();
            scoreLbl.Name = "lblScore";
            scoreLbl.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            scoreLbl.ForeColor = Color.FromArgb(180, 255, 255, 255);
            scoreLbl.AutoSize = true;
            scoreLbl.Location = new Point(chalkboardPanel.Width - 160, 18);

            // QUESTION LABEL
            questionLabel = new Label();
            questionLabel.Name = "lblQuestion";
            questionLabel.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            questionLabel.ForeColor = Color.WhiteSmoke;
            questionLabel.AutoSize = false;
            questionLabel.Size = new Size(560, 80);
            questionLabel.Location = new Point(30, 50);

            // ANSWER BUTTONS
            answerButtons = new Button[4];
            string[] prefixes = new string[] { "A", "B", "C", "D" };
            for (int i = 0; i < 4; i++)
            {
                answerButtons[i] = new Button();
                answerButtons[i].Size = new Size(560, 55);
                answerButtons[i].Location = new Point(30, 150 + (i * 68));
                answerButtons[i].FlatStyle = FlatStyle.Flat;
                answerButtons[i].ForeColor = Color.White;
                answerButtons[i].BackColor = Color.FromArgb(55, 110, 75);
                answerButtons[i].Font = new Font("Segoe UI", 11);
                answerButtons[i].TextAlign = ContentAlignment.MiddleLeft;
                answerButtons[i].Padding = new Padding(10, 0, 0, 0);
                answerButtons[i].FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
                answerButtons[i].FlatAppearance.BorderSize = 1;
                answerButtons[i].FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 140, 100);
                answerButtons[i].Tag = i;
                answerButtons[i].Click += new EventHandler(AnswerButton_Click);
            }

            // NEXT BUTTON
            nextButton = new Button();
            nextButton.Text = "Next Question  ->";
            nextButton.Size = new Size(200, 45);
            nextButton.Location = new Point(chalkboardPanel.Width - 240,
                                            chalkboardPanel.Height - 60);
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.ForeColor = Color.White;
            nextButton.BackColor = Color.FromArgb(30, 120, 60);
            nextButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            nextButton.FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
            nextButton.Visible = false;
            nextButton.Click += new EventHandler(NextButton_Click);

            // ASSEMBLE
            chalkboardPanel.Controls.Add(closeBtn);
            chalkboardPanel.Controls.Add(questionNumLabel);
            chalkboardPanel.Controls.Add(scoreLbl);
            chalkboardPanel.Controls.Add(questionLabel);
            foreach (Button btn in answerButtons)
                chalkboardPanel.Controls.Add(btn);
            chalkboardPanel.Controls.Add(nextButton);

            this.Controls.Add(overlayPanel);
            this.Controls.Add(chalkboardPanel);

            overlayPanel.BringToFront();
            chalkboardPanel.BringToFront();

            foreach (Control ctrl in this.Controls)
                if (ctrl != overlayPanel && ctrl != chalkboardPanel)
                    ctrl.Enabled = false;

            LoadQuestion(currentQuestion);
        }

        private void LoadQuestion(int index)
        {
            Label numLabel = chalkboardPanel.Controls["lblQuestionNum"] as Label;
            if (numLabel != null)
                numLabel.Text = "Question " + (index + 1).ToString()
                                + " of " + questionTexts.Length.ToString();

            // update score display
            Label scoreLabel = chalkboardPanel.Controls["lblScore"] as Label;
            if (scoreLabel != null)
                scoreLabel.Text = "Score: " + score + "/" + questionTexts.Length;

            questionLabel.Text = questionTexts[index];

            string[] prefixes = new string[] { "A", "B", "C", "D" };
            for (int i = 0; i < 4; i++)
            {
                answerButtons[i].Text = "  " + prefixes[i] + ".  " + answerChoices[index][i];
                answerButtons[i].BackColor = Color.FromArgb(55, 110, 75);
                answerButtons[i].Enabled = true;
            }

            nextButton.Visible = false;
            nextButton.Text = (index == questionTexts.Length - 1)
                ? "Finish"
                : "Next Question  ->";
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            int clickedIndex = (int)clicked.Tag;
            int correct = correctAnswers[currentQuestion];

            // Disable all buttons after any answer
            foreach (Button btn in answerButtons)
                btn.Enabled = false;

            if (clickedIndex == correct)
            {
                clicked.BackColor = Color.FromArgb(50, 200, 80);    // correct: green
                score++;                                              // increment score
            }
            else
            {
                clicked.BackColor = Color.FromArgb(200, 60, 60);            // wrong: red
                answerButtons[correct].BackColor = Color.FromArgb(50, 200, 80); // reveal correct answer in green
            }

            // Always show Next button regardless of right or wrong
            nextButton.Visible = true;
        }

        public void NextButton_Click(object sender, EventArgs e)
        {
            currentQuestion++;

            if (currentQuestion >= questionTexts.Length)
            {
                // Quiz finished — check if score meets the pass threshold
                if (score >= PASS_SCORE)
                {
                    MessageBox.Show(
                        "You passed with " + score + " out of " + questionTexts.Length + "!\nA room has been unlocked!",
                        "Passed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HideChalkboardOverlay();
                    GameState.UnlockRoom("Lec5");
                }
                else
                {
                    MessageBox.Show(
                        "You scored " + score + " out of " + questionTexts.Length + ".\n" +
                        "You need at least " + PASS_SCORE + " correct to unlock the next room.\nTry again!",
                        "Not Quite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HideChalkboardOverlay();
                }
            }
            else
            {
                LoadQuestion(currentQuestion);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            HideChalkboardOverlay();
        }

        private void ChalkboardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Panel panel = sender as Panel;

            using (Pen framePen = new Pen(Color.FromArgb(101, 67, 33), 12))
                g.DrawRectangle(framePen, 6, 6, panel.Width - 12, panel.Height - 12);

            using (Pen innerPen = new Pen(Color.FromArgb(139, 90, 43), 4))
                g.DrawRectangle(innerPen, 18, 18, panel.Width - 36, panel.Height - 36);

            using (Pen chalkPen = new Pen(Color.FromArgb(20, 255, 255, 255), 1))
            {
                Random rng = new Random(42);
                for (int i = 0; i < 15; i++)
                {
                    int x1 = rng.Next(20, panel.Width - 20);
                    int y1 = rng.Next(20, panel.Height - 20);
                    g.DrawLine(chalkPen, x1, y1,
                        x1 + rng.Next(-30, 30),
                        y1 + rng.Next(-5, 5));
                }
            }
        }

        private void HideChalkboardOverlay()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl != overlayPanel && ctrl != chalkboardPanel)
                    ctrl.Enabled = true;

            this.Controls.Remove(chalkboardPanel);
            this.Controls.Remove(overlayPanel);
            chalkboardPanel.Dispose();
            overlayPanel.Dispose();
        }
        
	}
}