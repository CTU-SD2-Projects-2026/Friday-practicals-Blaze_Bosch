using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem;

public class DashboardForm : Form
{
    private readonly Form loginForm;
    private readonly Button btnStudentDetails = new();
    private readonly Button btnStudentSummary = new();
    private readonly Button btnLogout = new();

    public DashboardForm(Form loginForm)
    {
        this.loginForm = loginForm;

        AutoScaleMode = AutoScaleMode.Font;
        Text = "Student Management System - Dashboard";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(640, 480);
        MinimumSize = new Size(560, 420);
        BackColor = Theme.Background;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label
        {
            Text = "Dashboard",
            Font = Theme.TitleFont,
            ForeColor = Theme.PrimaryDark,
            AutoSize = true
        };

        var welcome = new Label
        {
            Text = "Welcome, Administrator!",
            Font = Theme.HeadingFont,
            ForeColor = Theme.Text,
            AutoSize = true
        };

        ConfigureButton(btnStudentDetails, "Student Details", 160, 170, Theme.Primary);
        ConfigureButton(btnStudentSummary, "Student Summary", 160, 235, Theme.Accent);
        ConfigureButton(btnLogout, "Logout", 160, 300, Theme.Danger);

        // center the buttons and make them resize horizontally
        btnStudentDetails.Size = new Size(360, btnStudentDetails.Height);
        btnStudentSummary.Size = new Size(360, btnStudentSummary.Height);
        btnLogout.Size = new Size(360, btnLogout.Height);

        btnStudentDetails.Location = new Point((ClientSize.Width - btnStudentDetails.Width) / 2, 170);
        btnStudentSummary.Location = new Point((ClientSize.Width - btnStudentSummary.Width) / 2, 235);
        btnLogout.Location = new Point((ClientSize.Width - btnLogout.Width) / 2, 300);

        btnStudentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnStudentSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        btnStudentDetails.Click += (_, _) =>
        {
            new StudentDetailsForm(this).Show();
            Hide();
        };

        btnStudentSummary.Click += (_, _) =>
        {
            new StudentSummaryForm(this).Show();
            Hide();
        };

        btnLogout.Click += (_, _) => Logout();

        title.Location = new Point((ClientSize.Width - title.PreferredSize.Width) / 2, 50);
        welcome.Location = new Point((ClientSize.Width - welcome.PreferredSize.Width) / 2, 105);

        Controls.AddRange(new Control[]
        {
            title, welcome, btnStudentDetails, btnStudentSummary, btnLogout
        });
    }

    private static void ConfigureButton(Button button, string text, int x, int y, Color color)
    {
        button.Text = text;
        button.Location = new Point(x, y);
        button.Size = new Size(330, 48);
        button.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        button.BackColor = color;
        button.ForeColor = Color.White;
        button.FlatStyle = FlatStyle.Flat;
    }

    private void Logout()
    {
        Close();
        loginForm.Show();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);

        if (loginForm.IsDisposed)
            Application.Exit();
        else
            loginForm.Show();
    }
}
