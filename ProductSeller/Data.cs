using System;
using System.Collections.Generic;

namespace ProductSeller
{
    static class Data
    {
        private static List<Products> _list = new List<Products>();
        private static int _id;
        private static int _getLastId;
        private static string _temp_pname;
        private static string _temp_qty;
        private static string _temp_uprice;
        private static bool check_temp = false;

        internal static List<Products> List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
            }
        }

        public static int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public static int GetLastId
        {
            get
            {
                return _getLastId;
            }

            set
            {
                _getLastId = value;
            }
        }
        
        public static string Temp_pname
        {
            get
            {
                return _temp_pname;
            }

            set
            {
                _temp_pname = value;
            }
        }

        public static string Temp_qty
        {
            get
            {
                return _temp_qty;
            }

            set
            {
                _temp_qty = value;
            }
        }

        public static string Temp_uprice
        {
            get
            {
                return _temp_uprice;
            }

            set
            {
                _temp_uprice = value;
            }
        }

        public static bool Check_temp
        {
            get
            {
                return check_temp;
            }

            set
            {
                check_temp = value;
            }
        }

        //Converter
        public static double PriceToDouble(string uprice)
        {
            double real_price = 0;
            string[] hack_text = uprice.Split('$');
            string data = "";
            foreach (string temp in hack_text)
            {
                if (temp == "$")
                    continue;
                else
                    data += temp;
            }
            try
            {
                real_price = double.Parse(data);
            }
            catch (Exception)
            {
                return real_price = 0;
            }

            return real_price;
        }
        
    }
}
