namespace DKC3_Init_scripts
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_absPointer = new System.Windows.Forms.RadioButton();
            this.radioButton_pointer = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDown_pointer = new System.Windows.Forms.NumericUpDown();
            this.button_search = new System.Windows.Forms.Button();
            this.listBox_scriptEdit = new System.Windows.Forms.ListBox();
            this.label_scriptAddress = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_empty = new System.Windows.Forms.Button();
            this.numericUpDown_key = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_value = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_spriteSelect = new System.Windows.Forms.Button();
            this.label_sprite = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pointer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_sprite);
            this.groupBox1.Controls.Add(this.radioButton_absPointer);
            this.groupBox1.Controls.Add(this.radioButton_pointer);
            this.groupBox1.Location = new System.Drawing.Point(652, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_absPointer
            // 
            this.radioButton_absPointer.AutoSize = true;
            this.radioButton_absPointer.Location = new System.Drawing.Point(30, 63);
            this.radioButton_absPointer.Name = "radioButton_absPointer";
            this.radioButton_absPointer.Size = new System.Drawing.Size(102, 17);
            this.radioButton_absPointer.TabIndex = 1;
            this.radioButton_absPointer.Text = "Absolute Pointer";
            this.radioButton_absPointer.UseVisualStyleBackColor = true;
            // 
            // radioButton_pointer
            // 
            this.radioButton_pointer.AutoSize = true;
            this.radioButton_pointer.Checked = true;
            this.radioButton_pointer.Location = new System.Drawing.Point(30, 30);
            this.radioButton_pointer.Name = "radioButton_pointer";
            this.radioButton_pointer.Size = new System.Drawing.Size(58, 17);
            this.radioButton_pointer.TabIndex = 0;
            this.radioButton_pointer.TabStop = true;
            this.radioButton_pointer.Text = "Pointer";
            this.radioButton_pointer.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // numericUpDown_pointer
            // 
            this.numericUpDown_pointer.Hexadecimal = true;
            this.numericUpDown_pointer.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_pointer.Location = new System.Drawing.Point(682, 144);
            this.numericUpDown_pointer.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_pointer.Name = "numericUpDown_pointer";
            this.numericUpDown_pointer.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown_pointer.TabIndex = 3;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(682, 182);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 4;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // listBox_scriptEdit
            // 
            this.listBox_scriptEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox_scriptEdit.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_scriptEdit.FormattingEnabled = true;
            this.listBox_scriptEdit.ItemHeight = 21;
            this.listBox_scriptEdit.Location = new System.Drawing.Point(0, 24);
            this.listBox_scriptEdit.Name = "listBox_scriptEdit";
            this.listBox_scriptEdit.Size = new System.Drawing.Size(646, 426);
            this.listBox_scriptEdit.TabIndex = 5;
            this.listBox_scriptEdit.SelectedIndexChanged += new System.EventHandler(this.listBox_scriptEdit_SelectedIndexChanged);
            // 
            // label_scriptAddress
            // 
            this.label_scriptAddress.AutoSize = true;
            this.label_scriptAddress.Location = new System.Drawing.Point(659, 28);
            this.label_scriptAddress.Name = "label_scriptAddress";
            this.label_scriptAddress.Size = new System.Drawing.Size(0, 13);
            this.label_scriptAddress.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_empty
            // 
            this.button_empty.Location = new System.Drawing.Point(682, 415);
            this.button_empty.Name = "button_empty";
            this.button_empty.Size = new System.Drawing.Size(75, 23);
            this.button_empty.TabIndex = 7;
            this.button_empty.Text = "Empty list";
            this.button_empty.UseVisualStyleBackColor = true;
            this.button_empty.Click += new System.EventHandler(this.button_empty_Click);
            // 
            // numericUpDown_key
            // 
            this.numericUpDown_key.Hexadecimal = true;
            this.numericUpDown_key.Location = new System.Drawing.Point(662, 274);
            this.numericUpDown_key.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_key.Name = "numericUpDown_key";
            this.numericUpDown_key.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_key.TabIndex = 8;
            // 
            // numericUpDown_value
            // 
            this.numericUpDown_value.Hexadecimal = true;
            this.numericUpDown_value.Location = new System.Drawing.Point(662, 332);
            this.numericUpDown_value.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_value.Name = "numericUpDown_value";
            this.numericUpDown_value.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_value.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Value";
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(682, 370);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 12;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_spriteSelect
            // 
            this.button_spriteSelect.Location = new System.Drawing.Point(653, 144);
            this.button_spriteSelect.Name = "button_spriteSelect";
            this.button_spriteSelect.Size = new System.Drawing.Size(23, 23);
            this.button_spriteSelect.TabIndex = 13;
            this.button_spriteSelect.UseVisualStyleBackColor = true;
            this.button_spriteSelect.Click += new System.EventHandler(this.button_spriteSelect_Click);
            // 
            // label_sprite
            // 
            this.label_sprite.AutoSize = true;
            this.label_sprite.Location = new System.Drawing.Point(7, 3);
            this.label_sprite.Name = "label_sprite";
            this.label_sprite.Size = new System.Drawing.Size(35, 13);
            this.label_sprite.TabIndex = 2;
            this.label_sprite.Text = "label3";
            // 
            // Form1
            // 
            this.AcceptButton = this.button_search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_spriteSelect);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_value);
            this.Controls.Add(this.numericUpDown_key);
            this.Controls.Add(this.button_empty);
            this.Controls.Add(this.label_scriptAddress);
            this.Controls.Add(this.listBox_scriptEdit);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.numericUpDown_pointer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DKC3 Init Script Viewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pointer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_absPointer;
        private System.Windows.Forms.RadioButton radioButton_pointer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown_pointer;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ListBox listBox_scriptEdit;
        private System.Windows.Forms.Label label_scriptAddress;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_empty;
        private System.Windows.Forms.NumericUpDown numericUpDown_key;
        private System.Windows.Forms.NumericUpDown numericUpDown_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_spriteSelect;
        private System.Windows.Forms.Label label_sprite;
    }
}

