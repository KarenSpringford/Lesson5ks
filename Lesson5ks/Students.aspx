<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Lesson5ks.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <br />
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus fa-lg"></i>Add Student</a>


                <div>
                    <label for="PageSizeDropDownList">Records Per Page</label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default btn-small dropdown-toggle"
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>

                <asp:GridView runat="server" ID="StudentsGridView" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="StudentID"
                    OnRowDeleting="StudentsGridView_RowDeleting" AllowPaging="true" OnPageIndexChanging="StudentsGridView_PageIndexChanging"
                    PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true"
                            DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
