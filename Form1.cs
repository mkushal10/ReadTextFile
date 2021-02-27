using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadTextFile
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            try{
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter="Text Documents|*.txt", Multiselect=false, ValidateNames = true })
                {
                    if (ofd.ShowDialog()==DialogResult.OK)
                    {
                        using(StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            txtContent.Text = await sr.ReadToEndAsync();
                        }
                    }
                }
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
