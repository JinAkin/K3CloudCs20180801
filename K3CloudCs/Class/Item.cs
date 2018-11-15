using System.Collections.Generic;
namespace K3CloudCs
{
    public class Item
    {
        public Item()
        {
            tid_item = new List<tid_item>();
        }
        private string _resultNum;
        public string resultNum
        {
            get { return _resultNum; }
            set { _resultNum = value; }
        }
        private string _storage_id;
        public string storage_id
        {
            get { return _storage_id; }
            set { _storage_id = value; }
        }
        private string _tid;
        public string tid
        {
            get { return _tid; }
            set { _tid = value; }
        }
        private string _transaction_id;
        public string transaction_id
        {
            get { return _transaction_id; }
            set { _transaction_id = value; }
        }
        private string _customer_id;
        public string customer_id
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }
        private string _distributor_id;
        public string distributor_id
        {
            get { return _distributor_id; }
            set { _distributor_id = value; }
        }
        private string _shop_name;
        public string shop_name
        {
            get { return _shop_name; }
            set { _shop_name = value; }
        }
        private string _out_tid;
        public string out_tid
        {
            get { return _out_tid; }
            set { _out_tid = value; }
        }
        private string _out_pay_tid;
        public string out_pay_tid
        {
            get { return _out_pay_tid; }
            set { _out_pay_tid = value; }
        }
        private string _voucher_id;
        public string voucher_id
        {
            get { return _voucher_id; }
            set { _voucher_id = value; }
        }
        private string _shopid;
        public string shopid
        {
            get { return _shopid; }
            set { _shopid = value; }
        }
        private string _serial_num;
        public string serial_num
        {
            get { return _serial_num; }
            set { _serial_num = value; }
        }
        private string _order_channel;
        public string order_channel
        {
            get { return _order_channel; }
            set { _order_channel = value; }
        }
        private string _order_from;
        public string order_from
        {
            get { return _order_from; }
            set { _order_from = value; }
        }
        private string _buyer_id;
        public string buyer_id
        {
            get { return _buyer_id; }
            set { _buyer_id = value; }
        }
        private string _buyer_name;
        public string buyer_name
        {
            get { return _buyer_name; }
            set { _buyer_name = value; }
        }
        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _abnormal_status;
        public string abnormal_status
        {
            get { return _abnormal_status; }
            set { _abnormal_status = value; }
        }
        private string _merge_status;
        public string merge_status
        {
            get { return _merge_status; }
            set { _merge_status = value; }
        }
        private string _receiver_name;
        public string receiver_name
        {
            get { return _receiver_name; }
            set { _receiver_name = value; }
        }
        private string _receiver_mobile;
        public string receiver_mobile
        {
            get { return _receiver_mobile; }
            set { _receiver_mobile = value; }
        }
        private string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _province;
        public string province
        {
            get { return _province; }
            set { _province = value; }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _district;
        public string district
        {
            get { return _district; }
            set { _district = value; }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _post;
        public string post
        {
            get { return _post; }
            set { _post = value; }
        }
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _is_bill;
        public string is_bill
        {
            get { return _is_bill; }
            set { _is_bill = value; }
        }
        private string _invoice_name;
        public string invoice_name
        {
            get { return _invoice_name; }
            set { _invoice_name = value; }
        }
        private string _invoice_situation;
        public string invoice_situation
        {
            get { return _invoice_situation; }
            set { _invoice_situation = value; }
        }
        private string _invoice_title;
        public string invoice_title
        {
            get { return _invoice_title; }
            set { _invoice_title = value; }
        }
        private string _invoice_type;
        public string invoice_type
        {
            get { return _invoice_type; }
            set { _invoice_type = value; }
        }
        private string _invoice_content;
        public string invoice_content
        {
            get { return _invoice_content; }
            set { _invoice_content = value; }
        }
        private string _pro_totalfee;
        public string pro_totalfee
        {
            get { return _pro_totalfee; }
            set { _pro_totalfee = value; }
        }
        private string _order_totalfee;
        public string order_totalfee
        {
            get { return _order_totalfee; }
            set { _order_totalfee = value; }
        }
        private string _reference_price_paid;
        public string reference_price_paid
        {
            get { return _reference_price_paid; }
            set { _reference_price_paid = value; }
        }
        private string _invoice_fee;
        public string invoice_fee
        {
            get { return _invoice_fee; }
            set { _invoice_fee = value; }
        }
        private string _cod_fee;
        public string cod_fee
        {
            get { return _cod_fee; }
            set { _cod_fee = value; }
        }
        private string _other_fee;
        public string other_fee
        {
            get { return _other_fee; }
            set { _other_fee = value; }
        }
        private string _refund_totalfee;
        public string refund_totalfee
        {
            get { return _refund_totalfee; }
            set { _refund_totalfee = value; }
        }
        private string _discount_fee;
        public string discount_fee
        {
            get { return _discount_fee; }
            set { _discount_fee = value; }
        }
        private string _discount;
        public string discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        private string _channel_disfee;
        public string channel_disfee
        {
            get { return _channel_disfee; }
            set { _channel_disfee = value; }
        }
        private string _merchant_disfee;
        public string merchant_disfee
        {
            get { return _merchant_disfee; }
            set { _merchant_disfee = value; }
        }
        private string _order_disfee;
        public string order_disfee
        {
            get { return _order_disfee; }
            set { _order_disfee = value; }
        }
        private string _commission_fee;
        public string commission_fee
        {
            get { return _commission_fee; }
            set { _commission_fee = value; }
        }
        private string _is_cod;
        public string is_cod
        {
            get { return _is_cod; }
            set { _is_cod = value; }
        }
        private string _point_pay;
        public string point_pay
        {
            get { return _point_pay; }
            set { _point_pay = value; }
        }
        private string _cost_point;
        public string cost_point
        {
            get { return _cost_point; }
            set { _cost_point = value; }
        }
        private string _point;
        public string point
        {
            get { return _point; }
            set { _point = value; }
        }
        private string _superior_point;
        public string superior_point
        {
            get { return _superior_point; }
            set { _superior_point = value; }
        }
        private string _royalty_fee;
        public string royalty_fee
        {
            get { return _royalty_fee; }
            set { _royalty_fee = value; }
        }
        private string _external_point;
        public string external_point
        {
            get { return _external_point; }
            set { _external_point = value; }
        }
        private string _express_no;
        public string express_no
        {
            get { return _express_no; }
            set { _express_no = value; }
        }
        private string _express;
        public string express
        {
            get { return _express; }
            set { _express = value; }
        }
        private string _express_coding;
        public string express_coding
        {
            get { return _express_coding; }
            set { _express_coding = value; }
        }
        private string _online_express;
        public string online_express
        {
            get { return _online_express; }
            set { _online_express = value; }
        }
        private string _sending_type;
        public string sending_type
        {
            get { return _sending_type; }
            set { _sending_type = value; }
        }
        private string _real_income_freight;
        public string real_income_freight
        {
            get { return _real_income_freight; }
            set { _real_income_freight = value; }
        }
        private string _real_pay_freight;
        public string real_pay_freight
        {
            get { return _real_pay_freight; }
            set { _real_pay_freight = value; }
        }
        private string _gross_weight;
        public string gross_weight
        {
            get { return _gross_weight; }
            set { _gross_weight = value; }
        }
        private string _gross_weight_freight;
        public string gross_weight_freight
        {
            get { return _gross_weight_freight; }
            set { _gross_weight_freight = value; }
        }
        private string _net_weight_freight;
        public string net_weight_freight
        {
            get { return _net_weight_freight; }
            set { _net_weight_freight = value; }
        }
        private string _freight_explain;
        public string freight_explain
        {
            get { return _freight_explain; }
            set { _freight_explain = value; }
        }
        private string _total_weight;
        public string total_weight
        {
            get { return _total_weight; }
            set { _total_weight = value; }
        }
        private string _tid_net_weight;
        public string tid_net_weight
        {
            get { return _tid_net_weight; }
            set { _tid_net_weight = value; }
        }
        private string _tid_time;
        public string tid_time
        {
            get { return _tid_time; }
            set { _tid_time = value; }
        }
        private string _pay_time;
        public string pay_time
        {
            get { return _pay_time; }
            set { _pay_time = value; }
        }
        private string _get_time;
        public string get_time
        {
            get { return _get_time; }
            set { _get_time = value; }
        }
        private string _order_creater;
        public string order_creater
        {
            get { return _order_creater; }
            set { _order_creater = value; }
        }
        private string _business_man;
        public string business_man
        {
            get { return _business_man; }
            set { _business_man = value; }
        }
        private string _payment_received_operator;
        public string payment_received_operator
        {
            get { return _payment_received_operator; }
            set { _payment_received_operator = value; }
        }
        private string _payment_received_time;
        public string payment_received_time
        {
            get { return _payment_received_time; }
            set { _payment_received_time = value; }
        }
        private string _review_orders_operator;
        public string review_orders_operator
        {
            get { return _review_orders_operator; }
            set { _review_orders_operator = value; }
        }
        private string _review_orders_time;
        public string review_orders_time
        {
            get { return _review_orders_time; }
            set { _review_orders_time = value; }
        }
        private string _finance_review_operator;
        public string finance_review_operator
        {
            get { return _finance_review_operator; }
            set { _finance_review_operator = value; }
        }
        private string _finance_review_time;
        public string finance_review_time
        {
            get { return _finance_review_time; }
            set { _finance_review_time = value; }
        }
        private string _advance_printer;
        public string advance_printer
        {
            get { return _advance_printer; }
            set { _advance_printer = value; }
        }
        private string _printer;
        public string printer
        {
            get { return _printer; }
            set { _printer = value; }
        }
        private string _print_time;
        public string print_time
        {
            get { return _print_time; }
            set { _print_time = value; }
        }
        private string _is_print;
        public string is_print
        {
            get { return _is_print; }
            set { _is_print = value; }
        }
        private string _adv_distributer;
        public string adv_distributer
        {
            get { return _adv_distributer; }
            set { _adv_distributer = value; }
        }
        private string _adv_distribut_time;
        public string adv_distribut_time
        {
            get { return _adv_distribut_time; }
            set { _adv_distribut_time = value; }
        }
        private string _distributer;
        public string distributer
        {
            get { return _distributer; }
            set { _distributer = value; }
        }
        private string _distribut_time;
        public string distribut_time
        {
            get { return _distribut_time; }
            set { _distribut_time = value; }
        }
        private string _is_inspection;
        public string is_inspection
        {
            get { return _is_inspection; }
            set { _is_inspection = value; }
        }
        private string _inspecter;
        public string inspecter
        {
            get { return _inspecter; }
            set { _inspecter = value; }
        }
        private string _inspect_time;
        public string inspect_time
        {
            get { return _inspect_time; }
            set { _inspect_time = value; }
        }
        private string _cancel_operator;
        public string cancel_operator
        {
            get { return _cancel_operator; }
            set { _cancel_operator = value; }
        }
        private string _cancel_time;
        public string cancel_time
        {
            get { return _cancel_time; }
            set { _cancel_time = value; }
        }
        private string _revoke_cancel_er;
        public string revoke_cancel_er
        {
            get { return _revoke_cancel_er; }
            set { _revoke_cancel_er = value; }
        }
        private string _revoke_cancel_time;
        public string revoke_cancel_time
        {
            get { return _revoke_cancel_time; }
            set { _revoke_cancel_time = value; }
        }
        private string _packager;
        public string packager
        {
            get { return _packager; }
            set { _packager = value; }
        }
        private string _pack_time;
        public string pack_time
        {
            get { return _pack_time; }
            set { _pack_time = value; }
        }
        private string _weigh_operator;
        public string weigh_operator
        {
            get { return _weigh_operator; }
            set { _weigh_operator = value; }
        }
        private string _weigh_time;
        public string weigh_time
        {
            get { return _weigh_time; }
            set { _weigh_time = value; }
        }
        private string _book_delivery_time;
        public string book_delivery_time
        {
            get { return _book_delivery_time; }
            set { _book_delivery_time = value; }
        }
        private string _delivery_operator;
        public string delivery_operator
        {
            get { return _delivery_operator; }
            set { _delivery_operator = value; }
        }
        private string _delivery_time;
        public string delivery_time
        {
            get { return _delivery_time; }
            set { _delivery_time = value; }
        }
        private string _locker;
        public string locker
        {
            get { return _locker; }
            set { _locker = value; }
        }
        private string _lock_time;
        public string lock_time
        {
            get { return _lock_time; }
            set { _lock_time = value; }
        }
        private string _book_file_time;
        public string book_file_time
        {
            get { return _book_file_time; }
            set { _book_file_time = value; }
        }
        private string _file_operator;
        public string file_operator
        {
            get { return _file_operator; }
            set { _file_operator = value; }
        }
        private string _file_time;
        public string file_time
        {
            get { return _file_time; }
            set { _file_time = value; }
        }
        private string _finish_time;
        public string finish_time
        {
            get { return _finish_time; }
            set { _finish_time = value; }
        }
        private string _modity_time;
        public string modity_time
        {
            get { return _modity_time; }
            set { _modity_time = value; }
        }
        private string _is_promotion;
        public string is_promotion
        {
            get { return _is_promotion; }
            set { _is_promotion = value; }
        }
        private string _promotion_plan;
        public string promotion_plan
        {
            get { return _promotion_plan; }
            set { _promotion_plan = value; }
        }
        private string _out_promotion_detail;
        public string out_promotion_detail
        {
            get { return _out_promotion_detail; }
            set { _out_promotion_detail = value; }
        }
        private string _good_receive_time;
        public string good_receive_time
        {
            get { return _good_receive_time; }
            set { _good_receive_time = value; }
        }
        private string _receive_time;
        public string receive_time
        {
            get { return _receive_time; }
            set { _receive_time = value; }
        }
        private string _verificaty_time;
        public string verificaty_time
        {
            get { return _verificaty_time; }
            set { _verificaty_time = value; }
        }
        private string _enable_inte_sto_time;
        public string enable_inte_sto_time
        {
            get { return _enable_inte_sto_time; }
            set { _enable_inte_sto_time = value; }
        }
        private string _enable_inte_delivery_time;
        public string enable_inte_delivery_time
        {
            get { return _enable_inte_delivery_time; }
            set { _enable_inte_delivery_time = value; }
        }
        private string _alipay_id;
        public string alipay_id
        {
            get { return _alipay_id; }
            set { _alipay_id = value; }
        }
        private string _alipay_status;
        public string alipay_status
        {
            get { return _alipay_status; }
            set { _alipay_status = value; }
        }
        private string _pay_mothed;
        public string pay_mothed
        {
            get { return _pay_mothed; }
            set { _pay_mothed = value; }
        }
        private string _pay_status;
        public string pay_status
        {
            get { return _pay_status; }
            set { _pay_status = value; }
        }
        private string _platform_status;
        public string platform_status
        {
            get { return _platform_status; }
            set { _platform_status = value; }
        }
        private string _rate;
        public string rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        private string _currency;
        public string currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        private string _delivery_status;
        public string delivery_status
        {
            get { return _delivery_status; }
            set { _delivery_status = value; }
        }
        private string _buyer_message;
        public string buyer_message
        {
            get { return _buyer_message; }
            set { _buyer_message = value; }
        }
        private string _service_remarks;
        public string service_remarks
        {
            get { return _service_remarks; }
            set { _service_remarks = value; }
        }
        private string _inner_lable;
        public string inner_lable
        {
            get { return _inner_lable; }
            set { _inner_lable = value; }
        }
        private string _distributor_mark;
        public string distributor_mark
        {
            get { return _distributor_mark; }
            set { _distributor_mark = value; }
        }
        private string _system_remarks;
        public string system_remarks
        {
            get { return _system_remarks; }
            set { _system_remarks = value; }
        }
        private string _other_remarks;
        public string other_remarks
        {
            get { return _other_remarks; }
            set { _other_remarks = value; }
        }
        private string _message;
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _message_time;
        public string message_time
        {
            get { return _message_time; }
            set { _message_time = value; }
        }
        private string _is_stock;
        public string is_stock
        {
            get { return _is_stock; }
            set { _is_stock = value; }
        }
        private string _related_orders;
        public string related_orders
        {
            get { return _related_orders; }
            set { _related_orders = value; }
        }
        private string _related_orders_type;
        public string related_orders_type
        {
            get { return _related_orders_type; }
            set { _related_orders_type = value; }
        }
        private string _import_mark;
        public string import_mark
        {
            get { return _import_mark; }
            set { _import_mark = value; }
        }
        private string _delivery_name;
        public string delivery_name
        {
            get { return _delivery_name; }
            set { _delivery_name = value; }
        }
        private string _is_new_customer;
        public string is_new_customer
        {
            get { return _is_new_customer; }
            set { _is_new_customer = value; }
        }
        private string _distributor_level;
        public string distributor_level
        {
            get { return _distributor_level; }
            set { _distributor_level = value; }
        }
        private string _cod_service_fee;
        public string cod_service_fee
        {
            get { return _cod_service_fee; }
            set { _cod_service_fee = value; }
        }
        private string _express_col_fee;
        public string express_col_fee
        {
            get { return _express_col_fee; }
            set { _express_col_fee = value; }
        }
        private string _product_num;
        public string product_num
        {
            get { return _product_num; }
            set { _product_num = value; }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        private string _item_num;
        public string item_num
        {
            get { return _item_num; }
            set { _item_num = value; }
        }
        private string _single_num;
        public string single_num
        {
            get { return _single_num; }
            set { _single_num = value; }
        }
        private string _flag_color;
        public string flag_color
        {
            get { return _flag_color; }
            set { _flag_color = value; }
        }
        private string _is_flag;
        public string is_flag
        {
            get { return _is_flag; }
            set { _is_flag = value; }
        }
        private string _taobao_delivery_order_status;
        public string taobao_delivery_order_status
        {
            get { return _taobao_delivery_order_status; }
            set { _taobao_delivery_order_status = value; }
        }
        private string _taobao_delivery_status;
        public string taobao_delivery_status
        {
            get { return _taobao_delivery_status; }
            set { _taobao_delivery_status = value; }
        }
        private string _taobao_delivery_method;
        public string taobao_delivery_method
        {
            get { return _taobao_delivery_method; }
            set { _taobao_delivery_method = value; }
        }
        private string _order_process_time;
        public string order_process_time
        {
            get { return _order_process_time; }
            set { _order_process_time = value; }
        }
        private string _is_break;
        public string is_break
        {
            get { return _is_break; }
            set { _is_break = value; }
        }
        private string _breaker;
        public string breaker
        {
            get { return _breaker; }
            set { _breaker = value; }
        }
        private string _break_time;
        public string break_time
        {
            get { return _break_time; }
            set { _break_time = value; }
        }
        private string _break_explain;
        public string break_explain
        {
            get { return _break_explain; }
            set { _break_explain = value; }
        }
        private string _plat_send_status;
        public string plat_send_status
        {
            get { return _plat_send_status; }
            set { _plat_send_status = value; }
        }
        private string _plat_type;
        public string plat_type
        {
            get { return _plat_type; }
            set { _plat_type = value; }
        }
        private string _is_adv_sale;
        public string is_adv_sale
        {
            get { return _is_adv_sale; }
            set { _is_adv_sale = value; }
        }
        private string _provinc_code;
        public string provinc_code
        {
            get { return _provinc_code; }
            set { _provinc_code = value; }
        }
        private string _city_code;
        public string city_code
        {
            get { return _city_code; }
            set { _city_code = value; }
        }
        private string _area_code;
        public string area_code
        {
            get { return _area_code; }
            set { _area_code = value; }
        }
        private string _express_code;
        public string express_code
        {
            get { return _express_code; }
            set { _express_code = value; }
        }
        private string _last_returned_time;
        public string last_returned_time
        {
            get { return _last_returned_time; }
            set { _last_returned_time = value; }
        }
        private string _last_refund_time;
        public string last_refund_time
        {
            get { return _last_refund_time; }
            set { _last_refund_time = value; }
        }
        private string _deliver_centre;
        public string deliver_centre
        {
            get { return _deliver_centre; }
            set { _deliver_centre = value; }
        }
        private string _deliver_station;
        public string deliver_station
        {
            get { return _deliver_station; }
            set { _deliver_station = value; }
        }
        private string _is_pre_delivery_notice;
        public string is_pre_delivery_notice
        {
            get { return _is_pre_delivery_notice; }
            set { _is_pre_delivery_notice = value; }
        }
        private string _jd_delivery_time;
        public string jd_delivery_time
        {
            get { return _jd_delivery_time; }
            set { _jd_delivery_time = value; }
        }
        private string _Sorting_code;
        public string Sorting_code
        {
            get { return _Sorting_code; }
            set { _Sorting_code = value; }
        }
        private string _cod_settlement_vouchernumber;
        public string cod_settlement_vouchernumber
        {
            get { return _cod_settlement_vouchernumber; }
            set { _cod_settlement_vouchernumber = value; }
        }
        private string _three_codes;
        public string three_codes
        {
            get { return _three_codes; }
            set { _three_codes = value; }
        }
        private string _send_site_name;
        public string send_site_name
        {
            get { return _send_site_name; }
            set { _send_site_name = value; }
        }
        private string _distributing_centre_name;
        public string distributing_centre_name
        {
            get { return _distributing_centre_name; }
            set { _distributing_centre_name = value; }
        }
        private string _total_num;
        public string total_num
        {
            get { return _total_num; }
            set { _total_num = value; }
        }
        private string _originCode;
        public string originCode
        {
            get { return _originCode; }
            set { _originCode = value; }
        }
        private string _destCode;
        public string destCode
        {
            get { return _destCode; }
            set { _destCode = value; }
        }
        private string _big_marker;
        public string big_marker
        {
            get { return _big_marker; }
            set { _big_marker = value; }
        }
        private string _platform_preferential;
        public string platform_preferential
        {
            get { return _platform_preferential; }
            set { _platform_preferential = value; }
        }
        private string _总数量;
        public string 总数量
        {
            get { return _总数量; }
            set { _总数量 = value; }
        }
        private List<tid_item> _tid_item;
        public List<tid_item> tid_item {
            get { return _tid_item; }
            set { _tid_item = value; }
        }
    }
    
}
