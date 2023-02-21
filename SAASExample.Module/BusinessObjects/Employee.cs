﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using SAASExtension.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAASExample.Module.BusinessObjects {
    [DefaultClassOptions]
    [DefaultProperty(nameof(Employee.Name))]
#if TenantFirst || LogInFirst
    public class Employee : BaseObject {
#endif
#if TenantFirstOneDatabase
    public class Employee : Tenant {
#endif

        [RuleRequiredField("RuleRequiredField for Employee.Name", DefaultContexts.Save)]
        public virtual string Name { get; set; }
    }
}
