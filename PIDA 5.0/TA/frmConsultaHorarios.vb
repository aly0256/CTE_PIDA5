Public Class frmConsultaHorarios

    Public periodoactivo As String = ""
    Public cod_hora As String = ""

    Private Sub frmConsultaHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPeriodos As DataTable

        dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin,(CASE activo WHEN 1 THEN '   *' ELSE '' END) AS activo " & _
                                "FROM periodos WHERE periodo_especial IS NULL OR periodo_especial = 0 ORDER BY ano DESC,periodo ASC", "TA")

        cmbPeriodos.DataSource = dtPeriodos

        If periodoactivo <> "" Then
            cmbPeriodos.SelectedValue = periodoactivo
        End If


        Dim dtHorarios As DataTable

        dtHorarios = sqlExecute("select cod_hora, nombre from horarios")

        cmbHorarios.DataSource = dtHorarios

        If cod_hora <> "" Then
            cmbHorarios.SelectedValue = cod_hora
        End If

    End Sub

    Private Sub cmbHorarios_TextChanged(sender As Object, e As EventArgs) Handles cmbHorarios.SelectedValueChanged, cmbPeriodos.SelectedValueChanged
        Try
            Dim q As String = "select" & _
 " horarios.cod_hora, " & _
 " rol_horarios.ano, " & _
" rol_horarios.periodo, " & _
" rol_horarios.SEMANA, " & _
" max(case when dias.cod_dia = '1' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as L, " & _
" max(case when dias.cod_dia = '2' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as M, " & _
" max(case when dias.cod_dia = '3' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as W, " & _
" max(case when dias.cod_dia = '4' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as J, " & _
" max(case when dias.cod_dia = '5' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as V, " & _
" max(case when dias.cod_dia = '6' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as S, " & _
" max(case when dias.cod_dia = '7' then case when descanso = 1 then 'DESCANSO' else dias.ENTRA + ' a ' + dias.SALE end else '' end) as D " & _
"from horarios " & _
" left join rol_horarios on rol_horarios.cod_hora = horarios.cod_hora " & _
" left join dias on dias.cod_hora = horarios.cod_hora and dias.semana = rol_horarios.semana " & _
"where  " & _
" rol_horarios.ano +rol_horarios.periodo = '" & cmbPeriodos.SelectedValue & "' and rol_horarios.cod_hora = '" & cmbHorarios.SelectedValue & "' " & _
"group by " & _
" horarios.cod_hora, " & _
" rol_horarios.ano, " & _
" rol_horarios.periodo, " & _
" rol_horarios.SEMANA "
            DataGridViewX1.DataSource = sqlExecute(q)
        Catch ex As Exception

        End Try
    End Sub
End Class