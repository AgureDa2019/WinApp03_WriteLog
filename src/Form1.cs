using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWriteLog
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //----- 画面の出力値を設定 ----------------
            this.text_SERVER.Text = "";
            this.text_DATABASE.Text = "";
            this.text_UID.Text = "";
            this.text_PWD.Text = "";
            this.text_TableName.Text = "t001_userlog"; //初期値

        }

        /// <summary>
        ///　実行ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            LogDBManagers db_manager = new LogDBManagers();
            string resultMsg ="";
            bool isResultOK=false;

            //ログの処理内容を設定（※ダミー値）
            db_manager.SetLogItems(1, 101, 200, "XXツール", "Main", "LoginOK");

            //入力値を取得（DB接続情報、ログテーブル名）
            db_manager.SetInputData(this.text_SERVER.Text, this.text_DATABASE.Text, this.text_UID.Text, this.text_PWD.Text, this.text_TableName.Text);

            //入力値が取得できているならば
            if( db_manager.IsValidationCheckOK(ref resultMsg))
            {
                DataTable logTable = new DataTable();

                //ログテーブルにレコードを挿入
                isResultOK = db_manager.InsertAccessLog(ref resultMsg, ref logTable);

                //ログテーブルのレコードを表示
                this.dataGridView_logTable.Visible = false;
                this.dataGridView_logTable.DataSource = logTable;
                //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                this.dataGridView_logTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dataGridView_logTable.Visible = true;

                //実行結果のメッセージを設定
                resultMsg = isResultOK  ? "ログ出力に成功しました。" + Environment.NewLine + resultMsg : "ログ出力に失敗しました。" + Environment.NewLine + resultMsg;
            }

            //結果出力
            this.text_ResultMsg.Text = resultMsg;
            //メッセージ出力
            MessageBox.Show(isResultOK ? "ログ出力に成功しました。" : "ログ出力に失敗しました。", "実行結果", MessageBoxButtons.OK, (isResultOK ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

        }

    }
}
