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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            List<Policeman> policemen = policemanDAO.GetAll();
            GridViewPoliceman.DataSource = policemen;
            GridViewPoliceman.DataBind();

            IRankDAO rankDAO = factory.getRankDAO();
            IDepartmentDAO departmentDAO = factory.getDepartmentDAO();
            ISexDAO sexDAO = factory.getSexDAO();
            if (policemen.Count > 0)
            {
                var myFooterTextBoxRank = GridViewPoliceman.FooterRow.FindControl("myFooterTextBoxRank") as DropDownList;
                foreach (Rank r in rankDAO.GetAll())
                {
                    myFooterTextBoxRank.Items.Add(r.Id + ") " + r.Name);
                }
                var myFooterTextBoxDepartment = GridViewPoliceman.FooterRow.FindControl("myFooterTextBoxDepartment") as DropDownList;
                foreach (Department d in departmentDAO.GetAll())
                {
                    myFooterTextBoxDepartment.Items.Add(d.Id + ") " + d.Address + "," + d.City);
                }
                var myFooterTextBoxSex = GridViewPoliceman.FooterRow.FindControl("myFooterTextBoxSex") as DropDownList;
                foreach (Sex s in sexDAO.GetAll())
                {
                    myFooterTextBoxSex.Items.Add(s.Id + ") " + s.Name);
                }
            }
            Label5.Text = getInfoPageString();
        }

        protected void GridViewPoliceman_RowDeleting(object sender,GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridViewPoliceman.Rows[index];
            string key = ((Label)(row.Cells[0].FindControl("myLabelId"))).Text;
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            Policeman policeman = policemanDAO.GetById(Convert.ToInt32(key));
            if (policeman != null)
            {
                policemanDAO.Delete(policeman);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        protected void GridViewPoliceman_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.NewEditIndex;
            GridViewRow row = GridViewPoliceman.Rows[index];
            string oldPolicemanId = ((Label)(row.Cells[0].FindControl("myLabelId"))).Text;

            ViewState["oldPoliceman"] = oldPolicemanId;
            GridViewPoliceman.EditIndex = index;
            GridViewPoliceman.ShowFooter = false;
            GridViewPoliceman.DataBind();
        }
        private void Default_PreRender(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //Отмена редактирования записи
        protected void GridViewPoliceman_RowCancelingEdit(object sender,
        GridViewCancelEditEventArgs e)
        {
            GridViewPoliceman.EditIndex = -1;
            GridViewPoliceman.ShowFooter = true;
            GridViewPoliceman.DataBind();
        }
        //Редактирование строки
        protected void GridViewPoliceman_RowUpdating(object sender,
        GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridViewPoliceman.Rows[index];
            string newFirstName =
            ((TextBox)(row.Cells[1].FindControl("myTextBoxFirstName"))).Text;
            string newLastName =
            ((TextBox)(row.Cells[2].FindControl("myTextBoxLastName"))).Text;
            string newAge =
            ((TextBox)(row.Cells[3].FindControl("myTextBoxAge"))).Text;
            string newSex = ((TextBox)(row.Cells[4].FindControl("myTextBoxSex"))).Text;
            string newDepartment = ((TextBox)(row.Cells[5].FindControl("myTextBoxDepartment"))).Text;
            string newRank = ((TextBox)(row.Cells[6].FindControl("myTextBoxRank"))).Text;
            long oldPoliceman = Convert.ToInt32(ViewState["oldPoliceman"]);

            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            ISexDAO sexDAO = factory.getSexDAO();
            IDepartmentDAO departmentDAO = factory.getDepartmentDAO();
            IRankDAO rankDAO = factory.getRankDAO();

            Policeman policeman = policemanDAO.GetById(Convert.ToInt32(oldPoliceman));
            policeman.FirstName = newFirstName;
            policeman.LastName = newLastName;
            policeman.Age = Convert.ToInt32(newAge);
            policeman.Sex = sexDAO.GetById(Convert.ToInt32(newSex));
            policeman.Department = departmentDAO.GetById(Convert.ToInt32(newDepartment));
            policeman.Rank = rankDAO.GetById(Convert.ToInt32(newRank));

            policemanDAO.SaveOrUpdate(policeman);
            GridViewPoliceman.EditIndex = -1;
            GridViewPoliceman.ShowFooter = true;
            GridViewPoliceman.DataBind();
        }
        //Вывод списка всех студентов
        protected void GridViewPoliceman_RowCommand(object sender,
        GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPoliceman.Rows[index];
                string keyPoliceman = ((Label)(row.Cells[0].FindControl("myLabelId"))).Text;
                Session["keyPoliceman"] = keyPoliceman;
                Response.Redirect("IntruderForm.aspx");
            }
        }
        protected void GridViewPoliceman_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            GridViewPoliceman.PageIndex = e.NewPageIndex;
            GridViewPoliceman.EditIndex = -1;
            GridViewPoliceman.ShowFooter = true;
            GridViewPoliceman.DataBind();
        }

