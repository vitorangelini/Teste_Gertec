using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Infrastructure.Queries
{
    public class QueryExternal
    {
        public const string INSERT_LOG = @"insert into tblLog (Message,StackTrace,Data) 
                                                        Values(@Message, @StackTrace, NOW())";
    }
}
