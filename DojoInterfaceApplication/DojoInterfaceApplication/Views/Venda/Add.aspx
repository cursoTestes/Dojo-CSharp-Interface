<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DojoInterfaceApplication.Models.VendaModel>" %>

<asp:Content ID="vendaTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Venda
</asp:Content>

<asp:Content ID="vendaContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Adicione uma venda</h2>
     
    <% using (Html.BeginForm()) { %>
    <h2><%: ViewData["Message"] %></h2>
        <div>
            <fieldset>
                <legend>Dados da Venda</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Vendedor) %>
                </div>
                <div id="vendedor" class="editor-field">
                    <%: Html.TextBoxFor(m => m.Vendedor) %>
                    <%: Html.ValidationMessageFor(m => m.Vendedor, null, new {id = "validacaoVendedor" })%>
                </div>
                
                <div class="editor-label" >
                    <%: Html.LabelFor(m => m.DataVenda) %>
                </div>
                <div class="editor-field" id="dataDaVenda">
                    <%: Html.TextBoxFor(m => m.DataVenda)%>
                    <%: Html.ValidationMessageFor(m => m.DataVenda, null, new { id = "validacaoDataVenda" })%>
                </div>
                
                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Valor) %>
                </div>
                <div class="editor-field" id="valorVenda">
                    <%: Html.TextBoxFor(m => m.Valor)%>
                    <%: Html.ValidationMessageFor(m => m.Valor, null, new { id = "validacaoValor" })%>
                </div>
                
                <p>
                    <input type="submit" value="Add" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
