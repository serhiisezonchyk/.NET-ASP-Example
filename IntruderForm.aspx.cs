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
    public partial class IntruderForm : System.Web.UI.Page
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
            long keyPoliceman = Convert.ToInt32(Session["keyPoliceman"]);
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            Policeman owner = policemanDAO.GetById(keyPoliceman);
            Label5.Text = owner.Rank.Name + ": "+owner.FirstName + " " + owner.LastName;
            IList<Intruder> intruders = policemanDAO.getAllIntruderOfPoliceman(keyPoliceman);
            GridViewIntruder.DataSource = intruders;
            GridViewIntruder.DataBind();
            if (intruders.Count >0 )
            {
                ISexDAO sexDAO = factory.getSexDAO();
                var myFooterTextBoxPoliceman = GridViewIntruder.FooterRow.FindControl("myFooterTextBoxPoliceman") as DropDownList;
                foreach (Policeman p in policemanDAO.GetAll())
                {
                    myFooterTextBoxPoliceman.Items.Add(p.Id + ") " + p.FirstName + "," + p.LastName);
                }
                var myFooterTextBoxSex = GridViewIntruder.FooterRow.FindControl("myFooterTextBoxSex") as DropDownList;
                foreach (Sex s in sexDAO.GetAll())
                {
                    myFooterTextBoxSex.Items.Add(s.Id + ") " + s.Name);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ibInsert_Click(object sender, EventArgs e)
        {
            long keyPoliceman = Convert.ToInt32(Session["keyPoliceman"]);
            //Получаем значения полей
            string s1 =
            ((TextBox)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxFirstName")).Text;
            string s2 =       
            ((TextBox)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxLastName")).Text;
            string s3 =       
            ((TextBox)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxAge")).Text;
            string s4 =       
            ((TextBox)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxPhone")).Text;
            string s5 =
            ((TextBox)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxDescription")).Text;

            string s6 =
            ((DropDownList)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxSex")).Text;

            string s7 =
            ((DropDownList)GridViewIntruder.FooterRow.FindControl("MyFooterTextBoxPoliceman")).Text;
            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            ISexDAO sexDAO = factory.getSexDAO();
            IIntruderDAO iDAO = factory.getIntruderDAO();
            Policeman policeman = policemanDAO.GetById(Convert.ToInt32(s7.Substring(0, s7.IndexOf(")"))));
            IIntruderDAO intruderDAO = factory.getIntruderDAO();

            Intruder intruder = new Intruder();
            intruder.FirstName = s1;
            intruder.LastName = s2;
            intruder.Age = Convert.ToInt32(s3);
            intruder.Phone = s4;
            intruder.Description = s5;
            intruder.Sex = sexDAO.GetById(Convert.ToInt32(s6.Substring(0, s6.IndexOf(")"))));
            intruder.Policeman = policeman;
            policeman.IntrudersList.Add(intruder);
            //Сохраняем объект студента
            intruderDAO.SaveOrUpdate(intruder);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        protected void emptyImageButton_Click(object sender, EventArgs e)
        {
            long keyPoliceman = Convert.ToInt32(Session["keyPoliceman"]);
            //Получаем значения полей ввода
            var parent = ((Control)sender).Parent;
            var firstNameTextBox = parent
            .FindControl("emptyFirstNameTextBox") as TextBox;
            var lastNameTextBox = parent
            .FindControl("emptyLastNameTextBox") as TextBox;
            var ageTextBox = parent.FindControl("emptyAgeTextBox") as TextBox;
            var phoneTextBox = parent.FindControl("emptyPhoneTextBox") as TextBox;
            var descriptionTextBox = parent.FindControl("emptyDescriptionTextBox") as TextBox;
            var sexTextBox = parent
            .FindControl("emptySexTextBox") as DropDownList;
            
            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            Policeman policeman = policemanDAO.GetById(keyPoliceman);
            IIntruderDAO intruderDAO = factory.getIntruderDAO();
            ISexDAO sexDAO = factory.getSexDAO();

            Intruder intruder = new Intruder();
            intruder.FirstName = firstNameTextBox.Text;
            intruder.LastName = lastNameTextBox.Text;
            intruder.Age = Convert.ToInt32(ageTextBox.Text);
            intruder.Phone = phoneTextBox.Text;
            intruder.Description =descriptionTextBox.Text;
            intruder.Sex = sexDAO.GetById(Convert.ToInt32(sexTextBox.Text));
            intruder.Policeman = policemanDAO.GetById(keyPoliceman);
            policemanDAO.GetById(keyPoliceman).IntrudersList.Add(intruder);

            intruderDAO.SaveOrUpdate(intruder);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        //Удаление строки
        protected void GridViewIntruder_RowDeleting(object sender,
        GridViewDeleteEventArgs e)
        {
            long keyPoliceman = Convert.ToInt32(Session["keyPoliceman"]);
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridViewIntruder.Rows[index];

            long intruderId = Convert.ToInt32(((Label)(row.Cells[0].FindControl("myLabelId"))).Text);
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            IIntruderDAO intruderDAO = factory.getIntruderDAO();
            Intruder intruder = intruderDAO.GetById(intruderId);

            if (intruder != null)
            {
                intruder.Policeman.IntrudersList.Remove(intruder);
                intruderDAO.Delete(intruder);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void GridViewIntruder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            GridViewRow row = GridViewIntruder.Rows[index];
            string oldIntruderId = ((Label)(row.Cells[0].FindControl("myLabelId"))).Text;
            //Сохранение названия группы в коллекции ViewState
            ViewState["oldIntruderId"] = oldIntruderId;
            GridViewIntruder.EditIndex = index;
            GridViewIntruder.ShowFooter = false;
            GridViewIntruder.DataBind();
        }
        //Отмена редактирования строки
        protected void GridViewIntruder_RowCancelingEdit(object sender,
    GridViewCancelEditEventArgs e)
    {
        GridViewIntruder.EditIndex = -1;
        GridViewIntruder.ShowFooter = true;
        GridViewIntruder.DataBind();
    }
    //Редактирование строки
    protected void GridViewIntruder_RowUpdating(object sender,
    GridViewUpdateEventArgs e)
    {
        long keyPoliceman = Convert.ToInt32(Session["keyPoliceman"]);
        int index = e.RowIndex;
        GridViewRow row = GridViewIntruder.Rows[index];

        string newFirstName =
        ((TextBox)(row.Cells[1].FindControl("myTextBoxFirstName"))).Text;
        string newLastName =
        ((TextBox)(row.Cells[2].FindControl("myTextBoxLastName"))).Text;
        string newAge = ((TextBox)(row.Cells[3].FindControl("myTextBoxAge"))).Text;
        string newPhone = ((TextBox)(row.Cells[4].FindControl("myTextBoxPhone"))).Text;
        string newDescription = ((TextBox)(row.Cells[5].FindControl("myTextBoxDescription"))).Text;
        string newSex = ((TextBox)(row.Cells[6].FindControl("myTextBoxSex"))).Text;
        string newPoliceman = ((TextBox)(row.Cells[7].FindControl("myTextBoxPoliceman"))).Text;
        long oldIntruderId = Convert.ToInt32(ViewState["oldIntruderId"]);
        //Создание DAO группы
        ISession hbmSession = (ISession)Session["hbmsession"];
        DAOFactory factory = new NHibernateDAOFactory(hbmSession);
        IIntruderDAO intruderDAO = factory.getIntruderDAO();
        ISexDAO sexDAO = factory.getSexDAO();
        IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
        //Получение группы по имени
        Intruder intruder = intruderDAO.GetById(oldIntruderId);
        intruder.FirstName = newFirstName;
        intruder.LastName = newLastName;
        intruder.Age = Convert.ToInt32(newAge);
        intruder.Phone = newPhone;
        intruder.Description = newDescription;
        intruder.Sex = sexDAO.GetById(Convert.ToInt32(newSex));
        intruder.Policeman = policemanDAO.GetById(Convert.ToInt32(newPoliceman));
        intruderDAO.SaveOrUpdate(intruder);
        GridViewIntruder.EditIndex = -1;
        GridViewIntruder.ShowFooter = true;
        GridViewIntruder.DataBind();
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