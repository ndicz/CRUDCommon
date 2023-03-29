using CRUDBack;
using CRUDCommon;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;

namespace CRUDService
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDController : ControllerBase, ICRUD
    {
        [HttpPost]
        public IAsyncEnumerable<CustomerStreamDTO> CustomerList()
        {
            R_Exception loException = new R_Exception();
            IAsyncEnumerable<CustomerStreamDTO> loRtn = null;

            CRUDCls loCls;
            CustomerListDbParameterDTO loDbParameter;
            List<CustomerStreamDTO> loTempRtn;

            try
            {
                loDbParameter = new CustomerListDbParameterDTO();
                loDbParameter.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;

                loCls = new CRUDCls();

                loTempRtn = loCls.CustomerListDB(loDbParameter);

                loRtn = GetCustomerStream(loTempRtn);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }


        private async IAsyncEnumerable<CustomerStreamDTO> GetCustomerStream(List<CustomerStreamDTO> poParameter)
        {
            foreach (CustomerStreamDTO item in poParameter)
            {
                yield return item;
            }
        }


    }
}