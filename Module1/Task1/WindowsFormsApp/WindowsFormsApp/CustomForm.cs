using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) 
                MessageBox.Show("Sorry, repeat input", "Error");
            else 
                MessageBox.Show($"Hello, {name}!", "Greeting");
        }
    }
}
