using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisaApplication.DataBaseLayer;
using WebGrease.Css.Ast.Selectors;

namespace VisaApplication
{
    public partial class _Default : Page
    {
        VisaDBLayer context = new VisaDBLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserGrid();
                BindVisaApplicationGrid();
            }
                
        }

        public void BindUserGrid()
        {
            var res = context.GetUsers();
            if (res != null)
            {
                userGrid.DataSource = res;
                userGrid.DataBind();
            }
        }
        public void BindVisaApplicationGrid()
        {
            var dt = context.GetApplications();
            if (dt != null)
            {
                appgrid.DataSource = dt;
                appgrid.DataBind();
            }
        }

        protected void userGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userGrid.EditIndex = e.NewEditIndex;
            BindUserGrid();
        }

        protected void userGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            userGrid.EditIndex = -1;
            BindUserGrid();
        }

        protected void userGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string applicantName = ((TextBox)userGrid.Rows[rowIndex].FindControl("txtusername")).Text;
            string visaType = ((TextBox)userGrid.Rows[rowIndex].FindControl("txtpassword")).Text;
            var res = context.UpdateUser(applicantName, visaType);
            userGrid.EditIndex = -1;
            BindUserGrid();
        }

        protected void userGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int applicationID = Convert.ToInt32(userGrid.DataKeys[e.RowIndex].Value);
            var res = context.DeleteUser(applicationID);
            BindUserGrid();
        }

        protected void appgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int applicationID = Convert.ToInt32(e.CommandArgument);
                PopulateModalFields(applicationID);
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#editModal').modal('show');", true);
            }
        }

        public void PopulateModalFields(int applicationID)
        {
            DataRow row = context.GetVisaApplicationById(applicationID); // Mocked for demonstration
            if (row != null)
            {
                hfApplicationID.Value = row["ApplicationID"].ToString();
                txtUserName.Text = row["UserName"].ToString();
                ddlVisaType.SelectedValue = row["VisaType"].ToString();
                txtCountryOfApplication.Text = row["CountryOfApplication"].ToString();
                ddlApplicationStatus.SelectedValue = row["ApplicationStatus"].ToString();
                string passportCopyPath = row["PassportCopy"].ToString();
                if (!string.IsNullOrEmpty(passportCopyPath))
                {
                    lblCurrentFilePath.Visible = true;
                    litCurrentFilePath.Text = $"<a href='{passportCopyPath}' target='_blank'>View Current File</a>";
                }
            }
        }

        protected void appgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int applicationID = Convert.ToInt32(appgrid.DataKeys[e.RowIndex].Value);
            var res=context.DeleteVisaApplication(applicationID);
            BindVisaApplicationGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int applicationID = int.Parse(hfApplicationID.Value);
            string userName = txtUserName.Text;
            string applicationStatus = ddlApplicationStatus.SelectedValue;
            context.UpdateApplicationStatus(applicationID,applicationStatus);
            BindVisaApplicationGrid();
            ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "$('#editModal').modal('hide');", true);
        }

    }
}