/*     
 *     
 *     Insert in empty
 *     
*/
        protected void emptyImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ISexDAO sexDAO = factory.getSexDAO();
            IDepartmentDAO departmentDAO = factory.getDepartmentDAO();
            IRankDAO rankDAO = factory.getRankDAO();

            var parent = ((Control)sender).Parent;
            var firstNameTextBox = parent
            .FindControl("emptyFirstNameTextBox") as TextBox;
            var lastNameTextBox = parent
            .FindControl("emptyastNameTextBox") as TextBox;
            var ageTextBox = parent
            .FindControl("emptyAgeTextBox") as TextBox;
            var sexTextBox = parent
            .FindControl("emptySexTextBox") as DropDownList;
            var departmentTextBox = parent
            .FindControl("emptyDepartmentTextBox") as TextBox;
            var rankTextBox = parent
            .FindControl("emptyRankTextBox") as TextBox;

            Policeman policeman = new Policeman();
            policeman.FirstName = firstNameTextBox.Text;
            policeman.LastName = lastNameTextBox.Text;
            policeman.Age = Convert.ToInt32(ageTextBox.Text);
            policeman.Sex = sexDAO.GetById(Convert.ToInt32(sexTextBox.Text));
            policeman.Department = departmentDAO.GetById(Convert.ToInt32(departmentTextBox.Text));
            policeman.Rank = rankDAO.GetById(Convert.ToInt32(rankTextBox.Text));

            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            policemanDAO.SaveOrUpdate(policeman);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

/*
 * 
 * Insert policeman
 * 
 */
        protected void ibInsert_Click(object sender, ImageClickEventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ISexDAO sexDAO = factory.getSexDAO();
            IDepartmentDAO departmentDAO = factory.getDepartmentDAO();
            IRankDAO rankDAO = factory.getRankDAO();
            //Получаем значения полей
            string s1 =
            ((TextBox)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxFirstName")).Text;
            string s2 =
            ((TextBox)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxLastName")).Text;
            string s3 =
            ((TextBox)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxAge")).Text;

            string s4 =
            ((DropDownList)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxSex")).Text;

            string s5 =
            ((DropDownList)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxDepartment")).Text;

            string s6 =
            ((DropDownList)GridViewPoliceman.FooterRow.FindControl("MyFooterTextBoxRank")).Text;

            Policeman policeman = new Policeman();
            policeman.FirstName = s1;
            policeman.LastName = s2;
            policeman.Age = Convert.ToInt32(s3);
            policeman.Sex = sexDAO.GetById(Convert.ToInt32(s4.Substring(0, s4.IndexOf(")"))));
            policeman.Department = departmentDAO.GetById(Convert.ToInt32(s5.Substring(0, s5.IndexOf(")"))));
            policeman.Rank = rankDAO.GetById(Convert.ToInt32(s6.Substring(0, s6.IndexOf(")"))));

            IPolicemanDAO policemanDAO = factory.getPolicemanDAO();
            policemanDAO.SaveOrUpdate(policeman);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        private string getInfoPageString()
        {

            DAOFactory dao = new NHibernateDAOFactory((ISession)Session["hbmsession"]);
            IPolicemanDAO policemanDAO = dao.getPolicemanDAO();
            List<Policeman> policemanList = policemanDAO.GetAll();
            IDepartmentDAO departmentDAO = dao.getDepartmentDAO();
            List<Department> departmentList = departmentDAO.GetAll();
            IIntruderDAO intruderDAO = dao.getIntruderDAO();
            List<Intruder> intruderList = intruderDAO.GetAll();
            string str = "Department details <br>";
            string nameMax = "", nameMin = "";
            int maxCountOfPolicemen = int.MinValue, minCountOfPolicemen = int.MaxValue;
            foreach (Department d in departmentList)
            {
                if (d.PolicemenList.Count > maxCountOfPolicemen)
                {
                    nameMax = d.Address + ", " + d.City;
                    maxCountOfPolicemen = d.PolicemenList.Count;
                }
                if (d.PolicemenList.Count < minCountOfPolicemen)
                {
                    nameMin = d.Address + ", " + d.City;
                    minCountOfPolicemen = d.PolicemenList.Count;
                }
            }
            str += " The biggest department " + nameMax + "have " + maxCountOfPolicemen + "<br>";
            str += " The smallest department " + nameMin + "have " + minCountOfPolicemen + "<br>";
            str += "<br>Policeman details<br>";

            int totalAge = 0, maxCountOfIntruders = int.MinValue;
            string name = "";
            foreach (Policeman p in policemanList)
            {
                totalAge += p.Age;
                if (maxCountOfIntruders < p.IntrudersList.Count)
                {
                    name = p.Rank.Name + " " + p.FirstName + " " + p.LastName;
                    maxCountOfIntruders = p.IntrudersList.Count;
                }
            }
            totalAge /= policemanList.Count;
            str += " Average age of policemen " + totalAge + "<br> Most successful policeman: <br> " + name + " have " + maxCountOfIntruders + " intruders<br>";
            str += "<br>Intruder details<br>";

            int femalesCount = 0, malesCount = 0;
            totalAge = 0;
            foreach (Intruder i in intruderList)
            {
                totalAge += i.Age;
                if (i.Sex.Name == "male")
                    malesCount++;
                else femalesCount++;
            }
            totalAge /= intruderList.Count;
            str += " Average age of intruder " + totalAge + "<br> males:  " + malesCount + "<br> females " + femalesCount + "<br>";
            return str;
        }
    }
}