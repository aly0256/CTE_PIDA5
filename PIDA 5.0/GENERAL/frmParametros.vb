
'Imports Microsoft.Office.Interop
Public Class frmParametros

#Region "Declaraciones"
    Dim dtTemp As New DataTable
    Dim CambioLogo As Boolean = False

    ' Variables para Parametros
    Dim EditarParametros As Boolean                   'Modificar registro?
    Dim AgregarParametros As Boolean                  'Agregar nuevo?
    Dim ParametrosIdx As Integer                      'Indice actual
    Dim dtParametros As New DataTable                 'Tabla de compañías
    Dim dtPaths As New DataTable                      'Tabla que contiene todos los PATHS que va a utilizar el sistema


    ' Variables para modificaciones de sueldo
    Dim dtSueldo As New DataTable
    Dim CambiosSueldo(3, 0) As String           'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarSueldo As Boolean                 'Modificar registro?
    Dim AgregarSueldo As Boolean                'Agregar nuevo?
    Dim SueldoAnt As String                     'Código anterior

    ' Variables para Vacaciones
    Dim dtVacaciones As New DataTable
    Dim CambiosVacaciones(6, 0) As String         'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarVacaciones As Boolean               'Modificar registro?
    Dim AgregarVacaciones As Boolean              'Agregar nuevo?
    Dim VacacionesAnt As String                   'Código anterior

    'Variables para Documentos Word
    Dim dtDocumentos As New DataTable
    Dim EditarDocs As Boolean

    'Variables para TA
    Dim dtAusentismo As New DataTable

    Dim dtValores As New DataTable
    Dim dtCampos As New DataTable

    'Variables para nómina
    Dim dtMetodoPago As New DataTable
    Dim dtPeriodosI As New DataTable
    Dim dtPeriodosF As New DataTable
    Dim dtPeriodosP As New DataTable

