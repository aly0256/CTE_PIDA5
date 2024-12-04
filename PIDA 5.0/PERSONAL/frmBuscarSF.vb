Public Class frmBuscarSF
    Dim dtBuscar As New DataTable
    Dim idxBusca As Integer
    Dim DesdeGrid As Boolean
    Dim CamposBusca As String

    Dim BS As New BindingSource

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If txtReloj.Text <> "" Then
                RelojSF = txtReloj.Text.Trim
            End If
        Catch ex As Exception
            RelojSF = "CANCEL"
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        RelojSF = "CANCEL"
        Me.Close()
    End Sub

    Private Sub frmBuscar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Campos() As String
        Dim Extra As String = ""
        Dim dtParametros As New DataTable

        Try

            RelojSF = "CANCEL"
            dtParametros = sqlExecute("SELECT campos_busqueda FROM parametros")
            If dtParametros.Rows.Count = 0 Then
                CamposBusca = ""
            Else
                CamposBusca = IIf(IsDBNull(dtParametros.Rows(0).Item(0).ToString.Trim), "", dtParametros.Rows(0).Item(0).ToString.Trim)
            End If

            For Each Campo In CamposBusca.Split(",")
                If Campo.Length > 0 Then
                    Campo = Campo.Substring(0, 1).ToUpper & Campo.Substring(1).ToLower
                    Campo = Campo.Replace("Cod_", "Cód. ")
                    Campo = Campo.Replace("_", " ")
                    Extra = Extra & IIf(Extra.Length > 0, vbCrLf, "") & Campo
                End If
            Next
            lblExtras.Text = Extra
            pnlExtras.Visible = Extra.Length > 0

            dtBuscar = ConsultaPersonalVW("SELECT sf_id,NOMBRES AS NOMBRE,ALTA,BAJA,RTRIM(COD_DEPTO) + ' - ' + RTRIM(NOMBRE_DEPTO) AS DEPARTAMENTO," & _
                                  "RTRIM(COD_PUESTO) + ' - ' + RTRIM(NOMBRE_PUESTO) AS PUESTO,PERSONALVW.COD_COMP,FOTO,'' AS CAMPOS_EXTRA" & _
                                  IIf(CamposBusca.Length > 0, "," & CamposBusca, "") & " FROM PERSONALVW " & _
                                  "WHERE (nivel_seguridad IS NULL OR nivel_seguridad <=" & NivelConsulta & ") and baja is null and cod_comp = '610'", False)
            'dtBuscar = ConsultaPersonalVW("SELECT RELOJ,NOMBRES AS NOMBRE,ALTA,BAJA,RTRIM(COD_DEPTO) + ' - ' + RTRIM(NOMBRE_DEPTO) AS DEPARTAMENTO," & _
            '                      "RTRIM(COD_PUESTO) + ' - ' + RTRIM(NOMBRE_PUESTO) AS PUESTO,PERSONALVW.COD_COMP,FOTO,'' AS CAMPOS_EXTRA" & _
            '                      IIf(CamposBusca.Length > 0, "," & CamposBusca, "") & ",IMSS,RFC FROM PERSONALVW " & _
            '                      "WHERE (nivel_seguridad IS NULL OR nivel_seguridad <=" & NivelConsulta & ")", False)

            If CamposBusca.Length > 0 Then
                Campos = CamposBusca.Split(",")
                For Each dReg As DataRow In dtBuscar.Rows
                    Extra = ""
                    For Each Campo In Campos
                        Extra = Extra & IIf(Extra.Length > 0, vbCrLf, "") & IIf(IsDBNull(dReg(Campo)), "", dReg(Campo)).ToString.Trim
                    Next
                    dReg("campos_extra") = Extra
                Next
            End If

            BS.DataSource = dtBuscar
            navPersonal.BindingSource = BS

            dgTabla.DataSource = BS
            dgTabla.Columns("FOTO").Visible = False
            dgTabla.Columns("CAMPOS_EXTRA").Visible = False

            txtReloj.DataBindings.Add("Text", BS, "sf_id")
            txtNombre.DataBindings.Add("Text", BS, "nombre")
            txtPuesto.DataBindings.Add("Text", BS, "puesto")
            txtDepto.DataBindings.Add("Text", BS, "departamento")
            txtAlta.DataBindings.Add("Text", BS, "alta", True, DataSourceUpdateMode.Never, Nothing, "d")
            txtBaja.DataBindings.Add("Text", BS, "baja", True, DataSourceUpdateMode.Never, "------", "d")
            picFoto.DataBindings.Add("ImageLocation", BS, "foto")
            lblDatoExtra.DataBindings.Add("Text", BS, "campos_extra")

            txtNombre.DataBindings.Add("Text", BS, "IMSS")
            txtNombre.DataBindings.Add("Text", BS, "RFC")


            idxBusca = 0
            'MostrarInformacionBuscar()
        Catch ex As Exception
            If ex.HResult <> -2147024809 Then
                'Si el error no se debe a que ya se habían asignado los DataBindings de los textos
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                MessageBox.Show("Se detectó un error al iniciar pantalla de búsqueda. Si el problema persiste, contacte al administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            txtBusca.Text = ""
        End Try
    End Sub

    Private Sub txtBusca_GotFocus(sender As Object, e As EventArgs) Handles txtBusca.GotFocus
        txtBusca.SelectAll()
    End Sub

    Private Sub txtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtBuscar.Clone
            vl = txtBusca.Text.Replace("*", "%")
            vl = vl.Replace("'", "")
            i = vl.IndexOf("%")

            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(sf_id LIKE '%" & vlAnt & "%' OR nombre LIKE '%" & vlAnt & "%' OR campos_extra LIKE '%" & vlAnt & "%') AND (" & _
                    "sf_id LIKE '%" & vlDes & "%' OR nombre LIKE '%" & vlDes & "%' OR campos_extra LIKE '%" & vlDes & "%')"
            Else
                vl = "sf_id LIKE '%" & vl & "%' OR nombre LIKE '%" & vl & "%' OR campos_extra LIKE '%" & vl & "%'"
            End If

            For Each dDato As DataRow In dtBuscar.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BS.DataSource = dtSeleccion
            RevisaColores()

        Catch ex As Exception
            'MCR 26/OCT/2015
            'Cambio para evitar que "truene" cuando el usuario presione secuencias incorrectas
            'p.ej. *,*,
            MessageBox.Show("Se detectó un error al buscar un empleado que cumpla con la condición indicada. Favor de verificar." & vbCrLf & _
                             vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBusca.Text = ""
        End Try
    End Sub

    Private Sub dgTabla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentDoubleClick
        RelojSF = dgTabla.Item("colreloj", dgTabla.CurrentRow.Index).Value

        btnAceptar.PerformClick()
    End Sub

    Private Sub dgTabla_DoubleClick(sender As Object, e As EventArgs) Handles dgTabla.DoubleClick
        RelojSF = dgTabla.Item("colreloj", dgTabla.CurrentRow.Index).Value
        btnAceptar.PerformClick()
    End Sub

    Private Sub txtBaja_TextChanged(sender As Object, e As EventArgs) Handles txtBaja.TextChanged
        Dim EsBaja As Boolean

        Try
            EsBaja = txtBaja.Text <> "------"
        Catch ex As Exception
            EsBaja = False
        Finally
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBusca.Focus()
        End Try
    End Sub

    Private Sub RevisaColores()
        Dim vl As String
        Dim i As Integer

        Try

            vl = txtBusca.Text.ToUpper.Trim
            If vl = "" Then vl = "*******"
            txtReloj.BackColor = IIf(txtReloj.Text.Contains(vl), Color.Yellow, SystemColors.Control)
            txtNombre.BackColor = IIf(txtNombre.Text.ToUpper.Contains(vl), Color.Yellow, SystemColors.Control)

            lblDatoExtra.SelectionStart = 0
            lblDatoExtra.SelectionLength = lblDatoExtra.TextLength
            lblDatoExtra.SelectionBackColor = SystemColors.Window

            i = lblDatoExtra.Find(vl)

            Do Until i < 0 Or i >= lblDatoExtra.TextLength - 1
                If i >= 0 Then
                    lblDatoExtra.SelectionStart = i
                    lblDatoExtra.SelectionLength = vl.Length
                    lblDatoExtra.SelectionBackColor = Color.Yellow
                End If
                i = lblDatoExtra.Find(vl, i + 1, RichTextBoxFinds.None)
            Loop
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtReloj.TextChanged
        RevisaColores()
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        RevisaColores()
    End Sub

    Private Sub lblDatoExtra_TextChanged(sender As Object, e As EventArgs) Handles lblDatoExtra.TextChanged
        RevisaColores()
    End Sub

End Class