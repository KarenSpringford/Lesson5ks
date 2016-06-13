<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="Lesson5ks.Departments" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Departments</h1>
                <br />
                <a href="DepartmentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus fa-lg"></i> Add Department</a>
                <br />
                <asp:Gridview runat="server" AutoGenerateColumns="false" CSSClass="table table-bordered table-striped table-hover" 
                    ID="DepartmentsGridView">
                    <Columns>
                        <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" Visible="true"/>
                        <asp:BoundField DataField="Name" HeaderText="Name" Visible="true"/>
                        <asp:BoundField DataField="Budget" HeaderText="Budget" Visible="true" DataFormatString = "{0:C2}"/>

                    </Columns>
                </asp:Gridview>
            </div>
        </div>
</div>
</asp:Content>
