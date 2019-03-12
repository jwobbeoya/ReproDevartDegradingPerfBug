using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;

namespace ReproDevartDegradingPerfBug.OData.DataModel
{
   public class CommandListener
   {
      [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")]
      public void OnCommandExecuting(DbCommand command, DbCommandMethod executeMethod, Guid commandId, Guid connectionId, bool async, DateTimeOffset startTime)
      {
      }
   }

}
