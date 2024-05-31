namespace Homework
{
    partial class Form1
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
            this.DrawBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.CLoseBtn = new System.Windows.Forms.Button();
            this.ClearBrn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawBtn
            // 
            this.DrawBtn.Location = new System.Drawing.Point(192, 352);
            this.DrawBtn.Name = "DrawBtn";
            this.DrawBtn.Size = new System.Drawing.Size(75, 23);
            this.DrawBtn.TabIndex = 0;
            this.DrawBtn.Text = "Draw";
            this.DrawBtn.UseVisualStyleBackColor = true;
            this.DrawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(303, 352);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // CLoseBtn
            // 
            this.CLoseBtn.Location = new System.Drawing.Point(420, 352);
            this.CLoseBtn.Name = "CLoseBtn";
            this.CLoseBtn.Size = new System.Drawing.Size(75, 23);
            this.CLoseBtn.TabIndex = 2;
            this.CLoseBtn.Text = "Close";
            this.CLoseBtn.UseVisualStyleBackColor = true;
            this.CLoseBtn.Click += new System.EventHandler(this.CLoseBtn_Click);
            // 
            // ClearBrn
            // 
            this.ClearBrn.Location = new System.Drawing.Point(80, 352);
            this.ClearBrn.Name = "ClearBrn";
            this.ClearBrn.Size = new System.Drawing.Size(75, 23);
            this.ClearBrn.TabIndex = 3;
            this.ClearBrn.Text = "Clear";
            this.ClearBrn.UseVisualStyleBackColor = true;
            this.ClearBrn.Click += new System.EventHandler(this.ClearBrn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.ClearBrn);
            this.Controls.Add(this.CLoseBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.DrawBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.Resize += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ConnectBtn;
        public System.Windows.Forms.Button DrawBtn;
        private System.Windows.Forms.Button CLoseBtn;
        public System.Windows.Forms.Button ClearBrn;
    }
}