#End Region

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        If AgregarParametros Then
            EditarParametros = True
        End If
        AgregarParametros = False
        EditarParametros = Not EditarParametros
        MostrarParametros()
        txtFotografias.Focus()

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ActualizarInfo()
    End Sub
    Private Sub ActualizarInfo()
        Dim Campo As String
        Try
            EditarParametros = False
            dtTemp = sqlExecute("SELECT * FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                sqlExecute("INSERT INTO Parametros (path_foto) VALUES ('')")
            End If

            '--Estos 3 paths se deben de actualizar en SEGURIDAD.paths
            sqlExecute("UPDATE Parametros SET path_foto = '" & txtFotografias.Text & "'")
            sqlExecute("UPDATE Parametros SET path_reportes = '" & txtReportes.Text & "'")
            sqlExecute("UPDATE Parametros SET path_firma_capacitacion = '" & txtDirFirma.Text & "'")
            'sqlExecute("UPDATE paths set path_foto = '" & txtFotografias.Text & "'", "SEGURIDAD")
            'sqlExecute("UPDATE paths set path_reportes = '" & txtReportes.Text & "'", "SEGURIDAD")
            'sqlExecute("UPDATE paths set path_firma_capacitacion = '" & txtDirFirma.Text & "'", "SEGURIDAD")
            sqlExecute("UPDATE Parametros SET vacaciones_desde_variables = " & IIf(btnActualizaVacaciones.Value, 1, 0) & "")
            sqlExecute("UPDATE Parametros SET nc_empl = " & IIf(btnNC_Empl.Value, 1, 0) & "")
            sqlExecute("UPDATE Parametros SET metodo_pago_deducciones = '" & cmbDeducciones.SelectedValue & "'")
            sqlExecute("UPDATE Parametros SET SEMANA_INICIO_FONDO_AHORRO = '" & cmbInicio.SelectedValue & "'")
            sqlExecute("UPDATE Parametros SET SEMANA_FIN_FONDO_AHORRO = '" & cmbFin.SelectedValue & "'")
            sqlExecute("UPDATE Parametros SET PERMITIR_PRESTAMOS = '" & IIf(btnPrestamos.Value, 1, 0) & "'")
            sqlExecute("UPDATE Parametros SET SEMANA_INICIO_PRESTAMOS = '" & cmbInicioPrestamos.SelectedValue & "'")
            sqlExecute("UPDATE parametros SET path_hrs = '" & txtArchivo.Text & "'")
            sqlExecute("UPDATE parametros SET usa_gafete = " & IIf(sbReloj.Value, 1, 0) & "")
            sqlExecute("UPDATE parametros SET ausentismo = '" & cmbAusentismo.SelectedValue & "'")
            sqlExecute("UPDATE parametros SET inicia_sem = " & IIf(sbInicio.Value, 2, 1) & "")
            sqlExecute("UPDATE Parametros SET validar_clave_acceso = " & IIf(btnValidacion.Value, 1, 0))
            sqlExecute("UPDATE Parametros SET longitud_clave_acceso = " & intLongitud.Value)
            sqlExecute("UPDATE Parametros SET dias_expira_clave = " & intDias.Value)
            sqlExecute("UPDATE Parametros SET reiniciar_relojes_automatico = " & IIf(btnReiniciar.Value, 1, 0))
            sqlExecute("UPDATE Parametros SET analizar_entrada_salida = " & IIf(btnEntradaSalida.Value, 1, 0))
            sqlExecute("UPDATE Parametros SET minutos_importacion = " & intMinutos.Value)
            sqlExecute("UPDATE Parametros SET pago_vacaciones_semana_captura = " & IIf(chkCaptura.Checked, 1, 0))
            ' sqlExecute("UPDATE Parametros SET ideas_meta_anual = " & intMeta.Value)
            '   
            '  sqlExecute("UPDATE Parametros SET fecha_corte_talloc = '" & FechaSQL(txtFecha.Value) & "'")

            If chkTodos.Checked Then
                txtCriterio.Text = ""
            End If
            ' sqlExecute("UPDATE Parametros SET filtro_talloc = '" & txtCriterio.Text.Trim.Replace("'", "''") & "'")

            Campo = ""
            For Each it In lstAdicionales.Items
                Campo = Campo & IIf(Campo.Length = 0, "", ",") & it.ToString.Trim

            Next
            sqlExecute("UPDATE Parametros SET campos_busqueda ='" & Campo & "'")

            PathFoto = txtFotografias.Text.Trim
            PathFoto = PathFoto & IIf(PathFoto.Substring(PathFoto.Length - 1) = "\", "", "\")

            DireccionReportes = txtReportes.Text.Trim
            DireccionReportes = DireccionReportes & IIf(DireccionReportes.Substring(DireccionReportes.Length - 1) = "\", "", "\")

            PathFirma = txtDirFirma.Text.Trim
            PathFirma = PathFirma & IIf(PathFirma.Substring(PathFirma.Length - 1) = "\", "", "\")
            'MCR 9/NOV/2015
            IniciaLunes = sbInicio.Value

            dtParametros = sqlExecute("SELECT * FROM Parametros")
            ' dtPaths = sqlExecute("SELECT * from paths", "SEGURIDAD")
            dtPaths = sqlExecute("select path_foto,path_reportes,path_firma_capacitacion from parametros", "PERSONAL")

            MostrarParametros()
            HabilitarParametros()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Cod As String, x As Integer
        Cod = Buscar("Parametros", "cod_comp", "COMPAÑIAS", False)
        If Cod <> "CANCELAR" Then
            x = dtParametros.DefaultView.Find(Cod)
            If x >= 0 Then MostrarParametros()
        End If
    End Sub
    Private Sub HabilitarParametros()
        Dim NoRec As Boolean
        NoRec = dtParametros.Rows.Count = 0

        btnCerrar.Enabled = Not (AgregarParametros Or EditarParametros Or NoRec)

        If AgregarParametros Or EditarParametros Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnNuevo.Text = "Aceptar"
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnEditar.Text = "Cancelar"
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnNuevo.Text = "Agregar"
            btnEditar.Image = PIDA.My.Resources.Edit
            btnEditar.Text = "Editar"
        End If

        btnNuevo.Visible = EditarParametros
        btnNC_Empl.Enabled = EditarParametros

        'pnlGeneral.Enabled = AgregarParametros Or EditarParametros
        'pnlRegistros.Enabled = AgregarParametros Or EditarParametros
        'pnlDirecciones.Enabled = AgregarParametros Or EditarParametros
        'pnlTA.Enabled = AgregarParametros Or EditarParametros


        'Información general
        For Each Ctr In tbInfo.Controls
            If TypeOf Ctr Is DevComponents.DotNetBar.SuperTabControlPanel Then
                For Each Control In Ctr.controls
                    If TypeOf Control Is DevComponents.DotNetBar.Controls.SwitchButton Then
                        Control.isreadonly = Not (AgregarParametros Or EditarParametros)
                    ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.ComboBoxEx Or _
                        TypeOf Control Is DevComponents.DotNetBar.ButtonX Or _
                        TypeOf Control Is DevComponents.DotNetBar.Controls.CheckBoxX Or _
                        TypeOf Control Is DevComponents.DotNetBar.Controls.ComboTree Or _
                        TypeOf Control Is DevComponents.Editors.DateTimeAdv.DateTimeInput Or _
                        TypeOf Control Is DevComponents.Editors.IntegerInput Then
                        Control.Enabled = AgregarParametros Or EditarParametros
                    ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.DataGridViewX Then
                        Control.ReadOnly = Not (AgregarParametros Or EditarParametros)
                    ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.TextBoxX Then
                        Control.ReadOnly = Not (AgregarParametros Or EditarParametros)
                        Control.BackColor = IIf(Control.ReadOnly, SystemColors.Control, SystemColors.Window)
                    ElseIf TypeOf Control Is System.Windows.Forms.RadioButton Or _
                        TypeOf Control Is System.Windows.Forms.GroupBox Or TypeOf Control Is System.Windows.Forms.Panel Then
                        Control.Enabled = (AgregarParametros Or EditarParametros)
                    Else
                        'Stop
                    End If
                Next
            End If
        Next
        If Not (AgregarParametros Or EditarParametros) Then
            pnlEligeTAlloc.Visible = True
            gpFiltro.Visible = False
        End If
        'Nómina
        cmbDeducciones.Enabled = (AgregarParametros Or EditarParametros)

    End Sub

    Private Sub frmParametros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RevisarAccesos()
            pnlEligeTAlloc.Location = gpFiltro.Location
            dtParametros = sqlExecute("SELECT * FROM Parametros")
            ' dtPaths = sqlExecute("SELECT * from paths", "SEGURIDAD")
            dtPaths = sqlExecute("select path_foto,path_reportes,path_firma_capacitacion from parametros", "PERSONAL")

            dtPeriodosI = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
            dtPeriodosF = dtPeriodosI.Copy
            dtPeriodosP = dtPeriodosI.Copy

            cmbInicio.DataSource = dtPeriodosI
            cmbFin.DataSource = dtPeriodosF
            cmbInicioPrestamos.DataSource = dtPeriodosP

            lstAdicionales.Items.Clear()
            For Each Campo In IIf(IsDBNull(dtParametros.Rows(0).Item("campos_busqueda")), "", dtParametros.Rows(0).Item("campos_busqueda").ToString.Split(","))
                lstAdicionales.Items.Add(Campo)
            Next
            cmbDisponibles.DataSource = sqlExecute("SELECT cod_campo,nombre FROM campos UNION " & _
                                                   "(SELECT campo,nombre from auxiliares WHERE campo IN " & _
                                                   "(select distinct campo FROM detalle_auxiliares))")

            dtCampos = sqlExecute("SELECT nombre AS 'NOMBRE',UPPER(cod_campo) as 'COD_CAMPO',tipo FROM campos WHERE tipo='char' ORDER BY nombre")
            cbCampos.DataSource = dtCampos

            cbComparacion.Text = "="

            MostrarParametros()
            ReDim CambiosSueldo(3, 5)

            HabilitarParametros()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub RevisarAccesos()
        Dim Acceso As Boolean
        Dim i As Integer
        Try
            'Revisar cada control dentro del panel
            i = 0
            For Each c In tbInfo.Tabs
                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = '" & c.name & "' AND cod_perfil " & perfil, "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                c.visible = Acceso
                If Acceso Then i = i + 1
            Next
            tbInfo.Visible = i > 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub UbicacionArchivo(ByRef Desc As String, ByVal txtBox As Object)
        Try
            Dim FBD As New FolderBrowserDialog
            FBD.Description = Desc
            FBD.ShowNewFolderButton = True      'OR FALSE
            FBD.SelectedPath = txtBox.Text
            If FBD.ShowDialog() = DialogResult.OK Then
                txtBox.Text = FBD.SelectedPath
            End If
            FBD = Nothing
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnFotografias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFotografias.Click
        UbicacionArchivo("Ubicación de fotografías de empleados", txtFotografias)
    End Sub

    Private Sub MostrarParametros()
        Try
            Dim dPar As DataRow
            Dim dpath As DataRow
            Dim f As Boolean

            If dtParametros.Rows.Count = 0 Then
                dtParametros.Rows.Add()
            End If
            If dtPaths.Rows.Count = 0 Then
                dtPaths.Rows.Add()
            End If
            dPar = dtParametros.Rows.Item(0)
            dpath = dtPaths.Rows.Item(0)

            txtFotografias.Text = IIf(IsDBNull(dpath("path_foto")), "", dpath("path_foto")).ToString.Trim
            txtReportes.Text = IIf(IsDBNull(dpath("path_reportes")), "", dpath("path_reportes")).ToString.Trim
            txtDirFirma.Text = IIf(IsDBNull(dpath("path_firma_capacitacion")), "", dpath("path_firma_capacitacion")).ToString.Trim

            btnActualizaVacaciones.Value = IIf(IsDBNull(dPar("vacaciones_desde_variables")), 0, dPar("vacaciones_desde_variables"))
            btnNC_Empl.Value = IIf(IsDBNull(dPar("nc_empl")), 0, dPar("nc_empl"))

            dtAusentismo = sqlExecute("SELECT tipo_aus,nombre FROM tipo_ausentismo ORDER BY tipo_aus", "TA")
            cmbAusentismo.DataSource = dtAusentismo

            txtArchivo.Text = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("path_hrs")), "", dPar("path_hrs")).ToString.Trim
            sbReloj.Value = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("usa_gafete")), 0, dPar("usa_gafete")) = 1
            cmbAusentismo.SelectedIndex = -1
            cmbAusentismo.SelectedValue = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("ausentismo")), "", dtParametros.Rows.Item(ParametrosIdx).Item("ausentismo"))
            sbInicio.Value = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("inicia_sem")), 1, dPar("inicia_sem")) = 2

            dtMetodoPago = sqlExecute("SELECT codigo,nombre FROM metodo_deducciones", "nomina")
            cmbDeducciones.DataSource = dtMetodoPago
            cmbDeducciones.SelectedValue = IIf(IsDBNull(dPar("metodo_pago_deducciones")), "", dPar("metodo_pago_deducciones"))

            cmbInicio.SelectedValue = IIf(IsDBNull(dPar("SEMANA_INICIO_FONDO_AHORRO")), "", dPar("SEMANA_INICIO_FONDO_AHORRO"))
            cmbFin.SelectedValue = IIf(IsDBNull(dPar("SEMANA_FIN_FONDO_AHORRO")), "", dPar("SEMANA_FIN_FONDO_AHORRO"))
            btnPrestamos.Value = IIf(IsDBNull(dPar("PERMITIR_PRESTAMOS")), 0, dPar("PERMITIR_PRESTAMOS")) = 1
            cmbInicioPrestamos.SelectedValue = IIf(IsDBNull(dPar("SEMANA_INICIO_PRESTAMOS")), "", dPar("SEMANA_INICIO_PRESTAMOS"))

            btnValidacion.Value = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("Validar_clave_acceso")), 0, dPar("Validar_clave_acceso")) = 1
            intLongitud.Value = IIf(IsDBNull(dPar("longitud_clave_acceso")), 0, dPar("longitud_clave_acceso"))
            intDias.Value = IIf(IsDBNull(dPar("dias_expira_clave")), 0, dPar("dias_expira_clave"))
            intMinutos.Value = IIf(IsDBNull(dPar("minutos_importacion")), 0, dPar("minutos_importacion"))
            btnReiniciar.Value = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("reiniciar_relojes_automatico")), 0, dPar("reiniciar_relojes_automatico")) = 1
            btnEntradaSalida.Value = IIf(IsDBNull(dtParametros.Rows.Item(ParametrosIdx).Item("analizar_entrada_salida")), 0, dPar("analizar_entrada_salida")) = 1
            chkCaptura.Checked = IIf(IsDBNull(dPar("pago_vacaciones_semana_captura")), False, dPar("pago_vacaciones_semana_captura"))

            '   txtFecha.ValueObject = dtParametros.Rows(0).Item("fecha_corte_talloc")
            ' f = IIf(IsDBNull(dPar("filtro_talloc")), "", dPar("filtro_talloc")) <> ""
            'txtCriterio.Text = IIf(IsDBNull(dPar("filtro_talloc")), "", dPar("filtro_talloc"))

            ' intMeta.Value = IIf(IsDBNull(dPar("ideas_meta_anual")), 8, dPar("ideas_meta_anual"))

            chkTodos.Checked = Not f
            chkFiltros.Checked = f

            HabilitarParametros()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        dbArchivos.Title = "Ubicación de archivo HORAS EN BRUTO"
        dbArchivos.FileName = txtArchivo.Text
        If dbArchivos.ShowDialog <> DialogResult.Cancel Then
            txtArchivo.Text = dbArchivos.FileName
        End If
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        UbicacionArchivo("Ubicación de reportes", txtReportes)
    End Sub

    Private Sub btnAgregarCampo_Click(sender As Object, e As EventArgs) Handles btnAgregarCampo.Click
        lstAdicionales.Items.Add(cmbDisponibles.SelectedValue)
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lstAdicionales.Items.RemoveAt(lstAdicionales.SelectedIndex)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        Dim Resultado As New DataTable
        Dim R As String
        Dim c As Integer = 0
        Try
            Resultado = FiltrarDatos(txtFiltro.Text.Trim, False)

            lstFiltro.Items.Clear()
            For x = 0 To Resultado.Rows.Count - 1
                R = Resultado.Rows.Item(x).Item(0)
                If lstFiltro.FindString(R) < 0 Then
                    lstFiltro.Items.Add(Resultado.Rows.Item(x).Item(0))
                    lstFiltro.SetItemChecked(c, True)
                    c = c + 1
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function FiltrarDatos(Texto As String, Excepcion As Boolean) As DataTable
        Dim x As Integer
        Dim Campo As String
        Dim Valores() As String
        Valores = Split(Texto, ",")
        Dim FiltraValor As String = ""
        Try
            If cbCampos.SelectedIndex >= 0 Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else
                Campo = ""
            End If

            If UBound(Valores) = 0 And Valores(0) = "" Then
                FiltraValor = Campo & " <> '' AND NOT " & Campo & " IS NULL"
            Else
                For x = 0 To UBound(Valores)
                    If Valores(x).Length = 0 Then
                        'Si el valor está en blanco, utilizar una cadena siempre verdadera para no obstruir la consulta
                        Valores(x) = "1=1"
                    ElseIf Not Valores(x).Contains("*") Then
                        'Si no se incluye el asterisco, agregarlo al final
                        Valores(x) = Valores(x) & "*"
                    End If
                    'Formar la cadena con los valores a filtrar
                    FiltraValor = FiltraValor & Campo & " LIKE ('" & Valores(x).Replace("*", "%") & "')"

                    If x < UBound(Valores) Then
                        'Si no es el último elemento del arreglo, agregar el OR
                        FiltraValor = FiltraValor & " OR "
                    End If
                Next
            End If
            'End If

            If Excepcion Then
                FiltraValor = "NOT (" & FiltraValor & ")"
            End If

            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " from personalvw WHERE " & FiltraValor)

            Return dtValores
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return New DataTable
        End Try
    End Function

    Private Sub cbCampos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCampos.SelectionChanged
        Dim x As Integer
        Dim Campo As String
        Try

            If cbCampos.SelectedIndex >= 0 Then
                Campo = cbCampos.SelectedValue.ToString.Trim
            Else : lstFiltro.Items.Clear()
                Exit Sub
            End If

            'pnlCaracter.Visible = cbCampos.SelectedNode.NodesColumns.Item("tipo")

            'Si el campo es de tipo caracter
            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " from personalvw WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL")
            lstFiltro.Items.Clear()
            lstFiltro.Items.Add(" ")
            For x = 0 To dtValores.Rows.Count - 1
                lstFiltro.Items.Add(dtValores.Rows.Item(x).Item(0))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub cbCampos_TextChanged(sender As Object, e As EventArgs) Handles cbCampos.TextChanged

    End Sub

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
        gpFiltro.Visible = True
        pnlEligeTAlloc.Visible = False
    End Sub

    Private Sub chkFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltros.CheckedChanged
        pnlCriterio.Enabled = chkFiltros.Checked
        If chkFiltros.Checked Then
            txtCriterio.Focus()
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        pnlCriterio.Enabled = chkFiltros.Checked
    End Sub

    Private Sub btnAgregarCriterio_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterio.Click
        Dim Campo As String
        Dim FiltraValor As String
        Try
            If cbCampos.SelectedValue Is Nothing Then
                Campo = ""
            Else
                Campo = cbCampos.SelectedValue.ToString.Trim
                Campo = "[" & Campo & "]"
            End If

            FiltraValor = ""

            For x = 0 To lstFiltro.CheckedItems.Count - 1
                FiltraValor = FiltraValor & IIf(FiltraValor.Length > 0, ",", "") & "'" & lstFiltro.CheckedItems(x) & "'"
            Next
            FiltraValor = Campo & IIf(cbComparacion.Text = "<>", " NOT ", "") & " IN (" & FiltraValor & ")"

            txtCriterio.Text = txtCriterio.Text.Trim & IIf(txtCriterio.TextLength > 0, " AND ", "") & FiltraValor

            pnlEligeTAlloc.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Dim dtResultado As New DataTable
        Dim Valido As Boolean

        dtResultado = sqlExecute("SELECT reloj from personalvw" & IIf(txtCriterio.Text.Length > 0, " WHERE ", "") & txtCriterio.Text)
        Valido = Not (dtResultado Is Nothing)
        If Valido Then
            MessageBox.Show("El criterio es válido. Se  " & IIf(dtResultado.Rows.Count = 1, " se obtuvo 1 registro que cumple", "obtuvieron " & dtResultado.Rows.Count & " registros que cumplen") & " con esta condición.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El criterio no es válido. Favor de verificar.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        pnlEligeTAlloc.Visible = True
        gpFiltro.Visible = False
    End Sub

    Private Sub btnFirmas_Click(sender As Object, e As EventArgs) Handles btnFirmas.Click
        UbicacionArchivo("Ubicación de firmas", txtDirFirma)
    End Sub
End Class