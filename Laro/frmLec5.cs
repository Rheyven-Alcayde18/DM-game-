using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;

namespace Laro
{
    public partial class frmLec5 : Form
    {
        private TransparentPanel overlayPanel;
        private Panel monitorPanel;   // the outer bezel
        private Panel screenPanel;    // the inner glowing screen
        private Label questionLabel;
        private Button[] answerButtons;
        private Button nextButton;
        private int currentQuestion = 0;

        // ── Question data ─────────────────────────────────────────────
        private string[] questionTexts = new string[]
        {
            "LSPU has 8 campuses in total.",
            "Are you lost, babygirl?",
            "X + 7 = 29.",
            "Logic is the study of correct reasoning.",
            "How can I move on when I'm still in love with you?",
            "Is there a lifetime waiting for us, in a world where I was yours?",
            "Mark and Rhenz are more than friends.",
            "Rheyven, please report the bullies to the OSAS.",
            "'1 + 1 = 3' is a proposition even though it is false."
        };

        // Each question only has True / False
        private string[][] answerChoices = new string[][]
        {
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" },
            new string[] { "Proposition", "Not Proposition" }
        };

        // 0 = True is correct, 1 = False is correct
        private int[] correctAnswers = new int[] { 0, 1, 1, 0, 1, 1, 0, 1, 0 };

        // ── Constructor ───────────────────────────────────────────────
        public frmLec5()
        {
            InitializeComponent();
        }

        // ── Existing back-button handler ──────────────────────────────
        private async void label2_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            frmMainHall exitLec5 = new frmMainHall();
            exitLec5.Show();
            this.Close();
        }

        // ── Wire this to whichever control is the "highlighted computer" ──
        //    In the Designer: select the PictureBox / Label / Panel,
        //    set its Name to e.g. picComputer, then in Events double-click Click.
        //    Or call ShowChalkboardOverlay() from any existing click handler.
        void LblComputerClick(object sender, EventArgs e)
        {
            ShowChalkboardOverlay();
        }

