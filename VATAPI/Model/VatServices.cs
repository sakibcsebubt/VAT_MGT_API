using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VATAPI.Model
{
    public class VatServices
    {
        private readonly IConfiguration _config;
        private static SqlConnection _SqlConnection;
        public VatServices()
        {

        }
        public VatServices(IConfiguration configuration)
        {
            _config = configuration;
            _SqlConnection = new SqlConnection(_config.GetConnectionString("SQLDBConnection"));
        }

        public DataSet GetDataSet(string storedProcName, params SqlParameter[] parameters)
        {
            var command = new SqlCommand(storedProcName, _SqlConnection) { CommandType = CommandType.StoredProcedure };
            command.Parameters.AddRange(parameters);
            command.CommandTimeout = 0;
            var result = new DataSet();
            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(result);
            return result;
        }

        public static Task<DataSet> GetDataSetAsyncFinal(string storedProcName, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                //     _SqlConnection.Open();
                return Task.Run(() =>
                {
                    var command = new SqlCommand(storedProcName, _SqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    command.Parameters.AddRange(parameters);

                    // da.SelectCommand.CommandTimeout = 15000;
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(ds);
                    return ds;
                });
            }
            catch (Exception ex)
            {
                //  ErrorMsg = ex.Message.ToString();
                // HMISLogger.logger.Error(ex.Message.ToString() + " " + ProcName, ex);
                //  return ex;
            }
            finally
            {
                //  _SqlConnection.Close();
            }
            return null;
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    public static class ListToXml
    {
        public static string ToXml<T>(this T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }
        public static string ToXml<T>(this T obj, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var xmlNs = new XmlSerializerNamespaces();
            xmlNs.Add(string.Empty, string.Empty);

            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj, xmlNs);
                return sw.ToString();
            }
        }
    }
}
