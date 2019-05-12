namespace TestWriteLog
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.tableLayoutPanel_inputArea = new System.Windows.Forms.TableLayoutPanel();
            this.text_SERVER = new System.Windows.Forms.TextBox();
            this.label_server = new System.Windows.Forms.Label();
            this.label_UID = new System.Windows.Forms.Label();
            this.label_DATABASE = new System.Windows.Forms.Label();
            this.label_PWD = new System.Windows.Forms.Label();
            this.text_DATABASE = new System.Windows.Forms.TextBox();
            this.text_UID = new System.Windows.Forms.TextBox();
            this.text_PWD = new System.Windows.Forms.TextBox();
            this.groupBox_inputArea1 = new System.Windows.Forms.GroupBox();
            this.text_ResultMsg = new System.Windows.Forms.TextBox();
            this.dataGridView_logTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.text_InfoTable = new System.Windows.Forms.TextBox();
            this.groupBox_InputArea2 = new System.Windows.Forms.GroupBox();
            this.text_TableName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_inputArea.SuspendLayout();
            this.groupBox_inputArea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_logTable)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox_InputArea2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(232, 202);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(165, 46);
            this.ButtonConnect.TabIndex = 0;
            this.ButtonConnect.Text = "接続＆ログ出力";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // tableLayoutPanel_inputArea
            // 
            this.tableLayoutPanel_inputArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_inputArea.AutoScroll = true;
            this.tableLayoutPanel_inputArea.ColumnCount = 3;
            this.tableLayoutPanel_inputArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.01361F));
            this.tableLayoutPanel_inputArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.9864F));
            this.tableLayoutPanel_inputArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel_inputArea.Controls.Add(this.text_SERVER, 1, 0);
            this.tableLayoutPanel_inputArea.Controls.Add(this.label_server, 0, 0);
            this.tableLayoutPanel_inputArea.Controls.Add(this.label_DATABASE, 0, 1);
            this.tableLayoutPanel_inputArea.Controls.Add(this.label_UID, 0, 2);
            this.tableLayoutPanel_inputArea.Controls.Add(this.text_DATABASE, 1, 1);
            this.tableLayoutPanel_inputArea.Controls.Add(this.text_UID, 1, 2);
            this.tableLayoutPanel_inputArea.Controls.Add(this.text_PWD, 1, 3);
            this.tableLayoutPanel_inputArea.Controls.Add(this.label_PWD, 0, 3);
            this.tableLayoutPanel_inputArea.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel_inputArea.Name = "tableLayoutPanel_inputArea";
            this.tableLayoutPanel_inputArea.RowCount = 4;
            this.tableLayoutPanel_inputArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.21687F));
            this.tableLayoutPanel_inputArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.78313F));
            this.tableLayoutPanel_inputArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel_inputArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_inputArea.Size = new System.Drawing.Size(382, 142);
            this.tableLayoutPanel_inputArea.TabIndex = 1;
            // 
            // text_SERVER
            // 
            this.tableLayoutPanel_inputArea.SetColumnSpan(this.text_SERVER, 2);
            this.text_SERVER.Location = new System.Drawing.Point(99, 3);
            this.text_SERVER.Multiline = true;
            this.text_SERVER.Name = "text_SERVER";
            this.text_SERVER.Size = new System.Drawing.Size(276, 25);
            this.text_SERVER.TabIndex = 1;
            // 
            // label_server
            // 
            this.label_server.AutoEllipsis = true;
            this.label_server.AutoSize = true;
            this.label_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_server.Location = new System.Drawing.Point(3, 0);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(90, 37);
            this.label_server.TabIndex = 0;
            this.label_server.Text = "SERVER";
            this.label_server.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_UID
            // 
            this.label_UID.AutoEllipsis = true;
            this.label_UID.AutoSize = true;
            this.label_UID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_UID.Location = new System.Drawing.Point(3, 69);
            this.label_UID.Name = "label_UID";
            this.label_UID.Size = new System.Drawing.Size(90, 37);
            this.label_UID.TabIndex = 0;
            this.label_UID.Text = "UID";
            this.label_UID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_DATABASE
            // 
            this.label_DATABASE.AutoEllipsis = true;
            this.label_DATABASE.AutoSize = true;
            this.label_DATABASE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DATABASE.Location = new System.Drawing.Point(3, 37);
            this.label_DATABASE.Name = "label_DATABASE";
            this.label_DATABASE.Size = new System.Drawing.Size(90, 32);
            this.label_DATABASE.TabIndex = 2;
            this.label_DATABASE.Text = "DATABASE";
            this.label_DATABASE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_PWD
            // 
            this.label_PWD.AutoEllipsis = true;
            this.label_PWD.AutoSize = true;
            this.label_PWD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PWD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_PWD.Location = new System.Drawing.Point(3, 106);
            this.label_PWD.Name = "label_PWD";
            this.label_PWD.Size = new System.Drawing.Size(90, 36);
            this.label_PWD.TabIndex = 3;
            this.label_PWD.Text = "PASSWORD";
            this.label_PWD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_DATABASE
            // 
            this.tableLayoutPanel_inputArea.SetColumnSpan(this.text_DATABASE, 2);
            this.text_DATABASE.Location = new System.Drawing.Point(99, 40);
            this.text_DATABASE.Multiline = true;
            this.text_DATABASE.Name = "text_DATABASE";
            this.text_DATABASE.Size = new System.Drawing.Size(276, 25);
            this.text_DATABASE.TabIndex = 4;
            // 
            // text_UID
            // 
            this.text_UID.Location = new System.Drawing.Point(99, 72);
            this.text_UID.Multiline = true;
            this.text_UID.Name = "text_UID";
            this.text_UID.Size = new System.Drawing.Size(180, 25);
            this.text_UID.TabIndex = 5;
            // 
            // text_PWD
            // 
            this.text_PWD.Location = new System.Drawing.Point(99, 109);
            this.text_PWD.Multiline = true;
            this.text_PWD.Name = "text_PWD";
            this.text_PWD.Size = new System.Drawing.Size(180, 25);
            this.text_PWD.TabIndex = 6;
            // 
            // groupBox_inputArea1
            // 
            this.groupBox_inputArea1.Controls.Add(this.tableLayoutPanel_inputArea);
            this.groupBox_inputArea1.Location = new System.Drawing.Point(16, 17);
            this.groupBox_inputArea1.Name = "groupBox_inputArea1";
            this.groupBox_inputArea1.Size = new System.Drawing.Size(394, 173);
            this.groupBox_inputArea1.TabIndex = 2;
            this.groupBox_inputArea1.TabStop = false;
            this.groupBox_inputArea1.Text = "MySQL接続先";
            // 
            // text_ResultMsg
            // 
            this.text_ResultMsg.Location = new System.Drawing.Point(22, 265);
            this.text_ResultMsg.Multiline = true;
            this.text_ResultMsg.Name = "text_ResultMsg";
            this.text_ResultMsg.ReadOnly = true;
            this.text_ResultMsg.Size = new System.Drawing.Size(382, 196);
            this.text_ResultMsg.TabIndex = 3;
            this.text_ResultMsg.TabStop = false;
            // 
            // dataGridView_logTable
            // 
            this.dataGridView_logTable.AllowUserToAddRows = false;
            this.dataGridView_logTable.AllowUserToDeleteRows = false;
            this.dataGridView_logTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_logTable.Location = new System.Drawing.Point(3, 34);
            this.dataGridView_logTable.Name = "dataGridView_logTable";
            this.dataGridView_logTable.ReadOnly = true;
            this.dataGridView_logTable.RowTemplate.Height = 24;
            this.dataGridView_logTable.Size = new System.Drawing.Size(508, 396);
            this.dataGridView_logTable.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.text_InfoTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_logTable, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(445, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 441);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // text_InfoTable
            // 
            this.text_InfoTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_InfoTable.Location = new System.Drawing.Point(3, 3);
            this.text_InfoTable.Multiline = true;
            this.text_InfoTable.Name = "text_InfoTable";
            this.text_InfoTable.ReadOnly = true;
            this.text_InfoTable.Size = new System.Drawing.Size(508, 25);
            this.text_InfoTable.TabIndex = 7;
            this.text_InfoTable.TabStop = false;
            this.text_InfoTable.Text = "ログ出力先テーブル";
            this.text_InfoTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox_InputArea2
            // 
            this.groupBox_InputArea2.Controls.Add(this.text_TableName);
            this.groupBox_InputArea2.Location = new System.Drawing.Point(24, 194);
            this.groupBox_InputArea2.Name = "groupBox_InputArea2";
            this.groupBox_InputArea2.Size = new System.Drawing.Size(183, 54);
            this.groupBox_InputArea2.TabIndex = 7;
            this.groupBox_InputArea2.TabStop = false;
            this.groupBox_InputArea2.Text = "ログテーブル名";
            // 
            // text_TableName
            // 
            this.text_TableName.Location = new System.Drawing.Point(13, 22);
            this.text_TableName.Multiline = true;
            this.text_TableName.Name = "text_TableName";
            this.text_TableName.Size = new System.Drawing.Size(158, 25);
            this.text_TableName.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 485);
            this.Controls.Add(this.groupBox_InputArea2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.text_ResultMsg);
            this.Controls.Add(this.groupBox_inputArea1);
            this.Controls.Add(this.ButtonConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "ログ出力";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel_inputArea.ResumeLayout(false);
            this.tableLayoutPanel_inputArea.PerformLayout();
            this.groupBox_inputArea1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_logTable)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox_InputArea2.ResumeLayout(false);
            this.groupBox_InputArea2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_inputArea;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.TextBox text_SERVER;
        private System.Windows.Forms.Label label_UID;
        private System.Windows.Forms.Label label_DATABASE;
        private System.Windows.Forms.Label label_PWD;
        private System.Windows.Forms.TextBox text_DATABASE;
        private System.Windows.Forms.TextBox text_UID;
        private System.Windows.Forms.TextBox text_PWD;
        private System.Windows.Forms.GroupBox groupBox_inputArea1;
        private System.Windows.Forms.TextBox text_ResultMsg;
        private System.Windows.Forms.DataGridView dataGridView_logTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox text_InfoTable;
        private System.Windows.Forms.GroupBox groupBox_InputArea2;
        private System.Windows.Forms.TextBox text_TableName;
    }
}

