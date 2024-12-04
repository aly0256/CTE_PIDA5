Public Class CapturaSermed

    Public detalle As UserControl
    Public captura As DatosCapturaSermed

    'Public t As DevComponents.DotNetBar.SuperTabItem    

    Public Sub mostrarInformacion()
        Me.flowPanel.Controls.Clear()
        campoReloj.Text = captura.reloj
        rbExterno.Checked = captura.externo
        rbEmpleado.Checked = Not captura.externo

        If Not captura.externo Then
            flowPanel.Controls.Add(panelEmpleados)
            Dim dtEmpleado As DataTable = sqlExecute("select * from personalSermed where reloj = '" & captura.reloj & "'", "sermed")
            If dtEmpleado.Rows.Count > 0 Then
                Dim empleado As EmpleadoSermed = New EmpleadoSermed(dtEmpleado.Rows(0)("reloj"))
                campoNombreEmpleado.Text = empleado.nombres
                captura.nombres = empleado.nombres

                If captura.nombres.Length > 0 Then                    
                    Me.captura.apaterno = captura.nombres.Split(",")(0)
                    Me.captura.amaterno = captura.nombres.Split(",")(1)
                    Me.captura.nombre = captura.nombres.Split(",")(2)
                End If

                Me.campoTipo.Text = empleado.tipo
                Me.campoHorario.Text = empleado.horario
                Me.campoSuper.Text = empleado.super
                Me.campoTurno.Text = empleado.turno
                Me.campoPuesto.Text = empleado.puesto
                Me.campoDepto.Text = empleado.depto
                Me.campoAlta.Text = empleado.alta
                Me.campoBaja.Text = empleado.baja
                Me.campoSexoEmpleado.Text = empleado.sexo
                captura.sexo = empleado.sexo
                Me.campoEdadEmpleado.Text = empleado.edad
                captura.edad = empleado.edad

                If empleado.baja.Equals("") Then
                    lblEstado.Text = "ACTIVO"
                    lblEstado.BackColor = Color.LimeGreen
                Else
                    lblEstado.Text = "INACTIVO"
                    lblEstado.BackColor = Color.IndianRed
                End If
            Else
                captura.externo = True
                mostrarInformacion()
            End If
        Else
            flowPanel.Controls.Add(panelExternos)
            campoNombresExterno.Text = captura.nombre
            campoApaternoExterno.Text = captura.apaterno
            campoAmaternoExterno.Text = captura.amaterno
            campoEmpresa.Text = captura.empresa
            campoEdadExterno.Text = captura.edad
            campoReloj_fam.Text = captura.reloj_fam
            campoSexoExterno.Text = captura.sexo
        End If

        Me.flowPanel.Controls.Add(detalle)
    End Sub

    Sub New()
        InitializeComponent()        
    End Sub

    Private Sub checkedChanged(sender As Object, e As EventArgs) Handles rbEmpleado.CheckedChanged, rbExterno.CheckedChanged        
        captura.externo = rbExterno.Checked
        If captura.externo Then
            captura.reloj = "Exter"
        End If
        mostrarInformacion()
    End Sub

    Private Sub campoNombresExterno_TextChanged(sender As Object, e As EventArgs) Handles campoNombresExterno.TextChanged
        captura.nombre = campoNombresExterno.Text.ToUpper
        captura.nombres = captura.apaterno & "," & captura.amaterno & "," & captura.nombre
    End Sub

    Private Sub campoApaternoExterno_TextChanged(sender As Object, e As EventArgs) Handles campoApaternoExterno.TextChanged
        captura.apaterno = campoApaternoExterno.Text.ToUpper
        captura.nombres = captura.apaterno & "," & captura.amaterno & "," & captura.nombre
    End Sub

    Private Sub campoAmaternoExterno_TextChanged(sender As Object, e As EventArgs) Handles campoAmaternoExterno.TextChanged
        captura.amaterno = campoAmaternoExterno.Text.ToUpper
        captura.nombres = captura.apaterno & "," & captura.amaterno & "," & captura.nombre
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBusca.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                Me.campoReloj_fam.Text = Reloj
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub campoReloj_fam_TextChanged(sender As Object, e As EventArgs) Handles campoReloj_fam.TextChanged
        captura.reloj_fam = campoReloj_fam.Text
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            frmBusca.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                Me.captura.reloj = Reloj
                Me.captura.externo = False
                Me.rbExterno.Checked = Me.captura.externo
                Me.rbEmpleado.Checked = Not Me.captura.externo
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub campoEmpresa_TextChanged(sender As Object, e As EventArgs) Handles campoEmpresa.TextChanged
        Me.captura.empresa = campoEmpresa.Text.ToUpper
    End Sub

    Private Sub campoSexoExterno_TextChanged(sender As Object, e As EventArgs) Handles campoSexoExterno.TextChanged
        captura.sexo = campoSexoExterno.Text.ToUpper
    End Sub

    Private Sub campoEdadExterno_TextChanged(sender As Object, e As EventArgs) Handles campoEdadExterno.TextChanged
        captura.edad = campoEdadExterno.Text
    End Sub

    Private Sub CapturaSermed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.flowPanel.Controls.Clear()
    End Sub
End Class
