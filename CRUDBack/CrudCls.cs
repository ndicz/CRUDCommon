using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCommon;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace CRUDBack
{
    public class CRUDCls : R_BusinessObject<CustomerDTO>
    {
        public List<CustomerStreamDTO> CustomerListDB(CustomerListDbParameterDTO poParameterDto)
        {
         /*   R_Exception loException = new();
            List<CustomerStreamDTO> loRtn = null;
            string lcCmd;
            R_Db loDb;

            try
            {
                lcCmd = "select  CCOMPANY_ID, CustomerID, CustomerID,ContactName from TrainCustomer(nolock) where CCOMPANY_ID={0}";
                loDb = new R_Db();
                loRtn = loDb.SqlExecObjectQuery<CustomerStreamDTO>(lcCmd, poParameterDto.CCOMPANY_ID);

            }
            catch (Exception e)
            {
                loException.Add(e);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;*/
        }


        protected override CustomerDTO R_Display(CustomerDTO poEntity)
        {
            R_Exception loException = new R_Exception();
            R_Db loDb; 
            string lcCmd;
            CustomerDTO loRtn = null;

            try
            {
                loDb = new R_Db();
                lcCmd = "select  CCOMPANY_ID, CustomerID, CustomerID,ContactName from TrainCustomer(nolock) where CCOMPANY_ID={0} And CustomerID={1}";
                loRtn = loDb.SqlExecObjectQuery<CustomerDTO>(lcCmd, poEntity.COMPANY_ID, poEntity.CustomerID)
                        .FirstOrDefault();

            }
            catch (Exception e)
            {
                loException.Add(e);
            }
            EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtnCustomerDto;
        }

        protected override void R_Saving(CustomerDTO poNewEntity, eCRUDMode poCRUDMode)
        {
            throw new NotImplementedException();
        }

        protected override void R_Deleting(CustomerDTO poEntity)
        {
            throw new NotImplementedException();
        }
    }
}