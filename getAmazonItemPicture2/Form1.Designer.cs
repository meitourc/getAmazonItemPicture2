namespace getAmazonItemPicture2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_csv_read = new System.Windows.Forms.Button();
            this.button_exec = new System.Windows.Forms.Button();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button_input_set = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.button_output = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_csv_read
            // 
            this.button_csv_read.Location = new System.Drawing.Point(978, 74);
            this.button_csv_read.Name = "button_csv_read";
            this.button_csv_read.Size = new System.Drawing.Size(292, 71);
            this.button_csv_read.TabIndex = 0;
            this.button_csv_read.Text = "CSV読み取り";
            this.button_csv_read.UseVisualStyleBackColor = true;
            this.button_csv_read.Click += new System.EventHandler(this.button_csv_read_Click);
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(919, 294);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(403, 94);
            this.button_exec.TabIndex = 1;
            this.button_exec.Text = "実行";
            this.button_exec.UseVisualStyleBackColor = true;
            this.button_exec.Click += new System.EventHandler(this.button_exec_Click);
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(82, 94);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(671, 31);
            this.textBox_input.TabIndex = 2;
            // 
            // button_input_set
            // 
            this.button_input_set.Location = new System.Drawing.Point(759, 91);
            this.button_input_set.Name = "button_input_set";
            this.button_input_set.Size = new System.Drawing.Size(136, 36);
            this.button_input_set.TabIndex = 3;
            this.button_input_set.Text = "参照";
            this.button_input_set.UseVisualStyleBackColor = true;
            this.button_input_set.Click += new System.EventHandler(this.button_input_set_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(82, 227);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.Size = new System.Drawing.Size(671, 33);
            this.textBox_output.TabIndex = 4;
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(759, 227);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(127, 41);
            this.button_output.TabIndex = 5;
            this.button_output.Text = "出力先";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 668);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.button_input_set);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.button_exec);
            this.Controls.Add(this.button_csv_read);
            this.Name = "Form1";
            this.Text = "Amazon商品画像取得";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_csv_read;
        private System.Windows.Forms.Button button_exec;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button_input_set;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Button button_output;
    }
}

