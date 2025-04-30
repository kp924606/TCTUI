namespace TCTForm
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            tctBaseButton1 = new TCTUIComponentsFormsDotNet.TCTModel.TCTBaseButton(components);
            tctCycleButton1 = new TCTUIComponentsFormsDotNet.TCTButton.TCTCycleButton(components);
            SuspendLayout();
            // 
            // tctBaseButton1
            // 
            tctBaseButton1.Location = new Point(12, 24);
            tctBaseButton1.MajorColor = Color.Blue;
            tctBaseButton1.MinorColor = Color.White;
            tctBaseButton1.Name = "tctBaseButton1";
            tctBaseButton1.Size = new Size(130, 82);
            tctBaseButton1.StyleType = TCTUIComponentsFormsDotNet.TCTEnum.TCTControlStyleType.Default;
            tctBaseButton1.TabIndex = 0;
            tctBaseButton1.Text = "tctBaseButton1";
            tctBaseButton1.UseVisualStyleBackColor = false;
            // 
            // tctCycleButton1
            // 
            tctCycleButton1._optimalBorderThickness = 0;
            tctCycleButton1.CircleSize = 90;
            tctCycleButton1.Location = new Point(170, 24);
            tctCycleButton1.MajorColor = Color.Blue;
            tctCycleButton1.MinorColor = Color.White;
            tctCycleButton1.Name = "tctCycleButton1";
            tctCycleButton1.Size = new Size(90, 90);
            tctCycleButton1.StyleType = TCTUIComponentsFormsDotNet.TCTEnum.TCTControlStyleType.DefaultObvious;
            tctCycleButton1.TabIndex = 1;
            tctCycleButton1.Text = "tctCycleButton1";
            tctCycleButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tctCycleButton1);
            Controls.Add(tctBaseButton1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TCTUIComponentsFormsDotNet.TCTModel.TCTBaseButton tctBaseButton1;
        private TCTUIComponentsFormsDotNet.TCTButton.TCTCycleButton tctCycleButton1;
    }
}
