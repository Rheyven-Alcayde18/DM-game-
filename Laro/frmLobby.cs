// ============================================================
// frmLobby.cs — with built-in multi-character dialogue system
// SharpDevelop / C# WinForms compatible
// ============================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laro
{
    public partial class frmLobby : Form
    {
        // ── Cutscene state ────────────────────────────────────────
        string[] script = {
            " The school library was unusually quiet. ",
            "Only the sound of the electric fan and turning pages filled the room. ",
            "It was already past 11 PM. Most students had gone home hours ago. But one student remained."
        };
        int sceneIndex = 0;
        int charIndex  = 0;
        Timer timer    = new Timer();

        // ── Dialogue state ────────────────────────────────────────
        private List<DialogueLine>        _lines      = new List<DialogueLine>();
        private int                        _lineIndex  = -1;
        private int                        _dCharIndex = 0;
        private bool                       _isTyping   = false;
        private bool                       _dialogueDone = false;  // ← NEW
        private System.Windows.Forms.Timer _typeTimer;

        // ── Dialogue UI (built in code) ───────────────────────────
        private Panel  _pnlDialogue;
        private Panel  _pnlDivider;
        private Label  _lblSpeaker;
        private Label  _lblText;
        private Label  _lblHint;

        private const int DIALOGUE_HEIGHT = 160;
        private const int CHAR_DELAY_MS   = 30;

        // ─────────────────────────────────────────────────────────
        public frmLobby()
        {
            InitializeComponent();
			
            CharacterPic.SizeMode = PictureBoxSizeMode.Zoom;
            
            btnLobby.Visible       = false;
            DialogueBox.Visible    = false;
            CharacterName.Visible  = false;
            CharacterPic.Visible   = false;

            timer.Interval = 100;
            timer.Tick    += Timer_Tick;
            timer.Start();

            BuildDialogueUI();
            SetupDialogueTimer();
        }

        // ══════════════════════════════════════════════════════════
        //  DIALOGUE SYSTEM
        // ══════════════════════════════════════════════════════════

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
            _lblSpeaker.Font      = new Font("Arial", 9f, FontStyle.Bold);
            _lblSpeaker.ForeColor = Color.FromArgb(180, 210, 255);
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

            _lblHint               = new Label();
            _lblHint.AutoSize      = false;
            _lblHint.Size          = new Size(200, 20);
            _lblHint.Location      = new Point(formW - 220, DIALOGUE_HEIGHT - 26);
            _lblHint.Font          = new Font("Arial", 8f, FontStyle.Regular);
            _lblHint.ForeColor     = Color.FromArgb(140, 160, 180);
            _lblHint.BackColor     = Color.Transparent;
            _lblHint.TextAlign     = ContentAlignment.MiddleRight;
            _lblHint.Anchor        = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblHint.Click        += DialogueClick;
            _pnlDialogue.Controls.Add(_lblHint);
        }

        private void PnlDialogue_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.FromArgb(40, 70, 100), 1))
                e.Graphics.DrawLine(p, 0, 0, _pnlDialogue.Width, 0);
        }

        private void SetupDialogueTimer()
        {
            _typeTimer          = new System.Windows.Forms.Timer();
            _typeTimer.Interval = CHAR_DELAY_MS;
            _typeTimer.Tick    += TypeTimer_Tick;
        }

        private void StartDialogue(List<DialogueLine> lines)
        {
            if (_dialogueDone) return;  // ← GUARD: won't start if already played

            _lines     = lines;
            _lineIndex = -1;
            _pnlDialogue.Visible = true;
            _pnlDialogue.BringToFront();
            AdvanceLine();
            CharacterPic.Visible  = true;
        }

        private void AdvanceLine()
        {
            _lineIndex++;
            if (_lineIndex >= _lines.Count)
            {
                EndDialogue();
                return;
            }
            _dCharIndex      = 0;
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
            if (_dCharIndex < full.Length)
            {
                _lblText.Text += full[_dCharIndex];
                _dCharIndex++;
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
            _dialogueDone        = true;  // ← LOCK: prevents replay

            btnLobby.Visible = true;
            CharacterPic.Visible  = false;
        }

        private void DialogueClick(object sender, EventArgs e)
        {
            if (!_pnlDialogue.Visible) return;
            if (_isTyping)
                FinishLine();
            else
                AdvanceLine();
        }

        // ══════════════════════════════════════════════════════════
        //  ✏️  EDIT YOUR DIALOGUE LINES HERE
        //  Format: new DialogueLine("Speaker Name", "What they say")
        //  Add or remove lines freely — the system handles the rest.
        // ══════════════════════════════════════════════════════════
        // ══════════════════════════════════════════════════════════
        //  CUTSCENE SYSTEM
        // ══════════════════════════════════════════════════════════

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (sceneIndex < script.Length)
            {
                if (charIndex < script[sceneIndex].Length)
                {
                    Cutscene.AppendText(script[sceneIndex][charIndex].ToString());
                    charIndex++;
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        void FrmLobbyClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                Cutscene.Clear();
                Cutscene.Text = script[sceneIndex];
                charIndex     = script[sceneIndex].Length;
            }
            else
            {
                if (sceneIndex < script.Length - 1)
                {
                    sceneIndex++;
                    charIndex = 0;
                    Cutscene.Clear();
                    timer.Start();
                }
                else
                {
                    Cutscene.Hide();
                    DialogueBox.Visible   = false;
                    CharacterName.Visible = false;

                    StartDialogue(DialogueScript.LobbyDialogue());
                }
            }
        }

        // ══════════════════════════════════════════════════════════
        //  OTHER EXISTING HANDLERS
        // ══════════════════════════════════════════════════════════

        private void frmLobby_Load(object sender, EventArgs e) { }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            Form Form3 = new frmLibrary();
            Form3.Show();
            this.Close();
        }
        void CharacterNameClick(object sender, EventArgs e) { }
    }
}