namespace HMSV2._0
{
    partial class License
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "LicenseText";
            //Text = "Form1";
            ResumeLayout(false);



            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.LicenseText = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // LicenseText
            // 
            this.LicenseText.AutoSize = true;
            this.LicenseText.Location = new System.Drawing.Point(-3, 4);
            this.LicenseText.Name = "LicenseText";
            this.LicenseText.Size = new System.Drawing.Size(487, 228);
            this.LicenseText.TabIndex = 0;
            this.LicenseText.Text = """
                This Program Is Written For Educational Purposes Only.
                
                Open Source Frameworks:
                Modern Ul - Most Of The Metro UI Implimented Using This Open Source Framework.

                License under: MIT - http://github.com/viperneo

                Twilio - This Framework By Twilio Was Used To Send The Message To Phone Number Regarding Customer Reservation.

                https://www.twilio.com/ 
                """;
            //this.LicenseText.Text = resources.GetString("LicenseText.Text");
            // 
            // License
            // 
            this.Controls.Add(this.LicenseText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.PerformLayout();
        }

        #endregion
        private MetroFramework.Controls.MetroLabel LicenseText;
    }
}
