using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
namespace Laro
{
    public partial class frmLab1 : Form
    {
        // ── Overlay controls ──────────────────────────────────────────────────
        private TransparentPanel overlayPanel;
        private Panel            monitorPanel;
        private Panel            screenPanel;

        // ── Puzzle state ──────────────────────────────────────────────────────
        private int currentPuzzle = 0;

        // Each puzzle:
        //   Headers   – column names
        //   Rows      – full truth table rows (P, Q, result …)
        //   Blanks    – (row, col) pairs the player must fill in
        //   FullCol   – index of the column the player must fill entirely
        //               (-1 = none; the whole column is already blank in every row)
        //
        // Convention: null in a cell means "blank – player fills it".
        // Non-null cells are shown as read-only labels.

        private struct Puzzle
        {
            public string   Title;
            public string   Description;      // shown under the prompt line
            public string[] Headers;
            public string[,] Rows;            // [row, col]; null = blank
            public int      FullCol;          // column index the player fills entirely
        }

        private Puzzle[] puzzles = new Puzzle[]
        {
            // ── Puzzle 0 ── P ∧ Q  (AND)
            new Puzzle
            {
                Title       = "P ∧ Q  (Conjunction / AND)",
                Description = "Fill in the blanks. Complete the highlighted column entirely.",
                Headers     = new string[] { "P", "Q", "P ∧ Q" },
                Rows        = new string[,]
                {
                    { "T", "T", null  },   // null = blank
                    { "T", "F", null  },
                    { "F", "T", null  },
                    { "F", "F", null  }
                },
                FullCol = 2    // "P ∧ Q" column is the one the player fills
            },

            // ── Puzzle 1 ── P ∨ Q  (OR)  – mixed blanks
            new Puzzle
            {
                Title       = "P ∨ Q  (Disjunction / OR)",
                Description = "Some cells are hidden. Restore the full truth table.",
                Headers     = new string[] { "P", "Q", "P ∨ Q" },
                Rows        = new string[,]
                {
                    { "T",  "T",  null  },
                    { "T",  null, "T"   },   // Q is also blank
                    { null, "T",  "T"   },   // P is blank
                    { "F",  "F",  null  }
                },
                FullCol = 2
            },

            // ── Puzzle 2 ── ¬P  (NOT)
            new Puzzle
            {
                Title       = "¬P  (Negation / NOT)",
                Description = "Complete the negation column and the two hidden input cells.",
                Headers     = new string[] { "P", "¬P" },
                Rows        = new string[,]
                {
                    { "T", null },
                    { null, "F" },   // P blank (answer: F → ¬P = T, but ¬P given = F means P=T … wait, let's keep it simple)
                    { "F", null },
                    { null, "T" }
                },
                FullCol = 1
            },

            // ── Puzzle 3 ── P → Q  (Implication)
            new Puzzle
            {
                Title       = "P → Q  (Conditional / IF-THEN)",
                Description = "Fill the result column AND the two missing premise cells.",
                Headers     = new string[] { "P", "Q", "P → Q" },
                Rows        = new string[,]
                {
                    { "T", "T", null },
                    { "T", null, "F" },   // Q blank (answer: F)
                    { null, "T", "T" },   // P blank (answer: F)
                    { "F", "F", null }
                },
                FullCol = 2
            },

            // ── Puzzle 4 ── P ↔ Q  (Biconditional)
            new Puzzle
            {
                Title       = "P ↔ Q  (Biconditional / IFF)",
                Description = "Complete the biconditional column and restore the hidden cells.",
                Headers     = new string[] { "P", "Q", "P ↔ Q" },
                Rows        = new string[,]
                {
                    { "T", null, "T" },   // Q blank (answer: T)
                    { "T", "F", null },
                    { "F", null, "F" },   // Q blank (answer: T)
                    { "F", "F", null }
                },
                FullCol = 2
            }
        };

        // Correct answers parallel to puzzles[].Rows (null = pre-filled, non-null = answer)
        private string[][,] answers = new string[][,]
        {
            // Puzzle 0 – P ∧ Q
            new string[,] { { null,null,"T" }, { null,null,"F" }, { null,null,"F" }, { null,null,"F" } },
            // Puzzle 1 – P ∨ Q
            new string[,] { { null,null,"T" }, { null,"F",null }, { "F",null,null }, { null,null,"F" } },
            // Puzzle 2 – ¬P
            new string[,] { { null,"F" }, { "T",null }, { null,"T" }, { "F",null } },
            // Puzzle 3 – P → Q
            new string[,] { { null,null,"T" }, { null,"F",null }, { "F",null,null }, { null,null,"T" } },
            // Puzzle 4 – P ↔ Q
            new string[,] { { null,"T",null }, { null,null,"F" }, { null,"T",null }, { null,null,"T" } }
        };

