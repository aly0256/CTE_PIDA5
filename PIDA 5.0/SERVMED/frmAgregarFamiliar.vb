Public Class frmAgregarFamiliar
    Public reloj As String = ""
    Public cia As String = ""
    Public editar As Boolean = False
    Public idfamiliar As String = ""
    Dim dtFam As DataTable
    Private Sub frmAgregarFamiliar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFam = sqlExecute("SELECT * FROM familia")
        cmbFamiliares.DataSource = dtFam
        cmbFamiliares.ValueMember = "cod_familia"
        cmbFamiliares.SelectedIndex = -1

        If editar = True Then
            Dim dtidfld As DataTable = sqlExecute("select * from familiares where idfld='" & idfamiliar & "'", "personal")
            txtNombre.Text = RTrim(dtidfld.Rows(0)("nombre"))
            cmbFamiliares.SelectedValue = dtidfld.Rows(0)("cod_familia")
            txtNombre.Enabled = False
            cmbFamiliares.Enabled = False
            'cmbFamiliares.SelectedValue = cod_familiar
        Else
            txtNombre.Text = ""
            dtFechaNac.ValueObject = Now
            txtNombre.Enabled = True
            cmbFamiliares.Enabled = True
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If txtNombre.Enabled = True Then
                sqlExecute("INSERT INTO familiares(cod_comp,reloj,cod_familia,nombre,fecha_nac) values('" & cia & "','" & reloj & "','" & cmbFamiliares.SelectedValue & "','" & txtNombre.Text & "','" & dtFechaNac.ValueObject & "')", "personal")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                sqlExecute("UPDATE familiares SET fecha_nac='" & dtFechaNac.ValueObject & "' where idfld='" & idfamiliar & "'", "personal")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class