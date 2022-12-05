
Partial Class main_
    Inherits System.Web.UI.Page


    Protected Sub Active_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Active.SelectedIndexChanged
        Dim SqlString As String
        SqlString = "SELECT [EmployeeID] ,[EmployeeName]  ,[RefMobile]  ,[JobName] ,[Department] ,[Branch],[PeriodFromStart] ,[Active] ,[EmplStatus] FROM [dbo].[EmployeesView]"
        Dim act As String


        act = Active.SelectedItem.Text
        If act = "فعال" Then
            SqlString &= " where EmplStatus=N'فعال'"
            lblcnt.BackColor = System.Drawing.ColorTranslator.FromHtml("#10c469")
        ElseIf act = "غير فعال" Then

            SqlString &= " where EmplStatus=N'غير فعال'"
            lblcnt.BackColor = System.Drawing.Color.Red
        ElseIf act = "مجاز" Then
            SqlString &= " where EmplStatus=N'مجاز'"
            lblcnt.BackColor = System.Drawing.ColorTranslator.FromHtml("#10c469")
        End If
        SqlString &= " order by EmployeeName asc "
        sqlemps.SelectCommand = SqlString

        DG.DataBind()
    End Sub

    Private Sub sqlemps_Selected(sender As Object, e As SqlDataSourceStatusEventArgs) Handles sqlemps.Selected
        lblcnt.Text = e.AffectedRows
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        doSearch()
    End Sub

    Private Sub nam_TextChanged(sender As Object, e As EventArgs) Handles nam.TextChanged
        doSearch()
    End Sub

    Private Sub doSearch()
        Dim SqlString As String
        SqlString = "SELECT [EmployeeID] ,[EmployeeName]  ,[RefMobile]  ,[JobName] ,[Department] ,[Branch],[PeriodFromStart] ,[Active] ,[EmplStatus] " &
            "  FROM [dbo].[EmployeesView]"



        If Len(nam.Text) > 0 Then
            SqlString &= " where convert(nvarchar,[EmployeeID]) + [EmployeeName] + [RefMobile] +[JobName]+[Department]+[Branch]+[PeriodFromStart]+[EmplStatus] like N'%" & nam.Text & "%'"
        End If
        SqlString &= " order by EmployeeName asc "

        sqlemps.SelectCommand = SqlString

        DG.DataBind()
    End Sub

    Private Sub main__Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblcnt.BackColor = System.Drawing.ColorTranslator.FromHtml("#10c469")
        End If

    End Sub
End Class
