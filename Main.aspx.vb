
Imports System.Data.SqlTypes

Partial Class main
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Dim SqlString As String
            'SqlString = " Declare @Temp as DECIMAL(18,2)  Set @Temp=(Select top(1)  DATEDIFF(day,E.DateOfStart,getdate() ) As RemainingPrcentage  from  [dbo].[EmployeesData] E where Active=1  )select EmployeeID,Birthday,EmployeeName,RefMobile,JobName,Department,Branch,EmployeeType,DateOfStart,DateOfEnd,RemainingPrcentage, Convert(nvarchar(50) ,PeriodYear)+Convert(nvarchar(50) ,N'سنة ')+Convert(nvarchar(50) ,N'و ') +Convert(nvarchar(50) ,PeriodMonth)  +Convert(nvarchar(50) ,N'شهر ') As PeriodFromStart, Active,Case When InVocation is null then 1 else 0 end as InVocation, case when Active=0 then 'NotActive'  when Active=1 and InVocation is null then 'Active' when Active=1 and InVocation Is Not  Null then 'Invocation' end as EmplStatus   from (SELECT E.[EmployeeID],[EmployeeName]  ,[Mobile1] as RefMobile,Birthday,JobName,[Department],[Branch],T.EmployeesType As EmployeeType,DateOfStart,DateOfEnd,[Active],      Case When E.DateOfStart <> '1900-01-01' then (DATEDIFF(yy, E.DateOfStart, GETDATE()) - CASE WHEN (MONTH(E.DateOfStart) > MONTH(GETDATE())) OR (MONTH(E.DateOfStart) = MONTH(GETDATE()) AND DAY(E.DateOfStart) > DAY(GETDATE())) THEN 1 ELSE 0 END) Else '0' End as PeriodYear, Case When E.DateOfStart <> '1900-01-01' then DATEDIFF(m, DATEADD(yy, (DATEDIFF(yy, E.DateOfStart, GETDATE()) - CASE WHEN (MONTH(E.DateOfStart) > MONTH(GETDATE())) OR (MONTH(E.DateOfStart) = MONTH(GETDATE()) AND DAY(E.DateOfStart) > DAY(GETDATE())) THEN 1 ELSE 0 END), E.DateOfStart), GETDATE()) - CASE WHEN DAY(E.DateOfStart) > DAY(GETDATE()) THEN 1 ELSE 0 END else 0 end  As PeriodMonth , Case When E.DateOfStart <> '1900-01-01' then  case when @Temp > 1 then CAST(DATEDIFF(day,E.DateOfStart,getdate())* 100/@Temp  AS DECIMAL(18,2)) end else 0 end as RemainingPrcentage    FROM    [dbo].[EmployeesData] E  Left Join [dbo].[EmployeesTypes] T On E.EmployeeType=T.[ID]  ) A left join (Select EmployeeID As InVocation from Vocations where getdate() between FromDate And  DATEADD(hour,23,cast(cast(ToDate As Date) As datetime))) B on A.EmployeeID=B.InVocation "


            'sqlemps.SelectCommand = SqlString


        End If
    End Sub

    Protected Sub Active_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Active.SelectedIndexChanged
        Dim SqlString As String
        SqlString = "SELECT [EmployeeID] ,[EmployeeName]  ,[RefMobile]  ,[JobName] ,[Department] ,[Branch],[PeriodFromStart] ,[Active] ,[EmplStatus] FROM [dbo].[EmployeesView]"
        Dim act As String


        act = Active.SelectedItem.Text
        If act = "فعال" Then
            SqlString &= " where EmplStatus=N'فعال'"
        ElseIf act = "غير فعال" Then

            SqlString &= " where EmplStatus=N'غير فعال'"
        ElseIf act = "مجاز" Then
            SqlString &= " where EmplStatus=N'مجاز'"

        End If

        sqlemps.SelectCommand = SqlString

        DG.DataBind()
    End Sub


    
End Class
