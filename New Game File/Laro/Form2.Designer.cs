namespace Laro
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label Cutscene;
        private System.Windows.Forms.Label CharacterName;
        private System.Windows.Forms.TextBox DialogueBox;
        private System.Windows.Forms.PictureBox CharacterPic;
        private System.Windows.Forms.Label ClassHall;

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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
        	this.Cutscene = new System.Windows.Forms.Label();
        	this.CharacterName = new System.Windows.Forms.Label();
        	this.DialogueBox = new System.Windows.Forms.TextBox();
        	this.CharacterPic = new System.Windows.Forms.PictureBox();
        	this.ClassHall = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// Cutscene
        	// 
        	this.Cutscene.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Cutscene.Location = new System.Drawing.Point(292, 170);
        	this.Cutscene.Name = "Cutscene";
        	this.Cutscene.Size = new System.Drawing.Size(771, 289);
        	this.Cutscene.TabIndex = 0;
        	this.Cutscene.Text = "CUTSCENE\r\n(Texts only)";
        	this.Cutscene.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// CharacterName
        	// 
        	this.CharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.CharacterName.Location = new System.Drawing.Point(0, 496);
        	this.CharacterName.Name = "CharacterName";
        	this.CharacterName.Size = new System.Drawing.Size(138, 23);
        	this.CharacterName.TabIndex = 2;
        	this.CharacterName.Text = "(Character Name)";
        	// 
        	// DialogueBox
        	// 
        	this.DialogueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.DialogueBox.Cursor = System.Windows.Forms.Cursors.Default;
        	this.DialogueBox.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.DialogueBox.Location = new System.Drawing.Point(0, 522);
        	this.DialogueBox.Multiline = true;
        	this.DialogueBox.Name = "DialogueBox";
        	this.DialogueBox.ReadOnly = true;
        	this.DialogueBox.Size = new System.Drawing.Size(1369, 145);
        	this.DialogueBox.TabIndex = 3;
        	// 
        	// CharacterPic
        	// 
        	this.CharacterPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CharacterPic.BackgroundImage")));
        	this.CharacterPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.CharacterPic.Location = new System.Drawing.Point(1213, 352);
        	this.CharacterPic.Name = "CharacterPic";
        	this.CharacterPic.Size = new System.Drawing.Size(165, 234);
        	this.CharacterPic.TabIndex = 4;
        	this.CharacterPic.TabStop = false;
        	// 
        	// ClassHall
        	// 
        	this.ClassHall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.ClassHall.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.ClassHall.Location = new System.Drawing.Point(1243, 264);
        	this.ClassHall.Name = "ClassHall";
        	this.ClassHall.Size = new System.Drawing.Size(100, 23);
        	this.ClassHall.TabIndex = 5;
        	this.ClassHall.Text = "HALL";
        	this.ClassHall.Click += new System.EventHandler(this.ClassHallClick);
        	// 
        	// Form2
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1369, 667);
        	this.Controls.Add(this.ClassHall);
        	this.Controls.Add(this.DialogueBox);
        	this.Controls.Add(this.CharacterName);
        	this.Controls.Add(this.Cutscene);
        	this.Controls.Add(this.CharacterPic);
        	this.Name = "Form2";
        	this.Text = "School Lobby";
        	((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion
    }
}