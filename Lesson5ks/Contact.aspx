<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lesson5ks.Contact" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-4 col-md-8">
                <h1>Contact Us</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        <h3 class="panel-title">Contact Info</h3>
                    </div>
                    <div class="panel-body">
                        <address>
                            <strong>Contosa University</strong><br>
                            666 Elm Street<br>
                            Alcona ON L3Y5V9<br>
                            <abbr title="Phone">Tel:</abbr>
                            (905) 867-5309
                        </address>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
               
                <div class="form-group">
                    <label class="control-label" for="form-group-input">First Name</label>
                    <asp:TextBox runat="server" Cssclass="form-control" ID="FirstNameTextBox" required="true" placeholder="First Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="alert-danger" runat="server" ErrorMessage="First Name is Required" ControlToValidate="FirstNameTextBox" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Last Name</label>
                    <asp:TextBox runat="server" Cssclass="form-control" ID="LastNameTextBox" required="true" placeholder="Last Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="alert-danger" runat="server" ErrorMessage="Last Name is Required" ControlToValidate="LastNameTextBox" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                     </div>
                <div class="form-group">
                    <label class="control-label" for="EmailTextBox">Email: </label>
                    <asp:TextBox runat="server" TextMode="Email" Cssclass="form-control" ID="EmailTextBox" required="true" placeholder="joe.smith@gmail.com "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="alert-danger" runat="server" ErrorMessage="Email Required" ControlToValidate="EmailTextBox" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="ContactNumberTextBox">Phone #: </label>
                    <asp:TextBox runat="server" TextMode="Phone" Cssclass="form-control" ID="ContactNumberTextBox" required="true" placeholder="(905)865-5309 "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="alert-danger" runat="server" ErrorMessage="Contact Number Required" ControlToValidate="ContactNumberTextBox" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="control-label" for="MessageTextBox">Message: </label>
                    <asp:TextBox runat="server" TextMode="Multiline" Columns="3" Rows="3" Cssclass="form-control" ID="MessageTextBox" required="true" placeholder="Write your message here!"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="alert-danger" runat="server" ErrorMessage="Message Required" ControlToValidate="MessageTextBox" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <div class="text-right">
                    <a class="btn btn-danger btn-lg" id="CancelButton" href="Default.aspx">Cancel</a>
                    <asp:Button runat="server" ID="SubmitButton" Text="Submit" CssClass="btn btn-primary btn-lg" OnClick="SubmitButton_Click" CausesValidation="true"/>
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>
