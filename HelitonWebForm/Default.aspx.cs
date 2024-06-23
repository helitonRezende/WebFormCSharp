using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AtletaBLL;
using AtletaDTO;
using WebGrease.Css.Ast;

namespace HelitonWebForm
{
    public partial class _Default : Page
    {
        
        private static AcessoBLL acessoBLL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                acessoBLL = new AcessoBLL();
            }
            this.msg.InnerText = "";
        }

        // Botão do Grid Editar //
        protected void Editar_Click(object sender, EventArgs e)
        {
            try
            {
                // Set ID e Acessa Pesquisa BLL //
                int id = Convert.ToInt32(((Button)sender).CommandArgument);
                Atleta atleta = acessoBLL.GetAtletaId(id);

                // Set Dados Tela //
                FormUC.IdTabela.Text = atleta.Id.ToString().Trim();
                FormUC.Nome.Text = atleta.Nome.ToString().Trim();
                FormUC.Apelido.Text = atleta.Apelido.ToString().Trim();
                FormUC.Dtnascimento.Text = Convert.ToDateTime(atleta.DtNascimento.ToString()).ToString("dd/MM/yyyy");
                FormUC.Altura.Text = atleta.Altura.ToString().Trim();
                FormUC.Peso.Text = atleta.Peso.ToString().Trim();
                FormUC.Posicao.Text = atleta.Posicao.ToString().Trim();
                FormUC.Nrocamisa.Text = atleta.NroCamisa.ToString().Trim();

                // Habilita Botao Alteração //
                FormUC.ConfirmaAlterarbtn.Visible = true;
                FormUC.ConfirmaAdicionarbtn.Visible = false;

                // Habilita Div Incluir/Alterar //
                this.divPesquisar.Visible = false;
                this.divAdicinar.Visible = true;
            }
            catch (Exception ex)
            {
                this.msg.InnerText = ex.Message.ToString();
            }
        }

        // Botão do Grid Excluir //
        protected void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                // Set ID e Exclui BLL //
                int id = Convert.ToInt32(((Button)sender).CommandArgument);
                acessoBLL.Excluir(id);

                // Set Filtros //
                AtletaFiltro filtro = new AtletaFiltro();
                filtro.NroCamisa = ContactUC.Flt_nrocamisa.Text != "" ? Convert.ToInt16(ContactUC.Flt_nrocamisa.Text.ToString().Trim()) : 0;
                filtro.Apelido = ContactUC.Flt_apelido.Text.ToString().Trim();
                filtro.ClassificaIMC = ContactUC.Flt_classificaimc.SelectedValue.ToString().Trim();

                // Excuta Pesquisa //
                this.lista.DataSource = acessoBLL.ConsultarFiltro(filtro);
                this.lista.DataBind();

                this.msg.InnerText = "Registro deletado com sucesso!";
            }
            catch (Exception ex)
            {
                this.msg.InnerText = ex.Message.ToString();
            }
        }

        // Botão Form Adicionar //
        protected void Adicionar_Click(object sender, EventArgs e)
        {
            // Inicializa Dados Tela //
            FormUC.IdTabela.Text = "0";
            FormUC.Nome.Text = "";
            FormUC.Apelido.Text = "";
            FormUC.Dtnascimento.Text = "";
            FormUC.Altura.Text = "";
            FormUC.Peso.Text = "";
            FormUC.Posicao.Text = "";
            FormUC.Nrocamisa.Text = "";

            // Habilita Botao Incluir //
            FormUC.ConfirmaAlterarbtn.Visible = false;
            FormUC.ConfirmaAdicionarbtn.Visible = true;

            // Habilita Div Incluir/Alterar //
            this.divPesquisar.Visible = false;
            this.divAdicinar.Visible = true;
        }

        // Botão Form Pesquisa //
        protected void Pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Filtros //
                AtletaFiltro filtro = new AtletaFiltro();
                filtro.NroCamisa = ContactUC.Flt_nrocamisa.Text != "" ? Convert.ToInt16(ContactUC.Flt_nrocamisa.Text.ToString().Trim()) : 0;
                filtro.Apelido = ContactUC.Flt_apelido.Text.ToString().Trim();
                filtro.ClassificaIMC = ContactUC.Flt_classificaimc.SelectedValue.ToString().Trim();

                // Excuta Pesquisa //
                this.lista.DataSource = acessoBLL.ConsultarFiltro(filtro);
                this.lista.DataBind();
            }
            catch (Exception ex)
            {
                this.msg.InnerText = ex.Message.ToString();
            }
        }
    }
}