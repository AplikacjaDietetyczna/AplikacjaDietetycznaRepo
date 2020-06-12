using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AplikacjaDietetyczna.Klasy;
using System.Data;

namespace AplikacjaDietetyczna.Klasy
{
    public sealed class Singleton
    {
        private static readonly Singleton m_oInstance = new Singleton();

        static Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                return m_oInstance;
            }
        }

        public string CheckIfUserIsAdmin()
        {

            String message = "Nie udało połączyć się z bazą danych";
            string IsAdmin = "";
            try
            {

                
                AzureDB.openConnection();

                AzureDB.sql = ("SELECT TOP 1 * FROM USERS where Login =  '" + FunkcjeGlobalne.Login + "'  AND ID_User = '" + FunkcjeGlobalne.ID + "'");
                AzureDB.cmd.CommandType = CommandType.Text;
                AzureDB.cmd.CommandText = AzureDB.sql;
                AzureDB.rd = AzureDB.cmd.ExecuteReader();
                if (AzureDB.rd.Read())
                {
                    IsAdmin = AzureDB.rd["IsAdmin"].ToString();
                }

                AzureDB.closeConnection();
            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }
            return IsAdmin;

        }

    }
}