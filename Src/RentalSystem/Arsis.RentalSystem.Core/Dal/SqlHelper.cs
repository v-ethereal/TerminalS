using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.Core.Dal
{
    public static class SQLHelper
    {
        public static string SqlConnectionString
        {
            get
            {
                string connectionString =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.
                        ConnectionStrings["RentalSystemConnectionString"].ToString();

                if (String.IsNullOrEmpty(connectionString))
                {
                    throw new RentalSystemException("Не найдена строка подключения к БД.");
                }

                return connectionString;
            }
        }

        public static bool IsDbEnable()
        {
            try
            {
                SqlConnection connection = new SqlConnection(SqlConnectionString);
                connection.Open();
                connection.Close();
                return true;
            }
            catch (SqlException err)
            {
                throw new RentalSystemException(string.Format("Подключение к базе данных невозможно.\n{0}", err.Message));
            }
        }

        #region  Terminal

        /// <summary>
        /// Gets the not paid rental fees.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>List of not paid rental fees.</returns>
        public static List<PayLogRecord> GetNotPaidRentalFees(DateTime dateFrom, DateTime dateTo)
        {
            List<PayLogRecord> result = new List<PayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetNotPaidReport",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new PayLogRecord(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(),
                                                        decimal.Parse(reader.GetValue(2).ToString()),
                                                        decimal.Parse(reader.GetValue(3).ToString()),
                                                        DateTime.Parse(reader.GetValue(4).ToString()),
                                                        bool.Parse(reader.GetValue(5).ToString())));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the pay dates.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="placeNumber">The place number.</param>
        /// <returns>List of dates to pay to.</returns>
        public static List<PayDateInformation> GetPayDate(string contractNumber, string placeNumber)
        {
            List<PayDateInformation> result = new List<PayDateInformation>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetPayDates",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@PlaceNumber", Value = placeNumber};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@ContractNumber", Value = contractNumber};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new PayDateInformation(DateTime.Parse(reader.GetValue(0).ToString()).Date,
                                                              Convert.ToInt32(decimal.Parse(reader.GetValue(1).ToString())),
                                                              bool.Parse(reader.GetValue(2).ToString()),
                                                              Convert.ToInt32(decimal.Parse(reader.GetValue(3).ToString()))));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        #endregion

        #region AdminConsole

        /// <summary>
        /// Gets the rental fees.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>List of pay log records.</returns>
        public static List<RentalPayLogRecord> GetRentalFees(DateTime dateFrom, DateTime dateTo)
        {
            List<RentalPayLogRecord> result = new List<RentalPayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetRentalFees",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new RentalPayLogRecord(reader.GetValue(0).ToString(),
                                                              reader.GetValue(1).ToString(),
                                                              decimal.Parse(reader.GetValue(2).ToString()),
                                                              decimal.Parse(reader.GetValue(3).ToString()),
                                                              DateTime.Parse(reader.GetValue(4).ToString()),
                                                              bool.Parse(reader.GetValue(5).ToString()),
                                                              reader.GetValue(6).ToString()));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the paid rental fees.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>List of pay log records.</returns>
        public static List<RentalPayLogRecord> GetPaidRentalFees(DateTime dateFrom, DateTime dateTo)
        {
            List<RentalPayLogRecord> result = new List<RentalPayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetPaidReport",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new RentalPayLogRecord(reader.GetValue(0).ToString(),
                                                              reader.GetValue(1).ToString(),
                                                              decimal.Parse(reader.GetValue(2).ToString()),
                                                              decimal.Parse(reader.GetValue(3).ToString()),
                                                              DateTime.Parse(reader.GetValue(4).ToString()),
                                                              bool.Parse(reader.GetValue(5).ToString()),
                                                              reader.GetValue(6).ToString(),
                                                              reader.GetValue(7).ToString()));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the not transfered payments.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>List of pay log records.</returns>
        public static List<RentalPayLogRecord> GetNotTransferedPayment(DateTime dateFrom, DateTime dateTo)
        {
            List<RentalPayLogRecord> result = new List<RentalPayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetPaymentReport",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new RentalPayLogRecord(reader.GetValue(0).ToString(),
                                                              reader.GetValue(1).ToString(),
                                                              decimal.Parse(reader.GetValue(2).ToString()),
                                                              decimal.Parse(reader.GetValue(3).ToString()),
                                                              DateTime.Parse(reader.GetValue(4).ToString()),
                                                              bool.Parse(reader.GetValue(5).ToString()),
                                                              reader.GetValue(6).ToString()));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the service fees.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>List of pay log records.</returns>
        [Obsolete]
        public static List<ServicePayLogRecord> GetServiceFees(DateTime dateFrom, DateTime dateTo)
        {
            List<ServicePayLogRecord> result = new List<ServicePayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "GetServiceFees",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new ServicePayLogRecord(reader.GetValue(0).ToString(),
                                                               reader.GetValue(1).ToString(),
                                                               decimal.Parse(reader.GetValue(2).ToString()),
                                                               decimal.Parse(reader.GetValue(3).ToString()),
                                                               DateTime.Parse(reader.GetValue(4).ToString()),
                                                               reader.GetValue(5).ToString(),
                                                               reader.GetValue(6).ToString(),
                                                               null)); //номер места пустой
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        [Obsolete]
        public static List<ServicePayLogRecord> GetServiceFeesExt(DateTime from, DateTime to, int serviceId)
        {
            List<ServicePayLogRecord> result = new List<ServicePayLogRecord>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    const string commandText = @"
                            select  
                                sv.Name
                                ,sv.Description
                                ,ISNULL(
                                        (select 
                                                top 1 
                                                pl.Price
                                         from 
                                                dbo.PriceList pl 
                                         where 
                                                pl.ServiceId = sv.Id and pl.ValidFrom <= spm.DateTime 
                                         order by 
                                                pl.ValidFrom desc), 0)  as 
                                Price
                                ,spm.PaidSum as PaidSum
                                ,spm.DateTime as Date
                                ,tm.NetworkName as Terminal
                                ,spds.StatusMessage as StatusMessage
                            from
                                ServicePayments spm
                                    join dbo.ServicePaymentDailySummary spds on spm.DailySummaryId = spds.Id
                                    join dbo.Terminals tm on spm.TerminalId = tm.Id
                                    join dbo.Services sv on spm.ServiceId = sv.Id and sv.IsRental = 0
                            where 
                                spm.DateTime between @DateFrom and @DateTo and sv.Id = @serviceId
                            group by 
                                sv.Name
                                ,sv.Description
                                ,spm.DateTime
                                ,sv.Id
                                ,tm.NetworkName
                                ,spm.PaidSum
                                ,spds.StatusMessage";

                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = commandText,
                                                 Connection = connection,
                                                 CommandType = CommandType.Text
                                             };

                    command.Parameters.Add(new SqlParameter {ParameterName = "@DateFrom", Value = from});
                    command.Parameters.Add(new SqlParameter {ParameterName = "@DateTo", Value = to});
                    command.Parameters.Add(new SqlParameter {ParameterName = "@serviceId", Value = serviceId});

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new ServicePayLogRecord(reader.GetValue(0).ToString(),
                                                               reader.GetValue(1).ToString(),
                                                               decimal.Parse(reader.GetValue(2).ToString()),
                                                               decimal.Parse(reader.GetValue(3).ToString()),
                                                               DateTime.Parse(reader.GetValue(4).ToString()),
                                                               reader.GetValue(5).ToString(),
                                                               reader.GetValue(6).ToString(),
                                                               null)); //номер места пустой
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates financial info of contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="date">The date.</param>
        /// <param name="renderedAmmount">The rendered ammount.</param>
        /// <param name="recievedAmmount">The recieved ammount.</param>
        public static void GetFinancialInfo(int contractId, DateTime date, out decimal renderedAmmount,
                                            out decimal recievedAmmount)
        {
            renderedAmmount = 0;
            recievedAmmount = 0;
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "CalculateContract",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@ContractId", Value = contractId};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@Date", Value = date};
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            renderedAmmount = decimal.Parse(reader.GetValue(0).ToString());
                            recievedAmmount = decimal.Parse(reader.GetValue(1).ToString());
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Gets the state of the contracts.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="contractor">The contractor.</param>
        /// <returns>List of contracts state.</returns>
        public static List<ContractStateInformation> GetContractState(DateTime dateFrom, DateTime dateTo,
                                                                      string contractNumber, string contractor)
        {
            List<ContractStateInformation> result = new List<ContractStateInformation>();
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "ContractStateReport",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    SqlParameter parameter = new SqlParameter {ParameterName = "@DateFrom", Value = dateFrom};
                    command.Parameters.Add(parameter);

                    parameter = new SqlParameter {ParameterName = "@DateTo", Value = dateTo};
                    command.Parameters.Add(parameter);

                    if (!string.IsNullOrEmpty(contractNumber))
                    {
                        parameter = new SqlParameter {ParameterName = "@ContractNumber", Value = contractNumber};
                        command.Parameters.Add(parameter);
                    }

                    if (!string.IsNullOrEmpty(contractor))
                    {
                        parameter = new SqlParameter {ParameterName = "@Contractor", Value = contractor};
                        command.Parameters.Add(parameter);
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            result.Add(new ContractStateInformation(reader.GetValue(0).ToString(),
                                                                    DateTime.Parse(reader.GetValue(1).ToString()),
                                                                    DateTime.Parse(reader.GetValue(2).ToString()),
                                                                    reader.GetValue(3).ToString(),
                                                                    DateTime.Parse(reader.GetValue(4).ToString()),
                                                                    bool.Parse(reader.GetValue(5).ToString()),
                                                                    bool.Parse(reader.GetValue(6).ToString()),
                                                                    bool.Parse(reader.GetValue(7).ToString())));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Initiates 1c import process.
        /// </summary>
        public static void ReplyScan()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    SqlCommand command = new SqlCommand
                                             {
                                                 CommandText = "Ex1C_ReplyScan",
                                                 Connection = connection,
                                                 CommandType = CommandType.StoredProcedure
                                             };

                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion
    }
}