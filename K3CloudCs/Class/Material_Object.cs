using System;
using Newtonsoft.Json;
namespace K3CloudCs
{
    public class Material_OBJECT
    {
        public Material_OBJECT(Material[] sModel)
        {
            Model = sModel;
        }
        public bool NumberSearch = true;//：是否使用Number来搜索基础资料，默认为True（非必录）
        public bool ValidateFlag = true;//：是否验证标志，布尔类型,默认为True（非必录）
        public bool IsDeleteEntry = true;//：是否删除分录，默认True删除（非必录）：
        public string[] NeedUpDateFields = { };//：需要保存的字段,格式["fieldkey1", "fieldkey2", "entitykey1",...]，数组类型(非必录)
        public string[] NeedReturnFields = { };//：需要返回的结果字段,格式["fieldkey", "entitykey.fieldkey",...]（非必录）：
        public string SubSystemId = "";//：菜单所在子系统Id（非必录）：
        public Material[] Model;//：表单实体数据（必录）
        public int BatchCount = 0;//：批量保存数量，整形（非必录）
    }
    public class Material_Obj
    {
        /// <summary>
        /// 物料对象
        /// </summary>
        /// <param name="sModel">物料信息</param>
        public Material_Obj(Material sModel)
        {
            Model = sModel;
        }
        public string Creator="";
        public string[] NeedUpDateFields= {};
        public string[] NeedReturnFields = {};
        public bool IsDeleteEntry = true;
        public int SubSystemId;
        public Material Model;
    }
    public class Material
    {
        /// <summary>
        /// 物料信息
        /// </summary>
        /// <param name="sFName">物料名称</param>
        /// <param name="sFNumber">物料代码</param>
        /// <param name="sFUseOrgId">使用组织</param>
        /// <param name="sFCreateOrgId">创建组织</param>
        /// <param name="sSubHeadEntity">表体</param>
        /// <param name="sSubHeadEntity1">表体1</param>
        /// <param name="sSubHeadEntity2">表体2</param>
        /// <param name="sSubHeadEntity3">表体3</param>
        /// <param name="sSubHeadEntity4">表体4</param>
        /// <param name="sSubHeadEntity5">表体5</param>
        /// <param name="sFEntityInvPty"></param>
        public Material(string sFName,string sFNumber, BD_MATERIAL_ORG_Organizations sFUseOrgId, BD_MATERIAL_ORG_Organizations sFCreateOrgId, BD_MATERIAL__SubHeadEntity sSubHeadEntity, BD_MATERIAL__SubHeadEntity1 sSubHeadEntity1, BD_MATERIAL__SubHeadEntity2 sSubHeadEntity2, BD_MATERIAL__SubHeadEntity3 sSubHeadEntity3, BD_MATERIAL__SubHeadEntity4 sSubHeadEntity4, BD_MATERIAL__SubHeadEntity5 sSubHeadEntity5, BD_MATERIAL__FEntityInvPty[] sFEntityInvPty)
        {
            FName = sFName;
            FNumber = sFNumber;
            FCreateOrgId = sFCreateOrgId;
            FUseOrgId = sFUseOrgId;
            FMaterialGroup = new BD_MATERIAL_BOS_FORMGROUP();
            SubHeadEntity = sSubHeadEntity;
            SubHeadEntity1 = sSubHeadEntity1;
            SubHeadEntity2 = sSubHeadEntity2;
            SubHeadEntity3 = sSubHeadEntity3;
            SubHeadEntity4 = sSubHeadEntity4;
            SubHeadEntity5 = sSubHeadEntity5;
            SubHeadEntity7 = new BD_MATERIAL__SubHeadEntity7();
            SubHeadEntity6 = new BD_MATERIAL__SubHeadEntity6();
            FEntityAuxPty = new BD_MATERIAL__FEntityAuxPty[] { new BD_MATERIAL__FEntityAuxPty() };
            FEntityInvPty = sFEntityInvPty;
        }
        public long FMATERIALID;
        public BD_MATERIAL_ORG_Organizations FCreateOrgId;
        public BD_MATERIAL_ORG_Organizations FUseOrgId;
        public string FNumber="";
        public string FName="";
        public string FSpecification="";
        public string FMnemonicCode="";
        public string FOldNumber="";
        public string FDescription="";
        public BD_MATERIAL_BOS_FORMGROUP FMaterialGroup;
        public string FImgStorageType="";
        public bool FIsSalseByNet = false;
        public BD_MATERIAL__SubHeadEntity SubHeadEntity;
        public BD_MATERIAL__SubHeadEntity1 SubHeadEntity1;
        public BD_MATERIAL__SubHeadEntity2 SubHeadEntity2;
        public BD_MATERIAL__SubHeadEntity3 SubHeadEntity3;
        public BD_MATERIAL__SubHeadEntity4 SubHeadEntity4;
        public BD_MATERIAL__SubHeadEntity5 SubHeadEntity5;
        public BD_MATERIAL__SubHeadEntity7 SubHeadEntity7;
        public BD_MATERIAL__SubHeadEntity6 SubHeadEntity6;
        public BD_MATERIAL__FEntityAuxPty[] FEntityAuxPty;
        public BD_MATERIAL__FEntityInvPty[] FEntityInvPty;
        [JsonIgnore]
        public DateTime FApproveDate;
        [JsonIgnore]
        public BD_MATERIAL_SEC_User FApproverId;
        [JsonIgnore]
        public string FBaseProperty;
        [JsonIgnore]
        public DateTime FCreateDate;
        [JsonIgnore]
        public BD_MATERIAL_SEC_User FCreatorId;
        [JsonIgnore]
        public string FDocumentStatus;
        [JsonIgnore]
        public DateTime FForbidDate;
        [JsonIgnore]
        public string FForbidStatus;
        [JsonIgnore]
        public BD_MATERIAL_SEC_User FForbidderId;
        [JsonIgnore]
        public byte[] FImage1;
        [JsonIgnore]
        public string FImageFileServer;
        [JsonIgnore]
        public string FIsImgDataBase;
        [JsonIgnore]
        public string FIsImgFileServer;
        [JsonIgnore]
        public bool FIsValidate;
        [JsonIgnore]
        public string FMaterialSRC;
        [JsonIgnore]
        public BD_MATERIAL_SEC_User FModifierId;
        [JsonIgnore]
        public DateTime FModifyDate;
        [JsonIgnore]
        public string FPLMMaterialId;
    }
    public class BD_MATERIAL_ORG_Organizations
    {
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
        [JsonIgnore]
        public long FOrgID;//不显示
    }
    public class BD_MATERIAL_BOS_FORMGROUP
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FName;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL__SubHeadEntity
    {
        /// <summary>
        /// 表体信息
        /// </summary>
        /// <param name="sFErpClsID">物料属性</param>
        /// <param name="sFCategoryID">存货类别</param>
        /// <param name="sFBaseUnitId">基本单位</param>
        public BD_MATERIAL__SubHeadEntity(string sFErpClsID, BD_MATERIAL_BD_MATERIALCATEGORY sFCategoryID, BD_MATERIAL_BD_UNIT sFBaseUnitId)
        {
            FErpClsID = sFErpClsID;
            FCategoryID = sFCategoryID;
            FTaxType = new BD_MATERIAL_BOS_ASSISTANTDATA_SELECT();
            FTaxRateId = new BD_MATERIAL_BD_TaxRate();
            FBaseUnitId = sFBaseUnitId;
            FWEIGHTUNITID = new BD_MATERIAL_BD_UNIT();
            FVOLUMEUNITID = new BD_MATERIAL_BD_UNIT();
        }
        public string FBARCODE="";
        public string FErpClsID = "";
        public string FCONFIGTYPE = "";
        public BD_MATERIAL_BD_MATERIALCATEGORY FCategoryID;
        public BD_MATERIAL_BOS_ASSISTANTDATA_SELECT FTaxType;
        public BD_MATERIAL_BD_TaxRate FTaxRateId;
        public BD_MATERIAL_BD_UNIT FBaseUnitId;
        public bool FIsPurchase = false;
        public bool FIsInventory = false;
        public bool FIsSubContract = false;
        public bool FIsSale = false;
        public bool FIsProduce = false;
        public bool FIsAsset = false;
        public decimal FGROSSWEIGHT = 0;
        public decimal FNETWEIGHT = 0;
        public BD_MATERIAL_BD_UNIT FWEIGHTUNITID;
        public decimal FLENGTH = 0;
        public decimal FWIDTH = 0;
        public decimal FHEIGHT=0;
        public decimal FVOLUME = 0;        
        public BD_MATERIAL_BD_UNIT FVOLUMEUNITID;        
        [JsonIgnore]
        public bool FIsRealTimeAccout;//不显示
        [JsonIgnore]
        public BD_FLEXVALUESDETAIL_FTypeID FTypeID;//不显示
    }
    public class BD_MATERIAL__SubHeadEntity1
    {
        /// <summary>
        /// 表体1信息
        /// </summary>
        /// <param name="sFStoreUnitID">库存单位</param>
        /// <param name="sFSNGenerateTime">序列号生产时机</param>
        /// <param name="sFSNManageType">业务范围</param>
        /// <param name="sFUnitConvertDir">换算方向</param>
        public BD_MATERIAL__SubHeadEntity1(BD_MATERIAL_BD_UNIT sFStoreUnitID,string sFSNGenerateTime,string sFSNManageType,string sFUnitConvertDir)
        {
            FSNGenerateTime = sFSNGenerateTime;
            FStoreUnitID = sFStoreUnitID;
            FSNManageType = sFSNManageType;
            FUnitConvertDir = sFUnitConvertDir;
            FAuxUnitID = new BD_MATERIAL_BD_UNIT();
            FStockId = new BD_MATERIAL_BD_STOCK();
            FStockPlaceId = new BD_FLEXVALUESDETAIL_FStockPlaceId();
            FBatchRuleID = new BD_MATERIAL_BD_LotCodeRule();
            FCurrencyId = new BD_MATERIAL_BD_Currency();
            FSNCodeRule = new BD_MATERIAL_BD_LotCodeRule();
            FSNUnit = new BD_MATERIAL_BD_UNIT();
        }
        public BD_MATERIAL_BD_UNIT FStoreUnitID;
        public BD_MATERIAL_BD_UNIT FAuxUnitID;
        public string FUnitConvertDir = "";
        public BD_MATERIAL_BD_STOCK FStockId;
        public BD_FLEXVALUESDETAIL_FStockPlaceId FStockPlaceId;
        public bool FIsLockStock = false;
        public bool FIsCycleCounting = false;
        public string FCountCycle = "";
        public long FCountDay = 0;
        public bool FIsMustCounting = false;
        public bool FIsBatchManage = false;
        public BD_MATERIAL_BD_LotCodeRule FBatchRuleID;
        public bool FIsKFPeriod = false;
        public bool FIsExpParToFlot = false;
        public string FExpUnit="";
        public long FExpPeriod = 0;
        public long FOnlineLife = 0;
        public decimal FRefCost = 0;
        public BD_MATERIAL_BD_Currency FCurrencyId;
        public bool FIsEnableMinStock = false;
        public bool FIsEnableMaxStock = false;
        public bool FIsEnableSafeStock = false;
        public bool FIsEnableReOrder = false;
        public decimal FMinStock = 0;
        public decimal FSafeStock = 0;
        public decimal FReOrderGood = 0;
        public decimal FEconReOrderQty = 0;
        public decimal FMaxStock = 0;
        public bool FIsSNManage = false;
        public bool FIsSNPRDTracy = false;
        public BD_MATERIAL_BD_LotCodeRule FSNCodeRule;
        public BD_MATERIAL_BD_UNIT FSNUnit;
        public string FSNManageType="";
        public string FSNGenerateTime="";
        [JsonIgnore]
        public decimal FStoreURNom;//不显示
        [JsonIgnore]
        public decimal FStoreURNum;//不显示
    }
    public class BD_MATERIAL__SubHeadEntity2
    {
        /// <summary>
        /// 表体2信息
        /// </summary>
        /// <param name="sFOutLmtUnit">超发控制单位</param>
        /// <param name="sFSaleUnitId">销售单位</param>
        /// <param name="sFSalePriceUnitId">销售计价单位</param>
        public BD_MATERIAL__SubHeadEntity2(string sFOutLmtUnit, BD_MATERIAL_BD_UNIT sFSaleUnitId, BD_MATERIAL_BD_UNIT sFSalePriceUnitId)
        {
            FOutLmtUnit = sFOutLmtUnit;
            FSaleUnitId = sFSaleUnitId;
            FSalePriceUnitId = sFSalePriceUnitId;
            FTaxCategoryCodeId = new BD_MATERIAL_IV_GTTAXCODE();
        }
        public BD_MATERIAL_BD_UNIT FSaleUnitId;
        public BD_MATERIAL_BD_UNIT FSalePriceUnitId;
        public decimal FOrderQty = 0;
        public decimal FMinQty = 0;
        public decimal FMaxQty = 0;
        public decimal FOutStockLmtH = 0;
        public decimal FOutStockLmtL = 0;
        public decimal FAgentSalReduceRate = 0;
        public bool FIsATPCheck = false;
        public bool FIsReturnPart = false;
        public bool FIsInvoice = false;
        public bool FIsReturn = false;
        public bool FAllowPublish = false;
        public bool FISAFTERSALE = false;
        public bool FISPRODUCTFILES = false;
        public bool FISWARRANTED = false;
        public long FWARRANTY = 0;
        public string FWARRANTYUNITID = "";
        public string FOutLmtUnit = "";
        public BD_MATERIAL_IV_GTTAXCODE FTaxCategoryCodeId;
        [JsonIgnore]
        public decimal FSalePriceURNom;//不显示
        [JsonIgnore]
        public decimal FSalePriceURNum;//不显示
        [JsonIgnore]
        public decimal FSaleURNom;//不显示
        [JsonIgnore]
        public decimal FSaleURNum;//不显示
    }
    public class BD_MATERIAL__SubHeadEntity3
    {
        /// <summary>
        /// 表体3信息
        /// </summary>
        /// <param name="sFQuotaType">配额方式</param>
        /// <param name="sFPurchasePriceUnitId">采购计价单位</param>
        /// <param name="sFPurchaseUnitId">采购单位</param>
        public BD_MATERIAL__SubHeadEntity3(string sFQuotaType, BD_MATERIAL_BD_UNIT sFPurchasePriceUnitId, BD_MATERIAL_BD_UNIT sFPurchaseUnitId)
        {
            FQuotaType = sFQuotaType;
            FPurchaseUnitId = sFPurchaseUnitId;
            FPurchasePriceUnitId = sFPurchasePriceUnitId;
            FPurchaseOrgId = new BD_MATERIAL_ORG_Organizations();
            FPurchaseGroupId = new BD_MATERIAL_BD_OperatorGroup();
            FPurchaserId = new BD_MATERIAL_BD_BUYER();
            FDefaultVendor = new BD_MATERIAL_BD_Supplier();
            FChargeID = new BD_MATERIAL_BD_Expense();
            FDefBarCodeRuleId = new BD_MATERIAL_BD_BarCodeRule();
        }
        public decimal FBaseMinSplitQty = 0;
        public BD_MATERIAL_BD_UNIT FPurchaseUnitId;
        public BD_MATERIAL_BD_UNIT FPurchasePriceUnitId;
        public BD_MATERIAL_ORG_Organizations FPurchaseOrgId;
        public BD_MATERIAL_BD_OperatorGroup FPurchaseGroupId;
        public BD_MATERIAL_BD_BUYER FPurchaserId;
        public BD_MATERIAL_BD_Supplier FDefaultVendor;
        public BD_MATERIAL_BD_Expense FChargeID;
        public bool FIsQuota = false;
        public string FQuotaType="";
        public decimal FMinSplitQty = 0;
        public bool FIsVmiBusiness = false;
        public bool FEnableSL = false;
        public bool FIsPR = false;
        public bool FIsReturnMaterial = false;
        public bool FIsSourceControl = false;
        public decimal FReceiveMaxScale = 0;
        public decimal FReceiveMinScale = 0;
        public long FReceiveAdvanceDays = 0;
        public long FReceiveDelayDays = 0;
        public decimal FAgentPurPlusRate = 0;
        public BD_MATERIAL_BD_BarCodeRule FDefBarCodeRuleId;
        public long FPrintCount = 0;
        public long FMinPackCount = 0;
        [JsonIgnore]
        public bool FIsVendorQualification = false;//不显示
        [JsonIgnore]
        public decimal FPurPriceURNom;//不显示
        [JsonIgnore]
        public decimal FPurPriceURNum;//不显示
        [JsonIgnore]
        public decimal FPurURNom;//不显示
        [JsonIgnore]
        public decimal FPurURNum;//不显示
    }
    public class BD_MATERIAL__SubHeadEntity4
    {
        /// <summary>
        /// 表体4信息
        /// </summary>
        /// <param name="sFReserveType">预留类型</param>
        /// <param name="sFPlanOffsetTimeType">时间单位</param>
        /// <param name="sFVarLeadTimeType">变动提前期单位</param>
        /// <param name="sFFixLeadTimeType">固定提前期单位</param>
        /// <param name="sFOrderIntervalTimeType">订货间隔期单位</param>
        /// <param name="sFCheckLeadTimeType">检验提前期单位</param>
        /// <param name="sFOrderPolicy">订货策略</param>
        /// <param name="sFPlanningStrategy">计划策略</param>
        public BD_MATERIAL__SubHeadEntity4(string sFReserveType, string sFPlanOffsetTimeType,string sFVarLeadTimeType,string sFFixLeadTimeType,string sFOrderIntervalTimeType,string sFCheckLeadTimeType,string sFOrderPolicy,string sFPlanningStrategy)
        {
            FPlanOffsetTimeType = sFPlanOffsetTimeType;
            FReserveType = sFReserveType;
            FVarLeadTimeType = sFVarLeadTimeType;
            FFixLeadTimeType = sFFixLeadTimeType;
            FOrderIntervalTimeType = sFOrderIntervalTimeType;
            FCheckLeadTimeType = sFCheckLeadTimeType;
            FOrderPolicy = sFOrderPolicy;
            FPlanningStrategy = sFPlanningStrategy;
            FMfgPolicyId = new BD_MATERIAL_PLN_MANUFACTUREPOLICY();
            FPlanWorkshop = new BD_MATERIAL_PLN_PLANAREA();
            FPlanGroupId = new BD_MATERIAL_BD_OperatorGroup();
            FPlanerID = new BD_MATERIAL_BD_PLANNER();
            FSupplySourceId = new BD_MATERIAL_PLN_SUPPLYMANAGER();
            FTimeFactorId = new BD_MATERIAL_PLN_PRIORITYCALCULATION();
            FQtyFactorId = new BD_MATERIAL_PLN_PRIORITYCALCULATION();
        }
        public string FPlanMode = "";
        public decimal FBaseVarLeadTimeLotSize = 0;
        public string FPlanningStrategy="";
        public BD_MATERIAL_PLN_MANUFACTUREPOLICY FMfgPolicyId;
        public string FOrderPolicy="";
        public BD_MATERIAL_PLN_PLANAREA FPlanWorkshop;
        public long FFixLeadTime = 0;
        public string FFixLeadTimeType = "";
        public long FVarLeadTime = 0;
        public string FVarLeadTimeType = "";
        public long FCheckLeadTime = 0;
        public string FCheckLeadTimeType = "";
        public string FOrderIntervalTimeType = "";
        public long FOrderIntervalTime = 0;
        public decimal FMaxPOQty = 0;
        public decimal FMinPOQty = 0;
        public decimal FIncreaseQty = 0;
        public decimal FEOQ = 1;
        public decimal FVarLeadTimeLotSize = 1;
        public long FPlanIntervalsDays = 0;
        public decimal FPlanBatchSplitQty = 0;
        public long FRequestTimeZone = 0;
        public long FPlanTimeZone = 0;
        public BD_MATERIAL_BD_OperatorGroup FPlanGroupId;
        public BD_MATERIAL_BD_PLANNER FPlanerID;
        public long FCanLeadDays = 0;
        public bool FIsMrpComReq = false;
        public long FLeadExtendDay = 0;
        public string FReserveType = "";
        public decimal FPlanSafeStockQty = 0;
        public bool FAllowPartAhead = false;        
        public long FCanDelayDays = 0;
        public long FDelayExtendDay = 0;
        public bool FAllowPartDelay = false;
        public string FPlanOffsetTimeType = "";
        public long FPlanOffsetTime = 0;
        public BD_MATERIAL_PLN_SUPPLYMANAGER FSupplySourceId;
        public BD_MATERIAL_PLN_PRIORITYCALCULATION FTimeFactorId;
        public BD_MATERIAL_PLN_PRIORITYCALCULATION FQtyFactorId;
    }
    public class BD_MATERIAL__SubHeadEntity5
    {
        /// <summary>
        /// 表体5信息
        /// </summary>
        /// <param name="sFIssueType">发料方式</param>
        /// <param name="sFOverControlMode">超发控制方式</param>
        /// <param name="sFMinIssueUnitId">最小发料批量单位</param>
        public BD_MATERIAL__SubHeadEntity5(string sFIssueType,string sFOverControlMode, BD_MATERIAL_BD_UNIT sFMinIssueUnitId, BD_MATERIAL_BD_UNIT sFProduceUnitId)
        {
            FIssueType = sFIssueType;
            FOverControlMode = sFOverControlMode;
            FWorkShopId = new BD_MATERIAL_BD_Department();
            FProduceUnitId = sFProduceUnitId;
            FProduceBillType = new BD_MATERIAL_BOS_BillType();
            FOrgTrustBillType = new BD_MATERIAL_BOS_BillType();
            FBOMUnitId = new BD_MATERIAL_BD_UNIT();
            FPickStockId = new BD_MATERIAL_BD_STOCK();
            FPickBinId = new BD_FLEXVALUESDETAIL_FPickBinId();
            FDefaultRouting = new BD_MATERIAL_ENG_Route();
            FMinIssueUnitId = sFMinIssueUnitId;
        }
        public BD_MATERIAL_BD_Department FWorkShopId;
        public BD_MATERIAL_BD_UNIT FProduceUnitId;
        public decimal FFinishReceiptOverRate = 0;
        public decimal FFinishReceiptShortRate = 0;
        public BD_MATERIAL_BOS_BillType FProduceBillType;
        public BD_MATERIAL_BOS_BillType FOrgTrustBillType;        
        public bool FIsProductLine = false;
        public BD_MATERIAL_BD_UNIT FBOMUnitId;
        public decimal FConsumVolatility = 0;
        public bool FIsMainPrd = false;
        public bool FIsCoby = false;
        public bool FIsECN = false;
        public string FIssueType = "";
        public string FBKFLTime = "";
        public BD_MATERIAL_BD_STOCK FPickStockId;
        public BD_FLEXVALUESDETAIL_FPickBinId FPickBinId;
        public string FOverControlMode="";
        public decimal FMinIssueQty = 0;
        public bool FISMinIssueQty = false;
        public bool FIsKitting = false;
        public bool FIsCompleteSet = false;
        public BD_MATERIAL_ENG_Route FDefaultRouting;
        public decimal FStdLaborPrePareTime = 0;
        public decimal FStdLaborProcessTime = 0;
        public decimal FStdMachinePrepareTime = 0;
        public decimal FStdMachineProcessTime = 0;
        public BD_MATERIAL_BD_UNIT FMinIssueUnitId;
        [JsonIgnore]
        public decimal FPerUnitStandHour;
        [JsonIgnore]
        public decimal FBOMURNom;
        [JsonIgnore]
        public decimal FBOMURNum;
        [JsonIgnore]
        public decimal FPrdURNom;
        [JsonIgnore]
        public decimal FPrdURNum;
    }
    public class BD_MATERIAL__SubHeadEntity6
    {
        public BD_MATERIAL__SubHeadEntity6()
        {
            FIncSampSchemeId = new BD_MATERIAL_QM_SampleScheme();
            FIncQcSchemeId = new BD_MATERIAL_QM_QCScheme();
            FInspectorId = new BD_MATERIAL_BD_Inspector();
            FInspectGroupId = new BD_MATERIAL_BD_OperatorGroup();
        }
        public bool FCheckIncoming = false;
        public bool FCheckProduct = false;
        public bool FCheckStock = false;
        public bool FCheckReturn = false;
        public bool FCheckDelivery = false;
        public bool FEnableCyclistQCSTK = false;
        public long FStockCycle = 0;
        public bool FEnableCyclistQCSTKEW = false;
        public long FEWLeadDay = 0;
        public BD_MATERIAL_QM_SampleScheme FIncSampSchemeId;
        public BD_MATERIAL_QM_QCScheme FIncQcSchemeId;        
        public BD_MATERIAL_BD_OperatorGroup FInspectGroupId;
        public BD_MATERIAL_BD_Inspector FInspectorId;
    }
    public class BD_MATERIAL__SubHeadEntity7
    {
       public BD_MATERIAL__SubHeadEntity7()
        {
            FSubconUnitId = new BD_MATERIAL_BD_UNIT();
            FSubconPriceUnitId = new BD_MATERIAL_BD_UNIT();
            FSubBillType = new BD_MATERIAL_BOS_BillType();
        }
        public BD_MATERIAL_BD_UNIT FSubconUnitId;
        public BD_MATERIAL_BD_UNIT FSubconPriceUnitId;
        public BD_MATERIAL_BOS_BillType FSubBillType;
        [JsonIgnore]
        public decimal FSUBCONPRICEURNOM;
        [JsonIgnore]
        public decimal FSUBCONPRICEURNUM;
        [JsonIgnore]
        public decimal FSUBCONURNOM;
        [JsonIgnore]
        public decimal FSUBCONURNUM;
    }
    public class BD_MATERIAL_BD_UNIT
    {
        [JsonIgnore]
        public BD_MATERIAL_BD_UNIT__SubHeadEntity BD_MATERIAL_BD_UNIT__SubHeadEntity;//不显示
        [JsonIgnore]
        public bool FIsBaseUnit;//不显示
        [JsonIgnore]
        public string FName;//不显示
        public string FNumber="";
        [JsonIgnore]
        public long FPrecision;//不显示
        [JsonIgnore]
        public string FRoundType;//不显示
        [JsonIgnore]
        public long FUNITID;//不显示
        [JsonIgnore]
        public BD_MATERIAL_BD_UNITGROUP FUnitGroupId;//不显示
    }
    public class BD_MATERIAL_BD_MATERIALCATEGORY
    {
        [JsonIgnore]
        public long FCATEGORYID;//不显示
        [JsonIgnore]
        public string FName;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_TaxRate
    {
        [JsonIgnore]
        public bool FID;//不显示
        [JsonIgnore]
        public string FName;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BOS_ASSISTANTDATA_SELECT
    {
        [JsonIgnore]
        public string FDataValue;//不显示
        [JsonIgnore]
        public string FEntryID;//不显示
        public string FNumber="";
    }
    public class BD_FLEXVALUESDETAIL_FTypeID
    {
        public string FTYPEID__FF100001 = "";
        public string FTYPEID__FOPCODE = "";
    }
    public class BD_MATERIAL_BD_UNIT__SubHeadEntity
    {
        public string FConvertType = "";
    }
    public class BD_MATERIAL_BD_STOCK
    {
        [JsonIgnore]
        public BD_MATERIAL_BD_STOCK__FStockFlexItem[] BD_MATERIAL_BD_STOCK__FStockFlexItem;//不显示
        [JsonIgnore]
        public BD_MATERIAL_BD_StockStatus FDefStockStatusId;//不显示
        [JsonIgnore]
        public bool FIsOpenLocation;//不显示
        [JsonIgnore]
        public string FName;//不显示
        public string FNumber="";
        [JsonIgnore]
        public long FStockId;//不显示
    }
    public class BD_MATERIAL_BD_StockStatus
    {
        public string FNAME = "";
        public string FNumber="";
        public long FStockStatusId=0;
    }
    public class BD_MATERIAL_BD_STOCK__FStockFlexItem
    {
        public BD_MATERIAL_BD_STOCK__FStockFlexDetail[] BD_MATERIAL_BD_STOCK__FStockFlexDetail;
        public long FEntryID=0;
        public BD_MATERIAL_BOS_FLEXVALUE FFlexId;

    }
    public class BD_MATERIAL_BOS_FLEXVALUE
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_STOCK__FStockFlexDetail
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_FLEXVALUESDETAIL_FStockPlaceId
    {
        public string FSTOCKPLACEID__FF100001 = "";
        public string FSTOCKPLACEID__FOPCODE = "";
    }
    public class BD_MATERIAL_BD_LotCodeRule
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_Currency
    {
        [JsonIgnore]
        public long FAMOUNTDIGITS;
        [JsonIgnore]
        public long FCURRENCYID;
        [JsonIgnore]
        public string FFormatOrder;
        [JsonIgnore]
        public bool FIsShowCSymbol;
        [JsonIgnore]
        public string FName;
        public string FNumber="";
        [JsonIgnore]
        public long FPRICEDIGITS;
        [JsonIgnore]
        public string FRoundType;
        [JsonIgnore]
        public string FSYSMBOL;
    }
    public class BD_MATERIAL_IV_GTTAXCODE
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_Expense
    {
        [JsonIgnore]
        public long FEXPID;
        [JsonIgnore]
        public string FName;
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_BarCodeRule
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_BUYER
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_OperatorGroup
    {
        [JsonIgnore]
        public long FEntryId;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_Supplier
    {
        [JsonIgnore]
        public string FName;
        public string FNumber="";
        [JsonIgnore]
        public long FSupplierId;
    }
    public class BD_MATERIAL_SEC_User
    {
        public string FName = "";
        public string FUserAccount = "";
        public long FUserID = 0;
    }
    public class BD_MATERIAL__FEntityAuxPty
    {
        public BD_MATERIAL__FEntityAuxPty()
        {
            FAuxPropertyId = new BD_MATERIAL_BD_AuxPty_Select();
        }
        public long FEntryID = 0;
        public BD_MATERIAL_BD_AuxPty_Select FAuxPropertyId;
        public bool FIsEnable1 = false;
        public bool FIsComControl = false;
        public bool FIsAffectPrice1 = false;
        public bool FIsAffectPlan1 = false;
        public bool FIsAffectCost1 = false;
        public bool FIsMustInput = false;
        public string FValueType="";
        [JsonIgnore]
        public bool FValueSet;//不显示
    }
    public class BD_MATERIAL__FEntityInvPty
    {
        public BD_MATERIAL__FEntityInvPty(BD_MATERIAL_BD_InvPty sFInvPtyId)
        {
            FInvPtyId = sFInvPtyId;
        }
        public long FEntryID = 0;
        public BD_MATERIAL_BD_InvPty FInvPtyId;
        public bool FIsEnable = false;
        public bool FIsAffectPrice = false;
        public bool FIsAffectPlan = false;
        public bool FIsAffectCost = false;
    }
    public class BD_MATERIAL_PLN_MANUFACTUREPOLICY
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
        [JsonIgnore]
        public string FPlanMode;
    }
    public class BD_MATERIAL_PLN_PLANAREA
    {
        [JsonIgnore]
        public BD_MATERIAL_PLN_PLANAREA__FEntity[] BD_MATERIAL_PLN_PLANAREA__FEntity;
        [JsonIgnore]
        public string FName;
        public string FNumber="";
        [JsonIgnore]
        public long FPLANAREAID;

    }
    public class BD_MATERIAL_PLN_PLANAREA__FEntity
    {
        public long FEntryID=0;
        public BD_MATERIAL_BD_Department FWorkshopId;
    }
    public class BD_MATERIAL_BD_Department
    {
        [JsonIgnore]
        public long FDEPTID;
        [JsonIgnore]
        public bool FIsStock;
        [JsonIgnore]
        public string FName;
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_PLANNER
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_PLN_PRIORITYCALCULATION
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_PLN_SUPPLYMANAGER
    {
        [JsonIgnore]
        public BD_MATERIAL_ORG_Organizations FDemandOrgId;
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_ENG_Route
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BOS_BillType
    {
        [JsonIgnore]
        public string FBILLTYPEID;
        [JsonIgnore]
        public bool FIsDefault;
        [JsonIgnore]
        public string FName;
        public string FNumber="";
    }
    public class BD_FLEXVALUESDETAIL_FPickBinId
    {
        public string FPICKBINID__FF100001 = "";
        public string FPICKBINID__FOPCODE = "";
    }
    public class BD_MATERIAL_QM_QCScheme
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_Inspector
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_QM_SampleScheme
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_AuxPty_Select
    {
        [JsonIgnore]
        public long FID;//不显示
        public string FNUMBER="";
        [JsonIgnore]
        public string FNAME;//不显示
        [JsonIgnore]
        public string FValueType;//不显示
    }
    public class BD_MATERIAL_BD_InvPty
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
    public class BD_MATERIAL_BD_UNITGROUP
    {
        [JsonIgnore]
        public long FID;//不显示
        [JsonIgnore]
        public string FNAME;//不显示
        public string FNumber="";
    }
}
