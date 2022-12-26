namespace CMTE.Forms
{
    partial class Profile
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
            this.button1 = new System.Windows.Forms.Button();
            this.key = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.Label();
            this.subscription = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.expiry = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 72);
            this.button1.TabIndex = 9;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.Location = new System.Drawing.Point(27, 122);
            this.key.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(52, 18);
            this.key.TabIndex = 10;
            this.key.Text = "label1";
            // 
            // ip
            // 
            this.ip.AutoSize = true;
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.Location = new System.Drawing.Point(27, 151);
            this.ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(52, 18);
            this.ip.TabIndex = 11;
            this.ip.Text = "label2";
            // 
            // subscription
            // 
            this.subscription.AutoSize = true;
            this.subscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscription.Location = new System.Drawing.Point(27, 179);
            this.subscription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subscription.Name = "subscription";
            this.subscription.Size = new System.Drawing.Size(52, 18);
            this.subscription.TabIndex = 12;
            this.subscription.Text = "label3";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.Location = new System.Drawing.Point(27, 208);
            this.version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(52, 18);
            this.version.TabIndex = 13;
            this.version.Text = "label4";
            // 
            // expiry
            // 
            this.expiry.AutoSize = true;
            this.expiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiry.Location = new System.Drawing.Point(27, 237);
            this.expiry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(52, 18);
            this.expiry.TabIndex = 14;
            this.expiry.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 264);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "label4";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expiry);
            this.Controls.Add(this.version);
            this.Controls.Add(this.subscription);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.key);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label key;
        public System.Windows.Forms.Label ip;
        public System.Windows.Forms.Label subscription;
        public System.Windows.Forms.Label version;
        public System.Windows.Forms.Label expiry;
        public System.Windows.Forms.Label label1;
    }
}