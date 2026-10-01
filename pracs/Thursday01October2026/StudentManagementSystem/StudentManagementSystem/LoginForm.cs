using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem;

public class LoginForm : Form
{
    private readonly TextBox txtUsername = new();
    private readonly TextBox txtPassword = new();
    private readonly Button btnLogin = new();

    public LoginForm()
    {
        AutoScaleMode = AutoScaleMode.Font;
        Text = "Student Management System - Login";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(520, 420);
        MinimumSize = new Size(480, 360);
        BackColor = Theme.Background;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label
        {
            Text = "Student Management System",
            Font = Theme.TitleFont,
            ForeColor = Theme.PrimaryDark,
            AutoSize = true
        };

        var subtitle = new Label
        {
            Text = "Administrator Login",
            Font = Theme.HeadingFont,
            ForeColor = Theme.Text,
            AutoSize = true
        };

        var lblUsername = MakeLabel("Username", 90, 155);
        txtUsername.Size = new Size(360, 30);
        txtUsername.Location = new Point((ClientSize.Width - txtUsername.Width) / 2, 180);
        txtUsername.Font = Theme.NormalFont;
        txtUsername.Name = "txtUsername";

        var lblPassword = MakeLabel("Password", 90, 225);
        txtPassword.Size = new Size(360, 30);
        txtPassword.Location = new Point((ClientSize.Width - txtPassword.Width) / 2, 250);
        txtPassword.Font = Theme.NormalFont;
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.Name = "txtPassword";

        btnLogin.Text = "Login";
        btnLogin.Size = new Size(360, 42);
        btnLogin.Location = new Point((ClientSize.Width - btnLogin.Width) / 2, 305);
        btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        btnLogin.BackColor = Theme.Primary;
        btnLogin.ForeColor = Color.White;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Name = "btnLogin";
        btnLogin.Click += BtnLogin_Click;

        // Make controls resize horizontally with the form
        txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        // center title and subtitle based on calculated sizes
        title.Location = new Point((ClientSize.Width - title.PreferredSize.Width) / 2, 55);
        subtitle.Location = new Point((ClientSize.Width - subtitle.PreferredSize.Width) / 2, 105);

        Controls.AddRange(new Control[]
        {
            title, subtitle, lblUsername, txtUsername, lblPassword, txtPassword, btnLogin
        });

        AcceptButton = btnLogin;
    }

    private static Label MakeLabel(string text, int x, int y) => new()
    {
        Text = text,
        Location = new Point(x, y),
        AutoSize = true,
        Font = Theme.NormalFont,
        ForeColor = Theme.Text
    };

    private void InitializeComponent()
    {

    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        if (txtUsername.Text.Trim() == "admin" && txtPassword.Text == "1234")
        {
            var dashboard = new DashboardForm(this);
            dashboard.Show();
            Hide();
        }
        else
        {
            MessageBox.Show(
                "Incorrect username or password. Please try again.",
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
