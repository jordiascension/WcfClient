using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VuelingClientWcf.WebReference;

namespace VuelingClientWcf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebReference.IStudentWebService svc = new WebReference.StudentWebServiceClient();
            try
            {
                
                MessageBox.Show(svc.GetData(0, null).ToString());
                
            }
            catch (FaultException<ValidationFault> ex)
            {
                foreach (var details in ex.Detail.Details)
                {
                    MessageBox.Show(details.Message);
                }
            }

            try
            {
                MessageBox.Show(svc.ConcatStrings(null, null));
            }
            catch (FaultException<ValidationFault> ex)
            {
                foreach (var details in ex.Detail.Details)
                {
                    MessageBox.Show(details.Message);
                }
            }


        }
    }
}
