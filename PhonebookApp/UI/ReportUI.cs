using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PhonebookApp.DAO;
using PhonebookApp.DbGateway;
using PhonebookApp.Reports;
using QRCoder;

namespace PhonebookApp.UI
{
    public partial class ReportUI : Form
    {
        public int x;
        public ReportUI()
        {
            InitializeComponent();
        }

        private void letterOfIntroductionButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "District Name";

            //set the parameter value
            paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            LOI cr = new LOI();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void gretingsCardButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            //ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            //paramField.Name = "GroupName";

            //set the parameter value
           // paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            //paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            EidGreetingsForWorkingAdd cr = new EidGreetingsForWorkingAdd();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void addressButton_Click(object sender, EventArgs e)
        {
            ////creating an object of ParameterField class
            //ParameterField paramField = new ParameterField();

            ////creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            ////creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            ////set the parameter field name
            //paramField.Name = "Person Name";

            ////set the parameter value
            //paramDiscreteValue.Value = x;

            ////add the parameter value in the ParameterField object
            //paramField.CurrentValues.Add(paramDiscreteValue);

            ////add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            ////set the parameterfield information in the crystal report



            //ReportViewer f2 = new ReportViewer();
            //TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            //TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            //ConnectionInfo reportConInfo = new ConnectionInfo();
            //Tables tables = default(Tables);
            ////	Table table = default(Table);
            //var with1 = reportConInfo;
            //with1.ServerName = "tcp:KyotoServer,49172";
            //with1.DatabaseName = "PhoneBookDBKD22";
            //with1.UserID = "sa";
            //with1.Password = "SystemAdministrator";
            //GreetingCardsForWorkingAdd cr = new GreetingCardsForWorkingAdd();
            //tables = cr.Database.Tables;
            //foreach (Table table in tables)
            //{
            //    reportLogonInfo = table.LogOnInfo;
            //    reportLogonInfo.ConnectionInfo = reportConInfo;
            //    table.ApplyLogOnInfo(reportLogonInfo);
            //}
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            ////set the parameterfield information in the crystal report
            //f2.crystalReportViewer1.ReportSource = cr;
            ReportByDistrict f2=new ReportByDistrict();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void allAddressButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            //ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            //paramField.Name = " ";

            //set the parameter value
            //paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            //paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            //ReportViewer f2 = new ReportViewer();
            //TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            //TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            //ConnectionInfo reportConInfo = new ConnectionInfo();
            //Tables tables = default(Tables);
            //    Table table = default(Table);
            //var with1 = reportConInfo;
            //with1.ServerName = "tcp:KyotoServer,49172";
            //with1.DatabaseName = "PhoneBookDBKD22";
            //with1.UserID = "sa";
            //with1.Password = "SystemAdministrator";
            //GreetingCardsForResidentialAdd cr = new GreetingCardsForResidentialAdd();
            //tables = cr.Database.Tables;
            //foreach (Table table in tables)
            //{
            //    reportLogonInfo = table.LogOnInfo;
            //    reportLogonInfo.ConnectionInfo = reportConInfo;
            //    table.ApplyLogOnInfo(reportLogonInfo);
            //}
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            //f2.crystalReportViewer1.ReportSource = cr;
            ReportByGroup f2=new ReportByGroup();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //ConnectionString cs = new ConnectionString();

          //  TestReport objRpt;
          //  // Creating object of our report.
          //  objRpt = new TestReport();
          //SqlConnection con = new SqlConnection(cs.DBConn);
          //  //INNER Join Query
          //  //SqlDataAdapter sda = new SqlDataAdapter("SELECT Persons.PersonsId, Persons.PersonName, EmailBank.Email, Company.CompanyName, JobTitle.JobTitleName,Category.CategoryName, Specializations.Specialization, Profession.ProfessionName,EducationLevel.EducationLevelName,AgeGroup.AgeGroupLevel FROM Persons LEFT OUTER JOIN EmailBank ON Persons.EmailBankId = EmailBank.EmailBankId LEFT OUTER JOIN Category ON Persons.CategoryId = Category.CategoryId  LEFT OUTER JOIN Company ON Persons.CompanyId = Company.CompanyId  LEFT OUTER JOIN JobTitle ON Persons.JobTitleId = JobTitle.JobTitleId  LEFT OUTER JOIN EducationLevel ON Persons.EducationLevelId = EducationLevel.EducationLevelId  LEFT OUTER JOIN Profession ON Persons.ProfessionId = Profession.ProfessionId LEFT OUTER JOIN Specializations ON Persons.SpecializationsId = Specializations.SpecializationsId LEFT OUTER JOIN AgeGroup ON Persons.AgeGroupId=AgeGroup.AgeGroupId", con);
          //  //Left Join Query
           
          // // String connection = "SERVER=mydb;USER ID=user1;PWD=user1";

            

          //  String Query1 = "SELECT PostOffice.PostCode,Districts.District,ResidentialAddresses.RFlatNo,ResidentialAddresses.RHouseNo,ResidentialAddresses.RRoadNo,ResidentialAddresses.RBlock,ResidentialAddresses.RArea,Persons.PersonName,Company.CompanyName,JobTitle.JobTitleName,Persons.PersonsId FROM (((ResidentialAddresses LEFT OUTER JOIN Persons ON ResidentialAddresses.PersonsId=Persons.PersonsId) LEFT OUTER JOIN ((Thanas LEFT OUTER JOIN Districts ON Thanas.D_ID=Districts.D_ID) LEFT OUTER JOIN PostOffice ON Thanas.T_ID=PostOffice.T_ID) ON ResidentialAddresses.PostOfficeId=PostOffice.PostOfficeId) LEFT OUTER JOIN Company ON Persons.CompanyId=Company.CompanyId) LEFT OUTER JOIN JobTitle ON Persons.JobTitleId=JobTitle.JobTitleId";

          //  SqlDataAdapter adapter = new SqlDataAdapter(Query1,con);

          //  AddressReportDataSet Ds = new AddressReportDataSet();

          //  // here my_dt is the name of the DataTable which we 
          //  // created in the designer view.
          //  adapter.Fill(Ds.Tables["AddressDataTable"]);

          //  if (Ds.Tables[0].Rows.Count == 0)
          //  {
          //      MessageBox.Show("No data Found", "CrystalReportWithOracle");
          //      return;
          //  }

          //  foreach (DataRow dr in Ds.Tables[0].Rows)
          //  {
          //      string x = "BEGIN:VCARD\r\nVERSION:3.0\r\nN:" + (string)dr["PersonName"] + "\r\nFN: "+ (string)dr["PersonName"] +"\r\nORG:" +
          //          (!DBNull.Value.Equals(dr["CompanyName"]) ? (string)dr["CompanyName"] : "") + "\r\nTITLE:" + (!DBNull.Value.Equals(dr["JobTitleName"]) ? (string)dr["JobTitleName"] : "") +
          //          "\r\nADR;TYPE= POSTAL," +(!DBNull.Value.Equals(dr["RFlatNo"]) ?  (string)dr["RFlatNo"]:"") + "," +(!DBNull.Value.Equals(dr["RHouseNo"]) ?   (string)dr["RHouseNo"]:"") +
          //          "," +(!DBNull.Value.Equals(dr["RRoadNo"]) ?   (string)dr["RRoadNo"]:"") + "," +(!DBNull.Value.Equals(dr["RBlock"]) ? (string)dr["RBlock"]:"") + ","
          //          +(!DBNull.Value.Equals(dr["RArea"]) ? (string)dr["RArea"]:"") + "," +(!DBNull.Value.Equals(dr["District"]) ? (string)dr["District"]:"") + "," +(!DBNull.Value.Equals(dr["PostCode"]) ? (string)dr["PostCode"]:"") + "END:VCARD";
          //      QRCodeGenerator qrGenerator = new QRCodeGenerator();
          //      QRCodeData qrCodeData = qrGenerator.CreateQrCode(x, QRCodeGenerator.ECCLevel.Q);
          //      QRCode qrCode = new QRCode(qrCodeData);
          //      Properties.Resources.logo.MakeTransparent();
          //      Bitmap Logo =Properties.Resources.logo;
          //      Logo.MakeTransparent();
          //      Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, Logo,30);
          //      //qrCode.GetGraphic()
          //      System.IO.MemoryStream ms = new System.IO.MemoryStream();
          //      qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
          //      dr["QRCODE"] = ms.ToArray();
          //      ms.Dispose();
          //  }
           
          //  // Setting data source of our report object
          //  objRpt.SetDataSource(Ds);

          //  //CrystalDecisions.CrystalReports.Engine.TextObject root;
          //  //root = (CrystalDecisions.CrystalReports.Engine.TextObject)
          //  //    objRpt.ReportDefinition.ReportObjects["txt_header"];
          //  //root.Text = "Sample Report By Using Data Table!!";

          //  // Binding the crystalReportViewer with our report object. 
          //  ReportViewer f2 = new ReportViewer();
          //  objRpt.SetDataSource(Ds);
          //  f2.crystalReportViewer1.ReportSource = objRpt;
            ReportByMultiple f2=new ReportByMultiple();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void ReportUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmViewAndReport frm = new frmViewAndReport();
            frm.Show();
        }

        private void ReportUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            EidGreetingsForResidentialAdd cr = new EidGreetingsForResidentialAdd();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportByBatch f2=new ReportByBatch();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void CompanyWithEmailButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            CompanyDetails cr = new CompanyDetails();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void PersonsComEmailButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            PersonsWithCompany cr = new PersonsWithCompany();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void AllComListButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            ListofAllCompanies cr = new ListofAllCompanies();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void AllContactListButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            ListofAllContacts cr = new ListofAllContacts();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void CompanyWithEmailButton_Click_1(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            CompanyDetails cr = new CompanyDetails();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void PerWithCompanyButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            PersonsWithCompany cr = new PersonsWithCompany();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "PhoneBookDBKD22";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            SmallGreetingsForWorkingAddCopy cr = new SmallGreetingsForWorkingAddCopy();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListOfContactByReligion lcr = new ListOfContactByReligion();
            this.Visible = false;
            lcr.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

      
    }
}
