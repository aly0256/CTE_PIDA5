Public Class frmPerfiles
    Dim dtPerfiles As New DataTable
    Dim dtLista As New DataTable
    Dim dtClases As New DataTable
    Dim dtReportes As New DataTable
    Dim dtMaestro As New DataTable
    Dim dtCompanias As New DataTable
    Dim dtFormas As New DataTable
    Dim dtModulos As New DataTable
    Dim dtExcepciones As New DataTable

    Dim dtTemp As New DataTable

    'MCR 2017-10-10
    'Filtros para tipo de ausentismo por perfil
    Dim dtFiltroAusentismo As New DataTable

    Dim rbn As New DevComponents.DotNetBar.RibbonControl

    Dim Editar As Boolean
    Dim Nuevo As Boolean
    Dim ProcesoCancelado As Boolean = True

    Private Sub frmPerfiles_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            'If bgwRefresca.IsBusy Then
            '    bgwRefresca.CancelAsync()
            '    bgwRefresca.Dispose()
            'End If

            ProcesoCancelado = True
            pbAvance.IsRunning = False
            'For Each ct In Me.Controls
            '    ct.dispose()
            'Next
            rbn = Nothing
            My.Application.DoEvents()
            Me.Dispose()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub frmPerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemp As New DataTable
        Try
            gpAvance.Visible = True
            pbAvance.IsRunning = True
            rbn = frmMain.rbGeneral



            'MCR 10/NOV/2015
            'Permitir edición al presionar una tecla
            dgExcepciones.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.EditOnKeystroke

            'Asignar el estilo de pantallas de acuerdo a las preferencias seleccionadas por el usuario
            'MCR 21/OCT/2015
            'Regresar el estilo, ya que se pierde cuando se accesa al ribbon de frmMain
            dtTemp = sqlExecute("SELECT estilo,color FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")

            Dim scheme As DevComponents.DotNetBar.eStyle
            Dim sSel As String = dtTemp.Rows.Item(0).Item("estilo").ToString.Trim
            scheme = CType(System.Enum.Parse(GetType(DevComponents.DotNetBar.eStyle), sSel, False), DevComponents.DotNetBar.eStyle)
            mgrColorTint = Color.FromArgb(IIf(IsDBNull(dtTemp.Rows.Item(0).Item("color")), -1, dtTemp.Rows.Item(0).Item("color")))
            mgrStyle = scheme
            frmMain.stlEstiloVIsual.ManagerStyle = mgrStyle
            frmMain.stlEstiloVIsual.ManagerColorTint = mgrColorTint
            My.Application.DoEvents()


            'dgFormas.PrimaryGrid.Columns(2).EditControl.v
            lblAvance.Text = "CARGANDO PERFILES"
            Application.DoEvents()

            lblAvance.Text = "HABILITANDO PERFILES"
            Application.DoEvents()
            dtPerfiles = sqlExecute("SELECT TOP 1 * FROM perfiles ORDER BY cod_perfil", "Seguridad")

            'Estructura para la lista de los reportes
            dtReportes.Columns.Add("tag", GetType(System.String))
            dtReportes.Columns.Add("modulo", GetType(System.String))
            dtReportes.Columns.Add("reporte", GetType(System.String))
            dtReportes.Columns.Add("tipo", GetType(System.String))
            dtReportes.Columns.Add("acceso", GetType(System.Boolean))
            dgReportes.PrimaryGrid.DataSource = dtReportes
            dgReportes.PrimaryGrid.AutoGenerateColumns = False

            dgReportes.PrimaryGrid.Columns("tipo").FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.None

            'Estructura para la lista de maestro
            dtMaestro.Columns.Add("pantalla", GetType(System.String))
            dtMaestro.Columns.Add("control", GetType(System.String))
            dtMaestro.Columns.Add("acceso", GetType(System.Boolean))
            dgMaestro.DataSource = dtMaestro
            dgMaestro.AutoGenerateColumns = False

            'Estructura para la lista de compañías
            dtCompanias.Columns.Add("pantalla", GetType(System.String))
            dtCompanias.Columns.Add("control", GetType(System.String))
            dtCompanias.Columns.Add("acceso", GetType(System.Boolean))
            dgCias.DataSource = dtCompanias
            dgCias.AutoGenerateColumns = False


            'bgwRefresca.CancelAsync()
            ProcesoCancelado = True
            If ProcesoCancelado Then
                EmpNav.Enabled = False
                tabReportes.Enabled = False
                tabMaestro.Enabled = False
                tabFormas.Enabled = False
                tabCias.Enabled = False
                tabExcepciones.Enabled = False
                bgwRefresca.RunWorkerAsync()
            Else
                gpAvance.Visible = False
            End If

            'MCR 2017-10-10
            'Filtros para tipo de ausentismo por perfil
            dtFiltroAusentismo.Columns.Add("NOMBRE")
            dtFiltroAusentismo.Columns.Add("CAMPO")
            dtFiltroAusentismo.Rows.Add("TIPO DE AUSENTISMO", "TIPO_AUS")
            dtFiltroAusentismo.Rows.Add("TIPO DE NATURALEZA", "TIPO_NATURALEZA")
            dtFiltroAusentismo.Rows.Add("CON GOCE DE SUELDO", "GOCE_SDO")

            cbCampos.DataSource = dtFiltroAusentismo
            gpFiltro.Location = chkTodos.Location

            '**************

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub


    Private Sub HabilitarPerfiles()
        Dim NoRec As Boolean
        Try
            NoRec = dtPerfiles.Rows.Count = 0
            txtCodigo.Enabled = Nuevo
            txtNombre.Enabled = (Nuevo Or Editar)
            gpValores.Enabled = (Nuevo Or Editar)
            GroupPanel1.Enabled = (Nuevo Or Editar)
            chkTodosMaestro.Enabled = (Nuevo Or Editar)
            chkTodosCias.Enabled = (Nuevo Or Editar)
            dgMaestro.ReadOnly = Not (Nuevo Or Editar)
            dgCias.ReadOnly = Not (Nuevo Or Editar)
            chkTodosFormas.Enabled = (Nuevo Or Editar)

            'dgFormas.PrimaryGrid.ReadOnly = Not (Nuevo Or Editar)
            dgFormas.PrimaryGrid.Columns(2).AllowEdit = (Nuevo Or Editar)

            chkTodosHabilitado.Enabled = (Nuevo Or Editar)
            chkTodosVisible.Enabled = (Nuevo Or Editar)
            dgExcepciones.PrimaryGrid.AllowEdit = (Nuevo Or Editar)

            chkTodosReportes.Enabled = (Nuevo Or Editar)
            dgReportes.PrimaryGrid.ReadOnly = Not (Nuevo Or Editar)

            btnPrimero.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnAnterior.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnSiguiente.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnUltimo.Enabled = Not (Nuevo Or Editar Or NoRec)

            btnBuscar.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnBorrar.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnCerrar.Enabled = Not (Nuevo Or Editar Or NoRec)

            btnReporte.Enabled = Not (Nuevo Or Editar Or NoRec)
            btnEditar.Enabled = Not (Not (Editar Or Nuevo) And NoRec)


            If Nuevo Or Editar Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnEditar.Image = PIDA.My.Resources.CancelX
                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
                If Nuevo Then tabBuscar.SelectedTabIndex = 0
            Else

                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnEditar.Image = PIDA.My.Resources.Edit

                btnNuevo.Text = "Nuevo"
                btnEditar.Text = "Editar"
            End If

            txtCodigo.Enabled = Nuevo

            If Nuevo Then
                txtCodigo.Text = ""
                txtNombre.Text = ""
                sldConsulta.Value = 0
                sldEdicion.Value = 0
                sldSueldos.Value = 0
                ListarFORMAS("")
                ListarREPORTES("")
                ListarAccesosMAESTRO("")
                ListarAccesosCIAS("")
                ListarExcepciones("")

                txtCodigo.Focus()
            ElseIf Editar Then
                ' txtNombre.Focus()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Private Sub RefrescaInformacion()
        Try
            'gpAvance.Visible = True
            'pbAvance.IsRunning = True

            'lblAvance.Text = "PREPARANDO INFORMACIÓN"
            'Application.DoEvents()

            If dtPerfiles.Rows.Count > 0 Then
                txtCodigo.Text = dtPerfiles.Rows.Item(0).Item("cod_perfil")
                txtNombre.Text = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("nombre")), "NO IDENTIFICADO", dtPerfiles.Rows.Item(0).Item("nombre"))
                sldConsulta.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("nivel_consulta")), 0, dtPerfiles.Rows.Item(0).Item("nivel_consulta"))
                sldEdicion.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("nivel_edicion")), 0, dtPerfiles.Rows.Item(0).Item("nivel_edicion"))
                sldSueldos.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("nivel_sueldos")), 0, dtPerfiles.Rows.Item(0).Item("nivel_sueldos"))
                txtDias.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("dias_autorizacionTE")), 1, dtPerfiles.Rows.Item(0).Item("dias_autorizacionTE"))
                btnPeriodosInactivos.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("TAperiodos_inactivos")), 0, dtPerfiles.Rows.Item(0).Item("TAperiodos_inactivos")) = 1
                swcAsisPerfecta.Value = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("asist_perfecta")), 0, dtPerfiles.Rows.Item(0).Item("asist_perfecta")) = 1

                chkTodos.Checked = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("filtro_ausentismo")), "", dtPerfiles.Rows.Item(0).Item("filtro_ausentismo")).ToString.Trim.Length = 0
                chkFiltros.Checked = Not chkTodos.Checked
                txtCriterio.Text = IIf(IsDBNull(dtPerfiles.Rows.Item(0).Item("filtro_ausentismo")), "", dtPerfiles.Rows.Item(0).Item("filtro_ausentismo")).ToString.Trim
            End If

            dtClases = sqlExecute("SELECT clase.cod_comp,clase.cod_clase,clase.nombre," & _
                                  "ISNULL(clase.nivel_seguridad,0) AS 'Nivel'," & _
                                  "(CASE WHEN ISNULL(nivel_seguridad,0)<=" & sldSueldos.Value & " THEN 1 ELSE 0 END) AS Sueldos," & _
                                  "(CASE WHEN ISNULL(nivel_seguridad,0)<=" & sldConsulta.Value & " THEN 1 ELSE 0 END) AS Consulta," & _
                                  "(CASE WHEN ISNULL(nivel_seguridad,0)<=" & sldEdicion.Value & " THEN 1 ELSE 0 END) AS Edición  FROM CLASE ")
            dgClases.AutoGenerateColumns = False
            dgClases.DataSource = dtClases

            'Try
            '    dgClases.Columns.Remove("Sueldos")
            '    dgClases.Columns.Remove("Consulta")
            '    dgClases.Columns.Remove("Edición")
            'Catch ex As Exception
            '                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            'End Try
            'For x = 0 To dgClases.Columns.Count - 1
            '    dgClases.Columns(x).Width = 50
            'Next
            'dgClases.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            'Dim dgCol As New DataGridViewCheckBoxColumn
            'With dgCol
            '    .DataPropertyName = "Consulta"
            '    .Name = "Consulta"
            '    .HeaderText = "Consulta"
            'End With
            'dgClases.Columns.Add(dgCol)

            'dgCol = New DataGridViewCheckBoxColumn
            'With dgCol
            '    .DataPropertyName = "Edición"
            '    .Name = "Edición"
            '    .HeaderText = "Edición"
            'End With
            'dgClases.Columns.Add(dgCol)

            'dgCol = New DataGridViewCheckBoxColumn
            'With dgCol
            '    .DataPropertyName = "Sueldos"
            '    .Name = "Sueldos"
            '    .HeaderText = "Sueldos"
            'End With
            'dgClases.Columns.Add(dgCol)

            tabExcepciones.Enabled = True

            ListarAccesosMAESTRO(txtCodigo.Text)
            ListarAccesosCIAS(txtCodigo.Text)
            RevisarAccesosFORMAS(txtCodigo.Text)
            RevisarAccesosREPORTES(txtCodigo.Text)
            ListarExcepciones(txtCodigo.Text)


        Catch ex As Exception
            MessageBox.Show("Se detectaron errores al tratar de cargar la información. " & _
                            "Si el problema persiste, contactar al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Error: " & ex.Message, "PIDA - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosFormas.CheckedChanged
        Try
            Dim x As Integer = 0
            If chkTodosFormas.Checked Then
                chkTodosFormas.Text = "Desmarcar todos"

            Else
                chkTodosFormas.Text = "Marcar todos"
            End If
            Dim Filtro As String = ""
            Dim F As String = ""

            If Not dgFormas.PrimaryGrid.Columns(0).FilterExpr Is Nothing Then
                F = dgFormas.PrimaryGrid.Columns(0).FilterExpr
                F = F.Replace("[Módulo]", "modulo")
                If Not F.Contains("modulo") Then
                    F = "modulo " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = F

            End If

            If Not dgFormas.PrimaryGrid.Columns(1).FilterExpr Is Nothing Then
                F = dgFormas.PrimaryGrid.Columns(1).FilterExpr
                F = F.Replace("[Forma]", "forma")
                If Not F.Contains("forma") Then
                    F = "forma " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)
            End If


            If Not dgFormas.PrimaryGrid.Columns(2).FilterExpr Is Nothing Then

                F = dgFormas.PrimaryGrid.Columns(2).FilterExpr
                F = F.Replace("[Acceso]", "acceso")
                If Not F.Contains("acceso") Then
                    F = "acceso " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If

            For Each dForma As DataRow In dtFormas.Select(Filtro)
                dForma("acceso") = chkTodosFormas.Checked
            Next

            dgFormas.Refresh()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub ListarFORMAS(ActPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Dim si As Integer
        Dim t As Integer = 0
        Dim Tg As String
        Try
            dtModulos = New DataTable
            dtModulos.Columns.Add("modulo")

            'Estructura para la lista de formas
            dtFormas = New DataTable
            dtFormas.Columns.Add("modulo", GetType(System.String))
            dtFormas.Columns.Add("forma", GetType(System.String))
            dtFormas.Columns.Add("control", GetType(System.String))
            dtFormas.Columns.Add("acceso", GetType(System.Boolean))
            dgFormas.PrimaryGrid.AutoGenerateColumns = False


            For Each rp In rbn.Controls
                'Poner como tag en cada RibbonPanel, a qué módulo pertenece
                Tg = rp.tag
                dtModulos.Rows.Add({Tg})
                'Revisar cada control dentro del panel
                For Each c In rp.controls
                    i = 0
                    If TypeOf c Is DevComponents.DotNetBar.RibbonBar Then
                        ' Si es un ribbonbar, revisar cada elemento (botón)
                        For Each r In c.items
                            si = r.subitems.count
                            If si > 0 Then
                                'Si tiene subitems, revisar los accesos a cada uno
                                si = 0
                                For Each s In r.subitems
                                    dtFormas.Rows.Add(New String() {Tg, s.text, s.name, False})
                                    If Acceso Then si = si + 1
                                Next
                            Else
                                'Si no tiene subitems, igualar la variable a 1 para que revise acceso al botón
                                si = 1
                            End If

                            If si > 0 Then
                                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                                dtFormas.Rows.Add(New String() {Tg, r.text, r.name, True})
                            End If
                        Next
                    End If
                Next
            Next
            dgFormas.PrimaryGrid.DataSource = dtFormas

            'cmbModulos.DataSource = dtModulos
            ' cmbModulos.SelectedValue = ""
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Public Sub RevisarAccesosFORMAS(ActPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Dim si As Integer
        Dim t As Integer = 0
        Dim Tg As String
        Try

            For Each rp As DataRow In dtModulos.Rows
                'Poner como tag en cada RibbonPanel, a qué módulo pertenece
                Tg = IIf(IsDBNull(rp("modulo")), "", rp("modulo"))
                'Revisar cada control dentro del panel
                si = 0
                For Each c As DataRow In dtFormas.Select("modulo = '" & Tg & "'")
                    i = 0

                    dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'F' AND control = '" & c("control") & "' AND cod_perfil = '" & ActPerfil & "'", "Seguridad")

                    Acceso = False
                    If dtTemp.Rows.Count > 0 Then
                        Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                    End If

                    c("acceso") = Acceso
                    If Acceso Then si = si + 1
                Next
            Next

            dgFormas.PrimaryGrid.DataSource = dtFormas

            'cmbModulos.DataSource = dtModulos
            ' cmbModulos.SelectedValue = ""
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub ListarREPORTES(actPerfil As String)
        Dim dtTemp As New DataTable
        Dim x As Integer = 0
        Dim NM As String
        Dim DB As String
        Dim M As String

        Try
            Dim dtTablaReportes As New DataTable
            'dgReportes.Rows.Clear()
            dtReportes.Rows.Clear()
            For Each TabItem As Object In rbn.Items
                If TypeOf TabItem Is DevComponents.DotNetBar.RibbonTabItem Then
                    'Cada ribbon, debe tener el nombre de la base de datos que le corresponde en el tag
                    'Si la base de datos no tiene tabla de reportes, dejar el tag en blanco
                    DB = TabItem.tag
                    NM = TabItem.text

                    If DB <> "" Then
                        If DB.Length >= 3 Then
                            M = DB.Substring(0, 3)
                        Else
                            M = DB
                        End If
                        M = M.ToUpper

                        dtTablaReportes = sqlExecute("SELECT 1 as existe FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = '" & DB & "' OR name = '" & DB & "')")
                        If dtTablaReportes.Rows.Count = 0 Then
                            Continue For
                        End If

                        dtTablaReportes = sqlExecute("SELECT 1 as existe FROM INFORMATION_SCHEMA.TABLES WHERE " & _
                                                     "TABLE_TYPE='BASE TABLE' AND TABLE_NAME='reportes'", DB)
                        If dtTablaReportes.Rows.Count = 0 Then
                            Continue For
                        End If

                        'MCR 5/NOV/2015
                        'Confirmar que exista tabla tipo_reportes
                        dtTablaReportes = sqlExecute("SELECT 1 as existe FROM INFORMATION_SCHEMA.TABLES WHERE " & _
                                                     "TABLE_TYPE='BASE TABLE' AND TABLE_NAME='tipo_reportes'", DB)
                        If dtTablaReportes.Rows.Count = 0 Then
                            Continue For
                        End If

                        'MCR 5/NOV/2015
                        'Agregar columna de descripción de tipo en el GRID
                        'para mayor claridad al usuario
                        dtTablaReportes = sqlExecute("SELECT reportes.nombre,tipo_reportes.nombre as tipo " & _
                                                     "FROM reportes LEFT JOIN tipo_reportes ON reportes.tipo = tipo_reportes.tipo", DB)

                        For Each drReporte As DataRow In dtTablaReportes.Rows
                            dtReportes.Rows.Add(New String() {NM, M, drReporte("nombre").ToString.Trim, drReporte("tipo").ToString.Trim, False})
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub ListarExcepciones(actPerfil As String)
        'MCR 19/OCT/2015
        'Estructura para la lista de las excepciones
        Try
            dtExcepciones = sqlExecute("SELECT * FROM excepciones WHERE cod_perfil = '" & actPerfil & "'", "SEGURIDAD")
            dgExcepciones.PrimaryGrid.DataSource = dtExcepciones
            dgExcepciones.PrimaryGrid.AutoGenerateColumns = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub RevisarAccesosREPORTES(actPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean

        Try
            For Each drReporte As DataRow In dtReportes.Rows
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE control = '" & drReporte("reporte").ToString.Trim & _
                                    "' AND cod_perfil = '" & actPerfil & "' AND modulo = '" & drReporte("modulo").ToString.Trim & "'", "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                drReporte("acceso") = Acceso
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Public Sub ListarAccesosMAESTRO(actPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Try
            'Revisar cada control dentro del panel
            If actPerfil.Length = 0 Then Exit Sub
            i = 0
            dtMaestro.Rows.Clear()
            For Each c In frmMaestro.tbInfo.Tabs
                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = '" & c.name & "' AND cod_perfil = '" & actPerfil & "'", "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                dtMaestro.Rows.Add(New String() {c.text, c.name, Acceso})
            Next

            dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = 'btnBorrar' AND cod_perfil = '" & actPerfil & "'", "Seguridad")
            Acceso = False
            If dtTemp.Rows.Count > 0 Then
                Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
            End If
            dtMaestro.Rows.Add(New String() {"Borrar empleados", "btnBorrar", Acceso})
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub ListarAccesosCIAS(actPerfil As String)
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Try
            If actPerfil.Length = 0 Then Exit Sub
            'Revisar cada control dentro del panel
            i = 0
            dtCompanias.Rows.Clear()
            For Each c In frmParametros.tbInfo.Tabs
                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = '" & c.name & "' AND cod_perfil = '" & actPerfil & "'", "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                dtCompanias.Rows.Add(New String() {c.text, c.name, Acceso})
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosReportes.CheckedChanged
        Try
            Dim x As Integer = 0
            If chkTodosReportes.Checked Then
                chkTodosReportes.Text = "Desmarcar todos"

            Else
                chkTodosReportes.Text = "Marcar todos"
            End If

            Dim Filtro As String = ""
            Dim F As String = ""

            If Not dgReportes.PrimaryGrid.Columns(0).FilterExpr Is Nothing Then
                F = dgReportes.PrimaryGrid.Columns(0).FilterExpr
                F = F.Replace("[Módulo]", "tag")
                If Not F.Contains("tag") Then
                    F = "tag " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = F

            End If

            If Not dgReportes.PrimaryGrid.Columns(1).FilterExpr Is Nothing Then
                F = dgReportes.PrimaryGrid.Columns(1).FilterExpr
                F = F.Replace("[Reporte]", "reporte")
                If Not F.Contains("reporte") Then
                    F = "reporte " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)
            End If


            If Not dgReportes.PrimaryGrid.Columns(2).FilterExpr Is Nothing Then

                F = dgReportes.PrimaryGrid.Columns(2).FilterExpr
                F = F.Replace("[Acceso]", "acceso")
                If Not F.Contains("acceso") Then
                    F = "acceso " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If

            'MCR 5/NOV/2015
            'Columna tipo 
            If Not dgReportes.PrimaryGrid.Columns(3).FilterExpr Is Nothing Then

                F = dgReportes.PrimaryGrid.Columns(3).FilterExpr
                F = F.Replace("[Tipo]", "tipo")
                If Not F.Contains("tipo") Then
                    F = "tipo " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If
            Filtro = Filtro.Replace(Chr(34), "'")
            For Each dReporte As DataRow In dtReportes.Select(Filtro)
                dReporte("acceso") = chkTodosReportes.Checked
            Next

            dgFormas.Refresh()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosMaestro.CheckedChanged
        Try
            Dim x As Integer = 0
            If chkTodosMaestro.Checked Then
                chkTodosMaestro.Text = "Desmarcar todos"

            Else
                chkTodosMaestro.Text = "Marcar todos"
            End If

            For x = 0 To dgMaestro.Rows.Count - 1
                dgMaestro.Item("MaestroAcceso", x).Value = chkTodosMaestro.Checked
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("perfiles", "cod_perfil", dtPerfiles, "Seguridad")
        RefrescaInformacion()

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("perfiles", "cod_perfil", txtCodigo.Text, dtPerfiles, "Seguridad")
        RefrescaInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("perfiles", "cod_perfil", txtCodigo.Text, dtPerfiles, "Seguridad")
        RefrescaInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("perfiles", "cod_perfil", dtPerfiles, "Seguridad")
        RefrescaInformacion()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If Nuevo Then
                ' Si Agregar, revisar si existe cod_comp+cod_linea
                dtTemporal = sqlExecute("SELECT cod_perfil FROM perfiles where cod_perfil = '" & txtCodigo.Text & "'", "SEGURIDAD")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, debido a que ya existe el perfil '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else
                    sqlExecute("INSERT INTO perfiles (cod_perfil,nombre,nivel_consulta,nivel_edicion,nivel_sueldos,dias_autorizacionTE,filtro_ausentismo,TAperiodos_inactivos,asist_perfecta) VALUES ('" & _
                               txtCodigo.Text & "','" & _
                               txtNombre.Text & "'," & _
                               sldConsulta.Value & "," & _
                               sldEdicion.Value & "," & _
                               sldSueldos.Value & "," & _
                               txtDias.Value & ",'" & _
                               txtCriterio.Text.Replace("'", "''") & "'," & _
                               IIf(btnPeriodosInactivos.Value, 1, 0) & ", " & _
                               IIf(swcAsisPerfecta.Value, 1, 0) & ")", "Seguridad")
                    Nuevo = False

                    EditarPermisos(txtCodigo.Text)

                    GuardarExcepciones()
                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                sqlExecute("UPDATE perfiles SET nombre = '" & txtNombre.Text & _
                           "', nivel_consulta = " & sldConsulta.Value & _
                           ", nivel_edicion = " & sldEdicion.Value & _
                           ",nivel_sueldos=" & sldSueldos.Value & _
                           ",dias_autorizacionTE=" & txtDias.Value & _
                           ",TAperiodos_inactivos=" & IIf(btnPeriodosInactivos.Value, 1, 0) & _
                           ",asist_perfecta=" & IIf(swcAsisPerfecta.Value, 1, 0) & _
                           ",filtro_ausentismo = '" & IIf(chkTodos.Checked, "", txtCriterio.Text.Replace("'", "''")) & "'" & _
                           " WHERE cod_perfil = '" & txtCodigo.Text & "'", "Seguridad")
                EditarPermisos(txtCodigo.Text)



                If Perfil = txtCodigo.Text.Trim Then
                    PermitirAccesosXperfil()
                End If

                GuardarExcepciones()
                dtPerfiles = sqlExecute("SELECT * FROM perfiles WHERE cod_perfil = '" & txtCodigo.Text & "'", "Seguridad")
                RefrescaInformacion()
            Else
                Nuevo = True
            End If
            Editar = False

            HabilitarPerfiles()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub GuardarExcepciones()
        'MCR 21/OCT/2015
        'Guardar cambios a excepciones
        Try
            sqlExecute("DELETE FROM excepciones WHERE cod_perfil = '" & txtCodigo.Text & "'", "seguridad")
            For Each dExc As DevComponents.DotNetBar.SuperGrid.GridRow In dgExcepciones.PrimaryGrid.Rows
                'MCR 10/NOV/2015
                '...excepto los registros borrados...
                If Not dExc.IsDeleted Then
                    If Not IsDBNull(dExc.Cells("Forma").Value) And Not IsNothing(dExc.Cells("Forma").Value) And _
                        Not IsDBNull(dExc.Cells("Control").Value) And Not IsNothing(dExc.Cells("Control").Value) Then
                        sqlExecute("INSERT INTO excepciones (cod_perfil,nombre_forma,nombre_control,visible,habilitado) VALUES (" & _
                                   "'" & txtCodigo.Text.Trim & "'," & _
                                   "'" & dExc.Cells("Forma").Value.ToString.Trim & "'," & _
                                   "'" & dExc.Cells("Control").Value.ToString.Trim & "'," & _
                                    IIf(IsDBNull(dExc.Cells("Visible").Value), 0, IIf(dExc.Cells("Visible").Value, 1, 0)) & "," & _
                                    IIf(IsDBNull(dExc.Cells("Habilitado").Value), 0, IIf(dExc.Cells("Habilitado").Value, 1, 0)) & ")", "SEGURIDAD")
                    End If
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub EditarPermisos(actPerfil As String)
        Dim x As Integer
        Dim nmControl As String
        Dim Acceso As Boolean
        Dim tipo As String
        Dim modulo As String = ""
        Dim Nombre As String = ""
        Try
            'Información de archivo maestro
            For x = 0 To dgMaestro.Rows.Count - 1
                nmControl = dgMaestro.Item("ControlMaestro", x).Value
                Acceso = dgMaestro.Item("MaestroAcceso", x).Value
                Nombre = dgMaestro.Item("MaestroPantalla", x).Value
                tipo = "T"

                AfectaDatos(Acceso, actPerfil, nmControl, Nombre, tipo)
            Next

            'Información de archivo cias
            For x = 0 To dgCias.Rows.Count - 1
                nmControl = dgCias.Item("ciasControl", x).Value
                Acceso = dgCias.Item("ciasAcceso", x).Value
                Nombre = dgCias.Item("ciasPantalla", x).Value
                tipo = "T"

                AfectaDatos(Acceso, actPerfil, nmControl, Nombre, tipo)
            Next

            For Each dReg As DataRow In dtFormas.Rows
                nmControl = dReg("control")
                Acceso = dReg("acceso")
                Nombre = dReg("forma")
                tipo = "F"
                AfectaDatos(Acceso, actPerfil, nmControl, Nombre, tipo)
            Next

            For Each dReg As DataRow In dtReportes.Rows
                nmControl = dReg("reporte")
                Acceso = dReg("acceso")
                tipo = "R"
                modulo = dReg("modulo")
                AfectaDatos(Acceso, actPerfil, nmControl, nmControl, tipo, modulo)
            Next


            ''Información de formas
            'For x = 0 To dgFormas.Rows.Count - 1
            '    nmControl = dgFormas.Item("control", x).Value
            '    Acceso = dgFormas.PrimaryGrid.Rows.Item("FormaAcceso", x).Value
            '    tipo = "F"

            '    AfectaDatos(Acceso, actPerfil, nmControl, tipo)
            'Next

            ''Información de reportes
            'For x = 0 TodgReportes.PrimaryGrid.Rows.Count - 1
            '    nmControl = dgReportes.PrimaryGrid.Item("ReporteNombre", x).Value
            '    Acceso = dgReportes.PrimaryGrid.Item("ReporteAcceso", x).Value
            '    modulo = dgReportes.PrimaryGrid.Item("ReporteModTabla", x).Value
            '    tipo = "R"
            '    AfectaDatos(Acceso, actPerfil, nmControl, tipo, modulo)
            'Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub AfectaDatos(ByVal Acceso As Boolean, ByVal actPerfil As String, ByVal nmControl As String, ByVal Nombre As String, _
                            ByVal tipo As String, Optional modulo As String = "")
        Try
            If Acceso Then
                dtTemporal = sqlExecute("SELECT acceso FROM permisos WHERE cod_perfil = '" & actPerfil & "' AND control = '" & nmControl & _
                                        "'", "Seguridad")
                If dtTemporal.Rows.Count = 0 Then
                    'No se encuentra el registro
                    sqlExecute("INSERT INTO permisos (cod_perfil,control,tipo,acceso,modulo,nombre) VALUES ('" & _
                               actPerfil & "','" & _
                               nmControl & "','" & _
                               tipo & "',1,'" & _
                               modulo & "','" & Nombre & "')", "Seguridad")
                Else
                    sqlExecute("UPDATE permisos SET acceso=1 WHERE cod_perfil = '" & actPerfil & _
                               "' AND control = '" & nmControl & "'", "Seguridad")
                End If
            Else
                'Si no se tiene acceso, borrar el registro en permisos -en caso de que existiera -
                sqlExecute("DELETE FROM permisos WHERE cod_perfil = '" & actPerfil & "' AND control = '" & nmControl & "'", "Seguridad")
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Nuevo Then
            Editar = True
            Nuevo = False
            HabilitarPerfiles()
            txtNombre.Focus()
        Else
            Editar = False
            Nuevo = False
            HabilitarPerfiles()
            RefrescaInformacion()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim codigo As String
            codigo = txtCodigo.Text
            dtTemporal = sqlExecute("SELECT cod_perfil FROM appuser WHERE cod_perfil = '" & codigo & "'", "Seguridad")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    sqlExecute("DELETE FROM perfiles WHERE cod_perfil = '" & codigo & "'", "Seguridad")
                    sqlExecute("DELETE FROM permisos WHERE cod_perfil = '" & codigo & "'", "Seguridad")
                    btnSiguiente.PerformClick()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosCias_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosCias.CheckedChanged
        Try
            Dim x As Integer = 0
            If chkTodosCias.Checked Then
                chkTodosCias.Text = "Desmarcar todos"
            Else
                chkTodosCias.Text = "Marcar todos"
            End If

            For x = 0 To dgCias.Rows.Count - 1
                dgCias.Item("CiasAcceso", x).Value = chkTodosCias.Checked
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim dtClases As New DataTable
            Dim dtUsuarios As New DataTable
            Dim dtMax As New DataTable
            Dim dtMin As New DataTable
            Dim dPerfil As DataRow
            Dim dRow As DataRow
            Dim nombre As String

            Dim i As Integer
            Dim n As Integer
            Dim mx As Integer
            Dim mn As Integer
            dtUsuarios = sqlExecute("SELECT perfiles.cod_perfil,ISNULL(nivel_consulta,0)nivel_consulta,ISNULL(nivel_sueldos,0) AS nivel_sueldos," & _
                                    "ISNULL(nivel_edicion,0) AS nivel_edicion " & _
                                    "FROM seguridad.dbo.perfiles WHERE cod_perfil = '" & txtCodigo.Text.Trim & "'", "seguridad")
            For i = 0 To 9
                dtUsuarios.Columns.Add("consulta" & i, GetType(System.Int16))
                dtUsuarios.Columns.Add("edicion" & i, GetType(System.Int16))
                dtUsuarios.Columns.Add("sueldos" & i, GetType(System.Int16))
                dtUsuarios.Columns.Add("nivel" & i, GetType(System.String))
            Next
            dtUsuarios.Columns.Add("modulo")
            dtUsuarios.Columns.Add("tipo")
            dtUsuarios.Columns.Add("control")
            dtUsuarios.Columns.Add("acceso", GetType(System.Int16))

            dRow = dtUsuarios.Rows(0)

            dtMax = sqlExecute("SELECT MAX(nivel_seguridad) FROM clase")
            mx = IIf(IsDBNull(dtMax.Rows(0).Item(0)), 0, dtMax.Rows(0).Item(0))
            dtMin = sqlExecute("select min(nivel_seguridad) from clase")
            mn = IIf(IsDBNull(dtMin.Rows(0).Item(0)), 0, dtMin.Rows(0).Item(0))
            dtClases = sqlExecute("SELECT nombre,ISNULL(nivel_seguridad,0) AS nivel_seguridad FROM clase ORDER BY nivel_seguridad")
            For Each dR As DataRow In dtClases.Rows
                nombre = Trim(dR("nombre"))
                If nombre = "Directos" Then
                    dR("nivel_seguridad") = "0"
                End If
                dRow("nivel" & dR("nivel_seguridad")) = dR("nombre").ToString.Trim
            Next

            n = IIf(IsDBNull(dRow("nivel_consulta")), -1, dRow("nivel_consulta"))
            For i = 0 To mx
                nombre = dRow("nivel" & i)
                dRow("consulta" & i) = IIf((nombre = "Directos"), IIf(1 <= n, 1, 0), IIf(i <= n, 1, 0))
            Next
            n = IIf(IsDBNull(dRow("nivel_edicion")), -1, dRow("nivel_edicion"))
            For i = 0 To mx
                nombre = dRow("nivel" & i)
                dRow("edicion" & i) = IIf((nombre = "Directos"), IIf(1 <= n, 1, 0), IIf(i <= n, 1, 0))
            Next
            n = IIf(IsDBNull(dRow("nivel_sueldos")), -1, dRow("nivel_sueldos"))
            For i = 0 To mx
                nombre = dRow("nivel" & i)
                dRow("sueldos" & i) = IIf((nombre = "Directos"), IIf(1 <= n, 1, 0), IIf(i <= n, 1, 0))
            Next

            dPerfil = dRow
            For Each dControl As System.Windows.Forms.DataGridViewRow In dgMaestro.Rows
                dPerfil("modulo") = "RECURSOS HUMANOS"
                dPerfil("tipo") = "Consulta maestro"
                dPerfil("control") = dControl.Cells(0).Value.ToString.Trim
                'dPerfil("acceso") = IIf(dControl.Cells(2).Value, 1, 0)********************************CARLOS****************************************
                'dtUsuarios.ImportRow(dPerfil)
                If dControl.Cells(2).Value Then
                    dPerfil("acceso") = 1
                    dtUsuarios.ImportRow(dPerfil)
                End If
            Next

            For Each dControl As System.Windows.Forms.DataGridViewRow In dgCias.Rows
                dPerfil("modulo") = "GENERAL"
                dPerfil("tipo") = "Consulta parámetros"
                dPerfil("control") = dControl.Cells(0).Value.ToString.Trim
                'dPerfil("acceso") = IIf(dControl.Cells(2).Value, 1, 0)********************************CARLOS****************************************
                'dtUsuarios.ImportRow(dPerfil)
                If dControl.Cells(2).Value Then
                    dPerfil("acceso") = 1
                    dtUsuarios.ImportRow(dPerfil)
                End If
            Next

            For Each dControl As DataRow In dtFormas.Rows
                dPerfil("modulo") = dControl("modulo")
                dPerfil("tipo") = "Formas"
                dPerfil("control") = dControl("forma")
                'dPerfil("acceso") = IIf(dControl("acceso"), 1, 0)********************************CARLOS****************************************
                'dtUsuarios.ImportRow(dPerfil)
                If dControl("acceso") Then
                    dPerfil("acceso") = 1
                    dtUsuarios.ImportRow(dPerfil)
                End If
            Next

            For Each dControl As DataRow In dtReportes.Rows
                dPerfil("modulo") = dControl("tag")
                dPerfil("tipo") = "Reportes"
                dPerfil("control") = dControl("reporte")
                'dPerfil("acceso") = IIf(dControl("acceso"), 1, 0)********************************CARLOS****************************************
                'dtUsuarios.ImportRow(dPerfil)
                If dControl("acceso") Then
                    dPerfil("acceso") = 1
                    dtUsuarios.ImportRow(dPerfil)
                End If

            Next


            'For Each dControl As System.Windows.Forms.DataGridViewRow In dgReportes.PrimaryGrid.Rows
            '    dPerfil("modulo") = dControl.Cells(0).Value.ToString.Trim
            '    dPerfil("tipo") = "Reportes"
            '    dPerfil("control") = dControl.Cells(1).Value.ToString.Trim
            '    dPerfil("acceso") = IIf(dControl.Cells(5).Value, 1, 0)
            '    dtUsuarios.ImportRow(dPerfil)
            'Next

            frmVistaPrevia.LlamarReporte("Perfiles", dtUsuarios, "")
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgwRefresca_Disposed(sender As Object, e As EventArgs) Handles bgwRefresca.Disposed
        ProcesoCancelado = True
    End Sub

    Private Sub bgwRefresca_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwRefresca.DoWork
        Try
            ProcesoCancelado = False


            bgwRefresca.ReportProgress(0, "MAESTRO")
            ListarAccesosMAESTRO(txtCodigo.Text)
            dgMaestro.DataSource = dtMaestro
            tabMaestro.Enabled = True

            bgwRefresca.ReportProgress(0, "OPCIONES")
            ListarAccesosCIAS(txtCodigo.Text)
            dgCias.DataSource = dtCompanias
            tabCias.Enabled = True

            bgwRefresca.ReportProgress(0, "FORMAS")
            ListarFORMAS(txtCodigo.Text)
            dgFormas.PrimaryGrid.DataSource = dtFormas
            tabFormas.Enabled = True

            bgwRefresca.ReportProgress(0, "REPORTES")
            ListarREPORTES(txtCodigo.Text)
            dgReportes.PrimaryGrid.DataSource = dtReportes
            tabReportes.Enabled = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bgwRefresca_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwRefresca.ProgressChanged
        lblAvance.Text = "___ ACCESOS ___" & vbCrLf & CType(e.UserState, String)
    End Sub

    Private Sub bgwReporteso_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwRefresca.RunWorkerCompleted
        Try
            RefrescaInformacion()
            HabilitarPerfiles()

            gpAvance.Visible = False
            pbAvance.IsRunning = False
            EmpNav.Enabled = True
            ProcesoCancelado = True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim Cod As String
            Cod = Buscar("seguridad.dbo.perfiles", "cod_perfil", "PERFILES", False)
            If Cod <> "CANCELAR" Then
                dtPerfiles = sqlExecute("SELECT * FROM perfiles WHERE COD_PERFIL = '" & Cod & "' ", "SEGURIDAD")
                RefrescaInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs)
    '    Dim BuscaFormas As String
    '    If cmbModulos.SelectedValue Is Nothing Then Exit Sub

    '    Dim dSel() As DataRow
    '    Dim dtSelecciona As DataTable = dtFormas.Clone

    '    BuscaFormas = EliminaAcentos(txtBusca.Text.Trim)
    '    dSel = dtFormas.Select("forma LIKE '%" & BuscaFormas & "%' " & _
    '                                          IIf(cmbModulos.SelectedValue.ToString.Length > 0, " AND modulo = '" & cmbModulos.SelectedValue.ToString.Trim & "'", ""))
    '    For Each dS As DataRow In dSel
    '        dtSelecciona.ImportRow(dS)
    '    Next
    '    dgFormas.DataSource = dtSelecciona
    '    dgFormas.Refresh()
    'End Sub

    'Private Sub cmbModulos_SelectedValueChanged(sender As Object, e As EventArgs)
    '    Dim BuscaFormas As String
    '    If cmbModulos.SelectedValue Is Nothing Then Exit Sub

    '    Dim dSel() As DataRow
    '    Dim dtSelecciona As DataTable = dtFormas.Clone

    '    BuscaFormas = EliminaAcentos(txtBusca.Text.Trim)
    '    dSel = dtFormas.Select("forma LIKE '%" & BuscaFormas & "%' " & _
    '                                          IIf(cmbModulos.SelectedValue.ToString.Length > 0, " AND modulo = '" & cmbModulos.SelectedValue.ToString.Trim & "'", ""))
    '    For Each dS As DataRow In dSel
    '        dtSelecciona.ImportRow(dS)
    '    Next
    '    dgFormas.DataSource = dtSelecciona
    '    dgFormas.Refresh()

    'End Sub

    Private Sub chkTodosHabilitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosHabilitado.CheckedChanged
        Try
            Dim Filtro As String = FiltroExcepciones()

            For Each dRow As DataRow In dtExcepciones.Select(Filtro)
                dRow("habilitado") = chkTodosHabilitado.Checked
            Next

            dgExcepciones.Refresh()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosVisible_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosVisible.CheckedChanged
        Try
            Dim Filtro As String = FiltroExcepciones()
           
            For Each dRow As DataRow In dtExcepciones.Select(Filtro)
                dRow("visible") = chkTodosVisible.Checked
            Next

            dgExcepciones.Refresh()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function FiltroExcepciones() As String
        Try
            Dim x As Integer = 0

            Dim Filtro As String = ""
            Dim F As String = ""

            If Not dgExcepciones.PrimaryGrid.Columns(0).FilterExpr Is Nothing Then
                F = dgExcepciones.PrimaryGrid.Columns(0).FilterExpr
                F = F.Replace("[Forma]", "nombre_forma")
                If Not F.Contains("nombre_forma") Then
                    F = "nombre_forma " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = F

            End If

            If Not dgExcepciones.PrimaryGrid.Columns(1).FilterExpr Is Nothing Then
                F = dgExcepciones.PrimaryGrid.Columns(1).FilterExpr
                F = F.Replace("[Control]", "nombre_control")
                If Not F.Contains("nombre_control") Then
                    F = "nombre_control " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                F = F.Replace(Chr(34), "'")
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If

            If Not dgExcepciones.PrimaryGrid.Columns(2).FilterExpr Is Nothing Then
                F = dgExcepciones.PrimaryGrid.Columns(2).FilterExpr
                F = F.Replace("[Visible]", "Visible")
                If Not F.Contains("Visible") Then
                    F = "Visible " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)

            End If

            If Not dgExcepciones.PrimaryGrid.Columns(3).FilterExpr Is Nothing Then
                F = dgExcepciones.PrimaryGrid.Columns(3).FilterExpr
                F = F.Replace("[Habilitado]", "Habilitado")
                If Not F.Contains("Habilitado") Then
                    F = "Habilitado " & F
                End If
                F = F.Replace("!= null", "NOT IS NULL")
                If F.ToLower.Contains("like") Then
                    F = F.ToLower.Replace("like '", "like '%")
                    F = F.Substring(0, F.Length - 1) & "%'"
                End If
                Filtro = Filtro & IIf(Filtro.Length = 0, F, " AND " & F)
            End If
            Return Filtro
        Catch ex As Exception
            Return ""
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Function

    Private Sub chkFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltros.CheckedChanged
        pnlCriterio.Visible = chkFiltros.Checked
    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Try
            Dim dtResultado As New DataTable
            Dim Valido As Boolean

            dtResultado = sqlExecute("SELECT tipo_aus FROM ta.dbo.tipo_ausentismo" & IIf(txtCriterio.Text.Length > 0, " WHERE ", "") & txtCriterio.Text)
            Valido = Not (dtResultado Is Nothing)
            If Valido Then
                MessageBox.Show("El criterio es válido. Se " & IIf(dtResultado.Rows.Count = 1, "obtuvo 1 registro que cumple", "obtuvieron " & dtResultado.Rows.Count & " registros que cumplen") & " con esta condición.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El criterio no es válido. Favor de verificar.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCampos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCampos.SelectionChanged
        Dim x As Integer
        Dim Campo As String = ""
        Dim dtValores As New DataTable

        Try

            If cbCampos.SelectedIndex >= 0 Then
                For Each dr As DataRow In dtFiltroAusentismo.Rows
                    If dr("nombre") = cbCampos.SelectedValue.ToString.Trim Then
                        Campo = dr("campo")
                        Exit For
                    End If
                Next
                If Campo = "" Then
                    lstFiltro.Items.Clear()
                    Exit Sub
                End If
            Else : lstFiltro.Items.Clear()
                Exit Sub
            End If

            'pnlCaracter.Visible = cbCampos.SelectedNode.NodesColumns.Item("tipo")

            'Si el campo es de tipo caracter
            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " AS campo FROM ta.dbo.tipo_ausentismo  WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL")
            lstFiltro.Items.Clear()
            lstFiltro.Items.Add(" ")
            For x = 0 To dtValores.Rows.Count - 1
                lstFiltro.Items.Add(dtValores.Rows.Item(x).Item(0))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        Try
            Dim Resultado As New DataTable
            Dim R As String
            Dim c As Integer = 0
            Resultado = FiltrarDatos(txtFiltro.Text.Trim, False, cbCampos.SelectedValue)
            If Resultado Is Nothing Then Exit Sub
            lstFiltro.Items.Clear()
            For x = 0 To Resultado.Rows.Count - 1
                R = Resultado.Rows.Item(x).Item(0)
                If lstFiltro.FindString(R) < 0 Then
                    lstFiltro.Items.Add(Resultado.Rows.Item(x).Item(0))
                    lstFiltro.SetItemCheckState(c, True)
                    c = c + 1
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarCriterio_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterio.Click
        Try
            Dim Campo As String = ""
            Dim FiltraValor As String

            If cbCampos.SelectedIndex >= 0 Then
                For Each dr As DataRow In dtFiltroAusentismo.Rows
                    If dr("nombre") = cbCampos.SelectedValue.ToString.Trim Then
                        Campo = dr("campo")
                        Exit For
                    End If
                Next
            Else
                Campo = ""
            End If

            FiltraValor = ""


            For Each itm As DevComponents.DotNetBar.ListBoxItem In lstFiltro.CheckedItems
                FiltraValor = FiltraValor & IIf(FiltraValor.Length > 0, ",", "") & "'" & itm.Text & "'"
            Next
            FiltraValor = Campo & IIf(cbComparacion.Text = "<>", " NOT ", "") & " IN (" & FiltraValor & ")"

            txtCriterio.Text = txtCriterio.Text.Trim & IIf(txtCriterio.TextLength > 0, " AND ", "") & FiltraValor

            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelarCriterio_Click(sender As Object, e As EventArgs) Handles btnCancelarCriterio.Click
        Try
            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function FiltrarDatos(Texto As String, Excepcion As Boolean, CampoBusqueda As String) As DataTable
        Dim x As Integer
        Dim Campo As String = ""
        Dim Valores() As String
        Valores = Split(Texto, ",")
        Dim FiltraValor As String = ""
        Dim dtValores As New DataTable

        Try

            If CampoBusqueda.Length >= 0 Then
                For Each dr As DataRow In dtFiltroAusentismo.Rows
                    If dr("nombre") = cbCampos.SelectedValue.ToString.Trim Then
                        Campo = dr("campo")
                        Exit For
                    End If
                Next
                If Campo = "" Then
                    lstFiltro.Items.Clear()
                End If
            Else
                lstFiltro.Items.Clear()
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

            If Excepcion Then
                FiltraValor = "NOT (" & FiltraValor & ")"
            End If

            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " AS campo FROM ta.dbo.tipo_ausentismo  WHERE " & FiltraValor)

            Return dtValores
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
            Return New DataTable
        End Try

    End Function

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
        Try
            gpFiltro.Visible = True
            pnlCriterio.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class