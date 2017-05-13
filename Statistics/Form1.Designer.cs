namespace Statistics
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_filepath_server = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.btn_download_statsfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_server = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.tb_ftp_password_masked = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_search_ipfile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ip_datapath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_output_rich = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_search_stats_datafile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_stats_datapath = new System.Windows.Forms.TextBox();
            this.btn_parse = new System.Windows.Forms.Button();
            this.btn_deleteOutput = new System.Windows.Forms.Button();
            this.tb_starttime_masked = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_endtime_masked = new System.Windows.Forms.MaskedTextBox();
            this.tb_website_pattern = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_write_output_to_file = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_filepath_server);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Controls.Add(this.btn_download_statsfile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_server);
            this.groupBox1.Controls.Add(this.label_password);
            this.groupBox1.Controls.Add(this.tb_ftp_password_masked);
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FTP Einstellungen";
            // 
            // tb_filepath_server
            // 
            this.tb_filepath_server.Location = new System.Drawing.Point(6, 103);
            this.tb_filepath_server.Name = "tb_filepath_server";
            this.tb_filepath_server.Size = new System.Drawing.Size(125, 20);
            this.tb_filepath_server.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Login";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(6, 51);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(125, 20);
            this.tb_login.TabIndex = 4;
            // 
            // btn_download_statsfile
            // 
            this.btn_download_statsfile.Location = new System.Drawing.Point(6, 129);
            this.btn_download_statsfile.Name = "btn_download_statsfile";
            this.btn_download_statsfile.Size = new System.Drawing.Size(159, 23);
            this.btn_download_statsfile.TabIndex = 9;
            this.btn_download_statsfile.Text = "&Statistikdatei herunterladen";
            this.btn_download_statsfile.UseVisualStyleBackColor = true;
            this.btn_download_statsfile.Click += new System.EventHandler(this.btn_download_statsfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(6, 25);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(125, 20);
            this.tb_server.TabIndex = 2;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(137, 80);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(50, 13);
            this.label_password.TabIndex = 1;
            this.label_password.Text = "Passwort";
            // 
            // tb_ftp_password_masked
            // 
            this.tb_ftp_password_masked.Location = new System.Drawing.Point(6, 77);
            this.tb_ftp_password_masked.Name = "tb_ftp_password_masked";
            this.tb_ftp_password_masked.PasswordChar = '*';
            this.tb_ftp_password_masked.Size = new System.Drawing.Size(125, 20);
            this.tb_ftp_password_masked.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_search_ipfile);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_ip_datapath);
            this.groupBox2.Location = new System.Drawing.Point(320, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 87);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datei mit IP Daten";
            // 
            // btn_search_ipfile
            // 
            this.btn_search_ipfile.Location = new System.Drawing.Point(6, 51);
            this.btn_search_ipfile.Name = "btn_search_ipfile";
            this.btn_search_ipfile.Size = new System.Drawing.Size(159, 23);
            this.btn_search_ipfile.TabIndex = 4;
            this.btn_search_ipfile.Text = "&Durchsuchen";
            this.btn_search_ipfile.UseVisualStyleBackColor = true;
            this.btn_search_ipfile.Click += new System.EventHandler(this.btn_search_ipfile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dateipfad";
            // 
            // tb_ip_datapath
            // 
            this.tb_ip_datapath.Location = new System.Drawing.Point(6, 25);
            this.tb_ip_datapath.Name = "tb_ip_datapath";
            this.tb_ip_datapath.ReadOnly = true;
            this.tb_ip_datapath.Size = new System.Drawing.Size(100, 20);
            this.tb_ip_datapath.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_output_rich);
            this.groupBox3.Location = new System.Drawing.Point(19, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1005, 244);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // tb_output_rich
            // 
            this.tb_output_rich.Location = new System.Drawing.Point(12, 19);
            this.tb_output_rich.Name = "tb_output_rich";
            this.tb_output_rich.ReadOnly = true;
            this.tb_output_rich.Size = new System.Drawing.Size(987, 219);
            this.tb_output_rich.TabIndex = 8;
            this.tb_output_rich.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_search_stats_datafile);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tb_stats_datapath);
            this.groupBox4.Location = new System.Drawing.Point(521, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 87);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datei mit Statistiken vom Server";
            // 
            // btn_search_stats_datafile
            // 
            this.btn_search_stats_datafile.Location = new System.Drawing.Point(6, 51);
            this.btn_search_stats_datafile.Name = "btn_search_stats_datafile";
            this.btn_search_stats_datafile.Size = new System.Drawing.Size(159, 23);
            this.btn_search_stats_datafile.TabIndex = 4;
            this.btn_search_stats_datafile.Text = "&Durchsuchen";
            this.btn_search_stats_datafile.UseVisualStyleBackColor = true;
            this.btn_search_stats_datafile.Click += new System.EventHandler(this.btn_search_stats_datafile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dateipfad";
            // 
            // tb_stats_datapath
            // 
            this.tb_stats_datapath.Location = new System.Drawing.Point(6, 25);
            this.tb_stats_datapath.Name = "tb_stats_datapath";
            this.tb_stats_datapath.ReadOnly = true;
            this.tb_stats_datapath.Size = new System.Drawing.Size(100, 20);
            this.tb_stats_datapath.TabIndex = 2;
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(326, 121);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(390, 29);
            this.btn_parse.TabIndex = 11;
            this.btn_parse.Text = "D&atenabgleich";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // btn_deleteOutput
            // 
            this.btn_deleteOutput.Location = new System.Drawing.Point(19, 298);
            this.btn_deleteOutput.Name = "btn_deleteOutput";
            this.btn_deleteOutput.Size = new System.Drawing.Size(159, 23);
            this.btn_deleteOutput.TabIndex = 11;
            this.btn_deleteOutput.Text = "&Output löschen";
            this.btn_deleteOutput.UseVisualStyleBackColor = true;
            this.btn_deleteOutput.Click += new System.EventHandler(this.btn_deleteOutput_Click);
            // 
            // tb_starttime_masked
            // 
            this.tb_starttime_masked.Location = new System.Drawing.Point(6, 19);
            this.tb_starttime_masked.Mask = "00/00/0000 00:00";
            this.tb_starttime_masked.Name = "tb_starttime_masked";
            this.tb_starttime_masked.Size = new System.Drawing.Size(100, 20);
            this.tb_starttime_masked.TabIndex = 12;
            this.tb_starttime_masked.Text = "010120171000";
            this.tb_starttime_masked.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Startzeit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Endzeit";
            // 
            // tb_endtime_masked
            // 
            this.tb_endtime_masked.Location = new System.Drawing.Point(6, 45);
            this.tb_endtime_masked.Mask = "00/00/0000 00:00";
            this.tb_endtime_masked.Name = "tb_endtime_masked";
            this.tb_endtime_masked.Size = new System.Drawing.Size(100, 20);
            this.tb_endtime_masked.TabIndex = 14;
            this.tb_endtime_masked.Text = "010120171500";
            this.tb_endtime_masked.ValidatingType = typeof(System.DateTime);
            // 
            // tb_website_pattern
            // 
            this.tb_website_pattern.Location = new System.Drawing.Point(6, 71);
            this.tb_website_pattern.Name = "tb_website_pattern";
            this.tb_website_pattern.Size = new System.Drawing.Size(100, 20);
            this.tb_website_pattern.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(112, 74);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 13);
            this.label.TabIndex = 15;
            this.label.Text = "Website";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_write_output_to_file);
            this.groupBox5.Controls.Add(this.tb_starttime_masked);
            this.groupBox5.Controls.Add(this.label);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tb_website_pattern);
            this.groupBox5.Controls.Add(this.tb_endtime_masked);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(756, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 123);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Einstellungen für den Datenabgleich";
            // 
            // cb_write_output_to_file
            // 
            this.cb_write_output_to_file.AutoSize = true;
            this.cb_write_output_to_file.Checked = true;
            this.cb_write_output_to_file.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_write_output_to_file.Location = new System.Drawing.Point(6, 97);
            this.cb_write_output_to_file.Name = "cb_write_output_to_file";
            this.cb_write_output_to_file.Size = new System.Drawing.Size(146, 17);
            this.cb_write_output_to_file.TabIndex = 16;
            this.cb_write_output_to_file.Text = "Output in Datei schreiben";
            this.cb_write_output_to_file.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 583);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_deleteOutput);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Streaming IP Statistiken ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_login;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_server;
		private System.Windows.Forms.Label label_password;
		private System.Windows.Forms.MaskedTextBox tb_ftp_password_masked;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn_search_ipfile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_ip_datapath;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RichTextBox tb_output_rich;
		private System.Windows.Forms.Button btn_download_statsfile;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btn_search_stats_datafile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_stats_datapath;
		private System.Windows.Forms.Button btn_parse;
		private System.Windows.Forms.TextBox tb_filepath_server;
		private System.Windows.Forms.Button btn_deleteOutput;
		private System.Windows.Forms.MaskedTextBox tb_starttime_masked;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MaskedTextBox tb_endtime_masked;
		private System.Windows.Forms.TextBox tb_website_pattern;
		private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_write_output_to_file;
    }
}

