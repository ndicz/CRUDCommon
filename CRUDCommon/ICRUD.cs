using System;
using System.Collections.Generic;
using System.Text;
using R_CommonFrontBackAPI;

namespace CRUDCommon
{
    public interface ICRUD 
    {
        IAsyncEnumerable<CustomerStreamDTO> CustomerList();

    }
}
