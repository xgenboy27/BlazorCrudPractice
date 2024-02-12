using System.Data;
using System.Data.SqlClient;

namespace BlazorCrudPractice.Server.Common
{
    public interface ISqlQueryObject
    {
        string ConnectionString { get; set; }
        string ProcedureName { get; set; }
        SqlParameter[] Parameters { get; set; }
        DataSet Result { get; set; }
        bool OnFailure { get; set; }
        string Problem { get; set; }
        Exception Exception { get; set; }
        void Execute();
        Task ExecuteAsync();
        Task ExecuteAsync(CancellationToken cancellationToken);
        void Dispose();
    }
}
