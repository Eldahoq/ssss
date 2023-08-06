using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sim_Afk
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private bool isRunning = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void enableafk_CheckedChanged(object sender, EventArgs e)
        {
            if (enableafk.Checked)
            {
                StartAfkProcess();
            }
            else
            {
                StopAfkProcess();
            }
        }

        private void StartAfkProcess()
        {
            isRunning = true;
            Task.Run(() =>
            {
                while (isRunning)
                {
                    HoldKey("w", 2.00);
                    HoldKey("s", 2.00);
                    HoldKey("a", 2.00);
                    HoldKey("d", 2.00);
                    HoldKey("d", 2.00);
                    HoldKey("a", 2.00);
                }
            });
        }

        private void StopAfkProcess()
        {
            isRunning = false;
        }

        private void HoldKey(string key, double seconds = 1.00)
        {
            // Tuş basma işlemleri burada gerçekleştirilmeli
        }

        private void disableafk_Click(object sender, EventArgs e)
        {
            isRunning = false;
        }
    }
}
