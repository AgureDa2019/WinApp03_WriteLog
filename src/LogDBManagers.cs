using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Net;
using System.Data;

namespace TestWriteLog
{
    class LogDBManagers
    {
        //取得するレコード件数（最大値）：1万
        long GET_RECORD_LIMIT = 10000;

        //MYSQL接続情報
        String con_server { get; set; } = ""; //　SERVER
        String con_userId { get; set; } = "";      //　UID
        String con_userPwd { get; set; } = "";      // PASSWORD
        String con_dataBase { get; set; } = ""; // データベース名
        String con_tableName { get; set; } = "";      // ログテーブル名

        //ログテーブルのレコード追加用（フィールド値）
        String user_id { get; set; } = Environment.MachineName; //マシン名
        String user_name { get; set; } = Environment.UserName;  //ユーザ名
        String created_day { get; set; } = DateTime.Today.ToString("yyyy/MM/dd"); //登録日
        String created { get; set; } = DateTime.Now.ToString(); //登録日時
        String created_user_id { get; set; } = "batch"; //登録者ID
        uint tool_id { get; set; } = 0; //ツールID
        uint form_id { get; set; } = 0;//画面ID
        uint process_code { get; set; } = 0;  //作業コード
        String tool_name { get; set; } = ""; //ツール名
        String form_name { get; set; } = ""; //画面名
        String process_name { get; set; } = "";  //作業内容
        String ip_address { get; set; } = "";  //IPアドレス
        String host_name { get; set; } = Dns.GetHostName();  //ホスト名
        String domain_name { get; set; } = Environment.UserDomainName;  //ドメイン名
        String memo { get; set; } = ""; //コメント

        /// <summary>
        /// 画面入力値からDB接続情報とテーブル名を取得
        /// </summary>
        /// <param name="in_server"></param>
        /// <param name="in_database"></param>
        /// <param name="in_uid"></param>
        /// <param name="in_pwd"></param>
        /// <param name="in_logTable"></param>
        public void SetInputData(string in_server, string in_database,string in_uid, string in_pwd, string in_logTable)
        {
            this.con_server = in_server;
            this.con_dataBase = in_database;
            this.con_userId = in_uid;
            this.con_userPwd = in_pwd;
            this.con_tableName = in_logTable;
        }


        /// <summary>
        /// システム入力値から処理内容を取得
        /// </summary>
        /// <param name="tool_id"></param>
        /// <param name="form_id"></param>
        /// <param name="process_code"></param>
        /// <param name="tool_name"></param>
        /// <param name="form_name"></param>
        /// <param name="process_name"></param>
        public void SetLogItems( uint tool_id, uint form_id, uint process_code
                               , string tool_name , string form_name , string process_name)
        {
            this.tool_id = tool_id;
            this.form_id = form_id;
            this.process_code = process_code;
            this.tool_name = tool_name;
            this.form_name = form_name;
            this.process_name = process_name;
        }

        /// <summary>
        /// 画面入力値チェック　※簡易機能（未入力チェックのみ実装） ## 必要に応じて追加 ###
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public Boolean IsValidationCheckOK(ref string errMsg)
        {
            bool isOK=false;
            StringBuilder msgBuf = new StringBuilder(100);

            // 1)未入力チェック : SERVER
            if (this.con_server.Length == 0)
            {
                msgBuf.AppendLine("・SERVERを入力して下さい。");
            }
            // 2)未入力チェック : DATABASE
            if (this.con_dataBase.Length == 0)
            {
                msgBuf.AppendLine("・DATABASEを入力して下さい。");
            }
            // 3)未入力チェック : UID
            if (this.con_userId.Length == 0)
            {
                msgBuf.AppendLine("・UIDを入力して下さい。");
            }
            // 4)未入力チェック : PASSWORD
            if (this.con_userPwd.Length == 0)
            {
                msgBuf.AppendLine("・PASSWORDを入力して下さい。");
            }
            // 5)未入力チェック : ログテーブル名
            if (this.con_tableName.Length == 0)
            {
                msgBuf.AppendLine("・ログテーブル名を入力して下さい。");
            }

            errMsg = msgBuf.ToString();
            if (errMsg.Length == 0) { isOK = true; }

            return isOK;
        }

