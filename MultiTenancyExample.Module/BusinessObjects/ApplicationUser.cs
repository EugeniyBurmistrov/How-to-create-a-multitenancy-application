﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.ExpressApp.MultiTenancy.BusinessObjects;
using DevExpress.ExpressApp.MultiTenancy.Interfaces;
using DevExpress.ExpressApp.MultiTenancy.Security;

namespace MultiTenancyExample.Module.BusinessObjects;

[DefaultProperty(nameof(UserName))]
#if TenantFirst
public class ApplicationUser : PermissionPolicyUser, ISecurityUserWithLoginInfo {
#endif
#if TenantFirstOneDatabase || PredefinedTenant || PredefinedTenantOneDatabase
public class ApplicationUser : MultiTenancyPermissionPolicyUser, ISecurityUserWithLoginInfo {
#endif
#if LogInFirst || LogInFirstOneDatabase
public class ApplicationUser : MultiTenancyPermissionPolicyUserWithTenants, ISecurityUserWithLoginInfo {
#endif
        public ApplicationUser() : base() {
        UserLogins = new ObservableCollection<ApplicationUserLoginInfo>();
    }

    [Browsable(false)]
    [DevExpress.ExpressApp.DC.Aggregated]
    public virtual IList<ApplicationUserLoginInfo> UserLogins { get; set; }

    IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => UserLogins.OfType<ISecurityUserLoginInfo>();

    ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey) {
        ApplicationUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<ApplicationUserLoginInfo>();
        result.LoginProviderName = loginProviderName;
        result.ProviderUserKey = providerUserKey;
        result.User = this;
        return result;
    }
}
