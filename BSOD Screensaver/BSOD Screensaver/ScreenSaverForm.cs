using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSOD_Screensaver
{
    public partial class ScreenSaverForm : Form
    {
        private Label label1;
        private Timer timer2;
        private const int HORIZONTAL_MARGIN = 100;
        public Size OptimalLabelSize { get {
            Size windowSize = Screen.PrimaryScreen.Bounds.Size;
            return new Size(windowSize.Width - HORIZONTAL_MARGIN * 2, windowSize.Height);
        } }
        public Point OptimalLabelLocation { get {
            return new Point(HORIZONTAL_MARGIN, 0);
            }
        }

        private Point MouseXY;
        private int ScreenNumber;
        private ImageList imageList1;
        public string mode = "LR";
        private int progressThroughMesssage = 0;
        private string[] message = {
                                       "*** STOP: 0x0000001E  (0xC0000005, 0xF24A447A, 0x00000001, 0x00000000)",
                                       "KMODE_EXCEPTION_NOT_HANDLED",
                                       "",
                                       "*** Address F24A447A base at F24A0000, DateStamp 35825ef8d - wdmaud.sys",
                                       "",
                                       "",
                                       "If this is the first time you've seen this Stop error screen, restart your",
                                       "computer. If this screen appears again, follow these steps:",
                                       "",
                                       "Check to be sure you have adequate disk space. If a driver is identified in",
                                   "the Stop message, disable the driver or check with the manufacturer for",
                                        "driver updates. Try changing video adapters.",
                                        "",
                                        "Check with your hardware vendor for any BIOS updates. Disable BIOS memory",
                                        "options such as caching or shadowing. If you need to use Safe Mode to",
                                        "remove or disable components, restart your computer, press F8 to select",
                                        "Advanced Startup Options, and then select Safe Mode.",
                                        "",
                                        "Refer to your Getting Started manual for more information on troubleshooting",
                                        "Stop errors.",
                                        "",
                                        "Kernel Debugger Using: COM2 (Port 0x2f8, Baud Rate 19200)",
                                        "Beginning dump of physical memory",
                                        "DUMP DUMP DUMPITY DUMP DUMP",
                                        "Physical memory dump complete. Contact your system administrator or",
                                        "technical support group."};

        public ScreenSaverForm(int i)
        {
            InitializeComponent();
            ScreenNumber = i;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            mode = "LR";
            timer2.Start();

            this.Bounds = Screen.AllScreens[ScreenNumber].Bounds;
            Cursor.Hide();
            TopMost = true;
        }

        private void OnMouseEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!MouseXY.IsEmpty)
            {
                if (MouseXY != new Point(e.X, e.Y))
                    Close();
                if (e.Clicks > 0)
                    Close();
            }
            MouseXY = new Point(e.X, e.Y);
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void updateLabelText()
        {
            this.label1.Text = "\n";
            for (int i = 0; i < progressThroughMesssage; i++)
            {
                this.label1.Text += "\n" + message[i];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressThroughMesssage < message.Length)
            {
                progressThroughMesssage++;
                updateLabelText();
            }
        }
    }
}
