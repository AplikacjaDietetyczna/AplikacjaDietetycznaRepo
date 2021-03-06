﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplikacjaDietetyczna.Klasy
{
    public class PobieranieDanych
    {
        public static int PobierzIdProduktu(string produkt)
        {
            int id=0;
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty where NazwaProduktu='"+produkt+"'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                id = Convert.ToInt16(AzureDB.dt.Rows[0]["ID_Produktu"]);

            }
            AzureDB.closeConnection();
            return id;
        }
        public static string PobierzNazweProduktu(int id)
        {
            string nazwa="";
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Produkty where ID_Produktu=" + id;
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                nazwa = AzureDB.dt.Rows[0]["NazwaProduktu"].ToString();

            }
            AzureDB.closeConnection();
            return nazwa;
        }

        public static int PobierzIDUsera(string user)
        {
            int id = 0;
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Users where ID_User='" + user + "'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                id = Convert.ToInt16(AzureDB.dt.Rows[0]["ID_User"]);

            }
            AzureDB.closeConnection();
            return id;
        }
        public static int PobierzWage(int id)
        {
            int waga = 0;
            AzureDB.openConnection();
            AzureDB.sql = "Select * from Waga where ID_User='" + id + "'";
            AzureDB.cmd.CommandType = CommandType.Text;
            AzureDB.cmd.CommandText = AzureDB.sql;
            AzureDB.da = new SqlDataAdapter(AzureDB.cmd);
            AzureDB.dt = new DataTable();
            AzureDB.da.Fill(AzureDB.dt);
            if (AzureDB.dt.Rows.Count > 0)
            {
                waga = Convert.ToInt32(AzureDB.dt.Rows[0]["Waga"]);

            }
            AzureDB.closeConnection();
            return waga;
        }
    }
}
