
namespace Indiv2
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.twoLightsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.downWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.upWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.rightWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.leftWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.backWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.frontWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.smallCubeControls = new System.Windows.Forms.GroupBox();
            this.bigCubeControls = new System.Windows.Forms.GroupBox();
            this.sphereControls = new System.Windows.Forms.GroupBox();
            this.secondLightBoxControls = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zUpDown = new System.Windows.Forms.NumericUpDown();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.smallCubeSpecularityRadioButton = new System.Windows.Forms.RadioButton();
            this.smallCubeTransparencyRadioButton = new System.Windows.Forms.RadioButton();
            this.smallCubeRegularRadioButton = new System.Windows.Forms.RadioButton();
            this.bigCubeRegularRadioButton = new System.Windows.Forms.RadioButton();
            this.bigCubeTransparencyRadioButton = new System.Windows.Forms.RadioButton();
            this.bigCubeSpecularityRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereRegularRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereTransparencyRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereSpecularityRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.smallCubeControls.SuspendLayout();
            this.bigCubeControls.SuspendLayout();
            this.sphereControls.SuspendLayout();
            this.secondLightBoxControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(20, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1408, 1388);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1688, 279);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 790);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // twoLightsCheckBox
            // 
            this.twoLightsCheckBox.AutoSize = true;
            this.twoLightsCheckBox.Location = new System.Drawing.Point(1687, 25);
            this.twoLightsCheckBox.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.twoLightsCheckBox.Name = "twoLightsCheckBox";
            this.twoLightsCheckBox.Size = new System.Drawing.Size(181, 36);
            this.twoLightsCheckBox.TabIndex = 4;
            this.twoLightsCheckBox.Text = "2 источника";
            this.twoLightsCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.downWallSpecularCB);
            this.groupBox3.Controls.Add(this.upWallSpecularCB);
            this.groupBox3.Controls.Add(this.rightWallSpecularCB);
            this.groupBox3.Controls.Add(this.leftWallSpecularCB);
            this.groupBox3.Controls.Add(this.backWallSpecularCB);
            this.groupBox3.Controls.Add(this.frontWallSpecularCB);
            this.groupBox3.Location = new System.Drawing.Point(1452, 655);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox3.Size = new System.Drawing.Size(226, 414);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Зеркальность стен";
            // 
            // downWallSpecularCB
            // 
            this.downWallSpecularCB.AutoSize = true;
            this.downWallSpecularCB.Location = new System.Drawing.Point(13, 357);
            this.downWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.downWallSpecularCB.Name = "downWallSpecularCB";
            this.downWallSpecularCB.Size = new System.Drawing.Size(133, 36);
            this.downWallSpecularCB.TabIndex = 0;
            this.downWallSpecularCB.Text = "Нижняя";
            this.downWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // upWallSpecularCB
            // 
            this.upWallSpecularCB.AutoSize = true;
            this.upWallSpecularCB.Location = new System.Drawing.Point(13, 300);
            this.upWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.upWallSpecularCB.Name = "upWallSpecularCB";
            this.upWallSpecularCB.Size = new System.Drawing.Size(136, 36);
            this.upWallSpecularCB.TabIndex = 0;
            this.upWallSpecularCB.Text = "Верхняя";
            this.upWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // rightWallSpecularCB
            // 
            this.rightWallSpecularCB.AutoSize = true;
            this.rightWallSpecularCB.Location = new System.Drawing.Point(13, 244);
            this.rightWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rightWallSpecularCB.Name = "rightWallSpecularCB";
            this.rightWallSpecularCB.Size = new System.Drawing.Size(126, 36);
            this.rightWallSpecularCB.TabIndex = 0;
            this.rightWallSpecularCB.Text = "Правая";
            this.rightWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // leftWallSpecularCB
            // 
            this.leftWallSpecularCB.AutoSize = true;
            this.leftWallSpecularCB.Location = new System.Drawing.Point(13, 187);
            this.leftWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.leftWallSpecularCB.Name = "leftWallSpecularCB";
            this.leftWallSpecularCB.Size = new System.Drawing.Size(112, 36);
            this.leftWallSpecularCB.TabIndex = 0;
            this.leftWallSpecularCB.Text = "Левая";
            this.leftWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // backWallSpecularCB
            // 
            this.backWallSpecularCB.AutoSize = true;
            this.backWallSpecularCB.Location = new System.Drawing.Point(13, 130);
            this.backWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.backWallSpecularCB.Name = "backWallSpecularCB";
            this.backWallSpecularCB.Size = new System.Drawing.Size(122, 36);
            this.backWallSpecularCB.TabIndex = 0;
            this.backWallSpecularCB.Text = "Задняя";
            this.backWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // frontWallSpecularCB
            // 
            this.frontWallSpecularCB.AutoSize = true;
            this.frontWallSpecularCB.Location = new System.Drawing.Point(13, 74);
            this.frontWallSpecularCB.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.frontWallSpecularCB.Name = "frontWallSpecularCB";
            this.frontWallSpecularCB.Size = new System.Drawing.Size(154, 36);
            this.frontWallSpecularCB.TabIndex = 0;
            this.frontWallSpecularCB.Text = "Передняя";
            this.frontWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // smallCubeControls
            // 
            this.smallCubeControls.Controls.Add(this.smallCubeRegularRadioButton);
            this.smallCubeControls.Controls.Add(this.smallCubeTransparencyRadioButton);
            this.smallCubeControls.Controls.Add(this.smallCubeSpecularityRadioButton);
            this.smallCubeControls.Location = new System.Drawing.Point(1452, 25);
            this.smallCubeControls.Name = "smallCubeControls";
            this.smallCubeControls.Size = new System.Drawing.Size(226, 200);
            this.smallCubeControls.TabIndex = 6;
            this.smallCubeControls.TabStop = false;
            this.smallCubeControls.Text = "Малый куб";
            // 
            // bigCubeControls
            // 
            this.bigCubeControls.Controls.Add(this.bigCubeRegularRadioButton);
            this.bigCubeControls.Controls.Add(this.bigCubeTransparencyRadioButton);
            this.bigCubeControls.Controls.Add(this.bigCubeSpecularityRadioButton);
            this.bigCubeControls.Location = new System.Drawing.Point(1452, 231);
            this.bigCubeControls.Name = "bigCubeControls";
            this.bigCubeControls.Size = new System.Drawing.Size(226, 208);
            this.bigCubeControls.TabIndex = 7;
            this.bigCubeControls.TabStop = false;
            this.bigCubeControls.Text = "Большой куб";
            // 
            // sphereControls
            // 
            this.sphereControls.Controls.Add(this.sphereRegularRadioButton);
            this.sphereControls.Controls.Add(this.sphereTransparencyRadioButton);
            this.sphereControls.Controls.Add(this.sphereSpecularityRadioButton);
            this.sphereControls.Location = new System.Drawing.Point(1452, 445);
            this.sphereControls.Name = "sphereControls";
            this.sphereControls.Size = new System.Drawing.Size(226, 200);
            this.sphereControls.TabIndex = 8;
            this.sphereControls.TabStop = false;
            this.sphereControls.Text = "Сфера";
            // 
            // secondLightBoxControls
            // 
            this.secondLightBoxControls.Controls.Add(this.label3);
            this.secondLightBoxControls.Controls.Add(this.label2);
            this.secondLightBoxControls.Controls.Add(this.label1);
            this.secondLightBoxControls.Controls.Add(this.zUpDown);
            this.secondLightBoxControls.Controls.Add(this.yUpDown);
            this.secondLightBoxControls.Controls.Add(this.xUpDown);
            this.secondLightBoxControls.Location = new System.Drawing.Point(1687, 71);
            this.secondLightBoxControls.Name = "secondLightBoxControls";
            this.secondLightBoxControls.Size = new System.Drawing.Size(226, 200);
            this.secondLightBoxControls.TabIndex = 9;
            this.secondLightBoxControls.TabStop = false;
            this.secondLightBoxControls.Text = "2-й источник света";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // zUpDown
            // 
            this.zUpDown.Location = new System.Drawing.Point(83, 140);
            this.zUpDown.Name = "zUpDown";
            this.zUpDown.Size = new System.Drawing.Size(88, 39);
            this.zUpDown.TabIndex = 2;
            // 
            // yUpDown
            // 
            this.yUpDown.Location = new System.Drawing.Point(83, 95);
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(88, 39);
            this.yUpDown.TabIndex = 1;
            // 
            // xUpDown
            // 
            this.xUpDown.Location = new System.Drawing.Point(83, 50);
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(88, 39);
            this.xUpDown.TabIndex = 0;
            // 
            // smallCubeSpecularityRadioButton
            // 
            this.smallCubeSpecularityRadioButton.AutoSize = true;
            this.smallCubeSpecularityRadioButton.Location = new System.Drawing.Point(13, 56);
            this.smallCubeSpecularityRadioButton.Name = "smallCubeSpecularityRadioButton";
            this.smallCubeSpecularityRadioButton.Size = new System.Drawing.Size(179, 36);
            this.smallCubeSpecularityRadioButton.TabIndex = 3;
            this.smallCubeSpecularityRadioButton.TabStop = true;
            this.smallCubeSpecularityRadioButton.Text = "Зеркальный";
            this.smallCubeSpecularityRadioButton.UseVisualStyleBackColor = true;
            // 
            // smallCubeTransparencyRadioButton
            // 
            this.smallCubeTransparencyRadioButton.AutoSize = true;
            this.smallCubeTransparencyRadioButton.Location = new System.Drawing.Point(11, 96);
            this.smallCubeTransparencyRadioButton.Name = "smallCubeTransparencyRadioButton";
            this.smallCubeTransparencyRadioButton.Size = new System.Drawing.Size(186, 36);
            this.smallCubeTransparencyRadioButton.TabIndex = 4;
            this.smallCubeTransparencyRadioButton.TabStop = true;
            this.smallCubeTransparencyRadioButton.Text = "Прозрачный";
            this.smallCubeTransparencyRadioButton.UseVisualStyleBackColor = true;
            // 
            // smallCubeRegularRadioButton
            // 
            this.smallCubeRegularRadioButton.AutoSize = true;
            this.smallCubeRegularRadioButton.Location = new System.Drawing.Point(11, 138);
            this.smallCubeRegularRadioButton.Name = "smallCubeRegularRadioButton";
            this.smallCubeRegularRadioButton.Size = new System.Drawing.Size(153, 36);
            this.smallCubeRegularRadioButton.TabIndex = 5;
            this.smallCubeRegularRadioButton.TabStop = true;
            this.smallCubeRegularRadioButton.Text = "Обычный";
            this.smallCubeRegularRadioButton.UseVisualStyleBackColor = true;
            // 
            // bigCubeRegularRadioButton
            // 
            this.bigCubeRegularRadioButton.AutoSize = true;
            this.bigCubeRegularRadioButton.Location = new System.Drawing.Point(13, 129);
            this.bigCubeRegularRadioButton.Name = "bigCubeRegularRadioButton";
            this.bigCubeRegularRadioButton.Size = new System.Drawing.Size(153, 36);
            this.bigCubeRegularRadioButton.TabIndex = 8;
            this.bigCubeRegularRadioButton.TabStop = true;
            this.bigCubeRegularRadioButton.Text = "Обычный";
            this.bigCubeRegularRadioButton.UseVisualStyleBackColor = true;
            // 
            // bigCubeTransparencyRadioButton
            // 
            this.bigCubeTransparencyRadioButton.AutoSize = true;
            this.bigCubeTransparencyRadioButton.Location = new System.Drawing.Point(13, 87);
            this.bigCubeTransparencyRadioButton.Name = "bigCubeTransparencyRadioButton";
            this.bigCubeTransparencyRadioButton.Size = new System.Drawing.Size(186, 36);
            this.bigCubeTransparencyRadioButton.TabIndex = 7;
            this.bigCubeTransparencyRadioButton.TabStop = true;
            this.bigCubeTransparencyRadioButton.Text = "Прозрачный";
            this.bigCubeTransparencyRadioButton.UseVisualStyleBackColor = true;
            // 
            // bigCubeSpecularityRadioButton
            // 
            this.bigCubeSpecularityRadioButton.AutoSize = true;
            this.bigCubeSpecularityRadioButton.Location = new System.Drawing.Point(15, 47);
            this.bigCubeSpecularityRadioButton.Name = "bigCubeSpecularityRadioButton";
            this.bigCubeSpecularityRadioButton.Size = new System.Drawing.Size(179, 36);
            this.bigCubeSpecularityRadioButton.TabIndex = 6;
            this.bigCubeSpecularityRadioButton.TabStop = true;
            this.bigCubeSpecularityRadioButton.Text = "Зеркальный";
            this.bigCubeSpecularityRadioButton.UseVisualStyleBackColor = true;
            // 
            // sphereRegularRadioButton
            // 
            this.sphereRegularRadioButton.AutoSize = true;
            this.sphereRegularRadioButton.Location = new System.Drawing.Point(11, 125);
            this.sphereRegularRadioButton.Name = "sphereRegularRadioButton";
            this.sphereRegularRadioButton.Size = new System.Drawing.Size(153, 36);
            this.sphereRegularRadioButton.TabIndex = 11;
            this.sphereRegularRadioButton.TabStop = true;
            this.sphereRegularRadioButton.Text = "Обычный";
            this.sphereRegularRadioButton.UseVisualStyleBackColor = true;
            // 
            // sphereTransparencyRadioButton
            // 
            this.sphereTransparencyRadioButton.AutoSize = true;
            this.sphereTransparencyRadioButton.Location = new System.Drawing.Point(11, 83);
            this.sphereTransparencyRadioButton.Name = "sphereTransparencyRadioButton";
            this.sphereTransparencyRadioButton.Size = new System.Drawing.Size(186, 36);
            this.sphereTransparencyRadioButton.TabIndex = 10;
            this.sphereTransparencyRadioButton.TabStop = true;
            this.sphereTransparencyRadioButton.Text = "Прозрачный";
            this.sphereTransparencyRadioButton.UseVisualStyleBackColor = true;
            // 
            // sphereSpecularityRadioButton
            // 
            this.sphereSpecularityRadioButton.AutoSize = true;
            this.sphereSpecularityRadioButton.Location = new System.Drawing.Point(13, 43);
            this.sphereSpecularityRadioButton.Name = "sphereSpecularityRadioButton";
            this.sphereSpecularityRadioButton.Size = new System.Drawing.Size(179, 36);
            this.sphereSpecularityRadioButton.TabIndex = 9;
            this.sphereSpecularityRadioButton.TabStop = true;
            this.sphereSpecularityRadioButton.Text = "Зеркальный";
            this.sphereSpecularityRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1938, 1440);
            this.Controls.Add(this.secondLightBoxControls);
            this.Controls.Add(this.sphereControls);
            this.Controls.Add(this.bigCubeControls);
            this.Controls.Add(this.smallCubeControls);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.twoLightsCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ray Tracing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.smallCubeControls.ResumeLayout(false);
            this.smallCubeControls.PerformLayout();
            this.bigCubeControls.ResumeLayout(false);
            this.bigCubeControls.PerformLayout();
            this.sphereControls.ResumeLayout(false);
            this.sphereControls.PerformLayout();
            this.secondLightBoxControls.ResumeLayout(false);
            this.secondLightBoxControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox twoLightsCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox frontWallSpecularCB;
        private System.Windows.Forms.CheckBox rightWallSpecularCB;
        private System.Windows.Forms.CheckBox leftWallSpecularCB;
        private System.Windows.Forms.CheckBox backWallSpecularCB;
        private System.Windows.Forms.CheckBox downWallSpecularCB;
        private System.Windows.Forms.CheckBox upWallSpecularCB;
        private System.Windows.Forms.GroupBox smallCubeControls;
        private System.Windows.Forms.GroupBox bigCubeControls;
        private System.Windows.Forms.GroupBox sphereControls;
        private System.Windows.Forms.GroupBox secondLightBoxControls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown zUpDown;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.RadioButton smallCubeRegularRadioButton;
        private System.Windows.Forms.RadioButton smallCubeTransparencyRadioButton;
        private System.Windows.Forms.RadioButton smallCubeSpecularityRadioButton;
        private System.Windows.Forms.RadioButton bigCubeRegularRadioButton;
        private System.Windows.Forms.RadioButton bigCubeTransparencyRadioButton;
        private System.Windows.Forms.RadioButton bigCubeSpecularityRadioButton;
        private System.Windows.Forms.RadioButton sphereRegularRadioButton;
        private System.Windows.Forms.RadioButton sphereTransparencyRadioButton;
        private System.Windows.Forms.RadioButton sphereSpecularityRadioButton;
    }
}

