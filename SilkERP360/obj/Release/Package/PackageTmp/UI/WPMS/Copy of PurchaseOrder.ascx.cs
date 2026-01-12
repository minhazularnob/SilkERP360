using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.WPMS
{
    public partial class PurchaseOrder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPOQuotationCode();
            BuyerCode();
            ItemsCatagoryCode();
            InkAntiSlipLoadPO();//c
            InkBlackLoadPO();//c
            InkGrassGreenLoadPO();//c
            InkGreenLoadPO();//c
            InkSilverLoadPO();//c
            InkReflexBlueCLoadPO();//c
            InkAjinomotoRedLoadPO();//c
            InkRoyalBluePriceLoadPO();//
            InkBluePriceLoadPO();//
            InkPeacockBlueLoadPO();//
            InkMolybDateOrangeLoadPO();//
            HDPEPriceLoadPO();//
            LLDPEPriceLoadPO();//
            COCOPriceLoadPO();//
            LDPEPriceLoadPO();//
            D2EPriceLoadPO();//
            RecylePriceLoadPO();//
            InkGeraniumPriceLoadPO();//
            ThinnerPriceLoadPO();//
            EPIPriceLoadPO();//
            MasterBatchWhitePriceLoadPO();//
            MasterBatchGreenPriceLoadPO();//
            MasterBatchRedPriceLoadPO();//
            MasterBatchBluePriceLoadPO();//
            MasterBatchYellowPriceLoadPO();//
            MasterBatchLoryPriceLoadPO();//
            MasterBatchBeigePriceLoadPO();//
            MasterBatchBurgendyPriceLoadPO();//
            MasterBatchLemonGrassPriceLoadPO();//
            MasterBatchBlackPriceLoadPO();//
            MasterBatchOrangePriceLoadPO();//
            MasterBatchPinkPriceLoadPO();//
            InkLemonYellowPriceLoadPO();//
            InkMidYellowPriceLoadPO();//
            InkWhiteLoadPO();//
        }

        void ShowPOQuotationCode()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryProduct = System.String.Empty;
            lcl_str_SqlQueryProduct = System.String.Format("Select QUOTATION_M_CODE From WPMS_QUOTATION_M order by QUOTATION_M_CODE desc", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_ProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryProduct);
            System.Int32 lcl_i32_K = 1;
            while (lcl_obj_ProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_ProductReader["QUOTATION_M_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_ProductReader["QUOTATION_M_CODE"].ToString();
                this.ddlCustomerName2.Items.Insert(lcl_i32_K++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();

        }

        void BuyerCode()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME from WPMS_BUYER", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_FinishedProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["BUYER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["COMPANY_NAME"].ToString();
                this.ddlBuyer.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();
        }

        private void InkAntiSlipLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010006)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                EntiSlippr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkSilverLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010035)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkSilverPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }
        private void InkReflexBlueCLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010034)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtRFBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }
        private void InkAjinomotoRedLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010033)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtAMRedPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkBlackLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010032)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkBlackPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkGrassGreenLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010031)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkggreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkGreenLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010030)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkgreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkWhiteLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010029)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkWhitePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkMolybDateOrangeLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010028)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtmdorangePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkPeacockBlueLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010027)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkpbluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkBluePriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010026)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtInkBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkRoyalBluePriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010025)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtRBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkMidYellowPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010024)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtmyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkLemonYellowPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010023)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtlyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchOrangePriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010021)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtOrangePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchBlackPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010020)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                BlackPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchLemonGrassPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010019)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtLgrassPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchBurgendyPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010018)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtbgendyPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchPinkPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010017)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtPinkPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchBeigePriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010016)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtBeigePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchLoryPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010015)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtLoryPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchYellowPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010014)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchGreenPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010013)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtGreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchRedPriceLoadPO()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010012)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtRedPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchBluePriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010011)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void MasterBatchWhitePriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010010)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtMWPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void EPIPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010009)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtEPI_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void D2EPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010008)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtD2W_NPQ_StandardPrice0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void ThinnerPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010007)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                TextBox81.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void InkGeraniumPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010022)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtgeraniumPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void RecylePriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010005)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtPunchOut_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void LDPEPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010004)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                TextBox52.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void COCOPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010003)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txt_coco5.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void LLDPEPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010002)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtLLDPE_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        private void HDPEPriceLoadPO()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryHDPE = System.String.Empty;
            lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010001)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

            while (lcl_obj_WorkGroupReader.Read())
            {
                txtHDPE_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
            }
            lcl_obj_SqlFacade.Close();
        }

        void ItemsCatagoryCode()
        {

            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select ITEM_CATAGORY_CODE,CATAGORY_NAME from WPMS_ITEM_CATAGORY", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            System.Data.OracleClient.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_FinishedProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["ITEM_CATAGORY_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["CATAGORY_NAME"].ToString();
                this.ddlCatagory.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();

        }
    }
}