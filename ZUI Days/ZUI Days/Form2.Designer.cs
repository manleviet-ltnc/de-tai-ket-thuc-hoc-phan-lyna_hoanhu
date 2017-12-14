namespace ZUI_Days
{
    partial class Form2
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDateTime = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.tbxEvents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(13, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 59);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(259, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 59);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDateTime
            // 
            this.btnDateTime.Location = new System.Drawing.Point(12, 29);
            this.btnDateTime.Name = "btnDateTime";
            this.btnDateTime.Size = new System.Drawing.Size(75, 36);
            this.btnDateTime.TabIndex = 4;
            this.btnDateTime.Text = "Date Time";
            this.btnDateTime.UseVisualStyleBackColor = true;
            // 
            // btnEvents
            // 
            this.btnEvents.Location = new System.Drawing.Point(12, 77);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(75, 35);
            this.btnEvents.TabIndex = 5;
            this.btnEvents.Text = "Events";
            this.btnEvents.UseVisualStyleBackColor = true;
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDateTime.Location = new System.Drawing.Point(93, 35);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(241, 20);
            this.dtpDateTime.TabIndex = 6;
            // 
            // tbxEvents
            // 
            this.tbxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxEvents.Location = new System.Drawing.Point(93, 77);
            this.tbxEvents.Multiline = true;
            this.tbxEvents.Name = "tbxEvents";
            this.tbxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEvents.Size = new System.Drawing.Size(241, 132);
            this.tbxEvents.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 286);
            this.Controls.Add(this.tbxEvents);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnDateTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDateTime;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.TextBox tbxEvents;
        public System.Windows.Forms.DateTimePicker dtpDateTime;
    }
}