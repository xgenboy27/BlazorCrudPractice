using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;


namespace BlazorCrudPractice.Server.Common
{

    public class SqlQueryObject : IDisposable, ISqlQueryObject
    {
        //public string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["HISConnection"].ToString();
        public string ConnectionString { get; set; } = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BlazorCrudPractice";
        public string ProcedureName { get; set; }
        public SqlParameter[] Parameters { get; set; }

        public DataSet Result { get; set; } = new DataSet();
        public bool OnFailure { get; set; } = false;
        public string Problem { get; set; }
        public Exception Exception { get; set; }

        public void Execute()
        {
            if (string.IsNullOrEmpty(ProcedureName))
            {
                OnFailure = true;
                Problem = "Stored Procedure name not defined.";
                return;
            }

            var sqlConnection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            var sqlCommand = new System.Data.SqlClient.SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                    sqlCommand.Parameters.AddRange(Parameters);

                var sqlAdaptor = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                sqlAdaptor.Fill(Result);

                OnFailure = Result.Tables.Count.Equals(0);
            }
            catch (Exception ex)
            {
                OnFailure = true;
                Problem = ex.Message;
                Exception = ex;
            }
            finally
            {
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }

        public async Task ExecuteAsync()
        {
            if (string.IsNullOrEmpty(ProcedureName))
            {
                OnFailure = true;
                Problem = "Stored Procedure name not defined.";
                return;
            }

            var sqlConnection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            var sqlCommand = new System.Data.SqlClient.SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                    sqlCommand.Parameters.AddRange(Parameters);

                var sqlAdaptor = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);

                await Task.Run(() =>
                {
                    sqlAdaptor.Fill(Result);
                    OnFailure = Result.Tables.Count.Equals(0);
                });
            }
            catch (Exception ex)
            {
                OnFailure = true;
                Problem = ex.Message;
                Exception = ex;
            }
            finally
            {
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(ProcedureName))
            {
                OnFailure = true;
                Problem = "Stored Procedure name not defined.";
                return;
            }

            var sqlConnection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            var sqlCommand = new System.Data.SqlClient.SqlCommand();

            cancellationToken.Register(() => sqlCommand.Cancel());

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = ProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (Parameters != null)
                    sqlCommand.Parameters.AddRange(Parameters);

                var sqlAdaptor = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);

                if (cancellationToken.IsCancellationRequested)
                {
                    OnFailure = true;
                    Problem = "Operation Cancelled.";

                    Console.WriteLine("Operation cancelled prior to datafill.");
                }
                else
                {
                    await Task.Run(() =>
                    {
                        sqlAdaptor.Fill(Result);
                        OnFailure = Result.Tables.Count.Equals(0);

                    }, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                OnFailure = true;
                Problem = ex.Message;
                Exception = ex;

                if (Problem.Contains("Operation cancelled by user."))
                    Console.WriteLine("Operation cancelled prior to datafill.");
            }
            finally
            {
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }


        //---------------------------------------------------------------------------------------

        #region Disposable Implementation
        private bool disposed = false;
        private Component component = new Component();
        private IntPtr handle;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();

                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~SqlQueryObject()
        {
            Dispose(false);
        }

        #endregion

    }
}
