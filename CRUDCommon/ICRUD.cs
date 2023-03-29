using System;
using System.Collections.Generic;
using System.Text;
using R_CommonFrontBackAPI;

namespace CRUDCommon
{
    public interface ICRUD : R_IServiceCRUDBase<CustomerDTO>
    {
        IAsyncEnumerable<CustomerStreamDTO> CustomerList();

    }
}
