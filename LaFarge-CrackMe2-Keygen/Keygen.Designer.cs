
namespace LaFarge_CrackMe2_Keygen
{
    partial class Keygen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keygen));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtSerialKey = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(78, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(257, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtSerialKey
            // 
            this.txtSerialKey.Location = new System.Drawing.Point(78, 44);
            this.txtSerialKey.Name = "txtSerialKey";
            this.txtSerialKey.ReadOnly = true;
            this.txtSerialKey.Size = new System.Drawing.Size(257, 20);
            this.txtSerialKey.TabIndex = 1;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(100, 70);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(102, 32);
            this.btnGenerateKey.TabIndex = 2;
            this.btnGenerateKey.Text = "Generate Key";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(14, 21);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(44, 47);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Key:";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Enabled = false;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(208, 70);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(102, 32);
            this.btnCopyToClipboard.TabIndex = 5;
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // Keygen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 110);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnGenerateKey);
            this.Controls.Add(this.txtSerialKey);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Keygen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaFarge\'s CrackMe #2 Keygen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keygen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtSerialKey;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}

