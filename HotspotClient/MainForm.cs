using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using VarmaHotspot;
using System.Net.NetworkInformation;
using Notification;




namespace HotspotClient
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {


        #region DECLARATIONS

        public AppSettings Settings;

        public MaterialSkinManager skinManager;
        public int pause = 0;

        Hotspot.Details det;
        Hotspot htspot;

        Win32_NetAdapter winAdapters;

        Control parent;

        #endregion



        #region Methods
        public MainForm()
        {
            InitializeComponent();

            htspot = new Hotspot();
            Settings = AppSettings.Instance;
            Settings.Load();
            initGUI();
            parent = this;


        }
        public void initGUI()
        {
            //MaterialSkin Formatting


            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            ColorScheme clrscheme = skinManager.ColorScheme;

            //applying same formatting to all
            materialLabel3.BackColor = clrscheme.TextColor;
            groupBox3.ForeColor = clrscheme.DarkPrimaryColor;
            groupBox3.Font = skinManager.ROBOTO_MEDIUM_10;
            groupApperance.ForeColor = clrscheme.DarkPrimaryColor;
            groupApperance.Font = skinManager.ROBOTO_MEDIUM_10;

            groupStartUp.ForeColor = clrscheme.DarkPrimaryColor;
            groupStartUp.Font = skinManager.ROBOTO_MEDIUM_10;

            //adding items in ColorStyle Combobox
            foreach (string s in new ColorStyle().StyleNames)
            {
                comboColorStyle.Items.Add(s);
            }

            //ICS Checkbox initialising
            groupICS.Enabled = Settings.ICS;
            checkICS.Checked = Settings.ICS;

            //Comboboxs of Apperance initialising
            comboTheme.SelectedIndex = Settings.ThemeID;
            comboColorStyle.SelectedIndex = Settings.ColorID;

            //radiobuttons of Network Name or Adapter initialising
            if (Settings.ShowNetworkName)
            {
                radioNetName.Checked = Settings.ShowNetworkName;
            }
            else
            {
                radioNetAdapter.Checked = true;
            }


            //Determine the hotspot state to set the main button text and Title of Form.

            if (htspot.HostedNetworkStatus())
            {
                btnHotspot.Text = "Stop";
                this.Text = "HotspotHandler - Running";
                panelControl.Enabled = false;
            }
            else
            {
                btnHotspot.Text = "Start";
                this.Text = "HotspotHandler - Stopped";
                panelControl.Enabled = true;
            }


            txtPass.Text = Settings.Password;
            txtSSID.Text = Settings.SSID;


        }


        public void SetNetworkinComboNetwork()
        {
            try
            {
                comboNetwork.Items.Clear();

                radioNetAdapter.Enabled = false;
                radioNetName.Enabled = false;

                winAdapters = new Win32_NetAdapter((@"SELECT *  FROM   Win32_NetworkAdapter WHERE  NetEnabled = True "));

                foreach (NetworkAdapter n in winAdapters.GetAdapters())
                {
                    if (n.Name.Contains("Virtual") || n.Name.Contains("Hosted")) continue;

                    comboNetwork.Items.Add(Settings.ShowNetworkName ? n.NetConnectionID : n.Name);

                }


            }
            catch
            {
                comboNetwork.Items.Clear();
            }
            finally
            {
                radioNetAdapter.Enabled = true;
                radioNetName.Enabled = true;
            }
        }

        public void HostedNetworkSupport()
        {
            string reason;
            if (!htspot.IsHostedNetworkSupported(out reason))
            {
                Settings.IsHotspotSupported = false;
                groupControl.Enabled = false;
                btnRefreshDetails.Enabled = false;

                groupBox3.Enabled = false;
                groupStartUp.Enabled = false;

                switch (reason)
                {
                    case "HOSTEDNETWORK_NOT_SUPPORTED":
                        InfoBox.ShowDialogStatic(new Size(600, 200), "Hotspot Not Supported", Environment.NewLine + "Your Computer does not support creating Hotspot. Try to upgrade your wifi router/card.", InfoBox.InfoStyle.Error);
                        break;

                    case "OTHER":
                        InfoBox.ShowDialogStatic(new Size(500, 220), "Hotspot May Not Be Supported", Environment.NewLine + "We have detected Hotspot adapter(" + new HostedNetworkAdapter().GetAdapter().Name + ")" + " in your system but not able to detect support for Hotspot creating.", InfoBox.InfoStyle.Info);
                        break;

                    case "ADAPTER_NOT_FOUND":
                        InfoBox.ShowDialogStatic(new Size(500, 220), "Hotspot Adapter Not Found", Environment.NewLine + "No virtual adapter found in you system , Please make sure Microsoft Virtual Network Adapters are installed , if not please install them because without them Hotspot could not be start.", InfoBox.InfoStyle.Hand);
                        break;

                    case "SUCCESS":
                        Settings.IsHotspotSupported = true;
                        groupControl.Enabled = true;
                        btnRefreshDetails.Enabled = true;

                        groupBox3.Enabled = true;
                        groupStartUp.Enabled = true;

                        break;

                }
            }
        }






        #endregion



        #region EventListeners
        private void MainForm_Load(object sender, EventArgs e)
        {

            workerHostspotSupport.RunWorkerAsync();//Check for hostednetwork support, if not supported then set the setting to false, and disable some of controls.

            SetNetworkinComboNetwork(); // Display the networks in comboNetwork

            if (!workerRefresh.IsBusy)
            {
                workerRefresh.RunWorkerAsync();
            }
            timer1.Start();






        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Settings.Save();

            timer1.Stop();
            timer1.Dispose();

            if (workerDevices.IsBusy) workerDevices.CancelAsync();
            workerDevices.Dispose();

            workerHostspotSupport.Dispose();

            workerICSChange.Dispose();

            workerRefresh.Dispose();

            workerStart.Dispose();

            workerStop.Dispose();

            workerUI.Dispose();




        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            if (!workerUI.IsBusy)
            {
                workerUI.RunWorkerAsync();
            }
            timer1.Start();

        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            if (!workerUI.IsBusy)
            {
                workerUI.RunWorkerAsync();

            }
            timer1.Stop();
        }


        private void radioNetName_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowNetworkName = radioNetName.Checked;
            SetNetworkinComboNetwork();

        }

        private void radioNetAdapter_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowNetworkName = radioNetName.Checked;
            SetNetworkinComboNetwork();


        }

        private void checkICS_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ICS = checkICS.Checked;
            groupICS.Enabled = checkICS.Checked;
            Settings.ICSAdapterGUID = "";
        }

        private void comboColorStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

            ColorStyle clr = new ColorStyle();
            Settings.ColorID = comboColorStyle.SelectedIndex;
            switch (comboColorStyle.SelectedIndex)
            {
                case 0:
                    skinManager.ColorScheme = clr.Blue;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Blue;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Blue;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Blue;
                    break;

                case 1:
                    skinManager.ColorScheme = clr.Green;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Green;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Green;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Green;
                    break;

                case 2:
                    skinManager.ColorScheme = clr.Red;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Red;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Red;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Red;
                    break;

                case 3:
                    skinManager.ColorScheme = clr.Pink;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Pink;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Pink;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case 4:
                    skinManager.ColorScheme = clr.DarkGreen;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Teal;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Teal;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Teal;
                    break;

                default:
                    skinManager.ColorScheme = clr.Blue;

                    comboNetwork.Style = MetroFramework.MetroColorStyle.Blue;
                    comboColorStyle.Style = MetroFramework.MetroColorStyle.Blue;
                    comboTheme.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
            }


        }

        private void comboTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            Settings.ThemeID = comboTheme.SelectedIndex;
            switch (comboTheme.SelectedIndex)
            {
                case 0:
                    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                    break;

                //case 1:
                //    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                //    break;

                default:
                    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                    break;

            }
        }


        private void btnHotspot_Click(object sender, EventArgs e)
        {
            try
            {

                switch (btnHotspot.Text)
                {
                    case "Stop":
                        btnHotspot.Enabled = false;
                        workerStop.RunWorkerAsync();
                        break;

                    case "Start":
                        if (txtPass.Text.Length > 7 && txtSSID.Text.Length > 0)
                        {
                            btnHotspot.Enabled = false;
                            Tuple<string, string> args = new Tuple<string, string>(txtSSID.Text, txtPass.Text);
                            workerStart.RunWorkerAsync(args);

                        }
                        else
                        {
                            InfoBox.ShowDialogStatic(new Size(400, 160), "Invalid Entry", "Please Enter Password atleast 8 char long and SSID should not be null.", InfoBox.InfoStyle.Info);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                NotificationManager.Show(ref parent, ex.Message, skinManager.ColorScheme.DarkPrimaryColor, 4000);
            }

        }

        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
            btnRefreshDetails.Enabled = false;
            if (!workerRefresh.IsBusy)
            {
                workerRefresh.RunWorkerAsync();
            }

        }



        private void btnSetICS_Click(object sender, EventArgs e)
        {
            if (comboNetwork.SelectedItem != null)
            {
                comboNetwork.Enabled = false;
                checkICS.Enabled = false;
                radioNetAdapter.Enabled = false;
                radioNetName.Enabled = false;
                workerICSChange.RunWorkerAsync(comboNetwork.SelectedItem.ToString());

            }
            else
            {
                InfoBox.ShowDialogStatic(new Size(400, 200), "No Network Selected", "No Network selected . Please select network , if available.");
            }
        }


        private void tabDetails_Enter(object sender, EventArgs e)
        {
            if (!workerRefresh.IsBusy)
            {
                workerRefresh.RunWorkerAsync();
            }
        }



        #endregion





        #region BackGroundWorkers

        private void workerHostspotSupport_DoWork(object sender, DoWorkEventArgs e)
        {
            string reason;
            e.Result = new Tuple<bool, string>(htspot.IsHostedNetworkSupported(out reason), reason);

        }
        private void workerHostspotSupport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Tuple<bool, string> result = (Tuple<bool, string>)e.Result;

                if (!result.Item1)
                {
                    Settings.IsHotspotSupported = false;
                    groupControl.Enabled = false;
                    btnRefreshDetails.Enabled = false;

                    groupBox3.Enabled = false;
                    groupStartUp.Enabled = false;

                    switch (result.Item2)
                    {
                        case "HOSTEDNETWORK_NOT_SUPPORTED":
                            InfoBox.ShowDialogStatic(new Size(600, 200), "Hotspot Not Supported", Environment.NewLine + "Your Computer does not support creating Hotspot. Try to upgrade your wifi router/card.", InfoBox.InfoStyle.Error);
                            break;

                        case "OTHER":
                            InfoBox.ShowDialogStatic(new Size(500, 220), "Hotspot May Not Be Supported", Environment.NewLine + "We have detected Hotspot adapter(" + new HostedNetworkAdapter().GetAdapter().Name + ")" + " in your system but not able to detect support for Hotspot creating.", InfoBox.InfoStyle.Info);
                            break;

                        case "ADAPTER_NOT_FOUND":
                            InfoBox.ShowDialogStatic(new Size(500, 220), "Hotspot Adapter Not Found", Environment.NewLine + "No virtual adapter found in you system , Please make sure Microsoft Virtual Network Adapters are installed , if not please install them because without them Hotspot could not be start.", InfoBox.InfoStyle.Hand);
                            break;

                    }
                }
                else
                {
                    Settings.IsHotspotSupported = true;
                    groupControl.Enabled = true;
                    btnRefreshDetails.Enabled = true;

                    groupBox3.Enabled = true;
                    groupStartUp.Enabled = true;
                }
            }
            else
            {
                // if some error occured then assume that hotspot not supported.
                Settings.IsHotspotSupported = false;
            }
        }





        private void workerICSChange_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                winAdapters.Refresh();
                NetworkAdapter found = new NetworkAdapter();

                //if network exists , then save it in found variable.
                foreach (NetworkAdapter n in winAdapters.GetAdapters())
                {
                    if (Settings.ShowNetworkName)
                    {
                        if (n.NetConnectionID == (string)e.Argument)
                        {
                            found = n;
                            break;
                        }
                    }
                    else
                    {
                        if (n.Name == (string)e.Argument)
                        {
                            found = n;
                            break;
                        }
                    }
                }



                if (found.Name != null && found.SystemName != null)
                {


                    if (htspot.HostedNetworkStatus())
                    {

                        NetworkAdapter htadap = new HostedNetworkAdapter().GetAdapter();

                        if (htspot.SetICS(found.NetConnectionID, htadap.NetConnectionID, true))
                        {
                            //e.Result = "SUCESS_ICS_ENABLED";
                            e.Result = new Tuple<string, NetworkAdapter>("SUCESS_ICS_ENABLED", found);

                        }
                        else
                        {
                            e.Result = "ERROR_BUT_HOTSPOT_RUNNING";
                        }


                    }
                    else
                    {
                        Settings.ICSAdapterGUID = found.GUID;

                        //e.Result = "SETTINGS_SAVED";
                        e.Result = new Tuple<string, NetworkAdapter>("SETTINGS_SAVED", found);
                    }



                }
                else
                {
                    e.Result = "NOT_FOUND";
                }


            }
            catch (Exception ex)
            {
                e.Result = ex;
            }

        }
        private void workerICSChange_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboNetwork.Enabled = true;
            checkICS.Enabled = true;

            radioNetAdapter.Enabled = true;
            radioNetName.Enabled = true;

            switch (e.Result.ToString())
            {

                case "NOT_FOUND":
                    InfoBox.ShowDialogStatic(new Size(400, 200), "Network Not Found", "Selected Network was not found. Please select network again.", InfoBox.InfoStyle.Warning);
                    break;

                case "ERROR_BUT_HOTSPOT_RUNNING":
                    InfoBox.ShowDialogStatic(new Size(414, 190), "Error", "Unable to Start ICS(Internet Connection Sharing)." + Environment.NewLine + "Hotspot is running but not able to share internet.", InfoBox.InfoStyle.Warning);
                    break;

                default:
                    if (e.Result.GetType() == typeof(Exception))
                    {
                        Exception ex = (Exception)e.Result;
                        InfoBox.ShowDialogStatic(new Size(414, 400), "Error", Environment.NewLine + "Unable to Start ICS(Internet Connection Sharing)." + Environment.NewLine + "Due to some unknown error , please try again." + Environment.NewLine + ex.Message, InfoBox.InfoStyle.Error);
                    }
                    else if (e.Result.GetType() == typeof(Tuple<string, NetworkAdapter>))
                    {
                        Tuple<string, NetworkAdapter> tup = (Tuple<string, NetworkAdapter>)e.Result;

                        switch (tup.Item1)
                        {
                            case "SUCESS_ICS_ENABLED":
                                InfoBox.ShowDialogStatic(new Size(414, 240), "Successfull", "ICS(Internet Connection Sharing) has been enabled. '" + Environment.NewLine + tup.Item2.NetConnectionID + "' network is been share on Hotspot.", InfoBox.InfoStyle.Info);
                                break;

                            case "SETTINGS_SAVED":
                                InfoBox.ShowDialogStatic(new Size(500, 250), "Saved", "ICS settings have been saved and ICS will be enabled when Hotspot starts." + Environment.NewLine + Environment.NewLine + "Network Choose :-  " + (Settings.ShowNetworkName ? tup.Item2.NetConnectionID : tup.Item2.Name) + Environment.NewLine + "       GUID :-  " + tup.Item2.GUID + Environment.NewLine + "       Manufacturer :-  " + tup.Item2.Manufacturer, InfoBox.InfoStyle.Info);
                                break;
                        }


                    }
                    break;

            }

        }




        private void workerStart_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<string, string> args = (Tuple<string, string>)e.Argument;

            htspot = new Hotspot(args.Item1, args.Item2);
            ProcessResult startRes = htspot.Start();


            if (startRes.ExitCode == 0 || htspot.HostedNetworkStatus())
            {

                if (Settings.ICS && Settings.ICSAdapterGUID != "")
                {
                    winAdapters.Refresh();
                    NetworkAdapter found = new NetworkAdapter();

                    //if network exists , then save it in found variable.
                    foreach (NetworkAdapter n in winAdapters.GetAdapters())
                    {
                        if (n.GUID == Settings.ICSAdapterGUID)
                        {
                            found = n;
                            break;
                        }
                    }


                    if (found.Name != null && found.SystemName != null)
                    {
                        NetworkAdapter htadap = new HostedNetworkAdapter().GetAdapter();

                        if (htspot.SetICS(found.NetConnectionID, htadap.NetConnectionID, true))
                        {
                            //e.Result = "SUCESS_ICS_ENABLED";
                            e.Result = "SUCESS";

                        }
                        else
                        {
                            e.Result = "ERROR_ICS_BUT_HOTSPOT_RUNNING";
                        }
                    }
                    else
                    {
                        e.Result = "ICS_ADAPTER_NOT_FOUND";
                    }


                }
                else
                {
                    e.Result = "SUCESS";
                }



            }
            else
            {
                if (startRes.ExitCode == 1)
                {
                    e.Result = new Tuple<string, string>("ERROR_STARTING", startRes.Output);
                }
                else
                {
                    e.Result = "UNKNOWN_ERROR";
                }

            }

        }
        private void workerStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnHotspot.Enabled = true;
            //Set button 
            if (htspot.HostedNetworkStatus())
            {
                btnHotspot.Text = "Stop";
                this.Text = " HotspotHandler - Running";
                panelControl.Enabled = false;
            }

            if (!workerRefresh.IsBusy)
            {
                workerRefresh.RunWorkerAsync();
            }

            switch (e.Result.ToString())
            {
                case "SUCESS":
                    Settings.SSID = txtSSID.Text;
                    Settings.Password = txtPass.Text;
                    NotificationManager.Show(ref parent, "Hotspot Started Sucessfully", skinManager.ColorScheme.DarkPrimaryColor, 3000);

                    break;

                case "ERROR_ICS_BUT_HOTSPOT_RUNNING":
                    Settings.SSID = txtSSID.Text;
                    Settings.Password = txtPass.Text;

                    InfoBox.ShowDialogStatic(new Size(414, 190), "Error", "Unable to Start ICS(Internet Connection Sharing)." + Environment.NewLine + "Hotspot is running but not able to share internet.", InfoBox.InfoStyle.Warning);
                    Settings.ICSAdapterGUID = "";
                    break;

                case "ICS_ADAPTER_NOT_FOUND":
                    InfoBox.ShowDialogStatic(new Size(414, 190), "Error", "Unable to Start ICS(Internet Connection Sharing) because Network for ICS not found." + Environment.NewLine + "Hotspot is running but not able to share internet.", InfoBox.InfoStyle.Warning);
                    Settings.ICSAdapterGUID = "";
                    break;

                case "UNKNOWN_ERROR":
                    InfoBox.ShowDialogStatic(new Size(300, 170), "Error Starting", "Hotspot was not able to start due to unknown error.");
                    break;

                default:
                    if (e.Result.GetType() == typeof(Tuple<string, string>))
                    {
                        Tuple<string, string> tup = (Tuple<string, string>)e.Result;

                        if (tup.Item1 == "ERROR_STARTING") InfoBox.ShowDialogStatic(new Size(300, 170), "Error Starting", tup.Item2);

                    }
                    break;

            }
        }





        private void workerStop_DoWork(object sender, DoWorkEventArgs e)
        {
            if (htspot.HostedNetworkStatus())
            {
                ProcessResult restop = htspot.Stop();

                if (restop.ExitCode == 0 && htspot.HostedNetworkStatus())
                {
                    e.Result = "SUCESS";
                }
                else if (restop.ExitCode == 1)
                {
                    e.Result = new Tuple<string, string>("ERROR_STOPPING", restop.Output);
                }


            }
            else
            {
                e.Result = "RUNNING";
            }
        }
        private void workerStop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            btnHotspot.Enabled = true;
            //Set button 
            if (!htspot.HostedNetworkStatus())
            {
                btnHotspot.Text = "Start";
                this.Text = " HotspotHandler - Stopped";
                panelControl.Enabled = true;
            }

            if (!workerRefresh.IsBusy)
            {
                workerRefresh.RunWorkerAsync();
            }


            if (e.Result != null)
            {
                switch (e.Result.ToString())
                {
                    case "SUCESS":
                        NotificationManager.Show(ref parent, "Hotspot Stopped", skinManager.ColorScheme.DarkPrimaryColor, 3000);

                        break;

                    default:
                        if (e.Result.GetType() == typeof(Tuple<string, string>))
                        {
                            Tuple<string, string> tup = (Tuple<string, string>)e.Result;
                            if (tup.Item1 == "ERROR_STOPPING") InfoBox.ShowDialogStatic(new Size(300, 170), "Error Stopping", "Hotspot was not able to stop." + Environment.NewLine + tup.Item2);

                        }
                        break;
                }
            }
        }




        private void workerRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                det = new Hotspot.Details();
                e.Result = det;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void workerRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRefreshDetails.Enabled = true;

            if (e.Result.GetType() == typeof(Hotspot.Details))
            {
                property1.SelectedObject = (Hotspot.Details)e.Result;
            }
            else if (e.Result.GetType() == typeof(Exception))
            {
                Exception ex = (Exception)e.Result;
                InfoBox.ShowDialogStatic(new Size(300, 300), "Problem Finding Details", "Details of Hotspot was successfully loaded." + Environment.NewLine + ex.Message);
            }
        }




        private void workerUI_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = htspot.HostedNetworkStatus();
        }
        private void workerUI_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                btnHotspot.Text = "Stop";
                this.Text = "HotspotHandler - Running";
                panelControl.Enabled = false;

            }
            else
            {
                btnHotspot.Text = "Start";
                this.Text = " HotspotHandler - Stopped";
                panelControl.Enabled = true;

            }
        }






        private void workerDevices_DoWork(object sender, DoWorkEventArgs e)
        {



            string tup = (string)e.Argument;
            ListViewItem[] lists;


            if (tup == "ONLY_DEVICES")
            {


                if (det == null) det = new Hotspot.Details();
                if (det.Devices != null)
                {
                    lists = new ListViewItem[det.Devices.Length];
                    int j = 0;
                    foreach (ConnectedDevice n in det.Devices)
                    {
                        lists[j] = new ListViewItem(new string[] { n.Name, n.MacAddress });
                        j++;
                    }
                }
                else
                {
                    lists = new ListViewItem[0];
                }
                e.Result = lists;
            }
            else if (tup == "ALL")
            {


                if (det == null) det = new Hotspot.Details();
                if (det.Devices != null)
                {
                    lists = new ListViewItem[det.Devices.Length];
                    int j = 0;
                    foreach (ConnectedDevice n in det.Devices)
                    {
                        lists[j] = new ListViewItem(new string[] { n.Name, n.MacAddress });
                        j++;
                    }
                }
                else
                {
                    lists = new ListViewItem[0];
                }



                string[] macCompany = new string[lists.Length];

                int w = 0;
                foreach (ListViewItem list in lists)
                {
                    try
                    {
                        VarmaHotspot.Hotspot.MacLookUp maclook = new VarmaHotspot.Hotspot.MacLookUp(list.SubItems[1].Text);
                        macCompany[w] = maclook.Comapny;
                    }
                    catch
                    {
                        macCompany[w] = "";
                    }
                    w++;
                }


                int z = 0;
                foreach (string s in macCompany)
                {

                    lists[z].SubItems.Add(s);
                    z++;
                }

                e.Result = lists;



            }


        }

        private void workerDevices_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _listview.Items.Clear();

            ListViewItem[] a = (ListViewItem[])(e.Result);



            foreach (ListViewItem li in a)
            {
                _listview.Items.Add(li);
            }



        }


        #endregion

        private void materialLabel3_Click(object sender, EventArgs e)
        {
            if (!workerDevices.IsBusy)
            {
                ListViewItem[] lists = new ListViewItem[_listview.Items.Count];
                _listview.Items.CopyTo(lists, 0);
                workerDevices.RunWorkerAsync("ALL");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ListViewItem[] lists = new ListViewItem[_listview.Items.Count];
            _listview.Items.CopyTo(lists, 0);


            if (!workerDevices.IsBusy)
            {
                workerDevices.RunWorkerAsync("ALL");
            }
            if (!workerUI.IsBusy)
            {
                workerUI.RunWorkerAsync();
            }
        }



        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void tabAbout_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel l = (LinkLabel)sender;
            System.Diagnostics.Process.Start(l.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void comboNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NetworkInterface best = NativeHelper.GetBestNetworkInterface("www.google.com");
                if (best.Name == comboNetwork.SelectedItem.ToString() || best.Description == comboNetwork.SelectedItem.ToString())
                {
                    NotificationManager.Show(ref parent, comboNetwork.SelectedItem.ToString() + " is connected to internet", skinManager.ColorScheme.DarkPrimaryColor, 2000);

                }
                else
                {
                    NotificationManager.Show(ref parent, comboNetwork.SelectedItem.ToString() + " is NOT connected to internet", skinManager.ColorScheme.DarkPrimaryColor, 2000);
                }
            }
            catch
            {

            }
        }


    }





}
