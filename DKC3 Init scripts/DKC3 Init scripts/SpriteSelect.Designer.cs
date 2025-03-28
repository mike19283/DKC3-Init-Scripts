namespace DKC3_Init_scripts
{
    partial class SpriteSelect
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
            this.listBox_sprites = new System.Windows.Forms.ListBox();
            this.button_select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_sprites
            // 
            this.listBox_sprites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_sprites.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_sprites.FormattingEnabled = true;
            this.listBox_sprites.ItemHeight = 24;
            this.listBox_sprites.Location = new System.Drawing.Point(0, 0);
            this.listBox_sprites.Name = "listBox_sprites";
            this.listBox_sprites.Size = new System.Drawing.Size(800, 450);
            this.listBox_sprites.TabIndex = 0;
            this.listBox_sprites.DoubleClick += new System.EventHandler(this.listBox_sprites_DoubleClick);
            this.listBox_sprites.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_sprites_MouseDown);
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(711, 408);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Select";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // SpriteSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.listBox_sprites);
            this.Name = "SpriteSelect";
            this.Text = "SpriteSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_sprites;
        private System.Windows.Forms.Button button_select;
    }
}