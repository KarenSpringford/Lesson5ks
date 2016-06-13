<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="Lesson5ks.Courses" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Course List</h1>
                <a href="CourseDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus fa-lg"></i> Add Course</a>
                

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

                <asp:GridView runat="server" ID="CoursesGridView" AutoGenerateColumns="false" CSSClass="table table-bordered table-striped table-hover" OnRowDeleting="CoursesGridView_RowDeleting"
                    AllowPaging="true" OnPageIndexChanging="CoursesGridView_PageIndexChanging" 
                    PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="CourseID" HeaderText="Course ID" Visible="true"/>
                        <asp:BoundField DataField="Title" HeaderText="Title" Visible="true"/>
                        <asp:BoundField DataField="Credits" HeaderText="Credits" Visible="true"/>
                        <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" Visible="true"/>
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
