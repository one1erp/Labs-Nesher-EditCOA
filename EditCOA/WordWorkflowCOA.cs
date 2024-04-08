using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using LSExtensionControlLib;
using LSSERVICEPROVIDERLib;
using LSEXT;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace EditCOA
{
    [ComVisible(true)]
    [ProgId("EditCOA.WordWorkflowCOA")]
    public class WordWorkflowCOA : IWorkflowExtension
    {
        private INautilusDBConnection _ntlsCon;
        INautilusServiceProvider sp;
        private double coaId;
        string _wordPath = "";
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
            _wordPath = CurrentCOA.DocPath;
            if (CurrentCOA != null && _wordPath != null)
            {

                MessageBox.Show("CurrentCOA.DocPath is: " + CurrentCOA.Name);


                FileInfo fileInfo = new FileInfo(_wordPath);
                var lastMod = fileInfo.LastWriteTime;
                var createdStatus = CurrentCOA.Status == "C";

                Process p = Process.Start(_wordPath);
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
                MessageBox.Show("מסמך אינו קיים");
            }
           

        }
    }
}
