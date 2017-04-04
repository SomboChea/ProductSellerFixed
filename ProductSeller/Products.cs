using System.Windows.Forms;

namespace ProductSeller
{
    class Products
    {
        private int _id;
        private string _pname;
        private int _qty;
        private double _uprice;

        public int Id
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

        public string Pname
        {
            get
            {
                return _pname;
            }

            set
            {
                _pname = value;
            }
        }

        public int Qty
        {
            get
            {
                return _qty;
            }

            set
            {
                _qty = value;
            }
        }

        public double Uprice
        {
            get
            {
                return _uprice;
            }

            set
            {
                _uprice = value;
            }
        }

        public double Amount()
        {
            return Qty * Uprice;
        }

        public Products()
        {

        }

        public Products(int id, string pname, int qty, double uprice)
        {
            Id = id;
            Pname = pname;
            Qty = qty;
            Uprice = uprice;
        }

        public ListViewItem item()
        {
            string[] data = { Id.ToString("000"),Pname,Qty+"",Uprice.ToString("$#,##0.00"),Amount().ToString("$#,##0.00") };
            return new ListViewItem(data);
        }
    }
}
