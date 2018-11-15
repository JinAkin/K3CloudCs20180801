using Newtonsoft.Json;

namespace K3CloudCs
{
    public class SAL_OUTSTOCK_BatchOBJECT
    {
        public SAL_OUTSTOCK_BatchOBJECT(SAL_OUTSTOCK[] sModel)
        {
            Model = sModel;
        }
        public bool NumberSearch = true;//：是否使用Number来搜索基础资料，默认为True（非必录）
        public bool ValidateFlag = true;//：是否验证标志，布尔类型,默认为True（非必录）
        public bool IsDeleteEntry = true;//：是否删除分录，默认True删除（非必录）：
        public string[] NeedUpDateFields = { };//：需要保存的字段,格式["fieldkey1", "fieldkey2", "entitykey1",...]，数组类型(非必录)
        public string[] NeedReturnFields = { };//：需要返回的结果字段,格式["fieldkey", "entitykey.fieldkey",...]（非必录）：
        public string SubSystemId = "";//：菜单所在子系统Id（非必录）：
        public SAL_OUTSTOCK[] Model;//：表单实体数据（必录）
        public int BatchCount = 0;//：批量保存数量，整形（非必录）
    }
    public class SAL_OUTSTOCK_OBJECT
    {
        public SAL_OUTSTOCK_OBJECT(SAL_OUTSTOCK sSAL_OUTSTOCK)
        {
            Model = sSAL_OUTSTOCK;
        }
        public string Creator = "";
        public string[] NeedUpDateFields = { };
        public string[] NeedReturnFields = { };
        public bool IsDeleteEntry = true;
        public int SubSystemId;
        public bool IsVerifyBaseDataField = false;
        public SAL_OUTSTOCK Model;
    }
    public class SAL_OUTSTOCK
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFBillTypeID">单据类型代码</param>
        /// <param name="sFSaleOrgId">销售组织代码</param>
        /// <param name="sFDate">日期</param>
        /// <param name="sFStockOrgId">发货组织代码</param>
        /// <param name="sFStoreomerID">客户代码</param>
        /// <param name="SubHeadEntitys">表头信息</param>
        /// <param name="FEntitys">表体信息</param>
        /// <param name="FOutStockTraces">出货信息</param>
        public SAL_OUTSTOCK(string sFBillTypeID,string sFSaleOrgId,string sFDate,string sFStockOrgId,string sFStoreomerID, SAL_OUTSTOCK__SubHeadEntity SubHeadEntitys, SAL_OUTSTOCK__FEntity[] FEntitys, SAL_OUTSTOCK__FOutStockTrace[] FOutStockTraces)
        {
            FDate = sFDate;
            FBillTypeID = new SAL_OUTSTOCK_BOS_BillType();
            FBillTypeID.FNumber = sFBillTypeID;
            FSaleOrgId = new SAL_OUTSTOCK_ORG_Organizations();
            FSaleOrgId.FNumber = sFSaleOrgId;
            FSaleDeptID = new SAL_OUTSTOCK_BD_Department();
            FCustomerID = new SAL_OUTSTOCK_BD_Customer();
            FCustomerID.FNumber = sFStoreomerID;
            FHeadLocationId = new SAL_OUTSTOCK_BD_CUSTCONTACTION();
            FCarrierID = new SAL_OUTSTOCK_BD_Supplier();
            FCorrespondOrgId = new SAL_OUTSTOCK_ORG_Organizations();            
            FSalesGroupID = new SAL_OUTSTOCK_BD_OperatorGroup();
            FSalesManID = new SAL_OUTSTOCK_BD_Saler();
            FStockOrgId = new SAL_OUTSTOCK_ORG_Organizations();
            FStockOrgId.FNumber = sFStockOrgId;
            FDeliveryDeptID = new SAL_OUTSTOCK_BD_Department();
            FStockerGroupID = new SAL_OUTSTOCK_BD_OperatorGroup();
            FStockerID = new SAL_OUTSTOCK_BD_WAREHOUSEWORKERS();
            FReceiverID = new SAL_OUTSTOCK_BD_Customer();
            FSettleID = new SAL_OUTSTOCK_BD_Customer();
            FReceiverContactID = new SAL_OUTSTOCK_BD_StoreContact();
            FPayerID = new SAL_OUTSTOCK_BD_Customer();
            FOwnerIdHead = new SAL_OUTSTOCK_BOS_ItemClass();
            SubHeadEntity = SubHeadEntitys;
            FEntity = FEntitys;
            FOutStockTrace = FOutStockTraces;            
        }
        public long FID=0;
        public SAL_OUTSTOCK_BOS_BillType FBillTypeID;
        public string FBillNo="";
        public string FDate = "1900-01-01";
        public SAL_OUTSTOCK_ORG_Organizations FSaleOrgId;
        public SAL_OUTSTOCK_BD_Department FSaleDeptID;
        public SAL_OUTSTOCK_BD_Customer FCustomerID;
        public SAL_OUTSTOCK_BD_CUSTCONTACTION FHeadLocationId;
        public SAL_OUTSTOCK_ORG_Organizations FCorrespondOrgId;
        public SAL_OUTSTOCK_BD_Supplier FCarrierID;
        public string FCarriageNO="";
        public SAL_OUTSTOCK_BD_OperatorGroup FSalesGroupID;
        public SAL_OUTSTOCK_BD_Saler FSalesManID;
        public SAL_OUTSTOCK_ORG_Organizations FStockOrgId;
        public SAL_OUTSTOCK_BD_Department FDeliveryDeptID;
        public SAL_OUTSTOCK_BD_OperatorGroup FStockerGroupID;
        public SAL_OUTSTOCK_BD_WAREHOUSEWORKERS FStockerID;
        public string FNote="";
        public SAL_OUTSTOCK_BD_Customer FReceiverID;
        public string FReceiveAddress="";
        public SAL_OUTSTOCK_BD_Customer FSettleID;
        public SAL_OUTSTOCK_BD_StoreContact FReceiverContactID;
        public SAL_OUTSTOCK_BD_Customer FPayerID;
        public string FOwnerTypeIdHead="";
        public SAL_OUTSTOCK_BOS_ItemClass FOwnerIdHead;
        public string FScanBox="";
        public string FCDateOffsetUnit="";
        public long FCDateOffsetValue=0;
        public string FPlanRecAddress="";
        public string F_PAEZ_Text;
        public string F_PAEZ_Text1="";
        public bool FIsTotalServiceOrCost = false;
        public string F_PAEZ_Text2;
        public SAL_OUTSTOCK__SubHeadEntity SubHeadEntity;
        public SAL_OUTSTOCK__FEntity[] FEntity;
        public SAL_OUTSTOCK__FOutStockTrace[] FOutStockTrace;
        
