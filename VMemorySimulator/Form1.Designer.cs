namespace VMemorySimulator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.t_pm = new System.Windows.Forms.TextBox();
            this.t_la = new System.Windows.Forms.TextBox();
            this.t_page = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t_sm = new System.Windows.Forms.TextBox();
            this.t_pi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listScript = new System.Windows.Forms.ListView();
            this.Process = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableView1 = new VMemorySimulator.view.TableView();
            this.memoryView2 = new VMemorySimulator.view.MemoryView();
            this.memoryView1 = new VMemorySimulator.view.MemoryView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Page";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logic Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primary Memory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "pages";
            // 
            // t_pm
            // 
            this.t_pm.Location = new System.Drawing.Point(133, 139);
            this.t_pm.Name = "t_pm";
            this.t_pm.Size = new System.Drawing.Size(60, 20);
            this.t_pm.TabIndex = 5;
            this.t_pm.Text = "10";
            // 
            // t_la
            // 
            this.t_la.Location = new System.Drawing.Point(15, 178);
            this.t_la.Name = "t_la";
            this.t_la.Size = new System.Drawing.Size(60, 20);
            this.t_la.TabIndex = 6;
            this.t_la.Text = "5";
            // 
            // t_page
            // 
            this.t_page.Location = new System.Drawing.Point(15, 139);
            this.t_page.Name = "t_page";
            this.t_page.Size = new System.Drawing.Size(60, 20);
            this.t_page.TabIndex = 7;
            this.t_page.Text = "50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Secondary Memory (Max)";
            // 
            // t_sm
            // 
            this.t_sm.Location = new System.Drawing.Point(133, 178);
            this.t_sm.Name = "t_sm";
            this.t_sm.Size = new System.Drawing.Size(60, 20);
            this.t_sm.TabIndex = 9;
            this.t_sm.Text = "20";
            // 
            // t_pi
            // 
            this.t_pi.Location = new System.Drawing.Point(15, 217);
            this.t_pi.Name = "t_pi";
            this.t_pi.Size = new System.Drawing.Size(60, 20);
            this.t_pi.TabIndex = 11;
            this.t_pi.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Process Image";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LRU",
            "Clock"});
            this.comboBox1.Location = new System.Drawing.Point(15, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(242, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Substitution Algorithm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Size Configuration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Process Script Path";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 26);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(210, 20);
            this.textBox6.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 17;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(133, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 33);
            this.button2.TabIndex = 18;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Primary Memory Block";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(289, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Script Execution";
            // 
            // listScript
            // 
            this.listScript.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Process,
            this.Command,
            this.Address});
            this.listScript.Location = new System.Drawing.Point(278, 25);
            this.listScript.Name = "listScript";
            this.listScript.Size = new System.Drawing.Size(145, 211);
            this.listScript.TabIndex = 20;
            this.listScript.UseCompatibleStateImageBehavior = false;
            this.listScript.View = System.Windows.Forms.View.Details;
            // 
            // Process
            // 
            this.Process.Text = "P";
            this.Process.Width = 33;
            // 
            // Command
            // 
            this.Command.Text = "Cmd";
            this.Command.Width = 48;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(199, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "pages";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 347);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Secondary Memory Block";
            // 
            // tableView1
            // 
            this.tableView1.Location = new System.Drawing.Point(15, 439);
            this.tableView1.Name = "tableView1";
            this.tableView1.SelectedIndex = 0;
            this.tableView1.Size = new System.Drawing.Size(408, 155);
            this.tableView1.TabIndex = 0;
            // 
            // memoryView2
            // 
            this.memoryView2.BackColor = System.Drawing.Color.Transparent;
            this.memoryView2.Location = new System.Drawing.Point(15, 363);
            this.memoryView2.Name = "memoryView2";
            this.memoryView2.Size = new System.Drawing.Size(408, 70);
            this.memoryView2.TabIndex = 27;
            // 
            // memoryView1
            // 
            this.memoryView1.BackColor = System.Drawing.Color.Transparent;
            this.memoryView1.Location = new System.Drawing.Point(15, 274);
            this.memoryView1.Name = "memoryView1";
            this.memoryView1.Size = new System.Drawing.Size(408, 70);
            this.memoryView1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 608);
            this.Controls.Add(this.tableView1);
            this.Controls.Add(this.memoryView2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.memoryView1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listScript);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.t_pi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t_sm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_page);
            this.Controls.Add(this.t_la);
            this.Controls.Add(this.t_pm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Virtual Memory Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_pm;
        private System.Windows.Forms.TextBox t_la;
        private System.Windows.Forms.TextBox t_page;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_sm;
        private System.Windows.Forms.TextBox t_pi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listScript;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader Process;
        private System.Windows.Forms.ColumnHeader Command;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.Label label13;
        private view.MemoryView memoryView1;
        private System.Windows.Forms.Label label14;
        private view.MemoryView memoryView2;
        private view.TableView tableView1;
    }
}

