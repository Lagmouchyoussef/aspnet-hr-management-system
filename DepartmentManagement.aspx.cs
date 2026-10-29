using System;
using System.Linq;

namespace WebAppCodeFirst
{
    public partial class DepartmentManagement : System.Web.UI.Page
    {
        DbSalarieContext DbContext = new DbSalarieContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (DbContext.Departement.Count() > 0)
                {
                    GvDepartement.DataSource = DbContext.Departement.ToList();
                    GvDepartement.DataBind();
                    DDLDepartement.DataSource = DbContext.Departement.ToList();
                    DDLDepartement.DataTextField = "Description";
                    DDLDepartement.DataValueField = "DepartementId";
                    DDLDepartement.DataBind();
                }
            }
        }

        protected void GvDepartement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 IdDep = int.Parse(GvDepartement.SelectedValue.ToString());
            Departement MonDep = new Departement();
            MonDep = DbContext.Departement.Find(IdDep);
            TbId.Text = MonDep.DepartementId.ToString();
            TbDescription.Text = MonDep.Description;
            TbLocalisation.Text = MonDep.Location;
            Int32 Val = int.Parse(GvDepartement.SelectedValue.ToString());
            GvSalarie.DataSource = DbContext.Salarie.Where(s => s.DepartementId == Val).Select(s => new { s.SalarieId, s.Nom, s.Prenom, s.Fonction, s.Salaire }).ToList();
            GvSalarie.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Departement NewDep = new Departement();
            NewDep.Description = TbDescription.Text;
            NewDep.Location = TbLocalisation.Text;
            DbContext.Departement.Add(NewDep);
            DbContext.SaveChanges();
            GvDepartement.DataSource = (from dep in DbContext.Departement
                                        select dep).ToList();
            GvDepartement.DataBind();
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            Departement MonDep = new Departement();
            Int32 IdDep = int.Parse(GvDepartement.SelectedValue.ToString());
            MonDep = (from dep in DbContext.Departement
                      where dep.DepartementId == IdDep
                      select dep).Single();
            MonDep.Description = TbDescription.Text;
            MonDep.Location = TbLocalisation.Text;
            DbContext.SaveChanges();
            GvDepartement.DataSource = (from dep in DbContext.Departement
                                        select dep).ToList();
            GvDepartement.DataBind();
        }

        protected void BtDelette_Click(object sender, EventArgs e)
        {
            Departement MonDep = new Departement();
            Int32 IdDep = int.Parse(GvDepartement.SelectedValue.ToString());
            MonDep = (from dep in DbContext.Departement
                      where dep.DepartementId == IdDep
                      select dep).Single();
            DbContext.Departement.Remove(MonDep);
            DbContext.SaveChanges();
            GvDepartement.DataSource = (from dep in DbContext.Departement
                                        select dep).ToList();
            GvDepartement.DataBind();
        }

        protected void BtAddSalarie_Click(object sender, EventArgs e)
        {
            Salarie NewSalarie = new Salarie();
            NewSalarie.Prenom = TbPrenom.Text;
            NewSalarie.Nom = TbNom.Text;
            NewSalarie.Salaire = double.Parse(TbSalaire.Text);
            NewSalarie.Fonction = TbFonction.Text;
            NewSalarie.DepartementId = int.Parse(DDLDepartement.SelectedValue.ToString());
            DbContext.Salarie.Add(NewSalarie);
            DbContext.SaveChanges();
        }

        protected void GvSalarie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Salarie NewSalarie = new Salarie();
            NewSalarie = DbContext.Salarie.Find(GvSalarie.SelectedValue);
            TbPrenom.Text = NewSalarie.Prenom;
            TbNom.Text = NewSalarie.Nom;
            TbSalaire.Text = NewSalarie.Salaire.ToString();
            TbFonction.Text = NewSalarie.Fonction;
            DDLDepartement.SelectedValue = NewSalarie.DepartementId.ToString();
        }
    }
}
