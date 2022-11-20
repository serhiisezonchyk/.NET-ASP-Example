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
  
    public partial class OnliIntrudeerList : System.Web.UI.Page
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IIntruderDAO intruderDAO = factory.getIntruderDAO();
            IList<Intruder> intruders = intruderDAO.GetAll();
            GridViewIntruder.DataSource = intruders;
            GridViewIntruder.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridViewIntruder_PageIndexChanging(object sender,
GridViewPageEventArgs e)
        {
            GridViewIntruder.PageIndex = e.NewPageIndex;
            GridViewIntruder.EditIndex = -1;
            GridViewIntruder.ShowFooter = true;
            GridViewIntruder.DataBind();
        }
    }
}