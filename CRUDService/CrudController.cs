using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            R_Exception loException = new();
            IAsyncEnumerable<CustomerStreamDTO> loRtn = null;
            CRUDCls loCls;
            CustomerListDbParameterDTO loDbPar;
            List<CustomerStreamDTO> loRtnTmp;
            try
            {
                loDbPar = new();
                loDbPar.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;

                loCls = new();
                loRtnTmp = loCls.CustomerListDB(loDbPar);

                loRtn = GetCustomerStream(loRtnTmp);
            }
            catch (Exception e)
            {
                loException.Add(e);
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

        [HttpPost]
        public R_ServiceGetRecordResultDTO<CustomerDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<CustomerDTO> poParameter)
        {
            R_Exception loException = new();
            R_ServiceGetRecordResultDTO<CustomerDTO> loRtn = null;
            CRUDCls loCls;
            try
            {
                loCls = new();
                loRtn = new R_ServiceGetRecordResultDTO<CustomerDTO>();
                //poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception e)
            {
                loException.Add(e);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        [HttpPost]

        public R_ServiceSaveResultDTO<CustomerDTO> R_ServiceSave(R_ServiceSaveParameterDTO<CustomerDTO> poParameter)
        {
            R_Exception loException = new();
            R_ServiceSaveResultDTO<CustomerDTO> loRtn = null;
            CRUDCls loCls;
            try
            {
                loCls = new();
                loRtn = new R_ServiceSaveResultDTO<CustomerDTO>();
                //poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception e)
            {
                loException.Add(e);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;

        }

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<CustomerDTO> poParameter)
        {
            R_Exception loeException = new R_Exception();
            R_ServiceDeleteResultDTO lortn = new R_ServiceDeleteResultDTO();
            CRUDCls loclCls = null;

            try
            {
                loclCls = new CRUDCls();
                loclCls.R_Delete(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loeException.Add(ex);
            }
            loeException.ThrowExceptionIfErrors();
            return lortn;
        }
    }
}