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
            this.DropdownMenu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DropdownMenu
            // 
            this.DropdownMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownMenu.FormattingEnabled = true;
            this.DropdownMenu.Items.AddRange(new object[] {
            "Start",
            "Target",
            "Wall "});
            this.DropdownMenu.Location = new System.Drawing.Point(12, 12);
            this.DropdownMenu.Name = "DropdownMenu";
            this.DropdownMenu.Size = new System.Drawing.Size(121, 21);
            this.DropdownMenu.TabIndex = 0;
            this.DropdownMenu.SelectedValueChanged += new System.EventHandler(this.DropdownMenu_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 620);
            this.Controls.Add(this.DropdownMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ComboBox DropdownMenu;
    }
}

