﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.MultiTenancy.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyExample.Module.BusinessObjects {
    [DefaultClassOptions]
    [DefaultProperty(nameof(Employee.Name))]
#if OneDatabase
    public class Employee : Tenant {
#else
    public class Employee : BaseObject {
#endif

        [RuleRequiredField("RuleRequiredField for Employee.Name", DefaultContexts.Save)]
        public virtual string Name { get; set; }
    }
}
