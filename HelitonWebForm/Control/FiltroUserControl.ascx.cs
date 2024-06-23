using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelitonWebForm.Control
{
    public partial class FiltroUserControl : System.Web.UI.UserControl
    {
        private TextBox _flt_nrocamisa;
        private TextBox _flt_apelido;
        private DropDownList _flt_classificaimc;

        public TextBox Flt_nrocamisa
        {
            get { return _flt_nrocamisa; }
            set { _flt_nrocamisa = value; }
        }
        public TextBox Flt_apelido
        {
            get { return _flt_apelido; }
            set { _flt_apelido = value; }
        }
        public DropDownList Flt_classificaimc
        {
            get { return _flt_classificaimc; }
            set { _flt_classificaimc = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this._flt_nrocamisa = this.flt_nrocamisa;
            this._flt_apelido = this.flt_apelido;
            this._flt_classificaimc = this.flt_classificaimc;
        }
    }
}