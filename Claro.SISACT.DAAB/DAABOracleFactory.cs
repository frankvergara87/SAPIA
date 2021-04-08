using System.Data; 
using  Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Xml; 
using System.Collections;
using System;
namespace Claro.SisAct.DAAB
{ 
public class DAABOracleFactory : DAABAbstracFactory 
{ 
	
	private OracleConnection m_conecSQL; 
	private OracleTransaction m_TranSQL; 

	private void AttachParameters(OracleCommand command, OracleParameter[] commandParameters) 
	{ 
		if ((command == null)) 
		{ 
			throw new ArgumentNullException("command"); 
		} 
		if ((!(commandParameters == null))) 
		{ 
			; 
			foreach (OracleParameter p in commandParameters) 
			{ 
				if ((!(p == null))) 
				{ 
					if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && p.Value == null) 
					{ 
						p.Value = DBNull.Value; 
					} 
					command.Parameters.Add(p); 
				} 
			} 
		} 
	} 

	
	private void AssignParameterValues(OracleParameter[] commandParameters, DataRow dataRow) 
	{ 
		if (commandParameters == null || dataRow == null) 
		{ 
			return; 
		} 
		
		int i=0; 
		foreach (OracleParameter commandParameter in commandParameters) 
		{ 
			if ((commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1)) 
			{ 
				throw new Exception(string.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: ' {1}' .", i, commandParameter.ParameterName)); 
			} 
			if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName) != -1) 
			{ 
				commandParameter.Value = dataRow[commandParameter.ParameterName]; 
			} 
			i++; 
		} 
	} 

	
	private void AssignParameterValues(OracleParameter[] commandParameters, object[] parameterValues) 
	{ 
		int j; 
		if ((commandParameters == null) && (parameterValues == null)) 
		{ 
			return; 
		} 
		if (commandParameters.Length != parameterValues.Length) 
		{ 
			throw new ArgumentException("Parameter count does not match Parameter Value count."); 
		} 
		j = commandParameters.Length - 1; 
		for (int i = 0; i <= j; i++) 
		{ 
			if (parameterValues[i] is IDbDataParameter) 
			{ 
				IDbDataParameter paramInstance = ((IDbDataParameter)(parameterValues[i])); 
				if ((paramInstance.Value == null)) 
				{ 
					commandParameters[i].Value = DBNull.Value; 
				} 
				else 
				{ 
					commandParameters[i].Value = paramInstance.Value; 
				} 
			} 
			else if ((parameterValues[i] == null)) 
			{ 
				commandParameters[i].Value = DBNull.Value; 
			} 
			else 
			{ 
				commandParameters[i].Value = parameterValues[i]; 
			} 
		} 
	} 

	
	private void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, ref bool mustCloseConnection) 
	{ 
		if ((command == null)) 
		{ 
			throw new ArgumentNullException("command"); 
		} 
		if ((commandText == null || commandText.Length == 0)) 
		{ 
			throw new ArgumentNullException("commandText"); 
		} 
		if (connection.State != ConnectionState.Open) 
		{ 
			connection.Open(); 
			mustCloseConnection = true; 
		} 
		else 
		{ 
			mustCloseConnection = false; 
		} 
		command.Connection = connection; 
		command.CommandText = commandText; 
		
		if (!((transaction == null))) 
		{ 
			if (transaction.Connection == null) 
			{ 
				throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction"); 
			} 
			command.Transaction = transaction; 
		} 
		command.CommandType = commandType; 
		command.BindByName=true;
		if (!((commandParameters == null))) 
		{ 
			AttachParameters(command, commandParameters); 
		} 
		return; 
	} 


		private OracleParameter[] ConvertToOracleParameter(CommandType commandType, ArrayList parametros)
		{
			if (parametros==null || parametros.Count==0)
			{
				return null;
			}
	
			OracleParameter[]  oOracleParameter = new OracleParameter[parametros.Count];
			int y=0;

			foreach (IDbDataParameter iParan in parametros)
			{
				oOracleParameter[y]= new OracleParameter();
				oOracleParameter[y].ParameterName = iParan.ParameterName;
				oOracleParameter[y].SourceColumn = iParan.SourceColumn;
				oOracleParameter[y].SourceVersion = iParan.SourceVersion;
				oOracleParameter[y].Direction = iParan.Direction;
				oOracleParameter[y].DbType =  CastOracleParameterDbType(iParan.DbType);
				oOracleParameter[y].OracleDbType = CastOracleDbType(iParan.DbType);
				oOracleParameter[y].Size = (iParan.Size == 0 && iParan.DbType == DbType.String) ? 50 : iParan.Size;
				oOracleParameter[y].Value = iParan.Value;						
				y=y+1;
			}
			return oOracleParameter;
		}

		/// <summary>
		/// Conversion para datos no Soportados en Oracle System.Data.DbType
		/// </summary>
		/// <param name="dbType"></param>
		/// <returns></returns>
		public DbType CastOracleParameterDbType(DbType dbType)
		{
			if(DbType.Currency== dbType)
			{
				return DbType.Decimal;
			}
			else if (DbType.Boolean== dbType)
			{
				return DbType.Byte;
			}
			else if (DbType.Guid== dbType)
			{
				return DbType.String;
			}
			else if (DbType.SByte== dbType)
			{
				return DbType.Int32;
			}
			else if (DbType.UInt16== dbType)
			{
				return DbType.Int16;
			}
			else if (DbType.UInt32== dbType)
			{
				return DbType.Int32;
			}
			else if (DbType.UInt64== dbType)
			{
				return DbType.Int64;
			}
			else if (DbType.VarNumeric== dbType)
			{
				return DbType.Decimal;
			}
			else
			{
				return dbType;
			}
		}

	
		public OracleDbType CastOracleDbType(DbType oDbType)
		{
			switch (oDbType)
			{
				case DbType.Object:
					return OracleDbType.RefCursor;
				case DbType.Date:
					return OracleDbType.Date;
				case DbType.DateTime:
					return OracleDbType.Date;
				case DbType.Currency:
					return OracleDbType.Decimal;
				case DbType.Double:
					return OracleDbType.Double;
				case DbType.Single:
					return OracleDbType.Single;
				case DbType.Decimal:
					return OracleDbType.Decimal;
				case DbType.VarNumeric:
					return OracleDbType.Decimal;
				case DbType.Byte:
					return OracleDbType.Byte;
				case DbType.AnsiString:
					return OracleDbType.Varchar2;
				case DbType.AnsiStringFixedLength:
					return OracleDbType.Varchar2;
				case DbType.Binary:
					return OracleDbType.Blob;
				case DbType.Boolean:
					return OracleDbType.Byte;				
				case DbType.Guid:
					return OracleDbType.Raw;
				case DbType.SByte :
					return OracleDbType.Int16;
				case DbType.Int16 :
					return OracleDbType.Int16;
				case DbType.UInt16:
					return OracleDbType.Int16;
				case DbType.Int32:
					return OracleDbType.Int32;
				case DbType.UInt32:
					return OracleDbType.Int32;
				case  DbType.Int64 :
					return OracleDbType.Int64;
				case DbType.UInt64:
					return OracleDbType.Int64;
				case DbType.String:
					return OracleDbType.Varchar2;
				case DbType.StringFixedLength:
					return OracleDbType.Char;
				case DbType.Time:
					return OracleDbType.Date;
				default:
					return OracleDbType.Varchar2;
			}
		}


		private void AsingValueParameter(OracleParameter[] paranOracle, ref ArrayList paramValues )
		{
			if (paranOracle==null || paranOracle.Length==0) {return;}

			for (int r=0; r<paranOracle.Length; r++)
			{
				if (paranOracle[r].Direction != ParameterDirection.Input)
				{
					((IDbDataParameter)paramValues[r]).Value = CastsDbTypeValue(paranOracle[r]);
				}
			}
		}


		private object CastsDbTypeValue(OracleParameter oValue)
		{		
			if (oValue.Value.GetType().FullName.IndexOf("System.")>-1)
			{
				return oValue.Value;
			}

			switch (oValue.DbType)
			{
				case DbType.String:
					return  ((OracleString)oValue.Value).IsNull? null: ((OracleString)oValue.Value).ToString();
				case DbType.Int32:
					return  ((OracleDecimal)oValue.Value).IsNull? 0: ((OracleDecimal)oValue.Value).ToInt32();
				case DbType.Int64:
					return  ((OracleDecimal)oValue.Value).IsNull? 0: ((OracleDecimal)oValue.Value).ToInt64();	
				case DbType.Decimal:
					return  ((OracleDecimal)oValue.Value).IsNull? 0: ((OracleDecimal)oValue.Value).ToDouble();
				case DbType.Double:
					return  ((OracleDecimal)oValue.Value).IsNull? 0: ((OracleDecimal)oValue.Value).ToDouble();
				case DbType.Currency:
					return  ((OracleDecimal)oValue.Value).IsNull? 0: ((OracleDecimal)oValue.Value).ToDouble();
				default:
					return oValue.Value;
			}
		}
	

	private bool estableceConexion(bool pb_transaccional, string pc_cadConexion) 
	{ 
		if (m_conecSQL == null || m_conecSQL.State != ConnectionState.Open) 
		{ 
			m_conecSQL = new OracleConnection(pc_cadConexion); 
			m_conecSQL.Open(); 
		} 
		if (pb_transaccional && m_TranSQL == null) 
		{ 
			m_TranSQL = m_conecSQL.BeginTransaction(IsolationLevel.ReadCommitted); 
		} 
		return true;
	} 

	
	public override DataSet ExecuteDataset(ref DAABRequest request)
	{
		string connectionString = request.ConnectionString;
		DataSet objDataSet = new DataSet();
		if ((connectionString == null || connectionString.Length == 0))
		{
			throw new ArgumentNullException("connectionString");
		}
		if ((request.Command == null || request.Command.Length == 0))
		{
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
		}
		try
		{
			ArrayList lista = request.Parameters;
			estableceConexion(request.Transactional, connectionString);
			OracleParameter[]  aparam = ConvertToOracleParameter(request.CommandType, lista); 
			if (request.Transactional)
			{
				objDataSet = ExecuteDatasets(m_TranSQL, request.CommandType, request.Command, aparam, request.TableNames);
			}
			else
			{
				objDataSet = ExecuteDatasets(m_conecSQL, request.CommandType, request.Command, aparam, request.TableNames);
			}
			AsingValueParameter(aparam, ref lista);
		}
		catch (Exception ex)
		{
			request.Exception = ex;
			throw ex;
		}
		finally
		{
			if (!(request.Transactional) & !(m_conecSQL == null))
			{
				m_conecSQL.Dispose();
			}
                
		}
		return objDataSet;
	}

	
	private DataSet ExecuteDatasets(OracleConnection connection, CommandType commandType, string commandText, OracleParameter[] commandParameters, string[] tableNames) 
	{ 
		if ((connection == null)) 
		{ 
			throw new ArgumentNullException("connection"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		DataSet ds = new DataSet(); 
		OracleDataAdapter dataAdatpter = new OracleDataAdapter(); 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters,ref mustCloseConnection); 
		try 
		{ 
			dataAdatpter = new OracleDataAdapter(cmd); 
				if (tableNames == null)
				{
				dataAdatpter.Fill(ds); 
					for(int i=0 ;i<ds.Tables.Count;i++)
					{
					ds.Tables[0].TableName = "Tabla" + i.ToString();
					ds.AcceptChanges();
				}
				} 
				else if (!(tableNames == null && tableNames.Length > 0)) 
			{ 
				dataAdatpter.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					
					for ( int index = 0; index < tableNames.Length; index++) 
					{ 
							if ((tableNames[index] == null || tableNames[index].Length == 0))
							{ 
							throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames"); 
						} 

						ds.Tables[index].TableName = tableNames[index];
					} 				 
				}
			} 
			cmd.Parameters.Clear(); 
		} 
		finally 
		{ 
			if (dataAdatpter != null) 
			{ 
				dataAdatpter.Dispose(); 
			} 
		} 
		if ((mustCloseConnection)) 
		{ 
			connection.Close(); 
		} 
		return ds; 
	} 

	
	private DataSet ExecuteDatasets(OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, string[] tableNames) 
	{ 
		if ((transaction == null)) 
		{ 
			throw new ArgumentNullException("transaction"); 
		} 
		if (!((transaction == null)) && (transaction.Connection == null)) 
		{ 
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		DataSet ds = new DataSet(); 
		OracleDataAdapter dataAdatpter = new OracleDataAdapter(); 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection); 
		try 
		{ 
			dataAdatpter = new OracleDataAdapter(cmd); 
			if (!(tableNames == null && tableNames.Length > 0)) 
			{ 
				string tableName = "Table"; 
				
				for (int index = 0; index <= tableNames.Length - 1; index++) 
				{ 
					if ((tableNames[index] == null || tableNames[index].Length == 0)) 
					{ 
						throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames"); 
					} 
					dataAdatpter.TableMappings.Add(tableName, tableNames[index]); 
					tableName = tableName + (index + 1).ToString(); 
				} 
			} 
			dataAdatpter.Fill(ds); 
			cmd.Parameters.Clear(); 
		} 
		finally 
		{ 
			if ((!(dataAdatpter == null))) 
			{ 
				dataAdatpter.Dispose(); 
			} 
		} 
		return ds; 
	} 

	
	public override int ExecuteNonQuery(ref DAABRequest Request) 
	{ 
		string connectionString = Request.ConnectionString; 
		if ((connectionString == null || connectionString.Length == 0)) 
		{ 
			throw new ArgumentNullException("connectionString"); 
		} 
		if ((Request.Command == null || Request.Command.Length == 0)) 
		{ 
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar."); 
		} 
		try 
		{ 
			ArrayList lista = Request.Parameters;
				OracleParameter[] aparam = ConvertToOracleParameter(Request.CommandType,lista); 
			estableceConexion(Request.Transactional, connectionString); 
			int iretval; 
			if (Request.Transactional) 
			{ 
				iretval = ExecuteNonQuerys(m_TranSQL, Request.CommandType, Request.Command, aparam); 
			} 
			else 
			{ 
				iretval = ExecuteNonQuerys(m_conecSQL, Request.CommandType, Request.Command, aparam); 
			} 
				AsingValueParameter(aparam,ref lista);
			return iretval; 
		} 
		finally 
		{ 
			if (!(Request.Transactional) & !(m_conecSQL == null)) 
			{ 
				m_conecSQL.Dispose(); 
			} 
		} 
	} 

	
	private int ExecuteNonQuerys(OracleConnection connection, CommandType commandType, string commandText, OracleParameter[] commandParameters) 
	{ 
		if ((connection == null)) 
		{ 
			throw new ArgumentNullException("connection"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		int retval; 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, connection, ((OracleTransaction)(null)), commandType, commandText, commandParameters,ref mustCloseConnection); 
		retval = cmd.ExecuteNonQuery(); 
		cmd.Parameters.Clear(); 
		if ((mustCloseConnection)) 
		{ 
			connection.Close(); 
		} 
		return retval; 
	} 

	
	private int ExecuteNonQuerys(OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters) 
	{ 
		if ((transaction == null)) 
		{ 
			throw new ArgumentNullException("transaction"); 
		} 
		if (!((transaction == null)) && (transaction.Connection == null)) 
		{ 
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		int retval; 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection); 
		retval = cmd.ExecuteNonQuery(); 
		cmd.Parameters.Clear(); 
		return retval; 
	} 

	
	public override object ExecuteScalar(ref DAABRequest Request)
	{
		string connectionString = Request.ConnectionString;
		Object objObject = new Object();
		if ((connectionString == null || connectionString.Length == 0))
		{
			throw new ArgumentNullException("connectionString");
		}
		if ((Request.Command == null || Request.Command.Length == 0))
		{
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar.");
		}
		try
		{
			ArrayList lista = Request.Parameters;
			estableceConexion(Request.Transactional, connectionString);
			OracleParameter[]  aparam = ConvertToOracleParameter(Request.CommandType, lista); 
			if (Request.Transactional)
			{
				objObject = ExecuteScalares(m_TranSQL, Request.CommandType, Request.Command, aparam);
			}
			else
			{
				objObject = ExecuteScalares(m_conecSQL, Request.CommandType, Request.Command, aparam);
			}
			AsingValueParameter(aparam, ref lista);
		}
		catch (Exception ex)
		{
			Request.Exception = ex;
			throw ex;
		}
		finally
		{
			if (!(Request.Transactional) & !(m_conecSQL == null))
			{
				m_conecSQL.Dispose();
			}
		}
		return objObject;
	}

	
	private object ExecuteScalares(OracleConnection connection, CommandType commandType, string commandText, OracleParameter[] commandParameters) 
	{ 
		if ((connection == null)) 
		{ 
			throw new ArgumentNullException("connection"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		object retval; 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, connection, ((OracleTransaction)(null)), commandType, commandText, commandParameters, ref mustCloseConnection); 
		retval = cmd.ExecuteScalar(); 
		cmd.Parameters.Clear(); 
		if ((mustCloseConnection)) 
		{ 
			connection.Close(); 
		} 
		return retval; 
	} 

	
	private object ExecuteScalares(OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters) 
	{ 
		if ((transaction == null)) 
		{ 
			throw new ArgumentNullException("transaction"); 
		} 
		if (!((transaction == null)) && (transaction.Connection == null)) 
		{ 
			throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction"); 
		} 
		OracleCommand cmd = new OracleCommand(); 
		object retval; 
		bool mustCloseConnection = false; 
		PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection); 
		retval = cmd.ExecuteScalar(); 
		cmd.Parameters.Clear(); 
		return retval; 
	} 

	
	public override DAABDataReader ExecuteReader(ref DAABRequest Request) 
	{ 
		DAABOracleDataReader oDataReaderSQL; 
		string connectionString = Request.ConnectionString; 
		if ((connectionString == null || connectionString.Length == 0)) 
		{ 
			throw new ArgumentNullException("connectionString"); 
		} 
		try 
		{ 
			ArrayList lista = Request.Parameters;
				OracleParameter[] aparam = ConvertToOracleParameter(Request.CommandType, lista); 
			estableceConexion(false, connectionString); 
			OracleDataReader drSQL; 
			drSQL = ExecuteReaders(m_conecSQL, ((OracleTransaction)(null)), Request.CommandType, Request.Command, aparam); 
			oDataReaderSQL = new DAABOracleDataReader(); 
			oDataReaderSQL.ReturnDataReader = drSQL; 
				AsingValueParameter(aparam,ref lista);
			return oDataReaderSQL; 
		} 
		catch (OracleException ex1) 
		{ 
			if (!(m_conecSQL == null)) 
			{ 
				m_conecSQL.Dispose(); 
			} 
			Request.Exception = ex1; 
			throw ex1; 
		} 
		catch (Exception ex1) 
		{ 
			Request.Exception = ex1; 
			if (!(m_conecSQL == null)) 
			{ 
				m_conecSQL.Dispose(); 
			} 
			throw; 
		} 
	} 

	
	private OracleDataReader ExecuteReaders(OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters) 
	{ 
		if ((connection == null)) 
		{ 
			throw new ArgumentNullException("connection"); 
		} 
		bool mustCloseConnection = false; 
		OracleCommand cmd = new OracleCommand(); 
		try 
		{ 
			OracleDataReader dataReader; 
			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters,ref mustCloseConnection); 
			dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection); 
			bool canClear = true; 			 
			foreach (OracleParameter commandParameter in cmd.Parameters) 
			{ 
				if (commandParameter.Direction != ParameterDirection.Input) 
				{ 
					canClear = false; 
				} 
			} 
			if ((canClear)) 
			{ 
				cmd.Parameters.Clear(); 
			} 
			return dataReader; 
		} 
		catch (Exception ex1) 
		{ 
			if ((mustCloseConnection)) 
			{ 
				connection.Close(); 
			} 
			throw ex1; 
		} 
	} 

	
	public override void FillDataset(ref DAABRequest Request) 
	{ 
		string connectionString = Request.ConnectionString; 
		if ((connectionString == null || connectionString.Length == 0)) 
		{ 
			throw new ArgumentNullException("connectionString"); 
		} 
		if ((Request.Command == null || Request.Command.Length == 0)) 
		{ 
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar."); 
		} 
		if ((Request.RequestDataSet == null)) 
		{ 
			throw new ArgumentNullException("RequestDataSet"); 
		} 
		try 
		{ 
			ArrayList lista = Request.Parameters;
			estableceConexion(Request.Transactional, connectionString); 
				OracleParameter[] aparam = ConvertToOracleParameter(Request.CommandType, lista); 
			if (Request.Transactional) 
			{ 
				FillDatasets(m_conecSQL, m_TranSQL, Request.CommandType, Request.Command, Request.RequestDataSet, Request.TableNames, aparam); 
			} 
			else 
			{ 
				FillDatasets(m_conecSQL, ((OracleTransaction)(null)), Request.CommandType, Request.Command, Request.RequestDataSet, Request.TableNames, aparam); 
			} 
				AsingValueParameter(aparam,ref lista);
		} 
		catch (Exception ex1) 
		{ 
			Request.Exception = ex1; 
			throw ex1; 
		} 
		finally 
		{ 
			if (!(Request.Transactional) & !(m_conecSQL == null)) 
			{ 
				m_conecSQL.Dispose(); 
			} 
		} 
	} 

	
	private void FillDatasets(OracleConnection connection, OracleTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, OracleParameter[] commandParameters) 
	{ 
		if ((connection == null)) 
		{ 
			throw new ArgumentNullException("connection"); 
		} 
		if ((dataSet == null)) 
		{ 
			throw new ArgumentNullException("dataSet"); 
		} 
		OracleCommand command = new OracleCommand(); 
		bool mustCloseConnection = false; 
		PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, ref mustCloseConnection); 
		OracleDataAdapter dataAdapter = new OracleDataAdapter(command); 
		try 
		{ 
			if (!(tableNames == null && tableNames.Length > 0)) 
			{ 
				string tableName = "Table"; 
				int index=0; 
				for ( index = 0; index <= tableNames.Length - 1; index++) 
				{ 
					if ((tableNames[index] == null || tableNames[index].Length == 0)) 
					{ 
						throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames"); 
					} 
					dataAdapter.TableMappings.Add(tableName, tableNames[index]); 
					tableName = tableName + (index + 1).ToString(); 
				} 
			} 
			dataAdapter.Fill(dataSet); 
			command.Parameters.Clear(); 
		} 
		finally 
		{ 
			if ((!(dataAdapter == null))) 
			{ 
				dataAdapter.Dispose(); 
			} 
		} 
		if ((mustCloseConnection)) 
		{ 
			connection.Close(); 
		} 
	} 

	
	public override void UpdateDataSet(ref DAABRequest RequestInsert, ref DAABRequest RequestUpdate, ref DAABRequest RequestDelete) 
	{ 
		string connectionString = RequestInsert.ConnectionString; 
		OracleCommand cmdCommandInsert; 
		OracleCommand cmdCommandUpdate; 
		OracleCommand cmdCommandDelete; 
		if ((connectionString == null || connectionString.Length == 0)) 
		{ 
			throw new ArgumentNullException("connectionString"); 
		} 
		if ((RequestInsert.Command == null || RequestInsert.Command.Length == 0)) 
		{ 
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestInsert"); 
		} 
		if ((RequestUpdate.Command == null || RequestUpdate.Command.Length == 0)) 
		{ 
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestUpdate"); 
		} 
		if ((RequestDelete.Command == null || RequestDelete.Command.Length == 0)) 
		{ 
			throw new ArgumentNullException("No ha ingresado el commando a ejecutar.RequestDelete"); 
		} 
		if ((RequestInsert.RequestDataSet == null)) 
		{ 
			throw new ArgumentNullException("RequestDataSet:RequestInsert"); 
		} 
		if (RequestInsert.TableNames == null) 
		{ 
			throw new ArgumentNullException("Falta especificar el nombre de la tabla a actualizar"); 
		} 
		try 
		{ 
			bool cerrarCn=false;
			ArrayList lista = RequestInsert.Parameters;
			estableceConexion(RequestInsert.Transactional, connectionString); 
			cmdCommandInsert = new OracleCommand(); 
				OracleParameter[] aparamInsert = ConvertToOracleParameter(RequestInsert.CommandType,lista ); 
			PrepareCommand(cmdCommandInsert, m_conecSQL, m_TranSQL, RequestInsert.CommandType, RequestInsert.Command, aparamInsert,ref cerrarCn); 
			cmdCommandUpdate = new OracleCommand(); 
				OracleParameter[] aparamUpdate = ConvertToOracleParameter(RequestUpdate.CommandType,lista); 
			PrepareCommand(cmdCommandUpdate, m_conecSQL, m_TranSQL, RequestUpdate.CommandType, RequestUpdate.Command, aparamUpdate,ref cerrarCn); 
			cmdCommandDelete = new OracleCommand(); 
				OracleParameter[] aparamDelete = ConvertToOracleParameter(RequestDelete.CommandType,lista); 
			PrepareCommand(cmdCommandDelete, m_conecSQL, m_TranSQL, RequestDelete.CommandType, RequestDelete.Command, aparamDelete,ref cerrarCn); 
			UpdateDatasets(cmdCommandInsert, cmdCommandDelete, cmdCommandUpdate, RequestInsert.RequestDataSet, RequestInsert.TableNames[0]); 
				AsingValueParameter(aparamInsert,ref lista);
		} 
		catch (Exception ex1) 
		{ 
			RequestInsert.Exception = ex1; 
			RequestDelete.Exception = ex1; 
			RequestUpdate.Exception = ex1; 
			throw ex1; 
		} 
		finally 
		{ 
			if (!(RequestInsert.Transactional) & !(m_conecSQL == null)) 
			{ 
				m_conecSQL.Dispose(); 
			} 
		} 
	} 

	
	public void UpdateDatasets(OracleCommand insertCommand, OracleCommand deleteCommand, OracleCommand updateCommand, DataSet dataSet, string tableName) 
	{ 
		if ((insertCommand == null)) 
		{ 
			throw new ArgumentNullException("insertCommand"); 
		} 
		if ((deleteCommand == null)) 
		{ 
			throw new ArgumentNullException("deleteCommand"); 
		} 
		if ((updateCommand == null)) 
		{ 
			throw new ArgumentNullException("updateCommand"); 
		} 
		if ((dataSet == null)) 
		{ 
			throw new ArgumentNullException("dataSet"); 
		} 
		if ((tableName == null || tableName.Length == 0)) 
		{ 
			throw new ArgumentNullException("tableName"); 
		} 
		OracleDataAdapter dataAdapter = new OracleDataAdapter(); 
		try 
		{ 
			dataAdapter.UpdateCommand = updateCommand; 
			dataAdapter.InsertCommand = insertCommand; 
			dataAdapter.DeleteCommand = deleteCommand; 
			dataAdapter.Update(dataSet, tableName); 
			dataSet.AcceptChanges(); 
		} 
		finally 
		{ 
			if ((!(dataAdapter == null))) 
			{ 
				dataAdapter.Dispose(); 
			} 
		} 
	} 


	public override void CommitTransaction() 
	{ 
		if (!(m_conecSQL == null && m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null))) 
		{ 
			m_TranSQL.Commit(); 
			m_TranSQL = null; 
			Dispose(); 
		} 
	} 

	
	public override void RollBackTransaction() 
	{ 
		if (!(m_conecSQL == null && m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null))) 
		{ 
			m_TranSQL.Rollback(); 
			m_TranSQL = null; 
			Dispose(); 
		} 
	} 

	
	public override void Dispose() 
	{ 
		if (!(m_conecSQL == null && (!((m_conecSQL.State == ConnectionState.Closed)) | !((m_conecSQL.State == ConnectionState.Broken))))) 
		{ 
			if (m_conecSQL.State == ConnectionState.Open && !(m_TranSQL == null)) 
			{ 
				m_TranSQL.Commit(); 
				m_TranSQL = null; 
			} 
			m_conecSQL.Dispose(); 
		} 
	} 
}
}