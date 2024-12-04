Public Class frmGrupo
    Dim dtGrupos As New DataTable

    Private Sub frmFechaGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'CODIGO
            dtGrupos.Columns.Add("GRUPO")
            'NOMBRE
            dtGrupos.Columns.Add("NOMBRE_GRUPO")
            'DESCRIPCION EN REPORTE
            dtGrupos.Columns.Add("TIPO_GRUPO")

            dtGrupos.Rows.Add({"COD_DEPTO", "NOMBRE_DEPTO", "DEPARTAMENTO"})
            dtGrupos.Rows.Add({"COD_PUESTO", "NOMBRE_PUESTO", "PUESTO"})
            dtGrupos.Rows.Add({"COD_SUPER", "NOMBRE_SUPER", "SUPERVISOR"})
            dtGrupos.Rows.Add({"COD_TIPO", "NOMBRE_TIPOEMP", "TIPO"})
            dtGrupos.Rows.Add({"COD_CLASE", "NOMBRE_CLASE", "CLASE"})
            dtGrupos.Rows.Add({"COD_PLANTA", "NOMBRE_PLANTA", "PLANTA"})
            dtGrupos.Rows.Add({"COD_LINEA", "NOMBRE_LINEA", "LÍNEA"})
            If GrupoAuxiliares Then
                dtGrupos.Rows.Add({"OPERACION", "OPERACION", "OPERACIÓN"})
                dtGrupos.Rows.Add({"SUB_OP", "SUB_OP", "SUB-OPERACIÓN"})
                dtGrupos.Rows.Add({"PRENSA", "PRENSA", "PRENSA"})
            End If
            dtGrupos.PrimaryKey = New DataColumn() {dtGrupos.Columns("TIPO_GRUPO")}

            cmbGrupo.DataSource = dtGrupos
            ''cmbGrupo.ValueMember = "TIPO_GRUPO"
            'cmbGrupo.Columns.Remove(cmbGrupo.Columns("GRUPO"))
            ''cmbGrupo.Columns(1).Visible = False
            'cmbGrupo.Columns.Remove(cmbGrupo.Columns("NOMBRE_GRUPO"))
            'cmbGrupo.Columns(0).StretchToFill = True

        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        drGrupo = dtGrupos.Rows.Find({cmbGrupo.SelectedValue})

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        drGrupo = Nothing

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmbGrupo_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class