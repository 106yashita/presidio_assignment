﻿using ModelClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLlibrary
{
    public interface IDepartmentService
    {
        int AddDepartment(Department department);
        Department ChangeDepartmentName(string departmentOldName, string departmentNewName);
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string departmentName);
        int GetDepartmentHeadId(int departmentId);
    }
}
