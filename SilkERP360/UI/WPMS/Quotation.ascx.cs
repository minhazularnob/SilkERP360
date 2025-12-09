using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.WPMS
{
    public partial class Quotation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
            BuyerCode(lcl_obj_SqlFacade);
            ItemsCatagoryCode(lcl_obj_SqlFacade);
            HDPEPriceLoad(lcl_obj_SqlFacade);
            LLDPEPriceLoad(lcl_obj_SqlFacade);
            COCOPriceLoad(lcl_obj_SqlFacade);
            LDPEPriceLoad(lcl_obj_SqlFacade);
            D2EPriceLoad(lcl_obj_SqlFacade);
            RecylePriceLoad(lcl_obj_SqlFacade);
            InkGeraniumPriceLoad(lcl_obj_SqlFacade);
            ThinnerPriceLoad(lcl_obj_SqlFacade);
            EPIPriceLoad(lcl_obj_SqlFacade);
            MasterBatchWhitePriceLoad(lcl_obj_SqlFacade);
            MasterBatchGreenPriceLoad(lcl_obj_SqlFacade);
            MasterBatchRedPriceLoad(lcl_obj_SqlFacade);
            MasterBatchBluePriceLoad(lcl_obj_SqlFacade);
            MasterBatchYellowPriceLoad(lcl_obj_SqlFacade);
            MasterBatchLoryPriceLoad(lcl_obj_SqlFacade);
            MasterBatchBeigePriceLoad(lcl_obj_SqlFacade);
            MasterBatchBurgendyPriceLoad(lcl_obj_SqlFacade);
            MasterBatchLemonGrassPriceLoad(lcl_obj_SqlFacade);
            MasterBatchBlackPriceLoad(lcl_obj_SqlFacade);
            MasterBatchOrangePriceLoad(lcl_obj_SqlFacade);
            MasterBatchPinkPriceLoad(lcl_obj_SqlFacade);
            InkLemonYellowPriceLoad(lcl_obj_SqlFacade);
            InkMidYellowPriceLoad(lcl_obj_SqlFacade);
            InkWhiteLoad(lcl_obj_SqlFacade);
            InkMolybDateOrangeLoad(lcl_obj_SqlFacade);
            InkPeacockBlueLoad(lcl_obj_SqlFacade);
            InkBluePriceLoad(lcl_obj_SqlFacade);
            InkRoyalBluePriceLoad(lcl_obj_SqlFacade);
            InkAjinomotoRedLoad(lcl_obj_SqlFacade);
            InkReflexBlueCLoad(lcl_obj_SqlFacade);
            InkSilverLoad(lcl_obj_SqlFacade);
            InkGreenLoad(lcl_obj_SqlFacade);
            InkGrassGreenLoad(lcl_obj_SqlFacade);
            InkBlackLoad(lcl_obj_SqlFacade);
            InkAntiSlipLoad(lcl_obj_SqlFacade);
    
        }

        void BuyerCode(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

           
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME from WPMS_BUYER", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_Reader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_Reader["BUYER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_Reader["COMPANY_NAME"].ToString();
                this.ddlBuyer.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            IP_obj_SqlFacade.CloseReader();

        }


        void ItemsCatagoryCode(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select ITEM_CATAGORY_CODE,CATAGORY_NAME from WPMS_ITEM_CATAGORY", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_Reader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_Reader["ITEM_CATAGORY_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_Reader["CATAGORY_NAME"].ToString();
                this.ddlCatagory.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_Reader.Close();

        }

        private void HDPEPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010001)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtHDPE_NPQ_Standard_Price.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }
        private void LLDPEPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010002)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtLLDPE_NPQ_Standard_Price.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void COCOPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010003)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txt_coco2.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void LDPEPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010004)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                TextBox6.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }
        private void D2EPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010008)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtD2W_NPQ_StandardPrice.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void EPIPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010009)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtEPI_NPQ_Standard_Price.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchWhitePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010010)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtMWPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchBluePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010011)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtBluePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchRedPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010012)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtRedPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchGreenPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010013)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtGreenPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchYellowPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010014)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtyellowPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }
        private void MasterBatchLoryPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010015)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtLoryPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchBeigePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010016)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtBeigePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchPinkPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010017)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtPinkPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchBurgendyPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010018)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtbgendyPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchLemonGrassPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {

            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010019)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtLgrassPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchBlackPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010020)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                BlackPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void MasterBatchOrangePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010021)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtOrangePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkLemonYellowPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010023)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtlyellowPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkMidYellowPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010024)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtmyellowPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkRoyalBluePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010025)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtRBluePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkBluePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010026)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkBluePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkPeacockBlueLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010027)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkpbluePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkMolybDateOrangeLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010028)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtmdorangePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkWhiteLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010029)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkWhitePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkGreenLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010030)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkgreenPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkGrassGreenLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010031)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkggreenPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkBlackLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010032)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkBlackPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkAjinomotoRedLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010033)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtAMRedPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkReflexBlueCLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010034)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtRFBluePr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkSilverLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010035)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtInkSilverPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkAntiSlipLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010006)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                EntiSlippr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void RecylePriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010005)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtPunchOut_NPQ_Standard_Price.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void InkGeraniumPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010022)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                txtgeraniumPr.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }

        private void ThinnerPriceLoad(SilkERP360.FL.SqlFacade IP_obj_SqlFacade)
        {
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010007)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = IP_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_Reader.Read())
            {
                TextBox3.Text = lcl_obj_Reader["PRICE_M_TON"].ToString();
            }
            lcl_obj_Reader.Close();
        }
    }
}