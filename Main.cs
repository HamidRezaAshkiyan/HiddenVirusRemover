using System;
using System.IO;
using System.Windows.Forms;

namespace HiddenVirusRemover
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            var driveList = DriveInfo.GetDrives();

            foreach (var drive in driveList)
            {
                if (drive.DriveType == DriveType.Removable)
                    comboBox1.Items.Add(drive);

                if (drive.DriveType == DriveType.Fixed)
                    comboBox2.Items.Add(drive);
            }
        }

        private void BtnUSBSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا یکی از این گزینه ها را انتخاب کنید");
            }
            else
            {
                var driveName = comboBox1.SelectedItem.ToString();

                var process = new System.Diagnostics.Process();
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName    = "cmd.exe",
                    Arguments   = $@"/C attrib -s -h /s /d {driveName}*.*"
                };

                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void BtnPartitionSubmit_Click(object sender, EventArgs e)
        {
            var driveName = comboBox2.SelectedItem.ToString();

            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName    = "cmd.exe",
                Arguments   = $@"/C attrib -s -h /s /d {driveName}*.*"
            };

            process.StartInfo = startInfo;
            process.Start();
        }
    }
}