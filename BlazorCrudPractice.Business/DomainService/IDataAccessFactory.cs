using BlazorCrudPractice.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService
{
    public interface IDataAccessFactory
    {
        List<IDataAccess> DataAccess { get; set; }

        T GetDL<T>();
    }
}
