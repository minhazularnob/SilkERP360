using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;
using System.Runtime.InteropServices;
using CrystalDecisions.CrystalReports.Engine;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.UI.WPMS
{
    public partial class GenericUI : System.Web.UI.Page
    {
        
    
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowQuotationCode();
            ShowPOQuotationCode();
            RawPRoductList();
            RawPRoductListforPrint();
            ProductFixedTab();
            FisishedBuyerFixedTab();
            BuyerCodeForPO();
            HDPEPriceLoad();
            LLDPEPriceLoad();
            COCOPriceLoad();
            LDPEPriceLoad();
            D2EPriceLoad();
            RecylePriceLoad();
            InkGeraniumPriceLoad();
            ThinnerPriceLoad();
            EPIPriceLoad();
            MasterBatchWhitePriceLoad();
            MasterBatchGreenPriceLoad();
            MasterBatchRedPriceLoad();
            MasterBatchBluePriceLoad();
            MasterBatchYellowPriceLoad();
            MasterBatchLoryPriceLoad();
            MasterBatchBeigePriceLoad();
            MasterBatchBurgendyPriceLoad();
            MasterBatchLemonGrassPriceLoad();
            MasterBatchBlackPriceLoad();
            MasterBatchOrangePriceLoad();
            MasterBatchPinkPriceLoad();
            InkLemonYellowPriceLoad();
            InkMidYellowPriceLoad();
            InkWhiteLoad();
            InkMolybDateOrangeLoad(); 
            InkPeacockBlueLoad(); 
            InkBluePriceLoad(); 
            InkRoyalBluePriceLoad();
            InkAjinomotoRedLoad();
            InkReflexBlueCLoad();
            InkSilverLoad();
            InkGreenLoad();
            InkGrassGreenLoad(); 
            InkBlackLoad();
            InkAntiSlipLoad();
            ItemCode();

            //For PO
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


            
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME From WPMS_BUYER ", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_CustomerReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_CustomerReader["BUYER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_CustomerReader["COMPANY_NAME"].ToString();
                this.ddlCustomerName.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
                
            }
           
            lcl_obj_SqlFacade.CloseReader();

        }

        void RetrieveBuyer()

        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select DISTINCT BUYER_CODE,COMPANY_NAME From WPMS_BUYER ", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_CustomerReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_CustomerReader["BUYER_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_CustomerReader["COMPANY_NAME"].ToString();
                this.ddlCustomerName.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();
            
        }

        void ShowQuotationCode()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryProduct = System.String.Empty;
            lcl_str_SqlQueryProduct = System.String.Format("Select QUOTATION_M_CODE From WPMS_QUOTATION_M ", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryProduct);
            System.Int32 lcl_i32_K = 1;
            while (lcl_obj_ProductReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_ProductReader["QUOTATION_M_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_ProductReader["QUOTATION_M_CODE"].ToString();
                this.ddlQuotationCode.Items.Insert(lcl_i32_K++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();
        
        }

        //For PO

        void ShowPOQuotationCode()
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryProduct = System.String.Empty;
            lcl_str_SqlQueryProduct = System.String.Format("Select QUOTATION_M_CODE From WPMS_QUOTATION_M order by QUOTATION_M_CODE desc", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryProduct);
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



        protected void ddlCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CusReader = null;
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQueryCustomer = System.String.Empty;
            lcl_str_SqlQueryCustomer = System.String.Format("Select BUYER_CODE,COMPANY_NAME,ADDRESS,CONTACT_PERSON,PHONE,EMAIL From WPMS_BUYER where COMPANY_NAME='" + ddlCustomerName.SelectedItem + "' ", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            lcl_obj_CusReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryCustomer);

            if (!(lcl_obj_CusReader.HasRows))
            {
                throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Data Not Found!!!");
            }
            while (lcl_obj_CusReader.Read())
            {
                txtContactPerson_NPQ.Text = lcl_obj_CusReader["CONTACT_PERSON"].ToString();
                txtAddress.Text = lcl_obj_CusReader["ADDRESS"].ToString();
                txtEmail.Text = lcl_obj_CusReader["EMAIL"].ToString();
            }
            lcl_obj_SqlFacade.CloseReader();
            ddlCustomerName.AppendDataBoundItems = false;

        }
        
        void DuplicateDataClear()
        {

            {
                for (int i = 0; i < ddlCustomerName.Items.Count; i++)
                {
                    ddlCustomerName.SelectedIndex = i;
                    string str = ddlCustomerName.SelectedItem.ToString();
                    for (int counter = i + 1; counter < ddlCustomerName.Items.Count; counter++)
                    {
                        ddlCustomerName.SelectedIndex = counter;
                        string compareStr = ddlCustomerName.SelectedItem.ToString();
                        if (str == compareStr)
                        {
                            ddlCustomerName.Items.RemoveAt(counter);
                            counter = counter - 1;
                        }
                    }
                }
            }
        }

      public void RawPRoductList()

        { 
        
         SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            System.String lcl_str_SqlQuery1 = System.String.Empty;
            lcl_str_SqlQuery1 = System.String.Format("Select RM_CODE,RM_NAME,STATUS FROM WPMS_RAW_PRODUCT Where STATUS=1", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
            //if (!(lcl_obj_CustomerReader.HasRows))
            //{
            //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
            //}
            System.Int32 lcl_i32_j = 1;
            while (lcl_obj_CustomerReader.Read())
            {
                System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
                lcl_obj_EmployeeItem.Value = lcl_obj_CustomerReader["RM_CODE"].ToString();
                lcl_obj_EmployeeItem.Text = lcl_obj_CustomerReader["RM_NAME"].ToString();
                this.ddlProductSelect.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
            }
            lcl_obj_SqlFacade.CloseReader();
 
        }

      public void RawPRoductListforPrint()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQuery1 = System.String.Empty;
          lcl_str_SqlQuery1 = System.String.Format("Select RM_CODE,RM_NAME,STATUS FROM WPMS_RAW_PRODUCT Where STATUS=1", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_CustomerReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
          //if (!(lcl_obj_CustomerReader.HasRows))
          //{
          //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
          //}
          System.Int32 lcl_i32_j = 1;
          while (lcl_obj_CustomerReader.Read())
          {
              System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
              lcl_obj_EmployeeItem.Value = lcl_obj_CustomerReader["RM_CODE"].ToString();
              lcl_obj_EmployeeItem.Text = lcl_obj_CustomerReader["RM_NAME"].ToString();
              this.ddlProductSelect.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
             
          }
          lcl_obj_SqlFacade.CloseReader();

      }
        //...................... Finished Product Insert in Fixed Tab For Relation between Buyer and Finished Product...................

      void ProductFixedTab()

      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQuery1 = System.String.Empty;
          lcl_str_SqlQuery1 = System.String.Format("Select FINISHED_PRODUCT_CODE,FINISHED_PRODUCT_NAME from WPMS_FINISHED_PRODUCT", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
          //if (!(lcl_obj_CustomerReader.HasRows))
          //{
          //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
          //}
          System.Int32 lcl_i32_j = 1;
          while (lcl_obj_FinishedProductReader.Read())
          {
              System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
              lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["FINISHED_PRODUCT_CODE"].ToString();
              lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["FINISHED_PRODUCT_NAME"].ToString();
              this.ddlProductName1.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
          }
          lcl_obj_SqlFacade.CloseReader();
      
      }

      void FisishedBuyerFixedTab()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQuery1 = System.String.Empty;
          lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME from WPMS_BUYER", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
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
              this.ddlCustomerName0.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
          }
          lcl_obj_SqlFacade.CloseReader();
      }

        //For PO

      void BuyerCodeForPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQuery1 = System.String.Empty;
          lcl_str_SqlQuery1 = System.String.Format("Select BUYER_CODE,COMPANY_NAME from WPMS_BUYER", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
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
              this.ddlCustomerName1.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
          }
          lcl_obj_SqlFacade.CloseReader();
      }

      void RadiobuttonListShowProduct()
    {
SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
       
        System.String lcl_str_SqlQuery1 = System.String.Empty;
        lcl_str_SqlQuery1 = System.String.Format("Select FINISHED_PRODUCT_CODE,FINISHED_PRODUCT_NAME from WPMS_FINISHED_PRODUCT", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
        //if (!(lcl_obj_CustomerReader.HasRows))
        //{
        //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
        //}
        System.Int32 lcl_i32_j = 1;
        while (lcl_obj_FinishedProductReader.Read())
        {
            System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
            lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["FINISHED_PRODUCT_CODE"].ToString();
            lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["FINISHED_PRODUCT_NAME"].ToString();
            this.radLstProductCatalog_NPQ.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
        }
        lcl_obj_SqlFacade.CloseReader();
    
    }


      private void HDPEPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010001)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtHDPE_NPQ_Standard_Price.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //for Po

      private void HDPEPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010001)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtHDPE_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void LLDPEPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010002)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLLDPE_NPQ_Standard_Price.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


        //For Po

      private void LLDPEPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010002)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLLDPE_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void COCOPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010003)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txt_coco2.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void COCOPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010003)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txt_coco5.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void LDPEPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010004)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              TextBox6.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void LDPEPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010004)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              TextBox52.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void RecylePriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010005)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtPunchOut_NPQ_Standard_Price.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void RecylePriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010005)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtPunchOut_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkGeraniumPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010022)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtgeraniumPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po
      private void InkGeraniumPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010022)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtgeraniumPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void ThinnerPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010007)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              TextBox3.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For ?PO

      private void ThinnerPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010007)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              TextBox81.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
      private void D2EPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010008)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtD2W_NPQ_StandardPrice.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void D2EPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010008)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtD2W_NPQ_StandardPrice0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void EPIPriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010009)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtEPI_NPQ_Standard_Price.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


        //For PO

      private void EPIPriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010009)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtEPI_NPQ_Standard_Price0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchWhitePriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010010)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtMWPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void MasterBatchWhitePriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010010)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtMWPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchBluePriceLoad()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010011)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtBluePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void MasterBatchBluePriceLoadPO()
      {

          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010011)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void MasterBatchRedPriceLoad()

      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010012)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRedPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void MasterBatchRedPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010012)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRedPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchGreenPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010013)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtGreenPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
        
        //For PO

      private void MasterBatchGreenPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010013)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtGreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchYellowPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010014)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtyellowPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void MasterBatchYellowPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010014)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchLoryPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010015)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLoryPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po

      private void MasterBatchLoryPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010015)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLoryPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchBeigePriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010016)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtBeigePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
        //For Po

      private void MasterBatchBeigePriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010016)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtBeigePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void MasterBatchPinkPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010017)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtPinkPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void MasterBatchPinkPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010017)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtPinkPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchBurgendyPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010018)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtbgendyPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po

      private void MasterBatchBurgendyPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010018)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtbgendyPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void MasterBatchLemonGrassPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010019)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLgrassPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po
      private void MasterBatchLemonGrassPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010019)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtLgrassPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void MasterBatchBlackPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010020)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              BlackPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po
      private void MasterBatchBlackPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010020)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              BlackPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void MasterBatchOrangePriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010021)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtOrangePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For Po

      private void MasterBatchOrangePriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010021)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtOrangePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkLemonYellowPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010023)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtlyellowPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void InkLemonYellowPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010023)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtlyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkMidYellowPriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010024)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtmyellowPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void InkMidYellowPriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010024)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtmyellowPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkRoyalBluePriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010025)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRBluePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

