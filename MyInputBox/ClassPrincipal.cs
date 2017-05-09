using System.Windows.Forms;
namespace MyInputBox
{
    public partial class InputBox : Form
    {
        private static TextBox txtResposta = new TextBox() { Name = "txtResp", AutoSize = false, Visible = false };
        private static NumericUpDown nudResposta = new NumericUpDown() { Name = "nudResp", AutoSize = false, Visible = false };
        private static Label lblDescrição = new Label() { Name = "lblDesc", AutoSize = true, Visible = true };
        public InputBox()
        {
            nudResposta.Visible = false;
            txtResposta.Visible = false;
            nudResposta.ResetText();
            txtResposta.Text = null;
            lblDescrição.Text = null;            
            Controls.Add(txtResposta);
            Controls.Add(lblDescrição);
            Controls.Add(nudResposta);
            txtResposta.KeyDown += Resposta_KeyDown;
            nudResposta.KeyDown += Resposta_KeyDown;
            FormClosing += InputBox_FormClosing;
            FormClosed += InputBox_FormClosed;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Size = new System.Drawing.Size(300, 68);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InputBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Controls.Remove(txtResposta);
            Controls.Remove(lblDescrição);
            Controls.Remove(nudResposta);
        }

        private void Resposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyData.ToString().ToLower().Contains("oemtilde"))
            {
                if (e.KeyData.ToString().ToLower().Contains("oem") || e.KeyValue == 107 || e.KeyValue == 109 || e.KeyValue == 111)
                {
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyValue == 13 && txtResposta.Text.Trim() != "")
                {
                    e.SuppressKeyPress = true;
                    Close();
                }
            }
        }
        private void InputBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtResposta.Text.Trim() == "")
            {
                txtResposta.Text = "Indefinido";
            }
        }
        public static string Show(string text, string caption)
        {
            InputBox Form = new InputBox();
            txtResposta.Visible = true;
            Form.Text = caption;
            lblDescrição.Text = text;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string Show(string text, string caption, string txtText)
        {
            InputBox Form = new InputBox() { Text = caption };
            txtResposta.Visible = true;
            lblDescrição.Text = text;
            txtResposta.Text = txtText;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string Show(string text, string caption, int seconds)
        {
            InputBox Form = new InputBox();
            txtResposta.Visible = true;
            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(seconds))
                .ContinueWith((t) => Form.Close(), System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            Form.Text = caption;
            lblDescrição.Text = text;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string Show(string text, string caption, string txtText, int seconds)
        {
            InputBox Form = new InputBox() { Text = caption };
            txtResposta.Visible = true;
            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(seconds))
                .ContinueWith((t) => Form.Close(), System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            lblDescrição.Text = text;
            txtResposta.Text = txtText;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string ShowNumeric(string text, string caption)
        {
            InputBox Form = new InputBox();
            nudResposta.Visible = true;
            Form.Text = caption;
            lblDescrição.Text = text;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string ShowNumeric(string text, string caption, string value)
        {
            InputBox Form = new InputBox() { Text = caption };
            nudResposta.Visible = true;
            lblDescrição.Text = text;
            int NudValue = 0;
            int.TryParse(value, out NudValue);
            nudResposta.Value = NudValue;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string ShowNumeric(string text, string caption, int seconds)
        {
            InputBox Form = new InputBox();
            nudResposta.Visible = true;
            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(seconds))
                .ContinueWith((t) => Form.Close(), System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            Form.Text = caption;
            lblDescrição.Text = text;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        public static string ShowNumeric(string text, string caption, string value, int seconds)
        {
            InputBox Form = new InputBox() { Text = caption };
            nudResposta.Visible = true;
            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(seconds))
                .ContinueWith((t) => Form.Close(), System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            lblDescrição.Text = text;
            int NudValue = 0;
            int.TryParse(value,out NudValue);
            nudResposta.Value = NudValue;
            Comum();
            Form.ShowDialog();
            return txtResposta.Text;
        }
        private static void Comum()
        {
            lblDescrição.Location = new System.Drawing.Point(12,9);
            lblDescrição.Refresh();
            txtResposta.Location = new System.Drawing.Point(18 + lblDescrição.Width, 6);
            nudResposta.Location = new System.Drawing.Point(18 + lblDescrição.Width, 6);
            txtResposta.Size = new System.Drawing.Size(254 - lblDescrição.Width, 20);
                     
        }
    }
}