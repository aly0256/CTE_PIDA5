Public Class frmPruebaDinamico

    Private Sub botonActualizarTablas_Click(sender As Object, e As EventArgs) Handles botonActualizarTablas.Click
        Try

            Dim myconnection = New System.Data.SqlClient.SqlConnection(campoHost.Text & ";Initial Catalog=" & campoBase.Text & ";Persist Security Info=True; User ID=" & campoUsuario.Text & "; Password=" & campoPassword.Text & ";")

            myconnection.Open()

            Dim dtCampos As DataTable = myconnection.GetSchema("tables")

            If dtCampos.Rows.Count > 0 Then

                comboTablasPorBase.Items.Clear()

                For Each row As DataRow In dtCampos.Rows
                    comboTablasPorBase.Items.Add(row("table_name"))
                Next
                comboTablasPorBase.SelectedIndex = 0
            End If

            myconnection.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmPruebaDinamico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        campoHost.Text = Declaraciones.SQLConn
        campoUsuario.Text = Declaraciones.sUserAdmin
        campoPassword.Text = Declaraciones.sPassword
        campoBase.Text = "personal"
    End Sub

    Private Sub comboTablasPorBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTablasPorBase.SelectedIndexChanged
        Try
            Dim myconnection = New System.Data.SqlClient.SqlConnection(campoHost.Text & ";Initial Catalog=" & campoBase.Text & ";Persist Security Info=True; User ID=" & campoUsuario.Text & "; Password=" & campoPassword.Text & ";")
            Dim t As New tabla(myconnection, campoBase.Text, comboTablasPorBase.Text)
            cargarDatosCatalogo(t)
            t.cargarInfoRegistro()
            dgvInfoTabla.DataSource = t.dtInfo
        Catch ex As Exception
        End Try
    End Sub

    ' ---------------------------------------

    Dim campos As New ArrayList

    Public Sub cargarDatosCatalogo(t As tabla)
        campoTitulo.Text = t.nombre
        'cargar vista de tabla
        dgvTabla.DataSource = t.dtValues
        dgvTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTabla.AutoResizeColumns()

        panelIndividual.Controls.Clear()
        For Each campo As campo In t.campos
            campo.panel.Width = panelIndividual.Width * 0.75
            panelIndividual.Controls.Add(campo.panel)
        Next

    End Sub

End Class

Public Class tabla
    Public nombre As String = ""
    Public base As String = ""
    Public con As New SqlClient.SqlConnection
    Public dtInfo As New DataTable
    Public dtValues As New DataTable

    Public campos As New ArrayList

    Sub New(con As SqlClient.SqlConnection, base As String, nombre As String)
        Me.nombre = nombre
        Me.base = base
        Me.con = con

        Me.Inicializar()
    End Sub

    Private Sub Inicializar()
        Me.con.Open()

        'Dim dtCampos As DataTable = myconnection.GetSchema("tables")
        Dim restrictions() As String = {Me.base, Nothing, Me.nombre, Nothing}
        Me.dtInfo = Me.con.GetSchema("columns", restrictions)

        If Me.dtInfo.Rows.Count > 0 Then
            For Each row As DataRow In dtInfo.Rows
                Me.campos.Add(New campo(row))
            Next
        End If

        Me.dtInfo = Me.con.GetSchema("columns", restrictions)

        Me.con.Close()



        Me.dtValues = sqlExecute("select * from " & Me.nombre & "", Me.base)
    End Sub

    Public Sub cargarInfoRegistro()
        Dim dtRegistro As DataTable = sqlExecute("select top 1 * from " & Me.nombre & "", Me.base)
        If dtRegistro.Rows.Count > 0 Then
            Dim row As DataRow = dtRegistro.Rows(0)
            For Each campo As campo In Me.campos
                Try
                    If campo.textbox.Enabled Then
                        campo.textbox.Text = row(campo.nombre)
                    End If
                Catch ex As Exception

                End Try                
            Next
        End If
    End Sub
End Class

Class campo
    Public nombre As String
    Public tipo As String
    Public value As String
    Public longitud As Integer

    Public panel As New Panel
    Public panelc As New FlowLayoutPanel
    Public labelNombre As New Label

    Public textbox As New TextBox

    Sub New(row As DataRow)
        On Error Resume Next
        Me.nombre = row("column_name")
        Me.tipo = row("data_type")
        'Me.longitud
        inicializar()
    End Sub

    Public Sub inicializar()
        panelc.FlowDirection = FlowDirection.TopDown

        Me.labelNombre.Text = Me.nombre
        Me.panelc.Controls.Add(labelNombre)

        textbox.Enabled = False
        If Me.tipo.Equals("nvarchar") Then
            textbox.Enabled = True
            Me.panelc.Controls.Add(textbox)
        ElseIf Me.tipo.Equals("int") Then
            textbox.Enabled = True
            Me.panelc.Controls.Add(textbox)
        ElseIf Me.tipo.Equals("char") Then
            textbox.Enabled = True
            Me.panelc.Controls.Add(textbox)
        ElseIf Me.tipo.Equals("float") Then
            textbox.Enabled = True
            Me.panelc.Controls.Add(textbox)
        End If

        panelc.Height = 60

        Me.panel.Controls.Add(panelc)
    End Sub

End Class