//For PO
      private void InkRoyalBluePriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010025)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
      private void InkBluePriceLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010026)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkBluePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


        //For Po

      private void InkBluePriceLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010026)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
      private void InkPeacockBlueLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010027)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkpbluePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void InkPeacockBlueLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010027)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkpbluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkMolybDateOrangeLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010028)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtmdorangePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
      //For PO
      private void InkMolybDateOrangeLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010028)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtmdorangePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkWhiteLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010029)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkWhitePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
        //For Po
      private void InkWhiteLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010029)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkWhitePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void InkGreenLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010030)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkgreenPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void InkGreenLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010030)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkgreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkGrassGreenLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010031)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkggreenPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
        //For PO

      private void InkGrassGreenLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010031)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkggreenPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkBlackLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010032)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkBlackPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      //For PO
      private void InkBlackLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010032)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkBlackPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkAjinomotoRedLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010033)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtAMRedPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //for PO

      private void InkAjinomotoRedLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010033)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtAMRedPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkReflexBlueCLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010034)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRFBluePr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO
      private void InkReflexBlueCLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010034)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtRFBluePr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

      private void InkSilverLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010035)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkSilverPr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }
        //For PO
      private void InkSilverLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010035)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              txtInkSilverPr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      private void InkAntiSlipLoad()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010006)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              EntiSlippr.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }

        //For PO

      private void InkAntiSlipLoadPO()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQueryHDPE = System.String.Empty;
          lcl_str_SqlQueryHDPE = System.String.Format("select PRICE_M_TON from wpms_raw_material where PRODUCT_UPDATE_CODE = ( select max(PRODUCT_UPDATE_CODE) from wpms_raw_material where RM_CODE =1010006)", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQueryHDPE);

          while (lcl_obj_WorkGroupReader.Read())
          {
              EntiSlippr0.Text = lcl_obj_WorkGroupReader["PRICE_M_TON"].ToString();
          }
          lcl_obj_SqlFacade.Close();
      }


      //void QuotationCode()
      //{
      //    SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
      //    System.String lcl_str_SqlQuery1 = System.String.Empty;
      //    lcl_str_SqlQuery1 = System.String.Format("Select QUOTATION_CODE from WPMS_QUOTATION", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
      //    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
      //    //if (!(lcl_obj_CustomerReader.HasRows))
      //    //{
      //    //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
      //    //}
      //    System.Int32 lcl_i32_j = 1;
      //    while (lcl_obj_FinishedProductReader.Read())
      //    {
      //        System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
      //        lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["QUOTATION_CODE"].ToString();
      //        lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["QUOTATION_CODE"].ToString();
      //        this.QuotationCodeList.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
      //    }
      //    lcl_obj_SqlFacade.CloseReader();
      //}
      protected void Button1_Click(object sender, EventArgs e)
      {
          //Connection con = new Connection();
          
          //con.Conect();
          //string sqlTxt = "";

          //sqlTxt = " select QT.QUOTATION_CODE,QT.QUOTATION_DATE,b.company_name from wpms_quotation QT inner join wpms_buyer B on B.BUYER_CODE=qt.buyer_code where qt.QUOTATION_CODE = '" + DropDownList1.SelectedValue + "' ";
          //System.Data.OracleClient.OracleDataAdapter da = new System.Data.OracleClient.OracleDataAdapter(sqlTxt, con.);
          //DataSet ds = new DataSet();
          //da.Fill(ds, "WPMS_QUOTATION");

          //string sqlTxt1 = "";

          //sqlTxt1 = " Select * From WPMS_QUOTATION_DETAILS";
          //System.Data.OracleClient.OracleDataAdapter da1 = new System.Data.OracleClient.OracleDataAdapter(sqlTxt1, lcl_obj_DBManager);

          //da1.Fill(ds, "WPMS_QUOTATION_DETAILS");

          //string sqlTxt2 = "";

          //sqlTxt2 = " Select * From WPMS_FINISHED_PRODUCT";
          //System.Data.OracleClient.OracleDataAdapter da2 = new System.Data.OracleClient.OracleDataAdapter(sqlTxt2, lcl_obj_DBManager);

          //da2.Fill(ds, "WPMS_FINISHED_PRODUCT");

          ////string sqlTxt3 = "";
          ////sqlTxt3 = " Select * From WPMS_BUYER";
          ////System.Data.OracleClient.OracleDataAdapter da3 = new System.Data.OracleClient.OracleDataAdapter(sqlTxt3, lcl_obj_DBManager);

          ////da3.Fill(ds, "WPMS_BUYER");


          //ReportClass rpt = new ReportClass();
          //rpt = new QuotationReport();
          //rpt.SetDataSource(ds);
          //ReportingViewer rv = new ReportingViewer();
          //    rv.CrystalReportViewer1.RefreshReport();
          //CrystalReportViewer1.ReportSource = rpt;
      }

      void ItemCode()
      {
          SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
          System.String lcl_str_SqlQuery1 = System.String.Empty;
          lcl_str_SqlQuery1 = System.String.Format("Select PRODUCT_CATAGORY_CODE,CATAGORY_NAME from WPMS_ITEM_CATAGORY", (System.Int32)SilkERP360.CCL.Enums.Status.Active);
          Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_FinishedProductReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery1);
          //if (!(lcl_obj_CustomerReader.HasRows))
          //{
          //    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee for The Selected Company Was Not Found!!!");
          //}
          System.Int32 lcl_i32_j = 1;
          while (lcl_obj_FinishedProductReader.Read())
          {
              System.Web.UI.WebControls.ListItem lcl_obj_EmployeeItem = new System.Web.UI.WebControls.ListItem();
              lcl_obj_EmployeeItem.Value = lcl_obj_FinishedProductReader["PRODUCT_CATAGORY_CODE"].ToString();
              lcl_obj_EmployeeItem.Text = lcl_obj_FinishedProductReader["CATAGORY_NAME"].ToString();
              this.ddlItem.Items.Insert(lcl_i32_j++, lcl_obj_EmployeeItem);
          }
          lcl_obj_SqlFacade.CloseReader();
      }
    }
}