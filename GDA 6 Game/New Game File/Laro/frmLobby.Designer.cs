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
            ((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).BeginInit();
            this.SuspendLayout();
            // 
            // Cutscene
            // 
            this.Cutscene.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cutscene.Location = new System.Drawing.Point(330, 247);
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
            this.CharacterName.Location = new System.Drawing.Point(13, 513);
            this.CharacterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.Size = new System.Drawing.Size(184, 28);
            this.CharacterName.TabIndex = 2;
            this.CharacterName.Text = "(Character Name)";
            // 
            // DialogueBox
            // 
            this.DialogueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DialogueBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DialogueBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DialogueBox.Location = new System.Drawing.Point(0, 545);
            this.DialogueBox.Margin = new System.Windows.Forms.Padding(4);
            this.DialogueBox.Multiline = true;
            this.DialogueBox.Name = "DialogueBox";
            this.DialogueBox.ReadOnly = true;
            this.DialogueBox.Size = new System.Drawing.Size(1262, 128);
            this.DialogueBox.TabIndex = 3;
            // 
            // CharacterPic
            // 
            this.CharacterPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CharacterPic.BackgroundImage")));
            this.CharacterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CharacterPic.Location = new System.Drawing.Point(1101, 319);
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
            this.btnLobby.Location = new System.Drawing.Point(1083, 258);
            this.btnLobby.Margin = new System.Windows.Forms.Padding(4);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(199, 36);
            this.btnLobby.TabIndex = 6;
            this.btnLobby.Text = "HALL";
            this.btnLobby.UseVisualStyleBackColor = true;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // frmLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLobby;
    }
}