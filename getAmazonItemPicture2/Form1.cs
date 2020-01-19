using getAmazonItemPicture2.Exceptions;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace getAmazonItemPicture2
{
    public partial class Form1 : Form
    {

        static string DELIMITER = ","; //CSV読み書き用区切り文字
        static string DOUBLE_QUOTATION = "\""; //ダブルクォーテーション
        static string LINE_FEED_CODE = "\r\n"; //改行コード
        string OUTPUT_FOLDAR_PATH = "";
        string INPUT_FILE_PATH = "";
        static List<AmazonItemData> amazonItemDataList = new List<AmazonItemData>(); //CSV読み込みデータ格納リスト
                                                                 //List<string> stringList = new List<string>(); //CSV読み込みデータ格納リスト
        //public static List<string[]> stringList = new List<string[]>();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_exec_control();
            label_output_error1.Visible = false;
        }

        /// <summary>
        /// CSV読み取り
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_csv_read_Click(object sender, EventArgs e)
        {
            char[] delimiter = DELIMITER.ToCharArray(); //区切り文字をまとめる

            INPUT_FILE_PATH = textBox_input.Text;
            string path = INPUT_FILE_PATH;
           // string path = @"C:\1_project\種市さん\amazon\takuma\takuma\input\input4.csv";
            //INPUT_FILE_PATH = path;

            bool fileExists = System.IO.File.Exists(path);
            if (fileExists)
            {

                TextFieldParser parser = new TextFieldParser(path, System.Text.Encoding.Default);
                var dataList = new List<string[]>();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(DELIMITER);

                while (parser.EndOfData == false)
                {
                    try
                    {

                        string[] strData = parser.ReadFields();

                        if (parser.LineNumber == 2 && strData[0] == "id")
                        {
                            continue;
                        }

                        Console.WriteLine(strData[1]);

                        AmazonItemData amazonItemData = new AmazonItemData();
                        amazonItemData.id = strData[0];
                        amazonItemData.asin = strData[1];
                        amazonItemData.pictureName = strData[2];
                        amazonItemData.pictureURL = "";

                        amazonItemDataList.Add(amazonItemData);
                  

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("データの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                parser.Close();
            }
            button_exec_control();


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

            if (Directory.Exists(textBox_output.Text))
            {
                label_output_error1.Visible = false;
            }
            else
            {
                label_output_error1.Visible = true;
                return;
            }

            //
            //if (textBox_output.Text == "") { 
            //    string outputFoldarPath = @".\";
            //}

            foreach (var data in amazonItemDataList)
            {
                //Console.WriteLine(data.id + data.asin + data.pictureName);
                //Console.WriteLine(list[0]);
                string itemPictureUrl = getItemPictureUrl(data.asin);
                string itemPictureHtml = getItemPictureHtml(itemPictureUrl);
                data.pictureURL = scrapingItemPicture(itemPictureHtml,data.id, data.pictureName);
                
            }
            string output_file_path = OUTPUT_FOLDAR_PATH + @"\" + Path.GetFileName(INPUT_FILE_PATH);


            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                output_file_path,
                false,
                System.Text.Encoding.Default);

            string strData = ""; //1行分のデータ

            foreach (var data in amazonItemDataList)
            {
                strData = data.id + DELIMITER
                    + data.asin + DELIMITER
                    + data.pictureName + DELIMITER
                    + data.pictureURL + DELIMITER
                    + data.pictureURL;
                sw.WriteLine(strData);
            }
            sw.Close();
        }

        /// <summary>
        /// asinから画像データ取得
        /// </summary>
        /// <param name="asinData"></param>
        private string getItemPictureUrl(string asinData)
        {
            //asinデータからURLを生成
            string asinUrl = "http://www.amazon.co.jp/dp/" + asinData;
            Console.WriteLine(asinUrl);
            return asinUrl;
        }

        /// <summary>
        /// 引数urlにアクセスした際に取得できるHTMLを返す
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>取得したHTML</returns>
        private string getItemPictureHtml(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            string html = "";
            //指定したURLに対してrequestを投げてresponseを取得
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())

            using (var sr = new StreamReader(resSt, Encoding.UTF8))
            {
                //HTMLを取得する。
                html = sr.ReadToEnd();
            }
            return html;
        }


        private string scrapingItemPicture(string html,string id, string pictureName)
        {

             //string html = getItemPictureHtml(asinUrl);
            html = html.Replace("\r", "").Replace("\n", "");

            string output_foldar_path = OUTPUT_FOLDAR_PATH + @"/" + id + "_" + pictureName;
            String UriForConvert = "";

            string pattern = "";
            pattern = "imgTagWrapperId(.*)</div>";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(html);

            pattern = "src=(\".*\")";
            regex = new Regex(pattern);
            match = regex.Match(match.Value);

            pattern = "(\".*?\")";
            regex = new Regex(pattern);
            match = regex.Match(match.Value);

            System.Console.WriteLine(match.Groups.Count);
            int i = 0;
            foreach (var item in match.Groups)
            {
                Console.WriteLine("\n-------------------------------------------------------------------\n");


                string URI = item.ToString().Trim('\"');
                //Console.WriteLine("match.Groups[" + i + "] : " + item);
                Console.WriteLine(URI);

                SafeCreateDirectory(output_foldar_path);
                string path = output_foldar_path +"/" + pictureName;
                //string path = "../../sample_" + pictureName;

                string[] base64Image = URI.Split(',');

                Console.WriteLine("\n2-------------------------------------------------------------------\n");

                //Console.WriteLine(base64Image[1]);

                UriForConvert = base64Image[1];
                var bytes = Convert.FromBase64String(UriForConvert);



                using (var imageFile = new FileStream(path, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
             

            }
            return UriForConvert;

        }


        /// 指定したパスにディレクトリが存在しない場合
        /// すべてのディレクトリとサブディレクトリを作成します
        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }

        private void button_output_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            //FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            folderBrowserDialog1.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            folderBrowserDialog1.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            folderBrowserDialog1.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                Console.WriteLine(folderBrowserDialog1.SelectedPath);
                textBox_output.Text = folderBrowserDialog1.SelectedPath;;
                OUTPUT_FOLDAR_PATH = textBox_output.Text;
            }
        }


        /// <summary>
        /// 実行ボタンの活性/非活性のコントロール処理
        /// </summary>
        void button_exec_control()
        {
            if(amazonItemDataList.Count > 0 && textBox_input.Text != "" && textBox_output.Text != "")
            {
                button_exec.Enabled = true;
            }
            else { 
                button_exec.Enabled = false;
            }

        }

        /// <summary>
        /// 入力パスの値変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_input_TextChanged(object sender, EventArgs e)
        {
            button_exec_control();
        }

        /// <summary>
        /// 出力パスの値変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_output_TextChanged(object sender, EventArgs e)
        {
            button_exec_control();
        }
    }
}
