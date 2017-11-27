using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Statistics
{
	public partial class Form1 : Form
	{
		private string accessLogs = "AccessLogs";
		private string ipsFile = "IPsFolder";
		private string comparison_output = "output"; 
		private String currentAccessLogFile;
		private String currentIPstatsFile;
		private Boolean timeframe_isgiven = false;
		private DateTime datetime_start_used;
		private DateTime datetime_end_used;
        private Boolean outputFile_created = false;
        private FileStream filestreamToWrite; 
		Dictionary<string, string> zuschauerDict = new Dictionary<string, string>();
		Dictionary<string, List<DateTime>> zugriffeDict = new Dictionary<string, List<DateTime>>();

		public Form1()
		{
			InitializeComponent();
            loadConfigurationFile(); 
            Directory.CreateDirectory(accessLogs);
			Directory.CreateDirectory(ipsFile);
			Directory.CreateDirectory(comparison_output);
            tb_starttime_masked.Text = DateTime.Now.Add(new TimeSpan(-6, 0, 0)).ToString(); //Vor 6 Stunden...
            tb_endtime_masked.Text = DateTime.Now.AddHours(4).ToString();
        }


        private void loadConfigurationFile()
        {
            try
            {
  
                tb_server.Text = System.Configuration.ConfigurationSettings.AppSettings["server"];
                tb_login.Text = System.Configuration.ConfigurationSettings.AppSettings["ftp_login"];
                tb_ftp_password_masked.Text = System.Configuration.ConfigurationSettings.AppSettings["ftp_password"];
                tb_filepath_server.Text = System.Configuration.ConfigurationSettings.AppSettings["ftp_accesslog_path"];
                tb_website_pattern.Text = System.Configuration.ConfigurationSettings.AppSettings["compare_website"];
            }
            catch (Exception ex)
            {
               //Just omit this exception 

            }
        }

		private void btn_download_statsfile_Click(object sender, EventArgs e)
		{
			DownloadFileFTP(tb_server.Text, tb_login.Text, tb_ftp_password_masked.Text, tb_filepath_server.Text);
		}

		private void btn_search_ipfile_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory()+"\\"+ipsFile;
				openFileDialog1.Filter = "xml files (*.xml)|*.xml";
				openFileDialog1.RestoreDirectory = true;


				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
                    currentIPstatsFile = openFileDialog1.FileName; 
					tb_ip_datapath.Text = openFileDialog1.FileName;
					logToOutput("IP-XML Datei ausgewählt : " + openFileDialog1.FileName);
				}
		
			}
			catch (Exception ex)
			{
				logToOutput("Problem beim finden der IP-XML Datei: " + ex.ToString());
			}

		}

		private void btn_search_stats_datafile_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory()+"\\"+accessLogs;
				openFileDialog1.Filter = "access log files (*.aclog)|*.aclog";
				openFileDialog1.RestoreDirectory = true;


				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					currentAccessLogFile = openFileDialog1.FileName;
					tb_stats_datapath.Text = openFileDialog1.FileName;
					logToOutput("Access Log Datei ausgewählt : " + openFileDialog1.FileName);

				}
			}
			catch (Exception ex)
			{
				logToOutput("Problem beim Finden der Access Log Datei: " + ex.ToString());
			}
		}

		private void btn_parse_Click(object sender, EventArgs e)
		{

            createOutputFile();
            parseInputTimes();

            if (cb_use_ip_data.Checked)
            {
                parseXMLFile();
                parse_stats_dataFile();
                compareDictionaries();
                closeOutputFile();

            }
            else
            {
                parse_stats_dataFile();
                outputIPusers();
                closeOutputFile();
            }

        }


        private void closeOutputFile()
        {
            if (outputFile_created)
            {
                filestreamToWrite.Close();
            }
        }
        private void createOutputFile()
        {
            try
            {
                if (cb_write_output_to_file.Checked == true)
                {
                    const char pad = '0';
                    string outputfilePath = comparison_output + "/abgleich"
                        + DateTime.Today.Year.ToString().PadLeft(2, pad)
                        + DateTime.Today.Month.ToString().PadLeft(2, pad)
                        + DateTime.Today.Day.ToString().PadLeft(2, pad)
                        + DateTime.Now.Hour.ToString().PadLeft(2, pad)
                        + DateTime.Now.Minute.ToString().PadLeft(2, pad)
                        + DateTime.Now.Second.ToString().PadLeft(2, pad)
                        + ".txt";
                    filestreamToWrite = File.Create(outputfilePath);
                    logToOutput(" Erstelle Outputfile für den Datenabgleich: " + outputfilePath);
                    outputFile_created = true;
                }
                else
                {
                    outputFile_created = false;
                }
            }catch(Exception ex)
            {
                logToOutput("Problem beim erstellen der Outputdatei: " + ex.ToString());
                outputFile_created = false; 
            }
        }
        private void logToOutputFile(String text)
        {
            if (outputFile_created)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text+"\r\n");
                filestreamToWrite.Write(info, 0, info.Length);
            }
        }
		private void parseInputTimes()
		{
			String value_endtime = tb_endtime_masked.Text;
			String value_starttime = tb_starttime_masked.Text;
			DateTime date_starttime;
			Boolean conversionSuccess = DateTime.TryParse(value_starttime, out date_starttime);
			DateTime date_endtime;
			Boolean conversionSuccess2 = DateTime.TryParse(value_endtime, out date_endtime);
			if (!conversionSuccess)
			{
				timeframe_isgiven = false; 
				logToOutput("Keine korrekte Startzeit gegeben, verwende keine Zeitbegrenzung für das Auslesen des Access log");

			}
			else
			{
				timeframe_isgiven = true;
				datetime_start_used = date_starttime;
				if (!conversionSuccess2)
				{
					datetime_end_used = datetime_start_used;
					datetime_end_used.AddHours(6); //TODO was passiert gegen ende des tages hier? 

					logToOutput("Keine korrekte Endzeit gegeben, daher wird eine Endzeit 6 Stunden später als die Startzeit festgesetzt für das Auslesen des Access log");

				}
				else
				{
					datetime_end_used = date_endtime; 
					logToOutput("Angegebene End- und Startzeit sind korrekt");
				}

			}


		}
		private void compareDictionaries()
		{
            string anwesenheitszeit = "Anwesenheit zwischen: " + datetime_start_used.ToString() + " und " + datetime_end_used.ToString();
            logToOutputFile(anwesenheitszeit);
            logToOutput(anwesenheitszeit);

            foreach (KeyValuePair<string, string> entry in zuschauerDict)
			{
				if (zugriffeDict.ContainsKey(entry.Key))
				{
                    string anwesendJa = "Anwesend(Ja)   " + zuschauerDict[entry.Key] + " mit IP " + entry.Key + " Seitenaufrufe: " + zugriffeDict[entry.Key].Count;
                    logToOutputFile(anwesendJa); 
                    logToOutput(anwesendJa);
				}
				else
				{
                    string anwesendNein = "Anwesend(Nein) " + zuschauerDict[entry.Key] + " mit IP " + entry.Key;
                    logToOutputFile(anwesendNein);
                    logToOutput(anwesendNein);

				}
			}
            if (outputFile_created)
            {
                string logoutput_created = "Der Output wurde auch in das File geschrieben " + filestreamToWrite.Name; ;
                logToOutput(logoutput_created);
            }
		}
        private void outputIPusers()
        {
            int count = 0; 
            //Just output the ip users for a dedicated timeframe make a counter 
            foreach (KeyValuePair<string,List<DateTime>> entry in zugriffeDict)
            {
                IpInfo info = GetUserCountryByIp(entry.Key.ToString());
                string infoToAdd = "";
                if (info != null)
                {
                    infoToAdd += info.City + "/";
                    infoToAdd += info.Country + "/";
                    infoToAdd += info.Org + "/";
                    infoToAdd += info.Postal + "/";
                }
                string message = entry.Key.ToString() + " Seitenaufrufe: " + entry.Value.Count()+" Info: "+infoToAdd;
                logToOutput(message);
                logToOutputFile(message);
                count++; 
            }

            if (count == 0)
            {
                string message = "Es gibt einfach keine Benutzer zu dieser Zeit";
                logToOutput(message);
                logToOutputFile(message);
            }

            if (outputFile_created)
            {
                string logoutput_created = "Der Output wurde auch in das File geschrieben " + filestreamToWrite.Name; ;
                logToOutput(logoutput_created);
            }
        }

        private bool parse_stats_dataFile()
		{
			try
			{

				//Delete all previous dictionary data
				zugriffeDict.Clear();

				string line;
				string ipPattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b ";
				string datePatern = @"\[(.*?)\]";
				string websitePattern = tb_website_pattern.Text;//@"/Streaming.html"; //TODO make textbox for this 
				String dateFormatString = "dd/MMMM/yyyy:HH:mm:ss";
                long lineIndex = 0;
                long errorCount = 0;


				Regex regex_ip = new Regex(ipPattern, RegexOptions.IgnoreCase);
				Regex regex_date = new Regex(datePatern, RegexOptions.IgnoreCase);
				Regex regex_website = new Regex(websitePattern, RegexOptions.IgnoreCase);


				// Read the file and display it line by line.
				System.IO.StreamReader file = new System.IO.StreamReader(currentAccessLogFile);
				while ((line = file.ReadLine()) != null)
				{
        
					Match match_website = regex_website.Match(line);
					if (match_website.Length >= 1)
					{
                        try
                        {
                            Match match_ip = regex_ip.Match(line);
                            Match match_date = regex_date.Match(line);

                            //		Value	"[06/May/2017:22:40:14 +0200]"	string
                            //erronous value for date reduced "07/Nov/2017:08:44:27"
                            // Dateformat dd/Month/yyyy:hh:mm:ss + 
                            String dateReduced = match_date.Value.Replace("[", "").Replace("]", "").Split('+')[0].Trim();
                            if (dateReduced.Contains("/Nov/"))
                            {
                                dateReduced = dateReduced.Replace("/Nov/", "/November/");
                            }
                            //This works with test string 
                            DateTime parsedDate = DateTime.ParseExact(dateReduced, dateFormatString, System.Globalization.CultureInfo.InvariantCulture);
                            if (timeframe_isgiven)
                            {
                                if (!(parsedDate >= datetime_start_used && parsedDate <= datetime_end_used))
                                {
                                    continue;
                                }

                            }


                            String key = match_ip.Value.Trim();
                            if (!zugriffeDict.ContainsKey(key))
                            {
                                List<DateTime> times = new List<DateTime>();
                                times.Add(parsedDate);
                                zugriffeDict.Add(key, times);
                            }
                            else
                            {
                                zugriffeDict[key].Add(parsedDate);
                            }
                        }catch(Exception ex)
                        {
                            if (errorCount < 3)
                            {
                                logToOutput("Problem beim Auslesen der Zeile: " + lineIndex + " in Datei: " + currentIPstatsFile + " Exception: " + ex.ToString());
                            }
                            if(errorCount == 3)
                            {
                                logToOutput("Problem beim Auslesen der Zeile: " + lineIndex + " zu viele Fehler, kein log ab hier mehr");
                            }

                            
                            errorCount = errorCount + 1;
                        }

                    }
                    lineIndex = lineIndex + 1;
                }

				file.Close();

				logToOutput("Access Log Datei " + currentAccessLogFile + " erfolgreich ausgelesen ");
				return true;
			}
			catch (Exception ex)
			{
				logToOutput("Problem beim auslesen der Datei :" + currentAccessLogFile +" "+ex.ToString());
				return false;
			}

		}
		private Boolean parseXMLFile()
		{
			try
			{
				//Delete all previous dictionary data
				zuschauerDict.Clear();

				var xml_ips = XDocument.Load(currentIPstatsFile);

				// Query the data and write out a subset of contacts
				var query = from c in xml_ips.Root.Descendants("zuschauer")
							select new
							{
								Ip = c.Element("ip").Value,
								Name = c.Element("name").Value
							};

				foreach (var zuschauer in query)
				{
                    try
                    {
                        zuschauerDict.Add(zuschauer.Ip.Trim(), zuschauer.Name.Trim());
                    }catch(Exception ex)
                    {
                        logToOutput("Problem hinzufügen des XML-elements :"+zuschauer.ToString()+" Exception: " + ex.ToString());
                    }
                }
				logToOutput("XML Datei " + currentIPstatsFile + " erfolgreich ausgelesen ");
				return true; 
			}
			catch (Exception ex)
			{

				logToOutput("Problem beim auslesen der Datei :" + currentIPstatsFile + " Exception: "+ex.ToString());
				return false; 
			}

		}
		private void logToOutput(string text)
		{
			tb_output_rich.AppendText(DateTime.Now + " " + text + "\n");
			tb_output_rich.SelectionStart = tb_output_rich.Text.Length;
			tb_output_rich.ScrollToCaret();
		}


		private void DownloadFileFTP(string ftphost, string username,string password,string filepathServer)
		{
			try
			{

                char pad = '0';
            
                string inputfilepath = accessLogs+"/access_log" 
                    + DateTime.Today.Year.ToString().PadLeft(2,pad)
                    + DateTime.Today.Month.ToString().PadLeft(2, pad) 
                    + DateTime.Today.Day.ToString().PadLeft(2, pad) 
                    + ".aclog";

				string ftpfullpath = "ftp://" + ftphost + filepathServer;

				using (WebClient request = new WebClient())
				{
					request.Credentials = new NetworkCredential(username, password);

					byte[] fileData = request.DownloadData(ftpfullpath);

					using (FileStream file = File.Create(inputfilepath))
					{
						file.Write(fileData, 0, fileData.Length);
						file.Close();
						logToOutput("Download der Datei " + tb_filepath_server + " abgeschlossen. Zielverzeichnis: " + file.Name);
					}

				}
			}
			catch (Exception ex)
			{
				logToOutput("Problem beim FTP Download: " + ex.ToString());
			}
		}


		private void btn_deleteOutput_Click(object sender, EventArgs e)
		{
			tb_output_rich.Text = ""; 
		}

        public static IpInfo GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {

                ipInfo = null;
            }

            return ipInfo;
        }


        public class IpInfo
        {

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("loc")]
            public string Loc { get; set; }

            [JsonProperty("org")]
            public string Org { get; set; }

            [JsonProperty("postal")]
            public string Postal { get; set; }
        }
    }
}
