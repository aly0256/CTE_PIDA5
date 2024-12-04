Public Class frmProgramacionMenu
    Dim dtPeriodos As New DataTable
    Dim dtPeriodoSeleccionado As New DataTable
    Private Sub frmProgramacionMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
        dtPeriodos = sqlExecute("select ano+periodo as 'seleccionado',Ano as 'Año',Periodo,cast(fecha_ini as nvarchar(30)) as 'Fecha de inicio',cast(fecha_fin as nvarchar(30)) as 'Fecha de fin' from periodos where periodo < 54 order by periodo asc", "ta")
        cmbPeriodos.GroupingMembers = "Año"
        cmbPeriodos.DataSource = dtPeriodos

        cmbPeriodos.DisplayMembers = "seleccionado,Ano,Periodo,Fecha de inicio,Fecha de fin"
        cmbPeriodos.ValueMember = "seleccionado"

        cmbPeriodos.SelectedValue = ObtenerAnoPeriodo(Date.Now)
        dtPeriodoSeleccionado = sqlExecute("select * from periodos where ano+periodo = '" + cmbPeriodos.SelectedValue + "'", "ta")
        If dtPeriodoSeleccionado.Rows.Count > 0 Then
            Dim FechaInicio As Date = dtPeriodoSeleccionado.Rows(0).Item("FECHA_INI")
            For p As Integer = 0 To 6 Step 1
                flwPeriodoDIsponibles.Controls.Add(New uscPeriodoCafeteria(dtPeriodoSeleccionado.Rows(0).Item("periodo"), dtPeriodoSeleccionado.Rows(0).Item("ano"), FechaInicio.AddDays(p)))
            Next
        End If

        AddHandler cmbPeriodos.PopupClose, AddressOf cmbPeriodosE
    End Sub

    Private Sub cmbPeriodosE(sender As Object, e As EventArgs)
        flwPeriodoDIsponibles.Controls.Clear()
        '   dtPeriodoSeleccionado = 

        dtPeriodoSeleccionado = sqlExecute("select * from periodos where ano+periodo = '" + cmbPeriodos.SelectedValue + "'", "ta")
        If dtPeriodoSeleccionado.Rows.Count > 0 Then
           Dim FechaInicio As Date = dtPeriodoSeleccionado.Rows(0).Item("FECHA_INI")
            For p As Integer = 0 To 6 Step 1
                flwPeriodoDIsponibles.Controls.Add(New uscPeriodoCafeteria(dtPeriodoSeleccionado.Rows(0).Item("periodo"), dtPeriodoSeleccionado.Rows(0).Item("ano"), FechaInicio.AddDays(p)))
            Next
        End If
    End Sub
End Class