using CRUDBack;
using CRUDCommon;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

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


        public R_ServiceGetRecordResultDTO<CustomerDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<CustomerDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        public R_ServiceSaveResultDTO<CustomerDTO> R_ServiceSave(R_ServiceSaveParameterDTO<CustomerDTO> poParameter)
        {
            throw new NotImplementedException();
        }

        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<CustomerDTO> poParameter)
        {
            throw new NotImplementedException();
        }
    }
}