using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using icsmanager;


namespace VarmaHotspot
{

    /// <summary>
    /// NetworkAdapter structure which contains basic properties.
    /// </summary>
    public struct NetworkAdapter
    {

        public string Name;

        public string AdapterType;

        public int Availability;

        public string Caption;

        public string Description;

        public string DeviceID;

        public string GUID;

        public bool Installed;

        public string MACAddress;

        public string Manufacturer;

        public string NetConnectionID;

        public int NetConnectionStatus;

        public bool NetEnabled;

        public string ProductName;

        public string ServiceName;

        public string Status;

        public int StatusInfo;

        public string SystemName;



    } //Structure for adapters properties.
    public enum NetConnectionStatus : uint
    {
        Disconnected = 0,
        Connecting,
        Connected,
        Disconnecting,
        Hardware_Not_Present,
        Hardware_Disabled,
        Hardware_Malfunction,
        Media_Disconnected,
        Authenticating,
        Authentication_Succeeded,
        Authentication_Failed,
        Invalid_Address,
        Credentials_Required,
        Other
    }

    /// <summary>
    /// ProcessResult,contains Output & ExitCode of Process.
    /// </summary>
    public struct ProcessResult
    {
        public string Output;
        public int ExitCode;

    }

    /// <summary>
    /// Conatins Mac & Name of device.
    /// </summary>
    public struct ConnectedDevice
    {
        public string Name;
        public string MacAddress;
    }



    /// <summary>
    /// Class which have main methods like <c>Start()</c>,<c>Stop()</c>,<c>Execute()</c>. It also have reference to <c>icsmanager</c> to manage ICS.
    /// </summary>
    /// <remarks>Sub class are <c>Details</c> and <c>MacLookup</c></remarks>
    public class Hotspot
    {

        public ICSManager ics = new ICSManager();

        private const string STOP_ARGUMENTS = "wlan stop hostednetwork";
        private const string SHOW_HOTSPOT = "wlan show hostednetwork";
        private const string SHOW_DRIVERS = "wlan show drivers";


        private string m_key = "";
        private string m_ssid = "";


        /// <summary>
        /// Password to hostednetwork
        /// </summary>
        public string Key
        {
            get
            {
                return m_key;
            }

        } //Readonly 


        /// <summary>
        /// SSID of hostednetwork
        /// </summary>
        public string SSID
        {
            get
            {
                return m_ssid;
            }

        } //Readonly 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="pass"></param>
        public Hotspot(string ssid, string pass)
        {
            m_key = pass;
            m_ssid = ssid;
        }


        /// <summary>
        /// Hotspot object to get various functions without passing details of Hotspot , do not use methods like <c>Start()</c>,<c>Stop()</c>.
        /// </summary>
        /// <remarks>It contains <c>IsHostedNetworkSupported()</c> , <c>HostedNetworkStatus()</c> methods</remarks>
        /// 
        public Hotspot()
        {

        }


        /// <summary>
        /// Returns whether HostedNetwork is Supported or Not.
        /// </summary>
        /// <param name="Error">return <code>"HOSTEDNETWORK_NOT_SUPPORTED"</code> , <code>"ADAPTER_NOT_FOUND"</code> , <code>"SUCCESS"</code></param>
        /// <returns>True-if supported & flase-if not supported.</returns>
        public bool IsHostedNetworkSupported(out string Error)
        {
            HostedNetworkAdapter adap = new HostedNetworkAdapter();
            NetworkAdapter adapter = adap.GetAdapter();

            if (adapter.Name != null && adapter.Manufacturer != null && adapter.Caption != null && adapter.SystemName != null)
            {

                ProcessResult res = Execute(SHOW_DRIVERS);
                if (res.ExitCode == 0)
                {
                    if (res.Output.Contains("Hosted network supported  : Yes"))
                    {
                        Error = "SUCCESS";
                        return true;
                    }
                    else
                    {
                        Error = "HOSTEDNETWORK_NOT_SUPPORTED";
                        return false;
                    }

                }
                else
                {
                    Error = "OTHER";
                    return false;
                }
            }
            else
            {
                Error = "ADAPTER_NOT_FOUND";
                return false;
            }



        }


