namespace Laro
{
    partial class Form3
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
        	this.Lec4Room = new System.Windows.Forms.Label();
        	this.Lec5Room = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// Lec4Room
        	// 
        	this.Lec4Room.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.Lec4Room.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.Lec4Room.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Lec4Room.Location = new System.Drawing.Point(239, 72);
        	this.Lec4Room.Name = "Lec4Room";
        	this.Lec4Room.Size = new System.Drawing.Size(138, 23);
        	this.Lec4Room.TabIndex = 0;
        	this.Lec4Room.Text = "LEC 4";
        	this.Lec4Room.Click += new System.EventHandler(this.Lec4RoomClick);
        	// 
        	// Lec5Room
        	// 
        	this.Lec5Room.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.Lec5Room.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.Lec5Room.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Lec5Room.Location = new System.Drawing.Point(918, 72);
        	this.Lec5Room.Name = "Lec5Room";
        	this.Lec5Room.Size = new System.Drawing.Size(170, 23);
        	this.Lec5Room.TabIndex = 2;
        	this.Lec5Room.Text = "LEC 5";
        	this.Lec5Room.Click += new System.EventHandler(this.Lec5RoomClick);
        	// 
        	// Form3
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1386, 667);
        	this.Controls.Add(this.Lec5Room);
        	this.Controls.Add(this.Lec4Room);
        	this.Cursor = System.Windows.Forms.Cursors.Arrow;
        	this.Name = "Form3";
        	this.Text = "Form3";
        	this.Load += new System.EventHandler(this.Form3Load);
        	this.ResumeLayout(false);

        }

        #endregion
    }
}