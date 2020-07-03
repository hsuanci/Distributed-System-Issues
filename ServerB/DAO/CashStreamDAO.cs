using Dapper;
using Oracle.ManagedDataAccess.Client;
using ServerB.Helpers;
using ServerB.Models;
using System;
using System.Linq;
using System.Threading;

namespace ServerB.DAO
{
    public interface ICashStreamDAO
    {
        int UpadateCashStream();
    }
    public class CashStreamDAO : ICashStreamDAO
    {
        // UpdateCashStream
        public int UpadateCashStream()
        {
            using (OracleConnection conn = DBHelpers.GetConnection())
            {
                using (OracleTransaction trn = conn.BeginTransaction())
                {
                    try
                    {
                        // Get balance 
                        string selectSql = @"SELECT * FROM CASHSTREAM WHERE USERNAME=:name ORDER BY CREATETIME DESC";

                        var resultModel = conn.Query<CashStreamModel>(selectSql, new { name = "Henry" }).FirstOrDefault();
                        var selectedBalance = resultModel.BALANCE;

                        resultModel.BALANCE = resultModel.BALANCE + 50;
                        resultModel.CREATETIME = DateTime.Now;
                        resultModel.SERVER = "ServerB";

                        // Add balance and save into server
                        string strSql = @"UPDATE CASHSTREAM SET BALANCE=:BALANCE, SERVER=:SERVER, CREATETIME=:CREATETIME WHERE ID=:ID AND BALANCE=" + selectedBalance;
                        var col = conn.Execute(strSql, resultModel);

                        Thread.Sleep(3000);

                        trn.Commit();

                        return col;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return 0;
                    }
                }
            }
        }
    }
}