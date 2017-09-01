using MVVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.ViewModels
{
    class PageEightViewModel : WorkspaceViewModel
    {
        public string Logger
        {
            get
            {
                return m_logger;
            }
            set
            {
                m_logger = value;
                base.OnPropertyChanged(() => Logger);
            }
        }
        string m_logger = default(string);

        public string Channel
        {
            get
            {
                return m_Channel;
            }
            set
            {
                m_Channel = value;
                base.OnPropertyChanged(() => Channel);
            }
        }
        string m_Channel = default(string);

        public string Token
        {
            get
            {
                return m_Token;
            }
            set
            {
                m_Token = value;
                base.OnPropertyChanged(() => Token);
            }
        }
        string m_Token = default(string);

        public DateTime StartDate
        {
            get
            {
                return m_Start;
            }
            set
            {
                m_Start = value;
                base.OnPropertyChanged(() => StartDate);
            }
        }
        DateTime m_Start = default(DateTime);

        public DateTime EndDate
        {
            get
            {
                return m_End;
            }
            set
            {
                m_End = value;
                base.OnPropertyChanged(() => EndDate);
            }
        }
        DateTime m_End = default(DateTime);

        public string Result { get { return m_Result; } set { m_Result = value; base.OnPropertyChanged(() => Result); } }
        string m_Result = default(string);

        public CommandViewModel Send
        {
            get { return m_Send; }
            set
            {
                m_Send = value;
                base.OnPropertyChanged(() => Send);
            }
        }
        CommandViewModel m_Send = default(CommandViewModel);


        public PageEightViewModel()
        {
            Logger = "998815";
            Channel = "D1a";
            Token = "884bd453-b4a0-44ef-9af5-8f7cc7e587c8";
            StartDate = new DateTime(2016, 5, 30);
            EndDate = new DateTime(2016, 5, 31);
            Send = new CommandViewModel
            {
                DisplayName = "Send",
                Description = "Send",
                Command = new RelayCommand(p => SendRequest())
            };
        }

        private void SendRequest()
        {
            var request = WebRequest.Create(string.Format("http://decode.primayer.com/api/xilog/getmeter?siteID={0}&channelID={1}&token={2}&startDate={3}&endDate={4}&timeWindowStart&timeWindowEnd", Logger, Channel, Token, StartDate.ToString("MM/dd/yyyy"), EndDate.ToString("MM/dd/yyyy")));
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.Timeout = System.Threading.Timeout.Infinite;

            try
            {
                WebResponse response = request.GetResponse();

                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                // Display the content.
                Console.WriteLine(responseFromServer);

                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                Result = responseFromServer.Replace(",", "\r\n");
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }
    }
}
