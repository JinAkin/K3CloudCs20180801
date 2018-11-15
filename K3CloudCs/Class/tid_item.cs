using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K3CloudCs
{
    public class tid_item
    {
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
        private string _pro_detail_code;
        public string pro_detail_code
        {
            get { return _pro_detail_code; }
            set { _pro_detail_code = value; }
        }
        private string _pro_name;
        public string pro_name
        {
            get { return _pro_name; }
            set { _pro_name = value; }
        }
        private string _specification;
        public string specification
        {
            get { return _specification; }
            set { _specification = value; }
        }
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        private string _combine_barcode;
        public string combine_barcode
        {
            get { return _combine_barcode; }
            set { _combine_barcode = value; }
        }
        private string _iscancel;
        public string iscancel
        {
            get { return _iscancel; }
            set { _iscancel = value; }
        }
        private string _isscheduled;
        public string isscheduled
        {
            get { return _isscheduled; }
            set { _isscheduled = value; }
        }
        private string _stock_situation;
        public string stock_situation
        {
            get { return _stock_situation; }
            set { _stock_situation = value; }
        }
        private string _isbook_pro;
        public string isbook_pro
        {
            get { return _isbook_pro; }
            set { _isbook_pro = value; }
        }
        private string _iscombination;
        public string iscombination
        {
            get { return _iscombination; }
            set { _iscombination = value; }
        }
        private string _isgifts;
        public string isgifts
        {
            get { return _isgifts; }
            set { _isgifts = value; }
        }
        private string _gift_num;
        public string gift_num
        {
            get { return _gift_num; }
            set { _gift_num = value; }
        }
        private string _book_storage;
        public string book_storage
        {
            get { return _book_storage; }
            set { _book_storage = value; }
        }
        private string _pro_num;
        public string pro_num
        {
            get { return _pro_num; }
            set { _pro_num = value; }
        }
        private string _send_num;
        public string send_num
        {
            get { return _send_num; }
            set { _send_num = value; }
        }
        private string _refund_num;
        public string refund_num
        {
            get { return _refund_num; }
            set { _refund_num = value; }
        }
        private string _refund_renum;
        public string refund_renum
        {
            get { return _refund_renum; }
            set { _refund_renum = value; }
        }
        private string _inspection_num;
        public string inspection_num
        {
            get { return _inspection_num; }
            set { _inspection_num = value; }
        }
        private string _timeinventory;
        public string timeinventory
        {
            get { return _timeinventory; }
            set { _timeinventory = value; }
        }
        private string _cost_price;
        public string cost_price
        {
            get { return _cost_price; }
            set { _cost_price = value; }
        }
        private string _sell_price;
        public string sell_price
        {
            get { return _sell_price; }
            set { _sell_price = value; }
        }
        private string _average_price;
        public string average_price
        {
            get { return _average_price; }
            set { _average_price = value; }
        }
        private string _original_price;
        public string original_price
        {
            get { return _original_price; }
            set { _original_price = value; }
        }
        private string _sys_price;
        public string sys_price
        {
            get { return _sys_price; }
            set { _sys_price = value; }
        }
        private string _ferght;
        public string ferght
        {
            get { return _ferght; }
            set { _ferght = value; }
        }
        private string _item_discountfee;
        public string item_discountfee
        {
            get { return _item_discountfee; }
            set { _item_discountfee = value; }
        }
        private string _inspection_time;
        public string inspection_time
        {
            get { return _inspection_time; }
            set { _inspection_time = value; }
        }
        private string _weight;
        public string weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private string _shopid;
        public string shopid
        {
            get { return _shopid; }
            set { _shopid = value; }
        }
        private string _out_tid;
        public string out_tid
        {
            get { return _out_tid; }
            set { _out_tid = value; }
        }
        private string _out_proid;
        public string out_proid
        {
            get { return _out_proid; }
            set { _out_proid = value; }
        }
        private string _out_prosku;
        public string out_prosku
        {
            get { return _out_prosku; }
            set { _out_prosku = value; }
        }
        private string _proexplain;
        public string proexplain
        {
            get { return _proexplain; }
            set { _proexplain = value; }
        }
        private string _buyer_memo;
        public string buyer_memo
        {
            get { return _buyer_memo; }
            set { _buyer_memo = value; }
        }
        private string _seller_remark;
        public string seller_remark
        {
            get { return _seller_remark; }
            set { _seller_remark = value; }
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
        private string _second_barcode;
        public string second_barcode
        {
            get { return _second_barcode; }
            set { _second_barcode = value; }
        }
        private string _product_no;
        public string product_no
        {
            get { return _product_no; }
            set { _product_no = value; }
        }
        private string _brand_number;
        public string brand_number
        {
            get { return _brand_number; }
            set { _brand_number = value; }
        }
        private string _brand_name;
        public string brand_name
        {
            get { return _brand_name; }
            set { _brand_name = value; }
        }
        private string _book_inventory;
        public string book_inventory
        {
            get { return _book_inventory; }
            set { _book_inventory = value; }
        }
        private string _product_specification;
        public string product_specification
        {
            get { return _product_specification; }
            set { _product_specification = value; }
        }
        private string _discount_amount;
        public string discount_amount
        {
            get { return _discount_amount; }
            set { _discount_amount = value; }
        }
        private string _credit_amount;
        public string credit_amount
        {
            get { return _credit_amount; }
            set { _credit_amount = value; }
        }
        private string _MD5_encryption;
        public string MD5_encryption
        {
            get { return _MD5_encryption; }
            set { _MD5_encryption = value; }
        }
        private string _sncode;
        public string sncode
        {
            get { return _sncode; }
            set { _sncode = value; }
        }
        private string _store_location;
        public string store_location
        {
            get { return _store_location; }
            set { _store_location = value; }
        }
        private string _pro_type;
        public string pro_type
        {
            get { return _pro_type; }
            set { _pro_type = value; }
        }

    }
}
