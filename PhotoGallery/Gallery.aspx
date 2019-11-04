<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="PhotoGallery.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="myFileUpload" runat="server" Text="Choose a file" />
    <asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click" />
    <asp:Label ID="statusLabel" runat="server" Text="Displaying info"></asp:Label>
</asp:Content>
