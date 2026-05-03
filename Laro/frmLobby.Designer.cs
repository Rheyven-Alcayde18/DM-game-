namespace Laro
{
    partial class frmLobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label Cutscene;
        private System.Windows.Forms.Label CharacterName;
        private System.Windows.Forms.TextBox DialogueBox;
        private System.Windows.Forms.PictureBox CharacterPic;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLobby));
            this.Cutscene = new System.Windows.Forms.Label();
            this.CharacterName = new System.Windows.Forms.Label();
            this.DialogueBox = new System.Windows.Forms.TextBox();
            this.CharacterPic = new System.Windows.Forms.PictureBox();
            this.btnLobby = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cutscene
            // 
            this.Cutscene.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cutscene.Location = new System.Drawing.Point(451, 289);
            this.Cutscene.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cutscene.Name = "Cutscene";
            this.Cutscene.Size = new System.Drawing.Size(578, 98);
            this.Cutscene.TabIndex = 0;
            this.Cutscene.Text = "CUTSCENE\r\n(Texts only)";
            this.Cutscene.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharacterName
            // 
            this.CharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharacterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
            this.CharacterName.Location = new System.Drawing.Point(1, 661);
            this.CharacterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.Size = new System.Drawing.Size(184, 28);
            this.CharacterName.TabIndex = 2;
            this.CharacterName.Text = "(Character Name)";
            // 
            // DialogueBox
            // 
            this.DialogueBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.DialogueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogueBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DialogueBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DialogueBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DialogueBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
            this.DialogueBox.Location = new System.Drawing.Point(0, 693);
            this.DialogueBox.Margin = new System.Windows.Forms.Padding(4);
            this.DialogueBox.Multiline = true;
            this.DialogueBox.Name = "DialogueBox";
            this.DialogueBox.ReadOnly = true;
            this.DialogueBox.Size = new System.Drawing.Size(1488, 128);
            this.DialogueBox.TabIndex = 3;
            this.DialogueBox.Text = "The dialoag shows here and clicks";
            // 
            // CharacterPic
            // 
            this.CharacterPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CharacterPic.BackgroundImage")));
            this.CharacterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CharacterPic.Location = new System.Drawing.Point(1327, 465);
            this.CharacterPic.Margin = new System.Windows.Forms.Padding(4);
            this.CharacterPic.Name = "CharacterPic";
            this.CharacterPic.Size = new System.Drawing.Size(161, 229);
            this.CharacterPic.TabIndex = 4;
            this.CharacterPic.TabStop = false;
            // 
            // btnLobby
            // 
            this.btnLobby.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLobby.BackgroundImage")));
            this.btnLobby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLobby.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLobby.FlatAppearance.BorderSize = 0;
            this.btnLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLobby.ForeColor = System.Drawing.Color.White;
            this.btnLobby.Location = new System.Drawing.Point(1308, 421);
            this.btnLobby.Margin = new System.Windows.Forms.Padding(4);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(199, 36);
            this.btnLobby.TabIndex = 6;
            this.btnLobby.Text = "HALL";
            this.btnLobby.UseVisualStyleBackColor = true;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
            this.button1.Location = new System.Drawing.Point(1355, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
            this.btnClose.Location = new System.Drawing.Point(1421, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1489, 48);
            this.panel1.TabIndex = 7;
            // 
            // frmLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1488, 821);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLobby);
            this.Controls.Add(this.DialogueBox);
            this.Controls.Add(this.CharacterName);
            this.Controls.Add(this.Cutscene);
            this.Controls.Add(this.CharacterPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Lobby";
            this.Load += new System.EventHandler(this.frmLobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLobby;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}