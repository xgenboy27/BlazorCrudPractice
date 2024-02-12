using BlazorCrudPractice.Server.Common;
using BlazorCrudPractice.Shared;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorCrudPractice.Server.Services
{
    public class Service : IService
    {
        private readonly ISqlQueryObject _Context;

        const string SP_CreateEmployee = "sp_CreateEmployee";
        const string SP_GetEmployeeList = "sp_GetEmployeeList";
        const string SP_UpdateEmployee = "sp_UpdateEmployee";
        const string SP_DeleteEmployee = "sp_DeleteEmployee";
        const string SP_GetEmployeeById = "sp_GetEmployeeById";
        public Service(ISqlQueryObject Context)
        {
            _Context = Context;
        }
        public async Task<ServiceResponse<string>> SaveEmployee(EmployeeModel employee)
        {

            _Context.ProcedureName = SP_CreateEmployee;
            _Context.Parameters = new System.Data.SqlClient.SqlParameter[]
                { new System.Data.SqlClient.SqlParameter("@EmployeeName", employee.EmployeeName),
                new System.Data.SqlClient.SqlParameter("@EmployeeMiddleName", employee.EmployeeMiddleName),
                new System.Data.SqlClient.SqlParameter("@EmployeeLastName", employee.EmployeeLastName),
                new System.Data.SqlClient.SqlParameter("@EmployeeAge", employee.EmployeeAge)
                };
            await _Context.ExecuteAsync();
            if (_Context.OnFailure) return null;
            var row = _Context.Result.Tables[0].AsEnumerable().FirstOrDefault();

            if (row != null)
            {
                var result = Convert.ToString(row["Message_Code"]);
                return new ServiceResponse<string>
                {
                    Message = result
                };
            }
            else
            {
                return null;
            }
        }
        public async Task<ServiceResponse<string>> UpdateEmployee(EmployeeModel employee)
        {
            _Context.ProcedureName = SP_UpdateEmployee;
            _Context.Parameters = new System.Data.SqlClient.SqlParameter[]
                {
                new System.Data.SqlClient.SqlParameter("@RecId", employee.RecId),
                new System.Data.SqlClient.SqlParameter("@EmployeeName", employee.EmployeeName),
                new System.Data.SqlClient.SqlParameter("@EmployeeMiddleName", employee.EmployeeMiddleName),
                new System.Data.SqlClient.SqlParameter("@EmployeeLastName", employee.EmployeeLastName),
                new System.Data.SqlClient.SqlParameter("@EmployeeAge", employee.EmployeeAge)
                };
            await _Context.ExecuteAsync();
            if (_Context.OnFailure) return null;
            var row = _Context.Result.Tables[0].AsEnumerable().FirstOrDefault();

            if (row != null)
            {
                var result = Convert.ToString(row["Message_Code"]);
                return new ServiceResponse<string>
                {
                    Message = result
                };
            }
            else
            {
                return null;
            }
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployeeList()
        {
            _Context.ProcedureName = SP_GetEmployeeList;
            //_Context.Parameters = new System.Data.SqlClient.SqlParameter[]
            //    { new System.Data.SqlClient.SqlParameter("@EmployeeName", employee.EmployeeName),
            //    new System.Data.SqlClient.SqlParameter("@EmployeeMiddleName", employee.EmployeeMiddleName),
            //    new System.Data.SqlClient.SqlParameter("@EmployeeLastName", employee.EmployeeLastName),
            //    new System.Data.SqlClient.SqlParameter("@EmployeeAge", employee.EmployeeAge)
            //    };
            await _Context.ExecuteAsync();
            if (_Context.OnFailure) return null;

            var result = _Context.Result.Tables[0].AsEnumerable()
                            .Select(row => new EmployeeModel()
                            {
                                RecId = Convert.ToInt32(row["RecId"]),
                                EmployeeName = Convert.ToString(row["EmployeeName"]),
                                EmployeeMiddleName = Convert.ToString(row["EmployeeMiddleName"]),
                                EmployeeLastName = Convert.ToString(row["EmployeeLastName"]),
                                EmployeeAge = Convert.ToInt32(row["EmployeeAge"]),

                            })
                            .ToList();

            return new ServiceResponse<List<EmployeeModel>>() { Data = result };
        }
        public async Task<ServiceResponse<string>> DeleteEmployee(int recid)
        {
            _Context.ProcedureName = SP_DeleteEmployee;
            _Context.Parameters = new System.Data.SqlClient.SqlParameter[]
                {
                new System.Data.SqlClient.SqlParameter("@RecId", recid)
               
                };
            await _Context.ExecuteAsync();
            if (_Context.OnFailure) return null;
            var row = _Context.Result.Tables[0].AsEnumerable().FirstOrDefault();

            if (row != null)
            {
                var result = Convert.ToString(row["Message_Code"]);
                return new ServiceResponse<string>
                {
                    Message = result
                };
            }
            else
            {
                return null;
            }
        }
        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int recid)
        {
            EmployeeModel model = new EmployeeModel();
            _Context.ProcedureName = SP_GetEmployeeById;
            _Context.Parameters = new System.Data.SqlClient.SqlParameter[]
                {
                new System.Data.SqlClient.SqlParameter("@RecId", recid)
                };
            await _Context.ExecuteAsync();
            if (_Context.OnFailure) return null;
            var row = _Context.Result.Tables[0].AsEnumerable().FirstOrDefault();

            if (row != null)
            {
                model.RecId = Convert.ToInt32(row["RecId"]);
                model.EmployeeName = Convert.ToString(row["EmployeeName"]);
                model.EmployeeMiddleName = Convert.ToString(row["EmployeeMiddleName"]);
                model.EmployeeLastName = Convert.ToString(row["EmployeeLastName"]);
                model.EmployeeAge = Convert.ToInt32(row["EmployeeAge"]);
                return new ServiceResponse<EmployeeModel>
                {
                    Data = model
                };
            }
            else
            {
                return null;
            }
        }
    }
}
