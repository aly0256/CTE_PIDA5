Public Class frmElegirEtiquetas

    Private Sub frmElegirEtiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormaOrigen = "frmReporteador" Then
            cmbEtiquetas.DataSource = sqlExecute("select * from etiquetas")
        Else
            cmbEtiquetas.DataSource = sqlExecute("select * from etiquetas", "SERMED")
        End If
    End Sub
    Public Sub Etiqueta_5164_Beneficiarios(ByVal dtInformacion As DataTable)
        Me.Hide()
        Try
            Dim dtEtiqueta As DataTable
            Dim z As Integer
            Dim NombreEtiqueta As String = "AVERY 8066" ' AOS - Lo dejamos directo
            '  Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = '" + cmbEtiquetas.SelectedValue.ToString + "'", "SERMED") ' Forma Original

            Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = '" + NombreEtiqueta + "'", "PERSONAL")
            Dim Reporte As String = ""
            For Each row As DataRow In dtEtiquetas.Rows
                z = row.Item("numero_etiquetas")
                Reporte = row.Item("Reporte").ToString.Trim
            Next

            Dim dtDatos As New DataTable
            Dim x As Integer
            Dim Columnas(7) As DataColumn
            Dim fr As New frmEtiquetas
            Dim dtDatosCia As New DataTable
            ReDim EtiquetasDisponibles(29)
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj011", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres011", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("alta011", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("reloj012", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("nombres012", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("alta012", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("beneficiarios011", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("beneficiarios012", System.Type.GetType("System.String"))
            'estructura temporal
            Dim dtTemp As New DataTable
            dtTemp.Columns.Add("reloj", Type.GetType("System.String"))
            dtTemp.Columns.Add("nombres", Type.GetType("System.String"))
            dtTemp.Columns.Add("nombre", Type.GetType("System.String"))
            dtTemp.Columns.Add("adicionales", Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next
            For x = 0 To EtiquetasDisponibles.Count - 1
                EtiquetasDisponibles(x) = 1
            Next
            fr.MAXIMO_ETIQUETAS = z
            fr.ShowDialog()
            x = 0
            Dim dReg As DataRow = Nothing

            For Each registro As DataRow In dtInformacion.Rows
                dtEtiqueta = sqlExecute("select familiares.* from  personal.dbo.familiares where reloj='" & registro("reloj") & "'")
                For Each record As DataRow In dtEtiqueta.Rows
                    Dim fila As DataRow
                    fila = dtTemp.NewRow
                    fila("reloj") = registro("reloj")
                    Dim nombre_familiar As String = ""

                    Try
                        For Each n As String In record("nombre").ToString.Split(",")
                            nombre_familiar &= n & " "
                        Next
                        fila("nombre") = nombre_familiar

                    Catch ex As Exception
                        fila("nombre") = record("nombre")
                    End Try

                    fila("nombres") = registro("nombres")

                    Dim adicionales As String = ""

                    For Each f As DataRow In dtEtiqueta.Rows
                        adicionales &= RTrim(f("nombre")) & vbCrLf
                    Next

                    fila("adicionales") = adicionales

                    dtTemp.Rows.Add(fila)
                Next
            Next

            Dim dtTest As DataTable = dtTemp.DefaultView.ToTable("test", True, "reloj", "nombres", "adicionales")
            For Each dRow As DataRowView In dtTest.DefaultView
                Do While x < z
                    If EtiquetasDisponibles(x) = 1 Then
                        'Si esta etiqueta está disponible, salir del ciclo y pasar información
                        Exit Do
                    Else
                        'Si la etiqueta no está disponible, ignorarla
                        If x Mod 2 = 0 Then
                            'Si x es par, agregar registro en blanco
                            dReg = dtDatos.NewRow
                        Else
                            'Si x es non, insertar el registro en la tabla
                            dtDatos.Rows.Add(dReg)
                        End If
                        x = x + 1
                    End If
                Loop
                If x Mod 2 = 0 Then
                    'Si x es par, generar registro en blanco
                    dReg = dtDatos.NewRow
                End If
                'Pasar la información a la tabla. Si la x es par, ponerlo en la columna 1, si es non, en columna 2.
                dReg("reloj01" & (x Mod 2) + 1) = dRow.Item("reloj")
                dReg("nombres01" & (x Mod 2) + 1) = dRow.Item("nombres")
                dReg("beneficiarios01" & (x Mod 2) + 1) = dRow.Item("adicionales")

                If x Mod 2 = 1 Then
                    'Si x es non, insertar el registro en la tabla 
                    dtDatos.Rows.Add(dReg)
                End If
                x = x + 1

                'BG 19/10/15
                Dim a As Integer
                a = dtInformacion.Rows.Count
                If x = a And x Mod 2 = 1 Then
                    dtDatos.Rows.Add(dReg)
                End If


                If x >= z Then
                    'Si ya se completaron las 30 etiquetas, 
                    'considerar que la siguiente hoja de etiquetas está completa, y poner todas como disponibles
                    For x = 0 To z
                        EtiquetasDisponibles(x) = 1
                    Next
                    'Reiniciar X para iniciar en el tope de la hoja
                    x = 0
                End If
            Next
            frmVistaPrevia.LlamarReporte(Reporte, dtDatos)
            frmVistaPrevia.ShowDialog()
            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
            Me.Close()
        End Try
    End Sub
    Public Sub Etiqueta_5164_Pacientes(ByVal dtInformacion As DataTable)
        Me.Hide()
        Try
            Dim z As Integer
            Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = '" + cmbEtiquetas.SelectedValue.ToString + "'", "SERMED")
            Dim Reporte As String = ""
            For Each row As DataRow In dtEtiquetas.Rows
                z = row.Item("numero_etiquetas")
                Reporte = row.Item("Reporte").ToString.Trim

            Next
            Dim dtDatos As New DataTable
            Dim x As Integer
            Dim Columnas(13) As DataColumn
            Dim fr As New frmEtiquetas
            Dim dtDatosCia As New DataTable
            ReDim EtiquetasDisponibles(29)
            dtDatos = New DataTable("Datos")
            fr.MAXIMO_ETIQUETAS = z
            Columnas(0) = New DataColumn("reloj011", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("alta011", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("super011", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("codsuper011", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("turno011", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("departamento011", System.Type.GetType("System.String"))
            Columnas(6) = New DataColumn("paciente011", System.Type.GetType("System.String"))
            Columnas(7) = New DataColumn("reloj012", System.Type.GetType("System.String"))
            Columnas(8) = New DataColumn("alta012", System.Type.GetType("System.String"))
            Columnas(9) = New DataColumn("super012", System.Type.GetType("System.String"))
            Columnas(10) = New DataColumn("codsuper012", System.Type.GetType("System.String"))
            Columnas(11) = New DataColumn("turno012", System.Type.GetType("System.String"))
            Columnas(12) = New DataColumn("departamento012", System.Type.GetType("System.String"))
            Columnas(13) = New DataColumn("paciente012", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            For x = 0 To EtiquetasDisponibles.Count - 1
                EtiquetasDisponibles(x) = 1
            Next

            fr.ShowDialog()
            x = 0
            Dim dReg As DataRow = Nothing
            For Each dRow As DataRowView In dtInformacion.DefaultView
                Do While x < z
                    If EtiquetasDisponibles(x) = 1 Then
                        'Si esta etiqueta está disponible, salir del ciclo y pasar información
                        Exit Do
                    Else
                        'Si la etiqueta no está disponible, ignorarla
                        If x Mod 2 = 0 Then
                            'Si x es par, agregar registro en blanco
                            dReg = dtDatos.NewRow
                        Else
                            'Si x es non, insertar el registro en la tabla
                            dtDatos.Rows.Add(dReg)
                        End If
                        x = x + 1
                    End If
                Loop
                If x Mod 2 = 0 Then
                    'Si x es par, generar registro en blanco
                    dReg = dtDatos.NewRow
                End If
                'Pasar la información a la tabla. Si la x es par, ponerlo en la columna 1, si es non, en columna 2.
                dReg("reloj01" & (x Mod 2) + 1) = dRow.Item("reloj")
                dReg("alta01" & (x Mod 2) + 1) = dRow.Item("alta")
                dReg("super01" & (x Mod 2) + 1) = dRow.Item("nombre_super")
                dReg("codsuper01" & (x Mod 2) + 1) = dRow.Item("cod_super")
                dReg("turno01" & (x Mod 2) + 1) = dRow.Item("cod_turno")
                dReg("departamento01" & (x Mod 2) + 1) = dRow.Item("nombre_depto")
                dReg("paciente01" & (x Mod 2) + 1) = dRow.Item("nombres")
                If x Mod 2 = 1 Then
                    'Si x es non, insertar el registro en la tabla 
                    dtDatos.Rows.Add(dReg)
                End If
                x = x + 1

                'BG 19/10/15
                Dim a As Integer
                a = dtInformacion.Rows.Count
                If x = a And x Mod 2 = 1 Then
                    dtDatos.Rows.Add(dReg)
                End If


                If x >= z Then
                    'Si ya se completaron las 30 etiquetas, 
                    'considerar que la siguiente hoja de etiquetas está completa, y poner todas como disponibles
                    For x = 0 To z
                        EtiquetasDisponibles(x) = 1
                    Next
                    'Reiniciar X para iniciar en el tope de la hoja
                    x = 0
                End If
            Next
            frmVistaPrevia.LlamarReporte(Reporte, dtDatos)
            frmVistaPrevia.ShowDialog()
            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
            Me.Close()
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtDatosEtiquetas As DataTable
        If (FiltroReporte = "") Then
            dtDatosEtiquetas = sqlExecute("SELECT reloj, nombres, alta, baja, cod_super, nombre_super, cod_depto, nombre_depto, cod_turno FROM PERSONAL.dbo.PersonalVW")
        Else
            dtDatosEtiquetas = sqlExecute("SELECT reloj, nombres, alta, baja, cod_super, nombre_super, cod_depto, nombre_depto, cod_turno FROM PERSONAL.dbo.PersonalVW WHERE" & FiltroReporte & "")
        End If

        Dim dtDatos As New DataTable
        If cmbEtiquetas.SelectedValue = "AVERY 5164 Beneficiarios" Then
            Etiqueta_5164_Beneficiarios(dtDatosEtiquetas)
        ElseIf cmbEtiquetas.SelectedValue = "AVERY 5164 Pacientes" Then
            Etiqueta_5164_Pacientes(dtDatosEtiquetas)
        Else
            Etiquetas(dtDatosEtiquetas)
        End If

    End Sub

    Public Sub MandarEtiquetas()
        Dim dtDatosEtiquetas As DataTable
        If (FiltroReporte = "") Then
            dtDatosEtiquetas = sqlExecute("SELECT reloj, nombres, alta, baja, cod_super, nombre_super, cod_depto, nombre_depto, cod_turno FROM PERSONAL.dbo.PersonalVW")
        Else
            dtDatosEtiquetas = sqlExecute("SELECT reloj, nombres, alta, baja, cod_super, nombre_super, cod_depto, nombre_depto, cod_turno FROM PERSONAL.dbo.PersonalVW WHERE" & FiltroReporte & "")
        End If

        Dim dtDatos As New DataTable
        If cmbEtiquetas.SelectedValue = "AVERY 5164 Beneficiarios" Then
            Etiqueta_5164_Beneficiarios(dtDatosEtiquetas)
        ElseIf cmbEtiquetas.SelectedValue = "AVERY 5164 Pacientes" Then
            Etiqueta_5164_Pacientes(dtDatosEtiquetas)
        Else
            Etiquetas(dtDatosEtiquetas)
        End If
    End Sub
    Public Sub Etiquetas8066(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)



        Try
            Dim x As Integer
            Dim Columnas(5) As DataColumn

            Dim fr As New frmEtiquetas

            Dim dtDatosCia As New DataTable
            ReDim EtiquetasDisponibles(29)

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj011", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres011", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("alta011", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("reloj012", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("nombres012", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("alta012", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            For x = 0 To EtiquetasDisponibles.Count - 1
                EtiquetasDisponibles(x) = 1
            Next
            fr.ShowDialog()
            x = 0
            Dim dReg As DataRow = Nothing
            For Each dRow As DataRowView In dtInformacion.DefaultView
                Do While x < 30
                    If EtiquetasDisponibles(x) = 1 Then
                        'Si esta etiqueta está disponible, salir del ciclo y pasar información
                        Exit Do
                    Else
                        'Si la etiqueta no está disponible, ignorarla
                        If x Mod 2 = 0 Then
                            'Si x es par, agregar registro en blanco
                            dReg = dtDatos.NewRow
                        Else
                            'Si x es non, insertar el registro en la tabla
                            dtDatos.Rows.Add(dReg)
                        End If
                        x = x + 1
                    End If
                Loop
                If x Mod 2 = 0 Then
                    'Si x es par, generar registro en blanco
                    dReg = dtDatos.NewRow
                End If

                'Pasar la información a la tabla. Si la x es par, ponerlo en la columna 1, si es non, en columna 2.
                dReg("reloj01" & (x Mod 2) + 1) = dRow.Item("reloj")
                dReg("alta01" & (x Mod 2) + 1) = FechaCortaLetra(dRow.Item("alta"))
                dReg("nombres01" & (x Mod 2) + 1) = dRow.Item("nombres")
                If x Mod 2 = 1 Then
                    'Si x es non, insertar el registro en la tabla 
                    dtDatos.Rows.Add(dReg)
                End If
                x = x + 1

                'BG 19/10/15
                Dim a As Integer
                a = dtInformacion.Rows.Count
                If x = a And x Mod 2 = 1 Then
                    dtDatos.Rows.Add(dReg)
                End If

                If x >= 30 Then
                    'Si ya se completaron las 30 etiquetas, 
                    'considerar que la siguiente hoja de etiquetas está completa, y poner todas como disponibles
                    For x = 0 To EtiquetasDisponibles.GetUpperBound(1)
                        EtiquetasDisponibles(0) = 1
                    Next
                    'Reiniciar X para iniciar en el tope de la hoja
                    x = 0
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub Etiquetas(ByVal dtInformacion As DataTable)
        Me.Hide()
        Try
            Dim z As Integer
            Dim NombreEtiqueta As String = "AVERY 8066" ' AOS - Lo dejamos directo
            '    Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = '" + cmbEtiquetas.SelectedValue.ToString + "'")' Forma Original
            Dim dtEtiquetas As DataTable = sqlExecute("select * from etiquetas where etiqueta = '" + NombreEtiqueta + "'", "PERSONAL")


            Dim Reporte As String = ""
            For Each row As DataRow In dtEtiquetas.Rows
                z = row.Item("numero_etiquetas")
                Reporte = row.Item("Reporte").ToString.Trim
            Next

            Dim dtDatos As New DataTable
            Dim x As Integer
            Dim Columnas(5) As DataColumn
            Dim fr As New frmEtiquetas
            Dim dtDatosCia As New DataTable
            ReDim EtiquetasDisponibles(40)

            'Crear estructura de datos
            dtDatos = New DataTable("Datos")
            Columnas(0) = New DataColumn("reloj011", System.Type.GetType("System.String"))
            Columnas(1) = New DataColumn("nombres011", System.Type.GetType("System.String"))
            Columnas(2) = New DataColumn("alta011", System.Type.GetType("System.String"))
            Columnas(3) = New DataColumn("reloj012", System.Type.GetType("System.String"))
            Columnas(4) = New DataColumn("nombres012", System.Type.GetType("System.String"))
            Columnas(5) = New DataColumn("alta012", System.Type.GetType("System.String"))

            For x = 0 To UBound(Columnas)
                dtDatos.Columns.Add(Columnas(x))
            Next

            For x = 0 To EtiquetasDisponibles.Count - 1
                EtiquetasDisponibles(x) = 1
            Next
            fr.MAXIMO_ETIQUETAS = z
            fr.ShowDialog()
            x = 0
            Dim dReg As DataRow = Nothing
            For Each dRow As DataRowView In dtInformacion.DefaultView
                Do While x < z
                    If EtiquetasDisponibles(x) = 1 Then
                        'Si esta etiqueta está disponible, salir del ciclo y pasar información
                        Exit Do
                    Else
                        'Si la etiqueta no está disponible, ignorarla
                        If x Mod 2 = 0 Then
                            'Si x es par, agregar registro en blanco
                            dReg = dtDatos.NewRow
                        Else
                            'Si x es non, insertar el registro en la tabla
                            dtDatos.Rows.Add(dReg)
                        End If
                        x = x + 1
                    End If
                Loop
                If x Mod 2 = 0 Then
                    'Si x es par, generar registro en blanco
                    dReg = dtDatos.NewRow
                End If
                'Pasar la información a la tabla. Si la x es par, ponerlo en la columna 1, si es non, en columna 2.
                dReg("reloj01" & (x Mod 2) + 1) = dRow.Item("reloj")
                ' dReg("alta01" & (x Mod 2) + 1) = dRow.Item("alta")
                dReg("alta01" & (x Mod 2) + 1) = FechaSQL(dRow.Item("alta"))
                dReg("nombres01" & (x Mod 2) + 1) = dRow.Item("nombres")
                If x Mod 2 = 1 Then
                    'Si x es non, insertar el registro en la tabla 
                    dtDatos.Rows.Add(dReg)
                End If
                x = x + 1

                'BG 19/10/15
                Dim a As Integer
                a = dtInformacion.Rows.Count
                If x = a And x Mod 2 = 1 Then
                    dtDatos.Rows.Add(dReg)
                End If


                If x >= z Then
                    'Si ya se completaron las 30 etiquetas, 
                    'considerar que la siguiente hoja de etiquetas está completa, y poner todas como disponibles
                    For x = 0 To z
                        EtiquetasDisponibles(x) = 1
                    Next
                    'Reiniciar X para iniciar en el tope de la hoja
                    x = 0
                End If
            Next
            frmVistaPrevia.LlamarReporte(Reporte, dtDatos)
            frmVistaPrevia.ShowDialog()
            Me.Close()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "RecursosHumanos", ex.HResult, ex.Message)
            Me.Close()
        End Try
    End Sub
    
End Class