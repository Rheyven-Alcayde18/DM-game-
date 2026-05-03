namespace Laro
{
    partial class frmLec4
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
            this.lblBoard = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBoard
            // 
            this.lblBoard.BackColor = System.Drawing.Color.Transparent;
            this.lblBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBoard.Location = new System.Drawing.Point(511, 178);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(332, 143);
            this.lblBoard.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(1079, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 251);
            this.label2.TabIndex = 1;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblClue
            // 
            this.lblClue.BackColor = System.Drawing.Color.Transparent;
            this.lblClue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClue.Location = new System.Drawing.Point(460, 531);
            this.lblClue.Name = "lblClue";
            this.lblClue.Size = new System.Drawing.Size(86, 76);
            this.lblClue.TabIndex = 1;
            this.lblClue.Click += new System.EventHandler(this.lblClue_Click);
            // 
            // frmLec4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Laro.Properties.Resources.LEC_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1281, 699);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblClue);
            this.Controls.Add(this.lblBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLec4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClue;
    }
}