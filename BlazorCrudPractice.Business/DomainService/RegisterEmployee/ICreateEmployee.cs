﻿using BlazorCrudPractice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public interface ICreateEmployee
    {
        string createEmployee(EmployeeModel model);
    }
}
