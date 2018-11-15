using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace K3CloudCs
{
    public class SAL_RETURNSTOCK_BatchOBJECT
    {
        public SAL_RETURNSTOCK_BatchOBJECT(SAL_RETURNSTOCK[] sModel)
        {
            Model = sModel;
        }
        public bool NumberSearch = true;//：是否使用Number来搜索基础资料，默认为True（非必录）
        public bool ValidateFlag = true;//：是否验证标志，布尔类型,默认为True（非必录）
        public bool IsDeleteEntry = true;//：是否删除分录，默认True删除（非必录）：
        public string[] NeedUpDateFields = { };//：需要保存的字段,格式["fieldkey1", "fieldkey2", "entitykey1",...]，数组类型(非必录)
        public string[] NeedReturnFields = { };//：需要返回的结果字段,格式["fieldkey", "entitykey.fieldkey",...]（非必录）：
        public string SubSystemId = "";//：菜单所在子系统Id（非必录）：
        public SAL_RETURNSTOCK[] Model;//：表单实体数据（必录）
        public int BatchCount = 0;//：批量保存数量，整形（非必录）
    }
    public class SAL_RETURNSTOCK_OBJECT
    {
        /// <summary>
        /// 退货订单对象
        /// </summary>
        /// <param name="sSal_RETURNSTOCK">退货订单</param>
        public SAL_RETURNSTOCK_OBJECT(SAL_RETURNSTOCK sSal_RETURNSTOCK)
        {
            Model = sSal_RETURNSTOCK;
        }
        public string Creator = "";
        public string[] NeedUpDateFields = { };
        public string[] NeedReturnFields = { };
        public bool IsDeleteEntry = true;
        public int SubSystemId;
        public bool IsVerifyBaseDataField = false;
        public SAL_RETURNSTOCK Model;
    }
    public class SAL_RETURNSTOCK
    {
        /// <summary>
        /// 退货订单
        /// </summary>
        /// <param name="sFBillTypeID">单据类型代码</param>
        /// <param name="sFSaleOrgId">销售组织代码</param>
        /// <param name="sFDate">日期</param>
        /// <param name="sFRetcustId">退货客户代码</param>
        /// <param name="sFStockOrgId">库存组织代码</param>
        /// <param name="sSubHeadEntity">退货订单表头信息</param>
        /// <param name="FEntitys">退货订单表体信息</param>
        public SAL_RETURNSTOCK(string sFBillTypeID,string sFSaleOrgId,string sFDate,string sFRetcustId,string sFStockOrgId,SAL_RETURNSTOCK__SubHeadEntity sSubHeadEntity,SAL_RETURNSTOCK__FEntity[] FEntitys)
        {
            FDate = sFDate;
            FBillTypeID = new SAL_RETURNSTOCK_BOS_BillType();
            FBillTypeID.FNumber = sFBillTypeID;
            FSaleOrgId = new SAL_RETURNSTOCK_ORG_Organizations();
            FSaleOrgId.FNumber = sFSaleOrgId;
            //FSaledeptid = new SAL_RETURNSTOCK_BD_Department();
            FRetcustId = new SAL_RETURNSTOCK_BD_Storeomer();
            FRetcustId.FNumber = sFRetcustId;
            //FReturnReason = new SAL_RETURNSTOCK_BOS_ASSISTANTDATA_SELECT();
            //FHeadLocId = new SAL_RETURNSTOCK_BD_CUSTCONTACTION();
            //FCorrespondOrgId = new SAL_RETURNSTOCK_ORG_Organizations();
            //FTransferBizType = new SAL_RETURNSTOCK_IOS_TransferBizType();
            //FSaleGroupId = new SAL_RETURNSTOCK_BD_OperatorGroup();
            //FSalesManId = new SAL_RETURNSTOCK_BD_Saler();
            FStockOrgId = new SAL_RETURNSTOCK_ORG_Organizations();
            FStockOrgId.FNumber = sFStockOrgId;
            //FStockDeptId = new SAL_RETURNSTOCK_BD_Department();
            //FStockerGroupId = new SAL_RETURNSTOCK_BD_OperatorGroup();
            //FStockerId = new SAL_RETURNSTOCK_BD_WAREHOUSEWORKERS();
            //FReceiveStoreId = new SAL_RETURNSTOCK_BD_Storeomer();
            //FSettleStoreId = new SAL_RETURNSTOCK_BD_Storeomer();
            //FReceiveCusContact = new SAL_RETURNSTOCK_BD_StoreContact();
            //FPayStoreId = new SAL_RETURNSTOCK_BD_Storeomer();
            //FOwnerIdHead = new SAL_RETURNSTOCK_BOS_ItemClass();           
            SubHeadEntity = sSubHeadEntity;
            FEntity = FEntitys;
        }
        [Description("订单ID")]
        public long FID;
        [Description("订单类型")]
        public SAL_RETURNSTOCK_BOS_BillType FBillTypeID;
        [Description("订单单号")]
        public string FBillNo="";
        public string FDate=DateTime.Now.ToShortDateString();
        public SAL_RETURNSTOCK_ORG_Organizations FSaleOrgId;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_Department FSaledeptid;
        public SAL_RETURNSTOCK_BD_Storeomer FRetcustId;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BOS_ASSISTANTDATA_SELECT FReturnReason;
        //public SAL_RETURNSTOCK_BD_CUSTCONTACTION FHeadLocId;
        //public SAL_RETURNSTOCK_BD_OperatorGroup FSaleGroupId;
        //public SAL_RETURNSTOCK_IOS_TransferBizType FTransferBizType;
        //public SAL_RETURNSTOCK_ORG_Organizations FCorrespondOrgId;     
        //public SAL_RETURNSTOCK_BD_Saler FSalesManId;
        public SAL_RETURNSTOCK_ORG_Organizations FStockOrgId;
        //public SAL_RETURNSTOCK_BD_Department FStockDeptId;
        //public SAL_RETURNSTOCK_BD_OperatorGroup FStockerGroupId;
        //public SAL_RETURNSTOCK_BD_WAREHOUSEWORKERS FStockerId;
        //public string FHeadNote="";
        //public SAL_RETURNSTOCK_BD_Storeomer FReceiveStoreId;
        //public string FReceiveAddress="";
        //public SAL_RETURNSTOCK_BD_Storeomer FSettleStoreId;
        //public SAL_RETURNSTOCK_BD_StoreContact FReceiveCusContact;
        //public SAL_RETURNSTOCK_BD_Storeomer FPayStoreId;
        //public string FOwnerTypeIdHead="";
        //public SAL_RETURNSTOCK_BOS_ItemClass FOwnerIdHead;
        //public string FScanBox="";
        //public string FCDateOffsetUnit="";
        //public long FCDateOffsetValue=0;
        //public string F_PAEZ_Combo = "";
        public string F_PAEZ_Text = "";
        //public string F_PAEZ_Remarks = "";
        //public string F_PAEZ_Text1 = "";
        public string F_PAEZ_Text2 = "";

        public string F_PAEZ_REMARKS = "备注";
        public SAL_RETURNSTOCK__SubHeadEntity SubHeadEntity;
        public SAL_RETURNSTOCK__FEntity[] FEntity;
        [JsonIgnore]
        public string FApproveDate;
        [JsonIgnore]
        public SAL_RETURNSTOCK_SEC_User FApproverId;
        [JsonIgnore]
        public string FBussinessType;
        [JsonIgnore]
        public string FCancelDate;
        [JsonIgnore]
        public string FCancelStatus;
        [JsonIgnore]
        public SAL_RETURNSTOCK_SEC_User FCancellerId;
        [JsonIgnore]
        public string FCreateDate;
        [JsonIgnore]
        public SAL_RETURNSTOCK_SEC_User FCreatorId;
        [JsonIgnore]
        public string FCreditCheckResult;
        [JsonIgnore]
        public string FDocumentStatus;
        [JsonIgnore]
        public bool FIsInterLegalPerson;
        [JsonIgnore]
        public SAL_RETURNSTOCK_SEC_User FModifierId;
        [JsonIgnore]
        public string FModifyDate;

                   
    }

    public class SAL_RETURNSTOCK__SubHeadEntity
    {
        /// <summary>
        /// 退货订单表头信息
        /// </summary>
        /// <param name="sFSettleCurrId">结算币别</param>
        /// <param name="sFSettleOrgId">结算组织</param>
        public SAL_RETURNSTOCK__SubHeadEntity(string sFSettleCurrId,string sFSettleOrgId)
        {
            FSettleCurrId = new SAL_RETURNSTOCK_BD_Currency();
            FSettleCurrId.FNumber = sFSettleCurrId;
            FSettleOrgId = new SAL_RETURNSTOCK_ORG_Organizations();
            FSettleOrgId.FNumber = sFSettleOrgId;
            //FSettleTypeId = new SAL_RETURNSTOCK_BD_SETTLETYPE();
            //FChageCondition = new SAL_RETURNSTOCK_BD_RecCondition();
            //FPriceListId = new SAL_RETURNSTOCK_BD_SAL_PriceList();
            //FDiscountListId = new SAL_RETURNSTOCK_BD_SAL_DiscountList();
            //FLocalCurrId = new SAL_RETURNSTOCK_BD_Currency();
            //FExchangeTypeId = new SAL_RETURNSTOCK_BD_RateType();
        }
        public SAL_RETURNSTOCK_BD_Currency FSettleCurrId;
        public SAL_RETURNSTOCK_ORG_Organizations FSettleOrgId;
        //public SAL_RETURNSTOCK_BD_SETTLETYPE FSettleTypeId;
        //public SAL_RETURNSTOCK_BD_RecCondition FChageCondition;
        //public SAL_RETURNSTOCK_BD_SAL_PriceList FPriceListId;
        //public SAL_RETURNSTOCK_BD_SAL_DiscountList FDiscountListId;
        //public SAL_RETURNSTOCK_BD_Currency FLocalCurrId;
        public SAL_RETURNSTOCK_BD_RateType FExchangeTypeId;
        public decimal FExchangeRate = 1;

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
        public bool FISGENFORIOS;
        [JsonIgnore]
        public bool FIsIncludedTax;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_Supplier FOwnerSupplierID;
        [JsonIgnore]
        public long FPrecision;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_Storeomer FSETTLEStoreomerID;
    }

    public class SAL_RETURNSTOCK_BD_SETTLETYPE
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_SAL_PriceList
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_Supplier
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_Currency
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_RateType
    {
        public string FNumber= "HLTX01_SYS";
    }

    public class SAL_RETURNSTOCK_BD_SAL_DiscountList
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_RecCondition
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK__FEntity
    {
        /// <summary>
        /// 退货明细
        /// </summary>
        /// <param name="sFMaterialId">物料代码</param>
        /// <param name="sFOwnerId">货主</param>
        /// <param name="sFDeliveryDate">退货日期</param>
        /// <param name="sFReturnType">退货类型</param>
        /// <param name="sFUnitID">物料计量单位代码</param>
        public SAL_RETURNSTOCK__FEntity(string sFMaterialId,string sFOwnerId,string sFDeliveryDate,string sFReturnType,string sFUnitID, string FStockNumber)
        {
            //FMapId = new SAL_RETURNSTOCK_Sal_StoreMatMappingView();
            FMaterialId = new SAL_RETURNSTOCK_BD_MATERIAL();
            FMaterialId.FNumber = sFMaterialId;
            //FAuxpropId = new BD_FLEXSITEMDETAILV_FAuxpropId();
            FUnitID = new SAL_RETURNSTOCK_BD_UNIT();
            FUnitID.FNumber = sFUnitID;
            //FTaxCombination = new SAL_RETURNSTOCK_BD_TAXMIX();
            //FBOMId = new SAL_RETURNSTOCK_ENG_BOM();
            FReturnType = new SAL_RETURNSTOCK_BOS_ASSISTANTDATA_SELECT();
            FReturnType.FNumber = sFReturnType;
            //FOwnerId = new SAL_RETURNSTOCK_BOS_ItemClass();
            //FOwnerId.FNumber = sFOwnerId;
            FStockId = new SAL_RETURNSTOCK_BD_STOCK();
            FStockId.FNumber = FStockNumber;
            //FStocklocId = new BD_FLEXVALUESDETAIL_FStocklocId();
            FStockstatusId = new SAL_RETURNSTOCK_BD_StockStatus();
            //FExtAuxUnitId = new SAL_RETURNSTOCK_BD_UNIT();
            //FLot = new SAL_RETURNSTOCK_BD_BatchMainFile();
            //FSalUnitID = new SAL_RETURNSTOCK_BD_UNIT();
            //FEOwnerSupplierId = new SAL_RETURNSTOCK_BD_Supplier();
            //FESettleStoreomerId = new SAL_RETURNSTOCK_BD_Storeomer();
            //FPriceListEntry = new SAL_RETURNSTOCK_BD_SAL_PriceList();
            //List<SAL_RETURNSTOCK__FTaxDetailSubEntity> lts = new List<SAL_RETURNSTOCK__FTaxDetailSubEntity>();
            //SAL_RETURNSTOCK__FTaxDetailSubEntity ts = new SAL_RETURNSTOCK__FTaxDetailSubEntity();
            //lts.Add(ts);
            //FTaxDetailSubEntity = lts.ToArray();
            //List<SAL_RETURNSTOCK__FSerialSubEntity> lss = new List<SAL_RETURNSTOCK__FSerialSubEntity>();
            //SAL_RETURNSTOCK__FSerialSubEntity fs = new SAL_RETURNSTOCK__FSerialSubEntity();
            //lss.Add(fs);
            //FSerialSubEntity = lss.ToArray();
            //FDeliveryDate = sFDeliveryDate;
        }
        //public long FENTRYID=0;
        //public SAL_RETURNSTOCK_Sal_StoreMatMappingView FMapId;
        public string F_PAEZ_Text4 = "";
        public SAL_RETURNSTOCK_BD_MATERIAL FMaterialId;
        //public BD_FLEXSITEMDETAILV_FAuxpropId FAuxpropId;
        public SAL_RETURNSTOCK_BD_UNIT FUnitID;
        public decimal FInventoryQty = 0;
        public decimal FRealQty = 0;
        public decimal FPrice = 0;
        public decimal FTaxPrice = 0;
        public string FIsFree = "false";
        //public SAL_RETURNSTOCK_BD_TAXMIX FTaxCombination;
        //public decimal FEntryTaxRate=0;
        //public SAL_RETURNSTOCK_ENG_BOM FBOMId;
        public SAL_RETURNSTOCK_BOS_ASSISTANTDATA_SELECT FReturnType;
        //public string FOwnerTypeId="";
        //public SAL_RETURNSTOCK_BOS_ItemClass FOwnerId;
        //public string FProduceDate=DateTime.Now.ToShortDateString();
        //public string FExpiryDate ="1900-01-01";
        public SAL_RETURNSTOCK_BD_STOCK FStockId;
        //public BD_FLEXVALUESDETAIL_FStocklocId FStocklocId;
        public SAL_RETURNSTOCK_BD_StockStatus FStockstatusId;
        //public string FDeliveryDate = "1900-01-01";
        //public string FMtoNo = "";
        //public string FNote = "";
        //public decimal FDiscountRate = 0;
        //public decimal FAuxUnitQty = 0;
        //public SAL_RETURNSTOCK_BD_UNIT FExtAuxUnitId;
        //public decimal FExtAuxUnitQty=0;
        //public decimal FSalCostPrice=0;
        //public string FISCONSUMESUM="";
        //public SAL_RETURNSTOCK_BD_BatchMainFile FLot;
        //public SAL_RETURNSTOCK_BD_UNIT FSalUnitID;
        //public decimal FSalUnitQty=0;
        //public decimal FSalBaseQty = 0;
        //public decimal FPriceBaseQty = 0;
        //public string FProjectNo="";
        //public string FQualifyType="";
        //public SAL_RETURNSTOCK_BD_Supplier FEOwnerSupplierId;
        //public bool FIsOverLegalOrg=false;
        //public SAL_RETURNSTOCK_BD_Storeomer FESettleStoreomerId;
        //public long FSOEntryId=0;
        //public SAL_RETURNSTOCK_BD_SAL_PriceList FPriceListEntry;
        //public decimal FARNOTJOINQTY=0;
        //public bool FIsReturnCheck = false;
        //public SAL_RETURNSTOCK__FTaxDetailSubEntity[] FTaxDetailSubEntity;
        //public SAL_RETURNSTOCK__FSerialSubEntity[] FSerialSubEntity;
        [JsonIgnore]
        public decimal FARAMOUNT;
        [JsonIgnore]
        public decimal FARJOINAMOUNT;
        [JsonIgnore]
        public decimal FAllAmount;
        [JsonIgnore]
        public decimal FAllAmount_LC;
        public decimal FAmount;
        [JsonIgnore]
        public decimal FAmount_LC;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_UNIT FAuxUnitId;

        public decimal FBASEARQTY;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BOS_BFVersion FBFLowId;
        [JsonIgnore]
        public decimal FBaseARJoinQty;
        [JsonIgnore]
        public decimal FBaseInvoicedQty;
        [JsonIgnore]
        public decimal FBaseSumInvoicedQty;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_UNIT FBaseunitId;
        [JsonIgnore]
        public decimal FBaseunitQty;
        [JsonIgnore]
        public decimal FBefDisAllAmt;
        [JsonIgnore]
        public decimal FBefDisAmt;
        [JsonIgnore]
        public decimal FCostAmount_LC;
        [JsonIgnore]
        public decimal FCostPrice;
        [JsonIgnore]
        public decimal FDiscount;
        [JsonIgnore]
        public decimal FEntryCostAmount;
        [JsonIgnore]
        public decimal FEntryTaxAmount;
        [JsonIgnore]
        public string FExpPeriod;
        [JsonIgnore]
        public string FExpUnit;
        [JsonIgnore]
        public decimal FInvoicedQty;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BOS_ItemClass FKeeperId;
        [JsonIgnore]
        public string FKeeperTypeId;
        [JsonIgnore]
        public decimal FLimitDownPrice;
        [JsonIgnore]
        public string FMapName;
        [JsonIgnore]
        public string FMaterialModel;
        [JsonIgnore]
        public string FMaterialName;
        [JsonIgnore]
        public string FMaterialType;
        [JsonIgnore]
        public decimal FMustqty;
        [JsonIgnore]
        public string FOrderNo;
        [JsonIgnore]
        public decimal FPriceCoefficient;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_UNIT FPriceUnitId;
        public decimal FPriceUnitQty;
        [JsonIgnore]
        public bool FRefuseFlag;
        [JsonIgnore]
        public decimal FSNQty;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_UNIT FSNUnitID;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BOS_BillType FSOBILLTYPEID;
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_UNIT FSRCBIZUNITID;
        [JsonIgnore]
        public decimal FSalBaseARJoinQty;
        [JsonIgnore]
        public decimal FSalBaseNum;
        [JsonIgnore]
        public string FSrcBillNo;
        [JsonIgnore]
        public string FSrcBillTypeID;
        [JsonIgnore]
        public decimal FStockBaseARJoinQty;
        [JsonIgnore]
        public decimal FStockBaseDen;
        [JsonIgnore]
        public bool FStockFlag;
        [JsonIgnore]
        public decimal FSumInvoicedAmt;
        [JsonIgnore]
        public decimal FSumInvoicedQty;
        [JsonIgnore]
        public decimal FSumRecievedAmt;
        [JsonIgnore]
        public decimal FSysPrice;
        [JsonIgnore]
        public decimal FTaxAmount_LC;
        [JsonIgnore]
        public decimal FTaxNetPrice;
        [JsonIgnore]
        public SAL_RETURNSTOCK__FEntity_Link[] SAL_RETURNSTOCK__FEntity_Link;
    }

    public class SAL_RETURNSTOCK__FTaxDetailSubEntity
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

    public class SAL_RETURNSTOCK__FSerialSubEntity
    {
        public long FDetailID=0;
        public string FSerialNo="";
        public string FSerialNote="";
        [JsonIgnore]
        public SAL_RETURNSTOCK_BD_SerialMainFile FSerialId;
    }

    public class SAL_RETURNSTOCK_BD_SerialMainFile
    {
        public string FNumber="";
        public string FSERIALID;
    }

    public class SAL_RETURNSTOCK__FEntity_Link
    {
        public decimal FEntity_Link_FAuxUnitQty;
        public decimal FEntity_Link_FAuxUnitQtyOld;
        public decimal FEntity_Link_FBaseunitQty;
        public decimal FEntity_Link_FBaseunitQtyOld;
        public string FEntity_Link_FFlowId;
        public long FEntity_Link_FFlowLineId;
        public decimal FEntity_Link_FLnk1Amount;
        public string FEntity_Link_FLnk1SState;
        public string FEntity_Link_FLnk1TrackerId;
        public decimal FEntity_Link_FLnk2Amount;
        public string FEntity_Link_FLnk2SState;
        public string FEntity_Link_FLnk2TrackerId;
        public decimal FEntity_Link_FLnkAmount;
        public string FEntity_Link_FLnkSState;
        public string FEntity_Link_FLnkTrackerId;
        public string FEntity_Link_FRuleId;
        public string FEntity_Link_FSBillId;
        public string FEntity_Link_FSId;
        public long FEntity_Link_FSTableId;
        public string FEntity_Link_FSTableName;
        public decimal FEntity_Link_FSalBaseQty;
        public decimal FEntity_Link_FSalBaseQtyOld;
        public long FLinkId;
    }

    public class SAL_RETURNSTOCK_BD_TAXMIX
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_StockStatus
    {
        public string FNumber= "KCZT01_SYS";
    }

    public class BD_FLEXVALUESDETAIL_FStocklocId
    {
        public string FSTOCKLOCID__FF100001="";
        public string FSTOCKLOCID__FOPCODE="";
    }

    public class SAL_RETURNSTOCK_BD_STOCK
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_MATERIAL
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_Sal_StoreMatMappingView
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_BatchMainFile
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_ENG_BOM
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BOS_BFVersion
    {
        public long FId;
        public string FName;
    }

    public class BD_FLEXSITEMDETAILV_FAuxpropId
    {
        public string FAUXPROPID__FOPCODE = "";
        public string FAUXPROPID__FF100001="";
        public string FAUXPROPID__FF100004 = "";
        public string FAUXPROPID__FF100002 = "";            
    }

    public class SAL_RETURNSTOCK_BD_UNIT
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_IOS_TransferBizType
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_WAREHOUSEWORKERS
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_Saler
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_Department
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_OperatorGroup
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BOS_ASSISTANTDATA_SELECT
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_StoreContact
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BD_Storeomer
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BOS_ItemClass
    {
        [JsonIgnore]
        public long FItemID;//不显示
        public string FNumber="";
        [JsonIgnore]
        public string FNAME;//不显示
    }

    public class SAL_RETURNSTOCK_BD_CUSTCONTACTION
    {
        public string FNUMBER="";
    }

    public class SAL_RETURNSTOCK_ORG_Organizations
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_BOS_BillType
    {
        public string FNumber="";
    }

    public class SAL_RETURNSTOCK_SEC_User
    {
        public string FName;
        public string FUserAccount;
        public long FUserID;
    }
}
