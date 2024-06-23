<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelitonWebForm._Default" %>

<%@ Register Src="~/Control/FiltroUserControl.ascx" TagPrefix="uc1" TagName="ContactUC" %>
<%@ Register Src="~/Control/FormUserControl.ascx" TagPrefix="uc2" TagName="FormUC" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <%-- Mensagem --%>
        <span class="label" id="msg" style="width: 100%;text-align: center; color:red" runat="server"></span>

        <%-- Pesquisar --%>
        <div id="divPesquisar" runat="server" visible="true">
            <%-- Botões Pesquisar e Adicionar --%>
            <div>
                <asp:Button Text="Pesauisar" id="Pesquisar" class="btn btn-primary btn-md" runat="server" OnClick="Pesquisar_Click" />
                <asp:Button Text="Adicionar" id="Adicionar" class="btn btn-primary btn-md" runat="server" OnClick="Adicionar_Click" />
            </div>
            <%-- Filtros --%>
            <uc1:ContactUC runat="server" id="ContactUC"/> 

            <%-- Lista Pesquisada --%>
            <asp:GridView id="lista" CssClass="table table-hover" AutoGenerateColumns="false" runat="server" Width="100%" BorderStyle="None">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
                    <asp:BoundField DataField="Nrocamisa" HeaderText="Camisa" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Apelido" HeaderText="Apelido" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Posicao" HeaderText="Posição" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Idade" HeaderText="Idade" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="Altura" HeaderText="Altura" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Right"/>
                    <asp:BoundField DataField="Peso" HeaderText="Peso" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Right"/>
                    <asp:BoundField DataField="IMC" HeaderText="IMC" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Right"/>
                    <asp:BoundField DataField="ClassificaIMC" HeaderText="Classificação IMC" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Right"/>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:Button id="Editar" Text="Editar" Width="65px" CssClass="btn btn-primary btn-md" onClick="Editar_Click" CommandArgument = '<%# Eval("id") %>' runat="server"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Excluir">
                        <ItemTemplate>
                            <asp:Button id="Excluir" Text="Excluir" Width="65px" CssClass="btn btn-primary btn-md" onClick="Excluir_Click" CommandArgument = '<%# Eval("id") %>' runat="server"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%-- Form Incluir ou Editar --%>
        <div id="divAdicinar" runat="server" visible="false">
            <uc2:FormUC runat="server" id="FormUC"/> 
        </div>

    </main>

</asp:Content>