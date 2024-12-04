Imports OfficeOpenXml

Public Class frmLider
#Region "Declaraciones"
    Dim dtLista As DataTable        'Lista de datos para grid
    Dim dtRegistro As DataTable     'Mantiene el registro actual
    Dim dtCias As DataTable         'Tabla de compañías
    Dim dtSuper As DataTable        'Tabla de supervisores
    Dim dtReloj As DataTable

    Dim dtClerks As New DataTable   'Tabla  de Clerks

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
#End Region


    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar

        chkTodasLasCias.Visible = (Agregar Or Editar Or NoRec)

        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)


        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If

        txtCodigo.Enabled = Agregar
        cmbCia.Enabled = Agregar

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            '*** LA CLERKS ***
            ' cmbClerks.SelectedIndex = -1
            '*****************
            txtEmail.Text = ""
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
        End If
    End Sub
    Private Sub MostrarInformacion()

        Dim i As Integer
        txtCodigo.Text = dtRegistro.Rows(0).Item("cod_lider")
        cmbCia.SelectedValue = dtRegistro.Rows(0).Item("cod_comp")
        cmbReloj.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("reloj")), "", dtRegistro.Rows(0).Item("reloj"))
        txtNombre.Text = dtRegistro.Rows(0).Item("nombre").ToString.Trim

        '*** LA CLERKS ***
        'Try
        '    cmbClerks.SelectedValue = IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_clerk")), "", dtRegistro.Rows(0).Item("cod_clerk"))
        'Catch ex As Exception
        '    cmbClerks.SelectedIndex = -1
        'End Try
        '****************

        Try
            txtEmail.Text = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("correo")), "", dtRegistro.Rows(0).Item("correo")))
        Catch ex As Exception

        End Try

        If Not DesdeGrid Then
            i = dtLista.DefaultView.Find(txtCodigo.Text)
            If i >= 0 Then
                dgTabla.FirstDisplayedScrollingRowIndex = i
                dgTabla.Rows(i).Selected = True
            End If
        End If
        DesdeGrid = False
        HabilitarBotones()
    End Sub

    Private Sub ReporteRelacionClerkSupervisor(ByVal dtInformacion As DataTable)

        Dim archivo As ExcelPackage = New ExcelPackage()
        Dim wb As ExcelWorkbook = archivo.Workbook
        Dim frm As New frmTrabajando

        Try

            If dtInformacion.Columns.Contains("ERROR") Then
                MessageBox.Show("Se presentó un problema al buscar la información requerida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf dtInformacion.Rows.Count > 0 Then

                Dim sfd As New SaveFileDialog

                sfd.Title = "Guardar en"
                sfd.FileName = "Reporte_relación_clerk-supervisor"
                sfd.DefaultExt = "xlsx"
                sfd.AddExtension = True
                sfd.OverwritePrompt = True
                sfd.Filter = "Excel(*.xlsx)|*.xlsx"

                If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    ' Reporte a detalle Excel
                    Dim x As Integer = 1
                    Dim y As Integer = 1

                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add("Reporte relación clerk-supervisor")

                    '-----ENCABEZADOS----------
                    '**VALORES FIJOS

                    hoja_excel.Cells(x, y).Value = "COD_CLERK"
                    hoja_excel.Cells(x, y).Style.Font.Bold = True

                    hoja_excel.Cells(x, y + 1).Value = "NOMBRE_CLERK"
                    hoja_excel.Cells(x, y + 1).Style.Font.Bold = True

                    hoja_excel.Cells(x, y + 2).Value = "COD_SUPER"
                    hoja_excel.Cells(x, y + 2).Style.Font.Bold = True

                    hoja_excel.Cells(x, y + 3).Value = "NOMBRE_SUPER"
                    hoja_excel.Cells(x, y + 3).Style.Font.Bold = True

                    hoja_excel.Cells(x, y + 4).Value = "RELOJ"
                    hoja_excel.Cells(x, y + 4).Style.Font.Bold = True

                    hoja_excel.Cells(x, y + 5).Value = "ID_SF_SUPER"
                    hoja_excel.Cells(x, y + 5).Style.Font.Bold = True

                    x += 1

                    frm.Show()

                    For Each drRow As DataRow In dtInformacion.Rows

                        My.Application.DoEvents()

                        hoja_excel.Cells(x, y).Value = Trim(IIf(IsDBNull(drRow("COD_CLERK")), "", drRow("COD_CLERK")))

                        hoja_excel.Cells(x, y + 1).Value = Trim(IIf(IsDBNull(drRow("Clerk")), "", drRow("Clerk")))

                        hoja_excel.Cells(x, y + 2).Value = Trim(IIf(IsDBNull(drRow("COD_SUPER")), "", drRow("COD_SUPER")))

                        hoja_excel.Cells(x, y + 3).Value = Trim(IIf(IsDBNull(drRow("Supervisor")), "", drRow("Supervisor")))

                        hoja_excel.Cells(x, y + 4).Value = Trim(IIf(IsDBNull(drRow("RELOJ")), "", drRow("RELOJ")))

                        hoja_excel.Cells(x, y + 5).Value = Trim(IIf(IsDBNull(drRow("cod_sf")), "", drRow("cod_sf")))

                        x += 1
                    Next

                    hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

                    archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))

                    MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)


                End If

            Else

                MessageBox.Show("No se encontró la información requerida para el reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar procesar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ActivoTrabajando = False
        frm.Close()

    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("lideres", "cod_lider", "lider", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * from lideres WHERE cod_lider = '" & Cod & "' AND cod_comp = '" & Compania & "'")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Primero("lideres", "(cod_comp + cod_lider)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Anterior("lideres", "(cod_comp + cod_lider)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtNombre.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Ultimo("lideres", "(cod_comp + cod_lider)", dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim dtCias As DataTable

        If Agregar Then

            ' Si Agregar, revisar si existe cod_comp+cod_depto
            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                dtTemporal = sqlExecute("SELECT cod_lider FROM lideres where cod_comp = '" & row("cod_comp") & "' AND cod_lider = '" & txtCodigo.Text & "'")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el lider '" & txtCodigo.Text & "' asignado a la compañía '" & row("cod_comp") & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                End If
            Next

            For Each row As DataRow In dtCias.Rows
                Dim nompro As String
                nompro = StrConv(txtNombre.Text, VbStrConv.ProperCase)
                'sqlExecute("INSERT INTO super (cod_comp,cod_super,nombre,reloj) VALUES ('" & row("cod_comp") & "','" & txtCodigo.Text & "','" & nompro & "','" & cmbReloj.SelectedValue & "')")

                '*** LA CLERKS ***
                Dim Clerk As String = ""
                sqlExecute("INSERT INTO lideres (cod_comp,cod_lider,nombre,reloj) VALUES ('" & row("cod_comp") & "','" & txtCodigo.Text & "','" & nompro & "','" & cmbReloj.SelectedValue & "')")
                sqlExecute("UPDATE lideres SET correo = '" & txtEmail.Text & "' WHERE cod_lideres = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
                '*****************

                Agregar = False
            Next


        ElseIf Editar Then
            ' Si Editar, entonces guardar cambios a registro

            dtCias = sqlExecute("select * from cias " & IIf(chkTodasLasCias.Checked = True, "", " where cod_comp = '" & cmbCia.SelectedValue & "'"))

            For Each row As DataRow In dtCias.Rows
                Dim dttabla As DataTable = sqlExecute("select *  from deptos where cod_comp = '" & row("cod_comp") & "' and cod_depto = '" & txtCodigo.Text & "'")
                ' Si Editar, entonces guardar cambios a registro
                ' sqlExecute("UPDATE super SET nombre = '" & txtNombre.Text & "', reloj = '" & cmbReloj.SelectedValue & "' WHERE cod_super = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")

                '*** LA CLERKS ***
                Dim Clerk As String = ""
                sqlExecute("UPDATE lideres SET nombre = '" & txtNombre.Text & "', reloj = '" & cmbReloj.SelectedValue & "' WHERE cod_lider = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
                sqlExecute("UPDATE lideres SET correo = '" & txtEmail.Text & "' WHERE cod_lider = '" & txtCodigo.Text & "' AND cod_comp = '" & row("cod_comp") & "'")
                '*****************
            Next

        Else
            Agregar = True
        End If
        Editar = False

        HabilitarBotones()
    End Sub

    Private Sub frmLider_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtLista = sqlExecute("SELECT cod_comp as 'Compañía',cod_lider as 'Código',Nombre FROM lideres")
            dtLista.DefaultView.Sort = "Código"
            dgTabla.DataSource = dtLista
            dgTabla.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias

            dtReloj = sqlExecute("SELECT reloj, (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw ORDER BY reloj")
            cmbReloj.DataSource = dtReloj
            cmbReloj.ValueMember = "reloj"
            cmbReloj.DisplayMembers = "reloj, nombres"

            '*** LA Clerks ***
            'dtClerks = sqlExecute("SELECT cod_clerk,rtrim(isnull(nombre,'')) as nombre from clerks ORDER BY cod_clerk")
            'cmbClerks.DataSource = dtClerks
            'cmbClerks.ValueMember = "cod_clerk"
            'cmbClerks.DisplayMembers = "cod_clerk,nombre"
            '*****************

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM lideres ORDER BY cod_comp ASC, cod_lider ASC")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Siguiente("lideres", "(cod_comp + cod_lider)", cmbCia.SelectedValue & txtCodigo.Text, dtRegistro)
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        Dim codigo As String, comp As String
        codigo = txtCodigo.Text
        comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT reloj from personalvw WHERE cod_linea = '" & codigo & "' AND cod_comp = '" & comp & "'")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un líder que se encuentre asignado a algún empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM lideres WHERE cod_lider = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtDatos As New DataTable
        'dtDatos = sqlExecute("SELECT * FROM super WHERE cod_comp = '" & cmbCia.Text & "'")
        'frmVistaPrevia.LlamarReporte("Supervisores", dtDatos, cmbCia.Text)
        'frmVistaPrevia.ShowDialog()

        dtDatos = sqlExecute("SELECT super.COD_COMP,super.COD_SUPER,super.NOMBRE as Supervisor,super.RELOJ,super.COD_CLERK,clerks.NOMBRE as Clerk," & vbCr & _
                     " super.cod_sf,super.RELOJ_SUPERG,super.RELOJ_GERENTE FROM super left join clerks on super.COD_CLERK = clerks.COD_CLERK" & vbCr & _
                     " WHERE cod_comp = '" & cmbCia.Text & "'")

        ReporteRelacionClerkSupervisor(dtDatos)



    End Sub

    Private Sub cmbReloj_Validating(sender As Object, e As EventArgs) Handles cmbReloj.SelectedValueChanged
        Try
            If cmbReloj.SelectedValue <> "" Then
                dtTemporal = sqlExecute("SELECT (rtrim(nombre) + ' ' + rtrim(apaterno)) as nombres from personalvw WHERE reloj = '" & cmbReloj.SelectedValue & "'")
                If dtTemporal.Rows.Count = 0 Then
                    txtNombre.Text = "NO LOCALIZADO"
                Else
                    txtNombre.Text = StrConv(dtTemporal.Rows(0).Item("nombres").ToString.Trim, VbStrConv.ProperCase)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub cmbReloj_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbReloj.ButtonCustomClick
        Try
            'Reloj = "CANCEL"
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                'MostrarInformacion()
                cmbReloj.SelectedValue = Reloj
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub dgTabla_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        On Error Resume Next

        Dim cod As String, nom As String

        DesdeGrid = True

        cod = dgTabla.Item("Código", e.RowIndex).Value
        nom = dgTabla.Item("Compañía", e.RowIndex).Value
        dtRegistro = sqlExecute("SELECT * from lideres WHERE cod_lider = '" & cod & "' AND cod_comp = '" & nom & "'")
        MostrarInformacion()
    End Sub
End Class