using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Siticone.UI.WinForms;

namespace TutorialTabsLunar
{
	// Token: 0x02000004 RID: 4
	public class Login : Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020B8 File Offset: 0x000002B8
		public Login()
		{
			this.InitializeComponent();
			this.LoadValidKeys();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020CC File Offset: 0x000002CC
		private void CloseAppButton_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002244 File Offset: 0x00000444
		private void LoadValidKeys()
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					string key = Login.GetKey();
					string text = webClient.DownloadString("" + key);
					this.validKeys = new List<string>
					{
						text.Trim()
					};
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading keys: " + ex.Message, "FluxTeam");
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022D0 File Offset: 0x000004D0
		private void siticoneButton2_Click(object sender, EventArgs e)
		{
			string text = this.textBox1.Text;
			if (text.Length <= 30)
			{
				MessageBox.Show("ERROR, Key must be longer than 30 characters", "FluxTeam");
				return;
			}
			if (this.validKeys != null && this.validKeys.Contains(text))
			{
				base.Hide();
				new Mainform().Show();
				return;
			}
			MessageBox.Show("Please enter a valid key!!!", "FluxTeam");
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000233C File Offset: 0x0000053C
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			using (WebClient webClient = new WebClient())
			{
				string key = Login.GetKey();
				Process.Start(webClient.DownloadString("" + key));
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020D4 File Offset: 0x000002D4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002388 File Offset: 0x00000588
		private void InitializeComponent()
		{
			this.CloseAppButton = new Guna2ControlBox();
			this.TopbarTitle = new Label();
			this.Topbar = new SiticonePanel();
			this.siticoneButton4 = new SiticoneButton();
			this.siticoneButton1 = new SiticoneButton();
			this.siticoneButton2 = new SiticoneButton();
			this.textBox1 = new TextBox();
			this.Topbar.SuspendLayout();
			base.SuspendLayout();
			this.CloseAppButton.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.CloseAppButton.Animated = true;
			this.CloseAppButton.BorderColor = Color.FromArgb(25, 21, 25);
			this.CloseAppButton.ControlBoxStyle = ControlBoxStyle.Custom;
			this.CloseAppButton.Cursor = Cursors.Hand;
			this.CloseAppButton.FillColor = Color.FromArgb(25, 21, 25);
			this.CloseAppButton.HoverState.BorderColor = Color.FromArgb(25, 21, 25);
			this.CloseAppButton.HoverState.FillColor = Color.FromArgb(25, 21, 25);
			this.CloseAppButton.HoverState.IconColor = Color.White;
			this.CloseAppButton.IconColor = Color.Silver;
			this.CloseAppButton.Location = new Point(228, 2);
			this.CloseAppButton.Name = "CloseAppButton";
			this.CloseAppButton.PressedColor = Color.FromArgb(25, 21, 25);
			this.CloseAppButton.PressedDepth = 100;
			this.CloseAppButton.Size = new Size(34, 29);
			this.CloseAppButton.TabIndex = 1;
			this.CloseAppButton.Click += this.CloseAppButton_Click;
			this.TopbarTitle.AutoSize = true;
			this.TopbarTitle.BackColor = Color.FromArgb(25, 21, 25);
			this.TopbarTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.TopbarTitle.ForeColor = Color.FromArgb(224, 224, 224);
			this.TopbarTitle.Location = new Point(7, 7);
			this.TopbarTitle.Name = "TopbarTitle";
			this.TopbarTitle.Size = new Size(122, 13);
			this.TopbarTitle.TabIndex = 2;
			this.TopbarTitle.Text = "FluxTeam - Getkey";
			this.Topbar.BorderColor = Color.FromArgb(25, 21, 25);
			this.Topbar.Controls.Add(this.siticoneButton4);
			this.Topbar.Controls.Add(this.CloseAppButton);
			this.Topbar.Controls.Add(this.TopbarTitle);
			this.Topbar.CustomBorderColor = Color.FromArgb(35, 31, 35);
			this.Topbar.CustomBorderThickness = new Padding(0, 0, 0, 1);
			this.Topbar.FillColor = Color.FromArgb(25, 21, 25);
			this.Topbar.Location = new Point(0, -1);
			this.Topbar.Name = "Topbar";
			this.Topbar.ShadowDecoration.Parent = this.Topbar;
			this.Topbar.Size = new Size(266, 37);
			this.Topbar.TabIndex = 3;
			this.siticoneButton4.BackColor = Color.Transparent;
			this.siticoneButton4.CheckedState.Parent = this.siticoneButton4;
			this.siticoneButton4.CustomImages.Parent = this.siticoneButton4;
			this.siticoneButton4.FillColor = Color.Transparent;
			this.siticoneButton4.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton4.ForeColor = Color.White;
			this.siticoneButton4.HoveredState.Parent = this.siticoneButton4;
			this.siticoneButton4.Location = new Point(640, 3);
			this.siticoneButton4.Name = "siticoneButton4";
			this.siticoneButton4.ShadowDecoration.Parent = this.siticoneButton4;
			this.siticoneButton4.Size = new Size(31, 27);
			this.siticoneButton4.TabIndex = 7;
			this.siticoneButton4.Text = "_";
			this.siticoneButton1.BackColor = Color.FromArgb(18, 14, 18);
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = Color.Transparent;
			this.siticoneButton1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = Color.White;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new Point(24, 219);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new Size(207, 34);
			this.siticoneButton1.TabIndex = 7;
			this.siticoneButton1.Text = "Get Key";
			this.siticoneButton1.Click += this.siticoneButton1_Click;
			this.siticoneButton2.BackColor = Color.FromArgb(18, 14, 18);
			this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
			this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
			this.siticoneButton2.FillColor = Color.Transparent;
			this.siticoneButton2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton2.ForeColor = Color.White;
			this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
			this.siticoneButton2.Location = new Point(24, 179);
			this.siticoneButton2.Name = "siticoneButton2";
			this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
			this.siticoneButton2.Size = new Size(207, 34);
			this.siticoneButton2.TabIndex = 8;
			this.siticoneButton2.Text = "Check Key";
			this.siticoneButton2.Click += this.siticoneButton2_Click;
			this.textBox1.BackColor = Color.FromArgb(20, 20, 20);
			this.textBox1.BorderStyle = BorderStyle.None;
			this.textBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = Color.White;
			this.textBox1.Location = new Point(44, 101);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(167, 32);
			this.textBox1.TabIndex = 9;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ControlText;
			base.ClientSize = new Size(264, 286);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.siticoneButton2);
			base.Controls.Add(this.siticoneButton1);
			base.Controls.Add(this.Topbar);
			this.ForeColor = Color.FromArgb(18, 14, 18);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Login";
			this.Text = "Login";
			this.Topbar.ResumeLayout(false);
			this.Topbar.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002B7C File Offset: 0x00000D7C
		public static string GenerateRandomString(int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Login.random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public static string GetKey()
		{
			if (string.IsNullOrEmpty(Login.cachedKey))
			{
				string str = "Fluxteam_";
				string str2 = Login.GenerateRandomString(30);
				Login.cachedKey = str + str2;
			}
			return Login.cachedKey;
		}

		// Token: 0x04000004 RID: 4
		private List<string> validKeys;

		// Token: 0x04000005 RID: 5
		private IContainer components;

		// Token: 0x04000006 RID: 6
		private Guna2ControlBox CloseAppButton;

		// Token: 0x04000007 RID: 7
		private Label TopbarTitle;

		// Token: 0x04000008 RID: 8
		private SiticonePanel Topbar;

		// Token: 0x04000009 RID: 9
		private SiticoneButton siticoneButton4;

		// Token: 0x0400000A RID: 10
		private SiticoneButton siticoneButton1;

		// Token: 0x0400000B RID: 11
		private SiticoneButton siticoneButton2;

		// Token: 0x0400000C RID: 12
		private TextBox textBox1;

		// Token: 0x0400000D RID: 13
		private static Random random = new Random();

		// Token: 0x0400000E RID: 14
		private static string cachedKey;

		// Token: 0x02000005 RID: 5
		public class ApiResponse
		{
			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000012 RID: 18 RVA: 0x000020FF File Offset: 0x000002FF
			// (set) Token: 0x06000013 RID: 19 RVA: 0x00002107 File Offset: 0x00000307
			public string Status { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000014 RID: 20 RVA: 0x00002110 File Offset: 0x00000310
			// (set) Token: 0x06000015 RID: 21 RVA: 0x00002118 File Offset: 0x00000318
			public string ShortenedUrl { get; set; }
		}
	}
}
