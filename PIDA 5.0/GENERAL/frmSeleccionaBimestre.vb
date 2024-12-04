
Public Class frmSeleccionaBimestre
    ' test
    Private fecha_ini As Date
    Private fecha_fin As Date

    Public ReadOnly Property fha_ini_bim As Date
        Get
            Return Me.fecha_ini
        End Get
    End Property

    Public ReadOnly Property fha_fin_bim As Date
        Get
            Return Me.fecha_fin
        End Get
    End Property

    Private Function CargarBimestres(ByVal par_anio As Integer) As DataTable

        Dim dtBimestres As New DataTable

        Try

            dtBimestres.Columns.Add("bimestre", GetType(String))
            dtBimestres.Columns.Add("meses", GetType(String))
            dtBimestres.Columns.Add("inicio", GetType(String))
            dtBimestres.Columns.Add("fin", GetType(String))

            dtBimestres.Rows.Add({"Bim 1", "Ene-Feb", par_anio.ToString & "-01-01", par_anio.ToString & "-02-" & IIf(par_anio Mod 4 = 0, 29, 28).ToString})
            dtBimestres.Rows.Add({"Bim 2", "Mar-Abr", par_anio.ToString & "-03-01", par_anio.ToString & "-04-30"})
            dtBimestres.Rows.Add({"Bim 3", "May-Jun", par_anio.ToString & "-05-01", par_anio.ToString & "-06-30"})
            dtBimestres.Rows.Add({"Bim 4", "Jul-Ago", par_anio.ToString & "-07-01", par_anio.ToString & "-08-31"})
            dtBimestres.Rows.Add({"Bim 5", "Sep-Oct", par_anio.ToString & "-09-01", par_anio.ToString & "-10-31"})
            dtBimestres.Rows.Add({"Bim 6", "Nov-Dic", par_anio.ToString & "-11-01", par_anio.ToString & "-12-31"})

        Catch ex As Exception
            If dtBimestres.Rows.Count > 0 Then dtBimestres.Rows.Clear()
            MessageBox.Show("Error al cargar los bimestres.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtBimestres

    End Function


    Private Sub frmSeleccionaBimestre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtAnio.Value = Now.Year
            cmbBimestre.DataSource = CargarBimestres(txtAnio.Value)
        Catch ex As Exception
            MessageBox.Show("Error al cargar la ventana.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cmbBimestre.SelectedIndex = -1

    End Sub

    Private Sub frmSeleccionaBimestre_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            Dim Posx As Double = (Me.Width - Panel1.Width) / 2
            Panel1.Left = Posx
        Catch ex As Exception
            ' TEST
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.fecha_ini = Nothing
        Me.fecha_fin = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            If cmbBimestre.SelectedIndex >= 0 Then

                fecha_ini = Date.Parse(cmbBimestre.Text.Split(",")(2).Trim)
                fecha_fin = Date.Parse(cmbBimestre.Text.Split(",")(3).Trim)

            Else
                MessageBox.Show("Debe seleccionar un bimestre.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbBimestre.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            fecha_ini = Nothing
            fecha_fin = Nothing
            MessageBox.Show("Error al seleccionar bimestre.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'test
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtAnio_ValueObjectChanged(sender As Object, e As EventArgs) Handles txtAnio.ValueObjectChanged
        Try
            cmbBimestre.DataSource = CargarBimestres(txtAnio.Value)
        Catch ex As Exception
            fecha_ini = Nothing
            fecha_fin = Nothing
            MessageBox.Show("Error al cargar los bimestres del año ingresado.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbBimestre.SelectedIndex = -1
        End Try
        cmbBimestre.SelectedIndex = -1
    End Sub
End Class