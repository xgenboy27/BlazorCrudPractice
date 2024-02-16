using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.DataSQL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlazorCrudPractice.Service
{
    public class BaseDataAccessFactory
    {
        private List<IDataAccess> _dataAcesses;
        public List<IDataAccess> dataAcesses { get { return this._dataAcesses; } }

        public IConfiguration Configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json").Build();

        public BaseDataAccessFactory()
        {
            this.RegisterDataAcesses();
        }

        private void RegisterDataAcesses()
        {
            this._dataAcesses = new List<IDataAccess>();
            this._dataAcesses.Add(new DLMainBlazorCrudPractice());
        }
    }
}
