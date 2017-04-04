using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductSeller
{
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
        }

        private void ViewProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            if(Data.List.Count > 0)
            {
                foreach (Products temp in Data.List)
                    ListViewProduct.Items.Add(temp.item());
            }
        }

        ListViewItem item_selected;
        private void ListViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ListViewProduct.SelectedItems.Count == 0)
            {
                Clear();
                Disable();

                return;
            }

            item_selected = ListViewProduct.SelectedItems[0];
            TxtID.Text = item_selected.Text;
            TxtPname.Text = item_selected.SubItems[1].Text;
            TxtQty.Text = item_selected.SubItems[2].Text;
            TxtUprice.Text = Data.PriceToDouble(item_selected.SubItems[3].Text)+"";

            Enable();

        }

        private void Clear()
        {
            TxtID.Clear();
            TxtPname.Clear();
            TxtQty.Clear();
            TxtUprice.Clear();
        }

        private void Disable()
        {
            TxtPname.Enabled = false;
            TxtQty.Enabled = false;
            TxtUprice.Enabled = false;
        }

        private void Enable()
        {
            TxtPname.Enabled = true;
            TxtQty.Enabled = true;
            TxtUprice.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (ListViewProduct.SelectedItems.Count > 0)
                index = ListViewProduct.Items.IndexOf(ListViewProduct.SelectedItems[0]);

            int id = int.Parse(TxtID.Text);
            string pname = TxtPname.Text;
            int qty = int.Parse(TxtQty.Text);
            double uprice = Data.PriceToDouble(TxtUprice.Text);

            Products p = new Products(id, pname, qty, uprice);

            if(index !=-1)
            {
                Data.List[index] = p;
                ListViewProduct.Items.RemoveAt(index);
                ListViewProduct.Items.Insert(index, p.item());
            }

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem temp in ListViewProduct.SelectedItems)
            {
                Data.List.RemoveAt(temp.Index);
                ListViewProduct.Items.Remove(temp);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new Main().Show();
        }

        bool lb1 = false;
        bool lb2 = false;
        bool lb3 = false;
        bool check_update = false;

        private void TxtPname_TextChanged(object sender, EventArgs e)
        {
            if (TxtPname.Text.Trim() != "")
            {
                lb1 = true;
                lbReq1.Text = "";
                Add_Enable();
            }
            else
            {
                lb1 = false;
                lbReq1.Text = "*";
                Add_Enable();
            }

        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if (TxtQty.Text.Trim() != "")
            {
                try
                {
                    int Qty = int.Parse(TxtQty.Text);
                    if (Qty > 0)
                    {
                        lb2 = true;
                        lbReq2.Text = "";
                        Add_Enable();
                    }
                    else
                    {
                        err_lb2();
                    }

                }
                catch (Exception)
                {
                    err_lb2();
                }
            }
            else
            {
                err_lb2();
            }
        }

        private void TxtUprice_TextChanged(object sender, EventArgs e)
        {
            if (TxtUprice.Text.Trim() != "")
            {
                try
                {
                    double price = double.Parse(TxtUprice.Text);
                    if (price > 0)
                    {
                        lb3 = true;
                        lbReq3.Text = "";
                        Add_Enable();
                    }
                    else
                    {
                        err_lb3();
                    }
                }
                catch (Exception)
                {
                    err_lb3();
                }
            }
            else
            {
                err_lb3();
            }
        }

        private void err_lb2()
        {
            lb2 = false;
            lbReq2.Text = "*";
            Add_Enable();
        }

        private void err_lb3()
        {
            lb3 = false;
            lbReq3.Text = "*";
            Add_Enable();
        }

        private void Add_Enable()
        {
            if (lb1 && lb2 && lb3)
            {
                if(TxtPname.Text.Trim() == item_selected.SubItems[1].Text &&
                   TxtQty.Text.Trim() == item_selected.SubItems[2].Text &&
                   TxtUprice.Text.Trim() == Data.PriceToDouble(item_selected.SubItems[3].Text)+"")
                {
                    BtnUpdate.Enabled = false;
                    BtnDel.Enabled = true;
                }
                else
                {
                    BtnUpdate.Enabled = true;
                    BtnDel.Enabled = false;
                }
            }
            else
            {
                BtnUpdate.Enabled = false;
                BtnDel.Enabled = false;
            }
        }
    }
}
