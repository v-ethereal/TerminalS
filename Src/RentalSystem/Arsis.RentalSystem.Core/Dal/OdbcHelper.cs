using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Text;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.Core.Dal
{
	public static class OdbcHelper
	{
		private static string OdbcConnectionString
		{
			get
			{
				string connectionString =
						ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings[
								"ContractorProviderConnectionString"].ToString();

				if (String.IsNullOrEmpty(connectionString))
				{
					throw new RentalSystemException("Не найдена строка подключения к БД 1C.");
				}

				return connectionString;
			}
		}
		#region Constants

		private const string GET_ALL_COMMAND_TEXT =
				"select Cli.CODE, Cli.DESCR, Cli.SP121, Cli.SP123, Cli.SP124, Cli.SP125, Cli.SP126, Cli.SP127, Cli.SP128, Cli.SP129, Cli.SP130" +
						" from SC133 CliGr" +
								" inner join SC133 Cli on(CliGr.ID = Cli.PARENTID)" +
										" where Cli.ISFOLDER = 2 and CliGr.ISFOLDER = 1 and ltrim(rtrim(CliGr.CODE)) = ?" +
												" order by Cli.DESCR";
		private const string GET_ONE_COMMAND_TEXT = "select CODE, DESCR, SP121, SP123, SP124, SP125, SP126, SP127, SP128, SP129, SP130 from SC133 where CODE = ?";
		private const string PRIVATE_PERSONE_CODE = "C5";

		#endregion

		#region Public Methods

		public static bool IsOdbcConnectionExists()
		{
			bool result = true;
			OdbcConnection connection = null;

			try
			{
				connection = new OdbcConnection(OdbcConnectionString);

				connection.Open();

				if(connection.State == ConnectionState.Broken)
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (connection != null && connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return result;
		}

		/// <summary>
		/// Gets the contractors.
		/// </summary>
		/// <returns>List of contractors.</returns>
		public static List<Contractor> GetContractors(string parentCode)
		{
			List<Contractor> result = new List<Contractor>();
			using (OdbcConnection connection = new OdbcConnection(OdbcConnectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				try
				{
					OdbcCommand command = new OdbcCommand { CommandText = GET_ALL_COMMAND_TEXT, Connection = connection, CommandType = CommandType.Text };
					command.Parameters.Add(new OdbcParameter("@code", parentCode));
					OdbcDataReader reader = command.ExecuteReader();
					if (reader != null)
					{
						while (reader.Read())
						{
							string client1SCode = Convert(reader.GetValue(0).ToString().Trim());
							string clientName = Convert(reader.GetValue(1).ToString().Trim());
							bool isJuridicalPerson = Convert(reader.GetValue(2).ToString().Trim()) == PRIVATE_PERSONE_CODE ? false : true;
							string clientAddress = Convert(reader.GetValue(3).ToString().Trim());
							string clientPostAddress = Convert(reader.GetValue(4).ToString().Trim());
							string clientPhone = Convert(reader.GetValue(5).ToString().Trim());
							string inn = Convert(reader.GetValue(6).ToString().Trim());
							string passportSeries = Convert(reader.GetValue(7).ToString().Trim());
							string passportNumber = Convert(reader.GetValue(8).ToString().Trim());
							string passportOutletOrgan = Convert(reader.GetValue(9).ToString().Trim());
							string passportOutletDate = Convert(reader.GetValue(10).ToString().Trim());
							result.Add(new Contractor(client1SCode, clientName, isJuridicalPerson, clientAddress, clientPostAddress, clientPhone, inn, passportSeries, passportNumber, passportOutletOrgan, passportOutletDate));
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
		/// Gets the contractor.
		/// </summary>
		/// <param name="contractorCode">The contractor code.</param>
		/// <returns>The contractor.</returns>
		public static Contractor GetContractor(string contractorCode)
		{
			Contractor result = null;
			using (OdbcConnection connection = new OdbcConnection(OdbcConnectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}
				try
				{
					OdbcCommand command = new OdbcCommand { CommandText = GET_ONE_COMMAND_TEXT, Connection = connection, CommandType = CommandType.StoredProcedure };
					command.Parameters.Add(new OdbcParameter("@code", contractorCode));
					OdbcDataReader reader = command.ExecuteReader();
					if (reader != null)
					{
						while (reader.Read())
						{
							string client1SCode = Convert(reader.GetValue(0).ToString().Trim());
							string clientName = Convert(reader.GetValue(1).ToString().Trim());
							bool isJuridicalPerson = Convert(reader.GetValue(2).ToString().Trim()) == PRIVATE_PERSONE_CODE ? false : true;
							string clientAddress = Convert(reader.GetValue(3).ToString().Trim());
							string clientPostAddress = Convert(reader.GetValue(4).ToString().Trim());
							string clientPhone = Convert(reader.GetValue(5).ToString().Trim());
							string inn = Convert(reader.GetValue(6).ToString().Trim());
							string passportSeries = Convert(reader.GetValue(7).ToString().Trim());
							string passportNumber = Convert(reader.GetValue(8).ToString().Trim());
							string passportOutletOrgan = Convert(reader.GetValue(9).ToString().Trim());
							string passportOutletDate = Convert(reader.GetValue(10).ToString().Trim());
							result = new Contractor(client1SCode, clientName, isJuridicalPerson, clientAddress, clientPostAddress, clientPhone, inn, passportSeries, passportNumber, passportOutletOrgan, passportOutletDate);
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

		#region Private Methods

		private static string Convert(string value)
		{
			byte[] res866 = Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding(866),
			                                 Encoding.Unicode.GetBytes(value));
			byte[] resUni = Encoding.Convert(Encoding.GetEncoding(1251), Encoding.Unicode,
			                                 res866);
			string result = Encoding.Unicode.GetString(resUni);
			return result;
		}

		#endregion
	}
}