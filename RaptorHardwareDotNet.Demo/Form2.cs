using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaptorHardwareDotNet.Demo
{
    public unsafe partial class Form2 : Form
    {
        public Form2(IRaptorHwDevice device)
        {
            this.device = device;
            InitializeComponent();
        }

        private IRaptorHwDevice device;
        private bool ready;
        private bool rxEnabled;
        private long rxSamples;
        private Timer rxUpdateTimer;

        private FileStream rxFile;
        private byte[] rxFileBuffer;

        private void Form2_Load(object sender, EventArgs e)
        {
            //Set properties
            propName.Text = device.Name;
            propSerial.Text = device.Serial;
            propCapabilities.Text = ((int)device.Capabilities).ToString();
            propMinFreq.Text = device.MinFrequency.ToString();
            propMaxFreq.Text = device.MaxFrequency.ToString();

            //Enable or disable features
            settingBiasT.Enabled = (device.Capabilities & RaptorHwDeviceCapabilities.BIAS_T) == RaptorHwDeviceCapabilities.BIAS_T;
            settingDirectSampling.Enabled = (device.Capabilities & RaptorHwDeviceCapabilities.DIRECT_SAMPLING) == RaptorHwDeviceCapabilities.DIRECT_SAMPLING;

            //Add sample rates
            foreach (int rate in device.SupportedSamplerates)
                settingSampleRate.Items.Add(rate);

            //Set up the frequency control
            settingFreq.Value = device.CenterFrequency;
            settingFreq.Minimum = device.MinFrequency;
            settingFreq.Maximum = device.MaxFrequency;

            //Set custom properties
            PropertyWrapper[] wrapped = new PropertyWrapper[device.CustomProperties.Length];
            for (int i = 0; i < wrapped.Length; i++)
                wrapped[i] = new PropertyWrapper(device.CustomProperties[i]);
            customProperties.DataSource = wrapped;

            //Update RX panel and start timer to update it periodically
            UpdateRxPanel();
            rxUpdateTimer = new Timer();
            rxUpdateTimer.Tick += RxUpdateTimer_Tick;
            rxUpdateTimer.Interval = 50;
            rxUpdateTimer.Start();

            //Bind to device events for this
            device.OnSamplesReceived += Device_OnSamplesReceived;

            //Set flag
            ready = true;
        }

        private void Device_OnSamplesReceived(IRaptorHwDevice device, RaptorHwComplex* samples, int samplePairCount)
        {
            //Update count
            rxSamples += samplePairCount;

            //Resize file buffer if needed
            int size = samplePairCount * sizeof(RaptorHwComplex);
            if (rxFileBuffer == null || rxFileBuffer.Length < size)
                rxFileBuffer = new byte[size];

            //Copy in
            Marshal.Copy((IntPtr)samples, rxFileBuffer, 0, size);

            //Write to disk
            rxFile.Write(rxFileBuffer, 0, size);
        }

        private void RxUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateRxPanel();
        }

        private void UpdateRxPanel()
        {
            btnStartRx.Enabled = !rxEnabled;
            btnStopRx.Enabled = rxEnabled;
            rxInfo.Text = rxSamples + " samples";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop RX timer
            rxUpdateTimer.Stop();

            //Close the device
            device.Dispose();
        }

        private void settingFreq_ValueChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                device.CenterFrequency = (long)settingFreq.Value;
            }
        }

        private void settingSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                device.SampleRate = (int)settingSampleRate.SelectedItem;
            }
        }

        private void settingBiasT_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                device.EnableBiasT = settingBiasT.Checked;
            }
        }

        private void settingDirectSampling_CheckedChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                device.EnableDirectSampling = settingDirectSampling.Checked;
            }        }

        private void btnStartRx_Click(object sender, EventArgs e)
        {
            //Show file dialog
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Complex Float32 files (*.bin)|*.bin";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //Open file
                rxFile = new FileStream(fd.FileName, FileMode.Create);

                //Start RX
                device.StartRx();
                rxEnabled = true;

                //Update panel
                UpdateRxPanel();
            }
        }

        private void btnStopRx_Click(object sender, EventArgs e)
        {
            //Stop RX
            device.StopRx();
            rxEnabled = false;

            //Update panel
            UpdateRxPanel();

            //Close file
            rxFile.Close();
        }

        class PropertyWrapper
        {
            public PropertyWrapper(IRaptorHwCustomProperty prop)
            {
                this.prop = prop;
            }

            private IRaptorHwCustomProperty prop;

            public string Name => prop.Name;
            public object Value
            {
                get => prop.Value;
                set => prop.Value = value;
            }
        }
    }
}
