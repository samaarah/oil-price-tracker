namespace OilPriceTracker
{
    partial class Application
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
            this.buttonGetOilPrices = new System.Windows.Forms.Button();
            this.listBoxOilPrices_Teboil = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listBoxOilPrices_Lampopuisto = new System.Windows.Forms.ListBox();
            this.listBoxOilPrices_Neste = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStartReadingPrices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetOilPrices
            // 
            this.buttonGetOilPrices.Location = new System.Drawing.Point(590, 319);
            this.buttonGetOilPrices.Name = "buttonGetOilPrices";
            this.buttonGetOilPrices.Size = new System.Drawing.Size(174, 23);
            this.buttonGetOilPrices.TabIndex = 0;
            this.buttonGetOilPrices.Text = "Get Oil Prices";
            this.buttonGetOilPrices.UseVisualStyleBackColor = true;
            this.buttonGetOilPrices.Click += new System.EventHandler(this.buttonGetOilPrices_Click);
            // 
            // listBoxOilPrices_Teboil
            // 
            this.listBoxOilPrices_Teboil.FormattingEnabled = true;
            this.listBoxOilPrices_Teboil.Location = new System.Drawing.Point(38, 29);
            this.listBoxOilPrices_Teboil.Name = "listBoxOilPrices_Teboil";
            this.listBoxOilPrices_Teboil.Size = new System.Drawing.Size(153, 264);
            this.listBoxOilPrices_Teboil.TabIndex = 1;
            // 
            // listBoxOilPrices_Lampopuisto
            // 
            this.listBoxOilPrices_Lampopuisto.FormattingEnabled = true;
            this.listBoxOilPrices_Lampopuisto.Location = new System.Drawing.Point(214, 29);
            this.listBoxOilPrices_Lampopuisto.Name = "listBoxOilPrices_Lampopuisto";
            this.listBoxOilPrices_Lampopuisto.Size = new System.Drawing.Size(153, 264);
            this.listBoxOilPrices_Lampopuisto.TabIndex = 2;
            // 
            // listBoxOilPrices_Neste
            // 
            this.listBoxOilPrices_Neste.FormattingEnabled = true;
            this.listBoxOilPrices_Neste.Location = new System.Drawing.Point(397, 29);
            this.listBoxOilPrices_Neste.Name = "listBoxOilPrices_Neste";
            this.listBoxOilPrices_Neste.Size = new System.Drawing.Size(153, 264);
            this.listBoxOilPrices_Neste.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Teboil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lampöpuisto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Neste";
            // 
            // buttonStartReadingPrices
            // 
            this.buttonStartReadingPrices.Location = new System.Drawing.Point(590, 349);
            this.buttonStartReadingPrices.Name = "buttonStartReadingPrices";
            this.buttonStartReadingPrices.Size = new System.Drawing.Size(174, 27);
            this.buttonStartReadingPrices.TabIndex = 7;
            this.buttonStartReadingPrices.Text = "Start reading prices continuously";
            this.buttonStartReadingPrices.UseVisualStyleBackColor = true;
            this.buttonStartReadingPrices.Click += new System.EventHandler(this.buttonStartReadingPrices_Click);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartReadingPrices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOilPrices_Neste);
            this.Controls.Add(this.listBoxOilPrices_Lampopuisto);
            this.Controls.Add(this.listBoxOilPrices_Teboil);
            this.Controls.Add(this.buttonGetOilPrices);
            this.Name = "Application";
            this.Text = "Oil prices tracker application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetOilPrices;
        private System.Windows.Forms.ListBox listBoxOilPrices_Teboil;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBoxOilPrices_Lampopuisto;
        private System.Windows.Forms.ListBox listBoxOilPrices_Neste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStartReadingPrices;
    }
}

