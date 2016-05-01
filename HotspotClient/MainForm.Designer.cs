namespace HotspotClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Github :- https://github.com/IgnaceMaes/MaterialSkin/");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("MaterialSkin by IgnaceMaes", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Github :- https://github.com/thielj/MetroFramework");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MetroFramework by thielj", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("CodeProject  :- http://www.codeproject.com/Articles/442983/Android-Style-Toast-No" +
        "tification-for-NET");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Android-Style (Toast) Notification for .NET by John Espiritu", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("License : - http://creativecommons.org/licenses/by-sa/3.0/");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("2, bar, signal, wifi icon", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.btnRefreshDetails = new MaterialSkin.Controls.MaterialFlatButton();
            this.property1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._listview = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.panelControl = new System.Windows.Forms.Panel();
            this.txtPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSSID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnHotspot = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkICS = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupICS = new System.Windows.Forms.GroupBox();
            this.btnSetICS = new MaterialSkin.Controls.MaterialRaisedButton();
            this.radioNetAdapter = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioNetName = new MaterialSkin.Controls.MaterialRadioButton();
            this.comboNetwork = new MetroFramework.Controls.MetroComboBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.groupApperance = new System.Windows.Forms.GroupBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.comboColorStyle = new MetroFramework.Controls.MetroComboBox();
            this.comboTheme = new MetroFramework.Controls.MetroComboBox();
            this.groupStartUp = new System.Windows.Forms.GroupBox();
            this.checkExit = new MaterialSkin.Controls.MaterialCheckBox();
            this.checkStartUp2 = new MaterialSkin.Controls.MaterialCheckBox();
            this.checkStartUp1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.processbar = new MaterialSkin.Controls.MaterialProgressBar();
            this.workerHostspotSupport = new System.ComponentModel.BackgroundWorker();
            this.workerICSChange = new System.ComponentModel.BackgroundWorker();
            this.workerStart = new System.ComponentModel.BackgroundWorker();
            this.workerStop = new System.ComponentModel.BackgroundWorker();
            this.workerRefresh = new System.ComponentModel.BackgroundWorker();
            this.workerUI = new System.ComponentModel.BackgroundWorker();
            this.workerDevices = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabDetails.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupControl.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupICS.SuspendLayout();
            this.groupApperance.SuspendLayout();
            this.groupStartUp.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.btnRefreshDetails);
            this.tabDetails.Controls.Add(this.property1);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(458, 434);
            this.tabDetails.TabIndex = 3;
            this.tabDetails.Text = "Hotspot Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            this.tabDetails.Enter += new System.EventHandler(this.tabDetails_Enter);
            // 
            // btnRefreshDetails
            // 
            this.btnRefreshDetails.AutoSize = true;
            this.btnRefreshDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshDetails.Depth = 0;
            this.btnRefreshDetails.Location = new System.Drawing.Point(193, 6);
            this.btnRefreshDetails.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshDetails.Name = "btnRefreshDetails";
            this.btnRefreshDetails.Primary = true;
            this.btnRefreshDetails.Size = new System.Drawing.Size(70, 36);
            this.btnRefreshDetails.TabIndex = 1;
            this.btnRefreshDetails.Text = "Refresh";
            this.btnRefreshDetails.UseVisualStyleBackColor = true;
            this.btnRefreshDetails.Click += new System.EventHandler(this.btnRefreshDetails_Click);
            // 
            // property1
            // 
            this.property1.AccessibleRole = System.Windows.Forms.AccessibleRole.PropertyPage;
            this.property1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.property1.DisabledItemForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.property1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.property1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.property1.Location = new System.Drawing.Point(3, 22);
            this.property1.Name = "property1";
            this.property1.Size = new System.Drawing.Size(452, 409);
            this.property1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.groupBox2);
            this.tabControl.Controls.Add(this.groupControl);
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(458, 434);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Controls";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.materialLabel3);
            this.groupBox2.Location = new System.Drawing.Point(0, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 305);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._listview);
            this.panel2.Location = new System.Drawing.Point(3, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 234);
            this.panel2.TabIndex = 4;
            // 
            // _listview
            // 
            this._listview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this._listview.Depth = 0;
            this._listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listview.Font = new System.Drawing.Font("Roboto", 24F);
            this._listview.FullRowSelect = true;
            this._listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._listview.Location = new System.Drawing.Point(0, 0);
            this._listview.MouseLocation = new System.Drawing.Point(-1, -1);
            this._listview.MouseState = MaterialSkin.MouseState.OUT;
            this._listview.Name = "_listview";
            this._listview.OwnerDraw = true;
            this._listview.Size = new System.Drawing.Size(455, 234);
            this._listview.TabIndex = 0;
            this._listview.UseCompatibleStateImageBehavior = false;
            this._listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mac Address";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Company";
            this.columnHeader3.Width = 150;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoEllipsis = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(123, 12);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(201, 24);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "Connected Devices";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.materialLabel3.Click += new System.EventHandler(this.materialLabel3_Click);
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.panelControl);
            this.groupControl.Controls.Add(this.btnHotspot);
            this.groupControl.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl.Location = new System.Drawing.Point(0, -7);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(465, 151);
            this.groupControl.TabIndex = 0;
            this.groupControl.TabStop = false;
            // 
            // panelControl
            // 
            this.panelControl.AutoSize = true;
            this.panelControl.BackColor = System.Drawing.Color.White;
            this.panelControl.Controls.Add(this.txtPass);
            this.panelControl.Controls.Add(this.txtSSID);
            this.panelControl.Controls.Add(this.materialLabel2);
            this.panelControl.Controls.Add(this.materialLabel1);
            this.panelControl.Location = new System.Drawing.Point(8, 13);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(441, 83);
            this.panelControl.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Depth = 0;
            this.txtPass.Hint = "Password for Hotspot";
            this.txtPass.Location = new System.Drawing.Point(147, 57);
            this.txtPass.MaxLength = 32767;
            this.txtPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '\0';
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.Size = new System.Drawing.Size(256, 23);
            this.txtPass.TabIndex = 3;
            this.txtPass.TabStop = false;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtSSID
            // 
            this.txtSSID.Depth = 0;
            this.txtSSID.Hint = "Name Of Hotspot";
            this.txtSSID.Location = new System.Drawing.Point(147, 16);
            this.txtSSID.MaxLength = 32767;
            this.txtSSID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.PasswordChar = '\0';
            this.txtSSID.SelectedText = "";
            this.txtSSID.SelectionLength = 0;
            this.txtSSID.SelectionStart = 0;
            this.txtSSID.Size = new System.Drawing.Size(256, 23);
            this.txtSSID.TabIndex = 2;
            this.txtSSID.TabStop = false;
            this.txtSSID.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(27, 57);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Password";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(61, 19);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(41, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "SSID";
            // 
            // btnHotspot
            // 
            this.btnHotspot.Depth = 0;
            this.btnHotspot.Location = new System.Drawing.Point(155, 102);
            this.btnHotspot.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHotspot.Name = "btnHotspot";
            this.btnHotspot.Primary = true;
            this.btnHotspot.Size = new System.Drawing.Size(123, 36);
            this.btnHotspot.TabIndex = 1;
            this.btnHotspot.Text = "Start";
            this.btnHotspot.UseVisualStyleBackColor = true;
            this.btnHotspot.Click += new System.EventHandler(this.btnHotspot_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.tabControl);
            this.TabControl1.Controls.Add(this.tabDetails);
            this.TabControl1.Controls.Add(this.tabSettings);
            this.TabControl1.Controls.Add(this.tabAbout);
            this.TabControl1.Depth = 0;
            this.TabControl1.Location = new System.Drawing.Point(0, 122);
            this.TabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(466, 460);
            this.TabControl1.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tableLayoutPanel1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(458, 434);
            this.tabSettings.TabIndex = 4;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupApperance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupStartUp, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.62617F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.09346F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.51402F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 428);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 184);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ICS(Internet Connection Sharing)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.checkICS, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.15525F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.84475F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(440, 165);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkICS
            // 
            this.checkICS.AutoSize = true;
            this.checkICS.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tableLayoutPanel2.SetColumnSpan(this.checkICS, 2);
            this.checkICS.Depth = 0;
            this.checkICS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkICS.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkICS.Location = new System.Drawing.Point(0, 0);
            this.checkICS.Margin = new System.Windows.Forms.Padding(0);
            this.checkICS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkICS.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkICS.Name = "checkICS";
            this.checkICS.Ripple = true;
            this.checkICS.Size = new System.Drawing.Size(440, 23);
            this.checkICS.TabIndex = 0;
            this.checkICS.Text = "Enable ICS , require for sharing internet through Hotspot.";
            this.checkICS.UseVisualStyleBackColor = true;
            this.checkICS.CheckedChanged += new System.EventHandler(this.checkICS_CheckedChanged);
            // 
            // panel3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.groupICS);
            this.panel3.Controls.Add(this.materialDivider1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 136);
            this.panel3.TabIndex = 1;
            // 
            // groupICS
            // 
            this.groupICS.Controls.Add(this.btnSetICS);
            this.groupICS.Controls.Add(this.radioNetAdapter);
            this.groupICS.Controls.Add(this.radioNetName);
            this.groupICS.Controls.Add(this.comboNetwork);
            this.groupICS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupICS.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupICS.Location = new System.Drawing.Point(0, 0);
            this.groupICS.Name = "groupICS";
            this.groupICS.Size = new System.Drawing.Size(434, 136);
            this.groupICS.TabIndex = 2;
            this.groupICS.TabStop = false;
            this.groupICS.Text = "Choose Network to Share";
            // 
            // btnSetICS
            // 
            this.btnSetICS.Depth = 0;
            this.btnSetICS.Location = new System.Drawing.Point(6, 99);
            this.btnSetICS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSetICS.Name = "btnSetICS";
            this.btnSetICS.Primary = true;
            this.btnSetICS.Size = new System.Drawing.Size(140, 28);
            this.btnSetICS.TabIndex = 4;
            this.btnSetICS.Text = "Set Sharing";
            this.btnSetICS.UseVisualStyleBackColor = true;
            this.btnSetICS.Click += new System.EventHandler(this.btnSetICS_Click);
            // 
            // radioNetAdapter
            // 
            this.radioNetAdapter.AutoSize = true;
            this.radioNetAdapter.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioNetAdapter.Depth = 0;
            this.radioNetAdapter.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioNetAdapter.Location = new System.Drawing.Point(261, 56);
            this.radioNetAdapter.Margin = new System.Windows.Forms.Padding(0);
            this.radioNetAdapter.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioNetAdapter.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioNetAdapter.Name = "radioNetAdapter";
            this.radioNetAdapter.Ripple = true;
            this.radioNetAdapter.Size = new System.Drawing.Size(170, 30);
            this.radioNetAdapter.TabIndex = 3;
            this.radioNetAdapter.TabStop = true;
            this.radioNetAdapter.Text = "Show Network Adapter";
            this.radioNetAdapter.UseVisualStyleBackColor = true;
            this.radioNetAdapter.CheckedChanged += new System.EventHandler(this.radioNetAdapter_CheckedChanged);
            // 
            // radioNetName
            // 
            this.radioNetName.AutoSize = true;
            this.radioNetName.Depth = 0;
            this.radioNetName.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioNetName.Location = new System.Drawing.Point(3, 56);
            this.radioNetName.Margin = new System.Windows.Forms.Padding(0);
            this.radioNetName.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioNetName.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioNetName.Name = "radioNetName";
            this.radioNetName.Ripple = true;
            this.radioNetName.Size = new System.Drawing.Size(158, 30);
            this.radioNetName.TabIndex = 2;
            this.radioNetName.TabStop = true;
            this.radioNetName.Text = "Show Network Name";
            this.radioNetName.UseVisualStyleBackColor = true;
            this.radioNetName.CheckedChanged += new System.EventHandler(this.radioNetName_CheckedChanged);
            // 
            // comboNetwork
            // 
            this.comboNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboNetwork.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.comboNetwork.FormattingEnabled = true;
            this.comboNetwork.ItemHeight = 23;
            this.comboNetwork.Location = new System.Drawing.Point(3, 22);
            this.comboNetwork.Name = "comboNetwork";
            this.comboNetwork.Size = new System.Drawing.Size(428, 29);
            this.comboNetwork.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboNetwork.TabIndex = 0;
            this.comboNetwork.Theme = MetroFramework.MetroThemeStyle.Light;
            this.comboNetwork.SelectedIndexChanged += new System.EventHandler(this.comboNetwork_SelectedIndexChanged);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(-4, 3);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(442, 1);
            this.materialDivider1.TabIndex = 1;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // groupApperance
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupApperance, 2);
            this.groupApperance.Controls.Add(this.materialLabel5);
            this.groupApperance.Controls.Add(this.materialLabel4);
            this.groupApperance.Controls.Add(this.comboColorStyle);
            this.groupApperance.Controls.Add(this.comboTheme);
            this.groupApperance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupApperance.Location = new System.Drawing.Point(3, 193);
            this.groupApperance.Name = "groupApperance";
            this.groupApperance.Size = new System.Drawing.Size(446, 79);
            this.groupApperance.TabIndex = 1;
            this.groupApperance.TabStop = false;
            this.groupApperance.Text = "Appearance";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(227, 36);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(83, 19);
            this.materialLabel5.TabIndex = 3;
            this.materialLabel5.Text = "Color Style";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(6, 36);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(55, 19);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "Theme";
            // 
            // comboColorStyle
            // 
            this.comboColorStyle.FormattingEnabled = true;
            this.comboColorStyle.ItemHeight = 23;
            this.comboColorStyle.Location = new System.Drawing.Point(316, 30);
            this.comboColorStyle.Name = "comboColorStyle";
            this.comboColorStyle.Size = new System.Drawing.Size(121, 29);
            this.comboColorStyle.TabIndex = 1;
            this.comboColorStyle.SelectedIndexChanged += new System.EventHandler(this.comboColorStyle_SelectedIndexChanged);
            // 
            // comboTheme
            // 
            this.comboTheme.FormattingEnabled = true;
            this.comboTheme.ItemHeight = 23;
            this.comboTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.comboTheme.Location = new System.Drawing.Point(67, 30);
            this.comboTheme.Name = "comboTheme";
            this.comboTheme.Size = new System.Drawing.Size(140, 29);
            this.comboTheme.TabIndex = 0;
            this.comboTheme.SelectedIndexChanged += new System.EventHandler(this.comboTheme_SelectedIndexChanged);
            // 
            // groupStartUp
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupStartUp, 2);
            this.groupStartUp.Controls.Add(this.checkExit);
            this.groupStartUp.Controls.Add(this.checkStartUp2);
            this.groupStartUp.Controls.Add(this.checkStartUp1);
            this.groupStartUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStartUp.Location = new System.Drawing.Point(3, 278);
            this.groupStartUp.Name = "groupStartUp";
            this.groupStartUp.Size = new System.Drawing.Size(446, 147);
            this.groupStartUp.TabIndex = 2;
            this.groupStartUp.TabStop = false;
            this.groupStartUp.Text = "StartUp and Exit";
            // 
            // checkExit
            // 
            this.checkExit.Depth = 0;
            this.checkExit.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkExit.Location = new System.Drawing.Point(6, 109);
            this.checkExit.Margin = new System.Windows.Forms.Padding(0);
            this.checkExit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkExit.Name = "checkExit";
            this.checkExit.Ripple = true;
            this.checkExit.Size = new System.Drawing.Size(437, 25);
            this.checkExit.TabIndex = 2;
            this.checkExit.Text = "Close Hotspot on Exit.";
            this.checkExit.UseVisualStyleBackColor = true;
            // 
            // checkStartUp2
            // 
            this.checkStartUp2.Depth = 0;
            this.checkStartUp2.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkStartUp2.Location = new System.Drawing.Point(6, 70);
            this.checkStartUp2.Margin = new System.Windows.Forms.Padding(0);
            this.checkStartUp2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkStartUp2.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkStartUp2.Name = "checkStartUp2";
            this.checkStartUp2.Ripple = true;
            this.checkStartUp2.Size = new System.Drawing.Size(437, 25);
            this.checkStartUp2.TabIndex = 1;
            this.checkStartUp2.Text = "Automatically Start Hotspot on Computer Start up";
            this.checkStartUp2.UseVisualStyleBackColor = true;
            // 
            // checkStartUp1
            // 
            this.checkStartUp1.Depth = 0;
            this.checkStartUp1.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkStartUp1.Location = new System.Drawing.Point(6, 30);
            this.checkStartUp1.Margin = new System.Windows.Forms.Padding(0);
            this.checkStartUp1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkStartUp1.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkStartUp1.Name = "checkStartUp1";
            this.checkStartUp1.Ripple = true;
            this.checkStartUp1.Size = new System.Drawing.Size(437, 25);
            this.checkStartUp1.TabIndex = 0;
            this.checkStartUp1.Text = "Automatically Start on Computer Start Up";
            this.checkStartUp1.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.AutoScroll = true;
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Controls.Add(this.linkLabel3);
            this.tabAbout.Controls.Add(this.label9);
            this.tabAbout.Controls.Add(this.treeView1);
            this.tabAbout.Controls.Add(this.label8);
            this.tabAbout.Controls.Add(this.label5);
            this.tabAbout.Controls.Add(this.groupBox1);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Controls.Add(this.label3);
            this.tabAbout.Controls.Add(this.label2);
            this.tabAbout.Controls.Add(this.label1);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(458, 434);
            this.tabAbout.TabIndex = 5;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            this.tabAbout.Click += new System.EventHandler(this.tabAbout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotspotClient.Properties.Resources._1460729544_ic_signal_wifi_2_bar_48px;
            this.pictureBox1.Location = new System.Drawing.Point(106, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.Location = new System.Drawing.Point(39, 162);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(327, 15);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "http://ashutoshvarma.me/projects/hotspothandler/";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Raleway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "Project Webpage :-";
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Indent = 19;
            this.treeView1.Location = new System.Drawing.Point(41, 363);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node6";
            treeNode1.Text = "Github :- https://github.com/IgnaceMaes/MaterialSkin/";
            treeNode2.Name = "Node5";
            treeNode2.NodeFont = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "MaterialSkin by IgnaceMaes";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Github :- https://github.com/thielj/MetroFramework";
            treeNode4.Name = "Node7";
            treeNode4.NodeFont = new System.Drawing.Font("Raleway", 8.999999F);
            treeNode4.Text = "MetroFramework by thielj";
            treeNode5.Name = "Node10";
            treeNode5.Text = "CodeProject  :- http://www.codeproject.com/Articles/442983/Android-Style-Toast-No" +
    "tification-for-NET";
            treeNode6.Name = "Node9";
            treeNode6.NodeFont = new System.Drawing.Font("Raleway", 8.999999F);
            treeNode6.Text = "Android-Style (Toast) Notification for .NET by John Espiritu";
            treeNode7.Name = "Node12";
            treeNode7.Text = "License : - http://creativecommons.org/licenses/by-sa/3.0/";
            treeNode8.Name = "Node11";
            treeNode8.NodeFont = new System.Drawing.Font("Raleway", 8.999999F);
            treeNode8.Text = "2, bar, signal, wifi icon";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(396, 89);
            this.treeView1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Raleway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "Open Source Licenses :-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ashutosh Varma";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(41, 243);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(375, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(98, 37);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(237, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://plus.google.com/+AshutoshVarmaOfficial";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Google Plus  :- ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(100, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(177, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/ashutoshvarma/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Github Profile : -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Raleway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contributors : -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "This a simple project which uses netsh commands to setup and \r\ncontrol Hotspot(ho" +
    "stednetwork) on computer having supported\r\n network adapter card.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version - 1.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "HotspotHandler";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.TabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 63);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(465, 59);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // processbar
            // 
            this.processbar.Depth = 0;
            this.processbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.processbar.Location = new System.Drawing.Point(0, 578);
            this.processbar.MarqueeAnimationSpeed = 1000000;
            this.processbar.MouseState = MaterialSkin.MouseState.HOVER;
            this.processbar.Name = "processbar";
            this.processbar.Size = new System.Drawing.Size(465, 5);
            this.processbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.processbar.TabIndex = 3;
            this.processbar.Value = 100;
            // 
            // workerHostspotSupport
            // 
            this.workerHostspotSupport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerHostspotSupport_DoWork);
            this.workerHostspotSupport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerHostspotSupport_RunWorkerCompleted);
            // 
            // workerICSChange
            // 
            this.workerICSChange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerICSChange_DoWork);
            this.workerICSChange.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerICSChange_RunWorkerCompleted);
            // 
            // workerStart
            // 
            this.workerStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerStart_DoWork);
            this.workerStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerStart_RunWorkerCompleted);
            // 
            // workerStop
            // 
            this.workerStop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerStop_DoWork);
            this.workerStop.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerStop_RunWorkerCompleted);
            // 
            // workerRefresh
            // 
            this.workerRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerRefresh_DoWork);
            this.workerRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerRefresh_RunWorkerCompleted);
            // 
            // workerUI
            // 
            this.workerUI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerUI_DoWork);
            this.workerUI.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerUI_RunWorkerCompleted);
            // 
            // workerDevices
            // 
            this.workerDevices.WorkerSupportsCancellation = true;
            this.workerDevices.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDevices_DoWork);
            this.workerDevices.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerDevices_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(465, 583);
            this.Controls.Add(this.processbar);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(465, 583);
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotspotHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.Leave += new System.EventHandler(this.MainForm_Leave);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupICS.ResumeLayout(false);
            this.groupICS.PerformLayout();
            this.groupApperance.ResumeLayout(false);
            this.groupApperance.PerformLayout();
            this.groupStartUp.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

       

        #endregion

        private MaterialSkin.Controls.MaterialTabControl TabControl1;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabAbout;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRaisedButton btnHotspot;
        private System.Windows.Forms.Panel panelControl;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPass;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSSID;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton btnRefreshDetails;
        private System.Windows.Forms.PropertyGrid property1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialCheckBox checkICS;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.GroupBox groupICS;
        private MaterialSkin.Controls.MaterialListView _listview;
        private MetroFramework.Controls.MetroComboBox comboNetwork;
        private MaterialSkin.Controls.MaterialRadioButton radioNetAdapter;
        private MaterialSkin.Controls.MaterialRadioButton radioNetName;
        private MaterialSkin.Controls.MaterialRaisedButton btnSetICS;
        private System.Windows.Forms.GroupBox groupApperance;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.GroupBox groupStartUp;
        private MaterialSkin.Controls.MaterialCheckBox checkStartUp2;
        private MaterialSkin.Controls.MaterialCheckBox checkStartUp1;
        private MaterialSkin.Controls.MaterialCheckBox checkExit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialProgressBar processbar;
        private System.ComponentModel.BackgroundWorker workerHostspotSupport;
        private System.ComponentModel.BackgroundWorker workerICSChange;
        private MetroFramework.Controls.MetroComboBox comboColorStyle;
        private MetroFramework.Controls.MetroComboBox comboTheme;
        private System.ComponentModel.BackgroundWorker workerStart;
        private System.ComponentModel.BackgroundWorker workerStop;
        private System.ComponentModel.BackgroundWorker workerRefresh;
        private System.ComponentModel.BackgroundWorker workerUI;
        private System.ComponentModel.BackgroundWorker workerDevices;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}