Public Class frmExamenMedico

    Public nuevo As Boolean = False

    Public tmpFolio As String

    Public ema As New ExamenMedico

    Public dtExamenMedico As DataTable

    Public dtMPF As DataTable = sqlExecute("select id_mpf as 'id', descripcion as 'descripcion' from mpf", "SERMED")

    Public dtEstadosCivilesM As DataTable = sqlExecute("select id_edo_civil as 'id', descripcion_m as 'descripcion' from estados_civiles", "SERMED")

    Public dtEstadosCivilesF As DataTable = sqlExecute("select id_edo_civil as 'id', descripcion_f as 'descripcion' from estados_civiles", "SERMED")

    Public dtReligionesM As DataTable = sqlExecute("select id_religion as 'id', descripcion_M as 'descripcion' from religiones", "SERMED")

    Public dtReligionesF As DataTable = sqlExecute("select id_religion as 'id', descripcion_f as 'descripcion' from religiones", "SERMED")

    Public dtEscolaridad As DataTable = sqlExecute("select id_escolaridad as 'id', descripcion as 'descripcion' from escolaridades", "SERMED")

    Public Sub frmExamenMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboEdo_civil.DataSource = dtEstadosCivilesM
        comboEdo_civil.DisplayMember = "descripcion"
        comboEdo_civil.ValueMember = "id"

        comboReligion.DataSource = dtReligionesM
        comboReligion.DisplayMember = "descripcion"
        comboReligion.ValueMember = "id"

        comboEscolaridad.DataSource = dtEscolaridad
        comboEscolaridad.DisplayMember = "descripcion"
        comboEscolaridad.ValueMember = "id"

        comboMPF.DataSource = dtMPF
        comboMPF.DisplayMember = "descripcion"
        comboMPF.ValueMember = "id"

        cargarDatos("")
    End Sub

    Public Sub cargarDatos(Optional ByVal folio As String = "nuevo")

        btnNuevo.Text = "Agregar"
        btnEditar.Text = "Editar"

        campoNombre.Enabled = False
        campoApaterno.Enabled = False
        campoAmaterno.Enabled = False
        campoEdad.Enabled = False


        Me.TabPage1.Enabled = False
        Me.TabPage2.Enabled = False
        Me.TabPage3.Enabled = False

        If folio.Equals("") Then
            dtExamenMedico = sqlExecute("select top 1 * from examen_medico order by folio asc", "sermed")
            If dtExamenMedico.Rows.Count > 0 Then
                ema = New ExamenMedico(dtExamenMedico.Rows(0))
            End If
        ElseIf folio.Equals("nuevo") Then
            ema = New ExamenMedico()
            Me.TabPage1.Enabled = True
            Me.TabPage2.Enabled = True
            Me.TabPage3.Enabled = True
        Else
            dtExamenMedico = sqlExecute("select * from examen_medico where folio = '" + folio + "'", "sermed")
            If dtExamenMedico.Rows.Count > 0 Then
                ema = New ExamenMedico(dtExamenMedico.Rows(0))
            End If
        End If

        campoFolio.Text = ema.folio

        campoFecha.Text = ema.fecha

        campoNombre.Text = ema.nombre

        campoApaterno.Text = ema.apaterno

        campoAmaterno.Text = ema.amaterno

        campoEdad.Text = ema.edad

        If ema.sexo.Equals("M") Then
            comboSexo.Text = "Masculino"
        Else
            comboSexo.Text = "Femenino"
        End If

        comboEdo_civil.SelectedValue = ema.edo_civil

        comboEscolaridad.SelectedValue = ema.escolaridad

        comboReligion.SelectedValue = ema.religion

        campoEsc_anos.Text = ema.esc_anos

        campoDomicilio.Text = ema.domicilio

        campoLugar_n.Text = ema.lugar_n

        campoTrab_ant.Text = ema.trab_ant


        'indices

        comboTA1.SelectedItem = ema.ta1

        comboTA2.SelectedItem = ema.ta2

        comboFC.SelectedItem = ema.fc

        comboFR.SelectedItem = ema.fr

        campoPeso.Text = ema.peso

        campoAltura.Text = ema.altura

        'campoIMC.Text = ema.imc

        comboAgudezaVisual.SelectedItem = ema.agudezaVisual


        'datos patologicos

        campoAHF.Text = ema.ahf

        comboTabaquismo.SelectedItem = ema.tabaquismo

        comboAlcoholismo.SelectedItem = ema.alcoholismo

        comboToxico.SelectedItem = ema.toxico

        campoAPNP.Text = ema.apnp

        cbInmunizaciones.Checked = ema.inmun_comp

        campoDeportes.Text = ema.deportes

        campoAPP.Text = ema.app

        campoIPAS.Text = ema.ipas


        'antescedentes ginecologicos

        comboMenarca.SelectedItem = ema.menarca.ToString

        comboCiclo.SelectedItem = ema.ciclo_menstrual

        comboIVSA.SelectedItem = ema.ivsa

        comboGestas.Text = ema.gestas

        comboParas.Text = ema.paras

        comboAbortos.Text = ema.abortos

        comboCesareas.Text = ema.cesareas

        comboMPF.SelectedValue = ema.mpf

        campoResumenGinecologico.Text = ema.resumen


        'cabeza

        campoCraneo.Text = ema.craneo

        campoNariz.Text = ema.nariz

        campoOrofaringe.Text = ema.orofaringe

        campoAud.Text = ema.aud

        campoConjuntiva.Text = ema.conjuntiva


        '' ? ? ? 

        campoCuello.Text = ema.cuello

        campoTorax.Text = ema.torax

        campoAbdomen.Text = ema.abdomen

        campoGenitales.Text = ema.genitales

        campoExtremidad.Text = ema.extremidad

        campoLaboratorio.Text = ema.laboratorio

        comboAntidoping.Text = ema.antidoping

        comboSustancias.Text = ema.substancia

        campoComentariosAntidoping.Text = ema.comentario_antidoping


        ''conclusion

        campoComentario.Text = ema.comentario

        campoConclusion.Text = ema.conclusion

        rbApto.Checked = ema.apto
        rbNoApto.Checked = Not ema.apto

        Panel2.BackColor = IIf(ema.apto, Color.LimeGreen, Color.IndianRed)

        labelHora_captura.Text = ema.hora_captura

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel2.DisplayRectangle, Color.Gray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub rbApto_CheckedChanged(sender As Object, e As EventArgs) Handles rbApto.CheckedChanged
        If rbApto.Checked Then
            ema.apto = True
            Panel2.BackColor = Color.LimeGreen
            TabPage3.ImageIndex = 2
            Label51.Text = "Apto"
        End If
    End Sub

    Private Sub rbNoApto_CheckedChanged(sender As Object, e As EventArgs) Handles rbNoApto.CheckedChanged
        If rbNoApto.Checked Then
            ema.apto = False
            Panel2.BackColor = Color.IndianRed
            TabPage3.ImageIndex = 3
            Label51.Text = "No Apto"
        End If
    End Sub

    Private Sub comboAntidoping_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAntidoping.SelectedIndexChanged
        If comboAntidoping.Text = "NEG" Then
            comboSustancias.Visible = False
        Else
            comboSustancias.Visible = True
            Me.campoComentario.Text += "( POSITIVO A ANTIDOPING )"
        End If
        ema.antidoping = comboAntidoping.Text
    End Sub

    Private Sub validarIMC()
        ema.imc = RoundUp(ema.peso / (ema.altura * ema.altura), 2)
        campoIMC.Text = ema.imc
    End Sub

    Private Sub comboSexo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSexo.SelectedIndexChanged
        ' M - Masculino
        ' F - Femenino        

        Dim edo As Integer = comboEdo_civil.SelectedIndex
        Dim rel As Integer = comboReligion.SelectedIndex

        comboEdo_civil.DataSource = Nothing
        comboReligion.DataSource = Nothing

        If comboSexo.Text = "Masculino" Then
            AntecedentesGinecologicos.Visible = False
            ema.sexo = "M"
            comboEdo_civil.DataSource = dtEstadosCivilesM
            comboReligion.DataSource = dtReligionesM
        Else
            AntecedentesGinecologicos.Visible = True
            ema.sexo = "F"
            comboEdo_civil.DataSource = dtEstadosCivilesF
            comboReligion.DataSource = dtReligionesF
        End If

        comboEdo_civil.DisplayMember = "descripcion"
        comboEdo_civil.ValueMember = "id"

        comboReligion.DisplayMember = "descripcion"
        comboReligion.ValueMember = "id"

        comboEdo_civil.SelectedIndex = edo
        comboReligion.SelectedIndex = rel
    End Sub

    Private Sub comboEdo_civil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboEdo_civil.SelectedIndexChanged
        Try
            ema.edo_civil = comboEdo_civil.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboReligion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboReligion.SelectedIndexChanged
        Try
            ema.religion = comboReligion.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub campoDomicilio_TextChanged(sender As Object, e As EventArgs) Handles campoDomicilio.TextChanged
        If campoDomicilio.Text <> "" Then
            ema.domicilio = campoDomicilio.Text.ToUpper
        End If
    End Sub

    Private Sub campoLugar_n_TextChanged(sender As Object, e As EventArgs) Handles campoLugar_n.TextChanged
        If campoLugar_n.Text <> "" Then
            ema.lugar_n = campoLugar_n.Text.ToUpper
        End If
    End Sub

    Private Sub campoTrab_ant_TextChanged(sender As Object, e As EventArgs) Handles campoTrab_ant.TextChanged
        If campoTrab_ant.Text <> "" Then
            ema.trab_ant = campoTrab_ant.Text.ToUpper
        End If
    End Sub


    Private Sub campoNombre_TextChanged(sender As Object, e As EventArgs) Handles campoNombre.TextChanged
        If campoNombre.Text <> "" Then
            ema.nombre = campoNombre.Text.ToUpper
            ema.nombres = ema.apaterno & "," & ema.amaterno & "," & ema.nombre
        End If
    End Sub

    Private Sub campoApaterno_TextChanged(sender As Object, e As EventArgs) Handles campoApaterno.TextChanged
        If campoApaterno.Text <> "" Then
            ema.apaterno = campoApaterno.Text.ToUpper
            ema.nombres = ema.apaterno & "," & ema.amaterno & "," & ema.nombre
        End If
    End Sub

    Private Sub campoAmaterno_TextChanged(sender As Object, e As EventArgs) Handles campoAmaterno.TextChanged
        If campoAmaterno.Text <> "" Then
            ema.amaterno = campoAmaterno.Text.ToUpper
            ema.nombres = ema.apaterno & "," & ema.amaterno & "," & ema.nombre
        End If
    End Sub

    Private Sub campoEdad_TextChanged(sender As Object, e As EventArgs) Handles campoEdad.TextChanged
        If campoEdad.Text <> "" Then
            ema.edad = Integer.Parse(campoEdad.Text)
        End If
    End Sub

    Private Sub campoEsc_anos_TextChanged(sender As Object, e As EventArgs) Handles campoEsc_anos.TextChanged
        If campoEsc_anos.Text <> "" Then
            ema.esc_anos = Integer.Parse(campoEsc_anos.Text)
        End If
    End Sub

    Private Sub comboEscolaridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboEscolaridad.SelectedIndexChanged
        Try
            ema.escolaridad = comboEscolaridad.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboTA1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTA1.SelectedIndexChanged
        ema.ta1 = comboTA1.Text
    End Sub

    Private Sub comboTA2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTA2.SelectedIndexChanged
        ema.ta2 = comboTA2.Text
    End Sub

    Private Sub comboFC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFC.SelectedIndexChanged
        ema.fc = comboFC.Text
    End Sub

    Private Sub comboFR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFR.SelectedIndexChanged
        ema.fr = comboFR.Text
    End Sub

    Private Sub comboAgudezaVisual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAgudezaVisual.SelectedIndexChanged
        ema.agudezaVisual = comboAgudezaVisual.Text
    End Sub

    Private Sub campoPeso_TextChanged(sender As Object, e As EventArgs) Handles campoPeso.TextChanged
        If campoPeso.Text <> "" Then
            ema.peso = campoPeso.Text
            validarIMC()
        Else
            campoPeso.Text = "0.0"
        End If
    End Sub

    Private Sub campoAltura_TextChanged(sender As Object, e As EventArgs) Handles campoAltura.TextChanged
        If campoAltura.Text <> "" Then
            ema.altura = campoAltura.Text
            validarIMC()
        Else
            campoAltura.Text = "0.0"
        End If
    End Sub

    Private Sub campoIMC_TextChanged(sender As Object, e As EventArgs) Handles campoIMC.TextChanged
        If ema.imc < 18.5 Then
            labelIMC.Text = "Infrapeso"
            labelIMC.BackColor = Color.Gold
        ElseIf ema.imc >= 18.5 And ema.imc < 25 Then
            labelIMC.Text = "Normopeso"
            labelIMC.BackColor = Color.LimeGreen
        ElseIf ema.imc >= 25 And ema.imc < 27 Then
            labelIMC.Text = "Sobrepeso Grado I"
            labelIMC.BackColor = Color.Gold
        ElseIf ema.imc >= 27 And ema.imc < 30 Then
            labelIMC.Text = "Sobrepeso Grado II (Preobesidad)"
            labelIMC.BackColor = Color.Gold
        ElseIf ema.imc >= 30 And ema.imc < 35 Then
            labelIMC.Text = "Obesidad Tipo I"
            labelIMC.BackColor = Color.IndianRed
        ElseIf ema.imc >= 35 And ema.imc < 40 Then
            labelIMC.Text = "Obesidad Tipo II"
            labelIMC.BackColor = Color.IndianRed
        ElseIf ema.imc >= 49 Then
            labelIMC.Text = "Obesidad Tipo III (Mórbida)"
            labelIMC.BackColor = Color.IndianRed
        End If
    End Sub


    Private Sub campoAHF_TextChanged(sender As Object, e As EventArgs) Handles campoAHF.TextChanged
        ema.ahf = campoAHF.Text.ToUpper
    End Sub

    Private Sub campoDeportes_TextChanged(sender As Object, e As EventArgs) Handles campoDeportes.TextChanged
        ema.deportes = campoDeportes.Text.ToUpper
    End Sub

    Private Sub campoAPP_TextChanged(sender As Object, e As EventArgs) Handles campoAPP.TextChanged
        ema.app = campoAPP.Text.ToUpper
    End Sub

    Private Sub campoIPAS_TextChanged(sender As Object, e As EventArgs) Handles campoIPAS.TextChanged
        ema.ipas = campoIPAS.Text.ToUpper
    End Sub

    Private Sub comboMenarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboMenarca.SelectedIndexChanged
        ema.menarca = Integer.Parse(comboMenarca.Text)
    End Sub

    Private Sub comboCiclo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCiclo.SelectedIndexChanged
        ema.ciclo_menstrual = comboCiclo.Text
    End Sub

    Private Sub comboIVSA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboIVSA.SelectedIndexChanged
        ema.ivsa = comboIVSA.Text
    End Sub

    Private Sub validarGestas()
        If ema.paras + ema.abortos + ema.cesareas = ema.gestas Then
            comboGestas.BackColor = Color.LimeGreen
        Else
            comboGestas.BackColor = Color.Gold
        End If
    End Sub

    Private Sub comboGestas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboGestas.SelectedIndexChanged
        ema.gestas = Integer.Parse(comboGestas.Text)
    End Sub

    Private Sub comboParas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboParas.SelectedIndexChanged
        ema.paras = Integer.Parse(comboParas.Text)
        validarGestas()
    End Sub

    Private Sub comboAbortos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAbortos.SelectedIndexChanged
        ema.abortos = Integer.Parse(comboAbortos.Text)
        validarGestas()
    End Sub

    Private Sub comboCesareas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCesareas.SelectedIndexChanged
        ema.cesareas = Integer.Parse(comboCesareas.Text)
        validarGestas()
    End Sub

    Private Sub comboMPF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboMPF.SelectedIndexChanged
        Try
            ema.mpf = comboMPF.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboTabaquismo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTabaquismo.SelectedIndexChanged
        ema.tabaquismo = comboTabaquismo.Text
    End Sub

    Private Sub comboAlcoholismo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAlcoholismo.SelectedIndexChanged
        ema.alcoholismo = comboAlcoholismo.Text
    End Sub

    Private Sub comboToxico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboToxico.SelectedIndexChanged
        ema.toxico = comboToxico.Text
    End Sub

    Private Sub cbInmunizaciones_CheckedChanged(sender As Object, e As EventArgs) Handles cbInmunizaciones.CheckedChanged
        ema.inmun_comp = cbInmunizaciones.Checked
    End Sub

    Private Sub comboSustancias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSustancias.SelectedIndexChanged
        ema.substancia = comboSustancias.Text
    End Sub

    Private Sub campoCraneo_TextChanged(sender As Object, e As EventArgs) Handles campoCraneo.TextChanged
        ema.craneo = campoCraneo.Text.ToUpper
    End Sub

    Private Sub campoConjuntiva_TextChanged(sender As Object, e As EventArgs) Handles campoConjuntiva.TextChanged
        ema.conjuntiva = campoConjuntiva.Text.ToUpper
    End Sub

    Private Sub campoAud_TextChanged(sender As Object, e As EventArgs) Handles campoAud.TextChanged
        ema.aud = campoAud.Text.ToUpper
    End Sub

    Private Sub campoNariz_TextChanged(sender As Object, e As EventArgs) Handles campoNariz.TextChanged
        ema.nariz = campoNariz.Text.ToUpper
    End Sub

    Private Sub campoOrofaringe_TextChanged(sender As Object, e As EventArgs) Handles campoOrofaringe.TextChanged
        ema.orofaringe = campoOrofaringe.Text.ToUpper
    End Sub

    Private Sub campoCuello_TextChanged(sender As Object, e As EventArgs) Handles campoCuello.TextChanged
        ema.cuello = campoCuello.Text.ToUpper
    End Sub

    Private Sub campoTorax_TextChanged(sender As Object, e As EventArgs) Handles campoTorax.TextChanged
        ema.torax = campoTorax.Text.ToUpper
    End Sub

    Private Sub campoAbdomen_TextChanged(sender As Object, e As EventArgs) Handles campoAbdomen.TextChanged
        ema.abdomen = campoAbdomen.Text.ToUpper
    End Sub

    Private Sub campoGenitales_TextChanged(sender As Object, e As EventArgs) Handles campoGenitales.TextChanged
        ema.genitales = campoGenitales.Text.ToUpper
    End Sub

    Private Sub campoExtremidad_TextChanged(sender As Object, e As EventArgs) Handles campoExtremidad.TextChanged
        ema.extremidad = campoExtremidad.Text.ToUpper
    End Sub

    Private Sub campoLaboratorio_TextChanged(sender As Object, e As EventArgs) Handles campoLaboratorio.TextChanged
        ema.laboratorio = campoLaboratorio.Text.ToUpper
    End Sub

    Private Sub campoConclusion_TextChanged(sender As Object, e As EventArgs) Handles campoComentario.TextChanged
        ema.comentario = campoComentario.Text.ToUpper
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("examen_medico", "folio", ema.folio, dtExamenMedico, "sermed")
        If dtExamenMedico.Rows().Count > 0 Then
            Dim folio As String = dtExamenMedico.Rows(0)("folio")
            cargarDatos(folio)
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("examen_medico", "folio", ema.folio, dtExamenMedico, "sermed")
        If dtExamenMedico.Rows().Count > 0 Then
            Dim folio As String = dtExamenMedico.Rows(0)("folio")
            cargarDatos(folio)
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("examen_medico", "folio", dtExamenMedico, "sermed")
        If dtExamenMedico.Rows().Count > 0 Then
            Dim folio As String = dtExamenMedico.Rows(0)("folio")
            cargarDatos(folio)
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("examen_medico", "folio", dtExamenMedico, "sermed")
        If dtExamenMedico.Rows().Count > 0 Then
            Dim folio As String = dtExamenMedico.Rows(0)("folio")
            cargarDatos(folio)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String, x As Integer
        Cod = Buscar("SERMED.dbo.examen_medico", "folio", "EXAMEN MEDICO", False)
        If Cod <> "CANCELAR" Then
            cargarDatos(Cod)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If btnEditar.Text = "Editar" Then

            campoNombre.Enabled = True
            campoApaterno.Enabled = True
            campoAmaterno.Enabled = True
            campoEdad.Enabled = True

            tmpFolio = ema.folio

            Me.TabPage1.Enabled = True
            Me.TabPage2.Enabled = True
            Me.TabPage3.Enabled = True

            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"
        Else
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
            cargarDatos(tmpFolio)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If btnNuevo.Text = "Agregar" Then

            tmpFolio = ema.folio

            cargarDatos("nuevo")

            campoNombre.Enabled = True
            campoApaterno.Enabled = True
            campoAmaterno.Enabled = True
            campoEdad.Enabled = True

            Me.TabPage1.Enabled = True
            Me.TabPage2.Enabled = True
            Me.TabPage3.Enabled = True

            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"
        Else

            If ema.abortos + ema.paras + ema.cesareas = ema.gestas Then
                ema.evaluado = True
                ema.hora_captura = Date.Now
                ema.guardar()
                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
                cargarDatos(ema.folio)
            Else
                MsgBox("El número de gestaciones no coincide", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MsgBox("¿Desea eliminar el registro del folio " & ema.folio & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            If ema.nuevo = False Then
                ema.eliminar()
                btnPrev.PerformClick()
            Else
                cargarDatos("nuevo")
            End If
        End If
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click
        Transferir.Show()
    End Sub

    Private Sub campoNombre_Click(sender As Object, e As EventArgs) Handles campoNombre.Click
        campoNombre.SelectAll()
    End Sub

    Private Sub campoApaterno_Click(sender As Object, e As EventArgs) Handles campoApaterno.Click
        campoApaterno.SelectAll()
    End Sub

    Private Sub campoAmaterno_Click(sender As Object, e As EventArgs) Handles campoAmaterno.Click
        campoAmaterno.SelectAll()
    End Sub

    Private Sub campoEdad_Click(sender As Object, e As EventArgs) Handles campoEdad.Click
        campoEdad.SelectAll()
    End Sub

    Private Sub campoEsc_anos_Click(sender As Object, e As EventArgs) Handles campoEsc_anos.Click
        campoEsc_anos.SelectAll()
    End Sub

    Private Sub campoDomicilio_Click(sender As Object, e As EventArgs) Handles campoDomicilio.Click
        campoDomicilio.SelectAll()
    End Sub

    Private Sub campoTrab_ant_Click(sender As Object, e As EventArgs) Handles campoTrab_ant.Click
        campoTrab_ant.SelectAll()
    End Sub

    Private Sub campoLugar_n_Click(sender As Object, e As EventArgs) Handles campoLugar_n.Click
        campoLugar_n.SelectAll()
    End Sub

    Private Sub campoAHF_Click(sender As Object, e As EventArgs) Handles campoAHF.Click
        campoAHF.SelectAll()
    End Sub

    Private Sub campoDeportes_Click(sender As Object, e As EventArgs) Handles campoDeportes.Click
        campoDeportes.SelectAll()
    End Sub

    Private Sub campoAPP_Click(sender As Object, e As EventArgs) Handles campoAPP.Click
        campoAPP.SelectAll()
    End Sub

    Private Sub campoIPAS_Click(sender As Object, e As EventArgs) Handles campoIPAS.Click
        campoIPAS.SelectAll()
    End Sub

    Private Sub campoAPNP_Click(sender As Object, e As EventArgs) Handles campoAPNP.Click
        campoAPNP.SelectAll()
    End Sub

    Private Sub campoPeso_Click(sender As Object, e As EventArgs) Handles campoPeso.Click
        campoPeso.SelectAll()
    End Sub

    Private Sub campoAltura_Click(sender As Object, e As EventArgs) Handles campoAltura.Click
        campoAltura.SelectAll()
    End Sub

    Private Sub campoCraneo_Click(sender As Object, e As EventArgs) Handles campoCraneo.Click
        campoCraneo.SelectAll()
    End Sub

    Private Sub campoConjuntiva_Click(sender As Object, e As EventArgs) Handles campoConjuntiva.Click
        campoConjuntiva.SelectAll()
    End Sub

    Private Sub campoNariz_Click(sender As Object, e As EventArgs) Handles campoNariz.Click
        campoNariz.SelectAll()
    End Sub

    Private Sub campoOrofaringe_Click(sender As Object, e As EventArgs) Handles campoOrofaringe.Click
        campoOrofaringe.SelectAll()
    End Sub

    Private Sub campoCuello_Click(sender As Object, e As EventArgs) Handles campoCuello.Click
        campoCuello.SelectAll()
    End Sub

    Private Sub campoTorax_Click(sender As Object, e As EventArgs) Handles campoTorax.Click
        campoTorax.SelectAll()
    End Sub

    Private Sub campoAbdomen_Click(sender As Object, e As EventArgs) Handles campoAbdomen.Click
        campoAbdomen.SelectAll()
    End Sub

    Private Sub campoGenitales_Click(sender As Object, e As EventArgs) Handles campoGenitales.Click
        campoGenitales.SelectAll()
    End Sub

    Private Sub campoExtremidad_Click(sender As Object, e As EventArgs) Handles campoExtremidad.Click
        campoExtremidad.SelectAll()
    End Sub

    Private Sub campoLaboratorio_Click(sender As Object, e As EventArgs) Handles campoLaboratorio.Click
        campoLaboratorio.SelectAll()
    End Sub

    Private Sub campoComentariosAntidoping_Click(sender As Object, e As EventArgs) Handles campoComentariosAntidoping.Click
        campoComentariosAntidoping.SelectAll()
    End Sub

    Private Sub campoConclusion_Click(sender As Object, e As EventArgs) Handles campoComentario.Click
        campoComentario.SelectAll()
    End Sub

    Private Sub campoResumenGinecologico_Click(sender As Object, e As EventArgs) Handles campoResumenGinecologico.Click
        campoResumenGinecologico.SelectAll()
    End Sub

    Private Sub campoResumenGinecologico_TextChanged(sender As Object, e As EventArgs) Handles campoResumenGinecologico.TextChanged
        ema.resumen = campoResumenGinecologico.Text
    End Sub

    Private Sub campoAPNP_TextChanged(sender As Object, e As EventArgs) Handles campoAPNP.TextChanged
        ema.apnp = campoAPNP.Text.ToUpper
    End Sub

    Private Sub campoComentariosAntidoping_TextChanged(sender As Object, e As EventArgs) Handles campoComentariosAntidoping.TextChanged
        ema.comentario_antidoping = Me.campoComentariosAntidoping.Text.ToUpper
    End Sub

    Private Sub campoConclusion_TextChanged_1(sender As Object, e As EventArgs) Handles campoConclusion.TextChanged
        ema.conclusion = campoConclusion.Text.ToUpper
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub
End Class

'update examen_medico set antidoping = 'NEG' where antidoping = '      PPE-NEGATIVO,17NOV.05'

'select folio, antidoping, substancia from examen_medico where ANTIDOPING != 'NEG' order by ANTIDOPING

'select SERMED.dbo.examen_medico.folio, personal.dbo.personal.reloj, SERMED.dbo.examen_medico.sexo, SERMED.dbo.examen_medico.nombres, SERMED.dbo.examen_medico.ginecologia from SERMED.dbo.examen_medico left join PERSONAL.dbo.personal on PERSONAL.dbo.personal.nombres = SERMED.dbo.examen_medico.nombres where SERMED.dbo.examen_medico.sexo = 'f' and SERMED.dbo.examen_medico.ginecologia != '' and personal.dbo.personal.reloj is not null

Public Class ExamenMedico
    ' informacion de archivo

    Public nuevo As Boolean = True

    Public folio As String = "00000"

    Public fecha As Date = Date.Now.Date

    'datos personales
    Public nombre As String = ""

    Public apaterno As String = ""

    Public amaterno As String = ""

    Public nombres As String = ""

    Public sexo As String = "M"

    Public edad As Integer = 18

    Public edo_civil As String = "S"

    Public domicilio As String = ""

    Public religion As String = "C"

    Public trab_ant As String = "Maquiladora"

    Public lugar_n As String = "Ciudad Juárez"

    Public escolaridad As String = "01"

    Public esc_anos As Integer = 0

    'indices
    Public ta1 As String = "110"

    Public ta2 As String = "60"

    Public fc As String = "65"

    Public fr As String = "20"

    Public peso As Double = 0

    Public altura As Double = 0

    Public imc As Double = 0

    Public agudezaVisual As String = "100"


    'datos patologicos
    'Public ahf As String = "Sin datos patológicos"
    Public ahf As String = "Sin datos patológicos"

    Public tabaquismo As String = "NEG"

    Public alcoholismo As String = "NEG"

    Public toxico As String = "NEG"

    Public apnp As String = "Sin Antecedentes"

    Public inmun_comp As Boolean = True

    Public deportes As String = "Ninguno"

    Public app As String = "Sin datos patológicos"

    Public ipas As String = "Sin datos patológicos"


    'antescedentes ginecologicos
    Public menarca As String = ""

    Public ciclo_menstrual As String = ""

    Public ivsa As String = ""

    Public gestas As Integer = 0

    Public paras As Integer = 0

    Public abortos As Integer = 0

    Public cesareas As Integer = 0

    Public mpf As String = ""

    Public resumen As String = ""


    'cabeza
    Public craneo As String = "Normal"

    Public nariz As String = "Normal"

    Public orofaringe As String = "Normal"

    Public aud As String = "Normal"

    Public conjuntiva As String = "Normal"


    ' ? ? ? 
    Public cuello As String = "Normal"

    Public torax As String = "Normal"

    Public abdomen As String = "Normal"

    Public genitales As String = "Normal"

    Public extremidad As String = "Normal"

    Public laboratorio As String = ""

    Public antidoping As String = "NEG"

    Public substancia As String = ""

    Public comentario_antidoping As String = ""


    'conclusion
    Public conclusion As String = ""

    Public comentario As String = ""

    Public apto As Boolean = False

    Public evaluado As Boolean = True

    Public usuario As String = ""

    Public hora_captura As DateTime = Date.Now

    Sub New()
        Dim dtFolio As DataTable = sqlExecute("select top 1 folio from examen_medico order by folio desc", "sermed")
        If dtFolio.Rows.Count > 0 Then
            Me.folio = completar(Integer.Parse(dtFolio(0)("folio")) + 1, 5)
        End If
    End Sub

    Private Function completar(numero As Integer, caracteres As Integer) As String
        Dim s As String = numero.ToString
        While (s.Length < caracteres)
            s = "0" + s
        End While
        Return s
    End Function

    Sub New(row As DataRow)

        nuevo = False

        'informacion de archivo
        Try
            folio = row("folio")

            fecha = row("fecha")
        Catch ex As Exception

        End Try

        'datos personales
        Try
            nombre = row("nombre")

            apaterno = row("apaterno")

            amaterno = row("amaterno")

            nombres = row("nombres")

            sexo = row("sexo")

            edad = Integer.Parse(row("edad"))

            edo_civil = row("edo_civil")

            domicilio = row("domicilio")

            religion = row("religion")

            trab_ant = row("trab_ant")

            lugar_n = row("lugar_n")

            escolaridad = row("escolaridad")

            esc_anos = row("esc_anos")
        Catch ex As Exception

        End Try

        'indices
        Try
            ta1 = row("ta1")

            ta2 = row("ta2")

            fc = row("fc")

            fr = row("fr")

            peso = row("peso")

            altura = Double.Parse(row("altura"))

            imc = Double.Parse(row("imc"))

            agudezaVisual = row("agudeza_visual")
        Catch ex As Exception

        End Try

        'datos patologicos
        Try
            ahf = row("ahf")

            tabaquismo = row("tabaquismo")

            alcoholismo = row("alcoholismo")

            toxico = row("toxico")

            apnp = row("apnp")

            inmun_comp = IIf(row("inmun_comp").Equals("Y"), True, False)

            deportes = row("deportes")

            app = row("app")

            ipas = row("ipas")
        Catch ex As Exception

        End Try

        'antescedentes ginecologicos
        Try

            resumen = row("ginecologia")

            ivsa = row("ivsa")

            menarca = Integer.Parse(row("menarca"))

            ciclo_menstrual = row("ciclo_menstrual")



            gestas = Integer.Parse(row("gestas"))

            paras = Integer.Parse(row("paras"))

            abortos = Integer.Parse(row("abortos"))

            cesareas = Integer.Parse(row("cesareas"))

            mpf = row("mpf")

        Catch ex As Exception

        End Try

        'cabeza
        Try
            craneo = row("craneo")

            nariz = row("nariz")

            orofaringe = row("orofaringe")

            aud = row("aud")

            conjuntiva = row("conjuntiva")
        Catch ex As Exception

        End Try

        ' ? ? ? 
        Try
            cuello = IIf(Not IsDBNull(row("cuello")), row("cuello"), "")

            torax = row("torax")

            abdomen = row("abdomen")

            genitales = row("genitales")

            extremidad = row("extremidad")

            laboratorio = row("laboratorio")

            antidoping = row("antidoping")

            substancia = row("substancia")

            comentario_antidoping = row("comentario_antidoping")
        Catch ex As Exception

        End Try

        ' conclusiones
        Try
            comentario = row("comentario")

            conclusion = row("conclusion")

            apto = IIf(row("apto").Equals("Y"), True, False)

            hora_captura = row("hora_captura")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub eliminar()
        If Not nuevo Then
            sqlExecute("delete from examen_medico where folio = '" & Me.folio & "'", "sermed")
        End If
    End Sub

    Public Sub guardar()
        ' select folio, fecha, nombre, apaterno, amaterno, nombres, sexo, edad, edo_civil,domicilio, religion, trab_ant, lugar_n, escolarida, esc_anos from examen_medico

        'registro
        If nuevo Then
            sqlExecute("insert into examen_medico " & _
                   " (folio, fecha, nombre, apaterno, amaterno, nombres, edad)" & _
                   " values " & _
                   " ('" & Me.folio & "', '" + FechaSQL(Me.fecha) + "', '" & Me.nombre & "', '" & Me.apaterno & "', '" & Me.amaterno & "', '" & Me.nombres & "', '" & Me.edad & "')", "sermed")
        End If

        'datos personales
        sqlExecute("update examen_medico set sexo = '" + Me.sexo + "', edo_civil = '" + Me.edo_civil + "', religion = '" + Me.religion + "', escolaridad = '" + Me.escolaridad + "', esc_anos = '" + Me.esc_anos.ToString + "', domicilio = '" + Me.domicilio + "', trab_ant = '" + Me.trab_ant + "', lugar_n = '" + Me.lugar_n + "' where folio = '" + Me.folio + "'", "sermed")
        'datos patologicos
        sqlExecute("update examen_medico set ahf = '" + Me.ipas + "', deportes = '" + Me.deportes + "', app = '" + Me.app + "', ipas = '" + Me.ipas + "', apnp = '" + Me.apnp + "', tabaquismo = '" + Me.tabaquismo + "', alcoholismo = '" + Me.alcoholismo + "', toxico = '" + Me.toxico + "', inmun_comp = '" + IIf(Me.inmun_comp, "Y", "N") + "' where folio = '" + Me.folio + "'", "sermed")
        'datos ginecologicos
        sqlExecute("update examen_medico set menarca = '" + Me.menarca + "', ciclo_menstrual = '" + Me.ciclo_menstrual + "', ivsa = '" + Me.ivsa + "', gestas = '" + Me.gestas.ToString + "', paras = '" + Me.paras.ToString + "', abortos = '" + Me.abortos.ToString + "', cesareas = '" + Me.cesareas.ToString + "', mpf = '" + Me.mpf + "', ginecologia  = '" + Me.resumen + "' where folio = '" + Me.folio + "'", "sermed")
        'indices
        sqlExecute("update examen_medico set ta1 = '" + Me.ta1 + "', ta2 = '" + Me.ta2 + "', fc = '" + Me.fc + "', fr = '" + Me.fr + "', agudeza_visual = '" + Me.agudezaVisual + "', peso = '" + Me.peso.ToString + "', altura = '" + Me.altura.ToString + "', imc = '" + Me.imc.ToString + "' where folio = '" + Me.folio + "'", "sermed")
        'cabeza
        sqlExecute("update examen_medico set craneo = '" + Me.craneo + "', conjuntiva = '" + Me.conjuntiva + "', aud = '" + Me.aud + "', nariz = '" + Me.nariz + "', orofaringe = '" + Me.orofaringe + "'where folio = '" + Me.folio + "'", "sermed")
        'cuerpo
        sqlExecute("update examen_medico set cuello = '" + Me.cuello + "', torax = '" + Me.torax + "', abdomen = '" + Me.abdomen + "', genitales = '" + Me.genitales + "', extremidad = '" + Me.extremidad + "' where folio = '" + Me.folio + "'", "sermed")
        'laboratorio
        sqlExecute("update examen_medico set laboratorio = '" + Me.laboratorio + "', antidoping = '" + Me.antidoping + "', substancia = '" + Me.substancia + "', comentario_antidoping = '" + Me.comentario_antidoping + "'where folio = '" + Me.folio + "'", "sermed")
        'conclusiones
        sqlExecute("update examen_medico set comentario = '" + Me.comentario + "', conclusion = '" + Me.conclusion + "', hora_captura = '" + Me.hora_captura + "', apto = '" + IIf(Me.apto, "Y", "N") + "', evaluado = '" + IIf(Me.evaluado, "Y", "N") + "', usuario = '" + IIf(Declaraciones.Usuario <> "", Declaraciones.Usuario, "PIDA") + "' where folio = '" + Me.folio + "'", "sermed")
    End Sub

End Class