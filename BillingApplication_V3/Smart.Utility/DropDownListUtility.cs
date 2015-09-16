using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;


namespace Smart.Utility
{
    public class DropDownListUtility 
    {
        public void FillDropDownList(DropDownList ddl, DataTable dt, string dataTextField, string dataValueField)
        {
            try
            {
                ddl.DataTextField = dataTextField;
                ddl.DataValueField = dataValueField;

                ddl.DataSource = dt;
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void FillDropDownList(DropDownList ddl, List<object> dt, string dataTextField, string dataValueField)
        {
            try
            {
                ddl.DataTextField = dataTextField;
                ddl.DataValueField = dataValueField;

                ddl.DataSource = dt;
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        //public void FillDropDownList(CustomControlLibrary.CustomDDL ddl, DataTable dt, string dataTextField, string dataValueField)
        //{
        //    try
        //    {
        //        ddl.DataTextField = dataTextField;
        //        ddl.DataValueField = dataValueField;

        //        ddl.DataSource = dt;
        //        ddl.DataBind();
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}

        public void FillDropDownList(DropDownList ddl, DataTable dt, string dataTextField, string dataValueField, Int32 newValue, string newText)
        {
            try
            {
                dt = this.AddOneRowToDataTable(dt, dataTextField, dataValueField, newValue, newText);

                ddl.DataTextField = dataTextField;
                ddl.DataValueField = dataValueField;

                ddl.DataSource = dt;
                ddl.DataBind();
            }
            catch 
            {


            }
        }

        private DataTable AddOneRowToDataTable(DataTable dt, string dataTextField, string dataValueField, Int32 newValue, string newText)
        {
            try
            {
                DataTable One = new DataTable();

                DataTable Two = new DataTable();

                One = dt;

                Two.Columns.Add(dataValueField);
                Two.Columns.Add(dataTextField);

                DataRow dr = Two.NewRow();
                dr[dataValueField] = newValue;
                dr[dataTextField] = newText;

                Two.Rows.Add(dr);

                for (int i = 0; i < One.Rows.Count; i++)
                {
                    dr = Two.NewRow();

                    dr[dataValueField] = One.Rows[i][dataValueField];
                    dr[dataTextField] = One.Rows[i][dataTextField];

                    Two.Rows.Add(dr);
                }

                return Two;
            }
            catch 
            {
                return null;
            }
        }

        public DataView conIListToDataView( IList<Object> objList )
        {
            DataView dv = new DataView();

            //objList[0]..cou

            return dv;
        }

    }
}
