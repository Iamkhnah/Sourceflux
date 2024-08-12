using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Siticone.UI.WinForms;

namespace TutorialTabsLunar
{
	// Token: 0x02000006 RID: 6
	public class Mainform : Form
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002121 File Offset: 0x00000321
		public Mainform()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000020CC File Offset: 0x000002CC
		private void CloseAppButton_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000214F File Offset: 0x0000034F
		private void DashboardPageButton_Click(object sender, EventArgs e)
		{
			this.DashboardPagePanel.Visible = true;
			this.Page2Panel.Visible = false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002169 File Offset: 0x00000369
		private void Page2PanelButton_Click(object sender, EventArgs e)
		{
			this.Page2Panel.Visible = true;
			this.DashboardPagePanel.Visible = false;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002183 File Offset: 0x00000383
		private void Page3PanelButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Coming Soon!");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002190 File Offset: 0x00000390
		private void guna2ControlBox1_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002199 File Offset: 0x00000399
		private void siticoneButton6_Click(object sender, EventArgs e)
		{
			this.webBrowser1.Document.InvokeScript("SetText", new object[]
			{
				""
			});
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002C00 File Offset: 0x00000E00
		private void siticoneButton7_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Stream stream = sfd.OpenFile();
				StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.Write(this.webBrowser1.Document.InvokeScript("GetText", new object[0]));
				streamWriter.Close();
				stream.Close();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002C60 File Offset: 0x00000E60
		private void siticoneButton8_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string mofd = File.ReadAllText(ofd.FileName);
				this.webBrowser1.Document.InvokeScript("SetText", new object[]
				{
					mofd
				});
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000021BF File Offset: 0x000003BF
		private void siticoneButton3_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "main.exe"
			});
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002CB4 File Offset: 0x00000EB4
		private void addIntel(string label, string kind, string detail, string insertText)
		{
			"\"" + label + "\"";
			"\"" + kind + "\"";
			"\"" + detail + "\"";
			"\"" + insertText + "\"";
			this.webBrowser1.Document.InvokeScript("AddIntellisense", new object[]
			{
				label,
				kind,
				detail,
				insertText
			});
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002D34 File Offset: 0x00000F34
		private void addGlobalF()
		{
			foreach (string text in File.ReadAllLines(this.defPath + "//globalf.txt"))
			{
				if (text.Contains(':'))
				{
					this.addIntel(text, "Function", text, text.Substring(1));
				}
				else
				{
					this.addIntel(text, "Function", text, text);
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002D98 File Offset: 0x00000F98
		private void addGlobalV()
		{
			foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
			{
				this.addIntel(text, "Variable", text, text);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002DFC File Offset: 0x00000FFC
		private void addGlobalNS()
		{
			foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
			{
				this.addIntel(text, "Class", text, text);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002E60 File Offset: 0x00001060
		private void addMath()
		{
			foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
			{
				this.addIntel(text, "Method", text, text);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002EC4 File Offset: 0x000010C4
		private void addBase()
		{
			foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
			{
				this.addIntel(text, "Keyword", text, text);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002F28 File Offset: 0x00001128
		private void Mainform_Load(object sender, EventArgs e)
		{
			Mainform.<Mainform_Load>d__18 <Mainform_Load>d__;
			<Mainform_Load>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Mainform_Load>d__.<>4__this = this;
			<Mainform_Load>d__.<>1__state = -1;
			<Mainform_Load>d__.<>t__builder.Start<Mainform.<Mainform_Load>d__18>(ref <Mainform_Load>d__);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000021D7 File Offset: 0x000003D7
		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://raw.githubusercontent.com/CriShoux/OwlHub/master/OwlHub.txt");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000021E4 File Offset: 0x000003E4
		private void siticoneButton2_Click(object sender, EventArgs e)
		{
			Process.Start("https://pastebin.com/raw/a3YwXjBk");
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002F60 File Offset: 0x00001160
		private void siticoneButton5_Click(object sender, EventArgs e)
		{
			Mainform.<siticoneButton5_Click>d__21 <siticoneButton5_Click>d__;
			<siticoneButton5_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<siticoneButton5_Click>d__.<>4__this = this;
			<siticoneButton5_Click>d__.<>1__state = -1;
			<siticoneButton5_Click>d__.<>t__builder.Start<Mainform.<siticoneButton5_Click>d__21>(ref <siticoneButton5_Click>d__);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002190 File Offset: 0x00000390
		private void siticoneButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021F1 File Offset: 0x000003F1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002F98 File Offset: 0x00001198
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Mainform));
			this.TopbarDrag = new Guna2DragControl(this.components);
			this.Topbar = new SiticonePanel();
			this.CloseAppButton = new Guna2ControlBox();
			this.TopbarTitle = new Label();
			this.FormElipse = new Guna2Elipse(this.components);
			this.guna2ShadowForm1 = new Guna2ShadowForm(this.components);
			this.Sidebar = new SiticonePanel();
			this.Page3PanelButton = new Guna2Button();
			this.Page2PanelButton = new Guna2Button();
			this.DashboardPageButton = new Guna2Button();
			this.Page2Panel = new Panel();
			this.siticonePanel1 = new SiticonePanel();
			this.label3 = new Label();
			this.siticoneSeparator1 = new SiticoneSeparator();
			this.siticonePanel4 = new SiticonePanel();
			this.siticoneButton2 = new SiticoneButton();
			this.siticoneSeparator3 = new SiticoneSeparator();
			this.label8 = new Label();
			this.siticonePanel5 = new SiticonePanel();
			this.siticoneButton1 = new SiticoneButton();
			this.siticoneSeparator4 = new SiticoneSeparator();
			this.label13 = new Label();
			this.siticonePanel6 = new SiticonePanel();
			this.label14 = new Label();
			this.siticonePanel2 = new SiticonePanel();
			this.siticoneButton8 = new SiticoneButton();
			this.siticoneImageButton5 = new SiticoneImageButton();
			this.siticoneButton7 = new SiticoneButton();
			this.siticoneImageButton4 = new SiticoneImageButton();
			this.siticoneButton6 = new SiticoneButton();
			this.siticoneImageButton3 = new SiticoneImageButton();
			this.siticoneButton5 = new SiticoneButton();
			this.siticoneImageButton2 = new SiticoneImageButton();
			this.siticoneImageButton1 = new SiticoneImageButton();
			this.siticoneButton3 = new SiticoneButton();
			this.label1 = new Label();
			this.DashboardPagePanel = new Panel();
			this.webBrowser1 = new WebBrowser();
			this.siticoneButton4 = new SiticoneButton();
			this.Topbar.SuspendLayout();
			this.Sidebar.SuspendLayout();
			this.Page2Panel.SuspendLayout();
			this.siticonePanel1.SuspendLayout();
			this.siticonePanel4.SuspendLayout();
			this.siticonePanel5.SuspendLayout();
			this.siticonePanel6.SuspendLayout();
			this.siticonePanel2.SuspendLayout();
			this.DashboardPagePanel.SuspendLayout();
			base.SuspendLayout();
			this.TopbarDrag.DockIndicatorTransparencyValue = 1.0;
			this.TopbarDrag.DragStartTransparencyValue = 1.0;
			this.TopbarDrag.TargetControl = this.Topbar;
			this.TopbarDrag.UseTransparentDrag = true;
			this.Topbar.BorderColor = Color.FromArgb(25, 21, 25);
			this.Topbar.Controls.Add(this.siticoneButton4);
			this.Topbar.Controls.Add(this.CloseAppButton);
			this.Topbar.Controls.Add(this.TopbarTitle);
			this.Topbar.CustomBorderColor = Color.FromArgb(35, 31, 35);
			this.Topbar.CustomBorderThickness = new Padding(0, 0, 0, 1);
			this.Topbar.FillColor = Color.FromArgb(25, 21, 25);
			this.Topbar.Location = new Point(-1, -1);
			this.Topbar.Name = "Topbar";
			this.Topbar.ShadowDecoration.Parent = this.Topbar;
			this.Topbar.Size = new Size(706, 34);
			this.Topbar.TabIndex = 2;
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
			this.CloseAppButton.Location = new Point(668, 2);
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
			this.TopbarTitle.Size = new Size(147, 13);
			this.TopbarTitle.TabIndex = 2;
			this.TopbarTitle.Text = "FluxTeam | New Exploit";
			this.FormElipse.TargetControl = this;
			this.guna2ShadowForm1.BorderRadius = 6;
			this.guna2ShadowForm1.TargetForm = this;
			this.Sidebar.BorderColor = Color.FromArgb(25, 21, 25);
			this.Sidebar.Controls.Add(this.Page3PanelButton);
			this.Sidebar.Controls.Add(this.Page2PanelButton);
			this.Sidebar.Controls.Add(this.DashboardPageButton);
			this.Sidebar.CustomBorderColor = Color.FromArgb(35, 31, 35);
			this.Sidebar.CustomBorderThickness = new Padding(0, 0, 1, 0);
			this.Sidebar.FillColor = Color.FromArgb(25, 21, 25);
			this.Sidebar.Location = new Point(-1, 33);
			this.Sidebar.Name = "Sidebar";
			this.Sidebar.ShadowDecoration.Parent = this.Sidebar;
			this.Sidebar.Size = new Size(203, 356);
			this.Sidebar.TabIndex = 3;
			this.Page3PanelButton.Animated = true;
			this.Page3PanelButton.BackColor = Color.FromArgb(25, 21, 25);
			this.Page3PanelButton.BorderColor = Color.FromArgb(25, 21, 25);
			this.Page3PanelButton.BorderRadius = 4;
			this.Page3PanelButton.BorderThickness = 1;
			this.Page3PanelButton.ButtonMode = ButtonMode.RadioButton;
			this.Page3PanelButton.CheckedState.BorderColor = Color.FromArgb(31, 27, 31);
			this.Page3PanelButton.CheckedState.CustomBorderColor = Color.FromArgb(31, 27, 31);
			this.Page3PanelButton.CheckedState.FillColor = Color.FromArgb(31, 27, 31);
			this.Page3PanelButton.CheckedState.ForeColor = Color.White;
			this.Page3PanelButton.Cursor = Cursors.Hand;
			this.Page3PanelButton.DisabledState.BorderColor = Color.DarkGray;
			this.Page3PanelButton.DisabledState.CustomBorderColor = Color.DarkGray;
			this.Page3PanelButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.Page3PanelButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.Page3PanelButton.FillColor = Color.FromArgb(25, 21, 25);
			this.Page3PanelButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Page3PanelButton.ForeColor = Color.Silver;
			this.Page3PanelButton.HoverState.BorderColor = Color.FromArgb(29, 25, 29);
			this.Page3PanelButton.HoverState.CustomBorderColor = Color.FromArgb(29, 25, 29);
			this.Page3PanelButton.HoverState.FillColor = Color.FromArgb(29, 25, 29);
			this.Page3PanelButton.HoverState.ForeColor = Color.FromArgb(224, 224, 224);
			this.Page3PanelButton.Location = new Point(11, 78);
			this.Page3PanelButton.Name = "Page3PanelButton";
			this.Page3PanelButton.PressedDepth = 10;
			this.Page3PanelButton.Size = new Size(180, 29);
			this.Page3PanelButton.TabIndex = 2;
			this.Page3PanelButton.Text = "More Soon!";
			this.Page3PanelButton.Click += this.Page3PanelButton_Click;
			this.Page2PanelButton.Animated = true;
			this.Page2PanelButton.BackColor = Color.FromArgb(25, 21, 25);
			this.Page2PanelButton.BorderColor = Color.FromArgb(25, 21, 25);
			this.Page2PanelButton.BorderRadius = 4;
			this.Page2PanelButton.BorderThickness = 1;
			this.Page2PanelButton.ButtonMode = ButtonMode.RadioButton;
			this.Page2PanelButton.CheckedState.BorderColor = Color.FromArgb(31, 27, 31);
			this.Page2PanelButton.CheckedState.CustomBorderColor = Color.FromArgb(31, 27, 31);
			this.Page2PanelButton.CheckedState.FillColor = Color.FromArgb(31, 27, 31);
			this.Page2PanelButton.CheckedState.ForeColor = Color.White;
			this.Page2PanelButton.Cursor = Cursors.Hand;
			this.Page2PanelButton.DisabledState.BorderColor = Color.DarkGray;
			this.Page2PanelButton.DisabledState.CustomBorderColor = Color.DarkGray;
			this.Page2PanelButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.Page2PanelButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.Page2PanelButton.FillColor = Color.FromArgb(25, 21, 25);
			this.Page2PanelButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Page2PanelButton.ForeColor = Color.Silver;
			this.Page2PanelButton.HoverState.BorderColor = Color.FromArgb(29, 25, 29);
			this.Page2PanelButton.HoverState.CustomBorderColor = Color.FromArgb(29, 25, 29);
			this.Page2PanelButton.HoverState.FillColor = Color.FromArgb(29, 25, 29);
			this.Page2PanelButton.HoverState.ForeColor = Color.FromArgb(224, 224, 224);
			this.Page2PanelButton.Location = new Point(11, 45);
			this.Page2PanelButton.Name = "Page2PanelButton";
			this.Page2PanelButton.PressedDepth = 10;
			this.Page2PanelButton.Size = new Size(180, 29);
			this.Page2PanelButton.TabIndex = 1;
			this.Page2PanelButton.Text = "Script Hub";
			this.Page2PanelButton.Click += this.Page2PanelButton_Click;
			this.DashboardPageButton.Animated = true;
			this.DashboardPageButton.BackColor = Color.FromArgb(25, 21, 25);
			this.DashboardPageButton.BorderColor = Color.FromArgb(25, 21, 25);
			this.DashboardPageButton.BorderRadius = 4;
			this.DashboardPageButton.BorderThickness = 1;
			this.DashboardPageButton.ButtonMode = ButtonMode.RadioButton;
			this.DashboardPageButton.Checked = true;
			this.DashboardPageButton.CheckedState.BorderColor = Color.FromArgb(31, 27, 31);
			this.DashboardPageButton.CheckedState.CustomBorderColor = Color.FromArgb(31, 27, 31);
			this.DashboardPageButton.CheckedState.FillColor = Color.FromArgb(31, 27, 31);
			this.DashboardPageButton.CheckedState.ForeColor = Color.White;
			this.DashboardPageButton.Cursor = Cursors.Hand;
			this.DashboardPageButton.DisabledState.BorderColor = Color.DarkGray;
			this.DashboardPageButton.DisabledState.CustomBorderColor = Color.DarkGray;
			this.DashboardPageButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.DashboardPageButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.DashboardPageButton.FillColor = Color.FromArgb(25, 21, 25);
			this.DashboardPageButton.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.DashboardPageButton.ForeColor = Color.Silver;
			this.DashboardPageButton.HoverState.BorderColor = Color.FromArgb(29, 25, 29);
			this.DashboardPageButton.HoverState.CustomBorderColor = Color.FromArgb(29, 25, 29);
			this.DashboardPageButton.HoverState.FillColor = Color.FromArgb(29, 25, 29);
			this.DashboardPageButton.HoverState.ForeColor = Color.FromArgb(224, 224, 224);
			this.DashboardPageButton.Location = new Point(11, 10);
			this.DashboardPageButton.Name = "DashboardPageButton";
			this.DashboardPageButton.PressedDepth = 10;
			this.DashboardPageButton.Size = new Size(180, 29);
			this.DashboardPageButton.TabIndex = 0;
			this.DashboardPageButton.Text = "Executer";
			this.DashboardPageButton.Click += this.DashboardPageButton_Click;
			this.Page2Panel.Controls.Add(this.siticonePanel1);
			this.Page2Panel.Controls.Add(this.siticonePanel4);
			this.Page2Panel.Controls.Add(this.siticonePanel5);
			this.Page2Panel.Controls.Add(this.siticonePanel6);
			this.Page2Panel.Location = new Point(206, 39);
			this.Page2Panel.Name = "Page2Panel";
			this.Page2Panel.Size = new Size(483, 332);
			this.Page2Panel.TabIndex = 6;
			this.siticonePanel1.BorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel1.BorderRadius = 4;
			this.siticonePanel1.BorderThickness = 1;
			this.siticonePanel1.Controls.Add(this.label3);
			this.siticonePanel1.Controls.Add(this.siticoneSeparator1);
			this.siticonePanel1.CustomBorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel1.FillColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel1.Location = new Point(127, 189);
			this.siticonePanel1.Name = "siticonePanel1";
			this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
			this.siticonePanel1.Size = new Size(232, 112);
			this.siticonePanel1.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.FromArgb(25, 21, 25);
			this.label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.FromArgb(224, 224, 224);
			this.label3.Location = new Point(46, 62);
			this.label3.Name = "label3";
			this.label3.Size = new Size(139, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "MORE COMING SOON!";
			this.siticoneSeparator1.BackColor = Color.FromArgb(25, 21, 25);
			this.siticoneSeparator1.FillColor = Color.FromArgb(35, 31, 35);
			this.siticoneSeparator1.Location = new Point(0, 30);
			this.siticoneSeparator1.Name = "siticoneSeparator1";
			this.siticoneSeparator1.Size = new Size(235, 10);
			this.siticoneSeparator1.TabIndex = 5;
			this.siticonePanel4.BorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel4.BorderRadius = 4;
			this.siticonePanel4.BorderThickness = 1;
			this.siticonePanel4.Controls.Add(this.siticoneButton2);
			this.siticonePanel4.Controls.Add(this.siticoneSeparator3);
			this.siticonePanel4.Controls.Add(this.label8);
			this.siticonePanel4.CustomBorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel4.FillColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel4.Location = new Point(246, 46);
			this.siticonePanel4.Name = "siticonePanel4";
			this.siticonePanel4.ShadowDecoration.Parent = this.siticonePanel4;
			this.siticonePanel4.Size = new Size(232, 112);
			this.siticonePanel4.TabIndex = 5;
			this.siticoneButton2.BackColor = Color.FromArgb(18, 14, 18);
			this.siticoneButton2.CheckedState.Parent = this.siticoneButton2;
			this.siticoneButton2.CustomImages.Parent = this.siticoneButton2;
			this.siticoneButton2.FillColor = Color.Transparent;
			this.siticoneButton2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton2.ForeColor = Color.White;
			this.siticoneButton2.HoveredState.Parent = this.siticoneButton2;
			this.siticoneButton2.Location = new Point(11, 55);
			this.siticoneButton2.Name = "siticoneButton2";
			this.siticoneButton2.ShadowDecoration.Parent = this.siticoneButton2;
			this.siticoneButton2.Size = new Size(207, 34);
			this.siticoneButton2.TabIndex = 10;
			this.siticoneButton2.Text = "Open";
			this.siticoneButton2.Click += this.siticoneButton2_Click;
			this.siticoneSeparator3.BackColor = Color.FromArgb(25, 21, 25);
			this.siticoneSeparator3.FillColor = Color.FromArgb(35, 31, 35);
			this.siticoneSeparator3.Location = new Point(-1, 30);
			this.siticoneSeparator3.Name = "siticoneSeparator3";
			this.siticoneSeparator3.Size = new Size(235, 10);
			this.siticoneSeparator3.TabIndex = 9;
			this.label8.AutoSize = true;
			this.label8.BackColor = Color.FromArgb(25, 21, 25);
			this.label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label8.ForeColor = Color.FromArgb(224, 224, 224);
			this.label8.Location = new Point(8, 7);
			this.label8.Name = "label8";
			this.label8.Size = new Size(126, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Phantom Forces ESP";
			this.siticonePanel5.BorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel5.BorderRadius = 4;
			this.siticonePanel5.BorderThickness = 1;
			this.siticonePanel5.Controls.Add(this.siticoneButton1);
			this.siticonePanel5.Controls.Add(this.siticoneSeparator4);
			this.siticonePanel5.Controls.Add(this.label13);
			this.siticonePanel5.CustomBorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel5.FillColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel5.Location = new Point(5, 46);
			this.siticonePanel5.Name = "siticonePanel5";
			this.siticonePanel5.ShadowDecoration.Parent = this.siticonePanel5;
			this.siticonePanel5.Size = new Size(232, 112);
			this.siticonePanel5.TabIndex = 4;
			this.siticoneButton1.BackColor = Color.FromArgb(18, 14, 18);
			this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
			this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
			this.siticoneButton1.FillColor = Color.Transparent;
			this.siticoneButton1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton1.ForeColor = Color.White;
			this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
			this.siticoneButton1.Location = new Point(11, 55);
			this.siticoneButton1.Name = "siticoneButton1";
			this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
			this.siticoneButton1.Size = new Size(207, 34);
			this.siticoneButton1.TabIndex = 6;
			this.siticoneButton1.Text = "Open";
			this.siticoneButton1.Click += this.siticoneButton1_Click;
			this.siticoneSeparator4.BackColor = Color.FromArgb(25, 21, 25);
			this.siticoneSeparator4.FillColor = Color.FromArgb(35, 31, 35);
			this.siticoneSeparator4.Location = new Point(0, 30);
			this.siticoneSeparator4.Name = "siticoneSeparator4";
			this.siticoneSeparator4.Size = new Size(235, 10);
			this.siticoneSeparator4.TabIndex = 5;
			this.label13.AutoSize = true;
			this.label13.BackColor = Color.FromArgb(25, 21, 25);
			this.label13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label13.ForeColor = Color.FromArgb(224, 224, 224);
			this.label13.Location = new Point(8, 9);
			this.label13.Name = "label13";
			this.label13.Size = new Size(51, 13);
			this.label13.TabIndex = 3;
			this.label13.Text = "OwlHub";
			this.siticonePanel6.BorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel6.BorderRadius = 4;
			this.siticonePanel6.BorderThickness = 1;
			this.siticonePanel6.Controls.Add(this.label14);
			this.siticonePanel6.CustomBorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel6.FillColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel6.Location = new Point(5, 4);
			this.siticonePanel6.Name = "siticonePanel6";
			this.siticonePanel6.ShadowDecoration.Parent = this.siticonePanel6;
			this.siticonePanel6.Size = new Size(473, 33);
			this.siticonePanel6.TabIndex = 0;
			this.label14.AutoSize = true;
			this.label14.BackColor = Color.FromArgb(25, 21, 25);
			this.label14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label14.ForeColor = Color.FromArgb(224, 224, 224);
			this.label14.Location = new Point(8, 7);
			this.label14.Name = "label14";
			this.label14.Size = new Size(75, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Script - Hub";
			this.siticonePanel2.BorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel2.BorderRadius = 4;
			this.siticonePanel2.BorderThickness = 1;
			this.siticonePanel2.Controls.Add(this.siticoneButton8);
			this.siticonePanel2.Controls.Add(this.siticoneImageButton5);
			this.siticonePanel2.Controls.Add(this.siticoneButton7);
			this.siticonePanel2.Controls.Add(this.siticoneImageButton4);
			this.siticonePanel2.Controls.Add(this.siticoneButton6);
			this.siticonePanel2.Controls.Add(this.siticoneImageButton3);
			this.siticonePanel2.Controls.Add(this.siticoneButton5);
			this.siticonePanel2.Controls.Add(this.siticoneImageButton2);
			this.siticonePanel2.Controls.Add(this.siticoneImageButton1);
			this.siticonePanel2.Controls.Add(this.siticoneButton3);
			this.siticonePanel2.Controls.Add(this.label1);
			this.siticonePanel2.CustomBorderColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel2.FillColor = Color.FromArgb(25, 21, 25);
			this.siticonePanel2.Location = new Point(5, 4);
			this.siticonePanel2.Name = "siticonePanel2";
			this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
			this.siticonePanel2.Size = new Size(473, 33);
			this.siticonePanel2.TabIndex = 0;
			this.siticoneButton8.BackColor = Color.Transparent;
			this.siticoneButton8.CheckedState.Parent = this.siticoneButton8;
			this.siticoneButton8.CustomImages.Parent = this.siticoneButton8;
			this.siticoneButton8.FillColor = Color.Transparent;
			this.siticoneButton8.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton8.ForeColor = Color.White;
			this.siticoneButton8.HoveredState.Parent = this.siticoneButton8;
			this.siticoneButton8.Location = new Point(237, 7);
			this.siticoneButton8.Name = "siticoneButton8";
			this.siticoneButton8.ShadowDecoration.Parent = this.siticoneButton8;
			this.siticoneButton8.Size = new Size(36, 23);
			this.siticoneButton8.TabIndex = 17;
			this.siticoneButton8.Text = "Open";
			this.siticoneButton8.Click += this.siticoneButton8_Click;
			this.siticoneImageButton5.BackColor = Color.Transparent;
			this.siticoneImageButton5.CheckedState.Parent = this.siticoneImageButton5;
			this.siticoneImageButton5.HoveredState.Parent = this.siticoneImageButton5;
			this.siticoneImageButton5.Image = (Image)componentResourceManager.GetObject("siticoneImageButton5.Image");
			this.siticoneImageButton5.Location = new Point(213, 7);
			this.siticoneImageButton5.Name = "siticoneImageButton5";
			this.siticoneImageButton5.PressedState.Parent = this.siticoneImageButton5;
			this.siticoneImageButton5.Size = new Size(27, 23);
			this.siticoneImageButton5.TabIndex = 16;
			this.siticoneButton7.BackColor = Color.Transparent;
			this.siticoneButton7.CheckedState.Parent = this.siticoneButton7;
			this.siticoneButton7.CustomImages.Parent = this.siticoneButton7;
			this.siticoneButton7.FillColor = Color.Transparent;
			this.siticoneButton7.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton7.ForeColor = Color.White;
			this.siticoneButton7.HoveredState.Parent = this.siticoneButton7;
			this.siticoneButton7.Location = new Point(171, 6);
			this.siticoneButton7.Name = "siticoneButton7";
			this.siticoneButton7.ShadowDecoration.Parent = this.siticoneButton7;
			this.siticoneButton7.Size = new Size(36, 23);
			this.siticoneButton7.TabIndex = 15;
			this.siticoneButton7.Text = "Save";
			this.siticoneButton7.Click += this.siticoneButton7_Click;
			this.siticoneImageButton4.BackColor = Color.Transparent;
			this.siticoneImageButton4.CheckedState.Parent = this.siticoneImageButton4;
			this.siticoneImageButton4.HoveredState.Parent = this.siticoneImageButton4;
			this.siticoneImageButton4.Image = (Image)componentResourceManager.GetObject("siticoneImageButton4.Image");
			this.siticoneImageButton4.Location = new Point(147, 6);
			this.siticoneImageButton4.Name = "siticoneImageButton4";
			this.siticoneImageButton4.PressedState.Parent = this.siticoneImageButton4;
			this.siticoneImageButton4.Size = new Size(27, 23);
			this.siticoneImageButton4.TabIndex = 14;
			this.siticoneButton6.BackColor = Color.Transparent;
			this.siticoneButton6.CheckedState.Parent = this.siticoneButton6;
			this.siticoneButton6.CustomImages.Parent = this.siticoneButton6;
			this.siticoneButton6.FillColor = Color.Transparent;
			this.siticoneButton6.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton6.ForeColor = Color.White;
			this.siticoneButton6.HoveredState.Parent = this.siticoneButton6;
			this.siticoneButton6.Location = new Point(303, 6);
			this.siticoneButton6.Name = "siticoneButton6";
			this.siticoneButton6.ShadowDecoration.Parent = this.siticoneButton6;
			this.siticoneButton6.Size = new Size(36, 23);
			this.siticoneButton6.TabIndex = 9;
			this.siticoneButton6.Text = "Clear";
			this.siticoneButton6.Click += this.siticoneButton6_Click;
			this.siticoneImageButton3.BackColor = Color.Transparent;
			this.siticoneImageButton3.CheckedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.HoveredState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Image = (Image)componentResourceManager.GetObject("siticoneImageButton3.Image");
			this.siticoneImageButton3.Location = new Point(279, 6);
			this.siticoneImageButton3.Name = "siticoneImageButton3";
			this.siticoneImageButton3.PressedState.Parent = this.siticoneImageButton3;
			this.siticoneImageButton3.Size = new Size(27, 23);
			this.siticoneImageButton3.TabIndex = 8;
			this.siticoneButton5.BackColor = Color.Transparent;
			this.siticoneButton5.CheckedState.Parent = this.siticoneButton5;
			this.siticoneButton5.CustomImages.Parent = this.siticoneButton5;
			this.siticoneButton5.FillColor = Color.Transparent;
			this.siticoneButton5.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton5.ForeColor = Color.White;
			this.siticoneButton5.HoveredState.Parent = this.siticoneButton5;
			this.siticoneButton5.Location = new Point(360, 6);
			this.siticoneButton5.Name = "siticoneButton5";
			this.siticoneButton5.ShadowDecoration.Parent = this.siticoneButton5;
			this.siticoneButton5.Size = new Size(36, 23);
			this.siticoneButton5.TabIndex = 7;
			this.siticoneButton5.Text = "Run";
			this.siticoneButton5.Click += this.siticoneButton5_Click;
			this.siticoneImageButton2.BackColor = Color.Transparent;
			this.siticoneImageButton2.CheckedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.HoveredState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Image = (Image)componentResourceManager.GetObject("siticoneImageButton2.Image");
			this.siticoneImageButton2.Location = new Point(336, 6);
			this.siticoneImageButton2.Name = "siticoneImageButton2";
			this.siticoneImageButton2.PressedState.Parent = this.siticoneImageButton2;
			this.siticoneImageButton2.Size = new Size(27, 23);
			this.siticoneImageButton2.TabIndex = 6;
			this.siticoneImageButton1.BackColor = Color.Transparent;
			this.siticoneImageButton1.CheckedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.HoveredState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Image = (Image)componentResourceManager.GetObject("siticoneImageButton1.Image");
			this.siticoneImageButton1.Location = new Point(402, 6);
			this.siticoneImageButton1.Name = "siticoneImageButton1";
			this.siticoneImageButton1.PressedState.Parent = this.siticoneImageButton1;
			this.siticoneImageButton1.Size = new Size(27, 23);
			this.siticoneImageButton1.TabIndex = 4;
			this.siticoneButton3.BackColor = Color.Transparent;
			this.siticoneButton3.CheckedState.Parent = this.siticoneButton3;
			this.siticoneButton3.CustomImages.Parent = this.siticoneButton3;
			this.siticoneButton3.FillColor = Color.Transparent;
			this.siticoneButton3.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.siticoneButton3.ForeColor = Color.White;
			this.siticoneButton3.HoveredState.Parent = this.siticoneButton3;
			this.siticoneButton3.Location = new Point(415, 0);
			this.siticoneButton3.Name = "siticoneButton3";
			this.siticoneButton3.ShadowDecoration.Parent = this.siticoneButton3;
			this.siticoneButton3.Size = new Size(55, 34);
			this.siticoneButton3.TabIndex = 5;
			this.siticoneButton3.Text = "inject";
			this.siticoneButton3.Click += this.siticoneButton3_Click;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.FromArgb(25, 21, 25);
			this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.FromArgb(224, 224, 224);
			this.label1.Location = new Point(8, 7);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Executer";
			this.DashboardPagePanel.Controls.Add(this.webBrowser1);
			this.DashboardPagePanel.Controls.Add(this.siticonePanel2);
			this.DashboardPagePanel.Location = new Point(208, 39);
			this.DashboardPagePanel.Name = "DashboardPagePanel";
			this.DashboardPagePanel.Size = new Size(483, 332);
			this.DashboardPagePanel.TabIndex = 3;
			this.webBrowser1.Location = new Point(5, 44);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new Size(473, 280);
			this.webBrowser1.TabIndex = 1;
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
			this.siticoneButton4.Click += this.siticoneButton4_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(18, 14, 18);
			base.ClientSize = new Size(701, 383);
			base.Controls.Add(this.Sidebar);
			base.Controls.Add(this.Topbar);
			base.Controls.Add(this.Page2Panel);
			base.Controls.Add(this.DashboardPagePanel);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Mainform";
			this.Text = "Form1";
			base.Load += this.Mainform_Load;
			this.Topbar.ResumeLayout(false);
			this.Topbar.PerformLayout();
			this.Sidebar.ResumeLayout(false);
			this.Page2Panel.ResumeLayout(false);
			this.siticonePanel1.ResumeLayout(false);
			this.siticonePanel1.PerformLayout();
			this.siticonePanel4.ResumeLayout(false);
			this.siticonePanel4.PerformLayout();
			this.siticonePanel5.ResumeLayout(false);
			this.siticonePanel5.PerformLayout();
			this.siticonePanel6.ResumeLayout(false);
			this.siticonePanel6.PerformLayout();
			this.siticonePanel2.ResumeLayout(false);
			this.siticonePanel2.PerformLayout();
			this.DashboardPagePanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000011 RID: 17
		private WebClient wc = new WebClient();

		// Token: 0x04000012 RID: 18
		private string defPath = Application.StartupPath + "//Monaco//";

		// Token: 0x04000013 RID: 19
		private IContainer components;

		// Token: 0x04000014 RID: 20
		private Guna2DragControl TopbarDrag;

		// Token: 0x04000015 RID: 21
		private Guna2Elipse FormElipse;

		// Token: 0x04000016 RID: 22
		private Guna2ShadowForm guna2ShadowForm1;

		// Token: 0x04000017 RID: 23
		private Guna2ControlBox CloseAppButton;

		// Token: 0x04000018 RID: 24
		private SiticonePanel Topbar;

		// Token: 0x04000019 RID: 25
		private Label TopbarTitle;

		// Token: 0x0400001A RID: 26
		private SiticonePanel Sidebar;

		// Token: 0x0400001B RID: 27
		private Guna2Button DashboardPageButton;

		// Token: 0x0400001C RID: 28
		private Guna2Button Page2PanelButton;

		// Token: 0x0400001D RID: 29
		private Guna2Button Page3PanelButton;

		// Token: 0x0400001E RID: 30
		private Panel DashboardPagePanel;

		// Token: 0x0400001F RID: 31
		private SiticonePanel siticonePanel2;

		// Token: 0x04000020 RID: 32
		private Label label1;

		// Token: 0x04000021 RID: 33
		private WebBrowser webBrowser1;

		// Token: 0x04000022 RID: 34
		private SiticoneImageButton siticoneImageButton1;

		// Token: 0x04000023 RID: 35
		private SiticoneButton siticoneButton3;

		// Token: 0x04000024 RID: 36
		private SiticoneButton siticoneButton8;

		// Token: 0x04000025 RID: 37
		private SiticoneImageButton siticoneImageButton5;

		// Token: 0x04000026 RID: 38
		private SiticoneButton siticoneButton7;

		// Token: 0x04000027 RID: 39
		private SiticoneImageButton siticoneImageButton4;

		// Token: 0x04000028 RID: 40
		private SiticoneButton siticoneButton6;

		// Token: 0x04000029 RID: 41
		private SiticoneImageButton siticoneImageButton3;

		// Token: 0x0400002A RID: 42
		private SiticoneButton siticoneButton5;

		// Token: 0x0400002B RID: 43
		private SiticoneImageButton siticoneImageButton2;

		// Token: 0x0400002C RID: 44
		private Panel Page2Panel;

		// Token: 0x0400002D RID: 45
		private SiticonePanel siticonePanel4;

		// Token: 0x0400002E RID: 46
		private SiticoneSeparator siticoneSeparator3;

		// Token: 0x0400002F RID: 47
		private Label label8;

		// Token: 0x04000030 RID: 48
		private SiticonePanel siticonePanel5;

		// Token: 0x04000031 RID: 49
		private SiticoneSeparator siticoneSeparator4;

		// Token: 0x04000032 RID: 50
		private Label label13;

		// Token: 0x04000033 RID: 51
		private SiticonePanel siticonePanel6;

		// Token: 0x04000034 RID: 52
		private Label label14;

		// Token: 0x04000035 RID: 53
		private SiticoneButton siticoneButton2;

		// Token: 0x04000036 RID: 54
		private SiticoneButton siticoneButton1;

		// Token: 0x04000037 RID: 55
		private SiticonePanel siticonePanel1;

		// Token: 0x04000038 RID: 56
		private Label label3;

		// Token: 0x04000039 RID: 57
		private SiticoneSeparator siticoneSeparator1;

		// Token: 0x0400003A RID: 58
		private SiticoneButton siticoneButton4;
	}
}
