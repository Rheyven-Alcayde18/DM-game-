/*
 * Created by SharpDevelop.
 * User: CJ
 * Date: 5/4/2026
 * Time: 4:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Laro
{
	partial class frmName
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton Female;
		private System.Windows.Forms.RadioButton Male;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Female = new System.Windows.Forms.RadioButton();
			this.Male = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
			this.button1.Location = new System.Drawing.Point(1185, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 43);
			this.button1.TabIndex = 5;
			this.button1.Text = "-";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(221)))));
			this.btnClose.Location = new System.Drawing.Point(1242, 2);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(52, 43);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Location = new System.Drawing.Point(2, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1303, 48);
			this.panel1.TabIndex = 8;
			// 
			// txtName
			// 
			this.txtName.AllowDrop = true;
			this.txtName.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(19, 84);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtName.MaxLength = 16;
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(373, 40);
			this.txtName.TabIndex = 9;
			this.txtName.TextChanged += new System.EventHandler(this.TxtNameTextChanged);
			this.txtName.Enter += new System.EventHandler(this.TxtNameEnter);
			this.txtName.Leave += new System.EventHandler(this.TxtNameLeave);
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
			this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSubmit.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSubmit.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSubmit.Location = new System.Drawing.Point(157, 282);
			this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(87, 28);
			this.btnSubmit.TabIndex = 10;
			this.btnSubmit.Text = "Confirm";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.BtnSubmitClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(19, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(300, 27);
			this.label1.TabIndex = 11;
			this.label1.Text = "CHARACTER NAME";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.groupBox1.Controls.Add(this.Female);
			this.groupBox1.Controls.Add(this.Male);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox1.Location = new System.Drawing.Point(19, 164);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(373, 100);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Choose Gender:";
			// 
			// Female
			// 
			this.Female.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.Female.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.Female.Location = new System.Drawing.Point(27, 63);
			this.Female.Name = "Female";
			this.Female.Size = new System.Drawing.Size(104, 24);
			this.Female.TabIndex = 1;
			this.Female.TabStop = true;
			this.Female.Text = "FEMALE";
			this.Female.UseVisualStyleBackColor = false;
			this.Female.CheckedChanged += new System.EventHandler(this.FemaleCheckedChanged);
			// 
			// Male
			// 
			this.Male.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.Male.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.Male.Location = new System.Drawing.Point(27, 23);
			this.Male.Name = "Male";
			this.Male.Size = new System.Drawing.Size(104, 24);
			this.Male.TabIndex = 0;
			this.Male.TabStop = true;
			this.Male.Text = "MALE";
			this.Male.UseVisualStyleBackColor = false;
			this.Male.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.btnSubmit);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.txtName);
			this.panel2.Location = new System.Drawing.Point(418, 134);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(410, 331);
			this.panel2.TabIndex = 13;
			// 
			// panel3
			// 
			this.panel3.Location = new System.Drawing.Point(2, 4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(404, 30);
			this.panel3.TabIndex = 13;
			// 
			// frmName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
			this.ClientSize = new System.Drawing.Size(1302, 821);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmName";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "name";
			this.Load += new System.EventHandler(this.FrmNameLoad);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
