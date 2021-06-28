using System;
using System.Windows.Forms;
using System.IO;

namespace USB_and_Partition_List
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

        private void btnUSBSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا یکی از این گزینه ها را انتخاب کنید");
            }
            else
            {
                var driveName = comboBox1.SelectedItem.ToString();

                var process   = new System.Diagnostics.Process();
                var startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName    = "cmd.exe";
                startInfo.Arguments   = $@"/C attrib -s -h /s /d {driveName}*.*";
                process.StartInfo     = startInfo;
                process.Start();
            }
        }

        private void btnPartitionSumbit_Click(object sender, EventArgs e)
        {
            var driveName = comboBox2.SelectedItem.ToString();

            var process   = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName    = "cmd.exe";
            startInfo.Arguments   = $@"/C attrib -s -h /s /d {driveName}*.*";
            process.StartInfo     = startInfo;
            process.Start();
        }
    }
}