        // ── Overlay ───────────────────────────────────────────────────
        private void ShowChalkboardOverlay()
        {
            currentQuestion = 0;

            // ── DIM OVERLAY ───────────────────────────────────────────
            overlayPanel = new TransparentPanel(Color.FromArgb(180, 0, 0, 0));
            overlayPanel.Size = this.ClientSize;
            overlayPanel.Location = new Point(0, 0);

            // ── MONITOR BEZEL (outer dark plastic frame) ──────────────
            int mW = 660, mH = 500;
            monitorPanel = new Panel();
            monitorPanel.Size = new Size(mW, mH);
            monitorPanel.Location = new Point(
                (overlayPanel.Width  - mW) / 2,
                (overlayPanel.Height - mH) / 2);
            monitorPanel.BackColor = Color.FromArgb(28, 28, 32);   // near-black plastic
            monitorPanel.Paint += new PaintEventHandler(MonitorBezel_Paint);

            // ── SCREEN AREA (glowing blue-tinted display) ─────────────
            // Leave bezel padding: 18px sides, 40px top (for title bar), 55px bottom (for stand)
            int scrPad = 18;
            int titleBarH = 32;
            int standH = 55;
            screenPanel = new Panel();
            screenPanel.Size = new Size(mW - scrPad * 2, mH - titleBarH - scrPad - standH);
            screenPanel.Location = new Point(scrPad, titleBarH);
            screenPanel.BackColor = Color.FromArgb(10, 18, 30);    // deep navy screen
            screenPanel.Paint += new PaintEventHandler(Screen_Paint);

            // ── TITLE BAR inside bezel (above screen) ─────────────────
            Label titleBar = new Label();
            titleBar.AutoSize = false;
            titleBar.Size = new Size(mW - scrPad * 2, titleBarH - 4);
            titleBar.Location = new Point(scrPad, 4);
            titleBar.BackColor = Color.FromArgb(20, 22, 28);
            titleBar.ForeColor = Color.FromArgb(0, 200, 255);
            titleBar.Font = new Font("Consolas", 9, FontStyle.Bold);
            titleBar.Text = "  ● LOGIC LAB TERMINAL  v1.0   |   CCS Department";
            titleBar.TextAlign = ContentAlignment.MiddleLeft;

            // Traffic-light style dots on title bar
            titleBar.Paint += (s, ev) => {
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 95, 87)),  new Rectangle(mW - 80, 9, 13, 13));
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 189, 46)), new Rectangle(mW - 58, 9, 13, 13));
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(40, 200, 65)),  new Rectangle(mW - 36, 9, 13, 13));
            };

            // ── CLOSE BUTTON (red dot) ────────────────────────────────
            Button closeBtn = new Button();
            closeBtn.Size = new Size(13, 13);
            closeBtn.Location = new Point(mW - 80, 9);  // aligned with red dot
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.Click += new EventHandler(CloseBtn_Click);

            // ── QUESTION NUMBER label ─────────────────────────────────
            Label questionNumLabel = new Label();
            questionNumLabel.Name = "lblQuestionNum";
            questionNumLabel.Font = new Font("Consolas", 9, FontStyle.Regular);
            questionNumLabel.ForeColor = Color.FromArgb(0, 180, 220);
            questionNumLabel.BackColor = Color.Transparent;
            questionNumLabel.AutoSize = true;
            questionNumLabel.Location = new Point(20, 14);

            // ── PROMPT prefix (like a terminal cursor line) ────────────
            Label promptLabel = new Label();
            promptLabel.AutoSize = false;
            promptLabel.Size = new Size(580, 20);
            promptLabel.Location = new Point(20, 40);
            promptLabel.Font = new Font("Consolas", 8, FontStyle.Regular);
            promptLabel.ForeColor = Color.FromArgb(0, 180, 100);
            promptLabel.BackColor = Color.Transparent;
            promptLabel.Text = "student@logiclab:~$ quiz --subject=propositions";

            // ── QUESTION LABEL ────────────────────────────────────────
            questionLabel = new Label();
            questionLabel.Name = "lblQuestion";
            questionLabel.Font = new Font("Consolas", 13, FontStyle.Bold);
            questionLabel.ForeColor = Color.FromArgb(220, 240, 255);
            questionLabel.BackColor = Color.Transparent;
            questionLabel.AutoSize = false;
            questionLabel.Size = new Size(580, 90);
            questionLabel.Location = new Point(20, 68);

            // ── DIVIDER LINE painted on screen (via Screen_Paint) ─────
            // (drawn in Screen_Paint at y=168)

            // ── FEEDBACK LABEL ────────────────────────────────────────
            Label feedbackLabel = new Label();
            feedbackLabel.Name = "lblFeedback";
            feedbackLabel.Font = new Font("Consolas", 10, FontStyle.Italic);
            feedbackLabel.BackColor = Color.Transparent;
            feedbackLabel.AutoSize = false;
            feedbackLabel.Size = new Size(580, 26);
            feedbackLabel.Location = new Point(20, 170);
            feedbackLabel.TextAlign = ContentAlignment.MiddleCenter;
            feedbackLabel.Visible = false;

            // ── TRUE / FALSE BUTTONS ──────────────────────────────────
            answerButtons = new Button[2];
            string[] btnLabels   = new string[] { "PROPOSITION", "NOT PROPOSITION" };
            Color[]  btnBaseCol  = new Color[]
            {
                Color.FromArgb(15, 80, 50),    // green tint for TRUE
                Color.FromArgb(80, 20, 20)     // red tint for FALSE
            };
            Color[]  btnHoverCol = new Color[]
            {
                Color.FromArgb(25, 120, 70),
                Color.FromArgb(120, 35, 35)
            };
            Color[]  btnBorderCol = new Color[]
            {
                Color.FromArgb(0, 200, 100),
                Color.FromArgb(220, 60, 60)
            };

            int btnW = 270, btnH = 70, startY = 210;
            int[] xPos = new int[] { 20, 310 };

            for (int i = 0; i < 2; i++)
            {
                int idx = i; // capture for lambda
                answerButtons[i] = new Button();
                answerButtons[i].Size = new Size(btnW, btnH);
                answerButtons[i].Location = new Point(xPos[i], startY);
                answerButtons[i].FlatStyle = FlatStyle.Flat;
                answerButtons[i].ForeColor = Color.White;
                answerButtons[i].BackColor = btnBaseCol[i];
                answerButtons[i].Font = new Font("Consolas", 14, FontStyle.Bold);
                answerButtons[i].TextAlign = ContentAlignment.MiddleLeft;
                answerButtons[i].Padding = new Padding(8, 0, 0, 0);
                answerButtons[i].FlatAppearance.BorderColor = btnBorderCol[i];
                answerButtons[i].FlatAppearance.BorderSize = 2;
                answerButtons[i].FlatAppearance.MouseOverBackColor = btnHoverCol[i];
                answerButtons[i].Cursor = Cursors.Hand;
                answerButtons[i].Text = btnLabels[i];
                answerButtons[i].Tag = i;
                answerButtons[i].Click += new EventHandler(AnswerButton_Click);
            }

            // ── NEXT BUTTON ───────────────────────────────────────────
            nextButton = new Button();
            nextButton.Text = "NEXT  >";
            nextButton.Size = new Size(160, 40);
            nextButton.Location = new Point(screenPanel.Width - 180, screenPanel.Height - 55);
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.ForeColor = Color.FromArgb(0, 220, 255);
            nextButton.BackColor = Color.FromArgb(10, 50, 70);
            nextButton.Font = new Font("Consolas", 11, FontStyle.Bold);
            nextButton.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 220);
            nextButton.FlatAppearance.BorderSize = 2;
            nextButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 80, 110);
            nextButton.Cursor = Cursors.Hand;
            nextButton.Visible = false;
            nextButton.Click += new EventHandler(NextButton_Click);

            // ── ASSEMBLE: screen contents ─────────────────────────────
            screenPanel.Controls.Add(questionNumLabel);
            screenPanel.Controls.Add(promptLabel);
            screenPanel.Controls.Add(questionLabel);
            screenPanel.Controls.Add(feedbackLabel);
            foreach (Button btn in answerButtons)
                screenPanel.Controls.Add(btn);
            screenPanel.Controls.Add(nextButton);

            // ── ASSEMBLE: monitor ─────────────────────────────────────
            monitorPanel.Controls.Add(titleBar);
            monitorPanel.Controls.Add(closeBtn);
            monitorPanel.Controls.Add(screenPanel);

            // ── ASSEMBLE: overlay → form ──────────────────────────────
            overlayPanel.Controls.Add(monitorPanel);
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();

            // Disable all form controls except the overlay
            foreach (Control ctrl in this.Controls)
                if (ctrl != overlayPanel)
                    ctrl.Enabled = false;

            LoadQuestion(currentQuestion);
        }

        private void LoadQuestion(int index)
        {
            Label numLabel = screenPanel.Controls["lblQuestionNum"] as Label;
            if (numLabel != null)
                numLabel.Text = "// Question " + (index + 1).ToString()
                                + " of " + questionTexts.Length.ToString();

            questionLabel.Text = "> " + questionTexts[index];

            // Reset button colors
            Color[] baseColors = new Color[]
            {
                Color.FromArgb(15, 80, 50),
                Color.FromArgb(80, 20, 20)
            };
            for (int i = 0; i < 2; i++)
            {
                answerButtons[i].BackColor = baseColors[i];
                answerButtons[i].Enabled = true;
            }

            // Reset feedback
            Label feedback = screenPanel.Controls["lblFeedback"] as Label;
            if (feedback != null)
                feedback.Visible = false;

            nextButton.Visible = false;
            nextButton.Text = (index == questionTexts.Length - 1) ? "FINISH  ✔" : "NEXT  >";
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            int clickedIndex = (int)clicked.Tag;
            int correct = correctAnswers[currentQuestion];

            Label feedback = screenPanel.Controls["lblFeedback"] as Label;

            if (clickedIndex == correct)
            {
                clicked.BackColor = Color.FromArgb(20, 160, 70);

                foreach (Button btn in answerButtons)
                    btn.Enabled = false;

                if (feedback != null)
                {
                    feedback.Text = "✓  Correct!";
                    feedback.ForeColor = Color.FromArgb(80, 220, 130);
                    feedback.Visible = true;
                }

                nextButton.Visible = true;
            }
            else
            {
                clicked.BackColor = Color.FromArgb(160, 30, 30);

                answerButtons[correct].BackColor = Color.FromArgb(20, 160, 70);

                foreach (Button btn in answerButtons)
                    btn.Enabled = false;

                if (feedback != null)
                {
                    feedback.Text = "✗  Incorrect!";
                    feedback.ForeColor = Color.FromArgb(230, 100, 100);
                    feedback.Visible = true;
                }

                nextButton.Visible = true;
            }
        }

        public void NextButton_Click(object sender, EventArgs e)
        {
            currentQuestion++;

            if (currentQuestion >= questionTexts.Length)
            {
                MessageBox.Show("You've completed all questions! A room has been unlocked!", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideChalkboardOverlay();
                GameState.UnlockRoom("Lec2"); // adjust room name as needed
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

        private void MonitorBezel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Panel p = sender as Panel;

            // Outer rounded bezel
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                p.ClientRectangle,
                Color.FromArgb(50, 52, 60),
                Color.FromArgb(22, 22, 28),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                g.FillRoundedRect(brush, 0, 0, p.Width, p.Height, 12);

            // Bright edge highlight (top)
            using (var pen = new Pen(Color.FromArgb(80, 80, 95), 1))
                g.DrawLine(pen, 12, 1, p.Width - 12, 1);

            // Monitor stand / base at the bottom
            int standW = 180, standH = 16, neckH = 20, neckW = 40;
            int baseY = p.Height - standH;
            int centerX = p.Width / 2;

            // Neck
            using (var b = new SolidBrush(Color.FromArgb(40, 42, 50)))
                g.FillRectangle(b, centerX - neckW / 2, p.Height - standH - neckH, neckW, neckH);

            // Base
            using (var b = new SolidBrush(Color.FromArgb(35, 37, 45)))
                g.FillRectangle(b, centerX - standW / 2, baseY, standW, standH);

            using (var pen = new Pen(Color.FromArgb(60, 62, 75), 1))
                g.DrawRectangle(pen, centerX - standW / 2, baseY, standW, standH);

            // Power LED dot
            using (var b = new SolidBrush(Color.FromArgb(0, 220, 130)))
                g.FillEllipse(b, centerX - 4, baseY + 5, 8, 8);
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Panel p = sender as Panel;

            // Screen background gradient (deep dark blue)
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                p.ClientRectangle,
                Color.FromArgb(8, 15, 28),
                Color.FromArgb(14, 22, 38),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                g.FillRectangle(brush, p.ClientRectangle);

            // Subtle scan-line effect
            using (var scanPen = new Pen(Color.FromArgb(8, 255, 255, 255), 1))
                for (int y = 0; y < p.Height; y += 4)
                    g.DrawLine(scanPen, 0, y, p.Width, y);

            // Glow border inside screen
            using (var pen = new Pen(Color.FromArgb(0, 160, 220), 2))
                g.DrawRectangle(pen, 1, 1, p.Width - 3, p.Height - 3);

            // Divider line below question area
            using (var pen = new Pen(Color.FromArgb(0, 100, 160), 1))
                g.DrawLine(pen, 20, 165, p.Width - 20, 165);

            // Corner brackets — top-left
            using (var pen = new Pen(Color.FromArgb(0, 200, 255), 2))
            {
                g.DrawLine(pen, 10, 10, 30, 10);
                g.DrawLine(pen, 10, 10, 10, 30);
                // top-right
                g.DrawLine(pen, p.Width - 30, 10, p.Width - 10, 10);
                g.DrawLine(pen, p.Width - 10, 10, p.Width - 10, 30);
                // bottom-left
                g.DrawLine(pen, 10, p.Height - 10, 30, p.Height - 10);
                g.DrawLine(pen, 10, p.Height - 30, 10, p.Height - 10);
                // bottom-right
                g.DrawLine(pen, p.Width - 30, p.Height - 10, p.Width - 10, p.Height - 10);
                g.DrawLine(pen, p.Width - 10, p.Height - 30, p.Width - 10, p.Height - 10);
            }
        }

        private void HideChalkboardOverlay()
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = true;

            this.Controls.Remove(overlayPanel);
            overlayPanel.Dispose(); // disposes monitorPanel and screenPanel (children)
            overlayPanel = null;
            monitorPanel = null;
            screenPanel  = null;
        }
		void LblMonitorClick(object sender, EventArgs e)
		{
			ShowChalkboardOverlay();		}
    }

    // ── Graphics extension for rounded rectangle ──────────────────────────────
    internal static class GraphicsEx
    {
        public static void FillRoundedRect(this Graphics g, Brush brush,
            int x, int y, int w, int h, int r)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x,                 y,                 r * 2, r * 2, 180, 90);
            path.AddArc(x + w - r * 2,     y,                 r * 2, r * 2, 270, 90);
            path.AddArc(x + w - r * 2,     y + h - r * 2,     r * 2, r * 2,   0, 90);
            path.AddArc(x,                 y + h - r * 2,     r * 2, r * 2,  90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }
    }
    
    // Custom panel that supports real alpha-blended background painting
    public class TransparentPanel : Panel
    {
        private Color _dimColor;

        public TransparentPanel(Color dimColor)
        {
            _dimColor = dimColor;
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do NOT call base — we handle all painting ourselves
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(_dimColor))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Required so child controls (chalkboard) paint correctly on top
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
    }
}