namespace Laro
{
    partial class frmCCSFaculty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCCSFaculty));
        	this.lblExit = new System.Windows.Forms.Label();
        	this.CharacterPic = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// lblExit
        	// 
        	this.lblExit.BackColor = System.Drawing.Color.Transparent;
        	this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.lblExit.Location = new System.Drawing.Point(762, 38);
        	this.lblExit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lblExit.Name = "lblExit";
        	this.lblExit.Size = new System.Drawing.Size(261, 440);
        	this.lblExit.TabIndex = 1;
        	this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
        	// 
        	// CharacterPic
        	// 
        	this.CharacterPic.BackColor = System.Drawing.Color.Transparent;
        	this.CharacterPic.Location = new System.Drawing.Point(946, 258);
        	this.CharacterPic.Name = "CharacterPic";
        	this.CharacterPic.Size = new System.Drawing.Size(158, 260);
        	this.CharacterPic.TabIndex = 2;
        	this.CharacterPic.TabStop = false;
        	this.CharacterPic.Visible = false;
        	// 
        	// frmCCSFaculty
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        	this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.ClientSize = new System.Drawing.Size(1116, 667);
        	this.Controls.Add(this.CharacterPic);
        	this.Controls.Add(this.lblExit);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "frmCCSFaculty";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "frmCCSFaculty";
        	this.Load += new System.EventHandler(this.FrmCCSFacultyLoad);
        	((System.ComponentModel.ISupportInitialize)(this.CharacterPic)).EndInit();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.PictureBox CharacterPic;
    }
}