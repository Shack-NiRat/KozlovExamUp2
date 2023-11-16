namespace ОООСпорт
{
    public partial class Autorisation : Form
    {
        public int mistakes = 0;

        public bool fallcapcha = false;

        private string? role;

        capcha f = new capcha();

        int time = 10;

        public Autorisation()
        {
            textBox2.UseSystemPasswordChar = true;
            button2.Text = "\U0001F441";
            timer1.Interval = 1000;
            timer1.Start();
            InitializeComponent();
        }

        void CheckAutorisation()
        {
            using (TradeContext db = new TradeContext())
            {
                string login = textBox1.Text;
                string password = textBox2.Text;


                User? autorisation = db.Users.FirstOrDefault(p => p.UserLogin == login && p.UserPassword == password);

                if (autorisation == null)
                {
                    if (mistakes == 0)
                    {
                        MessageBox.Show("Неверный логин или пароль");
                        mistakes++;
                        return;
                    }
                    if (mistakes > 0)
                    {
                        if (f != null)
                        {
                            f.Dispose();
                            f = new capcha();
                            f.Owner = this;
                        }
                        f.Show();
                    }
                    
                }
                else
                {
                    role = autorisation.UserRole;
                }
            }
        }


        void GoToForm()
        {
            if (role == null) return;

            if (role == "Admin")
            {
                Administator admin = new Administator();
                this.Hide();
                admin.ShowDialog();
                this.Close();
            }

            if (role == "Student")
            {
                Client client = new Client();
                this.Hide();
                client.ShowDialog();
                this.Close();
            }

            if (role == "Teacher")
            {
                Manager manager = new Manager();
                this.Hide();
                manager.ShowDialog();
                this.Close();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            CheckAutorisation();

            GoToForm();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                button1.Enabled = false;
            }
            else button1.Enabled = true;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fallcapcha)
            {
                label4.Visible = true;
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                label4.Text = time.ToString();
                time--;
                if (time <= 0)
                {
                    label4.Visible = false;
                    timer1.Stop();
                    button1.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    fallcapcha = false;
                }
            }

        }
    }
}