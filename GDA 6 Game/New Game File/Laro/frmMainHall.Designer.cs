namespace Laro
{
    partial class frmMainHall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label Lec4Room;
        private System.Windows.Forms.Label Lec5Room;

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
            this.Lec4Room = new System.Windows.Forms.Label();
            this.Lec5Room = new System.Windows.Forms.Label();
            this.btnLobby = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lec4Room
            // 
            this.Lec4Room.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lec4Room.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lec4Room.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lec4Room.Location = new System.Drawing.Point(137, 208);
            this.Lec4Room.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lec4Room.Name = "Lec4Room";
            this.Lec4Room.Size = new System.Drawing.Size(184, 28);
            this.Lec4Room.TabIndex = 0;
            this.Lec4Room.Text = "LEC 4";
            this.Lec4Room.Click += new System.EventHandler(this.Lec4RoomClick);
            // 
            // Lec5Room
            // 
            this.Lec5Room.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lec5Room.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lec5Room.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lec5Room.Location = new System.Drawing.Point(992, 208);
            this.Lec5Room.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lec5Room.Name = "Lec5Room";
            this.Lec5Room.Size = new System.Drawing.Size(227, 28);
            this.Lec5Room.TabIndex = 2;
            this.Lec5Room.Text = "LEC 5";
            this.Lec5Room.Click += new System.EventHandler(this.Lec5RoomClick);
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
            this.btnLobby.Location = new System.Drawing.Point(1050, 624);
            this.btnLobby.Margin = new System.Windows.Forms.Padding(4);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(199, 36);
            this.btnLobby.TabIndex = 7;
            this.btnLobby.Text = "LOBBY";
            this.btnLobby.UseVisualStyleBackColor = true;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // frmMainHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnLobby);
            this.Controls.Add(this.Lec5Room);
            this.Controls.Add(this.Lec4Room);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMainHall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLobby;
    }
}