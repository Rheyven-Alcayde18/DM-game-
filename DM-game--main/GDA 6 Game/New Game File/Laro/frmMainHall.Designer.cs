namespace Laro
{
    partial class frmMainHall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainHall));
            this.btnLobby = new System.Windows.Forms.Button();
            this.lblLec4 = new System.Windows.Forms.Label();
            this.lblLec6 = new System.Windows.Forms.Label();
            this.lblLec5 = new System.Windows.Forms.Label();
            this.lblLec7 = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblCCSFaculty = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnLobby.Location = new System.Drawing.Point(1185, 683);
            this.btnLobby.Margin = new System.Windows.Forms.Padding(4);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(199, 36);
            this.btnLobby.TabIndex = 7;
            this.btnLobby.Text = "LOBBY";
            this.btnLobby.UseVisualStyleBackColor = true;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // lblLec4
            // 
            this.lblLec4.AutoSize = true;
            this.lblLec4.Location = new System.Drawing.Point(385, 256);
            this.lblLec4.Name = "lblLec4";
            this.lblLec4.Size = new System.Drawing.Size(46, 17);
            this.lblLec4.TabIndex = 8;
            this.lblLec4.Text = "label1";
            this.lblLec4.Click += new System.EventHandler(this.lblLec4_Click);
            // 
            // lblLec6
            // 
            this.lblLec6.AutoSize = true;
            this.lblLec6.Location = new System.Drawing.Point(385, 294);
            this.lblLec6.Name = "lblLec6";
            this.lblLec6.Size = new System.Drawing.Size(46, 17);
            this.lblLec6.TabIndex = 8;
            this.lblLec6.Text = "label1";
            this.lblLec6.Click += new System.EventHandler(this.lblLec6_Click);
            // 
            // lblLec5
            // 
            this.lblLec5.AutoSize = true;
            this.lblLec5.Location = new System.Drawing.Point(568, 256);
            this.lblLec5.Name = "lblLec5";
            this.lblLec5.Size = new System.Drawing.Size(46, 17);
            this.lblLec5.TabIndex = 8;
            this.lblLec5.Text = "label1";
            this.lblLec5.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblLec7
            // 
            this.lblLec7.AutoSize = true;
            this.lblLec7.Location = new System.Drawing.Point(568, 294);
            this.lblLec7.Name = "lblLec7";
            this.lblLec7.Size = new System.Drawing.Size(46, 17);
            this.lblLec7.TabIndex = 8;
            this.lblLec7.Text = "label1";
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Location = new System.Drawing.Point(385, 346);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(46, 17);
            this.lblExit.TabIndex = 8;
            this.lblExit.Text = "label1";
            // 
            // lblCCSFaculty
            // 
            this.lblCCSFaculty.AutoSize = true;
            this.lblCCSFaculty.Location = new System.Drawing.Point(568, 346);
            this.lblCCSFaculty.Name = "lblCCSFaculty";
            this.lblCCSFaculty.Size = new System.Drawing.Size(46, 17);
            this.lblCCSFaculty.TabIndex = 8;
            this.lblCCSFaculty.Text = "label1";
            // 
            // frmMainHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1488, 821);
            this.Controls.Add(this.lblCCSFaculty);
            this.Controls.Add(this.lblLec7);
            this.Controls.Add(this.lblLec5);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblLec6);
            this.Controls.Add(this.lblLec4);
            this.Controls.Add(this.btnLobby);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMainHall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLobby;
        private System.Windows.Forms.Label lblLec4;
        private System.Windows.Forms.Label lblLec6;
        private System.Windows.Forms.Label lblLec5;
        private System.Windows.Forms.Label lblLec7;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblCCSFaculty;
    }
}