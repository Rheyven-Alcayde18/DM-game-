using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laro
{
    public partial class frmLec2 : Form
    {
        private Panel overlayPanel;
        private Panel chalkboardPanel;
        private Label questionLabel;
        private Button[] answerButtons;
        private Button nextButton;
        private int currentQuestion = 0;
        private int score = 0;              // tracks correct answers
        private const int PASS_SCORE = 7;  // minimum correct answers to unlock (out of 10)

        // ── Question data ─────────────────────────────────────────────
        private string[] questionTexts = new string[]
        {
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [(p ∧ ¬r) → (q ∧ s)]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [(¬p ∨ r) → (q ∧ s)]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [((p → r) ∧ q) ∨ ¬s]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [¬(p ∧ q) → (r ∨ s)]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [((p ∨ r) → (q → s)) ∧ ¬r]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [¬((p → q) ∧ (r ∨ s))]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [((¬p ∨ q) → (r ∧ s)) ∨ p]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [((p ∧ s) → r) → (¬q ∨ s)]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [¬((p ∨ q) → (r ∧ s))]",
            "Given:  p = T,  q = T,  r = F,  s = T\n\nConvert:  [((p ↔ q) ∧ (¬r → s)) → p]",
        };

        private string[][] answerChoices = new string[][]
        {
            // Q1: p=T,q=T,r=F,s=T  →  [(p ∧ ¬r) → (q ∧ s)]
            new string[] {
                "A. [(T ∧ ¬F) → (T ∧ T)]",   // CORRECT
                "B. [(T ∧ ¬T) → (T ∧ F)]",
                "C. [(F ∧ ¬F) → (T ∧ T)]",
                "D. [(T ∧ ¬F) → (F ∧ T)]"
            },
            // Q2: p=T,q=T,r=F,s=T  →  [(¬p ∨ r) → (q ∧ s)]
            new string[] {
                "A. [(¬T ∨ F) → (T ∧ T)]",   // CORRECT
                "B. [(¬F ∨ F) → (T ∧ T)]",
                "C. [(¬T ∨ T) → (F ∧ T)]",
                "D. [(¬T ∨ F) → (T ∧ F)]"
            },
            // Q3: p=T,q=T,r=F,s=T  →  [((p → r) ∧ q) ∨ ¬s]
            new string[] {
                "A. [((T → F) ∧ T) ∨ ¬T]",   // CORRECT
                "B. [((F → F) ∧ T) ∨ ¬T]",
                "C. [((T → T) ∧ F) ∨ ¬T]",
                "D. [((T → F) ∧ T) ∨ ¬F]"
            },
            // Q4: p=T,q=T,r=F,s=T  →  [¬(p ∧ q) → (r ∨ s)]
            new string[] {
                "A. [¬(T ∧ T) → (F ∨ T)]",   // CORRECT
                "B. [¬(F ∧ T) → (F ∨ T)]",
                "C. [¬(T ∧ F) → (T ∨ T)]",
                "D. [¬(T ∧ T) → (T ∨ F)]"
            },
            // Q5: p=T,q=T,r=F,s=T  →  [((p ∨ r) → (q → s)) ∧ ¬r]
            new string[] {
                "A. [((T ∨ F) → (T → T)) ∧ ¬F]",   // CORRECT
                "B. [((F ∨ F) → (T → T)) ∧ ¬F]",
                "C. [((T ∨ T) → (F → T)) ∧ ¬T]",
                "D. [((T ∨ F) → (T → F)) ∧ ¬F]"
            },
            // Q6: p=T,q=T,r=F,s=T  →  [¬((p → q) ∧ (r ∨ s))]
            new string[] {
                "A. [¬((T → T) ∧ (F ∨ T))]",   // CORRECT
                "B. [¬((T → F) ∧ (F ∨ T))]",
                "C. [¬((T → T) ∧ (T ∨ F))]",
                "D. [¬((F → T) ∧ (F ∨ F))]"
            },
            // Q7: p=T,q=T,r=F,s=T  →  [((¬p ∨ q) → (r ∧ s)) ∨ p]
            new string[] {
                "A. [((¬T ∨ T) → (F ∧ T)) ∨ T]",   // CORRECT
                "B. [((¬F ∨ T) → (F ∧ T)) ∨ T]",
                "C. [((¬T ∨ F) → (F ∧ T)) ∨ T]",
                "D. [((¬T ∨ T) → (T ∧ T)) ∨ F]"
            },
            // Q8: p=T,q=T,r=F,s=T  →  [((p ∧ s) → r) → (¬q ∨ s)]
            new string[] {
                "A. [((T ∧ T) → F) → (¬T ∨ T)]",   // CORRECT
                "B. [((F ∧ T) → F) → (¬T ∨ T)]",
                "C. [((T ∧ F) → F) → (¬F ∨ T)]",
                "D. [((T ∧ T) → T) → (¬T ∨ F)]"
            },
            // Q9: p=T,q=T,r=F,s=T  →  [¬((p ∨ q) → (r ∧ s))]
            new string[] {
                "A. [¬((T ∨ T) → (F ∧ T))]",   // CORRECT
                "B. [¬((F ∨ T) → (F ∧ T))]",
                "C. [¬((T ∨ F) → (T ∧ T))]",
                "D. [¬((T ∨ T) → (F ∧ F))]"
            },
            // Q10: p=T,q=T,r=F,s=T  →  [((p ↔ q) ∧ (¬r → s)) → p]
            new string[] {
                "A. [((T ↔ T) ∧ (¬F → T)) → T]",   // CORRECT
                "B. [((F ↔ T) ∧ (¬F → T)) → T]",
                "C. [((T ↔ F) ∧ (¬T → T)) → T]",
                "D. [((T ↔ T) ∧ (¬F → F)) → F]"
            },
        };

        // All answers are A (index 0)
        private int[] correctAnswers = new int[]
        {
            0, // Q1  → A
            0, // Q2  → A
            0, // Q3  → A
            0, // Q4  → A
            0, // Q5  → A
            0, // Q6  → A
            0, // Q7  → A
            0, // Q8  → A
            0, // Q9  → A
            0, // Q10 → A
        };

        private string[] explanations = new string[]
        {
            "Replace each variable: p→T, q→T, r→F, s→T. Keep ¬ attached to its variable.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬p means negate p's value.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬s negates s directly.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬(p ∧ q) wraps both p and q.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬r in the last part negates r.",
            "Replace each variable: p→T, q→T, r→F, s→T. All variables inside ¬(…) are substituted.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬p negates p; last ∨ p uses p's value.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬q negates q inside the consequent.",
            "Replace each variable: p→T, q→T, r→F, s→T. All variables inside ¬(…) are substituted.",
            "Replace each variable: p→T, q→T, r→F, s→T. ¬r negates r inside (¬r → s).",
        };

        // ── Constructor ───────────────────────────────────────────────
        public frmLec2()
        {
            InitializeComponent();
        }

        private async void lblExit_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            frmMainHall exitLec2 = new frmMainHall();
            exitLec2.Show();
            this.Close();
        }

        void lblBboard_Click(object sender, EventArgs e)
        {
            ShowChalkboardOverlay();
        }

        private void ShowChalkboardOverlay()
        {
            currentQuestion = 0;
            score = 0;              // reset score each time the quiz is opened

            overlayPanel = new Panel();
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.BackColor = Color.FromArgb(150, 0, 0, 0);

            chalkboardPanel = new Panel();
            chalkboardPanel.Size = new Size(660, 560);
            chalkboardPanel.Location = new Point(
                (this.ClientSize.Width  - 660) / 2,
                (this.ClientSize.Height - 560) / 2);
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
            questionLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            questionLabel.ForeColor = Color.WhiteSmoke;
            questionLabel.AutoSize = false;
            questionLabel.Size = new Size(600, 110);
            questionLabel.Location = new Point(30, 45);

            // INSTRUCTION LABEL
            Label instructionLabel = new Label();
            instructionLabel.Name = "lblInstruction";
            instructionLabel.Text = "Choose the correct substitution of truth values:";
            instructionLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            instructionLabel.ForeColor = Color.FromArgb(200, 255, 220);
            instructionLabel.AutoSize = false;
            instructionLabel.Size = new Size(600, 20);
            instructionLabel.Location = new Point(30, 158);

            // EXPLANATION LABEL
            Label explanationLabel = new Label();
            explanationLabel.Name = "lblExplanation";
            explanationLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            explanationLabel.ForeColor = Color.FromArgb(200, 255, 220);
            explanationLabel.AutoSize = false;
            explanationLabel.Size = new Size(600, 40);
            explanationLabel.Location = new Point(30, 500);
            explanationLabel.Visible = false;

            // A / B / C / D ANSWER BUTTONS
            answerButtons = new Button[4];
            Color baseCol = Color.FromArgb(55, 110, 75);

            for (int i = 0; i < 4; i++)
            {
                answerButtons[i] = new Button();
                answerButtons[i].Size = new Size(600, 52);
                answerButtons[i].Location = new Point(30, 185 + i * 60);
                answerButtons[i].FlatStyle = FlatStyle.Flat;
                answerButtons[i].ForeColor = Color.White;
                answerButtons[i].BackColor = baseCol;
                answerButtons[i].Font = new Font("Consolas", 10, FontStyle.Regular);
                answerButtons[i].TextAlign = ContentAlignment.MiddleLeft;
                answerButtons[i].Padding = new Padding(10, 0, 0, 0);
                answerButtons[i].FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
                answerButtons[i].FlatAppearance.BorderSize = 1;
                answerButtons[i].FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 140, 100);
                answerButtons[i].Tag = i;
                answerButtons[i].Click += new EventHandler(AnswerButton_Click);
            }

            // RESULT LABEL
            Label resultLabel = new Label();
            resultLabel.Name = "lblResult";
            resultLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            resultLabel.AutoSize = false;
            resultLabel.Size = new Size(600, 28);
            resultLabel.Location = new Point(30, 430);
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Visible = false;

            // NEXT BUTTON
            nextButton = new Button();
            nextButton.Text = "Next Question  ->";
            nextButton.Size = new Size(200, 40);
            nextButton.Location = new Point(chalkboardPanel.Width - 240,
                                            chalkboardPanel.Height - 48);
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
            chalkboardPanel.Controls.Add(instructionLabel);
            chalkboardPanel.Controls.Add(explanationLabel);
            foreach (Button btn in answerButtons)
                chalkboardPanel.Controls.Add(btn);
            chalkboardPanel.Controls.Add(resultLabel);
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
                numLabel.Text = "Question " + (index + 1) + " of " + questionTexts.Length;

            // Update live score display
            Label scoreLabel = chalkboardPanel.Controls["lblScore"] as Label;
            if (scoreLabel != null)
                scoreLabel.Text = "Score: " + score + "/" + questionTexts.Length;

            questionLabel.Text = questionTexts[index];

            for (int i = 0; i < 4; i++)
            {
                answerButtons[i].Text      = answerChoices[index][i];
                answerButtons[i].BackColor = Color.FromArgb(55, 110, 75);
                answerButtons[i].Enabled   = true;
            }

            Label expl = chalkboardPanel.Controls["lblExplanation"] as Label;
            if (expl != null) expl.Visible = false;

            Label result = chalkboardPanel.Controls["lblResult"] as Label;
            if (result != null) result.Visible = false;

            nextButton.Visible = false;
            nextButton.Text = (index == questionTexts.Length - 1)
                ? "Finish"
                : "Next Question  ->";
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button clicked   = sender as Button;
            int clickedIndex = (int)clicked.Tag;
            int correct      = correctAnswers[currentQuestion];

            Label result = chalkboardPanel.Controls["lblResult"] as Label;
            Label expl   = chalkboardPanel.Controls["lblExplanation"] as Label;

            // Disable all buttons after any answer
            foreach (Button btn in answerButtons)
                btn.Enabled = false;

            if (clickedIndex == correct)
            {
                clicked.BackColor = Color.FromArgb(50, 200, 80);
                score++;    // increment score on correct answer

                if (result != null)
                {
                    result.Text      = "✓  Correct!";
                    result.ForeColor = Color.FromArgb(120, 255, 140);
                    result.Visible   = true;
                }
            }
            else
            {
                clicked.BackColor                = Color.FromArgb(200, 60, 60);
                answerButtons[correct].BackColor = Color.FromArgb(50, 200, 80); // reveal correct answer
                if (result != null)
                {
                    result.Text      = "✗  Incorrect!";
                    result.ForeColor = Color.FromArgb(255, 100, 100);
                    result.Visible   = true;
                }
            }

            if (expl != null)
            {
                expl.Text    = "  Tip: " + explanations[currentQuestion];
                expl.Visible = true;
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
                    GameState.UnlockRoom("Lab1");
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
            Graphics g     = e.Graphics;
            Panel    panel = sender as Panel;

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
                        y1 + rng.Next(-5,  5));
                }
            }

            // Divider under question area
            using (Pen divPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                g.DrawLine(divPen, 30, 178, panel.Width - 30, 178);

            // Divider above tip area
            using (Pen divPen2 = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                g.DrawLine(divPen2, 30, 465, panel.Width - 30, 465);
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