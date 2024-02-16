using BlazorCrudPractice.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService
{
    public class BaseDataInfo
    {
        public bool isValid;
        public List<IDataAccess> dataAccess { get; set; }
        public IDataAccessFactory dataFactory { get; set; }


        public IDLMainBlazorCrudPractice dlMainBlazorCrudPractice;

        public BaseDataInfo(List<IDataAccess> pDataAccess)
        {
            this.dataAccess = pDataAccess;
            this.dataFactory = new DataAccessFactory(dataAccess);
            this.dlMainBlazorCrudPractice = dataFactory.GetDL<IDLMainBlazorCrudPractice>();

        }

        public BaseDataInfo(IDataAccessFactory pDataFactory)
        {
            this.dataFactory = pDataFactory;
            this.dataAccess = dataFactory.DataAccess;
            this.dlMainBlazorCrudPractice = dataFactory.GetDL<IDLMainBlazorCrudPractice>();

        }

        public BaseDataInfo() { }
    }
}
