namespace PinsGenerator
{
    partial class MainForm
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
            this.generatePinBtn = new System.Windows.Forms.Button();
            this.pinOutput = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.restartProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generatePinBtn
            // 
            this.generatePinBtn.Location = new System.Drawing.Point(220, 98);
            this.generatePinBtn.Name = "generatePinBtn";
            this.generatePinBtn.Size = new System.Drawing.Size(177, 41);
            this.generatePinBtn.TabIndex = 0;
            this.generatePinBtn.Text = "Generate Unique PIN";
            this.generatePinBtn.UseVisualStyleBackColor = true;
            this.generatePinBtn.Click += new System.EventHandler(this.generatePin_Click);
            // 
            // pinOutput
            // 
            this.pinOutput.AutoSize = true;
            this.pinOutput.Location = new System.Drawing.Point(114, 195);
            this.pinOutput.Name = "pinOutput";
            this.pinOutput.Size = new System.Drawing.Size(0, 17);
            this.pinOutput.TabIndex = 1;
            this.pinOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pinOutput.Visible = false;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(35, 195);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(52, 17);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "Result:";
            this.outputLabel.Visible = false;
            // 
            // restartProgram
            // 
            this.restartProgram.Location = new System.Drawing.Point(220, 300);
            this.restartProgram.Name = "restartProgram";
            this.restartProgram.Size = new System.Drawing.Size(177, 39);
            this.restartProgram.TabIndex = 3;
            this.restartProgram.Text = "Restart Program";
            this.restartProgram.UseVisualStyleBackColor = true;
            this.restartProgram.Visible = false;
            this.restartProgram.Click += new System.EventHandler(this.restartBtn_Clicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 383);
            this.Controls.Add(this.restartProgram);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.pinOutput);
            this.Controls.Add(this.generatePinBtn);
            this.Name = "MainForm";
            this.Text = "PINS Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generatePinBtn;
        private System.Windows.Forms.Label pinOutput;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button restartProgram;
    }
}