        /// <summary>
        /// IPアドレスを取得する
        /// </summary>
        /// <returns></returns>
        public String GetIPAddress()
        {
            // ホスト名を取得する
            string hostname = Dns.GetHostName();
            string ipaddress = "";
            // ホスト名からIPアドレスを取得する
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                ipaddress = address.ToString();
                
                //IPv4 かつ　ローカルIPアドレスではない
                if (ipaddress.IndexOf(".") > 0 && !ipaddress.StartsWith("127."))
                {
                    this.ip_address = ipaddress;
                    break;
                } 
            }
            return this.ip_address;
        }

        /// <summary>
        /// データベース接続後、ログテーブルにレコードを挿入する
        /// </summary>
        /// <param name="resultMsg">実行結果メッセージ（画面出力用）</param>
        /// <param name="logDb">ログテーブル参照用DataTable</param>
        /// <returns>実行結果（OK・NG）</returns>
        public Boolean InsertAccessLog(ref string resultMsg, ref DataTable logDb)
        {
            bool isOK = false;

            //データベース接続情報をセット
            StringBuilder connectStr = new StringBuilder(200);
            connectStr.Append("SERVER=" + con_server + ";");
            connectStr.Append("DATABASE=" + con_dataBase + ";");
            connectStr.Append("UID=" + con_userId + ";");
            connectStr.Append("PASSWORD=" + con_userPwd + ";");

            resultMsg = resultMsg　+ "STEP1　データベースに接続します・・・" + Environment.NewLine;

            using (MySqlConnection con = new MySqlConnection(connectStr.ToString()))
            {
                try
                {
                    //データベース接続
                    con.Open();
                    resultMsg = resultMsg + "STEP2　データベースに接続しました！" + Environment.NewLine;

                    #region info
                    //Console.WriteLine("\n !!! success, connected successfully !!!\n");
                    ////Display connection information
                    //Console.WriteLine("Connection Information:");
                    //Console.WriteLine("\tConnection String:" +
                    //                  con.ConnectionString);
                    //Console.WriteLine("\tConnection Timeout:" +
                    //                  con.ConnectionTimeout);
                    //Console.WriteLine("\tDatabase:" +
                    //                  con.Database);
                    //Console.WriteLine("\tDataSource:" +
                    //                  con.DataSource);
                    //Console.WriteLine("\tServerVersion:" +
                    //                  con.ServerVersion);
                    #endregion info

                    StringBuilder sqlCreate = new StringBuilder(900);
                    sqlCreate.AppendLine("CREATE TABLE IF NOT EXISTS "  + con_tableName  + "(");
                    sqlCreate.AppendLine("id BIGINT AUTO_INCREMENT COMMENT 'ユニークID'");
                    sqlCreate.AppendLine(", user_id VARCHAR(15) COMMENT '利用者ID（マシン名）'");
                    sqlCreate.AppendLine(", user_name VARCHAR(10) COMMENT '利用者名'");
                    sqlCreate.AppendLine(", created_day DATE COMMENT '登録日'");
                    sqlCreate.AppendLine(", created DATETIME COMMENT '登録日時'");
                    sqlCreate.AppendLine(", created_user_id VARCHAR(30) COMMENT '登録者ID（batch）'");
                    sqlCreate.AppendLine(", tool_id MEDIUMINT(3)  UNSIGNED COMMENT 'ツールID'");
                    sqlCreate.AppendLine(", form_id MEDIUMINT(2)  UNSIGNED COMMENT '画面ID'");
                    sqlCreate.AppendLine(", process_code SMALLINT(4)  COMMENT '作業コード'");
                    sqlCreate.AppendLine(", tool_name VARCHAR(50) COMMENT 'ツール名'");
                    sqlCreate.AppendLine(", form_name VARCHAR(50) COMMENT '画面名'");
                    sqlCreate.AppendLine(", process_name VARCHAR(50) COMMENT '作業内容'");
                    sqlCreate.AppendLine(", ip_address VARCHAR(50) COMMENT 'IPアドレス'");
                    sqlCreate.AppendLine(", host_name VARCHAR(63) COMMENT 'ホスト名'");
                    sqlCreate.AppendLine(", domain_name VARCHAR(255) COMMENT 'ドメイン名'");
                    sqlCreate.AppendLine(", memo VARCHAR(255) COMMENT 'コメント'");
                    sqlCreate.AppendLine(", PRIMARY KEY(id)");
                    sqlCreate.AppendLine(")");
                    sqlCreate.AppendLine("ENGINE = InnoDB");
                    sqlCreate.AppendLine("CHARACTER SET = utf8mb4");
                    sqlCreate.AppendLine("COMMENT = 'T001利用ログ'");
                    sqlCreate.AppendLine(";");

                    resultMsg = resultMsg + "STEP2　テーブル接続中です（なければ作成します）" + Environment.NewLine;
                    using (MySqlCommand cmd = new MySqlCommand(sqlCreate.ToString(), con))
                    {
                        // SQLの実行
                        cmd.ExecuteNonQuery();
                        resultMsg = resultMsg + "STEP2　テーブル接続しました！" + Environment.NewLine;
                    }

                    resultMsg = resultMsg + "STEP3　レコード登録中です・・・" + Environment.NewLine;
                    // Insert文のSQLを作成
                    StringBuilder sqlInsert = new StringBuilder(300);
                    sqlInsert.AppendLine("INSERT INTO " + con_tableName);
                    sqlInsert.AppendLine("(user_id,user_name,created_day,created,created_user_id,tool_id,form_id,process_code,tool_name,form_name,process_name,ip_address,host_name,domain_name,memo)");
                    sqlInsert.AppendLine(" VALUES ");
                    sqlInsert.AppendLine("(@user_id,@user_name,@created_day,@created,@created_user_id,@tool_id,@form_id,@process_code,@tool_name,@form_name,@process_name,@ip_address,@host_name,@domain_name,@memo)");
                    sqlInsert.AppendLine(";");

                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert.ToString(), con))
                    {
                        //パラメータ値のセット
                        cmd.Parameters.Add(new MySqlParameter("user_id", this.user_id));
                        cmd.Parameters.Add(new MySqlParameter("user_name", this.user_name));
                        cmd.Parameters.Add(new MySqlParameter("created_day", this.created_day));
                        cmd.Parameters.Add(new MySqlParameter("created", this.created));
                        cmd.Parameters.Add(new MySqlParameter("created_user_id", this.created_user_id));
                        cmd.Parameters.Add(new MySqlParameter("tool_id", this.tool_id));
                        cmd.Parameters.Add(new MySqlParameter("form_id", this.form_id));
                        cmd.Parameters.Add(new MySqlParameter("process_code", this.process_code));
                        cmd.Parameters.Add(new MySqlParameter("tool_name", this.tool_name));
                        cmd.Parameters.Add(new MySqlParameter("form_name", this.form_name));
                        cmd.Parameters.Add(new MySqlParameter("process_name", this.process_name));
                        cmd.Parameters.Add(new MySqlParameter("ip_address", GetIPAddress()));
                        cmd.Parameters.Add(new MySqlParameter("host_name", this.host_name));
                        cmd.Parameters.Add(new MySqlParameter("domain_name", this.domain_name));
                        cmd.Parameters.Add(new MySqlParameter("memo", this.memo));

                        // SQLの実行
                        cmd.ExecuteNonQuery();
                        resultMsg = resultMsg + "STEP3　レコード登録しました！" + Environment.NewLine;
                    }

                    StringBuilder sqlSelect = new StringBuilder(100);
                    sqlSelect.AppendLine("SELECT ");
                    sqlSelect.AppendLine("id,created, user_id,user_name,created_day,created_user_id,tool_id,form_id,process_code,tool_name,form_name,process_name,ip_address,host_name,domain_name,memo");
                    sqlSelect.AppendLine(" FROM " + con_tableName );
                    sqlSelect.AppendLine(" ORDER BY id DESC");
                    sqlSelect.AppendLine(" LIMIT " + GET_RECORD_LIMIT); 　//レコード取得件数に制限をかける

                    resultMsg = resultMsg + "STEP4　レコード参照中です・・・" + Environment.NewLine;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sqlSelect.ToString(), con))
                    {
                        // SQLの実行
                        // 検索
                        da.Fill(logDb);
                        resultMsg = resultMsg + "STEP4　レコード参照しました！（最大行数：" + GET_RECORD_LIMIT +"）" + Environment.NewLine;
                    }

                    isOK = true;
                }
                catch (Exception e)
                {
                    resultMsg = resultMsg + Environment.NewLine
                                + e.Message;                    
                }
                finally
                {
                    con.Close();
                }
            }
                       
                return isOK;
        }


    }
}
