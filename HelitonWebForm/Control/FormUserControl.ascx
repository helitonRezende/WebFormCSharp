<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormUserControl.ascx.cs" Inherits="HelitonWebForm.Control.FormUserControl" %>

<div class="row">
    <%-- Mensagem --%>
    <span class="label" id="msgForm" style="width: 100%;text-align: center; color:red" runat="server"></span>

    <%-- Formatação campos --%>
    <asp:RegularExpressionValidator ID="txtExpressao1" ControlToValidate="altura" ValidationGroup="Insert" ForeColor="Red" Display="Dynamic" ErrorMessage="Altura formatação inválida, Exemplo 1,80!" ValidationExpression="^\d+([,\.]\d{1,2})?$" runat="server"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="txtExpressao2" ControlToValidate="peso" ValidationGroup="Insert" ForeColor="Red" Display="Dynamic" ErrorMessage="Peso formatação inválida, Exemplo 80,10!" ValidationExpression="^\d+([,\.]\d{1,2})?$" runat="server"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="txtExpressao3" ControlToValidate="nrocamisa" ValidationGroup="Insert" ForeColor="Red" Display="Dynamic" ErrorMessage="Camisa somente número inteiro, verifique!" ValidationExpression="^\d+([,\.]\d{0})?$" runat="server"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="txtExpressao4" ControlToValidate="dtnascimento" ValidationGroup="Insert" ForeColor="Red" Display="Dynamic" ErrorMessage="Nascimento formato inválido de data, verifique!" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" runat="server"></asp:RegularExpressionValidator>

    <%-- Campos obrigatório validado no BootStrep --%>
    <div class="container">  
        <div class="controls">
            <asp:TextBox id="idTabela" Value="0" runat="server" Visible="false"></asp:TextBox>
            <label style="position: relative; top:9px; left:5px;"><strong>Nome:</strong></label>
            <asp:TextBox id="nome" Text="" MaxLength="50" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:9px; left:3px; width: 606px;" runat="server"></asp:TextBox>
            
            <label style="position: relative; top:14px; left:5px;"><strong>Apelido:</strong></label>
            <asp:TextBox id="apelido" Text="" MaxLength="50" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:18px; left:3px; width: 606px;" runat="server" ></asp:TextBox>
            
            <label style="position: relative; top:24px; left:5px;"><strong>Nascimento (dd/mm/yyyy):</strong></label>
            <asp:TextBox id="dtnascimento" Text="" MaxLength="10" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:26px; left:3px; width: 195px;" runat="server" ></asp:TextBox>
            
            <label style="position: relative; top:-36px; left:221px;"><strong>Altura:</strong></label>
            <asp:TextBox id="altura" Text="" MaxLength="4" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:-36px; left:217px; width:90px;" runat="server" ></asp:TextBox>
            
            <label style="position: relative; top:-98px; left:324px;"><strong>Peso:</strong></label>
            <asp:TextBox id="peso" Text="" MaxLength="6" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:-98px; left:320px; width:90px;" runat="server"></asp:TextBox>
            
            <label style="position: relative; top:-159px; left:430px;"><strong>Número da Camisa:</strong></label>
            <asp:TextBox id="nrocamisa" Text="" MaxLength="6" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:-160px; left:426px; width:178px;" runat="server" ></asp:TextBox>
            
            <label style="position: relative; top:-155px; left:5px;"><strong>Posição:</strong></label>
            <asp:TextBox id="posicao" Text="" MaxLength="50" class="form-control" placeholder="Obrigatório *" required="required" data-error="Firstname is required." style="position: relative; top:-150px; left:3px; width:606px;" runat="server" ></asp:TextBox>
        </div>
        <%-- Botões Alterar, Incluir e Voltar --%>
        <did>
            <asp:Button id="ConfirmaAlterar" Text="Alterar" CssClass="btn btn-primary btn-md" Visible="false" onClick="ConfirmaAlterar_Click" style="position: relative; top:-144px; left:3px; width:100px;" runat="server"></asp:Button>
            <asp:Button id="ConfirmaAdicionar" Text="Incluir" CssClass="btn btn-primary btn-md" Visible="false" onClick="ConfirmaAdicionar_Click" style="position: relative; top:-144px; left:3px; width:100px;" runat="server"></asp:Button>
            <a class="btn btn-primary btn-md" href="~/" style="position: relative; top:-144px; left:12px; width:100px;" runat="server">Voltar</a>
        </did>'
    </div>
</div>