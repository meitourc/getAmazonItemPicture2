using getAmazonItemPicture2.Exceptions;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace getAmazonItemPicture2
{
    public partial class Form1 : Form
    {

        static string DELIMITER = ","; //CSV読み書き用区切り文字
        static string DOUBLE_QUOTATION = "\""; //ダブルクォーテーション
        static string LINE_FEED_CODE = "\r\n"; //改行コード
        List<string> stringList = new List<string>(); //CSV読み込みデータ格納リスト




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CSV読み取り
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_csv_read_Click(object sender, EventArgs e)
        {
            string path = @""; //入力ファイル名
            char[] delimiter = DELIMITER.ToCharArray(); //区切り文字をまとめる
            string[] strData; //分解後の文字の入れ物
            string strLine; //1行分のデータ

            path = textBox_input.Text;
            path = @"C:\1_project\種市さん\amazon\takuma\takuma\input\input.csv";

            bool fileExists = System.IO.File.Exists(path);
            if (fileExists)
            {

                TextFieldParser parser = new TextFieldParser(path, System.Text.Encoding.Default);
                var dataList = new List<string[]>();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(DELIMITER);
                //while (sr.Peek() >= 0)
                while (parser.EndOfData == false)
                {
                    try
                    {

                        strData = parser.ReadFields();

                        if (parser.LineNumber == 2 && strData[0] == "id")
                        {
                            continue;
                        }

 

                        stringList.AddRange(strData);



                        Console.WriteLine(strData[1]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("データの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                parser.Close();
            }


        }

        /// <summary>
        /// 入力パス設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_input_set_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel) throw new CancelException();
            if (result == DialogResult.No) return;
            textBox_input.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// スクレイピング実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_exec_Click(object sender, EventArgs e)
        {
            // コンソールに出力する
            foreach (string list in stringList)
            {
                //Console.WriteLine("{0} ", list);
                Console.WriteLine(list[0]);
            }

        }
    }
}
