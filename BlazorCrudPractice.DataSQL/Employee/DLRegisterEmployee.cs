using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.DataSQL.Employee
{
    public class DLRegisterEmployee : BaseDataAccess, IDLRegisterEmployee
    {
        const string SP_GetEmployeeList = "sp_GetEmployeeList";
        const string SP_CreateEmployee = "sp_CreateEmployee";
        const string SP_GetEmployeeById = "sp_GetEmployeeById";
        const string SP_UpdateEmployee = "sp_UpdateEmployee";
        const string SP_DeleteEmployee = "sp_DeleteEmployee";
        public List<EmployeeServiceList> GetEmployeeList()
        {       
            IList<EmployeeServiceList> employeelist = new List<EmployeeServiceList>();
            try
            {
                using (var dbCon = new BlazorCrudPracticeDbContext(this.Builder.Options))
                {
                    dbCon.LoadStoredProc(SP_GetEmployeeList)
                                         //.WithSqlParam("@UserID", pUserID)
                                         .ExecuteStoredProc((handler) =>
                                         {
                                             employeelist = handler.ReadToList<EmployeeServiceList>();
                                         });
                }
                //if (employeelist.Count > 0)
                //{
                //    employee = employeelist.ToList();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeelist.ToList();
        }
        public string result { get; set; }
        public string CreateEmployee(string model)
        {
            System.Data.Common.DbParameter message_Code = null;
            using (var dbCon = new BlazorCrudPracticeDbContext(this.Builder.Options))
            {

                dbCon.LoadStoredProc(SP_CreateEmployee)
                                     .WithSqlParam("@JData", model)
                                     //.WithSqlParam("@EmployeeMiddleName", model.EmployeeMiddleName)
                                     //.WithSqlParam("@EmployeeLastName", model.EmployeeLastName)
                                     //.WithSqlParam("@EmployeeAge", model.EmployeeAge)
                                     //.WithSqlParam("@EmployeeDateOfBirth", model.EmployeeDateOfBirth)
                                     .WithSqlParam("@Message_Code", (dbParam) =>
                                     {
                                         dbParam.Direction = System.Data.ParameterDirection.Output;
                                         dbParam.DbType = System.Data.DbType.String;
                                         dbParam.Size = 150;
                                         message_Code = dbParam;
                                     })
                                    .ExecuteStoredProc((handler) =>
                                    {
                                    });
            }
            return (string)message_Code.Value;
        }
        public EmployeeModel GetEmployeeById(int recid)
        {

            EmployeeModel employeelist = new EmployeeModel();
            try
            {
                using (var dbCon = new BlazorCrudPracticeDbContext(this.Builder.Options))
                {
                    dbCon.LoadStoredProc(SP_GetEmployeeById)
                                         .WithSqlParam("@RecId", recid)
                                         .ExecuteStoredProc((handler) =>
                                         {
                                             employeelist = handler.ReadToList<EmployeeModel>().ToList().SingleOrDefault();
                                         });
                }
                //if (employeelist.Count > 0)
                //{
                //    employee = employeelist.ToList();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeelist;
        }
        public string UpdateEmployee(EmployeeModel model)
        {
            System.Data.Common.DbParameter message_Code = null;
            using (var dbCon = new BlazorCrudPracticeDbContext(this.Builder.Options))
            {
                dbCon.LoadStoredProc(SP_UpdateEmployee)
                                      .WithSqlParam("@RecId", model.RecId)
                                     .WithSqlParam("@EmployeeName", model.EmployeeName)
                                     .WithSqlParam("@EmployeeMiddleName", model.EmployeeMiddleName)
                                     .WithSqlParam("@EmployeeLastName", model.EmployeeLastName)
                                     .WithSqlParam("@EmployeeAge", model.EmployeeAge)
                                     .WithSqlParam("@EmployeeDateOfBirth", model.EmployeeDateOfBirth)
                                     .WithSqlParam("@Message_Code", (dbParam) =>
                                     {
                                         dbParam.Direction = System.Data.ParameterDirection.Output;
                                         dbParam.DbType = System.Data.DbType.String;
                                         dbParam.Size = 150;
                                         message_Code = dbParam;
                                     })
                                    .ExecuteStoredProc((handler) =>
                                    {
                                    });
            }
            return (string)message_Code.Value;
        }
        public string DeleteEmployee(int recid)
        {
            System.Data.Common.DbParameter message_Code = null;
            using (var dbCon = new BlazorCrudPracticeDbContext(this.Builder.Options))
            {
                dbCon.LoadStoredProc(SP_DeleteEmployee)
                                      .WithSqlParam("@RecId", recid)                    
                                     .WithSqlParam("@Message_Code", (dbParam) =>
                                     {
                                         dbParam.Direction = System.Data.ParameterDirection.Output;
                                         dbParam.DbType = System.Data.DbType.String;
                                         dbParam.Size = 150;
                                         message_Code = dbParam;
                                     })
                                    .ExecuteStoredProc((handler) =>
                                    {
                                    });
            }
            return (string)message_Code.Value;
        }
    }
}
