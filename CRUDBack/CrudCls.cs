using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCommon;
using R_BackEnd;
using R_Common;

namespace CRUDBack
{
    public class CRUDCls    
    {
        public List<CustomerStreamDTO> CustomerListDB(CustomerListDbParameterDTO poParameterDto)
        {
            R_Exception loException = new();
            List<CustomerStreamDTO> loRtn = null;
            string lcCmd;
            R_Db loDb;

            try
            {
                lcCmd = "select  CCOMPANY_ID, CustomerID, CustomerID,ContactName TrainCustomer (nolock) where CCOMPANY_ID={0}";
                loDb = new R_Db();
                loRtn = loDb.SqlExecObjectQuery<CustomerStreamDTO>(lcCmd, poParameterDto.CCOMPANY_ID);

            }
            catch (Exception e)
            {
                loException.Add(e);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }
    }
}