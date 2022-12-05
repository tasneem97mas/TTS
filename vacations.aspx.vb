
Imports DevExpress.ASPxSpellChecker

Partial Class vacations
    Inherits System.Web.UI.Page

    Private Sub vac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vac.SelectedIndexChanged

        Dim SqlString As String
        SqlString = "SELECT  [VocID],[EmployeeName],[JobName],[Department] ,[Branch],[Vocation],[FromDate],[ToDate] ,[NoDays] FROM [OrdersApp].[dbo].[VocationView]"

        Dim act As String


        act = vac.SelectedItem.Text
        If act = "أمومة" Then
            SqlString &= " where Vocation=N'أمومة'"

        ElseIf act = "بدون راتب" Then

            SqlString &= " where Vocation=N'بدون راتب'"

        ElseIf act = "سنوية" Then
            SqlString &= " where Vocation=N'سنوية'"

        ElseIf act = "عطل رسمية" Then
            SqlString &= " where Vocation=N'عطل رسمية'"

        ElseIf act = "عطلة اسبوعية" Then
            SqlString &= " where Vocation=N'عطلة اسبوعية'"

        ElseIf act = "مرضية" Then
            SqlString &= " where Vocation=N'مرضية'"

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
        SqlString = "SELECT  [VocID],[EmployeeName],[JobName],[Department] ,[Branch],[Vocation],[FromDate],[ToDate] ,[NoDays] FROM [OrdersApp].[dbo].[VocationView]"



        If Len(nam.Text) > 0 Then
            SqlString &= " where convert(nvarchar,[VocID]) + [EmployeeName] + isnull([JobName],'') +isnull([Department],'')+[Branch]+[Vocation]+convert(nvarchar,[FromDate])+convert(nvarchar,[ToDate])+ convert(nvarchar,[NoDays]) like N'%" & nam.Text & "%'"
        End If
        SqlString &= " order by EmployeeName asc "

        sqlemps.SelectCommand = SqlString

        DG.DataBind()
    End Sub

End Class
