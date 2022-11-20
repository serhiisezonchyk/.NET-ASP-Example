using FluentHibernateTest.dao;
using FluentHibernateTest.domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspDotNet2_l5
{
    public partial class DepartmentForm : System.Web.UI.Page
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IDepartmentDAO departmentDAO = factory.getDepartmentDAO();
            List<Department> groups = departmentDAO.GetAll();
            GridViewDepartment.DataSource = groups;
            GridViewDepartment.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridViewDepartment_PageIndexChanging(object sender,
GridViewPageEventArgs e)
        {
            GridViewDepartment.PageIndex = e.NewPageIndex;
            GridViewDepartment.EditIndex = -1;
            GridViewDepartment.ShowFooter = true;
            GridViewDepartment.DataBind();
        }
    }
}