﻿using System;
using System.Windows.Forms;

namespace ProductSeller
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //Closed form when exit an application
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Load Data from List
            if(Data.List.Count > 0)
            {
                foreach(Products temp in Data.List)
                {
                    ListViewMain.Items.Add(temp.item());
                    Data.GetLastId = temp.Id;
                }
            }
            else
            {
                Data.GetLastId = 0;
                Data.Id = 1;
            }

            //Check ID and correct it
            if (Data.Id == Data.GetLastId)
                Data.Id++;
            else
                Data.Id = Data.GetLastId + 1;

            TxtID.Text = Data.Id + "";

            //Check Temp data;
            if(Data.Check_temp)
            {
                TxtPname.Text = Data.Temp_pname;
                TxtQty.Text = Data.Temp_qty;
                TxtUprice.Text = Data.Temp_uprice;
            }
            
        }

        //Button add data to list
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int id = Data.Id;
            string pname = TxtPname.Text.Trim();
            int qty = int.Parse(TxtQty.Text);
            double uprice = double.Parse(TxtUprice.Text);

            Products p = new Products(id, pname, qty, uprice);

            //Add data to list and ListView
            Data.List.Add(p);
            ListViewMain.Items.Add(p.item());

            Data.Id++;
            TxtID.Text = Data.Id + "";

            Clear();
        }

        //Clear data from textbox
        private void Clear()
        {
            TxtPname.Clear();
            TxtQty.Clear();
            TxtUprice.Clear();
        }

        //Button view products and actions
        private void BtnView_Click(object sender, EventArgs e)
        {
            //Check if have data in textbox store it, when load view products
            if(TxtPname.Text.Trim()!="" || TxtQty.Text.Trim()!="" || TxtUprice.Text.Trim() != "")
            {
                Data.Temp_pname = TxtPname.Text.Trim();
                Data.Temp_qty = TxtQty.Text.Trim();
                Data.Temp_uprice = TxtUprice.Text.Trim();
                Data.Check_temp = true;
            }
            else
            {
                Data.Temp_pname = "";
                Data.Temp_qty = "";
                Data.Temp_uprice = "";
                Data.Check_temp = false;
            }

            //Load View Products and hide Main
            Hide();
            new ViewProducts().Show();
        }

        //Defined for check error when typing to textbox data
        bool lb1 = false;
        bool lb2 = false;
        bool lb3 = false;

        //TxtPname textbox when has an action
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

        //TxtQty textbox when has an action
        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if(TxtQty.Text.Trim()!="")
            {
                try
                {
                    int Qty = int.Parse(TxtQty.Text);
                    if(Qty > 0)
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

        //TxtUprice textbox when has an action
        private void TxtUprice_TextChanged(object sender, EventArgs e)
        {
            if(TxtUprice.Text.Trim()!="")
            {
                try
                {
                    double price = double.Parse(TxtUprice.Text);
                    if(price > 0)
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

        //Defined for error label 2 of Qty
        private void err_lb2()
        {
            lb2 = false;
            lbReq2.Text = "*";
            Add_Enable();
        }

        //Defined for error label 2 of Uprice
        private void err_lb3()
        {
            lb3 = false;
            lbReq3.Text = "*";
            Add_Enable();
        }

        //Defined for Enable Add button and Disable
        private void Add_Enable()
        {
            if(lb1 && lb2 && lb3)
                BtnAdd.Enabled = true;
            else
                BtnAdd.Enabled = false;
        }

    }
}
