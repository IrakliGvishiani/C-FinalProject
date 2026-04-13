namespace Calculator
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
            Dot = new Button();
            Equals = new Button();
            Divide = new Button();
            Multiply = new Button();
            Zero = new Button();
            Minus = new Button();
            Nine = new Button();
            Eight = new Button();
            Seven = new Button();
            Plus = new Button();
            Six = new Button();
            Five = new Button();
            Four = new Button();
            Clear = new Button();
            Three = new Button();
            Two = new Button();
            one = new Button();
            ResultBox = new TextBox();
            SuspendLayout();
            // 
            // Dot
            // 
            Dot.BackColor = Color.FromArgb(255, 128, 0);
            Dot.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Dot.Location = new Point(98, 365);
            Dot.Name = "Dot";
            Dot.Size = new Size(80, 59);
            Dot.TabIndex = 35;
            Dot.Text = ".";
            Dot.UseVisualStyleBackColor = false;
            Dot.Click += Number_Click;
            // 
            // Equals
            // 
            Equals.BackColor = Color.Silver;
            Equals.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Equals.Location = new Point(331, 365);
            Equals.Name = "Equals";
            Equals.Size = new Size(121, 59);
            Equals.TabIndex = 34;
            Equals.Text = "=";
            Equals.UseVisualStyleBackColor = false;
            Equals.Click += Equals_Click;
            // 
            // Divide
            // 
            Divide.BackColor = Color.Black;
            Divide.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Divide.ForeColor = Color.FromArgb(255, 128, 0);
            Divide.Location = new Point(514, 365);
            Divide.Name = "Divide";
            Divide.Size = new Size(80, 59);
            Divide.TabIndex = 33;
            Divide.Text = "/";
            Divide.UseVisualStyleBackColor = false;
            Divide.Click += Operation_Click;
            // 
            // Multiply
            // 
            Multiply.BackColor = Color.Black;
            Multiply.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Multiply.ForeColor = Color.FromArgb(255, 128, 0);
            Multiply.Location = new Point(514, 276);
            Multiply.Name = "Multiply";
            Multiply.Size = new Size(80, 59);
            Multiply.TabIndex = 32;
            Multiply.Text = "*";
            Multiply.UseVisualStyleBackColor = false;
            Multiply.Click += Operation_Click;
            // 
            // Zero
            // 
            Zero.BackColor = Color.FromArgb(255, 128, 0);
            Zero.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Zero.Location = new Point(218, 365);
            Zero.Name = "Zero";
            Zero.Size = new Size(80, 59);
            Zero.TabIndex = 31;
            Zero.Text = "0";
            Zero.UseVisualStyleBackColor = false;
            Zero.Click += Number_Click;
            // 
            // Minus
            // 
            Minus.BackColor = Color.Black;
            Minus.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Minus.ForeColor = Color.FromArgb(255, 128, 0);
            Minus.Location = new Point(514, 182);
            Minus.Name = "Minus";
            Minus.Size = new Size(80, 59);
            Minus.TabIndex = 30;
            Minus.Text = "-";
            Minus.UseVisualStyleBackColor = false;
            Minus.Click += Operation_Click;
            // 
            // Nine
            // 
            Nine.BackColor = Color.FromArgb(255, 128, 0);
            Nine.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Nine.Location = new Point(331, 276);
            Nine.Name = "Nine";
            Nine.Size = new Size(80, 59);
            Nine.TabIndex = 29;
            Nine.Text = "9";
            Nine.UseVisualStyleBackColor = false;
            Nine.Click += Number_Click;
            // 
            // Eight
            // 
            Eight.BackColor = Color.FromArgb(255, 128, 0);
            Eight.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Eight.Location = new Point(218, 276);
            Eight.Name = "Eight";
            Eight.Size = new Size(80, 59);
            Eight.TabIndex = 28;
            Eight.Text = "8";
            Eight.UseVisualStyleBackColor = false;
            Eight.Click += Number_Click;
            // 
            // Seven
            // 
            Seven.BackColor = Color.FromArgb(255, 128, 0);
            Seven.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Seven.Location = new Point(98, 276);
            Seven.Name = "Seven";
            Seven.Size = new Size(80, 59);
            Seven.TabIndex = 27;
            Seven.Text = "7";
            Seven.UseVisualStyleBackColor = false;
            Seven.Click += Number_Click;
            // 
            // Plus
            // 
            Plus.BackColor = Color.Black;
            Plus.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Plus.ForeColor = Color.FromArgb(255, 128, 0);
            Plus.Location = new Point(514, 85);
            Plus.Name = "Plus";
            Plus.Size = new Size(80, 59);
            Plus.TabIndex = 26;
            Plus.Text = "+";
            Plus.UseVisualStyleBackColor = false;
            Plus.Click += Operation_Click;
            // 
            // Six
            // 
            Six.BackColor = Color.FromArgb(255, 128, 0);
            Six.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Six.Location = new Point(331, 182);
            Six.Name = "Six";
            Six.Size = new Size(80, 59);
            Six.TabIndex = 25;
            Six.Text = "6";
            Six.UseVisualStyleBackColor = false;
            Six.Click += Number_Click;
            // 
            // Five
            // 
            Five.BackColor = Color.FromArgb(255, 128, 0);
            Five.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Five.Location = new Point(218, 182);
            Five.Name = "Five";
            Five.Size = new Size(80, 59);
            Five.TabIndex = 24;
            Five.Text = "5";
            Five.UseVisualStyleBackColor = false;
            Five.Click += Number_Click;
            // 
            // Four
            // 
            Four.BackColor = Color.FromArgb(255, 128, 0);
            Four.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Four.Location = new Point(98, 182);
            Four.Name = "Four";
            Four.Size = new Size(80, 59);
            Four.TabIndex = 23;
            Four.Text = "4";
            Four.UseVisualStyleBackColor = false;
            Four.Click += Number_Click;
            // 
            // Clear
            // 
            Clear.BackColor = Color.Red;
            Clear.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Clear.ForeColor = Color.Black;
            Clear.Location = new Point(623, 85);
            Clear.Name = "Clear";
            Clear.Size = new Size(80, 59);
            Clear.TabIndex = 22;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = false;
            Clear.Click += Clear_Click;
            // 
            // Three
            // 
            Three.BackColor = Color.FromArgb(255, 128, 0);
            Three.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Three.Location = new Point(331, 85);
            Three.Name = "Three";
            Three.Size = new Size(80, 59);
            Three.TabIndex = 21;
            Three.Text = "3";
            Three.UseVisualStyleBackColor = false;
            Three.ClientSizeChanged += Number_Click;
            Three.Click += Number_Click;
            // 
            // Two
            // 
            Two.BackColor = Color.FromArgb(255, 128, 0);
            Two.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Two.Location = new Point(218, 85);
            Two.Name = "Two";
            Two.Size = new Size(80, 59);
            Two.TabIndex = 20;
            Two.Text = "2";
            Two.UseVisualStyleBackColor = false;
            Two.Click += Number_Click;
            // 
            // one
            // 
            one.BackColor = Color.FromArgb(255, 128, 0);
            one.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            one.Location = new Point(98, 85);
            one.Name = "one";
            one.Size = new Size(80, 59);
            one.TabIndex = 19;
            one.Text = "1";
            one.UseVisualStyleBackColor = false;
            one.Click += Number_Click;
            // 
            // ResultBox
            // 
            ResultBox.Location = new Point(98, 26);
            ResultBox.Name = "ResultBox";
            ResultBox.ReadOnly = true;
            ResultBox.Size = new Size(313, 27);
            ResultBox.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Dot);
            Controls.Add(Equals);
            Controls.Add(Divide);
            Controls.Add(Multiply);
            Controls.Add(Zero);
            Controls.Add(Minus);
            Controls.Add(Nine);
            Controls.Add(Eight);
            Controls.Add(Seven);
            Controls.Add(Plus);
            Controls.Add(Six);
            Controls.Add(Five);
            Controls.Add(Four);
            Controls.Add(Clear);
            Controls.Add(Three);
            Controls.Add(Two);
            Controls.Add(one);
            Controls.Add(ResultBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Dot;
        private Button Equals;
        private Button Divide;
        private Button Multiply;
        private Button Zero;
        private Button Minus;
        private Button Nine;
        private Button Eight;
        private Button Seven;
        private Button Plus;
        private Button Six;
        private Button Five;
        private Button Four;
        private Button Clear;
        private Button Three;
        private Button Two;
        private Button one;
        private TextBox ResultBox;
    }
}
