using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace K3CloudCs
{
    public class Order_Dal
    {
        private string strcon;
        public List<Item> lItem;
        string date_type = "";
        string page_size = "";
        DataTable dtTrade;
        DataTable dtTradeEntry;
        ConfigHelper config;
        public Order_Dal(string Constring, string strpage_size, string strdate_type)
        {
            config = new ConfigHelper();
            strcon = Constring;
            dtTrade = new DataTable();
            string TradeFields = ConfigurationManager.AppSettings["TradeFields"];
            string TradeValues = ConfigurationManager.AppSettings["TradeDefaultValues"];
            string[] Fields = TradeFields.Split(',');
            string[] Values = TradeValues.Split(',');
            if (Fields.Length > 0 && Values.Length > 0 && Fields.Length == Values.Length)
            {
                CreateTable(dtTrade, Fields, Values);
            }
            dtTradeEntry = new DataTable();
            string TradeEntryFields = ConfigurationManager.AppSettings["TradeEntryFields"];
            string TradeEntryValues = ConfigurationManager.AppSettings["TradeEntryDefaultValues"];
            string[] EntryFields = TradeFields.Split(',');
            string[] EntryValues = TradeValues.Split(',');
            if (EntryFields.Length > 0 && EntryValues.Length > 0 && EntryFields.Length == EntryValues.Length)
            {
                CreateTable(dtTradeEntry, EntryFields, EntryValues);
            }
            lItem = new List<Item>();
            date_type = config.ReadValueByKey(ConfigurationFile.AppConfig, "date_type");
            page_size = config.ReadValueByKey(ConfigurationFile.AppConfig, "page_size");
        }
        public void GetItemListBySql(DateTime begin_time, DateTime end_time, string tid, string order_status)
        {
            //List<Item> lItem = new List<Item>();
            lItem.Clear();
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("@begin_time", begin_time));
            pars.Add(new SqlParameter("@end_time", end_time));
            string sWhere = " Where tid_time>= @begin_time and tid_time<= @end_time";
            if (tid.ToString().Trim() != "")
            {
                pars.Add(new SqlParameter("@tid", tid));
                sWhere = sWhere + " and tid = @tid";
            }
            if (order_status != "全部")
            {
                pars.Add(new SqlParameter("@delivery_status", order_status));
                sWhere = sWhere + " and delivery_status =@delivery_status";
            }
            using (SqlDataReader r = SqlHelper.ExecuteReader(strcon, CommandType.Text, "select top 50 * from tb_Trade " + sWhere, pars.ToArray()))
            {
                while (r.Read())
                {
                    Item i = new Item();
                    i.resultNum = r["resultNum"].ToString();
                    i.storage_id = r["storage_id"].ToString();
                    i.tid = r["tid"].ToString();
                    i.transaction_id = r["transaction_id"].ToString();
                    i.customer_id = r["customer_id"].ToString();
                    i.distributor_id = r["distributor_id"].ToString();
                    i.shop_name = r["shop_name"].ToString();
                    i.out_tid = r["out_tid"].ToString();
                    i.out_pay_tid = r["out_pay_tid"].ToString();
                    i.voucher_id = r["voucher_id"].ToString();
                    i.shopid = r["shopid"].ToString();
                    i.serial_num = r["serial_num"].ToString();
                    i.order_channel = r["order_channel"].ToString();
                    i.order_from = r["order_from"].ToString();
                    i.buyer_id = r["buyer_id"].ToString();
                    i.buyer_name = r["buyer_name"].ToString();
                    i.type = r["type"].ToString();
                    i.status = r["status"].ToString();
                    i.abnormal_status = r["abnormal_status"].ToString();
                    i.merge_status = r["merge_status"].ToString();
                    i.receiver_name = r["receiver_name"].ToString();
                    i.receiver_mobile = r["receiver_mobile"].ToString();
                    i.phone = r["phone"].ToString();
                    i.province = r["province"].ToString();
                    i.city = r["city"].ToString();
                    i.district = r["district"].ToString();
                    i.address = r["address"].ToString();
                    i.post = r["post"].ToString();
                    i.email = r["email"].ToString();
                    i.is_bill = r["is_bill"].ToString();
                    i.invoice_name = r["invoice_name"].ToString();
                    i.invoice_situation = r["invoice_situation"].ToString();
                    i.invoice_title = r["invoice_title"].ToString();
                    i.invoice_type = r["invoice_type"].ToString();
                    i.invoice_content = r["invoice_content"].ToString();
                    i.pro_totalfee = r["pro_totalfee"].ToString();
                    i.order_totalfee = r["order_totalfee"].ToString();
                    i.reference_price_paid = r["reference_price_paid"].ToString();
                    i.invoice_fee = r["invoice_fee"].ToString();
                    i.cod_fee = r["cod_fee"].ToString();
                    i.other_fee = r["other_fee"].ToString();
                    i.refund_totalfee = r["refund_totalfee"].ToString();
                    i.discount_fee = r["discount_fee"].ToString();
                    i.discount = r["discount"].ToString();
                    i.channel_disfee = r["channel_disfee"].ToString();
                    i.merchant_disfee = r["merchant_disfee"].ToString();
                    i.order_disfee = r["order_disfee"].ToString();
                    i.commission_fee = r["commission_fee"].ToString();
                    i.is_cod = r["is_cod"].ToString();
                    i.point_pay = r["point_pay"].ToString();
                    i.cost_point = r["cost_point"].ToString();
                    i.point = r["point"].ToString();
                    i.superior_point = r["superior_point"].ToString();
                    i.royalty_fee = r["royalty_fee"].ToString();
                    i.external_point = r["external_point"].ToString();
                    i.express_no = r["express_no"].ToString();
                    i.express = r["express"].ToString();
                    i.express_coding = r["express_coding"].ToString();
                    i.online_express = r["online_express"].ToString();
                    i.sending_type = r["sending_type"].ToString();
                    i.real_income_freight = r["real_income_freight"].ToString();
                    i.real_pay_freight = r["real_pay_freight"].ToString();
                    i.gross_weight = r["gross_weight"].ToString();
                    i.gross_weight_freight = r["gross_weight_freight"].ToString();
                    i.net_weight_freight = r["net_weight_freight"].ToString();
                    i.freight_explain = r["freight_explain"].ToString();
                    i.total_weight = r["total_weight"].ToString();
                    i.tid_net_weight = r["tid_net_weight"].ToString();
                    i.tid_time = r["tid_time"].ToString();
                    i.pay_time = r["pay_time"].ToString();
                    i.get_time = r["get_time"].ToString();
                    i.order_creater = r["order_creater"].ToString();
                    i.business_man = r["business_man"].ToString();
                    i.payment_received_operator = r["payment_received_operator"].ToString();
                    i.payment_received_time = r["payment_received_time"].ToString();
                    i.review_orders_operator = r["review_orders_operator"].ToString();
                    i.review_orders_time = r["review_orders_time"].ToString();
                    i.finance_review_operator = r["finance_review_operator"].ToString();
                    i.finance_review_time = r["finance_review_time"].ToString();
                    i.advance_printer = r["advance_printer"].ToString();
                    i.printer = r["printer"].ToString();
                    i.print_time = r["print_time"].ToString();
                    i.is_print = r["is_print"].ToString();
                    i.adv_distributer = r["adv_distributer"].ToString();
                    i.adv_distribut_time = r["adv_distribut_time"].ToString();
                    i.distributer = r["distributer"].ToString();
                    i.distribut_time = r["distribut_time"].ToString();
                    i.is_inspection = r["is_inspection"].ToString();
                    i.inspecter = r["inspecter"].ToString();
                    i.inspect_time = r["inspect_time"].ToString();
                    i.cancel_operator = r["cancel_operator"].ToString();
                    i.cancel_time = r["cancel_time"].ToString();
                    i.revoke_cancel_er = r["revoke_cancel_er"].ToString();
                    i.revoke_cancel_time = r["revoke_cancel_time"].ToString();
                    i.packager = r["packager"].ToString();
                    i.pack_time = r["pack_time"].ToString();
                    i.weigh_operator = r["weigh_operator"].ToString();
                    i.weigh_time = r["weigh_time"].ToString();
                    i.book_delivery_time = r["book_delivery_time"].ToString();
                    i.delivery_operator = r["delivery_operator"].ToString();
                    i.delivery_time = r["delivery_time"].ToString();
                    i.locker = r["locker"].ToString();
                    i.lock_time = r["lock_time"].ToString();
                    i.book_file_time = r["book_file_time"].ToString();
                    i.file_operator = r["file_operator"].ToString();
                    i.file_time = r["file_time"].ToString();
                    i.finish_time = r["finish_time"].ToString();
                    i.modity_time = r["modity_time"].ToString();
                    i.is_promotion = r["is_promotion"].ToString();
                    i.promotion_plan = r["promotion_plan"].ToString();
                    i.out_promotion_detail = r["out_promotion_detail"].ToString();
                    i.good_receive_time = r["good_receive_time"].ToString();
                    i.receive_time = r["receive_time"].ToString();
                    i.verificaty_time = r["verificaty_time"].ToString();
                    i.enable_inte_sto_time = r["enable_inte_sto_time"].ToString();
                    i.enable_inte_delivery_time = r["enable_inte_delivery_time"].ToString();
                    i.alipay_id = r["alipay_id"].ToString();
                    i.alipay_status = r["alipay_status"].ToString();
                    i.pay_mothed = r["pay_mothed"].ToString();
                    i.pay_status = r["pay_status"].ToString();
                    i.platform_status = r["platform_status"].ToString();
                    i.rate = r["rate"].ToString();
                    i.currency = r["currency"].ToString();
                    i.delivery_status = r["delivery_status"].ToString();
                    i.buyer_message = r["buyer_message"].ToString();
                    i.service_remarks = r["service_remarks"].ToString();
                    i.inner_lable = r["inner_lable"].ToString();
                    i.distributor_mark = r["distributor_mark"].ToString();
                    i.system_remarks = r["system_remarks"].ToString();
                    i.other_remarks = r["other_remarks"].ToString();
                    i.message = r["message"].ToString();
                    i.message_time = r["message_time"].ToString();
                    i.is_stock = r["is_stock"].ToString();
                    i.related_orders = r["related_orders"].ToString();
                    i.related_orders_type = r["related_orders_type"].ToString();
                    i.import_mark = r["import_mark"].ToString();
                    i.delivery_name = r["delivery_name"].ToString();
                    i.is_new_customer = r["is_new_customer"].ToString();
                    i.distributor_level = r["distributor_level"].ToString();
                    i.cod_service_fee = r["cod_service_fee"].ToString();
                    i.express_col_fee = r["express_col_fee"].ToString();
                    i.product_num = r["product_num"].ToString();
                    i.sku = r["sku"].ToString();
                    i.item_num = r["item_num"].ToString();
                    i.single_num = r["single_num"].ToString();
                    i.flag_color = r["flag_color"].ToString();
                    i.is_flag = r["is_flag"].ToString();
                    i.taobao_delivery_order_status = r["taobao_delivery_order_status"].ToString();
                    i.taobao_delivery_status = r["taobao_delivery_status"].ToString();
                    i.taobao_delivery_method = r["taobao_delivery_method"].ToString();
                    i.order_process_time = r["order_process_time"].ToString();
                    i.is_break = r["is_break"].ToString();
                    i.breaker = r["breaker"].ToString();
                    i.break_time = r["break_time"].ToString();
                    i.break_explain = r["break_explain"].ToString();
                    i.plat_send_status = r["plat_send_status"].ToString();
                    i.plat_type = r["plat_type"].ToString();
                    i.is_adv_sale = r["is_adv_sale"].ToString();
                    i.provinc_code = r["provinc_code"].ToString();
                    i.city_code = r["city_code"].ToString();
                    i.area_code = r["area_code"].ToString();
                    i.express_code = r["express_code"].ToString();
                    i.last_returned_time = r["last_returned_time"].ToString();
                    i.last_refund_time = r["last_refund_time"].ToString();
                    i.deliver_centre = r["deliver_centre"].ToString();
                    i.deliver_station = r["deliver_station"].ToString();
                    i.is_pre_delivery_notice = r["is_pre_delivery_notice"].ToString();
                    i.jd_delivery_time = r["jd_delivery_time"].ToString();
                    i.Sorting_code = r["Sorting_code"].ToString();
                    i.cod_settlement_vouchernumber = r["cod_settlement_vouchernumber"].ToString();
                    i.three_codes = r["three_codes"].ToString();
                    i.send_site_name = r["send_site_name"].ToString();
                    i.distributing_centre_name = r["distributing_centre_name"].ToString();
                    i.total_num = r["total_num"].ToString();
                    i.originCode = r["originCode"].ToString();
                    i.destCode = r["destCode"].ToString();
                    i.big_marker = r["big_marker"].ToString();
                    i.platform_preferential = r["platform_preferential"].ToString();
                    i.总数量 = r["总数量"].ToString();
                    CreateItemEntry(i.tid, i.tid_item);
                    lItem.Add(i);
                }
            }
            //return lItem;
        }
        private void CreateItemEntry(string tid, List<tid_item> items)
        {
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@tid", tid) };
            using (SqlDataReader r = SqlHelper.ExecuteReader(strcon, CommandType.Text, "select * from tb_TradeEntry where tid = @tid", pars))
            {
                while (r.Read())
                {
                    tid_item t = new tid_item();
                    t.storage_id = r["storage_id"].ToString();
                    t.tid = r["tid"].ToString();
                    t.pro_detail_code = r["pro_detail_code"].ToString();
                    t.pro_name = r["pro_name"].ToString();
                    t.specification = r["specification"].ToString();
                    t.barcode = r["barcode"].ToString();
                    t.combine_barcode = r["combine_barcode"].ToString();
                    t.iscancel = r["iscancel"].ToString();
                    t.isscheduled = r["isscheduled"].ToString();
                    t.stock_situation = r["stock_situation"].ToString();
                    t.isbook_pro = r["isbook_pro"].ToString();
                    t.iscombination = r["iscombination"].ToString();
                    t.isgifts = r["isgifts"].ToString();
                    t.gift_num = r["gift_num"].ToString();
                    t.book_storage = r["book_storage"].ToString();
                    t.pro_num = r["pro_num"].ToString();
                    t.send_num = r["send_num"].ToString();
                    t.refund_num = r["refund_num"].ToString();
                    t.refund_renum = r["refund_renum"].ToString();
                    t.inspection_num = r["inspection_num"].ToString();
                    t.timeinventory = r["timeinventory"].ToString();
                    t.cost_price = r["cost_price"].ToString();
                    t.sell_price = r["sell_price"].ToString();
                    t.average_price = r["average_price"].ToString();
                    t.original_price = r["original_price"].ToString();
                    t.sys_price = r["sys_price"].ToString();
                    t.ferght = r["ferght"].ToString();
                    t.item_discountfee = r["item_discountfee"].ToString();
                    t.inspection_time = r["inspection_time"].ToString();
                    t.weight = r["weight"].ToString();
                    t.shopid = r["shopid"].ToString();
                    t.out_tid = r["out_tid"].ToString();
                    t.out_proid = r["out_proid"].ToString();
                    t.out_prosku = r["out_prosku"].ToString();
                    t.proexplain = r["proexplain"].ToString();
                    t.buyer_memo = r["buyer_memo"].ToString();
                    t.seller_remark = r["seller_remark"].ToString();
                    t.distributer = r["distributer"].ToString();
                    t.distribut_time = r["distribut_time"].ToString();
                    t.second_barcode = r["second_barcode"].ToString();
                    t.product_no = r["product_no"].ToString();
                    t.brand_number = r["brand_number"].ToString();
                    t.brand_name = r["brand_name"].ToString();
                    t.book_inventory = r["book_inventory"].ToString();
                    t.product_specification = r["product_specification"].ToString();
                    t.discount_amount = r["discount_amount"].ToString();
                    t.credit_amount = r["credit_amount"].ToString();
                    t.MD5_encryption = r["MD5_encryption"].ToString();
                    t.sncode = r["sncode"].ToString();
                    t.store_location = r["store_location"].ToString();
                    t.pro_type = r["pro_type"].ToString();
                    items.Add(t);
                }
            }
        }
        public void GetItemListByNet(string begin_time, string end_time, string tid, string order_status, string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            lItem.Clear();
            switch (order_status)
            {
                case "未发货":
                    FillList(begin_time, end_time, tid, "未发货", StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);                    
                    break;
                case "已发货":                    
                    FillList(begin_time, end_time, tid, "已发货", StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    break;
                default:
                    FillList(begin_time, end_time, tid, "未发货", StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    FillList(begin_time, end_time, tid, "已发货", StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                    break;
            }
        }
        private void FillList(string begin_time, string end_time, string tid, string order_status, string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            DateTime dt = DateTime.Parse(begin_time);
            bool isContinue = true;
            while (isContinue == true)
            {
                List<Item> ListItems = LoadInfo(date_type, dt.ToString(), end_time, order_status, StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                dt = getMaxDateTime(dt, ListItems);
                foreach (Item i in ListItems)
                {
                    if (i.tid.Contains(tid) == true)
                    {
                        lItem.Add(i);
                    }
                }
                if (page_size != "" || ListItems.Count == 0)
                {
                    if (ListItems.Count < int.Parse(page_size))
                    {
                        isContinue = false;
                    }
                }
            }
        }
        private DateTime getMaxDateTime(DateTime dt,List<Item>lItems)
        {
            foreach(Item i in lItems)
            {
                try
                {
                    DateTime curDateTime = DateTime.Parse(i.tid_time);
                    if (curDateTime > dt)
                    {
                        dt = curDateTime;
                    }
                }
                catch
                {

                }
            }
            return dt;
        }
        public List<tid_item> GetItemEntry(JArray j)
        {
            List<tid_item> ltid_item = new List<tid_item>();
            foreach (JObject jo in j)
            {
                tid_item t = new tid_item();
                t.storage_id = jo["storage_id"].ToString();
                t.tid = jo["tid"].ToString();
                t.pro_detail_code = jo["pro_detail_code"].ToString();
                t.pro_name = jo["pro_name"].ToString();
                t.specification = jo["specification"].ToString();
                t.barcode = jo["barcode"].ToString();
                t.combine_barcode = jo["combine_barcode"].ToString();
                t.iscancel = jo["iscancel"].ToString();
                t.isscheduled = jo["isscheduled"].ToString();
                t.stock_situation = jo["stock_situation"].ToString();
                t.isbook_pro = jo["isbook_pro"].ToString();
                t.iscombination = jo["iscombination"].ToString();
                t.isgifts = jo["isgifts"].ToString();
                t.gift_num = jo["gift_num"].ToString();
                t.book_storage = jo["book_storage"].ToString();
                t.pro_num = jo["pro_num"].ToString();
                t.send_num = jo["send_num"].ToString();
                t.refund_num = jo["refund_num"].ToString();
                t.refund_renum = jo["refund_renum"].ToString();
                t.inspection_num = jo["inspection_num"].ToString();
                t.timeinventory = jo["timeinventory"].ToString();
                t.cost_price = jo["cost_price"].ToString();
                t.sell_price = jo["sell_price"].ToString();
                t.average_price = jo["average_price"].ToString();
                t.original_price = jo["original_price"].ToString();
                t.sys_price = jo["sys_price"].ToString();
                t.ferght = jo["ferght"].ToString();
                t.item_discountfee = jo["item_discountfee"].ToString();
                t.inspection_time = jo["inspection_time"].ToString();
                t.weight = jo["weight"].ToString();
                t.shopid = jo["shopid"].ToString();
                t.out_tid = jo["out_tid"].ToString();
                t.out_proid = jo["out_proid"].ToString();
                t.out_prosku = jo["out_prosku"].ToString();
                t.proexplain = jo["proexplain"].ToString();
                t.buyer_memo = jo["buyer_memo"].ToString();
                t.seller_remark = jo["seller_remark"].ToString();
                t.distributer = jo["distributer"].ToString();
                t.distribut_time = jo["distribut_time"].ToString();
                t.second_barcode = jo["second_barcode"].ToString();
                t.product_no = jo["product_no"].ToString();
                t.brand_number = jo["brand_number"].ToString();
                t.brand_name = jo["brand_name"].ToString();
                t.book_inventory = jo["book_inventory"].ToString();
                t.product_specification = jo["product_specification"].ToString();
                t.discount_amount = jo["discount_amount"].ToString();
                t.credit_amount = jo["credit_amount"].ToString();
                t.MD5_encryption = jo["MD5_encryption"].ToString();
                t.sncode = jo["sncode"].ToString();
                t.store_location = jo["store_location"].ToString();
                t.pro_type = jo["pro_type"].ToString();
                ltid_item.Add(t);
            }
            return ltid_item;
        }
        public void InsertDB(Item i)
        {

            JObject jo = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(i));
            JArray arr = new JArray();
            arr.Add(jo);
            JArray j = new JArray();
            foreach(tid_item ti in i.tid_item)
            {
                JObject ji = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(ti));
                j.Add(ji);
            }
            dtTrade = JsonToDataTable(arr.ToString());
            SqlBulkCopyInsert("tb_Trade", dtTrade);
            dtTradeEntry = JsonToDataTable(j.ToString());
            SqlBulkCopyInsert("tb_TradeEntry", dtTradeEntry);
        }
        private Item GetItem(JObject j)
        {
            Item i = new Item();
            i.resultNum = j["resultNum"].ToString();
            i.storage_id = j["storage_id"].ToString();
            i.tid = j["tid"].ToString();
            i.transaction_id = j["transaction_id"].ToString();
            i.customer_id = j["customer_id"].ToString();
            i.distributor_id = j["distributor_id"].ToString();
            i.shop_name = j["shop_name"].ToString();
            i.out_tid = j["out_tid"].ToString();
            i.out_pay_tid = j["out_pay_tid"].ToString();
            i.voucher_id = j["voucher_id"].ToString();
            i.shopid = j["shopid"].ToString();
            i.serial_num = j["serial_num"].ToString();
            i.order_channel = j["order_channel"].ToString();
            i.order_from = j["order_from"].ToString();
            i.buyer_id = j["buyer_id"].ToString();
            i.buyer_name = j["buyer_name"].ToString();
            i.type = j["type"].ToString();
            i.status = j["status"].ToString();
            i.abnormal_status = j["abnormal_status"].ToString();
            i.merge_status = j["merge_status"].ToString();
            i.receiver_name = j["receiver_name"].ToString();
            i.receiver_mobile = j["receiver_mobile"].ToString();
            i.phone = j["phone"].ToString();
            i.province = j["province"].ToString();
            i.city = j["city"].ToString();
            i.district = j["district"].ToString();
            i.address = j["address"].ToString();
            i.post = j["post"].ToString();
            i.email = j["email"].ToString();
            i.is_bill = j["is_bill"].ToString();
            i.invoice_name = j["invoice_name"].ToString();
            i.invoice_situation = j["invoice_situation"].ToString();
            i.invoice_title = j["invoice_title"].ToString();
            i.invoice_type = j["invoice_type"].ToString();
            i.invoice_content = j["invoice_content"].ToString();
            i.pro_totalfee = j["pro_totalfee"].ToString();
            i.order_totalfee = j["order_totalfee"].ToString();
            i.reference_price_paid = j["reference_price_paid"].ToString();
            i.invoice_fee = j["invoice_fee"].ToString();
            i.cod_fee = j["cod_fee"].ToString();
            i.other_fee = j["other_fee"].ToString();
            i.refund_totalfee = j["refund_totalfee"].ToString();
            i.discount_fee = j["discount_fee"].ToString();
            i.discount = j["discount"].ToString();
            i.channel_disfee = j["channel_disfee"].ToString();
            i.merchant_disfee = j["merchant_disfee"].ToString();
            i.order_disfee = j["order_disfee"].ToString();
            i.commission_fee = j["commission_fee"].ToString();
            i.is_cod = j["is_cod"].ToString();
            i.point_pay = j["point_pay"].ToString();
            i.cost_point = j["cost_point"].ToString();
            i.point = j["point"].ToString();
            i.superior_point = j["superior_point"].ToString();
            i.royalty_fee = j["royalty_fee"].ToString();
            i.external_point = j["external_point"].ToString();
            i.express_no = j["express_no"].ToString();
            i.express = j["express"].ToString();
            i.express_coding = j["express_coding"].ToString();
            i.online_express = j["online_express"].ToString();
            i.sending_type = j["sending_type"].ToString();
            i.real_income_freight = j["real_income_freight"].ToString();
            i.real_pay_freight = j["real_pay_freight"].ToString();
            i.gross_weight = j["gross_weight"].ToString();
            i.gross_weight_freight = j["gross_weight_freight"].ToString();
            i.net_weight_freight = j["net_weight_freight"].ToString();
            i.freight_explain = j["freight_explain"].ToString();
            i.total_weight = j["total_weight"].ToString();
            i.tid_net_weight = j["tid_net_weight"].ToString();
            i.tid_time = j["tid_time"].ToString();
            i.pay_time = j["pay_time"].ToString();
            i.get_time = j["get_time"].ToString();
            i.order_creater = j["order_creater"].ToString();
            i.business_man = j["business_man"].ToString();
            i.payment_received_operator = j["payment_received_operator"].ToString();
            i.payment_received_time = j["payment_received_time"].ToString();
            i.review_orders_operator = j["review_orders_operator"].ToString();
            i.review_orders_time = j["review_orders_time"].ToString();
            i.finance_review_operator = j["finance_review_operator"].ToString();
            i.finance_review_time = j["finance_review_time"].ToString();
            i.advance_printer = j["advance_printer"].ToString();
            i.printer = j["printer"].ToString();
            i.print_time = j["print_time"].ToString();
            i.is_print = j["is_print"].ToString();
            i.adv_distributer = j["adv_distributer"].ToString();
            i.adv_distribut_time = j["adv_distribut_time"].ToString();
            i.distributer = j["distributer"].ToString();
            i.distribut_time = j["distribut_time"].ToString();
            i.is_inspection = j["is_inspection"].ToString();
            i.inspecter = j["inspecter"].ToString();
            i.inspect_time = j["inspect_time"].ToString();
            i.cancel_operator = j["cancel_operator"].ToString();
            i.cancel_time = j["cancel_time"].ToString();
            i.revoke_cancel_er = j["revoke_cancel_er"].ToString();
            i.revoke_cancel_time = j["revoke_cancel_time"].ToString();
            i.packager = j["packager"].ToString();
            i.pack_time = j["pack_time"].ToString();
            i.weigh_operator = j["weigh_operator"].ToString();
            i.weigh_time = j["weigh_time"].ToString();
            i.book_delivery_time = j["book_delivery_time"].ToString();
            i.delivery_operator = j["delivery_operator"].ToString();
            i.delivery_time = j["delivery_time"].ToString();
            i.locker = j["locker"].ToString();
            i.lock_time = j["lock_time"].ToString();
            i.book_file_time = j["book_file_time"].ToString();
            i.file_operator = j["file_operator"].ToString();
            i.file_time = j["file_time"].ToString();
            i.finish_time = j["finish_time"].ToString();
            i.modity_time = j["modity_time"].ToString();
            i.is_promotion = j["is_promotion"].ToString();
            i.promotion_plan = j["promotion_plan"].ToString();
            i.out_promotion_detail = j["out_promotion_detail"].ToString();
            i.good_receive_time = j["good_receive_time"].ToString();
            i.receive_time = j["receive_time"].ToString();
            i.verificaty_time = j["verificaty_time"].ToString();
            i.enable_inte_sto_time = j["enable_inte_sto_time"].ToString();
            i.enable_inte_delivery_time = j["enable_inte_delivery_time"].ToString();
            i.alipay_id = j["alipay_id"].ToString();
            i.alipay_status = j["alipay_status"].ToString();
            i.pay_mothed = j["pay_mothed"].ToString();
            i.pay_status = j["pay_status"].ToString();
            i.platform_status = j["platform_status"].ToString();
            i.rate = j["rate"].ToString();
            i.currency = j["currency"].ToString();
            i.delivery_status = j["delivery_status"].ToString();
            i.buyer_message = j["buyer_message"].ToString();
            i.service_remarks = j["service_remarks"].ToString();
            i.inner_lable = j["inner_lable"].ToString();
            i.distributor_mark = j["distributor_mark"].ToString();
            i.system_remarks = j["system_remarks"].ToString();
            i.other_remarks = j["other_remarks"].ToString();
            i.message = j["message"].ToString();
            i.message_time = j["message_time"].ToString();
            i.is_stock = j["is_stock"].ToString();
            i.related_orders = j["related_orders"].ToString();
            i.related_orders_type = j["related_orders_type"].ToString();
            i.import_mark = j["import_mark"].ToString();
            i.delivery_name = j["delivery_name"].ToString();
            i.is_new_customer = j["is_new_customer"].ToString();
            i.distributor_level = j["distributor_level"].ToString();
            i.cod_service_fee = j["cod_service_fee"].ToString();
            i.express_col_fee = j["express_col_fee"].ToString();
            i.product_num = j["product_num"].ToString();
            i.sku = j["sku"].ToString();
            i.item_num = j["item_num"].ToString();
            i.single_num = j["single_num"].ToString();
            i.flag_color = j["flag_color"].ToString();
            i.is_flag = j["is_flag"].ToString();
            i.taobao_delivery_order_status = j["taobao_delivery_order_status"].ToString();
            i.taobao_delivery_status = j["taobao_delivery_status"].ToString();
            i.taobao_delivery_method = j["taobao_delivery_method"].ToString();
            i.order_process_time = j["order_process_time"].ToString();
            i.is_break = j["is_break"].ToString();
            i.breaker = j["breaker"].ToString();
            i.break_time = j["break_time"].ToString();
            i.break_explain = j["break_explain"].ToString();
            i.plat_send_status = j["plat_send_status"].ToString();
            i.plat_type = j["plat_type"].ToString();
            i.is_adv_sale = j["is_adv_sale"].ToString();
            i.provinc_code = j["provinc_code"].ToString();
            i.city_code = j["city_code"].ToString();
            i.area_code = j["area_code"].ToString();
            i.express_code = j["express_code"].ToString();
            i.last_returned_time = j["last_returned_time"].ToString();
            i.last_refund_time = j["last_refund_time"].ToString();
            i.deliver_centre = j["deliver_centre"].ToString();
            i.deliver_station = j["deliver_station"].ToString();
            i.is_pre_delivery_notice = j["is_pre_delivery_notice"].ToString();
            i.jd_delivery_time = j["jd_delivery_time"].ToString();
            i.Sorting_code = j["Sorting_code"].ToString();
            i.cod_settlement_vouchernumber = j["cod_settlement_vouchernumber"].ToString();
            i.three_codes = j["three_codes"].ToString();
            i.send_site_name = j["send_site_name"].ToString();
            i.distributing_centre_name = j["distributing_centre_name"].ToString();
            i.total_num = j["total_num"].ToString();
            i.originCode = j["originCode"].ToString();
            i.destCode = j["destCode"].ToString();
            i.big_marker = j["big_marker"].ToString();
            i.platform_preferential = j["platform_preferential"].ToString();
            i.总数量 = j["总数量"].ToString();
            JArray ja = (JArray)JsonConvert.DeserializeObject(j["tid_item"].ToString());
            i.tid_item = GetItemEntry(ja);
            return i;
        }
        public List<string> lError(Item i)
        {
            List<string> lstring = new List<string>();
            string strError = "门店信息:"+i.shop_name+"不存在!" ;
            string strSql = "select a.shop_name from tb_shopSet01 a inner join T_ORG_ORGANIZATIONS b on a.SaleOrg_id = b.FORGID inner join T_ORG_ORGANIZATIONS_L c on a.SaleOrg_id = c.FORGID inner join T_BD_CUSTOMER d on a.Cust_id = d.FCUSTID inner join T_BD_CUSTOMER_L e on a.Cust_id = e.FCUSTID where a.shop_name = '"+ i.shop_name +"'";
            if (isExists(strSql) == false)
            {
                lstring.Add(strError.ToString());
            }
            foreach(tid_item ti in i.tid_item)
            {
                strError = "产品代码:"+ti.product_no+ "不存在!";
                strSql = "select FNUMBER from T_BD_MATERIAL where FNUMBER='" + ti.product_no +"'";
                if (isExists(strSql) == false)
                {
                    lstring.Add(strError.ToString());
                }

                strError = "仓库代码:" + ti.storage_id + "不存在!";
                strSql = "select FNUMBER from T_BD_STOCK where FNUMBER='" + ti.storage_id + "'";
                if (isExists(strSql) == false)
                {
                    lstring.Add(strError.ToString());
                }

                strError = "产品代码:" + ti.product_no + "数量小于等于0!";
                if (float.Parse(ti.pro_num) <= 0)
                {
                    lstring.Add(strError.ToString());
                }

                strError = "产品代码:" + ti.product_no + "库存不存在!";
                strSql = "select a.FNUMBER from T_BD_MATERIAL a inner join [dbo].[T_STK_INVENTORY] b on b.[FMATERIALID]=a.FMATERIALID where a.FNUMBER='" + ti.product_no + "'";
                if (isExists(strSql) == false)
                {
                    lstring.Add(strError.ToString());
                }
                else
                {
                    strError = "产品代码:" + ti.product_no + "库存数量小于等于0!";
                    strSql = "select a.FNUMBER from T_BD_MATERIAL a inner join [dbo].[T_STK_INVENTORY] b on b.[FMATERIALID]=a.FMATERIALID where b.FQTY>0 and a.FNUMBER='" + ti.product_no + "'";
                    if (isExists(strSql) == false)
                    {
                        lstring.Add(strError.ToString());
                    }
                }
            }
            return lstring;
        }
        public bool isExists(string strSQL)
        {
            bool isEx = false;
            using (SqlDataReader r = SqlHelper.ExecuteReader(strcon, CommandType.Text,strSQL, null))
            {
                isEx = r.HasRows;
            }
            return isEx;
        }
        private void CreateTable(DataTable dt, string[] Fileds, string[] Values)
        {
            for (int i = 0; i < Fileds.Length; i++)
            {
                DataColumn Column = new DataColumn();
                //该列的数据类型
                Column.DataType = Type.GetType("System.String");
                //该列得名称
                Column.ColumnName = Fileds[i];
                //该列得默认值
                Column.DefaultValue = Values[i];

                dt.Columns.Add(Column);
            }
        }
        private DataTable JsonToDataTable(string sJson)
        {
            try
            {
                DataTable api_Table = JsonConvert.DeserializeObject(sJson, typeof(DataTable)) as DataTable;
                return api_Table;
            }
            catch
            {
                return null;
            }
        }
        private void SqlBulkCopyInsert(string strTableName, DataTable dtData)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(strcon))//引用SqlBulkCopy  
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;//数据库中对应的表名  
                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;//有几行数据  
                    sqlRevdBulkCopy.WriteToServer(dtData);//数据导入数据库  
                    sqlRevdBulkCopy.Close();//关闭连接  
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteFileLog(typeof(Edb_OUTSTOCK_DAL), ex.ToString());
            }
        }
        private List<Item> LoadInfo(string date_type, string begin_time, string end_time, string order_status, string StrserviceUrl, string Strdbhost, string Strappkey, string Strappscret, string Strtoken)
        {
            List<Item> lItems = new List<Item>();
            bool isSuccess = false;
            string strJson = string.Empty;
            while (isSuccess != true)
            {
                EdbLib edb = new EdbLib(StrserviceUrl, Strdbhost, Strappkey, Strappscret, Strtoken);
                Dictionary<String, String> @params = edb.edbGetCommonParams("edbTradeGet");
                if (date_type != "") @params["date_type"] = date_type;
                @params["begin_time"] = begin_time;
                @params["end_time"] = end_time;
                @params["order_status"] = order_status;
                @params["page_no"] = "1";
                @params["page_size"] = page_size;
                strJson = edb.edbRequstPost(@params, out isSuccess);
                edb = null;
            }

            if (strJson != string.Empty)
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
                JArray arr = (JArray)jo["Success"]["items"]["item"];
                foreach (JObject j in arr)
                {
                    lItems.Add(GetItem(j));
                }
            }

            return lItems;
        }

    }
}
