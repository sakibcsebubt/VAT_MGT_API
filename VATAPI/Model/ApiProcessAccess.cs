using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using VATAPI.Model.ViewModel;

namespace VATAPI.Model
{
    public class ApiProcessAccess
    {
        public static string GetMacAddress()
        {
            string strMac1 = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string strMac2 = "";
                //if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                if ((nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    && nic.OperationalStatus == OperationalStatus.Up)
                {
                    //return nic.GetPhysicalAddress();
                    var address1 = nic.GetPhysicalAddress();

                    byte[] bytes = address1.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        strMac2 += bytes[i].ToString("X2");
                        // Display the physical address in hexadecimal.
                        //Console.Write("{0}", bytes[i].ToString("X2"));
                        // Insert a hyphen after each byte, unless we are at the end of the
                        // address.
                        if (i != bytes.Length - 1)
                        {
                            //strMac2 += "-";
                            //Console.Write("-");
                        }
                    }
                    //return strMac2;
                }
                if (strMac2.Trim().Length > 0)
                    strMac1 += (strMac1.Trim().Length > 0 ? ", " : "") + strMac2;
            }
            return strMac1;
        }

        public static List<VatEntityManpower.SignInInfo> SignedInUserList { get; set; }

        public static void GetSignedInUserList(string SignInName = "MILLAT", string hcPass = "XXXX", string TerminalID = "UNKNOWN", string newPass1 = "ABCD", string newPass2 = "EFGH")
        {

            if (SignedInUserList == null)
            {


                //   var pap1 = vmCfg1.SetParamSignIn("6521", SignInName, hcPass, TerminalID, newPass1, newPass2);
                DataSet ds1 = null; //ApiProcessAccess.GetHmsDataSet(pap1, sqlConnection);
                if (ds1 == null)
                    return;

                if (ds1.Tables[0].Rows.Count == 0)
                    return;

                string _comcod1 = ds1.Tables[0].Rows[0]["comcod"].ToString().Trim();
                string _hccode1 = ds1.Tables[0].Rows[0]["hccode"].ToString().Trim();

                SignedInUserList = null; //ds1.Tables[0].DataTableToList<VatEntityManpower.SignInInfo>();

                if (!(ds1.Tables[0].Rows[0]["hcphoto"] is DBNull))
                    SignedInUserList[0].hcphoto = (byte[])ds1.Tables[0].Rows[0]["hcphoto"];

                if (!(ds1.Tables[0].Rows[0]["hcinisign"] is DBNull))
                    SignedInUserList[0].hcinisign = (byte[])ds1.Tables[0].Rows[0]["hcinisign"];

                if (!(ds1.Tables[0].Rows[0]["hcfullsign"] is DBNull))
                    SignedInUserList[0].hcfullsign = (byte[])ds1.Tables[0].Rows[0]["hcfullsign"];

                string xmlbytostring = (System.Text.ASCIIEncoding.Default.GetString((byte[])(ds1.Tables[1].Rows[0]["perdesc"])));
                char[] xmlDSArray = xmlbytostring.ToCharArray().Reverse().ToArray();
                string xmlDS = new string(xmlDSArray);
                DataSet ds1a = new DataSet();
                System.IO.StringReader xmlSR = new System.IO.StringReader(xmlDS);
                //ds1a.ReadXml(xmlSR, XmlReadMode.IgnoreSchema);
                ds1a.ReadXml(xmlSR);

                string _comcod2 = ds1a.Tables[1].Rows[0]["comcod"].ToString().Trim();
                string _hccode2 = ds1a.Tables[1].Rows[0]["hccode"].ToString().Trim();

                if (!(_comcod1 == _comcod2 && _hccode1 == _hccode2))
                    return;
                DataView dv1 = ds1a.Tables[0].DefaultView;
                dv1.RowFilter = ("objallow=True");
                DataTable tbl1 = dv1.ToTable();
                if (tbl1.Rows.Count == 0)
                    return;
            }
        }


        public static DataSet GetHmsDataSet(ASITFunParams.ProcessAccessParams pap1, string ParamPassType = "PARAMETERS") // string ParamPassType = "CLASS" --- used for WPF 
        {
            VatServices vatServices = new VatServices();
            try
            {
                string Comcod1 = "6521"; // (AspSession.Current.CompInfList == null ? AspSession.Current.AppComCode : AspSession.Current.CompInfList[0].comcod);
                DataSet ds1 = new DataSet();
                switch (ParamPassType.ToUpper())
                {
                    case "PARAMETERS":
                        #region
                        SqlParameter[] parameters = new SqlParameter[25];


                        SqlParameter comCod = new SqlParameter(parameterName: "@comCod", dbType: System.Data.SqlDbType.NVarChar);
                        comCod.Value = pap1.comCod;

                        //SqlParameter ProcName = new SqlParameter(parameterName: "@ProcName", dbType: System.Data.SqlDbType.NVarChar);
                        //ProcName.Value = pap1.ProcName;

                        SqlParameter ProcID = new SqlParameter(parameterName: "@ProcessID", dbType: System.Data.SqlDbType.NVarChar);
                        ProcID.Value = pap1.ProcID;

                        SqlParameter parmXml01 = new SqlParameter(parameterName: "@Pxml01", dbType: System.Data.SqlDbType.NVarChar);
                        parmXml01.Value = pap1.pXml01;

                        SqlParameter parmXml02 = new SqlParameter(parameterName: "@Pxml02", dbType: System.Data.SqlDbType.Xml);
                        parmXml02.Value = pap1.pXml02;

                        SqlParameter parmBin01 = new SqlParameter(parameterName: "@Pbin01", dbType: System.Data.SqlDbType.VarBinary);
                        parmBin01.Value = pap1.parmBin01;



                        SqlParameter Param01 = new SqlParameter(parameterName: "@Param01", dbType: System.Data.SqlDbType.NVarChar);
                        Param01.Value = pap1.parm01;

                        SqlParameter Param02 = new SqlParameter(parameterName: "@Param02", dbType: System.Data.SqlDbType.NVarChar);
                        Param02.Value = pap1.parm02;

                        SqlParameter Param03 = new SqlParameter(parameterName: "@Param03", dbType: System.Data.SqlDbType.NVarChar);
                        Param03.Value = pap1.parm03;

                        SqlParameter Param04 = new SqlParameter(parameterName: "@Param04", dbType: System.Data.SqlDbType.NVarChar);
                        Param04.Value = pap1.parm04;

                        SqlParameter Param05 = new SqlParameter(parameterName: "@Param05", dbType: System.Data.SqlDbType.NVarChar);
                        Param05.Value = pap1.parm05;

                        SqlParameter Param06 = new SqlParameter(parameterName: "@Param06", dbType: System.Data.SqlDbType.NVarChar);
                        Param06.Value = (pap1.parm06 == null ? "" : pap1.parm06);

                        SqlParameter Param07 = new SqlParameter(parameterName: "@Param07", dbType: System.Data.SqlDbType.NVarChar);
                        Param07.Value = (pap1.parm07 == null ? "" : pap1.parm07);

                        SqlParameter Param08 = new SqlParameter(parameterName: "@Param08", dbType: System.Data.SqlDbType.NVarChar);
                        Param08.Value = (pap1.parm08 == null ? "" : pap1.parm08);

                        SqlParameter Param09 = new SqlParameter(parameterName: "@Param09", dbType: System.Data.SqlDbType.NVarChar);
                        Param09.Value = (pap1.parm09 == null ? "" : pap1.parm09);

                        SqlParameter Param10 = new SqlParameter(parameterName: "@Param10", dbType: System.Data.SqlDbType.NVarChar);
                        Param10.Value = (pap1.parm10 == null ? "" : pap1.parm10);

                        SqlParameter Param11 = new SqlParameter(parameterName: "@Param11", dbType: System.Data.SqlDbType.NVarChar);
                        Param11.Value = (pap1.parm11 == null ? "" : pap1.parm11);

                        SqlParameter Param12 = new SqlParameter(parameterName: "@Param12", dbType: System.Data.SqlDbType.NVarChar);
                        Param12.Value = (pap1.parm12 == null ? "" : pap1.parm12);

                        SqlParameter Param13 = new SqlParameter(parameterName: "@Param13", dbType: System.Data.SqlDbType.NVarChar);
                        Param13.Value = (pap1.parm13 == null ? "" : pap1.parm13);

                        SqlParameter Param14 = new SqlParameter(parameterName: "@Param14", dbType: System.Data.SqlDbType.NVarChar);
                        Param14.Value = (pap1.parm14 == null ? "" : pap1.parm14);

                        SqlParameter Param15 = new SqlParameter(parameterName: "@Param15", dbType: System.Data.SqlDbType.NVarChar);
                        Param15.Value = (pap1.parm15 == null ? "" : pap1.parm15);

                        SqlParameter Param16 = new SqlParameter(parameterName: "@Param16", dbType: System.Data.SqlDbType.NVarChar);
                        Param16.Value = (pap1.parm16 == null ? "" : pap1.parm16);

                        SqlParameter Param17 = new SqlParameter(parameterName: "@Param17", dbType: System.Data.SqlDbType.NVarChar);
                        Param17.Value = (pap1.parm17 == null ? "" : pap1.parm17);

                        SqlParameter Param18 = new SqlParameter(parameterName: "@Param18", dbType: System.Data.SqlDbType.NVarChar);
                        Param18.Value = (pap1.parm18 == null ? "" : pap1.parm18);

                        SqlParameter Param19 = new SqlParameter(parameterName: "@Param19", dbType: System.Data.SqlDbType.NVarChar);
                        Param19.Value = (pap1.parm19 == null ? "" : pap1.parm19);

                        SqlParameter Param20 = new SqlParameter(parameterName: "@Param20", dbType: System.Data.SqlDbType.NVarChar);
                        Param20.Value = (pap1.parm20 == null ? "" : pap1.parm20);

                        //SqlParameter _comcod1 = new SqlParameter(parameterName: "@ComCod", dbType: System.Data.SqlDbType.NVarChar);
                        //_comcod1.Value = Comcod1;


                        parameters[0] = comCod;
                        parameters[1] = ProcID;
                        //parameters[2] = ProcID;
                        parameters[2] = parmXml01;
                        parameters[3] = parmXml02;
                        parameters[4] = parmBin01;

                        parameters[5] = Param01;
                        parameters[6] = Param02;
                        parameters[7] = Param03;
                        parameters[8] = Param04;
                        parameters[9] = Param05;
                        parameters[10] = Param06;
                        parameters[11] = Param07;
                        parameters[12] = Param08;
                        parameters[13] = Param09;
                        parameters[14] = Param10;
                        parameters[15] = Param11;
                        parameters[16] = Param12;
                        parameters[17] = Param13;
                        parameters[18] = Param14;
                        parameters[19] = Param15;
                        parameters[20] = Param16;
                        parameters[21] = Param17;
                        parameters[22] = Param18;
                        parameters[23] = Param19;
                        parameters[24] = Param20;
                        //parameters[26] = _comcod1;


                        #endregion // SqlParameters
                        // [dbo_hcm].[SP_REPORT_HCM_TRANS_01]
                        ds1 = vatServices.GetDataSet(pap1.ProcName, parameters);
                        break;
                }
                if (ds1.Tables.Count == 0)
                {
                    return null;
                }
                return ds1;
            }
            catch (Exception exp)
            {
                return null;
            }
        }


    }
}
