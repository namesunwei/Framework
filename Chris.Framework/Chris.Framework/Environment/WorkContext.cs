using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chris.Framework.Environment
{
    [DebuggerDisplay("WorkContext: U = {CurrentUser.UserName}; L = {CurrentLanguage}; T = {CurrentTimeZone.Id}")]
    public abstract class WorkContext : IDisposable
    {
       // private IEnumerable<>
        public const string CurrentUserName = "CurrentUser";
        public const string CurrentLanguageStateName = "CurrentLanguage";
        public const string CurrentTimeZoneState = "CurrentTimeZone";


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
