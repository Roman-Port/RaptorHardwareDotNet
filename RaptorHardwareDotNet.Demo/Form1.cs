using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaptorHardwareDotNet.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IRaptorHwContext hw;
        private IRaptorHwCandidateList list;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Open library
            hw = RaptorHardware.CreateContext();

            //Set active modules
            installedModules.Items.AddRange(hw.ActiveModules);
        }

        private void RefreshDeviceList()
        {
            //Request list
            if (list != null)
                list.Dispose();
            list = hw.Search();

            //Clear and update
            deviceList.SuspendLayout();
            deviceList.Rows.Clear();
            foreach (var d in list)
            {
                int index = deviceList.Rows.Add();
                deviceList.Rows[index].Cells["DeviceName"].Value = d.Name;
                deviceList.Rows[index].Cells["Serial"].Value = d.Serial;
                deviceList.Rows[index].Cells["Capabilities"].Value = ((int)d.Capabilities).ToString();
            }
            deviceList.ResumeLayout();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void deviceList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Open the selected device
            var device = list[e.RowIndex].Open();

            //Show form
            new Form2(device).ShowDialog();
        }
    }
}
