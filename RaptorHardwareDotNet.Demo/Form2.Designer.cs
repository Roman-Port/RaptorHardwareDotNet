
namespace RaptorHardwareDotNet.Demo
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
            this.label1 = new System.Windows.Forms.Label();
            this.propName = new System.Windows.Forms.TextBox();
            this.propSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.propCapabilities = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.propMinFreq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.propMaxFreq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.settingFreq = new System.Windows.Forms.NumericUpDown();
            this.settingSampleRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.settingBiasT = new System.Windows.Forms.CheckBox();
            this.settingDirectSampling = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStartRx = new System.Windows.Forms.Button();
            this.btnStopRx = new System.Windows.Forms.Button();
            this.rxInfo = new System.Windows.Forms.Label();
            this.customProperties = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingFreq)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customProperties)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // propName
            // 
            this.propName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propName.Location = new System.Drawing.Point(9, 32);
            this.propName.Name = "propName";
            this.propName.ReadOnly = true;
            this.propName.Size = new System.Drawing.Size(358, 20);
            this.propName.TabIndex = 1;
            // 
            // propSerial
            // 
            this.propSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propSerial.Location = new System.Drawing.Point(9, 71);
            this.propSerial.Name = "propSerial";
            this.propSerial.ReadOnly = true;
            this.propSerial.Size = new System.Drawing.Size(358, 20);
            this.propSerial.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serial";
            // 
            // propCapabilities
            // 
            this.propCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propCapabilities.Location = new System.Drawing.Point(9, 110);
            this.propCapabilities.Name = "propCapabilities";
            this.propCapabilities.ReadOnly = true;
            this.propCapabilities.Size = new System.Drawing.Size(358, 20);
            this.propCapabilities.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Capabilities";
            // 
            // propMinFreq
            // 
            this.propMinFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propMinFreq.Location = new System.Drawing.Point(9, 149);
            this.propMinFreq.Name = "propMinFreq";
            this.propMinFreq.ReadOnly = true;
            this.propMinFreq.Size = new System.Drawing.Size(358, 20);
            this.propMinFreq.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min Frequency";
            // 
            // propMaxFreq
            // 
            this.propMaxFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propMaxFreq.Location = new System.Drawing.Point(9, 188);
            this.propMaxFreq.Name = "propMaxFreq";
            this.propMaxFreq.ReadOnly = true;
            this.propMaxFreq.Size = new System.Drawing.Size(358, 20);
            this.propMaxFreq.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max Frequency";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.propMaxFreq);
            this.groupBox1.Controls.Add(this.propName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.propMinFreq);
            this.groupBox1.Controls.Add(this.propSerial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.propCapabilities);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 216);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.settingDirectSampling);
            this.groupBox2.Controls.Add(this.settingBiasT);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.settingSampleRate);
            this.groupBox2.Controls.Add(this.settingFreq);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 82);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Center Frequency";
            // 
            // settingFreq
            // 
            this.settingFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingFreq.Location = new System.Drawing.Point(9, 32);
            this.settingFreq.Name = "settingFreq";
            this.settingFreq.Size = new System.Drawing.Size(225, 20);
            this.settingFreq.TabIndex = 1;
            this.settingFreq.ThousandsSeparator = true;
            this.settingFreq.ValueChanged += new System.EventHandler(this.settingFreq_ValueChanged);
            // 
            // settingSampleRate
            // 
            this.settingSampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.settingSampleRate.FormattingEnabled = true;
            this.settingSampleRate.Location = new System.Drawing.Point(240, 32);
            this.settingSampleRate.Name = "settingSampleRate";
            this.settingSampleRate.Size = new System.Drawing.Size(127, 21);
            this.settingSampleRate.TabIndex = 2;
            this.settingSampleRate.SelectedIndexChanged += new System.EventHandler(this.settingSampleRate_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Sample Rate";
            // 
            // settingBiasT
            // 
            this.settingBiasT.AutoSize = true;
            this.settingBiasT.Location = new System.Drawing.Point(11, 58);
            this.settingBiasT.Name = "settingBiasT";
            this.settingBiasT.Size = new System.Drawing.Size(56, 17);
            this.settingBiasT.TabIndex = 4;
            this.settingBiasT.Text = "Bias-T";
            this.settingBiasT.UseVisualStyleBackColor = true;
            this.settingBiasT.CheckedChanged += new System.EventHandler(this.settingBiasT_CheckedChanged);
            // 
            // settingDirectSampling
            // 
            this.settingDirectSampling.AutoSize = true;
            this.settingDirectSampling.Location = new System.Drawing.Point(73, 58);
            this.settingDirectSampling.Name = "settingDirectSampling";
            this.settingDirectSampling.Size = new System.Drawing.Size(100, 17);
            this.settingDirectSampling.TabIndex = 5;
            this.settingDirectSampling.Text = "Direct Sampling";
            this.settingDirectSampling.UseVisualStyleBackColor = true;
            this.settingDirectSampling.CheckedChanged += new System.EventHandler(this.settingDirectSampling_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rxInfo);
            this.groupBox3.Controls.Add(this.btnStopRx);
            this.groupBox3.Controls.Add(this.btnStartRx);
            this.groupBox3.Location = new System.Drawing.Point(12, 428);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 50);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receiving";
            // 
            // btnStartRx
            // 
            this.btnStartRx.Location = new System.Drawing.Point(9, 19);
            this.btnStartRx.Name = "btnStartRx";
            this.btnStartRx.Size = new System.Drawing.Size(75, 23);
            this.btnStartRx.TabIndex = 0;
            this.btnStartRx.Text = "Start RX";
            this.btnStartRx.UseVisualStyleBackColor = true;
            this.btnStartRx.Click += new System.EventHandler(this.btnStartRx_Click);
            // 
            // btnStopRx
            // 
            this.btnStopRx.Location = new System.Drawing.Point(90, 19);
            this.btnStopRx.Name = "btnStopRx";
            this.btnStopRx.Size = new System.Drawing.Size(75, 23);
            this.btnStopRx.TabIndex = 1;
            this.btnStopRx.Text = "Stop RX";
            this.btnStopRx.UseVisualStyleBackColor = true;
            this.btnStopRx.Click += new System.EventHandler(this.btnStopRx_Click);
            // 
            // rxInfo
            // 
            this.rxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rxInfo.Location = new System.Drawing.Point(171, 19);
            this.rxInfo.Name = "rxInfo";
            this.rxInfo.Size = new System.Drawing.Size(196, 23);
            this.rxInfo.TabIndex = 2;
            this.rxInfo.Text = "label8";
            this.rxInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customProperties
            // 
            this.customProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customProperties.Location = new System.Drawing.Point(11, 19);
            this.customProperties.Name = "customProperties";
            this.customProperties.Size = new System.Drawing.Size(356, 75);
            this.customProperties.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.customProperties);
            this.groupBox4.Location = new System.Drawing.Point(12, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 100);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom Properties";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 579);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingFreq)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customProperties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox propName;
        private System.Windows.Forms.TextBox propSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox propCapabilities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox propMinFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox propMaxFreq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox settingSampleRate;
        private System.Windows.Forms.NumericUpDown settingFreq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox settingBiasT;
        private System.Windows.Forms.CheckBox settingDirectSampling;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStartRx;
        private System.Windows.Forms.Label rxInfo;
        private System.Windows.Forms.Button btnStopRx;
        private System.Windows.Forms.DataGridView customProperties;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}