﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visproProject
{
    public partial class report : Form
    {
        public int booking_id1 { get; set; }
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            CrystalReport11.SetParameterValue("filterbybookingid", booking_id1);
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            CrystalReport11.SetParameterValue("filterbybookingid", booking_id1);
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Refresh();
            //create crystal report and report by last booking_id
            
        }
        
    }
}
