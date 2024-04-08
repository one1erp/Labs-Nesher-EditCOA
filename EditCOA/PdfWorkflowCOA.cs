using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using DAL;
using LSExtensionControlLib;
using LSSERVICEPROVIDERLib;
using LSEXT;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace EditCOA
{
    [ComVisible(true)]
    [ProgId("EditCOA.PdfWorkflowCOA")]
    public class PdfWorkflowCOA : IWorkflowExtension
    {
        private INautilusDBConnection _ntlsCon;
        INautilusServiceProvider sp;
        private double coaId;
        string _pdfPath = "";
        private IDataLayer dal;
        private COA_Report CurrentCOA;

        public void Execute(ref LSExtensionParameters Parameters)
        {
            sp = Parameters["SERVICE_PROVIDER"];
            var records = Parameters["RECORDS"];

            _ntlsCon = Utils.GetNtlsCon(sp);
            Utils.CreateConstring(_ntlsCon);

            dal = new DataLayer();
            dal.Connect();

            records.MoveLast();
            coaId = records.Fields["U_COA_REPORT_ID"].Value;
            CurrentCOA = dal.GetCoaReportById(Convert.ToInt64(coaId));


            if (CurrentCOA != null)
            {
                _pdfPath = CurrentCOA.PdfPath;
                MessageBox.Show("PDF Path: " + _pdfPath);

            }

            if (CurrentCOA != null && _pdfPath != null)
            {
                Process p = Process.Start(_pdfPath);
                p.WaitForExit();
            }
            else
            {
                MessageBox.Show("מסמך אינו קיים");
            }

        }
    }
}
