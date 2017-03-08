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
    class PageFiveViewModel : WorkspaceViewModel
    {
        public string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                m_Username = value;
                base.OnPropertyChanged(() => Username);
            }
        }
        string m_Username = default(string);

        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
                base.OnPropertyChanged(() => Password);
            }
        }
        string m_Password = default(string);

        public string Result { get { return m_Result; } set { m_Result = value; base.OnPropertyChanged(() => Result); } }string m_Result = default(string);

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


        public PageFiveViewModel()
        {
            Username = "Conference Demo";
            Password = "primayer";

            Send = new CommandViewModel
            {
                DisplayName = "Send",
                Description = "Send",
                Command = new RelayCommand(p => SendRequest())
            };
        }

        private void SendRequest()
        {
            var request = WebRequest.Create(string.Format("http://api.primayer.com/api/xilog/gettoken?username={0}&password={1}", Username, Password));
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

                Result = responseFromServer;
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
        }
    }
}
