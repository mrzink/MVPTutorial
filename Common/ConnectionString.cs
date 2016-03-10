
//using System.Threading.Tasks;
////using System.Data.Entity.Infrastructure;
//using System.Data.Entity;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.SqlClient;
//namespace EntityDataModel.CommonSQL
//{
//    /******************************************************************
//    C# JCS Coding conventions 
//    * File Name : ConnectionString.cs * 
//    * Create by : PhuongDQ *   
//    * Create date : 2015/09/19 *
//    * Update by :  * 
//    * Update date : * 
//    ******************************************************************/
//    public sealed class ConnectionString
//    {
//        public static string Connection
//        {
//            get
//            {
//                return ConnectionString.Connect();
//            }
//        }
//        private string serverName;
//        private string userName;
//        private string password;

//        /// <summary>
//        /// constructor
//        /// </summary>
//        /// <param name="serverName"></param>
//        /// <param name="user"></param>
//        /// <param name="pass"></param>
//        public ConnectionString(string serverName, string user, string pass)
//        {
//            this.serverName = serverName;
//            this.userName = user;
//            this.password = pass;
//        }

//        /// <summary>
//        /// get connectionString to test connection
//        /// </summary>
//        /// <returns>connectionString</returns>
//        public string LocalConnect()
//        {
//            try
//            {
//                //Build an SQL connection string
//                SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
//                {
//                    DataSource = this.serverName, // Server name
//                    InitialCatalog = Common.SystemConfig.DbConfigSetting.Database,  //Database
//                    UserID = this.userName,         //Username
//                    Password = this.password,  //Password
//                };
//                //Build an Entity Framework connection string
//                EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
//                {
//                    Provider = "System.Data.SqlClient",
//                    Metadata = "res://*/Database.ERP_DB.csdl|res://*/Database.ERP_DB.ssdl|res://*/Database.ERP_DB.msl",
//                    ProviderConnectionString = sqlString.ToString()
//                };
//                return entityString.ConnectionString;
//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//            }
//        }

//        /// <summary>
//        /// get connectionString to connected
//        /// </summary>
//        /// <returns>connectionString</returns>
//        private static string Connect()
//        {
//            try
//            {
//                //Build an SQL connection string
//                SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
//                {
//                    DataSource = Common.SystemConfig.DbConfigSetting.ServerName, // Server name
//                    InitialCatalog = Common.SystemConfig.DbConfigSetting.Database,  //Database
//                    UserID = Common.SystemConfig.DbConfigSetting.UserName,         //Username
//                    Password = Common.SystemConfig.DbConfigSetting.UserPasword,  //Password
//                    //  ConnectTimeout = (int)Common.SystemConfig.DbConfigSetting.TimeOut,
//                };
//                //Build an Entity Framework connection string
//                EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
//                {
//                    Provider = "System.Data.SqlClient",
//                    Metadata = "res://*/Database.ERP_DB.csdl|res://*/Database.ERP_DB.ssdl|res://*/Database.ERP_DB.msl",
//                    ProviderConnectionString = sqlString.ToString()
//                };
//                return entityString.ConnectionString;
//            }
//            catch (System.Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
