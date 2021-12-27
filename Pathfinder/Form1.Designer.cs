namespace Pathfinder
{
    partial class Form1
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
            this.start_button = new System.Windows.Forms.Button();
            this.type = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.PB_bitmapTest = new System.Windows.Forms.PictureBox();
            this.btn_test1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_bitmapTest)).BeginInit();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.Location = new System.Drawing.Point(24, 38);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(71, 37);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Start",
            "Target",
            "Wall"});
            this.type.Location = new System.Drawing.Point(3, 129);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 21);
            this.type.TabIndex = 1;
            this.type.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(3, 81);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(121, 32);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // PB_bitmapTest
            // 
            this.PB_bitmapTest.Location = new System.Drawing.Point(1181, 176);
            this.PB_bitmapTest.Name = "PB_bitmapTest";
            this.PB_bitmapTest.Size = new System.Drawing.Size(300, 300);
            this.PB_bitmapTest.TabIndex = 3;
            this.PB_bitmapTest.TabStop = false;
            // 
            // btn_test1
            // 
            this.btn_test1.Location = new System.Drawing.Point(1251, 500);
            this.btn_test1.Name = "btn_test1";
            this.btn_test1.Size = new System.Drawing.Size(154, 45);
            this.btn_test1.TabIndex = 4;
            this.btn_test1.Text = "add line";
            this.btn_test1.UseVisualStyleBackColor = true;
            this.btn_test1.Click += new System.EventHandler(this.btn_test1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.btn_test1);
            this.Controls.Add(this.PB_bitmapTest);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.type);
            this.Controls.Add(this.start_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.PB_bitmapTest)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.PictureBox PB_bitmapTest;
        private System.Windows.Forms.Button btn_test1;
    }
}

