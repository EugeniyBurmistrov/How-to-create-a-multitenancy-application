﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.MultiTenancy.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyExample.Module.BusinessObjects {
    [DefaultClassOptions]
    [DefaultProperty(nameof(Position.Title))]
#if OneDatabase
    public class Position : Tenant {
#else
    public class Position : BaseObject {
#endif

        [RuleRequiredField("RuleRequiredField for Position.Title", DefaultContexts.Save)]
        public virtual string Title { get; set; }
    }
}
