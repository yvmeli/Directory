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

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                agendaBindingSource.Filter = $"Nombre like '*{textBox1.Text}*' or Móvil='{textBox1.Text}'";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                dataSet1.ReadXml($"{Application.StartupPath}/data.dat");
        }

        private void agendaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            agendaBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Los datos han sido guardados correctamente.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}
