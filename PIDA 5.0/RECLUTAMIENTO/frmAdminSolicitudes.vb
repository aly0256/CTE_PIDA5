Public Class frmAdminSolicitudes
    Dim dtSolicitudes As DataTable
    Dim dtPerfil As DataTable
    Dim query As String = ""
    Dim requi As String = ""
    Dim codvacante As String = ""

    Private Sub frmAdminSolicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbStatus.Text = "No exportadas"
        cmbStatus.Items.Add("No exportadas")
        cmbStatus.Items.Add("Exportadas")
        cmbStatus.Items.Add("Todas")
        cmbVacantes.DataSource = sqlExecute("select cod_vac, vacante from reclutamiento.dbo.vacantes")
        query = "where (c.layout = 0 or c.layout is null)"
        MostrarInformacion()
    End Sub

    Private Sub MostrarInformacion()
        Try
            dtSolicitudes = sqlExecute("select c.folio,  v.cod_vac, v.vacante, rtrim(c.nombre)+' '+rtrim(c.segundonombre)+' '+rtrim(c.paterno)+' '+rtrim(c.materno) as nombre, " & _
                                       "c.fhaapli, c.AprobadoMedico as medicoAprobado, c.AprobadoEntrevistaRH as EntrevistaRHAprobado, c.AprobadoSupervisor as supervisorAprobado, c.AprobadoRH as RHAprobado, c.layout, c.agencia from reclutamiento.dbo.candidatos c " & _
                                       "join reclutamiento.dbo.vacantes v on c.cod_vac = v.cod_vac " & query & requi)
            dgSolicitudes.DataSource = dtSolicitudes
            dgSolicitudes.AutoGenerateColumns = False
            dgSolicitudes.Columns("folio").DisplayIndex = 0
            dgSolicitudes.Columns("cod_vacc").DisplayIndex = 1
            dgSolicitudes.Columns("colVacante").DisplayIndex = 2
            dgSolicitudes.Columns("colNombre").DisplayIndex = 3
            dgSolicitudes.Columns("colfhaApli").DisplayIndex = 4
            dgSolicitudes.Columns("colfhaApli").Width = 60
            dgSolicitudes.Columns("agencia").DisplayIndex = 5
            dgSolicitudes.Columns("solicitud").DisplayIndex = 6
            dgSolicitudes.Columns("Layouts").DisplayIndex = 7
            dgSolicitudes.Columns("Posicion").DisplayIndex = 8
            dgSolicitudes.Columns("EntrevistaRHBuscar").DisplayIndex = 9
            dgSolicitudes.Columns("EntrevistaRHAprobado").DisplayIndex = 10
            dgSolicitudes.Columns("SupervisorBuscar").DisplayIndex = 11
            dgSolicitudes.Columns("supervisorAprobado").DisplayIndex = 12
            dgSolicitudes.Columns("medicoBuscar").DisplayIndex = 13
            dgSolicitudes.Columns("medicoAprobado").DisplayIndex = 14
            dgSolicitudes.Columns("RHBuscar").DisplayIndex = 15
            dgSolicitudes.Columns("RHAprobado").DisplayIndex = 16
            dgSolicitudes.Columns("Exportado").DisplayIndex = 17

            'deshabilitar columnas y botones para los que no son de RH
            dtPerfil = sqlExecute("SELECT cod_perfil FROM appuser WHERE username = '" & Usuario & "'", "seguridad")
            If dtPerfil.Rows.Count > 0 Then
                Select Case dtPerfil.Rows(0).Item("cod_perfil").ToString.Trim
                    Case "SERMED", "RHTHRLYRM"  'medico
                        dgSolicitudes.Columns("EntrevistaRHBuscar").Visible = False
                        dgSolicitudes.Columns("SupervisorBuscar").Visible = False
                        'dgSolicitudes.Columns("medicoBuscar").Visible = False
                        dgSolicitudes.Columns("RHBuscar").Visible = False
                        dgSolicitudes.Columns("solicitud").Visible = False
                        dgSolicitudes.Columns("Layouts").Visible = False
                        dgSolicitudes.Columns("Posicion").Visible = False
                        btnLayouts.Visible = False
                        btnSolicitudes.Visible = False
                        ButtonX2.Visible = False
                        btnLiberarPosiciones.Visible = False
                    Case "RECLUSUPERVISOR", "RHTHRLYRS"    'supervisor
                        dgSolicitudes.Columns("EntrevistaRHBuscar").Visible = False
                        'dgSolicitudes.Columns("SupervisorBuscar").Visible = False
                        dgSolicitudes.Columns("medicoBuscar").Visible = False
                        dgSolicitudes.Columns("RHBuscar").Visible = False
                        dgSolicitudes.Columns("solicitud").Visible = False
                        dgSolicitudes.Columns("Posicion").Visible = False
                        dgSolicitudes.Columns("Layouts").Visible = False
                        btnLayouts.Visible = False
                        btnSolicitudes.Visible = False
                        ButtonX2.Visible = False
                        btnLiberarPosiciones.Visible = False
                    Case "ADMINISTRADOR", "RECLURH", "RHTHRLYC", "RHTHRLYR"  'Full Access
                End Select
            End If
            'Bloquear para layout los renglones importados
            'For Each row As DataRow In dtSolicitudes.Select("layout = 1")
            '    For Each dgRow As DataGridViewRow In dgSolicitudes.Rows
            '        If dgRow.Cells("folio").Value.ToString.Trim.Equals(row.Item("folio").ToString.Trim) Then
            '            dgRow.Cells("Layouts").ReadOnly = True
            '        End If
            '    Next
            'Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Public Class CandidatoIDS
        Implements IEquatable(Of CandidatoIDS)
        Public Property Folio() As String
            Get
                Return m_Folio
            End Get
            Set(value As String)
                m_Folio = value
            End Set
        End Property
        Private m_Folio As String

        Public Property UserID() As String
            Get
                Return m_UserID
            End Get
            Set(value As String)
                m_UserID = value
            End Set
        End Property
        Private m_UserID As String

        Public Property sfID() As String
            Get
                Return m_sfID
            End Get
            Set(value As String)
                m_sfID = value
            End Set
        End Property
        Private m_sfID As String

        Public Overrides Function ToString() As String
            Return "Folio: " & Folio & "   User ID: " & UserID & "   SF ID: " & sfID
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then
                Return False
            End If
            Dim objAsCandidatoIDS As CandidatoIDS = TryCast(obj, CandidatoIDS)
            If objAsCandidatoIDS Is Nothing Then
                Return False
            Else
                Return Equals(objAsCandidatoIDS)
            End If
        End Function
        Public Overrides Function GetHashCode() As Integer
            'Return UserID
            Return sfID
        End Function
        Public Overloads Function Equals(other As CandidatoIDS) As Boolean _
            Implements IEquatable(Of CandidatoIDS).Equals
            If other Is Nothing Then
                Return False
            End If
            'Return (Me.UserID.Equals(other.UserID))
            Return (Me.sfID.Equals(other.sfID))
        End Function

    End Class

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnLayouts.Click
        Dim strFolios As String = ""
        Dim dtLayouts As DataTable
        Dim dtHeaders As DataTable
        Dim dtRelojes As DataTable
        Dim strPlanta As String = "MXQ"  'MXQ Queretaro  MXJ Juarez
        Dim strReloj As String = ""
        Dim strRelojSF As String = ""
        'Dim strUserID As String = ""
        Dim strPath As String = ""
        Dim listaCandidatos As New List(Of CandidatoIDS)()
        Dim dr As System.Data.DataRow
        Dim blnFaltaAprobacionMsg As Boolean = False
        Try
            Dim result As Integer = MessageBox.Show("¿Deseas confirmar el envío de los archivos para su procesamiento? ", "Confirmar envio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.OK Then

            End If
            Dim oFileStream As System.IO.FileStream
            Dim byteData() As Byte
            Dim dtPathP As DataTable = sqlExecute("select top 1 path_layouts_reclutamiento from parametros ", "reclutamiento")
            If dtPathP.Rows.Count > 0 Then
                strPath = dtPathP.Rows(0).Item("path_layouts_reclutamiento").ToString.Trim
            Else
                strPath = ""
            End If
            If strPath.Trim.Length > 0 Then
                For Each row As DataGridViewRow In dgSolicitudes.Rows
                    If row.Cells("Layouts").Value Then
                        If row.Cells("EntrevistaRHAprobado").Value And row.Cells("supervisorAprobado").Value And row.Cells("medicoAprobado").Value And row.Cells("RHAprobado").Value Then
                            strReloj = ""
                            strRelojSF = ""
                            'dtRelojes = sqlExecute("select RelojPida, RelojSF from reclutamiento.dbo.candidatos where folio = '" & row.Cells("Folio").Value.ToString & "'")
                            dtRelojes = sqlExecute("select RelojSF from reclutamiento.dbo.candidatos where folio = '" & row.Cells("Folio").Value.ToString & "'")
                            If dtRelojes.Rows.Count() > 0 Then
                                'If dtRelojes.Rows(0).Item("RelojPida").ToString().Trim().Length > 0 Then
                                '    strReloj = dtRelojes.Rows(0).Item("RelojPida").ToString().Trim()
                                'End If
                                If dtRelojes.Rows(0).Item("RelojSF").ToString().Trim().Length > 0 Then
                                    strRelojSF = dtRelojes.Rows(0).Item("RelojSF").ToString().Trim()
                                End If
                            End If
                            'If strReloj.Trim.Length = 0 Then
                            If strRelojSF.Trim.Length = 0 Then
                                strReloj = SiguienteReloj()  'checar que sea diferente a "000000"
                                strRelojSF = strPlanta & strReloj.TrimStart("0"c)
                            End If
                            If strReloj <> "000000" Then
                                listaCandidatos.Add(New CandidatoIDS() With { _
                                        .Folio = row.Cells("Folio").Value.ToString, _
                                        .UserID = strReloj, _
                                        .sfID = strRelojSF _
                                })
                                strFolios &= "'" & row.Cells("Folio").Value.ToString & "',"
                            End If
                        Else
                            blnFaltaAprobacionMsg = True
                        End If
                    End If
                Next
                If blnFaltaAprobacionMsg Then
                    MessageBox.Show("No se generaron algunos layouts por falta de aprobaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If strFolios.Length <= 0 Then
                    MessageBox.Show("No selecciono ningun candidato para exportar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                strFolios &= ","
                strFolios = strFolios.Replace(",,", "")
                Dim dtDatosCorreo = sqlExecute("select distinct v.NumRequisicion, v.Vacante " & _
                                      "from reclutamiento.dbo.candidatos c join reclutamiento.dbo.vacantes v on c.cod_vac = v.cod_vac and c.folio in (" & strFolios & ")")
                Dim strNumReq As String = ""
                Dim strVacantes As String = ""
                For Each dRow As DataRow In dtDatosCorreo.Rows
                    strNumReq &= dRow.Item("NumRequisicion")
                    strVacantes &= dRow.Item("Vacante")
                Next
                strNumReq = strNumReq.TrimEnd
                'Basic Info
                dtLayouts = New DataTable
                dtLayouts.Columns.Add("STATUS", GetType(String))
                dtLayouts.Columns.Add("USERID", GetType(String))
                dtLayouts.Rows.Add("STATUS", "USERID")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    dtLayouts.Rows.Add("Active", itemCandidato.sfID)
                Next
                byteData = csvBytesWriter(dtLayouts)
                oFileStream = New System.IO.FileStream(strPath & "\Basic Import_" & strNumReq & "_1.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Biographical Info
                dtLayouts = sqlExecute("select folio,'' as [user-id], Cod_Pais_Nac as [country-of-birth], CONVERT(VARCHAR(10), FhaNac, 101) as  [date-of-birth], '' as [person-id-external], lugar_nac collate SQL_Latin1_General_Cp1251_CS_AS as [place-of-birth], EdoNac collate SQL_Latin1_General_Cp1251_CS_AS as [region-of-birth] " & _
                                           "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                        dRow.Item("person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("user-id")
                dtHeaders.Columns.Add("country-of-birth")
                dtHeaders.Columns.Add("date-of-birth")
                dtHeaders.Columns.Add("person-id-external")
                dtHeaders.Columns.Add("place-of-birth")
                dtHeaders.Columns.Add("region-of-birth")
                dtHeaders.Rows.Add("User ID", "Country Of Birth(Mexico & Belgium)", "Date Of Birth", "Person Id", "Place Of Birth(Mexico & Belgium)", "State Of Birth(Mexico)")
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Biographical Information_" & strNumReq & "_2.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Employment Details
                dtLayouts = sqlExecute("select folio, case Reingreso when '1' then '&&NO_OVERWRITE&&' when '0' then CONVERT(VARCHAR(10), FechaAlta, 101) else CONVERT(VARCHAR(10), FechaAlta, 101) end as [start-date], '' as  [person-id-external], '' as [user-id], " & _
                                       "case Reingreso when '1' then '&&NO_OVERWRITE&&' when '0' then CONVERT(VARCHAR(10), FechaAlta, 101) else CONVERT(VARCHAR(10), FechaAlta, 101) end as [originalStartDate], " & _
                                       "CONVERT(VARCHAR(10), FechaAntiguedad, 101) as  [seniorityDate], CONVERT(VARCHAR(10), FechaAlta, 101) as [serviceDate], CONVERT(VARCHAR(10), FechaVacaciones, 101) as  [custom-date22] " & _
                                           "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                        dRow.Item("person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("start-date")
                dtHeaders.Columns.Add("person-id-external")
                dtHeaders.Columns.Add("user-id")
                dtHeaders.Columns.Add("originalStartDate")
                dtHeaders.Columns.Add("seniorityDate")
                dtHeaders.Columns.Add("serviceDate")
                dtHeaders.Columns.Add("custom-date22")
                dr = dtHeaders.NewRow
                dr("start-date") = "Hire/Re-hire Date"
                dr("person-id-external") = "Person ID External"
                dr("user-id") = "User ID"
                dr("originalStartDate") = "Original Start Date"
                dr("seniorityDate") = "Seniority Start Date"
                dr("serviceDate") = "Service Date"
                dr("custom-date22") = "Vacation Date"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Employment Details_" & strNumReq & "_3.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Job Info
                'dtLayouts = sqlExecute("select distinct c.folio, dpto.unit as [business-unit], CONVERT(VARCHAR(10), c.FechaAlta, 101) as  [start-date], '' as [user-id],  c.ClaseEmpleadoNombre as [custom-string16], " & _
                '                       "left(v.Depto,5) as [department], dpto.division as [division], case c.Reingreso when '0' then '7A7A' when '1' then '7G7A' else '7A7A' end as  [event-reason], '0610' as  company, " & _
                '                       "'MXQUE_01' as  [location], c.Position as  [position], (select SUBSTRING(v.Supervisor,1,(SELECT CHARINDEX('-', v.Supervisor)-1))) as [manager-id], rtrim('000100000'+SUBSTRING(v.CCostos, 1, CHARINDEX('-', v.CCostos)-1)) as  [cost-center], " & _
                '                       "'Employee' as [employee-class], c.EmployeeTypeFortia as [custom-string15], te.nombre as [employment-type], '1' as fte, 'Q1' as [holiday-calendar-code], 'Yes' as [is-fulltime-employee], " & _
                '                       "replace(v.cod_puesto,'Q_','') as [job-code], CONVERT(VARCHAR(10), c.FechaAlta, 101) as jobEntryDate, SUBSTRING(v.puesto, CHARINDEX('-', v.puesto) + 2, len(v.puesto)) as [job-title], SUBSTRING(v.puesto, CHARINDEX('-', v.puesto) + 2, len(v.puesto)) as [local-job-title], ISNULL(LEFT(n.Nivel, LEN(n.Nivel) - 1),'') as [custom-string2], " & _
                '                       "n.Nivel as [custom-string3], 'Queretaro' as payScaleArea, n.PayScaleGroup as payScaleGroup, n.PayScaleLevel as payScaleLevel, 'Operatives' as payScaleType, 'Permanent' as [regular-temp], " & _
                '                       "c.HorasSemanales as [standard-hours], 'MEX_HOURLY_QUERETARO' as [time-type-profile-code], 'US/Central' as timezone, 'Perm Full-time' as [custom-string4], c.Horario_cod_sf as [workschedule-code], c.DiasSemana as workingDaysPerWeek " & _
                '                       "from reclutamiento.dbo.candidatos c inner join reclutamiento.dbo.Vacantes v on c.cod_vac = v.cod_vac left join reclutamiento.dbo.tipo_empleado te on c.tipoempleado = te.cod_tipo_empleado " & _
                '                       "left join personal.dbo.deptos dpto on left(v.Depto,5) = dpto.cod_depto and dpto.cod_comp = 'WME'" & _
                '                       "left join personal.dbo.niveles n on c.Nivel = n.Nivel and n.cod_comp = 'WME'" & _
                '                       "where folio in (" & strFolios & ")")

                dtLayouts = sqlExecute("select distinct c.folio, dpto.unit as [business-unit], CONVERT(VARCHAR(10), c.FechaAlta, 101) as  [start-date], '' as [user-id],  c.ClaseEmpleadoNombre as [custom-string16], " & _
                       "left(v.Depto,5) as [department], dpto.division as [division], case c.Reingreso when '0' then '7A7A' when '1' then '7G7A' else '7A7A' end as  [event-reason], '0610' as  company, " & _
                       "'MXQUE_01' as  [location], pos.num_posicion as  [position], (select SUBSTRING(v.Supervisor,1,(SELECT CHARINDEX('-', v.Supervisor)-1))) as [manager-id], rtrim('000100000'+SUBSTRING(v.CCostos, 1, CHARINDEX('-', v.CCostos)-1)) as  [cost-center], " & _
                       "'Employee' as [employee-class], c.EmployeeTypeFortia as [custom-string15], te.nombre as [employment-type], '1' as fte, 'Q1' as [holiday-calendar-code], 'Yes' as [is-fulltime-employee], " & _
                       "replace(v.cod_puesto,'Q_','') as [job-code], CONVERT(VARCHAR(10), c.FechaAlta, 101) as jobEntryDate, SUBSTRING(v.puesto, CHARINDEX('-', v.puesto) + 2, len(v.puesto)) as [job-title], SUBSTRING(v.puesto, CHARINDEX('-', v.puesto) + 2, len(v.puesto)) as [local-job-title], ISNULL(LEFT(n.Nivel, LEN(n.Nivel) - 1),'') as [custom-string2], " & _
                       "n.Nivel as [custom-string3], 'Queretaro' as payScaleArea, n.PayScaleGroup as payScaleGroup, n.PayScaleLevel as payScaleLevel, 'Operatives' as payScaleType, 'Permanent' as [regular-temp], " & _
                       "c.HorasSemanales as [standard-hours], 'MEX_HOURLY_QUERETARO' as [time-type-profile-code], 'US/Central' as timezone, 'Perm Full-time' as [custom-string4], c.Horario_cod_sf as [workschedule-code], c.DiasSemana as workingDaysPerWeek " & _
                       "from reclutamiento.dbo.candidatos c inner join reclutamiento.dbo.Vacantes v on c.cod_vac = v.cod_vac left join reclutamiento.dbo.tipo_empleado te on c.tipoempleado = te.cod_tipo_empleado " & _
                       "left join personal.dbo.deptos dpto on left(v.Depto,5) = dpto.cod_depto and dpto.cod_comp = 'WME'" & _
                       "left join personal.dbo.niveles n on c.Nivel = n.Nivel and n.cod_comp = 'WME'" & _
                       "left join reclutamiento.dbo.posiciones pos on c.Position = pos.cod_posicion " & _
                       "where folio in (" & strFolios & ")")

                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("business-unit")  'personal.dbo.deptos.unit
                dtHeaders.Columns.Add("start-date")
                dtHeaders.Columns.Add("user-id")
                dtHeaders.Columns.Add("custom-string16")
                dtHeaders.Columns.Add("department")
                dtHeaders.Columns.Add("division")      'personal.dbo.deptos.division
                dtHeaders.Columns.Add("event-reason")  'Hire 7A7A Rehire 7G7A
                dtHeaders.Columns.Add("company")       '0600 Juarez  0610 Qro.
                dtHeaders.Columns.Add("location")      'MXQUE_01 queretaro MXJUA_01 MXJUA_02 juarez
                dtHeaders.Columns.Add("position")
                dtHeaders.Columns.Add("manager-id")  'Supervisor sf_id o NO_MANAGER
                dtHeaders.Columns.Add("cost-center")
                dtHeaders.Columns.Add("employee-class")
                dtHeaders.Columns.Add("custom-string15")  'Unionized Non Unionized
                dtHeaders.Columns.Add("employment-type")
                dtHeaders.Columns.Add("fte")                  'siempre 1
                dtHeaders.Columns.Add("holiday-calendar-code")  'Q1 para Qro. J2 juarez
                dtHeaders.Columns.Add("is-fulltime-employee")   'siempre Yes
                dtHeaders.Columns.Add("job-code")               'codigo sf del puesto
                dtHeaders.Columns.Add("jobEntryDate")           'fecha de alta
                dtHeaders.Columns.Add("job-title")           'Puesto.nombre
                dtHeaders.Columns.Add("local-job-title")     'Puesto.nombre
                dtHeaders.Columns.Add("custom-string2")      'personal.dbo.niveles.nivel sin la ultima letra
                dtHeaders.Columns.Add("custom-string3")      'personal.dbo.niveles.nivel
                dtHeaders.Columns.Add("payScaleArea")        'Juarez, Queretaro
                dtHeaders.Columns.Add("payScaleGroup")       'personal.dbo.niveles.payscalegroup
                dtHeaders.Columns.Add("payScaleLevel")       'personal.dbo.niveles.payscalelevel
                dtHeaders.Columns.Add("payScaleType")        'Siempre Operatives
                dtHeaders.Columns.Add("regular-temp")        'Siempre Permanent
                dtHeaders.Columns.Add("standard-hours")       'campo horas semanales
                dtHeaders.Columns.Add("time-type-profile-code")    'MEX_HOURLY_JUAREZ, MEX_HOURLY_QUERETARO
                dtHeaders.Columns.Add("timezone")    'US/Central (Queretaro), US/Mountain (Juarez)
                dtHeaders.Columns.Add("custom-string4")      'Perm Full-time
                dtHeaders.Columns.Add("workschedule-code")   'codigo de SF
                dtHeaders.Columns.Add("workingDaysPerWeek")   'dias de trabajo
                dr = dtHeaders.NewRow
                dr("business-unit") = "Business Unit"
                dr("start-date") = "Event Date"
                dr("user-id") = "User ID"
                dr("custom-string16") = "Classification"
                dr("department") = "Department (Cost Center)"
                dr("division") = "Division"
                dr("event-reason") = "event-reason"
                dr("company") = "Legal Entity"
                dr("location") = "Location"
                dr("position") = "Position"
                dr("manager-id") = "Supervisor"
                dr("cost-center") = "Cost Center"
                dr("employee-class") = "Employee Group"
                dr("custom-string15") = "Employee Type (Fortia)"
                dr("employment-type") = "Employment Type"
                dr("fte") = "FTE"
                dr("holiday-calendar-code") = "Holiday Calendar"
                dr("is-fulltime-employee") = "Is Fulltime Employee"
                dr("job-code") = "Job Classification"
                dr("jobEntryDate") = "Job Entry Date"
                dr("job-title") = "Job Title"
                dr("local-job-title") = "Local Job Title"
                dr("custom-string2") = "Pay Grade / Pay Scale Group (Integration)"
                dr("custom-string3") = "Pay Grade Level / Pay Scale Level (Integration)"
                dr("payScaleArea") = "Pay Scale Area"
                dr("payScaleGroup") = "Pay Scale Group"
                dr("payScaleLevel") = "Pay Scale Level"
                dr("payScaleType") = "Pay Scale Type"
                dr("regular-temp") = "Permanent / Temporary"
                dr("standard-hours") = "Standard Weekly Hours"
                dr("time-type-profile-code") = "Time Profile"
                dr("timezone") = "Time Zone"
                dr("custom-string4") = "Work Contract"
                dr("workschedule-code") = "Work Schedule"
                dr("workingDaysPerWeek") = "Working Days Per Week"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Job History_" & strNumReq & "_4.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Comp Info
                dtLayouts = sqlExecute("select folio, CONVERT(VARCHAR(10), FechaAlta, 101) as [start-date], case Reingreso when '0' then '7A7A' when '1' then '7G7A' else '7A7A' end as  [event-reason], '' as [user-id],  '1Q' as [pay-group], 'Mexico - PIDA' as  [payroll-system-id], 'Plant Employee / Blue Collar' as [job-level], 'employee' as  [custom-string1], '' as [payroll-id] " & _
                                           "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                        'dRow.Item("payroll-id") = itemCandidato.UserID.TrimStart("0"c)
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("start-date")        'Fecha de alta
                dtHeaders.Columns.Add("event-reason")      'Hire 7A7A Rehire 7G7A
                dtHeaders.Columns.Add("user-id")
                dtHeaders.Columns.Add("pay-group")         '1Q Queretaro 1J juarez 
                dtHeaders.Columns.Add("payroll-system-id")  'Mexico - PIDA  fijo
                dtHeaders.Columns.Add("job-level")          'Siempre Plant Employee / Blue Collar
                dtHeaders.Columns.Add("custom-string1")     'Siempre employee
                dtHeaders.Columns.Add("payroll-id")         'user-id sin MXJ
                dr = dtHeaders.NewRow
                dr("start-date") = "Event Date"
                dr("event-reason") = "FIN: event-reason"
                dr("user-id") = "User ID"
                dr("pay-group") = "Pay Group"
                dr("payroll-system-id") = "Payroll System Id"
                dr("job-level") = "Job Level"
                dr("custom-string1") = "Joblevel Flag"
                dr("payroll-id") = "Payroll Id"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Compensation Info_" & strNumReq & "_5.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Pay Component
                dtLayouts = sqlExecute("select folio, SueldoDiario as [paycompvalue], 'MXN' as  [currency-code],  CONVERT(VARCHAR(10), FechaAlta, 101) as [start-date], 'DLY' as  [frequency], '1001' as [pay-component], '' as [user-id] " & _
                                           "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("paycompvalue")   'Sueldo Diario
                dtHeaders.Columns.Add("currency-code")  'MXN fijo
                dtHeaders.Columns.Add("start-date")     'Fecha de alta
                dtHeaders.Columns.Add("frequency")      'DLY fijo
                dtHeaders.Columns.Add("pay-component")  '1001 fijo
                dtHeaders.Columns.Add("user-id")
                dr = dtHeaders.NewRow
                dr("paycompvalue") = "Amount"
                dr("currency-code") = "Currency"
                dr("start-date") = "Event Date"
                dr("frequency") = "Frequency"
                dr("pay-component") = "Pay Component"
                dr("user-id") = "User ID"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Pay Component Recurring_" & strNumReq & "_6.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Job Relationship 2 registros por persona
                dtLayouts = sqlExecute("select folio,CONVERT(VARCHAR(10), FechaAlta, 101) as [start-date], t.HRBP as  [rel-user-id], 'HRBP' as [relationship-type], '' as [user-id] " & _
                                       "from reclutamiento.dbo.candidatos c join personal.dbo.turnos t on c.Turno = t.nombre where folio in (" & strFolios & ") " & _
                                       "union " & _
                                       "select folio,CONVERT(VARCHAR(10), FechaAlta, 101) as [start-date], t.SEC_HRBP as  [rel-user-id], '2nd HRBP' as [relationship-type], '' as [user-id] " & _
                                       "from reclutamiento.dbo.candidatos c join personal.dbo.turnos t on c.Turno = t.nombre where folio in (" & strFolios & ") order by folio")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("user-id") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("start-date")        'Fecha de alta
                dtHeaders.Columns.Add("rel-user-id")        'segun tabla
                dtHeaders.Columns.Add("relationship-type")  'segun tabla
                dtHeaders.Columns.Add("user-id")
                dr = dtHeaders.NewRow
                dr("start-date") = "Event Date"
                dr("rel-user-id") = "Name"
                dr("relationship-type") = "Relationship Type"
                dr("user-id") = "User ID"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Job Relationships_" & strNumReq & "_7.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Personal Info
                dtLayouts = sqlExecute("select folio, CONVERT(VARCHAR(10), FechaAlta, 101) as [start-date], Nombre as  [first-name], Genero as gender, Paterno as [last-name], '' as [personInfo.person-id-external], " & _
                                       "case cod_civil when 'C' then 'Married' when 'D' then 'Divorced' when 'L' then 'Common law / Registered Partnership' when 'S' then 'Single' when 'U' then 'Common law / Registered Partnership' " & _
                                       "when 'V' then 'Widowed' when 'X' then 'Separated' END as [marital-status], " & _
                                       "SegundoNombre as [middle-name], 'MEX' as nationality, 'Spanish' as [native-preferred-lang], salutation as salutation, Materno as [second-last-name]" & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("start-date")   'Fecha de alta
                dtHeaders.Columns.Add("first-name")
                dtHeaders.Columns.Add("gender")    'M o F
                dtHeaders.Columns.Add("last-name")
                dtHeaders.Columns.Add("personInfo.person-id-external")  'Id de PIDA
                dtHeaders.Columns.Add("marital-status")
                dtHeaders.Columns.Add("middle-name")
                dtHeaders.Columns.Add("nationality")
                dtHeaders.Columns.Add("native-preferred-lang")  'Spanish fijo
                dtHeaders.Columns.Add("salutation")
                dtHeaders.Columns.Add("second-last-name")
                dr = dtHeaders.NewRow
                dr("start-date") = "Event Date"
                dr("first-name") = "First Name"
                dr("gender") = "Gender"
                dr("last-name") = "Last Name"
                dr("personInfo.person-id-external") = "Person ID External"
                dr("marital-status") = "Marital Status"
                dr("middle-name") = "Middle Name"
                dr("nationality") = "Nationality"
                dr("native-preferred-lang") = "Preferred Language"
                dr("salutation") = "Salutation"
                dr("second-last-name") = "Second Last Name"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Personal Information_" & strNumReq & "_8.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Global Info
                dtLayouts = sqlExecute("select folio, 'MEX' as country, CONVERT(VARCHAR(10), FechaAlta, 101) as  [start-date], '' as [personInfo.person-id-external], case UltimoGrado when '01' then 'Elementary School' " & _
                                       "when '02' then 'Middle School' when '03' then 'High School' when '04' then 'Technical Career' when '05' then 'College Degree' when '06' then 'Specialty' when '07' then 'Master Degree' " & _
                                       "when '08' then 'Doctorate' end as genericString8, Numero_Hijos as genericNumber1 " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("country")                           'MEX fijo
                dtHeaders.Columns.Add("start-date")                        'Fecha de alta
                dtHeaders.Columns.Add("personInfo.person-id-external")     'Id de PIDA
                dtHeaders.Columns.Add("genericString8")                    'Equivalentes del espanol del grado de estudios
                dtHeaders.Columns.Add("genericNumber1")
                dr = dtHeaders.NewRow
                dr("country") = "Country"
                dr("start-date") = "Event Date"
                dr("personInfo.person-id-external") = "Person ID External"
                dr("genericString8") = "Education Level"
                dr("genericNumber1") = "Number of Children"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Global Information_" & strNumReq & "_9.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'National Id        3 registros uno pora IMSS, CURP y RFC
                dtLayouts = sqlExecute("select folio, 'MEX' as country, 'Yes' as  isPrimary, rtrim(IMSS)+rtrim(DIG_VER) as [national-id],  'IMSS' as [card-type] , '' as [personInfo.person-id-external] " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") " & _
                                       "union " & _
                                       "select folio, 'MEX' as country, 'No' as  isPrimary, rtrim(CURP) as [national-id],  'CURP' as [card-type] , '' as [personInfo.person-id-external] " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") " & _
                                       "union " & _
                                       "select folio, 'MEX' as country, 'No' as  isPrimary, rtrim(RFC) as [national-id],  'RFC' as [card-type] , '' as [personInfo.person-id-external] " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") " & _
                                       "order by folio")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("country")           'MEX fijo
                dtHeaders.Columns.Add("isPrimary")         'Yes/No
                dtHeaders.Columns.Add("national-id")       'numero de imss, curpo o rfc
                dtHeaders.Columns.Add("card-type")         'IMSS, CURP, RFC
                dtHeaders.Columns.Add("personInfo.person-id-external")  'Id de PIDA
                dr = dtHeaders.NewRow
                dr("country") = "Country"
                dr("isPrimary") = "Is Primary"
                dr("national-id") = "National Id"
                dr("card-type") = "National Id Card Type"
                dr("personInfo.person-id-external") = "Person ID External"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\National ID Information_" & strNumReq & "_10.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Address
                dtLayouts = sqlExecute("select c.folio, 'home' as [address-type], 'MEX' as  country, CONVERT(VARCHAR(10), c.FechaAlta, 101) as [start-date], '' as [personInfo.person-id-external] ,  " & _
                                       "rtrim(c.Departamento) as address2, cd.nombre as city, c.Colonia as address3, m.nombre as address4, rtrim(c.CP) as [zip-code], e.nombre as state, " & _
                                       "c.Direccion as address1 " & _
                                       "from reclutamiento.dbo.candidatos c left join personal.dbo.ciudad cd on c.ciudad = cd.cod_cd " & _
                                       "left join reclutamiento.dbo.municipios m on c.municipio = m.cod_mun " & _
                                       "left join reclutamiento.dbo.estados e on c.cod_est = e.cod_edo " & _
                                       "where c.folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("address-type")               'home fijo
                dtHeaders.Columns.Add("country")                    'MEX fijo
                dtHeaders.Columns.Add("start-date")                 'Fecha de alta
                dtHeaders.Columns.Add("personInfo.person-id-external")  'Id de PIDA
                dtHeaders.Columns.Add("address2")            'Departamento
                dtHeaders.Columns.Add("city")                    'obtener del codigo de ciudad
                dtHeaders.Columns.Add("address3")            'Colonia
                dtHeaders.Columns.Add("address4")            'Municipio  obtener del codigo de municipio
                dtHeaders.Columns.Add("zip-code")
                dtHeaders.Columns.Add("state")               'cod_est
                dtHeaders.Columns.Add("address1")            'Calle y numero
                dr = dtHeaders.NewRow
                dr("address-type") = "Address Type"
                dr("country") = "Country"
                dr("start-date") = "Event Date"
                dr("personInfo.person-id-external") = "Person ID External"
                dr("address2") = "Apartment"
                dr("city") = "City"
                dr("address3") = "Colony"
                dr("address4") = "Municipality"
                dr("zip-code") = "Postal Code"
                dr("state") = "State"
                dr("address1") = "Street and House Number"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Addresses_" & strNumReq & "_11.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Email             3 registros Personal Business Other
                dtLayouts = sqlExecute("select folio, EmailPersonal as [email-address], 'Personal' as  [email-type], '' as [personInfo.person-id-external] , 'Yes' as isPrimary " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(rtrim(EmailPersonal)) > 0 " & _
                                       "union " & _
                                       "select folio, EmailBusiness as [email-address], 'Business' as  [email-type], '' as [personInfo.person-id-external] , 'No' as isPrimary " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(rtrim(EmailBusiness)) > 0 " & _
                                       "union " & _
                                       "select folio, EmailOtro as [email-address], 'Other' as  [email-type], '' as [personInfo.person-id-external] , 'No' as isPrimary " & _
                                       "from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(rtrim(EmailOtro)) > 0 " & _
                                       "order by folio")
                If dtLayouts.Rows.Count > 0 Then
                    For Each itemCandidato As CandidatoIDS In listaCandidatos
                        For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                            dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                        Next
                    Next
                    dtLayouts.Columns.Remove("folio")
                    dtHeaders = New DataTable
                    dtHeaders.Columns.Add("email-address")
                    dtHeaders.Columns.Add("email-type")
                    dtHeaders.Columns.Add("personInfo.person-id-external")
                    dtHeaders.Columns.Add("isPrimary")
                    dr = dtHeaders.NewRow
                    dr("email-address") = "Email Address"
                    dr("email-type") = "Email Type"
                    dr("personInfo.person-id-external") = "Person ID External"
                    dr("isPrimary") = "Is Primary"
                    dtHeaders.Rows.Add(dr)
                    dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                    byteData = csvBytesWriter(dtHeaders)
                    oFileStream = New System.IO.FileStream(strPath & "\Email Information_" & strNumReq & "_12.csv", System.IO.FileMode.Create)
                    oFileStream.Write(byteData, 0, byteData.Length)
                    oFileStream.Close()
                End If

                'Phone            Varios registros
                dtLayouts = sqlExecute("select * from " & _
                                       "( " & _
                                       "  select folio, '' as [personInfo.person-id-external], Telefono1 as [phone-number], 'Personal Cell' as  [phone-type],  'No' as isPrimary, '' as extension " & _
                                       "  from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(Telefono1) > 0 " & _
                                       "  union " & _
                                       "  select folio, '' as [personInfo.person-id-external], Telefono2 as [phone-number], 'Home' as  [phone-type],  'No' as isPrimary, '' as extension " & _
                                       "  from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(Telefono2) > 0 " & _
                                       "  union " & _
                                       "  select folio, '' as [personInfo.person-id-external], Telefono3 as [phone-number], 'Business' as  [phone-type],  'Yes' as isPrimary, '' as extension " & _
                                       "  from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") " & _
                                       "  union " & _
                                       "  select folio, '' as [personInfo.person-id-external], Telefono4 as [phone-number], 'Other' as  [phone-type],  'No' as isPrimary, '' as extension " & _
                                       "  from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(Telefono4) > 0 " & _
                                       "  union " & _
                                       "  select folio, '' as [personInfo.person-id-external], Telefono5 as [phone-number], 'Business Cell' as  [phone-type],  'No' as isPrimary, '' as extension " & _
                                       "  from reclutamiento.dbo.candidatos where folio in (" & strFolios & ") and len(Telefono5) > 0 " & _
                                       ") s " & _
                                       "where [phone-number] is not null " & _
                                       "order by folio")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                        dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                    Next
                Next
                dtLayouts.Columns.Remove("folio")
                dtHeaders = New DataTable
                dtHeaders.Columns.Add("personInfo.person-id-external")
                dtHeaders.Columns.Add("phone-number")
                dtHeaders.Columns.Add("phone-type")
                dtHeaders.Columns.Add("isPrimary")
                dtHeaders.Columns.Add("extension")       'no poner nada
                dr = dtHeaders.NewRow
                dr("personInfo.person-id-external") = "Person ID External"
                dr("phone-number") = "Phone Number"
                dr("phone-type") = "Phone Type"
                dr("isPrimary") = "Is Primary"
                dr("extension") = "Extension"
                dtHeaders.Rows.Add(dr)
                dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                byteData = csvBytesWriter(dtHeaders)
                oFileStream = New System.IO.FileStream(strPath & "\Phone Information_" & strNumReq & "_13.csv", System.IO.FileMode.Create)
                oFileStream.Write(byteData, 0, byteData.Length)
                oFileStream.Close()

                'Dependents Info               Varios registros
                dtLayouts = sqlExecute("select c.folio, '' as [personInfo.person-id-external], 'Dep_Mex_' as [related-person-id-external], '' as [is-beneficiary], '' as [custom-string7], CONVERT(VARCHAR(10), c.FechaAlta, 101) as [start-date], " & _
                                       "case d.Parentezco when 'Hijo(a)' then 'Child' when 'Hijastro(a)' then 'Stepchild' when 'Esposo(a)' then 'Spouse' END as [relationship-type], " & _
                                       "'' as [is-address-same-as-person], '' as [is-accompanying-dependent], '' as operation, " & _
                                       "CONVERT(VARCHAR(10), d.FhaNacimiento, 101) as [person.date-of-birth], '' as [person.country-of-birth], '' as [person.place-of-birth], '' as [person.region-of-birth], " & _
                                       "d.Nombre as [personalInfo.first-name], d.Paterno as [personalInfo.last-name], " & _
                                       "d.Materno as [personalInfo.second-last-name], d.SegundoNombre as [personalInfo.middle-name], '' as [personalInfo.salutation], '' as [personalInfo.gender], '' as [personalInfo.marital-status], " & _
                                       "'' as [personalInfo.native-preferred-lang], '' as [personalInfo.nationality], '' as [personalInfo.since], '' as [personalInfo.preferred-name], '' as [personalInfo.second-nationality], " & _
                                       "'' as [nationalIdCard.country], '' as [nationalIdCard.card-type], '' as [nationalIdCard.national-id], '' as [nationalIdCard.isPrimary], '' as [nationalIdCard.notes], '' as [address.address1], " & _
                                       "'' as [address.address2], '' as [address.address3], '' as [address.city], '' as [address.county], '' as [address.state], '' as [address.province], '' as [address.zip-code], " & _
                                       "'' as [address.country], '' as [address.notes], '' as [address.address4], '' as [address.address5], '' as [address.address20], '' as [address.address6], '' as [address.address7] " & _
                                       "from reclutamiento.dbo.candidatos c join reclutamiento.dbo.dependientes d on c.Folio = d.Folio where c.folio in (" & strFolios & ") order by c.folio")
                If dtLayouts.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For Each itemCandidato As CandidatoIDS In listaCandidatos
                        i = 0
                        For Each dRow As DataRow In dtLayouts.Select("folio = '" & itemCandidato.Folio & "'")
                            i = i + 1
                            dRow.Item("personInfo.person-id-external") = itemCandidato.sfID
                            dRow.Item("related-person-id-external") = dRow.Item("related-person-id-external") & itemCandidato.sfID.Remove(0, 3) & "_" & i
                        Next
                    Next
                    dtLayouts.Columns.Remove("folio")
                    dtHeaders = New DataTable
                    dtHeaders.Columns.Add("personInfo.person-id-external")
                    dtHeaders.Columns.Add("related-person-id-external")
                    dtHeaders.Columns.Add("is-beneficiary")
                    dtHeaders.Columns.Add("custom-string7")
                    dtHeaders.Columns.Add("start-date")
                    dtHeaders.Columns.Add("relationship-type")
                    dtHeaders.Columns.Add("is-address-same-as-person")
                    dtHeaders.Columns.Add("is-accompanying-dependent")
                    dtHeaders.Columns.Add("operation")
                    dtHeaders.Columns.Add("person.date-of-birth")
                    dtHeaders.Columns.Add("person.country-of-birt")
                    dtHeaders.Columns.Add("person.place-of-birth")
                    dtHeaders.Columns.Add("person.region-of-birth")
                    dtHeaders.Columns.Add("personalInfo.first-name")
                    dtHeaders.Columns.Add("personalInfo.last-name")
                    dtHeaders.Columns.Add("personalInfo.second-last-name")
                    dtHeaders.Columns.Add("personalInfo.middle-name")
                    dtHeaders.Columns.Add("personalInfo.salutation")
                    dtHeaders.Columns.Add("personalInfo.gender")
                    dtHeaders.Columns.Add("personalInfo.marital-status")
                    dtHeaders.Columns.Add("personalInfo.native-preferred-lang")
                    dtHeaders.Columns.Add("personalInfo.nationality")
                    dtHeaders.Columns.Add("personalInfo.since")
                    dtHeaders.Columns.Add("personalInfo.preferred-name")
                    dtHeaders.Columns.Add("personalInfo.second-nationality")
                    dtHeaders.Columns.Add("nationalIdCard.country")
                    dtHeaders.Columns.Add("nationalIdCard.card-type")
                    dtHeaders.Columns.Add("nationalIdCard.national-id")
                    dtHeaders.Columns.Add("nationalIdCard.isPrimary")
                    dtHeaders.Columns.Add("nationalIdCard.notes")
                    dtHeaders.Columns.Add("address.address1")
                    dtHeaders.Columns.Add("address.address2")
                    dtHeaders.Columns.Add("address.address3")
                    dtHeaders.Columns.Add("address.city")
                    dtHeaders.Columns.Add("address.county")
                    dtHeaders.Columns.Add("address.state")
                    dtHeaders.Columns.Add("address.province")
                    dtHeaders.Columns.Add("address.zip-code")
                    dtHeaders.Columns.Add("address.country")
                    dtHeaders.Columns.Add("address.notes")
                    dtHeaders.Columns.Add("address.address4")
                    dtHeaders.Columns.Add("address.address5")
                    dtHeaders.Columns.Add("address.address20")
                    dtHeaders.Columns.Add("address.address6")
                    dtHeaders.Columns.Add("address.address7")
                    dr = dtHeaders.NewRow
                    dr("personInfo.person-id-external") = "Person ID External"
                    dr("related-person-id-external") = "Related Person Id External"
                    dr("is-beneficiary") = "Is Beneficiary"
                    dr("custom-string7") = "Smoker"
                    dr("start-date") = "Event Date"
                    dr("relationship-type") = "Relationship"
                    dr("is-address-same-as-person") = "Address Same as Employee"
                    dr("is-accompanying-dependent") = "Accompanying"
                    dr("operation") = "Operation"
                    dr("person.date-of-birth") = "Date Of Birth"
                    dr("person.country-of-birt") = "Country Of Birth(Mexico & Belgium)"
                    dr("person.place-of-birth") = "Place Of Birth(Mexico & Belgium)"
                    dr("person.region-of-birth") = "State Of Birth(Mexico)"
                    dr("personalInfo.first-name") = "First Name"
                    dr("personalInfo.last-name") = "Last Name"
                    dr("personalInfo.second-last-name") = "Second Last Name"
                    dr("personalInfo.middle-name") = "Middle Name"
                    dr("personalInfo.salutation") = "Salutation"
                    dr("personalInfo.gender") = "Gender"
                    dr("personalInfo.marital-status") = "Marital Status"
                    dr("personalInfo.native-preferred-lang") = "Preferred Language"
                    dr("personalInfo.nationality") = "Nationality"
                    dr("personalInfo.since") = "Marital Status Since"
                    dr("personalInfo.preferred-name") = "Preferred Name"
                    dr("personalInfo.second-nationality") = "Second Nationality"
                    dr("nationalIdCard.country") = "Country"
                    dr("nationalIdCard.card-type") = "National Id Card Type"
                    dr("nationalIdCard.national-id") = "National Id"
                    dr("nationalIdCard.isPrimary") = "Is Primary"
                    dr("nationalIdCard.notes") = "Notes"
                    dr("address.address1") = "Address1"
                    dr("address.address2") = "Address2"
                    dr("address.address3") = "Address3"
                    dr("address.city") = "City"
                    dr("address.county") = "County"
                    dr("address.state") = "State"
                    dr("address.province") = "Province"
                    dr("address.zip-code") = "Zip"
                    dr("address.country") = "Country"
                    dr("address.notes") = "Notes"
                    dr("address.address4") = "Address4"
                    dr("address.address5") = "Address5"
                    dr("address.address20") = "Address20"
                    dr("address.address6") = "Address6"
                    dr("address.address7") = "Address7"
                    dtHeaders.Rows.Add(dr)
                    dtHeaders.Merge(dtLayouts, False, MissingSchemaAction.Ignore)
                    byteData = csvBytesWriter(dtHeaders)
                    oFileStream = New System.IO.FileStream(strPath & "\Consolidated Dependents_" & strNumReq & "_14.csv", System.IO.FileMode.Create)
                    oFileStream.Write(byteData, 0, byteData.Length)
                    oFileStream.Close()
                End If

                sqlExecute("update reclutamiento.dbo.candidatos set layout = '1' where folio in (" & strFolios & ")")
                For Each itemCandidato As CandidatoIDS In listaCandidatos
                    'sqlExecute("Update reclutamiento.dbo.candidatos set RelojPida= '" & itemCandidato.UserID & "', RelojSF = '" & itemCandidato.sfID & "' where folio = '" & itemCandidato.Folio & "'")
                    sqlExecute("Update reclutamiento.dbo.candidatos set RelojSF = '" & itemCandidato.sfID & "' where folio = '" & itemCandidato.Folio & "'")
                Next
                MsgBox("Se generaron los layouts para los candidatos seleccionados.", MsgBoxStyle.Information, "Informe")

                Dim strDestinatarios = ""
                Dim strPlantaReq = ""
                If SQLConn.ToUpper.Contains("MXQTDB01") Then
                    Dim dtDestinatarios As DataTable = sqlExecute("select top 1 destinatarios_layouts from parametros ", "reclutamiento")
                    If dtDestinatarios.Rows.Count > 0 Then
                        strDestinatarios = dtDestinatarios.Rows(0).Item("destinatarios_layouts")
                    Else
                        strDestinatarios = "mibrp@brp.com; mariana.olvera@brp.com"
                    End If
                    strPlantaReq = "Querétaro"
                Else
                    Dim dtDestinatarios As DataTable = sqlExecute("select top 1 destinatarios_layouts_prueba from parametros ", "reclutamiento")
                    If dtDestinatarios.Rows.Count > 0 Then
                        strDestinatarios = dtDestinatarios.Rows(0).Item("destinatarios_layouts_prueba")
                    Else
                        strDestinatarios = "jose.hernandez@pida.com.mx"
                    End If
                    strPlantaReq = "PIDA"
                End If
                EnviarCorreoSF("Requisición " & strNumReq & " " & strVacantes, "Requisición de " & strPlantaReq & " favor de dar de alta a los siguientes " & listaCandidatos.Count & " empleados", strDestinatarios, "", strPath, strNumReq)
                Dim myDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(strPath)
                If myDir.EnumerateFiles().Any() Then
                    For Each _file As String In System.IO.Directory.GetFiles(strPath, "*.csv")
                        System.IO.File.Delete(_file)
                    Next
                End If
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            'Borrar todos los csv generados si hay algun error
            For Each deleteFile In System.IO.Directory.GetFiles(strPath, "*.csv", System.IO.SearchOption.TopDirectoryOnly)
                System.IO.File.Delete(deleteFile)
            Next
            'Regresar el contador de reloj
            'sqlExecute("update reclutamiento.dbo.UltimoReloj set Reloj = '" & (Convert.ToInt32(listaCandidatos(0).UserID) - 1).ToString.PadLeft(6, "0") & "'")
            MsgBox("Hubo un error generando los layouts para los candidatos seleccionados.", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles btnSolicitudes.Click
        Dim strFolios As String = ""
        Dim dtSolicitudes As DataTable
        Dim dtDependientes As DataTable
        Try
            For Each row As DataGridViewRow In dgSolicitudes.Rows
                If row.Cells("Solicitud").Value Then
                    strFolios &= "'" & row.Cells("Folio").Value.ToString & "',"
                End If
            Next
            If strFolios.Length <= 0 Then
                MessageBox.Show("No selecciono ningun candidato para imprimir su solicitud.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            strFolios &= ","
            strFolios = strFolios.Replace(",,", "")
            If strFolios.Length > 0 Then
                dtSolicitudes = sqlExecute("select c.folio, c.RecomendadoPor,c.TallaZapato,rtrim(c.Paterno) as Paterno,rtrim(c.Materno) as Materno,rtrim(c.Nombre)+' '+rtrim(c.SegundoNombre) as nombres,c.FhaApli,c.Direccion, c.Edad, " & _
                                           "v.cod_planta, v.vacante, c.turno ,c.colonia, c.cp, c.Telefono1, c.lugar_nac,c.FhaNac, c.genero, civil.nombre as EdoCivil, c.Telefono2, e.nombre as ultimo_grado,c.OtroGrado,c.NomEmpUltTrab, " & _
                                           "c.AnoIngresoUltTrab+' - '+ c.AnoBajaUltimoTrab as periodoUltTrab, c.PuestoUltTrab, c.NomEmpPenTrab, c.AnoIngresoPenTrab+' - '+ c.AnoBajaPenTrab as periodoPenTrab, c.PuestoPenTrab, " & _
                                           "'' as Esposoa, '' as NacEsposoa, '' as Hijoa1, '' as NacHijoa1, '' as Hijoa2, '' as NacHijoa2, '' as Hijoa3, '' as NacHijoa3 " & _
                                           "from reclutamiento.dbo.candidatos c join reclutamiento.dbo.vacantes v on c.cod_vac = v.cod_vac left join personal.dbo.civil as civil on c.cod_civil = civil.cod_civil " & _
                                           "left join escuelas e on c.UltimoGrado = e.COD_ESCUELA where folio in (" & strFolios & ")")
                dtDependientes = sqlExecute("select folio, Parentezco, rtrim(nombre)+' '+rtrim(segundonombre)+' '+rtrim(paterno)+' '+rtrim(materno) as nombre,fhanacimiento from reclutamiento.dbo.dependientes where folio in (" & strFolios & ")")
                For Each row As System.Data.DataRow In dtDependientes.Rows
                    Dim CandidateRow As DataRow
                    CandidateRow = dtSolicitudes.Select("folio = " & row.Item("folio").ToString.Trim).FirstOrDefault
                    If row.Item("Parentezco").ToString.Trim.Equals("Esposo(a)") Then
                        CandidateRow("Esposoa") = row.Item("nombre").ToString.Trim
                        CandidateRow("NacEsposoa") = row.Item("fhanacimiento").ToString.Trim
                    End If
                    If row.Item("Parentezco").ToString.Trim.Equals("Hijo(a)") Or row.Item("Parentezco").ToString.Trim.Equals("Hijastro(a)") Then
                        If CandidateRow("Hijoa1").ToString.Trim.Length = 0 Then
                            CandidateRow("Hijoa1") = row.Item("nombre").ToString.Trim
                            CandidateRow("NacHijoa1") = FechaSQL(row.Item("fhanacimiento").ToString.Trim)
                        ElseIf CandidateRow("Hijoa2").ToString.Trim.Length = 0 Then
                            CandidateRow("Hijoa2") = row.Item("nombre").ToString.Trim
                            CandidateRow("NacHijoa2") = FechaSQL(row.Item("fhanacimiento").ToString.Trim)
                        ElseIf CandidateRow("Hijoa3").ToString.Trim.Length = 0 Then
                            CandidateRow("Hijoa3") = row.Item("nombre").ToString.Trim
                            CandidateRow("NacHijoa3") = FechaSQL(row.Item("fhanacimiento").ToString.Trim)
                        End If
                    End If
                Next
                frmVistaPrevia.LlamarReporte("SolicitudReclutamiento", dtSolicitudes)
                frmVistaPrevia.ShowDialog()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Function csvBytesWriter(ByRef dTable As DataTable) As Byte()

        '--------Columns Name--------------------------------------------------------------------------- 

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i + 1
            sb.Append("""" + dTable.Columns(i).ColumnName.ToString() + """")
            If i = intClmn - 1 Then
                sb.Append(" ")
            Else
                sb.Append(",")
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns--------------------------------------------------------------------------- 

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append("""" + row(ir).ToString().Replace("""", """""") + """")
                If ir = intClmn - 1 Then
                    sb.Append(" ")
                Else
                    sb.Append(",")
                End If

            Next
            sb.Append(vbNewLine)
        Next

        Return System.Text.Encoding.UTF8.GetBytes(sb.ToString)

    End Function

    Private Sub dgSolicitudes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSolicitudes.CellContentClick
        'if click is on new row or header row
        If e.RowIndex = dgSolicitudes.NewRowIndex Or e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = dgSolicitudes.Columns("EntrevistaRHBuscar").Index Then
            frmEntrevistaRH.MdiParent = frmMain
            frmEntrevistaRH.WindowState = FormWindowState.Maximized
            frmEntrevistaRH.Show(dgSolicitudes.CurrentRow.Cells("folio").Value.ToString.Trim)
            frmEntrevistaRH.Focus()
        End If
        'Check if click is on specific column 
        If e.ColumnIndex = dgSolicitudes.Columns("SupervisorBuscar").Index Then
            frmEvaluacionSolicitantes.MdiParent = frmMain
            frmEvaluacionSolicitantes.WindowState = FormWindowState.Maximized
            frmEvaluacionSolicitantes.Show(dgSolicitudes.CurrentRow.Cells("folio").Value.ToString.Trim)
            frmEvaluacionSolicitantes.Focus()
        End If
        'Check if click is on specific column 
        If e.ColumnIndex = dgSolicitudes.Columns("medicoBuscar").Index Then
            frmSMedico.MdiParent = frmMain
            frmSMedico.WindowState = FormWindowState.Maximized
            frmSMedico.Show(dgSolicitudes.CurrentRow.Cells("folio").Value.ToString.Trim)
            frmSMedico.Focus()
        End If
        If e.ColumnIndex = dgSolicitudes.Columns("RHBuscar").Index Then
            frmrevision.MdiParent = frmMain
            frmrevision.WindowState = FormWindowState.Maximized
            frmrevision.Show(dgSolicitudes.CurrentRow.Cells("folio").Value.ToString.Trim)
            frmrevision.Focus()
        End If
    End Sub

    Function SiguienteReloj() As String
        Dim sigReloj As String
        'Asignar número de reloj, de acuerdo a código de compañía
        Dim dtPredeterminados As DataTable = sqlExecute("select top 1 minimo_rango,maximo_rango from tipo_emp where cod_comp = 'WME' AND cod_tipo in ('O','A')")
        If dtPredeterminados.Rows.Count = 0 Then
            sigReloj = "000000"
        Else
            Dim row As DataRow = dtPredeterminados.Rows(0)

            If IsDBNull(row("minimo_rango")) Or IsDBNull(row("maximo_rango")) Then
                sigReloj = "000000"
            Else
                Dim dtReloj As DataTable
                Dim min As String
                Dim max As String

                If row("minimo_rango").ToString.Length < 6 Then
                    min = row("minimo_rango").ToString.PadLeft(6, "0")
                Else
                    min = row("minimo_rango").ToString
                End If
                If row("maximo_rango").ToString.Length < 6 Then
                    max = row("maximo_rango").ToString.PadLeft(6, "0")
                Else
                    max = row("maximo_rango").ToString
                End If
                dtReloj = sqlExecute("select reloj from reclutamiento.dbo.UltimoReloj where " & _
                                     "reloj > '" & min & _
                                     "' and reloj < '" & max & "'")
                If dtReloj.Rows.Count Then
                    sigReloj = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(LongReloj, "0")
                Else
                    'sigReloj = row("minimo_rango").ToString.PadLeft(6, "0")
                    sigReloj = "000000"
                    Return sigReloj
                    Exit Function
                End If

                'Validar que el número de reloj no exista
                dtReloj = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & sigReloj & "'")
                Do Until dtReloj.Rows.Count = 0
                    sigReloj = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(LongReloj, "0")
                    dtReloj = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & sigReloj & "'")
                Loop

                'Si el rango ya está completo, notificar al usuario, luego salir
                If sigReloj > row("maximo_rango").ToString.PadLeft(6, "0") Then
                    MessageBox.Show("No hay números de reloj disponibles en el rango indicado, del " & _
                                    row("minimo_rango").ToString.PadLeft(5, "0") & " al " & row("maximo_rango").ToString.PadLeft(5, "0"), _
                                    "Rango completo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sigReloj = "000000"
                    Return sigReloj
                    Exit Function
                End If
            End If 'IsDBNull(row("minimo_rango")) Or IsDBNull(row("maximo_rango"))

            'Si el número de reloj está en blanco, salir
            If Val(sigReloj) = 0 Then
                MessageBox.Show("El número de reloj no puede quedar en blanco." & vbCrLf & "Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return sigReloj
                Exit Function
            End If

            If sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & sigReloj & "'").Rows.Count > 0 Then
                MessageBox.Show("El número de reloj ya se encuentra asignado a otro empleado." & vbCrLf & "Favor de verificar.", "Reloj duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sigReloj = "000000"
                Return sigReloj
                Exit Function
            End If

            'Actualizar ultimo reloj
            Dim dtNuevoReloj = sqlExecute("update reclutamiento.dbo.UltimoReloj set reloj = '" & sigReloj & "', fecha = CONVERT (date, GETDATE())")
            If dtNuevoReloj.Columns.Count > 0 Then
                If dtNuevoReloj.Columns(0).ColumnName = "ERROR" Then
                    MessageBox.Show("Hubo un problema al actualizar el numero de reloj", "Reloj no guardado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sigReloj = "000000"
                    Return sigReloj
                    Exit Function
                End If
            End If
        End If  ' If dtPredeterminados.Rows.Count = 0
        Return sigReloj
    End Function

    Private Sub cmbStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedValueChanged
        If cmbStatus.Text = "Todas" Then
            query = "where (c.layout = 1 or c.layout = 0 or c.layout is null)"
        ElseIf cmbStatus.Text = "Exportadas" Then
            query = "where c.layout = 1"
        ElseIf cmbStatus.Text = "No exportadas" Then
            query = "where (c.layout = 0 or c.layout is null)"
        End If
        MostrarInformacion()
    End Sub

    Private Sub cmbVacantes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVacantes.SelectedValueChanged
        requi = " and c.cod_vac = '" & cmbVacantes.SelectedValue & "'"
        MostrarInformacion()
    End Sub

    Public Function EnviarCorreoSF(Asunto As String, Mensaje As String, Destinatario As String, CC As String, strPath As String, strNumReq As String) As Boolean
        Try
            Dim r As New System.Web.Mail.MailMessage
            r.Body = Mensaje
            r.BodyEncoding = System.Text.Encoding.UTF8
            r.BodyFormat = Web.Mail.MailFormat.Html
            r.Subject = Asunto

            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Basic Import_" & strNumReq & "_1.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Biographical Information_" & strNumReq & "_2.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Employment Details_" & strNumReq & "_3.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Job History_" & strNumReq & "_4.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Compensation Info_" & strNumReq & "_5.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Pay Component Recurring_" & strNumReq & "_6.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Job Relationships_" & strNumReq & "_7.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Personal Information_" & strNumReq & "_8.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Global Information_" & strNumReq & "_9.csv"))
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\National ID Information_" & strNumReq & "_10.csv"))
            Try
                r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Addresses_" & strNumReq & "_11.csv"))
            Catch
            End Try
            Try
                r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Email Information_" & strNumReq & "_12.csv"))
            Catch
            End Try
            r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Phone Information_" & strNumReq & "_13.csv"))
            Try
                r.Attachments.Add(New System.Web.Mail.MailAttachment(strPath & "\Consolidated Dependents_" & strNumReq & "_14.csv"))
            Catch
            End Try

            If SQLConn.ToUpper.Contains("MXQTDB01") Then
                r.From = "mxju_pida@brp.local"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp-mxqt.brp.local"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = "25"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "svc_mxju_smtp_pida@brp.local"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "PW4P!d@$"
                System.Web.Mail.SmtpMail.SmtpServer = "smtp-mxqt.brp.local"
            Else
                r.From = "sistema.pida@gmail.com"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.gmail.com"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 465
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
                r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "datamark.pida@gmail.com" '"sistema.pida@gmail.com"
                r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "resultados" '"Resultados1"
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com"
            End If

            'System.Web.Mail.SmtpMail.SmtpServer = "smtp.pida.com.mx"
            'MessageBox.Show(Asunto + vbCrLf + Destino + vbCrLf + Archivo + vbCrLf + Archivo2 + vbCrLf + Mensaje)

            r.To() = Destinatario
            If CC.Trim <> "" Then
                r.Cc = CC
            End If

            System.Web.Mail.SmtpMail.Send(r)
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
            Return False
        End Try
    End Function

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        MostrarInformacion()
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try
            Dim dtAuxiliares As DataTable
            dtAuxiliares = sqlExecute("select folio, RelojSF, TallaZapato, TallaPantalon, TallaPlayera, Ruta, Medio, Agencia, RecomendadoPor from reclutamiento.dbo.Candidatos where " & _
                                 "len(RelojSF)>0 and Layout = '1' and cod_vac = '" & cmbVacantes.SelectedValue.ToString & "'")
            If dtAuxiliares.Rows.Count > 0 Then
                For Each row In dtAuxiliares.Rows
                    Dim dtReloj As DataTable
                    Dim strRelojPIDA As String
                    dtReloj = sqlExecute("select reloj from personal.dbo.SF_Hirings where sf_id = '" & row("RelojSF") & "'")
                    If dtReloj.Rows.Count Then
                        strRelojPIDA = dtReloj.Rows(0)("reloj").ToString.Trim
                    Else
                        'strRelojPIDA = row("minimo_rango").ToString.PadLeft(6, "0")
                        Continue For
                    End If
                    Dim strPromedio As String
                    Dim dtPromedio = sqlExecute("select promedio from reclutamiento.dbo.evaluaciones_solicitantes where folio = '" & row("folio") & "'and CAST(promedio as DECIMAL(9,2)) > 0")
                    If dtPromedio.Rows.Count Then
                        strPromedio = dtPromedio.Rows(0)("promedio").ToString.Trim
                    Else
                        strPromedio = "0.0"
                    End If
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_PANTALON' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','T_PANTALON','" & row("TallaPantalon") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("TallaPantalon") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_PANTALON' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_PLAYERA' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','T_PLAYERA','" & row("TallaPlayera") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("TallaPlayera") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_PLAYERA' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_ZAPATO' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','T_ZAPATO','" & row("TallaZapato") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("TallaZapato") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'T_ZAPATO' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'RUTA' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','RUTA','" & row("Ruta") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("Ruta") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'RUTA' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'FUENTE_R' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','FUENTE_R','" & row("Medio") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("Medio") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'FUENTE_R' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'AGENCIA' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','AGENCIA','" & row("Agencia") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("Agencia") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'AGENCIA' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'RECOMEN' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','RECOMEN','" & row("RecomendadoPor") & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & row("RecomendadoPor") & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'RECOMEN' " & _
                                "end", "PERSONAL")
                    sqlExecute(" select * from PERSONAL.dbo.detalle_auxiliares where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'ENTREVISTA' " & _
                                "if @@ROWCOUNT = 0 " & _
                                "begin " & _
                                "    insert into PERSONAL.dbo.detalle_auxiliares (cod_comp,reloj,campo,contenido,idfld) " & _
                                "    values('610','" & strRelojPIDA & "','ENTREVISTA','" & strPromedio & "',(select max(idFld)+1 AS ID from personal.dbo.detalle_auxiliares)) " & _
                                "end " & _
                                "else " & _
                                "begin " & _
                                "    update PERSONAL.dbo.detalle_auxiliares set contenido = '" & strPromedio & "' " & _
                                "    where cod_comp = 'WME' and reloj = '" & strRelojPIDA & "' and campo = 'ENTREVISTA' " & _
                                "end", "PERSONAL")
                Next
                MsgBox("Se actualizaron los datos auxiliares para los candidatos de la vacante seleccionada.", MsgBoxStyle.Information, "Auxiliares Guardados.")
            Else
                MsgBox("No se encontraron datos pendientes para la vacante seleccionada.", MsgBoxStyle.Exclamation, "Auxiliares.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MostrarInformacion()
    End Sub

    Private Sub btnLiberarPosiciones_Click(sender As Object, e As EventArgs) Handles btnLiberarPosiciones.Click
        Dim strFolios As String = ""
        Try
            Dim result As Integer = MessageBox.Show("¿Deseas confirmar la liberacion de las posiciones? ", "Confirmar liberacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.OK Then
            End If
            For Each row As DataGridViewRow In dgSolicitudes.Rows
                If row.Cells("Posicion").Value Then
                    strFolios &= "'" & row.Cells("Folio").Value.ToString & "',"
                End If
            Next
            If strFolios.Length <= 0 Then
                MessageBox.Show("No selecciono ningun candidato para liberar su posicion.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            strFolios &= ","
            strFolios = strFolios.Replace(",,", "")
            If strFolios.Length > 0 Then
                Try
                    sqlExecute("update posiciones set status = 1 where cod_posicion in (select Position from candidatos where folio in (" & strFolios & "))", "RECLUTAMIENTO")
                Catch
                End Try
                sqlExecute("update candidatos set Position = '' where folio in (" & strFolios & ")", "RECLUTAMIENTO")
                MsgBox("Se liberaron las posiciones para los candidatos seleccionados.", MsgBoxStyle.Information, "Posiciones liberadas.")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim frmsolvacantes As New frmReporteSolicitudesVacantes()
        frmsolvacantes.strCodVac = Trim(cmbVacantes.SelectedValue)
        frmsolvacantes.ShowDialog(Me)
    End Sub
End Class