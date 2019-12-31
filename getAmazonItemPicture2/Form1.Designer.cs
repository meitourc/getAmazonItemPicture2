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
            this.SuspendLayout();
            // 
            // button_csv_read
            // 
            this.button_csv_read.Location = new System.Drawing.Point(860, 94);
            this.button_csv_read.Name = "button_csv_read";
            this.button_csv_read.Size = new System.Drawing.Size(292, 71);
            this.button_csv_read.TabIndex = 0;
            this.button_csv_read.Text = "CSV読み取り";
            this.button_csv_read.UseVisualStyleBackColor = true;
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(877, 235);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(403, 94);
            this.button_exec.TabIndex = 1;
            this.button_exec.Text = "実行";
            this.button_exec.UseVisualStyleBackColor = true;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(82, 94);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(671, 31);
            this.textBox_input.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 668);
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
    }
}

