using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common;
using DAL;
using LSExtensionControlLib;
using LSSERVICEPROVIDERLib;

namespace EditCOA
{

    [ComVisible(true)]
    [ProgId("EditCOA.Edit_COAcls")]
    public partial class Edit_COACls : UserControl, IExtensionControl
    {
        private INautilusDBConnection _ntlsCon;
        private IExtensionControlSite _site;
        private INautilusServiceProvider sp;
        private INautilusProcessXML nautilusProcessXML;
        private INautilusDBConnection ntlCon;
        double coaReportId;
        string _wordPath = null;
        string _pdfPath = null;
        private IDataLayer dal;
        private COA_Report CurrentCOA;



        #region Ctor

        public Edit_COACls()
        {

            InitializeComponent();
            this.BackColor = Color.FromName("Control");
        }
        #endregion

        #region Page Extension Interface

        public void SetReadOnly(bool readOnly) { }

        public void Internationalise() { }

        public void SetSite(object site)
        {
            if (site != null)
            {
                _site = site as IExtensionControlSite;

            }
        }

        bool flag;
        public void SetupData()
        {

            if (_site != null)
            {
                // Set the page name
                _site.SetPageName("תעודה");

                //   Get the record id, in this example" Product

                _site.GetDoubleValue("U_COA_REPORT_ID", out coaReportId, out flag);


            }
        }

        public void SaveData()
        { }

        public void EnterPage()
        {



            Utils.CreateConstring(ntlCon);

            dal = new DataLayer();
            dal.Connect();
            CurrentCOA = dal.GetCoaReportById(Convert.ToInt64(coaReportId));
            btnOpenDoc.Image = Properties.Resources.images__5_;
            btnOpenPdf.Image = Properties.Resources.pdfIcon1;
            lblPdfPath.Text = string.Empty;
            lblWordPath.Text = string.Empty;
            btnOpenDoc.Enabled = true;
            if (CurrentCOA != null)
            {

                _wordPath = CurrentCOA.DocPath;
                _pdfPath = CurrentCOA.PdfPath;
                if (CurrentCOA.Status == "A")
                {
                    btnOpenPdf.Enabled = true;
                    lblPdfPath.Text = CurrentCOA.PdfPath;
                    lblWordPath.Text = CurrentCOA.DocPath;
                }
                else
                {

                    btnOpenPdf.Enabled = false;
                    lblWordPath.Text = CurrentCOA.DocPath;
                    lblPdfPath.Text = "";
                }


            }
            else
            {
                string error = "Error";

                lblWordPath.Text = error;
                lblPdfPath.Text = error;
                btnOpenDoc.Enabled = false;
                btnOpenPdf.Enabled = false;
            }
        }



        public void ExitPage()
        {
            if (dal != null) dal.Close();
        }

        public void PreDisplay()
        {


        }

        public void SetServiceProvider(object serviceProvider)
        {
            // serviceProvider = sp as INautilusServiceProvider; //TODO :שורה שהסרתי לשאול את אשילוס אם נכון לעשות זאת

            sp = serviceProvider as INautilusServiceProvider;
            //    serviceProvider = sp as INautilusServiceProvider;


            // Using the service provider object get the XML Processor interface
            // We will use this object to get information from the database
            nautilusProcessXML = Utils.GetXmlProcessor(sp);


            ntlCon = Utils.GetNtlsCon(sp);
        }

        public void SaveSettings(int hKey)
        { }

        public void RestoreSettings(int hKey)
        { }


        #endregion

        private void OpenDoc_Click(object sender, EventArgs e)
        {
            // Create a new FileSystemWatcher and set its properties.
            OpenDocument(_wordPath);
        }
        private void btnOpenPdf_Click(object sender, EventArgs e)
        {
            OpenDocument(_pdfPath);
        }
        private void OpenDocument(string path)
        {
            try
            {
                if (CurrentCOA != null && path != null)
                {
                    //FileSystemWatcher watcher = new FileSystemWatcher(CurrentCOA.DocPath);
                    //watcher.Changed += new FileSystemEventHandler(watcher_Changed);

                    FileInfo fileInfo = new FileInfo(path);


                    var lastMod = fileInfo.LastWriteTime;
                    var createdStatus = CurrentCOA.Status == "C";

                    Process p = Process.Start(path);
                    p.WaitForExit();

                    if (createdStatus)
                    {
                        FileInfo newfileInfo = new FileInfo(CurrentCOA.DocPath);

                        //אם נעשו שינויים במסמך
                        if (!DateTime.Equals(lastMod, newfileInfo.LastWriteTime))
                        {
                            CurrentCOA.Status = "E";
                            dal.SaveChanges();
                        }
                    }
                }
                else
                {
                    lblPdfPath.Text = "לא נוצר מסמך";
                }
            }
            catch (Exception xeException)
            {
                lblPdfPath.Text = "שגיאה בכתובת המסמך";
                Logger.WriteLogFile(xeException);
            }
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            var createdStatus = CurrentCOA.Status == "C";
            if (createdStatus)
            {
                CurrentCOA.Status = "E";
                dal.SaveChanges();
            }
        }

        private void Edit_COACls_Load(object sender, EventArgs e)
        {

        }


    }
}