        [JsonIgnore]
        public string FApproveDate;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FApproverID;
        [JsonIgnore]
        public string FBussinessType;
        [JsonIgnore]
        public string FCancelDate;
        [JsonIgnore]
        public string FCancelStatus;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FCancellerID;
        [JsonIgnore]
        public string FCreateDate;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FCreatorId;
        [JsonIgnore]
        public string FCreditCheckResult;
        [JsonIgnore]
        public string FDocumentStatus;
        [JsonIgnore]
        public bool FIsInterLegalPerson;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FModifierId;
        [JsonIgnore]
        public string FModifyDate;
        [JsonIgnore]
        public SAL_OUTSTOCK_IOS_TransferBizType FTransferBizType; 
    }
    public class SAL_OUTSTOCK__SubHeadEntity
    {
        /// <summary>
        /// 出库单表头信息
        /// </summary>
        /// <param name="sFSettleCurrID">结算币别</param>
        /// <param name="sFSettleOrgID">结算组织</param>
        public SAL_OUTSTOCK__SubHeadEntity(string sFSettleCurrID,string sFSettleOrgID)
        {
            FSettleCurrID = new SAL_OUTSTOCK_BD_Currency();
            FSettleCurrID.FNumber = sFSettleCurrID;
            FSettleOrgID = new SAL_OUTSTOCK_ORG_Organizations();
            FSettleOrgID.FNumber = sFSettleOrgID;
            FSettleTypeID = new SAL_OUTSTOCK_BD_SETTLETYPE();
            FReceiptConditionID = new SAL_OUTSTOCK_BD_RecCondition();
            FPriceListId = new SAL_OUTSTOCK_BD_SAL_PriceList();
            FDiscountListId = new SAL_OUTSTOCK_BD_SAL_DiscountList();
            FLocalCurrID = new SAL_OUTSTOCK_BD_Currency();
            FExchangeTypeID = new SAL_OUTSTOCK_BD_RateType();
        }
        public SAL_OUTSTOCK_BD_Currency FSettleCurrID;
        public SAL_OUTSTOCK_ORG_Organizations FSettleOrgID;
        public SAL_OUTSTOCK_BD_SETTLETYPE FSettleTypeID;
        public SAL_OUTSTOCK_BD_RecCondition FReceiptConditionID;
        public SAL_OUTSTOCK_BD_SAL_PriceList FPriceListId;
        public SAL_OUTSTOCK_BD_SAL_DiscountList FDiscountListId;
        public bool FIsIncludedTax = false;
        public SAL_OUTSTOCK_BD_Currency FLocalCurrID;
        public SAL_OUTSTOCK_BD_RateType FExchangeTypeID;
        public decimal FExchangeRate = 1;
        public bool FIsPriceExcludeTax = false;
        [JsonIgnore]
        public decimal FBillAllAmount;
        [JsonIgnore]
        public decimal FBillAllAmount_LC;
        [JsonIgnore]
        public decimal FBillAmount;
        [JsonIgnore]
        public decimal FBillAmount_LC;
        [JsonIgnore]
        public decimal FBillCostAmount;
        [JsonIgnore]
        public decimal FBillCostAmount_LC;
        [JsonIgnore]
        public decimal FBillTaxAmount;
        [JsonIgnore]
        public decimal FBillTaxAmount_LC;
        [JsonIgnore]
        public decimal FCreChkAmount;
        [JsonIgnore]
        public long FCreChkDays;
        [JsonIgnore]
        public string FCreChkStatus;
        [JsonIgnore]
        public string FCreMonControlOver;
        [JsonIgnore]
        public string FCrePreBatAndMonStatus;
        [JsonIgnore]
        public string FCrePreBatchOver;
        [JsonIgnore]
        public bool FISGENFORIOS;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_Supplier FOwnerSupplierID;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_Customer FSETTLEStoreomerID;
    }
    public class SAL_OUTSTOCK__FEntity
    {
        /// <summary>
        /// 出库明细
        /// </summary>
        /// <param name="sFOwnerID">货主:FOwnerID  (必填项)</param>
        /// <param name="sFUnitID">库存单位:FUnitID  (必填项)</param>
        public SAL_OUTSTOCK__FEntity(string sFOwnerID,string sFUnitID, SAL_OUTSTOCK_BD_MATERIAL sFMaterialID)
        {
            FCustMatID = new SAL_OUTSTOCK_Sal_StoreMatMappingView();
            //FAuxPropId = new BD_FLEXSITEMDETAILV_FAuxPropId();
            FUnitID = new SAL_OUTSTOCK_BD_UNIT();
            FUnitID.FNumber = sFUnitID;
            //FBomID = new SAL_OUTSTOCK_ENG_BOM();
            FOwnerID = new SAL_OUTSTOCK_BOS_ItemClass();
            FOwnerID.FNumber = sFOwnerID;
            FMaterialID = sFMaterialID;
            //FLot = new SAL_OUTSTOCK_BD_BatchMainFile();
            //FTaxCombination = new SAL_OUTSTOCK_BD_TAXMIX();
            //FExtAuxUnitId = new SAL_OUTSTOCK_BD_UNIT();
            FStockID = new SAL_OUTSTOCK_BD_STOCK();
            FStockID.FNumber = "CK001";
            //FStockLocID = new BD_FLEXVALUESDETAIL_FStockLocID();
            //FStockStatusID = new SAL_OUTSTOCK_BD_StockStatus();
            //FSalUnitID = new SAL_OUTSTOCK_BD_UNIT();
            //FEOwnerSupplierId = new SAL_OUTSTOCK_BD_Supplier();
            //FESettleStoreomerId = new SAL_OUTSTOCK_BD_Storeomer();
            //FPriceListEntry = new SAL_OUTSTOCK_BD_SAL_PriceList();
            //FTaxDetailSubEntity = new SAL_OUTSTOCK__FTaxDetailSubEntity[] { new SAL_OUTSTOCK__FTaxDetailSubEntity() };
            //FSerialSubEntity = new SAL_OUTSTOCK__FSerialSubEntity[] { new SAL_OUTSTOCK__FSerialSubEntity() };
        }
        public long FENTRYID = 0;
        public SAL_OUTSTOCK_Sal_StoreMatMappingView FCustMatID;
        public string F_PAEZ_Text3="";
        public SAL_OUTSTOCK_BD_MATERIAL FMaterialID;
        public BD_FLEXSITEMDETAILV_FAuxPropId FAuxPropId;
        public SAL_OUTSTOCK_BD_UNIT FUnitID;
        [JsonIgnore]
        public string FInventoryQty = "0";
        public string FRealQty = "0";
        public decimal FPrice=0;
        public decimal FTaxPrice=0;
        public string FIsFree="false";
        public SAL_OUTSTOCK_ENG_BOM FBomID;
        [JsonIgnore]
        public string FProduceDate="";
        public string FOwnerTypeID = "BD_OwnerOrg";
        public SAL_OUTSTOCK_BOS_ItemClass FOwnerID;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_BatchMainFile FLot;
        [JsonIgnore]
        public string FExpiryDate = "";
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_TAXMIX FTaxCombination;
        [JsonIgnore]
        public decimal FEntryTaxRate=0;
        public decimal FAuxUnitQty=0;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FExtAuxUnitId;
        [JsonIgnore]
        public decimal FExtAuxUnitQty=0;
        public SAL_OUTSTOCK_BD_STOCK FStockID;
        [JsonIgnore]
        public BD_FLEXVALUESDETAIL_FStockLocID FStockLocID;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_StockStatus FStockStatusID;
        [JsonIgnore]
        public string FQualifyType = "";
        [JsonIgnore]
        public string FMtoNo = "";
        [JsonIgnore]
        public string FEntrynote = "";
        [JsonIgnore]
        public decimal FDiscountRate=0;
        [JsonIgnore]
        public decimal FActQty=0;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FSalUnitID;
        [JsonIgnore]
        public decimal FSALUNITQTY=0;
        [JsonIgnore]
        public decimal FSALBASEQTY=0;
        [JsonIgnore]
        public decimal FPRICEBASEQTY=0;
        [JsonIgnore]
        public string FProjectNo="";
        [JsonIgnore]
        public bool FOUTCONTROL=false;
        [JsonIgnore]
        public decimal FRepairQty=0;
        [JsonIgnore]
        public string FIsCreateProDoc="";
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_Supplier FEOwnerSupplierId;
        [JsonIgnore]
        public bool FIsOverLegalOrg=false;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_Customer FESettleStoreomerId;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_SAL_PriceList FPriceListEntry;
        [JsonIgnore]
        public decimal FARNOTJOINQTY=0;
        [JsonIgnore]
        public long FQmEntryID=0;
        [JsonIgnore]
        public long FConvertEntryID = 0;
        [JsonIgnore]
        public long FSOEntryId=0;
        [JsonIgnore]
        public long FDisPriceQty = 0;
        [JsonIgnore]
        public long FBeforeDisPriceQty = 0;

        public SAL_OUTSTOCK__FTaxDetailSubEntity[] FTaxDetailSubEntity;
        public SAL_OUTSTOCK__FSerialSubEntity[] FSerialSubEntity;
        [JsonIgnore]
        public decimal FARAMOUNT;
        [JsonIgnore]
        public decimal FARJOINAMOUNT;
        [JsonIgnore]
        public decimal FARJoinQty;
        public decimal FAllAmount;
        public decimal FAllAmount_LC;
        public decimal FAmount;
        public decimal FAmount_LC;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FArrivalConfirmor;
        [JsonIgnore]
        public string FArrivalDate;
        [JsonIgnore]
        public string FArrivalStatus;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FAuxUnitID;
        [JsonIgnore]
        public long FB2CORDERDETAILID;
        [JsonIgnore]
        public string FBASEARQTY;
        [JsonIgnore]
        public SAL_OUTSTOCK_BOS_BFVersion FBFLowId;
        [JsonIgnore]
        public decimal FBaseARJoinQty;
        [JsonIgnore]
        public decimal FBaseInvoicedQty;
        [JsonIgnore]
        public decimal FBaseJoinInStockQty;
        [JsonIgnore]
        public decimal FBaseMustQty;
        [JsonIgnore]
        public decimal FBaseReturnQty;
        [JsonIgnore]
        public decimal FBaseSumInvoicedQty;
        [JsonIgnore]
        public decimal FBaseSumRetNoticeQty;
        [JsonIgnore]
        public decimal FBaseSumRetstockQty;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FBaseUnitID;
        
        [JsonIgnore]
        public decimal FBefDisAllAmt;
        [JsonIgnore]
        public decimal FBefDisAmt;
        [JsonIgnore]
        public decimal FCostAmount_LC;
        [JsonIgnore]
        public decimal FCostPrice;
        [JsonIgnore]
        public string FStoreMatName;
        [JsonIgnore]
        public decimal FDiscount;
        [JsonIgnore]
        public decimal FEntryCostAmount;
        [JsonIgnore]
        public decimal FEntryTaxAmount;
        [JsonIgnore]
        public string FExpiryPeriod;
        [JsonIgnore]
        public string FExpiryPeriodUnit;
        [JsonIgnore]
        public bool FFullyJoined;
        [JsonIgnore]
        public decimal FInvoicedQty;
        [JsonIgnore]
        public string FIsConsumeSum;
        [JsonIgnore]
        public bool FIsRepair;
        [JsonIgnore]
        public decimal FJoinInStockQty;
        [JsonIgnore]
        public string FJoinStatus;
        [JsonIgnore]
        public decimal FJoinedAmount;
        [JsonIgnore]
        public long FJoinedQty;
        [JsonIgnore]
        public SAL_OUTSTOCK_BOS_ItemClass FKeeperID;
        [JsonIgnore]
        public string FKeeperTypeID;
        [JsonIgnore]
        public decimal FLimitDownPrice;
        [JsonIgnore]
        public string FMateriaModel;
        [JsonIgnore]
        public string FMateriaType;
        [JsonIgnore]
        public string FMaterialName;
        [JsonIgnore]
        public decimal FMustQty;
        [JsonIgnore]
        public decimal FPURBASEJOININSTOCKQTY;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_Department FPickDeptId;
        [JsonIgnore]
        public decimal FPriceCoefficient;

        
        [JsonIgnore]
        public string FPriceUnitQty;
        [JsonIgnore]
        public decimal FRefuseQty;
        [JsonIgnore]
        public long FReserveEntryId;
        [JsonIgnore]
        public decimal FReturnQty;
        [JsonIgnore]
        public decimal FSECJOININSTOCKQTY;
        [JsonIgnore]
        public decimal FSECRETURNQTY;
        [JsonIgnore]
        public decimal FSNQty;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FSNUnitID;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_UNIT FSRCBIZUNITID;
        [JsonIgnore]
        public decimal FSalBaseARJoinQty;
        [JsonIgnore]
        public decimal FSalBaseNum;
        [JsonIgnore]
        public decimal FSalCostPrice;
        [JsonIgnore]
        public string FServiceContext;
        [JsonIgnore]
        public string FSoorDerno;
        [JsonIgnore]
        public string FSrcBillNo;
        [JsonIgnore]
        public string FSrcType;
        [JsonIgnore]
        public decimal FStockBaseARJoinQty;
        [JsonIgnore]
        public decimal FStockBaseDen;
        [JsonIgnore]
        public decimal FStockBaseReturnQty;
        [JsonIgnore]
        public decimal FStockBaseSumRetStockQty;
        [JsonIgnore]
        public bool FStockFlag;
        [JsonIgnore]
        public decimal FSumInvoicedAMT;
        [JsonIgnore]
        public decimal FSumInvoicedQty;
        [JsonIgnore]
        public decimal FSumReceivedAMT;
        [JsonIgnore]
        public decimal FSumRetNoticeQty;
        [JsonIgnore]
        public decimal FSumRetStockQty;
        [JsonIgnore]
        public decimal FSysPrice;
        [JsonIgnore]
        public decimal FTaxAmount_LC;
        public decimal FTaxNetPrice;
        [JsonIgnore]
        public long FUNJOINQTY;
        [JsonIgnore]
        public decimal FUnJoinAmount;
        [JsonIgnore]
        public SAL_OUTSTOCK_SEC_User FValidateConfirmor;
        [JsonIgnore]
        public string FValidateDate;
        [JsonIgnore]
        public string FValidateStatus;
        [JsonIgnore]
        public SAL_OUTSTOCK__FEntity_Link[] SAL_OUTSTOCK__FEntity_Link;
               
    }
    public class SAL_OUTSTOCK__FTaxDetailSubEntity
    {
        public long FDetailID=0;
        public decimal FTaxRate=0;
        [JsonIgnore]
        public bool FBuyerWithholding;
        [JsonIgnore]
        public decimal FCostAmount;
        [JsonIgnore]
        public decimal FCostPercent;
        [JsonIgnore]
        public bool FSellerWithholding;
        [JsonIgnore]
        public decimal FTaxAmount;
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_TaxRate FTaxRateId;
        [JsonIgnore]
        public bool FVAT;
    }
    public class SAL_OUTSTOCK__FSerialSubEntity
    {
        public long FDetailID=0;
        public string FSerialNo = "";
        public string FSerialNote="";
        [JsonIgnore]
        public SAL_OUTSTOCK_BD_SerialMainFile FSerialId;       
    }
    public class SAL_OUTSTOCK_SEC_User
    {
        public string FName;
        public string FUserAccount;
        public long FUserID;
    }
    public class SAL_OUTSTOCK_BOS_BillType
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_Supplier
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_ORG_Organizations
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_Customer
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_Department
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_CUSTCONTACTION
    {
        public string FNUMBER="";
    }
    public class SAL_OUTSTOCK_BOS_ItemClass
    {
        [JsonIgnore]
        public long FItemID;//不显示
        public string FNumber="";
        [JsonIgnore]
        public string FNAME;//不显示
    }
    public class SAL_OUTSTOCK_BD_StoreContact
    {
        public string FName = "";
    }
    public class SAL_OUTSTOCK_BD_OperatorGroup
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_Saler
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_WAREHOUSEWORKERS
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_IOS_TransferBizType
    {
        [JsonIgnore]
        public long FID;//不显示
        public string FNUMBER;
        [JsonIgnore]
        public string FNAME;//不显示
    }
    
    public class SAL_OUTSTOCK__FEntity_Link
    {
        public decimal FEntity_Link_FAuxUnitQty;
        public decimal FEntity_Link_FAuxUnitQtyOld;
        public decimal FEntity_Link_FBaseUnitQty;
        public decimal FEntity_Link_FBaseUnitQtyOld;
        public string FEntity_Link_FFlowId;
        public long FEntity_Link_FFlowLineId;
        public decimal FEntity_Link_FLnk1Amount;
        public string FEntity_Link_FLnk1SState;
        public string FEntity_Link_FLnk1TrackerId;
        public decimal FEntity_Link_FLnkAmount;
        public string FEntity_Link_FLnkSState;
        public string FEntity_Link_FLnkTrackerId;
        public string FEntity_Link_FRuleId;
        public decimal FEntity_Link_FSALBASEQTY;
        public decimal FEntity_Link_FSALBASEQTYOld;
        public string FEntity_Link_FSBillId;
        public string FEntity_Link_FSId;
        public long FEntity_Link_FSTableId;
        public string FEntity_Link_FSTableName;
        public long FLinkId;
    }
    public class SAL_OUTSTOCK__FOutStockTraceDetail
    {
        public string FTraceTime = "";
        public string FTraceDetail="";        
    }
   
    public class SAL_OUTSTOCK_BD_SETTLETYPE
    {
        public string FNumber="";
    }

    public class SAL_OUTSTOCK_BD_RecCondition
    {
        public string FNumber="";
    }

    public class SAL_OUTSTOCK_BD_Currency
    {
        public string FNumber="";
    }

    public class SAL_OUTSTOCK_BD_RateType
    {
        public string FNumber="";
    }

    public class SAL_OUTSTOCK_BD_SAL_DiscountList
    {
        public string FNumber="";
    }

    public class BD_FLEXSITEMDETAILV_FAuxPropId
    {
        public string FAUXPROPID__FOPCODE = "";
        public string FAUXPROPID__FF100001="";
        public string FAUXPROPID__FF100004 = "";
        public string FAUXPROPID__FF100002 = "";       
    }
    public class SAL_OUTSTOCK_BD_UNIT
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BOS_BFVersion
    {
        public long FId;
        public string FName;
    }
    public class SAL_OUTSTOCK_ENG_BOM
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_Sal_StoreMatMappingView
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_BatchMainFile
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_MATERIAL
    {
        public SAL_OUTSTOCK_BD_MATERIAL(string sFNumber)
        {
            FNumber = sFNumber;
        }
        public string FNumber="";
    }
    
    public class SAL_OUTSTOCK_BD_SAL_PriceList
    {
        public string FNumber="";
    }
     public class SAL_OUTSTOCK_BD_STOCK
    {
        public string FNumber="";
    }
    public class BD_FLEXVALUESDETAIL_FStockLocID
    {
        public string FSTOCKLOCID__FF100001 = "";
        public string FSTOCKLOCID__FOPCODE = "";
    }
    public class SAL_OUTSTOCK_BD_StockStatus
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK_BD_TAXMIX
    {
        public string FNumber="";
    }
    public class SAL_OUTSTOCK__FOutStockTrace
    {  
        public SAL_OUTSTOCK__FOutStockTrace(string sFCarryBillNo)
        {
            FLogComId = new SAL_OUTSTOCK_BD_KD100LogisticsCom();
            FCarryBillNo = sFCarryBillNo;
            FOutStockTraceDetail = new SAL_OUTSTOCK__FOutStockTraceDetail[] { };
        }
        public long FEntryID = 0;
        public SAL_OUTSTOCK_BD_KD100LogisticsCom FLogComId;
        public string FCarryBillNo = "";
        public SAL_OUTSTOCK__FOutStockTraceDetail[] FOutStockTraceDetail;
    }
    public class SAL_OUTSTOCK_BD_SerialMainFile
    {
        public string FNumber="";
        public long FSERIALID;
    }     
    public class SAL_OUTSTOCK_BD_TaxRate
    {
        [JsonIgnore]
        public long FID;//不显示
        public string FNUMBER;
        [JsonIgnore]
        public string FNAME;//不显示
        public string FTaxType;//不显示
    }
    public class SAL_OUTSTOCK_BD_KD100LogisticsCom
    {
        public string FCode="";
    }

}