        // Runtime: [row, col] → TextBox or null
        private TextBox[,] inputCells;

        // Undo stack: each entry is (row, col, previousValue)
        private struct UndoEntry
		{
		    public int Row;
		    public int Col;
		    public string Prev;
		
		    public UndoEntry(int row, int col, string prev)
		    {
		        Row = row;
		        Col = col;
		        Prev = prev;
		    }
		}

		private Stack<UndoEntry> undoStack = new Stack<UndoEntry>();
        // ─────────────────────────────────────────────────────────────────────
        //  Constructor & back button
        // ─────────────────────────────────────────────────────────────────────
        public frmLab1()
        {
            InitializeComponent();
        }

        private async void lblExit_Click(object sender, EventArgs e)
        {
        	SoundManager.PlayDoorSound();
        	await Task.Delay(500);
            frmMainHall exitLab1 = new frmMainHall();
            exitLab1.Show();
            this.Close();
        }

        // Wire this to your monitor / board click in the Designer
        void LblBoardClick(object sender, EventArgs e)
		{
		    ShowTruthTableOverlay();
		}
		
		void LblMonitorClick(object sender, EventArgs e)
		{
		    ShowTruthTableOverlay();
		}

        // ─────────────────────────────────────────────────────────────────────
        //  Build the overlay (same monitor shell as frmLec5)
        // ─────────────────────────────────────────────────────────────────────
        private void ShowTruthTableOverlay()
        {
            currentPuzzle = 0;
            undoStack.Clear();

            // DIM OVERLAY
            overlayPanel          = new TransparentPanel(Color.FromArgb(180, 0, 0, 0));
            overlayPanel.Size     = this.ClientSize;
            overlayPanel.Location = Point.Empty;

            // MONITOR BEZEL
            int mW = 720, mH = 540;
            monitorPanel          = new Panel();
            monitorPanel.Size     = new Size(mW, mH);
            monitorPanel.Location = new Point((overlayPanel.Width - mW) / 2,
                                              (overlayPanel.Height - mH) / 2);
            monitorPanel.BackColor = Color.FromArgb(28, 28, 32);
            monitorPanel.Paint    += MonitorBezel_Paint;

            // SCREEN PANEL
            int scrPad = 18, titleBarH = 32, standH = 55;
            screenPanel          = new Panel();
            screenPanel.Size     = new Size(mW - scrPad * 2, mH - titleBarH - scrPad - standH);
            screenPanel.Location = new Point(scrPad, titleBarH);
            screenPanel.BackColor = Color.FromArgb(10, 18, 30);
            screenPanel.Paint    += Screen_Paint;

            // TITLE BAR
            Label titleBar       = new Label();
            titleBar.AutoSize    = false;
            titleBar.Size        = new Size(mW - scrPad * 2, titleBarH - 4);
            titleBar.Location    = new Point(scrPad, 4);
            titleBar.BackColor   = Color.FromArgb(20, 22, 28);
            titleBar.ForeColor   = Color.FromArgb(0, 200, 255);
            titleBar.Font        = new Font("Consolas", 9, FontStyle.Bold);
            titleBar.Text        = "  ● LOGIC LAB TERMINAL  v1.0   |   Truth Table Puzzles";
            titleBar.TextAlign   = ContentAlignment.MiddleLeft;
            titleBar.Paint      += (s, ev) =>
            {
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 95, 87)),  new Rectangle(mW - 80, 9, 13, 13));
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 189, 46)), new Rectangle(mW - 58, 9, 13, 13));
                ev.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(40, 200, 65)),  new Rectangle(mW - 36, 9, 13, 13));
            };

            // CLOSE BUTTON (transparent, over red dot)
            Button closeBtn      = new Button();
            closeBtn.Size        = new Size(13, 13);
            closeBtn.Location    = new Point(mW - 80, 9);
            closeBtn.FlatStyle   = FlatStyle.Flat;
            closeBtn.BackColor   = Color.Transparent;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            closeBtn.Cursor      = Cursors.Hand;
            closeBtn.Click      += (s, e) => HideOverlay();

            monitorPanel.Controls.Add(titleBar);
            monitorPanel.Controls.Add(closeBtn);
            monitorPanel.Controls.Add(screenPanel);

            overlayPanel.Controls.Add(monitorPanel);
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();

            foreach (Control c in this.Controls)
                if (c != overlayPanel) c.Enabled = false;

            LoadPuzzle(currentPuzzle);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Load a puzzle onto the screen panel
        // ─────────────────────────────────────────────────────────────────────
        private void LoadPuzzle(int idx)
        {
            screenPanel.Controls.Clear();
            undoStack.Clear();

            Puzzle pz = puzzles[idx];
            int rows = pz.Rows.GetLength(0);
            int cols = pz.Rows.GetLength(1);

            inputCells = new TextBox[rows, cols];

            // ── PROMPT LINE ───────────────────────────────────────────────────
            Label prompt      = new Label();
            prompt.AutoSize   = false;
            prompt.Size       = new Size(660, 18);
            prompt.Location   = new Point(20, 10);
            prompt.Font       = new Font("Consolas", 8, FontStyle.Regular);
            prompt.ForeColor  = Color.FromArgb(0, 180, 100);
            prompt.BackColor  = Color.Transparent;
            prompt.Text       = "student@logiclab:~$ truth-table --puzzle=" + (idx + 1);
            screenPanel.Controls.Add(prompt);

            // ── PUZZLE COUNTER ────────────────────────────────────────────────
            Label counter     = new Label();
            counter.AutoSize  = true;
            counter.Location  = new Point(20, 32);
            counter.Font      = new Font("Consolas", 9, FontStyle.Regular);
            counter.ForeColor = Color.FromArgb(0, 180, 220);
            counter.BackColor = Color.Transparent;
            counter.Text      = "// Puzzle " + (idx + 1) + " of " + puzzles.Length;
            screenPanel.Controls.Add(counter);

            // ── TITLE ─────────────────────────────────────────────────────────
            Label title       = new Label();
            title.AutoSize    = false;
            title.Size        = new Size(660, 26);
            title.Location    = new Point(20, 54);
            title.Font        = new Font("Consolas", 13, FontStyle.Bold);
            title.ForeColor   = Color.FromArgb(220, 240, 255);
            title.BackColor   = Color.Transparent;
            title.Text        = "> " + pz.Title;
            screenPanel.Controls.Add(title);

            // ── DESCRIPTION ───────────────────────────────────────────────────
            Label desc        = new Label();
            desc.AutoSize     = false;
            desc.Size         = new Size(660, 20);
            desc.Location     = new Point(20, 82);
            desc.Font         = new Font("Consolas", 8, FontStyle.Italic);
            desc.ForeColor    = Color.FromArgb(160, 200, 255);
            desc.BackColor    = Color.Transparent;
            desc.Text         = pz.Description;
            screenPanel.Controls.Add(desc);

            // ── LEGEND ────────────────────────────────────────────────────────
            Label legend      = new Label();
            legend.AutoSize   = true;
            legend.Location   = new Point(20, 104);
            legend.Font       = new Font("Consolas", 7, FontStyle.Regular);
            legend.ForeColor  = Color.FromArgb(100, 160, 200);
            legend.BackColor  = Color.Transparent;
            legend.Text       = "[ highlighted column = must fill entirely ]   [ type T or F in blank cells ]";
            screenPanel.Controls.Add(legend);

            // ── TRUTH TABLE ───────────────────────────────────────────────────
            int tableX   = 20;
            int tableY   = 128;
            int cellW    = 90;
            int cellH    = 36;
            int headerH  = 36;

            // Headers
            for (int c = 0; c < cols; c++)
            {
                bool isFullCol = (c == pz.FullCol);

                Label hdr      = new Label();
                hdr.AutoSize   = false;
                hdr.Size       = new Size(cellW, headerH);
                hdr.Location   = new Point(tableX + c * (cellW + 2), tableY);
                hdr.Font       = new Font("Consolas", 10, FontStyle.Bold);
                hdr.ForeColor  = isFullCol ? Color.FromArgb(0, 220, 255) : Color.FromArgb(200, 220, 255);
                hdr.BackColor  = isFullCol ? Color.FromArgb(0, 50, 80)   : Color.FromArgb(15, 30, 50);
                hdr.Text       = pz.Headers[c];
                hdr.TextAlign  = ContentAlignment.MiddleCenter;
                hdr.BorderStyle = BorderStyle.FixedSingle;
                screenPanel.Controls.Add(hdr);
            }

            // Rows
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    bool isFullCol = (c == pz.FullCol);
                    string cellVal = pz.Rows[r, c];
                    int x = tableX + c * (cellW + 2);
                    int y = tableY + headerH + 2 + r * (cellH + 2);

                    if (cellVal == null)
                    {
                        // BLANK – editable TextBox
                        TextBox tb      = new TextBox();
                        tb.Size         = new Size(cellW, cellH);
                        tb.Location     = new Point(x, y);
                        tb.Font         = new Font("Consolas", 13, FontStyle.Bold);
                        tb.ForeColor    = isFullCol ? Color.FromArgb(0, 255, 200) : Color.FromArgb(255, 220, 80);
                        tb.BackColor    = isFullCol ? Color.FromArgb(0, 40, 55)   : Color.FromArgb(40, 35, 0);
                        tb.BorderStyle  = BorderStyle.FixedSingle;
                        tb.TextAlign    = HorizontalAlignment.Center;
                        tb.MaxLength    = 1;
                        tb.Tag          = new Point(r, c); // store position
                        tb.CharacterCasing = CharacterCasing.Upper;

                        tb.KeyPress    += TruthCell_KeyPress;
                        tb.TextChanged += TruthCell_TextChanged;

                        screenPanel.Controls.Add(tb);
                        inputCells[r, c] = tb;
                    }
                    else
                    {
                        // PRE-FILLED – read-only label
                        Label lbl      = new Label();
                        lbl.AutoSize   = false;
                        lbl.Size       = new Size(cellW, cellH);
                        lbl.Location   = new Point(x, y);
                        lbl.Font       = new Font("Consolas", 13, FontStyle.Bold);
                        lbl.ForeColor  = Color.FromArgb(180, 200, 220);
                        lbl.BackColor  = Color.FromArgb(12, 22, 38);
                        lbl.Text       = cellVal;
                        lbl.TextAlign  = ContentAlignment.MiddleCenter;
                        lbl.BorderStyle = BorderStyle.FixedSingle;
                        screenPanel.Controls.Add(lbl);
                    }
                }
            }

            int tableBottom = tableY + headerH + 2 + rows * (cellH + 2) + 14;

            // ── FEEDBACK LABEL ────────────────────────────────────────────────
            Label feedback      = new Label();
            feedback.Name       = "lblFeedback";
            feedback.AutoSize   = false;
            feedback.Size       = new Size(540, 26);
            feedback.Location   = new Point(20, tableBottom);
            feedback.Font       = new Font("Consolas", 10, FontStyle.Italic);
            feedback.BackColor  = Color.Transparent;
            feedback.TextAlign  = ContentAlignment.MiddleLeft;
            feedback.Visible    = false;
            screenPanel.Controls.Add(feedback);

            // ── UNDO BUTTON ───────────────────────────────────────────────────
            Button undoBtn      = new Button();
            undoBtn.Name        = "btnUndo";
            undoBtn.Text        = "↩ UNDO";
            undoBtn.Size        = new Size(120, 36);
            undoBtn.Location    = new Point(20, screenPanel.Height - 50);
            undoBtn.FlatStyle   = FlatStyle.Flat;
            undoBtn.ForeColor   = Color.FromArgb(255, 200, 60);
            undoBtn.BackColor   = Color.FromArgb(50, 40, 0);
            undoBtn.Font        = new Font("Consolas", 10, FontStyle.Bold);
            undoBtn.FlatAppearance.BorderColor = Color.FromArgb(200, 160, 0);
            undoBtn.FlatAppearance.BorderSize  = 2;
            undoBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 65, 0);
            undoBtn.Cursor      = Cursors.Hand;
            undoBtn.Click      += UndoBtn_Click;
            screenPanel.Controls.Add(undoBtn);

            // ── CHECK BUTTON ──────────────────────────────────────────────────
            Button checkBtn     = new Button();
            checkBtn.Name       = "btnCheck";
            checkBtn.Text       = "CHECK  ✔";
            checkBtn.Size       = new Size(150, 36);
            checkBtn.Location   = new Point(screenPanel.Width - 350, screenPanel.Height - 50);
            checkBtn.FlatStyle  = FlatStyle.Flat;
            checkBtn.ForeColor  = Color.FromArgb(0, 220, 130);
            checkBtn.BackColor  = Color.FromArgb(0, 40, 25);
            checkBtn.Font       = new Font("Consolas", 10, FontStyle.Bold);
            checkBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 100);
            checkBtn.FlatAppearance.BorderSize  = 2;
            checkBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 60, 38);
            checkBtn.Cursor     = Cursors.Hand;
            checkBtn.Click     += CheckBtn_Click;
            screenPanel.Controls.Add(checkBtn);

            // ── NEXT BUTTON ───────────────────────────────────────────────────
            Button nextBtn      = new Button();
            nextBtn.Name        = "btnNext";
            nextBtn.Text        = (idx == puzzles.Length - 1) ? "FINISH  ✔" : "NEXT  >";
            nextBtn.Size        = new Size(150, 36);
            nextBtn.Location    = new Point(screenPanel.Width - 180, screenPanel.Height - 50);
            nextBtn.FlatStyle   = FlatStyle.Flat;
            nextBtn.ForeColor   = Color.FromArgb(0, 220, 255);
            nextBtn.BackColor   = Color.FromArgb(10, 50, 70);
            nextBtn.Font        = new Font("Consolas", 10, FontStyle.Bold);
            nextBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 220);
            nextBtn.FlatAppearance.BorderSize  = 2;
            nextBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 80, 110);
            nextBtn.Cursor      = Cursors.Hand;
            nextBtn.Visible     = false;
            nextBtn.Click      += NextBtn_Click;
            screenPanel.Controls.Add(nextBtn);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Cell input validation – only T or F allowed
        // ─────────────────────────────────────────────────────────────────────
        private void TruthCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = char.ToUpper(e.KeyChar);
            if (c != 'T' && c != 'F' && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // block everything else
        }

        private void TruthCell_TextChanged(object sender, EventArgs e)
        {
            TextBox tb  = sender as TextBox;
            Point pos   = (Point)tb.Tag;
            string prev = "";   // we record before-change; simplest: push every change

            // Push current value before this change (we stored on KeyPress; here we
            // push old value = whatever was there before the keystroke arrived).
            // Since TextChanged fires after the change, "prev" is already gone.
            // We push (row, col, oldValue) each time a character is added/removed.
            // On undo we put the old value back; the stack records the NEW value so
            // popping restores the previous.
            // Simpler strategy: push AFTER change, store new value; undo replaces with "".
            undoStack.Push(new UndoEntry(pos.X, pos.Y, tb.Text)); // record this state so undo can clear it

            // Immediately hide feedback when the player edits
            Label feedback = screenPanel.Controls["lblFeedback"] as Label;
            if (feedback != null) feedback.Visible = false;

            Button next = screenPanel.Controls["btnNext"] as Button;
            if (next != null) next.Visible = false;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Undo
        // ─────────────────────────────────────────────────────────────────────
        private void UndoBtn_Click(object sender, EventArgs e)
        {
            if (undoStack.Count == 0) return;

            // Pop last entry → clear that cell
            UndoEntry entry = undoStack.Pop();

			int r = entry.Row;
			int c = entry.Col;
            if (inputCells[r, c] != null)
            {
                // Temporarily detach TextChanged so pushing to stack doesn't loop
                inputCells[r, c].TextChanged -= TruthCell_TextChanged;
                inputCells[r, c].Text = "";
                inputCells[r, c].TextChanged += TruthCell_TextChanged;
            }

            Label feedback = screenPanel.Controls["lblFeedback"] as Label;
            if (feedback != null) feedback.Visible = false;

            Button next = screenPanel.Controls["btnNext"] as Button;
            if (next != null) next.Visible = false;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Check answer
        // ─────────────────────────────────────────────────────────────────────
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            Puzzle pz   = puzzles[currentPuzzle];
            int rows    = pz.Rows.GetLength(0);
            int cols    = pz.Rows.GetLength(1);
            bool allCorrect = true;
            bool allFilled  = true;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    TextBox tb = inputCells[r, c];
                    if (tb == null) continue; // pre-filled

                    string expected = answers[currentPuzzle][r, c];
                    string entered  = tb.Text.Trim().ToUpper();

                    if (entered == "")
                    {
                        allFilled = false;
                        tb.BackColor = Color.FromArgb(60, 30, 0); // orange-warn
                        continue;
                    }

                    if (entered == expected)
                        tb.BackColor = Color.FromArgb(0, 50, 30);  // green tint
                    else
                    {
                        tb.BackColor = Color.FromArgb(80, 10, 10); // red tint
                        allCorrect   = false;
                    }
                }
            }

            Label feedback = screenPanel.Controls["lblFeedback"] as Label;
            Button next    = screenPanel.Controls["btnNext"]     as Button;

            if (!allFilled)
            {
                if (feedback != null)
                {
                    feedback.Text      = "⚠  Fill in all blank cells first!";
                    feedback.ForeColor = Color.FromArgb(255, 200, 50);
                    feedback.Visible   = true;
                }
                return;
            }

            if (allCorrect)
            {
                if (feedback != null)
                {
                    feedback.Text      = "✓  All correct! Well done!";
                    feedback.ForeColor = Color.FromArgb(80, 220, 130);
                    feedback.Visible   = true;
                }
                if (next != null) next.Visible = true;
            }
            else
            {
                if (feedback != null)
                {
                    feedback.Text      = "✗  Some answers are wrong. Review red cells.";
                    feedback.ForeColor = Color.FromArgb(230, 100, 100);
                    feedback.Visible   = true;
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Next puzzle / finish
        // ─────────────────────────────────────────────────────────────────────
        private void NextBtn_Click(object sender, EventArgs e)
        {
            currentPuzzle++;
            if (currentPuzzle >= puzzles.Length)
            {
                MessageBox.Show("You've completed all truth table puzzles!\nA room has been unlocked!",
                    "Puzzle Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideOverlay();
                GameState.UnlockRoom("CCSFaculty"); // Room Name Unlock
            }
            else
            {
                undoStack.Clear();
                LoadPuzzle(currentPuzzle);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Hide / dispose overlay
        // ─────────────────────────────────────────────────────────────────────
        private void HideOverlay()
        {
            foreach (Control c in this.Controls)
                c.Enabled = true;

            this.Controls.Remove(overlayPanel);
            overlayPanel.Dispose();
            overlayPanel = null;
            monitorPanel = null;
            screenPanel  = null;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Paint handlers (identical to frmLec5)
        // ─────────────────────────────────────────────────────────────────────
        private void MonitorBezel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g  = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Panel p     = sender as Panel;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                p.ClientRectangle,
                Color.FromArgb(50, 52, 60),
                Color.FromArgb(22, 22, 28),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                g.FillRectangle(brush, 0, 0, p.Width, p.Height);

            using (var pen = new Pen(Color.FromArgb(80, 80, 95), 1))
                g.DrawLine(pen, 12, 1, p.Width - 12, 1);

            int standW = 200, standH = 16, neckH = 20, neckW = 44;
            int baseY = p.Height - standH, centerX = p.Width / 2;

            using (var b = new SolidBrush(Color.FromArgb(40, 42, 50)))
                g.FillRectangle(b, centerX - neckW / 2, p.Height - standH - neckH, neckW, neckH);
            using (var b = new SolidBrush(Color.FromArgb(35, 37, 45)))
                g.FillRectangle(b, centerX - standW / 2, baseY, standW, standH);
            using (var pen = new Pen(Color.FromArgb(60, 62, 75), 1))
                g.DrawRectangle(pen, centerX - standW / 2, baseY, standW, standH);
            using (var b = new SolidBrush(Color.FromArgb(0, 220, 130)))
                g.FillEllipse(b, centerX - 4, baseY + 4, 8, 8);
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g  = e.Graphics;
            Panel p     = sender as Panel;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                p.ClientRectangle,
                Color.FromArgb(8, 15, 28),
                Color.FromArgb(14, 22, 38),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                g.FillRectangle(brush, p.ClientRectangle);

            using (var scanPen = new Pen(Color.FromArgb(8, 255, 255, 255), 1))
                for (int y = 0; y < p.Height; y += 4)
                    g.DrawLine(scanPen, 0, y, p.Width, y);

            using (var pen = new Pen(Color.FromArgb(0, 160, 220), 2))
                g.DrawRectangle(pen, 1, 1, p.Width - 3, p.Height - 3);

            using (var pen = new Pen(Color.FromArgb(0, 200, 255), 2))
            {
                g.DrawLine(pen, 10, 10, 30, 10); g.DrawLine(pen, 10, 10, 10, 30);
                g.DrawLine(pen, p.Width - 30, 10, p.Width - 10, 10); g.DrawLine(pen, p.Width - 10, 10, p.Width - 10, 30);
                g.DrawLine(pen, 10, p.Height - 10, 30, p.Height - 10); g.DrawLine(pen, 10, p.Height - 30, 10, p.Height - 10);
                g.DrawLine(pen, p.Width - 30, p.Height - 10, p.Width - 10, p.Height - 10); g.DrawLine(pen, p.Width - 10, p.Height - 30, p.Width - 10, p.Height - 10);
            }
        }
    }
}