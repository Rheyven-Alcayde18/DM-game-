// ============================================================
// frmCCSFaculty.cs  –  Full replacement
// • Intro dialogue → chalkboard quiz overlay (combined + harder Qs)
// • Completion dialogue fires after all questions answered
// ============================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Laro
{
	// ── frmCCSFaculty ────────────────────────────────────────────
    public partial class frmCCSFaculty : Form
    {
        // ── Dialogue state ────────────────────────────────────────
        private List<DialogueLine>        _lines     = new List<DialogueLine>();
        private int                        _lineIndex = -1;
        private int                        _charIndex = 0;
        private bool                       _isTyping  = false;
        private System.Windows.Forms.Timer _typeTimer;

        // ── Dialogue UI ───────────────────────────────────────────
        private Panel _pnlDialogue;
        private Panel _pnlDivider;
        private Label _lblSpeaker;
        private Label _lblText;
        private Label _lblHint;

        private const int DIALOGUE_HEIGHT = 160;
        private const int CHAR_DELAY_MS   = 25;

        // Callback invoked when a dialogue sequence ends
        private Action _onDialogueEnd = null;

        // ── Chalkboard quiz state ─────────────────────────────────
        private Panel _overlayPanel;
        private Panel _chalkboardPanel;
        private Label _questionLabel;
        private Button[] _answerButtons;
        private Button _nextButton;
        private int _currentQuestion = 0;

        // ─────────────────────────────────────────────────────────
        //  QUESTION DATA  (combined from Lec4 + Lec5 + Lec2, harder)
        // ─────────────────────────────────────────────────────────
        private string[] _questionTexts = new string[]
        {
            // ── From Lec5 (Proposition or Not) – harder phrasing ──────────────────
            "\"Every student who studies hard will pass the exam.\"\nIs this a proposition?",

            "\"Did you submit your logic assignment on time?\"\nIs this a proposition?",

            "\"x² + 1 = 0 has no real solutions.\"\nIs this a proposition?",

            "\"Some prime numbers are even.\"\nIs this a proposition?",

            // ── From Lec4 (Logic symbols & definitions) – harder ──────────────────
            "Which symbolic expression correctly represents:\n\"If it is raining, then the ground is wet\" using p = raining, q = ground is wet?",

            "Given p = T and q = F, which compound proposition is TRUE?",

            "What is the truth value of ¬(p ∧ q) when p = T and q = T?",

            "Which of the following is the correct symbol for the biconditional (IF AND ONLY IF) connective?",

            "Which quantifier uses the phrase \"FOR SOME\" or \"THERE EXISTS\"?",

            // ── From Lec2 (Substitution) – combined harder variants ───────────────
            "Given p = T, q = F, r = T, s = F\n\nWhich substitution is correct for: [(p ∧ ¬q) → (r ∨ s)]",

            "Given p = T, q = F, r = T, s = F\n\nWhich substitution is correct for: [¬(p ∨ q) ↔ (¬p ∧ ¬q)]",

            "Given p = F, q = T, r = F, s = T\n\nWhich substitution is correct for: [((p → q) ∧ ¬r) ∨ s]",

            "Given p = T, q = T, r = F, s = F\n\nWhich substitution is correct for: [(p ↔ q) → (r ∨ ¬s)]",

            "Given p = T, q = F, r = T, s = T\n\nWhich substitution is correct for: [¬((p ∧ q) ∨ (¬r → s))]",

            // ── New harder mixed questions ─────────────────────────────────────────
            "Which of the following is a TAUTOLOGY (always true)?",

            "De Morgan's Law states that ¬(p ∨ q) is logically equivalent to:",

            "Which expression represents the CONTRAPOSITIVE of p → q?",

            "\"All cats are mammals\" can be symbolically written as:",

            "Given the argument: p → q, p ∴ q\nThis is an example of which rule of inference?",

            "Which of the following compound statements is a CONTRADICTION (always false)?"
        };

        private string[][] _answerChoices = new string[][]
        {
            // Q1 – Proposition?
            new string[] { "Proposition", "Not a Proposition", "A command, not a statement", "An open sentence" },
            // Q2 – Question
            new string[] { "Proposition", "Not a Proposition", "A paradox", "An axiom" },
            // Q3 – Math statement
            new string[] { "Proposition", "Not a Proposition", "An open formula", "A tautology" },
            // Q4 – "Some prime numbers are even"
            new string[] { "Proposition", "Not a Proposition", "An exclamation", "A command" },

            // Q5 – IF p THEN q symbol
            new string[] { "p → q", "p ↔ q", "p ∧ q", "¬p ∨ q" },
            // Q6 – p=T, q=F, which is true?
            new string[] { "p ∨ q", "p ∧ q", "p → q", "p ↔ q" },
            // Q7 – ¬(T ∧ T)
            new string[] { "T", "F", "Undefined", "T and F" },
            // Q8 – biconditional symbol
            new string[] { "↔", "→", "∨", "∧" },
            // Q9 – existential quantifier
            new string[] { "Existential (∃)", "Universal (∀)", "Particular (∂)", "Null (∅)" },

            // Q10 – substitution [(p ∧ ¬q) → (r ∨ s)]  p=T,q=F,r=T,s=F
            new string[] {
                "[(T ∧ ¬F) → (T ∨ F)]",   // CORRECT
                "[(T ∧ ¬T) → (T ∨ F)]",
                "[(F ∧ ¬F) → (T ∨ T)]",
                "[(T ∧ ¬F) → (F ∨ F)]"
            },
            // Q11 – [¬(p ∨ q) ↔ (¬p ∧ ¬q)]  p=T,q=F,r=T,s=F
            new string[] {
                "[¬(T ∨ F) ↔ (¬T ∧ ¬F)]",   // CORRECT
                "[¬(T ∨ T) ↔ (¬T ∧ ¬T)]",
                "[¬(F ∨ F) ↔ (¬F ∧ ¬F)]",
                "[¬(T ∧ F) ↔ (¬T ∨ ¬F)]"
            },
            // Q12 – [((p → q) ∧ ¬r) ∨ s]  p=F,q=T,r=F,s=T
            new string[] {
                "[((F → T) ∧ ¬F) ∨ T]",   // CORRECT
                "[((T → T) ∧ ¬F) ∨ F]",
                "[((F → F) ∧ ¬T) ∨ T]",
                "[((F → T) ∧ ¬T) ∨ F]"
            },
            // Q13 – [(p ↔ q) → (r ∨ ¬s)]  p=T,q=T,r=F,s=F
            new string[] {
                "[(T ↔ T) → (F ∨ ¬F)]",   // CORRECT
                "[(T ↔ F) → (F ∨ ¬T)]",
                "[(T ↔ T) → (T ∨ ¬F)]",
                "[(F ↔ T) → (F ∨ ¬F)]"
            },
            // Q14 – [¬((p ∧ q) ∨ (¬r → s))]  p=T,q=F,r=T,s=T
            new string[] {
                "[¬((T ∧ F) ∨ (¬T → T))]",   // CORRECT
                "[¬((T ∧ T) ∨ (¬F → T))]",
                "[¬((F ∧ F) ∨ (¬T → F))]",
                "[¬((T ∧ F) ∨ (¬F → T))]"
            },

            // Q15 – Tautology
            new string[] { "p ∨ ¬p", "p ∧ ¬p", "p → F", "¬p ∧ p" },
            // Q16 – De Morgan's
            new string[] { "¬p ∧ ¬q", "¬p ∨ ¬q", "p ∧ q", "p ∨ q" },
            // Q17 – Contrapositive of p → q
            new string[] { "¬q → ¬p", "q → p", "¬p → ¬q", "p → ¬q" },
            // Q18 – Universal quantifier sentence
            new string[] { "∀x (Cat(x) → Mammal(x))", "∃x (Cat(x) ∧ Mammal(x))", "∀x (Cat(x) ∧ Mammal(x))", "∃x (Cat(x) → Mammal(x))" },
            // Q19 – Modus Ponens
            new string[] { "Modus Ponens", "Modus Tollens", "Hypothetical Syllogism", "Disjunctive Syllogism" },
            // Q20 – Contradiction
            new string[] { "p ∧ ¬p", "p ∨ ¬p", "p → p", "¬p → p" }
        };

        private int[] _correctAnswers = new int[]
        {
            0, // Q1  – Proposition
            1, // Q2  – Not a Proposition (question)
            0, // Q3  – Proposition (math fact)
            0, // Q4  – Proposition
            0, // Q5  – p → q
            0, // Q6  – p ∨ q  (T∨F=T)
            1, // Q7  – ¬(T∧T)=¬T=F
            0, // Q8  – ↔
            0, // Q9  – Existential
            0, // Q10 – substitution A
            0, // Q11 – substitution A
            0, // Q12 – substitution A
            0, // Q13 – substitution A
            0, // Q14 – substitution A
            0, // Q15 – p ∨ ¬p tautology
            0, // Q16 – De Morgan ¬p ∧ ¬q
            0, // Q17 – ¬q → ¬p contrapositive
            0, // Q18 – ∀x (Cat→Mammal)
            0, // Q19 – Modus Ponens
            0  // Q20 – p ∧ ¬p contradiction
        };

        // ─────────────────────────────────────────────────────────
        //  Constructor
        // ─────────────────────────────────────────────────────────
        public frmCCSFaculty()
        {
            InitializeComponent();
            CharacterPic.SizeMode = PictureBoxSizeMode.Zoom;
            BuildDialogueUI();
            SetupTimer();
        }

        // ─────────────────────────────────────────────────────────
        //  BUILD DIALOGUE UI
        // ─────────────────────────────────────────────────────────
        private void BuildDialogueUI()
        {
            int formW = this.ClientSize.Width;
            int formH = this.ClientSize.Height;

            _pnlDialogue           = new Panel();
            _pnlDialogue.Size      = new Size(formW, DIALOGUE_HEIGHT);
            _pnlDialogue.Location  = new Point(0, formH - DIALOGUE_HEIGHT);
            _pnlDialogue.BackColor = Color.FromArgb(10, 15, 28);
            _pnlDialogue.Anchor    = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pnlDialogue.Visible   = false;
            _pnlDialogue.Cursor    = Cursors.Hand;
            _pnlDialogue.Paint    += PnlDialogue_Paint;
            _pnlDialogue.Click    += DialogueClick;
            this.Controls.Add(_pnlDialogue);
            _pnlDialogue.BringToFront();

            _pnlDivider           = new Panel();
            _pnlDivider.Size      = new Size(formW, 1);
            _pnlDivider.Location  = new Point(0, 34);
            _pnlDivider.BackColor = Color.FromArgb(50, 80, 110);
            _pnlDivider.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pnlDialogue.Controls.Add(_pnlDivider);

            _lblSpeaker           = new Label();
            _lblSpeaker.AutoSize  = false;
            _lblSpeaker.Size      = new Size(500, 28);
            _lblSpeaker.Location  = new Point(14, 6);
            _lblSpeaker.Font      = new Font("Arial", 9f, FontStyle.Regular);
            _lblSpeaker.ForeColor = Color.White;
            _lblSpeaker.BackColor = Color.Transparent;
            _lblSpeaker.Click    += DialogueClick;
            _pnlDialogue.Controls.Add(_lblSpeaker);

            _lblText           = new Label();
            _lblText.AutoSize  = false;
            _lblText.Size      = new Size(formW - 28, 100);
            _lblText.Location  = new Point(14, 40);
            _lblText.Font      = new Font("Arial", 10f, FontStyle.Regular);
            _lblText.ForeColor = Color.White;
            _lblText.BackColor = Color.Transparent;
            _lblText.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblText.Click    += DialogueClick;
            _pnlDialogue.Controls.Add(_lblText);

            _lblHint           = new Label();
            _lblHint.AutoSize  = false;
            _lblHint.Size      = new Size(200, 20);
            _lblHint.Location  = new Point(formW - 220, DIALOGUE_HEIGHT - 26);
            _lblHint.Font      = new Font("Arial", 8f, FontStyle.Regular);
            _lblHint.ForeColor = Color.FromArgb(140, 160, 180);
            _lblHint.BackColor = Color.Transparent;
            _lblHint.TextAlign = ContentAlignment.MiddleRight;
            _lblHint.Anchor    = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblHint.Text      = "";
            _lblHint.Click    += DialogueClick;
            _pnlDialogue.Controls.Add(_lblHint);
        }

        private void PnlDialogue_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(40, 70, 100), 1))
                e.Graphics.DrawLine(p, 0, 0, _pnlDialogue.Width, 0);
        }

        // ─────────────────────────────────────────────────────────
        //  TIMER
        // ─────────────────────────────────────────────────────────
        private void SetupTimer()
        {
            _typeTimer          = new System.Windows.Forms.Timer();
            _typeTimer.Interval = CHAR_DELAY_MS;
            _typeTimer.Tick    += TypeTimer_Tick;
        }

        // ─────────────────────────────────────────────────────────
        //  DIALOGUE ENGINE
        // ─────────────────────────────────────────────────────────
        private void StartDialogue(List<DialogueLine> lines, Action onEnd = null)
        {
            _lines         = lines;
            _lineIndex     = -1;
            _onDialogueEnd = onEnd;
            _pnlDialogue.Visible = true;
            _pnlDialogue.BringToFront();
            AdvanceLine();
        }

        private void AdvanceLine()
        {
            _lineIndex++;
            if (_lineIndex >= _lines.Count)
            {
                EndDialogue();
                return;
            }
            _charIndex = 0;
            _isTyping        = true;
            _lblSpeaker.Text = _lines[_lineIndex].Speaker;
            _lblText.Text    = "";
            if (_lines[_lineIndex].Portrait != "")
			{
			    CharacterPic.Image =
			        Image.FromFile(_lines[_lineIndex].Portrait);
			
			    CharacterPic.Visible = true;
			}
			else
			{
			    CharacterPic.Visible = false;
			}
            _lblHint.Text    = "click to skip...";
            _typeTimer.Start();
        }

        private void TypeTimer_Tick(object sender, EventArgs e)
        {
            string full = _lines[_lineIndex].Text;
            if (_charIndex < full.Length)
            {
                _lblText.Text += full[_charIndex];
                _charIndex++;
            }
            else
            {
                FinishLine();
            }
        }

        private void FinishLine()
        {
            _typeTimer.Stop();
            _isTyping        = false;
            _lblText.Text    = _lines[_lineIndex].Text;
            bool last        = (_lineIndex >= _lines.Count - 1);
            _lblHint.Text    = last ? "▼  click to close" : "▼  click to continue";
        }

        private void EndDialogue()
        {
            _typeTimer.Stop();
            _pnlDialogue.Visible = false;
            _isTyping            = false;
            if (_onDialogueEnd != null)
            {
                Action cb = _onDialogueEnd;
                _onDialogueEnd = null;
                cb();
            }
            else
            {
                _onDialogueEnd = null;
            }
        }

        private void DialogueClick(object sender, EventArgs e)
        {
            if (!_pnlDialogue.Visible) return;
            if (_isTyping)
                FinishLine();
            else
                AdvanceLine();
        }

        // ─────────────────────────────────────────────────────────
        //  EXISTING HANDLERS
        // ─────────────────────────────────────────────────────────
        private async void lblExit_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            frmMainHall exitFaculty = new frmMainHall();
            exitFaculty.Show();
            this.Close();
        }
        // ─────────────────────────────────────────────────────────
        //  CHALKBOARD OVERLAY
        // ─────────────────────────────────────────────────────────
        private void ShowChalkboardOverlay()
        {
            _currentQuestion = 0;
	 
            // DIM OVERLAY
            _overlayPanel          = new Panel();
            _overlayPanel.Size     = this.ClientSize;
            _overlayPanel.Location = new Point(0, 0);
            _overlayPanel.BackColor = Color.FromArgb(150, 0, 0, 0);

            // CHALKBOARD PANEL  (slightly larger to fit harder/longer questions)
            _chalkboardPanel          = new Panel();
            _chalkboardPanel.Size     = new Size(680, 530);
            _chalkboardPanel.Location = new Point(
                (this.ClientSize.Width  - 680) / 2,
                (this.ClientSize.Height - 530) / 2);
            _chalkboardPanel.BackColor = Color.FromArgb(45, 90, 60);
            _chalkboardPanel.Paint    += ChalkboardPanel_Paint;

            // CLOSE BUTTON
            Button closeBtn           = new Button();
            closeBtn.Text             = "X";
            closeBtn.Size             = new Size(35, 35);
            closeBtn.Location         = new Point(_chalkboardPanel.Width - 45, 10);
            closeBtn.FlatStyle        = FlatStyle.Flat;
            closeBtn.ForeColor        = Color.White;
            closeBtn.BackColor        = Color.Transparent;
            closeBtn.FlatAppearance.BorderColor = Color.White;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 255, 255, 255);
            closeBtn.Click           += (s, e) => HideChalkboardOverlay();

            // HEADER LABEL  (Prof. Santos badge)
            Label headerLabel         = new Label();
            headerLabel.AutoSize      = false;
            headerLabel.Size          = new Size(460, 22);
            headerLabel.Location      = new Point(30, 14);
            headerLabel.Font          = new Font("Segoe UI", 9, FontStyle.Italic);
            headerLabel.ForeColor     = Color.FromArgb(200, 255, 220);
            headerLabel.BackColor     = Color.Transparent;
            headerLabel.Text          = "Prof. Santos's Logic Evaluation  —  CCS Faculty Room";

            // QUESTION NUMBER LABEL
            Label questionNumLabel    = new Label();
            questionNumLabel.Name     = "lblQuestionNum";
            questionNumLabel.Font     = new Font("Segoe UI", 10, FontStyle.Italic);
            questionNumLabel.ForeColor = Color.FromArgb(180, 255, 255, 255);
            questionNumLabel.AutoSize = true;
            questionNumLabel.Location = new Point(30, 36);

            // QUESTION LABEL
            _questionLabel            = new Label();
            _questionLabel.Name       = "lblQuestion";
            _questionLabel.Font       = new Font("Segoe UI", 12, FontStyle.Bold);
            _questionLabel.ForeColor  = Color.WhiteSmoke;
            _questionLabel.AutoSize   = false;
            _questionLabel.Size       = new Size(620, 100);
            _questionLabel.Location   = new Point(30, 60);

            // ANSWER BUTTONS  (4)
            _answerButtons = new Button[4];
            string[] prefixes = new string[] { "A", "B", "C", "D" };
            for (int i = 0; i < 4; i++)
            {
                _answerButtons[i]          = new Button();
                _answerButtons[i].Size     = new Size(620, 58);
                _answerButtons[i].Location = new Point(30, 175 + (i * 66));
                _answerButtons[i].FlatStyle = FlatStyle.Flat;
                _answerButtons[i].ForeColor = Color.White;
                _answerButtons[i].BackColor = Color.FromArgb(55, 110, 75);
                _answerButtons[i].Font      = new Font("Consolas", 10, FontStyle.Regular);
                _answerButtons[i].TextAlign = ContentAlignment.MiddleLeft;
                _answerButtons[i].Padding   = new Padding(10, 0, 0, 0);
                _answerButtons[i].FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
                _answerButtons[i].FlatAppearance.BorderSize  = 1;
                _answerButtons[i].FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 140, 100);
                _answerButtons[i].Tag    = i;
                _answerButtons[i].Click += AnswerButton_Click;
            }

            // RESULT LABEL
            Label resultLabel      = new Label();
            resultLabel.Name       = "lblResult";
            resultLabel.Font       = new Font("Segoe UI", 11, FontStyle.Bold);
            resultLabel.AutoSize   = false;
            resultLabel.Size       = new Size(460, 28);
            resultLabel.Location   = new Point(30, 445);
            resultLabel.TextAlign  = ContentAlignment.MiddleLeft;
            resultLabel.BackColor  = Color.Transparent;
            resultLabel.Visible    = false;

            // NEXT BUTTON
            _nextButton          = new Button();
            _nextButton.Text     = "Next Question  ->";
            _nextButton.Size     = new Size(200, 42);
            _nextButton.Location = new Point(_chalkboardPanel.Width - 238,
                                             _chalkboardPanel.Height - 56);
            _nextButton.FlatStyle = FlatStyle.Flat;
            _nextButton.ForeColor = Color.White;
            _nextButton.BackColor = Color.FromArgb(30, 120, 60);
            _nextButton.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            _nextButton.FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
            _nextButton.Visible   = false;
            _nextButton.Click    += NextButton_Click;

            // ASSEMBLE
            _chalkboardPanel.Controls.Add(closeBtn);
            _chalkboardPanel.Controls.Add(headerLabel);
            _chalkboardPanel.Controls.Add(questionNumLabel);
            _chalkboardPanel.Controls.Add(_questionLabel);
            foreach (Button btn in _answerButtons)
                _chalkboardPanel.Controls.Add(btn);
            _chalkboardPanel.Controls.Add(resultLabel);
            _chalkboardPanel.Controls.Add(_nextButton);

            this.Controls.Add(_overlayPanel);
            this.Controls.Add(_chalkboardPanel);
            _overlayPanel.BringToFront();
            _chalkboardPanel.BringToFront();

            foreach (Control ctrl in this.Controls)
                if (ctrl != _overlayPanel && ctrl != _chalkboardPanel)
                    ctrl.Enabled = false;

            LoadQuestion(_currentQuestion);
        }

        private void LoadQuestion(int index)
        {
            Label numLabel = _chalkboardPanel.Controls["lblQuestionNum"] as Label;
            if (numLabel != null)
                numLabel.Text = "Question " + (index + 1) + " of " + _questionTexts.Length;

            _questionLabel.Text = _questionTexts[index];

            string[] prefixes = new string[] { "A", "B", "C", "D" };
            for (int i = 0; i < 4; i++)
            {
                _answerButtons[i].Text      = "  " + prefixes[i] + ".  " + _answerChoices[index][i];
                _answerButtons[i].BackColor = Color.FromArgb(55, 110, 75);
                _answerButtons[i].Enabled   = true;
            }

            Label result = _chalkboardPanel.Controls["lblResult"] as Label;
            if (result != null) result.Visible = false;

            _nextButton.Visible = false;
            _nextButton.Text = (index == _questionTexts.Length - 1)
                ? "Finish"
                : "Next Question  ->";
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button clicked      = sender as Button;
            int clickedIndex    = (int)clicked.Tag;
            int correct         = _correctAnswers[_currentQuestion];

            Label result = _chalkboardPanel.Controls["lblResult"] as Label;

            foreach (Button btn in _answerButtons)
                btn.Enabled = false;

            if (clickedIndex == correct)
            {
                clicked.BackColor = Color.FromArgb(50, 200, 80);
                if (result != null)
                {
                    result.Text      = "✓  Correct!";
                    result.ForeColor = Color.FromArgb(120, 255, 140);
                    result.Visible   = true;
                }
            }
            else
            {
                clicked.BackColor                  = Color.FromArgb(200, 60, 60);
                _answerButtons[correct].BackColor  = Color.FromArgb(50, 200, 80);
                if (result != null)
                {
                    result.Text      = "✗  Incorrect! The correct answer is highlighted.";
                    result.ForeColor = Color.FromArgb(255, 100, 100);
                    result.Visible   = true;
                }
            }

            _nextButton.Visible = true;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            _currentQuestion++;

            if (_currentQuestion >= _questionTexts.Length)
            {
                HideChalkboardOverlay();
                ShowCompletionDialogue();
            }
            else
            {
                LoadQuestion(_currentQuestion);
            }
        }

        private void ChalkboardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g     = e.Graphics;
            Panel    panel = sender as Panel;

            // Outer wooden frame
            using (Pen framePen = new Pen(Color.FromArgb(101, 67, 33), 14))
                g.DrawRectangle(framePen, 7, 7, panel.Width - 14, panel.Height - 14);

            // Inner frame detail
            using (Pen innerPen = new Pen(Color.FromArgb(139, 90, 43), 4))
                g.DrawRectangle(innerPen, 20, 20, panel.Width - 40, panel.Height - 40);

            // Chalk dust marks (decorative)
            using (Pen chalkPen = new Pen(Color.FromArgb(20, 255, 255, 255), 1))
            {
                Random rng = new Random(99);
                for (int i = 0; i < 20; i++)
                {
                    int x1 = rng.Next(24, panel.Width - 24);
                    int y1 = rng.Next(24, panel.Height - 24);
                    g.DrawLine(chalkPen, x1, y1,
                        x1 + rng.Next(-40, 40),
                        y1 + rng.Next(-6, 6));
                }
            }

            // Divider under header area
            using (Pen divPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                g.DrawLine(divPen, 30, 56, panel.Width - 30, 56);

            // Divider above result area
            using (Pen divPen2 = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                g.DrawLine(divPen2, 30, 440, panel.Width - 30, 440);
        }

        private void HideChalkboardOverlay()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl != _overlayPanel && ctrl != _chalkboardPanel)
                    ctrl.Enabled = true;

            if (_chalkboardPanel != null)
            {
                this.Controls.Remove(_chalkboardPanel);
                _chalkboardPanel.Dispose();
                _chalkboardPanel = null;
            }
            if (_overlayPanel != null)
            {
                this.Controls.Remove(_overlayPanel);
                _overlayPanel.Dispose();
                _overlayPanel = null;
            }
        }

        // ─────────────────────────────────────────────────────────
        //  COMPLETION DIALOGUE (fires after quiz is done)
        // ─────────────────────────────────────────────────────────
        private void ShowCompletionDialogue()
        {
            // When completion dialogue ends → unlock next room
            StartDialogue(DialogueScript.CcsFacultyDialogueEnd(), onEnd: () =>
            {
                GameState.CCSfCompleted = true; // adjust room name as needed
                MessageBox.Show("Congratulations! You finished the game!", "Game Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                
            });
        }
		async void FrmCCSFacultyLoad(object sender, EventArgs e)
		{
			lblExit.Enabled = false;
			MusicManager.BackGroundMusicPlay();
			await Task.Delay(1200);
			
			StartDialogue(DialogueScript.CcsFacultyDialogueStart(),onEnd: ShowChalkboardOverlay);
		}
    }
    // ── DialogueLine ─────────────────────────────────────────────

}