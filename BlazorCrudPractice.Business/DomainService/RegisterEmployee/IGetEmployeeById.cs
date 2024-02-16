﻿using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public interface IGetEmployeeById
    {
        EmployeeModel getEmployeeById(int recid);
    }
}
