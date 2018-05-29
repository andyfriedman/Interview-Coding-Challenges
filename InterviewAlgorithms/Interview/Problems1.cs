using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interview
{
    // Winforms threading questions
    public partial class Problems1 : Form
    {
        private CancellationTokenSource _tokenSource;
        private Task _workTask;

        public Problems1()
        {
            InitializeComponent();
        }

        // This method should execute DoWork in the background. The UI needs to remain responsive.
        private void btnStart_Click(object sender, EventArgs e)
        {
            StopWork();
            _tokenSource = new CancellationTokenSource();
            _workTask = Task.Factory.StartNew(DoWork, _tokenSource.Token);
        }

        private void DoWork()
        {
            // Name any problems with this code
            //      It's going to freeze the UI because of the Thread.Sleep called on the UI thread

            //for (int i = 0; i < 100; i++)
            //{
            //    this.txtUpdateMe.Text = i.ToString();
            //    System.Threading.Thread.Sleep(1000);
            //}
           
            for (int i = 0; i < 100; i++)
            {
                if (_tokenSource.Token.IsCancellationRequested)
                {
                    break;
                }

                if (InvokeRequired)
                {
                    this.txtUpdateMe.BeginInvoke(new MethodInvoker(() =>
                    {
                        txtUpdateMe.Text = i.ToString();
                    }));
                }
                else
                {
                    txtUpdateMe.Text = i.ToString();
                }

                System.Threading.Thread.Sleep(1000);
            }
        }
        
        // This method should stop execution of DoWork in the background if it is started.
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Implement code to stop thread here.
            StopWork();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            StopWork();
        }

        private void StopWork()
        {
            _tokenSource?.Cancel();
            _workTask?.Wait();
            _workTask?.Dispose();
            _tokenSource?.Dispose();
            _tokenSource = null;
            _workTask = null;
        }
    }
}
