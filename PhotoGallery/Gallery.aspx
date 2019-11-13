<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="PhotoGallery.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="myFileUpload" runat="server" Text="Choose a file" />
    <asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click" />
    <asp:Label ID="statusLabel" runat="server" Text="Displaying info"></asp:Label>
    <asp:Repeater ID="RepeaterUserPhoto" runat="server">
        <ItemTemplate>
            <img  id="imgUserPhotoImg" src="<%# Container.DataItem %>" style="width: 100px; height: 100px;" runat="server" alt='' onmouseover="preview.src=this.src" />
        </ItemTemplate>
    </asp:Repeater>
    <img id="preview" src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAA  AAALAAAAAABAAEAAAICR  AEAOw==" alt="" width="400" />
</asp:Content>