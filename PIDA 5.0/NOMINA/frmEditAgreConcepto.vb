Public Class frmEditAgreConcepto

    Dim dtConceptos As New DataTable
    Dim dtConceptosAjusteCalculo As New DataTable
    Dim dtRegistro As New DataTable
    Dim MostrarDatos As Boolean = False
    Dim Clave As String = ""
    Dim lclFolio As String = ""
    Dim lclPeriodo As String = ""
    Dim lclFiltro As String = ""
    Dim lclReloj As String = ""
    Dim GridConceptos As DataTable
    Dim lclConcepo As String = ""
    Dim lclMonto As Double = 0
    Dim lclBajaFiniquito As Date = Nothing

    Dim row As DataGridViewRow

    Private Sub frmEditAgreConcepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Clave = frmFiniquitoWME.EditarAgregar
            lclPeriodo = Trim(IIf(frmFiniquitoWME.cmbPeriodos.SelectedIndex >= 0, frmFiniquitoWME.cmbPeriodos.SelectedValue, ""))
            lclFolio = frmFiniquitoWME.txtFolio.Text.Trim
            lclReloj = frmFiniquitoWME.txtReloj.Text.Trim
            GridConceptos = DirectCast(frmFiniquitoWME.dgvConceptos.DataSource, DataTable)
            txtMonto.Value = 0

            If Clave = "NVO" Then

                'Para mostrar los conceptos en el combo para seleccion, deben estar activos y en el campo 'finiquito' debe estar en 1
                dtConceptos = sqlExecute("select ltrim(rtrim(conceptos.concepto)) as concepto,upper(ltrim(rtrim(conceptos.nombre))) as nombre," & vbCr & _
                                     "convert(char(100), ltrim(rtrim( naturalezas.nombre))) as naturaleza " & vbCr & _
                                     "from conceptos left join naturalezas on conceptos.COD_NATURALEZA = naturalezas.COD_NATURALEZA" & vbCr & _
                                     "where activo = 1 and finiquito = 1 and rtrim(ltrim(isnull(naturalezas.nombre,''))) <> ''", "NOMINA")

                If dtConceptos.Rows.Count > 0 Then
                    cmbConceptos.DataSource = dtConceptos
                    cmbConceptos.ValueMember = "CONCEPTO"
                    cmbConceptos.DisplayMembers = "CONCEPTO,NOMBRE"
                End If

                cmbConceptos.SelectedIndex = -1
                MostrarDatos = True

            ElseIf Clave = "EDT" Then

                Dim edtConcepto As String = ""

                'dtConceptos = sqlExecute("select ltrim(rtrim(ajucalc.Concepto)) as 'concepto',upper(ltrim(rtrim(isnull(ajucalc.Descripcion,'Sin especificar')))) as 'nombre',convert(char(100),ltrim(rtrim(isnull(naturalezas.NOMBRE,'Indefinido')))) as 'naturaleza'" & vbCr & _
                '                         "from ajustes_calculo ajucalc left join conceptos on ajucalc.Concepto = conceptos.CONCEPTO" & vbCr & _
                '                         "left join naturalezas on naturalezas.COD_NATURALEZA = conceptos.COD_NATURALEZA" & vbCr & _
                '                        "where (ano+periodo) = '" & lclPeriodo & "' and folio = '" & lclFolio & "' and reloj = '" & lclReloj & "' and concepto = '" & edtConcepto & "'", "NOMINA")

                row = frmFiniquitoWME.dgvConceptos.SelectedRows(0)

                Dim FiltroConcepto As String = row.Cells("ColConcepto").Value.ToString.Trim
                lclConcepo = row.Cells("ColConcepto").Value.ToString.Trim
                lclMonto = row.Cells("ColMonto").Value.ToString.Trim

                dtConceptos = sqlExecute("select ltrim(rtrim(conceptos.concepto)) as concepto,upper(ltrim(rtrim(conceptos.nombre))) as nombre," & vbCr & _
                                   "convert(char(100), ltrim(rtrim( naturalezas.nombre))) as naturaleza " & vbCr & _
                                   "from conceptos left join naturalezas on conceptos.COD_NATURALEZA = naturalezas.COD_NATURALEZA" & vbCr & _
                                   "where concepto = '" & FiltroConcepto & "'", "NOMINA")

                If dtConceptos.Rows.Count > 0 Then
                    MostrarDatos = True
                    cmbConceptos.DataSource = dtConceptos
                    cmbConceptos.SelectedIndex = 0
                Else
                    MessageBox.Show("No se localizó el concepto a editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar mostrar parte de la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConceptos.SelectedIndexChanged

        Try

            If Clave = "EDT" Then

                If cmbConceptos.SelectedIndex >= 0 And dtConceptos.Rows.Count > 0 And MostrarDatos Then
                    Dim drRow As DataRow = dtConceptos.Select("concepto = '" & lclConcepo & "'")(0)
                    txtDescripcion.Text = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                    txtMonto.Value = lclMonto
                End If

            ElseIf Clave = "NVO" Then

                If cmbConceptos.SelectedIndex >= 0 And dtConceptos.Rows.Count > 0 And MostrarDatos Then
                    Dim drRow As DataRow = dtConceptos.Select("concepto = '" & cmbConceptos.SelectedValue.ToString.Trim & "'")(0)
                    txtDescripcion.Text = Trim(IIf(IsDBNull(drRow("nombre")), "", drRow("nombre")))
                    txtMonto.Value = 0


                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar mostrar parte de la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDescripcion.Text = ""
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmEditAgreConcepto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim Existencia As Integer = 0
            Dim strConcepto As String = ""
            Dim dtAgregar As New DataTable
            Dim Agregado As Boolean = False

            If cmbConceptos.SelectedIndex >= 0 And txtMonto.Value > 0 Then

                If Clave = "NVO" Then

                    strConcepto = cmbConceptos.SelectedValue.ToString.Trim()

                    If GridConceptos.Rows.Count > 0 Then

                        Existencia = GridConceptos.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = strConcepto).Count

                        If Existencia = 0 Then
                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = '" & strConcepto & "'", "NOMINA")

                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then
                                Dim drFila As DataRow = GridConceptos.NewRow

                                drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drFila("monto") = txtMonto.ValueObject
                                drFila("factor") = 0

                                GridConceptos.Rows.Add(drFila)

                                Agregado = True
                            Else

                                MessageBox.Show("El concepto [" & strConcepto & "] no se pudo agragar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If

                        ElseIf Existencia > 0 Then

                            MessageBox.Show("El concepto [" & strConcepto & "] ya ha sido agregado para el cálculo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If

                    Else

                        dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = '" & strConcepto & "'", "NOMINA")

                        If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                            Dim drFila As DataRow = GridConceptos.NewRow

                            drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                            drFila("monto") = txtMonto.ValueObject
                            drFila("factor") = 0

                            GridConceptos.Rows.Add(drFila)

                            Agregado = True
                        Else

                            MessageBox.Show("El concepto [" & strConcepto & "] no se pudo agragar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If

                    End If

                ElseIf Clave = "EDT" Then

                    row.Cells("colMonto").Value = txtMonto.Value

                    Agregado = True

                End If

              
            Else

                If Not cmbConceptos.SelectedIndex >= 0 Then
                    MessageBox.Show("Debe seleccionar un concepto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cmbConceptos.Focus()
                ElseIf txtMonto.Value <= 0 Then
                    MessageBox.Show("El monto es inválido. Favor de verificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtMonto.Focus()
                End If


            End If

            If Agregado Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub
End Class