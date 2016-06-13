<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Lesson5ks.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <br />
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus fa-lg"></i> Add Student</a>
                <br />
                <asp:GridView runat="server" ID="StudentsGridView" AutoGenerateColumns="false" CSSClass="table table-bordered table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true"/>
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true"/>
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true"/>
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true"
                            DataFormatString ="{0:MMM dd, yyyy}"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
