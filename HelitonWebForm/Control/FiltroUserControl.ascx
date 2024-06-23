<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltroUserControl.ascx.cs" Inherits="HelitonWebForm.Control.FiltroUserControl" %>
<div class="container">  
    <div class="controls">
        <%-- Formatação campos --%>
        <asp:RegularExpressionValidator ID="txtExpressao1" ControlToValidate="flt_nrocamisa" ValidationGroup="Insert" ForeColor="Red" Display="Dynamic" ErrorMessage="Camisa somente número inteiro, verifique!" ValidationExpression="^\d+([,\.]\d{0})?$" runat="server"></asp:RegularExpressionValidator>
        <%-- campos Filtro --%>        
        <asp:TextBox id="flt_nrocamisa" Text="" MaxLength="6" class="form-control" placeholder="Número da Camisa" style="position: relative; top:9px; left:-9px; width: 200px;" runat="server" ></asp:TextBox>
        <asp:TextBox id="flt_apelido" Text="" MaxLength="50" class="form-control" placeholder="Apelido" style="position: relative; top:-29px; left:200px; width: 285px;" runat="server" ></asp:TextBox>
        <asp:DropDownList ID="flt_classificaimc" class="form-control"  placeholder="Classificação IMC" style="position: relative; top:-67px; left:499px; width: 220px;" runat="server">    
            <asp:ListItem Value="0">Classificação IMC</asp:ListItem>    
            <asp:ListItem Value="1">Abaixo do peso normal</asp:ListItem>    
            <asp:ListItem Value="2">Peso normal</asp:ListItem>    
            <asp:ListItem Value="3">Excesso de peso</asp:ListItem>    
            <asp:ListItem Value="4">Obsidade classe I</asp:ListItem>    
            <asp:ListItem Value="5">Obsidade classe II</asp:ListItem>    
            <asp:ListItem Value="6">Obsidade classe III</asp:ListItem>    
        </asp:DropDownList>
    </div>
</div>