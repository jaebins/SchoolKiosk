namespace SchoolKiosk
{
    partial class Attendance
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
            this.input_Attendance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // input_Attendance
            // 
            this.input_Attendance.BackColor = System.Drawing.Color.RosyBrown;
            this.input_Attendance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input_Attendance.Location = new System.Drawing.Point(-4, -2);
            this.input_Attendance.Multiline = true;
            this.input_Attendance.Name = "input_Attendance";
            this.input_Attendance.ReadOnly = true;
            this.input_Attendance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input_Attendance.Size = new System.Drawing.Size(392, 767);
            this.input_Attendance.TabIndex = 0;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 761);
            this.Controls.Add(this.input_Attendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Attendance";
            this.Text = "현재 출석한 사람";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox input_Attendance;
    }
}