        /// <summary>
        /// Status of HostedNetwork Adapter.
        /// </summary>
        /// <returns>True-if Adapter running & False-if adapter not running</returns>
        /// <remarks>It checks <c>NetConnectionStatus</c> , <c>NetEnabled</c> , <c>GUID</c> to tell whether running or not.</remarks>
        public bool HostedNetworkStatus()
        {
            HostedNetworkAdapter adap = new HostedNetworkAdapter();
            NetworkAdapter adapter = adap.GetAdapter();

            if (adapter.NetConnectionStatus == 2 && adapter.NetEnabled != false && adapter.GUID != null)
            {
                adap.Dispose();
                return true;
            }
            else
            {
                adap.Dispose();
                return false;
            }

        }


        /// <summary>
        /// Converts UNICODE to ASCII strings.
        /// </summary>
        /// <param name="a">String to convert</param>
        /// <returns>ASCII string</returns>
        public string ConvertedASCII(string a)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            Byte[] encodedBytes = ascii.GetBytes(a);
            string start = ascii.GetString(encodedBytes);

            return start;
        }  //ConvertedASCII Function


        /// <summary>
        /// Executes arguments to netsh.exe
        /// </summary>
        /// <param name="arguments">Arguments to pass</param>
        /// <returns>Return a <c>ProcessResult</c> type which contain Output & ExitCode</returns>
        /// <remarks>If due to some error enable to start process , return <c>ProcessResult</c> with ExitCode=1 & Output=<code>ex.Message</code></remarks>
        public ProcessResult Execute(string arguments)
        {
            ProcessResult proc_output = new ProcessResult();
            try
            {
                Process proc = new Process
                {
                    StartInfo =
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        FileName = Environment.SystemDirectory + "\\netsh.exe",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        Arguments = arguments
                    }
                };



                proc.Start();

                proc.WaitForExit();

                int exitCode = proc.ExitCode;
                string output = proc.StandardOutput.ReadToEnd();



                proc_output.ExitCode = exitCode;
                proc_output.Output = output;

                return proc_output;
            }
            catch (Exception ex)
            {
                proc_output.ExitCode = 1;
                proc_output.Output = ex.Message;
                return proc_output;

            }

        } //Executes commands and return <c>ProcessOutput</c> which contains Output & ExitCode.


        /// <summary>
        /// Start the hotspot
        /// </summary>
        /// <returns>ProcessResult type</returns>
        /// <remarks>it use <c>Execute()</c> function to stop hotspot which already use<code>try .. catch</code> so no need to use then again</remarks>
        public ProcessResult Start()
        {
            //convert UNICODE to ASCII         
            string UnicodeArgs = String.Format("wlan set hostednetwork mode=allow ssid={0} key={1}", SSID, Key);
            string startArgs = ConvertedASCII(UnicodeArgs);

            ProcessResult result = new ProcessResult();
            result = Execute(startArgs);

            return result;
        }


        /// <summary>
        /// Stop the hotspot
        /// </summary>
        /// <returns>ProcessResult type</returns>
        /// <remarks>it use <c>Execute()</c> function to stop hotspot which already use<code>try .. catch</code> so no need to use then again</remarks>
        public ProcessResult Stop()
        {
            ProcessResult result = new ProcessResult();
            result = Execute(STOP_ARGUMENTS);

            return result;
        }

        public ProcessResult Restart()
        {

            ProcessResult stop = Stop(); //Stop hotspot

            ProcessResult start = Start();//Start Hotspot


            ProcessResult restart = new ProcessResult();

            if (start.ExitCode == 0)
            {
                restart.ExitCode = 0;
                restart.Output = "Hotspot has been Sucessfully Restarted.";
            }
            else
            {
                restart.ExitCode = start.ExitCode;
                restart.Output = "Hotspot was not able to Restart sucessfully due to some error";
            }

            return restart;

        } // It stops the hotspot and then start again


        /// <summary>
        /// Get the raw output of details of hotspot by <c>Ececute()</c> function
        /// </summary>
        /// <returns>ProcessResult type </returns>
        public ProcessResult Detail()
        {

            ProcessResult result = new ProcessResult();
            result = Execute(SHOW_HOTSPOT);

            return result;
        }


        /// <summary>
        /// To Enable or Disable ICS(Internet Connection Sharing)
        /// </summary>
        /// <param name="sPublicConnectionName">Name of Active Connection you want to share</param>
        /// <param name="sPrivateConnectionName">Name of your Connection you want to share with</param>
        /// <param name="bEnable">Enable or Disable</param>
        /// <returns>True if successful , False if failed</returns>
        /// <remarks></remarks>
        public bool SetICS(string sPublicName, string sPrivateName, bool Setable)
        {
            return ics.EnableDisableICS(sPublicName, sPrivateName, Setable);
        }



        // SUB - CLASSES....................................................................

        /// <summary>
        /// Details of Hotspot by using raw output of <c> wlan show hostednetwork</c> command
        /// </summary>
        public class Details
        {

            private string[] strs;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="raw">raw output of netsh command</param>
            public Details(string raw)
            {
                Refresh(raw);
            }//Constructor :- When raw output is given - fast method

            /// <summary>
            /// 
            /// </summary>
            /// <param name="raw">raw output of netsh command</param>
            public void Refresh(string raw)
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Text = raw;
                strs = rtb.Lines;
                rtb.Dispose();
            } // Refresh the details with given raw data - - fast method

            private ProcessResult pvtExecute(string arguments)
            {
                Process proc = new Process
                {
                    StartInfo =
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        FileName = Environment.SystemDirectory + "\\netsh.exe",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        Arguments = arguments
                    }
                };

                proc.PriorityClass = ProcessPriorityClass.High;

                proc.Start();

                proc.WaitForExit();

                int exitCode = proc.ExitCode;
                string output = proc.StandardOutput.ReadToEnd();



                ProcessResult proc_output = new ProcessResult();

                proc_output.ExitCode = exitCode;
                proc_output.Output = output;

                return proc_output;
            }

            public Details()
            {
                Refresh();
            }//Constructor :- When raw output is not given , have to use <c>Execute</c> function - Time consuming,can freeze UI thread ,beter to use backgoundWorker
            public void Refresh()
            {
                ProcessResult detail = pvtExecute(SHOW_HOTSPOT);

                if (detail.ExitCode == 0)
                {

                    RichTextBox rtb = new RichTextBox();
                    rtb.Text = detail.Output;
                    strs = rtb.Lines;
                    rtb.Dispose();
                }
                else
                {
                    strs = null;
                }
            } // Refresh the details ,without raw input - Time consuming,can freeze UI thread ,beter to use backgoundWorker




            [Browsable(true)]
            [ReadOnly(true)]
            [Description("This tells us hostednetwork is allowed or not.")]
            [Category("Technical Details")]
            [DisplayName("Mode")]

            public string Mode
            {
                get
                {
                    return strs[3].Substring(29).Trim();
                }

            }

            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Name of Hotspot you created.")]
            [Category("Basic Details")]
            [DisplayName("SSID(Name)")]
            public string SSID
            {
                get
                {
                    return (strs[4].Substring(strs[4].IndexOf('"')).Trim()).Substring(1, (strs[4].Substring(strs[4].IndexOf('"')).Trim()).Length - 2).Trim();
                }
            }

            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Status of Hotspot - start , stop , pending.")]
            [Category("Technical Details")]
            [DisplayName("Status")]
            public string Status
            {
                get
                {
                    return strs[11].Substring(29).Trim();
                }
            }


            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Authentication of Hotspot")]
            [Category("Technical Details")]
            [DisplayName("Authentication")]
            public string Authentication
            {
                get
                {
                    return strs[6].Substring(29).Trim();
                }
            }


            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Cipher of Hotspot")]
            [Category("Technical Details")]
            [DisplayName("Cipher")]
            public string Cipher
            {
                get
                {
                    return strs[7].Substring(29).Trim();
                }
            }



            [Browsable(true)]
            [ReadOnly(true)]
            [Description("BSSID of Hotspot")]
            [Category("Technical Details")]
            [DisplayName("BSSID")]
            public string BSSID
            {
                get
                {
                    if (Status == "Started")
                    {
                        return strs[12].Substring(29).Trim();
                    }
                    else
                    {
                        return "HOTSPOT NOT STARTED";
                    }
                }
            }

            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Radio Type of Hotspot")]
            [Category("Technical Details")]
            [DisplayName("Radio Type")]
            public string Radio_Type
            {
                get
                {
                    if (Status == "Started")
                    {
                        return strs[13].Substring(29).Trim();
                    }
                    else
                    {
                        return "HOTSPOT NOT STARTED";
                    }
                }
            }



            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Number of Connected Clients.")]
            [Category("Basic Details")]
            [DisplayName("No. Of Clients")]
            public string ConnectedClients
            {
                get
                {
                    if (Status == "Started")
                    {
                        return strs[15].Substring(29).Trim();
                    }
                    else
                    {
                        return "HOTSPOT NOT STARTED";
                    }
                }
            }

            [Browsable(false)]
            [ReadOnly(true)]
            [Description("Mac Address of Connected Clients/Devices.")]
            [Category("Basic Details")]
            [DisplayName("Connected Clients Mac")]
            public List<string> ClientsMac
            {
                get
                {
                    List<string> local = new List<string>();
                    if (Status == "Started")
                    {

                        int num = Convert.ToInt32(ConnectedClients);

                        for (int i = 0; i < num; i++)
                        {
                            local.Add(strs[16 + i].Substring(8, 17));
                        }

                        return local;
                    }
                    else
                    {
                        local.Add("HOTSPOT NOT STARTED");
                        return local;
                    }
                }

            }

            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Details of Devices Connected")]
            [Category("Basic Details")]
            [DisplayName("Connected Devices")]
            public ConnectedDevice[] Devices
            {
                get
                {
                    if (Status == "Started")
                    {

                        int num = Convert.ToInt32(ConnectedClients);

                        if (num != 0)
                        {

                            ConnectedDevice[] local = new ConnectedDevice[num];


                            for (int i = 0; i < num; i++)
                            {

                                local[i].Name = "Device " + (i + 1);
                                local[i].MacAddress = strs[16 + i].Substring(8, 17);

                            }
                            return local;

                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }


                }
            }

        }


        /// <summary>
        /// Gives details about mac address
        /// </summary>
        public class MacLookUp
        {
            private string mac;
            private XmlDocument xmldoc;
            private XmlElement root;
            private XmlNodeList nodeList;
            private string output;

            [Browsable(false)]
            public MacLookUp(string m)
            {
                mac = m;

                string url = "http://www.macvendorlookup.com/api/v2/" + m + "/xml";
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(url);

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                output = objReader.ReadToEnd();

                xmldoc = new XmlDocument();
                xmldoc.LoadXml(output);
                root = xmldoc.DocumentElement;




            }

            [Browsable(false)]
            public string Comapny
            {
                get
                {
                    nodeList = root.GetElementsByTagName("company");

                    return nodeList.Item(0).InnerXml;

                }
            }

            [Browsable(false)]
            public string Type
            {
                get
                {
                    nodeList = root.GetElementsByTagName("type");

                    return nodeList.Item(0).InnerXml;
                }
            }



        }



    }



    
    public class Win32_NetAdapter : IDisposable
    {

        private ManagementObjectSearcher manageObjSearcher;



        public Win32_NetAdapter()
        {
            Refresh();

        } // Constructor 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">custom query form Win32_NetworkAdapter , do not to select any specific property</param>
        public Win32_NetAdapter(string query)
        {
            Refresh(query);
        } // Constructor - with custom query.

        public virtual void Refresh(string query = "select * from Win32_NetworkAdapter")
        {
            manageObjSearcher = new ManagementObjectSearcher(query);
        }


        /// <summary>
        /// All the NetworkAdapter in Computer.
        /// </summary>
        /// <returns>Array of NetworkAdapter .</returns>
        public NetworkAdapter[] GetAdapters()
        {


            NetworkAdapter[] local = new NetworkAdapter[manageObjSearcher.Get().Count];

            int a = 0;
            foreach (ManagementObject adapter in manageObjSearcher.Get())
            {
                if (adapter["Name"] != null) local[a].Name = adapter["Name"].ToString();
                if (adapter["AdapterType"] != null) local[a].AdapterType = (string)adapter["AdapterType"];
                if (adapter["Availability"] != null) local[a].Availability = Convert.ToInt32(adapter["Availability"].ToString());
                if (adapter["Caption"] != null) local[a].Caption = (string)adapter["Caption"];
                if (adapter["Description"] != null) local[a].Description = (string)adapter["Description"];
                if (adapter["DeviceID"] != null) local[a].DeviceID = (string)adapter["DeviceID"];
                if (adapter["GUID"] != null) local[a].GUID = (string)adapter["GUID"];
                if (adapter["Installed"] != null) local[a].Installed = (bool)adapter["Installed"];
                if (adapter["MACAddress"] != null) local[a].MACAddress = (string)adapter["MACAddress"];
                if (adapter["Manufacturer"] != null) local[a].Manufacturer = (string)adapter["Manufacturer"];
                if (adapter["NetConnectionID"] != null) local[a].NetConnectionID = (string)adapter["NetConnectionID"];
                if (adapter["NetConnectionStatus"] != null) local[a].NetConnectionStatus = Convert.ToInt32(adapter["NetConnectionStatus"].ToString());
                if (adapter["NetEnabled"] != null) local[a].NetEnabled = (bool)adapter["NetEnabled"];
                if (adapter["ProductName"] != null) local[a].ProductName = (string)adapter["ProductName"];
                if (adapter["ServiceName"] != null) local[a].ServiceName = (string)adapter["ServiceName"];
                if (adapter["Status"] != null) local[a].Status = (string)adapter["Status"];
                if (adapter["StatusInfo"] != null) local[a].StatusInfo = (int)adapter["StatusInfo"];
                if (adapter["SystemName"] != null) local[a].SystemName = (string)adapter["SystemName"];
                a++;
            }


            return local;
        }


        /// <summary>
        /// Enables or Disable the NetworkAdapter
        /// </summary>
        /// <param name="deviceId">Device ID of adapter to disable/enable</param>
        /// <param name="enableORDisable">Enable or Disable</param>
        /// <returns>True-if successful & False-if failed.</returns>
        public bool SetAdapter(string deviceId, bool enableORDisable)
        {
            try
            {
                ManagementObject currentMObject = new ManagementObject();
                string strWQuery = "SELECT DeviceID,ProductName,Description,NetEnabled "
                    + "FROM Win32_NetworkAdapter "
                    + "WHERE DeviceID = " + deviceId;
                ObjectQuery oQuery = new System.Management.ObjectQuery(strWQuery);
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
                ManagementObjectCollection oReturnCollection = oSearcher.Get();


                foreach (ManagementObject mo in oReturnCollection)
                {
                    currentMObject = mo;
                }

                if (enableORDisable)
                {
                    currentMObject.InvokeMethod("Enable", null);
                }
                else
                {
                    currentMObject.InvokeMethod("Disable", null);
                }

                return true;

            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            manageObjSearcher.Dispose();

        }


    }




    /// <summary>
    /// Derived from <c>Win32_NetAdapter</c> class to provide properties and method of HostedNetworkAdapter
    /// </summary>
    public class HostedNetworkAdapter : Win32_NetAdapter
    {
        public HostedNetworkAdapter()
            : base(@"SELECT *  FROM   Win32_NetworkAdapter WHERE  Name = 'Microsoft Hosted Network Virtual Adapter'
                                                                          OR (Name = 'Microsoft Virtual Miniport Adapter')")
        {

        }



        /// <summary>
        /// Hostednetwork Adapter
        /// </summary>
        /// <returns>Adapter which is used to create Hotspot - <c>'Microsoft Hosted Network Virtual Adapter'</c> & <c>'Microsoft Virtual Miniport Adapter'</c> </returns>
        public NetworkAdapter GetAdapter()
        {
            NetworkAdapter[] adapters = base.GetAdapters();

            if (adapters.Length > 0)
            {
                return adapters[0];
            }
            else
            {
                return new NetworkAdapter();
            }

        }

        /// <summary>
        /// Enables the Virtual HostedNetwork adapter
        /// </summary>
        /// <returns>True-if successful & False-if failed.</returns>
        public bool EnableAdapter()
        {
            try
            {
                return base.SetAdapter(GetAdapter().DeviceID, true);

            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Disable the Virtual HostedNetwork adapter
        /// </summary>
        /// <returns>True-if successful & False-if failed.</returns>
        public bool DisableAdapter()
        {
            try
            {
                return base.SetAdapter(GetAdapter().DeviceID, false);

            }
            catch
            {
                return false;
            }
        }

        public override void Refresh(string query = "select * from Win32_NetworkAdapter")
        {
            base.Refresh(@"SELECT *  FROM   Win32_NetworkAdapter WHERE  Name = 'Microsoft Hosted Network Virtual Adapter'
                                                                          OR (Name = 'Microsoft Virtual Miniport Adapter')");
        }


    }




    /// <summary>
    /// Have <c>GetBestNetworkInterface()</c> function
    /// </summary>
    public class Win32ApiCalls
    {
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto)]
        private static extern int GetBestInterface(UInt32 destAddr, out UInt32 bestIfIndex);

        private NetworkInterface GetNetworkInterfaceByIndex(uint index)
        {
            // Search in all network interfaces that support IPv4.
            NetworkInterface ipv4Interface = (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                                              where thisInterface.Supports(NetworkInterfaceComponent.IPv4)
                                              let ipv4Properties = thisInterface.GetIPProperties().GetIPv4Properties()
                                              where ipv4Properties != null && ipv4Properties.Index == index
                                              select thisInterface).SingleOrDefault();
            if (ipv4Interface != null)
                return ipv4Interface;

            // Search in all network interfaces that support IPv6.
            NetworkInterface ipv6Interface = (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                                              where thisInterface.Supports(NetworkInterfaceComponent.IPv6)
                                              let ipv6Properties = thisInterface.GetIPProperties().GetIPv6Properties()
                                              where ipv6Properties != null && ipv6Properties.Index == index
                                              select thisInterface).SingleOrDefault();

            return ipv6Interface;
        }



        /// <summary>
        /// Gives NetworkInterface which is best to reach address given by you.
        /// </summary>
        /// <param name="website">web address to reach</param>
        /// <returns>NetworkInterface type which is best to reach address given by you.</returns>
        /// <remarks>pass proper web address like <c>www.google.com</c></remarks>
        public NetworkInterface GetBestNetworkInterface(string website)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(website);

                IPAddress ipv4Address = (from thisAddress in hostInfo.AddressList
                                         where thisAddress.AddressFamily == AddressFamily.InterNetwork
                                         select thisAddress).FirstOrDefault();
                if (ipv4Address == null)
                {
                    return null;
                }

                UInt32 ipv4AddressAsUInt32 = BitConverter.ToUInt32(ipv4Address.GetAddressBytes(), 0);
                UInt32 interfaceindex;
                int result = GetBestInterface(ipv4AddressAsUInt32, out interfaceindex);
                if (result != 0)
                {
                    return null;
                }


                NetworkInterface interfaceInfo = GetNetworkInterfaceByIndex(interfaceindex);

                return interfaceInfo;

            }
            catch
            {
                return null;
            }
        }

    }



}






