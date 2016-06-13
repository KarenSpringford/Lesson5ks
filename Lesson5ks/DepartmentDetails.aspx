<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="Lesson5ks.DepartmentDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Department Details</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="DepartmentIDTextBox">Department ID</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmentIDTextBox" ReadOnly="false" Enabled="false" required="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DepartmentTextBox">Department</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmentTextBox" placeholder="Department" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="BudgetTextBox">Budget</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="BudgetTextBox" placeholder="Budget ie: 20000" required="true"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Budget 20000 - 50000"
                        ControlToValidate="BudgetTextBox" MinimumValue="20000" MaximumValue="50000"
                        Type="Currency" Display="Dynamic" BackColor="Red" ForeColor="White" Font-Size="Large"></asp:RangeValidator>
                </div>
                <br />
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn-danger btn-lg" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Submit" ID="SaveButton" CssClass="btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
