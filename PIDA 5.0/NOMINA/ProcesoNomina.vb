Imports System.IO
Imports OfficeOpenXml
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Data.SQLite
'Imports Devart.Data.SQLite.SQLiteConnection

Public Enum stepsData
    INICIALIZAR = 1
    PROCESAR = 2
    ASENTAR = 3
End Enum

Structure strBool
    Shared sTrue = "True"
    Shared sFalse = "False"
    Shared Function getValue(val As String) As Boolean
        Return val = sTrue Or val = "1"
    End Function
End Structure

Public Enum logType
    INFO = 1
    WARN = 2
    ERR = 3
End Enum

''' <summary>
''' Clase contenedora del proceso de la nómina
''' </summary>
''' <remarks></remarks>
Public Class ProcesoNomina

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

#Region "Vars"
    'Pasos del proceso
    Private _steps As New Dictionary(Of Integer, String) From {{stepsData.INICIALIZAR, "Inicializar"},
                                                               {stepsData.PROCESAR, "Procesar"},
                                                               {stepsData.ASENTAR, "Asentar"}}

    '-- Pasos de proceso cuando sea periodo especial (como aguinaldo) -- Ernesto -- 29 nov 2023
    Private _steps2 As New Dictionary(Of Integer, String) From {{stepsData.INICIALIZAR, "Inicializar especial"},
                                                                {stepsData.PROCESAR, "Procesar"},
                                                                {stepsData.ASENTAR, "Asentar"}}


    'Listado de imagenes a utilizar en el tree de los pasos del proceso
    Private _imgLst As New ImageList
    'Formato de la fecha de los logs
    Private _dateFormat = "dd/MM/yyyy HH:mm" ':ss ffffzzz
    'Listado de logs
    Private _logs As New Dictionary(Of String, String)
    'Datos del periodo en que se procesa
    Private period As New Dictionary(Of String, String)

    'Mensajes que se incluyen en los logs
    Private _logsMsg As New Dictionary(Of String, String) From {{"NEXTSTAGE", "Aplicado nuevo paso: {0}"},
                                                                {"RESTARTSTAGES", "Reiniciado el proceso"}}

    Private _globalVars As New Dictionary(Of String, Decimal) From {{"_acum_base_pago", 0},
                                                                    {"_acum_base_pago_comp", 0},
                                                                    {"_porcentaje_despensa", 0},
                                                                    {"_acum_neto", 0}}

    'Opciones de interfaz, se llenan en frmProcesoNominaOpciones -- Se agrego var aguinaldo anual y aguinaldo fecha -- Ernesto -- 29 nov 2023
    Dim _options As New Dictionary(Of String, Object) From {{"aplica_vales_despensa_finiquitos", False},
                                                            {"validar_psg_5hrs", False},
                                                            {"incluir_bondes", False},
                                                            {"periodo_aguinaldo", False},
                                                            {"descuento_sindical", False},
                                                            {"sua_pagado_mes_anterior", False},
                                                            {"incluir_ajuste_subsidio", False},
                                                            {"empleados_descuento_defuncion", ""},
                                                            {"incluir_aguinaldo_proporcional", False},
                                                            {"aguinaldo_anual", False},
                                                            {"aguinaldo_fecha", ""}}

    Dim filter As String = Nothing
    Public canceled As Boolean = False

    '-- Variable compartida para saber si ya se pago aguinaldo anual -- Ernesto -- 13 dic 2023
    Public Shared sePagoAguiAnual As Boolean = False

    '-- Variables globales para calculo normal y compensacion
    Dim dtMovsProLocal As New DataTable
    Dim dtMovsCompLocal As New DataTable
#End Region

#Region "Members"
    Private _bgWorker As System.ComponentModel.BackgroundWorker = Nothing
#End Region

#Region "Properties"

    Public ReadOnly Property PeriodoInfo As Dictionary(Of String, String)
        Get
            Return Me.period
        End Get
    End Property


    Public ReadOnly Property Steps As Dictionary(Of Integer, String)
        Get
            Return Me._steps
        End Get
    End Property

    ''' <summary>
    ''' Propiedad para los pasos de periodo especial [aguinaldo] -- Ernesto -- 19 oct 2023
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Steps2 As Dictionary(Of Integer, String)
        Get
            Return Me._steps2
        End Get
    End Property


    Public Property Options As Dictionary(Of String, Object)
        Get
            Return Me._options
        End Get
        Set(value As Dictionary(Of String, Object))
            Me._options = value
        End Set
    End Property

    Public ReadOnly Property ImgList As ImageList
        Get
            Return Me._imgLst
        End Get
    End Property

    Public ReadOnly Property Logs As Dictionary(Of String, String)
        Get
            Return Me._logs
        End Get
    End Property

    Public ReadOnly Property LogsMsg As Dictionary(Of String, String)
        Get
            Return Me._logsMsg
        End Get
    End Property

    Public Property BgWorker As System.ComponentModel.BackgroundWorker
        Get
            Return Me._bgWorker
        End Get
        Set(value As System.ComponentModel.BackgroundWorker)
            Me._bgWorker = value
        End Set
    End Property

    Public Property DateFormat As String
        Get
            Return Me._dateFormat
        End Get
        Set(value As String)
            Me._dateFormat = value
        End Set
    End Property

    Public ReadOnly Property allMiscelaneos As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM ajustesPro")
        End Get
    End Property

    Public ReadOnly Property DtRecib As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM dtRecib")
        End Get
    End Property

    Public ReadOnly Property NominaPro As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM nominaPro")
        End Get
    End Property

    Public ReadOnly Property MovimientosPro As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM movimientosPro")
        End Get
    End Property

    Public ReadOnly Property HorasPro As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM horasPro")
        End Get
    End Property

    Public ReadOnly Property conceptosPro As DataTable
        Get
            Return sqlExecute("SELECT * FROM nomina.dbo.conceptos")
        End Get
    End Property

    Public ReadOnly Property MtroDed As DataTable
        Get
            Return sqlExecute("SELECT * FROM nomina.dbo.mtro_ded")
        End Get
    End Property

    Public ReadOnly Property AjustesPro As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM ajustesPro")
        End Get
    End Property

    Public ReadOnly Property FiniquitosN As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM finiquitosN")
        End Get
    End Property


    Public ReadOnly Property PensionesAlimenticias As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM pensionesAlimenticias")
        End Get
    End Property

    Public ReadOnly Property PrimaVacDetalle As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM primaVacDetalle")
        End Get
    End Property

    Public ReadOnly Property AguinaldoExcento As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM aguinaldoExcento")
        End Get
    End Property

    Public ReadOnly Property MovimientosCompensacion As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM movimientosCompensacion")
        End Get
    End Property

    Public ReadOnly Property AjustesSubsidio As DataTable
        Get
            Return Sqlite.getInstance().sqliteExecute("SELECT * FROM ajustesSubsidio")
        End Get
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        _imgLst.Images.Add(PIDA.My.Resources.Resources.Process32A)
        _imgLst.Images.Add(PIDA.My.Resources.Resources.Accept32)

        'Creando _nominaPro vacia
        Dim _nominaPro As New DataTable
        _nominaPro.Columns.Add("cod_comp", GetType(System.String))
        _nominaPro.Columns.Add("procesar", GetType(System.Boolean))
        _nominaPro.Columns.Add("retiro_fah", GetType(System.Boolean))
        _nominaPro.Columns.Add("folio", GetType(System.Int32))
        _nominaPro.Columns.Add("pagina", GetType(System.Int32))
        _nominaPro.Columns.Add("cod_tipo_nomina", GetType(System.String))
        _nominaPro.Columns.Add("cod_pago", GetType(System.String))
        _nominaPro.Columns.Add("periodo", GetType(System.String))
        _nominaPro.Columns.Add("ano", GetType(System.String))
        _nominaPro.Columns.Add("reloj", GetType(System.String))
        _nominaPro.Columns.Add("nombres", GetType(System.String))
        _nominaPro.Columns.Add("mes", GetType(System.String))
        _nominaPro.Columns.Add("sactual", GetType(System.Double))
        _nominaPro.Columns.Add("integrado", GetType(System.Double))
        _nominaPro.Columns.Add("cod_depto", GetType(System.String))
        _nominaPro.Columns.Add("cod_turno", GetType(System.String))
        _nominaPro.Columns.Add("cod_puesto", GetType(System.String))
        _nominaPro.Columns.Add("cod_super", GetType(System.String))
        _nominaPro.Columns.Add("cod_hora", GetType(System.String))
        _nominaPro.Columns.Add("cod_tipo", GetType(System.String))
        _nominaPro.Columns.Add("cod_clase", GetType(System.String))
        _nominaPro.Columns.Add("sindicalizado", GetType(System.Boolean))
        _nominaPro.Columns.Add("tipo_nomina", GetType(System.Char))
        _nominaPro.Columns.Add("alta", GetType(System.DateTime))
        _nominaPro.Columns.Add("baja", GetType(System.DateTime))
        _nominaPro.Columns.Add("alta_antig", GetType(System.DateTime))
        _nominaPro.Columns.Add("periodo_act", GetType(System.String))
        _nominaPro.Columns.Add("cod_cate", GetType(System.String))
        _nominaPro.Columns.Add("cod_tipo2", GetType(System.String))
        _nominaPro.Columns.Add("fah_participa", GetType(System.Boolean))
        _nominaPro.Columns.Add("fah_porcentaje", GetType(System.Double))
        _nominaPro.Columns.Add("infonavit_credito", GetType(System.String))
        _nominaPro.Columns.Add("tipo_credito", GetType(System.String))
        _nominaPro.Columns.Add("cuota_credito", GetType(System.Double))
        _nominaPro.Columns.Add("cobro_segviv", GetType(System.Boolean))
        _nominaPro.Columns.Add("inicio_credito", GetType(System.DateTime))
        _nominaPro.Columns.Add("calculado", GetType(System.Boolean))
        _nominaPro.Columns.Add("retiro_parcial", GetType(System.Boolean))
        _nominaPro.Columns.Add("cuenta1", GetType(System.String))
        _nominaPro.Columns.Add("monto_retiro", GetType(System.Double))
        _nominaPro.Columns.Add("curp", GetType(System.String))
        _nominaPro.Columns.Add("cod_area", GetType(System.String))
        _nominaPro.Columns.Add("privac_porc", GetType(System.Double))
        _nominaPro.Columns.Add("privac_dias", GetType(System.Double))
        _nominaPro.Columns.Add("factor_dias", GetType(System.Double))
        _nominaPro.Columns.Add("dias_habiles", GetType(System.Int32))
        _nominaPro.Columns.Add("vales_cta", GetType(System.String))
        _nominaPro.Columns.Add("vales_tarj", GetType(System.String))
        _nominaPro.Columns.Add("sdo_cobertura", GetType(System.Double))
        _nominaPro.Columns.Add("incapacidad", GetType(System.Int32))
        _nominaPro.Columns.Add("faltas", GetType(System.Int32))
        _nominaPro.Columns.Add("vacaciones", GetType(System.Int32))
        _nominaPro.Columns.Add("cod_clerk", GetType(System.String))
        _nominaPro.Columns.Add("finiquito", GetType(System.Boolean))
        _nominaPro.Columns.Add("finiquito_esp", GetType(System.Boolean))
        _nominaPro.Columns.Add("permiso", GetType(System.Int32))
        Sqlite.getInstance().createTable(_nominaPro, "nominaPro")

        'creando _movimientosCompensacion vacia
        Dim _movimientosCompensacion As New DataTable
        _movimientosCompensacion.Columns.Add("ano", GetType(System.String))
        _movimientosCompensacion.Columns.Add("periodo", GetType(System.String))
        _movimientosCompensacion.Columns.Add("tipo_nomin", GetType(System.String))
        _movimientosCompensacion.Columns.Add("reloj", GetType(System.String))
        _movimientosCompensacion.Columns.Add("concepto", GetType(System.String))
        _movimientosCompensacion.Columns.Add("monto", GetType(System.Double))
        _movimientosCompensacion.Columns.Add("prioridad", GetType(System.Int32))
        _movimientosCompensacion.Columns.Add("importar", GetType(System.Boolean))
        _movimientosCompensacion.Columns.Add("nuevo", GetType(System.String))
        _movimientosCompensacion.Columns.Add("periodo_ac", GetType(System.String))
        _movimientosCompensacion.Columns.Add("tipo_comp", GetType(System.String))
        Sqlite.getInstance().createTable(_movimientosCompensacion, "movimientosCompensacion")

        'creando _movimientosPro vacio
        Dim _movimientosPro As New DataTable
        _movimientosPro.Columns.Add("ano", GetType(System.String))
        _movimientosPro.Columns.Add("periodo", GetType(System.String))
        _movimientosPro.Columns.Add("tipo_nomina", GetType(System.String))
        _movimientosPro.Columns.Add("reloj", GetType(System.String))
        _movimientosPro.Columns.Add("concepto", GetType(System.String))
        _movimientosPro.Columns.Add("monto", GetType(System.Double))
        _movimientosPro.Columns.Add("prioridad", GetType(System.Int32))
        _movimientosPro.Columns.Add("importar", GetType(System.Boolean))
        _movimientosPro.Columns.Add("nuevo", GetType(System.String))
        _movimientosPro.Columns.Add("periodo_act", GetType(System.String))
        Sqlite.getInstance().createTable(_movimientosPro, "movimientosPro")

        'creando Horas pro vacia
        Dim _horasPro As New DataTable
        _horasPro.Columns.Add("reloj", GetType(System.String))
        _horasPro.Columns.Add("concepto", GetType(System.String))
        _horasPro.Columns.Add("descripcion", GetType(System.String))
        _horasPro.Columns.Add("monto", GetType(System.Double))
        _horasPro.Columns.Add("periodo", GetType(System.String))
        _horasPro.Columns.Add("ano", GetType(System.String))
        _horasPro.Columns.Add("usuario", GetType(System.String))
        _horasPro.Columns.Add("datetime", GetType(System.DateTime))
        _horasPro.Columns.Add("fecha", GetType(System.DateTime))
        _horasPro.Columns.Add("cod_hora", GetType(System.String))
        _horasPro.Columns.Add("factor", GetType(System.Double))
        Sqlite.getInstance().createTable(_horasPro, "horasPro")

        'creando Ajustes pro vacia
        Dim _ajustesPro As New DataTable
        _ajustesPro.Columns.Add("ano", GetType(System.String))
        _ajustesPro.Columns.Add("periodo", GetType(System.String))
        _ajustesPro.Columns.Add("reloj", GetType(System.String))
        _ajustesPro.Columns.Add("per_ded", GetType(System.String))
        _ajustesPro.Columns.Add("concepto", GetType(System.String))
        _ajustesPro.Columns.Add("descripcion", GetType(System.String))
        _ajustesPro.Columns.Add("monto", GetType(System.Double))
        _ajustesPro.Columns.Add("clave", GetType(System.String))
        _ajustesPro.Columns.Add("origen", GetType(System.String))
        _ajustesPro.Columns.Add("usuario", GetType(System.String))
        _ajustesPro.Columns.Add("datetime", GetType(System.DateTime))
        _ajustesPro.Columns.Add("afecta_vac", GetType(System.Boolean))
        _ajustesPro.Columns.Add("factor", GetType(System.Double))
        _ajustesPro.Columns.Add("fecha", GetType(System.String))
        _ajustesPro.Columns.Add("sueldo", GetType(System.Double))
        _ajustesPro.Columns.Add("fecha_fox", GetType(System.DateTime))
        _ajustesPro.Columns.Add("per_aplica", GetType(System.String))
        _ajustesPro.Columns.Add("ano_aplica", GetType(System.String))
        _ajustesPro.Columns.Add("saldo", GetType(System.Double))
        Sqlite.getInstance().createTable(_ajustesPro, "ajustesPro")

        'creando ajuste al subsidio
        Dim _ajustesSubsidio As New DataTable
        _ajustesSubsidio.Columns.Add("ano", GetType(System.String))
        _ajustesSubsidio.Columns.Add("periodo", GetType(System.String))
        _ajustesSubsidio.Columns.Add("reloj", GetType(System.String))
        _ajustesSubsidio.Columns.Add("concepto", GetType(System.String))
        _ajustesSubsidio.Columns.Add("monto", GetType(System.Double))
        _ajustesSubsidio.Columns.Add("origen", GetType(System.String))
        _ajustesSubsidio.Columns.Add("usuario", GetType(System.String))
        _ajustesSubsidio.Columns.Add("datetime", GetType(System.DateTime))
        Sqlite.getInstance().createTable(_ajustesSubsidio, "ajustesSubsidio")

        Dim _dRecib As New DataTable
        _dRecib.Columns.Add("reloj", GetType(System.String))
        _dRecib.Columns.Add("concepto", GetType(System.String))
        _dRecib.Columns.Add("monto", GetType(System.Double))
        _dRecib.Columns.Add("cod_naturaleza", GetType(System.Char))
        _dRecib.Columns.Add("credito", GetType(System.String))
        _dRecib.Columns.Add("semanas", GetType(System.Double))
        _dRecib.Columns.Add("saldo", GetType(System.Double))
        _dRecib.Columns.Add("fecha", GetType(System.DateTime))
        _dRecib.Columns.Add("factor", GetType(System.Double))
        _dRecib.Columns.Add("dobles", GetType(System.Double))
        _dRecib.Columns.Add("triples", GetType(System.Double))
        _dRecib.Columns.Add("semana_pago", GetType(System.String))
        _dRecib.Columns.Add("fecha_fox", GetType(System.DateTime))
        _dRecib.Columns.Add("detalles", GetType(System.String))
        Sqlite.getInstance().createTable(_dRecib, "dtRecib")

        'creando finiquitos N vacia
        Dim _finiquitosN As New DataTable
        _finiquitosN.Columns.Add("reloj", GetType(System.String))
        _finiquitosN.Columns.Add("cod_comp", GetType(System.String))
        _finiquitosN.Columns.Add("nombre", GetType(System.String))
        _finiquitosN.Columns.Add("cod_tipo", GetType(System.String))
        _finiquitosN.Columns.Add("baja", GetType(System.DateTime))
        _finiquitosN.Columns.Add("alta", GetType(System.DateTime))
        _finiquitosN.Columns.Add("sactual", GetType(System.String))
        _finiquitosN.Columns.Add("alta_vacacion", GetType(System.DateTime))
        _finiquitosN.Columns.Add("calculo", GetType(System.DateTime))
        _finiquitosN.Columns.Add("ano", GetType(System.String))
        _finiquitosN.Columns.Add("fecha_ini", GetType(System.DateTime))
        _finiquitosN.Columns.Add("fecha_fin", GetType(System.DateTime))
        _finiquitosN.Columns.Add("fecha_pago", GetType(System.DateTime))
        _finiquitosN.Columns.Add("last_period", GetType(System.String))
        _finiquitosN.Columns.Add("activo", GetType(System.String))
        _finiquitosN.Columns.Add("diasva", GetType(System.String))
        Sqlite.getInstance().createTable(_finiquitosN, "finiquitosN")

        'creando Pensiones alimenticias vacia
        Dim _pensionesAlimenticias As New DataTable
        _pensionesAlimenticias.Columns.Add("reloj", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("pensionado", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("porcentaje", GetType(System.Double))
        _pensionesAlimenticias.Columns.Add("tipo_pen", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("base_pen", GetType(System.Double))
        _pensionesAlimenticias.Columns.Add("fijo", GetType(System.Double))
        _pensionesAlimenticias.Columns.Add("cuenta", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("activo", GetType(System.Boolean))
        _pensionesAlimenticias.Columns.Add("apaterno", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("amaterno", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("nombre", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("cuaderno", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("num_pensio", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("cuenta_val", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("comentario", GetType(System.String))
        _pensionesAlimenticias.Columns.Add("inicio", GetType(System.DateTime))
        _pensionesAlimenticias.Columns.Add("suspension", GetType(System.DateTime))
        _pensionesAlimenticias.Columns.Add("mercantil", GetType(System.Boolean))
        Sqlite.getInstance().createTable(_pensionesAlimenticias, "pensionesAlimenticias")

        Dim _primaVacDetalle As New DataTable
        _primaVacDetalle.Columns.Add("reloj", GetType(System.String))
        _primaVacDetalle.Columns.Add("ano", GetType(System.String))
        _primaVacDetalle.Columns.Add("monto", GetType(System.Double))
        Sqlite.getInstance().createTable(_primaVacDetalle, "primaVacDetalle")

        Dim _aguinaldoExcento As New DataTable
        _aguinaldoExcento.Columns.Add("reloj", GetType(System.String))
        _aguinaldoExcento.Columns.Add("ano", GetType(System.String))
        _aguinaldoExcento.Columns.Add("monto", GetType(System.Double))
        Sqlite.getInstance().createTable(_aguinaldoExcento, "aguinaldoExcento")

        freeMemory()
    End Sub
#End Region

#Region "Funciones Proceso"

    ''' <summary>
    ''' Se almacena el msj del proceso de nomina en una tabla sql
    ''' </summary>
    ''' <param name="metodo">Origen del detalle</param>
    ''' <param name="msj">Comentario del detalle</param>
    ''' <remarks></remarks>
    Shared Sub log_proceso(metodo As String, msj As String, Optional err As String = "Error")
        Try
            Dim strQry = "insert into nomina.dbo.log_procnomina (metodo,usuario,fecha_hora,detalles,categoria) values ('" &
                          metodo & "','" & Usuario & "','" & Convert.ToDateTime(Date.Now) & "','" & msj & "','" & err & "')"
            sqlExecute(strQry)
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para limpiar memoria 
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub freeMemory()
        Try
            Dim memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Adicionar un log
    ''' </summary>
    ''' <param name="value">Texto del log.</param>
    ''' <remarks></remarks>
    Public Sub addLog(value As String, Optional type As logType = Nothing, Optional setTime As Boolean = True)
        Dim key = Date.Now.ToString(Me.DateFormat)
        'En el caso de que se haya incluido otro log en exactamente el mismo milisegundo, se cambia la llave para el diccionario
        While Me._logs.ContainsKey(key) : key &= " " : End While
        If setTime Then : Me._logs.Add(key, IIf(type = Nothing, value, key.Trim & ": " & value & ":" & type))
        Else : Me._logs.Add(key, IIf(type = Nothing, value, "".PadLeft(key.Length, ".") & ": " & value & ":" & logType.INFO))
        End If
    End Sub

    ''' <summary>
    ''' Limpiar todos los datos
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearData()
        Sqlite.getInstance.sqliteExecute("DELETE FROM nominaPro; " &
                                         "DELETE FROM horasPro; " &
                                         "DELETE FROM ajustesPro; " &
                                         "DELETE FROM ajustesSubsidio; " &
                                         "DELETE FROM movimientosPro; " &
                                         "DELETE FROM finiquitosN; " &
                                         "DELETE FROM dtRecib; " &
                                         "DELETE FROM movimientosCompensacion; " &
                                         "DELETE FROM pensionesAlimenticias; " &
                                         "DELETE FROM primaVacDetalle; ")
    End Sub

    ''' <summary>
    ''' Limpiar los logs
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearLog()
        Me._logs.Clear()
    End Sub


    ''' <summary>
    ''' Se cargan los ajustes de ajustes_nom
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <remarks></remarks>
    Public Sub Exportar(ByRef data As Dictionary(Of String, String))
        '-- Carga de miscelaneos se exportan los finiquitos normales --- No se incluira para CTE
        'Me.ExportarMiscelaneos(data)
        '-- Carga ajustes aca se exportan los _dRecib
        Me.ExportarAjustes(data)

        '--- Con carga de finiquitos normales
        Dim FIni As Date = Me.period("fecha_ini")
        Dim FFin As Date = Me.period("fecha_fin")
        Dim dtFiniquitosNormales = sqlExecute("SELECT cod_comp, reloj, nombres, cod_tipo, baja, sactual, alta, alta_vacacion FROM personalvw p " & _
                                                "WHERE (baja BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) &
                                                "' AND reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) " & _
                                                "AND (cod_comp in (" & data("codComp") & ")) AND DATEDIFF (d, alta, baja) >= 2 AND " & _
                                                "reloj NOT IN (SELECT b.reloj FROM bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                                "fecha_mantenimiento >'" & FechaHoraSQL(DateAdd(DateInterval.Minute, 3630, FFin)) & "' AND campo='baja' AND " & _
                                                "ValorNuevo IS NOT NULL AND ValorNuevo<>'' AND valoranterior<>valornuevo AND baja<='" & FechaSQL(FFin) & "')) " & _
                                                "OR reloj IN (SELECT reloj FROM PERSONAL.dbo.reingresos WHERE baja_ant BETWEEN '" & FechaSQL(FIni) & "' and '" & FechaSQL(FFin) & "') " & _
                                                "union " & _
                                                "SELECT p.cod_comp, b.reloj, p.nombres, p.cod_tipo, p.baja, p.sactual, p.alta, p.alta_vacacion " & _
                                                "FROM bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                                "b.reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) AND " & _
                                                "fecha_mantenimiento >= '" & FechaHoraSQL(DateAdd(DateInterval.Hour, 36, FIni)) & "' AND " & _
                                                "(cod_comp in (" & data("codComp") & ")) AND campo='baja' AND ValorNuevo IS NOT NULL " & _
                                                "AND ValorNuevo <>'' AND valoranterior <> valornuevo AND b.tipo_movimiento = 'B' AND " & _
                                                "baja < '" & FechaSQL(FIni) & "' AND DATEDIFF (d, alta,baja)>=2 ORDER BY baja ", "Personal")

        CargaFiniquitosNormales(dtFiniquitosNormales, data)

    End Sub

    ''' <summary>
    ''' Cargar finiquitos especiales a nomina
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="strFolio"></param>
    ''' <remarks></remarks>
    Public Shared Sub CargaFiniquitosEspeciales(ByRef data As Dictionary(Of String, String), Optional strFolio As String = "")
        Dim sql = "SELECT * FROM NOMINA.dbo.nomina_calculo WHERE finiq_especial_ano = '" & data("ano") & "' And " &
                  "finiq_especial_periodo = '" & data("periodo") & "' and finiq_especial_tipo = '" & data("tipoPeriodo") & "' " &
                  "ORDER BY reloj, folio"

        '-- Filtro para incorporar finiquitos especiales desde la interfaz
        If strFolio <> "" Then sql = "SELECT * FROM NOMINA.dbo.nomina_calculo where folio='" & strFolio & "'"
        Dim elements = sqlExecute(sql)

        If elements.Rows.Count > 0 Then

            Dim relojes = "(" & String.Join(",", (From i In elements.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ")"
            Dim last_periodos = sqlExecute("SELECT T.*, p.*, pe.BAJA FROM ( " &
                                          "SELECT reloj, MAX(n.ano +n.periodo) AS last_period " &
                                          "FROM NOMINA.dbo.nomina AS n " &
                                          "INNER JOIN TA.dbo." & data("tabla") & " AS p on n.ano = p.ANO AND n.PERIODO = p.periodo " &
                                          "WHERE n.reloj in " & relojes & " " &
                                          "AND isnull(p.periodo_especial,0) = 0 " &
                                          "GROUP BY reloj) as T " &
                                          "INNER JOIN TA.dbo.periodos as p on p.ano + p.periodo = T.last_period " &
                                          "INNER JOIN PERSONAL.dbo.personal as pe ON pe.RELOJ = T.reloj")

            Sqlite.getInstance.ExecuteNonQueryFunc(IIf(strFolio = "", "DELETE FROM finiquitosE", "DELETE FROM finiquitosE WHERE folio='" & strFolio & "'"))

            For Each itm In elements.Rows
                Dim lp = (From i In last_periodos.Rows Where i("reloj") = itm("reloj")).ToList
                Try

                    '-- En caso de que no tenga fecha de baja en personal, tomarla de nomina_calculo -- Ernesto -- 22 junio 2023
                    Dim fhaBaja = ""
                    If IsDBNull(lp.First()("baja")) Then
                        fhaBaja = FechaSQL(elements.Select("reloj='" & itm("reloj") & "'").First.Item("baja_finqto"))
                    Else
                        fhaBaja = FechaSQL(lp.First()("baja"))
                    End If

                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"reloj", itm("reloj")},
                                                                                 {"cod_comp", itm("cod_comp")},
                                                                                 {"nombre", itm("nombres")},
                                                                                 {"cod_tipo", itm("cod_tipo")},
                                                                                 {"baja", fhaBaja},
                                                                                 {"alta", itm("alta")},
                                                                                 {"sactual", itm("sactual")},
                                                                                 {"alta_vacacion", itm("alta_antig")},
                                                                                 {"calculo", itm("fhacalculo")},
                                                                                 {"ano", itm("ano")},
                                                                                 {"fecha_ini", lp.First()("fecha_ini")},
                                                                                 {"fecha_fin", lp.First()("fecha_fin")},
                                                                                 {"fecha_pago", lp.First()("fecha_pago")},
                                                                                 {"folio", itm("folio")},
                                                                                 {"activo", lp.First()("activo")},
                                                                                 {"diasva", 0}}, "finiquitosE")


                    '-- Actualizar nominaPro en caso de que se este agregando finiquito especial desde interfaz
                    If strFolio <> "" Then Sqlite.getInstance.ExecuteNonQueryFunc("update nominaPro set procesar='True',finiquito_esp='True',cod_tipo_nomina='F' where reloj='" & itm("reloj") & "'")

                Catch ex As Exception
                    Console.WriteLine("No se inserto finiquito especial: " & itm("reloj"))
                End Try
            Next

            '-- Marcar finiquito especial si se agrega desde interfaz
            If strFolio <> "" Then
                sqlExecute("update nomina.dbo.nomina_calculo set finiq_especial_ano='" & data("ano") & "'," &
                           "finiq_especial_periodo='" & data("periodo") & "'," &
                           "finiq_especial_tipo='" & data("tipoPeriodo") & "' where folio='" & strFolio & "'")
            End If

        End If
    End Sub

    ''' <summary>
    ''' Se crea un query a partir de un diccionario con informacion -- Ernesto -- 14 dic 2023
    ''' </summary>
    ''' <param name="dicInfo">Diccionario con info. de registro para query</param>
    ''' <param name="tabla">Tabla donde se insertará</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreaQuery(dicInfo As Dictionary(Of String, Object), tabla As String) As String
        Try
            Dim nullValues As New List(Of Object) From {Nothing, "", "{}"}
            Dim columns = String.Join(",", (From k In dicInfo.Keys Select k))

            Dim fixed_vals = (From i In dicInfo.Values Select IIf(i Is Nothing, "", i)).ToList
            Dim values = String.Join(",", (From k In fixed_vals Select IIf(nullValues.Contains(k.ToString), "NULL", "'" & k.ToString.Trim & "'")))

            Return String.Format("INSERT INTO {0} ({1}) VALUES ({2});", tabla, columns, values)

        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Guarda los bloques de registros en sqlite -- Ernesto -- 18 dic 2023
    ''' </summary>
    ''' <param name="strTitulo">Título de paso del proceso</param>
    ''' <param name="data">Variables de proceso</param>
    ''' <param name="strQuerys">Querys que se ejecutarán</param>
    ''' <remarks></remarks>
    Private Sub GuardaMovimientosTabla(strTitulo As String, ByRef data As Dictionary(Of String, String), strQuerys As ArrayList)
        Try
            '-- Variables
            Dim lim = 20                                    'Cantidad de querys de un bloque
            Dim cont = 0                                    'Contador querys 
            Dim numBloq = 0                                 'Num. de bloque con querys
            Dim strQry As New System.Text.StringBuilder     'Almacena cadena de querys

            data("etapa") = strTitulo
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If

            For Each i In strQuerys
                strQry.Append(i)
                If cont = lim Then
                    Sqlite.getInstance.ExecuteNonQueryFunc(strQry.ToString) : cont = 0 : numBloq += 1 : strQry.Clear()
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * numBloq / (strQuerys.Count / lim)) : End If
                End If
                cont += 1
            Next

            If cont > 0 Then Sqlite.getInstance.ExecuteNonQueryFunc(strQry.ToString)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Carga de las tablas principales del proceso y finiquitos especiales -- Modif. 22 dic 2023
    ''' </summary>
    ''' <param name="data">Variables de proceso</param>
    ''' <remarks></remarks>
    Public Sub CargaPrevia(ByRef data As Dictionary(Of String, String))

        '-- Variable compartida para saber si se pago aguinaldo anual -- Ernesto -- 13 dic 2023
        Dim strQuerys As New ArrayList
        sePagoAguiAnual = Me._options("incluir_aguinaldo_proporcional")
        canceled = False

        '-- Cargar pensiones Alimenticias
        Dim pensiones = sqlExecute("SELECT reloj,pensionado,porcentaje,tipo_pen,base_pen,fijo,cuenta,activo,apaterno,amaterno,nombre," &
                                   "cuaderno,num_pensio,cuenta_val,comentario,inicio,suspension,mercantil FROM PERSONAL.dbo.pensiones_alimenticias WHERE activo = '1'")

        For Each item In pensiones.Rows
            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", item("reloj")}, {"pensionado", item("pensionado")}, {"porcentaje", item("porcentaje")},
                                                                           {"tipo_pen", item("tipo_pen")}, {"base_pen", item("base_pen")}, {"fijo", item("fijo")},
                                                                           {"cuenta", item("cuenta")}, {"activo", item("activo") = 1}, {"apaterno", item("apaterno")},
                                                                           {"amaterno", item("amaterno")}, {"nombre", item("nombre")}, {"cuaderno", item("cuaderno")},
                                                                           {"num_pensio", item("num_pensio")}, {"cuenta_val", item("cuenta_val")},
                                                                           {"comentario", item("comentario")}, {"inicio", item("inicio")},
                                                                           {"suspension", item("suspension")}, {"mercantil", item("mercantil")}}, "pensionesAlimenticias"))
        Next

        '-- Guardar registros pensiones alimenticias
        GuardaMovimientosTabla("Cargando pensiones alimenticias", data, strQuerys)
        strQuerys.Clear()

        data("etapa") = "Realizando carga previa" : Dim counter = 0
        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / 3) : counter += 1 : End If
        CargaFiniquitosEspeciales(data)
        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / 3) : counter += 1 : End If

        '-- Cargando datos del periodo que se esta trabajando
        Dim dtPeriodo = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin,fecha_pago,num_mes,periodo_especial," &
                                    "fecha_corte,estatus_nomina,mes_acumulado,incluir_bondes, ANO+PERIODO as 'ano_periodo', '" &
                                    data("tipoPeriodo") & "' as 'tipoPeriodo' " &
                                    If(data("tipoPeriodo") = "Q", ",fecha_ini_incidencia,fecha_fin_incidencia,sem1,sem2,sem3,fecha_corte_ant", "") & "  FROM TA.dbo." & data("tabla") &
                                    " WHERE ANO = '" & data("ano") & "' AND PERIODO = '" & data("periodo") & "'", "TA")

        If dtPeriodo.Rows.Count > 0 Then
            Me.period = New Dictionary(Of String, String) From {{"ano", dtPeriodo.Rows(0)("ano").ToString}, {"periodo", dtPeriodo.Rows(0)("periodo").ToString},
                                                                {"fecha_ini", FechaSQL(dtPeriodo.Rows(0)("fecha_ini"))}, {"fecha_fin", FechaSQL(dtPeriodo.Rows(0)("fecha_fin"))},
                                                                {"fecha_pago", FechaSQL(dtPeriodo.Rows(0)("fecha_pago"))}, {"num_mes", dtPeriodo.Rows(0)("num_mes").ToString},
                                                                {"periodo_especial", dtPeriodo.Rows(0)("periodo_especial").ToString},
                                                                {"fecha_corte", FechaSQL(dtPeriodo.Rows(0)("fecha_corte"))}, {"estatus_nomina", dtPeriodo.Rows(0)("estatus_nomina").ToString},
                                                                {"ano_periodo", dtPeriodo.Rows(0)("ano_periodo").ToString}, {"tipoPeriodo", dtPeriodo.Rows(0)("tipoPeriodo").ToString},
                                                                {"mes_acumulado", dtPeriodo.Rows(0)("mes_acumulado").ToString}}

            Me.period.Add("fecha_ini_incidencia", "")
            Me.period.Add("fecha_fin_incidencia", "")
            Me.period.Add("fecha_corte_ant", "")
            Me.period.Add("sem1", "")
            Me.period.Add("sem2", "")
            Me.period.Add("sem3", "")

            If data("tipoPeriodo") = "Q" Then
                Me.period("fecha_ini_incidencia") = FechaSQL(dtPeriodo.Rows(0)("fecha_ini_incidencia"))
                Me.period("fecha_fin_incidencia") = FechaSQL(dtPeriodo.Rows(0)("fecha_fin_incidencia"))
                Me.period("fecha_corte_ant") = FechaSQL(dtPeriodo.Rows(0)("fecha_corte_ant"))

                Me.period("sem1") = If(IsDBNull(dtPeriodo.Rows(0)("sem1")), "", dtPeriodo.Rows(0)("sem1"))
                Me.period("sem2") = If(IsDBNull(dtPeriodo.Rows(0)("sem2")), "", dtPeriodo.Rows(0)("sem2"))
                Me.period("sem3") = If(IsDBNull(dtPeriodo.Rows(0)("sem3")), "", dtPeriodo.Rows(0)("sem3"))
            Else
                Me.period("fecha_ini_incidencia") = FechaSQL(dtPeriodo.Rows(0)("fecha_ini"))
                Me.period("fecha_fin_incidencia") = FechaSQL(dtPeriodo.Rows(0)("fecha_fin"))
            End If

            '-- Ivette orientó cargar Bono de despensa (incluir_bondes) desde TA
            Dim incluir_bondes = False
            If Not IsDBNull(dtPeriodo.Rows(0)("incluir_bondes")) Then : incluir_bondes = Convert.ToBoolean(dtPeriodo.Rows(0)("incluir_bondes")) : End If
            Me.Options("incluir_bondes") = incluir_bondes
        End If

        '--- COMENTADO. NO SE UTILIZARA EN CTE

        ''-- Cargar sueldo cobertura
        'Dim _sueldoCobertura = sqlExecute("SELECT reloj,sdo_cobert,comp_diaria,fha_inicio,fha_fin,tipo_comp,retroactiv,activo,comentario,ano_ini,periodo_ini," &
        '                                  "tipo_periodo_ini,porcentaje FROM NOMINA.dbo.sueldo_cobertura WHERE activo = '1' and fha_inicio <= '" & Me.period("fecha_fin") & "' ")

        'For Each item In _sueldoCobertura.Rows
        '    strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", item("reloj")}, {"sdo_cobert", item("sdo_cobert")}, {"comp_diaria", item("comp_diaria")},
        '                                                                    {"fha_inicio", FechaSQL(item("fha_inicio"))}, {"fha_fin", FechaSQL(item("fha_fin"))}, {"tipo_comp", item("tipo_comp")},
        '                                                                    {"retroactiv", item("retroactiv")}, {"activo", item("activo")}, {"comentario", item("comentario")},
        '                                                                    {"ano_ini", item("ano_ini")}, {"periodo_ini", item("periodo_ini")}, {"tipo_periodo_ini", item("tipo_periodo_ini")},
        '                                                                    {"porcentaje", item("porcentaje")}}, "sueldoCobertura"))
        'Next


        ''-- Guardar registros sueldo cobertura
        'GuardaMovimientosTabla("Cargando sueldos cobertura", data, strQuerys)
        'strQuerys.Clear()

        ''-- Cargar horas retrasadas
        'Dim sql = "SELECT * FROM NOMINA.dbo.conceptos_rezagados WHERE Origen like 'Horas_no_aplicadas%' "
        'If Not Me.filter Is Nothing Then : sql &= Me.filter : End If
        'Dim items = sqlExecute(sql, "NOMINA")
        'Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM horasLazy")

        'Try
        '    For Each item In items.Rows
        '        Dim dictList = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(item("json_detalles"))

        '        For Each dict In dictList
        '            Dim monto = Nothing, sueldo = Nothing, fecha_fox = Nothing, per_aplica = Nothing, ano_aplica = Nothing, saldo = Nothing
        '            If dict.Keys.Contains("Monto") Then : monto = dict("Monto") : End If
        '            If dict.Keys.Contains("Sueldo") Then : sueldo = dict("Sueldo") : End If
        '            If dict.Keys.Contains("fecha_fox") Then : fecha_fox = dict("fecha_fox") : End If
        '            If dict.Keys.Contains("per_aplica") Then : per_aplica = dict("per_aplica") : End If
        '            If dict.Keys.Contains("ano_aplica") Then : ano_aplica = dict("ano_aplica") : End If
        '            If dict.Keys.Contains("saldo") Then : saldo = dict("saldo") : End If

        '            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", item("reloj")},
        '                                                                            {"per_ded", Nothing}, {"concepto", dict("Concepto")}, {"descripcion", Nothing},
        '                                                                            {"monto", monto}, {"clave", Nothing}, {"origen", "rezagados"},
        '                                                                            {"usuario", Usuario}, {"datetime", Now()}, {"afecta_vac", Nothing},
        '                                                                            {"factor", dict("Factor")}, {"fecha", If(dict("Fecha") = "- -", Nothing, dict("Fecha"))},
        '                                                                            {"sueldo", sueldo}, {"fecha_fox", fecha_fox}, {"per_aplica", per_aplica},
        '                                                                            {"ano_aplica", ano_aplica}, {"saldo", saldo}}, "horasLazy"))
        '        Next
        '    Next

        '    '-- Guardar registros horas rezagadas
        '    GuardaMovimientosTabla("Cargando horas rezagadas", data, strQuerys)
        '    strQuerys.Clear()

        'Catch ex As Exception : End Try


        ''-- Cargar ajustes retrasados
        'items = sqlExecute("SELECT * FROM NOMINA.dbo.conceptos_rezagados WHERE Origen like 'Miscelaneos_no_aplicados%' ", "NOMINA")
        'Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM ajustesLazy")

        'Try
        '    For Each item In items.Rows
        '        Dim dictList = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(item("json_detalles"))

        '        For Each dict In dictList
        '            Dim monto = Nothing, sueldo = Nothing, fecha_fox = Nothing, per_aplica = Nothing, ano_aplica = Nothing, saldo = Nothing
        '            If dict.Keys.Contains("Monto") Then : monto = dict("Monto") : End If
        '            If dict.Keys.Contains("Sueldo") Then : sueldo = dict("Sueldo") : End If
        '            If dict.Keys.Contains("fecha_fox") Then : fecha_fox = dict("fecha_fox") : End If
        '            If dict.Keys.Contains("per_aplica") Then : per_aplica = dict("per_aplica") : End If
        '            If dict.Keys.Contains("ano_aplica") Then : ano_aplica = dict("ano_aplica") : End If
        '            If dict.Keys.Contains("saldo") Then : saldo = dict("saldo") : End If

        '            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", item("reloj")},
        '                                                                            {"per_ded", Nothing}, {"concepto", dict("Concepto")}, {"descripcion", Nothing},
        '                                                                            {"monto", monto}, {"clave", Nothing}, {"origen", "rezagados"},
        '                                                                            {"usuario", Usuario}, {"datetime", Now()}, {"afecta_vac", Nothing},
        '                                                                            {"factor", dict("Factor")}, {"fecha", If(dict("Fecha") = "- -", Nothing, dict("Fecha"))},
        '                                                                            {"sueldo", sueldo}, {"fecha_fox", fecha_fox}, {"per_aplica", per_aplica},
        '                                                                            {"ano_aplica", ano_aplica}, {"saldo", saldo}}, "ajustesLazy"))
        '        Next
        '    Next

        '    '-- Guardar registros horas rezagadas
        '    GuardaMovimientosTabla("Cargando miscelaneos rezagados", data, strQuerys)
        '    strQuerys.Clear()

        'Catch ex As Exception
        '    Console.WriteLine(ex)
        'End Try

        '-- Se realizan los exportar de pida 
        Me.Exportar(data)

        '-- Limpiar memoria
        freeMemory()
    End Sub

    Private Function tableToDict(table As DataTable) As List(Of Dictionary(Of String, String))
        Dim list As New List(Of Dictionary(Of String, String))
        Dim columns = (From i As DataColumn In table.Columns Select i.ColumnName).ToList
        For Each row In table.Rows
            Dim rowDict As New Dictionary(Of String, String)
            For Each column In columns : rowDict.Add(column, row(column).ToString) : Next
            list.Add(rowDict)
        Next
        Return list
    End Function

    ''' <summary>
    ''' Almacenar estado del proceso en el historial a la base de datos
    ''' </summary>
    ''' <param name="data">Datos generales.</param>
    ''' <param name="stepData">Etapa del proceso.</param>
    ''' <remarks></remarks>                                                       
    Public Sub saveProcessStatus(data As Dictionary(Of String, String), ByVal comentVersion As String)

        '-- Se guarda archivo sqlite en carpeta de respaldos
        CrearRespaldoLocal(data)

        Dim query = "INSERT INTO NOMINA.dbo.bitacora_proceso (ano, periodo, tipo_periodo, version, usuario, json_logs, json_period, json_globalVars, json_options, " &
                   "json_nominaPro, json_horasPro, json_ajustesPro, " &
                   "json_movimientosPro, json_finiquitosN, json_dRecib, json_movimientosCompensacion, json_pensionesAlimenticias, " &
                   "json_primaVacDetalle, json_aguinaldoExcento, json_ajustesSubsidio, etapa, json_data,comentario) " &
                   "values ('" & data("ano") & "', " &
                   "'" & data("periodo") & "', '" & data("tipoPeriodo") & "', " &
                   "(SELECT COALESCE(max(version),0)+1 AS version FROM NOMINA.dbo.bitacora_proceso where ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "'), " &
                   "'" & Usuario & "', " &
                   "'" & JsonConvert.SerializeObject(Me._logs).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(Me.period).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(Me._globalVars).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(Me._options).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.NominaPro)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.HorasPro)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.AjustesPro)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.MovimientosPro)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.FiniquitosN)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.DtRecib)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.MovimientosCompensacion)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.PensionesAlimenticias)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.PrimaVacDetalle)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.AguinaldoExcento)).Replace("'", "") & "', " &
                   "'" & JsonConvert.SerializeObject(tableToDict(Me.AjustesSubsidio)).Replace("'", "") & "', " &
                   "'" & data("activeMethod") & "', " &
                   "'" & JsonConvert.SerializeObject(data).Replace("'", "") & "', " &
                   "'" & comentVersion & "')"
        sqlExecute(query, "NOMINA")

    End Sub

    ''' <summary>
    ''' Cargar los datos de la base de datos para restaurar estado
    ''' </summary>
    ''' <param name="data">Datos generales.</param>
    ''' <remarks></remarks>
    Public Function restoreProcessStatus(id As Integer, ByRef data As Dictionary(Of String, String)) As stepsData
        Dim bitacora = sqlExecute("SELECT * FROM NOMINA.dbo.bitacora_proceso WHERE id = '" & id & "'", "NOMINA")
        Dim strQuery As New ArrayList

        If bitacora.Rows.Count > 0 Then
            Try

                '-- Restaura desde archivo de una ruta definida -- Ernesto -- 1 dic 2023
                If RestauraRespaldoLocal(data, bitacora) < 1 Then
                    data("etapa") = "Cargando bitacora" : Dim counter = 0 : Dim total = 15
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    Me.period = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(bitacora.Rows(0)("json_period"))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    Me._globalVars = JsonConvert.DeserializeObject(Of Dictionary(Of String, Decimal))(bitacora.Rows(0)("json_globalVars"))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    Me._options = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(bitacora.Rows(0)("json_options"))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("nominaPro", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_nominaPro")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("horasPro", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_horasPro")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("ajustesPro", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_ajustesPro")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("movimientosPro", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_movimientosPro")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("finiquitosN", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_finiquitosN")))

                    '-- Restauracion inecesaria (son ajustesnom y no se utilizan para calculo)
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("dtRecib", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_dRecib")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("movimientosCompensacion", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_movimientosCompensacion")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("pensionesAlimenticias", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_pensionesAlimenticias")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    dictsToSqlite("ajustesSubsidio", JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(bitacora.Rows(0)("json_ajustesSubsidio")))

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                    Me._logs = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(bitacora.Rows(0)("json_logs"))

                    data = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(bitacora.Rows(0)("json_data"))

                End If

                data("activeMethod") = 4
                CambiarFormatoFechas(strQuerys:=strQuery)
                GuardaMovimientosTabla("Revision de formato de fechas", data, strQuery)

                Return bitacora.Rows(0)("etapa")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Convertir diccionario a datarow
    ''' </summary>
    ''' <param name="data">Datos generales.</param>
    ''' <remarks></remarks>
    Private Sub dictToDatatable(ByRef table As DataTable, data As List(Of Dictionary(Of String, String)))
        table.Rows.Clear()
        For Each element In data
            Dim row = table.NewRow()
            For Each item In element
                Try
                    Select Case row.Table.Columns(item.Key).DataType
                        Case GetType(Boolean) : Try : row(item.Key) = Boolean.Parse(item.Value) : Catch ex As Exception : row(item.Key) = False : End Try
                        Case Else : Try : row(item.Key) = item.Value : Catch ex As Exception : Continue For : End Try
                    End Select
                Catch ex As Exception : End Try
            Next
            table.Rows.Add(row)
        Next
    End Sub

    ''' <summary>
    ''' Insertar lista de diccionarios a SQlite
    ''' </summary>
    ''' <param name="table">tabla sqlite.</param>
    ''' <param name="data">Datos generales.</param>
    ''' <remarks></remarks>
    Private Sub dictsToSqlite(table As String, data As List(Of Dictionary(Of String, Object)))
        Sqlite.getInstance.sqliteExecute("DELETE FROM " & table)
        For Each element In data : Sqlite.getInstance.insert(element, table) : Next
    End Sub

    Private Sub cancelProcess() 'Optional text As String = "Proceso cancelado, verificar notificaciones."
        Me.canceled = True
        Me.BgWorker.CancelAsync()
    End Sub

    ''' <summary>
    ''' Inicialización de proceso: nominapro, ajustes a conceptos, etc
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Sub Inicializar(ByRef data As Dictionary(Of String, String))

        Try
            '-- Consulta a nomina_calculo para validar si el empleado se procesa o no.
            Dim dtNomCalc = sqlExecute("select * from nomina.dbo.nomina_calculo")
            '-- Consulta el no. de mes del periodo
            Dim dtNoMes = sqlExecute("select top 1 mes_acumulado from ta.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where ano+periodo='" &
                                     data("ano") & data("periodo") & "'")
            '-- Arreglo para los inserts
            Dim strQuerys As New ArrayList

            data("etapa") = "Identificando datos de la nómina" : Dim counter = 0 : Dim total = 10
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            '-- Cargar vacaciones
            Dim vacations = sqlExecute("SELECT * FROM PERSONAL.dbo.vacaciones", "PERSONAL")

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            '-- Cargar personal
            Dim dtPeriodos = sqlExecute("SELECT * FROM " & data("tabla") & " WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "'", "TA")
            Dim FIni As Date = dtPeriodos.Rows(0)("fecha_ini") : Dim FFin As Date = dtPeriodos.Rows(0)("fecha_fin")

            Dim strFiniquitosNormales = "SELECT reloj FROM PERSONAL.dbo.personalvw p " & _
                                        "WHERE (baja BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) &
                                        "' AND reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) " & _
                                        "AND (cod_comp in (" & data("codComp") & ")) AND DATEDIFF (d, alta, baja) >= 2 AND " & _
                                        "reloj NOT IN (SELECT b.reloj FROM PERSONAL.dbo.bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                        "fecha_mantenimiento >'" & FechaHoraSQL(DateAdd(DateInterval.Minute, 3630, FFin)) & "' AND campo='baja' AND " & _
                                        "ValorNuevo IS NOT NULL AND ValorNuevo<>'' AND valoranterior<>valornuevo AND baja<='" & FechaSQL(FFin) & "')) " & _
                                        "OR reloj IN (SELECT reloj FROM PERSONAL.dbo.reingresos WHERE baja_ant BETWEEN '" & FechaSQL(FIni) & "' and '" & FechaSQL(FFin) & "') " & _
                                        "union " & _
                                        "SELECT b.reloj FROM PERSONAL.dbo.bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                        "b.reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) AND " & _
                                        "fecha_mantenimiento >= '" & FechaHoraSQL(DateAdd(DateInterval.Hour, 36, FIni)) & "' AND " & _
                                        "(cod_comp in (" & data("codComp") & ")) AND campo='baja' AND ValorNuevo IS NOT NULL " & _
                                        "AND ValorNuevo <>'' AND valoranterior <> valornuevo AND b.tipo_movimiento = 'B' AND " & _
                                        "baja < '" & FechaSQL(FIni) & "' AND DATEDIFF (d, alta,baja)>=2"

            Dim strFinitosEspeciales = "SELECT reloj FROM NOMINA.dbo.nomina_calculo WHERE finiq_especial_ano = '" & data("ano") & "' And " &
                                       "finiq_especial_periodo = '" & data("periodo") & "' and finiq_especial_tipo = '" & data("tipoPeriodo") & "'"

            Dim sql = "SELECT DISTINCT P.*, " &
                      "(SELECT top 1 fecha_mantenimiento FROM personal.dbo.bitacora_personal WHERE reloj = p.reloj AND campo='inactivo') as fecha_inac, " &
                      "(SELECT top 1 factor from personal.dbo.rol_horarios where ano='" & data("ano") & "' and periodo = '" & data("periodo") & "' and " &
                      "COD_COMP=p.COD_COMP and COD_HORA=(select top 1 cod_hora from ta.dbo.asist where ano+periodo='" & data("ano") & data("periodo") & "' and reloj=p.reloj)) as factor_dias, " &
                      "RTRIM(P.NOMBRE) + ' ' + RTRIM(P.APATERNO) + ' ' + RTRIM(P.AMATERNO) as 'nombre_completo', " &
                      "Pl.nombre as 'nombre_planta',  " &
                      "dpto.NOMBRE as 'nombre_dpto', " &
                      "'' as cod_area " &
                      "FROM PERSONAL.dbo.personal AS P " &
                      "JOIN PERSONAL.dbo.plantas AS Pl on P.COD_PLANTA = Pl.COD_PLANTA AND P.COD_COMP = Pl.COD_COMP " &
                      "JOIN PERSONAL.dbo.deptos AS DPTO on DPTO.COD_COMP = P.COD_COMP and DPTO.COD_DEPTO = P.COD_DEPTO " &
                      "WHERE (P.COD_COMP in (" & data("codComp") & ") " &
                      "AND p.alta <= '" & FechaSQL(period("fecha_fin")) & "' " &
                      "AND (p.baja is NUll Or p.baja >= '" & FechaSQL(period("fecha_ini")) & "') " &
                      "AND (p.inactivo = 0 or p.inactivo is null)) OR " &
                      "(P.reloj in (" & strFiniquitosNormales & ")) OR " &
                      "(P.reloj in (" & strFinitosEspeciales & "))"

            If Not Me.filter Is Nothing Then : sql &= Me.filter : End If
            Dim dtPersonal = sqlExecute(sql, "PERSONAL")
            Sqlite.getInstance().createTable(dtPersonal, "dtPersonal")

            '-- Validación: Nombres o apellidos con comillas
            Dim campos = {"nombre_completo", "nombre", "amaterno", "apaterno"}
            If dtPersonal.Rows.Count > 0 Then
                For i As Integer = 0 To dtPersonal.Rows.Count - 1
                    For Each campo In campos
                        If dtPersonal.Rows(i)(campo).ToString.Trim.Contains("'") Then
                            dtPersonal.Rows(i)(campo) = dtPersonal.Rows(i)(campo).ToString.Trim.Replace("'", "")
                        End If
                    Next
                Next
            End If

            '-- Tabla temporal de personal
            For Each element In dtPersonal.Rows
                Dim dict As New Dictionary(Of String, Object)
                For Each dataColumn In dtPersonal.Columns : dict.Add(dataColumn.ColumnName, element(dataColumn.ColumnName).ToString()) : Next
                strQuerys.Add(CreaQuery(dict, "dtPersonal"))
            Next

            '-- Guardar registros de personal
            GuardaMovimientosTabla("Identificando datos de la nómina: Personal", data, strQuerys) : strQuerys.Clear()
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            '-- Filtrar personal
            Dim employsToPay = Sqlite.getInstance().sqliteExecute("SELECT * FROM dtPersonal WHERE cod_comp in (" & data("codComp") & ") OR reloj in (SELECT reloj FROM finiquitosN) order by reloj asc")
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            '-- Cargar infonavit
            Dim relojes = "(" & String.Join(",", (From i In employsToPay.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ")"
            Dim dtInfonavit = sqlExecute("SELECT * FROM PERSONAL.dbo.INFONAVIT WHERE activo = '1' and reloj in " & relojes, "PERSONAL")

            Sqlite.getInstance().createTable(dtInfonavit, "dtInfonavit")
            For Each element In dtInfonavit.Rows
                Dim dict As New Dictionary(Of String, Object)
                For Each dataColumn In dtInfonavit.Columns : dict.Add(dataColumn.ColumnName, element(dataColumn.ColumnName).ToString()) : Next
                strQuerys.Add(CreaQuery(dict, "dtInfonavit"))
            Next

            '-- Guardar registros de infonavit
            GuardaMovimientosTabla("Identificando datos de la nómina: Infonavit", data, strQuerys) : strQuerys.Clear()
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            '-- Carga supervisores
            Dim dtSuper = sqlExecute("SELECT * FROM PERSONAL.dbo.super where reloj in " & relojes, "PERSONAL")

            Sqlite.getInstance().createTable(dtSuper, "dtSuper")
            For Each element In dtSuper.Rows
                Dim dict As New Dictionary(Of String, Object)
                For Each dataColumn In dtSuper.Columns : dict.Add(dataColumn.ColumnName, element(dataColumn.ColumnName).ToString()) : Next
                strQuerys.Add(CreaQuery(dict, "dtSuper"))
            Next

            '-- Guardar registros de supervisores
            GuardaMovimientosTabla("Identificando datos de la nómina: Supervisores", data, strQuerys) : strQuerys.Clear()
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            data("etapa") = "Cargando empleados de la nómina" : counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / employsToPay.Rows.Count) : counter += 1 : End If

            '-- Tablas de consulta
            'Dim dtInfonav = Sqlite.getInstance().sqliteExecute("SELECT * FROM dtInfonavit Order by reloj,FECHA_APLICACION desc")
            Dim dtInfonav = Sqlite.getInstance().sqliteExecute("SELECT * FROM dtInfonavit Order by reloj")

            Dim dtFinN = Sqlite.getInstance().sqliteExecute("SELECT * FROM finiquitosN")
            Dim dtSupers = Sqlite.getInstance().sqliteExecute("SELECT * FROM dtSuper")

            For Each item In employsToPay.Rows

                Dim strReloj = item("reloj").ToString.Trim
                Dim strFhaAlta = FechaSQL(item("alta"))
                Dim infonavit = infoTabla("reloj='" & strReloj & "'", dtInfonav)

                Dim finiqN = infoTabla("reloj='" & strReloj & "'", dtFinN)

                '-- Variable para definir si es finiquito (Si lo es, en nominaPro el factor será 1 siempre [a excepcion de que el usuario decida modificarlo manualmente])
                Dim esFiniquito = finiqN.Rows.Count > 0

                Dim infon = Nothing, tipo_cred = Nothing, cuota_cred = 0D, cobro_segv = False, suspension = False, activo = False, inicio_cre = Nothing
                If infonavit.Rows.Count > 0 Then
                    activo = infonavit.Rows(0)("activo")
                    infon = If(activo And Not IsDBNull(infonavit.Rows(0)("infonavit")), infonavit.Rows(0)("infonavit").Trim, Nothing)
                    tipo_cred = If(activo And Not IsDBNull(infonavit.Rows(0)("tipo_cred")), infonavit.Rows(0)("tipo_cred").Trim, Nothing)
                    cuota_cred = If(activo And Not IsDBNull(infonavit.Rows(0)("cuota_cred")), infonavit.Rows(0)("cuota_cred"), Nothing)
                    cobro_segv = If(activo And Not IsDBNull(infonavit.Rows(0)("cobro_segv")), Convert.ToBoolean(infonavit.Rows(0)("cobro_segv")), False)
                    suspension = If(activo And Not IsDBNull(infonavit.Rows(0)("suspension")), True, Nothing)
                    inicio_cre = If(activo And Not IsDBNull(infonavit.Rows(0)("inicio_cre")), infonavit.Rows(0)("inicio_cre"), Nothing)
                End If

                Dim privac_porc = 0, privac_dias = 0.0
                Dim super = infoTabla("reloj='" & strReloj & "'", dtSupers)

                '-- Procesar
                Dim fecha_inac = IIf(IsDBNull(item("fecha_inac")), Nothing, item("fecha_inac"))
                Dim alta = IIf(IsDBNull(item("alta")), Nothing, item("alta"))
                Dim baja = IIf(IsDBNull(item("baja")), Nothing, item("baja"))
                Dim inactivo = False
                If Not IsDBNull(item("inactivo")) Then : inactivo = Convert.ToBoolean(Convert.ToInt16(item("inactivo"))) : End If

                Dim fecha_fin = Convert.ToDateTime(period("fecha_fin"))
                Dim fecha_ini = Convert.ToDateTime(period("fecha_ini"))

                '-- FOX: replace procesar with iif(seek(nomina_pro.reloj,"inactivos","reloj") and inactivos.fecha_inac>=nomina_pro.alta,.f.,.t.)
                Dim procesar = Not inactivo
                If Not fecha_inac Is Nothing And Not alta Is Nothing Then : procesar = procesar And fecha_inac < alta : End If

                '-- FOX: replace procesar with iif(!empty(baja) and baja-alta<=1,.f.,procesar)
                If Not baja Is Nothing And Not alta Is Nothing Then : procesar = procesar And DateDiff(DateInterval.Day, alta, baja) > 1 : End If

                '-- Validación por parte de Ivette. Evaluar si el empleado se encuentra en nomina_calculo. Si es así, no se incluye para procesar nómina.
                procesar = procesar And Not (dtNomCalc.Select("reloj='" & strReloj & "' and status<>'CANCELADO' and captura is not null and captura>'" & strFhaAlta & "'").Count > 0)

                Dim aniversary_antig As Date, aniversary As Date
                Try : aniversary_antig = DateTime.ParseExact(Convert.ToDateTime(item("alta_vacacion")).ToString("ddMM") & fecha_fin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                Catch ex As Exception : aniversary_antig = "1900-01-01" : item("alta_vacacion") = "1900-01-01"
                End Try

                Try : aniversary = DateTime.ParseExact(Convert.ToDateTime(item("alta")).ToString("ddMM") & fecha_fin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                Catch ex As Exception : aniversary = DateTime.ParseExact(Convert.ToDateTime(item("alta")).AddDays(-1).ToString("ddMM") & fecha_fin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                End Try

                If aniversary_antig > fecha_fin Then
                    aniversary_antig = aniversary_antig.AddMonths(-12)
                    aniversary = aniversary.AddMonths(-12)
                End If

                If (aniversary_antig >= fecha_ini And aniversary_antig <= fecha_fin) And Integer.Parse(period("periodo").ToString()) <= 53 And aniversary_antig <> item("alta_vacacion") And ((finiqN.Rows.Count > 0 And baja >= aniversary_antig) Or finiqN.Rows.Count = 0) Then
                    Dim anos = aniversary_antig.Year() - Convert.ToDateTime(item("alta_vacacion")).Year()
                    Dim vac = (From i In vacations Where i("COD_COMP").ToString.Trim = item("cod_comp").ToString.Trim And i("COD_TIPO").ToString.Trim = item("cod_tipo").ToString.Trim And i("ANOS") = anos).ToList()
                    If vac.Count > 0 Then
                        privac_porc = vac.First()("POR_PRIMA")
                        If ((fecha_fin - Convert.ToDateTime(item("alta").ToString)).TotalDays + 1) / 365 <= 1 Then
                            privac_dias = Math.Round(vac.First()("DIAS") / 365 * ((aniversary_antig - Convert.ToDateTime(item("alta").ToString)).TotalDays + 1), 2)
                        Else
                            privac_dias = vac.First()("DIAS")
                        End If
                    End If
                End If

                Dim sdo_cober = 0, sup = Nothing
                If super.Rows.Count > 0 Then : sup = super.Rows(0)("cod_clerk") : End If

                '-- Validación de baja: Si la baja es posterior de la fha final del periodo, se deja al empleado como si no la tuviese. [Ivette]
                Dim fhaBaja = Nothing
                If Not IsDBNull(item("baja")) Then If Convert.ToDateTime(item("baja")) > Convert.ToDateTime(FFin) Then fhaBaja = Nothing Else fhaBaja = item("baja")

                strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"cod_comp", item("cod_comp")}, {"procesar", procesar}, {"retiro_fah", ""}, {"folio", ""},
                                                                                    {"pagina", ""}, {"cod_tipo_nomina", IIf(finiqN.Rows.Count > 0, "F", "N")},
                                                                                    {"cod_pago", item("tipo_pago")}, {"periodo", period("periodo")}, {"ano", data("ano")},
                                                                                    {"reloj", item("reloj")}, {"nombres", item("nombre_completo")}, {"mes", dtNoMes.Rows(0)("mes_acumulado").ToString.Trim},
                                                                                    {"sactual", item("sactual")}, {"integrado", item("integrado")}, {"cod_depto", item("cod_depto")},
                                                                                    {"cod_turno", item("cod_turno")}, {"cod_puesto", item("cod_puesto")}, {"cod_super", item("cod_super")},
                                                                                    {"cod_hora", item("cod_hora")}, {"cod_tipo", item("cod_tipo")}, {"cod_clase", item("cod_clase")},
                                                                                    {"sindicalizado", item("sindicalizado")}, {"tipo_nomina", data("tipoPeriodo")}, {"alta", item("alta")},
                                                                                    {"baja", fhaBaja}, {"alta_antig", item("alta_vacacion")}, {"periodo_act", period("ano_periodo")},
                                                                                    {"cod_cate", ""}, {"cod_tipo2", ""}, {"fah_participa", item("fah_partic")},
                                                                                    {"fah_porcentaje", item("fah_porcen")}, {"infonavit_credito", infon}, {"tipo_credito", tipo_cred},
                                                                                    {"cuota_credito", cuota_cred}, {"cobro_segviv", IIf(activo, cobro_segv, 0)}, {"inicio_credito", inicio_cre},
                                                                                    {"calculado", ""}, {"retiro_parcial", ""}, {"cuenta1", item("cuenta_banco")},
                                                                                    {"monto_retiro", ""}, {"curp", item("curp")}, {"cod_area", item("cod_area")},
                                                                                    {"privac_porc", privac_porc}, {"privac_dias", privac_dias}, {"factor_dias", IIf(esFiniquito, "1", item("factor_dias"))},
                                                                                    {"dias_habiles", ""}, {"vales_cta", ""}, {"vales_tarj", ""},
                                                                                    {"sdo_cobertura", sdo_cober}, {"incapacidad", ""}, {"faltas", ""},
                                                                                    {"vacaciones", ""}, {"cod_clerk", sup}, {"finiquito", IIf(finiqN.Rows.Count > 0, True, False)},
                                                                                    {"finiquito_esp", False}, {"permiso", ""}}, "nominaPro"))

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / employsToPay.Rows.Count) : counter += 1 : End If
            Next

            '-- Guardar registros de nominaPro
            GuardaMovimientosTabla("Cargando empleados de la nómina", data, strQuerys) : strQuerys.Clear()

            '-- Revisar si la información del empleado tuvo cambios después del último lunes del periodo en curso. Si es asi, revertirlos
            ReversaDatosNominapro(data, strQuerys:=strQuerys)
            GuardaMovimientosTabla("Validando: Reversa de datos", data, strQuerys) : strQuerys.Clear()

            '-- Quitar empleados que no corresponden al tipo de periodo que se esta corriendo
            'Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM nominaPro where cod_tipo<>'" & IIf(data("tipoPeriodo") = "S", "O", "A") & "' and finiquito='False' and finiquito_esp='False'")

            '-- Notificar cantidad de empleados a procesar
            Dim noEmp = Sqlite.getInstance.sqliteExecute("select count(reloj) as num from nominaPro")
            Me.addLog("Se procesarán " & noEmp.Rows(0)("num") & " empleados.")

            '-- Revisión de info no valida en nominaPro
            RevisionInfoIncorrecta(data)

            '-- Carga los miscelaneos exportados 
            CargarMiscelaneos(data)

            '-- Conceptos de finiquitos (nuevo)
            ConceptosFiniquitosNormales(data, seCalculoAguiAnual:=Me._options("incluir_aguinaldo_proporcional"))

            '-- exporta y carga las horas de PIDA
            ProcesarHoras(data)

            '-- Depurar registros de conceptos de acuerdo a la alta o baja del empleado
            DepurarConceptos(strQuerys:=strQuerys)
            GuardaMovimientosTabla("Depurando conceptos de altas y bajas", data, strQuerys) : strQuerys.Clear()

            '-- Revisar los sueldo de los conceptos en ajustesPro si son de fechas fuera del periodo
            SueldoConceptoTabla(data, strQuerys:=strQuerys)
            GuardaMovimientosTabla("Validando sueldo de conceptos", data, strQuerys) : strQuerys.Clear()

            '-- Factor 1 a finiquitos
            FactorFiniquito(strQuerys:=strQuerys)
            GuardaMovimientosTabla("Validando factor de finiquitos", data, strQuerys) : strQuerys.Clear()

            '-- Calcular los dia de aguinaldo para las bajas y altas del periodo en curso
            CalculoDiasAguinaldoProporcionales(data)

            '-- Cargar los dias normales
            CargarHorasSem(data)

            '-- Agrega descripcion a conceptos [que es cada concepto] a las tablas de ajustes y horas
            DescripcionConceptos(data)

            ''-- Se cambia el formato de las fechas de los regitros de algunas tablas
            'CambiarFormatoFechas(strQuerys:=strQuerys)
            'GuardaMovimientosTabla("Validando formato de fechas", data, strQuerys) : strQuerys.Clear()



            '-- limpiar memoria
            freeMemory()
        Catch ex As Exception

        End Try
       
    End Sub

    ''' <summary>
    ''' Se verifica info. no válida en nominaPro -- Ernesto -- 22 dic 2023
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <remarks></remarks>
    Private Sub RevisionInfoIncorrecta(ByRef data As Dictionary(Of String, String))
        Try
            Dim counter = 0, total = 4
            Data("etapa") = "Cargando validaciones"

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            Dim finiqNotBaja = Sqlite.getInstance.sqliteExecute("SELECT * FROM finiquitosN WHERE baja is NUll ")
            If finiqNotBaja.Rows.Count > 0 Then
                Me.addLog("Existen finiquitos sin baja, favor de completar la información solicitada para los empleados:", logType.WARN)
                For Each i In finiqNotBaja.Rows : Me.addLog(" - " & i("nombre") & " (" & i("reloj") & ")", Nothing, False) : Next
                'cancelProcess()
            End If

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
            Dim nominaConBaja = Sqlite.getInstance().sqliteExecute("SELECT * FROM nominaPro WHERE NOT (baja IS null OR baja = '') AND finiquito = 'False' AND finiquito_esp = 'False' AND procesar = 'True'")
            If nominaConBaja.Rows.Count > 0 Then
                Me.addLog("Existen empleados con baja que NO son finiquitos, favor de quitarles la fecha de baja:", logType.WARN)
                For Each i In nominaConBaja.Rows : Me.addLog(" - " & i("nombres") & " (" & i("reloj") & ")", Nothing, False) : Next
                'cancelProcess()
            End If

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            Dim nominaFactorMenor1 = Sqlite.getInstance().sqliteExecute("SELECT * FROM nominaPro WHERE factor_dias < 1")
            If nominaFactorMenor1.Rows.Count > 0 Then
                Me.addLog("Existen empleados con factor menor a 1:", logType.WARN)
                For Each i In nominaFactorMenor1.Rows : Me.addLog(" - " & i("nombres") & " (" & i("reloj") & ")", Nothing, False) : Next
                'cancelProcess()
            End If

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If

            Dim nominaFactorIgual1 = Sqlite.getInstance().sqliteExecute("SELECT * FROM nominaPro WHERE factor_dias = 1")
            If nominaFactorMenor1.Rows.Count > 0 Then
                Me.addLog("Existen empleados activos con factor igual 1:", logType.WARN)
                For Each i In nominaFactorMenor1.Rows : Me.addLog(" - " & i("nombres") & " (" & i("reloj") & ")", Nothing, False) : Next
                'cancelProcess()
            End If

            '-- Avisar si existen empleados con bajas antes del periodo -- 24 ene 2024
            AlertaEmpleadoBajaAntesPeriodo()

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Importante. Aviso para empleados con bajas previas al inicio del periodo. [Saber que ya se le pago un finiquito y no se vuelva a procesar]
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlertaEmpleadoBajaAntesPeriodo(Optional strFiltro As String = "")
        Try
            Dim dtBajaPerAnterior = Sqlite.getInstance().sqliteExecute("SELECT reloj,nombres,baja FROM nominaPro WHERE procesar='True' and baja is not null " & strFiltro)
            Dim cont = 0

            If dtBajaPerAnterior.Rows.Count > 0 Then
                For Each i In dtBajaPerAnterior.Rows
                    If Convert.ToDateTime(i("baja")) < Convert.ToDateTime(Me.period("fecha_ini")) Then
                        If cont = 0 Then Me.addLog("Alerta: Existen empleados con bajas antes del inicio del periodo, favor de revisar", logType.WARN) : cont += 1
                        Me.addLog(" - " & i("nombres") & " (" & i("reloj") & ") -- " & FechaSQL(i("baja")), Nothing, False)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Cambia el formato de las fechas de ciertas tablas como ajustesPro,ajustesLazy,horasPro,horasLazy,etc. -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CambiarFormatoFechas(Optional CrudAgregar As Boolean = False, Optional strReloj As String = "",
                                           Optional ByRef strQuerys As ArrayList = Nothing)
        Try
            Dim tablas_columnas = {"ajustesPro:datetime,fecha,fecha_fox",
                                   "horasPro:datetime,fecha",
                                   "finiquitosN:baja,alta,alta_vacacion,fecha_ini,fecha_fin,fecha_pago,calculo",
                                   "nominaPro:alta,baja,alta_antig,inicio_credito"}

            Dim strQry = {"select id,reloj,concepto,{0} from {1}", "select id,{0} from {1}"}


            If CrudAgregar Then
                tablas_columnas = {"finiquitosN:baja,alta,alta_vacacion,fecha_ini,fecha_fin,fecha_pago,calculo",
                                   "ajustesPro:datetime,fecha,fecha_fox",
                                   "horasPro:datetime,fecha",
                                   "nominaPro:alta,baja,alta_antig,inicio_credito"}

                strQry = {"select id,reloj,concepto,{0} from {1}",
                          "select id,{0} from {1} where reloj='" & strReloj & "'"}
            End If

            Dim strUpd = "update {0} set {1} where id='{2}';"
            Dim camposActualiza = ""
            Dim actualizar = False
            Dim dtInfo As New DataTable

            For Each tabla In tablas_columnas
                Dim valores = tabla.Split(":")
                dtInfo = Sqlite.getInstance.sqliteExecute(String.Format(If({"ajustesPro", "horasPro"}.Contains(valores(0)), strQry(0), strQry(1)), valores(1), valores(0)))

                If CrudAgregar AndAlso {"ajustesPro", "horasPro"}.Contains(valores(0)) Then
                    dtInfo = dtInfo.Select("reloj='" & strReloj & "'").CopyToDataTable
                End If

                If dtInfo.Rows.Count > 0 Then
                    For Each row In dtInfo.Rows
                        For Each col In valores(1).Split(",")
                            If IsDBNull(row(col)) Then Continue For
                            camposActualiza &= col & "='" & FechaSQL(Convert.ToDateTime(row(col))) & "',"
                            actualizar = True
                        Next

                        If actualizar Then
                            If Not CrudAgregar Then strQuerys.Add(String.Format(strUpd, valores(0), camposActualiza.Substring(0, camposActualiza.Length - 1), row("id")))
                            If CrudAgregar Then Sqlite.getInstance.ExecuteNonQueryFunc(String.Format(strUpd, valores(0), camposActualiza.Substring(0, camposActualiza.Length - 1), row("id")))
                        End If
                        camposActualiza = ""
                        actualizar = False
                    Next
                End If
            Next

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Agrega la descripcion de los conceptos de las tabla de ajustesPro,ajustesLazy,horasPro,horasLazy -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DescripcionConceptos(data As Dictionary(Of String, String))
        Try
            '-- Info conceptos
            Dim dtConceptos = sqlExecute("select concepto,nombre,cod_naturaleza from nomina.dbo.conceptos")
            Dim tablas = {"horasPro", "ajustesPro"}
            Dim actualiza = "update {0} set {1} where id={2}"
            Dim strQuery As New ArrayList
            Dim nombre = ""
            Dim nat = ""

            If dtConceptos.Rows.Count > 0 Then
                For Each t In tablas
                    Dim dtTablas = Sqlite.getInstance.sqliteExecute(String.Format("select id,concepto from {0}", t))
                    If dtTablas.Rows.Count > 0 Then
                        Dim campos = IIf(t = "horasPro", "descripcion='{0}'", "descripcion='{0}',per_ded='{1}'")
                        For Each i In dtTablas.Rows

                            If dtConceptos.Select("concepto='" & i("concepto") & "'").Count = 0 Then
                                nombre = "- No existe concepto -"
                                nat = "- No existe concepto -"
                            Else
                                nombre = dtConceptos.Select("concepto='" & i("concepto") & "'").First.Item("nombre").ToString.ToUpper
                                nat = dtConceptos.Select("concepto='" & i("concepto") & "'").First.Item("cod_naturaleza").ToString.ToUpper
                            End If

                            strQuery.Add(String.Format("update {0} set " & String.Format(campos, nombre, nat) & " where id={1};", t, i("id")))
                        Next
                    End If
                Next
                GuardaMovimientosTabla("Agregando descripción de conceptos", data, strQuery)
            End If
        Catch ex As Exception : End Try
    End Sub


    ''' <summary>
    ''' Función que se encarga de calcular los dias de aguinaldo [ya sea para finiquito o dias de aguinaldo proporcionales a final de año] -- Ernesto
    ''' </summary>
    ''' <param name="_alta"></param>
    ''' <param name="_baja"></param>
    ''' <param name="_altaAntig"></param>
    ''' <param name="codComp"></param>
    ''' <param name="codTipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DiasAguinaldo(data As Dictionary(Of String, String), _alta As Date, _baja As Date, _altaAntig As Date, codComp As String,
                                   codTipo As String, Optional tipo As String = "") As Decimal
        Try
            '==== Condiciones iniciales
            '== Si ya se pagó el aguinaldo y es una alta, calcular de alta al 31 de diciembre [monto positivo]
            '== Si ya se pagó el aguinaldo y es una baja, calcular de la baja [un día siguiente] al 31 de diciembre [monto negativo]
            '== Si no se ha pagado el aguinaldo, se calculan los dias de aguinaldo solo a los finiquitos

            Dim opcionVal = IIf(Me._options("incluir_aguinaldo_proporcional") And tipo = "Baja", "PropBaja",
                                IIf(Me._options("incluir_aguinaldo_proporcional") And tipo = "Alta", "PropAlta",
                                    "Normal"))

            Dim primeroAgui = DateSerial(Year(_baja), 1, 1)
            Dim diasAnualesAgui = DateDiff(DateInterval.DayOfYear, DateSerial(Year(_baja), 1, 1), DateSerial(Year(_baja), 12, 31)) + 1
            Dim altaAgui = _alta
            Dim altaAntigAgui = _altaAntig
            Dim ultimoAgui = _baja
            Dim dias = 0.0
            Dim corresponden = 0.0

            If FechaSQL(altaAntigAgui) = "1900-01-01" Then altaAntigAgui = altaAgui
            If FechaSQL(altaAgui) > FechaSQL(primeroAgui) Then primeroAgui = altaAgui

            Dim anios = IIf(antiguedad(altaAntigAgui, ultimoAgui) < 1, 1, antiguedad(altaAntigAgui, ultimoAgui))

            Select Case opcionVal
                Case "PropBaja"
                    primeroAgui = _baja.AddDays(1)
                    ultimoAgui = DateSerial(data("ano"), 12, 31)
                Case "PropAlta"
                    primeroAgui = _alta
                    ultimoAgui = DateSerial(data("ano"), 12, 31)
                Case "Normal"
                    ultimoAgui = _baja
            End Select

            '-- Si el empleado es "PropBaja" la antiguedad siempre sera negativa -- Ernesto -- 15 dic 2023
            Dim ant_completa = If(opcionVal = "PropBaja", (Antiguedad_Dias(primeroAgui, ultimoAgui) + 1) * -1, Antiguedad_Dias(primeroAgui, ultimoAgui) + 1)

            Dim _cod_comp = IIf(codComp = "", "X", codComp)
            Dim _tipo_emp = IIf(codTipo = "", "X", codTipo)

            Dim dtAguinaldo = sqlExecute("select * from agui where cod_comp = '" & _cod_comp & "' and cod_tipo = '" & _tipo_emp & "' and anos = '" & anios & "'")

            If dtAguinaldo.Rows.Count > 0 Then
                dias = IIf(IsDBNull(dtAguinaldo.Rows(0).Item("DIAS")), 0, dtAguinaldo.Rows(0).Item("DIAS")) +
                    IIf(IsDBNull(dtAguinaldo.Rows(0).Item("DIAS_AD")), 0, dtAguinaldo.Rows(0).Item("DIAS_AD"))
            Else
                dias = 15
            End If

            corresponden = (dias * ant_completa) / diasAnualesAgui
            corresponden = Math.Round(corresponden, 2)

            Return corresponden
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Función que se encarga de calcular los dias de aguinaldo a las altas y bajas del periodo en curso -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculoDiasAguinaldoProporcionales(data As Dictionary(Of String, String))
        Try
            If Me._options("incluir_aguinaldo_proporcional") Then
                Dim strQuerys As New ArrayList
                Dim dtNomCompleta = Sqlite.getInstance.sqliteExecute("select * from nominaPro ")
                Dim dtPerActual = sqlExecute("select * from ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                             " where ano='" & data("ano") & "' and periodo='" & data("periodo") & "'")


                Dim dtAguinaldo = sqlExecute("select * from personal.dbo.agui")
                'Dim dtDiasAguiAnio = sqlExecute("select * from nomina.dbo.movimientos where ano='" & data("ano") & "' and " &
                '                              "periodo in ('" & Me._options("_aguinaldo_per_sem") & "','" & Me._options("_aguinaldo_per_quin") & "') and " &
                '                              "concepto='DIASAG'")

                'If dtNomCompleta.Rows.Count > 0 And dtPerActual.Rows.Count > 0 And dtAguinaldo.Rows.Count > 0 Then
                If dtNomCompleta.Rows.Count > 0 Then

                    Dim fhaIniPer = Convert.ToDateTime(dtPerActual.Rows(0)("fecha_ini"))
                    Dim fhaFinPer = Convert.ToDateTime(dtPerActual.Rows(0)("fecha_fin"))

                    For Each e In dtNomCompleta.Rows
                        Dim altaEmp = Convert.ToDateTime(e("alta"))
                        Dim bajaEmp = Nothing
                        If Not IsDBNull(e("baja")) Then bajaEmp = Convert.ToDateTime(e("baja")) Else bajaEmp = Convert.ToDateTime("1900-01-01")
                        Dim diasProporcion = 0.0

                        '== Bajas
                        'If Not bajaPeriodo Is Nothing AndAlso (bajaPeriodo >= fhaIniPer And bajaPeriodo <= fhaFinPer) Then
                        If (bajaEmp > Convert.ToDateTime("1900-01-01")) AndAlso (bajaEmp >= fhaIniPer And bajaEmp <= fhaFinPer) Then
                            '== Dias aguinaldo finiquito,dias aguinaldo anticipado,dias aguinaldo periodo anio
                            Dim diasAguiFini = 0.0, diasAguiAcudag = 0.0, diasAguiAnio = 0.0
                            Try : diasAguiFini = Sqlite.getInstance.sqliteExecute("select * from ajustesPro where concepto='DIASAG' and reloj='" & e("reloj") & "'").Rows(0)("monto") : Catch ex As Exception : diasAguiFini = 0.0 : End Try
                            'Try : diasAguiAcudag = sqlExecute("select top 1 * from nomina.dbo.movimientos where concepto='ACUDAG' and ano='" & data("ano") & "' and reloj='" & e("reloj") & "' order by PERIODO desc").Rows(0)("monto")
                            'Catch ex As Exception : diasAguiAcudag = 0.0 : End Try
                            'Try : diasAguiAnio = dtDiasAguiAnio.Select("reloj='" & e("reloj") & "' and periodo='" & IIf(e("cod_tipo") = "O", Me._options("_aguinaldo_per_sem"), Me._options("_aguinaldo_per_quin")) & "'").First.Item("monto")
                            'Catch ex As Exception : diasAguiAnio = 0.0 : End Try

                            '== Diferencia para nómina
                            'difNomina = Math.Round(diasAguiFini - (diasAguiAnio - diasAguiAcudag), 2)
                            diasProporcion = DiasAguinaldo(data, Convert.ToDateTime(e("alta")), bajaEmp,
                                                      Convert.ToDateTime(e("alta_antig")), e("cod_comp").ToString.Trim, e("cod_tipo").ToString.Trim, "Baja")

                            'If difNomina <> 0 Then
                            strQuerys.Add("update ajustesPro set monto='" & diasProporcion & "',origen='AguinaldoProporcionalBajas' where concepto='DIASAG' and reloj='" & e("reloj") & "';")
                            'End If

                            Continue For
                        End If

                        '== Altas
                        If altaEmp >= fhaIniPer And altaEmp <= fhaFinPer Then
                            Dim aniosEmpresa = IIf(altaEmp.Year = Date.Now.Year, 1, Date.Now.Year - altaEmp.Year + 1)
                            Dim diasAlAnio = dtAguinaldo.Select("cod_comp='" & e("cod_comp") & "' and cod_tipo='" & e("cod_tipo") & "' and anos='" & aniosEmpresa & "'").First.Item("dias")
                            Dim diasFinDiciembre = DateDiff(DateInterval.Day, altaEmp, Convert.ToDateTime(data("ano") & "-12-31")) + 1
                            diasProporcion = Math.Round(diasAlAnio / 365 * diasFinDiciembre, 2)

                            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                                   {"periodo", data("periodo")},
                                                                                                   {"reloj", e("reloj")},
                                                                                                   {"per_ded", "P"},
                                                                                                   {"concepto", "DIASAG"},
                                                                                                   {"descripcion", Nothing},
                                                                                                   {"monto", diasProporcion},
                                                                                                   {"clave", Nothing},
                                                                                                   {"origen", "AguinaldoProporcionalAltas"},
                                                                                                   {"usuario", Usuario},
                                                                                                   {"datetime", Date.Now},
                                                                                                   {"afecta_vac", "False"},
                                                                                                   {"factor", Nothing},
                                                                                                   {"fecha", Nothing},
                                                                                                   {"sueldo", Nothing},
                                                                                                   {"fecha_fox", Nothing},
                                                                                                   {"per_aplica", data("periodo")},
                                                                                                   {"ano_aplica", data("ano")},
                                                                                                   {"saldo", Nothing}}, "ajustesPro"))
                        End If
                    Next
                    GuardaMovimientosTabla("Almacenando días de aguinaldo proporcional", data, strQuerys)
                End If
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función que se encarga de revisar si el sueldo del concepto en la tabla de ajustesPro coincide con su periodo -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SueldoConceptoTabla(data As Dictionary(Of String, String), Optional relojManual As String = "",
                                          Optional ByRef strQuerys As ArrayList = Nothing)
        Try
            '== Filtro para empleado que se agrego manualmente desde interfaz
            Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "') ", "")

            Dim ajustesConceptos = Sqlite.getInstance.sqliteExecute("select * from ajustesPro where ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and fecha is not null " & String.Format(filtroIngresoManual, "and"))
            'Dim periodoInfo = Sqlite.getInstance.sqliteExecute("select ano,periodo,fecha_ini,fecha_fin from periodosNomPro where ano='" & data("ano") & "' and periodo='" & data("periodo") & "'")
            Dim periodoInfo = sqlExecute("select ano,periodo,fecha_ini,fecha_fin from ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                         " where ano='" & data("ano") & "' and periodo='" & data("periodo") & "'")


            '== Sueldo del empleado en otro periodo de acuerdo a la fecha del concepto
            Dim strNomina = "select reloj,ano,periodo,sactual from nomina.dbo.nomina where ano+periodo in (select ano+periodo from ta.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " " &
                            "where '{0}'>=fecha_ini and '{0}'<=fecha_fin and periodo<=53) and reloj='{1}' and tipo_periodo='{2}'"

            '== Sueldo del empleado en otro periodo de acuerdo a su tipo [semanal o quincenal]
            Dim strTipoPeriodEmp = "select P.ano,P.periodo,P.fecha_ini,P.fecha_fin,P.tipo_periodo from " &
                                   "(select ano,periodo,fecha_ini,fecha_fin,'S' as 'tipo_periodo' from ta.dbo.periodos " &
                                   "union all select ano,periodo,fecha_ini,fecha_fin,'Q' as 'tipo_periodo' from ta.dbo.periodos_quincenal) as P " &
                                   "where '{0}'>=P.fecha_ini and '{0}'<=P.fecha_fin AND P.PERIODO<=53 AND P.tipo_periodo<>'" & data("tipoPeriodo") & "'"

            If ajustesConceptos.Rows.Count > 0 And periodoInfo.Rows.Count > 0 Then
                Dim iniPer = Convert.ToDateTime(periodoInfo.Rows(0)("fecha_ini"))
                Dim finPer = Convert.ToDateTime(periodoInfo.Rows(0)("fecha_fin"))

                For Each drow In ajustesConceptos.Rows
                    Dim fecha = Convert.ToDateTime(drow("fecha"))
                    If (fecha >= iniPer And fecha <= finPer) Then Continue For

                    Dim nominaInfo = sqlExecute(String.Format(strNomina, FechaSQL(fecha), drow("reloj"), data("tipoPeriodo")))

                    '== Si existe nomina pasada para el empleado con el mismo tipo de empleado
                    If nominaInfo.Rows.Count > 0 Then
                        If nominaInfo.Rows.Count > 0 AndAlso (CDbl(nominaInfo.Rows(0)("sactual")) <> CDbl(drow("sueldo"))) Then
                            '== Si el sueldo del periodo pasado es distinto que el del actual, se actualiza con el sueldo con el sueldo anterior en ajustesPro

                            If relojManual = "" And Not strQuerys Is Nothing Then strQuerys.Add("update ajustesPro set sueldo='" & nominaInfo.Rows(0)("sactual") & "' where id='" & drow("id") & "';")
                            If relojManual <> "" And strQuerys Is Nothing Then Sqlite.getInstance.ExecuteNonQueryFunc("update ajustesPro set sueldo='" & nominaInfo.Rows(0)("sactual") & "' where id='" & drow("id") & "';")
                        End If
                    Else
                        '== Si no hay una nomina pasada, se entiende que el empleado era de otro tipo. 
                        Dim otroTipo = sqlExecute(String.Format(strTipoPeriodEmp, FechaSQL(fecha)))
                        Dim nominaOtroTipo = sqlExecute("select reloj,ano,periodo,sactual from nomina.dbo.nomina " &
                                                        "where ano='" & otroTipo.Rows(0)("ano") & "' and periodo='" & otroTipo.Rows(0)("periodo") & "' and tipo_periodo='" & otroTipo.Rows(0)("tipo_periodo") & "'")

                        If nominaOtroTipo.Rows.Count > 0 AndAlso (CDbl(nominaOtroTipo.Rows(0)("sactual")) <> CDbl(drow("sueldo"))) Then
                            '== Si el sueldo del periodo pasado es distinto que el del actual, se actualiza con el sueldo con el sueldo anterior en ajustesPro
                            If relojManual = "" And Not strQuerys Is Nothing Then strQuerys.Add("update ajustesPro set sactual='" & nominaOtroTipo.Rows(0)("sactual") & "' where id='" & drow("id") & "';")
                            If relojManual <> "" And strQuerys Is Nothing Then Sqlite.getInstance.ExecuteNonQueryFunc("update ajustesPro set sactual='" & nominaOtroTipo.Rows(0)("sactual") & "' where id='" & drow("id") & "';")
                        End If
                    End If
                Next
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función que se encarga de remover los registros de conceptos que se dieron antes de una alta o después de la baja del empleado. -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub DepurarConceptos(Optional relojManual As String = "", Optional ByRef strQuerys As ArrayList = Nothing)
        Try
            '== Filtro para empleado que se agrego manualmente desde interfaz
            Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "') ", "")

            '== Conceptos en las tablas de ajustesPro,ajustesLazy,horasPro,horasLazy. 
            Dim faltasInjustificadas = Sqlite.getInstance.sqliteExecute("SELECT reloj,concepto,monto," &
                                                                        "(select alta from nominaPro p where p.reloj=t.reloj) as 'alta'," &
                                                                        "(select baja from nominaPro p where p.reloj=t.reloj) as 'baja'," &
                                                                        "(t.fecha) as 'fecha_concepto'," &
                                                                        "(case when t.reloj in (select reloj from nominaPro p where t.reloj=p.reloj) then '1' else '0' end) as 'existe_nominaPro'," &
                                                                        "(t.tabla) as 'origen' " &
                                                                        "FROM (select * from (select *,'ajustesPro' as 'tabla' from ajustesPro)) as t " &
                                                                        "WHERE (t.fecha Is Not null) and t.concepto not in ('HRSPSG','HRSRET') " & String.Format(filtroIngresoManual, "and") &
                                                                        "union " &
                                                                        "SELECT reloj,concepto,monto," &
                                                                        "(select alta from nominaPro p where p.reloj=h.reloj) as 'alta'," &
                                                                        "(select baja from nominaPro p where p.reloj=h.reloj) as 'baja'," &
                                                                        "h.fecha AS 'fecha_concepto'," &
                                                                        "(case when reloj in (select reloj from nominaPro p where h.reloj=p.reloj) then '1' else '0' end) as 'existe_nominaPro'," &
                                                                        "('horasPro') as 'origen' " &
                                                                        "FROM horasPro h " &
                                                                        "WHERE h.fecha is not null and h.concepto not in ('HRSPSG','HRSRET') " & String.Format(filtroIngresoManual, "and"))

            '== Actualización de tablas de acuerdo a si la fecha del registro es anterior a la alta del empleado o despues de la baja.
            If faltasInjustificadas.Rows.Count > 0 Then
                For Each f In faltasInjustificadas.Select("existe_nominaPro='1'")
                    If Not IsDBNull(f.Item("fecha_concepto")) Then
                        Dim fechaCero = f.Item("fecha_concepto").ToString
                        If fechaCero = "01/01/0001 12:00:00 a. m." Then Continue For

                        Dim evaluacion = (Convert.ToDateTime(f.Item("fecha_concepto")) < Convert.ToDateTime(f.Item("alta"))) OrElse
                                         (Not IsDBNull(f.Item("baja")) AndAlso (Convert.ToDateTime(f.Item("fecha_concepto")) > Convert.ToDateTime(f.Item("baja"))))

                        If evaluacion Then
                            If relojManual <> "" And strQuerys Is Nothing Then
                                Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM " & f.Item("origen") & " WHERE reloj='" & f.Item("reloj").ToString.Trim & "' and concepto='" & f.Item("concepto") & "' and fecha='" & f.Item("fecha_concepto") & "';")
                            End If
                            If relojManual = "" And Not strQuerys Is Nothing Then
                                strQuerys.Add("DELETE FROM " & f.Item("origen") & " WHERE reloj='" & f.Item("reloj").ToString.Trim & "' and concepto='" & f.Item("concepto") & "' and fecha='" & f.Item("fecha_concepto") & "';")
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para dar reversa a cambios que se realizaron despues del lunes del periodo en curso para nominaPro [sueldo,horario,supervisor,departamento,puesto,tipo,clase] -- Ernesto
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <param name="relojManual">Reloj en caso de ingresar es caso de ingreso manual</param>
    ''' <param name="strQuerys">Arreglo de querys para insertar</param>
    ''' <remarks></remarks>
    Public Shared Sub ReversaDatosNominapro(data As Dictionary(Of String, String), Optional relojManual As String = "",
                                            Optional ByRef strQuerys As ArrayList = Nothing)
        Try
            Dim periodoNom = sqlExecute("select ano+periodo as periodo,fecha_ini,fecha_fin from ta.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                        " where ano+periodo='" & data("ano") & data("periodo") & "'")
            Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "')", "")

            Dim topeDia = Nothing
            Dim noAplican As DataTable = Nothing
            Dim sueldoIntegrado As DataTable = Nothing
            Dim nominaPro As DataTable = Nothing
            Dim dtPersonal As DataTable = Nothing

            '== Acercarse al último lunes del periodo [para semanales]
            If periodoNom.Rows.Count > 0 Then
                topeDia = Convert.ToDateTime(periodoNom.Rows(0)("fecha_fin")).AddDays(1)

                '-- Dar reversa tambien a los sindicalizados -- 2 agosto 2023
                noAplican = sqlExecute("select * from personal.dbo.bitacora_personal where fecha>='" & FechaSQL(topeDia) & "' and " &
                                       "campo in ('sactual','cod_depto','cod_super','cod_puesto','cod_hora','cod_tipo','cod_clase','sindicalizado','alta','baja') and " &
                                       "tipo_movimiento not in ('A') and reloj<'800000' order by campo,reloj")

                sueldoIntegrado = sqlExecute("select * from personal.dbo.bitacora_personal where fecha>='" & FechaSQL(topeDia) & "' and " &
                                             "campo in ('integrado') and tipo_movimiento not in ('A') and reloj<'800000' order by fecha_mantenimiento desc")
            End If

            '== Cambio de valores
            If noAplican.Rows.Count > 0 Or sueldoIntegrado.Rows.Count > 0 Then
                nominaPro = Sqlite.getInstance.sqliteExecute("select * from nominaPro " & String.Format(filtroIngresoManual, "where"))
                Dim relojes = (From i In sueldoIntegrado.Rows Select i("reloj").ToString.Trim).ToList().Distinct
                Dim srtRlj = String.Join(",", (From i In relojes Select "'" & i & "'"))

                If sueldoIntegrado.Rows.Count > 0 Then dtPersonal = sqlExecute("select reloj,factor_int,pro_var from personal.dbo.personal where reloj in (" & srtRlj & ")")

                If nominaPro.Rows.Count > 0 Then
                    For Each nom In nominaPro.Rows

                        Dim val = noAplican.Select("reloj='" & nom("reloj").ToString.Trim & "'")
                        Dim val2 = sueldoIntegrado.Select("reloj='" & nom("reloj").ToString.Trim & "'")

                        If val.Count > 0 Then
                            Dim strQry = "update nominaPro set " &
                                          String.Join(",", (From i In val Select (i("campo").ToString.Trim & "='" & i("ValorAnterior").ToString.Trim & "'"))) & " where reloj='" & nom("reloj") & "';"
                            strQuerys.Add(strQry)
                        End If

                        '== Validación especial. Para sueldo integrado [Ya que no se incluye el valor anterior en la bitacora de personal]
                        If val2.Count > 0 Then
                            '== En caso de que la bitacora si contenga el valor anterior, insertarlo, sino, recalcular
                            If val2.First.Item("ValorAnterior").ToString.Trim = "" Or IsDBNull(val2.First.Item("ValorAnterior")) Then
                                Dim salAnterior = noAplican.Select("campo='sactual' and reloj='" & nom("reloj").ToString.Trim & "'").First.Item("ValorAnterior")
                                Dim factorInt = dtPersonal.Select("reloj='" & nom("reloj").ToString.Trim & "'").First.Item("factor_int")
                                Dim proVar = dtPersonal.Select("reloj='" & nom("reloj").ToString.Trim & "'").First.Item("pro_var")

                                Dim strQry = String.Format("update nominaPro set integrado='{0}' where reloj='{1}';", Math.Round((salAnterior * factorInt) + proVar, 2), nom("reloj").ToString.Trim)
                                strQuerys.Add(strQry)
                            Else
                                Dim strQry = "update nominaPro set " &
                                             String.Join(",", (From i In val2 Select (i("campo").ToString.Trim & "='" & i("ValorAnterior").ToString.Trim & "'"))) & " where reloj='" & nom("reloj") & "';"
                                strQuerys.Add(strQry)
                            End If

                        End If
                    Next
                End If
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Ingresar empleados que estan en finiquitos pero no son tomados en cuenta durante la inicializacion -- Ernesto
    ''' </summary>
    ''' <param name="dtInfo"></param>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub empFiniquitosParaPersonal(dtInfo As DataTable, data As Dictionary(Of String, String), Optional tipoFiniquito As Integer = 0)
        Try
            Dim relojes = (From i In dtInfo.Rows Select i("reloj").ToString.Trim).ToList()
            Dim srtRlj = String.Join(",", (From i In relojes Select "'" & i & "'"))
            Dim dtPer = Sqlite.getInstance.sqliteExecute("select * from dtPersonal")
            Dim finOp = ""

            '== Si tipoFiniquito=0 [finiquito normal] de lo contrario finiquito especial [no es necesario validar finiquitos especiales con nomina_calculo, ya que en la interfaz se marcan los que se procesaran]
            If tipoFiniquito = 0 Then finOp = "and p.reloj not in (select reloj from nomina.dbo.nomina_calculo where status<>'CANCELADO')" Else finOp = ""

            Dim dtPerSQL = sqlExecute("select p.*, (SELECT top 1 fecha_mantenimiento FROM personal.dbo.bitacora_personal WHERE reloj = p.reloj AND campo='inactivo') as fecha_inac, " &
                                      "(SELECT top 1 factor from personal.dbo.rol_horarios where ano='" & data("ano") & "' and periodo = '" & data("periodo") & "' and COD_COMP=p.COD_COMP and COD_HORA = P.COD_HORA) as factor_dias, " &
                                      "RTRIM(P.NOMBRE) + ' ' + RTRIM(P.APATERNO) + ' ' + RTRIM(P.AMATERNO) as 'nombre_completo', " &
                                      "Pl.nombre as 'nombre_planta', " &
                                      "dpto.NOMBRE as 'nombre_dpto', " &
                                      "CC.cod_area " & _
                                      "FROM PERSONAL.dbo.personal AS P " &
                                      "JOIN PERSONAL.dbo.plantas AS Pl on P.COD_PLANTA = Pl.COD_PLANTA AND P.COD_COMP = Pl.COD_COMP " &
                                      "JOIN PERSONAL.dbo.deptos AS DPTO on DPTO.COD_COMP = P.COD_COMP and DPTO.COD_DEPTO = P.COD_DEPTO " &
                                      "JOIN PERSONAL.dbo.c_costos AS CC on CC.centro_costos = DPTO.CENTRO_COSTOS " &
                                      "WHERE p.reloj in (" & srtRlj & ") " & finOp)

            '== Revisa si es reingreso. [Si lo es, poner su alta y su baja a como lo tenia anteriormente]
            Dim dtFecPer = sqlExecute("SELECT TOP 1 * FROM TA.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " WHERE ISNULL(periodo_especial,0)=0 and ano+periodo='" & data("ano") & data("periodo") & "'")
            For Each fin In dtPerSQL.Rows
                Dim esReingreso = sqlExecute("SELECT TOP 1 * FROM PERSONAL.dbo.reingresos WHERE reloj='" & fin("reloj").ToString.Trim & "' AND baja_ant BETWEEN '" &
                                             FechaSQL(dtFecPer.Rows(0)("fecha_ini")) & "' and '" & FechaSQL(dtFecPer.Rows(0)("fecha_fin")) & "' ORDER BY fecha DESC")
                If esReingreso.Rows.Count > 0 Then
                    fin("alta") = esReingreso.Rows(0)("alta_ant")
                    fin("baja") = esReingreso.Rows(0)("baja_ant")
                End If
            Next

            If dtPerSQL.Rows.Count > 0 Then
                dtPer.Rows.Clear()
                dtPer.Columns.Remove("id")
                For Each emp In dtPerSQL.Rows
                    Dim dict As New Dictionary(Of String, Object)
                    For Each dataColumn In dtPer.Columns : dict.Add(dataColumn.ColumnName, emp(dataColumn.ColumnName).ToString()) : Next
                    Sqlite.getInstance().insert(dict, "dtPersonal")
                Next
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Establece como factor 1 a todos los finiquitos [En ajustesPro y horasPro] -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub FactorFiniquito(Optional relojManual As String = "",
                                      Optional ByRef strQuerys As ArrayList = Nothing)
        Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "')", "")
        Dim nomPro As DataTable = Sqlite.getInstance.sqliteExecute("SELECT reloj,factor_dias FROM nominaPro where finiquito='True' or finiquito_esp='True' " & String.Format(filtroIngresoManual, "and"))

        For Each fin As DataRow In nomPro.Rows

            If relojManual = "" And Not strQuerys Is Nothing Then
                strQuerys.Add("UPDATE ajustesPro SET factor='1' WHERE reloj='" & fin("reloj").ToString.Trim & "';")
                strQuerys.Add("UPDATE horasPro SET factor='1' WHERE reloj='" & fin("reloj").ToString.Trim & "';")
            End If

            If relojManual <> "" And strQuerys Is Nothing Then
                Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE ajustesPro SET factor='1' WHERE reloj='" & fin("reloj").ToString.Trim & "';")
                Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE horasPro SET factor='1' WHERE reloj='" & fin("reloj").ToString.Trim & "';")
            End If
        Next
    End Sub

    ''' <summary>
    ''' Inserta los saldos de fondo de ahorro (SAFAHC,SAFAHE,SAFAPE) en la tabla de movimientosPro, seg♪n corresponda, después del cálculo y antes de los finiquitos especiales [Ivette] -- Ernesto
    ''' </summary>
    ''' <param name="strAnio">Año del periodo analizado</param>
    ''' <param name="strPeriodo">Periodo analizado</param>
    ''' <remarks></remarks>
    Private Sub CorridaSaldosFondoAhorro(ByRef data As Dictionary(Of String, String), Optional strFiltroRelojes As String = "")
        Try
            'data("ano"), data("periodo"), data("tipoPeriodo")
            '== Querys
            Dim strQuerys As New ArrayList

            '== Contador animación
            Dim counter = 0

            '== Pensiones alimenticias
            Dim dtPensiones = Sqlite.getInstance.sqliteExecute("select reloj,SUM(porcentaje) as porcentaje from pensionesAlimenticias where activo='True' and (mercantil='False' or mercantil is null) GROUP BY reloj")

            '== Solo empleados que no sean finiquitos y que sean procesar=True -- Ernesto -- 27 julio 2023
            Dim dtNominaPro = Sqlite.getInstance.sqliteExecute("SELECT ano,periodo,reloj FROM nominaPro where procesar='True' and finiquito='False' and finiquito_esp='False' " & strFiltroRelojes)

            If dtNominaPro.Rows.Count > 0 Then
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Cálculo: Procesando saldo de fondo de ahorro" : Me.BgWorker.ReportProgress(0) : End If

                Dim strRelojes = String.Join(",", (From i In dtNominaPro Select "'" & i("reloj") & "'"))
                Dim dtMovimientosPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM movimientosPro where reloj in (" & strRelojes & ") and concepto in ('APOFAH','APOCIA')")

                '== Revisar si en periodo inicia el fondo de ahorro
                Dim strAnioAnt = "" : Dim strPerAnt = ""
                'Dim dtPeriodos = Sqlite.getInstance.sqliteExecute("SELECT ano,periodo FROM periodosNomPro WHERE ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and inicia_fondo=1")
                Dim dtPeriodos = sqlExecute("SELECT ano,periodo FROM ta.dbo." & data("tabla") & " WHERE ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and inicia_fondo=1")

                '== Suma de montos de fondo de ahorro y pensionados [si se da el caso]
                If dtPeriodos.Rows.Count > 0 Then
                    strAnioAnt = "9999"
                    strPerAnt = data("periodo")
                Else
                    '== Definir periodos para consulta en tabla de movimientos
                    strAnioAnt = IIf(data("periodo") = "01", CInt(data("ano")) - 1, data("ano"))
                    Select Case data("periodo") & data("tipoPeriodo")
                        Case "01S" : strPerAnt = "53"
                        Case "01Q" : strPerAnt = "24"
                        Case Else : strPerAnt = CStr(CInt(data("periodo")) - 1).PadLeft(2, "0")
                    End Select
                End If

                '== Si hay periodo anterior, se consulta la tabla de movimientos para sacar los conceptos de SAFAHE y SAFAHC. En caso contrario, solo se toma en cuenta el del periodo analizado
                Dim strQry = ""
                Dim dtMovimientos = sqlExecute("SELECT reloj,concepto,monto FROM NOMINA.dbo.movimientos " &
                                               "WHERE ano+periodo='" & strAnioAnt & strPerAnt & "' AND tipo_periodo='" & data("tipoPeriodo") & "' AND concepto IN ('SAFAHE','SAFAHC') " & strFiltroRelojes)
                Dim montoMovimientos = 0.0
                Dim montoMovimientosPro = 0.0

                For Each row In dtNominaPro.Rows

                    montoMovimientos = 0.0 : montoMovimientosPro = 0.0

                    '--- Saldo y aportacion de fondo de ahorro de empleado
                    Try : montoMovimientos = dtMovimientos.Select("reloj='" & row("reloj") & "' and concepto='SAFAHE'").First.Item("monto")
                    Catch ex As Exception : montoMovimientos = 0.0 : End Try
                    Try : montoMovimientosPro = dtMovimientosPro.Select("reloj='" & row("reloj") & "' and concepto='APOFAH'").First.Item("monto")
                    Catch ex As Exception : montoMovimientosPro = 0.0 : End Try

                    Dim saldoFondoEmpleado = Math.Round(montoMovimientos + montoMovimientosPro, 2)

                    '--- Saldo y aportacion de fondo de ahorro de empresa
                    Try : montoMovimientos = dtMovimientos.Select("reloj='" & row("reloj") & "' and concepto='SAFAHC'").First.Item("monto")
                    Catch ex As Exception : montoMovimientos = 0.0 : End Try
                    Try : montoMovimientosPro = dtMovimientosPro.Select("reloj='" & row("reloj") & "' and concepto='APOCIA'").First.Item("monto")
                    Catch ex As Exception : montoMovimientosPro = 0.0 : End Try

                    Dim saldoFondoEmpresa = Math.Round(montoMovimientos + montoMovimientosPro, 2)

                    strQry = "INSERT INTO movimientosPro (ano,periodo,tipo_nomina,reloj,concepto,monto) " &
                             "VALUES ('" & row("ano") & "','" & row("periodo") & "','N','" & row("reloj") & "','SAFAHE'," & saldoFondoEmpleado & ");" &
                             "INSERT INTO movimientosPro (ano,periodo,tipo_nomina,reloj,concepto,monto) " &
                             "VALUES ('" & row("ano") & "','" & row("periodo") & "','N','" & row("reloj") & "','SAFAHC'," & saldoFondoEmpresa & ");"


                    '--- Saldo de fondo de ahorro de pensionada
                    Dim pensiones = dtPensiones.Select("reloj='" & row("reloj") & "'")

                    If pensiones.Count > 0 Then
                        Dim saldoFondoPension = Math.Round(saldoFondoEmpresa * CInt(pensiones.First.Item("porcentaje")) / 100, 2)
                        strQry &= "INSERT INTO movimientosPro (ano,periodo,tipo_nomina,reloj,concepto,monto) " &
                                  "VALUES ('" & row("ano") & "','" & row("periodo") & "','N','" & row("reloj") & "','SAFAPE'," & saldoFondoPension & ");"
                    End If

                    '== Guardar querys movimientosPro
                    strQuerys.Add(strQry)
                    counter += 1

                    '== Animación de actualización
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(counter * 100 / dtNominaPro.Rows.Count - 1) : End If
                Next

                GuardaMovimientosTabla("Cálculo: Guardando saldo de fondo de ahorro", data, strQuerys)
            End If


        Catch ex As Exception
            MessageBox.Show("Error corrida saldo de fondo de ahorro: " & vbNewLine & ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Se identifican los montos negativos [si los hay] en movimientosPro después del cálculo -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConceptosMontoNegativo(ByRef data As Dictionary(Of String, String))
        Try
            If Not Me.BgWorker Is Nothing Then : Data("etapa") = "Cálculo: Revisión montos negativos" : Me.BgWorker.ReportProgress(0) : End If
            Dim dtMovsNegativos = Sqlite.getInstance.sqliteExecute("select distinct reloj,concepto,monto from movimientosPro where monto<0 and concepto<>'CREFIS'")

            If dtMovsNegativos.Rows.Count > 0 Then
                For Each row In dtMovsNegativos.Rows
                    Me.addLog("Alerta! Monto negativo detectado: Reloj [" & row("reloj") & "] Concepto [" & row("concepto") & "] Monto [" & row("monto") & "]")
                Next
            End If

        Catch ex As Exception : End Try
    End Sub


    ''' <summary>
    ''' Datatables con la información necesaria para iniciar el cálculo -- Ernesto -- 27 dic 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Function DatatablesInfoProceso(ByRef data As Dictionary(Of String, String), Optional strFiltroRelojes As Object = Nothing) As Dictionary(Of String, DataTable)
        Try
            '--- Diccionario dt
            Dim dicInfoDatatable As New Dictionary(Of String, DataTable)

            '--- Tablas de consulta
            Dim sqlAguiExcento = sqlExecute("SELECT " & If(Me._options("aguinaldo_anual"), "top 0", "") & " reloj, ano, sum(monto) as monto FROM NOMINA.dbo.movimientos WHERE ano+periodo >='" &
                             data("ano").Trim & "01' AND " & "periodo<='53' AND periodo<" & data("periodo") & " AND concepto='PEXAGI' " & strFiltroRelojes(1) & " group by reloj, ano")
            Dim sqlVacDetalle = sqlExecute("SELECT reloj, ano, sum(monto) as monto FROM NOMINA.dbo.movimientos WHERE ano+periodo <='" & data("ano").Trim & "53' AND " &
                                       "ano='" & Integer.Parse(data("ano").Trim) & "' AND periodo<" & data("periodo") & " AND concepto='PEXVAC' " & strFiltroRelojes(1) & " group by reloj, ano")
            Dim sqlCias = sqlExecute("SELECT * FROM PERSONAL.dbo.cias WHERE cod_comp in (" & data("codComp") & ")")
            Dim sqlIsptMensual = sqlExecute("SELECT * FROM NOMINA.dbo.ispt_pro_mensual")
            Dim sqlIsptQuin = sqlExecute("SELECT * FROM NOMINA.dbo.ispt_quincenal")
            Dim sqlIspt = sqlExecute("SELECT * FROM NOMINA.dbo.ispt_pro")

            Dim sqliteConceptos = Me.ConceptosPro
            Dim sqliteHorasPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM horasPro WHERE ano = '" & data("ano") & "' AND periodo= '" & data("periodo") & "' " & strFiltroRelojes(1))
            Dim sqlitePeriodos = sqlExecute("SELECT * FROM ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' ")
            Dim sqliteAjustesProC = Sqlite.getInstance.sqliteExecute("SELECT * FROM (SELECT * FROM ajustesPro) as T " &
                                                               "WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' " & strFiltroRelojes(1))
            Dim sqliteAjustesPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro " & strFiltroRelojes(0))
            Dim sqliteMtrodedBonos = sqlExecute("SELECT * FROM nomina.dbo.mtro_ded WHERE concepto='BONOS' and activo=1 " & strFiltroRelojes(1))
            Dim sqlitePensionesAlim = Sqlite.getInstance.sqliteExecute("SELECT * FROM pensionesAlimenticias WHERE activo='True' " & strFiltroRelojes(1))

            Dim sqlTurnos = sqlExecute("SELECT * FROM PERSONAL.dbo.turnos")

            '--- Crear variables para trabajar con movimientosPro y compensaciones en el cálculo
            dtMovsProLocal = Sqlite.getInstance.sqliteExecute("select * from movimientosPro limit 0") : dtMovsProLocal.Columns.Remove("id")
            dtMovsCompLocal = Sqlite.getInstance.sqliteExecute("select * from movimientosCompensacion limit 0") : dtMovsCompLocal.Columns.Remove("id")

            '--- Borrar contenido movimientos y compensaciones cada nuevo cálculo
            Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM movimientosPro " & strFiltroRelojes(0) & ";DELETE FROM movimientosCompensacion " & strFiltroRelojes(0) & "")

            '--- Reiniciar indices de tablas de movimientos y compensaciones
            Dim numRegMovs = Sqlite.getInstance.sqliteExecute("select count(id) as cuenta from movimientosPro").Rows(0)("cuenta")
            Dim numRegComp = Sqlite.getInstance.sqliteExecute("select count(id) as cuenta from movimientosCompensacion").Rows(0)("cuenta")
            If numRegMovs = 0 Then Sqlite.getInstance.ExecuteNonQueryFunc("update SQLITE_SEQUENCE set seq = 0 where name ='movimientosPro'")
            If numRegComp = 0 Then Sqlite.getInstance.ExecuteNonQueryFunc("update SQLITE_SEQUENCE set seq = 0 where name ='movimientosCompensacion'")

            '--- Dic. datatables
            dicInfoDatatable.Add("dtTurnos", sqlTurnos)
            dicInfoDatatable.Add("dtisptQuincenal", sqlIsptQuin)
            dicInfoDatatable.Add("dtisptPro", sqlIspt)
            dicInfoDatatable.Add("dtisptProMensual", sqlIsptMensual)
            dicInfoDatatable.Add("dtCias", sqlCias)
            dicInfoDatatable.Add("dtPeriodos", sqlitePeriodos)
            dicInfoDatatable.Add("dtHorasPro", sqliteHorasPro)
            dicInfoDatatable.Add("dtAjustesProC", sqliteAjustesProC)
            dicInfoDatatable.Add("dtAjustesPro", sqliteAjustesPro)
            dicInfoDatatable.Add("dtMtroDed", sqliteMtrodedBonos)
            dicInfoDatatable.Add("dtPensionesAlim", sqlitePensionesAlim)
            dicInfoDatatable.Add("dtAguiExcento", sqlAguiExcento)
            dicInfoDatatable.Add("dtPrimaVacDetalle", sqlVacDetalle)
            dicInfoDatatable.Add("dtConceptosPro", sqliteConceptos)

            Return dicInfoDatatable

        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Convierte un datatable a querys y los pasa a un arraylist -- Ernesto -- 27 dic 2023
    ''' </summary>
    ''' <param name="dtInfo"></param>
    ''' <remarks></remarks>
    Private Sub DatatableAQuerys(ByRef arreglo As ArrayList, ByRef dtInfo As DataTable, ByVal tabla As String)
        Try
            Dim strQuerys As New ArrayList
            Dim strCadena = "INSERT INTO " & tabla & " ({0}) VALUES ({1});"
            Dim strCols = ""
            Dim strVal = ""

            If dtInfo.Columns.Contains("id") Then dtInfo.Columns.Remove("id")
            For Each col As DataColumn In dtInfo.Columns
                strCols &= col.ColumnName & ","
            Next

            strCols = strCols.Remove(strCols.Length - 1)

            For Each emp In dtInfo.Rows
                strVal = ""
                For Each col In strCols.Split(",")
                    strVal &= If(IsDBNull(emp(col)), "NULL", "'" & emp(col) & "'") & ","
                Next
                strVal = strVal.Remove(strVal.Length - 1)
                strQuerys.Add(String.Format(strCadena, strCols, strVal))
            Next

            For Each q In strQuerys : arreglo.Add(q) : Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RecoleccionErrores()
        Try

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Función principal para el proceso de calculo, calculo compensacion y registros a movimientosPro -- Ernesto
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="calculoIndividual"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Proceso(ByRef data As Dictionary(Of String, String),
                            Optional calculoIndividual As List(Of String) = Nothing,
                            Optional recalculoRapido As Boolean = False) As Boolean
        Try
            '--- Variables
            Dim strFiltroRelojes = {"", ""}
            Dim counter = 1
            Dim noEmpleados = 0
            Dim strRelojSub = ""
            Dim dtRelojSub As New DataTable
            Dim dicInfoDatatable As New Dictionary(Of String, DataTable)
            Dim strErrores As New System.Text.StringBuilder

            If Not Me.BgWorker Is Nothing Then : data("etapa") = "Cálculo: Validacion datos" : Me.BgWorker.ReportProgress(0) : End If

            '--- Recalculo para un empleado desde interfaz
            If recalculoRapido Then
                Dim relojes = String.Join(",", (From i In calculoIndividual Select "'" & i & "'"))
                strFiltroRelojes(0) = "where reloj in (" & relojes & ")"
                strFiltroRelojes(1) = "and reloj in (" & relojes & ")"
                Me._options("incluir_ajuste_subsidio") = False
            Else
                '--- Incluir ajuste al subsidio
                If Me._options("incluir_ajuste_subsidio") Then

                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Cálculo: Agregando ajustes subsidio" : Me.BgWorker.ReportProgress(0) : End If
                    Dim sinDatos = False
                    AgregaRegSubsidiosAjustesPro(data, sinDatos)

                    If sinDatos Then
                        If MessageBox.Show("No existen registros de ajustes de subsidio para agregar al proceso de cálculo. ¿Desea continuar con el resto del proceso?",
                                        "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then
                            Return False
                        End If
                    Else
                        '--- Si hay datos en la tabla de ajustessubsidio, realizar el cálculo solo para eso relojes
                        dtRelojSub = Sqlite.getInstance.sqliteExecute("select distinct reloj from ajustesSubsidio order by reloj asc")
                        If dtRelojSub.Rows.Count > 0 Then
                            strRelojSub = String.Join(",", (From i In dtRelojSub Select "'" & i("reloj") & "'"))
                        End If
                    End If
                End If

                '--- Cálculo de relojes seleccionados o de subsidio
                If calculoIndividual.Count > 0 Or dtRelojSub.Rows.Count > 0 Then

                    Dim relojes = ""
                    Dim subsidio = dtRelojSub.Rows.Count > 0
                    Dim msj = If(dtRelojSub.Rows.Count > 0,
                                 "Se correrá el cálculo solo para los empleados con subsidio [" & dtRelojSub.Rows.Count & " empleado(s)]. ¿Desea correr el proceso de cálculo con este filtro?",
                                 "Existe un filtro de relojes seleccionados de manera individual [" & calculoIndividual.Count & " empleado(s)]. ¿Desea correr el proceso de cálculo?")

                    If MessageBox.Show(msj, "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

                        Select Case subsidio
                            Case True : relojes = strRelojSub
                            Case False : relojes = String.Join(",", (From i In calculoIndividual Select "'" & i & "'"))
                        End Select

                        strFiltroRelojes(0) = "where reloj in (" & relojes & ")"
                        strFiltroRelojes(1) = "and reloj in (" & relojes & ")"
                    Else
                        Return False
                    End If
                End If
            End If

            '--- Avisar si existen empleados con bajas antes del periodo -- 24 ene 2024
            AlertaEmpleadoBajaAntesPeriodo(strFiltroRelojes(1))
            '--- Datatables consulta
            dicInfoDatatable = DatatablesInfoProceso(data, strFiltroRelojes)
            '--- Personal directo y finiquitos normales
            Dim dtEmpleados = Sqlite.getInstance().sqliteExecute("SELECT * FROM nominaPro WHERE procesar = 'True' and finiquito_esp = 'False' " & strFiltroRelojes(1) & "")
            '--- Identificar empleados que son finiquitos
            Dim dtFiniquitosNor As New DataTable
            Try : dtFiniquitosNor = New DataView(dtEmpleados.Select("finiquito='True'").CopyToDataTable).ToTable(False, "reloj")
            Catch ex As Exception : dtFiniquitosNor = Sqlite.getInstance.sqliteExecute("select reloj,finiquito from nominaPro LIMIT 0") : End Try
            noEmpleados = dtEmpleados.Rows.Count + 1

            '--- Esta variable se utiliza si durante el cálculo, el neto es 0 o menor que 100 y dicho empleado tiene TIENDA o ADEINF [Adeudo de infonavit]. 
            Dim recalculo = True
            Dim rlj As String = ""
            Dim esFiniquitoNor = False
            Dim strQrysMovs As New ArrayList
            Dim strQrysComp As New ArrayList

            '--- Inicio del cálculo
            If Not Me.BgWorker Is Nothing Then : data("etapa") = "Cálculo: Progreso" : Me.BgWorker.ReportProgress(0) : End If

            For Each item In dtEmpleados.Rows

                rlj = item("reloj").ToString.Trim
                esFiniquitoNor = dtFiniquitosNor.Select("reloj='" & rlj & "'").Count > 0

                '--- Cálculo compensación
                'CalculoCompensacion(item, data, esFiniquitoNor, dicInfoDatatable)
                '--- Cálculo normal
                CalculoNormal(item, data, dicInfoDatatable, strFiltroRelojes, strErrores)
                '--- Cálculo bondes  
                'If (Me._options("incluir_bondes") And Not esFiniquitoNor) Then calculoBondes(item, data, "610", dicInfoDatatable)

                counter += 1
                DatatableAQuerys(strQrysMovs, dtMovsProLocal, "movimientosPro")
                dtMovsProLocal.Clear()
                'DatatableAQuerys(strQrysComp, dtMovsCompLocal, "movimientosCompensacion")
                'dtMovsCompLocal.Clear()

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / noEmpleados) : End If
                freeMemory()
                recalculo = True
            Next

            '--- Guardar movimientosPro y compensaciones
            'If strQrysComp.Count > 0 Then GuardaMovimientosTabla("Cálculo: Guardando movimientos compensaciones", data, strQrysComp)
            If strQrysMovs.Count > 0 Then GuardaMovimientosTabla("Cálculo: Guardando movimientos normales", data, strQrysMovs)

            '--- Si es aguinaldo anual, no realizar revision de montos negativos,corrida de saldo de fondo de ahorro,hrs extras -- Ernesto -- 24 oct 2023
            If Not Me._options("aguinaldo_anual") Then
                '--- Revisión de montos negativos en conceptos de movimientosPro [sqlite]
                ConceptosMontoNegativo(data)
                '--- Corrida de saldo de fondo de ahorro [sqlite]
                CorridaSaldosFondoAhorro(data, strFiltroRelojes(1))
                '--- Registros de horas extras [sqlite]
                IngresarConceptoHrsExtras(data, strFiltroRelojes(1))
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante el proceso de cálculo, por favor, revise el log y/o notifique al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.addLog("Error en el proceso de cálculo: " & ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_procesoCalculo", ex.HResult, ex.Message)
        End Try
    End Function


    ''' <summary>
    ''' Se ingresan en movimientos los registros de HR2SE1 Y HR3SE1 de empleados que tengan conceptos de HRSEX2 y HRSEX3 -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IngresarConceptoHrsExtras(ByRef data As Dictionary(Of String, String), strFiltro As String)
        Try
            Dim dtMovs = Sqlite.getInstance.sqliteExecute("select * from movimientosPro where concepto in ('HRSEX2','HRSEX3') " & strFiltro)
            Dim strQry As New ArrayList

            If dtMovs.Rows.Count > 0 Then
                For Each x In dtMovs.Rows
                    strQry.Add("insert into movimientosPro (ano,periodo,tipo_nomina,reloj,concepto,monto,prioridad,importar) values " &
                                "('" & x("ano") & "','" & x("periodo") & "',NULL,'" & x("reloj") & "','" &
                                If(x("concepto") = "HRSEX2", "HR2SE1", "HR3SE1") & "','" & x("monto") & "','0','0');")
                Next
                GuardaMovimientosTabla("Cálculo: Guardando conceptos hrs. extras", Data, strQry)
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Corrida de saldos de anticipo de aguinaldo-- Ernesto
    ''' </summary>
    ''' <param name="strFiltro"></param>
    ''' <remarks></remarks>
    Private Sub AnticipoAguinaldo(data As Dictionary(Of String, String), strFiltro As String)
        Try
            '-- Se valida que el acumulado solo se realice a empleados activos -- 1 nov 2023
            Dim dtPersonalActivo = sqlExecute("select reloj from personal.dbo.personal where cod_comp in ('610','700') and baja is null order by reloj asc")
            Dim strActivos = strFiltro

            If dtPersonalActivo.Rows.Count > 0 Then
                If strActivos.Length = 0 Then
                    strActivos = "and reloj in (" & String.Join(",", (From i In dtPersonalActivo Select "'" & i("reloj").ToString.Trim & "'")) & ")"
                Else
                    Dim dtFiltro = New DataView(dtPersonalActivo, strActivos.Replace("and", ""), "reloj asc", DataViewRowState.CurrentRows).ToTable("", False)
                    If dtFiltro.Rows.Count > 0 Then
                        strActivos = "and reloj in (" & String.Join(",", (From i In dtFiltro Select "'" & i("reloj").ToString.Trim & "'")) & ")"
                    Else
                        Exit Sub
                    End If
                End If
            End If


            Dim dtAntiAguinaldo = sqlExecute("select ano+periodo as periodo,anticipo_aguinaldo from ta.dbo.periodos where ano+periodo='" & data("ano") & data("periodo") &
                                             "' and isnull(periodo_especial,0)=0 and " & data("periodo") & ">=anticipo_aguinaldo")

            If dtAntiAguinaldo.Rows.Count > 0 Then
                If MessageBox.Show("Esta a punto de correr el anticipo de aguinaldo, por lo que se los registros existentes de los conceptos ACUDAG y SAANAG del periodo " & data("ano") & "-" & data("periodo") &
                                   If(strActivos.Length > 0, " para los empleados del filtro seleccionado", "") &
                                   " se eliminarán para ingresarlos nuevamente. ¿Desea continuar?", "Anticipo de aguinaldo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

                    If sqlExecute("select reloj from nomina.dbo.movimientos where concepto in ('ACUDAG','SAANAG') and ano+periodo='" & data("ano") & data("periodo") &
                                  "' and tipo_periodo='" & data("tipoPeriodo") & "' " & strActivos).Rows.Count > 0 Then

                        sqlExecute("delete from nomina.dbo.movimientos where concepto in ('ACUDAG','SAANAG') and ano+periodo='" & data("ano") & data("periodo") & "' and tipo_periodo='" & data("tipoPeriodo") & "' " & strActivos)
                    End If

                    Dim acudag = "use nomina;" &
                                 "INSERT INTO MOVIMIENTOS SELECT '" & data("ano") & "' as ANO,'" & data("periodo") & "' as PERIODO,'N' as TIPO_NOMINA,RELOJ,'ACUDAG' as concepto,sum(MONTO) as monto,PRIORIDAD,IMPORTAR,NUEVO," &
                                 "'S' as TIPO_PERIODO,PER_CALENDARIO,cod_comp FROM MOVIMIENTOS " &
                                 "WHERE ano='" & data("ano") & "' and periodo>='" & dtAntiAguinaldo.Rows(0)("anticipo_aguinaldo") & "' " & If(strActivos.Length > 0, strActivos, "") &
                                 " AND PERIODO<='53' and tipo_periodo='S' and concepto='DIASAG' " &
                                 "GROUP BY RELOj,prioridad,importar,nuevo,per_calendario,cod_comp"

                    sqlExecute(acudag)

                    Dim saanag = "use nomina;" &
                                 "INSERT INTO MOVIMIENTOS SELECT '" & data("ano") & "' as ANO,'" & data("periodo") & "' as PERIODO,'N' as TIPO_NOMINA,RELOJ,'SAANAG' as concepto,sum(MONTO) as monto,PRIORIDAD,IMPORTAR,NUEVO," &
                                 "'S' as TIPO_PERIODO,PER_CALENDARIO,cod_comp FROM MOVIMIENTOS " &
                                 "WHERE ano='" & data("ano") & "' and periodo>='" & dtAntiAguinaldo.Rows(0)("anticipo_aguinaldo") & "' " & If(strActivos.Length > 0, strActivos, "") &
                                 " AND PERIODO<='53' and tipo_periodo='S' and concepto='PERAGI' " &
                                 "GROUP BY RELOj,prioridad,importar,nuevo,per_calendario,cod_comp"

                    sqlExecute(saanag)
                End If
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Proceso en el cual se asentua la nómina en el proceso [tablas de nominaPro a nomina y movimientosPro a movimientos] -- Ernesto -- Modif. para aguinaldo 29 nov 2023
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="calculoIndividual"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Asentar(data As Dictionary(Of String, String), Optional calculoIndividual As List(Of String) = Nothing) As Boolean
        Try

            '-- Seccion para asentar de periodos especiales
            If Me._options("aguinaldo_anual") Then
                AsentarEspecial(data, calculoIndividual)
            Else
                Dim strFiltroRelojes = {""}
                Dim noEmpleados = 0
                Dim contador = 0
                Dim indivduales = False

                '-- Fecha final del periodo
                Dim fhaFinPeriodo = ""
                Try : fhaFinPeriodo = FechaSQL(sqlExecute("select fecha_fin from ta.dbo.periodos where ano+periodo='" & data("ano") & data("periodo") & "'").Rows(0)("fecha_fin"))
                Catch ex As Exception : fhaFinPeriodo = "" : End Try

                '--- Relojes para cálculo individual
                If calculoIndividual.Count > 0 Then
                    If MessageBox.Show("Existen relojes seleccionados de manera individual. ¿Desea correr el proceso de asentar solo para los empleados indicados?. " & vbNewLine &
                                       "NOTA: Solo se actualizarán los registros de los relojes seleccionados", "Aviso",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        strFiltroRelojes(0) = "and reloj in (" & String.Join(",", (From i In calculoIndividual Select "'" & i & "'")) & ")"
                        indivduales = True
                    Else
                        Exit Function
                    End If
                End If

                '--- Información de nominaPro, movimientosPro y periodos
                Dim dtNominaPro = Sqlite.getInstance.sqliteExecute("SELECT cod_comp,cod_pago,periodo,ano,reloj,nombres,sactual,integrado,cod_depto,cod_turno,cod_puesto,cod_super,cod_hora,cod_tipo,cod_clase,alta,baja FROM nominaPro WHERE procesar='True' " & strFiltroRelojes(0))
                Dim dtMovimientosPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM movimientosPro WHERE " &
                                                                        "ano='" & data("ano") & "' and periodo='" & data("periodo") & "' " & strFiltroRelojes(0))

                Dim dtPeriodos = sqlExecute("select * from ta.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                            " where ano in ('" & data("ano") & "','" & CInt(data("ano")) - 1 & "') and PERIODO_ESPECIAL=0 order by ano,periodo")

                '--- ADVERTENCIA SI NO HAY REGISTROS TANTO EN NOMINA COMO EN MOVIMIENTOS
                If dtNominaPro.Rows.Count = 0 Or dtMovimientosPro.Rows.Count = 0 Then
                    Dim regVacios = {dtNominaPro.Rows.Count, dtMovimientosPro.Rows.Count}
                    Dim strMsj = {IIf(regVacios(0) = 0 Or regVacios(1) > 0, "nómina",
                                     IIf(regVacios(0) > 1 Or regVacios(1) = 0, "movimientos",
                                         IIf(regVacios(0) = 0 Or regVacios(1) = 0, "nómina y movimientos", ""))), ""}

                    strMsj(1) = IIf(strMsj(0) = "nómina", "por favor, rectifique la existencia de registros en la tabla de empleados y/o tenga relojes seleccionados para trabajar.",
                                    IIf(strMsj(0) = "movimientos", "por favor, rectifique que se haya ejecutado previamente el paso de 'procesar' para el cálculo.",
                                        IIf(strMsj(0) = "nómina y movimientos", "por favor, rectifique que se tengan registros en la tabla de empleados y/o tenga relojes seleccionados para trabajar y haber realizado el paso de 'procesar' para el cálculo", "")))


                    MessageBox.Show("No existen registros en " & strMsj(0) & ", " & strMsj(1), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                End If

                '--- PRIMER PASO: INSERCION DE MOVIMIENTOSPRO A NOMINA.DBO.MOVIMIENTOS
                If dtMovimientosPro.Rows.Count > 0 Then

                    '--- Mensaje de progreso inicial en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Ingresando movimientos" : Me.BgWorker.ReportProgress(0) : End If

                    '--- Eliminar registros de NOMINA.dbo.movimientos e insertar los nuevos registros obtenidos de movimientosPro 
                    sqlExecute("DELETE FROM NOMINA.dbo.movimientos WHERE ANO+PERIODO+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' " & strFiltroRelojes(0))

                    Dim strQryMovimientos = "INSERT INTO NOMINA.dbo.movimientos (ANO,PERIODO,RELOJ,CONCEPTO,MONTO,tipo_periodo,tipo_nomina) VALUES " &
                                            "('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                    Dim strCodComp = ""

                    '--- Total movimientos
                    noEmpleados = dtMovimientosPro.Rows.Count

                    For Each rowM In dtMovimientosPro.Rows
                        '-- Correccion de cod_comp si es vacio -- Ernesto -- 27 julio 2023
                        Try : strCodComp = dtNominaPro.Select("reloj='" & rowM("reloj") & "'").First.Item("cod_comp") : Catch ex As Exception : strCodComp = "" : End Try
                        sqlExecute(String.Format(strQryMovimientos, rowM("ano"), rowM("periodo"), rowM("reloj"), rowM("concepto"), rowM("monto"), data("tipoPeriodo"), "N"))
                        contador += 1
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * contador / noEmpleados) : End If
                        freeMemory()
                    Next
                End If

                '--- Actualiza campo de tipo de pago en personal de acuerdo a si en la tabla 'detalle_auxiliares' tienen la variable 'Generar deposito' como 'NO' -- Ernesto -- 13 julio 2023
                Dim val = (From i In dtNominaPro.Rows Select i("reloj").ToString.Trim).ToList()
                If val.Count > 0 Then
                    Dim rlj = String.Join(",", From i In val Select "'" & i.ToString & "'")
                    Dim strQryAux = "update personal.dbo.personal set tipo_pago='S',cuenta_banco=null,clabe=null,banco=null where reloj in " &
                                    "(select reloj from personal.dbo.detalle_auxiliares where campo='NOPAGO' and contenido='NO' and reloj in (" & rlj & "))"
                    sqlExecute(strQryAux)
                End If

                '--- SEGUNDO PASO: INSERCION DE NOMINAPRO A NOMINA.DBO.NOMINA
                '--- Inserción en la tabla de nómina [Query Ivette]
                contador = 0
                noEmpleados = 0
                Dim strQryNomina = "insert into NOMINA.dbo.nomina " &
                                    "select " &
                                    "'0' as FOLIO,'' as PAGINA,'N' as COD_TIPO_nomina," &
                                    "case when (select contenido from PERSONAL.dbo.detalle_auxiliares where campo = 'NOPAGO' and detalle_auxiliares.reloj = personalvw.RELOJ) = 'NO' " &
                                    "then 'S' " &
                                    "else case when personalvw.COD_SUB_BA = '24' and baja is not null " &
                                    "then 'A' " &
                                    "else case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(CUENTA_BANCO, ''))) then 'D' else case when len(rtrim(isnull(CUENTA_BANCO, '')))=0 " &
                                    "then 'E' " &
                                    "else'B' end end end end as COD_PAGO,'" & data("periodo") & "' as  PERIODO, '" & data("ano") & "' as ANO,RELOJ,NOMBRES,'' as MES, 0 as HORAS_NORMALES, 0 as HORAS_DOBLES," &
                                    "0 as HORAS_TRIPLES, 0 as HORAS_FESTIVAS, 0 as HORAS_DESCANSO," &
                                    "0 as HORAS_DOMINGO, 0 as HORAS_COMPENSA," &
                                    "0 as DIAS_VAC, 0 as DIAS_AGUI, SACTUAL, INTEGRADO, COD_DEPTO, COD_TURNO, COD_PUESTO, COD_SUPER," &
                                    "COD_HORA, COD_TIPO, COD_CLASE, ALTA, BAJA,1 as DEPOSITO,'" & data("periodo") & "' as PERIODO_ACT,case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(cuenta_banco, ''))) then " &
                                    "clabe else CUENTA_BANCO end,COD_PLANTA,cod_comp," &
                                    "null as FOLIO_CFDI, null as FECHA_CFDI,null as CERTIFICADO_CFDI,null as UBICACION_ARCHIVO_CFDI,null as REFERENCIA_DAP," &
                                    "0 as info_vsm,0 as info_porc,infonavit as info_cred,0 as fah_porc," &
                                    "'01' as banco, '' as info_cuota, '' as cla_ban, 0 as impresa, '' as comentario,'' as firma, '" & data("tipoPeriodo") & "' as tipo_periodo,null as recalc_nom,null as cod_area,null as cod_costos,tipo_cre " &
                                    "from personal.dbo.personalvw where reloj in (" &
                                    "select reloj from NOMINA.dbo.movimientos where ano+periodo+tipo_periodo = '" & data("ano") & data("periodo") & data("tipoPeriodo") &
                                    "' and concepto not in ('SAFAHE','SAFAHC','SALPRF','SAFAPE','ACUDAG','SAANAG')" &
                                    ") " & strFiltroRelojes(0)

                If dtNominaPro.Rows.Count > 0 Then
                    '--- Total empleados
                    noEmpleados = dtNominaPro.Rows.Count

                    '** Mensaje de progreso inicial en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Ingresando nómina" : Me.BgWorker.ReportProgress(0) : End If

                    '--- Eliminar registros de NOMINA.dbo.nomina e insertar los nuevos registros obtenidos de nominaPro 
                    sqlExecute("DELETE FROM NOMINA.dbo.nomina WHERE ANO+PERIODO+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' " & strFiltroRelojes(0))
                    sqlExecute(strQryNomina)

                    '** Mensaje de progreso inicial en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Actualizando campos de nomina con nominaPro" : Me.BgWorker.ReportProgress(100 * 1 / 6) : End If

                    '--- Actualizar campos de nomina con los campos que tiene en nominaPro [Para que no se quede con los valores actualizados de personal; Es posible que antes del asentar se hayan hecho cambios en personal]
                    Dim strQry = "update nomina.dbo.nomina set {0} where ano+periodo+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' and reloj={1}"
                    Dim cols = {"cod_comp", "periodo", "ano", "sactual", "integrado", "cod_depto", "cod_turno", "cod_puesto", "cod_super", "cod_hora", "cod_tipo", "cod_clase", "alta", "baja"}
                    Dim strCampos = ""
                    For Each row In dtNominaPro.Rows
                        For Each s In cols
                            strCampos &= s & "=" & If(IsDBNull(row(s)), "NULL", "'" & row(s).ToString.Trim & "'") & ","
                        Next
                        sqlExecute(String.Format(strQry, strCampos.Substring(0, strCampos.Length - 1), "'" & row("reloj").ToString.Trim) & "'")
                        strCampos = ""
                    Next

                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Revisiones adicionales [bancos,cuentas]" : Me.BgWorker.ReportProgress(100 * 2 / 6) : End If

                    '--- Revisiones adicionales [de acuerdo a query de Ivette]
                    Dim anoPerTipo = data("ano") & data("periodo") & data("tipoPeriodo")
                    Dim strQryAdicional = "update nomina.dbo.nomina set banco = null where ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "' and cod_pago = 'D';" &
                    "update nomina.dbo.nomina set cuenta = '' where cod_pago = 'E' and ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "';" &
                    "update nomina.dbo.nomina set cuenta='' where  ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "' and cod_pago = 'S';" &
                    "update nomina.dbo.nomina set nombres='SANCHEZ,ARMAS,CARLOS DARLO' where reloj='061344' and ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "'"
                    sqlExecute(strQryAdicional)

                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Adquiriendo info. de tipo de pagos" : Me.BgWorker.ReportProgress(100 * 3 / 6) : End If

                    '--- Agrupar por tipo de pagos [mostrar en log]
                    strQryAdicional = "select nomina.COD_PAGO, " &
                                      "COUNT(nomina.reloj) AS NO_REGISTROS," &
                                      "CASE WHEN nomina.COD_PAGO='B' THEN 'BANAMEX' WHEN nomina.COD_PAGO='D' THEN 'INTERBANCARIOS' " &
                                      "WHEN nomina.COD_PAGO='E' THEN 'ORDENES DE PAGO' WHEN nomina.COD_PAGO='S' THEN 'CONVENIOS' ELSE '' END AS TIPO_PAGO " &
                                      "from nomina.dbo.nomina where ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "' group by nomina.cod_pago"
                    Dim dtTipoPagosNomina = sqlExecute(strQryAdicional)

                    If dtTipoPagosNomina.Rows.Count > 0 Then
                        Me.addLog("Tipos de pagos:")
                        For Each drow In dtTipoPagosNomina.Rows
                            Me.addLog(String.Format("Tipo de pago: {0} - {1}  Número de registros: {2}", drow("cod_pago").ToString.Trim, drow("tipo_pago"), drow("no_registros")))
                        Next
                    End If

                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Adquiriendo info. de cuentas duplicadas" : Me.BgWorker.ReportProgress(100 * 4 / 6) : End If

                    '--- Agrupar por cuentas duplicadas [mostrar log]
                    strQryAdicional = "select CUENTA,count(reloj) as cuantos from nomina.dbo.nomina where ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "' and " &
                                      "cuenta is not null and cuenta<>'' group by cuenta having count(reloj)>1"
                    Dim dtCuentasDuplicadas = sqlExecute(strQryAdicional)

                    If dtCuentasDuplicadas.Rows.Count > 0 Then
                        Me.addLog("Cuentas duplicadas:")
                        For Each drow In dtTipoPagosNomina.Rows
                            Me.addLog(String.Format("Cuenta: {0}  No. duplicados: {1}", drow("cuenta").ToString.Trim, drow("cuantos")))
                        Next
                    End If

                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Registro automático de préstamos de fondo de ahorro" : Me.BgWorker.ReportProgress(100 * 5 / 6) : End If

                    '--- A partir de sem 50-2021 se registran automaticamente los prestamos de fondo de ahorro al momento de exportarlos, 
                    '--- solo los voy a ir copiando de un periodo al otro IVO
                    Dim perAnt = PeriodoAnterior(data("periodo") & data("ano"), dtPeriodos)

                    strQryAdicional = "delete from nomina.dbo.movimientos where ANO+PERIODO+tipo_periodo = '" & anoPerTipo & "' and concepto='SALPRF' " & strFiltroRelojes(0)
                    sqlExecute(strQryAdicional)

                    strQryAdicional = "INSERT INTO NOMINA.dbo.MOVIMIENTOS SELECT '" & data("ano") & "' as ANO,'" & data("periodo") & "' as PERIODO," &
                                      "'N' as TIPO_NOMINA,RELOJ,'SALPRF' as concepto,monto,PRIORIDAD,IMPORTAR,NUEVO," &
                                      "'" & data("tipoPeriodo") & "' as TIPO_PERIODO,PER_CALENDARIO,cod_comp FROM NOMINA.dbo.MOVIMIENTOS " &
                                      "WHERE ano='" & perAnt.Substring(2, 4) & "' and periodo='" & perAnt.Substring(0, 2) & "' and concepto='SALPRF' AND tipo_periodo='" & data("tipoPeriodo") & "' " & strFiltroRelojes(0)
                    sqlExecute(strQryAdicional)

                    '--- Aplicar descuentos de saldos
                    AplicarDescuentosSaldos(data, strFiltroRelojes(0))

                    '--- Anticipo de aguinaldo
                    AnticipoAguinaldo(data, strFiltroRelojes(0))

                End If

                '** Mensaje de progreso en interfaz
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Actualizando integrado natural en personal" : Me.BgWorker.ReportProgress(100 * 6 / 6) : End If

                '--- Información para el cálculo del integrado natural
                If MessageBox.Show("¿Desea aplicar el cálculo de integrado natural en la tabla de personal?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

                    Dim dtPer = sqlExecute("select reloj,alta_vacacion,cod_tipo,cod_clase,cod_comp,sactual from personal.dbo.personal where cod_comp in ('610','700') and baja is null order by reloj asc")
                    Dim dtAgui = sqlExecute("select cod_comp,cod_tipo,anos,dias from personal.dbo.agui")
                    Dim dtVac = sqlExecute("select cod_comp,cod_tipo,anos,dias,por_prima from personal.dbo.vacaciones")
                    Dim dtCias = sqlExecute("select cod_comp,uma from personal.dbo.cias where cod_comp in ('610','700')")
                    Dim integradoNatural = 0.0
                    Dim qry As New System.Text.StringBuilder

                    If dtPer.Rows.Count > 0 Then
                        For Each p As DataRow In dtPer.Rows
                            integradoNatural = CalculaIntegradoNatural(p, dtAgui, dtVac, dtCias, p("reloj").ToString.Trim)
                            qry.Append("update personal.dbo.personal set integrado_natural=" & Math.Round(integradoNatural, 2) & " where reloj='" & p("reloj").trim & "' and cod_comp='" & p("cod_comp").Trim & "';")
                        Next
                        sqlExecute(qry.ToString)
                    End If

                End If
            End If

            freeMemory()

        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Funcion para asentar periodos especiales como aguinaldo -- Ernesto -- 29 nov 2023
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AsentarEspecial(data As Dictionary(Of String, String), Optional calculoIndividual As List(Of String) = Nothing)
        Try
            Dim strFiltroRelojes = {""}
            Dim noEmpleados = 0
            Dim contador = 0
            Dim indivduales = False

            '-- Relojes para cálculo individual
            If calculoIndividual.Count > 0 Then
                If MessageBox.Show("Existen relojes seleccionados de manera individual. ¿Desea correr el proceso de asentar especial solo para los empleados indicados?. " & vbNewLine &
                                   "NOTA: Solo se actualizarán los registros de los relojes seleccionados", "Aviso",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    strFiltroRelojes(0) = "and reloj in (" & String.Join(",", (From i In calculoIndividual Select "'" & i & "'")) & ")"
                    indivduales = True
                Else
                    Exit Sub
                End If
            End If

            '-- Información de nominaPro, movimientosPro y periodos
            Dim dtNominaPro = Sqlite.getInstance.sqliteExecute("SELECT cod_comp,cod_pago,periodo,ano,reloj,nombres,sactual,integrado,cod_depto,cod_turno,cod_puesto,cod_super,cod_hora,cod_tipo,cod_clase,alta,baja FROM nominaPro WHERE procesar='True' " & strFiltroRelojes(0))
            Dim dtMovimientosPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM movimientosPro WHERE " &
                                                                    "ano='" & data("ano") & "' and periodo='" & data("periodo") & "' " & strFiltroRelojes(0))

            '-- Advertencia si no hay registro en nominaPro y movimientosPro
            If dtNominaPro.Rows.Count = 0 Or dtMovimientosPro.Rows.Count = 0 Then
                Dim regVacios = {dtNominaPro.Rows.Count, dtMovimientosPro.Rows.Count}
                Dim strMsj = {IIf(regVacios(0) = 0 Or regVacios(1) > 0, "nómina",
                                 IIf(regVacios(0) > 1 Or regVacios(1) = 0, "movimientos",
                                     IIf(regVacios(0) = 0 Or regVacios(1) = 0, "nómina y movimientos", ""))), ""}

                strMsj(1) = IIf(strMsj(0) = "nómina", "por favor, rectifique la existencia de registros en la tabla de empleados y/o tenga relojes seleccionados para trabajar.",
                                IIf(strMsj(0) = "movimientos", "por favor, rectifique que se haya ejecutado previamente el paso de 'procesar' para el cálculo.",
                                    IIf(strMsj(0) = "nómina y movimientos", "por favor, rectifique que se tengan registros en la tabla de empleados y/o tenga relojes seleccionados para trabajar y haber realizado el paso de 'procesar' para el cálculo", "")))


                MessageBox.Show("No existen registros en " & strMsj(0) & ", " & strMsj(1), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub
            End If

            '-- Insertar movimientoPro a movimientos
            If dtMovimientosPro.Rows.Count > 0 Then

                '-- Mensaje de progreso inicial en interfaz
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Ingresando movimientos especiales" : Me.BgWorker.ReportProgress(0) : End If

                '-- Eliminar registros de NOMINA.dbo.movimientos e insertar los nuevos registros obtenidos de movimientosPro 
                Dim strQryMovimientos = "INSERT INTO NOMINA.dbo.movimientos (ANO,PERIODO,RELOJ,CONCEPTO,MONTO,tipo_periodo,tipo_nomina,cod_comp) VALUES " &
                                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})"
                Dim strCodComp = ""

                sqlExecute("DELETE FROM NOMINA.dbo.movimientos WHERE ANO+PERIODO+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' " & strFiltroRelojes(0))

                '-- Total movimientos
                noEmpleados = dtMovimientosPro.Rows.Count

                For Each rowM In dtMovimientosPro.Rows

                    '-- Corrección de cod_comp si es vacio -- Ernesto -- 27 julio 2023
                    Try : strCodComp = dtNominaPro.Select("reloj='" & rowM("reloj") & "'").First.Item("cod_comp") : Catch ex As Exception : strCodComp = "''" : End Try
                    sqlExecute(String.Format(strQryMovimientos, rowM("ano"), rowM("periodo"), rowM("reloj"), rowM("concepto"), rowM("monto"), data("tipoPeriodo"), "N", strCodComp))
                    contador += 1

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * contador / noEmpleados) : End If
                    freeMemory()
                Next
            End If

            '-- Insertar nominaPro a nomina
            Dim strQryNomina = "insert into NOMINA.dbo.nomina " &
                               "select " &
                               "'0' as FOLIO,'' as PAGINA,'N' as COD_TIPO_nomina," &
                               "case when (select contenido from PERSONAL.dbo.detalle_auxiliares where campo = 'NOPAGO' and detalle_auxiliares.reloj = personalvw.RELOJ) = 'NO' " &
                               "then 'S' " &
                               "else case when personalvw.COD_SUB_BA = '24' and baja is not null " &
                               "then 'A' " &
                               "else case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(CUENTA_BANCO, ''))) then 'D' else case when len(rtrim(isnull(CUENTA_BANCO, '')))=0 " &
                               "then 'E' " &
                               "else'B' end end end end as COD_PAGO,'" & data("periodo") & "' as  PERIODO, '" & data("ano") & "' as ANO,RELOJ,NOMBRES,'' as MES, 0 as HORAS_NORMALES, 0 as HORAS_DOBLES," &
                               "0 as HORAS_TRIPLES, 0 as HORAS_FESTIVAS, 0 as HORAS_DESCANSO," &
                               "0 as HORAS_DOMINGO, 0 as HORAS_COMPENSA," &
                               "0 as DIAS_VAC, 0 as DIAS_AGUI, SACTUAL, INTEGRADO, COD_DEPTO, COD_TURNO, COD_PUESTO, COD_SUPER," &
                               "COD_HORA, COD_TIPO, COD_CLASE, ALTA, BAJA,1 as DEPOSITO,'" & data("periodo") & "' as PERIODO_ACT,case when len(rtrim(isnull(clabe, '')))>len(rtrim(isnull(cuenta_banco, ''))) then " &
                               "clabe else CUENTA_BANCO end,COD_PLANTA,cod_comp," &
                               "null as FOLIO_CFDI, null as FECHA_CFDI,null as CERTIFICADO_CFDI,null as UBICACION_ARCHIVO_CFDI,null as REFERENCIA_DAP," &
                               "0 as info_vsm,0 as info_porc,'' as info_cred,0 as fah_porc," &
                               "'01' as banco, '' as info_cuota, '' as cla_ban, 0 as impresa, '' as comentario,'' as firma, '" & data("tipoPeriodo") & "' tipo_periodo,0 as baja_aus " &
                               "from personal.dbo.personalvw where reloj in (" &
                               "select reloj from NOMINA.dbo.movimientos where ano+periodo+tipo_periodo = '" & data("ano") & data("periodo") & data("tipoPeriodo") &
                               "' and concepto not in ('SAFAHE','SAFAHC','SALPRF','SAFAPE','ACUDAG','SAANAG')" &
                               ") " & strFiltroRelojes(0)

            If dtNominaPro.Rows.Count > 0 Then

                '-- Total empleados
                noEmpleados = dtNominaPro.Rows.Count
                contador = 0

                '-- Mensaje de progreso inicial en interfaz
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Ingresando nómina especial" : Me.BgWorker.ReportProgress(0) : End If

                '-- Ingreso de registros a nomina
                sqlExecute("DELETE FROM NOMINA.dbo.nomina WHERE ANO+PERIODO+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' " & strFiltroRelojes(0))
                sqlExecute(strQryNomina)

                '-- Mensaje de progreso inicial en interfaz
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Asentando nómina: Actualizando campos de nomina" : Me.BgWorker.ReportProgress(0) : End If

                '-- Actualizar campos de nomina con los campos que tiene en nominaPro 
                Dim strQry = "update nomina.dbo.nomina set {0} where ano+periodo+tipo_periodo='" & data("ano") & data("periodo") & data("tipoPeriodo") & "' and reloj={1}"
                Dim cols = {"cod_comp", "periodo", "ano", "sactual", "integrado", "cod_depto", "cod_turno", "cod_puesto", "cod_super", "cod_hora", "cod_tipo", "cod_clase", "alta", "baja"}
                Dim strCampos = ""
                For Each row In dtNominaPro.Rows
                    For Each s In cols
                        strCampos &= s & "=" & If(IsDBNull(row(s)), "NULL", "'" & row(s).ToString.Trim & "'") & ","
                    Next
                    sqlExecute(String.Format(strQry, strCampos.Substring(0, strCampos.Length - 1), "'" & row("reloj").ToString.Trim) & "'")
                    strCampos = ""
                    contador += 1
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * contador / noEmpleados) : End If
                Next

            End If


        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función que se encarga de calcular el integrado natural de un empleado. -- Ernesto
    ''' </summary>
    ''' <param name="dtPerInfo">Tabla de personal.dbo.personal</param>
    ''' <param name="dtAgui">Tabla de personal.dbo.agui</param>
    ''' <param name="strReloj">Reloj de empleado</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalculaIntegradoNatural(ByVal rowInfo As DataRow, ByVal dtAgui As DataTable, ByVal dtVac As DataTable, ByVal dtCias As DataTable, ByVal strReloj As String) As Decimal

        Dim agui = 0.0
        Dim privac = 0.0
        Dim despensa = 0.0

        Dim alta_antig = Convert.ToDateTime(rowInfo.Item("alta_vacacion"))
        Dim cod_tipo = rowInfo.Item("cod_tipo").ToString.Trim
        Dim cod_clase = rowInfo.Item("cod_clase").ToString.Trim
        Dim cod_comp = rowInfo.Item("cod_comp").ToString.Trim
        Dim sactual = rowInfo.Item("sactual")
        Dim uma = dtCias.Select("cod_comp='" & cod_comp & "'").First.Item("uma")

        '-- Antiguedad
        Dim antiguedad = 0
        antiguedad = Math.Floor((DateDiff(DateInterval.Day, Convert.ToDateTime(alta_antig), Date.Now) / 365.25)) + 1

        '-- Aguinaldo
        Dim aguiInfo = dtAgui.Select("cod_tipo='" & cod_tipo & "' and anos='" & antiguedad & "' and cod_comp='" & cod_comp & "'")
        If aguiInfo.Count > 0 Then
            agui = aguiInfo.First.Item("dias") * sactual
        End If

        '-- Prima vacacional
        Dim vacInfo = dtVac.Select("cod_tipo='" & If(cod_clase = "G", "A", cod_tipo) & "' and anos='" & antiguedad & "' and cod_comp='" & cod_comp & "'")
        If vacInfo.Count > 0 Then
            privac = vacInfo.First.Item("dias") * vacInfo.First.Item("por_prima") / 100 * sactual
        End If

        '-- Despensa
        despensa = If(cod_tipo = "A", 0.1, 0.115) * sactual * 365
        despensa = If(despensa > uma * 365, uma * 365, despensa)

        '-- Total
        Return ((agui + privac + despensa) / 365) + sactual

    End Function

    ''' <summary>
    ''' Función que se encarga de correr los descuentos de los saldos en las tablas de maestros de deducciones e infonavit -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AplicarDescuentosSaldos(data As Dictionary(Of String, String), Optional filtro As String = "")
        Try
            '== Se solicita al usuario que confirme este paso
            If MessageBox.Show("¿Desea aplicar los descuentos de saldos para maestro de deducciones e infonavit",
                               "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

                '== Se verifica que ya exista una nomina asentada -- Correccion de filtro -- Ernesto -- 27 julio 2023
                Dim dtMovsAsentados As DataTable = sqlExecute("SELECT * FROM NOMINA.dbo.movimientos WHERE ano+periodo+tipo_periodo='" &
                                                              data("ano") & data("periodo") & data("tipoPeriodo") & "' " & filtro.Replace("and", "where"))

                If dtMovsAsentados.Rows.Count > 0 Then

                    '== Tomar solo los relojes de movimientos
                    Dim dtMovsRelojes = sqlExecute("select distinct reloj from nomina.dbo.movimientos " & filtro)
                    Dim strRelojes = "and reloj in (" & String.Join(",", (From i In dtMovsRelojes Select "'" & i("reloj").ToString.Trim & "'")) & ")"

                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Aplicación de descuentos de saldos: Maestro de deducciones" : Me.BgWorker.ReportProgress(0) : End If

                    '== Maestro de deducciones
                    Dim dtMtroDed As DataTable = sqlExecute("SELECT * FROM NOMINA.dbo.mtro_ded WHERE " &
                                                            "ultimo_per='" & data("periodo") & "' and ultimo_ano='" & data("ano") & "' and tipo_perio='" & data("tipoPeriodo") & "' " & strRelojes)

                    If dtMtroDed.Select("concepto='FNAALC'").Count > 0 Then
                        MessageBox.Show("El periodo que desea aplicar ya se ha aplicado anteriormente, no es posible continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else

                        dtMtroDed = sqlExecute("select id,reloj,concepto,sald_act,activo,fijo from nomina.dbo.mtro_ded where activo=1 and sald_act>0 " & strRelojes)

                        For Each row In dtMtroDed.Rows
                            Dim infoMov = dtMovsAsentados.Select("reloj='" & row("reloj").ToString.Trim & "' and concepto='" & row("concepto").ToString.Trim & "'")

                            If infoMov.Count > 0 Then
                                Dim saldoFinal = Math.Round(row("sald_act") - infoMov.First.Item("monto"), 2)

                                sqlExecute("UPDATE NOMINA.dbo.mtro_ded SET ultimo_per='" & data("periodo") & "',ultimo_ano='" & data("ano") & "',sald_act='" & saldoFinal & "' WHERE id=" & row("id"))

                                If saldoFinal <= 0 And row("activo") And Not row("fijo") Then
                                    sqlExecute("UPDATE NOMINA.dbo.mtro_ded SET activo=0,comentario='Liquidado periodo " & data("ano") & "-" & data("periodo") & "-" & data("tipoPeriodo") & "' WHERE id=" & row("id"))
                                End If

                            End If

                            '** Mensaje de progreso en interfaz
                            If Not Me.BgWorker Is Nothing Then : data("etapa") = "Aplicación de descuentos de saldos: Maestro de deducciones [Actualizando registros]" : Me.BgWorker.ReportProgress(100 * 1 / 2) : End If
                        Next
                    End If

                    '== Cobro de seguro de vivienda
                    '** Mensaje de progreso en interfaz
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Aplicación de descuentos de saldos: Cobro de seguro de vivenda" : Me.BgWorker.ReportProgress(100 * 2 / 2) : End If

                    Dim dtInfonavitActivo = sqlExecute("SELECT * FROM PERSONAL.dbo.infonavit WHERE activo=1")

                    For Each movs In dtMovsAsentados.Select("concepto='SEGVIV'")
                        If dtInfonavitActivo.Select("reloj='" & movs("reloj").ToString.Trim & "'").Count > 0 Then
                            sqlExecute("UPDATE PERSONAL.dbo.infonavit SET cobro_segv=0 WHERE reloj='" & movs("reloj").ToString.Trim & "' and activo=1")

                            '** Mensaje de progreso en interfaz
                            If Not Me.BgWorker Is Nothing Then : data("etapa") = "Aplicación de descuentos de saldos: Cobro de seguro de vivenda [Actualizando registros]" : Me.BgWorker.ReportProgress(100 * 2 / 2) : End If
                        End If
                    Next
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            MessageBox.Show("Ha ocurrido un error con la aplicación de descuentos de saldos." & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Función para recalcular los montos de ADEINF y TIENDA en caso de neto igual o menor a 100 -- Ernesto
    ''' </summary>
    ''' <param name="decNeto"></param>
    ''' <param name="strReloj"></param>
    ''' <remarks></remarks>
    Private Function RecalculoNeto(decNeto As Decimal,
                                   strReloj As String,
                                   ByRef data As Dictionary(Of String, String),
                                   Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing,
                                   Optional strFiltroRelojes As Object = Nothing) As Boolean
        Try
            Dim decAjuste = 0D : Dim dtinfo As New DataTable

            '== Se busca si existe el concepto de TIENDA en movimientosPro y si el neto del empleado es 0.
            '== Si es así, se hace elimina el concepto de TIENDA y su derivados informativos [TIEN01, etc] de ajustesPro.
            dtinfo = infoTabla("concepto IN ('TIENDA') AND reloj='" & strReloj & "'", dtMovsProLocal)
            If dtinfo.Rows.Count > 0 And decNeto = 0 Then
                Sqlite.getInstance().ExecuteNonQueryFunc("DELETE FROM ajustesPro WHERE reloj='" & strReloj & "' AND concepto like 'TIEN%'")
                dicInfoDt("dtAjustesPro") = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro " & strFiltroRelojes(0))
                dicInfoDt("dtAjustesProC") = Sqlite.getInstance.sqliteExecute("SELECT * FROM (SELECT * FROM ajustesPro UNION ALL SELECT * FROM ajustesLazy UNION ALL SELECT * FROM horasLazy) as T " &
                                                                              "WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' " & strFiltroRelojes(1))
                dtMovsProLocal.Clear()
                Return True
            End If

            '== Se busca si existe el concepto de ADEINF en moviemientosPro y si el neto del empleado es menor a 100.
            '== Si es así, se hace un ajuste al adeudo de infonavit en la tabla de ajustesPro.
            dtinfo = infoTabla("concepto IN ('ADEINF') AND reloj='" & strReloj & "'", dtMovsProLocal)

            If dtinfo.Rows.Count > 0 And decNeto < 100 Then
                decAjuste = CDec(dtinfo.Rows(0)("monto")) - (100 - decNeto)
                Sqlite.getInstance().ExecuteNonQueryFunc("UPDATE ajustesPro SET monto='" & decAjuste & "' WHERE reloj='" & strReloj & "' AND concepto like 'ADEIN%' and concepto not in ('ADEINF')")
                dicInfoDt("dtAjustesPro") = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro " & strFiltroRelojes(0))
                dicInfoDt("dtAjustesProC") = Sqlite.getInstance.sqliteExecute("SELECT * FROM (SELECT * FROM ajustesPro UNION ALL SELECT * FROM ajustesLazy UNION ALL SELECT * FROM horasLazy) as T " &
                                                                              "WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' " & strFiltroRelojes(1))
                dtMovsProLocal.Clear()
                Return True
            End If

            Return False
        Catch ex As Exception : Return False : End Try
    End Function

    ''' <summary>
    ''' Función del calculo compensación del proceso -- Modificaciones -- Ernesto -- 11 oct 2023
    ''' </summary>
    ''' <param name="element"></param>
    ''' <param name="data"></param>
    ''' <param name="exepcionCalculo"></param>
    ''' <param name="finiquito"></param>
    ''' <param name="dicInfoDt"></param>
    ''' <remarks></remarks>
    Public Sub CalculoCompensacion(element As DataRow,
                                   data As Dictionary(Of String, String),
                                   Optional finiquito As Boolean = False,
                                   Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing)

        '--- Si es aguinaldo anual, no realizar cálculo de compensación -- Ernesto -- 24 oct 2023
        If Me._options("aguinaldo_anual") Then Exit Sub

        Dim strReloj = element("reloj").ToString.Trim

        Try
            Dim vars As New Dictionary(Of String, Decimal) From {{"_sueldo_cobertura", 0.0},
                                                                 {"_por_fah", 9.7},
                                                                 {"_descuentos_dias_total", 0}}
            _globalVars("_acum_base_pago_comp") = 0

            '--- Excepciones de cálculo
            Dim filtExep As DataTable = infoTabla("reloj='" & strReloj & "' and concepto='por_fah'", dicInfoDt("dtExcepCalc"))
            If filtExep.Rows.Count > 0 Then : vars("_por_fah") = filtExep.Rows(0)("monto") : End If

            '--- Se busca el sueldo Cobertura para el reloj trabajado
            Dim sdoCober As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtSdoCobertura"))

            If sdoCober.Rows.Count > 0 Then
                Dim esPorcentaje = If(IsDBNull(sdoCober.Rows(0)("porcentaje")), False, sdoCober.Rows(0)("porcentaje") > 0)

                If Not esPorcentaje Then
                    If sdoCober.Rows(0)("sdo_cobert") <= element("sactual") Then
                        Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE sueldoCobertura SET comentario = 'Cancelado por sueldo mayor o igual al de cobertura " &
                                                               FechaSQL(Date.Now) & "', activo = '0' WHERE id = '" & sdoCober.Rows(0)("id") & "'")
                        sdoCober.Rows(0)("porcentaje") = 0
                    End If
                End If


                If Not sdoCober.Rows(0)("fha_fin") Is Nothing And Convert.ToDateTime(sdoCober.Rows(0)("fha_fin")) <= Convert.ToDateTime(Me.period("fecha_ini")) And
                    Not Convert.ToDateTime(sdoCober.Rows(0)("fha_fin")) < "1950-01-01" Then

                    Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE sueldoCobertura SET comentario = 'Cancelado vencimiento " & FechaSQL(Date.Now) & "', activo = '0' WHERE id = '" & sdoCober.Rows(0)("id") & "'")
                    sqlExecute("UPDATE nomina.dbo.sueldo_cobertura SET comentario = 'Cancelado vencimiento " & FechaSQL(Date.Now) & "', activo = '0' " &
                               "WHERE reloj='" & sdoCober.Rows(0)("reloj").ToString.Trim & "' and " &
                               "sdo_cobert='" & sdoCober.Rows(0)("sdo_cobert") & "' and fha_inicio='" & FechaSQL(sdoCober.Rows(0)("fha_inicio")) & "'")
                    Exit Sub
                End If

                If Not sdoCober.Rows(0)("fha_inicio") Is Nothing And Convert.ToDateTime(sdoCober.Rows(0)("fha_inicio")) < Convert.ToDateTime(element("alta")) And
                    Not Convert.ToDateTime(sdoCober.Rows(0)("fha_fin")) < "1950-01-01" Then

                    Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE sueldoCobertura SET comentario = 'Cancelado por baja " & FechaSQL(Date.Now) & "', activo = '0' WHERE id = '" & sdoCober.Rows(0)("id") & "'")
                    sqlExecute("UPDATE nomina.dbo.sueldo_cobertura SET comentario = 'Cancelado por baja " & FechaSQL(Date.Now) & "', activo = '0' " &
                               "WHERE reloj='" & sdoCober.Rows(0)("reloj").ToString.Trim & "' and " &
                               "sdo_cobert='" & sdoCober.Rows(0)("sdo_cobert") & "' and fha_inicio='" & FechaSQL(sdoCober.Rows(0)("fha_inicio")) & "'")
                    Exit Sub
                End If

                'FOX: Agregue la condicion para que incluya solo compensaciones posteriores al alta, ya que hay reingresos que no deben de tener la misma compensacion anterior que se quedo activa IVO sem 41-2020
                If Convert.ToDateTime(sdoCober.Rows(0)("fha_inicio")) >= Convert.ToDateTime(element("alta")) Then
                    Dim vac_pag = 0

                    If Not IsDBNull(sdoCober.Rows(0)("porcentaje")) AndAlso sdoCober.Rows(0)("porcentaje") > 0 Then
                        vars("_sueldo_cobertura") = element("sactual") * (sdoCober.Rows(0)("porcentaje") / 100)
                        GoTo ContinuarConPorcentaje
                    End If

                    If sdoCober.Rows(0)("sdo_cobert") = 0 And sdoCober.Rows(0)("comp_diaria") > 0 Then
                        vars("_sueldo_cobertura") = sdoCober.Rows(0)("comp_diaria")
                    Else
                        vars("_sueldo_cobertura") = sdoCober.Rows(0)("sdo_cobert") - element("sactual")
                    End If
                End If

ContinuarConPorcentaje:

                'FOX: Variables con Horas
                Dim horasProC As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtHorasPro"))
                Dim ajustesProC As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtAjustesProC"))

                vars.Add("_hrs_normales", sumaMonto(strReloj, "HRSNOR", horasProC))                                                                             'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSNOR","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_normales
                vars.Add("_hrs_dobles", sumaMonto(strReloj, "HRSEX2", horasProC))                                                                               'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSEX2","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_dobles
                vars.Add("_hrs_triples", sumaMonto(strReloj, "HRSEX3", horasProC))                                                                              'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSEX3","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_triples
                vars.Add("_hrs_festivo_laborado", sumaMonto(strReloj, "HRSFEL", horasProC))                                                                     'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSFEL","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_festivo_laborado
                vars.Add("_hrs_dobles_anteriores", sumaMonto(strReloj, "HRS2AN", ajustesProC))                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"HRS2AN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_dobles_anteriores
                vars.Add("_hrs_triples_anteriores", sumaMonto(strReloj, "HRS3AN", ajustesProC))                                                                 'FOX: store iif(seek(_ano+_periodo+_reloj+"HRS3AN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_triples_anteriores
                vars.Add("_hrs_festivo", sumaMonto(strReloj, "HRSFES", horasProC))                                                                              'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSFES","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_festivo
                vars.Add("_hrs_convenio", sumaMonto(strReloj, "HRSCNV", horasProC))                                                                             'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSCNV","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_convenio
                vars.Add("_hrs_conv_cobrado", sumaMonto(strReloj, "HRSCOC", horasProC))                                                                         'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSCOC","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_conv_cobrado
                vars.Add("_hrs_permiso_sin_goce", sumaMonto(strReloj, "HRSPSG", horasProC))                                                                     'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSPSG","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_permiso_sin_goce
                vars.Add("_hrs_retardo", sumaMonto(strReloj, "HRSRET", horasProC))                                                                              'FOX: store iif(seek(_ano+_periodo+_reloj+"HRSRET","horas_pro_c","unico"),horas_pro_c.monto,0) to _hrs_retardo
                vars.Add("_min_devolucion_retardo", sumaMonto(strReloj, "HDVRET", ajustesProC))                                                                 'FOX: store iif(seek(_ano+_periodo+_reloj+"HDVRET","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _min_devolucion_retardo
                vars.Add("_dias_aguinaldo", sumaMonto(strReloj, "DIASAG", horasProC))                                                                           'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASAG","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_aguinaldo

                'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPSH","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _hrs_permiso_sin_goce_dev
                Dim factor = ajustesProC.Select("concepto='DDVPSH'")
                Dim fact_val = 1
                If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                vars.Add("_hrs_permiso_sin_goce_dev", sumaMonto(strReloj, "DDVPSH", ajustesProC) * fact_val)

                'FOX: Ausentismos con goce
                vars.Add("_dias_normales", sumaMonto(strReloj, "DIANOR", horasProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIANOR","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_normales
                vars.Add("_dias_festivos", sumaMonto(strReloj, "DIAFES", horasProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFES","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_festivos
                vars.Add("_dias_prima", sumaMonto(strReloj, "DIAPRI", horasProC))                                                                               'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPRI","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_prima

                'FOX: store _dias_normales+_dias_festivos to _dias_pagados,_dias_infonavit
                vars.Add("_dias_pagados", vars("_dias_normales") + vars("_dias_festivos"))
                vars.Add("_dias_infonavit", vars("_dias_pagados"))
                vars.Add("_dias_vac", sumaMonto(strReloj, "DIASVA", horasProC))                                                                                 'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASVA","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_vac
                vars.Add("_dias_permiso_con_goce", sumaMonto(strReloj, "DIAPGO", horasProC))                                                                    'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPGO","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_permiso_con_goce
                vars.Add("_dias_permiso_nacimiento", sumaMonto(strReloj, "DIANAC", horasProC))                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"DIANAC","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_permiso_nacimiento
                vars.Add("_dias_permiso_matrimonio", sumaMonto(strReloj, "DIAMAT", horasProC))                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAMAT","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_permiso_matrimonio
                vars.Add("_dias_permiso_funeral", sumaMonto(strReloj, "DIAFUN", horasProC))                                                                     'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFUN","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_permiso_funeral
                vars("_dias_vac") += sumaMonto(strReloj, "DIASVA", ajustesProC)                                                                                 'FOX: store _dias_vac+iif(seek(_ano+_periodo+_reloj+"DIASVA","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_vac
                vars("_dias_permiso_con_goce") += sumaMonto(strReloj, "DIAPGO", ajustesProC)                                                                    'FOX: store _dias_permiso_con_goce+iif(seek(_ano+_periodo+_reloj+"DIAPGO","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_permiso_con_goce
                vars("_dias_permiso_nacimiento") += sumaMonto(strReloj, "DIANAC", ajustesProC)                                                                  'FOX: store _dias_permiso_nacimiento+iif(seek(_ano+_periodo+_reloj+"DIANAC","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_permiso_nacimiento
                vars("_dias_permiso_matrimonio") += sumaMonto(strReloj, "DIAMAT", ajustesProC)                                                                  'FOX: store _dias_permiso_matrimonio+iif(seek(_ano+_periodo+_reloj+"DIAMAT","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_permiso_matrimonio
                vars("_dias_permiso_funeral") += sumaMonto(strReloj, "DIAFUN", ajustesProC)                                                                     'FOX: store _dias_permiso_funeral+iif(seek(_ano+_periodo+_reloj+"DIAFUN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_permiso_funeral
                vars.Add("_dias_prima_sabatina", sumaMonto(strReloj, "DIASAB", horasProC))                                                                      'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASAB","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_prima_sabatina
                vars.Add("_dias_prima_dominical", sumaMonto(strReloj, "DIADOM", horasProC))                                                                     'FOX: store iif(seek(_ano+_periodo+_reloj+"DIADOM","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_prima_dominical
                vars("_dias_prima_sabatina") += sumaMonto(strReloj, "DIASAB", ajustesProC)                                                                      'FOX: store _dias_prima_sabatina+iif(seek(_ano+_periodo+_reloj+"DIASAB","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_prima_sabatina
                vars("_dias_prima_dominical") += sumaMonto(strReloj, "DIADOM", ajustesProC)                                                                     'FOX: store _dias_prima_dominical+iif(seek(_ano+_periodo+_reloj+"DIADOM","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_prima_dominical

                'FOX: store _dias_pagados+_dias_vac+_dias_permiso_con_goce+_dias_permiso_nacimiento+_dias_permiso_matrimonio+_dias_permiso_funeral to _dias_pagados,_dias_infonavit
                '== De acuerdo a indicación de Ivette, si se trata de finiquito, no se le suman los dias de vacaciones a los dias pagados
                vars("_dias_pagados") += IIf(finiquito, 0, vars("_dias_vac")) + vars("_dias_permiso_con_goce") + vars("_dias_permiso_nacimiento") + vars("_dias_permiso_matrimonio") + vars("_dias_permiso_funeral")
                vars("_dias_infonavit") = vars("_dias_pagados")

                'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVVAC","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _dias_vac_dev
                factor = ajustesProC.Select("concepto='DDVVAC'")
                fact_val = 1
                If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                vars.Add("_dias_vac_dev", sumaMonto(strReloj, "DDVVAC", ajustesProC) * fact_val)
                'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPGO","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _dias_permiso_con_goce_dev
                factor = ajustesProC.Select("concepto='DDVPGO'")
                fact_val = 1
                If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                vars.Add("_dias_permiso_con_goce_dev", sumaMonto(strReloj, "DDVPGO", ajustesProC) * fact_val)
                'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVNAC","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _dias_permiso_nacimiento_dev
                factor = ajustesProC.Select("concepto='DDVNAC'")
                fact_val = 1
                If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                vars.Add("_dias_permiso_nacimiento_dev", sumaMonto(strReloj, "DDVNAC", ajustesProC) * fact_val)
                'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVMAT","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _dias_permiso_matrimonio_dev
                factor = ajustesProC.Select("concepto='DDVMAT'")
                fact_val = 1
                If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                vars.Add("_dias_permiso_matrimonio_dev", sumaMonto(strReloj, "DDVMAT", ajustesProC) * fact_val)

                'FOX: store _dias_pagados+_dias_vac_dev+_dias_permiso_con_goce_dev+_dias_permiso_nacimiento_dev+_dias_permiso_matrimonio_dev to _dias_pagados
                vars("_dias_pagados") += vars("_dias_vac_dev") + vars("_dias_permiso_con_goce_dev") + vars("_dias_permiso_nacimiento_dev") + vars("_dias_permiso_matrimonio_dev")

                'FOX: Ausentismos sin goce
                vars.Add("_dias_falta_injustificada", sumaMonto(strReloj, "DIAFIN", horasProC))                                                                         'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFIN","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_falta_injustificada
                vars.Add("_dias_falta_justificada", sumaMonto(strReloj, "DIAFJU", horasProC))                                                                           'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFJU","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_falta_justificada
                vars.Add("_dias_permiso_sin_goce", sumaMonto(strReloj, "DIAPSG", horasProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPSG","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_permiso_sin_goce
                vars.Add("_dias_suspension", sumaMonto(strReloj, "DIASUS", horasProC))                                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASUS","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_suspension
                vars.Add("_dias_verano", sumaMonto(strReloj, "DIAPSV", horasProC))                                                                                      'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPSV","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_verano

                'vars.Add("_dias_inc_general", (From i In horasProC Where i("concepto") = "DIAING" Select Decimal.Parse(i("Monto").ToString)).Sum())                    'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAING","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_inc_general
                'vars.Add("_dias_inc_trabajo", (From i In horasProC Where i("concepto") = "DIAITR" Select Decimal.Parse(i("Monto").ToString)).Sum())                    'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAITR","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_inc_trabajo
                'vars.Add("_dias_inc_trayecto", (From i In horasProC Where i("concepto") = "DIAITY" Select Decimal.Parse(i("Monto").ToString)).Sum())                   'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAITY","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_inc_trayecto

                vars("_dias_falta_injustificada") += sumaMonto(strReloj, "DIAFIN", ajustesProC)                                                                         'FOX: store _dias_falta_injustificada+iif(seek(_ano+_periodo+_reloj+"DIAFIN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_falta_injustificada
                vars("_dias_falta_justificada") += sumaMonto(strReloj, "DIAFJU", ajustesProC)                                                                           'FOX: store _dias_falta_justificada+iif(seek(_ano+_periodo+_reloj+"DIAFJU","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_falta_justificada
                vars("_dias_permiso_sin_goce") += sumaMonto(strReloj, "DIAPSG", ajustesProC)                                                                            'FOX: store _dias_permiso_sin_goce+iif(seek(_ano+_periodo+_reloj+"DIAPSG","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0)to _dias_permiso_sin_goce
                vars("_dias_suspension") += sumaMonto(strReloj, "DIASUS", ajustesProC)                                                                                  'FOX: store _dias_suspension+iif(seek(_ano+_periodo+_reloj+"DIASUS","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_suspension
                vars("_dias_verano") += sumaMonto(strReloj, "DIAPSV", ajustesProC)                                                                                      'FOX: store  _dias_verano+iif(seek(_ano+_periodo+_reloj+"DIAPSV","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_verano
                vars.Add("_dias_inc_maternidad", sumaMonto(strReloj, "DIAIMA", ajustesProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAIMA","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_inc_maternidad
                vars.Add("_dias_inc_general", sumaMonto(strReloj, "DIAING", ajustesProC))                                                                               'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAING","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_inc_general
                vars.Add("_dias_inc_trabajo", sumaMonto(strReloj, "DIAITR", ajustesProC))                                                                               'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAITR","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_inc_trabajo
                vars.Add("_dias_inc_trayecto", sumaMonto(strReloj, "DIAITY", ajustesProC))                                                                              'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAITY","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_inc_trayecto

                'FOX: store _dias_pagados-_dias_falta_injustificada-_dias_falta_justificada-_dias_permiso_sin_goce-_dias_suspension to _dias_pagados
                'FOX: store _dias_pagados-_dias_inc_maternidad-_dias_inc_general-_dias_inc_trabajo-_dias_inc_trayecto to _dias_pagados
                vars("_dias_pagados") -= (vars("_dias_falta_injustificada") + vars("_dias_falta_justificada") + vars("_dias_permiso_sin_goce") +
                                          vars("_dias_suspension") + vars("_dias_inc_maternidad") + vars("_dias_inc_general") + vars("_dias_inc_trabajo") + vars("_dias_inc_trayecto"))

                'FOX: store _dias_infonavit-_dias_inc_maternidad-_dias_inc_general-_dias_inc_trabajo-_dias_inc_trayecto to _dias_infonavit
                vars("_dias_infonavit") -= (vars("_dias_inc_maternidad") + vars("_dias_inc_general") + vars("_dias_inc_trabajo") + vars("_dias_inc_trayecto"))

                vars.Add("_dias_falta_injustificada_dev", sumaMonto(strReloj, "DDVFIN", ajustesProC))                                                                   'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVFIN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_falta_injustificada_dev
                vars.Add("_dias_falta_justificada_dev", sumaMonto(strReloj, "DDVFJU", ajustesProC))                                                                     'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVFJU","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_falta_justificada_dev
                vars.Add("_dias_permiso_sin_goce_dev", sumaMonto(strReloj, "DDVPSG", ajustesProC))                                                                      'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPSG","ajustes_pro_c","unico"),ajustes_pro_c.monto*iif(ajustes_pro_c.factor>0,ajustes_pro_c.factor,1),0) to _dias_permiso_sin_goce_dev
                vars.Add("_dias_suspension_dev", sumaMonto(strReloj, "DDVSUS", ajustesProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVSUS","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_suspension_dev
                vars.Add("_dias_permiso_verano_dev", sumaMonto(strReloj, "DDVPSV", ajustesProC))                                                                        'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPSV","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_permiso_verano_dev

                'FOX: store _dias_pagados+_dias_falta_injustificada_dev+_dias_falta_justificada_dev+_dias_permiso_sin_goce_dev+_dias_suspension_dev+_dias_permiso_verano_dev-_dias_verano to _dias_pagados
                vars("_dias_pagados") += vars("_dias_falta_injustificada_dev") + vars("_dias_falta_justificada_dev") +
                                         vars("_dias_permiso_sin_goce_dev") + vars("_dias_suspension_dev") + vars("_dias_permiso_verano_dev") - vars("_dias_verano")

                vars.Add("_dias_inc_dev", sumaMonto(strReloj, "DIDVIN", horasProC))                                                                                         'FOX: store iif(seek(_ano+_periodo+_reloj+"DIDVIN","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_inc_dev
                vars("_dias_pagados") += vars("_dias_inc_dev")                                                                                                              'FOX: store _dias_pagados+_dias_inc_dev to _dias_pagados
                vars.Add("_horas_extras_dobles_dev", sumaMonto(strReloj, "HDVEX2", ajustesProC))                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"HDVEX2","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _horas_extras_dobles_dev
                vars.Add("_horas_extras_triples_dev", sumaMonto(strReloj, "HDVEX3", ajustesProC))                                                                           'FOX: store iif(seek(_ano+_periodo+_reloj+"HDVEX3","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _horas_extras_triples_dev

                'FOX: Comedor
                vars.Add("_dias_comedor_sinsub", sumaMonto(strReloj, "DIASIN", horasProC))                                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASIN","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_comedor_sinsub
                vars("_dias_comedor_sinsub") += sumaMonto(strReloj, "DIASIN", ajustesProC)                                                                                  'FOX: store _dias_comedor_sinsub+iif(seek(_ano+_periodo+_reloj+"DIASIN","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_comedor_sinsub
                vars.Add("_dias_comedor_consub", sumaMonto(strReloj, "DIACON", horasProC))                                                                                  'FOX: store iif(seek(_ano+_periodo+_reloj+"DIACON","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_comedor_consub
                vars("_dias_comedor_consub") += sumaMonto(strReloj, "DIACON", ajustesProC)                                                                                  'FOX: store _dias_comedor_consub+iif(seek(_ano+_periodo+_reloj+"DIACON","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_comedor_consub

                'FOX: Ajustes varios
                vars.Add("_dias_descuento_50", sumaMonto(strReloj, "DIAC50", horasProC))                                                                                    'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAC50","horas_pro_c","unico"),horas_pro_c.monto,0) to _dias_descuento_50
                vars("_dias_comedor_consub") += sumaMonto(strReloj, "DIAC50", ajustesProC)                                                                                  'FOX: store _dias_descuento_50+iif(seek(_ano+_periodo+_reloj+"DIAC50","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_descuento_50
                vars.Add("_dias_devolucion_descuento_50", sumaMonto(strReloj, "DDVD50", ajustesProC))                                                                       'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVD50","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _dias_devolucion_descuento_50

                'FOX: Agregamos horas que vengan en Miscelaneos
                vars("_hrs_normales") += sumaMonto(strReloj, "HRSNOR", ajustesProC)                                                                                         'FOX: store _hrs_normales+iif(seek(_ano+_periodo+_reloj+"HRSNOR","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_normales
                vars("_hrs_festivo") += sumaMonto(strReloj, "HRSFES", ajustesProC)                                                                                          'FOX: store _hrs_festivo+iif(seek(_ano+_periodo+_reloj+"HRSFES","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_festivo
                vars("_hrs_convenio") += sumaMonto(strReloj, "HRSCNV", ajustesProC)                                                                                         'FOX: store _hrs_convenio+iif(seek(_ano+_periodo+_reloj+"HRSCNV","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_convenio
                vars("_hrs_conv_cobrado") += sumaMonto(strReloj, "HRSCOC", ajustesProC)                                                                                     'FOX: store _hrs_conv_cobrado+iif(seek(_ano+_periodo+_reloj+"HRSCOC","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_conv_cobrado
                vars("_hrs_permiso_sin_goce") += sumaMonto(strReloj, "HRSPSG", ajustesProC)                                                                                 'FOX: store _hrs_permiso_sin_goce+iif(seek(_ano+_periodo+_reloj+"HRSPSG","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_permiso_sin_goce
                vars("_hrs_retardo") += sumaMonto(strReloj, "HRSRET", ajustesProC)                                                                                          'FOX: store _hrs_retardo+iif(seek(_ano+_periodo+_reloj+"HRSRET","ajustes_pro_c","unico"),ajustes_pro_c.monto,0) to _hrs_retardo

                Me.puenteCompensacion(vars("_hrs_normales"), "HRSNOR", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                              'FOX: do puente_compensacion with _reloj,_hrs_normales,_tipo_nomina,'HRSNOR',_tipo_comp
                Me.puenteCompensacion(vars("_dias_falta_injustificada_dev"), "DDVFIN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                              'FOX: do puente_compensacion with _reloj,_dias_falta_injustificada_dev,_tipo_nomina,"DDVFIN",_tipo_comp
                Me.puenteCompensacion(vars("_dias_falta_justificada_dev"), "DDVFJU", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                'FOX: do puente_compensacion with _reloj,_dias_falta_justificada_dev,_tipo_nomina,"DDVFJU",_tipo_comp
                Me.puenteCompensacion(vars("_dias_suspension_dev"), "DDVSUS", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_dias_suspension_dev,_tipo_nomina,"DDVSUS",_tipo_comp
                Me.puenteCompensacion(vars("_dias_permiso_con_goce"), "DIAPGO", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                     'FOX: do puente_compensacion with _reloj,_dias_permiso_con_goce,_tipo_nomina,"DIAPGO",_tipo_comp
                Me.puenteCompensacion(vars("_dias_permiso_nacimiento"), "DIANAC", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                   'FOX: do puente_compensacion with _reloj,_dias_permiso_nacimiento,_tipo_nomina,"DIANAC",_tipo_comp
                Me.puenteCompensacion(vars("_dias_permiso_matrimonio"), "DIAMAT", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                   'FOX: do puente_compensacion with _reloj,_dias_permiso_matrimonio,_tipo_nomina,"DIAMAT",_tipo_comp
                Me.puenteCompensacion(vars("_dias_permiso_funeral"), "DIAFUN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                      'FOX: do puente_compensacion with _reloj,_dias_permiso_funeral,_tipo_nomina,"DIAFUN",_tipo_comp
                Me.puenteCompensacion(vars("_dias_normales"), "DIANOR", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                             'FOX: do puente_compensacion with _reloj,_dias_normales,_tipo_nomina,"DIANOR",_tipo_comp
                Me.puenteCompensacion(vars("_dias_festivos"), "DIAFES", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                             'FOX: do puente_compensacion with _reloj,_dias_festivos,_tipo_nomina,"DIAFES",_tipo_comp
                Me.puenteCompensacion(vars("_dias_prima_sabatina"), "DIASAB", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_dias_prima_sabatina,_tipo_nomina,"DIASAB",_tipo_comp
                Me.puenteCompensacion(vars("_dias_prima_dominical"), "DIADOM", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                      'FOX: do puente_compensacion with _reloj,_dias_prima_dominical,_tipo_nomina,"DIADOM",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_permiso_sin_goce"), "HRSPSG", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                      'FOX: do puente_compensacion with _reloj,_hrs_permiso_sin_goce,_tipo_nomina,"HRSPSG",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_retardo"), "HRSRET", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                               'FOX: do puente_compensacion with _reloj,_hrs_retardo,_tipo_nomina,"HRSRET",_tipo_comp
                Me.puenteCompensacion(vars("_min_devolucion_retardo"), "HDVRET", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                    'FOX: do puente_compensacion with _reloj,_min_devolucion_retardo,_tipo_nomina,"HDVRET",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_permiso_sin_goce_dev"), "DDVPSH", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                  'FOX: do puente_compensacion with _reloj,_hrs_permiso_sin_goce_dev,_tipo_nomina,"DDVPSH",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_dobles"), "HRSEX2", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                                'FOX: do puente_compensacion with _reloj,_hrs_dobles,_tipo_nomina,"HRSEX2",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_triples"), "HRSEX3", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                               'FOX: do puente_compensacion with _reloj,_hrs_triples,_tipo_nomina,"HRSEX3",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_festivo_laborado"), "HRSFEL", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                      'FOX: do puente_compensacion with _reloj,_hrs_festivo_laborado,_tipo_nomina,"HRSFEL",_tipo_comp
                Me.puenteCompensacion(vars("_hrs_dobles_anteriores"), "HRS2AN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                     'FOX: do puente_compensacion with _reloj,_hrs_dobles_anteriores,_tipo_nomina,"HRS2AN",_tipo_comp						
                Me.puenteCompensacion(vars("_hrs_triples_anteriores"), "HRS3AN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                    'FOX: do puente_compensacion with _reloj,_hrs_triples_anteriores,_tipo_nomina,"HRS3AN",_tipo_comp	
                Me.puenteCompensacion(vars("_dias_vac"), "DIASVA", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)

                'FOX: CALCULO DE PERCEPCION NORMAL
                vars.Add("_percepcion_normal", vars("_sueldo_cobertura") * vars("_dias_normales"))                                                                          'FOX: store round(_sueldo_cobertura*_dias_normales,2) to _percepcion_normal
                Me.puenteCompensacion(vars("_percepcion_normal"), "PERNOR", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                         'FOX: do puente_compensacion with _reloj,_percepcion_normal,_tipo_nomina,'PERNOR',_tipo_comp

                'CALCULO DE LA PERCEPCION FESTIVA -- 7 DIC 2023
                vars.Add("_percepcion_festiva", vars("_sueldo_cobertura") * vars("_dias_festivos"))
                Me.puenteCompensacion(vars("_percepcion_festiva"), "PERFES", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)

                'FOX: CALCULO DE PERCEPCION PERMISO CON GOCE
                vars.Add("_percepcion_con_goce", vars("_sueldo_cobertura") * vars("_dias_permiso_con_goce"))                          'FOX: store round(_sueldo_cobertura*_dias_permiso_con_goce,2) to _percepcion_con_goce
                Me.puenteCompensacion(vars("_percepcion_con_goce"), "PERPGO", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_percepcion_con_goce,_tipo_nomina,'PERPGO',_tipo_comp

                'FOX: CALCULO CORRESPONDIENTE A VACACIONES
                vars.Add("_vacaciones", IIf(finiquito, 0, vars("_dias_vac") * vars("_sueldo_cobertura")))                                                                                      'FOX: store round(_dias_vac* _sueldo_cobertura,2) to _vacaciones
                Me.puenteCompensacion(vars("_vacaciones"), "PERVAC", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                                'FOX: do puente_compensacion with _reloj,_vacaciones,_tipo_nomina,'PERVAC',_tipo_comp

                'FOX: DEVOLUCION INCAPACIDADES
                vars.Add("_devolucion_incapacidad", vars("_dias_inc_dev") * vars("_sueldo_cobertura"))                                                                      'FOX: store _dias_inc_dev * _sueldo_cobertura to _devolucion_incapacidad
                Me.puenteCompensacion(vars("_devolucion_incapacidad"), "DEVING", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                    'FOX: do puente_compensacion with _reloj,_devolucion_incapacidad,_tipo_nomina,'DEVING',_tipo_comp

                'FOX: DEVOLUCION FALTA INJUSTIFICADA
                Dim factorTmp = 1 : Dim dtFact = Nothing
                dtFact = infoTabla("concepto='DDVFIN' and factor is not null", ajustesProC)
                If dtFact.Rows.Count > 0 Then factorTmp = dtFact.Rows(0)("factor") Else factorTmp = 1
                vars.Add("_devolucion_falta_injustificada", vars("_dias_falta_injustificada_dev") * vars("_sueldo_cobertura"))                                              'FOX: store _dias_falta_injustificada_dev * _sueldo_cobertura to _devolucion_falta_injustificada
                Me.puenteCompensacion(vars("_devolucion_falta_injustificada"), "DEVFIN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                            'FOX: do puente_compensacion with _reloj,_devolucion_falta_injustificada,_tipo_nomina,'DEVFIN',_tipo_comp

                'FOX: DEVOLUCION FALTA JUSTIFICADA
                dtFact = infoTabla("concepto='DDVFJU' and factor is not null", ajustesProC)
                If dtFact.Rows.Count > 0 Then factorTmp = dtFact.Rows(0)("factor") Else factorTmp = 1
                vars.Add("_devolucion_falta_justificada", vars("_dias_falta_justificada_dev") * vars("_sueldo_cobertura"))                                                  'FOX: store _dias_falta_justificada_dev * _sueldo_cobertura to _devolucion_falta_justificada
                Me.puenteCompensacion(vars("_devolucion_falta_justificada"), "DEVFJU", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                              'FOX: do puente_compensacion with _reloj,_devolucion_falta_justificada,_tipo_nomina,'DEVFJU',_tipo_comp

                'FOX: DEVOLUCION PERMISO SIN GOCE DE SUELDO
                dtFact = infoTabla("concepto='DDVPSG' and factor is not null", ajustesProC)
                If dtFact.Rows.Count > 0 Then factorTmp = dtFact.Rows(0)("factor") Else factorTmp = 1
                vars.Add("_devolucion_permiso_sin_goce", vars("_dias_permiso_sin_goce_dev") * vars("_sueldo_cobertura"))                                                    'FOX: store _dias_permiso_sin_goce_dev * _sueldo_cobertura to _devolucion_permiso_sin_goce
                Me.puenteCompensacion(vars("_devolucion_permiso_sin_goce"), "DEVPSG", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                               'FOX: do puente_compensacion with _reloj,_devolucion_permiso_sin_goce,_tipo_nomina,'DEVPSG',_tipo_comp

                'FOX: DEVOLUCION SUSPENSION
                dtFact = infoTabla("concepto='DDVSUS' and factor is not null", ajustesProC)
                If dtFact.Rows.Count > 0 Then factorTmp = dtFact.Rows(0)("factor") Else factorTmp = 1
                vars.Add("_devolucion_suspension", vars("_dias_suspension_dev") * vars("_sueldo_cobertura"))                                                                'FOX: store _dias_suspension_dev * _sueldo_cobertura to _devolucion_suspension
                Me.puenteCompensacion(vars("_devolucion_suspension"), "DEVSUS", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                     'FOX: do puente_compensacion with _reloj,_devolucion_suspension,_tipo_nomina,'DEVSUS',_tipo_comp

                'FOX: DEVOLUCION PERMISO SIN GOCE VERANO
                vars.Add("_devolucion_permiso_verano", vars("_dias_permiso_verano_dev") * vars("_sueldo_cobertura"))                                                        'FOX: store _dias_permiso_verano_dev * _sueldo_cobertura to _devolucion_permiso_verano
                Me.puenteCompensacion(vars("_devolucion_permiso_verano"), "DEVPSV", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                 'FOX: do puente_compensacion with _reloj,_devolucion_permiso_verano,_tipo_nomina,'DEVPSV',_tipo_comp

                'FOX: DEVOLUCION DESCUENTO 50%
                dtFact = infoTabla("concepto='DDVD50' and factor is not null", ajustesProC)
                If dtFact.Rows.Count > 0 Then factorTmp = dtFact.Rows(0)("factor") Else factorTmp = 1
                vars.Add("_devolucion_descuento_50", vars("_dias_devolucion_descuento_50") * vars("_sueldo_cobertura") / 2)                                                 'FOX: store _sueldo_cobertura/2* _dias_devolucion_descuento_50 to _devolucion_descuento_50
                Me.puenteCompensacion(vars("_devolucion_descuento_50"), "DEVD50", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                   'FOX: do puente_compensacion with _reloj, _devolucion_descuento_50,_tipo_nomina,'DEVD50',_tipo_comp

                'FOX: DEVOLUCION PERMISO SIN GOCE DE SUELDO EN HORAS
                vars.Add("_dev_hrs_permiso_sin_goce", 0)
                If vars("_hrs_permiso_sin_goce_dev") > 0 Then
                    factor = ajustesProC.Select("concepto='DDVPSH'")
                    fact_val = 1
                    If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                    'Dim _factor_temp As Decimal = IIf((From i In ajustesProC.Rows Where i("concepto") = "DDVPSH").Count > 0, fact_val, 1)                                   'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPSH","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                    Dim _factor_temp As Decimal = IIf(infoTabla("concepto='DDVPSH'", ajustesProC).Rows.Count > 0, fact_val, 1)                                   'FOX: store iif(seek(_ano+_periodo+_reloj+"DDVPSH","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp

                    vars("_dev_hrs_permiso_sin_goce") = vars("_sueldo_cobertura") / 8 * vars("_hrs_permiso_sin_goce_dev") * _factor_temp                                    'FOX: store _sueldo_cobertura/8*_hrs_permiso_sin_goce_dev*_factor_temp to _dev_hrs_permiso_sin_goce
                    Me.puenteCompensacion(vars("_dev_hrs_permiso_sin_goce"), "DEVPSH", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                              'FOX: do puente_compensacion with _reloj,_dev_hrs_permiso_sin_goce,_tipo_nomina,'DEVPSH',_tipo_comp
                End If

                'FOX: DEVOLUCION RETARDO
                vars.Add("_dev_hrs_retardo", 0)
                If vars("_min_devolucion_retardo") > 0 Then
                    factor = ajustesProC.Select("concepto='HDVRET'")
                    fact_val = 1
                    If factor.Count > 0 Then : fact_val = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1) : End If
                    'Dim _factor_temp As Decimal = IIf((From i In ajustesProC.Rows Where i("concepto") = "HDVRET").Count > 0, fact_val, 1)                                   'FOX: store iif(seek(_ano+_periodo+_reloj+"HDVRET","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                    Dim _factor_temp As Decimal = IIf(infoTabla("concepto='HDVRET'", ajustesProC).Rows.Count > 0, fact_val, 1)                                   'FOX: store iif(seek(_ano+_periodo+_reloj+"HDVRET","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp

                    vars("_dev_hrs_permiso_sin_goce") = vars("_sueldo_cobertura") / 8 * vars("_min_devolucion_retardo") * _factor_temp                                      'FOX: store _sueldo_cobertura/8*_min_devolucion_retardo*_factor_dias to _dev_hrs_retardo
                    Me.puenteCompensacion(vars("_dev_hrs_retardo"), "DEVRET", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_dev_hrs_retardo,_tipo_nomina,'DEVRET',_tipo_comp
                End If

                'FOX: CALCULO DE PERCEPCION DE EXTRAS DOBLES
                vars.Add("_percepcion_doble", vars("_sueldo_cobertura") / 8 * vars("_hrs_dobles") * 2)                                                                      'FOX: store round(_sueldo_cobertura/8*_hrs_dobles*2,2) to _percepcion_doble
                Me.puenteCompensacion(vars("_percepcion_doble"), "PEREX2", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                          'FOX: do puente_compensacion with _reloj,_percepcion_doble,_tipo_nomina,'PEREX2',_tipo_comp

                'FOX: CALCULO DE PERCEPCION DE EXTRAS TRIPLES
                vars.Add("_percepcion_triple", vars("_sueldo_cobertura") / 8 * vars("_hrs_triples") * 3)                                                                    'FOX: store round(_sueldo_cobertura/8*_hrs_triples*3,2) to _percepcion_triple
                Me.puenteCompensacion(vars("_percepcion_triple"), "PEREX3", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                         'FOX: do puente_compensacion with _reloj,_percepcion_triple,_tipo_nomina,'PEREX3',_tipo_comp

                'FOX: CALCULO DE FESTIVO LABORADO
                vars.Add("_festivo_laborado", vars("_sueldo_cobertura") / 8 * vars("_hrs_festivo_laborado") * 2)                                                            'FOX: store round(_sueldo_cobertura/8*_hrs_festivo_laborado*2,2) to _festivo_laborado
                Me.puenteCompensacion(vars("_festivo_laborado"), "PHRFEL", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                          'FOX: do puente_compensacion with _reloj,_festivo_laborado,_tipo_nomina,'PHRFEL',_tipo_comp

                'FOX: CALCULO CORRESPONDIENTE A PRIMA SABATINA
                vars.Add("_prima_sabatina", 0)
                If vars("_dias_prima_sabatina") > 0 Then
                    vars("_prima_sabatina") = vars("_sueldo_cobertura") * 0.25 * vars("_dias_prima_sabatina")                                                               'FOX: _prima_sabatina=round(_sueldo_cobertura*.25*_dias_prima_sabatina,2)
                End If
                Me.puenteCompensacion(vars("_prima_sabatina"), "PRISAB", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                            'FOX: do puente_compensacion with _reloj,_prima_sabatina ,_tipo_nomina,'PRISAB',_tipo_comp

                'FOX: CALCULO CORRESPONDIENTE A PRIMA DOMINICAL
                vars.Add("_prima_dominical", 0)
                If vars("_dias_prima_dominical") > 0 Then
                    vars("_prima_dominical") = vars("_sueldo_cobertura") * 0.25 * vars("_dias_prima_dominical")                                                             'FOX: _prima_dominical = round(_sueldo_cobertura * 0.25 * _dias_prima_dominical, 2)
                End If
                'FOX: store _prima_dominical to _monto
                Me.puenteCompensacion(vars("_prima_dominical"), "PRIDOM", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                           'FOX: do puente_compensacion with _reloj,_prima_dominical,_tipo_nomina,'PRIDOM',_tipo_comp

                'FOX: CALCULO DE PERCEPCION DE EXTRAS DOBLES ANTERIORES
                vars.Add("_percepcion_doble_anterior", vars("_sueldo_cobertura") / 8 * vars("_hrs_dobles_anteriores") * 2)                                                  'FOX: store round(_sueldo_cobertura/8*_hrs_dobles_anteriores*2,2) to _percepcion_doble_anterior
                Me.puenteCompensacion(vars("_percepcion_doble_anterior"), "PER2AN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                 'FOX: do puente_compensacion with _reloj,_percepcion_doble_anterior,_tipo_nomina,'PER2AN',_tipo_comp

                'FOX: CALCULO DE PERCEPCION DE EXTRAS TRIPLES  ANTERIORES
                vars.Add("_percepcion_triple_anterior", vars("_sueldo_cobertura") / 8 * vars("_hrs_triples_anteriores") * 3)                                                'FOX: store round(_sueldo_cobertura/8*_hrs_triples_anteriores*3,2) to _percepcion_triple_anterior
                Me.puenteCompensacion(vars("_percepcion_triple_anterior"), "PER3AN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                'FOX: do puente_compensacion with _reloj,_percepcion_triple_anterior,_tipo_nomina,'PER3AN',_tipo_comp

                'FOX: INCAPACIDAD MATERNIDAD
                vars.Add("_ded_inc_maternidad", vars("_sueldo_cobertura") * vars("_dias_inc_maternidad"))                                                                   'FOX: store _sueldo_cobertura*_dias_inc_maternidad to _ded_inc_maternidad
                Me.puenteCompensacion(vars("_ded_inc_maternidad"), "DEDIMA", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                        'FOX: do puente_compensacion with _reloj,_ded_inc_maternidad,_tipo_nomina,'DEDIMA',_tipo_comp
                vars("_descuentos_dias_total") += vars("_ded_inc_maternidad")                                                                                               'FOX: store _descuentos_dias_total+_ded_inc_maternidad to _descuentos_dias_total

                'FOX: INCAPACIDAD GENERAL
                vars.Add("_ded_inc_general", vars("_sueldo_cobertura") * vars("_dias_inc_general"))                                                                         'FOX: store _sueldo_cobertura*_dias_inc_general to _ded_inc_general
                Me.puenteCompensacion(vars("_ded_inc_general"), "DEDING", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                           'FOX: do puente_compensacion with _reloj,_ded_inc_general,_tipo_nomina,'DEDING',_tipo_comp
                vars("_descuentos_dias_total") += vars("_ded_inc_general")                                                                                                  'FOX: store _descuentos_dias_total+_ded_inc_general to _descuentos_dias_total

                'FOX: INCAPACIDAD RIESGO DE TRABAJO
                vars.Add("_ded_inc_trabajo", vars("_sueldo_cobertura") * vars("_dias_inc_trabajo"))                                                                         'FOX: store _sueldo_cobertura*_dias_inc_trabajo to _ded_inc_trabajo
                Me.puenteCompensacion(vars("_ded_inc_trabajo"), "DEDITR", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                           'FOX: do puente_compensacion with _reloj,_ded_inc_trabajo,_tipo_nomina,'DEDITR',_tipo_comp
                vars("_descuentos_dias_total") += vars("_ded_inc_trabajo")                                                                                                  'FOX: store _descuentos_dias_total+_ded_inc_trabajo to _descuentos_dias_total

                'FOX: INCAPACIDAD TRAYECTO
                vars.Add("_ded_inc_trayecto", vars("_sueldo_cobertura") * vars("_dias_inc_trayecto"))                                                                       'FOX: store _sueldo_cobertura*_dias_inc_trayecto to _ded_inc_trayecto
                Me.puenteCompensacion(vars("_ded_inc_trayecto"), "DEDITY", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                          'FOX: do puente_compensacion with _reloj,_ded_inc_trayecto,_tipo_nomina,'DEDITY',_tipo_comp
                vars("_descuentos_dias_total") += vars("_ded_inc_trayecto")                                                                                                 'FOX: store _descuentos_dias_total+_ded_inc_trayecto to _descuentos_dias_total

                'FOX: SUSPENSIONES
                factor = ajustesProC.Select("concepto='DIASUS'")
                If factor.Count > 0 Then
                    Dim _factor_temp = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1)                                                                       'FOX: store iif(seek(_ano+_periodo+_reloj+"DIASUS","ajustes_pro_c","unico") and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                    vars.Add("_ded_suspension", vars("_sueldo_cobertura") * vars("_dias_suspension") * _factor_temp)                                                        'FOX: store _sueldo_cobertura*_factor_temp*_dias_suspension to _ded_suspension
                    Me.puenteCompensacion(vars("_ded_suspension"), "DEDSUS", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                        'FOX: do puente_compensacion with _reloj,_ded_suspension,_tipo_nomina,'DEDSUS',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_suspension")                                                                                               'FOX: store _descuentos_dias_total+_ded_suspension to _descuentos_dias_total
                End If

                'FOX: DESCUENTO 50%
                vars.Add("_descuento_50", vars("_sueldo_cobertura") / 2 * vars("_dias_descuento_50"))                                                                       'FOX: store _sueldo_cobertura/2*_dias_descuento_50 to _descuento_50
                Me.puenteCompensacion(vars("_descuento_50"), "DESC50", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                              'FOX: do puente_compensacion with _reloj,_descuento_50,_tipo_nomina,'DESC50',_tipo_comp
                vars("_descuentos_dias_total") += vars("_descuento_50")                                                                                                     'FOX: store _descuentos_dias_total+_descuento_50 to _descuentos_dias_total

                'FOX: PERMISO SIN GOCE VERANO-INVIERNO
                factor = ajustesProC.Select("concepto='DIAPSV'")                                                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPSV","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                If factor.Count > 0 Then
                    vars.Add("_ded_verano", vars("_sueldo_cobertura") * vars("_dias_verano"))                                                                               'FOX: store _sueldo_cobertura*_dias_verano to _ded_verano
                    Me.puenteCompensacion(vars("_ded_verano"), "DEDPSV", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                            'FOX: do puente_compensacion with _reloj,_ded_verano,_tipo_nomina,'DEDPSV',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_verano")                                                                                                   'FOX: store _descuentos_dias_total+_ded_verano to _descuentos_dias_total
                End If

                'FOX: FALTAS PERMISO SIN GOCE
                factor = ajustesProC.Select("concepto='DIAPSG'")                                                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAPSG","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                If factor.Count > 0 Then
                    Dim _factor_temp = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1)
                    vars.Add("_ded_permiso_sin_goce", vars("_sueldo_cobertura") * vars("_dias_permiso_sin_goce") * _factor_temp)                                            'FOX: store _sueldo_cobertura*_factor_temp*_dias_permiso_sin_goce to _ded_permiso_sin_goce
                    Me.puenteCompensacion(vars("_ded_permiso_sin_goce"), "DEDPSG", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                  'FOX: do puente_compensacion with _reloj,_ded_permiso_sin_goce,_tipo_nomina,'DEDPSG',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_permiso_sin_goce")                                                                                         'FOX: store _descuentos_dias_total+_ded_permiso_sin_goce to _descuentos_dias_total
                End If

                'FOX: PERMISO SIN GOCE DE SUELDO EN HORAS
                vars.Add("_ded_hrs_permiso_sin_goce", vars("_sueldo_cobertura") / 8 * vars("_hrs_permiso_sin_goce") * IIf(IsDBNull(element("factor_dias")), 0, element("factor_dias")))                               'FOX: store _sueldo_cobertura/8*_hrs_permiso_sin_goce*_factor_dias to _ded_hrs_permiso_sin_goce
                Me.puenteCompensacion(vars("_ded_hrs_permiso_sin_goce"), "DEHPSG", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                  'FOX: do puente_compensacion with _reloj,_ded_hrs_permiso_sin_goce,_tipo_nomina,'DEHPSG',_tipo_comp
                vars("_descuentos_dias_total") += vars("_ded_hrs_permiso_sin_goce")                                                                                         'FOX: store _descuentos_dias_total+_ded_hrs_permiso_sin_goce to _descuentos_dias_total

                'FOX: RETARDO
                If vars("_hrs_retardo") Then
                    vars.Add("_ded_hrs_retardo", vars("_sueldo_cobertura") / 8 * vars("_hrs_retardo") * element("factor_dias"))                                             'FOX: store _sueldo_cobertura/8*_hrs_retardo*_factor_dias to _ded_hrs_retardo
                    Me.puenteCompensacion(vars("_ded_hrs_retardo"), "DEHRET", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_ded_hrs_retardo,_tipo_nomina,'DEHRET',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_hrs_retardo")                                                                                              'FOX: store _descuentos_dias_total+_ded_hrs_retardo to _descuentos_dias_total
                End If

                'FOX: FALTAS JUSTIFICADAS
                factor = ajustesProC.Select("concepto='DIAFJU'")                                                                                                            'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFJU","ajustes_pro_c","unico")and ajustes_pro_c.factor>0,ajustes_pro_c.factor,1) to _factor_temp
                If factor.Count > 0 Then
                    Dim _factor_temp = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1)
                    vars.Add("_ded_falta_justificada", vars("_sueldo_cobertura") * vars("_dias_falta_justificada") * _factor_temp)                                          'FOX: store _sueldo_cobertura*_factor_temp*_dias_falta_justificada to _ded_falta_justificada
                    Me.puenteCompensacion(vars("_ded_falta_justificada"), "DEDFJU", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                 'FOX: do puente_compensacion with _reloj,_ded_falta_justificada,_tipo_nomina,'DEDFJU',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_falta_justificada")                                                                                        'FOX: store _descuentos_dias_total+_ded_falta_justificada to _descuentos_dias_total
                End If

                'FOX: FALTAS INJUSTIFICADAS
                factor = horasProC.Select("concepto='DIAFIN'")                                                                                                              'FOX: store iif(seek(_ano+_periodo+_reloj+"DIAFIN","horas_pro_c","unico")and horas_pro_c.factor>0,horas_pro_c.factor,1) to _factor_temp
                If factor.Count > 0 Then
                    Dim _factor_temp = IIf(factor.First()("factor") > 0, factor.First()("factor"), 1)
                    vars.Add("_ded_falta_injustificada", vars("_sueldo_cobertura") * vars("_dias_falta_injustificada") * _factor_temp)                                      'FOX: store _sueldo_cobertura*_factor_temp*_dias_falta_injustificada to _ded_falta_injustificad
                    Me.puenteCompensacion(vars("_ded_falta_injustificada"), "DEDFIN", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                               'FOX: do puente_compensacion with _reloj,_ded_falta_injustificada,_tipo_nomina,'DEDFIN',_tipo_comp
                    vars("_descuentos_dias_total") += vars("_ded_falta_injustificada")
                End If

                'FOX: PERCEPCION TOTAL
                vars.Add("_percepcion_total", totPercCompensacion(data, element, sdoCober.Rows(0)("tipo_comp"), dtMovsCompLocal, dicInfoDt))                             'FOX: store _tot_perc_compensacion(_reloj,'movimientos_compensacion',sdo_cobertura.tipo_comp) to _percepcion_total
                Me.puenteCompensacion(vars("_percepcion_total"), "TOTPER", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                          'FOX: do puente_compensacion with _reloj,_monto,_tipo_nomina,'TOTPER',_tipo_comp

                'FOX: DEDUCCION TOTAL
                vars.Add("_deduccion_total", totDedCompensacion(data, element, sdoCober.Rows(0)("tipo_comp"), dtMovsCompLocal, dicInfoDt))                                  'FOX: store _tot_ded_compensacion(_reloj,'movimientos_compensacion',sdo_cobertura.tipo_comp) to _deduccion_total
                Me.puenteCompensacion(vars("_deduccion_total"), "TOTDED", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                           'FOX: do puente_compensacion with _reloj,_monto,_tipo_nomina,'TOTDED',_tipo_comp

                'FOX: CALCULO DE NETO
                vars.Add("neto", vars("_percepcion_total") - vars("_deduccion_total"))                                                                                      'FOX: store _percepcion_total - _deduccion_total to _neto
                vars("neto") = IIf(vars("neto") < 0, 0, vars("neto"))                                                                                                       'FOX: store iif(_neto<0,0,_neto) to _neto 
                Me.puenteCompensacion(vars("neto"), "NETO", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                                         'FOX: do puente_compensacion with _reloj,_monto,_tipo_nomina,'NETO',_tipo_comp

                'FOX: CALCULO DE FONDO DE AHORRO
                'FOX: El 8 de mayo 2018 Marisa dio la indicacion de que se debe calcular el fondo de ahorro de la compensacion con los mismos 
                'conceptos que se calcula el fondo de la nomina normal
                'FOX: Lo calculo al final para no afectar el calculo de la compensacion
                vars.Add("_fahorro", _globalVars("_acum_base_pago_comp") * vars("_por_fah") / 100)                                                                          'FOX: store round(_acum_base_pago_comp  *  _por_fah/100,2) to _fahorro
                vars("_fahorro") = IIf(vars("_fahorro") < 0, 0, vars("_fahorro"))                                                                                           'FOX: store iif(_fahorro<0,0,_fahorro) to _fahorro
                Me.puenteCompensacion(vars("_fahorro"), "APOFAH", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                                   'FOX: do puente_compensacion with _reloj,_fahorro,_tipo_nomina,'APOFAH',_tipo_comp

                'FOX: CALCULO CORRESPONDIENTE A AGUINALDO COBERTURA
                vars.Add("_aguinaldo_cobertura", vars("_dias_aguinaldo") * vars("_sueldo_cobertura"))                                                                       'FOX: store round(_dias_aguinaldo * _sueldo_cobertura,2) to _aguinaldo_cobertura
                vars("_aguinaldo_cobertura") += sumaMonto(strReloj, "PERAGC", ajustesProC)                                                                                  'FOX: store _aguinaldo_cobertura+iif(seek(_ano+_periodo+_reloj+"PERAGC","ajustes_pro","unico"),ajustes_pro.monto,0)  to _aguinaldo_cobertura
                Me.puenteCompensacion(vars("_aguinaldo_cobertura"), "PERAGC", sdoCober.Rows(0)("tipo_comp"), element, dicInfoDt)                                                       'FOX: do puente_compensacion with _reloj,_monto,_tipo_nomina,'PERAGC'
            End If
        Catch ex As Exception
            'MessageBox.Show("Ha ocurrido un error durante el proceso de cálculo [compensación], por favor, revise el log y/o notifique al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.addLog("Error en el proceso de cálculo [compensación] reloj [" & strReloj & "]: " & ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_compensacion", ex.HResult, ex.Message)
        End Try

    End Sub

    'modi comm librerias (puente_compensacion) -- 11 oct 2023 -- Modificaciones Ernesto
    Private Sub puenteCompensacion(_monto As Decimal, _concepto As String, _tipo_comp As String, nominaElem As DataRow, Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing)
        'se redondea a 2 lugares
        _monto = Math.Round(_monto, 2) ', MidpointRounding.AwayFromZero

        Dim concept = infoTabla("concepto='" & _concepto.Trim & "'", dicInfoDt("dtConceptosPro"))

        'FOX: En sem-10 nos dimos cuenta que se esta pagando el ISR a favor al empleado 053427, por lo que cancelamos la condicion IVO 22 mzo 2020
        'FOX: El 2021-09-22 Brenda solicito que no topemos los conceptos de incapacidad cuando sea finiquito
        Dim _sobrepasa_incapacidad = False
        If Not IsDBNull(nominaElem("incapacidad")) And Not IsDBNull(nominaElem("faltas")) Then : _sobrepasa_incapacidad = nominaElem("incapacidad") > 0 And nominaElem("incapacidad") + nominaElem("faltas") >= 7 : End If

        'FOX: If _sobrepasa_incapacidad And !_incap_7 And !inlist(_concepto, "DIDESP", "BONDES", "BONPA1", "BONPA2", "BONPA3") And !_es_finiquito Then
        Dim incap7 = False
        If concept.Rows.Count > 0 Then : incap7 = IIf(IsDBNull(concept.Rows(0)("incap_7")), False, strBool.getValue(concept.Rows(0)("incap_7"))) : End If
        If _sobrepasa_incapacidad And incap7 And {"DIDESP", "BONDES", "BONPA1", "BONPA2", "BONPA3"}.Contains(_concepto.Trim) And Not strBool.getValue(nominaElem("finiquito")) Then : _monto = 0 : End If

        If concept.Rows.Count > 0 Then
            If concept.Rows(0)("suma_neto") Then
                If concept.Rows(0)("cod_naturaleza").ToString.Trim = "P" Then
                    _globalVars("_acum_base_pago_comp") += IIf(strBool.getValue(concept.Rows(0)("base_pago")), _monto, 0)                                                                'FOX: _acum_base_pago_comp = _acum_base_pago_comp + IIf(_base_pago, _monto, 0)
                ElseIf concept.Rows(0)("cod_naturaleza").ToString.Trim = "D" Then
                    _globalVars("_acum_base_pago_comp") -= IIf(strBool.getValue(concept.Rows(0)("base_pago")), _monto, 0)                                                                'FOX: _acum_base_pago_comp = _acum_base_pago_comp - IIf(_base_pago, _monto, 0)
                End If
            End If

            Dim tpnom = IIf(IsDBNull(concept.Rows(0)("cod_tipo_nomina")), "", concept.Rows(0)("cod_tipo_nomina"))
            Dim ctipNom = IIf(IsDBNull(nominaElem("cod_tipo_nomina")), "", nominaElem("cod_tipo_nomina"))

            If _monto <> 0 Or {"TOTPER", "TOTDED", "NETO"}.Contains(_concepto.Trim) And tpnom = ctipNom And strBool.getValue(concept.Rows(0)("activo")) And Not strBool.getValue(concept.Rows(0)("importar")) Then
                Dim search = infoTabla("ano = '" & nominaElem("ano").Trim & "' AND periodo = '" & nominaElem("periodo").Trim & "' AND reloj = '" & nominaElem("reloj").Trim &
                                          "' AND concepto = '" & _concepto.Trim & "' AND tipo_nomin = '" & nominaElem("tipo_nomina").Trim & "'", dtMovsCompLocal)

                If search.Rows.Count = 0 Then
                    Dim dicInfo = New Dictionary(Of String, Object) From {{"ano", nominaElem("ano")}, {"periodo", nominaElem("periodo")},
                                                                          {"tipo_nomin", nominaElem("cod_tipo_nomina")}, {"reloj", nominaElem("reloj")},
                                                                          {"concepto", _concepto.Trim}, {"monto", _monto}, {"prioridad", concept.Rows(0)("prioridad")},
                                                                          {"importar", concept.Rows(0)("importar")}, {"nuevo", Nothing}, {"periodo_ac", Nothing},
                                                                          {"tipo_comp", _tipo_comp}}
                    ModificaDatatable("Agregar", dtMovsCompLocal, dicInfo)
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Se encarga de guardar los conceptos en movimientosPro
    ''' </summary>
    ''' <param name="_monto">Monto de concepto</param>
    ''' <param name="_concepto">Concepto</param>
    ''' <param name="data">Diccionario con info. de variables del periodo</param>
    ''' <param name="infoEmp">Registro con info. de empleado [nominaPro]</param>
    ''' <param name="dicInfoDt">Tablas de consulta</param>
    ''' <remarks></remarks>
    Private Sub puente(ByRef _monto As Decimal,
                       _concepto As String,
                       data As Dictionary(Of String, String),
                       infoEmp As DataRow,
                       Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing)

        _monto = Math.Round(_monto, 2, MidpointRounding.AwayFromZero)

        Dim concept = infoTabla("concepto='" & _concepto.Trim & "'", dicInfoDt("dtConceptosPro"))
        Dim incap_7 = If(IsDBNull(concept.Rows(0)("incap_7")), 0, 1)
        Dim activo = If(IsDBNull(concept.Rows(0)("activo")), 0, 1)
        Dim suma_neto = If(IsDBNull(concept.Rows(0)("suma_neto")), 0, 1)
        Dim base_pago = If(IsDBNull(concept.Rows(0)("base_pago")), 0, 1)

        Dim incapacidad = IIf(IsDBNull(infoEmp("incapacidad")), 0, infoEmp("incapacidad"))
        Dim _sobrepasa_incapacidad As Boolean = incapacidad > 0 And incapacidad + IIf(IsDBNull(infoEmp("faltas")), 0, infoEmp("faltas")) >= 7


        If _sobrepasa_incapacidad And Not strBool.getValue(incap_7) And
            Not {"DIDESP", "BONDES", "BONPA1", "BONPA2", "BONPA3"}.Contains(_concepto.Trim) And
            Not strBool.getValue(infoEmp("finiquito")) Then : _monto = 0 : End If

        If Not strBool.getValue(activo) Then : _monto = 0 : End If

        If suma_neto Then
            If _concepto.Trim = "SEGVIV" And Me._globalVars("_acum_base_pago") < _monto Then
                _monto = 0
            ElseIf concept.Rows(0)("cod_naturaleza").ToString.Trim = "P" Then
                Me._globalVars("_acum_neto") += _monto
                Me._globalVars("_acum_base_pago") += IIf(strBool.getValue(base_pago), _monto, 0)
            ElseIf concept.Rows(0)("cod_naturaleza").ToString.Trim = "D" And Me._globalVars("_acum_neto") >= _monto And Me._globalVars("_acum_neto") > 0 Then
                _globalVars("_acum_neto") -= _monto
                _globalVars("_acum_base_pago") -= IIf(strBool.getValue(base_pago), _monto, 0)
            ElseIf concept.Rows(0)("cod_naturaleza").ToString.Trim = "D" And Me._globalVars("_acum_neto") < _monto And Me._globalVars("_acum_neto") > 0 Then
                _monto = Me._globalVars("_acum_neto")
                Me._globalVars("_acum_neto") = 0
                Me._globalVars("_acum_base_pago") -= IIf(strBool.getValue(base_pago), _monto, 0)
            ElseIf concept.Rows(0)("cod_naturaleza").ToString.Trim = "D" And Me._globalVars("_acum_neto") < _monto And Me._globalVars("_acum_neto") <= 0 Then
                _monto = 0
                Me._globalVars("_acum_neto") = 0
                Me._globalVars("_acum_base_pago") -= IIf(strBool.getValue(base_pago), _monto, 0)
            End If
        End If

        Dim vars As New Dictionary(Of String, Decimal) From {{"_saldo_temp", 0}}
        If IsDBNull(concept.Rows(0)("concepto_saldo")) Or concept.Rows(0)("concepto_saldo").ToString.Count > 0 Then
            Dim saldo = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' AND reloj = '" & infoEmp("reloj") & "' AND concepto = '" & _concepto.Trim & "'", dicInfoDt("dtAjustesPro"))
            Dim value = 0D
            If saldo.Rows.Count > 0 Then
                Try : value = saldo.Rows(0)("saldo") : Catch ex As Exception : value = 0.0 : End Try
            End If
            vars("_saldo_temp") = IIf(saldo.Rows.Count > 0, value - _monto, 0)
        End If

        If _monto <> 0 Or {"TOTPER", "TOTDED", "NETO"}.Contains(_concepto.Trim) And concept.Rows(0)("cod_tipo_nomina").ToString.Trim = infoEmp("cod_tipo_nomina").ToString.Trim And activo Then

            Dim movPro = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' AND reloj = '" & infoEmp("reloj").Trim &
                                      "' AND concepto = '" & _concepto.Trim & "' AND tipo_nomina = 'N' ", dtMovsProLocal)

            If movPro.Rows.Count = 0 Then
                Dim dicInfo = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"tipo_nomina", "N"},
                                                                     {"reloj", infoEmp("reloj")}, {"concepto", _concepto.Trim}, {"monto", _monto},
                                                                     {"prioridad", concept.Rows(0)("prioridad")}, {"importar", concept.Rows(0)("importar")},
                                                                     {"nuevo", Nothing}, {"periodo_act", Nothing}}
                ModificaDatatable("Agregar", dtMovsProLocal, dicInfo)

                If _concepto.Trim = "HRSEX2" Then
                    Dim existe As DataTable = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' AND reloj = '" & infoEmp("reloj").Trim &
                                                           "' AND concepto = '" & _concepto.Trim & "' AND tipo_nomina = '" & infoEmp("tipo_nomina").Trim & "'", dtMovsProLocal)

                    If existe.Rows.Count > 0 Then
                        Dim conInfo = infoTabla("concepto='HR2SE1'", dicInfoDt("dtConceptosPro"))
                        Dim dicInfo2 = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"tipo_nomina", "N"},
                                                                               {"reloj", infoEmp("reloj")}, {"concepto", "HR2SE1"}, {"monto", _monto},
                                                                               {"prioridad", conInfo.Rows(0)("prioridad")}, {"importar", conInfo.Rows(0)("importar")},
                                                                               {"nuevo", Nothing}, {"periodo_act", Nothing}}
                        ModificaDatatable("Agregar", dtMovsProLocal, dicInfo2)
                    End If
                End If
            Else

                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & _concepto.Trim &
                                  "'", col:="monto", valor:=IIf({"PENALI", "PORPEN"}.Contains(_concepto.Trim), movPro.Rows(0)("monto"), 0) + _monto)
                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & _concepto.Trim &
                                  "'", col:="prioridad", valor:=concept.Rows(0)("prioridad"))
                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & _concepto.Trim &
                                  "'", col:="importar", valor:=concept.Rows(0)("importar"))
            End If
        End If

        If vars("_saldo_temp") > 0 And concept.Rows(0)("concepto_saldo").ToString.Trim.Count > 0 Then

            Dim movPro = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' AND reloj = '" & infoEmp("reloj").Trim & "' AND concepto = '" &
                                      concept.Rows(0)("concepto_saldo").Trim & "' AND tipo_nomina = '" & infoEmp("tipo_nomina").Trim & "'", dtMovsProLocal)

            If movPro.Rows.Count = 0 Then
                Dim dicInfo = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"tipo_nomina", "N"},
                                                                      {"reloj", infoEmp("reloj")}, {"concepto", concept.Rows(0)("concepto_saldo").Trim},
                                                                      {"monto", vars("_saldo_temp")}, {"prioridad", concept.Rows(0)("prioridad")},
                                                                      {"importar", concept.Rows(0)("importar")}, {"nuevo", Nothing}, {"periodo_act", Nothing}}
                ModificaDatatable("Agregar", dtMovsProLocal, dicInfo)
            Else
                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & concept.Rows(0)("concepto_saldo").Trim &
                                 "'", col:="monto", valor:=vars("_saldo_temp"))
                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & _concepto.Trim &
                                  "'", col:="prioridad", valor:=concept.Rows(0)("prioridad"))
                ModificaDatatable("Editar", dtMovsProLocal, filtro:="reloj='" & infoEmp("reloj") & "' and concepto='" & _concepto.Trim &
                                  "'", col:="importar", valor:=concept.Rows(0)("importar"))
            End If
        End If

    End Sub

    'modi comm librerias (_tot_perc_compensacion) -- 11 oct 2023 -- Modificaciones Ernesto
    Private Function totPercCompensacion(data As Dictionary(Of String, String), element As DataRow, _tipo_comp As String, tabla As DataTable,
                         Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal
        Dim _pertot = 0D
        Dim dataTable = dtMovsCompLocal
        If dataTable.Rows.Count > 0 Then
            For Each item In dataTable.Rows
                Dim conceptP As DataTable = infoTabla("concepto = '" & item("concepto").Trim & "' and suma_neto = '1' AND positivo = '1'", dicInfoDt("dtConceptosPro"))
                If conceptP.Rows.Count > 0 Then : _pertot += item("monto") : End If
            Next
        End If

        Return _pertot
    End Function

    'modi comm librerias (_tot_ded_compensacion) -- 11 oct 2023 -- Modificaciones Ernesto
    Private Function totDedCompensacion(data As Dictionary(Of String, String), element As DataRow, _tipo_comp As String, tabla As DataTable,
                         Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal
        Dim _dedtot = 0D
        Dim dataTable = dtMovsCompLocal
        If dataTable.Rows.Count > 0 Then
            For Each item In dataTable.Rows
                Dim conceptP As DataTable = infoTabla("concepto = '" & item("concepto").Trim & "' and suma_neto = '1' AND positivo = '0'", dicInfoDt("dtConceptosPro"))
                If conceptP.Rows.Count > 0 Then : _dedtot += item("monto") : End If
            Next
        End If

        Return _dedtot
    End Function

    'modi comm librerias (antiguedad)
    Private Shared Function antiguedad(fecha_ini As Date, Optional fecha_fin As Date = Nothing) As Integer
        If fecha_fin = Nothing Then : fecha_fin = Now() : End If
        'FOX: *calculo de años cumplidos
        Return (fecha_fin - fecha_ini.AddDays(1)).TotalDays / 365.25 + 1
    End Function

    'modi comm librerias (_tot_perc) -- MOdificaciones 4 oct 2023 -- Ernesto
    Private Function totPerc(data As Dictionary(Of String, String), element As DataRow, Optional tabla As DataTable = Nothing,
                         Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal

        Dim pertot = 0D
        If tabla Is Nothing Then : tabla = dtMovsProLocal : End If
        Dim tablaRows = tabla.Select("ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and reloj='" & element("reloj") & "'")

        For Each item In tablaRows
            Dim concept As DataTable = infoTabla("concepto = '" & item("concepto").Trim & "' and suma_neto = 1 AND positivo = 1", dicInfoDt("dtConceptosPro"))
            If concept.Rows.Count > 0 Then : pertot += item("monto") : End If
        Next
        Return Math.Round(pertot, 2, MidpointRounding.AwayFromZero)
    End Function

    'modi comm librerias (_tot_ded) -- MOdificaciones 4 oct 2023 -- Ernesto
    Private Function totDed(data As Dictionary(Of String, String), element As DataRow, Optional tabla As DataTable = Nothing,
                       Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal

        Dim dedtot = 0D
        If tabla Is Nothing Then : tabla = dtMovsProLocal : End If
        Dim tablaRows = tabla.Select("ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and reloj='" & element("reloj") & "'")

        For Each item In tablaRows
            Dim concept As DataTable = infoTabla("concepto = '" & item("concepto").Trim & "' and suma_neto = 1 AND positivo = 0", dicInfoDt("dtConceptosPro"))
            If concept.Rows.Count > 0 Then : dedtot += item("monto") : End If
        Next
        Return Math.Round(dedtot, 2, MidpointRounding.AwayFromZero)
    End Function

    'modi comm librerias (ispt_2008_quincenal) -- MOdificaciones 4 oct 2023 -- Ernesto
    Private Function ispt2008Quincenal(data As Dictionary(Of String, String), element As DataRow, gravado As Decimal, tabla As String,
                       Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal

        Dim valor = 0D
        Dim isptQuincenal As DataTable = infoTabla("tabla='" & tabla & "' and lim_inf <= '" & gravado & "'", dicInfoDt("dtisptQuincenal"), "lim_inf DESC")

        If isptQuincenal.Rows.Count > 0 Then
            If tabla = "Impuesto" Then : valor = (gravado - isptQuincenal.Rows(0)("lim_inf")) * isptQuincenal.Rows(0)("porcentaje") + isptQuincenal.Rows(0)("cta_fija")                                 'FOX: store ((_gravado-ispt_quincenal.lim_inf)*ispt_quincenal.porcentaje)+ispt_quincenal.cta_fija to _valor
            Else : valor = isptQuincenal.Rows(0)("subempleo") : End If                                                                                                                                  'FOX: store subempleo to _valor
        End If
        Return valor
    End Function

    'modi comm librerias (ispt_2008) -- MOdificaciones 4 oct 2023 -- Ernesto
    Private Function ispt2008(data As Dictionary(Of String, String), element As DataRow, gravado As Decimal, tabla As String,
                       Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal

        Dim valor = 0D
        Dim isptPro As DataTable = infoTabla("tabla='" & tabla & "' and lim_inf <= '" & gravado & "'", dicInfoDt("dtisptPro"), "lim_inf DESC")

        If isptPro.Rows.Count > 0 Then
            If tabla = "Impuesto" Then : valor = (gravado - isptPro.Rows(0)("lim_inf")) * isptPro.Rows(0)("porcentaje") + isptPro.Rows(0)("cta_fija")                                                   'FOX: store ((_gravado-ispt_quincenal.lim_inf)*ispt_quincenal.porcentaje)+ispt_quincenal.cta_fija to _valor
            Else : valor = isptPro.Rows(0)("subempleo")                                                                                                                                                 'FOX: store subempleo to _valor
            End If
        End If
        Return valor
    End Function

    'modi comm librerias (ispt_2008) -- MOdificaciones 4 oct 2023 -- Ernesto
    Private Function ispt2008Mensual(data As Dictionary(Of String, String), element As DataRow, gravado As Decimal, tabla As String,
                       Optional ByVal dicInfoDt As Dictionary(Of String, DataTable) = Nothing) As Decimal

        Dim valor = 0D
        Dim isptProMensual As DataTable = infoTabla("tabla='" & tabla & "' and lim_inf <= '" & gravado & "'", dicInfoDt("dtisptProMensual"), "lim_inf DESC")

        If isptProMensual.Rows.Count > 0 Then
            If tabla = "Impuesto" Then : valor = (gravado - isptProMensual.Rows(0)("lim_inf")) * isptProMensual.Rows(0)("porcentaje") + isptProMensual.Rows(0)("cta_fija")                              'FOX: store ((_gravado-ispt_quincenal.lim_inf)*ispt_quincenal.porcentaje)+ispt_quincenal.cta_fija to _valor
            Else : valor = isptProMensual.Rows(0)("subempleo") : End If                                                                                                                                 'FOX: store subempleo to _valor
        End If
        Return valor
    End Function

    ''' <summary>
    ''' Suma de montos de los conceptos de cálculo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function sumaMonto(param1 As String, param2 As String, dt As Object, Optional op As Integer = 0) As Decimal
        Select Case op
            Case 0
                Return IIf(IsDBNull(dt.Compute("sum(monto)", "reloj='" & param1 & "' and concepto='" & param2 & "'")), 0.0, dt.Compute("sum(monto)", "reloj='" & param1 & "' and concepto='" & param2 & "'"))
            Case 1
                Return IIf(IsDBNull(dt.Compute("sum(monto)", param1)), 0.0, dt.Compute("sum(monto)", param1))
            Case 2
                Dim total = 0D
                For Each rowInf In dt : total += CDec(rowInf("monto").ToString) : Next : Return total
        End Select
    End Function

    '== Retorna variable 'vars' de funcion calculo
    Private Function diccionarioVarCalculo(element As DataRow, _tipo As String) As Dictionary(Of String, Double)
        Dim vars As New Dictionary(Of String, Double) From {{"_sdo_priant", element("sactual")},
                                                             {"_sdo_norest", element("sactual")},
                                                             {"_sdo_indemn", element("sactual")},
                                                             {"_porc_priant", 100},
                                                             {"_porc_norest", 100},
                                                             {"_porc_indemn", 100},
                                                             {"_vacaciones", 0},
                                                             {"_ajuste_vacaciones", 0},
                                                             {"_dias_ajuste_vacaciones", 0},
                                                             {"_prima_vac", 0},
                                                             {"_dias_prima", 0},
                                                             {"_prima_sabatina", 0},
                                                             {"_prima_dominical", 0},
                                                             {"_exento_dominical", 0},
                                                             {"_monto_despensa_efectivo", 0},
                                                             {"_exento_prima_vac", 0},
                                                             {"_dev_hrs_permiso_sin_goce", 0},
                                                             {"_anticipo_aguinaldo", 0},
                                                             {"_exento_aguinaldo", 0},
                                                             {"_excedente_ahorro", 0},
                                                             {"_dev_hrs_retardo", 0},
                                                             {"_ajuste_aguinaldo", 0},
                                                             {"_liq_intereses_fa", 0},
                                                             {"_dias_bim", 0},
                                                             {"_semanas_infonavit", 0},
                                                             {"_seguro_vivienda", 0},
                                                             {"_15_minimos", 0},
                                                             {"_tope_vac", 0},
                                                             {"_bono", 0},
                                                             {"_isr_cargo", 0},
                                                             {"_exento_indemnizacion", 0},
                                                             {"_ded_falta_injustificada", 0},
                                                             {"_liq_fa_empleado", 0},
                                                             {"_liq_fa_empresa", 0},
                                                             {"_exento_prima_ant", 0},
                                                             {"_exento_no_rest", 0},
                                                             {"_hrs_normales", 0},
                                                             {"_hrs_dobles", 0},
                                                             {"_hrs_triples", 0},
                                                             {"_hrs_domingo", 0},
                                                             {"_hrs_descanso", 0},
                                                             {"_hrs_festivo", 0},
                                                             {"_hrs_convenio", 0},
                                                             {"_hrs_conv_cobrado", 0},
                                                             {"_bono_asi", 0},
                                                             {"_bono_pun", 0},
                                                             {"_dobles33", 0},
                                                             {"_triples33", 0},
                                                             {"_cant_bono_asist_perfecta", 0},
                                                             {"_hrs_festivo_laborado", 0},
                                                             {"_hrs_dobles_integrables", 0},
                                                             {"_hrs_triples_integrables", 0},
                                                             {"_hrs_permiso_sin_goce", 0},
                                                             {"_hrs_retardo", 0},
                                                             {"_min_devolucion_retardo", 0},
                                                             {"_hrs_dobles_anteriores", 0},
                                                             {"_hrs_triples_anteriores", 0},
                                                             {"_sueldo_dobles_anteriores", 0},
                                                             {"_sueldo_triples_anteriores", 0},
                                                             {"_dias_devolucion_comedor_con_subsidio", 0},
                                                             {"_dias_devolucion_comedor_sin_subsidio", 0},
                                                             {"_dias_devolucion_comedor_sin_subsidio2", 0},
                                                             {"_dias_devolucion_desayuno_sin_subsidio", 0},
                                                             {"_hrs_permiso_sin_goce_dev", 0},
                                                             {"_coutas_gafete", 0},
                                                             {"_dias_normales", 0},
                                                             {"_dias_festivos", 0},
                                                             {"_dias_subsidio_incapacidad", 0},
                                                             {"_dias_pagados", 0},
                                                             {"_dias_infonavit", 0},
                                                             {"_dias_imss", 0},
                                                             {"_dias_vac", 0},
                                                             {"_dias_permiso_con_goce", 0},
                                                             {"_dias_permiso_nacimiento", 0},
                                                             {"_dias_permiso_matrimonio", 0},
                                                             {"_dias_permiso_funeral", 0},
                                                             {"_dias_permiso_corporativo", 0},
                                                             {"_dias_aguinaldo", 0},
                                                             {"_dias_prima_sabatina", 0},
                                                             {"_dias_prima_dominical", 0},
                                                             {"_dias_permiso_con_goce_dev", 0},
                                                             {"_dias_permiso_nacimiento_dev", 0},
                                                             {"_dias_permiso_matrimonio_dev", 0},
                                                             {"_dias_prima_sabatina_dev", 0},
                                                             {"_dias_prima_dominical_dev", 0},
                                                             {"_dias_falta_injustificada", 0},
                                                             {"_dias_falta_justificada", 0},
                                                             {"_dias_permiso_sin_goce", 0},
                                                             {"_dias_suspension", 0},
                                                             {"_dias_verano", 0},
                                                             {"_dias_inc_maternidad", 0},
                                                             {"_dias_falta_injustificada_dev", 0},
                                                             {"_dias_falta_justificada_dev", 0},
                                                             {"_dias_permiso_sin_goce_dev", 0},
                                                             {"_dias_suspension_dev", 0},
                                                             {"_dias_permiso_verano_dev", 0},
                                                             {"_dias_inc_dev", 0},
                                                             {"_dias_inc_maternidad_devol", 0},
                                                             {"_dias_inc_general_dev", 0},
                                                             {"_dias_inc_trabajo_dev", 0},
                                                             {"_horas_extras_dobles_dev", 0},
                                                             {"_horas_extras_triples_dev", 0},
                                                             {"_percepcion_normal", 0},
                                                             {"_dias_semana", 0},
                                                             {"_percepcion_con_goce", 0},
                                                             {"_percepcion_nacimiento", 0},
                                                             {"_percepcion_matrimonio", 0},
                                                             {"_percepcion_funeral", 0},
                                                             {"_percepcion_corporativo", 0},
                                                             {"_percepcion_festiva", 0},
                                                             {"_dias_comedor_sinsub", 0},
                                                             {"_dias_comedor_consub", 0},
                                                             {"_dias_comedor_desayuno", 0},
                                                             {"_dias_comedor_desayuno_sinsub", 0},
                                                             {"_dias_descuento_50", 0},
                                                             {"_dias_devolucion_descuento_50", 0},
                                                             {"_dias_festivo_laborado", 0},
                                                             {"_dias_inc_general", 0},
                                                             {"_percepcion_doble", 0},
                                                             {"_percepcion_doble_anterior", 0},
                                                             {"_percepcion_triple_anterior", 0},
                                                             {"_sueldo_despensa", 0},
                                                             {"_ajuste_prima_vacacional", 0},
                                                             {"_subsidio_incapacidad", 0},
                                                             {"_retroactivo", 0},
                                                             {"_ideas", 0},
                                                             {"_idea_trimestral", 0},
                                                             {"_idea_anual", 0},
                                                             {"_yellow_blood", 0},
                                                             {"_compensacion_temporal", 0},
                                                             {"_compensacion_tunel", 0},
                                                             {"_devolucion_incapacidad", 0},
                                                             {"_devolucion_falta_injustificada", 0},
                                                             {"_factor_temp", 0},
                                                             {"_sueldo_temp", 0},
                                                             {"_devolucion_falta_justificada", 0},
                                                             {"_monto_despensa", 0},
                                                             {"_bono_recomendacion", 0},
                                                             {"_bono_especial", 0},
                                                             {"_bono_ajuste_vida", 0},
                                                             {"_bono_lealtad", 0},
                                                             {"_devolucion_juzgado_civil", 0},
                                                             {"_devolucion_afecta_isr", 0},
                                                             {"_exento_doble", 0},
                                                             {"_percepcion_doble_integrables", 0},
                                                             {"_percepcion_triple", 0},
                                                             {"_percepcion_triple_integrables", 0},
                                                             {"_festivo_laborado", 0},
                                                             {"_sueldo_diafel", 0},
                                                             {"_festivo_laborado_dias", 0},
                                                             {"_dias_inc_trabajo", 0},
                                                             {"_dias_inc_trayecto", 0},
                                                             {"_dias_incapacidad_total", 0},
                                                             {"_devolucion_permiso_sin_goce", 0},
                                                             {"_devolucion_suspension", 0},
                                                             {"_devolucion_permiso_verano", 0},
                                                             {"_gafete_dev", 0},
                                                             {"_devolucion_comedor_con_subsidio", 0},
                                                             {"_devolucion_comedor_sin_subsidio", 0},
                                                             {"_devolucion_comedor_sin_subsidio2", 0},
                                                             {"_devolucion_desayuno_sin_subsidio", 0},
                                                             {"_devolucion_fonacot", 0},
                                                             {"_devolucion_infonavit", 0},
                                                             {"_devolucion_recuperacion_infonavit", 0},
                                                             {"_fahorro", 0},
                                                             {"_compensacion_aguinaldo", 0},
                                                             {"_30_minimos", 0},
                                                             {"_tope_ahorro", 0},
                                                             {"_otras_per_no_gra", 0},
                                                             {"_percepcion_exenta", 0},
                                                             {"_descuentos_dias_total", 0},
                                                             {"_ded_inc_maternidad", 0},
                                                             {"_ded_inc_general", 0},
                                                             {"_ded_inc_trabajo", 0},
                                                             {"_ded_inc_trayecto", 0},
                                                             {"_ded_suspension", 0},
                                                             {"_sueldo_paro", 0},
                                                             {"_pago_c50", 0},
                                                             {"_descuento_50", 0},
                                                             {"_ded_verano", 0},
                                                             {"_ded_permiso_sin_goce", 0},
                                                             {"_ded_falta_justificada", 0},
                                                             {"_ded_hrs_retardo", 0},
                                                             {"_devolucion_festivo_laborado", 0},
                                                             {"_isr_afavor", 0},
                                                             {"_devolucion_percepcion_doble", 0},
                                                             {"_devolucion_percepcion_triple", 0},
                                                             {"_devolucion_prima_sabatina", 0},
                                                             {"_devolucion_prima_dominical", 0},
                                                             {"_ajuste_sueldo", 0},
                                                             {"_percepcion_gravable", 0},
                                                             {"_percepcion_gravable_sin_aguinaldo", 0},
                                                             {"_percepcion_gravable_solo_aguinaldo", 0},
                                                             {"_devolucion_isr_cargo", 0},
                                                             {"_gravado_diario", 0},
                                                             {"_gravado_mensual", 0},
                                                             {"_gravado_semanal", 0},
                                                             {"_gravado_quincenal", 0},
                                                             {"_ispt_temp", 0},
                                                             {"_sub_empleo_temp", 0},
                                                             {"_ispt_temp_acumulado", 0},
                                                             {"_total_gravado", 0},
                                                             {"_dias_anuales", 0},
                                                             {"_sueldo_mensual", 0},
                                                             {"_ispt_temp_1", 0},
                                                             {"_ispt_temp_2", 0},
                                                             {"_factor1", 0},
                                                             {"_crepag_temp", 0},
                                                             {"_isptre_temp", 0},
                                                             {"_imss", 0},
                                                             {"_imss_vac", 0},
                                                             {"_enf", 0},
                                                             {"_inv", 0},
                                                             {"_excedente", 0},
                                                             {"_infonavit", 0},
                                                             {"_cuota_semanal", 0},
                                                             {"_adeudo_infonavit_extra", 0},
                                                             {"_fonacot", 0},
                                                             {"_fonacot_proporcional", 0},
                                                             {"_recuperacion_fonacot", 0},
                                                             {"_pension_alimenticia", 0},
                                                             {"_base_pension", 0},
                                                             {"_despensa_pension", 0},
                                                             {"_cuota_sindical", 0},
                                                             {"_adeudo_infonavit", 0},
                                                             {"_prestamo_sueldo", 0},
                                                             {"_caja_ahorro", 0},
                                                             {"_prestamo_caja_ahorro", 0},
                                                             {"_comedor_sinsub", 0},
                                                             {"_comedor_desayuno", 0},
                                                             {"_comedor_desayuno_sinsub", 0},
                                                             {"_comedor_consub", 0},
                                                             {"_adeudo_comedor_consub", 0},
                                                             {"_adeudo_infonavit_", 0},
                                                             {"_adeudo_infonavit_x", 0},
                                                             {"_tienda", 0},
                                                             {"_tienda_resta", 0},
                                                             {"_FAMILY", 0},
                                                             {"_devolucion_vacaciones", 0},
                                                             {"_devolucion_subsidio_por_incapacidad", 0},
                                                             {"_devolucion_per_goce", 0},
                                                             {"_devolucion_per_nacimiento", 0},
                                                             {"_devolucion_per_matrimonio", 0},
                                                             {"_beneficios_flexibles", 0},
                                                             {"_gafete", 0},
                                                             {"_bondes_temporal", 0},
                                                             {"_devolucion_bono", 0},
                                                             {"_devolucion_bono_recomendacion", 0},
                                                             {"_capacitacion", 0},
                                                             {"_prestamo_subsidio", 0},
                                                             {"_percepcion_total", 0},
                                                             {"_deduccion_total", 0},
                                                             {"_nod107", 0},
                                                             {"_nod002", 0},
                                                             {"_nop007", 0},
                                                             {"_nod071", 0},
                                                             {"_nop008", 0},
                                                             {"_neto", 0},
                                                             {"_devolucion_tienda", 0},
                                                             {"_devolucion_inc_general", 0},
                                                             {"_devolucion_inc_trabajo", 0},
                                                             {"_devolucion_inc_maternidad", 0},
                                                             {"_devolucion_cuota_sindical", 0},
                                                             {"_devolucion_descuento_sindical", 0},
                                                             {"_vac_pag", 0},
                                                             {"_por_fah", IIf(Me.Options("periodo_aguinaldo"), 0, IIf(_tipo = "A", 13, 9.7))},
                                                             {"_dias_vac_dev", 0},
                                                             {"_deposito_defuncion", 0},
                                                             {"_reembolso_educativo", 0},
                                                             {"_reembolso_resta", 0},
                                                             {"_dias_despensa", 0},
                                                             {"_percepcion_teletrabajo", 0},
                                                             {"_bono_teletrabajo_semanal", 150},
                                                             {"_bono_teletrabajo_quincenal", 250},
                                                             {"_dias_permiso_teletrabajo", 0},
                                                             {"_bono_teletrabajo", 0},
                                                             {"_isr_anticipado", 0},
                                                             {"_bono_referencial", 0},
                                                             {"_prestamo_impuesto_cargo", 0},
                                                             {"_deduccion_prestamo_impuesto_cargo", 0},
                                                             {"_devolucion_RIDE", 0},
                                                             {"_prima_antiguedad", 0},
                                                             {"_bono_permanencia", 0},
                                                             {"_bono_cierre_eaton", 0},
                                                             {"_bono_cierre_schenker", 0},
                                                             {"_bono_cierre_te_schenker", 0}}

        Return vars
    End Function

    ''' <summary>
    ''' Función especial para sumarizar los montos respetando los sueldos y factores de los conceptos de DEVFIN,DEVPSG,DEVFJU,DEVPSV en la parte del cálculo
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SumarizarMontosDevoluciones(dtAjuste As DataTable, concepto As String, Optional sueldoActual As Decimal = 0.0, Optional factorDefault As Decimal = 0.0) As Decimal
        Try
            Dim sueldo = 0D
            Dim factor = 0D
            Dim monto = 0D
            Dim suma = 0D
            Dim drFiltro = dtAjuste.Select("concepto='" & concepto & "'")

            If drFiltro.Count > 0 Then
                For Each x In drFiltro
                    sueldo = 0D : factor = 0D : monto = 0D
                    sueldo = If(IsDBNull(x("sueldo")), sueldoActual, x("sueldo")) : If sueldo = 0 Then Me.addLog("El empleado " + x("reloj") + " con concepto " + drFiltro("concepto") + " no cuenta con sueldo [id " & x("id") & "]")
                    factor = If(IsDBNull(x("factor")), factorDefault, x("factor")) : If factor = 0 Then Me.addLog("El empleado " + x("reloj") + " con concepto " + drFiltro("concepto") + " no cuenta con factor [id " & x("id") & "]")
                    monto = If(IsDBNull(x("monto")), 0, x("monto"))
                    suma += (monto * sueldo * factor)
                Next
            End If

            Return Math.Round(suma, 2)

        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Cálculo normal
    ''' </summary>
    ''' <param name="recalculo">Correr nuevamente cálculo</param>
    ''' <param name="infoEmp">Registro con info. de empleado [nominaPro]</param>
    ''' <param name="data">Diccionario con info. de variables del periodo</param>
    ''' <param name="dicInfoDt">Tablas de consulta</param>
    ''' <param name="strFiltroRelojes">Filtro para relojes seleccionados</param>
    ''' <remarks></remarks>
    Public Sub CalculoNormal(infoEmp As DataRow,
                            data As Dictionary(Of String, String),
                            Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing,
                            Optional strFiltroRelojes As Object = Nothing,
                            Optional strErrores As System.Text.StringBuilder = Nothing)

        Dim strReloj = infoEmp("reloj").ToString.Trim

        Try
            '--- Variables generales
            Dim _dtCias = dicInfoDt("dtCias")
            Dim _uma = _dtCias.Rows(0)("uma")
            Dim _minimo_df = _dtCias.Rows(0)("minimo_df")
            Dim _fac_enfermedad_mat = _dtCias.Rows(0)("enf_mat_t")
            Dim _fac_invalidez_vida = _dtCias.Rows(0)("inv_vid_t")
            Dim _infonavit_cias = _dtCias.Rows(0)("umi")
            Dim _seguro_vivienda = _dtCias.Rows(0)("pago_seg_viv")

            '--- Variables info. empleado
            Dim _tipo = If(IsDBNull(infoEmp("cod_tipo")), "", infoEmp("cod_tipo").ToString.Trim)
            Dim _sactual = If(IsDBNull(infoEmp("sactual")), 0, infoEmp("sactual"))
            Dim _integrado = If(IsDBNull(infoEmp("integrado")), 0, infoEmp("integrado"))
            Dim _cod_turno = If(IsDBNull(infoEmp("cod_turno")), "", infoEmp("cod_turno").ToString.Trim)
            Dim _finiquito = If(IsDBNull(infoEmp("finiquito")), False, Convert.ToBoolean(infoEmp("finiquito")))
            Dim _cod_comp = If(IsDBNull(infoEmp("cod_comp")), "", "'" & infoEmp("cod_comp").ToString.Trim & "'")
            Dim _cod_clase = If(IsDBNull(infoEmp("cod_clase")), "", infoEmp("cod_clase").ToString.Trim)

            Dim _dias_prima_vac = infoEmp("privac_dias")
            Dim _por_prima_vac = 25

            Dim _hrs_turno = If(_cod_turno <> "",
                                If(IsDBNull(infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("horas")), 0,
                                   infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("horas")),
                                0)

            Dim _hrs_diarias = If(IsDBNull(infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("horas_diarias")), 0,
                                  infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("horas_diarias"))

            Dim _dias_habiles = If(IsDBNull(infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("dias_habiles")), 0,
                                  infoTabla("cod_turno='" & _cod_turno & "' and cod_comp in (" & _cod_comp & ")", dicInfoDt("dtTurnos")).rows(0)("dias_habiles"))


            Dim _dias_septimo = 7 - _dias_habiles

            Me._globalVars("_acum_base_pago") = 0D
            Me._globalVars("_acum_neto") = 0D
            Me._globalVars("_porcentaje_despensa") = 11.5

            '--- Validaciones de datos
            If _sactual = 0 Or _integrado = 0 Then
                strErrores.AppendLine("Cálculo normal: " & strReloj)
                strErrores.AppendLine("  >> Tipo empleado: " & _tipo.ToString)
                strErrores.AppendLine("  >> Sueldo: " & _sactual.ToString)
                strErrores.AppendLine("  >> Integrado: " & _integrado.ToString)
                strErrores.AppendLine("--------------------------------------")
                Me.addLog("No se realizó cálculo normal reloj [" & strReloj & "], por favor, revise su sueldo normal o integrado")
                Exit Sub
            End If

            '--- Tope integrado
            Dim _tope25 As Double = IIf(_integrado > (25 * _uma), 25 * _uma, _integrado)

            '--- Variables de conceptos que se almacenan en un diccionario
            Dim vars = diccionarioVarCalculo(infoEmp, _tipo)

            '--- Variables con Horas
            Dim horasProC As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtHorasPro"))
            Dim ajustesProC As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtAjustesProC"))

            '--- Información del periodo
            Dim _dtInfoPer As DataTable = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "'", dicInfoDt("dtPeriodos"))
            Dim _mesPer = Convert.ToDateTime(_dtInfoPer.Rows(0)("fecha_fin")).Month
            Dim _anioPer = Convert.ToDateTime(_dtInfoPer.Rows(0)("fecha_fin")).Year
            Dim _dias_bim = _dtInfoPer.Rows(0)("dias_bim")
            Dim _semanas_infonavit = _dtInfoPer.Rows(0)("semanas_infonavit")

            '********************************************************************* PERCEPCIONES ********************************************************************
            'HRSNOR - Horas normales
            vars("_hrs_normales") = sumaMonto(strReloj, "HRSNOR", horasProC)
            Me.puente(vars("_hrs_normales"), "HRSNOR", data, infoEmp, dicInfoDt)

            'DIANOR - Tomado desde ajustes y horas
            vars("_dias_normales") = sumaMonto(strReloj, "DIANOR", ajustesProC)
            vars("_dias_normales") += sumaMonto(strReloj, "DIANOR", horasProC)
            Me.puente(vars("_dias_normales"), "DIANOR", data, infoEmp, dicInfoDt)

            'PERNOR - Percepción normal
            If _dias_habiles > 0 Then
                vars("_percepcion_normal") = Math.Round(_sactual * vars("_dias_normales"), 2)
            Else
                vars("_percepcion_normal") = 0
            End If

            vars("_percepcion_normal") += sumaMonto(strReloj, "PERNOR", ajustesProC)
            Me.puente(vars("_percepcion_normal"), "PERNOR", data, infoEmp, dicInfoDt)

            'DIASVA - Días vacaciones
            vars("_dias_vac") = sumaMonto(strReloj, "DIASVA", horasProC)
            vars("_dias_vac") += sumaMonto(strReloj, "DIASVA", ajustesProC)
            Me.puente(vars("_dias_vac"), "DIASVA", data, infoEmp, dicInfoDt)

            'SEPTMO - Septimo día
            vars("_septimo_dia") = Math.Round(((_dias_septimo * (vars("_dias_normales") + If(Not _finiquito, vars("_dias_vac"), 0))) / _dias_habiles) * _sactual, 2)
            vars("_septimo_dia") += sumaMonto(strReloj, "SEPTMO", ajustesProC)
            Me.puente(vars("_septimo_dia"), "SEPTMO", data, infoEmp, dicInfoDt)

            'BONASI,BONPUN - Premio asistencia y puntualidad
            vars("_premio_asistencia") = Math.Round(0.1 * (vars("_percepcion_normal") + vars("_septimo_dia")), 2)
            vars("_premio_asistencia") += sumaMonto(strReloj, "BONASI", ajustesProC)
            Me.puente(vars("_premio_asistencia"), "BONASI", data, infoEmp, dicInfoDt)

            vars("_premio_puntualidad") = Math.Round(0.1 * (vars("_percepcion_normal") + vars("_septimo_dia")), 2)
            vars("_premio_puntualidad") += sumaMonto(strReloj, "BONPUN", ajustesProC)
            Me.puente(vars("_premio_puntualidad"), "BONPUN", data, infoEmp, dicInfoDt)

            'BONDES - Premio despensa
            vars("_premio_despensa") = Math.Round(_uma * 7 * 0.4, 2)
            vars("_premio_despensa") += sumaMonto(strReloj, "BONDES", ajustesProC)
            Me.puente(vars("_premio_despensa"), "BONDES", data, infoEmp, dicInfoDt)

            'BONPRO - Bono productividad
            vars("_bono_permanencia") = Math.Round((sumaMonto(strReloj, "BONPER", ajustesProC) * vars("_dias_normales")) / _dias_habiles)
            Me.puente(vars("_bono_permanencia"), "BONPER", data, infoEmp, dicInfoDt)

            vars("_bono_cierre_eaton") = sumaMonto(strReloj, "BONEAT", ajustesProC)
            vars("_bono_cierre_schenker") = sumaMonto(strReloj, "BONSCH", ajustesProC)
            vars("_bono_cierre_te_schenker") = sumaMonto(strReloj, "BONTES", ajustesProC)

            vars("_bono_productividad") = vars("_bono_cierre_eaton") + vars("_bono_cierre_schenker") + vars("_bono_cierre_te_schenker") + vars("_bono_permanencia")
            vars("_bono_productividad") += sumaMonto(strReloj, "BONPRO", ajustesProC)
            Me.puente(vars("_bono_productividad"), "BONPRO", data, infoEmp, dicInfoDt)

            If _cod_clase = "A" AndAlso vars("_bono_productividad") > 0 Then
                Me.addLog("El reloj [" & strReloj & "] es administrativo y cuenta con bono de productividad de [" & vars("_bono_productividad") & "]")
            End If

            'PRIANT - Prima antiguedad
            vars("_prima_antiguedad") = sumaMonto(strReloj, "PRIANT", ajustesProC)
            Me.puente(vars("_prima_antiguedad"), "PRIANT", data, infoEmp, dicInfoDt)

            '--------------------------------------------------------------------- Cálculo de vacaciones
            'PERVAC - Percepción vacacional
            If vars("_dias_vac") >= 0 Then
                vars("_vacaciones") = Math.Round(_sactual * vars("_dias_vac"), 2)
                vars("_vacaciones") += sumaMonto(strReloj, "PERVAC", ajustesProC)
                Me.puente(vars("_vacaciones"), "PERVAC", data, infoEmp, dicInfoDt)
            End If

            'DIAPRI - Días prima vacacional
            vars("_dias_prima") = Math.Round(_por_prima_vac / 100 * vars("_dias_vac"), 2)
            vars("_dias_prima") += sumaMonto(strReloj, "DIAPRI", horasProC)
            vars("_dias_prima") += sumaMonto(strReloj, "DIAPRI", ajustesProC)
            Me.puente(vars("_dias_prima"), "DIAPRI", data, infoEmp, dicInfoDt)

            'PRIVAC - Prima vacacional
            vars("_prima_vac") = Math.Round(vars("_dias_prima") * _sactual, 2)
            vars("_prima_vac") += sumaMonto(strReloj, "PRIVAC", ajustesProC)
            Me.puente(vars("_prima_vac"), "PRIVAC", data, infoEmp, dicInfoDt)

            'AJUVAC - Ajuste vacaciones
            'DIAAVA - Dias ajustes vacaciones
            If vars("_dias_vac") < 0 Then
                vars("_ajuste_vacaciones") = Math.Round(vars("_dias_vac") * _sactual * -1, 2)
                vars("_ajuste_vacaciones") += sumaMonto(strReloj, "AJUVAC", ajustesProC)
                vars("_dias_ajuste_vacaciones") = vars("_dias_vac") * -1
                'vars("_devolucion_afecta_isr") += vars("_ajuste_vacaciones")
            End If

            Me.puente(vars("_ajuste_vacaciones"), "AJUVAC", data, infoEmp, dicInfoDt)
            Me.puente(vars("_dias_ajuste_vacaciones"), "DIAAVA", data, infoEmp, dicInfoDt)

            '--------------------------------------------------------------------- Cálculo de aguinaldo
            'DIASAG - Días aguinaldo
            vars("_dias_aguinaldo") = sumaMonto(strReloj, "DIASAG", horasProC)
            vars("_dias_aguinaldo") += sumaMonto(strReloj, "DIASAG", ajustesProC)
            Me.puente(vars("_dias_aguinaldo"), "DIASAG", data, infoEmp, dicInfoDt)

            'PERAGI - Percepción aguinaldo
            If vars("_dias_aguinaldo") >= 0 Then
                vars("_aguinaldo") = Math.Round(_sactual * vars("_dias_aguinaldo"), 2)
                vars("_aguinaldo") += sumaMonto(strReloj, "PERAGI", ajustesProC)
                Me.puente(vars("_aguinaldo"), "PERAGI", data, infoEmp, dicInfoDt)
            End If

            '--------------------------------------------------------------------- Cálculo de percepciones exentas
            'DIADOM - Dias dominicales
            vars("_dias_prima_dominical") = sumaMonto(strReloj, "DIADOM", horasProC)
            vars("_dias_prima_dominical") += sumaMonto(strReloj, "DIADOM", ajustesProC)
            Me.puente(vars("_dias_prima_dominical"), "DIADOM", data, infoEmp, dicInfoDt)


            'FOX: CALCULO CORRESPONDIENTE A PRIMA DOMINICAL
            If vars("_dias_prima_dominical") > 0 Then : vars("_prima_dominical") = _sactual * 0.25 * vars("_dias_prima_dominical") : End If
            vars("_prima_dominical") += sumaMonto(strReloj, "PRIDOM", ajustesProC)
            Me.puente(vars("_prima_dominical"), "PRIDOM", data, infoEmp, dicInfoDt)

            'FOX: EXENTO POR DOMINGO TRABAJADO
            If vars("_prima_dominical") > 0 Then
                vars("_exento_dominical") = IIf(_uma >= vars("_prima_dominical"), vars("_prima_dominical"), _uma)
                Me.puente(vars("_exento_dominical"), "PEXDOM", data, infoEmp, dicInfoDt)
            End If

            'FOX: EXENTO POR PRIMA VACACIONAL
            If vars("_prima_vac") <> 0 Then
                Dim _tope_vac As Double = _uma * 15
                Dim privacExe = sumaMonto("reloj='" & strReloj & "' and ano='" & data("ano") & "'", "", dicInfoDt("dtPrimaVacDetalle"), 1)
                _tope_vac -= privacExe
                vars("_exento_prima_vac") = IIf(vars("_prima_vac") + vars("_ajuste_prima_vacacional") < _tope_vac,
                                                vars("_prima_vac") + vars("_ajuste_prima_vacacional"),
                                                _tope_vac)
            End If

            Me.puente(vars("_exento_prima_vac"), "PEXVAC", data, infoEmp, dicInfoDt)

            'FOX: EXENTO POR AGUINALDO
            Dim aExcent = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtAguiExcento"))
            vars("_30_minimos") = _uma * 30

            If aExcent.Rows.Count > 0 Then
                vars("_30_minimos") -= aExcent.Rows(0)("monto")
                vars("_30_minimos") = IIf(vars("_30_minimos") < 0, 0, vars("_30_minimos"))
            End If

            vars("_exento_aguinaldo") = IIf(vars("_30_minimos") >= vars("_aguinaldo"), vars("_aguinaldo"), vars("_30_minimos"))

            '-- SE HACE ESTA CONDICION SIEMPRE Y CUANDO NO SEA CALCULO DE AGUINALDO ANUAL -- 12 DIC 2023 -- ERNESTO
            If vars("_anticipo_aguinaldo") > 0 Then
                vars("_exento_aguinaldo") = IIf(vars("_exento_aguinaldo") < vars("_anticipo_aguinaldo"), 0, vars("_exento_aguinaldo") - vars("_anticipo_aguinaldo"))
            End If

            Me.puente(vars("_exento_aguinaldo"), "PEXAGI", data, infoEmp, dicInfoDt)

            '---------------------------------------------------------------------
            'PERGRA - Percepción gravable
            ' - Para operativos se suma bono de despensa
            vars("_percepcion_exenta") = vars("_exento_dominical") + vars("_exento_prima_vac") + vars("_exento_aguinaldo")
            vars("_percepcion_total") = Me.totPerc(data, infoEmp, Nothing, dicInfoDt)
            vars("_percepcion_gravable") = vars("_percepcion_total") - vars("_percepcion_exenta")
            vars("_percepcion_gravable") = IIf(vars("_percepcion_gravable") < 0, 0, vars("_percepcion_gravable"))
            Me.puente(vars("_percepcion_gravable"), "PERGRA", data, infoEmp, dicInfoDt)

            'DIASPA - Días pagados
            vars("_dias_pagados") = Convert.ToInt32((vars("_percepcion_normal") + vars("_septimo_dia") + vars("_vacaciones")) / _sactual)
            Me.puente(vars("_dias_pagados"), "DIASPA", data, infoEmp, dicInfoDt)

            '--------------------------------------------------------------------- Cálculo de liquidación fondo de ahorro
            If _finiquito Then
                vars("_fahorro") = (Me._globalVars("_acum_base_pago") - IIf(_finiquito, vars("_vacaciones"), 0)) * vars("_por_fah") / 100
                vars("_tope_ahorro") = _uma * vars("_dias_pagados") * 1.3

                If vars("_fahorro") > vars("_tope_ahorro") Then : vars("_fahorro") = vars("_tope_ahorro") : End If

                vars("_fahorro") = IIf(vars("_fahorro") < 0, 0, vars("_fahorro"))
                vars("_fahorro") += sumaMonto(strReloj, "APOFAH", ajustesProC)
                Me.puente(vars("_fahorro"), "APOFAH", data, infoEmp, dicInfoDt)
                Me.puente(vars("_fahorro"), "APOCIA", data, infoEmp, dicInfoDt)

                'LIFAHE - Liquidación de fondo de ahorro de empleado
                vars("_liq_fa_empleado") = sumaMonto(strReloj, "LIFAHE", ajustesProC) + IIf(_finiquito, vars("_fahorro"), 0)
                Me.puente(vars("_liq_fa_empleado"), "LIFAHE", data, infoEmp, dicInfoDt)

                'LIFAHC - Liquidación de fondo de ahorro de empresa
                vars("_liq_fa_empresa") = sumaMonto(strReloj, "LIFAHC", ajustesProC) + IIf(_finiquito, vars("_fahorro"), 0)
                Me.puente(vars("_liq_fa_empresa"), "LIFAHC", data, infoEmp, dicInfoDt)
            End If


            '********************************************************************* DEDUCCIONES ********************************************************************
            '--------------------------------------------------------------------- Cálculo de IMSS
            If _integrado <> _minimo_df Then
                vars("_dias_imss") = vars("_dias_pagados")

                'DIIMSS - Días IMSS
                If ajustesProC.Select("concepto='DIIMSS'").Count > 0 Then vars("_dias_imss") = sumaMonto(strReloj, "DIIMSS", ajustesProC)
                Me.puente(vars("_dias_imss"), "DIIMSS", data, infoEmp, dicInfoDt)

                'Enfermedad y Maternidad
                vars("_enf") = _tope25 * vars("_dias_imss") * _fac_enfermedad_mat

                'Invalidez y vida
                vars("_inv") = _tope25 * vars("_dias_imss") * _fac_invalidez_vida

                'Excedente 3 min
                vars("_excedente") = (_tope25 - (_uma * 3)) * vars("_dias_imss") * 0.004
                vars("_imss") = vars("_enf") + vars("_inv") + IIf(vars("_excedente") > 0, vars("_excedente"), 0)
            End If

            'IMSS - IMSS
            Dim monto = 0D
            monto += vars("_imss") + sumaMonto(strReloj, "IMSS", ajustesProC)
            Me.puente(monto, "IMSS", data, infoEmp, dicInfoDt)

            '--------------------------------------------------------------------- Cálculo de ISR
            If _tipo = "A" Then
                If vars("_dias_pagados") > 0 Then
                    vars("_gravado_diario") = vars("_percepcion_gravable") / vars("_dias_pagados")
                    vars("_gravado_mensual") = vars("_gravado_diario") * 30.4
                    vars("_gravado_semanal") = vars("_gravado_diario") * 7
                    vars("_gravado_quincenal") = vars("_gravado_diario") * 15
                End If

                If vars("_percepcion_gravable") > 0 Then
                    vars("_ispt_temp") = Me.ispt2008(data, infoEmp, vars("_percepcion_gravable"), "Impuesto", dicInfoDt)
                    vars("_sub_empleo_temp") = Me.ispt2008(data, infoEmp, vars("_percepcion_gravable"), "SubEmpleo", dicInfoDt)
                End If

                'FOX: Para que sea una deduccion negativa
                vars("_sub_empleo_temp") *= -1
                vars("_ispt_temp") += sumaMonto(strReloj, "ISPT", ajustesProC)
                vars("_sub_empleo_temp") -= sumaMonto(strReloj, "CREFIS", ajustesProC)

                Me.puente(vars("_ispt_temp"), "ISPT", data, infoEmp, dicInfoDt)
                Me.puente(vars("_sub_empleo_temp"), "CREFIS", data, infoEmp, dicInfoDt)

                'vars("_crepag_temp") = IIf(vars("_ispt_temp") < (vars("_sub_empleo_temp") * -1), vars("_sub_empleo_temp") + vars("_ispt_temp"), 0)
                'vars("_crepag_temp") += sumaMonto(strReloj, "CREPAG", ajustesProC)
                'Me.puente(vars("_crepag_temp") * -1, "CREPAG", data, infoEmp, dicInfoDt)

                vars("_isptre_temp") = IIf(vars("_ispt_temp") > vars("_sub_empleo_temp") * -1, vars("_sub_empleo_temp") + vars("_ispt_temp"), 0)
                vars("_isptre_temp") += sumaMonto(strReloj, "ISPTRE", ajustesProC)
                Me.puente(vars("_isptre_temp"), "ISPTRE", data, infoEmp, dicInfoDt)
            Else
                vars("_isptre_temp") = vars("_percepcion_total") * 0.075
                vars("_isptre_temp") += sumaMonto(strReloj, "ISPTRE", ajustesProC)
                Me.puente(vars("_isptre_temp"), "ISPTRE", data, infoEmp, dicInfoDt)
            End If

            '--------------------------------------------------------------------- Cálculo de pensiones alimenticias
            Dim pensiones = dicInfoDt("dtPensionesAlim").Select("reloj='" & strReloj & "'")
            Dim dtPension = Nothing

            If pensiones.Count > 0 Then
                dtPension = pensiones.CopyToDataTable.Copy

                For Each pens In dtPension.Rows
                    Dim _per = Me.totPerc(data, infoEmp, Nothing, dicInfoDt)
                    Dim _ded = Me.totDed(data, infoEmp, Nothing, dicInfoDt)
                    Dim tipoPen = pens("tipo_pen").ToString.Trim
                    Dim numPension = ""

                    If tipoPen <> "" Then
                        tipoPen = Convert.ToInt32(pens("tipo_pen").ToString.Trim)
                        numPension = Convert.ToInt32(pens("num_pensio").ToString.Trim)

                        Select Case tipoPen
                            Case 1
                                vars("_base_pension") = _per - _ded - vars("_infonavit") - vars("_liq_fa_empleado") -
                                                        vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 2
                                vars("_base_pension") = _per - vars("_descuentos_dias_total") - vars("_liq_fa_empleado") -
                                                        vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 3
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_isr_cargo") -
                                                        vars("_descuentos_dias_total") - vars("_liq_fa_empleado") - vars("_devolucion_tienda") -
                                                        vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 4
                                vars("_base_pension") = _per - vars("_percepcion_doble") - vars("_percepcion_triple") - vars("_ispt_temp") -
                                                        vars("_imss") - vars("_imss_vac") - vars("_isr_cargo") - vars("_descuentos_dias_total") -
                                                        vars("_liq_fa_empleado") - vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 5
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_fahorro") -
                                                        vars("_isr_cargo") - vars("_descuentos_dias_total") - vars("_liq_fa_empleado") -
                                                        vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 6
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_infonavit") -
                                                        vars("_fonacot") - vars("_isr_cargo") - vars("_descuentos_dias_total") -
                                                        vars("_liq_fa_empleado") - vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 7
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_infonavit") -
                                                        vars("_isr_cargo") - vars("_descuentos_dias_total") - vars("_liq_fa_empleado") -
                                                        vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 8
                                vars("_base_pension") = vars("_vacaciones") + vars("_prima_vac") + vars("_aguinaldo") + vars("_sub_empleo_temp") -
                                                        vars("_isptre_temp") - vars("_isr_cargo") - vars("_descuentos_dias_total") -
                                                        vars("_liq_fa_empleado") - vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 9
                                vars("_pension_alimenticia") = pens("fijo")
                            Case 10
                                vars("_base_pension") = (_per - vars("_descuentos_dias_total")) - (_uma * 7)
                            Case 11
                                vars("_base_pension") = _per - vars("_imss") - vars("_isptre_temp") - vars("_isr_cargo") - vars("_descuentos_dias_total") -
                                                        vars("_liq_fa_empleado") - vars("_devolucion_tienda") - vars("_ajuste_vacaciones") - vars("_ajuste_sueldo")
                            Case 12
                                vars("_base_pension") = (_per - vars("_descuentos_dias_total")) - (_uma * 7)
                            Case 13 '-- 14 dic 2023
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_isr_cargo") -
                                                        vars("_descuentos_dias_total") - vars("_liq_fa_empleado") - vars("_devolucion_tienda") -
                                                        vars("_ajuste_vacaciones") - vars("_ajuste_sueldo") - vars("_fahorro")
                            Case 14 '-- 14 dic 2023
                                vars("_base_pension") = _per - vars("_isptre_temp") - vars("_imss") - vars("_imss_vac") - vars("_isr_cargo") -
                                                        vars("_descuentos_dias_total") - vars("_liq_fa_empleado") - vars("_devolucion_tienda") -
                                                        vars("_ajuste_vacaciones") - vars("_ajuste_sueldo") - (_uma * 7)
                        End Select

                        '-- Restar a la base de pension el anticipo de aguinaldo -- Com. Ivette -- Ernesto -- 31 agosto 2023
                        vars("_base_pension") -= vars("_anticipo_aguinaldo")
                        vars("_base_pension") -= vars("_devolucion_infonavit")

                        If tipoPen <> 9 Then vars("_pension_alimenticia") = vars("_base_pension") * pens("porcentaje") / 100
                        If tipoPen = 11 Then vars("_pension_alimenticia") = (vars("_base_pension") - (_uma * 7)) * 0.3

                        vars("_pension_alimenticia") += sumaMonto(strReloj, "PENAL" & tipoPen.ToString, ajustesProC)
                        If vars("_pension_alimenticia") < 0 Then : vars("_pension_alimenticia") = 0D : End If

                        ''-- Guardar la base de la pension como concepto informativo -- Ernesto -- 10 Julio 2023
                        'Me.puente(vars("_base_pension"), "BASEPE", data, infoEmp, dicInfoDt)

                        Select Case tipoPen
                            Case 9 : Me.puente(vars("_pension_alimenticia"), "PENACF", data, infoEmp, dicInfoDt)
                            Case 10 : Me.puente(vars("_pension_alimenticia"), "DEDJUZ", data, infoEmp, dicInfoDt)
                            Case 11 : Me.puente(vars("_pension_alimenticia"), "DEDJUZ", data, infoEmp, dicInfoDt)
                            Case 12 : Me.puente(vars("_pension_alimenticia"), "DEDJUZ", data, infoEmp, dicInfoDt)
                            Case 14 : Me.puente(vars("_pension_alimenticia"), "DEDJUZ", data, infoEmp, dicInfoDt)
                            Case Else : Me.puente(vars("_pension_alimenticia"), "PENALI", data, infoEmp, dicInfoDt)
                        End Select

                        Me.puente(vars("_pension_alimenticia"), "PENAL" & numPension, data, infoEmp, dicInfoDt)
                        Me.puente(pens("porcentaje"), "PORPEN", data, infoEmp, dicInfoDt)
                    End If
                Next
            End If

            '--------------------------------------------------------------------- Cálculo de INFONAVIT
            If infoEmp("infonavit_credito").ToString.Count > 0 And
                infoEmp("cuota_credito").ToString.Count > 0 And
                infoEmp("tipo_credito").ToString.Count > 0 Then

                vars("_dias_infonavit") = vars("_dias_pagados")

                If Not IsDBNull(infoEmp("inicio_credito")) Then
                    If Convert.ToDateTime(infoEmp("inicio_credito")) >= Convert.ToDateTime(period("fecha_ini").ToString) And
                        Convert.ToDateTime(infoEmp("inicio_credito")) <= Convert.ToDateTime(period("fecha_fin").ToString) Then
                        vars("_dias_infonavit") = (Convert.ToDateTime(period("fecha_fin").ToString) - Convert.ToDateTime(infoEmp("inicio_credito").ToString)).TotalDays + 1
                    End If
                End If

                Try
                    If Convert.ToDateTime(infoEmp("inicio_credito")) >= Convert.ToDateTime(period("fecha_fin").ToString) Then
                        infoEmp("cobro_segviv") = False
                        GoTo NoInfonavit
                    End If
                Catch ex As Exception : End Try

                Select Case Convert.ToInt32(infoEmp("tipo_credito").ToString.Trim)
                    Case 1
                        vars("_infonavit") = _tope25 * (infoEmp("cuota_credito") / 100) * 7
                    Case 2
                        vars("_infonavit") = infoEmp("cuota_credito") * 2 / _dias_bim * 7
                    Case 3
                        vars("_cuota_semanal") = infoEmp("cuota_credito") * _infonavit_cias * 2 / _dias_bim * 7
                        vars("_infonavit") = vars("_cuota_semanal")
                End Select

                vars("_infonavit") = vars("_infonavit") / 7 * vars("_dias_infonavit")
                If vars("_infonavit") < 0 Then : vars("_infonavit") = 0D : End If

            Else
                infoEmp("cobro_segviv") = False
            End If

NoInfonavit:
            vars("_adeudo_infonavit_extra") = sumaMonto(strReloj, "ADEINY", ajustesProC)
            vars("_infonavit") += vars("_adeudo_infonavit_extra")
            Me.puente(vars("_adeudo_infonavit_extra"), "ADEINY", data, infoEmp, dicInfoDt)

            Select Case Convert.ToInt32(IIf(infoEmp("tipo_credito").ToString.Trim.Count > 0, infoEmp("tipo_credito").ToString.Trim, 0))
                Case 1
                    vars("_infonavit") += sumaMonto(strReloj, "DESINP", ajustesProC)
                    Me.puente(vars("_infonavit"), "DESINP", data, infoEmp, dicInfoDt)
                Case 2
                    vars("_infonavit") += sumaMonto(strReloj, "DESINF", ajustesProC)
                    Me.puente(vars("_infonavit"), "DESINF", data, infoEmp, dicInfoDt)
                Case 3
                    vars("_infonavit") += sumaMonto(strReloj, "DESINV", ajustesProC)
                    Me.puente(vars("_infonavit"), "DESINV", data, infoEmp, dicInfoDt)
            End Select

            'SEGVIV - Seguro de vivienda
            If infoEmp("cobro_segviv") And vars("_percepcion_total") > 0 And vars("_infonavit") > 0 Then : vars("_seguro_vivienda") = _seguro_vivienda : End If
            vars("_seguro_vivienda") += sumaMonto(strReloj, "SEGVIV", ajustesProC)
            Me.puente(vars("_seguro_vivienda"), "SEGVIV", data, infoEmp, dicInfoDt)
            '---------------------------------------------------------------------

            '********************************************************************* CALCULO NETO ********************************************************************
            'TOTPER - Percepción total
            vars("_percepcion_total") = Me.totPerc(data, infoEmp, Nothing, dicInfoDt)
            Me.puente(vars("_percepcion_total"), "TOTPER", data, infoEmp, dicInfoDt)

            'TOTDED - Deducción total
            vars("_deduccion_total") = Me.totDed(data, infoEmp, Nothing, dicInfoDt)

            'AJUSTE AL SUBSIDIO CAUSADO
            vars("_nod107") = sumaMonto(strReloj, "NOD107", ajustesProC)
            Me.puente(vars("_nod107"), "NOD107", data, infoEmp, dicInfoDt)

            vars("_nod002") = sumaMonto(strReloj, "NOD002", ajustesProC)
            Me.puente(vars("_nod002"), "NOD002", data, infoEmp, dicInfoDt)

            vars("_nop007") = sumaMonto(strReloj, "NOP007", ajustesProC)
            Me.puente(vars("_nop007"), "NOP007", data, infoEmp, dicInfoDt)

            vars("_nod071") = sumaMonto(strReloj, "NOD071", ajustesProC)
            Me.puente(vars("_nod071"), "NOD071", data, infoEmp, dicInfoDt)

            vars("_nop008") = sumaMonto(strReloj, "NOP008", ajustesProC)
            Me.puente(vars("_nop008"), "NOP008", data, infoEmp, dicInfoDt)

            vars("_deduccion_total") += vars("_nod107")

            Me.puente(vars("_deduccion_total"), "TOTDED", data, infoEmp, dicInfoDt)

            'NETO - Neto
            vars("_neto") = vars("_percepcion_total") - vars("_deduccion_total")
            vars("_neto") = IIf(vars("_neto") < 0, 0, vars("_neto"))
            Me.puente(vars("_neto"), "NETO", data, infoEmp, dicInfoDt)

        Catch ex As Exception
            Me.addLog("Error en el proceso de cálculo normal reloj [" & strReloj & "]: " & ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_calculo", ex.HResult, ex.Message)
        End Try

    End Sub

    Public Sub calculoBondes(element As DataRow, data As Dictionary(Of String, String), Optional cia As String = "610",
                          Optional ByRef dicInfoDt As Dictionary(Of String, DataTable) = Nothing)

        '-- Si es aguinaldo anual, no realizar cálculo de bono -- Ernesto -- 29 nov 2023
        If Me._options("aguinaldo_anual") Then Exit Sub

        Dim strReloj = element("reloj").Trim

        Try
            '== Consulta a movimientosPro [evitar conceptos repetidos]
            Dim dtMovPro = dtMovsProLocal

            'Buscando datos de la compañia
            Dim ciaDb As DataTable = infoTabla("cod_comp='" & cia & "'", dicInfoDt("dtCias"))

            'FOX: En julio 2019 Bety nos pidio que no quitemos a los finiquitos especiales, solo excluiremos los que en realidad estan dados de baja y ya se les calculo su finiquito IVO
            'Dim elements = (From i In Me._nominaPro.Rows Where i("baja").ToString.Count = 0 And i("procesar") And {"610", "700"}.Contains(i("cod_comp").ToString.Trim)).ToList

            'FOX: La base para calculo siempre va a ser de 30 dias IVO 25/feb/19
            Dim vars As New Dictionary(Of String, Decimal) From {{"_dias_despensa", 30},
                                                                 {"_sueldo_cobertura", 0},
                                                                 {"_sueldo_despensa", 0},
                                                                 {"_monto_despensa", 0},
                                                                 {"_dias_tope", 0},
                                                                 {"_bonpal_1", 0},
                                                                 {"_bonpal_2", 0},
                                                                 {"_bonpal_3", 0}}

            Dim ajustes As DataTable = infoTabla("reloj = '" & element("reloj").Trim & "'", dicInfoDt("dtAjustesPro"))

            'FOX: El 23 de abril 2018 Bety Licea me dio la instruccion de no incluir la compensacion por tunel, solo la temporal IVO 
            Dim _sdoCobert As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtSdoCobertura"))

            'FOX: store iif(seek(nomina_pro.reloj,"sdo_cobertura","RELOJ_ACTI") and alltrim(sdo_cobertura.tipo_comp)="TEMPORAL" and nomina_pro.cod_tipo="O",iif(sdo_cobertura.sdo_cobert>0,sdo_cobertura.sdo_cobert-nomina_pro.sactual,sdo_cobertura.comp_diaria),0)  to _sueldo_cobertura
            If _sdoCobert.Rows.Count > 0 Then
                If _sdoCobert.Rows(0)("tipo_comp").ToString.Trim = "TEMPORAL" And element("cod_tipo").ToString.Trim = "O" Then

                    '-- Tomar en cuenta el porcentaje de las compensaciones del empleado -- Ernesto -- 29 septiembre 2023
                    Dim esPorcentaje = If(IsDBNull(_sdoCobert.Rows(0)("porcentaje")), False, _sdoCobert.Rows(0)("porcentaje") > 0)

                    If _sdoCobert.Rows(0)("sdo_cobert") = 0 And esPorcentaje Then
                        vars("_sueldo_cobertura") = element("sactual") * (_sdoCobert.Rows(0)("porcentaje") / 100)
                    Else
                        vars("_sueldo_cobertura") = IIf(_sdoCobert.Rows(0)("sdo_cobert") > 0,
                                                                            _sdoCobert.Rows(0)("sdo_cobert") - element("sactual"),
                                                                            _sdoCobert.Rows(0)("comp_diaria"))
                    End If
                End If
            End If

            'FOX: store iif(_incluir_cobertura,_sueldo_cobertura,0) to _sueldo_cobertura

            If vars("_sueldo_cobertura") < 0 Then
                vars("_sueldo_cobertura") = 0D
                Me.addLog("Ojo, el empleado " + element("reloj") + " tiene un sueldo cobertura menor a su sueldo actual")
            End If
            vars("_sueldo_despensa") = element("sactual") + vars("_sueldo_cobertura")                                                                       'FOX: store nomina_pro.sactual+_sueldo_cobertura to _sueldo_despensa

            Dim periodos As DataTable = infoTabla("ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "'", dicInfoDt("dtPeriodos"))
            If periodos.Rows.Count > 0 Then
                If Not IsDBNull(periodos.Rows(0)("bondes_ini")) And Not IsDBNull(periodos.Rows(0)("bondes_fin")) Then
                    If Convert.ToDateTime(element("alta")) >= Convert.ToDateTime(periodos.Rows(0)("bondes_ini")) And Convert.ToDateTime(element("alta")) <= Convert.ToDateTime(periodos.Rows(0)("bondes_fin")) Then                                 'FOX: If between(nomina_pro.alta, _bondes_ini, _bondes_fin) Then
                        vars("_dias_despensa") = 30 - Convert.ToDateTime(element("alta").ToString).Day + 1                                                        'FOX:     store 30-day(nomina_pro.alta)+1 to _dias_despensa
                    End If
                End If
            End If

            If element("baja").ToString.Count > 0 Then
                Try
                    If Convert.ToDateTime(element("alta")) >= Convert.ToDateTime(periodos.Rows(0)("bondes_ini")) Then
                        vars("_dias_despensa") = Convert.ToDateTime(element("baja").ToString).Day - Convert.ToDateTime(element("alta").ToString).Day + 1        'FOX:       store day(nomina_pro.baja)-day(nomina_pro.alta)+1 to _dias_despensa
                    Else
                        vars("_dias_despensa") = Convert.ToDateTime(element("baja").ToString).Day                                                               'FOX:       store day(nomina_pro.baja) to _dias_despensa
                    End If
                Catch ex As Exception
                End Try
            End If

            vars("_dias_despensa") = IIf(vars("_dias_despensa") > 30, 30, vars("_dias_despensa"))                                                           'FOX: store iif(_dias_despensa>30, 30, _dias_despensa) to _dias_despensa
            vars("_dias_despensa") += (From i In ajustes Where i("concepto") = "DIDESP" Select Decimal.Parse(i("monto").ToString)).Sum()                    'FOX: store _dias_despensa+iif(seek(_ano+_periodo+nomina_pro.reloj+"DIDESP","ajustes_pro","unico"),ajustes_pro.monto,0) to _dias_despensa

            If periodos.Rows.Count > 0 Then
                If Not IsDBNull(periodos.Rows(0)("bondes_corte_ant")) And Not IsDBNull(periodos.Rows(0)("bondes_ini")) Then
                    If Convert.ToDateTime(element("alta")) >= Convert.ToDateTime(periodos.Rows(0)("bondes_corte_ant")) And Convert.ToDateTime(element("alta")) <= Convert.ToDateTime(periodos.Rows(0)("bondes_ini").ToString).AddDays(-1) And Convert.ToDateTime(element("alta")).Day <= 30 Then
                        If Convert.ToDateTime(element("alta")).Month = 2 Then
                            Dim _ultimo_dia_febrero = DateTime.ParseExact("0103" & Convert.ToDateTime(periodos.Rows(0)("bondes_ini").ToString).Year, "ddMMyyyy", CultureInfo.CurrentCulture).AddDays(-1).Day    'FOX:         store day(ctod(str(year(_bondes_ini))+".03.01")-1) to _ultimo_dia_febrero
                            vars("_dias_despensa") += _ultimo_dia_febrero - Convert.ToDateTime(element("alta")).Day + 1                                             'FOX:         _dias_despensa=_dias_despensa+ (_ultimo_dia_febrero-day(nomina_pro.alta)+1)  && El 25 de marzo 2019 Bety nos indico que el calculo de dias extras de personas con alta de febrero debe ser basado en los dias que tenga febrero ese año IVO
                        Else
                            vars("_dias_despensa") += 30 - Convert.ToDateTime(element("alta")).Day + 1                                                              'FOX:         _dias_despensa = _dias_despensa + (30 - Day(nomina_pro.alta) + 1)
                        End If
                    End If
                End If
            End If

            vars("_porcentaje_despensa") = IIf(element("cod_tipo").ToString.Trim = "O", 10.5, 10)                                                                               'FOX: store iif(nomina_pro.cod_tipo="O",10.5,10) to _porcentaje_despensa && El 20 de julio del 2020 cambió el porcentaje de despensa del 10 al 10.5%
            vars("_monto_despensa") = vars("_dias_despensa") * vars("_sueldo_despensa") * Me._globalVars("_porcentaje_despensa") / 100                             'FOX: store _dias_despensa*_sueldo_despensa*_porcentaje_despensa/100 to _monto_despensa
            vars("_dias_tope") = IIf(vars("_dias_despensa") = 30, 30.4, vars("_dias_despensa"))                                                          'FOX: store iif(_dias_despensa=30,30.4,_dias_despensa) to _dias_tope

            'FOX: Voy a tomar el monto de bondes de ajustes_pro como el monto total a pagar IVO 2021-10-21
            Dim val = (From i In ajustes.Rows Where i("concepto") = "BONDES" Select Decimal.Parse(i("monto").ToString)).Sum()
            vars("_monto_despensa") = IIf(val > 0, val, vars("_monto_despensa"))                                                                            'FOX: store iif(seek(_ano+_periodo+nomina_pro.reloj+"BONDES","ajustes_pro","unico"),ajustes_pro.monto,_monto_despensa) to _monto_despensa

            vars("_monto_despensa") = IIf(vars("_monto_despensa") >= ciaDb.Rows(0)("uma") * vars("_dias_tope"), ciaDb.Rows(0)("uma") * vars("_dias_tope"), vars("_monto_despensa"))          'FOX: store iif(_monto_despensa>=_uma* _dias_tope,_uma* _dias_tope,_monto_despensa) to _monto_despensa

            vars("_bonpal_1") = 0D : vars("_bonpal_2") = 0D : vars("_bonpal_3") = 0D

            Dim pensiAlim As DataTable = infoTabla("reloj='" & strReloj & "'", dicInfoDt("dtPensionesAlim"))
            For Each pa In pensiAlim.Select("", "num_pensio asc")
                Dim mercantil = IsDBNull(pa("mercantil"))
                mercantil = If(mercantil, 0, pa("mercantil"))

                If Convert.ToInt32(pa("tipo_pen")) <> 9 And Not strBool.getValue(mercantil) Then
                    If vars("_bonpal_1") = 0 Then : vars("_bonpal_1") = vars("_monto_despensa") * pa("porcentaje") / 100
                    ElseIf vars("_bonpal_1") > 0 And vars("_bonpal_2") = 0 Then : vars("_bonpal_2") = vars("_monto_despensa") * pa("porcentaje") / 100
                    ElseIf vars("_bonpal_2") > 0 And vars("_bonpal_3") = 0 Then : vars("_bonpal_3") = vars("_monto_despensa") * pa("porcentaje") / 100 : End If
                Else : vars("_bonpal_1") = 0 : End If
            Next

            If dtMovPro.Select("concepto='DIDESP' and monto='" & vars("_dias_despensa") & "'").Count = 0 Then Me.puente(vars("_dias_despensa"), "DIDESP", data, element, dicInfoDt) 'FOX: do puente with _reloj,_dias_despensa,_tipo_nomina,'DIDESP'
            If dtMovPro.Select("concepto='PORDES' and monto='" & Me._globalVars("_porcentaje_despensa") & "'").Count = 0 Then Me.puente(Me._globalVars("_porcentaje_despensa"), "PORDES", data, element, dicInfoDt) 'FOX: do puente with _reloj,_porcentaje_despensa,_tipo_nomina,'PORDES'
            If dtMovPro.Select("concepto='BONDEX' and monto='" & vars("_monto_despensa") & "'").Count = 0 Then Me.puente(vars("_monto_despensa"), "BONDEX", data, element, dicInfoDt) 'FOX: do puente with _reloj,_monto_despensa,_tipo_nomina,'BONDEX'
            If dtMovPro.Select("concepto='BONDES' and monto='" & vars("_monto_despensa") - vars("_bonpal_1") - vars("_bonpal_2") - vars("_bonpal_3") & "'").Count = 0 Then Me.puente(vars("_monto_despensa") - vars("_bonpal_1") - vars("_bonpal_2") - vars("_bonpal_3"), "BONDES", data, element, dicInfoDt) 'FOX: do puente with _reloj,_monto_despensa-_bonpal_1-_bonpal_2-_bonpal_3,_tipo_nomina,'BONDES'
            If dtMovPro.Select("concepto='BONPA1' and monto='" & vars("_bonpal_1") & "'").Count = 0 Then Me.puente(vars("_bonpal_1"), "BONPA1", data, element, dicInfoDt) 'FOX: do puente with _reloj,_bonpal_1,_tipo_nomina,'BONPA1'
            If dtMovPro.Select("concepto='BONPA2' and monto='" & vars("_bonpal_2") & "'").Count = 0 Then Me.puente(vars("_bonpal_2"), "BONPA2", data, element, dicInfoDt) 'FOX: do puente with _reloj,_bonpal_2,_tipo_nomina,'BONPA2'
            If dtMovPro.Select("concepto='BONPA3' and monto='" & vars("_bonpal_3") & "'").Count = 0 Then Me.puente(vars("_bonpal_3"), "BONPA3", data, element, dicInfoDt) 'FOX: do puente with _reloj,_bonpal_3,_tipo_nomina,'BONPA3'	

        Catch ex As Exception
            'MessageBox.Show("Ha ocurrido un error durante el proceso de cálculo [bondes], por favor, revise el log y/o notifique al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.addLog("Error en el proceso de cálculo [bondes] reloj [" & strReloj & "]: " & ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_calculoBondes", ex.HResult, ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 'Función Ajuste al subsidio mensual  2022-03-20 -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AjusteSubsidioMensual(dirAjusteSubsidio As String, ByRef data As Dictionary(Of String, String), Optional calculoIndividual As List(Of String) = Nothing)
        Try
            '--- Errores
            '- 0 = No hay ruta para el archivo
            '- 1 = Sin registros en movimientosPro

            If MessageBox.Show("Al momento de realizar el cálculo de ajuste al subsidio se eliminarán los registros de la tabla 'ajustesSubsidio' " &
                               "asi como los que se encuentren en incorporados en miscelaneos. " &
                               "¿Desea continuar?", "Cálculo ajuste subsidio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

                Dim lstError As New List(Of String)

                '--- Verficar que exista información en movimientosPro
                Dim dtRegmovPro = Sqlite.getInstance.sqliteExecute("select distinct reloj from movimientosPro")
                lstError.Add(IIf(dirAjusteSubsidio = "", "No se indicó una ruta válida para el reporte.", ""))
                lstError.Add(IIf(dtRegmovPro.Rows.Count = 0, "No hay movimientos del proceso de cálculo." &
                                 "Por favor, verifique haber realizado el proceso de cálculo o que existan registros en movimientos si se cargo una versión del historial.", ""))

                '--- Validaciones: Si hay ruta y registros en movimientosPro
                If lstError(0) = "" And lstError(1) = "" Then

                    '== Relojes para cálculo individual
                    Dim strFiltroRelojes = {"", ""}

                    '---- Se elimina lo que exista en la tabla de ajuste al subsidio y los que esten en ajustesPro
                    Sqlite.getInstance.sqliteExecute("DELETE FROM ajustesSubsidio " & strFiltroRelojes(0))
                    Sqlite.getInstance.sqliteExecute("DELETE FROM ajustesPro WHERE origen='AjusteSubsidioMensual' " & strFiltroRelojes(1))

                    '---Mostrar Progress
                    If Not Me.BgWorker Is Nothing Then : data("etapa") = "Inicializando cálculo ajuste al subsidio" : Me.BgWorker.ReportProgress(0) : End If

                    '-----Variables generales
                    Dim counter = 0
                    Dim nombreMes As String = "", anio As String = "", nombreTipoPer As String = "Hourly", num_mes As String = "", cod_tipo As String = "", per_actual As String = ""
                    Dim fecha_ini As String = "", fecha_fin As String = "", totalPeriodos As Integer = 0

                    '----- Cursores generales
                    '== Solicitud Ivette. No tomar en cuenta empleados administrativos [28 abril 2023] - Ernesto
                    Dim dtNominaPro As DataTable = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro WHERE cod_tipo ='A' and finiquito_esp='False' " & strFiltroRelojes(1)) ' Se toma la nomina actual y de aqui se toma el anio, periodo actual y el num del mes
                    Dim dtPeriodosMes As New DataTable
                    Dim noEmpleados = dtNominaPro.Rows.Count

                    '----- Tabla de 'ispt_pro_mensual'
                    Dim dtIsptProMensual = sqlExecute("SELECT * FROM NOMINA.dbo.ispt_pro_mensual")

                    '----- Obtener el nombre del mes, anio y nombre del tipo de periodo NOTA: Va a tomar el primero que encuentre, hay que ver con yordan si va a tener diferentes tipos de periodo en nomina_pro, meses y / o periodos
                    Try : anio = dtNominaPro.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try  ' Por lo ptonto se dejan fijos estos valores
                    Try : num_mes = dtNominaPro.Rows(0).Item("mes").ToString.Trim : Catch ex As Exception : num_mes = "" : End Try ' Por lo ptonto se dejan fijos estos valores
                    Try : cod_tipo = dtNominaPro.Rows(0).Item("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo = "" : End Try ' Por lo ptonto se dejan fijos estos valores
                    Try : per_actual = dtNominaPro.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per_actual = "" : End Try ' Por lo ptonto se dejan fijos estos valores
                    nombreMes = MesLetra(num_mes.Substring(4, 2))

                    Select Case cod_tipo
                        Case "O"
                            nombreTipoPer = "Hourly"
                        Case "A"
                            nombreTipoPer = "Salary"
                    End Select

                    '---- Obtener todos los periodos que entran a juego en el cálculo del ajuste al subsidio, incluyendo el que esta actualmente en nomina pro, estatus_nomina=2 significa que ya está asentada
                    dtPeriodosMes = sqlExecute("select * from " & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where mes_acumulado='" & num_mes & "' order by periodo asc", "TA")
                    totalPeriodos = dtPeriodosMes.Rows.Count  ' Total de periodos del mes

                    '--- Obtener fecha inicio y fecha fin
                    Dim dtFecIni As DataTable = sqlExecute("select MIN(fecha_ini) as fecha_ini from TA.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                                           " where mes_acumulado='" & num_mes & "' and isnull(periodo_especial,0)=0", "TA")
                    Dim dtFecFin As DataTable = sqlExecute("select MAX(fecha_fin) as fecha_fin from TA.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                                           " where mes_acumulado='" & num_mes & "' and isnull(periodo_especial,0)=0", "TA")

                    Try : fecha_ini = FechaSQL(dtFecIni.Rows(0).Item("fecha_ini").ToString.Trim) : Catch ex As Exception : fecha_ini = "" : End Try
                    Try : fecha_fin = FechaSQL(dtFecFin.Rows(0).Item("fecha_fin").ToString.Trim) : Catch ex As Exception : fecha_fin = "" : End Try

                    '--- Si no hay información en la tabla, no se debe proceder
                    If dtIsptProMensual.Rows.Count = 0 Then
                        MessageBox.Show("No existe información en la tabla para los subsidios e impuesto mensuales, Por favor, contacte al administrador del sistema",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim File = New FileInfo(DireccionReportes & "Plantilla Ajuste Subsidio Mensual.xlsx")
                    Using package As New ExcelPackage(File)

                        Dim workSheet As ExcelWorksheet = package.Workbook.Worksheets("Resumen")

                        '************************************************************************************************************************************************************
                        '*********************************************************ENCABEZADOS PRINCIPALES ***************************************************************************
                        '*************************************************************************************************************************************************************

                        workSheet.Cells("A2").Value = "Ajuste al subsidio " & nombreMes & " " & anio & " - " & nombreTipoPer
                        workSheet.Cells("F1").Value = fecha_ini
                        workSheet.Cells("H1").Value = fecha_fin

                        '************************************************************************************************************************************************************
                        '*********************************************************ENCABEZADOS CON NUMERO DE PERIODO ******************************************************************
                        '*************************************************************************************************************************************************************

                        '------------------- (Columnas J - O) si incluye el periodo actual
                        Dim xp As Integer = 0, yp As Integer = 0
                        xp = 3
                        yp = 10

                        For Each rp1 As DataRow In dtPeriodosMes.Rows
                            Dim numper As String = ""
                            Try : numper = rp1("PERIODO").ToString.Trim : Catch ex As Exception : numper = "" : End Try
                            workSheet.Cells(xp, yp).Value = numper  ' Ir insertando en cada columna
                            yp = yp + 1
                        Next

                        '------------------- (Columnas R - V) NO incluye el periodo actual
                        Dim yp2 As Integer = 0
                        yp2 = 18
                        For Each rp2 As DataRow In dtPeriodosMes.Rows
                            Dim numper As String = ""
                            Try : numper = rp2("PERIODO").ToString.Trim : Catch ex As Exception : numper = "" : End Try
                            If (numper <> per_actual) Then
                                workSheet.Cells(xp, yp2).Value = numper  ' Ir insertando en cada columna
                                yp2 = yp2 + 1
                            End If
                        Next

                        '-------------------(Columna Y)
                        Dim yp3 As Integer = 25, leyendaperactual As String = ""
                        leyendaperactual = per_actual & " - Subsidio pagado antes del ajuste"
                        workSheet.Cells(2, yp3).Value = leyendaperactual

                        '------------------- (Columnas AC - AG) si incluye el periodo actual
                        Dim yp4 As Integer = 29
                        For Each rp4 As DataRow In dtPeriodosMes.Rows
                            Dim numper As String = ""
                            Try : numper = rp4("PERIODO").ToString.Trim : Catch ex As Exception : numper = "" : End Try
                            workSheet.Cells(xp, yp4).Value = numper  ' Ir insertando en cada columna
                            yp4 = yp4 + 1
                        Next

                        '------------------- (Columnas BC - BG) si incluye el periodo actual
                        Dim yp5 As Integer = 55
                        For Each rp5 As DataRow In dtPeriodosMes.Rows
                            Dim numper As String = ""
                            Try : numper = rp5("PERIODO").ToString.Trim : Catch ex As Exception : numper = "" : End Try
                            workSheet.Cells(xp, yp5).Value = numper  ' Ir insertando en cada columna
                            yp5 = yp5 + 1
                        Next

                        '------------------- (Columnas BK - BO) si incluye el periodo actual
                        Dim yp6 As Integer = 63
                        For Each rp6 As DataRow In dtPeriodosMes.Rows
                            Dim numper As String = ""
                            Try : numper = rp6("PERIODO").ToString.Trim : Catch ex As Exception : numper = "" : End Try
                            workSheet.Cells(xp, yp6).Value = numper  ' Ir insertando en cada columna
                            yp6 = yp6 + 1
                        Next


                        '************************************************************************************************************************************************************
                        '*********************************************************INFO DE CADA EMPLEADO *****************************************************************************
                        '*************************************************************************************************************************************************************

                        '=========================== Datatable que almacerá los valores que se ingresen en la plantilla de excel
                        Dim dtInfoValores As New DataTable
                        Dim sumaValores = 0.0

                        '-- Columnas info. empleado
                        dtInfoValores.Columns.Add("Reloj", GetType(System.String))
                        dtInfoValores.Columns.Add("Cod_tipo", GetType(System.String))
                        dtInfoValores.Columns.Add("Alta", GetType(System.DateTime))
                        dtInfoValores.Columns.Add("Baja", GetType(System.DateTime))

                        '-- Columnas cálculo días: Inicio, fin, días
                        dtInfoValores.Columns.Add("Inicio", GetType(System.DateTime))
                        dtInfoValores.Columns.Add("Fin", GetType(System.DateTime))
                        dtInfoValores.Columns.Add("Dias", GetType(System.Int32))

                        '-- Columnas subsidio causado: Periodos, aguinaldo y total
                        For Each drP As DataRow In dtPeriodosMes.Select("periodo_especial=0") : dtInfoValores.Columns.Add("SubCausado_" & drP("periodo").ToString.Trim, GetType(System.Double)) : Next
                        dtInfoValores.Columns.Add("SubCausado_aguinaldo", GetType(System.Double))
                        dtInfoValores.Columns.Add("SubCausado_total", GetType(System.Double))

                        '-- Columnas subsidio pagado: Periodos, aguinaldo y total
                        For Each drP As DataRow In dtPeriodosMes.Select("periodo_especial=0 and periodo<>'" & per_actual & "'") : dtInfoValores.Columns.Add("SubPagado_" & drP("periodo").ToString.Trim, GetType(System.Double)) : Next
                        dtInfoValores.Columns.Add("SubPagado_aguinaldo", GetType(System.Double))
                        dtInfoValores.Columns.Add("SubPagado_total", GetType(System.Double))

                        '-- Columa subsidio pagado antes de ajuste
                        dtInfoValores.Columns.Add("Subsidio_pagado_antes_ajuste", GetType(System.Double))

                        '-- Columnas percepción gravada: Periodos, aguinaldo, total y mensualizado a 30.4 días
                        For Each drP As DataRow In dtPeriodosMes.Rows : dtInfoValores.Columns.Add("PerGravada_" & drP("periodo").ToString.Trim, GetType(System.Double)) : Next
                        dtInfoValores.Columns.Add("PerGravada_aguinaldo", GetType(System.Double))
                        dtInfoValores.Columns.Add("PerGravada_total", GetType(System.Double))
                        dtInfoValores.Columns.Add("Mensualizado_30.4_dias", GetType(System.Double))

                        '-- Columnas subsidio mensual: Percepción gravada, limite inferior, subsidio, subsidio proporcional a los días
                        dtInfoValores.Columns.Add("SubMensual_pergravada", GetType(System.Double))
                        dtInfoValores.Columns.Add("SubMensual_limite_inferior", GetType(System.Double))
                        dtInfoValores.Columns.Add("SubMensual_subsidio", GetType(System.Double))
                        dtInfoValores.Columns.Add("SubMensual_sub_proporcional_dias", GetType(System.Double))
                        '--

                        dtInfoValores.Columns.Add("Diferencia_original_subsidio", GetType(System.Double))
                        dtInfoValores.Columns.Add("CREFIS_ajuste_subsidio_sem_actual", GetType(System.Double))
                        dtInfoValores.Columns.Add("Subsidio_mensual_ajuste_semana_actual", GetType(System.Double))
                        dtInfoValores.Columns.Add("Diferencia_subsidio_final", GetType(System.Double))

                        dtInfoValores.Columns.Add("NOD107_ajuste_subsidio", GetType(System.Double))
                        dtInfoValores.Columns.Add("NOD002_NOP007_ajuste_isr", GetType(System.Double))
                        dtInfoValores.Columns.Add("NOD71_NOP008_ajuste_subsidio_pagado", GetType(System.Double))
                        dtInfoValores.Columns.Add("CREFIS_crefis_sumar_semana_actual", GetType(System.Double))
                        dtInfoValores.Columns.Add("Cuadre", GetType(System.Double))
                        '===========================

                        Dim dtAllMovs As New DataTable
                        Dim dtMovsPro As New DataTable
                        Dim listaPeriodos As String = ""
                        '---Obtener los periodos que van a entrar en juego para el acumulado del mes que se está consultando
                        For Each drP As DataRow In dtPeriodosMes.Rows
                            Dim _numPer As String = ""
                            _numPer = drP("PERIODO").ToString.Trim
                            If (_numPer <> per_actual) Then listaPeriodos = listaPeriodos & "'" & _numPer & "'," ' Excepto el periodo actual que es el calculado ya que ese lo tomamos de movspro
                        Next
                        listaPeriodos = listaPeriodos.TrimStart(",")
                        listaPeriodos = listaPeriodos.TrimEnd(",")


                        Dim lstRljsNominaPro = String.Join(",", (From j In dtNominaPro Select "'" & j("reloj") & "'"))

                        'dtAllMovs = sqlExecute("select * from movimientos where ANO='" & anio & "' and PERIODO in (" & listaPeriodos &
                        '                       ") and concepto in ('CREFIS','CREPAG','PERGRA','ISPT','ISPTRE')  and reloj in (" & lstRljsNominaPro & ")", "NOMINA")
                        dtAllMovs = sqlExecute("select m.* from nomina.dbo.movimientos m " &
                                               "left join ta.dbo.periodos p on (p.ano=m.ano and p.periodo=m.periodo) " &
                                               "where m.concepto in ('CREFIS','CREPAG','PERGRA','ISPT','ISPTRE') and p.mes_acumulado='" & num_mes & "' and m.reloj in (" & lstRljsNominaPro & ")")

                        dtMovsPro = Sqlite.getInstance.sqliteExecute("select * from movimientosPro where concepto in ('CREFIS','CREPAG','PERGRA','ISPT','ISPTRE') and reloj in (" & lstRljsNominaPro & ")")

                        '--Mostrar progress
                        If Not Me.BgWorker Is Nothing Then : data("etapa") = "Realizando cálculo ajuste al subsidio" : Me.BgWorker.ReportProgress(0) : End If

                        Dim x As Integer = 0, y As Integer = 0
                        x = 4 ' Significa que comenzamos en el renglon 4, columna 1 
                        y = 1
                        '-----Recorremos cada uno de los registros que hay en nomina pro para ir insertándolos en el excel
                        For Each row As DataRow In dtNominaPro.Rows

                            '--- Nuevo registro a dtInfoValores
                            Dim nrInfo = dtInfoValores.NewRow
                            nrInfo("Reloj") = row("reloj").ToString.Trim()
                            nrInfo("Cod_tipo") = row("cod_tipo").ToString.Trim()
                            nrInfo("Alta") = Convert.ToDateTime(row("Alta"))
                            Try : If IsDBNull(row("baja")) Then nrInfo("Baja") = DBNull.Value Else nrInfo("Baja") = Convert.ToDateTime(row("baja"))
                            Catch ex As Exception : nrInfo("Baja") = DBNull.Value : End Try

                            '-- Columnas cálculo días: Inicio, fin, días
                            nrInfo("Inicio") = IIf(Convert.ToDateTime(row("Alta")) > Convert.ToDateTime(fecha_ini), Convert.ToDateTime(row("Alta")), Convert.ToDateTime(fecha_ini))
                            If Not IsDBNull(row("baja")) Then
                                If row("baja") < Convert.ToDateTime(fecha_fin) Then nrInfo("Fin") = row("baja") Else nrInfo("Fin") = Convert.ToDateTime(fecha_fin)
                            Else
                                nrInfo("Fin") = Convert.ToDateTime(fecha_fin)
                            End If
                            nrInfo("Dias") = DateDiff(DateInterval.Day, nrInfo("Inicio"), nrInfo("Fin")) + 1

                            '-----------Datos generales de cada empleado
                            Dim rj As String = "", nombres As String = "", cod_tipo_empl As String = "", alta As String = "", baja As String = ""
                            Try : rj = row("RELOJ").ToString.Trim : Catch ex As Exception : rj = "" : End Try

                            '----Mostrar Progress - avance
                            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / noEmpleados) : End If
                            '----Ends Avance

                            Try : nombres = row("nombres").ToString.Trim : Catch ex As Exception : nombres = "" : End Try
                            Try : cod_tipo_empl = row("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo_empl = "" : End Try
                            Try : alta = FechaSQL(row("alta").ToString.Trim) : Catch ex As Exception : alta = "  -   -" : End Try
                            Try : baja = FechaSQL(row("baja").ToString.Trim) : Catch ex As Exception : baja = "  -   -" : End Try


                            workSheet.Cells(x, y).Value = rj  ' 4,1
                            workSheet.Cells(x, y + 1).Value = nombres  ' 4,2
                            workSheet.Cells(x, y + 2).Value = cod_tipo_empl  ' 4,3
                            workSheet.Cells(x, y + 3).Value = alta  ' 4,4
                            workSheet.Cells(x, y + 4).Value = baja  ' 4,5

                            '======================================================== FORMULAS EXCEL 
                            '-- SECCION 'CALCULO DIAS' EN EXCEL
                            workSheet.Cells(x, 6).Formula = "=IF(D" & x & ">$F$1,D" & x & ",$F$1)"                                                                          '-- Inicio [F]
                            workSheet.Cells(x, 7).Formula = "=IF(OR($H$1<E" & x & ",E" & x & "= ""  -   -""),$H$1,E" & x & ")"                                                 '-- Fin [G]
                            workSheet.Cells(x, 8).Formula = "=+G" & x & "-F" & x & "+1"                                                                                     '-- Dias [H]
                            '-- SECCION 'SUBSIDIO CAUSADO' EN EXCEL
                            workSheet.Cells(x, 16).Formula = "=SUM(J" & x & ":O" & x & ")*-1"                                                                                   '-- Total [P]
                            '-- SECCION 'SUBSIDIO PAGADO' EN EXCEL
                            workSheet.Cells(x, 23).Formula = "=SUM(R" & x & ":V" & x & ")"                                                                                      '-- Total [W]
                            '-- SECCION 'ISR COMPENSADO' EN EXCEL
                            workSheet.Cells(x, 27).Formula = "=BI" & x & "-BQ" & x                                                                                              '-- Isr compensado  [AA]
                            '-- SECCION 'PERCEPCION GRAVADA' EN EXCEL
                            workSheet.Cells(x, 35).Formula = "=SUM(AC" & x & ":AH" & x & ")"                                                                                    '-- Total [AI]
                            '-- SECCION 'MENSUALIZADO A 30.4 DIAS' EN EXCEL
                            workSheet.Cells(x, 36).Formula = "=AI" & x                                                                          '-- Mensualizado a 30.4 dias [AJ]
                            '-- SECCION 'SUBSIDIO MENSUAL' EN EXCEL
                            workSheet.Cells(x, 38).Formula = "=AJ" & x                                                                                                          '-- Percepcion gravada [AL]
                            workSheet.Cells(x, 39).Formula = "=IFERROR(VLOOKUP(AL" & x & ",'Tablas mensuales'!$A$21:$B$31,1),0)"                                                '-- Limite inferior [AM]
                            workSheet.Cells(x, 40).Formula = "=IFERROR(VLOOKUP(AL" & x & ",'Tablas mensuales'!$A$21:$B$31,2),0)"                                                '-- Subsidio [AN]
                            workSheet.Cells(x, 41).Formula = "=AN" & x                                                                                          '-- Subsidio proporcional a dias [AO]
                            '-- SECCION 'DIFERENCIA ORIGINAL SUBSIDIO' EN EXCEL
                            workSheet.Cells(x, 43).Formula = "=AO" & x & "-P" & x                                                                                               '-- Diferencia original subsidio [AQ]
                            '-- SECCION 'CREFIS' EN EXCEL
                            'workSheet.Cells(x, 44).Formula = "=IF(AND(AQ" & x & ">=N" & x & ",N" & x & "<0),AQ" & x & "*-1,IF(N" & x & "<>0,0,N" & x & "*-1))"                  '-- Ajuste al subsidio de la semana actual [AR]
                            '-- SECCION 'SUBSIDIO MENSUAL CON AJUSTE SEM ACTUAL' EN EXCEL [sumar en vez de restar -- Ivette -- 25 julio 2023]
                            workSheet.Cells(x, 45).Formula = "=+P" & x & "+AR" & x                                                                                              '-- Subsidio mensual con ajuste sem actual [AS]
                            '-- SECCION 'DIFERENCIA SUBSIDIO FINAL' EN EXCEL
                            workSheet.Cells(x, 46).Formula = "=+AO" & x & "-AS" & x                                                                                             '-- Diferencia Subsidio final [AT]
                            '-- SECCION 'NOD107' EN EXCEL
                            workSheet.Cells(x, 48).Formula = "=IF(AT" & x & "<0,AT" & x & "*-1,0)"                                                                              '-- Ajuste al subsidio [AV]
                            '-- SECCION 'NOD 002 - NOP 007' EN EXCEL

                            'workSheet.Cells(x, 49).Formula = "=IF(AT" & x & "<0,(AX" & x & "+AT" & x & ")*-1,0)"                                                                '-- Ajuste ISR [AW]
                            workSheet.Cells(x, 49).Formula = "=IF(AT" & x & "<0,(AX" & x & "+AT" & x & ")*-1,0)"                                                                '

                            '-- SECCION 'NOD 071 - NOP 008' EN EXCEL
                            workSheet.Cells(x, 50).Formula = "=IF(AT" & x & "<0,W" & x & ",0)"                                                                                  '-- Ajuste subsidio pagado [AX]
                            '-- SECCION 'CREFIS' EN EXCEL
                            workSheet.Cells(x, 51).Formula = "=IF(AT" & x & ">0,AT" & x & ",0)"                                                                                 '-- CREFIS a sumar en sem actual [AY]
                            '-- SECCION 'CUADRE' EN EXCEL
                            workSheet.Cells(x, 52).Formula = "=+AT" & x & "-AY" & x & "+AW" & x & "+AX" & x                                                                     '-- Cuadre [AZ]
                            '-- SECCION 'IMPUESTO CAUSADO' EN EXCEL
                            workSheet.Cells(x, 61).Formula = "=SUM(BC" & x & ":BH" & x & ")"                                                                                    '-- Total [BI]
                            '-- SECCION 'IMPUESTO RETENIDO' EN EXCEL
                            workSheet.Cells(x, 69).Formula = "=SUM(BK" & x & ":BP" & x & ")"                                                                                    '-- Total [BQ]
                            '-- SECCION 'ISR' EN EXCEL
                            workSheet.Cells(x, 71).Formula = "=AI" & x                                                                                                          '-- Percepcion gravada [BS]
                            workSheet.Cells(x, 72).Formula = "=VLOOKUP(BS" & x & ",'Tablas mensuales'!$A$4:$C$14,1)"                                                            '-- Limite inferior [BT]
                            workSheet.Cells(x, 73).Formula = "=BS" & x & "-BT" & x                                                                                              '-- Exedente [BU]
                            workSheet.Cells(x, 74).Formula = "=VLOOKUP(BS" & x & ",'Tablas mensuales'!$A$4:$C$14,3)/100"                                                        '-- % Exedente [BV]
                            workSheet.Cells(x, 75).Formula = "=ROUND(BU" & x & "*BV" & x & ",2)"                                                                                '-- Impuesto marginal [BW]
                            workSheet.Cells(x, 76).Formula = "=VLOOKUP(BS" & x & ",'Tablas mensuales'!$A$4:$C$14,2)"                                                            '-- Cuota fija [BX]
                            workSheet.Cells(x, 77).Formula = "=+BW" & x & "+BX" & x                                                                                             '-- Impuesto bruto [BY]
                            workSheet.Cells(x, 79).Formula = "=BI" & x & "-BY" & x                                                                                              '-- Diferencia impuesto [CA]
                            '========================================================

                            '-----Subsidio Causado  viene en negativo en Movs, (Incluye el periodo actual) - Columnas J - O
                            y = 10
                            For Each per As DataRow In dtPeriodosMes.Rows
                                Dim numPer As String = "", anioPer As String = "", concepto As String = "CREFIS", monto As Double = 0.0
                                '   Try : numPer = per("PERIODO").ToString.Trim : Catch ex As Exception : numPer = "" : End Try
                                numPer = per("PERIODO").ToString.Trim
                                anioPer = anio & numPer

                                If (numPer <> per_actual) Then ' Mientras no sea el per actual se tomará de movimientos
                                    For Each dr As DataRow In dtAllMovs.Select("reloj='" & rj & "' and periodo='" & numPer & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                Else ' Si es el periodo actual se tomará de movimientos_pro
                                    For Each dr As DataRow In dtMovsPro.Select("reloj='" & rj & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next
                                End If

                                '--- Guardar info en dtInfoValores: Periodos montos
                                nrInfo("SubCausado_aguinaldo") = 0.0
                                If per("periodo_especial") Then
                                    nrInfo("SubCausado_aguinaldo") = monto
                                Else
                                    nrInfo("SubCausado_" & numPer) = monto
                                End If
                                '---

                                '== Definición de fórmula para la sección de la columna roja 'CREFIS' en el excel.
                                '-- CREFIS - Ajuste al subsidio de la semana actual [AR]
                                If numPer = data("periodo") Then
                                    workSheet.Cells(x, 44).Formula = "=IF(AQ" & x & ">0,0,IF(AQ" & x & ">" & GetExcelColumnName(y) & x & ",AQ" & x & "," & GetExcelColumnName(y) & x & "))"
                                End If
                                '==

                                workSheet.Cells(x, y).Value = monto
                                y = y + 1
                            Next

                            '--- Guardar info en dtInfoValores: Subsidio causado total
                            For Each subCau In dtPeriodosMes.Select("periodo_especial=0") : sumaValores += nrInfo("SubCausado_" & subCau("periodo").ToString.Trim) : Next
                            nrInfo("SubCausado_total") = nrInfo("SubCausado_aguinaldo") + sumaValores * -1
                            sumaValores = 0.0
                            '---

                            '------ SUBSIDIO PAGADO (CREPAG) - Viene en Positivo y no incluye el PER ACTUAL -  (Columnas R - V)
                            y = 18
                            For Each per As DataRow In dtPeriodosMes.Rows
                                Dim numPer As String = "", anioPer As String = "", concepto As String = "CREPAG", monto As Double = 0.0
                                ' Try : numPer = per("PERIODO").ToString.Trim : Catch ex As Exception : numPer = "" : End Try
                                numPer = per("PERIODO").ToString.Trim
                                anioPer = anio & numPer

                                If (numPer <> per_actual) Then ' Mientras no sea el per actual se tomará de movimientos
                                    For Each dr As DataRow In dtAllMovs.Select("reloj='" & rj & "' and periodo='" & numPer & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next
                                    '--- Guardar info en dtInfoValores: Periodos montos
                                    nrInfo("SubPagado_aguinaldo") = 0.0
                                    If per("periodo_especial") Then
                                        nrInfo("SubPagado_aguinaldo") = monto
                                    Else
                                        nrInfo("SubPagado_" & numPer) = monto
                                    End If
                                    '---
                                End If
                                workSheet.Cells(x, y).Value = monto
                                y = y + 1
                            Next

                            '--- Guardar info en dtInfoValores: Subsidio pagado total
                            For Each subCau In dtPeriodosMes.Select("periodo_especial=0")
                                If subCau("periodo").ToString.Trim = per_actual Then Continue For
                                sumaValores += nrInfo("SubPagado_" & subCau("periodo").ToString.Trim)
                            Next
                            nrInfo("SubPagado_total") = sumaValores + nrInfo("SubPagado_aguinaldo")
                            sumaValores = 0.0
                            '---

                            '----- COLUMNA Y - SUBSIDIO PAGADO (SUBPAG) antes del ajuste (Nomina actual abierta)
                            y = 25
                            Dim subpag As Double = 0.0
                            For Each dr As DataRow In dtMovsPro.Select("reloj='" & rj & "' and concepto='CREPAG'")
                                Try : subpag = Double.Parse(dr("monto")) : Catch ex As Exception : subpag = 0.0 : End Try
                            Next
                            '--- Guardar info en dtInfoValores: Subsidio pagado antes de ajuste
                            nrInfo("Subsidio_pagado_antes_ajuste") = subpag
                            '---
                            workSheet.Cells(x, y).Value = subpag


                            '------- PERGRA (Percep Gravada) (Columnas AC - AG) si incluye el periodo actual
                            y = 29
                            For Each per As DataRow In dtPeriodosMes.Rows
                                Dim numPer As String = "", anioPer As String = "", concepto As String = "PERGRA", monto As Double = 0.0
                                '  Try : numPer = per("PERIODO").ToString.Trim : Catch ex As Exception : numPer = "" : End Try
                                numPer = per("PERIODO").ToString.Trim
                                anioPer = anio & numPer

                                If (numPer <> per_actual) Then ' Mientras no sea el per actual se tomará de movimientos
                                    For Each dr As DataRow In dtAllMovs.Select("reloj='" & rj & "' and periodo='" & numPer & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                Else ' Si es el periodo actual se tomará de movimientos_pro
                                    For Each dr As DataRow In dtMovsPro.Select("reloj='" & rj & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                End If

                                '--- Guardar info en dtInfoValores: Periodos montos
                                nrInfo("PerGravada_aguinaldo") = 0.0
                                If per("periodo_especial") Then
                                    nrInfo("PerGravada_aguinaldo") = monto
                                Else
                                    nrInfo("PerGravada_" & numPer) = monto
                                End If
                                '---
                                workSheet.Cells(x, y).Value = monto
                                y = y + 1
                            Next

                            '--- Guardar info en dtInfoValores: Percepción gravada
                            For Each subCau In dtPeriodosMes.Select("periodo_especial=0")
                                sumaValores += nrInfo("PerGravada_" & subCau("periodo").ToString.Trim)
                            Next
                            nrInfo("PerGravada_total") = sumaValores + nrInfo("PerGravada_aguinaldo")
                            'nrInfo("Mensualizado_30.4_dias") = Math.Round(nrInfo("PerGravada_total") / nrInfo("Dias") * 30.4, 2)
                            nrInfo("Mensualizado_30.4_dias") = nrInfo("PerGravada_total")

                            sumaValores = 0.0

                            '--- Guardar info en dtInfoValores: Subsidio mensual
                            nrInfo("SubMensual_pergravada") = nrInfo("Mensualizado_30.4_dias")

                            Try : nrInfo("SubMensual_limite_inferior") = dtIsptProMensual.Select("tabla='SubEmpleo' and lim_inf<=" & nrInfo("SubMensual_pergravada"), "lim_inf DESC").First().Item("lim_inf")
                            Catch ex As Exception : nrInfo("SubMensual_limite_inferior") = 0.0 : End Try
                            Try : nrInfo("SubMensual_subsidio") = dtIsptProMensual.Select("tabla='SubEmpleo' and lim_inf<=" & nrInfo("SubMensual_pergravada"), "lim_inf DESC").First().Item("subempleo")
                            Catch ex As Exception : nrInfo("SubMensual_subsidio") = 0.0 : End Try

                            'nrInfo("SubMensual_sub_proporcional_dias") = Math.Round(nrInfo("SubMensual_subsidio") / 30.4 * nrInfo("Dias"), 2)
                            nrInfo("SubMensual_sub_proporcional_dias") = nrInfo("SubMensual_subsidio")
                            '---

                            '---
                            nrInfo("Diferencia_original_subsidio") = Math.Round(nrInfo("SubMensual_sub_proporcional_dias") - nrInfo("SubCausado_total"), 2)
                            nrInfo("CREFIS_ajuste_subsidio_sem_actual") = Math.Round(IIf(nrInfo("Diferencia_original_subsidio") > 0, 0.0,
                                                                              IIf(nrInfo("Diferencia_original_subsidio") > nrInfo("SubCausado_" & per_actual), nrInfo("Diferencia_original_subsidio"), nrInfo("SubCausado_" & per_actual))), 2)

                            nrInfo("Subsidio_mensual_ajuste_semana_actual") = Math.Round(nrInfo("SubCausado_total") + nrInfo("CREFIS_ajuste_subsidio_sem_actual"), 2)
                            nrInfo("Diferencia_subsidio_final") = Math.Round(nrInfo("SubMensual_sub_proporcional_dias") - nrInfo("Subsidio_mensual_ajuste_semana_actual"), 2)
                            '---

                            '---
                            nrInfo("NOD107_ajuste_subsidio") = Math.Round(IIf(nrInfo("Diferencia_subsidio_final") < 0, nrInfo("Diferencia_subsidio_final") * -1, 0.0), 2)
                            nrInfo("NOD71_NOP008_ajuste_subsidio_pagado") = Math.Round(IIf(nrInfo("Diferencia_subsidio_final") < 0,
                                                                                IIf((nrInfo("Diferencia_subsidio_final") * -1) < nrInfo("SubPagado_total"),
                                                                                    nrInfo("Diferencia_subsidio_final") * -1, nrInfo("SubPagado_total")), 0.0), 2)

                            nrInfo("NOD002_NOP007_ajuste_isr") = Math.Round(IIf(nrInfo("Diferencia_subsidio_final") < 0, (nrInfo("NOD71_NOP008_ajuste_subsidio_pagado") + nrInfo("Diferencia_subsidio_final")) * -1, 0.0), 2)
                            nrInfo("CREFIS_crefis_sumar_semana_actual") = Math.Round(IIf(nrInfo("Diferencia_subsidio_final") > 0, nrInfo("Diferencia_subsidio_final"), 0.0), 2)
                            nrInfo("Cuadre") = Math.Round(nrInfo("Diferencia_subsidio_final") - nrInfo("CREFIS_crefis_sumar_semana_actual") + nrInfo("NOD002_NOP007_ajuste_isr") + nrInfo("NOD71_NOP008_ajuste_subsidio_pagado"), 2)
                            '---

                            '------- ISPT IMPUESTO CAUSADO   (Columnas BC - BG) si incluye el periodo actual
                            y = 55
                            For Each per As DataRow In dtPeriodosMes.Rows
                                Dim numPer As String = "", anioPer As String = "", concepto As String = "ISPT", monto As Double = 0.0
                                numPer = per("PERIODO").ToString.Trim
                                anioPer = anio & numPer

                                If (numPer <> per_actual) Then ' Mientras no sea el per actual se tomará de movimientos
                                    For Each dr As DataRow In dtAllMovs.Select("reloj='" & rj & "' and periodo='" & numPer & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                Else ' Si es el periodo actual se tomará de movimientos_pro
                                    For Each dr As DataRow In dtMovsPro.Select("reloj='" & rj & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                End If


                                workSheet.Cells(x, y).Value = monto
                                y = y + 1
                            Next

                            y = 63
                            '-----------ISPTRE isr Retenido-- (Columnas BK - BO) si incluye el periodo actual
                            For Each per As DataRow In dtPeriodosMes.Rows
                                Dim numPer As String = "", anioPer As String = "", concepto As String = "ISPTRE", monto As Double = 0.0
                                ' Try : numPer = per("PERIODO").ToString.Trim : Catch ex As Exception : numPer = "" : End Try
                                numPer = per("PERIODO").ToString.Trim
                                anioPer = anio & numPer

                                If (numPer <> per_actual) Then ' Mientras no sea el per actual se tomará de movimientos
                                    For Each dr As DataRow In dtAllMovs.Select("reloj='" & rj & "' and periodo='" & numPer & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next

                                Else ' Si es el periodo actual se tomará de movimientos_pro
                                    For Each dr As DataRow In dtMovsPro.Select("reloj='" & rj & "' and concepto='" & concepto & "'")
                                        Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : monto = 0.0 : End Try
                                    Next
                                End If


                                workSheet.Cells(x, y).Value = monto
                                y = y + 1
                            Next

                            x = x + 1 '- Ir registrando cada registro hacia abajo en cada renglón
                            y = 1 ' inicializamos a la primer columna para que comience con el nuevo registro

                            dtInfoValores.Rows.Add(nrInfo)

                            counter += 1
                        Next

                        '--Mostrar progress
                        Dim totalQrys = 0
                        If Not Me.BgWorker Is Nothing Then : data("etapa") = "Guardando registros de ajuste al subsidio" : Me.BgWorker.ReportProgress(0) : End If
                        counter = 0

                        '--- Se agregan los conceptos de ajuste subsidio a la tabla 'ajustesSubsidio'
                        Dim strQry = "", strConceptos = {"CREFIS:CREFIS_ajuste_subsidio_sem_actual",
                                                         "NOD107:NOD107_ajuste_subsidio",
                                                         "NOD002:NOD002_NOP007_ajuste_isr",
                                                         "NOP007:NOD002_NOP007_ajuste_isr",
                                                         "NOD071:NOD71_NOP008_ajuste_subsidio_pagado",
                                                         "NOP008:NOD71_NOP008_ajuste_subsidio_pagado",
                                                         "CREFIS:CREFIS_crefis_sumar_semana_actual"}

                        For Each rowSub In dtInfoValores.Rows
                            For Each c In strConceptos
                                If rowSub(c.Split(":")(1)) = "0" Then Continue For
                                strQry &= String.Format("INSERT INTO ajustesSubsidio (ano,periodo,reloj,concepto,monto,origen,usuario,datetime) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');",
                                                        anio, per_actual, rowSub("reloj"), c.Split(":")(0), rowSub(c.Split(":")(1)), "AjusteSubsidioMensual", Usuario, Now.ToString)
                                totalQrys += 1
                            Next
                        Next

                        If totalQrys = 0 Then
                            MessageBox.Show("No se encontraron empleados con subsidio.", "Empleados sin subsidio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.addLog("Atencion: No se encontraron empleados con subsidio")
                        Else
                            For Each qry In strQry.Split(";")
                                Sqlite.getInstance.sqliteExecute(qry)
                                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / totalQrys) : End If
                                counter += 1
                            Next

                            '--- Guardar el archivo
                            package.SaveAs(New System.IO.FileInfo(dirAjusteSubsidio))

                            '--- Aviso de confirmación
                            MessageBox.Show("Se ha generado el excel de 'Ajuste subsidio mensual' del mes de '" & nombreMes & "' y se guardaron los movimientos de los conceptos correspondientes.",
                                            "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.addLog("Confirmación: Se guardaron " & Sqlite.getInstance.sqliteExecute("select count(id) as num from ajustesSubsidio").Rows(0)("num") & " registros de ajuste al subsidio.")
                        End If

                    End Using
                Else
                    MessageBox.Show(IIf(lstError(0).Length > 0 And lstError(1).Length > 0, lstError(1), IIf(lstError(0).Length > 0, lstError(0), lstError(1))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.addLog("Error: Ajuste al subsidio no se pudo ejecutar [" & IIf(lstError(0).Length > 0 And lstError(1).Length > 0,
                                                                                      "Movimientos de proceso cálculo",
                                                                                      IIf(lstError(0).Length > 0, "Ruta no definida para reporte", "Movimientos de proceso cálculo")) & "]", Nothing, True)
                End If
            End If

        Catch ex As Exception
            'ActivoTrabajando = False
            'frmTrabajando.Close()
            'frmTrabajando.Dispose()
            MessageBox.Show("Error al crear el reporte Ajuste al subsidio Mensual." & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_reporteSubsidioMensual", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función para agregar los registros de la tabla 'ajustesSubsidio' a 'ajustesPro' en caso de que el usuario lo decida en la pantalla para el cálculo.  2023-02-08 -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregaRegSubsidiosAjustesPro(ByRef data As Dictionary(Of String, String), ByRef sinDatos As Boolean,
                                             Optional calculoIndividual As List(Of String) = Nothing)
        Try
            '== Se verifica que existan registros en en 'ajustesSubsidio'
            Sqlite.getInstance.sqliteExecute("DELETE FROM ajustesPro where origen='AjusteSubsidioMensual' ")
            Dim dtAjustesSubsidio = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesSubsidio ")
            Dim dtConceptos = sqlExecute("select concepto,nombre from nomina.dbo.conceptos")

            If dtAjustesSubsidio.Rows.Count > 0 Then
                Dim counter = dtAjustesSubsidio.Rows.Count
                Dim count = 0
                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Incorporando registros de ajuste subsidio al cálculo" : Me.BgWorker.ReportProgress(0) : End If

                For Each row In dtAjustesSubsidio.Rows
                    Dim nombre = Nothing
                    If dtConceptos.Select("concepto='" & row("concepto").ToString.Trim & "'").Any Then nombre = dtConceptos.Select("concepto='" & row("concepto").ToString.Trim & "'").First.Item("nombre").ToString.Trim
                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", row("ano")},
                                                                                        {"periodo", row("periodo")},
                                                                                        {"reloj", row("reloj")},
                                                                                        {"per_ded", ""},
                                                                                        {"concepto", row("concepto")},
                                                                                        {"descripcion", nombre},
                                                                                        {"monto", row("monto")},
                                                                                        {"clave", Nothing},
                                                                                        {"origen", "AjusteSubsidioMensual"},
                                                                                        {"usuario", Usuario},
                                                                                        {"datetime", Now},
                                                                                        {"afecta_vac", False},
                                                                                        {"factor", Nothing},
                                                                                        {"fecha", Nothing},
                                                                                        {"sueldo", Nothing},
                                                                                        {"fecha_fox", Nothing},
                                                                                        {"per_aplica", Nothing},
                                                                                        {"ano_aplica", Nothing},
                                                                                        {"saldo", 0}}, "ajustesPro")
                    count += 1
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * count / counter) : End If
                Next
                Me.addLog("Confirmación: Se agregaron " & counter & " registros de ajuste al subsidio para el cálculo.")
            Else
                Me.addLog("Aviso: No hay registros de ajustes subsidio para agregar al cálculo.")
                sinDatos = True
            End If

        Catch ex As Exception
            sinDatos = True
            MessageBox.Show("Ha ocurrido un error durante la inserción de los ajustes a subsidio a misceláneos, por favor, revise el log y/o notifique al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.addLog("Error en el proceso de cálculo [Agregar subsidio]: " & ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_agregarSubsidio", ex.HResult, ex.Message)
        End Try
    End Sub


    Public Shared Function tableToExcelPackage(table As DataTable, name As String) As ExcelPackage
        Dim columns = (From k As DataColumn In table.Columns Select k.ColumnName).ToList
        Dim file As ExcelPackage = New ExcelPackage()
        Dim wb As ExcelWorkbook = file.Workbook

        Dim i As Integer = 1
        Dim j As Integer = 1

        Dim nextPos = Sub(x As Integer, y As Integer)
                          i += y
                          j = x
                      End Sub

        Dim listOfPages As New List(Of ExcelWorksheet)
        listOfPages.Add(wb.Worksheets.Add(name))
        Dim page As ExcelWorksheet = listOfPages.Last()

        'Adicionando header
        For Each item In columns : page.Cells(i, j).Value = item.ToUpper() : page.Cells(i, j).Style.Font.Bold = True : j += 1 : Next

        'Llenando datos
        For Each item In table.Rows
            nextPos(1, 1)
            For Each t In columns : page.Cells(i, j).Value = item(t) : j += 1 : Next
        Next
        page.Cells.AutoFitColumns()
        Return file
    End Function

    Public Shared Sub saveExcelFile(NameFile As String, archivo As ExcelPackage,
                              Optional initialize As Boolean = True,
                              Optional rutaGuardar As String = "",
                              Optional tipoExcel As String = ".xlsx",
                              Optional filtro As String = "Archivo excel (xlsx)|*.xlsx")
        Try
            If rutaGuardar <> "" Then
                'Dim sfd2 As New SaveFileDialog
                'sfd2.FileName = rutaGuardar & NameFile & tipoExcel
                Dim strGuardar = rutaGuardar & NameFile & tipoExcel
                archivo.SaveAs(New System.IO.FileInfo(strGuardar))
                Exit Sub
            End If

            Dim sfd As New SaveFileDialog
            sfd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

            sfd.FileName = NameFile & tipoExcel
            sfd.Filter = filtro
            If sfd.ShowDialog() = DialogResult.OK Then
                archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
                If initialize Then
                    MessageBox.Show("Archivo generado correctamente.", "Reporte Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'System.Diagnostics.Process.Start(sfd.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar archivo. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Horas de nomina 
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
     Public Sub ProcesarHoras(ByRef data As Dictionary(Of String, String))
        Try
            '-- Variables
            Dim c = 0
            Dim counter = 0
            Dim dDato As DataRow
            Dim strFileName As String = ""
            Dim dtDatos As New DataTable

            Dim dRow As DataRow
            Dim strQuery As String = ""
            Dim strRelojes As String = ""
            Dim strQuerys As New ArrayList
            Dim dtEmpleados As New DataTable
            Dim dtPersonal As New DataTable
            Dim dtnomsem As New DataTable

            '-- Se limpia horas pro para llenarla de nuevo
            Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM horasPro")

            '-- Vacaciones trabajadas
            Try
                Dim mensaje_trabajadas = "", sql = ""

                Dim existeTipoPeriodo = False
                Dim strTipoPeriodo = If(existeTipoPeriodo, "AND tipo_periodo = '" & data("tipoPeriodo") & "'", "")
                Dim dtVacTrab = sqlExecute("SELECT reloj, isnull(comentario, '') AS comentario FROM ajustes_nom WHERE concepto = 'DIASVA' AND ano = '" &
                                           data("ano") & "' " & strTipoPeriodo & " AND periodo = '" & data("periodo") & "' ", "NOMINA")

                Dim coments = dtVacTrab.Select("len(trim(comentario))>0")

                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Cargando comentarios" : Me.BgWorker.ReportProgress(0) : End If

                For Each row As DataRow In coments
                    Try
                        Dim fecha = RTrim(row("comentario")).Split(",")(1)
                        sql &= "SELECT * FROM asist WHERE reloj = '" & row("reloj") & "' AND fha_ent_hor = '" & FechaSQL(fecha) & "' AND (comentario like '%VAC%' and comentario like '%TRAB%') UNION "
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / coments.Count) : counter += 1 : End If
                    Catch ex As Exception : End Try
                Next

                If sql.Length > 0 Then
                    Dim dtTrab = sqlExecute(sql.Substring(0, sql.Length - 7))
                    For Each row In dtTrab.Rows : mensaje_trabajadas &= vbCrLf & row("reloj") & ", " & "Vacaciones trabajadas, " & row("fha_ent_hor") : Next
                End If

                If mensaje_trabajadas <> "" Then
                    Me.addLog("Advertencia. Existen vacaciones trabajadas" & mensaje_trabajadas)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            data("etapa") = "Cargando datos"

            '-- Datatable con info. para el archivo de horas
            dtDatos = CrearDatatableArchivoHrs()

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 1 / 7) : End If
            Dim cod_tipo = "" : If data.ContainsKey("cod_tipo") Then : cod_tipo = " AND cod_tipo = '" & data("cod_tipo") & "' " : End If
            Dim cod_planta = "" : If data.ContainsKey("cod_planta") Then : cod_tipo = " AND cod_planta = '" & data("cod_planta") & "' " : End If

            '-- Empleados con horas
            If data("tipoPeriodo") = "S" Then

                '--- Se quito el cod_tipo para agregar todos los empleados
                strQuery = "WITH asistencia as ( " &
                           "select distinct reloj,COD_COMP,COD_TIPO from ta.dbo.asist where ano+periodo='" & data("ano") & data("periodo") & "' " &
                           ")" &
                           "SELECT distinct nomsem.*, personalvw.nombres,personalvw.nombre_area,personalvw.alta, personalvw.baja, " &
                           "personalvw.cod_planta,A.cod_tipo, personalvw.COD_DEPTO,personalvw.nombre_depto,personalvw.cod_super,dias_vacaciones,dias_aguinaldo,nombre_super AS super " &
                           "FROM ta.dbo.nomsem " &
                           "LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj " &
                           "LEFT JOIN asistencia A ON nomsem.RELOJ=a.RELOJ " &
                           "WHERE nomsem.periodo = '" & data("periodo") & "' AND nomsem.ano = '" & data("ano") &
                           "' AND personalvw.cod_comp in (" & data("codComp") & ") AND (personalvw.tipo_periodo = 'S') " &
                           "ORDER BY nomsem.RELOJ"
            Else
                strQuery = "select personalvw.RELOJ,personalvw.nombres,personalvw.nombre_area,personalvw.alta, personalvw.baja," &
                           "personalvw.cod_planta,personalvw.cod_tipo, personalvw.COD_DEPTO,personalvw.nombre_depto,personalvw.cod_super," &
                           "nombre_super AS super from personal.dbo.personalvw where COD_TIPO='A' and baja is null and COD_COMP in (" & data("codComp") & ") " &
                           "order by reloj asc "
            End If

            '-- Empleados para procesar hrs
            dtEmpleados = sqlExecute(strQuery)
            strRelojes = String.Join(",", From i In dtEmpleados Select "'" & i("reloj").ToString.Trim & "'")

            If dtEmpleados.Rows.Count = 0 Then
                Me.addLog("No se localizaron registros correspondientes a los parámetros indicados. Favor de verificar.", logType.ERR)
                'cancelProcess()
            End If

            dtPersonal = sqlExecute("SELECT * FROM personal WHERE reloj IN (" & strRelojes & ")")
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 2 / 7) : End If

            '-- Info. de incapacidades
            Dim dtIncap = sqlExecute("SELECT " &
                                    "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA " &
                                    "FROM TA.dbo.ausentismo " &
                                    "LEFT JOIN TA.dbo.tipo_ausentismo ON tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " &
                                    "WHERE TIPO_NATURALEZA = 'I' and ausentismo.fecha between '" & FechaSQL(Me.period("fecha_ini_incidencia")) & "' and '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' " &
                                    "AND reloj in (" & strRelojes & ") ", "TA")

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 3 / 7) : End If

            '-- Info. bajas ausentismos
            Dim dtbaja = sqlExecute("SELECT " &
                                    "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA " &
                                    "FROM TA.dbo.ausentismo " &
                                    "LEFT JOIN TA.dbo.tipo_ausentismo ON tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " &
                                    "LEFT JOIN PERSONAL.dbo.personal ON ausentismo.RELOJ = personal.reloj " &
                                    "WHERE TIPO_NATURALEZA = 'I' and ausentismo.fecha between '" & FechaSQL(Me.period("fecha_ini_incidencia")) & "' and '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' " &
                                    "AND ausentismo.reloj in (" & strRelojes & ") " &
                                    "AND baja IS NOT null", "TA")

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 4 / 7) : End If

            '-- Info. ausentismos
            Dim dtAusentismos = sqlExecute("WITH asistencia AS (" &
                                          "SELECT reloj,fecha_entro,fecha_salio,tipo_aus FROM " &
                                          "asist WHERE fecha_entro BETWEEN '" & FechaSQL(Me.period("fecha_ini_incidencia")) &
                                          "' AND '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' AND tipo_aus IN ('FI','C50','FES')" &
                                          ")" &
                                          "SELECT ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE, percepcion, cancelacion, deduccion, devolucion," &
                                          "(SELECT count(reloj) FROM asistencia a WHERE ausentismo.reloj=a.reloj AND ausentismo.fecha=a.fecha_entro AND ausentismo.tipo_aus=a.tipo_aus) AS existe_asist " &
                                          "FROM ausentismo " &
                                          "LEFT JOIN tipo_ausentismo ON tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " &
                                          "WHERE ausentismo.fecha BETWEEN '" & FechaSQL(Me.period("fecha_ini_incidencia")) &
                                          "' AND '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' " & If(data("tipoPeriodo") = "Q", " and reloj in (" & strRelojes & ")", ""), "TA")

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 5 / 7) : End If

            '-- Info. horas asistencia
            If data("tipoPeriodo") = "S" Then
                strQuery = "SELECT reloj, COALESCE(sum(dobles_33),0) as dobles_33, COALESCE(sum(triples_33),0) as triples_33 FROM TA.dbo.asist where fha_ent_hor between '" &
                           FechaSQL(Me.period("fecha_ini")) & "' and '" & FechaSQL(Me.period("fecha_fin")) & "' group by reloj"
            Else
                strQuery = "WITH ASISTENCIA AS (" &
                           "SELECT reloj," &
                           "COALESCE(dobles_33,0) AS dobles_33, " &
                           "COALESCE(triples_33,0) AS triples_33," &
                           "ROUND(CONVERT(FLOAT,CONVERT(DATETIME,HORAS_NORMALES))*24,2) AS HRS_NORMALES," &
                           "ROUND(CONVERT(FLOAT,CONVERT(DATETIME,EXTRAS_AUTORIZADAS))*24,2) AS HRS_EXTRAS_AUT," &
                           "DATEPART(WEEKDAY,FHA_ENT_HOR) AS DIA_SEMANA," &
                           "ROUND(CONVERT(FLOAT,CONVERT(DATETIME,REPLACE(horas_anticipadas,'-','')))*24*-1,2) AS HRS_ANTICIPADAS," &
                           "ROUND(CONVERT(FLOAT,CONVERT(DATETIME,HORAS_TARDE))*24,2) AS HRS_TARDE,TIPO_AUS,ANO,PERIODO,ausentismo " &
                           "FROM ta.dbo.asist " &
                           "WHERE fha_ent_hor between '" & FechaSQL(Me.period("fecha_ini_incidencia")) &
                           "' and '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' and COD_TIPO='A'" &
                           ") " &
                           "SELECT a.*," &
                           "(a.HRS_EXTRAS_AUT-triples_33) AS HRS_DOBLES," &
                           "(CASE WHEN a.DIA_SEMANA=7 AND (ISNULL(a.ausentismo,0)=0) THEN 1 ELSE 0 END) AS PRIMA_SABATINA," &
                           "(CASE WHEN a.DIA_SEMANA=1 AND (ISNULL(a.ausentismo,0)=0) THEN 1 ELSE 0 END) AS PRIMA_DOMINICAL " &
                           "FROM PERSONAL.DBO.personal p " &
                           "INNER JOIN ASISTENCIA a ON p.RELOJ=a.RELOJ " &
                           "WHERE p.COD_TIPO='A' and BAJA IS NULL "
            End If

            Dim dtHorasAsistencia = sqlExecute(strQuery)

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 6 / 7) : End If

            '-- Info. comedores
            Dim dtComedor = sqlExecute("SELECT reloj, SUM(CASE WHEN subsidio = 'C' THEN 1 ELSE 0 END) AS CON_SUBSIDIO, " &
                                       "SUM(CASE WHEN subsidio = 'S' THEN 1 ELSE 0 END) AS SIN_SUBSIDIO, " &
                                       "SUM(CASE WHEN subsidio = 'Z' THEN 1 ELSE 0 END) AS SIN_SUBSIDIO_D, " &
                                       "SUM(CASE WHEN subsidio = 'P' THEN 1 ELSE 0 END) AS SIN_SUBSIDIO_D2 " &
                                       "FROM hrs_brt_cafeteria " &
                                       "WHERE hrs_brt_cafeteria.fecha BETWEEN '" & FechaSQL(Me.period("fecha_ini_incidencia")) &
                                       "' AND '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' " & If(data("tipoPeriodo") = "Q", " and reloj in (" & strRelojes & ") ", "") &
                                       "GROUP BY reloj", "TA")

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 7 / 7) : End If

            '-- Info. falta checadas
            Dim dtFaltasChecadas As New DataTable
            If data("tipoPeriodo") = "Q" Then
                dtFaltasChecadas = sqlExecute("SELECT a.RELOJ,p.nombres,p.cod_clase,a.FHA_ENT_HOR,a.COMENTARIO,p.cod_hora,p.sactual " &
                                              "FROM ASIST a " &
                                              "left join personal.dbo.personalvw p on a.reloj=p.reloj " &
                                              "WHERE a.COD_TIPO='A' AND a.FHA_ENT_HOR BETWEEN '" & FechaSQL(Me.period("fecha_ini_incidencia")) & "' AND '" &
                                              FechaSQL(Me.period("fecha_fin_incidencia")) & "' AND " &
                                              "(a.COMENTARIO LIKE '%ENTRADA%' or a.COMENTARIO LIKE '%SALIDA%') and " &
                                              "(A.comentario not like '%TRABAJO%' and A.comentario not like '%FESTIVO%' and A.comentario not like '%VACACION%') " &
                                              "order by reloj,fecha_entro", "TA")
            End If

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If
            data("etapa") = "Procesando horas"
            counter = 0

            '-- Registros nomsem para operativos
            If data("tipoPeriodo") = "S" Then dtnomsem = sqlExecute("SELECT * FROM nomsem WHERE periodo = '" & data("periodo") & "' AND ano = '" & data("ano") & "' ", "TA")

            Dim date_time = Now
            Dim factor = Nothing, fecha_hrs = Nothing, dtPersona = Nothing, temp As New DataTable
            Dim strLineaArchivo = ""
            Dim strReloj = ""

            '-- Recorrido de empleados
            For Each dRow In dtEmpleados.Rows
                Try
                    strReloj = dRow("reloj").ToString.Trim
                    factor = Nothing : fecha_hrs = Nothing : strLineaArchivo = ""
                    dtPersona = infoTabla("reloj='" & strReloj & "'", dtPersonal)

                    If dtPersona.ROWS.Count > 0 Then
                        '-- Validar Cambio de sueldo con incapacidad
                        Dim fha_ult_mod As DateTime = IIf(IsDBNull(dtPersona.rows(0)("FHA_ULT_MO")), Nothing, dtPersona.rows(0)("FHA_ULT_MO"))
                        temp = infoTabla("reloj='" & dRow("reloj").ToString.Trim & "'", dtIncap)

                        If temp.Rows.Count > 0 And
                            (Convert.ToDateTime(Me.period("fecha_ini_incidencia")) <= Convert.ToDateTime(fha_ult_mod) And
                             Convert.ToDateTime(Me.period("fecha_fin_incidencia")) >= Convert.ToDateTime(fha_ult_mod)) Then
                            Me.addLog("El empleado " & temp.Rows(0)("reloj").ToString.Trim & " cuenta con incapacidad en la semana que se aplicó cambio de sueldo.")
                        End If

                        '-- Bajas
                        Dim fha_baja As DateTime = IIf(IsDBNull(dtPersona.rows(0)("baja")), Nothing, dtPersona.rows(0)("baja"))
                        temp = infoTabla("reloj='" & dRow("reloj").ToString.Trim & "'", dtbaja)

                        If temp.Rows.Count > 0 And
                            (Convert.ToDateTime(Me.period("fecha_ini_incidencia")) <= Convert.ToDateTime(fha_ult_mod) And
                             Convert.ToDateTime(Me.period("fecha_fin_incidencia")) >= Convert.ToDateTime(fha_ult_mod)) Then
                            Me.addLog("El empleado " & temp.Rows(0)("reloj").ToString.Trim & " se encuentra dado de baja y cuenta con una incapacidad en la semana. ")
                        End If
                    End If

                    '-- Operativos: Si existe más de un registro de un empleado en nomsem, manda advertencia

                    If data("tipoPeriodo") = "S" Then
                        Dim temp1 As DataTable = infoTabla("reloj='" & dRow("reloj").ToString.Trim & "'", dtnomsem)
                        If temp1.Rows.Count > 1 Then
                            Me.addLog("El empleado " & temp1.Rows(0)("reloj").ToString.Trim & " se encuentra dado de baja y cuenta con una incapacidad en la semana.", logType.ERR)
                            'cancelProcess()
                        End If
                    End If


                    dDato = LlenarFilaArchivoHrs(data, dRow, dtDatos)
                    dtDatos.Rows.Add(dDato)

                    '-- Horas y primas sabatinas y dominicales
                    HorasPrimaSabatinasDominicalesProcesarHrs(data, dDato, dtPersona, dRow, strQuerys)
                    '-- Ausentismos
                    AusentismosProcesarHrs(data, dRow, dtPersona, dDato, strQuerys, dtAusentismos)
                    '-- Asistencias
                    AsistenciasProcesarHrs(data, dRow, dtPersona, dDato, strQuerys, dtHorasAsistencia)
                    '-- Asistencias
                    ComedoresProcesarHrs(data, dRow, dtPersona, dDato, strQuerys, dtComedor)
                    '-- Falta de checadas
                    FaltaChecadasProcesarHrs(data, strQuerys, strReloj)

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtEmpleados.Rows.Count) : counter += 1 : End If

                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Continue For
                End Try
            Next

            '-- Se ejecutan los querys para la insercion a horasPro
            GuardaMovimientosTabla("Procesando horas: Guardando", data, strQuerys)

            '-- Se cambia el formato de las fechas de los regitros de algunas tablas
            strQuerys.Clear()
            CambiarFormatoFechas(strQuerys:=strQuerys)
            GuardaMovimientosTabla("Validando formato de fechas", data, strQuerys) : strQuerys.Clear()

        Catch ex As Exception
        Finally
            ActivoTrabajando = False
            'If data("tipoPeriodo") = "S" Then Me.CargarHorasSem(data)
            'If data("tipoPeriodo") = "Q" Then Me.CargarHorasQna(data)
        End Try
    End Sub

    ''' <summary>
    ''' Se calculan conceptos de horasPro provenientes de asist para quincenales -- Ernesto -- 19 ene 2024
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub ConceptosHrsAsistQna(ByRef data As Dictionary(Of String, String), row As DataTable,
                                     ByRef arreglo As ArrayList)
        Try
            Dim hrs233 = 0.0, hrs333 = 0.0, hrsnor = 0.0, diadom = 0.0, diasab = 0.0, hrsfel = 0.0
            Dim hr2se1 = 0.0, hr2se2 = 0.0, hr2se3 = 0.0, hr3se1 = 0.0, hr3se2 = 0.0, hr3se3 = 0.0
            Dim anoPer = "", strRlj = "", escribirArchivo = ""


            Dim dicAsist As New Dictionary(Of String, Double)
            dicAsist.Add("hrs233", 0.0) : dicAsist.Add("hrs333", 0.0) : dicAsist.Add("hrsnor", 0.0) : dicAsist.Add("diadom", 0.0)
            dicAsist.Add("diasab", 0.0) : dicAsist.Add("hrsfel", 0.0)
            dicAsist.Add("hr2se1", 0.0) : dicAsist.Add("hr2se2", 0.0) : dicAsist.Add("hr2se3", 0.0)
            dicAsist.Add("hr3se1", 0.0) : dicAsist.Add("hr3se2", 0.0) : dicAsist.Add("hr3se3", 0.0)

            For Each i In row.Rows

                strRlj = Trim(i("reloj"))
                anoPer = Trim(i("ano")) & Trim(i("periodo"))
                hrsnor += i("hrs_normales")
                diadom += i("prima_dominical")
                diasab += i("prima_sabatina")

                '-- Horas festivas
                If (Not IsDBNull(i("tipo_aus")) AndAlso i("tipo_aus") = "FES") And i("hrs_extras_aut") > 0 Then
                    If i("hrs_extras_aut") < hrsnor Then
                        hrsfel += i("hrs_extras_aut")
                    Else
                        hrsfel += i("hrs_normales")
                        hrs233 = i("dobles_33")
                    End If
                Else
                    hrs233 = i("hrs_dobles")
                    hrs333 = i("triples_33")
                End If

                '-- Horas dobles y triples por semana
                If Me.period("sem1") = anoPer Then hr2se1 += hrs233 : hr3se1 += hrs333
                If Me.period("sem2") = anoPer Then hr2se2 += hrs233 : hr3se2 += hrs333
                If Me.period("sem3") = anoPer Then hr2se3 += hrs233 : hr3se3 += hrs333
            Next

            dicAsist("hrs233") = hrs233 : dicAsist("hrs333") = hrs333 : dicAsist("hrsnor") = hrsnor : dicAsist("diadom") = diadom
            dicAsist("diasab") = diasab : dicAsist("hrsfel") = hrsfel
            dicAsist("hr2se1") = hr2se1 : dicAsist("hr2se2") = hr2se2 : dicAsist("hr2se3") = hr2se3 : dicAsist("hr3se1") = hr3se1
            dicAsist("hr3se2") = hr3se2 : dicAsist("hr3se3") = hr3se3

            For Each kvp As KeyValuePair(Of String, Double) In dicAsist
                If kvp.Value > 0 Then
                    escribirArchivo = If({"hrs233", "hrs333"}.Contains(kvp.Key),
                                         strRlj & "," & kvp.Key.ToUpper & "," & kvp.Value,
                                         strRlj.ToString.Trim.PadLeft(6) & "," & kvp.Key.ToUpper & "," & String.Format("{0:0.00}", kvp.Value))

                    arreglo.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", strRlj}, {"concepto", kvp.Key.ToUpper}, {"descripcion", Nothing},
                                                                                    {"monto", kvp.Value}, {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                    {"usuario", Usuario}, {"datetime", Now}, {"fecha", Nothing},
                                                                                    {"cod_hora", Nothing}, {"factor", Nothing}}, "horasPro"))
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Falta checadas en funcion 'procesarHoras'
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="strQuerys"></param>
    ''' <remarks></remarks>
    Private Sub FaltaChecadasProcesarHrs(ByVal data As Dictionary(Of String, String), ByRef strQuerys As ArrayList, ByVal strReloj As String)
        Try
            '-- Info. faltas checadas
            Dim dtFaltasChecadas As New DataTable

            If data("tipoPeriodo") = "Q" Then
                dtFaltasChecadas = sqlExecute("SELECT a.RELOJ,p.nombres,p.cod_clase,a.FHA_ENT_HOR,a.COMENTARIO,p.cod_hora,p.sactual " &
                                              "FROM ASIST a " &
                                              "left join personal.dbo.personalvw p on a.reloj=p.reloj " &
                                              "WHERE a.COD_TIPO='A' AND a.FHA_ENT_HOR BETWEEN '" & FechaSQL(Me.period("fecha_ini_incidencia")) & "' AND '" & FechaSQL(Me.period("fecha_fin_incidencia")) & "' AND " &
                                              "(a.COMENTARIO LIKE '%ENTRADA%' or a.COMENTARIO LIKE '%SALIDA%') and " &
                                              "(A.comentario not like '%TRABAJO%' and A.comentario not like '%FESTIVO%' and A.comentario not like '%VACACION%') " &
                                              "order by reloj,fecha_entro", "TA")

                If dtFaltasChecadas.Rows.Count > 0 Then

                    For Each rlj In dtFaltasChecadas.Select("reloj='" & strReloj & "'")
                        Try
                            Dim fhaIncidencia = rlj("FHA_ENT_HOR")
                            Dim dtPer = sqlExecute("select top 1 reloj,cod_hora from personal.dbo.personal where reloj='" & rlj("reloj").ToString.Trim & "'")
                            Dim codHr = Nothing
                            If dtPer.Rows.Count > 0 Then codHr = dtPer.Rows(0)("cod_hora").ToString.Trim

                            Dim factEmp = ObtenerFactor(codHr,
                                                        ObtenerAnoPeriodo(fhaIncidencia, data("tipoPeriodo")).ToString.Substring(0, 4),
                                                        ObtenerAnoPeriodo(fhaIncidencia, data("tipoPeriodo")).ToString.Substring(4, 2))

                            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", strReloj}, {"concepto", "DIAFCH"}, {"descripcion", Nothing},
                                                                                           {"monto", 1}, {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                           {"usuario", Usuario}, {"datetime", Now}, {"fecha", fhaIncidencia}, {"cod_hora", Nothing},
                                                                                           {"factor", factEmp}}, "horasPro"))
                        Catch ex As Exception : End Try
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Comedores en funcion de 'procesarHoras'
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComedoresProcesarHrs(ByVal data As Dictionary(Of String, String), ByRef dRow As DataRow,
                                       ByRef dtpersona As DataTable, ByRef dDato As DataRow, ByRef strQuerys As ArrayList, ByVal dtComedor As DataTable)

        Try
            Dim temp = dtComedor.Select("reloj='" & dRow("reloj").ToString.Trim & "'")
            Dim strCon = {"CON_SUBSIDIO:DIACON", "SIN_SUBSIDIO:DIASIN", "SIN_SUBSIDIO_D:DIADES", "SIN_SUBSIDIO_D2:DIADE2"}

            If temp.Count > 0 Then
                Dim col = "", con = ""
                For Each x In strCon
                    col = x.Split(":")(0) : con = x.Split(":")(1)
                    If temp.First()(col) > 0 Then
                        strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", dDato("reloj").ToString.Trim}, {"concepto", con}, {"descripcion", Nothing},
                                                                                        {"monto", temp.First()(col)}, {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                        {"usuario", Usuario}, {"datetime", Now}, {"fecha", Nothing}, {"cod_hora", dtpersona.Rows(0)("cod_hora")},
                                                                                        {"factor", Nothing}}, "horasPro"))

                        dDato(con) = temp.First()(col)
                    End If
                Next
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Horas asistencias en funcion de 'procesarHoras'
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AsistenciasProcesarHrs(ByVal data As Dictionary(Of String, String), ByRef dRow As DataRow,
                                       ByRef dtpersona As DataTable, ByRef dDato As DataRow, ByRef strQuerys As ArrayList, ByVal dtHorasAsistencia As DataTable)

        Try
            Dim temp = dtHorasAsistencia.Select("reloj='" & dRow("reloj").ToString.Trim & "'")
            Dim hrs233 = 0.0, hrs333 = 0.0, val = 0.0

            If data("tipoPeriodo") = "Q" Then
                ConceptosHrsAsistQna(data, temp.CopyToDataTable, strQuerys)
            Else
                For Each i In temp
                    hrs233 = 0.0 : hrs333 = 0.0 : val = 0.0

                    Try : hrs233 = Math.Round(i("dobles_33"), 2) : hrs333 = Math.Round(i("triples_33"), 2)
                    Catch ex As Exception : End Try

                    For Each x In {"HRS233", "HRS333"}
                        val = If(x = "HRS233", hrs233, hrs333)

                        If val > 0 Then
                            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", dDato("reloj").ToString.Trim}, {"concepto", x}, {"descripcion", Nothing},
                                                                                            {"monto", val}, {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                            {"usuario", Usuario}, {"datetime", Now}, {"fecha", Nothing},
                                                                                            {"cod_hora", dtpersona.Rows(0)("cod_hora")}, {"factor", Nothing}}, "horasPro"))
                        End If
                    Next
                Next
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Ausentismos en funcion de 'procesarHoras'
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AusentismosProcesarHrs(ByVal data As Dictionary(Of String, String), ByRef dRow As DataRow,
                                       ByRef dtpersona As DataTable, ByRef dDato As DataRow, ByRef strQuerys As ArrayList, ByVal dtAusentismos As DataTable)
        Try
            Dim temp1 As DataTable = infoTabla("reloj='" & dRow("reloj").ToString.Trim & "' and tipo_aus in ('FI','C50','FES') and existe_asist>0", dtAusentismos)
            Dim fecha_hrs = Nothing
            Dim factor = Nothing

            If temp1.Rows.Count > 0 Then
                Dim strOp = ""

                For Each i In temp1.Rows

                    If dtpersona.Rows.Count > 0 Then
                        fecha_hrs = Me.period("fecha_ini")
                        ConsultaBitacora(dtpersona, dtpersona.Rows(0), fecha_hrs)
                        factor = ObtenerFactor(dtpersona.Rows(0)("cod_hora"), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(4, 2))
                    End If

                    Dim percepcion_aus = Not IsDBNull(i("percepcion"))
                    Dim deduccion_aus = Not IsDBNull(i("deduccion"))

                    strOp = If(percepcion_aus, "percepcion", If(deduccion_aus, "deduccion", "ERROR"))

                    strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", dDato("reloj").ToString.Trim}, {"concepto", If(strOp = "ERROR", "ERROR", i(strOp))}, {"descripcion", Nothing},
                                                                                    {"monto", 1}, {"periodo", data("periodo")}, {"ano", data("ano")}, {"usuario", Usuario},
                                                                                    {"datetime", Now}, {"fecha", i("fecha")}, {"cod_hora", dtpersona.Rows(0)("cod_hora")},
                                                                                    {"factor", factor}}, "horasPro"))

                    If strOp <> "ERROR" Then
                        If IsDBNull(dDato(i(strOp))) Then : dDato(i(strOp)) = 1
                        Else : dDato(i(strOp)) += 1 : End If
                    End If


                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Horas y primas sabatinas y dominicales en funcion de 'procesarHoras'
    ''' </summary>
    ''' <param name="oWrite"></param>
    ''' <remarks></remarks>
    Private Sub HorasPrimaSabatinasDominicalesProcesarHrs(ByVal data As Dictionary(Of String, String), ByRef dRow As DataRow,
                                                          ByRef dtpersona As DataTable, ByVal dDato As DataRow, ByRef strQuerys As ArrayList)
        Try
            Dim dtConcepto As DataTable = creaDt("concepto,monto,concepto_tabla", "String,Double,String")
            Dim fecha_hrs = Nothing
            Dim factor = Nothing

            dtConcepto.Rows.Add("HRSNOR", dRow("HRSNOR"), "HRSNOR")
            dtConcepto.Rows.Add("HORDOB", dRow("HORDOB"), "HRSEX2")
            dtConcepto.Rows.Add("HORTRI", dRow("HORTRI"), "HRSEX3")
            'dtConcepto.Rows.Add("PRIMA_DOM", dRow("PRIMA_DOM"), "DIADOM")
            'dtConcepto.Rows.Add("PRIMA_SAB", dRow("PRIMA_SAB"), "DIASAB")
            dtConcepto.Rows.Add("HRSFEL", dRow("HRSFEL"), "HRSFEL")
            dtConcepto.Rows.Add("HRS_RETARDO", dRow("HRS_RETARDO"), "HRSRET")
            dtConcepto.Rows.Add("HRS_NOPAG", dRow("HRS_NOPAG"), "HRSPSG")

            For Each x In dtConcepto.Rows
                If x("monto") > 0 And Not {"HRS_RETARDO", "HRS_NOPAG"}.Contains(x("concepto")) Then

                ElseIf x("monto") > 0 And {"HRS_RETARDO", "HRS_NOPAG"}.Contains(x("concepto")) Then
                    fecha_hrs = Me.period("fecha_ini")

                    If dtpersona.Rows.Count > 0 Then
                        fecha_hrs = Me.period("fecha_ini")
                        ConsultaBitacora(dtpersona, dtpersona.Rows(0), fecha_hrs)
                        factor = ObtenerFactor(dtpersona.Rows(0)("cod_hora"), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(4, 2))
                    End If

                End If

                If x("monto") > 0 Then
                    strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", dRow("reloj").ToString.Trim}, {"concepto", x("concepto_tabla")}, {"descripcion", Nothing},
                                                                                   {"monto", x("monto")}, {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                   {"usuario", Usuario}, {"datetime", Now}, {"fecha", If({"HRS_RETARDO", "HRS_NOPAG"}.Contains(x("concepto")), fecha_hrs, Nothing)},
                                                                                   {"cod_hora", dtpersona.Rows(0)("cod_hora")}, {"factor", Nothing}}, "horasPro"))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se llena una fila en el datatble para la info. del archivo de horas en la funcion 'procesarHoras'
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LlenarFilaArchivoHrs(ByRef data As Dictionary(Of String, String), ByRef rowInfo As DataRow, ByRef dtDatos As DataTable) As DataRow
        Try
            Dim dDato As DataRow
            dDato = dtDatos.NewRow
            dDato("reloj") = rowInfo("reloj")
            dDato("cod_tipo") = rowInfo("cod_tipo")
            dDato("cod_depto") = rowInfo("cod_depto")
            dDato("nombre_depto") = rowInfo("nombre_depto")
            dDato("cod_super") = rowInfo("cod_super")
            dDato("super") = rowInfo("super")
            dDato("NOMBRES") = IIf(IsDBNull(rowInfo("NOMBRES")), "", rowInfo("NOMBRES"))
            dDato("NOMBRE_AREA") = IIf(IsDBNull(rowInfo("NOMBRE_AREA")), "", rowInfo("NOMBRE_AREA"))

            If data("tipoPeriodo") = "S" Then
                dDato("HRSNOR") = Math.Round(IIf(IsDBNull(rowInfo("hrs_normales")), 0, rowInfo("hrs_normales")), 2)
                dDato("HRSFES") = Math.Round(IIf(IsDBNull(rowInfo("hrs_fel")), 0, rowInfo("hrs_fel")), 2)
                dDato("HRSFEL") = Math.Round(IIf(IsDBNull(rowInfo("hrs_fel")), 0, rowInfo("hrs_fel")), 2)
                dDato("HORDOB") = Math.Round(IIf(IsDBNull(rowInfo("hrs_dobles")), 0, rowInfo("hrs_dobles")), 2)
                dDato("HORTRI") = Math.Round(IIf(IsDBNull(rowInfo("hrs_triples")), 0, rowInfo("hrs_triples")), 2)
                dDato("HORDOM") = Math.Round(IIf(IsDBNull(rowInfo("hrs_prim_dom")), 0, rowInfo("hrs_prim_dom")), 2)
                dDato("DIVACA") = 0
                dDato("DIAGUI") = 0
                dDato("BONO01") = Math.Round(IIf(IsDBNull(rowInfo("bono01")), 0, rowInfo("bono01")), 2)
                dDato("BONO02") = Math.Round(IIf(IsDBNull(rowInfo("bono02")), 0, rowInfo("bono02")), 2)
                dDato("BONO03") = Math.Round(IIf(IsDBNull(rowInfo("bono03")), 0, rowInfo("bono03")), 2)
                dDato("BONO04") = Math.Round(IIf(IsDBNull(rowInfo("bono04")), 0, rowInfo("bono04")), 2)
                dDato("BONO05") = Math.Round(IIf(IsDBNull(rowInfo("bono05")), 0, rowInfo("bono05")), 2)
                dDato("bono06") = Math.Round(IIf(IsDBNull(rowInfo("bono06")), 0, rowInfo("bono06")), 2)
                dDato("bono07") = Math.Round(IIf(IsDBNull(rowInfo("bono07")), 0, rowInfo("bono07")), 2)
                dDato("bono08") = Math.Round(IIf(IsDBNull(rowInfo("bono08")), 0, rowInfo("bono08")), 2)
                dDato("bono09") = Math.Round(IIf(IsDBNull(rowInfo("bono09")), 0, rowInfo("bono09")), 2)
                dDato("bono10") = Math.Round(IIf(IsDBNull(rowInfo("bono10")), 0, rowInfo("bono10")), 2)
                dDato("DIAFI2") = 0
                dDato("PRIMA_DOM") = Math.Round(IIf(IsDBNull(rowInfo("PRIMA_DOM")), 0, rowInfo("PRIMA_DOM")), 2)
                dDato("PRIMA_SAB") = Math.Round(IIf(IsDBNull(rowInfo("PRIMA_SAB")), 0, rowInfo("PRIMA_SAB")), 2)
                dDato("HORDIN") = Math.Round(IIf(IsDBNull(rowInfo("dobles_33")), 0, rowInfo("dobles_33")), 2)
                dDato("HORTIN") = Math.Round(IIf(IsDBNull(rowInfo("triples_33")), 0, rowInfo("triples_33")), 2)
                dDato("DIASTR") = 0
                dDato("DIASCM") = 0
                dDato("HRS_NOPAG") = Math.Round(IIf(IsDBNull(rowInfo("HRS_NOPAG")), 0, rowInfo("HRS_NOPAG")), 2)
                dDato("HRS_RETARDO") = Math.Round(IIf(IsDBNull(rowInfo("HRS_RETARDO")), 0, rowInfo("HRS_RETARDO")), 2)
            Else
                Dim cols = {"HRSNOR", "HRSFES", "HRSFEL", "HORDOB", "HORTRI", "HORDOM", "DIVACA", "DIAGUI", "BONO01",
                            "BONO02", "BONO03", "BONO04", "BONO05", "bono06", "bono07", "bono08", "bono09", "bono10",
                            "DIAFI2", "PRIMA_DOM", "PRIMA_SAB", "HORDIN", "HORTIN", "DIASTR", "DIASCM", "HRS_NOPAG", "HRS_RETARDO"}

                For Each info In cols : dDato(info) = 0 : Next
            End If

            Return dDato

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Se crea el datatable para la info. del archivo de horas en la funcion 'procesarHoras'
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CrearDatatableArchivoHrs() As DataTable
        Try
            Dim dtDatos As New DataTable
            dtDatos.Columns.Add("grupo", GetType(System.String))
            dtDatos.Columns.Add("reloj", GetType(System.String))
            dtDatos.Columns.Add("cod_tipo", GetType(System.String))
            dtDatos.Columns.Add("cod_depto", GetType(System.String))
            dtDatos.Columns.Add("nombre_depto", GetType(System.String))
            dtDatos.Columns.Add("cod_super", GetType(System.String))
            dtDatos.Columns.Add("super", GetType(System.String))
            dtDatos.Columns.Add("HRSNOR", GetType(System.Double))
            dtDatos.Columns.Add("HRSFES", GetType(System.Double))
            dtDatos.Columns.Add("HRSFEL", GetType(System.Double))
            dtDatos.Columns.Add("HORDOB", GetType(System.Double))
            dtDatos.Columns.Add("HORTRI", GetType(System.Double))
            dtDatos.Columns.Add("HORDOM", GetType(System.Double))
            dtDatos.Columns.Add("DIVACA", GetType(System.Double))
            dtDatos.Columns.Add("DIAGUI", GetType(System.Double))
            dtDatos.Columns.Add("BONO01", GetType(System.Double))
            dtDatos.Columns.Add("BONO02", GetType(System.Double))
            dtDatos.Columns.Add("BONO03", GetType(System.Double))
            dtDatos.Columns.Add("BONO04", GetType(System.Double))
            dtDatos.Columns.Add("BONO05", GetType(System.Double))
            dtDatos.Columns.Add("BONO06", GetType(System.Double))
            dtDatos.Columns.Add("BONO07", GetType(System.Double))
            dtDatos.Columns.Add("BONO08", GetType(System.Double))
            dtDatos.Columns.Add("BONO09", GetType(System.Double))
            dtDatos.Columns.Add("BONO10", GetType(System.Double))
            dtDatos.Columns.Add("HORDIN", GetType(System.Double))
            dtDatos.Columns.Add("HORTIN", GetType(System.Double))
            dtDatos.Columns.Add("DIASTR", GetType(System.Double))
            dtDatos.Columns.Add("PRIMA_DOM", GetType(System.Double))
            dtDatos.Columns.Add("PRIMA_SAB", GetType(System.Double))
            dtDatos.Columns.Add("DIASCM", GetType(System.Double))
            dtDatos.Columns.Add("HRS_NOPAG", GetType(System.Double))
            dtDatos.Columns.Add("HRS_RETARDO", GetType(System.Double))
            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_AREA", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_CLERK", GetType(System.String))

            Dim conceptos = sqlExecute("SELECT DISTINCT percepcion, 'percepcion' AS type FROM tipo_ausentismo " &
                                       "WHERE percepcion IS NOT NULL UNION SELECT DISTINCT deduccion, 'deduccion' AS type FROM tipo_ausentismo where deduccion IS NOT NULL", "TA")

            Dim dttiposausper = (From i In conceptos Where i("type").ToString.Contains("percepcion")).ToList()
            Dim dttiposausded = (From i In conceptos Where i("type").ToString.Contains("deduccion")).ToList()

            For Each trowp As DataRow In dttiposausper : dtDatos.Columns.Add(Trim(trowp("percepcion")), GetType(System.Double)) : Next
            For Each trowd As DataRow In dttiposausded : dtDatos.Columns.Add(Trim(trowd("percepcion")), GetType(System.Double)) : Next

            dtDatos.Columns.Add("DIAFI2", GetType(System.Double))
            dtDatos.Columns.Add("DIACON", GetType(System.Double))
            dtDatos.Columns.Add("DIASIN", GetType(System.Double))
            dtDatos.Columns.Add("DIADES", GetType(System.Double))
            dtDatos.Columns.Add("DIADE2", GetType(System.Double))
            dtDatos.Columns.Add("ANO", GetType(System.String))
            dtDatos.Columns.Add("PERIODO", GetType(System.String))

            Return dtDatos

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Cargar horas al proceso
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <remarks></remarks>
    Private Sub CargarHoras(ByRef data As Dictionary(Of String, String))

        data("etapa") = "Cargando horas"
        Dim counter = 0
        Dim strQuerys As New ArrayList

        '*** En BRP QTO despues vamos a cargar el complemento de dias IVO
        Dim horas_c = Sqlite.getInstance.sqliteExecute("select reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAFES', 'DIAPGO', 'DIANAC', 'DIAFUN', 'DIAMAT', 'DIACOR') or " &
                                                       "(concepto='DIASVA' and origen<>'Finiquitos') GROUP BY reloj order by reloj asc")

        '-- Separar los dias festivos -- Ernesto -- 30 nov 2023
        Dim horas_fes = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM horasPro WHERE concepto in ('DIAFES') GROUP BY reloj order by reloj asc")
        Dim incapacidades_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAIMA', 'DIAING', 'DIAITR') GROUP BY reloj order by reloj asc")
        Dim faltas_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM horasPro WHERE concepto in ('DIAFIN','DIAFJU','DIAPSG') GROUP BY reloj order by reloj asc")
        Dim vacaciones_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIASVA') GROUP BY reloj order by reloj asc")
        Dim permisos_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAPGO') GROUP BY reloj order by reloj asc")
        Dim nominaPro = Sqlite.getInstance.sqliteExecute("SELECT reloj,alta,baja,incapacidad,faltas,vacaciones,permiso,cod_hora FROM nominaPro ")

        For Each employ In nominaPro.Rows
            Try
                Dim _desde = Convert.ToDateTime(Me.period("fecha_ini"))
                Dim _hasta = Convert.ToDateTime(Me.period("fecha_fin"))
                Dim _altaEmp As New Date

                If Not IsDBNull(employ("alta")) Then : _altaEmp = FechaSQL(employ("alta")) : _desde = IIf(_altaEmp > _desde, _altaEmp, _desde) : End If                                                                           'store iif(nomina_pro.alta>_desde,nomina_pro.alta,_desde) to _desde
                If Not IsDBNull(employ("baja")) Then : _hasta = IIf(Convert.ToDateTime(Me.period("fecha_fin")) >= Convert.ToDateTime(employ("baja")) And
                                                                    Convert.ToDateTime(Me.period("fecha_ini")) <= Convert.ToDateTime(employ("baja")),
                                                                    Convert.ToDateTime(employ("baja")), _hasta) : End If                                                                                                            'store iif(between(nomina_pro.baja,_fecha_ini,_fecha_fin) and !empty(baja),nomina_pro.baja,_hasta) to _hasta

                Dim _dias_nor = DateDiff(DateInterval.Day, Convert.ToDateTime(_desde), Convert.ToDateTime(_hasta)) + 1

                '-- Variables de faltas,permisos,incapacidad,etc
                Dim fes_employ = horas_fes.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim horas_employ = horas_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim incapacidad_employ = incapacidades_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim faltas_employ = faltas_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim vacaciones_employ = vacaciones_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim permisos_employ = permisos_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")

                '-- Separar los dias festivos -- Ernesto -- 30 nov 2023
                If fes_employ.Count > 0 Then : _dias_nor -= fes_employ.First.Item("monto") : End If

                '-- Condicion siempre y cuando no sean finiquitos [21 abril 2023. Se descuenta a DIANOR - 'DIAFES', 'DIAPGO', 'DIANAC', 'DIASVA', 'DIAFUN', 'DIAMAT', 'DIACOR' independientemente si es finiquito o no
                If horas_employ.Count > 0 Then : _dias_nor -= horas_employ.First.Item("monto") : End If
                If Not IsDBNull(employ("baja")) Then : _dias_nor = IIf(Convert.ToDateTime(employ("baja")) < Convert.ToDateTime(Me.period("fecha_ini")), 0, _dias_nor) : End If

                If _dias_nor > 0 Then
                    strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", employ("reloj").ToString.Trim}, {"concepto", "DIANOR"},
                                                                                    {"descripcion", Nothing}, {"monto", _dias_nor},
                                                                                    {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                    {"usuario", Usuario}, {"datetime", Now()},
                                                                                    {"fecha", Nothing}, {"cod_hora", employ("cod_hora")},
                                                                                    {"factor", 1}}, "horasPro"))
                End If

                '*** En BRP QTO no debemos pagar nada cuando el empleado esta incapacitado IVO
                employ("incapacidad") = 0 : employ("faltas") = 0 : employ("vacaciones") = 0 : employ("permiso") = 0
                If incapacidad_employ.Count > 0 Then employ("incapacidad") = incapacidad_employ.First.Item("monto")
                If faltas_employ.Count > 0 Then employ("faltas") = faltas_employ.First.Item("monto")
                If vacaciones_employ.Count > 0 Then employ("vacaciones") = vacaciones_employ.First.Item("monto")
                If permisos_employ.Count > 0 Then employ("permiso") = permisos_employ.First.Item("monto")

                '-- Actualizar campo de incapacidad y faltas en nominaPro
                strQuerys.Add("UPDATE nominaPro set incapacidad='" & employ("incapacidad").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "';")
                strQuerys.Add("UPDATE nominaPro set faltas='" & employ("faltas").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "';")

                If employ("incapacidad") + employ("faltas") + employ("vacaciones") + employ("permiso") > 7 Then : Me.addLog("El empleado " & employ("reloj") & " tiene mas de 7 dias de incapacidad+faltas+vacaciones+permisos") : End If
                If employ("incapacidad") > 0 AndAlso _dias_nor < employ("incapacidad") Then Me.addLog("El empleado " & employ("reloj") & " tiene " & employ("incapacidad") & " dia(s) de incapacidad y " & _dias_nor & " dia(s) normal(es)")
                If employ("faltas") > 0 AndAlso _dias_nor < employ("faltas") Then Me.addLog("El empleado " & employ("reloj") & " tiene " & employ("faltas") & " dia(s) de faltas y " & _dias_nor & " dia(s) normal(es)")

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / Me.NominaPro.Rows.Count) : counter += 1 : End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Next

        '-- Agregar inserts a horasPro
        GuardaMovimientosTabla("Cargando horas: Guardando", data, strQuerys)
        Sqlite.getInstance.sqliteExecute("DELETE FROM horasPro WHERE reloj IN (SELECT reloj FROM finiquitosE)")

    End Sub


    ''' <summary>
    ''' Carga de horas al proceso
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub CargarHorasSem(ByRef data As Dictionary(Of String, String))
        Try
            data("etapa") = "Cargando horas"
            Dim counter = 0
            Dim strQuerys As New ArrayList

            '-- Dias normales obtenidos de nomsem
            Dim dtDianor = sqlExecute("select ano,periodo,reloj,BONO06 from ta.dbo.nomsem where ano+periodo='" & data("ano") & data("periodo") & "'")

            '-- Query que calcula los dias normales, asi como incapacidades, faltas, vacaciones
            Dim strQry = "WITH horas_c as (select reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in " &
                         "('DIAFES', 'DIAPGO', 'DIANAC', 'DIAFUN', 'DIAMAT', 'DIACOR') or (concepto='DIASVA' and origen<>'Finiquitos') GROUP BY reloj)," &
                         "horas_fes as (SELECT reloj,sum(monto) as monto FROM horasPro WHERE concepto in ('DIAFES') GROUP BY reloj)," &
                         "incapacidades_c as (SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAIMA', 'DIAING', 'DIAITR') GROUP BY reloj)," &
                         "faltas_c as (SELECT reloj,sum(monto) as monto FROM horasPro WHERE concepto in ('DIAFIN','DIAFJU','DIAPSG') GROUP BY reloj)," &
                         "vacaciones_c as (SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIASVA') GROUP BY reloj)," &
                         "permisos_c as (SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAPGO') GROUP BY reloj)," &
                         "nomina as (SELECT reloj,alta,baja,incapacidad,faltas,vacaciones,permiso,cod_hora,'' as a FROM nominaPro)," &
                         "periodo as (SELECT '" & Me.period("fecha_ini") & "' as desde,'" & Me.period("fecha_fin") & "' as hasta,'' as a)," &
                         "altasbajas as (" &
                         "select nomina.reloj,nomina.alta,nomina.baja,periodo.desde as fha_ini," &
                         "(case when date(alta)>date(periodo.desde) then date(alta) else date(periodo.desde) end) as desde," &
                         "(case when (date(periodo.hasta)>=date(nomina.baja) and date(periodo.desde)<=date(nomina.baja)) then nomina.baja else periodo.hasta end) as hasta " &
                         "from nomina left join periodo on periodo.a=nomina.a)," &
                         "dias as (" &
                         "select reloj,baja,desde,hasta,fha_ini,(JULIANDAY(hasta)-JULIANDAY(desde)+1) as dianor," &
                         "ifnull((select monto from horas_fes where reloj=altasbajas.reloj),0) as fes_employ," &
                         "ifnull((select monto from horas_c where reloj=altasbajas.reloj),0) as horas_employ," &
                         "ifnull((select monto from incapacidades_c where reloj=altasbajas.reloj),0) as incapacidad_employ," &
                         "ifnull((select monto from faltas_c where reloj=altasbajas.reloj),0) as faltas_employ," &
                         "ifnull((select monto from vacaciones_c where reloj=altasbajas.reloj),0) as vacaciones_employ," &
                         "ifnull((select monto from permisos_c where reloj=altasbajas.reloj),0) as permisos_employ " &
                         " from altasbajas)" &
                         "" &
                         "select reloj,baja,IFNULL((date(baja)<date(fha_ini)),0) as baja_menor_per," &
                         "(dianor-IFNULL(horas_employ,0)-IFNULL(fes_employ,0)) as dianor_total," &
                         "(case when IFNULL(incapacidad_employ,0)>0 then 'update nominapro set incapacidad='''|| cast(incapacidad_employ as integer) ||''' where reloj='''|| reloj ||''';' else '' end) as update_incap," &
                         "(case when IFNULL(faltas_employ,0)>0 then 'update nominapro set faltas='''|| cast(faltas_employ as integer) ||''' where reloj='''|| reloj ||''';' else '' end) as update_faltas," &
                         "incapacidad_employ,faltas_employ,vacaciones_employ,permisos_employ " &
                         "from dias	order by baja_menor_per desc"

            Dim dtInfo = Sqlite.getInstance.sqliteExecute(strQry)
            Dim _dias_nor = 0
            Dim _incapacidad = 0
            Dim _faltas = 0
            Dim _vacaciones = 0
            Dim _permiso = 0
            Dim strAviso As New ArrayList
            Dim strAvisoLog = ""

            If dtInfo.Rows.Count > 0 Then

                For Each x In dtInfo.Rows

                    strAvisoLog = ""
                    strAviso.Clear()

                    If dtInfo.Select("reloj='" & x("reloj").ToString.Trim & "'").Count > 0 Then
                        Try : _dias_nor = dtDianor.Select("reloj='" & x("reloj").ToString.Trim & "'").First.Item("BONO06") : Catch ex As Exception : End Try
                    Else
                        _dias_nor = 0
                    End If

                    '-- Días normales de acuerdo a su baja. Si la baja es menor a la fecha de inicio entonces DIANOR=0
                    'If x("baja_menor_per") > 0 Then _dias_nor = 0 Else _dias_nor = x("dianor_total")

                    '-- Días normales
                    If _dias_nor > 0 Then
                        strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", x("reloj").ToString.Trim}, {"concepto", "DIANOR"},
                                                                                        {"descripcion", Nothing}, {"monto", _dias_nor},
                                                                                        {"periodo", data("periodo")}, {"ano", data("ano")},
                                                                                        {"usuario", Usuario}, {"datetime", Now()},
                                                                                        {"fecha", Nothing}, {"cod_hora", Nothing},
                                                                                        {"factor", 1}}, "horasPro"))
                    End If

                    '-- Incapacidades y faltas
                    For Each col In {"update_incap", "update_faltas"}
                        If x(col).ToString.Length > 0 Then strQuerys.Add(x(col))
                    Next

                    '-- Dias incapacidad, faltas, vacaciones, permiso
                    _incapacidad = x("incapacidad_employ")
                    _faltas = x("faltas_employ")
                    _vacaciones = x("vacaciones_employ")
                    _permiso = x("permisos_employ")

                    '-- Más de 7 días
                    If _incapacidad + _faltas + _vacaciones + _permiso > 7 Then
                        If _incapacidad > 0 Then strAviso.Add("incapacidad+")
                        If _faltas > 0 Then strAviso.Add("faltas+")
                        If _vacaciones > 0 Then strAviso.Add("vacaciones+")
                        If _permiso > 0 Then strAviso.Add("permiso+")
                        strAvisoLog = String.Join("", From i In strAviso Select i)

                        Me.addLog("El empleado " & x("reloj") & " tiene mas de 7 dias de " & strAvisoLog.ToString.Substring(0, strAvisoLog.Length - 1))
                    End If

                    If _incapacidad > 0 AndAlso _dias_nor < _incapacidad Then Me.addLog("El empleado " & x("reloj") & " tiene " & _incapacidad & " dia(s) de incapacidad y " & _dias_nor & " dia(s) normal(es)")
                    If _faltas > 0 AndAlso _dias_nor < _faltas Then Me.addLog("El empleado " & x("reloj") & " tiene " & _faltas & " dia(s) de faltas y " & _dias_nor & " dia(s) normal(es)")
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / Me.NominaPro.Rows.Count) : counter += 1 : End If
                Next

                '-- Agregar inserts a horasPro
                GuardaMovimientosTabla("Cargando horas: Guardando", data, strQuerys)
                Sqlite.getInstance.sqliteExecute("DELETE FROM horasPro WHERE reloj IN (SELECT reloj FROM finiquitosE)")
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Cargar los dias normales de periodo quincenal -- Ernesto -- 22 ene 2024
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub CargarHorasQna(ByRef data As Dictionary(Of String, String))
        Try
            data("etapa") = "Cargando horas"

            Dim strQuerys As New ArrayList
            Dim _dias_adicionales = 0
            Dim _dias_nor = 0
            Dim _dia_fin = 0
            Dim counter = 0
            Dim baja = Nothing
            Dim alta = Nothing
            Dim desde = Nothing
            Dim hasta = Nothing
            Dim fha_ini = Convert.ToDateTime(Me.period("fecha_ini"))
            Dim fha_fin = Convert.ToDateTime(Me.period("fecha_fin"))
            Dim fha_corte = Convert.ToDateTime(Me.period("fecha_corte_ant"))
            Dim dias_ajuste = 0
            Dim dias_horas = 0

            Dim dtInc As New DataTable
            Dim dtFaltas As New DataTable
            Dim dtVac As New DataTable
            Dim dtPermiso As New DataTable

            Dim incapacidades_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAIMA', 'DIAING', 'DIAITR') GROUP BY reloj order by reloj asc")
            Dim faltas_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM horasPro WHERE concepto in ('DIAFIN','DIAFJU','DIAPSG') GROUP BY reloj order by reloj asc")
            Dim vacaciones_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIASVA') GROUP BY reloj order by reloj asc")
            Dim permisos_c = Sqlite.getInstance.sqliteExecute("SELECT reloj,sum(monto) as monto FROM ajustesPro WHERE concepto in ('DIAPGO') GROUP BY reloj order by reloj asc")

            Dim nominaPro = Sqlite.getInstance.sqliteExecute("SELECT reloj,alta,baja,incapacidad,faltas,vacaciones,permiso,cod_hora FROM nominaPro ")
            Dim ajustes_c = Sqlite.getInstance.sqliteExecute("select reloj,sum(monto) as monto FROM ajustesPro " &
                                                             "WHERE concepto in ('DIAFES','DIAPGO','DIANAC','DIASVA','DIAFUN','DIAMAT','DIACOR','DIALIC','DIAMED') GROUP BY reloj order by reloj asc")
            Dim horas_c = Sqlite.getInstance.sqliteExecute("select reloj,sum(monto) as monto FROM horasPro " &
                                                           "WHERE concepto in ('DIAFES','DIAPGO','DIANAC','DIASVA','DIAFUN','DIAMAT','DIACOR','DIALIC','DIAMED') GROUP BY reloj order by reloj asc")

            For Each employ In nominaPro.Rows
                Try
                    baja = Nothing : alta = Nothing
                    _dias_adicionales = 0 : _dias_nor = 0 : _dia_fin = 0
                    dias_ajuste = 0 : dias_horas = 0
                    dtInc.Rows.Clear()
                    dtFaltas.Rows.Clear()
                    dtVac.Rows.Clear()
                    dtPermiso.Rows.Clear()

                    If Not IsDBNull(employ("baja")) Then baja = Convert.ToDateTime(employ("baja"))
                    If Not IsDBNull(employ("alta")) Then alta = Convert.ToDateTime(employ("alta"))

                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", ajustes_c).Rows.Count > 0 Then dias_ajuste = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", ajustes_c).Rows(0)("monto")
                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", horas_c).Rows.Count > 0 Then dias_horas = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", horas_c).Rows(0)("monto")
                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", incapacidades_c).Rows.Count > 0 Then dtInc = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", incapacidades_c)
                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", faltas_c).Rows.Count > 0 Then dtFaltas = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", faltas_c)
                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", vacaciones_c).Rows.Count > 0 Then dtVac = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", vacaciones_c)
                    If infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", permisos_c).Rows.Count > 0 Then dtPermiso = infoTabla("reloj='" & employ("reloj").ToString.Trim & "'", permisos_c)

                    If IsDBNull(employ("baja")) Or (Not IsDBNull(employ("baja")) AndAlso (baja > fha_fin)) Then

                        If CInt(data("periodo")) <= 24 And (alta >= fha_corte.AddDays(1) And alta <= fha_ini.AddDays(-1)) Then

                            _dia_fin = If(fha_ini.AddDays(-1).Day > 30,
                                          30,
                                          fha_ini.AddDays(-1).Day)

                            _dias_adicionales = (_dia_fin - alta.Day) + 1
                        End If

                        desde = fha_ini
                        hasta = fha_fin

                        desde = If(alta > desde, alta, desde)
                        hasta = If(IsDBNull(employ("baja")), hasta, If(baja >= fha_ini And baja <= fha_fin, baja, hasta))

                        If desde = fha_ini And hasta = fha_fin Then
                            _dias_nor = 15
                        Else
                            _dias_nor = DateDiff(DateInterval.Day, desde, hasta) + 1

                            If hasta.Day = 31 Then
                                _dias_nor = _dias_nor - 1
                            End If
                        End If

                        If infoTabla("reloj='" & employ("reloj") & "'", ajustes_c).Rows.Count > 0 Then _dias_nor -= dias_ajuste
                        If infoTabla("reloj='" & employ("reloj") & "'", horas_c).Rows.Count > 0 Then _dias_nor -= dias_horas

                        _dias_nor += _dias_adicionales

                        '-- Actualizar campo de incapacidad y faltas en nominaPro
                        employ("incapacidad") = 0 : employ("faltas") = 0 : employ("vacaciones") = 0 : employ("permiso") = 0
                        If dtInc.Rows.Count > 0 Then employ("incapacidad") = dtInc.Rows(0)("monto")
                        If dtFaltas.Rows.Count > 0 Then employ("faltas") = dtFaltas.Rows(0)("monto")
                        If dtVac.Rows.Count > 0 Then employ("vacaciones") = dtVac.Rows(0)("monto")
                        If dtPermiso.Rows.Count > 0 Then employ("permiso") = dtPermiso.Rows(0)("monto")

                        strQuerys.Add("UPDATE nominaPro set incapacidad='" & employ("incapacidad").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "';")
                        strQuerys.Add("UPDATE nominaPro set faltas='" & employ("faltas").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "';")

                        If employ("incapacidad") + employ("faltas") + employ("vacaciones") + employ("permiso") > 15 Then : Me.addLog("El empleado " & employ("reloj") & " tiene mas de 15 dias de incapacidad+faltas+vacaciones+permisos") : End If
                        If employ("incapacidad") > 0 AndAlso _dias_nor < employ("incapacidad") Then Me.addLog("El empleado " & employ("reloj") & " tiene " & employ("incapacidad") & " dia(s) de incapacidad y " & _dias_nor & " dia(s) normal(es)")
                        If employ("faltas") > 0 AndAlso _dias_nor < employ("faltas") Then Me.addLog("El empleado " & employ("reloj") & " tiene " & employ("faltas") & " dia(s) de faltas y " & _dias_nor & " dia(s) normal(es)")

                        If _dias_nor > 0 Then
                            strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", employ("reloj").ToString.Trim}, {"concepto", "DIANOR"}, {"descripcion", Nothing}, {"monto", _dias_nor},
                                                                                            {"periodo", data("periodo")}, {"ano", data("ano")}, {"usuario", Usuario}, {"datetime", Now()},
                                                                                            {"fecha", Nothing}, {"cod_hora", employ("cod_hora")}, {"factor", 1}}, "horasPro"))
                        End If
                    End If

                Catch ex As Exception
                    Me.addLog("Error en cargar de horas para empleado " & employ("reloj").ToString.Trim)
                End Try

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / Me.NominaPro.Rows.Count) : counter += 1 : End If
            Next

            '-- Agregar inserts a horasPro
            GuardaMovimientosTabla("Cargando horas: Guardando", data, strQuerys)
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' Función para calcular los conceptos de finiquitos -- Ernesto
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Shared Sub ConceptosFiniquitosNormales(ByRef data As Dictionary(Of String, String), Optional relojManual As String = "", Optional seCalculoAguiAnual As Boolean = False)
        Try
            '==PRUEBAS
            Dim filtroAno = ""
            Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "')", "")
            If CInt(data("periodo")) = 1 Then filtroAno = data("ano") & "','" & CInt(data("ano")) - 1 Else filtroAno = data("ano")

            'Dim vacFin = Sqlite.getInstance.sqliteExecute("SELECT * FROM finiquitosN " & String.Format(filtroIngresoManual, "where"))
            Dim vacFin = sqlExecute("select reloj,dias_agui,dias_vac from personal.dbo.personal " & String.Format(filtroIngresoManual, "where"))

            Dim nomPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro WHERE baja is not null and finiquito='True' and finiquito_esp='False' " & String.Format(filtroIngresoManual, "and"))
            Dim ajustPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro " & String.Format(filtroIngresoManual, "where"))
            Dim conceptosPro = sqlExecute("SELECT * FROM nomina.dbo.conceptos WHERE finiquito=1")

            If nomPro.Rows.Count = 0 Then Exit Sub
            Dim periodosInfo = Nothing

            '== Revisar si inicia fondo de ahorro [19 junio 2023]
            Dim inicia_fondo = False
            Try : inicia_fondo = sqlExecute("SELECT inicia_fondo FROM ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " WHERE ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and inicia_fondo='1'").Rows.Count > 0
            Catch ex As Exception : inicia_fondo = False : End Try

            Dim relojes = (From i In nomPro.Rows Select i("reloj").ToString.Trim).ToList()
            Dim vacDatos = sqlExecute("SELECT * FROM PERSONAL.dbo.vacaciones")
            Dim movs As New DataTable

            If data("periodo") <> "01" Then
                movs = sqlExecute("SELECT * FROM NOMINA.dbo.movimientos WHERE concepto IN ('SAFAHE','SAFAHC','SALPRF','SAANAG') AND periodo<='53' and periodo<'" & data("periodo") & "' " &
                                  "AND ano IN ('" & filtroAno & "') and reloj in (" & String.Join(",", (From i In relojes Select "'" & i & "'")) & ") " &
                                  "ORDER BY ano+periodo desc")
            Else
                movs = sqlExecute("SELECT * FROM NOMINA.dbo.movimientos WHERE concepto IN ('SAFAHE','SAFAHC','SALPRF','SAANAG') AND periodo IN (53,24) " &
                                  "AND ano IN ('" & filtroAno & "') and reloj in (" & String.Join(",", (From i In relojes Select "'" & i & "'")) & ") " &
                                  "ORDER BY ano+periodo desc")
            End If


            Dim mtroDed = sqlExecute("SELECT * FROM NOMINA.dbo.mtro_ded WHERE activo=1 and " &
                                     "(concepto in ('FNAALC','TIENDA','ADEIN1','ADEIN2','ADEIN3','ADEIN4','ADEIN5','ADEIN6','ADEINX','TIEN01','TIEN02'," &
                                     "'TIEN03','TIEN04','TIEN05','TIEN06','TIEN07','TIEN08','TIEN09','TIEN10','TIEN11','TIEN12','TIEN13','TIEN14','TIEN15'," &
                                     "'RECFNT','ISRACA','DESINF','CHEKUP','SEGDEN','SEGVIS','EXVIDA','SEGMAS','DPMISR') OR " &
                                     "SUBSTRING(concepto,1,4)='PSUB') " & "and reloj in (" & String.Join(",", (From i In relojes Select "'" & i & "'")) & ") ")


            For Each emp In nomPro.Rows

                If emp("cod_tipo") = "A" Then
                    If data("periodo") <> "01" Then
                        periodosInfo = sqlExecute("SELECT TOP 1 S.ANO,S.PERIODO,S.FECHA_INI,S.FECHA_FIN," &
                                                  "(SELECT Q.ANO+Q.PERIODO FROM TA.DBO.periodos_quincenal Q WHERE S.FECHA_INI BETWEEN Q.FECHA_INI AND Q.FECHA_FIN AND Q.PERIODO<=24) as 'QUINCENAL' " &
                                                  "FROM TA.DBO.periodos S WHERE S.ANO='" & data("ano") & "' AND S.PERIODO=" & data("periodo") & " ORDER BY ANO,PERIODO DESC")
                    Else
                        periodosInfo = sqlExecute("SELECT S.ANO,S.PERIODO,S.FECHA_INI,S.FECHA_FIN," &
                                                  "(SELECT Q.ANO+Q.PERIODO FROM TA.DBO.periodos_quincenal Q WHERE S.FECHA_INI BETWEEN Q.FECHA_INI AND Q.FECHA_FIN AND Q.PERIODO<=24) as 'QUINCENAL' " &
                                                  "FROM TA.DBO.periodos S WHERE S.ANO=" & CInt(data("ano")) - 1 & " AND S.PERIODO=53 ORDER BY ANO,PERIODO DESC")
                    End If
                End If

                '==================================== Vacaciones 
                For Each rvac In vacFin.Select("reloj='" & emp("reloj").Trim & "'")
                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                       {"periodo", data("periodo")},
                                                                                       {"reloj", rvac("reloj")},
                                                                                       {"per_ded", "P"},
                                                                                       {"concepto", "DIASVA"},
                                                                                       {"descripcion", ""},
                                                                                       {"monto", If(IsDBNull(rvac("dias_vac")), 0, rvac("dias_vac"))},
                                                                                       {"clave", Nothing},
                                                                                       {"origen", IIf(relojManual = "", "Finiquitos", "MiscelaneoCRUDFiniquito")},
                                                                                       {"usuario", Usuario},
                                                                                       {"datetime", Now},
                                                                                       {"afecta_vac", False},
                                                                                       {"factor", emp("factor_dias")},
                                                                                       {"fecha", Nothing},
                                                                                       {"sueldo", 0},
                                                                                       {"fecha_fox", Nothing},
                                                                                       {"per_aplica", Nothing},
                                                                                       {"ano_aplica", Nothing},
                                                                                       {"saldo", 0}}, "ajustesPro")
                Next

                '==================================== Prima vacacional
                Dim _alta As Date = Convert.ToDateTime(emp("alta"))
                Dim _baja As Date = Convert.ToDateTime(emp("baja"))
                Dim _altaAntig As Date = Convert.ToDateTime(emp("alta_antig"))

                Dim _aniversario_antig As DateTime = New DateTime(_baja.Year, _altaAntig.Month, _altaAntig.Day)               'FOX: store ctod(str(year(nomina_pro.baja))+substr(dtoc(nomina_pro.alta_antig),5,6)) to _aniversario_antig
                Dim _aniversario As DateTime = New DateTime(_baja.Year, _alta.Month, _alta.Day)                               'FOX: store ctod(str(year(nomina_pro.baja))+substr(dtoc(nomina_pro.alta),5,6)) to _aniversario
                Dim _anos = 0

                If _aniversario_antig > _baja Then _aniversario_antig = _aniversario_antig.AddMonths(-12)
                If _aniversario > _baja Then _aniversario = _aniversario.AddMonths(-12)
                _anos = Year(_aniversario_antig) - Year(_altaAntig) + 1                                                                                       'Fox: store year(_aniversario_antig)-year(nomina_pro.alta_antig)+1 to _anos

                For Each rVac In vacDatos.Select("cod_comp='" & emp("cod_comp").Trim & "' and cod_tipo='" & emp("cod_tipo").Trim & "' and anos='" & Str(_anos) & "'")     'Fox: seek nomina_pro.cod_comp+nomina_pro.cod_tipo+STR(_anos,2,0)


                    '-- Dias y porcentaje de prima vacacional que trae el empleado en nominapro -- Ernesto -- 13 julio 2023
                    Dim nomPrivacDias = 0.0, nomPrivacPor = 0
                    Try : nomPrivacDias = emp("privac_dias") : Catch ex As Exception : nomPrivacDias = 0.0 : End Try
                    Try : nomPrivacPor = emp("privac_porc") : Catch ex As Exception : nomPrivacPor = 0 : End Try

                    'FOX: replace nomina_pro.privac_porc with vac.por_prima

                    '-- Si tiene porcentaje en porcentaje, respetarlo como esta -- Ernesto -- 13 julio 2023
                    If nomPrivacPor = 0 Then
                        Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE nominaPro SET privac_porc='" & rVac("por_prima") & "' WHERE " & _
                                                                            "reloj='" & emp("reloj").Trim & "' AND " & _
                                                                            "ano='" & data("ano").Trim & "' AND " & _
                                                                            "periodo='" & data("periodo").Trim & "' AND " & _
                                                                            "baja is not null AND " & _
                                                                            "finiquito='True' AND " & _
                                                                            "finiquito_esp='False'")
                    End If

                    Dim _privacDias = 0D
                    Dim _decRes = 0D
                    If ((DateDiff(DateInterval.Day, _altaAntig, _baja) + 1) / 365) <= 1 Then
                        _privacDias = CInt(rVac("dias")) / 365 * (DateDiff(DateInterval.Day, _alta, _baja) + 1)
                    Else
                        _privacDias = CInt(rVac("dias")) / 365 * (DateDiff(DateInterval.Day, _aniversario_antig, _baja) + 1)
                    End If

                    _privacDias = Math.Round(_privacDias, 2)

                    '-- Los dias de prima vacacional se le suman al nuevo cálculo de los mismos -- Ernesto -- 13 julio 2023
                    Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE nominaPro SET privac_dias='" & Math.Round(_privacDias + nomPrivacDias, 2) & "' WHERE " & _
                                                     "reloj='" & emp("reloj").Trim & "' AND " & _
                                                     "ano='" & data("ano").Trim & "' AND " & _
                                                     "periodo='" & data("periodo").Trim & "' AND " & _
                                                     "finiquito='True' AND " & _
                                                     "finiquito_esp='False'")
                Next

                '==================================== Aguinaldo
                '-- Checar que existe el concepto de "DIASAG" y el finiquito en si en la tabla de nomina_calculo (Duda si se toma en cuenta la baja de la tabla de finiquitos o en la baja de nomina_pro)
                If conceptosPro.Select("concepto='DIASAG'").Count > 0 Then
                    Try
                        '-- Dias aguinaldo provenientes de la tabla de personal
                        Dim dtDiasAg = vacFin.Select("reloj='" & emp("reloj").Trim & "'")
                        If dtDiasAg.Count > 0 Then
                            Dim dblDiasAg = vacFin.Select("reloj='" & emp("reloj").Trim & "'").First.Item("dias_agui")

                            '== Inserta DIASAG en ajustesPro [Verificar primero si ya existe el concepto en ajustesPro, si si, entonces actualizar el valor]
                            If ajustPro.Select("reloj='" & emp("reloj").Trim & "' and concepto='DIASAG'").Count > 0 Then
                                Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE ajustesPro SET monto='" & If(IsDBNull(dblDiasAg), 0, dblDiasAg) & "' WHERE reloj='" & emp("reloj").Trim & "' and concepto='DIASAG'")
                            Else
                                Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                                    {"periodo", data("periodo")},
                                                                                                    {"reloj", emp("reloj").Trim},
                                                                                                    {"per_ded", "P"},
                                                                                                    {"concepto", "DIASAG"},
                                                                                                    {"descripcion", ""},
                                                                                                    {"monto", If(IsDBNull(dblDiasAg), 0, dblDiasAg)},
                                                                                                    {"clave", Nothing},
                                                                                                    {"origen", IIf(relojManual = "", "Finiquitos", "MiscelaneoCRUDFiniquito")},
                                                                                                    {"usuario", Usuario},
                                                                                                    {"datetime", Now},
                                                                                                    {"afecta_vac", False},
                                                                                                    {"factor", emp("factor_dias")},
                                                                                                    {"fecha", Nothing},
                                                                                                    {"sueldo", 0},
                                                                                                    {"fecha_fox", Nothing},
                                                                                                    {"per_aplica", data("periodo")},
                                                                                                    {"ano_aplica", data("ano")},
                                                                                                    {"saldo", 0}}, "ajustesPro")
                            End If
                        End If

                    Catch ex As Exception : End Try
                End If

                Dim _conceptos = {"SAFAHE:LIFAHE", "SAFAHC:LIFAHC", "SALPRF:RETIRO", "SAANAG:SAANAG"}

                For Each con In _conceptos
                    Dim _perMax = Nothing
                    Dim _monto = Nothing : Dim _montoValor = 0.0
                    Dim _filtro = ""

                    If con.Substring(0, 6) = "SAFAHE" Or con.Substring(0, 6) = "SAANAG" Or con.Substring(0, 6) = "SAFAHC" Or con.Substring(0, 6) = "SALPRF" Then

                        '-- Validacion de aguinaldo. Si ya se pago aguinaldo anual ya no incluir SAANAG
                        If con.Substring(0, 6) = "SAANAG" And seCalculoAguiAnual Then
                            Continue For
                        End If

                        '== Si es administrativo
                        If emp("cod_tipo") = "A" Then
                            _filtro = "reloj='" & emp("reloj").Trim & "' and concepto in ('" & con.Substring(0, 6) & "') and " & "ano+periodo='" & periodosInfo.rows(0)("quincenal") & "' and tipo_periodo='Q'"
                            _perMax = movs.Select(_filtro, "periodo desc")
                        Else
                            '== Si no es el primer periodo del año
                            If data("periodo") <> "01" Then
                                Try
                                    _filtro = "reloj='" & emp("reloj").Trim & "' and concepto in ('" & con.Substring(0, 6) & "') and periodo=" & CInt(data("periodo")) - 1 & " and ano='" & data("ano") & "' and tipo_periodo='S'"
                                    _perMax = movs.Select(_filtro, "periodo desc")
                                Catch ex As Exception : _perMax = Nothing : End Try
                            Else
                                Try
                                    _filtro = "reloj='" & emp("reloj").Trim & "' and concepto in ('" & con.Substring(0, 6) & "') and " &
                                        "periodo='" & IIf(data("tipoPeriodo") = "S", 53, 24) & "' and ano='" & CInt(data("ano")) - 1 & "' and tipo_periodo='S'"

                                    _perMax = movs.Select(_filtro, "periodo desc")
                                Catch ex As Exception : _perMax = Nothing : End Try
                            End If
                        End If
                    End If

                    Try : _montoValor = _perMax(0)("monto") : Catch ex As Exception : _montoValor = 0.0 : End Try

                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                                {"periodo", data("periodo")},
                                                                                                {"reloj", emp("reloj").Trim},
                                                                                                {"per_ded", "P"},
                                                                                                {"concepto", con.Substring(7, 6)},
                                                                                                {"descripcion", ""},
                                                                                                {"monto", _montoValor},
                                                                                                {"clave", Nothing},
                                                                                                {"origen", IIf(relojManual = "", "Finiquitos", "MiscelaneoCRUDFiniquito")},
                                                                                                {"usuario", Usuario},
                                                                                                {"datetime", Now},
                                                                                                {"afecta_vac", False},
                                                                                                {"factor", emp("factor_dias")},
                                                                                                {"fecha", Nothing},
                                                                                                {"sueldo", 0},
                                                                                                {"fecha_fox", Nothing},
                                                                                                {"per_aplica", data("periodo")},
                                                                                                {"ano_aplica", data("ano")},
                                                                                                {"saldo", 0}}, "ajustesPro")

                Next

                '==================================== Deducciones pendientes

                'FOX:
                '*** DEDUCCIONES PENDIENTES
                '*** El 19 de septiembre 2018 confirme con Bety Licea que cuando son finiquitos normales trataremos de cobrar solo lo de una semana de fonacot
                '*** En el 2021 Marisa nos dio la indicacion de NO pagar el impuesto a favor en los finiquitos IVO

                For Each mtroD In mtroDed.Select("reloj='" & emp("reloj").Trim & "'")

                    If Not mtroD("concepto").ToString.Contains("FNAALC") Then
                        If ajustPro.Select("reloj='" & emp("reloj").Trim & "' and concepto='" & mtroD("concepto").ToString.Trim & "'").ToList.Count > 0 Then
                            Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE ajustesPro SET monto='" & mtroD("sald_act") & "' WHERE reloj='" & emp("reloj").Trim & "' and concepto='" & mtroD("concepto").ToString.Trim & "'")
                        Else
                            Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                            {"periodo", data("periodo")},
                                                                                            {"reloj", emp("reloj").Trim},
                                                                                            {"per_ded", "D"},
                                                                                            {"concepto", mtroD("concepto").ToString},
                                                                                            {"descripcion", ""},
                                                                                            {"monto", mtroD("sald_act").ToString},
                                                                                            {"clave", Nothing},
                                                                                            {"origen", IIf(relojManual = "", "Finiquitos", "MiscelaneoCRUDFiniquito")},
                                                                                            {"usuario", Usuario},
                                                                                            {"datetime", Now},
                                                                                            {"afecta_vac", False},
                                                                                            {"factor", emp("factor_dias")},
                                                                                            {"fecha", Nothing},
                                                                                            {"sueldo", 0},
                                                                                            {"fecha_fox", Nothing},
                                                                                            {"per_aplica", data("periodo")},
                                                                                            {"ano_aplica", data("ano")},
                                                                                            {"saldo", 0}}, "ajustesPro")
                        End If
                    Else

                        '== En la parte de los fonacots solo tomar aquellos cuyo mes de aplicacion coincida o sea menor al mes de la baja. Ernesto - 2023-06-13
                        Dim aplicaFonacot = False
                        aplicaFonacot = (Not IsDBNull(mtroD("mes_aplica")) AndAlso If(Convert.ToDateTime(emp("baja")).Month < CInt(mtroD("mes_aplica")), False, True)) OrElse IsDBNull(mtroD("mes_aplica"))

                        If aplicaFonacot Then
                            Dim montoFonacot = Math.Round((mtroD("ini_saldo") / 30 * Convert.ToDateTime(emp("baja")).Day) - (mtroD("ini_saldo") - mtroD("sald_act")), 2)
                            If montoFonacot > 0 Then
                                If ajustPro.Select("reloj='" & emp("reloj").Trim & "' and concepto='" & mtroD("concepto").ToString.Trim & "'").ToList.Count > 0 Then
                                    Sqlite.getInstance.ExecuteNonQueryFunc("UPDATE ajustesPro SET monto='" & CDec(montoFonacot) & "' WHERE reloj='" & emp("reloj").Trim & "' and concepto='" & mtroD("concepto").ToString.Trim & "'")
                                Else
                                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                                        {"periodo", data("periodo")},
                                                                                                        {"reloj", emp("reloj").Trim},
                                                                                                        {"per_ded", "D"},
                                                                                                        {"concepto", "FNAALC"},
                                                                                                        {"descripcion", ""},
                                                                                                        {"monto", CDec(montoFonacot)},
                                                                                                        {"clave", Nothing},
                                                                                                        {"origen", IIf(relojManual = "", "Finiquitos", "MiscelaneoCRUDFiniquito")},
                                                                                                        {"usuario", Usuario},
                                                                                                        {"datetime", Now},
                                                                                                        {"afecta_vac", False},
                                                                                                        {"factor", emp("factor_dias")},
                                                                                                        {"fecha", Nothing},
                                                                                                        {"sueldo", 0},
                                                                                                        {"fecha_fox", Nothing},
                                                                                                        {"per_aplica", data("periodo")},
                                                                                                        {"ano_aplica", data("ano")},
                                                                                                        {"saldo", 0}}, "ajustesPro")
                                End If
                            Else
                                '== En caso de que el concepto ya exista en ajustesPro [por alguna razón que en 'cargarMiscelaneos' se haya ingresado], eliminar
                                Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM ajustesPro WHERE ID=(SELECT ID FROM ajustesPro WHERE RELOJ='" & emp("reloj").Trim & "' AND concepto='FNAALC')")
                            End If
                        Else
                            '== En caso de que el concepto ya exista en ajustesPro [por alguna razón que en 'cargarMiscelaneos' se haya ingresado], eliminar
                            Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM ajustesPro WHERE ID=(SELECT ID FROM ajustesPro WHERE RELOJ='" & emp("reloj").Trim & "' AND concepto='FNAALC')")
                        End If

                    End If
                Next

                '== Se hace una revision en la tabla ajustesPro para quitar conceptos que no deben ir a proceso si es finiquito normal
                Dim ajustesProFiniquito As DataTable = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE reloj='" & emp("reloj").Trim & "'")
                For Each ajuste In ajustesProFiniquito.Rows
                    If conceptosPro.Select("concepto='" & ajuste("concepto").ToString.Trim & "'").Count = 0 Then
                        Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM ajustesPro WHERE reloj='" & emp("reloj").Trim & "' and concepto='" & ajuste("concepto").ToString.Trim & "'")
                    End If
                Next

                '== Si es inicio de semana de fondo de ahorro, se eliminan los conceptos de LIFAHE, LIFAHC y RETIRO de ajustesPro del finiquito [19 junio 2023]
                If inicia_fondo Then
                    ajustesProFiniquito = Sqlite.getInstance.sqliteExecute("SELECT id,reloj,concepto FROM ajustesPro WHERE reloj='" & emp("reloj").Trim & "' and concepto in ('LIFAHE','LIFAHC','RETIRO')")
                    For Each con In ajustesProFiniquito.Rows
                        Sqlite.getInstance.ExecuteNonQueryFunc("DELETE FROM ajustesPro WHERE id='" & con("id") & "'")
                    Next
                End If
            Next

        Catch ex As Exception
            'ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Días de aguinaldo pagados previamente
    ''' </summary>
    ''' <param name="param_rl"></param>
    ''' <param name="param_anio"></param>
    ''' <param name="param_tipo_periodo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function DiasAguiPagadas(ByVal param_rl As String, ByVal param_anio As String, ByVal param_tipo_periodo As String) As Decimal

        Dim valor As Decimal = 0
        Dim dtAguiAnioPagado As New DataTable

        Try
            Dim sql As String = ""

            Select Case param_tipo_periodo.Trim.ToUpper
                Case "S"
                    sql = "select sum(monto) as 'DIASAG'" & vbCrLf
                    sql &= " from movimientos" & vbCrLf
                    sql &= " where reloj = '" & param_rl.Trim & "' and concepto = 'DIASAG' and ano = '" & param_anio.Trim & "' and isnull(tipo_nomina,'') <> 'F' and tipo_periodo = 'S'" & vbCrLf
                    sql &= " and exists(select * from ta.dbo.periodos where periodos.ANO = movimientos.ano and periodos.PERIODO = movimientos.PERIODO" & vbCrLf
                    sql &= " and PERIODO_ESPECIAL = 1)"
                Case "Q"
                    sql = "select sum(monto) as 'DIASAG'" & vbCrLf
                    sql &= " from movimientos" & vbCrLf
                    sql &= " where reloj = '" & param_rl.Trim & "' and concepto = 'DIASAG' and ano = '" & param_anio.Trim & "' and isnull(tipo_nomina,'') <> 'F' and tipo_periodo = 'Q'" & vbCrLf
                    sql &= " and exists(select * from ta.dbo.periodos_quincenal periodos where periodos.ANO = movimientos.ano and periodos.PERIODO = movimientos.PERIODO" & vbCrLf
                    sql &= " and PERIODO_ESPECIAL = 1)"
                Case Else
                    sql = ""
            End Select

            If sql.Trim.Length > 0 Then
                Try
                    dtAguiAnioPagado = sqlExecute(sql, "NOMINA")
                    valor = Decimal.Parse(dtAguiAnioPagado.Rows(0)("DIASAG").ToString)
                Catch ex As Exception
                    valor = 0
                End Try
            End If

        Catch ex As Exception
        End Try

        Return Math.Round(valor, 2)
    End Function

    ''' <summary>
    ''' Representa la funcionalidad de exportar miscelaneos de pida para ser cargados por fox -- Modif. 22 dic 2023
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExportarMiscelaneos(ByRef data As Dictionary(Of String, String))

        Dim EncabezadoReporte = "PERIODO " & data("periodo") & " - " & data("ano")
        Dim strQuerys As New ArrayList

        data("etapa") = "Cargando miscelaneos"

        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If
        Try
            Dim excelPages As New Dictionary(Of String, DataTable)

            'TODO: utilizar Me.period
            Dim dtPeriodos = sqlExecute("SELECT * FROM " & data("tabla") & " WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "'", "TA")
            Dim FIni As Date = dtPeriodos.Rows(0)("fecha_ini")
            Dim FFin As Date = dtPeriodos.Rows(0)("fecha_fin")
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 1 / 15) : End If

            Dim FIniIncidencias As Date = FIni
            Dim FFinIncidencias As Date = FFin
            Dim strFileName = "Revisiones previas " & data("codComp").Replace(",", "-").Replace("'", "") & "_" & data("tipoPeriodo") & data("periodo") & ".XLSX"

            If data("tipoPeriodo") = "Q" Then
                FIniIncidencias = dtPeriodos.Rows(0)("fecha_ini_incidencia")
                FFinIncidencias = dtPeriodos.Rows(0)("fecha_fin_incidencia")
            End If
            data.Add("miscelaneos", strFileName)
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 2 / 15) : End If

            'PROCEDIMIENTOS DESDE QUERY PIDAEXPORTAPERSONAL
            '--- PARA ACTUALIZAR EL STATUS DE LOS INACTIVOS QUE YA SE DIERON DE BAJA, DEBEN SALIR COMO "BAJA
            '--- BORRAR AUSENTISMO SIN CODIGO, PARA QUE NO MARQUE ERROR EL KARDEX
            '---- ADMINISTRATIVOS
            '--- ACTUALIZA TIPO_PAGO
            sqlExecute("UPDATE PERSONAL.dbo.personal SET inactivo=0 WHERE baja IS NOT null AND inactivo=1; " &
                       "DELETE TA.dbo.ausentismo WHERE tipo_aus=''; " &
                       "UPDATE PERSONAL.dbo.personal SET tipo_periodo='Q' WHERE cod_tipo='A'; " &
                       "UPDATE PERSONAL.dbo.personal SET tipo_pago='B', banco='Citibanamex' WHERE cuenta_banco IS NOT NULL AND cuenta_banco <> '' AND tipo_pago <> 'B'; " &
                       "UPDATE PERSONAL.dbo.personal set tipo_pago='D' WHERE clabe IS NOT NULL AND clabe <> '' AND tipo_pago <> 'D'; ")
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 3 / 15) : End If

            '--- REVISION CUENTAS LARGAS
            excelPages.Add("Cuentas largas", sqlExecute("SELECT reloj, nombres, alta, baja, cuenta_banco, clabe, tipo_pago FROM personalvw WHERE " &
                                             "len(ltrim(rtrim(cuenta_banco))) > 11 AND baja IS NULL AND cod_comp IN ('610','700') AND cod_tipo='" &
                                             data("tipoPersonal") & "' ORDER BY reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 4 / 15) : End If

            '--- REVISION CLABES BANAMEX
            excelPages.Add("CLABES BANAMEX", sqlExecute("SELECT reloj, nombres, alta, baja, cuenta_banco, clabe, tipo_pago FROM personalvw WHERE " &
                                             "clabe LIKE '002%' AND baja IS NULL AND cod_comp in ('610','700') AND cod_tipo='" & data("tipoPersonal") & "' ORDER BY reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 5 / 15) : End If

            '--- REVISION DE CUENTAS DUPLICADAS
            excelPages.Add("CUENTAS DUPLICADAS", sqlExecute("SELECT cuenta_banco, clabe, count(reloj) AS cuantos FROM personalvw WHERE (baja IS NULL OR baja >'" & FechaSQL(FFin) & "') " &
                                                 "AND cod_comp in ('610','700') and cod_tipo='" & data("tipoPersonal") & "'" &
                                                 "AND sf_id IS NOT NULL AND cuenta_banco IS NOT NULL GROUP BY cuenta_banco, clabe HAVING count(reloj) > 1 ORDER BY cuenta_banco"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 6 / 15) : End If

            '--- REVISION DE RFC DUPLICADOS
            excelPages.Add("RFC DUPLICADOS", sqlExecute("SELECT cod_comp, compania, reloj, nombres, rfc, alta, baja FROM personalvw " &
                                             "WHERE rfc IN (SELECT rfc FROM personal WHERE (baja IS NULL OR baja>'" & FechaSQL(FFin) & "') AND sf_id IS NOT NULL " &
                                             "GROUP BY rfc HAVING count(reloj) > 1) AND cod_tipo='" & data("tipoPersonal") & "' ORDER BY rfc, cod_comp, reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 7 / 15) : End If

            '--- REVISION PERSONAS OPERATIVAS SIN CLERK (SOLO NOMINA SEMANAL, OPERATIVOS)
            Dim dtSinClerk As DataTable
            If data("tipoPeriodo") = "S" Then
                excelPages.Add("Personal sin clerk", sqlExecute("SELECT reloj, sf_id, nombres, nombre_area, nombre_super, cod_hora, alta, baja FROM personalvw WHERE baja IS NULL " &
                                        "AND cod_comp IN ('610','700') AND cod_tipo='" & data("tipoPersonal") & "' AND (cod_clerk='000' OR cod_clerk='') ORDER BY reloj"))
            End If
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 8 / 15) : End If

            '--- REVISION DE PERSONAS SIN CUENTA
            excelPages.Add("Personal sin cuenta", sqlExecute("SELECT reloj, sf_id, nombres, cod_tipo, cod_clase, alta, baja, cuenta_banco, clabe, inactivo FROM personalvw " &
                                            "WHERE alta <='" & FechaSQL(FFin) & "' AND (baja IS NULL OR baja>'" & FechaSQL(FFin) & "') AND sf_id IS NOT NULL " &
                                            "AND clabe IS NULL AND cuenta_banco IS NULL AND (inactivo=0 OR inactivo is null) AND cod_tipo = '" & data("tipoPersonal") &
                                            "' AND cod_comp IN ('610','700') ORDER BY reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 9 / 15) : End If

            '-- REVISION DE PERSONAS CON FALTANTE DE FECHA DE ALTA
            excelPages.Add("PERSONAL SIN ALTA", sqlExecute("SELECT reloj, sf_id, nombres, cod_tipo, cod_clase, alta, baja, cuenta_banco, clabe, inactivo, fh_alta_imss FROM personalvw " &
                                               "WHERE alta <'1950-01-01' AND sf_id IS NOT NULL " &
                                               "AND clabe IS NULL AND cuenta_banco IS NULL AND (inactivo=0 OR inactivo IS NULL) AND cod_tipo = '" & data("tipoPersonal") &
                                               "' AND cod_comp IN ('610','700') ORDER BY reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 10 / 15) : End If

            '--- REVISION DE PERSONAS QUE CAMBIAN DE TIPO DE EMPLEADO
            excelPages.Add("CAMBIO DE TIPO DE EMPLEADO", sqlExecute("SELECT * FROM bitacora_personal WHERE campo='cod_tipo' AND tipo_movimiento<>'A' AND valornuevo<>'O'  " &
                                          " AND fecha >= '" & FechaSQL(FIni) & "' " & "order by fecha_mantenimiento desc, reloj"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 11 / 15) : End If

            '--- Para identificar bajas con checada en cafeteria
            '--- Incluir 'desayuno sin subsidio, tipo P' de cafeteria [28 abril 2023] - Ernesto
            excelPages.Add("Bajas con comedor", sqlExecute("SELECT c.reloj, p.nombres, p.cod_tipo, p.alta, p.baja, c.subsidio, count(c.reloj) AS cuantos FROM " &
                                            "ta.dbo.hrs_brt_cafeteria c LEFT JOIN personal.dbo.personalvw p ON c.reloj=p.reloj " &
                                            "WHERE fecha BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) &
                                            "' AND subsidio IN ('C','S','Z','P') AND p.baja IS NOT NULL AND p.cod_tipo='" & data("tipoPersonal") & "' AND " &
                                            "p.cod_comp IN ('610','700') GROUP BY c.reloj, p.nombres, p.cod_tipo, p.alta, p.baja, c.subsidio ORDER BY c.reloj ", "TA"))
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 12 / 15) : End If

            '--- Horas cafetería 
            If data("tipoPeriodo") = "S" Then : excelPages.Add("Comedor semanal", horasCafeteria(FIni, FFin, data)) : Else : excelPages.Add("Comedor quincenal", horasCafeteria(FIniIncidencias, FFinIncidencias, data)) : End If
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 13 / 15) : End If

            ''--- Revisión faltantes checadas
            'Dim dtFaltas = sqlExecute("SELECT a.RELOJ,p.NOMBRES,p.COD_CLASE,a.FHA_ENT_HOR,a.COMENTARIO FROM ASIST a left join personal.dbo.personalvw p on a.reloj=p.reloj " &
            '                          "WHERE a.COD_TIPO='O' AND ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and " &
            '                          "(a.COMENTARIO = 'FALTA ENTRADA' or a.COMENTARIO = 'FALTA SALIDA' or a.comentario like '%CHECADA%') AND P.COD_COMP in ('610','700') " &
            '                          "ORDER BY reloj", "TA")

            '--- Revisión faltantes checadas
            Dim dtFaltas = sqlExecute("with faltas as (" &
                                      "select a.reloj,p.nombres,p.cod_clase,a.fha_ent_hor,a.comentario,a.cod_hora " &
                                      "from ta.dbo.asist a " &
                                      "left join personal.dbo.personalvw p on a.reloj=p.reloj " &
                                      "where a.cod_tipo='O' AND ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and " &
                                      "(a.comentario = 'FALTA ENTRADA' or a.comentario = 'FALTA SALIDA' or " &
                                      "a.comentario like '%CHECADA%') AND P.cod_comp in ('610','700'))," &
                                      "info as (" &
                                      "select F.*,p.sactual from personal.dbo.personal p " &
                                      "inner join faltas f on f.reloj=p.reloj)," &
                                      "periodo as (" &
                                      "select i.*,p.ano,p.periodo from info i " &
                                      "left join ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " p " &
                                      "on i.fha_ent_hor between p.fecha_ini and p.fecha_fin where isnull(periodo_especial,0)=0)" &
                                      "" &
                                      "select distinct p.*,r.factor from periodo p " &
                                      "left join personal.dbo.rol_horarios r " &
                                      "on r.ano=p.ano and r.periodo=p.periodo and r.COD_HORA=p.cod_hora " &
                                      "order by p.reloj asc")

            If dtFaltas.Rows.Count > 0 Then
                For Each rlj In dtFaltas.Rows
                    Try
                        'Dim fhaIncidencia = rlj("FHA_ENT_HOR")
                        'Dim dtPer = sqlExecute("select top 1 reloj,cod_hora,sactual from personal.dbo.personal where reloj='" & rlj("reloj").ToString.Trim & "'")
                        'Dim codHr = Nothing : Dim sactual = Nothing
                        'If dtPer.Rows.Count > 0 Then codHr = dtPer.Rows(0)("cod_hora").ToString.Trim : sactual = dtPer.Rows(0)("sactual")

                        'Dim factEmp = ObtenerFactor(codHr,
                        '                            ObtenerAnoPeriodo(fhaIncidencia, data("tipoPeriodo")).ToString.Substring(0, 4),
                        '                            ObtenerAnoPeriodo(fhaIncidencia, data("tipoPeriodo")).ToString.Substring(4, 2))
                        Dim fhaIncidencia = rlj("FHA_ENT_HOR")
                        Dim sactual = rlj("sactual")
                        Dim factEmp = rlj("factor")

                        strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", rlj("reloj").ToString.Trim},
                                                                                        {"per_ded", "P"}, {"concepto", "DIAFCH"}, {"descripcion", Nothing},
                                                                                        {"monto", 1}, {"clave", Nothing}, {"origen", "ExportarMiscelaneos"},
                                                                                        {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                        {"factor", factEmp}, {"fecha", fhaIncidencia}, {"sueldo", sactual},
                                                                                        {"fecha_fox", fhaIncidencia}, {"per_aplica", Nothing}, {"ano_aplica", Nothing},
                                                                                        {"saldo", 0}}, "ajustesPro"))
                    Catch ex As Exception : End Try
                Next

                '--- Guardar registros
                GuardaMovimientosTabla("Guardar checadas faltantes", data, strQuerys)
            End If

            excelPages.Add("Faltantes de checadas", dtFaltas)

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 14 / 15) : End If

            '-- Finiquitos de bajas recientes
            'Tipo de empleado no afecta, solo se generan finiquitos en nómina semanal
            Dim dtFiniquitos As DataTable
            If data("tipoPeriodo") = "S" Then
                'MR 20220121 Bitácora a las 12:30 del 3er día después del final del periodo (3630 minutos, o 60hrs + 30 minutos)
                '--- Con reingresos incluidos
                excelPages.Add("Finiquitos", sqlExecute("SELECT cod_comp, reloj, nombres, cod_tipo, baja, sactual, alta, alta_vacacion FROM personalvw p " & _
                                                        "WHERE (baja BETWEEN '" & FechaSQL(FIni) & "' AND '" & FechaSQL(FFin) & "' AND reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) " & _
                                                        "AND (cod_comp='610' OR cod_comp = '700') AND DATEDIFF (d, alta, baja) >= 2 AND " & _
                                                        "reloj NOT IN (SELECT b.reloj FROM bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                                        "fecha_mantenimiento >'" & FechaHoraSQL(DateAdd(DateInterval.Minute, 3630, FFin)) & "' AND campo='baja' AND " & _
                                                        "ValorNuevo IS NOT NULL AND ValorNuevo<>'' AND valoranterior<>valornuevo AND baja<='" & FechaSQL(FFin) & "')) " & _
                                                        "OR reloj IN (SELECT reloj FROM PERSONAL.dbo.reingresos WHERE baja_ant BETWEEN '" & FechaSQL(FIni) & "' and '" & FechaSQL(FFin) & "') " & _
                                                        "union " & _
                                                        "SELECT p.cod_comp, b.reloj, p.nombres, p.cod_tipo, p.baja, p.sactual, p.alta, p.alta_vacacion " & _
                                                        "FROM bitacora_personal b LEFT JOIN personalvw p ON b.reloj=p.reloj WHERE " & _
                                                        "b.reloj NOT IN (SELECT reloj FROM nomina.dbo.nomina_calculo WHERE status <>'CANCELADO' and captura>p.alta) AND " & _
                                                        "fecha_mantenimiento >= '" & FechaHoraSQL(DateAdd(DateInterval.Hour, 36, FIni)) & "' AND " & _
                                                        "(cod_comp='610' OR cod_comp = '700') AND campo='baja' AND ValorNuevo IS NOT NULL " & _
                                                        "AND ValorNuevo <>'' AND valoranterior <> valornuevo AND b.tipo_movimiento = 'B' AND " & _
                                                        "baja < '" & FechaSQL(FIni) & "' AND DATEDIFF (d, alta,baja)>=2 ORDER BY baja ", "Personal"))

                CargaFiniquitosNormales(excelPages("Finiquitos"), data)
            End If

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * 15 / 15) : End If
            ExportaRevisionExcel(data, excelPages)
            freeMemory()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Name, ex.HResult, ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Funcion para hacer modificaciones a un dt -- Ernesto -- 14 dic 2023
    ''' </summary>
    ''' <param name="op">Opción</param>
    ''' <param name="dt">Datatable a modificar</param>
    ''' <param name="dicInfo">Diccionario con info. para agregar a dt</param>
    ''' <param name="filtro">Filtro de dt</param>
    ''' <param name="col">Nombre de columna</param>
    ''' <param name="valor">Valor a ingresar</param>
    ''' <remarks></remarks>
    Private Sub ModificaDatatable(op As String, ByRef dt As DataTable, Optional dicInfo As Dictionary(Of String, Object) = Nothing,
                                   Optional filtro As String = "", Optional col As String = "", Optional valor As Object = Nothing)
        Try
            Select Case op
                Case "Agregar"
                    Dim newRow = dt.NewRow
                    For Each kvp As KeyValuePair(Of String, Object) In dicInfo : newRow(kvp.Key) = kvp.Value : Next
                    dt.Rows.Add(newRow)

                Case "Eliminar"
                    Dim dtClon = dt.Copy
                    For Each r In dtClon.Select(filtro) : dt.Rows.Remove(r) : Next

                Case "Editar"
                    For Each r In dt.Select(filtro) : r(col) = valor : Next
            End Select
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Representa la funcionalidad de cargar miscelaneos de fox
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <param name="relojManual">Reloj para ingreso manual</param>
    ''' <remarks></remarks>
    Private Sub CargarMiscelaneos(data As Dictionary(Of String, String), Optional relojManual As String = "")
        '********************************************************Boton 2********************************************************

        '-- Se limpian todos los registros de mtro_ded que sean el periodo-año que se va a trabajar y se obtienen los datos de maestro deducciones
        sqlExecute("DELETE FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'TIEN%' AND ini_ano ='" & data("ano").ToString.Trim &
                   "' and ini_per = '" & data("periodo").ToString.Trim & "' ", "NOMINA")
        Dim relojes = (From i In Me.NominaPro.Rows Select i("reloj").ToString.Trim).ToList()

        '-- Por alguna razon no agarra bien directamente el String.Join en el query.
        Dim filtroRelojes = String.Join(",", (From i In relojes Select "'" & i & "'"))
        Dim _mtroDed = sqlExecute("SELECT * FROM NOMINA.dbo.mtro_ded WHERE reloj IN (" & filtroRelojes & ")")
        Dim tienda_c = sqlExecute("SELECT reloj, MAX(concepto) as concepto FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'TIEN%' GROUP BY reloj")

        '-- Los REBECA de mtroded -- Ernesto -- 17 agosto 2023
        Dim rebec_c = sqlExecute("SELECT DISTINCT RELOJ,CONCEPTO,ACTIVO FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'REBEC%' ORDER BY RELOJ,concepto DESC")
        Dim sql = ""

        '-- Ajustes nom
        Dim _dRecib = Sqlite.getInstance.sqliteExecute("SELECT * FROM dtRecib ")

        '-- Inicio y fin del periodo en curso
        Dim infoPer = sqlExecute("select ano,periodo,fecha_ini,fecha_fin from ta.dbo." &
                                 If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where ano='" & data("ano") & "' and periodo='" & data("periodo") & "'")
        Dim fhaMin = Nothing
        Dim difReloj = ""

        '-- Ajustes pro y nominaPro
        Dim dtAjusPro = Me.AjustesPro
        Dim dtNomPro = Me.NominaPro
        Dim strFiltro = ""
        Dim strUpdates As New ArrayList
        Dim strInserts As New ArrayList

        'Recorriendo _dRecib
        data("etapa") = "Procesando miscelaneos"
        Dim cont = 0
        For Each recib In _dRecib.Select("", "reloj asc")

            '== Para la fecha del concepto DDVFIN
            If difReloj <> recib("reloj") Then difReloj = recib("reloj") : fhaMin = Nothing

            'poniendo todas las tiendas en semana = 1
            If recib("factor") = 0 Then : recib("factor") = 1 : End If
            If recib("concepto").ToString.Contains("TIENDA") And recib("semanas") = 1 Then : recib("semanas") = 1 : End If

            'Identificar el reloj en nomina_pro
            Dim employ = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro WHERE reloj = '" & recib("reloj").ToString.Trim & "'")
            Dim salary = 0D
            If employ.Rows.Count > 0 Then : salary = employ.Rows(0)("sactual") : End If

            If {"AHOALC", "CAPACI", "CAJPMO", "RECFNT"}.Contains(recib("concepto")) Then
                Dim element = _mtroDed.Select("reloj = '" & recib("reloj").Trim & "' and concepto = '" & recib("concepto").Trim & "' and activo")
                If element.Count > 0 Then
                    If element.First()("ini_per") <> data("periodo") Or element.First()("ini_ano").ToString.Trim <> data("ano") Or element.First()("abono") <> recib("monto") Then

                        sql &= "UPDATE NOMINA.dbo.mtro_ded SET comentario = 'Cancelado por nueva instrucción en periodo semanal " + data("ano") + "/" + data("periodo") &
                            "', activo = '0' WHERE id = '" & element.First()("id") & "'; "

                        sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, ini_saldo, sald_act) values ('" &
                            recib("reloj") & "', '" & recib("concepto") & "', '" & recib("monto") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '" &
                            {"AHOALC"}.Contains(recib("concepto")) & "', 'S', '" & recib("semanas") & "', '" & recib("saldo") & "', '" & recib("saldo") & "'); "
                    End If
                Else
                    sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, ini_saldo, sald_act) values ('" &
                        recib("reloj") & "', '" & recib("concepto") & "', '" & recib("monto") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '" &
                        {"AHOALC"}.Contains(recib("concepto")) & "', 'S', '" & recib("semanas") & "', '" & recib("saldo") & "', '" & recib("saldo") & "'); "
                End If

                'Un empleado puede tener varios descuentos de tienda, vamos a agregar los que lleguen con un concepto nuevo IVO 201-06-14
            ElseIf recib("concepto").ToString.Contains("TIENDA") And recib("semanas") > 1 Then
                Dim element = tienda_c.Select("reloj = '" & recib("reloj") & "'")
                Dim counter = 0, concept = "TIEN"
                If element.Count > 0 Then
                    Dim t = Regex.Replace(element.First()("concepto").ToString, "[^0-9]", "")
                    counter = Integer.Parse(IIf(t.Count > 0, t + 1, "0"))
                    concept &= counter.ToString.PadLeft(2, "0")
                Else : concept &= "01" : End If

                sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_saldo, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, sald_act) values ('" &
                    recib("reloj") & "', '" & concept & "', '" & recib("monto") & "', '" & recib("saldo") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '0', 'S', '" &
                    recib("semanas") & "', '" & recib("saldo") & "'); "

            ElseIf recib("concepto") = "HRSEXA" Then

                If recib("dobles") > 0 Then
                    strFiltro = " reloj = '" & recib("reloj") & "' and ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "' and concepto = 'HRS2AN'"
                    Dim element As DataTable = infoTabla(strFiltro, dtAjusPro)

                    If element.Rows.Count > 0 Then
                        ModificaDatatable("Editar", dtAjusPro, filtro:=strFiltro, col:="monto", valor:=element.Rows(0)("monto") + recib("dobles"))
                        strUpdates.Add("UPDATE ajustesPro set monto='" & element.Rows(0)("monto") + recib("dobles") & "' WHERE reloj='" & recib("reloj") & "' and concepto='HRS2AN';")
                    Else
                        Dim dicInfo As Dictionary(Of String, Object) = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", recib("reloj")},
                                                                                                               {"per_ded", "P"}, {"concepto", "HRS2AN"}, {"descripcion", ""},
                                                                                                               {"monto", recib("dobles")}, {"clave", Nothing}, {"origen", "archivo txt"},
                                                                                                               {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                                               {"factor", recib("factor")}, {"fecha", recib("fecha")}, {"sueldo", salary},
                                                                                                               {"fecha_fox", recib("fecha_fox")}, {"per_aplica", Nothing},
                                                                                                               {"ano_aplica", Nothing}, {"saldo", 0}}
                        ModificaDatatable("Agregar", dtAjusPro, dicInfo)
                        strInserts.Add(CreaQuery(dicInfo, "ajustesPro"))
                    End If
                End If

                If recib("triples") > 0 Then
                    strFiltro = "reloj = '" & recib("reloj") & "' and ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "' and concepto = 'HRS3AN'"
                    Dim element As DataTable = infoTabla(strFiltro, dtAjusPro)

                    If element.Rows.Count > 0 Then
                        ModificaDatatable("Editar", dtAjusPro, filtro:=strFiltro, col:="monto", valor:=element.Rows(0)("monto") + recib("triples"))
                        strUpdates.Add("UPDATE ajustesPro set monto='" & element.Rows(0)("monto") + recib("triples") & "' WHERE reloj='" & recib("reloj") & "' and concepto='HRS3AN'")
                    Else
                        Dim dicInfo As Dictionary(Of String, Object) = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", recib("reloj")},
                                                                                          {"per_ded", "P"}, {"concepto", "HRS3AN"}, {"descripcion", ""},
                                                                                          {"monto", recib("triples")}, {"clave", Nothing}, {"origen", "archivo txt"},
                                                                                          {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                          {"factor", recib("factor")}, {"fecha", recib("fecha")}, {"sueldo", salary},
                                                                                          {"fecha_fox", recib("fecha_fox")}, {"per_aplica", Nothing}, {"ano_aplica", Nothing},
                                                                                          {"saldo", 0}}
                        ModificaDatatable("Agregar", dtAjusPro, dicInfo)
                        strInserts.Add(CreaQuery(dicInfo, "ajustesPro"))
                    End If
                End If

            ElseIf recib("concepto").ToString.Trim = "BONOS" Then                '=== SECCION PARA CONCEPTO DE BONOS

                '== Si el no hay detalles en dtRecib, entonces se trata de un concepto con importe, sino entonces es con porcentaje
                If IsDBNull(recib("detalles")) Then
                    Dim dicInfo As Dictionary(Of String, Object) = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", recib("reloj")},
                                                                                                           {"per_ded", "P"}, {"concepto", recib("concepto")}, {"descripcion", ""},
                                                                                                           {"monto", recib("monto")}, {"clave", Nothing}, {"origen", "ajustes_nom"},
                                                                                                           {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                                           {"factor", recib("factor")}, {"fecha", recib("fecha")}, {"sueldo", salary},
                                                                                                           {"fecha_fox", recib("fecha_fox")}, {"per_aplica", Nothing}, {"ano_aplica", Nothing},
                                                                                                           {"saldo", 0}}
                    ModificaDatatable("Agregar", dtAjusPro, dicInfo)
                    strInserts.Add(CreaQuery(dicInfo, "ajustesPro"))
                Else
                    '== Se revisa si bono esta vigente
                    Dim detBono = recib("detalles").ToString.Trim
                    Dim strQryMtroDed = ""
                    Dim c = 0 : Dim fechasArr = {Nothing, Nothing}

                    For Each i In detBono.Split(",")
                        fechasArr(c) = Convert.ToDateTime(i.ToString.Split(":")(1)) : c += 1
                        If c > 1 Then Exit For
                    Next

                    '== Si es bono vencido, no incluir y actualizar estatus en maestro de deducciones.
                    Dim fhaValida = fechasArr(1) < Convert.ToDateTime(infoPer.Rows(0)("fecha_ini"))

                    If sqlExecute("select id from nomina.dbo.mtro_ded where reloj='" & recib("reloj") & "' and concepto='" &
                                  recib("concepto") & "' and comentario='" & recib("detalles") & "'").Rows.Count = 0 Then

                        If fhaValida Then
                            strQryMtroDed = "insert into nomina.dbo.mtro_ded (reloj,concepto,comentario,tipo_perio,activo,fijo) values " & _
                                            "('" & recib("reloj") & "','" & recib("concepto") & "','" & recib("detalles") & "','" & data("tipoPeriodo") & "',0,1)"
                        Else
                            strQryMtroDed = "insert into nomina.dbo.mtro_ded (reloj,concepto,comentario,tipo_perio,activo,fijo) values " & _
                                            "('" & recib("reloj") & "','" & recib("concepto") & "','" & recib("detalles") & "','" & data("tipoPeriodo") & "',1,1)"
                        End If

                        '== Inserción de bono
                        sqlExecute(strQryMtroDed)
                    End If
                End If

            ElseIf recib("concepto").ToString.Substring(0, 5) = "REBEC" And recib("semanas") > 1 Then            '--- Sección para el concepto REBEC1,REBEC2,etc -- Ernesto -- 18 AGOSTO 2023

                '-- Modificación REBECA [Solo pueden haber dos conceptos REBECA de acuerdo a Ivette -- 21 sep 2023]
                Dim filtro = "reloj = '" & recib("reloj").Trim &
                             "' and activo and abono='" & recib("monto") &
                             "' and ini_saldo='" & recib("saldo") &
                             "' and periodos='" & recib("semanas") &
                             "' and sald_act='" & recib("saldo") & "' and concepto like 'REBEC%'"

                Dim element = _mtroDed.Select(filtro)

                If element.Count = 0 Then

                    Dim existen As DataTable = infoTabla("reloj='" & recib("reloj").Trim & "'", rebec_c)
                    Dim numRebeca = "REBEC1"

                    If existen.Rows.Count > 0 Then
                        For Each e In existen.Rows
                            If e("concepto") = "REBEC1" And e("activo") Then numRebeca = "REBEC2"
                        Next
                    End If

                    sqlExecute("INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_saldo, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, sald_act, comentario) values ('" &
                               recib("reloj") & "', '" & numRebeca & "', '" & recib("monto") &
                               "', '" & recib("saldo") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '0', 'S', '" & recib("semanas") & "', '" & recib("saldo") &
                               "','Alta sem " & data("ano") & "-" & data("periodo") & "'); ")
                End If

            Else
                strFiltro = "reloj = '" & recib("reloj") & "' and ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "' and concepto = '" & recib("concepto") & "'"
                Dim element As DataTable = infoTabla(strFiltro, dtAjusPro)

                '== Validación especial para el concepto DDVFIN para que tome la fecha minima de los registros que traiga
                If recib("concepto").ToString.Trim = "DDVFIN" Then fhaMin = recib("fecha")

                If element.Rows.Count > 0 Then
                    '== Validación de fecha mínima para concepto DDVFIN
                    Dim min = recib("concepto").ToString.Trim = "DDVFIN" AndAlso (Convert.ToDateTime(fhaMin) < Convert.ToDateTime(element.Rows(0)("fecha")))

                    ModificaDatatable("Editar", dtAjusPro, filtro:=strFiltro, col:="monto", valor:=element.Rows(0)("monto") + recib("monto"))
                    strUpdates.Add("UPDATE ajustesPro SET " & IIf(min, "fecha='" & fhaMin & "',", "") & "monto='" & element.Rows(0)("monto") + recib("monto") &
                                   "' WHERE reloj = '" & recib("reloj") & "' and ano = '" & data("ano") &
                                   "' and periodo = '" & data("periodo") & "' and concepto = '" & recib("concepto") & "';")
                Else
                    Dim dicInfo As Dictionary(Of String, Object) = New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", recib("reloj")},
                                                                                                           {"per_ded", "P"}, {"concepto", recib("concepto")}, {"descripcion", ""},
                                                                                                           {"monto", recib("monto")}, {"clave", Nothing}, {"origen", "archivo txt"},
                                                                                                           {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                                           {"factor", recib("factor")}, {"fecha", recib("fecha")}, {"sueldo", salary},
                                                                                                           {"fecha_fox", recib("fecha_fox")}, {"per_aplica", Nothing}, {"ano_aplica", Nothing},
                                                                                                           {"saldo", 0}}
                    ModificaDatatable("Agregar", dtAjusPro, dicInfo)
                    strInserts.Add(CreaQuery(dicInfo, "ajustesPro"))
                End If
            End If
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * cont / _dRecib.Rows.Count) : cont += 1 : End If

        Next

        '-- Ingresar y/o modificar registros de ajustespro 
        GuardaMovimientosTabla("Cargando ajustes miscelaneos", data, strInserts)
        GuardaMovimientosTabla("Validando ajustes miscelaneos", data, strUpdates)
        strInserts.Clear()
        strUpdates.Clear()

        'Actualizacion de factores IVO 2021-08-03
        'TODO: Marcar en la tabla de conceptos a cuales le vamos a hacer actualizacion de factores
        Dim filter = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIAC50', 'DIAFIN', 'DIAFJU', 'DIAFUN', 'DIAMAT', 'DIANAC', 'DIAPGO', 'DIAPSG', 'DIASUS', 'DIASVA', 'DIAFCH') ")
        Dim dtEmp = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro")

        For Each filt In filter.Rows
            Dim employ As DataTable = infoTabla("reloj = '" & filt("reloj").ToString.Trim & "'", dtEmp)
            If employ.Rows.Count > 0 Then strUpdates.Add("UPDATE ajustesPro SET factor = '" & employ.Rows(0)("factor_dias") & "' WHERE id = '" & filt("id") & "';")
        Next
        GuardaMovimientosTabla("Actualización factores miscelaneos", data, strUpdates)
        filter.Clear()

        '********************************************************Boton 1********************************************************
        '-- Maestro de deducciones

        Dim dtMtroDed = sqlExecute("SELECT * FROM nomina.dbo.mtro_ded " &
                                   "WHERE activo = 1 " &
                                   "AND cast(abono as decimal) > 0 " &
                                   "AND (fijo = 1 or cast(sald_act as decimal) > 0) " &
                                   "AND (((cast(ini_ano as integer)<=" & data("ano") & ") and cast(ini_per as integer)<=" &
                                   data("periodo") & ") or cast(ini_ano as integer)<" & data("ano") & " or ini_per is null) ")

        For Each item In dtMtroDed.Rows
            Dim conti = True
            'En la SEM 41-2019 hicimos el cambio de acuerdo a lo solicitado por Marisa, para que no se junten 2 adeudos, en caso de que el empleado
            'tenga 2 adeudos o mas, primero se debe terminar de pagar el primero y hasta la siguiente semana comenzar a descontar el 2o IVO
            If {"ADEIN1", "ADEIN2", "ADEIN3", "ADEIN4", "ADEIN5", "ADEIN6"}.Contains(item("concepto")) Then
                Dim find = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE reloj = '" & item("reloj").Trim & "' AND concepto LIKE 'ADEIN%'")
                If find.Rows.Count > 0 Then : conti = False : Me.addLog("ALERTA!!! El empleado " & item("reloj") & " tiene activas 2 recuperaciones de Infonavit, solo se aplicará la primera", logType.WARN) : End If
            End If

            'Solo debemos subir un miscelaneo por empleado por concepto
            'A partir de la sem 43-2019 vamos a incluir los saldos de los conceptos del mtro_ded IVO
            If conti Then
                Dim ajp = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE ano = '" & data("ano") & "' and periodo = '" & data("periodo") &
                                                           "' AND reloj = '" & item("reloj").Trim & "' AND concepto = '" & item("concepto").Trim & "'")
                Dim abono = item("sald_act")
                If ajp.Rows.Count > 0 Then
                    If item("fijo") Or item("abono") <= item("sald_act") Then : abono = item("abono") : End If
                    Sqlite.getInstance().ExecuteNonQueryFunc("UPDATE ajustesPro SET monto = '" & ajp.Rows(0)("monto") + abono & "', saldo = '" & ajp.Rows(0)("saldo") + item("sald_act") & "' WHERE id = '" & ajp.Rows(0)("id") & "' ")
                Else
                    If item("fijo") Or item("abono") <= item("sald_act") Then : abono = item("abono") : End If
                    Dim employ = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro WHERE reloj = '" & item("reloj").Trim & "'")
                    If employ.Rows.Count > 0 Then
                        Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")}, {"periodo", data("periodo")}, {"reloj", item("reloj")},
                                                                                        {"per_ded", "D"}, {"concepto", item("concepto")},
                                                                                        {"descripcion", IIf(item("concepto").ToString.Trim = "BONOS", item("comentario").ToString.Trim, Nothing)},
                                                                                        {"monto", abono}, {"clave", Nothing}, {"origen", "nominaPro"},
                                                                                        {"usuario", Usuario}, {"datetime", Now}, {"afecta_vac", False},
                                                                                        {"factor", employ.Rows(0)("factor_dias")}, {"fecha", Nothing}, {"sueldo", employ.Rows(0)("sactual")},
                                                                                        {"fecha_fox", Nothing}, {"per_aplica", data("periodo")}, {"ano_aplica", data("ano")},
                                                                                        {"saldo", item("sald_act")}}, "ajustesPro")
                    End If
                End If
            End If
        Next

        freeMemory()
    End Sub

    ''' <summary>
    ''' Carga los finiquitos normales a la tabla sqlite del proceso correspondiente
    ''' </summary>
    ''' <param name="finiq">Tabla de finiquitos a ingresar</param>
    ''' <param name="data">Variables del proceso</param>
    ''' <remarks></remarks>
    Public Shared Sub CargaFiniquitosNormales(finiq As DataTable, ByRef data As Dictionary(Of String, String))
        Try
            data("etapa") = "Cargando finiquitos normales"

            Dim dtFecPer = sqlExecute("SELECT TOP 1 * FROM TA.dbo." & data("tabla") & " WHERE ISNULL(periodo_especial,0)=0 and ano+periodo='" & data("ano") & data("periodo") & "'")
            Dim fhaIni = FechaSQL(dtFecPer.Rows(0)("fecha_ini"))
            Dim fhaFin = FechaSQL(dtFecPer.Rows(0)("fecha_fin"))
            Dim fhaPago = FechaSQL(dtFecPer.Rows(0)("fecha_pago"))
            Dim fhaAnio = dtFecPer.Rows(0)("ano")
            Dim fhaPeriodo = data("periodo")

            Dim relojes = "(" & String.Join(",", (From i In finiq.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ")"
            Dim qryLastPeriodos = "SELECT T.*, p.*, pe.BAJA FROM ( " &
                                  "SELECT reloj, MAX(n.ano +n.periodo) AS last_period " &
                                  "FROM NOMINA.dbo.nomina AS n " &
                                  "INNER JOIN TA.dbo." & data("tabla") & " AS p on n.ano = p.ANO AND n.PERIODO = p.periodo " &
                                  "WHERE n.reloj in " & relojes & " " &
                                  "AND isnull(p.periodo_especial,0) = 0 " &
                                  "GROUP BY reloj) as T " &
                                  "INNER JOIN TA.dbo.periodos as p on p.ano + p.periodo = T.last_period " &
                                  "INNER JOIN PERSONAL.dbo.personal as pe ON pe.RELOJ = T.reloj"

            Dim last_periodos = sqlExecute(qryLastPeriodos)
            Dim info_periodo = Nothing

            info_periodo = (From el In finiq
                            Select New With {.reloj = el("reloj"),
                                            .cod_comp = el("cod_comp"),
                                            .nombre = el("nombres"),
                                            .cod_tipo = el("cod_tipo"),
                                            .baja = el("baja"),
                                            .alta = el("alta"),
                                            .sactual = el("sactual"),
                                            .alta_vacacion = el("alta_vacacion"),
                                            .ano = fhaAnio,
                                            .fecha_ini = fhaIni,
                                            .fecha_fin = fhaFin,
                                            .fecha_pago = fhaPago,
                                            .last_period = fhaPeriodo,
                                            .activo = "0",
                                            .calculo = Nothing,
                                            .diasva = 0.0}).Distinct.ToList

            '== Revisa si es reingreso. [Si lo es, poner su alta y su baja a como lo tenia anteriormente]
            For Each fin In info_periodo
                Dim esReingreso = sqlExecute("SELECT TOP 1 * FROM PERSONAL.dbo.reingresos WHERE reloj='" & fin.reloj & "' AND baja_ant BETWEEN '" &
                                             fhaIni & "' and '" & fhaFin & "' ORDER BY fecha DESC")
                If esReingreso.Rows.Count > 0 Then
                    fin.alta = esReingreso.Rows(0)("alta_ant")
                    fin.baja = esReingreso.Rows(0)("baja_ant")
                End If
            Next

            'nomina_finiquito
            Dim nom_fini = sqlExecute("SELECT * FROM nomina_finiquito where reloj in " & relojes, "NOMINA")

            'Dias de vacaciones
            For Each element In info_periodo
                Try
                    '-- Se cambio parametro de si se calcula como finiquito a false -- Ernesto -- 26 julio 2023
                    'Dim sVac As New CSaldoVacaciones(element.reloj, element.baja, False, False)
                    'element.DIASVA = sVac.Saldo_Final
                    'sVac.Dispose()

                    'Llenando valor de calculo en finiquitos que proviene de nomina_finiquito
                    Dim nf = (From i In nom_fini Where i("reloj").ToString.Trim = element.reloj).ToList()
                    If nf.Count > 0 Then : element.calculo = nf.First()("fecha_exportacion") : End If
                Catch ex As Exception : End Try
            Next

            For Each element In info_periodo
                Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"reloj", element.reloj}, {"cod_comp", element.cod_comp},
                                                                                    {"nombre", element.nombre}, {"cod_tipo", element.cod_tipo},
                                                                                    {"baja", element.baja}, {"alta", element.alta},
                                                                                    {"sactual", element.sactual}, {"alta_vacacion", element.alta_vacacion},
                                                                                    {"calculo", element.calculo}, {"ano", element.ano},
                                                                                    {"fecha_ini", element.fecha_ini}, {"fecha_fin", element.fecha_fin},
                                                                                    {"fecha_pago", element.fecha_pago}, {"last_period", element.last_period},
                                                                                    {"activo", element.activo}, {"diasva", element.DIASVA}}, "finiquitosN")
            Next

            freeMemory()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Cálcula el saldo total de vacaciones para finiquitos normales
    ''' </summary>
    ''' <param name="strReloj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalcSaldoVacFinNormal(intOp As Integer, strReloj As String) As Double
        Try
            Dim strQry = "select reloj,dias_agui,dias_vac from personal.dbo.personal where reloj='" & strReloj & "'"
            Dim dtPerInfo = sqlExecute(strQry)

            If dtPerInfo.Rows.Count > 0 Then
                Select Case intOp
                    Case 0 : Return If(IsDBNull(dtPerInfo.Rows(0)("dias_agui")), 0, dtPerInfo.Rows(0)("dias_agui"))
                    Case 1 : Return If(IsDBNull(dtPerInfo.Rows(0)("dias_vac")), 0, dtPerInfo.Rows(0)("dias_vac"))
                End Select
            End If

        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Private Function horasCafeteria(fini As Date, ffin As Date, ByRef Data As Dictionary(Of String, String)) As DataTable
        Try
            'MCR 20210125 - Si es nómina quincenal, tomar las fechas de incidencia, no el rango del periodo
            '== Incluir 'desayuno sin subsidio, tipo P' de cafeteria [28 abril 2023] - Ernesto
            Dim dtHorasC = sqlExecute("SELECT fecha, subsidio AS codigo,nombre_subsidio as SUBSIDIO,count(reloj) AS cuantos FROM " &
                                      "hrs_brt_cafeteria LEFT JOIN subsidio_cafeteria ON hrs_brt_cafeteria.subsidio = subsidio_cafeteria.cod_subsidio WHERE fecha BETWEEN '" &
                                      FechaSQL(fini) & "' AND '" & FechaSQL(ffin) & "' AND subsidio in ('C','S','Z','P') AND " &
                                      "reloj IN (SELECT reloj FROM personal.dbo.personal WHERE cod_tipo='" & Data("tipoPersonal") & "' AND cod_comp IN ('610','700')) " &
                                      "GROUP BY fecha,subsidio,nombre_subsidio ORDER BY fecha", "TA")
            Dim dtHorasPivote = GetInversedDataTable(dtHorasC, "fecha", "subsidio", "cuantos", "0", True)
            dtHorasPivote.Columns.Add("TOTAL", Type.GetType("System.Double"))

            Dim TR() As Integer, T = 0, dTotal As DataRow
            ReDim TR(DateDiff(DateInterval.Day, fini, ffin) + 1)
            For Each dRow As DataRow In dtHorasPivote.Rows
                T = 0
                For x = 1 To dtHorasPivote.Columns.Count - 2
                    dRow(x) = Val(dRow(x))
                    T = T + dRow(x)
                    TR(x) = TR(x) + dRow(x)
                Next
                dRow("total") = T
            Next
            dTotal = dtHorasPivote.NewRow

            dTotal("subsidio") = "TOTAL"
            T = 0
            For x = 1 To dtHorasPivote.Columns.Count - 2
                T = T + TR(x)
                dTotal(x) = TR(x)
            Next
            dTotal("total") = T
            dtHorasPivote.Rows.Add(dTotal)
            Return dtHorasPivote.Copy
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Exporta Recordset a excel SIN formato
    ''' </summary>
    Private Sub ExportaRevisionExcel(ByRef data As Dictionary(Of String, String), items As Dictionary(Of String, DataTable))
        Try
            Dim ExcelApp As ExcelPackage = New ExcelPackage()
            Dim wBook As ExcelWorkbook = ExcelApp.Workbook
            Dim wSheet As ExcelWorksheet
            data("etapa") = "Cargando miscelaneos"

            Dim otRev As New List(Of String) From {"CLABES BANAMEX", "CUENTAS DUPLICADAS", "RFC DUPLICADOS", "PERSONAL SIN ALTA", "CAMBIO DE TIPO DE EMPLEADO"}
            For Each item In items : If Not otRev.Contains(item.Key) Then : AgregaHojaExcel(item.Key, item.Value, wBook) : End If : Next
            AgregaHojasAdicionales("Otras revisiones", otRev, wBook, items)

            Try
                Dim fileTemp = System.IO.File.OpenWrite(data("miscelaneos"))
                fileTemp.Close()
            Catch ex As Exception : End Try

            Dim fileDir = Path.Combine(data("savePath"), data("miscelaneos"))
            If System.IO.File.Exists(fileDir) Then : System.IO.File.Delete(fileDir) : End If
            ExcelApp.SaveAs(New System.IO.FileInfo(fileDir))

            releaseObject(wBook)
            releaseObject(wSheet)
            releaseObject(ExcelApp)
            Me.addLog("Archivo " & data("miscelaneos") & " creado exitosamente.")
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub AgregaHojasAdicionales(Nombre As String, list As List(Of String), ByRef wBook As ExcelWorkbook, items As Dictionary(Of String, DataTable))
        Try
            Dim wSheet = wBook.Worksheets.Add(Nombre)
            wSheet.Name = Nombre
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim x As Integer = 1
            Dim datosHojaAd As Action(Of Integer, DataTable, String) = Sub(pos As Integer, rs As DataTable, header As String)
                                                                           Try
                                                                               Dim n = 0
                                                                               If rs.Rows.Count > 0 Then
                                                                                   wSheet.Cells(x, 1).Value = header.ToUpper
                                                                                   x += 1
                                                                                   For n = 1 To rs.Columns.Count : wSheet.Cells(x, n).Value = rs.Columns(n - 1).ColumnName : Next
                                                                                   For Each dr As DataRow In rs.Rows
                                                                                       n = 0 : x += 1
                                                                                       For Each dc As DataColumn In rs.Columns
                                                                                           n += 1 : wSheet.Cells(x, n).Value = dr(dc.ColumnName).ToString
                                                                                       Next
                                                                                   Next
                                                                                   x = x + rs.Rows.Count + 3
                                                                               End If
                                                                           Catch ex As Exception : End Try
                                                                       End Sub

            For Each item In items : If list.Contains(item.Key) Then : datosHojaAd(x, item.Value, item.Key) : End If : Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub AgregaHojaExcel(Nombre As String, rs As DataTable, ByRef wBook As ExcelWorkbook)
        Try
            If rs.Rows.Count = 0 Then Exit Sub
            Dim wSheet = wBook.Worksheets.Add(Nombre)
            Dim i = 0
            Dim x = 1

            For i = 1 To rs.Columns.Count : wSheet.Cells(1, i).Value = rs.Columns(i - 1).ColumnName : Next
            For Each dr In rs.Rows
                i = 0
                x += 1
                For Each dc In rs.Columns
                    i += 1
                    If IsDBNull(dr(dc.ColumnName)) Then : wSheet.Cells(x, i).Value = "" : Else
                        Select Case dc.DataType.ToString
                            Case Is = "System.String" : wSheet.Cells(x, i).Value = dr(dc.ColumnName).ToString
                            Case Is = "System.DateTime" : wSheet.Cells(x, i).Value = FechaSQL(dr(dc.ColumnName))
                            Case Is = "System.Double" : wSheet.Cells(x, i).Value = CDbl(dr(dc.ColumnName))
                            Case Is = "System.Decimal" : wSheet.Cells(x, i).Value = CDbl(dr(dc.ColumnName))
                            Case Is = "System.Int32" : wSheet.Cells(x, i).Value = CInt(dr(dc.ColumnName))
                            Case Else : wSheet.Cells(x, i).Value = dr(dc.ColumnName).ToString
                        End Select
                    End If
                Next
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función que se encargar de retornar un datatable con un filtro definido -- -- Ernesto
    ''' </summary>
    ''' <param name="filtro"></param>
    ''' <param name="dt"></param>
    ''' <param name="orden"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function infoTabla(filtro As String, dt As DataTable, Optional orden As String = "") As Object
        Dim dtRes = dt.Clone
        For Each drow As DataRow In dt.Select(filtro, orden) : dtRes.ImportRow(drow) : Next
        Return dtRes
    End Function

    ''' <summary>
    ''' Se checa en movimientos anteriores y se ajusta el monto de dias aguinaldo [8 dias tope anual] en caso de que se requiera. -- Ernesto
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub TopeDiasAgui(ByVal data As Dictionary(Of String, String), Optional ByRef strQuerys As ArrayList = Nothing)
        Try
            Dim empDiasAgui As DataTable = Sqlite.getInstance.sqliteExecute("SELECT A.* FROM ajustesPro A LEFT JOIN nominaPro N ON A.reloj=N.reloj " & _
                                                                           "WHERE N.procesar='True' AND N.finiquito='False' AND N.finiquito_esp='False' AND A.concepto='DIASAG' " & _
                                                                           "ORDER BY A.reloj ASC")

            For Each agui In empDiasAgui.Rows
                Dim r = agui("reloj").ToString.Trim
                Dim strQry = "select top 1 monto from nomina.dbo.movimientos where ano='" & data("ano") & "' and concepto='ACUDAG' AND reloj='" & r & _
                         "' and tipo_periodo='" & data("tipoPeriodo") & "' and periodo<='" & IIf(data("tipoPeriodo") = "S", 53, 24) & "' ORDER BY PERIODO DESC"

                '== Si no hay movimientos anteriores, monto correcto.
                Dim dtRes = sqlExecute(strQry)

                '== Si la diferencia entre el tope anual [8 días] y los dias de movimientos anteriores es igual o menor que lo que trae actualmente, entonces el monto es correcto
                Dim montoCorrecto As Decimal = 0.0 : Dim hayDif = False
                If dtRes.Rows.Count > 0 And CDec(agui("monto")) > 8 Then montoCorrecto = Math.Round(8 - dtRes.Rows(0)("monto"), 2) : hayDif = True
                If dtRes.Rows.Count = 0 And CDec(agui("monto")) > 8 Then montoCorrecto = 8 : hayDif = True
                If dtRes.Rows.Count > 0 And CDec(agui("monto")) <= 8 Then montoCorrecto = Math.Round(8 - dtRes.Rows(0)("monto"), 2) : hayDif = Not (montoCorrecto = CDec(agui("monto")))
                If dtRes.Rows.Count = 0 And CDec(agui("monto")) <= 8 Then montoCorrecto = CDec(agui("monto"))

                '== Si el monto ya no le alcanza o hay diferencias, se elimina el concepto o se ajusta el monto de ajustesPro
                If montoCorrecto = 0 Then
                    strQuerys.Add("DELETE FROM ajustesPro WHERE reloj='" & r & "' and concepto='DIASAG';")
                ElseIf hayDif Then
                    strQuerys.Add("UPDATE ajustesPro SET monto='" & montoCorrecto & "' WHERE reloj='" & r & "' and concepto='DIASAG';")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Guarda los bloques de registros en sqlite -- Ernesto -- 18 dic 2023
    ''' </summary>
    ''' <param name="strTitulo">Título de paso del proceso</param>
    ''' <param name="data">Variables de proceso</param>
    ''' <param name="strQuerys">Querys que se ejecutarán</param>
    ''' <remarks></remarks>
    Private Sub GuardaMovimientosTablaSQL(strTitulo As String, ByRef data As Dictionary(Of String, String), strQuerys As ArrayList)
        Try
            '-- Variables
            Dim lim = 500                                    'Cantidad de querys de un bloque
            Dim cont = 0                                    'Contador querys 
            Dim numBloq = 0                                 'Num. de bloque con querys
            Dim strQry As New System.Text.StringBuilder     'Almacena cadena de querys

            data("etapa") = strTitulo
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If

            For Each i In strQuerys
                strQry.Append(i)
                If cont = lim Then
                    sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;") : cont = 0 : numBloq += 1 : strQry.Clear()
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * numBloq / (strQuerys.Count / lim)) : End If
                End If
                cont += 1
            Next

            If cont > 0 Then sqlExecute("BEGIN TRANSACTION; " & strQry.ToString & "COMMIT;")

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se cargan los ajustes de ajustes_nom a la tabla correspondiente del proceso
    ''' </summary>
    ''' <param name="data">Variables del proceso</param>
    ''' <remarks></remarks>
    Public Sub ExportarAjustes(ByRef data As Dictionary(Of String, String))
        Try
            data("etapa") = "Exportando ajustes"
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If

            Dim dtDed2 As New DataTable
            Dim dtMtroDed As New DataTable
            Dim dtConceptos As New DataTable
            Dim SinSaldo As Integer = 0
            Dim Inicializa As Windows.Forms.DialogResult
            Dim Clave As String
            Dim HoraInicial As DateTime = Now
            Dim strFechasSab As String ' AOS
            Dim strFechasDom As String ' AOS
            Dim errorConcepto As New List(Of String)
            Dim sql = "" : Dim counter = 0
            Dim strQuerys As New ArrayList          'Almacenar querys para tabla de sqlite

            '--- IDEAS Y BONOS DE RECOMENDACION A AJUSTES
            If Integer.Parse(data("periodo")) <= 53 Then
                Dim dtConceptosMiscelaneos = sqlExecute("SELECT * FROM conceptos WHERE misce_clave IS NOT NULL", "NOMINA")
                data("etapa") = "Insertando conceptos"
                For Each row_i As DataRow In dtConceptosMiscelaneos.Rows
                    Try
                        Dim dtDetalleMiscelaneos = FuncionConcepto(row_i("concepto"), data("codComp"), data("ano"), data("periodo"), IIf(IsDBNull(row_i("misce_monto")), 0, row_i("misce_monto")), data("tipoPeriodo"))
                        If Not dtDetalleMiscelaneos Is Nothing Then
                            For Each row_j In dtDetalleMiscelaneos.Rows
                                sql &= "INSERT INTO ajustes_nom (reloj, ano, periodo,per_ded, clave, monto, comentario, concepto, usuario, fecha, tipo_periodo) " &
                                       "values ('" & row_j("reloj") & "', '" & row_j("ano") & "', '" & row_j("periodo") & "', '" & row_j("per_ded") & "', '" & row_j("clave") & "', '" & row_j("monto") & "', '" & row_j("comentario") & "', '" & row_j("concepto") & "', '" & row_j("usuario") & "', '" & FechaSQL(Date.Parse(row_j("fecha"))) & "', '" & data("tipoPeriodo") & "'); "
                            Next
                        End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtConceptosMiscelaneos.Rows.Count) : counter += 1 : End If
                    Catch ex As Exception : errorConcepto.Add(row_i("concepto")) : End Try
                Next
                If sql.Trim.Length > 0 Then : sqlExecute(sql, "NOMINA") : End If

                sql = ""
            End If

            Dim dtRecib As New DataTable
            Dim dRecib As DataRow

            dtRecib.Columns.Add("reloj")
            dtRecib.Columns.Add("clave")
            dtRecib.Columns.Add("fecha_incidencia", System.Type.GetType("System.String"))
            dtRecib.Columns.Add("numcredito")
            dtRecib.Columns.Add("cantidad", System.Type.GetType("System.Double"))
            dtRecib.Columns.Add("negativo")
            dtRecib.Columns.Add("tipo")
            dtRecib.Columns.Add("concepto")
            dtRecib.Columns.Add("numperiodos")
            dtRecib.Columns.Add("saldo_act", System.Type.GetType("System.Double"))
            dtRecib.Columns.Add("factor")
            dtRecib.Columns.Add("hrs_dobles", System.Type.GetType("System.Double"))
            dtRecib.Columns.Add("hrs_triples", System.Type.GetType("System.Double"))
            dtRecib.Columns.Add("semana_pago")
            dtRecib.Columns.Add("detalles", System.Type.GetType("System.String"))

            '== Se agregó el numcredito como parte de la llave [para bonos]
            dtRecib.PrimaryKey = New DataColumn() {dtRecib.Columns("reloj"), dtRecib.Columns("clave"), dtRecib.Columns("fecha_incidencia"), dtRecib.Columns("numcredito")}          '== Agregado

            '-- Se incluye cod_hora, año, periodo y factor de la incidencia -- 12 ene 2024 -- Ernesto
            Dim existeTipoPeriodo = False
            Dim strTipoPeriodo = If(existeTipoPeriodo, " ajustes_nom.tipo_periodo='" & data("tipoPeriodo") & "'", "")

            Dim dtAjustesNo = sqlExecute("SELECT ajustes_nom.reloj,conceptos.misce_clave AS clave," &
                                         "monto, saldo_act, numcredito, cod_naturaleza, ajustes_nom.concepto," &
                                         "ajustes_nom.comentario, fecha_incidencia, numperiodos, hrs_dobles, hrs_triples, semana_pago," &
                                         "P.COD_HORA, T.ANO, T.PERIODO, R.factor " &
                                         "FROM ajustes_nom " &
                                         "LEFT JOIN personal.dbo.personal P ON ajustes_nom.reloj=P.reloj " &
                                         "LEFT JOIN conceptos ON ajustes_nom.concepto=conceptos.concepto " &
                                         "LEFT JOIN ta.dbo.periodos T ON (ISNULL(T.PERIODO_ESPECIAL,0)=0 AND ajustes_nom.FECHA_INCIDENCIA BETWEEN T.FECHA_INI AND T.FECHA_FIN) " &
                                         "LEFT JOIN personal.dbo.rol_horarios R ON (P.COD_COMP=R.COD_COMP AND T.ANO=R.ANO AND T.PERIODO=R.PERIODO AND P.COD_HORA=R.COD_HORA) " &
                                         "WHERE " & IIf(data("codComp") = "", "", " P.cod_comp in (" & data("codComp") & ") and ") & strTipoPeriodo &
                                         "ajustes_nom.ano='" & data("ano") & "' AND ajustes_nom.periodo='" & data("periodo") & "' and isnull(cancelado, '0')='0' " &
                                         "order by ajustes_nom.concepto asc", "nomina")

            '-- Se incluye cod_hora, año, periodo y factor de la incidencia -- 12 ene 2024 -- Ernesto
            Dim dtBonosPorcentaje = sqlExecute("SELECT ajustes_nom.reloj,conceptos.misce_clave AS clave," &
                                           "monto, saldo_act, numcredito, cod_naturaleza, ajustes_nom.concepto," &
                                           "ajustes_nom.comentario, fecha_incidencia, numperiodos, hrs_dobles, hrs_triples, semana_pago," &
                                           "P.COD_HORA, T.ANO, T.PERIODO, R.factor " &
                                           "FROM ajustes_nom " &
                                           "LEFT JOIN personal.dbo.personal P ON ajustes_nom.reloj=P.reloj " &
                                           "LEFT JOIN conceptos ON ajustes_nom.concepto=conceptos.concepto " &
                                           "LEFT JOIN ta.dbo.periodos T ON (ISNULL(T.PERIODO_ESPECIAL,0)=0 AND ajustes_nom.FECHA_INCIDENCIA BETWEEN T.FECHA_INI AND T.FECHA_FIN) " &
                                           "LEFT JOIN personal.dbo.rol_horarios R ON (P.COD_COMP=R.COD_COMP AND T.ANO=R.ANO AND T.PERIODO=R.PERIODO AND P.COD_HORA=R.COD_HORA) " &
                                           "WHERE " & IIf(data("codComp") = "", "", " P.cod_comp in (" & data("codComp") & ") and ") & " ajustes_nom.CONCEPTO='BONOS' " &
                                           "and (ajustes_nom.COMENTARIO like 'fecha_inicio%')", "nomina")

            dtAjustesNo.Merge(dtBonosPorcentaje)

            '---------------------Proceso para insertar las primas sabatinas, dominical,  y cantidad de comedores  (Solo cuando sea QUINCENAL) al archivo de Texto .txt **Por Adrian Ortega (AOS) 13/05/2019
            If data("tipoPeriodo") = "Q" Then
                '--Obtener fechas de incidencia en base al periodo
                Dim dtFechasIniFin = sqlExecute("SELECT top 1 * FROM periodos_quincenal WHERE ANO='" & data("ano") & "' AND periodo='" & data("periodo") & "'  AND PERIODO_ESPECIAL=0 ORDER BY periodo DESC", "TA")
                Dim FIniInci As String = ""
                Dim FFinInci As String = ""
                If Not dtFechasIniFin.Columns.Contains("Error") And dtFechasIniFin.Rows.Count > 0 Then
                    FIniInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia")).ToString.Trim
                    FFinInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia")).ToString.Trim
                End If
                strFechasSab = ObtFecSabado(FechaSQL(FIniInci), FechaSQL(FFinInci))
                strFechasDom = ObtFecDomingo(FechaSQL(FIniInci), FechaSQL(FFinInci))

                '----Meter al dtAjustesNom los empleados del sabado (Prima Sabatina)
                Dim dtPrimSab = sqlExecute("SELECT reloj, FHA_ENT_HOR as fecha, count(reloj) as cuantos FROM asist WHERE FHA_ENT_HOR in (" & strFechasSab & ") AND COD_TIPO <> 'O' AND (ISNULL(ENTRO, '') <> '' OR ISNULL(SALIO,'') <> '') AND (ausentismo is null OR ausentismo=0)  group by reloj,FHA_ENT_HOR order by FHA_ENT_HOR", "TA")
                If Not dtPrimSab.Columns.Contains("Error") And dtPrimSab.Rows.Count > 0 Then
                    data("etapa") = "Prima sabatina" : counter = 0
                    For Each dRowSab In dtPrimSab.Rows
                        Dim Rj = IIf(IsDBNull(dRowSab("reloj")), "", dRowSab("reloj")).ToString.Trim
                        Dim fecha = IIf(IsDBNull(dRowSab("fecha")), "", dRowSab("fecha")).ToString.Trim
                        'Agregar al Dt ese registro manualmente, NOTA: tiene que ser tal y el orden de los campos vienen y su tipo de dato, si es double, y es vacio, poner un cero
                        If Rj.Length > 0 And fecha.Length > 0 Then : dtAjustesNo.Rows.Add({Rj, "53", "1", 0, "", "I", "DIASAB", FechaSQL(fecha), 0, 0, 0, ""}) : End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtPrimSab.Rows.Count) : counter += 1 : End If
                    Next
                End If

                '----Meter al dtAjustesNom los empleados del domingo (Prima Dominical)
                Dim dtPrimDom = sqlExecute("SELECT reloj, FHA_ENT_HOR as fecha, count(reloj) as cuantos FROM asist WHERE FHA_ENT_HOR in (" & strFechasDom & ") AND COD_TIPO <> 'O' AND (ISNULL(ENTRO, '') <> '' OR ISNULL(SALIO,'') <> '') AND (ausentismo is null or ausentismo=0)  group by reloj,FHA_ENT_HOR order by FHA_ENT_HOR", "TA")
                If Not dtPrimDom.Columns.Contains("Error") And dtPrimDom.Rows.Count > 0 Then
                    data("etapa") = "Prima dominical" : counter = 0
                    For Each dRowDom In dtPrimDom.Rows
                        Dim Rj = IIf(IsDBNull(dRowDom("reloj")), "", dRowDom("reloj")).ToString.Trim
                        Dim fecha = IIf(IsDBNull(dRowDom("fecha")), "", dRowDom("fecha")).ToString.Trim
                        If Rj.Length > 0 And fecha.Length > 0 Then : dtAjustesNo.Rows.Add({Rj, "53", "1", 0, "", "I", "DIADOM", FechaSQL(fecha), 0, 0, 0, ""}) : End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtPrimDom.Rows.Count) : counter += 1 : End If
                    Next
                End If

                '----Insertar los comedores por empleado, fecha y monto
                '== Incluir 'desayuno sin subsidio, tipo P' de cafeteria [28 abril 2023] - Ernesto
                Dim dtComedores = sqlExecute("SELECT reloj, subsidio, count(reloj) as monto FROM hrs_brt_cafeteria WHERE fecha BETWEEN '" & FechaSQL(FIniInci.Trim) & "' AND '" & FechaSQL(FFinInci.Trim) & "' AND reloj IN (SELECT reloj FROM personal.dbo.personal WHERE cod_tipo<>'O' AND ISNULL(inactivo,0)=0) AND subsidio in ('C','S','Z','P') GROUP BY reloj,subsidio", "TA")
                If (Not dtComedores.Columns.Contains("Error") And dtComedores.Rows.Count > 0) Then
                    Dim Rj = "", TipoSub = "", cve = "", monto = "", Concepto = ""
                    data("etapa") = "Comedores por empleados" : counter = 0
                    For Each dRowCom In dtComedores.Rows
                        Rj = IIf(IsDBNull(dRowCom("reloj")), "", dRowCom("reloj")).ToString.Trim
                        TipoSub = IIf(IsDBNull(dRowCom("subsidio")), "", dRowCom("subsidio")).ToString.Trim
                        cve = IIf(TipoSub.Trim = "C", "18", IIf(TipoSub.Trim = "S", "29", IIf(TipoSub.Trim = "P", "101", "30"))).ToString.Trim
                        monto = IIf(IsDBNull(dRowCom("monto")), "0", dRowCom("monto")).ToString.Trim
                        Concepto = IIf(TipoSub.Trim = "C", "DIACON", IIf(TipoSub.Trim = "S", "DIASIN", IIf(TipoSub.Trim = "P", "DIADE2", "DIADES"))).ToString.Trim
                        If Rj.Length > 0 Then : dtAjustesNo.Rows.Add({Rj, cve, monto, 0, "", "I", Concepto, FechaSQL(FFinInci.Trim), 0, 0, 0, ""}) : End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtComedores.Rows.Count) : counter += 1 : End If
                    Next
                End If
            End If

            If dtAjustesNo.Rows.Count = 0 Then
                Me.addLog("No existen ajustes.", logType.ERR)
                'cancelProcess()
            End If

            Dim relojes = " (" & String.Join(",", (From i In dtAjustesNo.Rows Select "'" & i("reloj").ToString.Trim & "'").Distinct()) & ") "
            If relojes = " () " Then relojes = "('999999')"

            Dim dtRequiereFecha = sqlExecute("SELECT distinct rtrim(concepto) AS concepto FROM conceptos where misce_fecha = '1' and cod_naturaleza not in ('P', 'D')", "nomina")
            dtRequiereFecha.PrimaryKey = New DataColumn() {dtRequiereFecha.Columns("concepto")}

            'Dim dtPersonal = sqlExecute("SELECT * FROM PERSONAL.dbo.personal WHERE reloj IN " & relojes)
            'Dim dtNomina = sqlExecute("SELECT * FROM NOMINA.dbo.nomina WHERE reloj IN " & relojes & " and ano+periodo = '" & data("ano") & data("periodo") & "' ", "NOMINA")

            data("etapa") = "Buscando horas dobles y triples" : counter = 0

            '--- Solo la cod_hora es necesaria
            Dim dtBitacora = sqlExecute("SELECT reloj,campo,valoranterior,valornuevo,fecha FROM bitacora_personal " &
                                     "WHERE FECHA = (SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA WHERE campo = bitacora_personal.campo and reloj= bitacora_personal.reloj) " &
                                     "AND reloj in " & relojes & " AND tipo_movimiento = 'C' and campo='cod_hora' ORDER BY fecha")

            strTipoPeriodo = If(existeTipoPeriodo, "AND ajustes_nom.tipo_periodo = '" & data("tipoPeriodo") & "' ", "")
            Dim dtAjustHrsExtAll = sqlExecute("SELECT ajustes_nom.reloj, isnull(sum(hrs_dobles),0) AS hrs_dobles, isnull(sum(hrs_triples),0) as hrs_triples, FECHA_INCIDENCIA " &
                                              "FROM ajustes_nom " &
                                              "LEFT JOIN personal.dbo.personal ON ajustes_nom.reloj = personal.reloj " &
                                              "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " &
                                              "WHERE cod_comp IN (" & data("codComp") & ") " &
                                              strTipoPeriodo &
                                              "AND ano = '" & data("ano") & "' " &
                                              "AND periodo = '" & data("periodo") & "' " &
                                              "AND isnull(cancelado, '0') = '0'" &
                                              "AND ajustes_nom.reloj in " & relojes & " " &
                                              "GROUP BY ajustes_nom.reloj, fecha_incidencia", "NOMINA")
            '--- Querys para ajustes
            Dim strQrys As New ArrayList

            For Each it In dtAjustesNo.Rows
                Try
                    sql = ""

                    '-----------------Proceso para agrupar el concepto HRSEXT cuando el reloj, clave y Fecha de incidencia son el mismo dia,para Totalizar las hrs dobles y triples para mandarlo en un solo registro (AOS) ya que asi se manda en el archivo .TXT
                    Dim HRSDOB As Double = IIf(IsDBNull(it("hrs_dobles")), 0, it("hrs_dobles"))
                    Dim HRSTRIP As Double = IIf(IsDBNull(it("hrs_triples")), 0, it("hrs_triples"))
                    Dim Fec_Inci = IIf(IsDBNull(it("fecha_incidencia")), "", it("fecha_incidencia")).ToString.Trim

                    If (it("concepto").Trim = "HRSEXA" Or ("concepto").Trim = "HRSEXT") Then '' Cambiar el total de hrsdob y hrsTrip para conceptos HRSEXA agruparlos x reloj, clave y fecha de incidencia
                        Dim dtAjustHrsExt = dtAjustHrsExtAll.Select("reloj='" & it("reloj").Trim & "' and fecha_incidencia='" & Convert.ToDateTime(Fec_Inci) & "'")
                        If dtAjustHrsExt.Count > 0 Then
                            HRSDOB = Double.Parse(IIf(IsDBNull(dtAjustHrsExt.First()("hrs_dobles")), "0", dtAjustHrsExt.First()("hrs_dobles")))
                            HRSTRIP = Double.Parse(IIf(IsDBNull(dtAjustHrsExt.First()("hrs_triples")), "0", dtAjustHrsExt.First()("hrs_triples")))
                        End If
                    End If

                    dRecib = dtRecib.Rows.Find({it("RELOJ"), IIf(IsDBNull(it("clave")), "", it("clave")), IIf(IsDBNull(it("fecha_incidencia")), "", it("fecha_incidencia")), IIf(IsDBNull(it("numcredito")), "", it("numcredito"))})                                                                             '== Agregado

                    If IsNothing(dRecib) Then
                        Dim strReloj = it("reloj")
                        Dim strNumCred = IIf(IsDBNull(it("numcredito")), "", it("numcredito"))
                        Dim strClave = IIf(IsDBNull(it("clave")), "", it("clave"))
                        Dim strFecha = IIf(IsDBNull(it("fecha_incidencia")), "", it("fecha_incidencia"))

                        dtRecib.Rows.Add({strReloj, strClave, strFecha, strNumCred})
                        dRecib = dtRecib.Rows.Find({strReloj, strClave, strFecha, strNumCred})
                    End If

                    dRecib("cantidad") = Math.Round(IIf(IsDBNull(dRecib("cantidad")), 0, dRecib("cantidad")) + it("monto"), 2)
                    dRecib("negativo") = IIf(dRecib("cantidad") < 0, "*", " ")
                    dRecib("tipo") = IIf(it("cod_naturaleza").ToString.Trim = "D", "D", "P")
                    dRecib("concepto") = it("concepto").Trim
                    dRecib("numcredito") = IIf(IsDBNull(it("numcredito")), "", it("numcredito"))
                    dRecib("numperiodos") = IIf(IsDBNull(it("numperiodos")), "", it("numperiodos"))
                    dRecib("saldo_act") = IIf(IsDBNull(it("saldo_act")), 0, it("saldo_act"))
                    dRecib("fecha_incidencia") = IIf(IsDBNull(it("fecha_incidencia")), "", it("fecha_incidencia"))
                    dRecib("hrs_dobles") = HRSDOB
                    dRecib("hrs_triples") = HRSTRIP
                    dRecib("semana_pago") = IIf(IsDBNull(it("semana_pago")), "", it("semana_pago"))
                    dRecib("detalles") = IIf(IsDBNull(it("comentario")), "", it("comentario").ToString.Trim)            '== Para los detalles de bono [en caso de que sea porcentaje]

                    If Not IsDBNull(it("fecha_incidencia")) Then
                        If Not dtRequiereFecha.Rows.Find({dRecib("concepto").ToString.Trim}) Is Nothing Then
                            Try
                                dRecib("factor") = it("factor")

                                '-- Revisa en bitacora personal si el cod_hora ha cambiado, si es asi, entonces se hace una consulta para cambiar el factor
                                Dim d = dtBitacora.Select("reloj='" & it("reloj") & "' and fecha>'" & Convert.ToDateTime(dRecib("fecha_incidencia").ToString) & "'")

                                If d.Count > 0 Then
                                    Dim dtFactor = sqlExecute("SELECT TOP 1 COD_HORA,factor FROM personal.dbo.rol_horarios " &
                                                              "WHERE COD_COMP='610' AND ANO+PERIODO='" & it("ano") & it("periodo") & "' AND COD_HORA='" & d.First.Item("cod_hora") & "'")
                                    If dtFactor.Rows.Count > 0 Then
                                        dRecib("factor") = dtFactor.Rows(0)("factor")
                                    End If
                                End If

                            Catch ex As Exception
                                Me.addLog("Error en el registro " & it("reloj") & "-" & dRecib("concepto").ToString.Trim & ". Requiere una fecha de incidencia válida (" & dRecib("fecha_incidencia") & ")")
                            End Try
                        End If
                    End If

                    Clave = IIf(it("clave").ToString.Trim = "", "(clave = '' OR clave IS NULL)", " clave = '" & it("clave").ToString.Trim & "'")

                    'En ajustes_nom, indicar quién y cuándo hizo la exportación
                    strQrys.Add("UPDATE nomina.dbo.ajustes_nom SET envio_nom = 1, envio_date = '" & FechaHoraSQL(Now) & "', " &
                                "envio_usu = '" & Usuario & "' WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "' AND reloj= '" & it("reloj") &
                                "' AND " & Clave &
                                " AND " & IIf(IsDBNull(it("numcredito")), "numcredito IS NULL;", " numcredito = '" & it("numcredito").ToString.Trim & "';"))


                Catch ex As Exception : Console.WriteLine("Error: " & ex.Message)
                Finally
                    'If sql.Trim.Length > 0 Then : sqlExecute(sql, "NOMINA") : End If
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtAjustesNo.Rows.Count) : counter += 1 : End If
                End Try
            Next

            '--- Guardar ajustes en tabla de ajustes_nom
            GuardaMovimientosTablaSQL("Realizando ajustes", data, strQrys)

            'Enviar los datos al archivo seleccionado
            data("etapa") = "Almacenando datos" : counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / If(dtRecib.Rows.Count = 0, 1, dtRecib.Rows.Count)) : End If

            For Each dRecib In dtRecib.Rows

                Try
                    Dim dat = Nothing
                    If dRecib("fecha_incidencia").ToString.Length > 0 Then
                        Try : dat = Convert.ToDateTime(dRecib("fecha_incidencia")) : Catch ex As Exception : End Try
                    End If

                    'Guardando recibos
                    strQuerys.Add(CreaQuery(New Dictionary(Of String, Object) From {{"reloj", dRecib("reloj").ToString.Trim}, {"concepto", dRecib("concepto").ToString.Trim}, {"monto", dRecib("cantidad")},
                                                                                    {"cod_naturaleza", dRecib("tipo").ToString.Trim}, {"credito", dRecib("numcredito").ToString.Trim},
                                                                                    {"semanas", IIf(dRecib("numperiodos").ToString.Trim.Count = 0, 0, dRecib("numperiodos"))},
                                                                                    {"saldo", dRecib("saldo_act")}, {"fecha", dat}, {"factor", IIf(dRecib("factor").ToString.Count > 0, dRecib("factor"), 0)},
                                                                                    {"dobles", dRecib("hrs_dobles")}, {"triples", dRecib("hrs_triples")}, {"semana_pago", dRecib("semana_pago")},
                                                                                    {"detalles", dRecib("detalles")}, {"fecha_fox", Now}}, "dtRecib"))
                Catch ex As Exception
                    Continue For
                Finally : If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtRecib.Rows.Count) : counter += 1 : End If
                End Try
            Next

            '-- Ingresar registros de dtRecib
            GuardaMovimientosTabla("Procesando ajustes: Guardando", data, strQuerys)


            strTipoPeriodo = If(existeTipoPeriodo, " and ajustes_nom.tipo_periodo = '" & data("tipoPeriodo") & "'", "")
            sql = "SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," &
                  "MONTO, fecha_incidencia FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " &
                  "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " &
                  "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " &
                  "WHERE personalvw.cod_comp in (" & data("codComp") & ") and ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "'" & strTipoPeriodo & " AND envio_usu = '" & Usuario &
                  "' AND envio_date >= '" & FechaHoraSQL(HoraInicial, False, False) & "'"
            dtAjustesNo = sqlExecute(sql, "nomina")

            ''----------------------Proc para agregar Prima sab, prima dom, y cantidad de comedores al Reporte final (NOTA: Solo para Administrativos (Per Quincenales)) por AOS 13/05/2019
            If (data("tipoPeriodo") = "Q") Then
                Dim dtFecIncidencia = sqlExecute("SELECT top 1 * from periodos_quincenal where ANO='" & data("ano") & "' and periodo='" & data("periodo") & "' and PERIODO_ESPECIAL=0 order by periodo desc", "TA")
                Dim F1Inci = ""
                Dim F2Inci = ""
                If Not dtFecIncidencia.Columns.Contains("Error") And dtFecIncidencia.Rows.Count > 0 Then
                    F1Inci = IIf(IsDBNull(dtFecIncidencia.Rows(0).Item("fecha_ini_incidencia")), "", dtFecIncidencia.Rows(0).Item("fecha_ini_incidencia")).ToString.Trim
                    F2Inci = IIf(IsDBNull(dtFecIncidencia.Rows(0).Item("fecha_fin_incidencia")), "", dtFecIncidencia.Rows(0).Item("fecha_fin_incidencia")).ToString.Trim
                End If
                strFechasSab = ObtFecSabado(FechaSQL(F1Inci), FechaSQL(F2Inci))
                strFechasDom = ObtFecDomingo(FechaSQL(F1Inci), FechaSQL(F2Inci))

                Dim RjFinal = ""
                Dim NbFinal = ""
                Dim Fecha_Inci_Final = ""
                Dim TipoSub = ""

                '----Prima Sab
                Dim dtTotPrimSab = sqlExecute("SELECT RELOJ,nombres,cod_clase,FHA_ENT_HOR,entro,dia_entro,salio,horas_normales,COMENTARIO FROM TAVW WHERE FHA_ENT_HOR in (" & strFechasSab & ") and cod_tipo<>'O' and (ENTRO <> '' and SALIO <>  '') ORDER BY RELOJ,FHA_ENT_HOR", "TA")
                If Not dtTotPrimSab.Columns.Contains("Error") And dtTotPrimSab.Rows.Count > 0 Then
                    data("etapa") = "Prima sabatina" : counter = 0
                    For Each dRTPS In dtTotPrimSab.Rows
                        RjFinal = IIf(IsDBNull(dRTPS("reloj")), "", dRTPS("reloj")).ToString.Trim
                        NbFinal = IIf(IsDBNull(dRTPS("nombres")), "", dRTPS("nombres")).ToString.Trim
                        Fecha_Inci_Final = IIf(IsDBNull(dRTPS("FHA_ENT_HOR")), "", dRTPS("FHA_ENT_HOR")).ToString.Trim
                        If RjFinal.Length > 0 And Fecha_Inci_Final.Length > 0 Then
                            dtAjustesNo.Rows.Add({data("ano"), data("periodo"), "", "PRIMA SABATINA Unidad", "DIASAB", "I", RjFinal, NbFinal, "1", FechaSQL(Fecha_Inci_Final)})
                        End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtTotPrimSab.Rows.Count) : counter += 1 : End If
                    Next
                End If

                '---Prima Dom
                Dim dtTotPrimDom = sqlExecute("SELECT RELOJ,nombres,cod_clase,FHA_ENT_HOR,entro,dia_entro,salio,horas_normales,COMENTARIO FROM TAVW WHERE FHA_ENT_HOR in (" & strFechasDom & ") and cod_tipo<>'O' and (ENTRO <> '' and SALIO <>  '') ORDER BY RELOJ,FHA_ENT_HOR", "TA")
                If Not dtTotPrimDom.Columns.Contains("Error") And dtTotPrimDom.Rows.Count > 0 Then
                    data("etapa") = "Prima dominical" : counter = 0
                    For Each dRTPD In dtTotPrimDom.Rows
                        RjFinal = IIf(IsDBNull(dRTPD("reloj")), "", dRTPD("reloj")).ToString.Trim
                        NbFinal = IIf(IsDBNull(dRTPD("nombres")), "", dRTPD("nombres")).ToString.Trim
                        Fecha_Inci_Final = IIf(IsDBNull(dRTPD("FHA_ENT_HOR")), "", dRTPD("FHA_ENT_HOR")).ToString.Trim
                        If RjFinal.Length > 0 And Fecha_Inci_Final.Length > 0 Then
                            dtAjustesNo.Rows.Add({data("ano"), data("periodo"), "", "PRIMA DOMINICAL Unidad", "DIADOM", "I", RjFinal, NbFinal, "1", FechaSQL(Fecha_Inci_Final)})
                        End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtTotPrimDom.Rows.Count) : counter += 1 : End If
                    Next
                End If

                '----Comedores (Cafetería)
                '== Incluir 'desayuno sin subsidio, tipo P' de cafeteria [28 abril 2023] - Ernesto
                Dim dtTotComedores = sqlExecute("SELECT hb.reloj,hb.subsidio,count(hb.reloj) as monto,psw.nombres,n.NOMBRE AS NATURALEZA " &
                                                "FROM hrs_brt_cafeteria hb left join PERSONAL.dbo.personalvw psw  on hb.RELOJ = psw.RELOJ LEFT JOIN NOMINA.dbo.naturalezas n on n.COD_NATURALEZA='I' " &
                                                "WHERE hb.fecha between '" & FechaSQL(F1Inci) & "' and '" & FechaSQL(F2Inci) & "' and hb.reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0) and hb.subsidio in ('C','S','Z','P') " &
                                                "GROUP BY hb.reloj,hb.subsidio,psw.nombres,n.NOMBRE", "TA")
                If Not dtTotComedores.Columns.Contains("Error") And dtTotComedores.Rows.Count > 0 Then
                    Dim ConcFinal = "", CveFinal = "", Naturaleza = "", MontoFinal = ""
                    data("etapa") = "Comedores" : counter = 0
                    For Each dRTCom In dtTotComedores.Rows
                        RjFinal = IIf(IsDBNull(dRTCom("reloj")), "", dRTCom("reloj")).ToString.Trim
                        NbFinal = IIf(IsDBNull(dRTCom("nombres")), "", dRTCom("nombres")).ToString.Trim
                        TipoSub = IIf(IsDBNull(dRTCom("subsidio")), "", dRTCom("subsidio")).ToString.Trim

                        '== Incluir 'desayuno sin subsidio, tipo P' de cafeteria [28 abril 2023] - Ernesto
                        ConcFinal = IIf(TipoSub.Trim = "C", "COMEDOR Unidad", IIf(TipoSub.Trim = "S", "COMEDOR SIN SUBSIDIO Unidad", IIf(TipoSub.Trim = "P", "DESAYUNO SIN SUBSIDIO UNIDAD", "COMEDOR 2 SIN SUBSIDIO UNIDAD"))).ToString.Trim
                        CveFinal = IIf(TipoSub.Trim = "C", "DIACON", IIf(TipoSub.Trim = "S", "DIASIN", IIf(TipoSub.Trim = "P", "DIADE2", "DIADES"))).ToString.Trim

                        Naturaleza = IIf(IsDBNull(dRTCom("NATURALEZA")), "", dRTCom("NATURALEZA")).ToString.Trim
                        MontoFinal = IIf(IsDBNull(dRTCom("monto")), "", dRTCom("monto")).ToString.Trim
                        If RjFinal.Length > 0 And Fecha_Inci_Final.Length > 0 Then
                            dtAjustesNo.Rows.Add({data("ano"), data("periodo"), "", ConcFinal, CveFinal, Naturaleza, RjFinal, NbFinal, MontoFinal, FechaSQL(F2Inci.Trim)})
                        End If
                        If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtTotComedores.Rows.Count) : counter += 1 : End If
                    Next
                End If

            End If

            freeMemory()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), System.Reflection.MethodBase.GetCurrentMethod.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function GetInversedDataTable(ByVal table As DataTable, ByVal columnX As String, ByVal columnY As String, ByVal columnZ As String, ByVal nullValue As String, ByVal sumValues As Boolean) As DataTable
        Try
            Dim returnTable As New DataTable()
            If columnX = "" Then : columnX = table.Columns(0).ColumnName : End If
            returnTable.Columns.Add(columnY.ToString.ToUpper)

            Dim columnXValues As New List(Of String)()
            For Each dr In table.Rows
                Dim columnXTemp = dr(columnX).ToString()
                If Not columnXValues.Contains(columnXTemp) Then
                    columnXValues.Add(columnXTemp)
                    returnTable.Columns.Add(columnXTemp, Type.GetType("System.Double")) 'MCR Se requiere tipo numérico para que Excel lo reconozca como número
                End If
            Next

            'Verify if Y and Z Axis columns re provided
            If columnY <> "" AndAlso columnZ <> "" Then
                Dim columnYValues As New List(Of String)()
                For Each dr In table.Rows
                    If Not columnYValues.Contains(dr(columnY).ToString()) Then : columnYValues.Add(dr(columnY).ToString()) : End If
                Next

                For Each columnYValue In columnYValues
                    Dim drReturn = returnTable.NewRow()
                    drReturn(0) = columnYValue
                    Dim rows = table.[Select]((columnY & "='") + columnYValue & "'")

                    For Each dr In rows
                        Dim rowColumnTitle = dr(columnX).ToString()
                        For Each dc In returnTable.Columns
                            If dc.ColumnName = rowColumnTitle Then
                                If sumValues Then
                                    Try : drReturn(rowColumnTitle) = Convert.ToDecimal(drReturn(rowColumnTitle)) + Convert.ToDecimal(dr(columnZ))
                                    Catch : drReturn(rowColumnTitle) = dr(columnZ) : End Try
                                Else : drReturn(rowColumnTitle) = dr(columnZ) : End If
                            End If
                        Next
                    Next
                    returnTable.Rows.Add(drReturn)
                Next
            Else : Throw New Exception("The columns to perform inversion are not provided") : End If

            If nullValue <> "" Then
                For Each dr As DataRow In returnTable.Rows
                    For Each dc As DataColumn In returnTable.Columns
                        If dr(dc.ColumnName).ToString() = "" Then : dr(dc.ColumnName) = nullValue : End If
                    Next
                Next
            End If
            Return returnTable
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Funciones aguinaldo anual" '-- Ernesto -- 19 oct 2023

    ''' <summary>
    ''' Inicia proceso de aguinaldo anual
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Sub IniciaAguinaldoAnual(ByRef data As Dictionary(Of String, String))
        Try
            CargarTablasAguinaldoAnual(data)
            InicializacionNominaAguinaldo(data)
            CalculoAguinaldoDiasAnual(data)
            AgregarAnticipoAguinaldo(data)

            data("etapa") = "Agregando descripción de conceptos" : Dim counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If
            DescripcionConceptos(data)
            If Not Me.BgWorker Is Nothing Then : counter += 1 : Me.BgWorker.ReportProgress(100 * counter / 2) : End If

            Dim strQuerys As New ArrayList
            CambiarFormatoFechas(strQuerys:=strQuerys)
            GuardaMovimientosTabla("Revisando formato de fechas", data, strQuerys)
            If Not Me.BgWorker Is Nothing Then : counter += 1 : Me.BgWorker.ReportProgress(100 * counter / 2) : End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se agrega el SAANAG del ultimo periodo
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Sub AgregarAnticipoAguinaldo(ByRef data As Dictionary(Of String, String))
        Try
            data("etapa") = "Agregando anticipo de aguinaldo" : Dim counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(0) : End If

            Dim dtAntAgui = sqlExecute("SELECT ANO+PERIODO AS PERIODO,RELOJ,CONCEPTO,MONTO," &
                                            "('INSERT INTO AJUSTESPRO (ANO,PERIODO,RELOJ,CONCEPTO,MONTO) VALUES ('''+ANO+''',''{0}'','''+RELOJ+''',''SAANAG'','+CONVERT(VARCHAR,MONTO)+');') as QUERY_SQLITE " &
                                            "FROM NOMINA.DBO.movimientos WHERE ANO='" & data("ano") & "' AND CONCEPTO='SAANAG' AND PERIODO IN (" &
                                            "SELECT MAX(PERIODO) FROM NOMINA.DBO.movimientos WHERE ANO='" & data("ano") & "' AND PERIODO>=01 AND PERIODO<=53 AND tipo_periodo='" & data("tipoPeriodo") & "')")

            If dtAntAgui.Rows.Count > 0 Then
                For Each saanag In dtAntAgui.Rows
                    Sqlite.getInstance.sqliteExecute(String.Format(saanag("QUERY_SQLITE"), data("periodo")))
                    If Not Me.BgWorker Is Nothing Then : counter += 1 : Me.BgWorker.ReportProgress(100 * counter / dtAntAgui.Rows.Count) : End If
                Next
            End If



        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Los días de aguinaldo anuales de todos los empleados activos de nómina -- Ernesto -- 23 oct 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalculoAguinaldoDiasAnual(ByRef data As Dictionary(Of String, String))
        Try
            Dim dtNomina = Sqlite.getInstance.sqliteExecute("select reloj,cod_comp,cod_tipo,alta,alta_antig from nominaPro")
            Dim diasAgui = 0.0

            data("etapa") = "Inicialización especial: Cargando dias de aguinaldo anual" : Dim counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtNomina.Rows.Count) : End If

            If dtNomina.Rows.Count > 0 Then

                For Each x In dtNomina.Rows
                    diasAgui = DiasAguinaldo(data, x("alta"), Me._options("aguinaldo_fecha"), x("alta_antig"), x("cod_comp"), x("cod_tipo"))

                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                                {"periodo", data("periodo")},
                                                                                                {"reloj", x("reloj")},
                                                                                                {"per_ded", "P"},
                                                                                                {"concepto", "DIASAG"},
                                                                                                {"descripcion", Nothing},
                                                                                                {"monto", diasAgui},
                                                                                                {"clave", Nothing},
                                                                                                {"origen", "AguinaldoAnual"},
                                                                                                {"usuario", Usuario},
                                                                                                {"datetime", Date.Now},
                                                                                                {"afecta_vac", "False"},
                                                                                                {"factor", Nothing},
                                                                                                {"fecha", Nothing},
                                                                                                {"sueldo", Nothing},
                                                                                                {"fecha_fox", Nothing},
                                                                                                {"per_aplica", data("periodo")},
                                                                                                {"ano_aplica", data("ano")},
                                                                                                {"saldo", Nothing}}, "ajustesPro")

                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtNomina.Rows.Count) : counter += 1 : End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Tablas que se cargarán a sqlite para el aguinaldo anual -- Ernesto -- 18 oct 2023
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub CargarTablasAguinaldoAnual(ByRef data As Dictionary(Of String, String))
        Try
            '-- Info. de avance interfaz
            data("etapa") = "Inicialización especial: Carga de información" : Dim counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / 6) : counter += 1 : End If

            Dim pensiones = sqlExecute("SELECT * FROM PERSONAL.dbo.pensiones_alimenticias WHERE activo = '1' and mercantil=0")
            For Each item In pensiones.Rows
                Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"reloj", item("reloj")},
                                                                                    {"pensionado", item("pensionado")},
                                                                                    {"porcentaje", item("porcentaje")},
                                                                                    {"tipo_pen", item("tipo_pen")},
                                                                                    {"base_pen", item("base_pen")},
                                                                                    {"fijo", item("fijo")},
                                                                                    {"cuenta", item("cuenta")},
                                                                                    {"activo", item("activo") = 1},
                                                                                    {"apaterno", item("apaterno")},
                                                                                    {"amaterno", item("amaterno")},
                                                                                    {"nombre", item("nombre")},
                                                                                    {"cuaderno", item("cuaderno")},
                                                                                    {"num_pensio", item("num_pensio")},
                                                                                    {"cuenta_val", item("cuenta_val")},
                                                                                    {"comentario", item("comentario")},
                                                                                    {"inicio", item("inicio")},
                                                                                    {"suspension", item("suspension")},
                                                                                    {"mercantil", item("mercantil")}}, "pensionesAlimenticias")
            Next

            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / 6) : counter += 1 : End If

            'Cargando datos del periodo que se esta trabajando
            'Cargar periodo
            Dim dtPeriodo = sqlExecute("SELECT *, ANO+PERIODO as 'ano_periodo', '" & data("tipoPeriodo") & "' as 'tipoPeriodo'  FROM TA.dbo." & data("tabla") & " WHERE ANO = '" & data("ano") & "' AND PERIODO = '" & data("periodo") & "'", "TA")
            If dtPeriodo.Rows.Count > 0 Then
                Me.period = New Dictionary(Of String, String) From {{"ano", dtPeriodo.Rows(0)("ano").ToString},
                                                                 {"periodo", dtPeriodo.Rows(0)("periodo").ToString},
                                                                 {"fecha_ini", FechaSQL(dtPeriodo.Rows(0)("fecha_ini"))},
                                                                 {"fecha_fin", FechaSQL(dtPeriodo.Rows(0)("fecha_fin"))},
                                                                 {"fecha_pago", FechaSQL(dtPeriodo.Rows(0)("fecha_pago"))},
                                                                 {"num_mes", dtPeriodo.Rows(0)("num_mes").ToString},
                                                                 {"periodo_especial", dtPeriodo.Rows(0)("periodo_especial").ToString},
                                                                 {"cierre", dtPeriodo.Rows(0)("cierre").ToString},
                                                                 {"fecha_corte", FechaSQL(dtPeriodo.Rows(0)("fecha_corte"))},
                                                                 {"estatus_nomina", dtPeriodo.Rows(0)("estatus_nomina").ToString},
                                                                 {"ano_periodo", dtPeriodo.Rows(0)("ano_periodo").ToString},
                                                                 {"tipoPeriodo", dtPeriodo.Rows(0)("tipoPeriodo").ToString},
                                                                 {"mes_acumulado", dtPeriodo.Rows(0)("mes_acumulado").ToString}}

                'Ivette orientó cargar Bono de despensa (incluir_bondes) desde TA
                Dim incluir_bondes = False
                If Not IsDBNull(dtPeriodo.Rows(0)("incluir_bondes")) Then : incluir_bondes = Convert.ToBoolean(dtPeriodo.Rows(0)("incluir_bondes")) : End If
                Me.Options("incluir_bondes") = incluir_bondes
            End If

            'Cargar sueldo cobertura
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / 6) : counter += 1 : End If
            Dim _sueldoCobertura = sqlExecute("SELECT * FROM NOMINA.dbo.sueldo_cobertura WHERE activo = '1' and fha_inicio <= '" & Me.period("fecha_fin") & "' ")
            For Each item In _sueldoCobertura.Rows
                Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"reloj", item("reloj")},
                                                                                    {"sdo_cobert", item("sdo_cobert")},
                                                                                    {"comp_diaria", item("comp_diaria")},
                                                                                    {"fha_inicio", FechaSQL(item("fha_inicio"))},
                                                                                    {"fha_fin", FechaSQL(item("fha_fin"))},
                                                                                    {"tipo_comp", item("tipo_comp")},
                                                                                    {"retroactiv", item("retroactiv")},
                                                                                    {"activo", item("activo")},
                                                                                    {"comentario", item("comentario")},
                                                                                    {"ano_ini", item("ano_ini")},
                                                                                    {"periodo_ini", item("periodo_ini")},
                                                                                    {"tipo_periodo_ini", item("tipo_periodo_ini")},
                                                                                    {"porcentaje", item("porcentaje")}}, "sueldoCobertura")
            Next

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Función para cargar información de empleados y conceptos cuando se trate de aguinaldo anual -- Ernesto -- 18 oct 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InicializacionNominaAguinaldo(ByRef data As Dictionary(Of String, String))
        Try
            '-- Info datatables
            '== Consulta a nomina_calculo para validar si el empleado se procesa o no.
            Dim dtNomCalc = sqlExecute("select * from nomina.dbo.nomina_calculo")
            '== Consulta el no. de mes del periodo
            Dim dtNoMes = sqlExecute("select top 1 mes_acumulado from ta.dbo." & IIf(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where ano+periodo='" & data("ano") & data("periodo") & "'")
            '========================================== Cargar personal 
            Dim dtPeriodos = sqlExecute("SELECT * FROM " & data("tabla") & " WHERE ano = '" & data("ano") & "' AND periodo = '" & data("periodo") & "'", "TA")
            Dim FIni As Date = dtPeriodos.Rows(0)("fecha_ini") : Dim FFin As Date = dtPeriodos.Rows(0)("fecha_fin")

            '-- Info. para nominaPro (solo activos)
            Dim sql = "SELECT DISTINCT P.*, " &
                      "(SELECT top 1 fecha_mantenimiento FROM personal.dbo.bitacora_personal WHERE reloj = p.reloj AND campo='inactivo') as fecha_inac, " &
                      "(SELECT top 1 factor from personal.dbo.rol_horarios where ano='" & data("ano") & "' and periodo = '" & data("periodo") & "' and " &
                      "COD_COMP=p.COD_COMP and COD_HORA=(select top 1 cod_hora from ta.dbo.asist where ano+periodo='" & data("ano") & data("periodo") & "' and reloj=p.reloj)) as factor_dias, " &
                      "RTRIM(P.NOMBRE) + ' ' + RTRIM(P.APATERNO) + ' ' + RTRIM(P.AMATERNO) as 'nombre_completo', " &
                      "Pl.nombre as 'nombre_planta',  " &
                      "dpto.NOMBRE as 'nombre_dpto', " &
                      "CC.cod_area " &
                      "FROM PERSONAL.dbo.personal AS P " &
                      "JOIN PERSONAL.dbo.plantas AS Pl on P.COD_PLANTA = Pl.COD_PLANTA AND P.COD_COMP = Pl.COD_COMP " &
                      "JOIN PERSONAL.dbo.deptos AS DPTO on DPTO.COD_COMP = P.COD_COMP and DPTO.COD_DEPTO = P.COD_DEPTO " &
                      "JOIN PERSONAL.dbo.c_costos AS CC on CC.centro_costos = DPTO.CENTRO_COSTOS " &
                      "WHERE (P.COD_COMP in (" & data("codComp") & ") " &
                      "AND p.alta <= '" & FechaSQL(period("fecha_fin")) & "' " &
                      "AND (p.baja is NUll) AND (p.inactivo = 0 or p.inactivo is null))"

            Dim dtPersonal = sqlExecute(sql, "PERSONAL")

            '-- Validación: Nombres o apellidos con comillas
            Dim campos = {"nombre_completo", "nombre", "amaterno", "apaterno"}
            If dtPersonal.Rows.Count > 0 Then
                For i As Integer = 0 To dtPersonal.Rows.Count - 1
                    For Each campo In campos
                        If dtPersonal.Rows(i)(campo).ToString.Trim.Contains("'") Then
                            dtPersonal.Rows(i)(campo) = dtPersonal.Rows(i)(campo).ToString.Trim.Replace("'", "")
                            Console.WriteLine(dtPersonal.Rows(i)(campo).ToString)
                        End If
                    Next
                Next
            End If

            data("etapa") = "Inicialización especial: Cargando empleados de la nómina" : Dim counter = 0
            If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtPersonal.Rows.Count) : End If

            Dim relojes = "(" & String.Join(",", (From i In dtPersonal.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ")"
            Dim dtSuper = sqlExecute("SELECT * FROM PERSONAL.dbo.super where reloj in " & relojes, "PERSONAL")

            For Each item In dtPersonal.Rows

                Dim strReloj = item("reloj").ToString.Trim
                Dim strFhaAlta = FechaSQL(item("alta"))
                Dim super = dtSuper
                Dim fecha_inac = IIf(IsDBNull(item("fecha_inac")), Nothing, item("fecha_inac"))
                Dim alta = IIf(IsDBNull(item("alta")), Nothing, item("alta"))
                Dim baja = IIf(IsDBNull(item("baja")), Nothing, item("baja"))
                Dim inactivo = False
                If Not IsDBNull(item("inactivo")) Then : inactivo = Convert.ToBoolean(Convert.ToInt16(item("inactivo"))) : End If
                Dim fecha_fin = Convert.ToDateTime(period("fecha_fin"))
                Dim fecha_ini = Convert.ToDateTime(period("fecha_ini"))
                Dim procesar = Not inactivo
                If Not fecha_inac Is Nothing And Not alta Is Nothing Then : procesar = procesar And fecha_inac < alta : End If
                If Not baja Is Nothing And Not alta Is Nothing Then : procesar = procesar And DateDiff(DateInterval.Day, alta, baja) > 1 : End If

                '== Validación por parte de Ivette. Evaluar si el empleado se encuentra en nomina_calculo. Si es así, no se incluye para procesar nómina.
                procesar = procesar And Not (dtNomCalc.Select("reloj='" & strReloj & "' and status<>'CANCELADO' and captura is not null and captura>'" & strFhaAlta & "'").Count > 0)

                Dim sdo_cober = 0, sup = Nothing
                If super.Rows.Count > 0 Then : sup = super.Rows(0)("cod_clerk") : End If

                '== Validación de baja: Si la baja es posterior de la fha final del periodo, se deja al empleado como si no la tuviese. [Ivette]
                Dim fhaBaja = Nothing
                If Not IsDBNull(item("baja")) Then
                    If Convert.ToDateTime(item("baja")) > Convert.ToDateTime(FFin) Then fhaBaja = Nothing Else fhaBaja = item("baja")
                End If

                '== Validación para agregar sueldo cobertura como el sueldo normal
                Dim sueldo = item("sactual")

                Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"cod_comp", item("cod_comp")},
                                                                                    {"procesar", procesar},
                                                                                    {"retiro_fah", ""},
                                                                                    {"folio", ""},
                                                                                    {"pagina", ""},
                                                                                    {"cod_tipo_nomina", "N"},
                                                                                    {"cod_pago", item("tipo_pago")},
                                                                                    {"periodo", period("periodo")},
                                                                                    {"ano", data("ano")},
                                                                                    {"reloj", item("reloj")},
                                                                                    {"nombres", item("nombre_completo")},
                                                                                    {"mes", dtNoMes.Rows(0)("mes_acumulado").ToString.Trim},
                                                                                    {"sactual", sueldo},
                                                                                    {"integrado", item("integrado")},
                                                                                    {"cod_depto", item("cod_depto")},
                                                                                    {"cod_turno", item("cod_turno")},
                                                                                    {"cod_puesto", item("cod_puesto")},
                                                                                    {"cod_super", item("cod_super")},
                                                                                    {"cod_hora", item("cod_hora")},
                                                                                    {"cod_tipo", item("cod_tipo")},
                                                                                    {"cod_clase", item("cod_clase")},
                                                                                    {"sindicalizado", item("sindicalizado")},
                                                                                    {"tipo_nomina", data("tipoPeriodo")},
                                                                                    {"alta", item("alta")},
                                                                                    {"baja", fhaBaja},
                                                                                    {"alta_antig", item("alta_vacacion")},
                                                                                    {"periodo_act", period("ano_periodo")},
                                                                                    {"cod_cate", ""},
                                                                                    {"cod_tipo2", ""},
                                                                                    {"fah_participa", item("fah_partic")},
                                                                                    {"fah_porcentaje", item("fah_porcen")},
                                                                                    {"infonavit_credito", Nothing},
                                                                                    {"tipo_credito", Nothing},
                                                                                    {"cuota_credito", 0},
                                                                                    {"cobro_segviv", 0},
                                                                                    {"inicio_credito", Nothing},
                                                                                    {"calculado", ""},
                                                                                    {"retiro_parcial", ""},
                                                                                    {"cuenta1", item("cuenta_banco")},
                                                                                    {"monto_retiro", ""},
                                                                                    {"curp", item("curp")},
                                                                                    {"cod_area", item("cod_area")},
                                                                                    {"privac_porc", 0},
                                                                                    {"privac_dias", 0},
                                                                                    {"factor_dias", 1},
                                                                                    {"dias_habiles", ""},
                                                                                    {"vales_cta", ""},
                                                                                    {"vales_tarj", ""},
                                                                                    {"sdo_cobertura", 0},
                                                                                    {"incapacidad", ""},
                                                                                    {"faltas", ""},
                                                                                    {"vacaciones", ""},
                                                                                    {"cod_clerk", sup},
                                                                                    {"finiquito", False},
                                                                                    {"finiquito_esp", False},
                                                                                    {"permiso", ""}}, "nominaPro")

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / dtPersonal.Rows.Count) : counter += 1 : End If
            Next

            '== Quitar empleados que no corresponden al tipo de periodo que se esta corriendo
            Sqlite.getInstance.sqliteExecute("DELETE FROM nominaPro where cod_tipo<>'" & IIf(data("tipoPeriodo") = "S", "O", "A") & "' and finiquito='False' and finiquito_esp='False'")
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Funciones Reportes"
    '=== VARIABLES PRUEBA
    Private _dtPersonalvw As DataTable
    Private _dtMovimientosPro As DataTable
    Private _dtMaestroDed As DataTable
    Private _dtFiniquitos As DataTable
    Private _dtMovimientos As DataTable
    Private _dtConceptosCatalogo As DataTable
    Private _dtPeriodos As DataTable
    Private _dtMovimientosFin As DataTable
    Private _dtPensionesAlim As DataTable

    Private _dtHorasPro As DataTable
    Private _dtHorasLazy As DataTable
    Private _dtAjustesPro As DataTable
    Private _dtAjustesLazy As DataTable

    Private _dtCompensacionTemp As DataTable
    Private _dtNominaPro As DataTable
    Private _dtSdoCobertura As DataTable
    Private _dtPuestos As DataTable
    Private _dtSuper As DataTable
    Private _dtClerks As DataTable
    Private _dtFiniE As DataTable
    Private _dtFiniN As DataTable

    Private _dtCias As DataTable

    ''' <summary>
    ''' Condensado donde se llaman los reportes para el proceso de nómina. -- Ernesto
    ''' </summary>
    ''' <param name="PerAño">Año y periodo del proceso.</param>
    ''' <param name="version">Versión del proceso ejecutándose</param>
    ''' <param name="fechaPago">Fecha de pago</param>
    ''' <remarks></remarks>
    Public Sub CondensadoReportesNominaBRPQro(PerAño As String, version As String, tipo_per As String,
                                              Optional fechaPago As String = "", Optional data As Dictionary(Of String, String) = Nothing,
                                              Optional directorio As String = "")
        Try
            Dim reportesGenerados = 0
            Dim semanaBonos = False
            Dim bondesValorPer = sqlExecute("select top 1 ano,periodo,bondes_ini from ta.dbo." & If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") &
                                            " where ano='" & PerAño.Substring(2, 4) & "' and periodo='" & PerAño.Substring(0, 2) & "'")

            semanaBonos = If(bondesValorPer.Rows.Count > 0, If(IsDBNull(bondesValorPer.Rows(0)("bondes_ini")), False, True), False)

            '-- Reportes de prenómina definidos
            Dim dtReportes = sqlExecute("SELECT * FROM nomina.dbo.validaciones_procnomina where variable like 'BRPQro_%' and valor='1'")

            If dtReportes.Rows.Count > 0 Then

                If Not Me.BgWorker Is Nothing Then : data("etapa") = "Generando reportes de prenómina" : Me.BgWorker.ReportProgress(0) : End If
                ConsultasBDReportes(PerAño, FechaSQL(Date.Now), tipo_per, data)

                For Each rep In dtReportes.Rows
                    Select Case rep("variable")
                        Case "BRPQro_Neto menor a 500" : ExcelReporteNetoMenorQuinientos(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Fonacot menor a 1000" : ExcelReporteNetoMenorMilFonacot(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Fonacot" : ExcelReporteFonacotObservaciones(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Comparativo nómina" : ExcelReporteComparativoNomina(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Prenómina" : ExcelReportePrenomina(directorio, version, "Normal", data, reportesGenerados)
                        Case "BRPQro_Prenómina finiquitos" : ExcelReportePrenomina(directorio, version, "Finiquitos", data, reportesGenerados)
                        Case "BRPQro_Diferencias detalle" : ExcelReporteDiferenciasDetalle(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Compensación temporal" : ExcelReporteCompensacionTemp(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Horas no aplicadas" : ExcelReporteHorasNoAplicadas(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Misceláneos no aplicados" : ExcelReporteMiscNoAplicados(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Pensiones" : TextReportePensionesAlimenticias(directorio, version, data, reportesGenerados)
                        Case "BRPQro_Bonos" : If semanaBonos Then ExcelReporteBonosDespensa(directorio, version, data, reportesGenerados)
                        Case "BRPQro_PensionesAlimentarias" : ExcelReportePensionesAlimentarias(directorio, version, data, reportesGenerados)
                    End Select
                    If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * reportesGenerados / dtReportes.Rows.Count) : End If
                Next

                freeMemory()

                Dim msj = {"Se generó 1 reporte de prenómina", "Se generaron {0} reportes de prenómina"}

                Me.addLog(If(reportesGenerados = 1, msj(0), String.Format(msj(1), reportesGenerados)))
                MessageBox.Show(If(reportesGenerados = 1, msj(0), String.Format(msj(1), reportesGenerados)), "Reportes prenómina", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al generar archivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "CondensadoReportesNominaBRPQro", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de bonos de despensa -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteBonosDespensa(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Bonos despensa sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim paramAdicionales As New ArrayList
            Dim atributosExcel As New ArrayList

            If _dtMovimientosPro.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim dtEstructura = creaDt("id_vales,nombre,f1,f2,vales_cta,vales_tarjeta,total_despensa", "String,String,String,String,String,String,Double")

                Dim filtro = String.Join(",", From i In _dtNominaPro Where i("procesar") = "True" Select "'" & i("reloj") & "'")

                'Bonos despensa
                Dim dtBonosDesp = sqlExecute("select c.reloj,isnull(cuenta,'') as cuenta,isnull(tarjeta,'') as tarjeta,c.reingreso " &
                                             "from nomina.dbo.cuentas_vales c left join personal.dbo.personalvw p on c.reloj=p.RELOJ where c.reloj in (" & filtro & ")")

                'Pensiones alimenticias
                Dim dtPensiones = sqlExecute("select pen.reloj,isnull(trim(pensionado),'') as pensionado,NUM_PENSIO as num_pensionado,isnull(cuenta_val,'') as cuenta_val,isnull(tarjeta_val,'') as tarjeta_val " &
                                             "from personal.dbo.pensiones_alimenticias pen left join personal.dbo.personalvw p on p.RELOJ=pen.RELOJ where pen.reloj in (" & filtro & ")")

                Dim strCta = ""
                Dim strTarjeta = ""
                Dim esReingreso = ""
                Dim numPen = ""
                Dim filtroDt = ""
                Dim reloj = ""

                For Each bono In _dtMovimientosPro.Select("concepto in ('BONDES','BONPA1','BONPA2','BONPA3')", "concepto asc")
                    Dim nrow As DataRow = dtEstructura.NewRow

                    Try : esReingreso = If(bono("concepto") = "BONDES" AndAlso dtBonosDesp.Select("reloj='" & bono("reloj") & "'").First.Item("reingreso") = True, "A", "") : Catch ex As Exception : esReingreso = "" : End Try
                    Try : numPen = If(bono("concepto").ToString.Substring(0, 5) = "BONPA", bono("concepto").ToString.Substring(bono("concepto").ToString.Length - 1, 1), "") : Catch ex As Exception : numPen = "" : End Try

                    nrow("id_vales") = CInt(bono("reloj")) & esReingreso
                    '-- Tomar en cuenta el num del pensionado para identificar el nombre -- Ernesto -- 26 julio 2023
                    nrow("nombre") = If(numPen = "",
                                        _dtPersonalvw.Select("reloj='" & bono("reloj") & "'").First.Item("nombres").ToString.Replace(",", " ").Trim,
                                        dtPensiones.Select("reloj='" & bono("reloj") & "' and num_pensionado='" & numPen & "'").First.Item("pensionado"))

                    nrow("f1") = 1 : nrow("f2") = 1

                    Select Case bono("concepto")
                        Case "BONDES"
                            filtroDt = "reloj='" & bono("reloj") & "'"
                            For Each i In {"cuenta:vales_cta", "tarjeta:vales_tarjeta"}
                                If dtBonosDesp.Select(filtroDt).Count > 0 Then
                                    nrow(i.Split(":")(1)) = dtBonosDesp.Select(filtroDt).First.Item(i.Split(":")(0)).ToString.Trim
                                Else
                                    nrow(i.Split(":")(1)) = ""
                                End If
                            Next

                        Case Else
                            filtroDt = "reloj='" & bono("reloj") & "' and num_pensionado='" & numPen & "'"
                            For Each i In {"cuenta_val:vales_cta", "tarjeta_val:vales_tarjeta"}
                                If dtPensiones.Select(filtroDt).Count > 0 Then
                                    nrow(i.Split(":")(1)) = dtPensiones.Select(filtroDt).First.Item(i.Split(":")(0)).ToString.Trim
                                Else
                                    nrow(i.Split(":")(1)) = ""
                                End If
                            Next
                    End Select

                    nrow("total_despensa") = bono("monto")
                    dtEstructura.Rows.Add(nrow)
                Next

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Bonos despensa sem " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                atributosExcel.Add("ID_VALES,NOMBRE,F1,F2,VALES_CTA,VALES_TARJETA,TOTAL_DESPENSA")
                atributosExcel.Add(Color.FromArgb(166, 166, 166))
                atributosExcel.Add(Color.FromArgb(0, 0, 0))
                atributosExcel.Add(Color.FromArgb(0, 0, 0))

                FormatoTablaCompleta(True, hoja_excel, dtEstructura, 4, atributosExcel, 0, "", 1)
                hoja_excel.SelectedRange("A4:D" & (dtEstructura.Rows.Count + 5).ToString).AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                cont += 1
                freeMemory()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al generar ExcelReporteBonosDespensa. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteBonosDespensa", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel para obtener el neto menor a $500 por periodo (Emp. operativos y administrativos). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteNetoMenorQuinientos(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            '/*Tablas utilizadas: personal y movimientos_pro*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Neto Menor a 500 sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))
            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim atributosExcel As New ArrayList

            '-- Empleados con neto 0 y menor a 500, con infonavit, fonacot o pensiones alimenticias
            Dim dtNetoMovs = Sqlite.getInstance.sqliteExecute("WITH nomina AS (SELECT reloj FROM nominaPro WHERE cuota_credito>0 AND procesar='True')," &
                            "pension AS (SELECT P.reloj FROM pensionesAlimenticias P LEFT JOIN nominaPro N ON (N.reloj=P.reloj) WHERE P.activo='True' AND N.procesar='True' GROUP BY P.reloj)," &
                            "miscelaneo AS (SELECT M.reloj FROM movimientosPro M LEFT JOIN nominaPro N ON (M.reloj=N.reloj) WHERE M.concepto='FNAALC' AND N.procesar='True' GROUP BY M.reloj)," &
                            "netomov AS (SELECT M.reloj FROM movimientosPro M WHERE (M.reloj NOT IN (SELECT reloj FROM movimientosPro WHERE concepto IN ('NETO') GROUP BY reloj)) OR (M.concepto='NETO' AND M.monto<500) GROUP BY M.reloj)," &
                            "movimientos AS (SELECT M.reloj FROM movimientosPro M GROUP BY reloj)," &
                            "percepciones AS (SELECT RELOJ,CONCEPTO,MONTO FROM movimientosPro WHERE concepto in ('TOTPER','NETO','TOTDED') GROUP BY RELOJ,CONCEPTO) " &
                            "SELECT M.reloj,N.nombres,N.alta,N.BAJA," &
                            "(CASE WHEN EXISTS (SELECT reloj FROM nomina WHERE reloj=M.reloj) THEN 1 ELSE 0 END) AS INFONAVIT," &
                            "(CASE WHEN EXISTS (SELECT reloj FROM pension WHERE reloj=M.reloj) THEN 1 ELSE 0 END) AS PENSIONES," &
                            "(CASE WHEN EXISTS (SELECT reloj FROM miscelaneo WHERE reloj=M.reloj) THEN 1 ELSE 0 END) AS MISCELANEOS," &
                            "(CASE WHEN EXISTS (SELECT reloj FROM netomov WHERE reloj=M.reloj) THEN 1 ELSE 0 END) AS NETOS," &
                            "(IFNULL((SELECT MONTO FROM percepciones WHERE reloj=M.reloj AND concepto='TOTPER'),0)) AS PERCEPCION," &
                            "(IFNULL((SELECT MONTO FROM percepciones WHERE reloj=M.reloj AND concepto='TOTDED'),0)) AS DEDUCCION," &
                            "(IFNULL((SELECT MONTO FROM percepciones WHERE reloj=M.reloj AND concepto='NETO'),0)) AS NETO " &
                            "FROM movimientos M " &
                            "LEFT JOIN nominaPro N ON M.reloj=N.reloj " &
                            "WHERE INFONAVIT+PENSIONES+MISCELANEOS+NETOS>0 AND N.BAJA IS NULL")

            If dtNetoMovs.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Neto Menor a 500 " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                atributosExcel.Add("Reloj,Nombres,Alta,Percepciones,Deducciones,Neto")

                FormatoCelda(hoja_excel, 0, 4, 7, "INFONAVIT", Color.Black, True, "", _alineacion:=Style.ExcelHorizontalAlignment.Center)
                FormatoCelda(hoja_excel, 0, 4, 8, "PENSIONES ALIMENTICIAS", Color.Black, True, "", _alineacion:=Style.ExcelHorizontalAlignment.Center)
                FormatoCelda(hoja_excel, 0, 4, 9, "FONACOT", Color.Black, True, "", _alineacion:=Style.ExcelHorizontalAlignment.Center)

                atributosExcel.Add(Color.FromArgb(166, 166, 166))
                atributosExcel.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, Nothing, 4, atributosExcel, 0, "", 1)

                Dim x As Integer = 5 : Dim y As Integer = 0
                Dim dic As New Dictionary(Of String, String)
                dic.Add("1", "ü") : dic.Add("0", "")

                For Each dr As DataRow In dtNetoMovs.Select("", "reloj")
                    hoja_excel.Cells(x, y + 1).Value = dr.Item("reloj").ToString.Trim
                    hoja_excel.Cells(x, y + 2).Value = dr.Item("nombres").ToString.Trim
                    hoja_excel.Cells(x, y + 3).Value = dr.Item("alta").ToString.Trim

                    hoja_excel.Cells(x, y + 4).Value = dr.Item("percepcion")
                    hoja_excel.Cells(x, y + 4).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right

                    hoja_excel.Cells(x, y + 5).Value = dr.Item("deduccion")
                    hoja_excel.Cells(x, y + 5).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right

                    hoja_excel.Cells(x, y + 6).Value = dr.Item("neto")
                    hoja_excel.Cells(x, y + 6).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right

                    hoja_excel.Cells(x, y + 7).Value = dic(dr.Item("infonavit").ToString.Trim)
                    hoja_excel.Cells(x, y + 7).Style.Font.Name = "Wingdings"
                    hoja_excel.Cells(x, y + 7).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.Cells(x, y + 8).Value = dic(dr.Item("pensiones").ToString.Trim)
                    hoja_excel.Cells(x, y + 8).Style.Font.Name = "Wingdings"
                    hoja_excel.Cells(x, y + 8).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    hoja_excel.Cells(x, y + 9).Value = dic(dr.Item("miscelaneos").ToString.Trim)
                    hoja_excel.Cells(x, y + 9).Style.Font.Name = "Wingdings"
                    hoja_excel.Cells(x, y + 9).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    x += 1 : y = 0
                Next

                hoja_excel.SelectedRange("A4:I" & x.ToString & "").AutoFitColumns()
                hoja_excel.SelectedRange("F4:I4").AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                cont += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteNetoMenorQuinientos. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteNetoMenorQuinientos", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel con empleados que tengan fonacot y un neto menor a 1000 (Solo operativos). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteNetoMenorMilFonacot(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            '/*Tablas utilizadas: personal, movimientos_pro, mtro_ded*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Fonacot Neto Menor 1000 sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))
            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"

            Dim atributosExcel As New ArrayList
            Dim dtNetoMenor = _dtMovimientosPro.Select("concepto='neto' and monto<1000").CopyToDataTable
            Dim dtMtroFon = _dtMaestroDed.Select("concepto='FNAALC' and activo=1").CopyToDataTable
            Dim dtPersInfo = _dtPersonalvw.Select("cod_tipo='O'").CopyToDataTable

            If dtMtroFon.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Fonacot Neto Menor 1000 " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                atributosExcel.Add("Reloj,Nombres,Fonacot_ret_mensual,Neto")
                atributosExcel.Add(Color.FromArgb(166, 166, 166))
                atributosExcel.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, Nothing, 4, atributosExcel, 0, "", 1)

                Dim x As Integer = 5
                Dim y As Integer = 0

                For Each dr As DataRow In dtMtroFon.Select("", "reloj")
                    If ResValDt("reloj='" & dr.Item("reloj").ToString.Trim & "'", "reloj", dtPersInfo, True) IsNot Nothing And ResValDt("reloj='" & dr.Item("reloj").ToString.Trim & "'", "reloj", dtNetoMenor, True) IsNot Nothing Then
                        hoja_excel.Cells(x, y + 1).Value = CInt(dr.Item("reloj").ToString.Trim)
                        hoja_excel.Cells(x, y + 2).Value = ResValDt("reloj='" & dr.Item("reloj").ToString.Trim & "'", "nombres", dtPersInfo, True).ToString.Trim
                        hoja_excel.Cells(x, y + 3).Value = ResValDt("reloj='" & dr.Item("reloj").ToString.Trim & "'", "ini_saldo", dtMtroFon, True)
                        hoja_excel.Cells(x, y + 4).Value = ResValDt("reloj='" & dr.Item("reloj").ToString.Trim & "'", "monto", dtNetoMenor, True)
                        x += 1 : y = 0
                    End If
                Next

                hoja_excel.SelectedRange("A4:D" & x.ToString & "").AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                cont += 1
                freeMemory()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteNetoMenorMilFonacot. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteNetoMenorMil", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel con empleados que tengan fonacot (Solo operativos). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteFonacotObservaciones(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            '/*Tablas utilizadas: personal, movimientos_pro, mtro_ded*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Fonacot Sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim atributosExcel As New ArrayList
            Dim dtMovsPro = _dtMovimientosPro.Select("concepto in ('neto','DIAIMA','DIAING','DIAITR','DIAFIN','FNAALC')").CopyToDataTable
            Dim dtMtroDed = _dtMaestroDed.Select("concepto='FNAALC' and activo='True'").CopyToDataTable
            Dim dtPersInfo = _dtPersonalvw.Select("cod_tipo='O'").CopyToDataTable

            If dtMtroDed.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Fonacot observaciones " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                atributosExcel.Add("Reloj,Nombres,Ret_mensual,Sem_" & aPer.Replace("-", "_") & ",Diferencia,Observaciones")
                atributosExcel.Add(Color.FromArgb(166, 166, 166))
                atributosExcel.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, Nothing, 4, atributosExcel, 0, "", 1)

                Dim x As Integer = 5
                Dim y As Integer = 0

                For Each dr As DataRow In dtMtroDed.Select("", "reloj")
                    Dim strReloj = dr.Item("reloj").ToString.Trim

                    If ResValDt("reloj='" & strReloj & "'", "reloj", dtPersInfo, True) IsNot Nothing Then
                        Dim strNombres = ResValDt("reloj='" & strReloj & "'", "nombres", dtPersInfo, True).ToString.Trim
                        Dim dblMovsProSem = ResValDt("reloj='" & strReloj & "' and concepto='FNAALC'", "monto", _dtMovimientosPro, True)
                        Dim dblMtroDedMensual = dr.Item("ini_saldo")
                        Dim dblMtroDedAbono = dr.Item("abono")
                        Dim strObservaciones = Nothing
                        Dim dblDiferencia = 0.0
                        strObservaciones = ResValDt("reloj='" & strReloj & "'", "baja", _dtNominaPro, True)

                        If strObservaciones Is Nothing Then strObservaciones = ""
                        If strObservaciones.GetType() Is GetType(System.DateTime) Then strObservaciones = "Baja " & FechaSQL(strObservaciones) : GoTo EscribeExcel Else strObservaciones = ""

                        If dblMovsProSem Is Nothing Or (dblMtroDedAbono <> dblMovsProSem) Then
                            strObservaciones = ResValDt("reloj='" & strReloj & "' and concepto in ('DIAIMA')", "concepto", dtMovsPro, True)
                            If strObservaciones IsNot Nothing Then strObservaciones = "Incapacidad maternidad" : GoTo EscribeExcel Else strObservaciones = ""
                            strObservaciones = ResValDt("reloj='" & strReloj & "' and concepto in ('DIAING')", "concepto", dtMovsPro, True)
                            If strObservaciones IsNot Nothing Then strObservaciones = "Incapacidad general" : GoTo EscribeExcel Else strObservaciones = ""
                            strObservaciones = ResValDt("reloj='" & strReloj & "' and concepto in ('DIAITR')", "concepto", dtMovsPro, True)
                            If strObservaciones IsNot Nothing Then strObservaciones = "Incapacidad riesgo trabajo" : GoTo EscribeExcel Else strObservaciones = ""
                            strObservaciones = ResValDt("reloj='" & strReloj & "' and concepto in ('DIAFIN')", "concepto", dtMovsPro, True)
                            If strObservaciones IsNot Nothing Then strObservaciones = "Ausentismo" : GoTo EscribeExcel Else strObservaciones = ""
                            strObservaciones = ResValDt("reloj='" & strReloj & "' and inactivo=1", "inactivo", dtPersInfo, True)
                            If strObservaciones IsNot Nothing Then strObservaciones = "Suspendido" : GoTo EscribeExcel Else strObservaciones = ""
                            Dim dateAlta = FechaSQL(ResValDt("reloj='" & strReloj & "'", "alta", dtPersInfo))

                            '-- Finiquitos (proceso)
                            Dim finiquitoBool = (Not IsNothing(ResValDt("reloj='" & strReloj & "'", "reloj", _dtFiniE))) OrElse (Not IsNothing(ResValDt("reloj='" & strReloj & "'", "reloj", _dtFiniN)))
                            If finiquitoBool Then strObservaciones = "Finiquito en proceso" : GoTo EscribeExcel Else strObservaciones = ""

                            strObservaciones = ResValDt("reloj='" & strReloj & "' and concepto in ('neto')", "monto", dtMovsPro, True)
                            strObservaciones = IIf(strObservaciones IsNot Nothing, IIf(strObservaciones = 0.0, "Sin neto", "Neto " & strObservaciones), "Sin neto")
                        End If
EscribeExcel:
                        hoja_excel.Cells(x, y + 1).Value = CInt(strReloj)
                        hoja_excel.Cells(x, y + 2).Value = strNombres
                        hoja_excel.Cells(x, y + 3).Value = IIf(dblMtroDedMensual Is Nothing, 0.0, dblMtroDedMensual)
                        hoja_excel.Cells(x, y + 4).Value = IIf(dblMovsProSem Is Nothing, 0.0, dblMovsProSem)
                        hoja_excel.Cells(x, y + 5).Value = dblDiferencia
                        hoja_excel.Cells(x, y + 6).Value = strObservaciones
                        x += 1 : y = 0
                    End If
                Next

                hoja_excel.SelectedRange("A4:F" & x.ToString & "").AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                cont += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ExcelReporteFonacotObservaciones. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteFonacotObservaciones", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel que compara las percepciones y deducciones del periodo actual y anterior (Operativos y administrativos). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteComparativoNomina(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            '/*Tablas utilizadas: personal, movimientos_pro, movimientos, periodos,*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Comparativo nómina sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, "CTE TRANSPORTE", data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim relojes As New ArrayList
            Dim x As Integer = 2
            Dim y As Integer = 0
            Dim rango As String = ""
            Dim netoPerDed As New ArrayList
            Dim paramAdicionales As New ArrayList
            Dim totalRegistros = 0

            If _dtMovimientosPro.Rows.Count > 0 And _dtMovimientos.Rows.Count > 0 Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim resultadoTemp As Object = Nothing
                Dim relojTemp As String = ""
                Dim nombreTemp As String = ""
                Dim periodoAntTemp As String = PeriodoAnterior(data("periodo") & data("ano"), _dtPeriodos)
                Dim semActual As String = data("periodo")
                Dim semAnt As String = periodoAntTemp.Substring(0, 2)

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Comparativo Nómina Semana " & aPer & " V" & verProc, Color.Black, True, "")

                Dim dtTotales As DataTable
                paramAdicionales.Add(semActual) : paramAdicionales.Add(semAnt)

                Dim dtPercepciones As DataTable = ComparativoNomPerDed("Percepciones", paramAdicionales, netoPerDed, periodoAntTemp, dtTotales)
                Dim dtDeducciones As DataTable = ComparativoNomPerDed("Deducciones", paramAdicionales, netoPerDed, periodoAntTemp, dtTotales)
                paramAdicionales.Clear()
                paramAdicionales.Add(data("periodo") & data("ano"))

                Dim dtAltas As DataTable = ComparativoNomAltasBajas("Altas", paramAdicionales)
                Dim dtBajas As DataTable = ComparativoNomAltasBajas("Bajas", paramAdicionales)
                paramAdicionales.Clear()
                paramAdicionales.Add(data("periodo") & data("ano"))

                Dim dtCambiosSueldo As DataTable = ComparativoNomCambioSueldo(paramAdicionales)
                paramAdicionales.Clear()

                Dim fin As Integer = 0

                FormatoCelda(hoja_excel, 0, 4, 1, "PERCEPCIONES", Color.FromArgb(0, 97, 0), True, "") : rango = RangoCeldasExcel(4, 1, 6)
                FormatoCelda(hoja_excel, 1, 4, 1, "", Color.FromArgb(0, 97, 0), True, rango, True, Color.FromArgb(198, 239, 206))
                paramAdicionales.Add("Concepto,Descripcion,Semana " & semActual & ",Semana " & semAnt & ",Diferencia,Variabilidad")
                paramAdicionales.Add(Color.FromArgb(198, 239, 206))
                paramAdicionales.Add(Color.FromArgb(0, 97, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))

                FormatoTablaCompleta(True, hoja_excel, dtPercepciones, 5, paramAdicionales, fin, "PerDed")
                FormatoCelda(hoja_excel, 0, fin + 1, 1, ResValDt("concepto='totper'", "Concepto", dtTotales), Color.FromArgb(0, 0, 0), True, "")
                FormatoCelda(hoja_excel, 0, fin + 1, 2, ResValDt("concepto='totper'", "Descripcion", dtTotales), Color.FromArgb(0, 0, 0), True, "")
                FormatoCelda(hoja_excel, 0, fin + 1, 3, ResValDt("concepto='totper'", "Semana " & semActual, dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 4, ResValDt("concepto='totper'", "Semana " & semAnt, dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 5, ResValDt("concepto='totper'", "Diferencia", dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 6, ResValDt("concepto='totper'", "Variabilidad", dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "0.00%")
                fin = fin + 2 + 1

                FormatoCelda(hoja_excel, 0, fin, 1, "DEDUCCIONES", Color.FromArgb(156, 87, 0), True, "") : rango = RangoCeldasExcel(fin, 1, 6) : paramAdicionales.Clear()
                FormatoCelda(hoja_excel, 1, fin, 1, "", Color.FromArgb(156, 87, 0), True, rango, True, Color.FromArgb(255, 235, 156))
                paramAdicionales.Add("Concepto,Descripcion,Semana " & semActual & ",Semana " & semAnt & ",Diferencia,Variabilidad")
                paramAdicionales.Add(Color.FromArgb(255, 235, 156))
                paramAdicionales.Add(Color.FromArgb(156, 87, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))

                FormatoTablaCompleta(True, hoja_excel, dtDeducciones, fin + 1, paramAdicionales, fin, "PerDed")
                FormatoCelda(hoja_excel, 0, fin + 1, 1, ResValDt("concepto='totded'", "Concepto", dtTotales), Color.FromArgb(0, 0, 0), True, "")
                FormatoCelda(hoja_excel, 0, fin + 1, 2, ResValDt("concepto='totded'", "Descripcion", dtTotales), Color.FromArgb(0, 0, 0), True, "")
                FormatoCelda(hoja_excel, 0, fin + 1, 3, ResValDt("concepto='totded'", "Semana " & semActual, dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 4, ResValDt("concepto='totded'", "Semana " & semAnt, dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 5, ResValDt("concepto='totded'", "Diferencia", dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin + 1, 6, ResValDt("concepto='totded'", "Variabilidad", dtTotales), Color.FromArgb(0, 0, 0), True, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "0.00%")
                fin = fin + 2

                Dim netoSemAct As Double = netoPerDed.Item(0) - netoPerDed.Item(3)
                Dim netoSemAnt As Double = netoPerDed.Item(1) - netoPerDed.Item(4)
                Dim netoDif As Double = netoPerDed.Item(2) - netoPerDed.Item(5)

                FormatoCelda(hoja_excel, 0, fin, 1, "NETO", Color.Black, True, "", True, Color.FromArgb(155, 194, 230))
                FormatoCelda(hoja_excel, 0, fin, 2, "NETO", Color.Black, True, "", True, Color.FromArgb(155, 194, 230))
                FormatoCelda(hoja_excel, 0, fin, 3, netoSemAct, Color.Black, True, "", True, Color.FromArgb(155, 194, 230), Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin, 4, netoSemAnt, Color.Black, True, "", True, Color.FromArgb(155, 194, 230), Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin, 5, netoDif, Color.Black, True, "", True, Color.FromArgb(155, 194, 230), Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                FormatoCelda(hoja_excel, 0, fin, 6, IIf(netoSemAnt > 0, Math.Round(netoSemAct - netoSemAnt) / netoSemAnt, 100), Color.Black, True, "", True, Color.FromArgb(155, 194, 230), Style.ExcelHorizontalAlignment.Right, True, "0.00%")
                fin = fin + 3

                FormatoCelda(hoja_excel, 0, fin, 1, "MOVIMIENTOS ALTAS", Color.FromArgb(0, 0, 0), True, "") : rango = RangoCeldasExcel(fin, 1, 4) : paramAdicionales.Clear()
                FormatoCelda(hoja_excel, 1, fin, 1, "", Color.FromArgb(0, 0, 0), True, rango, True, Color.FromArgb(91, 155, 213))
                paramAdicionales.Add("Reloj,Nombre,Fecha_alta,Sueldo")
                paramAdicionales.Add(Color.FromArgb(91, 155, 213))
                paramAdicionales.Add(Color.FromArgb(255, 255, 255))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtAltas, fin + 1, paramAdicionales, fin)
                fin = fin + 2

                FormatoCelda(hoja_excel, 0, fin, 1, "MOVIMIENTOS BAJAS", Color.FromArgb(0, 0, 0), True, "") : rango = RangoCeldasExcel(fin, 1, 3) : paramAdicionales.Clear()
                FormatoCelda(hoja_excel, 1, fin, 1, "", Color.FromArgb(0, 0, 0), True, rango, True, Color.FromArgb(91, 155, 213))
                paramAdicionales.Add("Reloj,Nombre,Fecha_baja")
                paramAdicionales.Add(Color.FromArgb(91, 155, 213))
                paramAdicionales.Add(Color.FromArgb(255, 255, 255))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtBajas, fin + 1, paramAdicionales, fin)
                fin = fin + 2

                FormatoCelda(hoja_excel, 0, fin, 1, "CAMBIOS DE SUELDO", Color.FromArgb(0, 0, 0), True, "") : rango = RangoCeldasExcel(fin, 1, 6) : paramAdicionales.Clear()
                FormatoCelda(hoja_excel, 1, fin, 1, "", Color.FromArgb(0, 0, 0), True, rango, True, Color.FromArgb(91, 155, 213))
                paramAdicionales.Add("Reloj,Nombre,Sueldo_anterior,Sueldo_nuevo,Variacion,Fecha")
                paramAdicionales.Add(Color.FromArgb(91, 155, 213))
                paramAdicionales.Add(Color.FromArgb(255, 255, 255))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))

                FormatoTablaCompleta(True, hoja_excel, dtCambiosSueldo, fin + 1, paramAdicionales, fin, "CambSueldo")
                Dim totPer = 0, totDed = 0, totAlta = 0, totBaja = 0, totSueldo = 0
                Try : totPer = dtPercepciones.Rows.Count : Catch ex As Exception : totPer = 0 : End Try
                Try : totDed = dtDeducciones.Rows.Count : Catch ex As Exception : totDed = 0 : End Try
                Try : totAlta = dtAltas.Rows.Count : Catch ex As Exception : totAlta = 0 : End Try
                Try : totBaja = dtBajas.Rows.Count : Catch ex As Exception : totBaja = 0 : End Try
                Try : totSueldo = dtCambiosSueldo.Rows.Count : Catch ex As Exception : totSueldo = 0 : End Try

                totalRegistros = totPer + totDed + totAlta + totBaja + totSueldo

                hoja_excel.SelectedRange("A4:F" & (totalRegistros + 5).ToString & "").AutoFitColumns()
                hoja_excel.PrinterSettings.HorizontalCentered = True
                hoja_excel.PrinterSettings.Scale = 60
                hoja_excel.PrinterSettings.TopMargin = 0.748
                hoja_excel.PrinterSettings.BottomMargin = 0.748
                hoja_excel.PrinterSettings.LeftMargin = 0.236
                hoja_excel.PrinterSettings.RightMargin = 0.236

                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                cont += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteComparativoNomina. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteComparativoNomina", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel para prenómina normal y finiquitos. -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="tipoPrenom">Si es normal o finiquito</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="ct">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReportePrenomina(ByVal dirGuardar As String, verProc As String, tipoPrenom As String, ByVal data As Dictionary(Of String, String), ByRef ct As Integer)
        Try
            '/*Tablas utilizadas: personal, movimientos_pro, movimientos_calculo,conceptos,nomina_pro*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = "{0} Prenomina" & IIf(tipoPrenom = "Normal", "", " Finiquitos") & " sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, "CTE TRANSPORTE", data("codComp"))
            Dim dirArchivo As String = dirGuardar & String.Format(strNomReporte, strCia) & " V" & verProc & ".xlsx"

            If _dtMovimientosPro.Rows.Count > 0 And _dtConceptosCatalogo.Rows.Count > 0 Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '-- Se generan diferentes hojas para cada planta
                Dim lstPlantas = (From i In Me.NominaPro Select i("cod_comp").ToString.Trim).ToList.Distinct

                For Each rowPlanta In lstPlantas
                    Dim strFiltro = {"procesar='True' and (finiquito='True' or finiquito_esp='True') and cod_comp in ('" & rowPlanta & "')", "cod_comp in ('" & rowPlanta & "')"}
                    Dim dtNomPro = (New DataView(_dtNominaPro, IIf(tipoPrenom = "Finiquitos", strFiltro(0), strFiltro(1)), "reloj", DataViewRowState.CurrentRows)).ToTable("", False)
                    Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(String.Format(strNomReporte, rowPlanta))
                    Dim dtInfoPer = (New DataView(_dtPersonalvw, "", "reloj", DataViewRowState.CurrentRows)).ToTable("", False, "reloj", "imss", "dig_ver", "centro_costos", "rfc", "nombre_clerk", "submotivo_baja")

                    Dim relojes As New ArrayList
                    Dim x = 2
                    Dim y = 0
                    Dim rango = ""
                    Dim paramAdicionales As New ArrayList
                    Dim indice As Integer = 0

                    Dim nomCol = "ano,periodo,reloj,nombres,cod_tipo,cod_clase,rfc,cod_depto,centro_costos,num_imss,alta,alta_antig,baja,sactual,integrado,cod_puesto,puesto," & _
                                 "supervisor,cod_hora,sindicalizado,tipo_credito,factor_infonavit,porc_pension,percepcion_gravable,percepcion_exenta,[conNom]"
                    Dim tipoCol = "String,String,String,String,String,String,String,String,String,String,String,String,String,Double,Double,String,String,String,String,String,String,Double,Double,Double,Double,[conTipo]"
                    Dim noColPrincipales = nomCol.Split(",").Count

                    Dim nomColFaltante = ""
                    Dim tipoColFaltante = ""
                    Dim reloj = ""
                    Dim dtPerActualMovs As DataTable = _dtMovimientosPro.Clone
                    Dim dtConPerActual As DataTable
                    Dim dtRelojesPerActual As DataTable
                    Dim dtEstructura As DataTable
                    Dim infoPersonal = True
                    Dim agregaEncabezado = True
                    Dim nomEncabezado = ""
                    Dim existePer As Boolean

                    Dim relojesFini = "", relojesFinEsp As DataTable = Nothing, dtBajaNomCalc As DataTable = Nothing

                    For Each row As DataRow In _dtMovimientosPro.Select("periodo+ano='" & data("periodo") & data("ano") & "'", "reloj")
                        existePer = Not IsNothing(ResValDt("reloj='" & row.Item("reloj").ToString.Trim & "'", "reloj", dtNomPro, True))
                        If existePer Then
                            dtPerActualMovs.ImportRow(row)
                        End If
                    Next

                    dtConPerActual = dtPerActualMovs.DefaultView.ToTable(True, "concepto")
                    dtRelojesPerActual = dtPerActualMovs.DefaultView.ToTable(True, "reloj")
                    Dim dtPensionMovsPro = Nothing : Dim dtGravExe = Nothing
                    Try : dtPensionMovsPro = _dtMovimientosPro.Select("concepto in ('PORPEN')").CopyToDataTable : Catch ex As Exception : End Try
                    Try : dtGravExe = _dtMovimientosPro.Select("concepto in ('PERGRA','PEREXE')").CopyToDataTable : Catch ex As Exception : End Try

                    '-- Si el reporte es de finiquitos especiales, consultar baja de empleado en nomina_calculo en caso de que no la tenga
                    Try
                        relojesFini = "(" & String.Join(",", (From i In dtRelojesPerActual.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ")"
                        relojesFinEsp = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro WHERE reloj in " & relojesFini & " and finiquito_esp='True'")
                        dtBajaNomCalc = sqlExecute("select reloj,baja_finqto from nomina.dbo.nomina_calculo where reloj in " &
                                                       "(" & String.Join(",", (From i In relojesFinEsp.Rows Select "'" & i("reloj").ToString.Trim & "'")) & ") and " &
                                                       "finiq_especial_ano='" & data("ano") & "' and finiq_especial_periodo='" & data("periodo") & "' and " &
                                                       "finiq_especial_tipo='" & data("tipoPeriodo") & "'")
                    Catch ex As Exception : End Try

                    For i = 0 To 1
                        Dim conVw As New DataView(_dtConceptosCatalogo, IIf(i = 0, "cod_naturaleza='P' and suma_neto=1 and activo=1 and positivo=1", "cod_naturaleza='D' and suma_neto=1 and activo=1 and positivo=0"),
                                                  "prioridad", DataViewRowState.CurrentRows)
                        Dim dtCon = conVw.ToTable("", False)

                        For Each concepto In dtCon.Select("concepto is not null", "prioridad")
                            Dim existeCon = ResValDt(" concepto='" & concepto.Item("concepto").ToString.Trim & "'", "concepto", dtConPerActual, True)
                            If Not IsNothing(existeCon) Then
                                Dim detalle = concepto.Item("detalle").ToString.Trim
                                If Not IsDBNull(detalle) Then
                                    If detalle = "DIDESP" Then detalle = ""
                                End If
                                Dim resultadoBool = IsDBNull(detalle) Or detalle.ToString.Length < 2
                                existeCon = existeCon.ToString.Trim
                                nomColFaltante &= IIf(resultadoBool, existeCon & ",", detalle & "," & existeCon & ",")
                                tipoColFaltante &= IIf(resultadoBool, "Double,", "Double,Double,")
                            End If
                        Next

                        If i = 0 Then nomColFaltante &= "TOTPER," : tipoColFaltante &= "Double," Else nomColFaltante &= "TOTDED," : tipoColFaltante &= "Double,"
                        'If i = 1 Then nomColFaltante &= "NETO,DIDESP,BONDES,BONPA1,BONPA2,BONPA3" : tipoColFaltante &= "Double,Double,Double,Double,Double,Double"
                        If i = 1 Then nomColFaltante &= "NETO" : tipoColFaltante &= "Double"
                    Next

                    Dim dtPerConceptos As New DataView(_dtConceptosCatalogo, "cod_naturaleza='P'", "prioridad", DataViewRowState.CurrentRows)
                    Dim dtPercepciones As DataTable = dtPerConceptos.ToTable()
                    Dim cont = 0
                    Dim gravable As Double = 0.0
                    Dim exento As Double = 0.0
                    Dim filtro = Replace(nomColFaltante, ",", "','")
                    Dim boolConValidos = False
                    Dim perex = 0.0
                    Dim pergra = 0.0
                    Dim numColumnas = 0
                    Dim dtMovimientosProFiltro = If(dtPerActualMovs.Rows.Count > 0, dtPerActualMovs.Select("concepto in ('" & filtro & "')").CopyToDataTable, dtPerActualMovs.Clone)
                    nomCol = Replace(nomCol, "[conNom]", nomColFaltante)
                    tipoCol = Replace(tipoCol, "[conTipo]", tipoColFaltante)
                    dtEstructura = creaDt(nomCol, tipoCol)

                    For Each relojRow As DataRow In dtRelojesPerActual.Rows
                        Dim nRow = dtEstructura.NewRow
                        reloj = Trim(relojRow.Item("reloj"))

                        For Each conRow As DataRow In dtMovimientosProFiltro.Select("reloj='" & reloj & "'")
                            Dim conceptoTemp = Trim(conRow.Item("concepto").ToString)
                            boolConValidos = True

                            If infoPersonal Then
                                Dim puesto = ResValDt("reloj='" & reloj & "'", "cod_puesto", _dtNominaPro, True)
                                puesto = ValNullStr(ResValDt("cod_puesto='" & puesto & "'", "nombre", _dtPuestos, True))

                                Dim super = ResValDt("reloj='" & reloj & "'", "cod_super", _dtNominaPro, True)
                                super = ValNullStr(ResValDt("cod_super='" & super & "'", "nombre", _dtSuper, True))

                                nRow.Item("ano") = conRow.Item("ano")
                                nRow.Item("periodo") = conRow.Item("periodo")
                                nRow.Item("reloj") = reloj
                                nRow.Item("nombres") = ValNullStr(ResValDt("reloj='" & reloj & "'", "nombres", _dtNominaPro, True))
                                nRow.Item("cod_tipo") = ValNullStr(ResValDt("reloj='" & reloj & "'", "cod_tipo", _dtNominaPro, True))
                                nRow.Item("cod_clase") = ValNullStr(ResValDt("reloj='" & reloj & "'", "cod_clase", _dtNominaPro, True))
                                nRow.Item("rfc") = ValNullStr(ResValDt("reloj='" & reloj & "'", "rfc", dtInfoPer, True))
                                nRow.Item("cod_depto") = ValNullStr(ResValDt("reloj='" & reloj & "'", "cod_depto", _dtNominaPro, True))
                                nRow.Item("centro_costos") = ValNullStr(ResValDt("reloj='" & reloj & "'", "centro_costos", dtInfoPer, True))
                                nRow.Item("num_imss") = ValNullStr(ResValDt("reloj='" & reloj & "'", "imss", dtInfoPer, True)) & ValNullStr(ResValDt("reloj='" & reloj & "'", "dig_ver", dtInfoPer, True))

                                Try : nRow.Item("alta") = FechaSQL(ResValDt("reloj='" & reloj & "'", "alta", _dtNominaPro, True)) : Catch ex As Exception : nRow.Item("alta") = "- -" : End Try
                                Try : nRow.Item("alta_antig") = FechaSQL(ResValDt("reloj='" & reloj & "'", "alta_antig", _dtNominaPro, True)) : Catch ex As Exception : nRow.Item("alta_antig") = "- -" : End Try
                                Try : nRow.Item("baja") = FechaSQL(ResValDt("reloj='" & reloj & "'", "baja", _dtNominaPro, True)) : Catch ex As Exception : nRow.Item("baja") = "- -" : End Try

                                '-- Si es finiquito especial y no tiene baja
                                Try
                                    If nRow.Item("baja") = "- -" Then
                                        Dim nuevaBaja = dtBajaNomCalc.Select("reloj='" & reloj & "'")
                                        If nuevaBaja.Count > 0 Then
                                            Try : nRow.Item("baja") = FechaSQL(nuevaBaja(0)("baja_finqto"))
                                            Catch ex As Exception : nRow.Item("baja") = "- -" : End Try
                                        End If
                                    End If
                                Catch ex As Exception : End Try

                                nRow.Item("sactual") = ResValDt("reloj='" & reloj & "'", "sactual", _dtNominaPro, True)
                                nRow.Item("integrado") = ResValDt("reloj='" & reloj & "'", "integrado", _dtNominaPro, True)
                                nRow.Item("cod_puesto") = ValNullStr(ResValDt("reloj='" & reloj & "'", "cod_puesto", _dtNominaPro, True))
                                nRow.Item("puesto") = puesto
                                nRow.Item("supervisor") = super
                                nRow.Item("cod_hora") = ValNullStr(ResValDt("reloj='" & reloj & "'", "cod_hora", _dtNominaPro, True))
                                Try : nRow.Item("sindicalizado") = IIf(ResValDt("reloj='" & reloj & "'", "sindicalizado", _dtNominaPro, True) = 1, "Si", "No") : Catch ex As Exception : nRow.Item("sindicalizado") = "No" : End Try
                                nRow.Item("tipo_credito") = IIf(IsDBNull(ResValDt("reloj='" & reloj & "'", "tipo_credito", _dtNominaPro, True)), "0", ResValDt("reloj='" & reloj & "'", "tipo_credito", _dtNominaPro, True))
                                nRow.Item("factor_infonavit") = ResValDt("reloj='" & reloj & "'", "cuota_credito", _dtNominaPro, True)
                                Try : nRow.Item("porc_pension") = ResValDt("reloj='" & reloj & "'", "monto", dtPensionMovsPro, True) : Catch ex As Exception : nRow.Item("porc_pension") = 0.0 : End Try
                                Try : pergra = ResValDt("reloj='" & reloj & "' and concepto='PERGRA'", "monto", dtGravExe, True) : Catch ex As Exception : pergra = 0.0 : End Try
                                Try : perex = ResValDt("reloj='" & reloj & "' and concepto='PEREXE'", "monto", dtGravExe, True) : Catch ex As Exception : perex = 0.0 : End Try
                                nRow.Item("percepcion_gravable") = pergra
                                nRow.Item("percepcion_exenta") = perex
                                dtEstructura.Rows.Add(nRow)

                                Dim conCol() = Split(nomColFaltante, ",") : Dim temp = ""

                                For Each name As String In conCol
                                    dtEstructura.Rows(cont)(name) = 0
                                    If agregaEncabezado Then nomEncabezado &= IIf(name = "DIAS_DESPENSA", "DIAS DESPENSA,", ResValDt("concepto='" & name & "'", "nombre", _dtConceptosCatalogo, True) & ",") : numColumnas += 1
                                Next

                                infoPersonal = False
                                agregaEncabezado = False
                            End If

                            Try : dtEstructura.Rows(cont)(conceptoTemp) = Math.Round(conRow.Item("monto"), 2) : Catch ex As Exception : End Try
                        Next

                        If boolConValidos Then
                            boolConValidos = False
                            cont += 1
                        End If

                        infoPersonal = True
                    Next

                    FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                    FormatoCelda(hoja_excel, 0, 2, 1, "Prenomina " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")

                    Dim fin = 0

                    If nomEncabezado.ToString.Length > 0 Then
                        paramAdicionales.Add(nomEncabezado.Substring(0, nomEncabezado.Length - 1))
                        paramAdicionales.Add(Color.FromArgb(166, 166, 166))
                        paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                        FormatoTablaCompleta(True, hoja_excel, Nothing, 3, paramAdicionales, fin, "", noColPrincipales) : paramAdicionales.Clear()
                    End If


                    paramAdicionales.Add(nomCol)
                    paramAdicionales.Add(Color.FromArgb(217, 217, 217))
                    paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                    paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                    FormatoTablaCompleta(True, hoja_excel, dtEstructura, 4, paramAdicionales, fin)

                    Dim intCol = noColPrincipales

                    FormatoCelda(hoja_excel, 0, fin, intCol - 1, "Totales", Color.Black, True, "", True, Color.FromArgb(217, 217, 217))
                    Dim arrCol = Split(nomColFaltante, ",")

                    For Each c In arrCol
                        Dim strFormula = "=SUM(" & RangoCeldasExcel(Nothing, intCol, intCol, 5, dtEstructura.Rows.Count + 4) & ")"
                        FormatoCelda(hoja_excel, 3, fin, intCol, strFormula, Color.Black, False, "", True, Color.FromArgb(217, 217, 217), Style.ExcelHorizontalAlignment.Right)
                        intCol += 1
                    Next

                    Dim totalRegistros = dtEstructura.Rows.Count + 5
                    Dim rangoFinal = RangoCeldasExcel(3, 1, (noColPrincipales - 1) + numColumnas)
                    Dim rangoTot() = Split(rangoFinal, ":")
                    Dim strRango = rangoTot(0) & ":" & rangoTot(1).Replace(rangoTot(1).Substring(rangoTot(1).Length - 1, 1), totalRegistros.ToString)
                    hoja_excel.SelectedRange(strRango).AutoFitColumns()

                    If tipoPrenom = "Normal" Then hoja_excel.Protection.SetPassword("PIDA" & data("ano"))
                Next

                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                ct += 1
                freeMemory()

            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReportePrenomina. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReportePrenomina", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de excel para desglosar conceptos por renglones. -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="c">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteDiferenciasDetalle(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef c As Integer)
        Try
            '/*Tablas utilizadas: conceptos, movimientos_pro, movimientos*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Diferencias detalle sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, "CTE TRANSPORTE", data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim paramAdicionales As New ArrayList
            Dim perAnt = PeriodoAnterior(data("periodo") & data("ano"), _dtPeriodos)
            Dim perAct = data("periodo")
            Dim lstReloj As New List(Of String)
            Dim cont = 0

            Dim dtNombresEmp = sqlExecute("select reloj,(rtrim(nombre) + ' ' + rtrim(apaterno) + ' ' + rtrim(amaterno)) as nombres from personal.dbo.personal")

            If _dtMovimientos.Rows.Count > 0 And _dtMovimientosPro.Rows.Count > 0 Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim columnasNom = "Reloj,Nombres,Concepto,Descripcion,Sem_Actual,Sem_Anterior,Diferencia,Porcentaje"
                Dim columnasTipo = "Integer,String,String,String,Double,Double,Double,Double"
                Dim dtEstructura = creaDt(columnasNom, columnasTipo)
                Dim dtTemp = New DataView(_dtMovimientos, "reloj is not null", "reloj", DataViewRowState.CurrentRows)
                Dim dtMvtsAnt = dtTemp.ToTable("", False, "reloj", "concepto", "monto", "periodo")
                dtTemp = New DataView(_dtMovimientosPro, "reloj is not null", "reloj", DataViewRowState.CurrentRows)
                Dim dtMvtsActual = dtTemp.ToTable("", False, "reloj", "concepto", "monto", "periodo")

                For Each semAnt As DataRow In dtMvtsAnt.Rows
                    Dim relojAnt = semAnt.Item("reloj").ToString.Trim
                    Dim concepAnt = semAnt.Item("concepto").ToString.Trim
                    Dim montoAnt = semAnt.Item("monto")
                    Dim filtro = "periodo='" & data("periodo") & "' and reloj='" & relojAnt & "' and concepto='" & concepAnt & "'"

                    If ResValDt(filtro, "reloj", dtMvtsActual, True) IsNot Nothing Then
                        Dim montoAct = ResValDt("reloj='" & relojAnt & "' and concepto='" & concepAnt & "' and periodo='" & data("periodo") & "'", "monto", dtMvtsActual, True)
                        If montoAnt <> montoAct Then
                            Dim newR = dtEstructura.NewRow
                            newR.Item("reloj") = relojAnt
                            newR.Item("concepto") = concepAnt
                            newR.Item("sem_actual") = montoAct
                            newR.Item("sem_anterior") = montoAnt
                            newR.Item("descripcion") = ValNullStr(ResValDt("concepto='" & concepAnt & "'", "nombre", _dtConceptosCatalogo, True))
                            dtEstructura.Rows.Add(newR)
                        End If
                    Else
                        Dim newR = dtEstructura.NewRow
                        newR.Item("reloj") = relojAnt
                        newR.Item("concepto") = concepAnt
                        newR.Item("sem_actual") = 0.0
                        newR.Item("sem_anterior") = montoAnt
                        newR.Item("descripcion") = ValNullStr(ResValDt("concepto='" & concepAnt & "'", "nombre", _dtConceptosCatalogo, True))
                        dtEstructura.Rows.Add(newR)
                    End If
                Next

                For Each semAct As DataRow In dtMvtsActual.Rows
                    Dim relojActual = semAct.Item("reloj").ToString.Trim
                    Dim conceptoActual = semAct.Item("concepto").ToString.Trim
                    Dim montoActual = semAct.Item("monto")
                    If ResValDt("concepto='" & conceptoActual & "' and cod_naturaleza in ('P','D')", "concepto", _dtConceptosCatalogo, True) IsNot Nothing Then
                        If ResValDt("reloj='" & relojActual & "' and concepto='" & conceptoActual & "'", "reloj", dtMvtsAnt, True) Is Nothing Then
                            Dim newR = dtEstructura.NewRow
                            newR.Item("reloj") = relojActual
                            newR.Item("concepto") = conceptoActual
                            newR.Item("sem_actual") = montoActual
                            newR.Item("sem_anterior") = 0.0
                            newR.Item("descripcion") = ValNullStr(ResValDt("concepto='" & conceptoActual & "'", "nombre", _dtConceptosCatalogo, True))
                            dtEstructura.Rows.Add(newR)
                        End If
                    End If
                Next

                '-- Agregar nombre de empleado
                For Each nom In dtEstructura.Rows
                    Try
                        nom("nombres") = dtNombresEmp.Select("reloj='" & nom("reloj") & "'").First.Item("nombres")
                    Catch ex As Exception
                        nom("nombres") = ""
                    End Try
                Next

                For i As Integer = 0 To dtEstructura.Rows.Count - 1
                    dtEstructura.Rows(i)("diferencia") = Math.Round(dtEstructura.Rows(i)("sem_actual") - dtEstructura.Rows(i)("sem_anterior"), 2)
                    dtEstructura.Rows(i)("porcentaje") = IIf(dtEstructura.Rows(i)("sem_anterior") = 0, 1, Math.Round((dtEstructura.Rows(i)("sem_actual") - dtEstructura.Rows(i)("sem_anterior")) / dtEstructura.Rows(i)("sem_anterior"), 6))
                Next

                Dim vwRes = New DataView(dtEstructura, "diferencia <> 0", "reloj", DataViewRowState.CurrentRows)
                Dim dtRes = vwRes.ToTable("", False)
                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Diferencias detalle  " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                paramAdicionales.Add("Reloj,Nombres,Concepto,Descripcion,Sem_Actual,Sem_anterior,Diferencia,Porcentaje")
                paramAdicionales.Add(Color.FromArgb(217, 217, 217))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtRes, 4, paramAdicionales, 0, "DifPor")
                hoja_excel.SelectedRange("A4:H" & (dtRes.Rows.Count + 5).ToString).AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                c += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteDiferenciasDetalle. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteDiferenciasDetalle", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de pensiones alimenticias (en textfile). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="cont">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub TextReportePensionesAlimenticias(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef cont As Integer)
        Try
            '/*Tablas utilizadas: nomina_pro, movimientos_pro, pensiones_alimenticias*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Pensiones alimenticias sem " & aPer
            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".txt"                                                                                                                          '-- Proceso

            If System.IO.File.Exists(dirArchivo) Then System.IO.File.Delete(dirArchivo)

            If _dtPensionesAlim.Rows.Count > 0 Then
                Dim docTxt = New StreamWriter(dirArchivo, True)
                Dim strRenglon = ""
                Dim temp = ""

                Dim dtNombresEmpleados = sqlExecute("select reloj,(rtrim(APATERNO)+' '+rtrim(AMATERNO)+' '+rtrim(NOMBRE)) as nombres from personal.dbo.personal")
                Dim dtPenMovs = Nothing
                Try : dtPenMovs = _dtMovimientosPro.Select("periodo+ano='" & data("periodo") & data("ano") & "' and concepto in ('PENAL1','PENAL2')").CopyToDataTable() : Catch ex As Exception : End Try

                If Not dtPenMovs Is Nothing Then
                    For i As Integer = 0 To 1
                        Dim indice = IIf(i = 0, 1, 2)

                        For Each x As DataRow In dtPenMovs.Select("concepto='PENAL" & indice.ToString & "'", "reloj asc")
                            Dim _reloj = x.Item("reloj").ToString.Trim

                            If ResValDt("reloj='" & _reloj & "' and periodo+ano='" & data("periodo") & data("ano") & "'", "reloj", _dtNominaPro, True) IsNot Nothing Then
                                For Each z As DataRow In _dtPensionesAlim.Select("reloj='" & _reloj & "' and num_pensio=" & indice & "")
                                    If ValNullStr(z.Item("cuaderno")) <> "" Then
                                        Dim strCuaderno = Trim(z.Item("cuaderno"))
                                        Dim strNombres = Trim(ResValDt("reloj='" & _reloj & "'", "nombres", dtNombresEmpleados, True))
                                        Dim strPensionado = Trim(ResValDt("reloj='" & _reloj & "' and num_pensio=" & indice & "", "pensionado", _dtPensionesAlim, True))
                                        Dim strMonto = CStr(Math.Round(x.Item("monto"), 2))
                                        strRenglon &= strCuaderno & "," & strNombres & ",," & strPensionado & "," & strMonto & vbNewLine
                                    Else
                                        Continue For
                                    End If
                                Next
                            End If

                        Next
                    Next
                End If

                docTxt.WriteLine(strRenglon)
                docTxt.Close()
                cont += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReportePensionesAlimenticias. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "TextReportePensionesAlimenticias", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de horas no aplicadas (horas_pro) (excel). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="c">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteHorasNoAplicadas(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef c As Integer)
        Try
            '/*Tablas utilizadas: horas_pro, movimientos_pro, personal,nomina_calculo,conceptos,conceptos_rezagados*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Horas No Aplicadas sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim paramAdicionales As New ArrayList
            Dim anio = ""
            Dim periodo = ""
            Dim baja = Nothing
            Dim reloj = ""
            Dim neto = ""
            Dim nombres = ""
            Dim observaciones = ""
            Dim concepto = ""
            Dim descripcion = ""
            Dim monto = 0.0
            Dim alta = Nothing
            Dim fha_incidencia = ""
            Dim factor = 0.0
            Dim sueldo = 0.0

            If _dtMovimientosPro.Rows.Count > 0 And _dtHorasPro.Rows.Count > 0 Then

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim dtEstructura = creaDt("Año,Periodo,Reloj,Nombre,Concepto,Descripción,Monto,Observaciones,Fecha,Factor,Sueldo", "String,String,String,String,String,String,Double,String,String,Double,Double")
                Dim dtTemp As New DataView(_dtPersonalvw, "", "reloj", DataViewRowState.CurrentRows)
                Dim dtPersonal = dtTemp.ToTable("", False, "reloj", "nombres", "baja", "inactivo", "alta")

                Dim dtTempHoras = _dtHorasPro.Copy : dtTempHoras.Merge(_dtHorasLazy)
                Dim dtHrsPro = (New DataView(_dtHorasPro, "concepto not in ('DIANOR')", "reloj", DataViewRowState.CurrentRows)).ToTable("", False, "ano", "periodo", "reloj", "concepto", "descripcion", "monto", "fecha", "factor")

                Dim dtTemp3 As New DataView(_dtMovimientosPro, "", "reloj", DataViewRowState.CurrentRows)
                Dim dtMovsPro = dtTemp3.ToTable("", False, "reloj", "concepto", "monto")
                Dim dtTemp5 As New DataView(_dtConceptosCatalogo, "", "concepto", DataViewRowState.CurrentRows)
                Dim dtCon = dtTemp5.ToTable("", False, "concepto", "nombre")
                Dim dtHrsProMov As DataTable = dtHrsPro.Clone : Dim ingresar As Boolean = True

                For Each i As DataRow In dtHrsPro.Rows
                    For Each j As DataRow In dtMovsPro.Select("reloj='" & i.Item("reloj").ToString.Trim & "' and concepto='" & i.Item("concepto").ToString.Trim & "'")
                        ingresar = False
                        Exit For
                    Next
                    If ingresar Then
                        dtHrsProMov.ImportRow(i)
                    Else
                        ingresar = True
                    End If
                Next

                '-- Omitir registros de empleados con bajas previas al inicio del periodo -- Ernesto -- 12 dic 2023
                Dim strPeriodo = data("ano") & data("periodo")
                Dim dtPeriodo = sqlExecute("select ano+periodo as periodo,fecha_ini from ta.dbo." &
                                           If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where ano+periodo='" & strPeriodo & "'")
                Dim strRelojes = String.Join(",", (From i In dtHrsProMov Select "'" & i("reloj") & "'").Distinct)
                Dim dtPer = Sqlite.getInstance.sqliteExecute("select reloj,baja from nominaPro where (baja is null or date(baja)>='" &
                                       FechaSQL(dtPeriodo.Rows(0)("fecha_ini")) & "') and reloj in (" & strRelojes & ")")

                For Each row As DataRow In dtHrsProMov.Rows

                    '-- Omitir registros de empleados con bajas previas al inicio del periodo -- Ernesto -- 12 dic 2023
                    If dtPer.Select("reloj='" & row("reloj") & "'").Count = 0 Then Continue For

                    reloj = row.Item("reloj").ToString.Trim
                    neto = ResValDt("reloj='" & reloj & "' and concepto in ('NETO')", "monto", dtMovsPro, True)
                    nombres = Trim(ResValDt("reloj='" & reloj & "'", "nombres", dtPersonal, True))
                    anio = Trim(row.Item("ano"))
                    periodo = Trim(row.Item("periodo"))
                    concepto = Trim(row.Item("concepto"))
                    descripcion = Trim(ResValDt("concepto='" & row.Item("concepto").ToString.Trim & "'", "nombre", dtCon, True))
                    monto = Math.Round(row.Item("monto"), 2)
                    alta = FechaSQL(ResValDt("reloj='" & reloj & "'", "alta", dtPersonal, True))

                    If Not IsDBNull(row.Item("fecha")) Then fha_incidencia = FechaSQL(row.Item("fecha")) Else fha_incidencia = "- -"
                    If Not IsDBNull(row.Item("factor")) Then factor = row.Item("factor") Else factor = 0.0

                    sueldo = ResValDt("reloj='" & reloj & "'", "sactual", _dtNominaPro, True)
                    baja = ValNullStr(ResValDt("reloj='" & reloj & "'", "baja", dtPersonal, True))

                    If Not baja.GetType() Is GetType(System.DateTime) Then observaciones = baja Else observaciones = "Baja " & FechaSQL(baja)
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and inactivo=1", "inactivo", dtPersonal, True) Is Nothing, "Suspendido", "")

                    Dim finiquitoBool = (Not IsNothing(ResValDt("reloj='" & reloj & "'", "reloj", _dtFiniE))) OrElse (Not IsNothing(ResValDt("reloj='" & reloj & "'", "reloj", _dtFiniN)))
                    If finiquitoBool Then observaciones = "Finiquito en proceso" : Continue For

                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAIMA')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad por maternidad", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAING')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad general", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAITR')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad riesgo trabajo", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAFIN')", "concepto", dtMovsPro, True) Is Nothing, "Ausentismo", "")
                    If observaciones = "" Then observaciones = IIf(Not neto Is Nothing, IIf(neto = 0.0, "Sin neto", "Neto " & CStr(neto)), "Sin neto")

                    Dim newR As DataRow = dtEstructura.NewRow
                    newR.Item("Año") = anio : newR.Item("Periodo") = periodo : newR.Item("Reloj") = reloj : newR.Item("Nombre") = nombres
                    newR.Item("Concepto") = concepto : newR.Item("Descripción") = descripcion : newR.Item("monto") = monto : newR.Item("observaciones") = observaciones
                    newR.Item("Fecha") = fha_incidencia : newR.Item("Factor") = factor : newR.Item("Sueldo") = sueldo
                    dtEstructura.Rows.Add(newR)
                Next

                ConceptosRezagadosDt(dtEstructura, "Horas_no_aplicadas", "Concepto,Descripción,Monto,Observaciones,Fecha,Factor,Sueldo", data("ano") & data("periodo"), data("tipoPeriodo"))
                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Horas No Aplicadas  " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                paramAdicionales.Add("Año,Periodo,Reloj,Nombre,Concepto,Descripción,Monto,Observaciones,Fecha,Factor,Sueldo")
                paramAdicionales.Add(Color.FromArgb(217, 217, 217))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtEstructura, 4, paramAdicionales, 0, "Descr")

                hoja_excel.SelectedRange("A4:H" & (dtEstructura.Rows.Count + 5).ToString).AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                c += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteHorasNoAplicadas. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteHorasNoAplicadas", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de miscelaneos no aplicados (horas_pro) (excel). -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="ct">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteMiscNoAplicados(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef ct As Integer)
        Try
            '/*Tablas utilizadas: ajustes_pro, movimientos_pro, personalvw,nomina_calculo,conceptos,conceptos_rezagados,no_descuentos*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Miscelaneos No Aplicados sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))

            Dim dirArchivo As String = dirGuardar & strNomReporte & " v" & verProc & ".xlsx"
            Dim paramAdicionales As New ArrayList
            Dim anio = ""
            Dim periodo = ""
            Dim reloj = ""
            Dim neto = ""
            Dim nombres = ""
            Dim observaciones = ""
            Dim concepto = ""
            Dim descripcion = ""
            Dim fecha = Nothing
            Dim monto = 0.0
            Dim factor = 0.0
            Dim sueldo = 0.0
            Dim baja = Nothing
            Dim descuento_cc = False
            Dim alta = Nothing

            If _dtAjustesPro.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim dtEstructura = creaDt("Año,Periodo,Reloj,Nombre,Concepto,Descripción,Fecha,Observaciones,Monto,Sueldo,Factor", "String,String,String,String,String,String,String,String,Double,Double,Double")
                Dim dtTemp = New DataView(_dtMovimientosPro, "", "reloj", DataViewRowState.CurrentRows)
                Dim dtMovsPro = dtTemp.ToTable("", False, "ano", "periodo", "reloj", "concepto", "monto")


                Dim dtTempAjustes = _dtAjustesPro.Copy : dtTempAjustes.Merge(_dtAjustesLazy)
                Dim dtAjustes = (New DataView(dtTempAjustes, "concepto not in ('HRSEXA','HRS233','HRS333','HRSNOR')", "reloj", DataViewRowState.CurrentRows)).ToTable("", False, "reloj", "ano", "periodo", "concepto", "descripcion", "monto", "factor", "sueldo", "fecha")
                Dim dtAjustesPro = dtAjustes.Clone

                Dim dtTemp3 = New DataView(_dtPersonalvw, "", "reloj", DataViewRowState.CurrentRows)
                Dim dtPersonal = dtTemp3.ToTable("", False, "reloj", "nombres", "baja", "inactivo", "alta")
                Dim dtTemp5 = New DataView(_dtConceptosCatalogo, "", "concepto", DataViewRowState.CurrentRows)
                Dim dtCon = dtTemp5.ToTable("", False, "concepto", "nombre")
                Dim dtNoDesc = sqlExecute("select reloj from nomina.dbo.no_descuentos")
                dtCon.Columns.Add("revisa_tabla", GetType(System.Boolean))
                Dim revisaTblCon = "concepto in ('TIENDA','AHOALC','ADEINF','CAJPMO','CAPACI','RECFNT','ADEIN1','ADEIN2','ADEIN3','ADEIN4','ADEIN5','ADEIN6','TIEN01','TIEN02','TIEN03','TIEN04','TIEN05','TIEN06','TIEN07','TIEN08','TIEN09','TIEN10','TIEN11','TIEN12','TIEN13'," & _
                                                                            "'TIEN14','TIEN15','TIEN16','TIEN17','TIEN18','TIEN19','TIEN20')"
                For Each row As DataRow In dtCon.Rows
                    If revisaTblCon.Contains(row.Item("concepto").ToString.Trim) Then row.Item("revisa_tabla") = True Else row.Item("revisa_tabla") = False
                Next

                For Each drow As DataRow In dtAjustes.Rows
                    Dim r = drow.Item("reloj").ToString.Trim
                    Dim a = drow.Item("ano").ToString.Trim
                    Dim p = drow.Item("periodo").ToString.Trim
                    Dim c = drow.Item("concepto").ToString.Trim
                    Dim filtro = "reloj='" & r & "' and periodo='" & p & "' and ano='" & a & "' and concepto="
                    If c = "DESINF" Then
                        If ResValDt(filtro & "'" & c & "'", "concepto", dtMovsPro, True) Is Nothing And ResValDt(filtro & "'DESINV'", "concepto", dtMovsPro, True) Is Nothing And ResValDt(filtro & "'DESINP'", "concepto", dtMovsPro, True) Is Nothing Then dtAjustesPro.ImportRow(drow)
                    Else
                        If ResValDt(filtro & "'" & c & "'", "concepto", dtMovsPro, True) Is Nothing Then dtAjustesPro.ImportRow(drow)
                    End If
                Next

                dtTemp = New DataView(_dtMovimientosPro, "concepto in ('DIAIMA','DIAING','DIAITR','DIAFIN','NETO')", "reloj", DataViewRowState.CurrentRows)
                dtMovsPro = dtTemp.ToTable("", False, "reloj", "concepto", "monto")

                '-- Omitir registros de empleados con bajas previas al inicio del periodo -- Ernesto -- 12 dic 2023
                Dim strPeriodo = data("ano") & data("periodo")
                Dim dtPeriodo = sqlExecute("select ano+periodo as periodo,fecha_ini from ta.dbo." &
                                           If(data("tipoPeriodo") = "S", "periodos", "periodos_quincenal") & " where ano+periodo='" & strPeriodo & "'")
                Dim strRelojes = String.Join(",", (From i In dtAjustesPro Select "'" & i("reloj") & "'").Distinct)
                Dim dtPer = Sqlite.getInstance.sqliteExecute("select reloj,baja from nominaPro where (baja is null or date(baja)>='" &
                                       FechaSQL(dtPeriodo.Rows(0)("fecha_ini")) & "') and reloj in (" & strRelojes & ")")

                For Each row As DataRow In dtAjustesPro.Rows

                    '-- Omitir registros de empleados con bajas previas al inicio del periodo -- Ernesto -- 12 dic 2023
                    If dtPer.Select("reloj='" & row("reloj") & "'").Count = 0 Then Continue For

                    Dim newR As DataRow = dtEstructura.NewRow
                    monto = Math.Round(row.Item("monto"), 2)
                    If monto = 0.0 Then Continue For

                    reloj = row.Item("reloj").ToString.Trim
                    neto = ResValDt("reloj='" & reloj & "' and concepto in ('NETO')", "monto", dtMovsPro, True)
                    nombres = Trim(ResValDt("reloj='" & reloj & "'", "nombres", dtPersonal, True))
                    anio = Trim(row.Item("ano"))
                    periodo = Trim(row.Item("periodo"))
                    concepto = Trim(row.Item("concepto"))
                    descripcion = Trim(ResValDt("concepto='" & row.Item("concepto").ToString.Trim & "'", "nombre", dtCon, True))
                    fecha = ValNullStr(row.Item("fecha")) : If Not fecha.GetType() Is GetType(System.DateTime) Then newR.Item("fecha") = "" Else newR.Item("fecha") = FechaSQL(fecha)
                    Try : sueldo = Math.Round(row.Item("sueldo"), 2) : Catch ex As Exception : sueldo = 0.0 : End Try
                    factor = If(Not IsDBNull(row.Item("factor")), Math.Round(row.Item("factor"), 4), 0.0)
                    alta = FechaSQL(ResValDt("reloj='" & reloj & "'", "alta", dtPersonal, True))
                    descuento_cc = Not ResValDt("concepto in ('" & concepto & "')", "concepto", dtCon, True) Is Nothing And ResValDt("concepto='" & concepto & "'", "revisa_tabla", dtCon, True) And
                                                Not ResValDt("reloj='" & reloj & "'", "reloj", dtNoDesc, True) Is Nothing
                    baja = ValNullStr(ResValDt("reloj='" & reloj & "'", "baja", dtPersonal, True))

                    If Not baja.GetType() Is GetType(System.DateTime) Then observaciones = baja Else observaciones = "Baja " & FechaSQL(baja)
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and inactivo=1", "inactivo", dtPersonal, True) Is Nothing, "Suspendido", "")

                    Dim finiquitoBool = (Not IsNothing(ResValDt("reloj='" & reloj & "'", "reloj", _dtFiniE))) OrElse (Not IsNothing(ResValDt("reloj='" & reloj & "'", "reloj", _dtFiniN)))
                    If finiquitoBool Then observaciones = "Finiquito en proceso" : Continue For

                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAIMA')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad por maternidad", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAING')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad general", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAITR')", "concepto", dtMovsPro, True) Is Nothing, "Incapacidad riesgo trabajo", "")
                    If observaciones = "" Then observaciones = IIf(descuento_cc, "No aplicar descuento por centro costos", "")
                    If observaciones = "" Then observaciones = IIf(Not ResValDt("reloj='" & reloj & "' and concepto in ('DIAFIN')", "concepto", dtMovsPro, True) Is Nothing, "Ausentismo", "")
                    If observaciones = "" Then observaciones = IIf(Not neto Is Nothing, IIf(neto = 0.0, "Sin neto", "Neto " & CStr(neto)), "Sin neto")

                    newR.Item("Año") = anio : newR.Item("Periodo") = periodo : newR.Item("Reloj") = reloj : newR.Item("Nombre") = nombres
                    newR.Item("Concepto") = concepto : newR.Item("Descripción") = descripcion : newR.Item("monto") = monto : newR.Item("observaciones") = observaciones
                    If fecha <> "" Then newR.Item("Fecha") = FechaSQL(fecha) Else newR.Item("Fecha") = "- -"
                    newR.Item("sueldo") = sueldo : newR.Item("factor") = factor
                    dtEstructura.Rows.Add(newR)
                Next

                ConceptosRezagadosDt(dtEstructura, "Miscelaneos_no_aplicados", "Concepto,Descripción,Monto,Fecha,Observaciones,Sueldo,Factor", data("ano") & data("periodo"), data("tipoPeriodo"))
                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Miscelaneos No Aplicados  " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")
                paramAdicionales.Add("Año,Periodo,Reloj,Nombre,Concepto,Descripción,Fecha,Observaciones,Monto,Sueldo,Factor")
                paramAdicionales.Add(Color.FromArgb(217, 217, 217))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtEstructura, 4, paramAdicionales, 0, "Misc")
                hoja_excel.SelectedRange("A4:K" & (dtEstructura.Rows.Count + 5).ToString).AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                ct += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteMiscNoAplicados. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteMiscNoAplicados", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de compensaciones temporales. -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="ct">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReporteCompensacionTemp(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef ct As Integer)
        Try
            '/*Tablas utilizadas: movimientos_compensacion, conceptos, nomina_pro,personalvw,conceptos,sdo_cobertura*/
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Compensacion temporal sem " & aPer
            Dim strNomComp = If(_dtCias.Rows.Count > 0, _dtCias.Rows(0)("nombre"), data("codComp"))
            Dim añoPer = data("periodo") & data("ano")

            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"
            Dim paramAdicionales As New ArrayList

            If _dtCompensacionTemp.Rows.Count > 0 Then
                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook
                Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(strNomReporte)
                Dim nomCol = "Tipo_compensacion,Ano,Periodo,Reloj,Nombres,Cod_tipo,Cod_clase,Rfc,Cod_depto,Num_imss,Alta,Alta_antig,Baja,Sactual,Integrado,Sueldo_cobertura,Compensacion_diaria,Porcentaje,Fecha_final,Cod_puesto,Puesto,[conNom]"
                Dim tipoCol = "String,String,String,String,String,String,String,String,String,String,String,String,String,Double,Double,Double,Double,Double,String,String,String,[conTipo]"
                Dim strComparativo = "TOTPER,TOTDED,NETO"
                Dim strNomColSup = ""
                Dim strNomCol = ""
                Dim strTipoCol = ""
                Dim boolInfoPers = False
                Dim cont = 0
                Dim vwTemp = New DataView(_dtCompensacionTemp, "", "concepto", DataViewRowState.CurrentRows)
                Dim dtConComp = vwTemp.ToTable("", True, "concepto")
                Dim dtComp As DataTable = _dtCompensacionTemp.Copy
                Dim dtConceptos = _dtConceptosCatalogo.Copy
                Dim relojes = (From x In dtComp.AsEnumerable Select x.Field(Of String)("reloj") Distinct).ToList

                For i As Integer = 0 To 1
                    Dim strFiltro = IIf(i = 0, "cod_naturaleza='P' and activo=1 and suma_neto=1 and positivo=1", "cod_naturaleza='D' and activo=1 and suma_neto=1 and positivo=0")

                    For Each row As DataRow In dtConceptos.Select(strFiltro)
                        Dim varCon = row.Item("concepto").ToString
                        Dim varDet = ""

                        If ResValDt("concepto='" & varCon & "'", "concepto", dtConComp, True) IsNot Nothing Then
                            varDet = ValNullStr(ResValDt("concepto='" & varCon & "'", "detalle", dtConceptos, True))

                            If varDet.Length > 2 Then
                                strNomColSup &= ResValDt("concepto='" & varDet & "'", "nombre", dtConceptos, True) & ","
                                strNomCol &= varDet.Trim.ToLower & ","
                                strTipoCol &= "Double,"
                            End If

                            strNomColSup &= ResValDt("concepto='" & varCon & "'", "nombre", dtConceptos, True) & ","
                            strNomCol &= varCon.ToLower & ","
                            strTipoCol &= "Double,"
                        End If
                    Next

                    strNomColSup &= IIf(i = 0, "PERCEPCIÓN TOTAL,", "TOTAL DEDUCCIONES,")
                    strNomCol &= IIf(i = 0, "totper,", "totded,")
                    strTipoCol &= "Double,"
                Next

                strNomColSup &= "NETO"
                strNomCol &= "neto"
                strTipoCol &= "Double"

                Dim dtEstructura = creaDt(Replace(nomCol, "[conNom]", strNomCol), Replace(tipoCol, "[conTipo]", strTipoCol))
                Dim arrCol() = Split(strNomCol, ",")

                For Each r In relojes
                    boolInfoPers = True

                    For Each c As DataRow In dtComp.Select("reloj='" & r.Trim & "'")

                        If boolInfoPers Then
                            Dim newRow As DataRow = dtEstructura.NewRow
                            Dim varBaja = Nothing

                            newRow.Item("tipo_compensacion") = c.Item("tipo_comp").ToString.Trim
                            newRow.Item("ano") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "ano", _dtNominaPro, True).ToString.Trim
                            newRow.Item("periodo") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "periodo", _dtNominaPro, True).ToString.Trim
                            newRow.Item("reloj") = r.Trim
                            newRow.Item("nombres") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "nombres", _dtNominaPro, True).ToString.Trim
                            newRow.Item("cod_tipo") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "cod_tipo", _dtNominaPro, True).ToString.Trim
                            newRow.Item("cod_clase") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "cod_clase", _dtNominaPro, True).ToString.Trim
                            newRow.Item("rfc") = ResValDt("reloj='" & r & "'", "rfc", _dtPersonalvw, True).ToString.Trim
                            newRow.Item("cod_depto") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "cod_depto", _dtNominaPro, True).ToString.Trim
                            newRow.Item("num_imss") = ResValDt("reloj='" & r & "'", "imss", _dtPersonalvw, True).ToString.Trim & ResValDt("reloj='" & r & "'", "dig_ver", _dtPersonalvw, True).ToString.Trim
                            newRow.Item("alta") = FechaSQL(ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "alta", _dtNominaPro, True))
                            newRow.Item("alta_antig") = FechaSQL(ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "alta_antig", _dtNominaPro, True))
                            varBaja = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "baja", _dtNominaPro, True)
                            If IsDBNull(varBaja) Or IsNothing(varBaja) Then newRow.Item("baja") = "  -   -" Else newRow.Item("baja") = FechaSQL(varBaja)
                            newRow.Item("sactual") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "sactual", _dtNominaPro, True)
                            newRow.Item("integrado") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "integrado", _dtNominaPro, True)
                            Try : newRow.Item("sueldo_cobertura") = ResValDt("reloj='" & r & "'", "sdo_cobert", _dtSdoCobertura, True) : Catch ex As Exception : newRow.Item("sueldo_cobertura") = 0.0 : End Try
                            Try : newRow.Item("compensacion_diaria") = ResValDt("reloj='" & r & "'", "comp_diaria", _dtSdoCobertura, True) : Catch ex As Exception : newRow.Item("compensacion_diaria") = 0.0 : End Try
                            Try : newRow.Item("porcentaje") = If(IsDBNull(ResValDt("reloj='" & r & "'", "porcentaje", _dtSdoCobertura, True)), 0.0, ResValDt("reloj='" & r & "'", "porcentaje", _dtSdoCobertura, True))
                            Catch ex As Exception : newRow.Item("porcentaje") = 0.0 : End Try

                            If IsDBNull(ResValDt("reloj='" & r & "'", "fha_fin", _dtSdoCobertura, True)) OrElse ResValDt("reloj='" & r & "'", "fha_fin", _dtSdoCobertura, True) = "1900-01-01" Then
                                newRow.Item("fecha_final") = "  -   -"
                            Else
                                newRow.Item("fecha_final") = ResValDt("reloj='" & r & "'", "fha_fin", _dtSdoCobertura, True).ToString
                            End If

                            newRow.Item("cod_puesto") = ResValDt("periodo+ano='" & añoPer & "' and reloj='" & r & "'", "cod_puesto", _dtNominaPro, True).ToString.Trim
                            newRow.Item("puesto") = ResValDt("reloj='" & r & "'", "nombre_puesto", _dtPersonalvw, True).ToString.Trim
                            newRow.Item("tipo_compensacion") = c.Item("tipo_comp").ToString.Trim
                            dtEstructura.Rows.Add(newRow)
                            boolInfoPers = False
                        End If
                        Try : dtEstructura.Rows(cont)(c.Item("concepto").ToString.Trim) = c.Item("monto") : Catch ex As Exception : End Try
                    Next

                    For Each s In arrCol
                        If IsDBNull(dtEstructura.Rows(cont)(s)) Then
                            dtEstructura.Rows(cont)(s) = 0.0
                        End If
                    Next
                    cont += 1
                Next

                FormatoCelda(hoja_excel, 0, 1, 1, strNomComp, Color.Black, True, "")
                FormatoCelda(hoja_excel, 0, 2, 1, "Compensacion temporal  " & data("periodo") & "-" & data("tipoPeriodo") & data("ano") & " V" & verProc, Color.Black, True, "")

                Dim fin = 0
                paramAdicionales.Add(strNomColSup)
                paramAdicionales.Add(Color.FromArgb(166, 166, 166))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, Nothing, 3, paramAdicionales, fin, "", 22) : paramAdicionales.Clear()
                paramAdicionales.Add(Replace(nomCol, "[conNom]", strNomCol))
                paramAdicionales.Add(Color.FromArgb(217, 217, 217))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                paramAdicionales.Add(Color.FromArgb(0, 0, 0))
                FormatoTablaCompleta(True, hoja_excel, dtEstructura, 4, paramAdicionales, fin) : paramAdicionales.Clear()

                Dim intCol = 22
                FormatoCelda(hoja_excel, 0, fin, intCol - 1, "Totales", Color.Black, True, "", True, Color.FromArgb(217, 217, 217))

                For Each c In arrCol
                    Dim strFormula = "=SUM(" & RangoCeldasExcel(Nothing, intCol, intCol, 3, dtEstructura.Rows.Count + 4) & ")"
                    FormatoCelda(hoja_excel, 3, fin, intCol, strFormula, Color.Black, False, "", True, Color.FromArgb(217, 217, 217), Style.ExcelHorizontalAlignment.Right)
                    intCol += 1
                Next

                Dim totalRegistros = dtEstructura.Rows.Count + 5
                Dim rangoFinal = RangoCeldasExcel(3, 1, 20 + arrCol.Count)
                Dim rangoTot() = Split(rangoFinal, ":")
                Dim strRango = rangoTot(0) & ":" & rangoTot(1).Replace(rangoTot(1).Substring(rangoTot(1).Length - 1, 1), totalRegistros.ToString)
                hoja_excel.SelectedRange(strRango).AutoFitColumns()
                archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                ct += 1
                freeMemory()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar ReporteCompensacionTemp. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReporteCompensacionTemp", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reporte de pensiones alimenticias desglozado en excel -- Ernesto
    ''' </summary>
    ''' <param name="dirGuardar">Ruta de guardado</param>
    ''' <param name="verProc">Versión del proceso</param>
    ''' <param name="data">Diccionario con info. del periodo</param>
    ''' <param name="c">Contador de no. reportes (si se generó)</param>
    ''' <remarks></remarks>
    Public Sub ExcelReportePensionesAlimentarias(ByVal dirGuardar As String, verProc As String, ByVal data As Dictionary(Of String, String), ByRef c As Integer)
        Try
            Dim strCia = data("codComp").Replace("'", "")
            Dim aPer = data("periodo") & "-" & data("ano")
            Dim strNomReporte = strCia & " " & "Pensiones alimenticias " & aPer
            Dim dirArchivo As String = dirGuardar & strNomReporte & " V" & verProc & ".xlsx"                                                                                                             '-- Proceso

            If _dtMovimientosPro.Rows.Count > 0 Then
                Dim vwPen = New DataView(_dtMovimientosPro, "concepto in ('BASEPE','TOTPER')", "reloj asc", DataViewRowState.CurrentRows)
                Dim dtMovsPensiones = vwPen.ToTable("", True, "reloj", "concepto", "monto")

                Dim vwMovs = New DataView(_dtMovimientosPro, "concepto in ('PENAL1','PENAL2','PENAL3')", "reloj asc", DataViewRowState.CurrentRows)
                Dim dtMovsPro = vwMovs.ToTable("", True, "reloj", "concepto", "monto")

                If dtMovsPensiones.Rows.Count > 0 Then
                    Dim archivo As ExcelPackage = New ExcelPackage()
                    Dim wb As ExcelWorkbook = archivo.Workbook
                    Dim hoja_excel As ExcelWorksheet = Nothing
                    Dim strReloj = ""
                    Dim strNombreEmp = ""
                    Dim strNombrePen = ""
                    Dim numPen = ""
                    Dim porcentaje = ""
                    Dim totPer = 0.0
                    Dim montoPension = 0.0
                    Dim basePension = 0.0
                    Dim x = 1, y = 1, cont = 1

                    If dtMovsPro.Rows.Count = 0 Then
                        Exit Sub
                    End If

                    For Each r In dtMovsPro.Select("", "reloj asc")

                        If strReloj <> r("reloj") Then
                            strNombreEmp = _dtPersonalvw.Select("reloj='" & r("reloj") & "'").First.Item("nombres").ToString.Replace(",", " ").Trim
                            hoja_excel = wb.Worksheets.Add(strNombreEmp & " - " & r("reloj"))
                            hoja_excel.Cells(1, 1).Value = "Concepto"
                            hoja_excel.Cells(1, 2).Value = "Monto"
                            x = 1
                            cont = 0
                        End If

                        Try : numPen = If(r("concepto").ToString.Substring(0, 5) = "PENAL", r("concepto").ToString.Substring(r("concepto").ToString.Length - 1, 1), "")
                        Catch ex As Exception : numPen = "" : End Try

                        Dim rowInfo = _dtPensionesAlim.Select("reloj='" & r("reloj") & "' and num_pensio='" & numPen & "'")

                        Try : strNombreEmp = rowInfo.First.Item("pensionado").ToString.ToUpper.Trim
                        Catch ex As Exception : strNombreEmp = "- Sin información -" : End Try

                        Try : porcentaje = "PORCENTAJE " & rowInfo.First.Item("porcentaje") & "%"
                        Catch ex As Exception : porcentaje = "- Sin información -" : End Try

                        Try : totPer = dtMovsPensiones.Select("reloj='" & r("reloj") & "' and concepto='TOTPER'").First.Item("monto")
                        Catch ex As Exception : totPer = 0.0 : End Try

                        Try : montoPension = dtMovsPro.Select("reloj='" & r("reloj") & "' and concepto='" & r("concepto") & "'").First.Item("monto")
                        Catch ex As Exception : montoPension = 0.0 : End Try

                        Try : basePension = dtMovsPensiones.Select("reloj='" & r("reloj") & "' and concepto='BASEPE'").First.Item("monto")
                        Catch ex As Exception : basePension = 0.0 : End Try

                        hoja_excel.Cells(x + cont, 1).Value = strNombreEmp
                        hoja_excel.Cells(x + cont, 2).Value = 0 : cont += 1

                        hoja_excel.Cells(x + cont, 1).Value = porcentaje
                        hoja_excel.Cells(x + cont, 2).Value = 0 : cont += 1

                        hoja_excel.Cells(x + cont, 1).Value = "TOTAL PERCEPCIONES"
                        hoja_excel.Cells(x + cont, 2).Value = totPer : cont += 1

                        hoja_excel.Cells(x + cont, 1).Value = "BASE PENSION"
                        hoja_excel.Cells(x + cont, 2).Value = basePension : cont += 1

                        hoja_excel.Cells(x + cont, 1).Value = "PENSION " & numPen & " (POR " & porcentaje & ")"
                        hoja_excel.Cells(x + cont, 2).Value = montoPension : cont += 3

                        hoja_excel.SelectedRange("A1:B50").AutoFitColumns()
                        strReloj = r("reloj")
                    Next

                    archivo.SaveAs(New System.IO.FileInfo(dirArchivo))
                    c += 1
                    freeMemory()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error al generar ExcelReportePensionesAlimentarias. Verifique que no está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ExcelReportePensionesAlimentarias", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función que inserta las horas y miscelaneos no aplicados en una tabla de respaldo para el siguiente proceso. -- Ernesto
    ''' </summary>
    ''' <param name="dtInfo">Registros a insertar</param>
    ''' <param name="origen">Tipo de concepto (hrs no aplicadas o misc no palicados)</param>
    ''' <param name="detalle">Columnas de la tabla</param>
    ''' <param name="aPer">Periodo y año</param>
    ''' <remarks></remarks>
    Public Sub ConceptosRezagadosDt(ByVal dtInfo As DataTable, ByVal origen As String, ByVal detalle As String, ByVal aPer As String, ByVal tipo_per As String)
        Try
            Dim Qry = "SELECT * FROM NOMINA.dbo.conceptos_rezagados WHERE origen='" & origen & "'"
            Dim dtConsulta = sqlExecute(Qry)
            Dim strDetalle() = Split(detalle, ",")
            Dim dtRes As New DataTable

            If dtConsulta.Rows.Count > 0 Then
                sqlExecute("delete from nomina.dbo.conceptos_rezagados where origen='" & origen & "'")
            End If

            Dim dtInformacion As DataTable = dtInfo.Clone
            For Each info In dtInfo.Rows
                If _dtConceptosCatalogo.Select("concepto='" & info("concepto").ToString.Trim & "' and rezagado=1").Count > 0 Then
                    If _dtPersonalvw.Select("reloj='" & info("reloj").ToString.Trim & "' and inactivo=0").Count > 0 Then
                        dtInformacion.ImportRow(info)
                    End If
                End If
            Next

            Dim vwReloj = New DataView(dtInformacion, "", "reloj", DataViewRowState.CurrentRows)
            Dim dtReloj = vwReloj.ToTable("", True, "reloj")

            For Each r As DataRow In dtReloj.Rows

                Dim strReloj = r.Item("reloj").ToString.Trim
                Dim info = (From x As DataRow In dtInformacion.AsEnumerable
                          Where x.Field(Of String)("reloj") = strReloj
                          Select x)


                dtRes = (New DataView(info.CopyToDataTable, "", "reloj", DataViewRowState.CurrentRows)).ToTable("", False, strDetalle)
                dtRes.Columns.Remove("Descripción")
                dtRes.Columns.Remove("Observaciones")

                Qry = "insert into nomina.dbo.conceptos_rezagados (origen,anio_periodo,reloj,tipo_periodo,json_detalles,fecha_insercion) values " & _
                    "('" & origen & "','" & aPer & "','" & strReloj & "','" & tipo_per & "','" & JsonConvert.SerializeObject(tableToDict(dtRes)).Replace("'", "") & "',getdate())"
                sqlExecute(Qry)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "GuardarConceptosRezagados", Err.Number, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función para llenar los datatables con la información de percepciones y deducciones para el reporte de comparativo de nóminas (Operativos y administrativos). Retorna un valor tipo datatable. -- Ernesto
    ''' </summary>
    ''' <param name="infoOp">Tipo de concepto.</param>
    ''' <param name="infoAdicional">Información adicional (como info de columnas)</param>
    ''' <param name="netos">Netos totales</param>
    ''' <param name="aPer">Periodo y año del proceso</param>
    ''' <param name="dtTotal">Resultado final (datatable)</param>
    ''' <remarks></remarks>
    Public Function ComparativoNomPerDed(infoOp As String, ByVal infoAdicional As ArrayList, ByRef netos As ArrayList, aPer As String, ByRef dtTotal As DataTable) As DataTable
        Dim dtResultado As New DataTable
        Dim dtTemp As New DataTable
        Dim newRow As DataRow
        Dim existeConcepto As Boolean = False
        Dim insertConcepto As Boolean = False
        Dim natCiclo As String = ""
        Dim filtro As String = ""

        Try
            Select Case infoOp
                Case "Percepciones"
                    natCiclo = "P"
                Case "Deducciones"
                    natCiclo = "D"
            End Select

            dtTemp = creaDt("Concepto,Descripcion,Semana " & infoAdicional.Item(0) & ",Semana " & infoAdicional.Item(1) & ",Diferencia,Variabilidad", "String,String,Double,Double,Double,Double")

            For Each con As DataRow In _dtConceptosCatalogo.Select("cod_naturaleza='" & natCiclo & "'")
                Dim concepto As String = con.Item("concepto").ToString.Trim
                Dim descripcion As String = con.Item("nombre").ToString.Trim
                Dim conAnterior = ResValDt("concepto='" & concepto & "'", "concepto", _dtMovimientos, True)
                Dim conActual = ResValDt("concepto='" & concepto & "'", "concepto", _dtMovimientosPro, True)

                If Not conAnterior Is Nothing Or Not conActual Is Nothing Then
                    newRow = dtTemp.NewRow
                    Dim monAnterior = 0.0
                    Dim monActual = 0.0

                    If conAnterior Is Nothing Then monAnterior = 0.0 Else monAnterior = IIf(IsDBNull(_dtMovimientos.Compute("sum(monto)", "concepto='" & concepto & "' and periodo+ano='" & aPer & "'")), 0.0, _dtMovimientos.Compute("sum(monto)", "concepto='" & concepto & "' and periodo+ano='" & aPer & "'"))
                    If conActual Is Nothing Then monActual = 0.0 Else monActual = IIf(IsDBNull(_dtMovimientosPro.Compute("sum(monto)", "concepto='" & concepto & "'")), 0.0, _dtMovimientosPro.Compute("sum(monto)", "concepto='" & concepto & "'"))

                    newRow.Item("Concepto") = concepto
                    newRow.Item("Descripcion") = descripcion
                    newRow.Item("Semana " & infoAdicional.Item(0)) = Math.Round(monActual, 2)
                    newRow.Item("Semana " & infoAdicional.Item(1)) = Math.Round(monAnterior, 2)
                    newRow.Item("Diferencia") = Math.Round(monActual - monAnterior, 2)
                    newRow.Item("Variabilidad") = IIf(monAnterior = 0.0, 1, Math.Round((monActual - monAnterior) / monAnterior, 6))
                    dtTemp.Rows.Add(newRow)
                End If
            Next

            Dim totActual = Math.Round(dtTemp.Compute("sum([Semana " & infoAdicional.Item(0) & "])", ""), 6)
            Dim totAnt = Math.Round(dtTemp.Compute("sum([Semana " & infoAdicional.Item(1) & "])", ""), 6)
            Dim totDif = Math.Round(totActual - totAnt, 6)
            Dim totVar = Math.Round((totActual - totAnt) / totAnt, 6)

            If infoOp = "Percepciones" Then dtTotal = dtTemp.Clone

            newRow = dtTotal.NewRow
            newRow.Item("Concepto") = IIf(natCiclo = "P", "TOTPER", "TOTDED")
            newRow.Item("Descripcion") = IIf(natCiclo = "P", "Total percepciones", "Total deducciones")
            newRow.Item("Semana " & infoAdicional.Item(0)) = totActual : netos.Add(totActual)
            newRow.Item("Semana " & infoAdicional.Item(1)) = totAnt : netos.Add(totAnt)
            newRow.Item("Diferencia") = totDif : netos.Add(totDif)
            newRow.Item("Variabilidad") = totVar
            dtTotal.Rows.Add(newRow)

            Dim dtTemporal As DataTable = dtTemp.Copy : dtTemp.Clear()

            For Each var As DataRow In dtTemporal.Select("concepto is not null", "variabilidad asc") : dtTemp.ImportRow(var) : Next

            dtResultado = dtTemp.Copy

            Return dtResultado
        Catch ex As Exception
            dtResultado = dtTemp.Clone
            Return dtResultado
        End Try
    End Function

    ''' <summary>
    ''' Función para llenar los datatables con la información del altas y bajas para el reporte de comparativo de nóminas (Operativos y administrativos). Retorna un valor tipo datatable. -- Ernesto
    ''' </summary>
    ''' <param name="infoOp">Tipo de concepto.</param>
    ''' <param name="infoAdicional">Información adicional (como el periodo actual, anterior, etc)</param>
    ''' <remarks></remarks>
    Public Function ComparativoNomAltasBajas(infoOp As String, ByVal infoAdicional As ArrayList) As DataTable
        Dim dtResultado As New DataTable
        Dim dtTemp As New DataTable
        Dim newRow As DataRow
        Dim natCiclo As String = ""

        Try
            Select Case infoOp
                Case "Altas"
                    natCiclo = "Alta"
                Case "Bajas"
                    natCiclo = "Baja"
            End Select

            Dim inicioPer As Date = ResValDt("periodo+ano='" & infoAdicional.Item(0) & "'", "fecha_ini", _dtPeriodos)
            Dim finPer As Date = ResValDt("periodo+ano='" & infoAdicional.Item(0) & "'", "fecha_fin", _dtPeriodos)

            Dim sueldo As Double = 0.0
            Dim colNomAdicional As String = IIf(natCiclo = "Alta", ",Sueldo", "")
            Dim colTipoAdicional As String = IIf(natCiclo = "Alta", ",Double", "")
            dtTemp = creaDt("Reloj,Nombre," & IIf(natCiclo = "Alta", "Fecha_alta", "Fecha_baja") & colNomAdicional, "String,String,String" & colTipoAdicional)

            For Each AltaBaja As DataRow In _dtNominaPro.Select("cod_tipo='O'", "reloj")
                Dim varFecha = Nothing

                If Not IsDBNull(AltaBaja(IIf(natCiclo = "Alta", "alta", "baja"))) Then

                    varFecha = Convert.ToDateTime(AltaBaja(IIf(natCiclo = "Alta", "alta", "baja")))

                    If varFecha >= inicioPer And varFecha <= finPer Then
                        newRow = dtTemp.NewRow
                        newRow.Item("Reloj") = AltaBaja.Item("reloj").ToString.Trim
                        newRow.Item("Nombre") = AltaBaja.Item("nombres").ToString.Trim
                        newRow.Item(IIf(natCiclo = "Alta", "Fecha_alta", "Fecha_baja")) = FechaSQL(varFecha)
                        If natCiclo = "Alta" Then newRow.Item("Sueldo") = Math.Round(AltaBaja.Item("sactual"), 2)
                        dtTemp.Rows.Add(newRow)
                    End If

                End If
            Next

            Dim dtTemporal As DataTable = dtTemp.Copy : dtTemp.Clear()

            For Each var As DataRow In dtTemporal.Select("reloj is not null", "reloj asc") : dtTemp.ImportRow(var) : Next
            dtResultado = dtTemp.Copy
            Return dtResultado

        Catch ex As Exception
            dtResultado = dtTemp.Clone
            Return dtResultado
        End Try
    End Function

    ''' <summary>
    ''' Función para llenar los datatables con la información de cambio de sueldo para el reporte de comparativo de nóminas (Operativos y administrativos). Retorna un valor tipo datatable. -- Ernesto
    ''' </summary>
    ''' <param name="infoAdicional">Información adicional (como el periodo actual, anterior, etc)</param>
    ''' <remarks></remarks>
    Public Function ComparativoNomCambioSueldo(ByVal infoAdicional As ArrayList) As DataTable
        Dim dtResultado As New DataTable
        Dim r As String = ""
        Dim newR As DataRow

        Try
            Dim inicioPer As Date = ResValDt("periodo+ano='" & infoAdicional.Item(0) & "'", "fecha_ini", _dtPeriodos)
            Dim finPer As Date = ResValDt("periodo+ano='" & infoAdicional.Item(0) & "'", "fecha_fin", _dtPeriodos)
            Dim dtSalarios As DataTable = sqlExecute("SELECT * FROM PERSONAL.dbo.mod_sal WHERE fecha between '" & FechaSQL(inicioPer) & "' and '" & FechaSQL(finPer) & "' ORDER BY RELOJ,FECHA DESC")

            Dim vwReloj = New DataView(_dtNominaPro.Select("cod_tipo='O'", "reloj").CopyToDataTable, "", "reloj", DataViewRowState.CurrentRows)
            Dim dtOperativos = vwReloj.ToTable("", True, "reloj")

            If dtSalarios.Rows.Count > 0 And Not dtSalarios.Columns.Contains("ERROR") Then
                dtResultado = creaDt("Reloj,Nombre,Sueldo_anterior,Sueldo_nuevo,Variacion,Fecha", "String,String,Double,Double,Double,String")

                For Each salRow As DataRow In dtSalarios.Rows
                    If r <> salRow.Item("reloj").ToString.Trim Then
                        If dtOperativos.Select("reloj='" & salRow.Item("reloj").ToString.Trim & "'").Count > 0 Then
                            Dim sueldoNvo As Double = salRow.Item("cambio_a")
                            Dim sueldoAnt As Double = salRow.Item("cambio_de")

                            r = salRow.Item("reloj").ToString.Trim

                            newR = dtResultado.NewRow
                            newR.Item("Reloj") = r
                            newR.Item("Nombre") = ResValDt("reloj='" & r & "'", "nombres", _dtPersonalvw).ToString.Trim
                            newR.Item("Sueldo_anterior") = sueldoAnt
                            newR.Item("Sueldo_nuevo") = sueldoNvo
                            newR.Item("Variacion") = Math.Round((sueldoNvo - sueldoAnt) / sueldoAnt, 6)
                            newR.Item("Fecha") = FechaSQL(salRow.Item("fecha"))
                            dtResultado.Rows.Add(newR)
                        End If
                    End If
                Next

                Dim dtTemporal As DataTable = dtResultado.Copy : dtResultado.Clear()
                For Each var As DataRow In dtTemporal.Select("reloj is not null", "reloj asc") : dtResultado.ImportRow(var) : Next
                Return dtResultado
            End If
        Catch ex As Exception : End Try

    End Function

    ''' <summary>
    ''' Función para crear datatables (solo columnas sin información). Retorna un valor tipo datatable. -- Ernesto
    ''' </summary>
    ''' <param name="nombresCol">Nombres de las columnas</param>
    ''' <param name="tipoCol">Tipo de columnas</param>
    ''' <remarks></remarks>
    Public Shared Function creaDt(ByVal nombresCol As String, ByVal tipoCol As String) As DataTable
        Try
            Dim dtTablaCol As New DataTable
            Dim infoN() As String = Split(nombresCol, ",")
            Dim infoT() As String = Split(tipoCol, ",")
            Dim cont As Integer = infoN.Count
            If infoN.Count = infoT.Count Then
                For i As Integer = 0 To cont - 1
                    Dim colN As New DataColumn
                    colN.ColumnName = infoN(i)

                    If dtTablaCol.Columns.Contains(colN.ColumnName) Then Continue For
                    dtTablaCol.Columns.Add(colN)
                    Select Case infoT(i)
                        Case "String"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(String)
                        Case "Int"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Integer)
                        Case "Date"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Date)
                        Case "Double"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Double)
                    End Select
                Next
            End If
            Return dtTablaCol
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Función que convierte un excel a pdf. -- Ernesto
    ''' </summary>
    ''' <param name="ruta">Ruta de guardado</param>
    ''' <remarks></remarks>
    Private Sub ConvertirExcelPDF(ruta As String)
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application
        Dim ExcelDoc As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim SalidaDoc As String
        Try
            ExcelDoc = excelApp.Workbooks.Open(ruta)
            SalidaDoc = System.IO.Path.ChangeExtension(ruta, "pdf")
            If Not ExcelDoc Is Nothing Then
                ExcelDoc.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, SalidaDoc, Excel.XlFixedFormatQuality.xlQualityStandard, True, True)
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error durante el proceso de conversión del excel a PDF, por favor, revise el log y/o notifique al admin. del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "ProcesoNomina_PDF", ex.HResult, ex.Message)
        Finally
            If Not ExcelDoc Is Nothing Then
                ExcelDoc.Close(False)
                releaseObject(ExcelDoc)
                ExcelDoc = Nothing
            End If
            If Not excelApp Is Nothing Then
                excelApp.Quit()
                releaseObject(excelApp)
                excelApp = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Consultas a BD de reportes de proceso de nómina (Emp. operativos y administrativos). -- Ernesto
    ''' </summary>
    ''' <param name="PerAño">Año y periodo del proceso</param>
    ''' <param name="FechaPago">Fecha de pago del proceso</param>
    ''' <remarks></remarks>
    Public Function ConsultasBDReportes(PerAño As String, FechaPago As String, tipo_per As String, ByVal data As Dictionary(Of String, String))
        Try
            Dim Qry As String = ""
            Qry = "select reloj,nombres,cod_tipo,baja,alta,rfc,imss,dig_ver,nombre_puesto,isnull(inactivo,0) as inactivo," &
                "centro_costos,'Indefinido' as nombre_clerk,isnull(submotivo_baja,'- -') as submotivo_baja from personal.dbo.personalvw where cod_comp in (" & data("codComp") & ")"
            Try : _dtPersonalvw = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select cod_puesto,nombre from personal.dbo.puestos where COD_COMP in (" & data("codComp") & ")"
            Try : _dtPuestos = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select cod_super,nombre from personal.dbo.super where COD_COMP in (" & data("codComp") & ")"
            Try : _dtSuper = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select cod_clerk,nombre from personal.dbo.clerks"
            Try : _dtClerks = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select * from ta.dbo." & IIf(tipo_per = "S", "periodos", "periodos_quincenal") & " where (ano=year('" & FechaSQL(FechaPago) & "') or ano=year('" & FechaSQL(FechaPago) & "')-1) and periodo_especial=0 order by ano,periodo asc"
            Try : _dtPeriodos = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select * from nomina.dbo.movimientos where periodo+ano = '" & PeriodoAnterior(PerAño, _dtPeriodos) & "' and tipo_periodo='" & tipo_per & "'"
            Try : _dtMovimientos = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select rtrim(concepto) as concepto,rtrim(nombre) as nombre,rtrim(cod_naturaleza) as cod_naturaleza,rtrim(exento) as exento,rtrim(detalle) as detalle" & _
                ",prioridad,suma_neto,activo,positivo,rezagado from nomina.dbo.conceptos order by prioridad"
            Try : _dtConceptosCatalogo = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select * from personal.dbo.pensiones_alimenticias"
            Try : _dtPensionesAlim = sqlExecute(Qry) : Catch ex As Exception : End Try
            Qry = "select rtrim(cod_comp) as cod_comp,rtrim(nombre) as nombre from personal.dbo.cias where cod_comp in (" & data("codComp") & ")"
            Try : _dtCias = sqlExecute(Qry) : Catch ex As Exception : End Try

            _dtMovimientosPro = Me.MovimientosPro
            _dtMaestroDed = Me.MtroDed
            _dtFiniN = Me.FiniquitosN
            _dtNominaPro = Me.NominaPro
            _dtHorasPro = Me.HorasPro
            _dtAjustesPro = Me.AjustesPro
            _dtCompensacionTemp = Me.MovimientosCompensacion

            freeMemory()
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Recorre un datatable de acuerdo al filtro que se aplicó y retorna un resultado de cualquier tipo. -- Ernesto
    ''' </summary>
    ''' <param name="filtro">Filtro para resultados</param>
    ''' <param name="campo">Nombre de columna para el valor de retorno</param>
    ''' <param name="dtInfo">Datatable con la información a consultar</param>
    ''' <param name="primerRes">Para pbtener primer resultado</param>
    ''' <remarks></remarks>
    Public Function ResValDt(filtro As String, campo As String, ByVal dtInfo As DataTable, Optional primerRes As Boolean = False) As Object
        Dim dtTemp As New DataTable
        Dim retorno As Object = Nothing
        Try
            For Each elem As DataRow In dtInfo.Select(filtro)
                retorno = elem.Item(campo)
                If primerRes Then Exit For
            Next
            Return retorno
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Filtra los registros de una tabla en base de otra. -- Ernesto
    ''' </summary>
    ''' <param name="dtTablaInfo">Filtro para resultados</param>
    ''' <param name="dtTablaFiltro">Nombre de columna para el valor de retorno</param>
    ''' <remarks></remarks>
    Public Function FiltraTabla(dtTablaInfo As DataTable, dtTablaFiltro As DataTable) As DataTable
        Dim linQ = (From i In dtTablaInfo Join f In dtTablaFiltro On i.Field(Of String)("reloj").Trim Equals f.Field(Of String)("reloj").Trim
                  Select i) : Return linQ.CopyToDataTable
    End Function

    ''' <summary>
    ''' Obtiene el rango de celdas para reportes de excel. Retorna un valor tipo string. Ejem. A1:H1 -- Ernesto
    ''' </summary>
    ''' <param name="noFila">Número de la fila donde se situará el rango</param>
    ''' <param name="noIniCol">Número de columna donde inicia</param>
    ''' <param name="noFinCol">Número de columna donde finaliza</param>
    ''' <param name="noFilaIni">Número de fila donde inicia</param>
    ''' <param name="numReg">Número de registros del rango</param>
    ''' <remarks></remarks>
    Private Function RangoCeldasExcel(noFila As Integer, noIniCol As Integer, noFinCol As Integer, Optional noFilaIni As Integer = 0, Optional numReg As Integer = 0) As String
        Dim arrCol As New ArrayList
        Dim letrasCol() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim rango As String = ""
        Try
            For Each lista As String In letrasCol : arrCol.Add(lista) : Next

            For Each x As String In letrasCol
                For Each y As String In letrasCol
                    Dim conjunto As String = x & y
                    arrCol.Add(conjunto)
                Next
            Next

            If noIniCol = noFinCol Then
                If noFilaIni = numReg Then
                    rango = arrCol.Item(noIniCol - 1) & noFilaIni.ToString & ":" & arrCol.Item(noIniCol - 1) & noFilaIni.ToString
                    Return rango
                End If

                For i As Integer = 1 To numReg
                    If i = noFilaIni Or i = numReg Then
                        rango &= arrCol.Item(noIniCol - 1) & IIf(i = noFilaIni, noFilaIni.ToString & ":", numReg.ToString)
                    End If
                Next
            Else
                For i As Integer = 0 To 999
                    If i = noIniCol - 1 Or i = noFinCol - 1 Then
                        rango &= arrCol.Item(i) & IIf(i = noIniCol - 1, noFila.ToString & ":", noFila.ToString)
                    End If
                Next
            End If

            Return rango
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Modifica el formato de una celda junto con su valor. -- Ernesto
    ''' </summary>
    ''' <param name="_hoja">Hoja de excel con la que se está trabajando</param>
    ''' <param name="_tipo">Tipo de formato que se dará (celda individual,rango o para bordes)</param>
    ''' <param name="_fil">No. de fila</param>
    ''' <param name="_col">No. de columna</param>
    ''' <param name="_valor">Dato de la celda</param>
    ''' <param name="_colorLetra">Color de letra</param>
    ''' <param name="_negrita">Si la letra es negrita o no</param>
    ''' <param name="_rango">Si hay rango de celdas</param>
    ''' <param name="_colorCel">Si la celda tiene color o no</param>
    ''' <param name="_colorCelda">Color de la celda</param>
    ''' <param name="_alineacion">Alineación del texto</param>
    ''' <param name="_formatoNum">Si se quiere dar formato al num. (booleano)</param>
    ''' <param name="_numeroFormato">Tipo de formato numérico</param>
    ''' <remarks></remarks>
    Private Sub FormatoCelda(ByRef _hoja As ExcelWorksheet,
                             _op As Integer,
                             _fil As Integer,
                             _col As Integer,
                             _valor As Object,
                             _colorLetra As Color,
                             _negrita As Boolean,
                             Optional _rango As String = "",
                             Optional _colorCel As Boolean = False,
                             Optional _colorCelda As Color = Nothing,
                             Optional _alineacion As Style.ExcelHorizontalAlignment = Style.ExcelHorizontalAlignment.Left,
                             Optional _formatoNum As Boolean = False,
                             Optional _numeroFormato As String = "")
        Try
            Select Case _op
                Case 0
                    _hoja.Cells(_fil, _col).Value = _valor
                    _hoja.Cells(_fil, _col).Style.Font.Color.SetColor(_colorLetra)
                    _hoja.Cells(_fil, _col).Style.Font.Bold = _negrita
                    _hoja.Cells(_fil, _col).Style.HorizontalAlignment = _alineacion

                    If _colorCel Then _hoja.Cells(_fil, _col).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    If _colorCel Then _hoja.Cells(_fil, _col).Style.Fill.BackgroundColor.SetColor(_colorCelda)
                    If _formatoNum Then _hoja.Cells(_fil, _col).Style.Numberformat.Format = _numeroFormato
                Case 1
                    _hoja.SelectedRange(_rango).Merge = True
                    _hoja.SelectedRange(_rango).Style.HorizontalAlignment = _alineacion

                    If _colorCel Then _hoja.SelectedRange(_rango).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    If _colorCel Then _hoja.SelectedRange(_rango).Style.Fill.BackgroundColor.SetColor(_colorCelda)
                    If _formatoNum Then _hoja.SelectedRange(_rango).Style.Numberformat.Format = _numeroFormato

                    _hoja.SelectedRange(_rango).Style.Font.Color.SetColor(_colorLetra)
                Case 2
                    _hoja.SelectedRange(_rango).Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                    _hoja.SelectedRange(_rango).Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                Case 3
                    _hoja.Cells(_fil, _col).Formula = _valor
                    _hoja.Cells(_fil, _col).Style.Font.Color.SetColor(_colorLetra)
                    _hoja.Cells(_fil, _col).Style.Font.Bold = _negrita
                    _hoja.Cells(_fil, _col).Style.HorizontalAlignment = _alineacion

                    If _colorCel Then _hoja.Cells(_fil, _col).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    If _colorCel Then _hoja.Cells(_fil, _col).Style.Fill.BackgroundColor.SetColor(_colorCelda)
            End Select
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Obtiene el periodo anterior del que se esta trabajando. Retorna un valor tipo String. -- Ernesto
    ''' </summary>
    ''' <param name="periodoActual">El periodo con el que se está trabajando</param>
    ''' <param name="tabla">Tabla de consulta</param>
    ''' <remarks></remarks>
    Private Function PeriodoAnterior(periodoActual As String, tabla As DataTable) As String
        Dim noFilas As Integer = tabla.Rows.Count
        Dim anoPeriodo As String = ""
        Dim perAnt As String = ""
        If tabla.Rows.Count > 0 And Not tabla.Columns.Contains("ERROR") Then
            For i As Integer = 0 To noFilas - 1
                If tabla.Rows(i)("periodo").ToString & tabla.Rows(i)("ano").ToString = periodoActual Then
                    perAnt = tabla.Rows(i - 1)("periodo").ToString & tabla.Rows(i - 1)("ano").ToString
                    Return perAnt
                End If
            Next
        End If
    End Function

    ''' <summary>
    ''' Si es valor null lo convierte en cadena. -- Ernesto
    ''' </summary>
    ''' <param name="valor">Dato a evaluar</param>
    ''' <remarks></remarks>
    Public Shared Function ValNullStr(valor As Object) As Object
        If IsDBNull(valor) Or valor Is Nothing Then
            Return ""
        Else
            If valor.GetType() Is GetType(System.String) Then Return Trim(valor)
            Return valor
        End If
    End Function

    ''' <summary>
    ''' Escribe la información en el archivo de excel (Encabezados y datos) -- Ernesto
    ''' </summary>
    ''' <param name="encabezado">Si hay encabezado</param>
    ''' <param name="excelHoja">Hoja de excel con la que se está trabajando</param>
    ''' <param name="dtInfo">Tabla de consulta</param>
    ''' <param name="excelFilaIni">Fila de excel de inicio</param>
    ''' <param name="excelDis">Arreglo referente a info de celdas o diseño</param>
    ''' <param name="excelFilaFin">Fila de excel de final</param>
    ''' <param name="cond">Condicion para excepciones de información en tabla</param>
    ''' <param name="excelColIni">Inicio de columna excel</param>
    ''' <remarks></remarks>
    Private Sub FormatoTablaCompleta(encabezado As Boolean,
                                     ByRef excelHoja As ExcelWorksheet,
                                     dtInfo As DataTable,
                                     excelFilaIni As Integer,
                                     arrDiseno As ArrayList,
                                     ByRef excelFilaFin As Integer,
                                     Optional cond As String = "",
                                     Optional excelColIni As Integer = 1)

        Dim _colNom() As String = Split(arrDiseno.Item(0), ",")
        Dim _col As Integer = excelColIni
        Dim _fil As Integer = excelFilaIni
        Dim _valCelda As Object = Nothing
        Dim _rango As String = ""

        For i As Integer = 1 To _colNom.Count
            If encabezado Then FormatoCelda(excelHoja, 0, _fil, _col, _colNom(i - 1), arrDiseno.Item(2), True, "", True, arrDiseno.Item(1))
            _col += 1
        Next

        _fil = _fil + 1

        If Not dtInfo Is Nothing Then

            For Each valores As DataRow In dtInfo.Rows

                For i As Integer = 1 To _col - 1
                    Dim _strCel As String = ""
                    Dim _doubleCel As Double = 0.0

                    _valCelda = valores.Item(_colNom(i - 1))

                    If _valCelda.GetType() Is GetType(System.DateTime) Then _strCel = FechaSQL(_valCelda)
                    If _valCelda.GetType() Is GetType(System.String) Then _strCel = _valCelda.ToString.Trim
                    If _valCelda.GetType() Is GetType(System.Double) Then _doubleCel = _valCelda
                    If _valCelda.GetType() Is GetType(System.DBNull) Then _strCel = "- -"

                    If _colNom(i - 1).Contains("Reloj") Or _colNom(i - 1).Contains("reloj") Then
                        FormatoCelda(excelHoja, 0, _fil, i, CInt(_strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right)

                    ElseIf (cond.Contains("PerDed") Or cond.Contains("CambSueldo")) And (_colNom(i - 1).Contains("Semana") Or _colNom(i - 1).Contains("Diferencia") Or _colNom(i - 1).Contains("Variabilidad") Or
                           _colNom(i - 1).Contains("Sueldo_anterior") Or _colNom(i - 1).Contains("Sueldo_nuevo") Or _colNom(i - 1).Contains("Variacion")) Then

                        If _colNom(i - 1).Contains("Variabilidad") Or _colNom(i - 1).Contains("Variacion") Then FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "0.00%") : _strCel = "" : Continue For
                        FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")

                    ElseIf (cond.Contains("DifPor") And _colNom(i - 1).Contains("Porcentaje")) Then
                        FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "0.00%")

                    ElseIf (cond.Contains("Descr") And _colNom(i - 1).Contains("Descripción")) And _valCelda.GetType() Is GetType(System.String) Then
                        FormatoCelda(excelHoja, 0, _fil, i, _strCel, arrDiseno.Item(3), False, "", False)

                    ElseIf ((cond.Contains("Descr") Or cond.Contains("Misc")) And _colNom(i - 1).Contains("Factor")) And _valCelda.GetType() Is GetType(System.Double) Then
                        FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.0000")

                    ElseIf _valCelda.GetType() Is GetType(System.Double) Then
                        If {"factor_dias", "factor_infonavit"}.Contains(_colNom(i - 1)) Then
                            FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "0.0000")
                        Else
                            FormatoCelda(excelHoja, 0, _fil, i, IIf(_strCel = "", _doubleCel, _strCel), arrDiseno.Item(3), False, "", False, Nothing, Style.ExcelHorizontalAlignment.Right, True, "#,##0.00")
                        End If
                    Else
                        FormatoCelda(excelHoja, 0, _fil, i, IIf(_valCelda.GetType() Is GetType(System.String), _strCel, _doubleCel), arrDiseno.Item(3), False, "", False)
                    End If
                Next
                _fil += 1
            Next
        End If

        excelFilaFin = _fil
    End Sub

    ''' <summary>
    ''' Obtiene la letra de la columna del excel de acuerdo a un parámetro de un número. -- Ernesto
    ''' </summary>
    ''' <param name="columnNumber">Número de columna</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function
#End Region

#Region "Funciones respaldo SQLite"

    ''' <summary>
    ''' Se hace una copia del archivo .sqlite del proceso en curso y se guarda de respaldo en una ruta predeterminada -- Ernesto -- 1 dic 2023
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Function CrearRespaldoLocal(ByRef data As Dictionary(Of String, String)) As Boolean
        Try
            '-- Se crea o indica la ruta de guardado
            Dim dtVar = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable='SQLITE_RESPALDOS'")
            Dim dtVar2 = sqlExecute("SELECT * FROM nomina.dbo.validaciones_procnomina WHERE variable='SQLITE_ARCHIVO_PROCESO'")

            Dim strDirResp = If(dtVar.Rows.Count = 0, "", dtVar.Rows(0)("valor"))
            Dim strArchivoProc = If(dtVar2.Rows.Count = 0, "", dtVar2.Rows(0)("valor"))

            If strDirResp = "" Then
                Dim dialog As New FolderBrowserDialog()

                dialog.RootFolder = Environment.SpecialFolder.Desktop
                dialog.Description = "Ruta de respaldo"

                If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then strDirResp = dialog.SelectedPath & "\" Else Return False
            End If

            Dim strRuta = strDirResp & "PERIODO " & If(data("tipoPeriodo") = "S", "SEM", "QNA") & " " & data("ano") & "-" & data("periodo")
            Dim dtVer = sqlExecute("SELECT COALESCE(max(version),0)+1 AS version FROM NOMINA.dbo.bitacora_proceso where ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "'")
            Dim strVer = If(dtVer.Rows.Count = 0, "1", dtVer.Rows(0)("version"))
            Dim strNombre = If(data("tipoPeriodo") = "S", "SEM", "QNA") & data("ano") & data("periodo") & "_" & strVer & ".sqlite"

            '-- Crea carpeta de respaldo para el periodo en curso si no existe
            If Not System.IO.Directory.Exists(strRuta) Then My.Computer.FileSystem.CreateDirectory(strRuta)

            '-- Se copia el archivo sqlite del proceso en curso a la carpeta de respaldos
            If System.IO.File.Exists(strArchivoProc) Then
                My.Computer.FileSystem.CopyFile(strArchivoProc, strRuta & "\" & strNombre, overwrite:=False)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Se restaura archivo .sqlite de una ruta definida -- Ernesto -- 1 dic 2023
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="dtBitacora"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RestauraRespaldoLocal(ByRef data As Dictionary(Of String, String), ByVal dtBitacora As DataTable) As Integer
        Try
            '-- Validacióm para poder restaurar desde BD
            Dim dtVar = sqlExecute("SELECT * FROM nomina.dbo.validaciones_procnomina WHERE variable='SQLITE_RESTAURA_DE_BD' AND valor=0")
            Dim dtVar2 = sqlExecute("SELECT * FROM nomina.dbo.validaciones_procnomina WHERE variable='SQLITE_ARCHIVO_PROCESO'")
            Dim strArchivoProc = If(dtVar2.Rows.Count = 0, "", dtVar2.Rows(0)("valor"))

            If dtVar.Rows.Count > 0 And (dtVar2.Rows.Count > 0 Or strArchivoProc.ToString.Length > 0) Then

                '-- Carga info. para variables desde BD
                data("etapa") = "Cargando bitacora" : Dim counter = 0 : Dim total = 5

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                Me.period = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(dtBitacora.Rows(0)("json_period"))

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                Me._globalVars = JsonConvert.DeserializeObject(Of Dictionary(Of String, Decimal))(dtBitacora.Rows(0)("json_globalVars"))

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                Me._options = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(dtBitacora.Rows(0)("json_options"))

                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                Me._logs = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(dtBitacora.Rows(0)("json_logs"))

                '-- Se carga archivo .sqlite del respaldo desde ruta definida
                If Not Me.BgWorker Is Nothing Then : Me.BgWorker.ReportProgress(100 * counter / total) : counter += 1 : End If
                data = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(dtBitacora.Rows(0)("json_data"))

                Dim dtVariables = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable='SQLITE_RESPALDOS'")
                Dim strDirRaiz = If(dtVariables.Rows.Count = 0, "", dtVariables.Rows(0)("valor"))

                If strDirRaiz = "" Then
                    Me.addLog("Sin ruta definida de respaldo: La carga se realizará desde base de datos [puede tardar]")
                    Return -1
                End If

                '-- Info. de archivo .sqlite de respaldo
                Dim strRuta = strDirRaiz & "PERIODO " & If(data("tipoPeriodo") = "S", "SEM", "QNA") & " " & data("ano") & "-" & data("periodo")
                Dim strVer = dtBitacora.Rows(0)("version")
                Dim strNombre = If(data("tipoPeriodo") = "S", "SEM", "QNA") & data("ano") & data("periodo") & "_" & strVer & ".sqlite"

                '-- Revisar si existe el respaldo
                If Not System.IO.File.Exists(strRuta & "\" & strNombre) Then
                    Me.addLog("No existe archivo de restauración: La carga se realizará desde base de datos [puede tardar]")
                    Return -1
                Else
                    '-- Se copia el archivo .sqlite de respaldo a la del proceso actual
                    If System.IO.File.Exists(strArchivoProc) Then
                        My.Computer.FileSystem.CopyFile(strRuta & "\" & strNombre, strArchivoProc, overwrite:=True)
                    Else
                        Me.addLog("Restauración de versión de bitacora por medio de BD [puede tardar]")
                        Return 0
                    End If

                End If
                Return 1
            Else
                Me.addLog("Restauración de versión de bitacora por medio de BD [puede tardar]")
                Return -1
            End If

        Catch ex As Exception
            Me.addLog("Error en restauración: " & ex.ToString)
            Return 0
        End Try
    End Function
#End Region

End Class

Public Class Sqlite

#Region "Vars"
    Private _tempPath As String
    Private _conn As SQLiteConnection
#End Region

#Region "Members"
    Private Shared _instance As Sqlite = Nothing
#End Region

#Region "Properties"
    Public ReadOnly Property sqliteConn As SQLiteConnection
        Get
            Return Me._conn
        End Get
    End Property
#End Region

#Region "Constructor"

    ''' <summary>
    ''' Rutas por default para el proceso en caso de no estar definidas
    ''' </summary>
    ''' <param name="opRuta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RutasDefaultArchivos(opRuta As String) As String
        Try
            '-- Variables
            Dim strDefault = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim dtInfo = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable in ('SQLITE_COMP')")
            Dim codComp = Nothing
            Dim strRutaFinal = ""

            '-- Nombre de compañia
            If dtInfo.Select("variable='SQLITE_COMP'").Count > 0 Then codComp = dtInfo.Select("variable='SQLITE_COMP'").First.Item("valor")
            codComp = If((IsNothing(codComp) OrElse IsDBNull(codComp)) OrElse codComp.ToString.Trim.Length = 0, "PIDA_PROCESO_NOMINA\", codComp & "_PROCESO_NOMINA\")

            Select Case opRuta
                Case "RUTA_PROCESO"
                    strRutaFinal = strDefault & "\" & codComp
                Case "RESPALDO_PROCESO"
                    strRutaFinal = strDefault & "\" & codComp & "RESPALDO_PROCESO\"
            End Select

            Return strRutaFinal
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Se validan rutas correctas para la corrida y respaldo del proceso
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidacionesRutas(ByRef rutaRed As Boolean)
        Try
            '---- Info. consulta para rutas
            Dim dtInfo = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable in ('SQLITE_ARCHIVO_PROCESO','SQLITE_RESPALDOS')")
            Dim strRuta = ""
            Dim strResp = ""
            rutaRed = False

            '-- Ruta del archivo de proceso principal
            If dtInfo.Select("variable='SQLITE_ARCHIVO_PROCESO'").Count > 0 Then
                Dim ruta = dtInfo.Select("variable='SQLITE_ARCHIVO_PROCESO'").First.Item("valor")
                strRuta = If(Not IsDBNull(ruta) AndAlso ruta.ToString.Trim.Length > 0, ruta, "")
            End If

            If strRuta.Length > 0 Then
                Me._tempPath = strRuta
                If strRuta.Contains("\\\\") Then rutaRed = True

                '-- Se confirma que exista la ruta, sino, se crea
                Dim strExiste = strRuta.Replace("ProcesoNomina.sqlite", "").Replace("\\\\", "\\")

                If Not System.IO.Directory.Exists(strExiste) Then
                    MessageBox.Show("No existe el DIRECTORIO de la RUTA DEFINIDA para el ARCHIVO de proceso, se creará automáticamente en la siguiente ubicación:" & vbNewLine & vbNewLine &
                                    strExiste, "Ruta de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    My.Computer.FileSystem.CreateDirectory(strExiste)
                End If
            Else
                '-- Ruta por default de archivo proceso
                Dim rutaProc = RutasDefaultArchivos("RUTA_PROCESO")

                MessageBox.Show("No existe una RUTA DEFINIDA para el ARCHIVO de proceso, se guardará y se creará automáticamente en la siguiente ubicación:" & vbNewLine & vbNewLine &
                                rutaProc, "Ruta de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '-- Se verifica si existe la carpeta sino la crea
                If Not System.IO.Directory.Exists(rutaProc) Then My.Computer.FileSystem.CreateDirectory(rutaProc)

                sqlExecute("insert into nomina.dbo.validaciones_procnomina values ('SQLITE_ARCHIVO_PROCESO','" & rutaProc & "ProcesoNomina.sqlite" & "','SQLite')")
                Me._tempPath = Path.Combine(rutaProc, "ProcesoNomina.sqlite")
            End If

            '-- Ruta del respaldo de proceso principal
            Dim respaldos = If(dtInfo.Select("variable='SQLITE_RESPALDOS'").Count > 0,
                               dtInfo.Select("variable='SQLITE_RESPALDOS'").First.Item("valor"),
                               DBNull.Value)

            If IsDBNull(respaldos) OrElse respaldos.ToString.Trim.Length = 0 Then
                strResp = RutasDefaultArchivos("RESPALDO_PROCESO")

                MessageBox.Show("No existe una RUTA DEFINIDA para los RESPALDOS del proceso, se guardará y se creará automáticamente en la siguiente ubicación:" & vbNewLine & vbNewLine &
                                strResp, "Ruta de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '-- Se verifica si existe la carpeta sino la crea
                If Not System.IO.Directory.Exists(strResp) Then My.Computer.FileSystem.CreateDirectory(strResp)

                sqlExecute("insert into nomina.dbo.validaciones_procnomina values ('SQLITE_RESPALDOS','" & strResp & "','SQLite')")
            Else
                '-- Se confirma que exista la ruta, sino, se crea
                If Not System.IO.Directory.Exists(respaldos.Replace("ProcesoNomina.sqlite", "")) Then
                    MessageBox.Show("No existe el DIRECTORIO de la RUTA DEFINIDA para los RESPALDOS de proceso, se creará automáticamente en la siguiente ubicación:" & vbNewLine & vbNewLine &
                                     respaldos, "Ruta de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    My.Computer.FileSystem.CreateDirectory(respaldos)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Constructor de archivo .sqlite
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Dim rutared = False

        Try
            ValidacionesRutas(rutared)
            If rutared Then Me._tempPath = Me._tempPath.Replace("\\\\", "\\")
            If System.IO.File.Exists(Me._tempPath) Then : System.IO.File.Delete(Me._tempPath) : End If
        Catch ex As Exception : MessageBox.Show(ex.Message) : End Try

        Me._conn = New SQLiteConnection(String.Format("Data Source={0};Version=3;", Me._tempPath))
        If rutaRed Then Me._conn.ParseViaFramework = True

    End Sub

    'Patrón Singleton
    Public Shared Function getInstance() As Sqlite
        If _instance Is Nothing Then : _instance = New Sqlite : End If
        Return _instance
    End Function
#End Region

#Region "Functions"

    Public Sub createTable(table As DataTable, name As String)
        'Dim columns = (From k As DataColumn In table.Columns Where k.ColumnName.ToLower <> "id" Select String.Format("{0} varchar(255)", k.ColumnName.ToLower)).ToList

        Dim columns As New List(Of String)
        For Each col As DataColumn In table.Columns
            If col.ColumnName.ToLower <> "id" Then
                Dim type = "varchar(255)"
                Select Case col.DataType
                    Case GetType(System.Boolean) : type = "varchar(5)"
                    Case GetType(System.Int32) : type = "INTEGER"
                    Case GetType(System.Double) : type = "DOUBLE"
                    Case GetType(System.Char) : type = "varchar(1)"
                    Case GetType(System.String) : type = "varchar(255)"
                    Case GetType(System.DateTime) : type = "varchar(10)"
                End Select
                columns.Add(String.Format("{0} {1}", col.ColumnName.ToLower, type))
            End If
        Next

        Try
            Me._conn.Open()
            Dim sqlite_cmd1 As New SQLiteCommand(String.Format("DROP TABLE IF EXISTS {0}; CREATE TABLE {0} (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, {1});", name, String.Join(",", (From k In columns))), Me._conn)
            sqlite_cmd1.ExecuteNonQuery()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally : Me._conn.Close()
        End Try
        'Dim sqlite_cmd As SQLiteCommand = Me._conn.CreateCommand
        'sqlite_cmd.CommandText = String.Format("CREATE TABLE IF NOT EXISTS {0} id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, {1}", name, String.Join(",", (From k As DataColumn In table.Columns Select String.Format("{0} NVARCHAR(255)", k.ColumnName))))
        'sqlite_cmd.ExecuteNonQuery()
    End Sub

    ''' <summary>
    ''' Funcion para ejecutar updates, insert y deletes en sqlite -- Ernesto -- 11 dic 2023
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <remarks></remarks>
    Public Sub ExecuteNonQueryFunc(sql As String)
        Try
            Me._conn.Open()
            Using transaction = Me._conn.BeginTransaction
                Dim sqlite_cmd1 As New SQLiteCommand(sql, Me._conn)
                sqlite_cmd1.ExecuteNonQuery()
                transaction.Commit()
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally : Me._conn.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Insertar registros a tablas sqlite -- Modif. 22 dic 2023
    ''' </summary>
    ''' <param name="row">Dic. con info de registro a ingresar</param>
    ''' <param name="name">Nom. de tabla</param>
    ''' <remarks></remarks>
    Public Sub insert(row As Dictionary(Of String, Object), name As String)
        Dim nullValues As New List(Of Object) From {Nothing, "", "{}"}
        Dim columns = String.Join(",", (From k In row.Keys Select k))

        Dim fixed_vals = (From i In row.Values Select IIf(i Is Nothing, "", i)).ToList
        Dim values = String.Join(",", (From k In fixed_vals Select IIf(nullValues.Contains(k.ToString), "NULL", "'" & k.ToString.Trim & "'")))

        Try
            ExecuteNonQueryFunc(String.Format("INSERT INTO {0} ({1}) VALUES ({2})", name, columns, values))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Function sqliteExecute(sql As String) As DataTable
        Dim dtresult As New DataTable
        Try
            Me._conn.Open()
            Dim dataAdapt As New SQLiteDataAdapter(sql, Me._conn)
            dataAdapt.Fill(dtresult)
        Catch ex As Exception
        Finally : Me._conn.Close()
        End Try
        Return dtresult
    End Function

    Public Sub deleteTable()
        If System.IO.File.Exists(Me._tempPath) Then : System.IO.File.Delete(Me._tempPath) : End If
    End Sub
#End Region
End Class
