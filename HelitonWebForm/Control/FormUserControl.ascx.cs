using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AtletaBLL;
using AtletaDTO;

namespace HelitonWebForm.Control
{
    public partial class FormUserControl : System.Web.UI.UserControl
    {
        private static AcessoBLL acessoBLL;

        private TextBox _idTabela;
        private TextBox _nome;
        private TextBox _apelido;
        private TextBox _dtnascimento;
        private TextBox _altura;
        private TextBox _peso;
        private TextBox _nrocamisa;
        private TextBox _posicao;
        private Button _confirmaAlterar;
        private Button _confirmaAdicionar;

        public TextBox IdTabela
        {
            get { return _idTabela; }
            set { _idTabela = value; }
        }
        public TextBox Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public TextBox Apelido
        {
            get { return _apelido; }
            set { _apelido = value; }
        }
        public TextBox Dtnascimento
        {
            get { return _dtnascimento; }
            set { _dtnascimento = value; }
        }
        public TextBox Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }
        public TextBox Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }
        public TextBox Nrocamisa
        {
            get { return _nrocamisa; }
            set { _nrocamisa = value; }
        }
        public TextBox Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public Button ConfirmaAlterarbtn
        {
            get { return _confirmaAlterar; }
            set { _confirmaAlterar = value; }
        }
        public Button ConfirmaAdicionarbtn
        {
            get { return _confirmaAdicionar; }
            set { _confirmaAdicionar = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                acessoBLL = new AcessoBLL();
            }

            this._idTabela = this.idTabela;
            this._nome = this.nome;
            this._apelido = this.apelido;
            this._dtnascimento = this.dtnascimento;
            this._altura = this.altura;
            this._peso = this.peso;
            this._nrocamisa = this.nrocamisa;
            this._posicao = this.posicao;
            this._confirmaAlterar = this.ConfirmaAlterar;
            this._confirmaAdicionar = this.ConfirmaAdicionar;
            this.msgForm.InnerText = "";
        }

        // Confirma Alterar //
        protected void ConfirmaAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Dados Tela para tabela //
                Atleta atleta = new Atleta();
                atleta.Id = Convert.ToInt16(this.IdTabela.Text.ToString());
                atleta.Nome = this.Nome.Text.ToString().Trim();
                atleta.Apelido = this.Apelido.Text.ToString().Trim();
                atleta.DtNascimento = Convert.ToDateTime(this.Dtnascimento.Text.ToString().Trim());
                this.Altura.Text = this.Altura.Text.ToString().Trim().Replace(".", ",");
                atleta.Altura = Convert.ToDecimal(this.Altura.Text.ToString().Trim());
                this.Peso.Text = this.Peso.Text.ToString().Trim().Replace(".", ",");
                atleta.Peso = Convert.ToDecimal(this.Peso.Text.ToString().Trim());
                atleta.Posicao = this.Posicao.Text.ToString().Trim();
                atleta.NroCamisa = Convert.ToInt16(this.Nrocamisa.Text.ToString().Trim());

                // Valida Chave  //
                bool chave = acessoBLL.GetAtletaChave(atleta.Id, atleta.NroCamisa);
                if (chave == true)
                {
                    this.msgForm.InnerText = "Já existe atleta com o número dessa camisa, verifique!";
                } 
                else
                {
                    // Altera //
                    acessoBLL.Alterar(atleta);
                    this.msgForm.InnerText = "Alteração efetuada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                this.msgForm.InnerText = ex.Message.ToString();
            }
        }

        // Confirma Incluir //
        protected void ConfirmaAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Set Dados Tela para tabela //
                Atleta atleta = new Atleta();
                atleta.Nome = this.Nome.Text.ToString().Trim();
                atleta.Apelido = this.Apelido.Text.ToString().Trim();
                atleta.DtNascimento = Convert.ToDateTime(this.Dtnascimento.Text.ToString().Trim());
                this.Altura.Text = this.Altura.Text.ToString().Trim().Replace(".", ",");
                atleta.Altura = Convert.ToDecimal(this.Altura.Text.ToString().Trim());
                this.Peso.Text = this.Peso.Text.ToString().Trim().Replace(".", ",");
                atleta.Peso = Convert.ToDecimal(this.Peso.Text.ToString().Trim());
                atleta.Posicao = this.Posicao.Text.ToString().Trim();
                atleta.NroCamisa = Convert.ToInt16(this.Nrocamisa.Text.ToString().Trim());

                // Valida Chave  //
                bool chave = acessoBLL.GetAtletaChave(0, atleta.NroCamisa);
                if (chave == true)
                {
                    this.msgForm.InnerText = "Já existe atleta com o número dessa camisa, verifique!";
                }
                else
                {
                    // Inclui //
                    acessoBLL.Incluir(atleta);
                    this.msgForm.InnerText = "Inclusão efetuada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                this.msgForm.InnerText = ex.Message.ToString();
            }
        }
    }
}