using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileTest
{
    public partial class FileTestForm : Form
    {
        public FileTestForm()
        {
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string fileName = inputTextBox.Text;

                if (File.Exists(fileName)) {
                    GetInformation(fileName);
                    StreamReader stream = null;

                    try {
                        using (stream = new StreamReader(fileName)) {
                            outputTextBox.AppendText(stream.ReadToEnd());
                        }
                    }
                    catch (IOException) {
                        MessageBox.Show("Error Reading from file", "File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (Directory.Exists(fileName) ){
                    GetInformation(fileName);

                    string[] directoryList =
                        Directory.GetDirectories(fileName);

                    outputTextBox.AppendText("Directory contents:\n");

                    foreach (var directory in directoryList) {
                        outputTextBox.AppendText(directory + "\n");
                    }

                }
                else
                {
                    MessageBox.Show(inputTextBox.Text +
                        " does not exist", "File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void GetInformation(string fileName)
        {
            outputTextBox.Clear();

            outputTextBox.AppendText(fileName + " exists\n");

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
