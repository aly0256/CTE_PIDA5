Imports System.Data.SqlClient
Imports System
Imports System.Threading
Imports System.IO
'Buscar específicamente Microsoft.Office.Interop.Excel.dll en la máquina
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Reporting.WinForms
Imports System.Runtime.CompilerServices

Imports System.Security.Cryptography
Imports System.Text

Module Declaraciones

    '====Variables para seguridad en el Login :
    Public tickLogin As Boolean = False
    Public dtPalabrasReservadas As DataTable
    Public controlActivo = Nothing '-- Control activo de la forma
    '====END Variables para seguridad en el login

    '== Bandera para señalar si determinada forma esta abierta              2mayo2022
    Public formaAbierta As Boolean

    '== Seleccionar año para reporte percepciones totales nomina                3ene2021
    Public anioSel As String = ""

    '== En el reporteador de TA, almacena la información de la segunda empresa          25nov2021
    Public dtInfoPlanta2 As New DataTable
    Public selecPlantaRep As Integer = 0

    '== Almacena las fechas de inicio y fin de un periodo desde el reporteador de ta con el filtro          27oct2021           Ernesto
    Public f_inicio As Date = Nothing
    Public f_final As Date = Nothing
    Public p_num As String = ""
    Public p_anio As String = ""

    '== Desde forma de empleados por curso              1oct2021
    Public _varRelojCurso As String = ""

    '== Nombre de los reportes que se generan (esta vez solo para ta)           6oct2021
    Public _varNomReport As String = ""

    '==Horario de empleado en TA (de acuerdo a la bitacora)                 22sep2021
    Public HorBitEmp As String = ""

    'Cafeteria
    Public BorrarCafeteria As Boolean = False
    Public CafFechaIni As Date = Nothing
    Public CafFechaFin As Date = Nothing

    'Declaraciones para proceso de cálculo de la nómina -- 25/07/2020 :: AOS
    Public acum_percep As Double
    Public acum_deduc As Double
    Public acum_neto As Double
    Public acum_exento As Double
    Public isrCausado As Double
    Public isrRetenido As Double
    Public subempleoCausado As Double
    Public subempleoPagado As Double
    Public fromCondFinanzas As Boolean '  Variable para indicar qeu viene del condensado de Finanzas

    Public CalcIndivKey As String
    Public saldo_tot_fahc As Double
    Public saldo_tot_fahe As Double
    Public totSemDescInfo As Double
    Public dtRecibosGlobal As DataTable
    Public nombreNomEspecial As String ' Var para indicar que tipo de nom se va  a procesar
    Public FecAplVar As String  ' Var para indicar la fecha de aplicacion de las variables

    '--Ends declaraciones para proc de Nomina

    Public AcumularNom As Boolean = False
    Public aniosRepNom As String = ""
    Public persRepNom As String = ""
    Public TipoPersNom As String = ""

    'ACASAS 20180417 
    Public ANALISIS_AUTOMATICO As Boolean = False

    Public ReporteTMP As New LocalReport
    Public MostrarReporte As Boolean = True
    Public MensajeError As String = ""
    Public FormaOrigen As String

    Public addInfoFirstTime As Boolean = False ' Agregar infonavit la primera vez en RH

    '----Para carga de documentos de personal
    Public PathArchivos As String       'Ubicaci n de los archivos del personal
    Public MsjErr As String = ""

    Structure OrdenFiltro
        Public Orden As String
        Public Filtro As String
    End Structure

    Structure DetalleSemana
        Public Mixto As Boolean
        Public NumSemana As Integer
        Public Factor As Double
        Public cod_hora As String
    End Structure

    Structure InfoCFDI
        Dim Compania As String
        Dim DireccionKey As String
        Dim DireccionCer As String
        Dim PasswordKey As String
        Dim UsuarioWeb As String
        Dim PasswordWeb As String
        Dim DirComercioDigital As String
        Dim DirDestino As String
        Dim Banco As String
        Dim Riesgo As String
        Dim entidad As String
    End Structure


    'MCR 2018-20-04***********
    Public anDobles As Double = 0
    Public anTriples As Double = 0
    Public anPerS As String = ""
    Public anSem As String = ""
    Public anComentario As String = ""
    '*************************
    Public ConsultaAhorro As New frmConsultaAhorroBRP
    Public CLABE_fah As String = ""
    Public RelojClabe As String

    Public reloj_mot_baj As String = ""
    'Horario excepcion
    Public horario_exc As String
    Public nombres_exc As String
    Public reloj_exc As String

    'Fecha cambio inactivo
    Public msginactivo As String = ""
    Public fechaultimo As Date = Nothing

    'Longitud del campo reloj
    Public LongReloj As String = 5
    Public ConsultaReloj As String

    Public mgrColorTint As Color
    Public mgrStyle As DevComponents.DotNetBar.eStyle
    Public desdeTE As Boolean = False
    Public strRespuesta As String
    Public VacacionesDesdeVariables As Boolean

    Public cod_capacitacion As String

    'MCR 9/NOV/2015
    Public IniciaLunes As Boolean
    'Ideas
    Public relojidea As String
    Public listarelojes As String
    Public totalcolaboradores As Integer
    Public mesideas As String
    'Filtro reporte edad de hijos
    Public EdadHijos As Integer = 0
    Public CapturaEdad As Boolean = False
    'Genrar reporte individual o general de las acciones disciplinarias
    Public DisciplinarioIndividual As Boolean
    Public DisciplinarioGeneral As Boolean
    Public DisciplinarioPDF As Boolean
    Public DisciplinarioEstadistico As Boolean
    Public TipoReporteEstadistico As String
    'Reporte Tiempo Extra
    Public TiempoExFecha As String
    Public TiempoExFechaEntro As String
    'Editar accion disciplinaria'
    Public folioDisciplinaria As String
    Public editarDisciplinaria As Boolean = False
    Public PathFirma As String      'Ubicacion de la firma(Capacitacion)
    'Reportes DC3
    Public repEmpresa As String
    Public repEmpleados As String
    'Reporteador
    Public EtiquetasDisponibles() As Integer
    Public drGrupo As DataRow
    Public Ano As String
    Public Periodo As String
    Public GrupoAuxiliares As Boolean = False
    Public NumControl As Integer
    Public ReporteDiario As Boolean = True
    '*** Reporteador de CAFETERIA **** CARLOS JUAREZ
    Public dtResultadoCafeteria As DataTable

    Public NCEmpl As Integer ' Para saber si va a ser num consec automatico o va  ser manual

    '--- PARAMETROS de cálculo para el PTU
    Public dias_ptu As Double = 0.0, cant_repartir As Double = 0.0, sd_max As Double = 0.0

    '******************************************
    'Private trd As Thread

    Public MtroDedConcepto As String
    Public MtroDedSaldo As Double
    Public drMtroDed As DataRow

    'Editar ajustes
    Public AjustesNomKey As String
    '*********************************

    'Editar/agregar cursos por empleado
    Public keyCurso As String
    Public keyReloj As String
    Public keyFechaInicio As Date
    'Si la captura es desde la pantalla de consulta individual, se aplica directamente
    'Si se captura desde la pantalla de captura general, no se debe aplicar aún...
    Public AplicarCurso As Boolean = True
    '*********************************

    Public ApVer As String  'Version de la publicación
    Public arCampos(0 To 29, 0 To 1) As String

    Public resCancelar As Boolean = True
    Public Const LetraDefault = -16777216
    Public Const FondoDefault = -1

    '**** VARIABLES DE SEGURIDAD ***
    Public Usuario As String
    Public FiltroXUsuario As String
    Public Perfil As String
    Public NivelConsulta As Integer
    Public Limite_TE As String
    Public NivelSueldos As Integer
    Public NivelEdicion As Integer
    Public ModuloInicial As String
    '*******************************

    '***** VARIABLES DE CONEXION A SQL usuario
    Public sForm As String

    Public SQLConn As String
    Public sPassword As String
    Public sUserAdmin As String

    'Public Const SQLConn As String = "Data Source=DREY\SQLPIDA"
    'Public Const sPassword As String = "soporte"
    'Public Const sUserAdmin As String = "sa"
    'Public SQLConn As String = "Data Source=miriam-hp\sqlexpress2012"
    'Public sPassword As String = "pida123"
    'Public sUserAdmin As String = "sa"


    Structure strucSucursales
        Public nombre As String
        Public conexion As String
        Public usuario As String
        Public clave As String
        Public def As Boolean
    End Structure
    '********************************************
    Public fecha_bitacora_wme As String = ""

    'Public myConn As New SqlConnection(SQLConn)
    Public sqlConexion As New SqlCommand
    Public sqlAdaptador As New SqlDataAdapter
    Public dtResulta As New DataTable

    Public dtTemporal As New DataTable

    Public no_locker As String      'numero de locker para operaciones
    Public grupo_locker As String   'grupo para separar lockers P1 y P2
    Public EmpIdx As Integer
    Public Reloj As String
    Public RelojSF As String
    Public Folio As String
    Public Reloj2 As String
    Public Compania As String
    Public PathFoto As String       'Ubicación de la foto
    Public EsBaja As Boolean        'Saber si el empleado está dado de baja
    Public Reingreso As Boolean     'Saber si el empleado es un reingreso

    Public CadenaBuscar As String   'Cadena a buscar en forma BuscaGeneral
    Public Codigo As String         'Codigo resultante en búsqueda de forma BuscaGeneral

    Public Filtros(,) As String     'Arreglo de filtros seleccionados
    Public NFiltros As Integer      'Cuantos filtros se han asignado
    Public Orden(,) As String       'Arreglo de campos seleccionados para ordenar
    Public NOrden As Integer        'Cuantos campos se han seleccionado para ordenar
    Public FiltroReporte As String  'Cadena de filtro para reporte
    Public OrdenReporte As String   'Cadena de orden para reporte
    Public EncabezadoReporte As String  'En nómina, el encabezado indica el periodo(s) seleccionados

    Public FechaInicial As Date
    Public FechaFinal As Date
    Public DireccionReportes As String

    Public PlantaReporteDiario As String = "***"

    'Datatable para reporteador de personal
    Public dtRHReporteador As New DataTable
    Public dtFiltroPersonal As New DataTable
    Public dtResultado As New DataTable
    Public dtReporteDinamico As New DataTable

    'Banderas para reporteadorTA
    Public TipoFiltro As String = ""
    Public RangoFInicial As Date = Nothing
    Public RangoFFinal As Date = Nothing
    Public AnoSelec As String = Nothing
    Public PeriodoSelec As String = Nothing
    Public TipoPeriodo As String = Nothing
    Public TipoPerSelec As String = Nothing

    'DataTable reporteador TAlloc
    Public dtResultadoTAlloc As New DataTable


    'DataTable reporteador TAlloc
    Public dtResultadoIDEAS As New DataTable

    'DataTable reporteador TA
    Public dtTAReporteador As New DataTable
    Public dtFiltroTA As New DataTable
    Public dtResultadoTA As New DataTable
    Public dtReporteDinamicoTA As New DataTable
    Public dtTAFiltroTA_2 As New DataTable

    'DataTable reporteador Ausentismo
    Public dtAUSReporteador As New DataTable
    Public dtFiltroAUS As New DataTable
    Public dtResultadoAUS As New DataTable
    Public dtReporteDinamicoAUS As New DataTable

    Public ActivoTrabajando As Boolean = False  'Bandera para indicar si está abierta la pantalla de frmTrabajando
    Public ContieneCampoCia As Boolean

    'Para crear reporte dinámico
    Public dtDisponibles As New DataTable
    Public ReporteadorFuente As String          'Para saber de qué módulo se manda llamar "Crear reporte dinámico"

    '*** Reporteador de nómina ****
    Public dtNominaReporteador As New DataTable
    Public dtNominaCondensado As New DataTable

    Public dtResultadoNomina As New DataTable
    Public PeriodosReporteador() As String
    Public CiaReporteador As String

    Public FiltrosNomina(,) As String     'Arreglo de filtros seleccionados
    Public NFiltrosNomina As Integer      'Cuantos filtros se han asignado
    Public OrdenNomina(,) As String       'Arreglo de campos seleccionados para ordenar
    Public NOrdenNomina As Integer        'Cuantos campos se han seleccionado para ordenar


    '*** Reporteador de capacitación ****
    Public dtCapacitacionReporteador As New DataTable
    Public dtResultadoCapacitacion As New DataTable
    Public FiltrosCapacitacion(,) As String     'Arreglo de filtros seleccionados
    Public NFiltrosCapacitacion As Integer      'Cuantos filtros se han asignado
    Public OrdenCapacitacion(,) As String       'Arreglo de campos seleccionados para ordenar
    Public NOrdenCapacitacion As Integer        'Cuantos campos se han seleccionado para ordenar
    Public MesSelec As String = Nothing


    '****Declaraciones para MapDrive****
    Public Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer
    Public Declare Function WNetCancelConnection2 Lib "mpr" Alias "WNetCancelConnection2A" (ByVal lpName As String, ByVal dwFlags As Integer, ByVal fForce As Integer) As Integer
    Public Const ForceDisconnect As Integer = 1
    Public Const RESOURCETYPE_DISK As Long = &H1
    Private Const ERROR_BAD_NETPATH = 53&
    Private Const ERROR_NETWORK_ACCESS_DENIED = 65&
    Private Const ERROR_INVALID_PASSWORD = 86&
    Private Const ERROR_NETWORK_BUSY = 54&

    'Declaración para concepto no localizado en carga de nómina
    Public NvoConcepto As String = ""

    ' en declaraciones
    '**** variables para la impresion

    Public PageHeight As Double = 11
    Public PageWidth As Double = 8.5

    Public TopMargin As Double = 0.2
    Public BottomMargin As Double = 0.2
    Public LeftMargin As Double = 0.25
    Public RightMargin As Double = 0.25

    Public landscape As Boolean = False
    Public seleccionado As String = "" ' Carga periodos para el pago de nomina en la captura de vacaciones desde el mtro de empleados

    Public Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure
    '***********************************

    Public Sub ActivityLog(ByVal Usuario As String, ByVal Actividad As String, ByVal reloj As String, ByVal codigo As String)
        Dim Cadena As String
        Try
            If Not Perfil.Equals("ADMINISTRADOR") Then
                Cadena = "INSERT INTO ActivityLog(Usuario,equipo,fecha_hora,actividad,version,reloj,codigo) VALUES ('" & Usuario & "','" & My.Computer.Name & "',GETDATE(),'"
                Cadena = Cadena & Actividad & "','" & ApVer & "','" & reloj & "','" & codigo & "')"
                dtTemporal = sqlExecute(Cadena, "KIOSCO")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", Err.Number, ex.Message)
        End Try
    End Sub

    'Public Sub ErrorLog(ByVal Usuario As String, ByVal Procedimiento As String, ByVal Forma As String, ByVal ErrNum As Long, ByVal ErrDesc As String, Optional Comentarios As String = "")
    '    Dim Cadena As String

    '    Try
    '        Comentarios = Comentarios.Replace("'", "''")
    '        ErrDesc = ErrDesc.Replace("'", "''")
    '        Cadena = "INSERT INTO ErrorLog (usuario,fechahora,procedimiento,forma,version,errnum,errdesc,comentarios,origen) VALUES ('" & Usuario & "',GETDATE(),'"
    '        Cadena = Cadena & Procedimiento & "','" & Forma & "','" & ApVer & "'," & ErrNum & ",'" & ErrDesc & "','" & Comentarios & "','" & _
    '            My.Computer.Name & "')"

    '        'dtTemporal = sqlExecute(Cadena, "seguridad")

    '    Catch ex As Exception
    '        MessageBox.Show("No se pudo insertar registro en bitácora de errores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '    End Try
    'End Sub

    Public Sub ErrorLog(ByVal Usuario As String, ByVal Procedimiento As String, ByVal Forma As String, ByVal ErrNum As Long, ByVal ErrDesc As String, Optional Comentarios As String = "")
        Dim Cadena As String
        Try
            Comentarios = Comentarios.Replace("'", "''")
            ErrDesc = ErrDesc.Replace("'", "''")
            Cadena = "INSERT INTO ErrorLog (usuario,fechahora,procedimiento,forma,version,errnum,errdesc,comentarios) VALUES ('" & "PIDA-" & Usuario & "',GETDATE(),'"
            Cadena = Cadena & Procedimiento & "','" & Forma & "','" & ApVer & "'," & ErrNum & ",'" & ErrDesc & "','" & Comentarios & "')"
            dtTemporal = sqlExecute(Cadena, "KIOSCO")
        Catch ex As Exception
            'MessageBox.Show("No se pudo insertar registro en bitácora de errores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Function ListaSucursales() As strucSucursales()
        Dim Sucursales(2) As strucSucursales

        '===GIT COMMIT TEST NEW

        '---- Server CTE
        Sucursales(0).nombre = "CTE"
        Sucursales(0).conexion = "Data Source=SERVERTC2\SQLPIDA"
        Sucursales(0).clave = "adip*014"
        Sucursales(0).usuario = "sa"
        Sucursales(0).def = True

        '-----SERVER CTE VPN
        Sucursales(1).nombre = "CTE_VPN"
        Sucursales(1).conexion = "Data Source=192.168.1.4"
        Sucursales(1).clave = "adip*014"
        Sucursales(1).usuario = "sa"
        Sucursales(1).def = False

        '----Local Server Pida
        Sucursales(2).nombre = "CTE_Server_Pida"
        Sucursales(2).conexion = "Data Source=PIDA-FS1\SQL_CTE"
        Sucursales(2).clave = "adip*014"
        Sucursales(2).usuario = "sa"
        Sucursales(2).def = False

        ''--- E
        'Sucursales(0).nombre = "CTE_LOCAL"
        'Sucursales(0).conexion = "Data Source=PIDA-DELL-1\CTE_LOCAL"
        'Sucursales(0).clave = "adip*014"
        'Sucursales(0).usuario = "sa"
        'Sucursales(0).def = True

        'Sucursales(0).nombre = "WME_LOCAL_ADRI"
        'Sucursales(0).conexion = "Data Source=DESKTOP-U1IAPNV\SQL_WME"
        'Sucursales(0).clave = "adip*014"
        'Sucursales(0).usuario = "sa"
        'Sucursales(0).def = True

        'Sucursales(0).nombre = "WME"
        'Sucursales(0).conexion = "Data Source=DESKTOP-UA6SL7J\SQLWSM"
        'Sucursales(0).clave = "root"
        'Sucursales(0).usuario = "sa"
        'Sucursales(0).def = True

        'Sucursales(0).nombre = "WME"
        'Sucursales(0).conexion = "Data Source=LEOSMS006\SQLEXPRESS"
        'Sucursales(0).clave = "BDPayroLL20$"
        'Sucursales(0).usuario = "sa"
        'Sucursales(0).def = True

        'Sucursales(1).nombre = "WSM - SALES"
        'Sucursales(1).conexion = "Data Source=LEOSMS006\SQLWSA"
        'Sucursales(1).clave = "BDPayroLL20$"
        'Sucursales(1).usuario = "sa"
        'Sucursales(1).def = False

        '----PONCHO 2023-12-13
        'Sucursales(0).nombre = "LOCAL_PONCHO"
        'Sucursales(0).conexion = "Data Source=DESKTOP-O5H2RUS\SQLWOLLTEST"
        'Sucursales(0).clave = "adip*014"
        'Sucursales(0).usuario = "sa"
        'Sucursales(0).def = True

        ''----IVETTE
        'Sucursales(1).nombre = "LOCAL_IVETTE"
        'Sucursales(1).conexion = "Data Source=DESKTOP-CKGE1I8\SQLWOLLTEST"
        'Sucursales(1).clave = "adip*014"
        'Sucursales(1).usuario = "sa"
        'Sucursales(1).def = False

        ''----PIDA_DESARROLLO
        'Sucursales(2).nombre = "PIDA_DESARROLLO"
        'Sucursales(2).conexion = "Data Source=PIDA-FS1\PIDA_BASE"
        'Sucursales(2).clave = "adip*014"
        'Sucursales(2).usuario = "sa"
        'Sucursales(2).def = False

        Return Sucursales
    End Function

    '== Función para enviar correos                         11feb2022               Ernesto
    Public Function EnviarCorreo(mensaje As String, Asunto As String, Destinatario As String, Archivo As String, Optional Archivo2 As String = "") As Boolean
        Try

            Dim r As New System.Web.Mail.MailMessage
            r.Body = mensaje
            r.BodyEncoding = System.Text.Encoding.UTF8
            '  r.BodyFormat = Web.Mail.MailFormat.Text
            r.BodyFormat = Web.Mail.MailFormat.Html ' Formato HTML
            r.Subject = Asunto


            '== Remitente
            ' r.From = "sistema.pida@gmail.com" ' Cuenta de PIDA de Gmail para pruebas:: YA NO FUNCIONA A PARTIR DE MAYO DEL 2022
            '  r.From = "aosw82@hotmail.com" ' Cuenta de Hotmail para pruebas
            '  r.From = "adrian.ortega@pida.com.mx" ' Cuenta Pida prueba
            r.From = "no-reply@wollsdorf.com" ' Cuenta de Wollsdorf

            '== Adjuntar archivos al correo
            r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo))
            If Not Archivo2.Equals("") Then
                r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo2))
            End If

            ''== Cuenta de prueba PIDA NOTA: Apartir del MAYO DEL 2022 YA NO FUNCIONA
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.gmail.com"
            '' r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 587 ' Es para TLS, el menos utilizado
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 465 ' Es para SSL el mas utilizado y con el que se ha probado el envío
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            '  r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "sistema.pida@gmail.com"
            '   r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Resultados2"

            '== Cuenta de PIDA - NO HA FUNCIONADO
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.pida.com.mx"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "adrian.ortega@pida.com.mx"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Resultados_01"

            '=== Cuenta HOTMAIL
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.office365.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 587
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True ' Encriptado debe de ser true siempre
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "aosw82@hotmail.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = ""
            ''r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "17752913c92d92e967a8ec954d8ece4b"


            '== Cuenta de WME actual (abril 2021)
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "mail.wollsdorf.com"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 0
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "leo_svc_pida"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "GQa4oJ1H3Q9d9dJhWrh8"

            r.To() = Destinatario
            System.Web.Mail.SmtpMail.SmtpServer = "mail.wollsdorf.com" ' Wollsdorf
            '  System.Web.Mail.SmtpMail.SmtpServer = "smtp.pida.com.mx" ' PIDA
            ' System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com" ' Gmail
            'System.Web.Mail.SmtpMail.SmtpServer = "smtp.office365.com" ' Hotmail

            Try
                System.Web.Mail.SmtpMail.Send(r)
                Return True
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio Correo SMTP", Err.Number, ex.Message)
                Return False
            End Try

            ' Try : System.Web.Mail.SmtpMail.Send(r) : Return True : Catch ex As Exception : Return False : ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio Correo SMTP", Err.Number, ex.Message) : End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EnviarCorreoPIDA", Err.Number, ex.Message)
            Return False
        End Try
    End Function

    '== Función para filtrar información de datatables de acuerdo a usuario u otro parámetro                            2mayo2022           Ernesto
    Public Function FiltraInformacion(dtInfo As DataTable, campoFiltro As String) As DataTable
        Try

            '== Determina el tipo de perfil
            Dim tipoPerfil As String = "" : Dim dtRes As New DataTable : Dim filtro As String = "" : Dim relojUsuario As String = ""
            Dim QryGral As String = "SELECT * FROM SEGURIDAD.dbo.appuser WHERE USERNAME='" & Usuario & "'"
            Dim dtUsuario As DataTable = sqlExecute(QryGral)

            If dtUsuario.Rows.Count > 0 Then tipoPerfil = dtUsuario.Rows(0)("cod_perfil").ToString.Trim : relojUsuario = dtUsuario.Rows(0)("reloj").ToString.Trim

            '== Filtro
            Select Case tipoPerfil
                Case "SUPERV"
                    dtRes = dtInfo.Clone : filtro = campoFiltro & " in ('" & dtUsuario.Rows(0)("reloj").ToString.Trim & "')"
                    ' For Each x As DataRow In dtInfo.Select(filtro) : dtRes.ImportRow(x) : Next
                    For Each x As DataRow In dtInfo.Rows : dtRes.ImportRow(x) : Next

                Case "GERENTE_MEDICO"
                    QryGral = "SELECT * FROM PERSONAL.dbo.super WHERE reloj='" & relojUsuario & "'"
                    Dim dtGerMed = sqlExecute(QryGral)

                    dtRes = dtInfo.Clone : filtro = campoFiltro & " in ('" & dtGerMed.Rows(0)("cod_super") & "')"

                    If dtInfo.Columns.Contains("cod_super") Then
                        For Each x As DataRow In dtInfo.Select(filtro) : dtRes.ImportRow(x) : Next
                    Else
                        Dim dtEmpSuper As DataTable = sqlExecute("SELECT * FROM PERSONAL.dbo.personal WHERE " & filtro & "")
                        For Each r As DataRow In dtInfo.Rows
                            For Each s As DataRow In dtEmpSuper.Select("reloj='" & r.Item("reloj").ToString.Trim & "'")
                                dtRes.ImportRow(r)
                            Next
                        Next
                    End If

                Case Else
                    dtRes = dtInfo.Copy
            End Select

            Return dtRes

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '== Para botones de navegacion                 2may2022        Ernesto
    Public Function NavegacionRegistros(ByVal strOp As String, ByVal dtInfo As DataTable, Optional strFiltro As String = "", Optional strOrden As String = "") As DataTable

        Dim pos = 0
        Dim dtResultado As DataTable = dtInfo.Clone

        Select Case strOp
            Case "SigAnt"
                For Each row As DataRow In dtInfo.Select(strFiltro, strOrden) : dtResultado.ImportRow(row) : Exit For : Next
            Case "Primero"
                pos = 1
            Case "Ultimo"
                pos = dtInfo.Rows.Count
        End Select

        If strOp = "Primero" Or strOp = "Ultimo" Then
            Dim cont = 1
            For Each row As DataRow In dtInfo.Rows
                If cont = pos Then
                    dtResultado.ImportRow(row)
                    Exit For
                End If
                cont += 1
            Next
        End If

        Return dtResultado

    End Function

    '== Filtro de información para la información en los reportes                        22nov2021
    Public Function FiltroPerfilReportes(ByRef dtInfo As DataTable, filtro As String) As DataTable
        Try
            '== Filtros actuales
            Dim filtroReportes As New ArrayList
            filtroReportes.Add("3RLO*Formato de solicitud de tiempo extra")

            If filtroReportes.Contains(filtro) Then
                Dim dtInfoUser As DataTable = sqlExecute("select RTRIM(s.RELOJ) as reloj,RTRIM(s.cod_super) as no_super from PERSONAL.dbo.super s " & _
                                                                                           "left join SEGURIDAD.dbo.appuser u on s.RELOJ=u.reloj " & _
                                                                                           "where u.USERNAME='" & Usuario.Trim & "'")
                Dim dtTempInfo As DataTable = dtInfo.Clone

                If dtInfoUser.Rows.Count > 0 Then
                    Dim dtPersonal As DataTable = sqlExecute("select rtrim(reloj) as reloj from personal.dbo.personal where cod_super='" & dtInfoUser.Rows(0)("no_super").ToString.Trim & "'")
                    If dtPersonal.Rows.Count > 0 Then
                        For Each x As DataRow In dtPersonal.Rows
                            For Each y As DataRow In dtInfo.Select("reloj = '" & x.Item("reloj").ToString & "'")
                                dtTempInfo.ImportRow(y)
                            Next
                        Next
                    End If
                    Return dtTempInfo
                Else
                    Return dtInfo
                End If
            Else
                Return dtInfo
            End If

        Catch ex As Exception
            Return dtInfo
        End Try
    End Function

    Public Sub PermitirAccesosXperfil()
        Try

            For Each TabItem As Object In frmMain.rbGeneral.Items
                If TypeOf TabItem Is DevComponents.DotNetBar.RibbonTabItem Then
                    TabItem.visible = RevisarAccesos(TabItem.panel)
                End If
            Next

            'frmMain.RecursosHumanos.Visible = RevisarAccesos(frmMain.rpPersonal)
            'frmMain.TiempoAsistencia.Visible = RevisarAccesos(frmMain.rpTA)
            'frmMain.Nomina.Visible = RevisarAccesos(frmMain.rpNomina)
            'frmMain.Seguridad.Visible = RevisarAccesos(frmMain.rpSeguridad)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Function ValidarClaveAcceso(Clave As String) As Boolean
        Dim Valido As Boolean = False
        Dim c As String = ""
        Dim May As Integer = 0
        Dim Min As Integer = 0
        Dim Esp As Integer = 0
        Dim Num As Integer = 0
        Dim x As Integer
        Dim dtCia As New DataTable
        Dim Validar As Boolean
        Dim Longitud As Integer
        Try
            dtCia = sqlExecute("SELECT validar_clave_acceso,longitud_clave_acceso FROM parametros")
            If dtCia.Rows.Count = 0 Then Return False
            Validar = IIf(IsDBNull(dtCia.Rows(0).Item("validar_clave_acceso")), 0, dtCia.Rows(0).Item("validar_clave_acceso"))
            Longitud = IIf(IsDBNull(dtCia.Rows(0).Item("longitud_clave_acceso")), 8, dtCia.Rows(0).Item("longitud_clave_acceso"))

            If Not Validar Then Return True

            If Clave.Length < Longitud Then
                Valido = False
            Else
                For x = 0 To Clave.Length - 1
                    c = Clave.Substring(x, 1)
                    If Not Char.IsLetterOrDigit(c) Then
                        Esp = Esp + 1
                    ElseIf IsNumeric(c) Then
                        Num = Num + 1
                    ElseIf Char.IsUpper(c) Then
                        May = May + 1
                    ElseIf Char.IsLower(c) Then
                        Min = Min + 1
                    End If
                Next
            End If

            If Min >= 1 And May >= 1 And Num >= 1 And Esp >= 1 Then
                Valido = True
            End If

            Return Valido
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, Clave)
            Return False
        End Try

    End Function


    Public Structure campo_mantenimiento
        Public nombre_campo As String
        Public longitud As Integer
    End Structure

    Public campos_mantenimiento As New ArrayList


    Public Function CrearTablaMNT(ByVal dtResulta As DataTable, cia As String) As Boolean
        Dim Cadena As String

        Dim s As String
        s = SQLConn & ";Initial Catalog=personal;Persist Security Info=True; User ID=sa; Password=" & sPassword & ";"

        Dim connectionString As String = s

        Try
            ' Dim da As New SqlDataAdapter(strQuery, connection)
            If Not dtResulta Is Nothing Then
                dtResulta.Columns.Clear()
                dtResulta.Clear()
            End If
            sqlConexion.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Initial Catalog=personal; Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")

            'Revisar si existe la tabla mnt_temp
            sqlConexion.CommandText = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[mnt_temp]') AND type in (N'U')"
            sqlAdaptador.SelectCommand = sqlConexion
            sqlAdaptador.Fill(dtResulta)

            If dtResulta.Rows(0).Item(0) > 0 Then
                'Si existe la tabla, la borra. Esto para asegurarnos que tiene la estructura correcta
                dtTemporal = sqlExecute("DROP TABLE mnt_temp")
            End If

            campos_mantenimiento.Clear()

            Dim dtCamposMantenimiento As DataTable = sqlExecute("select * from campos_mantenimiento where cod_comp = '" & cia & "'")
            If dtCamposMantenimiento.Rows.Count Then
                For Each row As DataRow In dtCamposMantenimiento.Rows
                    Dim campo As New campo_mantenimiento
                    With campo
                        .nombre_campo = row("nombre_campo")
                        .longitud = row("longitud")
                    End With
                    campos_mantenimiento.Add(campo)
                Next
            End If

            'arCampos(0, 0) = "reloj"
            'arCampos(0, 1) = LongReloj
            'arCampos(1, 0) = "nombres"
            'arCampos(1, 1) = 49
            'arCampos(2, 0) = "cod_depto"
            'arCampos(2, 1) = 6
            'arCampos(3, 0) = "centro_costos"
            'arCampos(3, 1) = 8
            'arCampos(4, 0) = "cod_tipo"
            'arCampos(4, 1) = 1
            'arCampos(5, 0) = "imss"
            'arCampos(5, 1) = 11
            'arCampos(6, 0) = "cod_clase"
            'arCampos(6, 1) = 1
            'arCampos(7, 0) = "sactual"
            'arCampos(7, 1) = 8
            'arCampos(8, 0) = "cod_turno"
            'arCampos(8, 1) = 1
            'arCampos(9, 0) = "alta"
            'arCampos(9, 1) = 8
            'arCampos(10, 0) = "cod_super"
            'arCampos(10, 1) = 4
            'arCampos(11, 0) = "sexo"
            'arCampos(11, 1) = 1
            'arCampos(12, 0) = "rfc"
            'arCampos(12, 1) = 13
            'arCampos(13, 0) = "baja"
            'arCampos(13, 1) = 8
            'arCampos(14, 0) = "fha_sdo"
            'arCampos(14, 1) = 8
            'arCampos(15, 0) = "cod_hora"
            'arCampos(15, 1) = 3
            'arCampos(16, 0) = "mot_baja"
            'arCampos(16, 1) = 1
            'arCampos(17, 0) = "f1"
            'arCampos(17, 1) = 1
            'arCampos(18, 0) = "dias_vac"
            'arCampos(18, 1) = 4
            'arCampos(19, 0) = "f2"
            'arCampos(19, 1) = 1
            'arCampos(20, 0) = "dias_agui"
            'arCampos(20, 1) = 4
            'arCampos(21, 0) = "f3"
            'arCampos(21, 1) = 1
            'arCampos(22, 0) = "cod_pago"
            'arCampos(22, 1) = 1
            'arCampos(23, 0) = "f4"
            'arCampos(23, 1) = 1
            'arCampos(24, 0) = "cuenta_banco"
            'arCampos(24, 1) = 16
            'arCampos(25, 0) = "CURP"   
            'arCampos(25, 1) = 18
            'arCampos(26, 0) = "factor_int"
            'arCampos(26, 1) = 8
            'arCampos(27, 0) = "F5"
            'arCampos(27, 1) = 5
            'arCampos(28, 0) = "cod_planta"
            'arCampos(28, 1) = 3
            'arCampos(29, 0) = "tipo_tran"
            'arCampos(29, 1) = 1




            Cadena = "CREATE TABLE mnt_temp ("
            'For x = 0 To UBound(arCampos, 1)
            '    Cadena = Cadena & arCampos(x, 0) & " char(" & arCampos(x, 1) & ")" & IIf(x < UBound(arCampos, 1), ",", ")")
            'Next

            For Each campo As campo_mantenimiento In campos_mantenimiento
                Cadena = Cadena & campo.nombre_campo & " char(" & campo.longitud & ")" & IIf(campo.Equals(campos_mantenimiento(campos_mantenimiento.Count - 1)), ")", ",")
            Next

            'reloj char(5), nombres char(49), cod_depto char(6),centro_costos char(8), cod_tipo char(1), "
            '            Cadena = Cadena & "imss char(11),cod_clase char(1),sactual char(8),"
            '            Cadena = Cadena & "cod_turno char(1),alta char(8),cod_super char(4), sexo char(1),"
            '            Cadena = Cadena & "rfc char(13), baja char(8), fha_sdo char(8),cod_hora char(3),mot_baja char(1),"
            '            Cadena = Cadena & "f1 char(1),dias_vac char(4),f2 char(1),dias_agui char(4),f3 char(1),cod_pago char(1),f4 char(1),"
            '            Cadena = Cadena & "cuenta_banco char(16),CURP char(18),factor_int char(8),F5 char(5),cod_planta char(3),tipo_tran char(1))"

            sqlConexion.CommandText = Cadena
            sqlAdaptador.SelectCommand = sqlConexion
            sqlAdaptador.Fill(dtResulta)

            Return True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return False
        End Try

    End Function

    Public Function AuxiliaresAPersonal(ByRef dtResulta As DataTable) As Boolean
        Try
            'Agrega los auxiliares al datatable de personal
            Dim dtAuxiliares As New DataTable
            dtAuxiliares = sqlExecute("SELECT campo FROM auxiliares ORDER BY campo")
            'Agregar columnas para auxiliares
            For x = 0 To dtAuxiliares.Rows.Count - 1
                dtResulta.Columns.Add(dtAuxiliares.Rows(x).Item("campo").ToString.Trim)
            Next

            'Agregar auxiliares para cada registro
            For x = 0 To dtResulta.Rows.Count - 1
                dtAuxiliares = sqlExecute("SELECT campo,contenido FROM detalle_auxiliares WHERE reloj = '" & dtResulta.Rows(x).Item("reloj") & "'")
                For y = 0 To dtAuxiliares.Rows.Count - 1
                    Try
                        dtResulta.Rows(x).Item(dtAuxiliares.Rows(y).Item("campo").ToString.Trim) = dtAuxiliares.Rows(y).Item("contenido")
                    Catch ex As Exception
                        'IGNORAR EL ERROR
                    End Try
                Next
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return False
        End Try
    End Function
    Private Sub ThreadTask()
        frmTrabajando.Show()
    End Sub

    Public Function ConsultaPersonalVW(ByVal Consulta As String, Optional AgregarExtras As Boolean = True) As DataTable
        Dim QueryPersonalVW As String = ""
        Dim CamposPersonalVW As String = ""
        Dim dtCampos As New DataTable
        Dim dtTemp As New DataTable
        Dim dRow As DataRow
        Dim dRowData As DataRow
        Dim ArchivoFoto As String = ""
        Dim dtResulta As New DataTable

        Dim i As Integer
        Try
            QueryPersonalVW = Consulta.ToLower
            QueryPersonalVW = QueryPersonalVW.Replace("personal.dbo.", "cambio.dbo.")
            QueryPersonalVW = QueryPersonalVW.Replace("personal.", "personalvw.")
            QueryPersonalVW = QueryPersonalVW.Replace("cambio.dbo.", "personal.dbo.")
            QueryPersonalVW = QueryPersonalVW.Replace("from personal ", "from personalvw ")
            If QueryPersonalVW.Contains("*") Then
                dtCampos = sqlExecute("SELECT c.name as 'nombre' FROM syscolumns c INNER JOIN sysobjects o ON c.id = o.id AND o.xtype = 'v' where o.name = 'PersonalVW' ORDER BY c.colid")
                CamposPersonalVW = ""
                For i = 0 To dtCampos.Rows.Count - 1
                    CamposPersonalVW = CamposPersonalVW & IIf(CamposPersonalVW.Length > 0, ",", "") & "PersonalVW." & dtCampos.Rows.Item(i).Item("nombre")
                Next
            End If

            QueryPersonalVW = QueryPersonalVW.Replace("*", CamposPersonalVW)
            QueryPersonalVW = QueryPersonalVW.ToLower
            ' BERE
            'QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.sactual,", ",IIF(nivel_seguridad>" & NivelSueldos & ",0,PersonalVW.SACTUAL) AS SACTUAL,")
            QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.sactual,", ",CASE WHEN nivel_seguridad > " & NivelSueldos & " THEN 0 ELSE PersonalVW.SACTUAL END AS SACTUAL,")
            QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.integrado,", ",CASE WHEN nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE PersonalVW.INTEGRADO END AS INTEGRADO,")
            QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.pro_var,", ",CASE WHEN nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE PersonalVW.pro_var END AS pro_var,")
            QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.factor_int,", ",CASE WHEN nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE personalvw.factor_int END AS factor_int,")
            QueryPersonalVW = QueryPersonalVW.Replace(",personalvw.sal_ant,", ",CASE WHEN nivel_seguridad>" & NivelSueldos & " THEN 0 ELSE personalvw.sal_ant END AS sal_ant,")

            If QueryPersonalVW.Contains("where") Then
                QueryPersonalVW = QueryPersonalVW.Replace("where", "where nivel_seguridad <=" & NivelConsulta & " AND ")
            ElseIf QueryPersonalVW.Contains("order by") Then
                QueryPersonalVW = QueryPersonalVW.Replace("order by", "where nivel_seguridad <=" & NivelConsulta & " ORDER BY")
            Else
                QueryPersonalVW = QueryPersonalVW & " where nivel_seguridad <=" & NivelConsulta
            End If

            If FiltroXUsuario.Length > 0 Then
                QueryPersonalVW = QueryPersonalVW.Replace("where ", "where " & FiltroXUsuario & " AND ")
            End If

            'Utilizar WERE en lugar de WHERE para cualquier tabla que no sea personal
            QueryPersonalVW = QueryPersonalVW.Replace("were", "where")
            dtResulta = sqlExecute(QueryPersonalVW)

            'AGREGAR COLUMNAS  EXTRA
            Dim dtAuxiliares As New DataTable
            dtAuxiliares = sqlExecute("SELECT DISTINCT campo FROM auxiliares ORDER BY campo")

            'Agregar columnas para auxiliares
            For Each dRow In dtAuxiliares.Rows
                If dtResulta.Columns.IndexOf(dRow.Item("campo").ToString.Trim.ToLower) < 0 Then
                    'Si el campo no está ya incluido en la tabla, agregarlo
                    dtResulta.Columns.Add(dRow.Item("campo").ToString.Trim.ToLower)
                End If
            Next


            'Columna para fotografías

            If AgregarExtras Then
                'dtResulta.Columns.Add("foto")
                For Each dRowData In dtResulta.Rows
                    'Agregar auxiliares para cada registro
                    dtAuxiliares = sqlExecute("SELECT campo,contenido FROM detalle_auxiliares where reloj = '" & dRowData.Item("reloj") & "'")
                    For Each dRow In dtAuxiliares.Rows
                        Try
                            dRowData.Item(dRow.Item("campo").ToString.Trim) = dRow.Item("contenido")
                        Catch ex As Exception
                            'IGNORAR ERROR
                        End Try
                    Next
                Next
            Else
                'INCLUIR SOLAMENTE LOS AUXILIARES QUE SE DEBEN MOSTRAR EN PERSONAL
            End If
            Return dtResulta

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, QueryPersonalVW)
            Return New DataTable
        Finally
            'trd.Abort()
        End Try
    End Function

    '== Instancias diferentes               24marzo2022         Ernesto
    Public Function sqlExecuteInstancias(ByVal strQuery As String, Optional ByVal sMainDatabase As String = "Personal", Optional instancia As Integer = 0) As DataTable
        Static Intentos As Integer
        Dim dtResulta As New DataTable
        Dim conTemp As String = ""
        Dim DBTemp As String = sMainDatabase
        Dim UserTemp As String = ""
        Dim PassTemp As String = ""

        Try
            Select Case instancia
                Case 1
                    '== WME
                    conTemp = "Data Source=LEOSMS006\SQLEXPRESS"
                    DBTemp = sMainDatabase
                    UserTemp = "sa"
                    PassTemp = "BDPayroLL20$"

                    'conTemp = "Data Source=LAPTOP-2IANB3EO\SQL_WME"
                    'DBTemp = sMainDatabase
                    'UserTemp = "sa"
                    'PassTemp = "soporte"
                Case 2
                    '== WSM
                    conTemp = "Data Source=LEOSMS006\SQLWSA"
                    DBTemp = sMainDatabase
                    UserTemp = "sa"
                    PassTemp = "BDPayroLL20$"

                    'conTemp = "Data Source=LAPTOP-2IANB3EO\SQL_WSM"
                    'DBTemp = sMainDatabase
                    'UserTemp = "sa"
                    'PassTemp = "soporte"
            End Select

            If instancia <= 2 And instancia > 0 Then
                sqlConexion.Connection = New System.Data.SqlClient.SqlConnection(conTemp & ";Initial Catalog=" & DBTemp & _
                                                        ";Persist Security Info=True; User ID=" & UserTemp & "; Password=" & _
                                                        PassTemp & ";")

                sqlConexion.CommandText = strQuery
                sqlConexion.CommandTimeout = 360
                sqlAdaptador.SelectCommand = sqlConexion
                sqlAdaptador.Fill(dtResulta)
            End If

        Catch ex As SqlClient.SqlException
            If ex.HResult = -2146232060 And ex.Message.Contains("server was not found") Then
            ElseIf Intentos < 3 Then
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, strQuery)
            End If
            dtResulta.Columns.Add("ERROR")
            Intentos += 1
        Finally
            sqlClose()
        End Try
        Return dtResulta

    End Function

    '----Funcion original para conectarse a una sola instancia
    Public Function sqlExecute(ByVal strQuery As String, Optional ByVal sMainDatabase As String = "Personal") As DataTable
        Static Intentos As Integer
        Dim dtResulta As New DataTable


        Try
            sqlConexion.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Initial Catalog=" & sMainDatabase & _
                                                                        ";Persist Security Info=True; User ID=" & sUserAdmin & "; Password=" & _
                                                                        sPassword & ";")
            sqlConexion.CommandText = strQuery
            sqlConexion.CommandTimeout = 360
            sqlAdaptador.SelectCommand = sqlConexion
            sqlAdaptador.Fill(dtResulta)

            Intentos = 0
        Catch ex As SqlClient.SqlException
            If ex.HResult = -2146232060 And ex.Message.Contains("server was not found") Then
                'MessageBox.Show("No fue posible conectarse al servidor de datos. Si el error persiste, contacte al administrador del sistema." & _
                '                vbCrLf & vbCrLf & "Err.-" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf Intentos < 3 Then
                If Not tickLogin Then
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, strQuery)
                End If

                ' ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, strQuery)
            End If
            dtResulta.Columns.Add("ERROR")
            Intentos += 1
        Finally
            sqlClose()
        End Try
        Return dtResulta

    End Function

    '== Modificado 25nov2021            Ernesto - Funcion para conectarse a 2 instancias
    'Public Function sqlExecute(ByVal strQuery As String, Optional ByVal sMainDatabase As String = "Personal", Optional opEmpresa As Integer = 0) As DataTable
    '    Static Intentos As Integer = 0
    '    Dim dtResulta As New DataTable

    '    Try
    '        If opEmpresa = 0 Or opEmpresa = 2 Then
    '            sqlConexion.Connection = New System.Data.SqlClient.SqlConnection(SQLConn & ";Initial Catalog=" & sMainDatabase & _
    '                                                           ";Persist Security Info=True; User ID=" & sUserAdmin & "; Password=" & _
    '                                                           sPassword & ";")
    '            sqlConexion.CommandText = strQuery
    '            sqlConexion.CommandTimeout = 360
    '            sqlAdaptador.SelectCommand = sqlConexion
    '            sqlAdaptador.Fill(dtResulta)

    '            Intentos = 0
    '        End If
    '    Catch ex As SqlClient.SqlException
    '        If ex.HResult = -2146232060 And ex.Message.Contains("server was not found") Then
    '        ElseIf Intentos < 3 Then
    '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, strQuery)
    '        End If
    '        dtResulta.Columns.Add("ERROR")
    '        Intentos += 1
    '    Finally
    '        '== Finaliza la primera conexión
    '        If opEmpresa = 0 Or opEmpresa = 2 Then sqlClose()

    '        '== Bandera en caso de que se requieran datos de otra empresa               24nov2021       Ernesto
    '        If opEmpresa > 0 Then
    '            Dim dtResulta2 As New DataTable

    '            '== Conexión
    '            Dim ConTemp As String = "Data Source=LEOSMS006\SQLWSA"
    '            Dim DBTemp As String = sMainDatabase
    '            Dim UserTemp As String = "sa"
    '            Dim PassTemp As String = "BDPayroLL20$"

    '            sqlConexion.Connection = New System.Data.SqlClient.SqlConnection(ConTemp & ";Initial Catalog=" & DBTemp & _
    '                                                         ";Persist Security Info=True; User ID=" & UserTemp & "; Password=" & _
    '                                                         PassTemp & ";")

    '            sqlConexion.CommandText = strQuery
    '            sqlConexion.CommandTimeout = 360
    '            sqlAdaptador.SelectCommand = sqlConexion
    '            sqlAdaptador.Fill(dtResulta2)

    '            '== Si no hubo error en el primer query
    '            If Not dtResulta.Columns.Contains("ERROR") Then
    '                '== Si se selecciona solo para la empresa de WSM
    '                If opEmpresa = 1 Then
    '                    'dtResulta.Rows.Clear()
    '                    dtResulta = dtResulta2.Copy
    '                    '== Si es para ambas
    '                ElseIf opEmpresa = 2 Then
    '                    For Each x As DataRow In dtResulta2.Rows
    '                        dtResulta.ImportRow(x)
    '                    Next
    '                End If
    '            End If

    '            '== Finaliza la segunda conexión
    '            sqlClose()

    '        End If
    '    End Try
    '    Return dtResulta

    'End Function

    '== Filtro para la tabla dtInformacion en el reporteador según las plantas seleccionadas            25nov2021           Ernesto
    Public Function FiltroDtInfo(ByVal dtEmp1 As DataTable, ByVal dtEmp2 As DataTable, op As Integer) As DataTable
        Try
            Select Case op
                Case 0
                    Return dtEmp1
                Case 1
                    Return dtEmp2
                Case 2
                    Dim dtResult As DataTable = dtEmp1.Copy
                    For Each x In dtEmp2.Rows
                        dtResult.ImportRow(x)
                    Next
                    Return dtResult
            End Select

        Catch ex As Exception
            Return dtEmp1
        End Try
    End Function

    Public Sub sqlClose()
        sqlAdaptador.Dispose()
        sqlConexion.Dispose()
    End Sub

    Public Function FechaSQL(ByVal Fecha As Date) As String
        Try
            Return Fecha.Year.ToString.PadLeft(4, "0") & "-" & Fecha.Month.ToString.PadLeft(2, "0") & "-" & Fecha.Day.ToString.PadLeft(2, "0")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function FechaLetra(ByVal Fecha As Date) As String
        Dim FechaL As String = ""
        FechaL = Fecha.Day & "-" & MesLetra(Fecha) & "-" & Fecha.Year
        Return FechaL
    End Function

    Public Function FechaCortaLetra(ByVal Fecha As Date) As String
        Dim FechaL As String = ""
        FechaL = Fecha.Day & "-" & MesLetra(Fecha).Substring(0, 3) & "-" & Fecha.Year
        Return FechaL
    End Function

    Public Function FechaMediaLetra(ByVal Fecha As Date) As String
        Dim FechaL As String = ""
        FechaL = Fecha.Day & " de " & MesLetra(Fecha) & " de " & Fecha.Year
        Return FechaL
    End Function

    Public Function MesLetra(ByVal Fecha As Date, Optional len As Integer = 0) As String
        Dim M As String
        Dim NumMes As Integer
        NumMes = Fecha.Month
        M = MesLetra(NumMes)

        If len > 0 Then
            M = M.Substring(0, len)
        End If

        Return M
    End Function

    Public Function MesLetra(ByVal NumMes As String) As String
        Dim M As String = ""
        Select Case NumMes
            Case 1, "01"
                M = "Enero"
            Case 2, "02"
                M = "Febrero"
            Case 3, "03"
                M = "Marzo"
            Case 4, "04"
                M = "Abril"
            Case 5, "05"
                M = "Mayo"
            Case 6, "06"
                M = "Junio"
            Case 7, "07"
                M = "Julio"
            Case 8, "08"
                M = "Agosto"
            Case 9, "09"
                M = "Septiembre"
            Case 10
                M = "Octubre"
            Case 11
                M = "Noviembre"
            Case 12
                M = "Diciembre"
            Case Else
                M = ""
        End Select
        Return M
    End Function


    Public Function MesNumero(ByVal Mes As String) As String
        Try
            Dim dtMeses As New DataTable
            Dim N As String
            dtMeses = sqlExecute("SELECT num_mes FROM meses WHERE mes_may = '" & Mes.Trim.ToUpper & "'")
            N = dtMeses.Rows(0).Item("num_mes").ToString.Trim.PadLeft(2, "0")
            Return N
        Catch ex As Exception
            Return -1
        End Try
    End Function

    '----------------------------Agregado por Antonio----------------------------
    Public Function AnioLetra(ByVal NumAnio As String) As String
        Dim M As String = ""
        Select Case NumAnio
            Case 1, "20"
                M = "Mil Veinte"
            Case 2, "21"
                M = "Mil Veintiuno"
            Case 3, "22"
                M = "Mil Veintidos"
            Case 4, "23"
                M = "Mil Veintitres"
            Case 5, "24"
                M = "Mil Veinticuatro"
            Case 6, "25"
                M = "Mil Veinticinco"
            Case 7, "26"
                M = "Mil Veintiseis"
            Case 8, "27"
                M = "Mil Veintisiete"
            Case 9, "28"
                M = "Mil Veintiocho"
            Case 29
                M = "Mil Veintinueve"
            Case 30
                M = "Mil Treinta"
            Case 31
                M = "Mil Treinta y uno"
            Case Else
                M = ""
        End Select
        Return M
    End Function
    '---------------------------Fin de lo de Antonio-------------------------------

    Public Function FechaHoraSQL(ByVal Fecha As DateTime, Optional IncluirSEG As Boolean = True, Optional IncluirMILISEG As Boolean = True) As String
        Dim Hr As String
        'Hr = Fecha.TimeOfDay
        Hr = Fecha.Hour.ToString.PadLeft(2, "0") & ":" & Fecha.Minute.ToString.PadLeft(2, "0")
        If IncluirSEG Then
            Hr = Hr & ":" & Fecha.Second.ToString.PadLeft(2, "0")
        End If
        If IncluirMILISEG Then
            Hr = Hr & "." & Fecha.Millisecond.ToString.PadRight(3, "0")
        End If
        FechaHoraSQL = Fecha.Year.ToString & "-" & Fecha.Month.ToString.PadLeft(2, "0") & "-" & Fecha.Day.ToString.PadLeft(2, "0") & " " & Hr
    End Function


    Public Function Buscar(ByVal Tabla As String, ByVal Campo As String, ByVal TextoAMostrar As String, Optional ByRef FiltrarCompania As Boolean = True, Optional nombre As String = "nombre", Optional ByRef FiltrarInactivos As Boolean = False) As String
        Dim strFilterInactivos As String = ""
        If FiltrarInactivos Then
            'If Tabla.Equals("deptos") Then
            '    strFilterInactivos = " and inactivo = '0' "
            'End If
            If Tabla.Equals("puestos") Then
                strFilterInactivos = " and activo = '1' "
            End If
        End If
        Dim dtTemp As New DataTable
        'sqlExecute("SHOW COLUMNS FROM " & Tabla & " WHERE field='cod_comp'", dtTemp)
        dtTemp = sqlExecute("SELECT C.COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS As C WHERE C.TABLE_NAME = '" & Tabla & "' AND C.COLUMN_NAME='cod_comp'")
        ContieneCampoCia = dtTemp.Rows.Count > 0

        If FiltrarCompania Then
            CadenaBuscar = "SELECT cod_comp AS 'Compañía', " & Campo & " AS codigo, " & nombre & " FROM " & Tabla & " WHERE cod_comp = '" & Compania & "' AND (" & Campo & " LIKE '%strBuscar%' OR " & nombre & " LIKE '%strBuscar%')" & strFilterInactivos
        Else
            If Not ContieneCampoCia Then
                CadenaBuscar = "SELECT 'NA' AS 'Compañía'," & Campo & " AS codigo, " & nombre & " FROM " & Tabla & " WHERE " & Campo & " LIKE '%strBuscar%' OR " & nombre & " LIKE '%strBuscar%'" & strFilterInactivos
            Else
                CadenaBuscar = "SELECT cod_comp AS 'Compañía'," & Campo & " AS codigo, " & nombre & " FROM " & Tabla & " WHERE " & Campo & " LIKE '%strBuscar%' OR " & nombre & " LIKE '%strBuscar%'" & strFilterInactivos
            End If

        End If
        If Not ContieneCampoCia Then
            frmBuscaGeneral.dgDatos.Columns(0).Visible = False
        End If
        frmBuscaGeneral.lblEstado.Text = TextoAMostrar.ToUpper

        frmBuscaGeneral.ShowDialog(frmMain.ActiveMdiChild)
        frmBuscaGeneral.Dispose()
        If Codigo = "" Then Codigo = "CANCELAR"
        Buscar = Codigo
    End Function

    Function getMD5Hash(ByVal strToHash As String) As String
        ' Procedimiento para encriptar la clave de acceso
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Public Sub Siguiente(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & " >'" & valor & "' ORDER BY " & campo & " ASC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " ORDER BY " & campo & " DESC", BaseDatos)
        End If

    End Sub

    Public Sub Anterior(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & "<'" & valor & "' ORDER BY " & campo & " DESC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " ORDER BY " & campo & " ASC", BaseDatos)
        End If
    End Sub

    Public Sub Primero(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " ORDER BY " & campo & " ASC ", BaseDatos)
    End Sub

    Public Sub Ultimo(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " ORDER BY " & campo & " DESC", BaseDatos)
    End Sub

    Public Function Edad(FechaNac As Date, FechaReferencia As Date) As Byte
        Dim E As Byte
        Try
            E = DateDiff(DateInterval.Year, FechaNac, FechaReferencia)
        Catch ex As Exception
            E = 0
        End Try
        Return E
    End Function

    Public Sub SubirElemento(ByVal Box As ListBox)
        On Error GoTo ErrS

        Dim Index As Integer = Box.SelectedIndex    'Index of selected item
        Dim Swap As Object = Box.SelectedItem       'Selected Item
        If Not (Swap Is Nothing) And Index > 0 Then
            Box.Items.RemoveAt(Index)                   'Remove it
            Box.Items.Insert(Index - 1, Swap)           'Add it back in one spot up
            Box.SelectedItem = Swap                     'Keep this item selected
        End If

        Exit Sub
ErrS:
        'MessageBox.Show(Err.Description)
    End Sub
    Public Sub BajarElemento(ByVal Box As ListBox)
        On Error GoTo ErrS
        Dim Index As Integer = Box.SelectedIndex    'Index of selected item
        Dim Swap As Object = Box.SelectedItem       'Selected Item
        If (Index <> -1) AndAlso (Index + 1 < Box.Items.Count) Then
            Box.Items.RemoveAt(Index)                   'Remove it
            Box.Items.Insert(Index + 1, Swap)           'Add it back in one spot up
            Box.SelectedItem = Swap                     'Keep this item selected
        End If

        Exit Sub
ErrS:
        'MessageBox.Show(Err.Description)
    End Sub


    Public Function RevisarAccesos(rp As DevComponents.DotNetBar.RibbonPanel) As Boolean
        Dim dtTemp As New DataTable
        Dim Acceso As Boolean
        Dim i As Integer
        Dim si As Integer
        Dim w As Double
        Dim iW As Double
        Dim t As Integer = 0
        Try
            'Revisar cada control dentro del panel
            For Each c In rp.Controls
                i = 0
                If TypeOf c Is DevComponents.DotNetBar.RibbonBar Then
                    ' Si es un ribbonbar, revisar cada elemento (botón)
                    For Each r In c.items
                        si = r.subitems.count
                        If si > 0 Then
                            'Si tiene subitems, revisar los accesos a cada uno
                            si = 0
                            For Each s In r.subitems


                                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'F' AND control = '" & s.name & "' AND cod_perfil " & Perfil, "Seguridad")
                                Acceso = False
                                If dtTemp.Rows.Count > 0 Then
                                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                                ElseIf Perfil.Contains("ADMIN") Then
                                    Acceso = True
                                End If
                                s.visible = Acceso
                                If Acceso Then si = si + 1
                            Next
                            r.visible = si > 0
                            Acceso = si > 0
                        End If

                        If si = 0 Then
                            'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                            dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'F' AND control = '" & r.name & "' AND cod_perfil " & Perfil, "Seguridad")
                            Acceso = False
                            If dtTemp.Rows.Count > 0 Then
                                Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                            ElseIf Perfil.Contains("ADMIN") Then
                                Acceso = True
                            End If
                            r.visible = Acceso
                        End If

                        If Acceso Then
                            'Si se tiene acceso al botón, incrementar la variable
                            iW = r.fixedsize.width
                            i = i + 1
                            t = t + 1
                        End If
                    Next
                    'Si no se tiene acceso por lo menos a un botón, poner invisible la barra
                    c.Visible = i > 0

                    ' Ajustar el ancho del panel, de acuerdo al número de controles desplegados X el ancho del control + 3
                    '(agregar un espacio entre controles)
                    If c.Visible Then
                        w = i * (iW + 3) + 3
                        c.Width = w
                    End If
                End If
            Next
            'Devolver si tiene acceso por lo menos a un elemento del panel
            Return t > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function TipoNaturaleza(TipoAus As String) As String
        Try
            dtTemporal = sqlExecute("SELECT tipo_naturaleza FROM tipo_ausentismo WHERE tipo_aus = '" & TipoAus & "'", "TA")
            If dtTemporal.Rows.Count = 0 Then
                Return "ERROR"
            Else
                Return dtTemporal.Rows(0).Item("tipo_naturaleza")
            End If
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Public Function GetColorLetra(TipoAus As String) As Integer
        Dim Color As Integer
        Dim dtColor As New DataTable
        Try
            dtColor = sqlExecute("SELECT color_letra FROM tipo_ausentismo WHERE tipo_aus = '" & TipoAus & "'", "TA")
            If dtColor.Rows.Count > 0 Then
                Color = IIf(IsDBNull(dtColor.Rows(0).Item("color_letra")), LetraDefault, dtColor.Rows(0).Item("color_letra"))
            Else
                Color = LetraDefault
            End If
            Return Color

        Catch ex As Exception
            Return LetraDefault
        End Try
    End Function
    Public Function GetColorFondo(TipoAus As String) As Integer
        Dim Color As Integer
        Dim dtColor As New DataTable
        Try
            dtColor = sqlExecute("SELECT color_back FROM tipo_ausentismo WHERE tipo_aus = '" & TipoAus & "'", "TA")
            If dtColor.Rows.Count > 0 Then
                Color = IIf(IsDBNull(dtColor.Rows(0).Item("color_back")), FondoDefault, dtColor.Rows(0).Item("color_back"))
            Else
                Color = FondoDefault
            End If
            Return Color

        Catch ex As Exception
            Return FondoDefault
        End Try
    End Function



    Public Function DiaDescanso(Fecha As Date, Optional Reloj As String = "") As Boolean
        Dim dtDescanso As New DataTable
        Dim dtLunes As New DataTable
        Dim V As Boolean = False
        Dim Semana As DetalleSemana
        Try
            If Reloj = "" Then
                V = (Fecha.DayOfWeek = DayOfWeek.Sunday Or Fecha.DayOfWeek = DayOfWeek.Saturday)
            Else
                'MCR 9/NOV/2015
                'Quitar consulta de si inicia en lunes; se puso en login para evitar hacerlo cada vez

                Dim ano_periodo As String = ObtenerAnoPeriodo(Fecha)

                Semana = SemanaHorarioMixto(ano_periodo, Reloj)

                'Dim dtPersonal As DataTable = sqlExecute("select * from personal where reloj = '" & Reloj & "'")
                'Dim cod_hora As String = dtPersonal.Rows(0)("cod_hora")

                'Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_personal left join ta.dbo.periodos on bitacora_personal.fecha between periodos.FECHA_INI and periodos.FECHA_FIN where reloj = '" & Reloj & "' and campo = 'cod_hora' and ISNULL(periodos.periodo_especial, 0) = 0 and periodos.ANO+periodo > '" & ano_periodo & "' order by fecha asc")
                'If dtBitacora.Rows.Count > 0 Then
                '    Dim anterior As String = dtBitacora.Rows(0)("valoranterior")
                '    cod_hora = anterior
                'End If

                '---aos 2022-02-10 Para tomar el cod_hora correcto
                Dim cod_hora As String = ""
                Dim dtPersonal As DataTable = sqlExecute("select * from personal where reloj = '" & Reloj & "'", "PERSONAL")
                Dim dtPeriodos As DataTable = sqlExecute("SELECT * from periodos where '" & FechaSQL(Fecha) & "' between FECHA_INI and FECHA_FIN and isnull(PERIODO_ESPECIAL,0)=0", "TA") 'AOS 2022-12-14: Que solo tome en cuenta periodos normales
                Dim FechaFinPeriodo As Date
                If (Not dtPeriodos.Columns.Contains("Error") And dtPeriodos.Rows.Count > 0) Then
                    Try : FechaFinPeriodo = Date.Parse(dtPeriodos.Rows(0).Item("fecha_fin")) : Catch ex As Exception : FechaFinPeriodo = Nothing : End Try
                End If

                For Each drEmpleado As DataRow In dtPersonal.Select("reloj='" & Reloj & "'")
                    cod_hora = ConsultaBitacoraHorarios(dtPersonal, drEmpleado, FechaFinPeriodo, "cod_hora")
                Next

                If (cod_hora = "") Then ' Tomar el horario que traiga en personal
                    Try : cod_hora = dtPersonal.Rows(0).Item("cod_hora").ToString.Trim : Catch ex As Exception : cod_hora = "" : End Try
                End If


                dtDescanso = sqlExecute("SELECT DESCANSO FROM dias where dias.cod_hora = '" & cod_hora & "' AND semana = '" & Semana.NumSemana & _
                                        "' and cod_dia = '" & IIf(IniciaLunes And Fecha.DayOfWeek = 0, 7, Fecha.DayOfWeek) & "'")

                If dtDescanso.Rows.Count = 0 Then
                    V = False
                Else
                    V = IIf(IsDBNull(dtDescanso.Rows(0).Item("descanso")), False, dtDescanso.Rows(0).Item("descanso"))
                End If
            End If

            Dim dtExcepcionesDescanso As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & Reloj & "' and fecha_original = '" & FechaSQL(Fecha) & "'")
            If dtExcepcionesDescanso.Rows.Count > 0 Then
                V = True
            End If
            Dim dtExcepcionesNoDescanso As DataTable = sqlExecute("select * from tiempo_x_tiempo where reloj = '" & Reloj & "' and fecha_intercambio = '" & FechaSQL(Fecha) & "'")
            If dtExcepcionesNoDescanso.Rows.Count > 0 Then
                V = False
            End If


            Return V
        Catch ex As Exception

            Return False
        End Try

    End Function

    Public Function ConvNvo(ByVal Cantidad As Decimal) As String

        Dim i As Double
        Dim h As String
        Dim Decimales As String
        Dim dtDenomina As New DataTable

        i = Int(Cantidad)
        h = i
        Decimales = Math.Round((Cantidad - i) * 100, 2).ToString.PadLeft(2, "0")

        Dim impLetra As String = ""

        Dim c As Integer = 0

        Do While i > 0
            c = c + 1
            i = Math.Round(i / 1000, 3)
            h = i.ToString("N3")
            dtDenomina = sqlExecute("SELECT denomina FROM denomina WHERE RTRIM(clave) ='" & Val(Right(h, 3)) & "'", "Kiosco")
            If dtDenomina.Rows.Count > 0 Then
                i = Int(i)
                Select Case c
                    Case 1
                        impLetra = dtDenomina.Rows(0).Item("denomina").ToString.Trim & impLetra
                    Case 2
                        impLetra = dtDenomina.Rows(0).Item("denomina").ToString.Trim & " MIL " & impLetra
                    Case 3
                        If i = 1 Then
                            impLetra = dtDenomina.Rows(0).Item("denomina").ToString.Trim & " MILLÓN " & impLetra
                        Else
                            impLetra = dtDenomina.Rows(0).Item("denomina").ToString.Trim & " MILLONES " & impLetra
                        End If
                End Select

            End If

        Loop
        If Int(Cantidad) = 0 Then
            impLetra = "CERO PESOS " & Decimales & "/100"
        ElseIf Int(Cantidad) = 1 Then
            impLetra = impLetra & " PESO " & Decimales & "/100"
        Else
            impLetra = impLetra & " PESOS " & Decimales & "/100"
        End If


        Return impLetra
    End Function

    ''' <summary>
    ''' Exporta a excel un Datatable (más lento que 
    ''' recordset, pues pasa los registros uno a uno)
    ''' </summary>

    Public Sub ExportaExcel(dt As DataTable, NombreArchivo As String, Optional indice As String = "reloj", Optional titulo As String = "", Optional frhcn As Boolean = False)
        Dim ExcelAPP As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        Dim frmT As New frmTrabajando

        Try

            If System.IO.File.Exists(NombreArchivo) Then
                System.IO.File.Delete(NombreArchivo)
            End If

            Try
                frmT.Show(frmMain.ActiveForm)
            Catch ex As Exception
                frmT.Show()
            End Try

            frmT.Avance.Value = 0
            frmT.Avance.IsRunning = True
            frmT.lblAvance.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            frmT.lblAvance.Text = "Exportar a excel"
            Application.DoEvents()

            wBook = ExcelAPP.Workbooks.Add
            wSheet = wBook.ActiveSheet()

            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 1
            Dim rowIndex As Integer = 1
            Dim colReloj As Boolean = False
            Dim t As Integer

            Dim _range As Excel.Range

            If titulo <> "" Then
                rowIndex += 2
            End If



            For Each dc In dt.Columns
                frmT.lblAvance.Text = dc.ColumnName
                If dc.ColumnName.ToLower = indice Then colReloj = True

                Application.DoEvents()

                If frhcn Then ' First Row Has Column Names                    
                    ExcelAPP.Cells(rowIndex, colIndex) = "placeholder"
                Else
                    ExcelAPP.Cells(rowIndex, colIndex) = dc.ColumnName
                End If


                _range = wSheet.Range(wSheet.Cells(rowIndex, colIndex), wSheet.Cells(rowIndex, colIndex))
                _range.Interior.Color = Color.FromArgb(28, 58, 112)
                _range.Font.Color = Color.White
                _range.Font.Bold = True

                colIndex += 1

            Next

            If frhcn Then ' First Row Has Column Names
                rowIndex -= 1
            End If


            t = dt.Rows.Count
            For Each dr In dt.Rows
                frmT.lblAvance.Text = IIf(colReloj, dr(indice), Math.Round(rowIndex * 100 / t, 0) & "%")
                Application.DoEvents()

                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    ExcelAPP.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next

                rowIndex = rowIndex + 1
            Next

            frmT.lblAvance.Text = "Guardar"
            Application.DoEvents()

            wSheet.Columns.AutoFit()

            If titulo <> "" Then
                ExcelAPP.Cells(1, 1) = titulo
                _range = wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(1, 1))
                _range.Interior.Color = Color.White
                _range.Font.Color = Color.Black
                _range.Font.Bold = True
                _range.Font.Size = 12
            End If


            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(NombreArchivo) Then
                System.IO.File.Delete(NombreArchivo)
            End If

            wBook.SaveAs(NombreArchivo)
            wBook.Close()

            ExcelAPP.Workbooks.Open(NombreArchivo)
            ExcelAPP.Visible = False

            releaseObject(wSheet)
            releaseObject(wBook)
            releaseObject(ExcelAPP)

            ActivoTrabajando = False
            frmT.Hide()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)

            ActivoTrabajando = False

            frmT.Hide()
        Finally
            ActivoTrabajando = False

            frmT.Hide()
        End Try
    End Sub

    ''' <summary>
    ''' 'Función para abrir un archivo de excel, y pasar una lista de relojes a un arreglo
    ''' tomando la primer columna, de la primer hoja
    ''' </summary>
    ''' <param name="Archivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExcelTOArrayList(ByVal Archivo As String) As String(,)

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim arRango(,) As String
        Dim x As Integer
        Dim y As Integer
        Try
            xlApp.Workbooks.Open(Archivo)
            xlWorkBook = xlApp.ActiveWorkbook

            Dim lastrow As Excel.Range = xlApp.Rows.End(Excel.XlDirection.xlDown)
            Dim myRange As Excel.Range
            myRange = xlApp.Range("A1:B" & lastrow.Row)

            Dim myArray As Object(,)
            myArray = myRange.Value

            'El arreglo myRange es a partir de 1, 
            'el arreglo myArray, inicia en 0
            If myArray(1, 1).ToString.ToLower = "reloj" Then
                'Si tiene encabezado, reducir 1 por la diferencia, más el del encabezado
                y = 2
            Else
                'Si no hay encabezado, solo reducir 1
                y = 1
            End If

            ReDim arRango(2, lastrow.Row - y)
            For x = y To lastrow.Row
                arRango(1, x - y) = myArray(x, 1)
                arRango(2, x - y) = myArray(x, 2)
            Next

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            Return arRango
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            'GC.Collect()
        End Try
    End Sub


    ''' <summary>
    ''' Función que regresa un Recordset a partir de una consulta SQL
    ''' </summary>
    Public Function sqlExecute(ByVal strQuery As String, DesdeRecordset As Boolean, Optional ByRef sMainDatabase As String = "Personal") As ADODB.Recordset
        Dim S As String
        Dim cn As New ADODB.Connection
        Dim dtResulta As New ADODB.Recordset
        Try
            S = "provider=sqloledb;" & SQLConn & ";database=" & sMainDatabase & ";uid=" & sUserAdmin & ";password=" & sPassword
            If cn.State = 0 Then cn.Open(S)
            dtResulta.Open(strQuery, cn, ADODB.CursorTypeEnum.adOpenStatic)
            Return dtResulta
        Catch ex As Exception
            Return Nothing
        Finally
            'cn.Close()
        End Try
    End Function

    ''' <summary>
    ''' Exporta Recordset a excel SIN formato
    ''' </summary>
    Public Sub ExportaExcel(rs As ADODB.Recordset, NombreArchivo As String, Optional AbrirArchivo As Boolean = True)
        Try

            Dim ExcelAPP As New Excel.Application
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet

            wBook = ExcelAPP.Workbooks.Add
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "PIDA"
            Dim i As Integer = 0

            For i = 1 To rs.Fields.Count
                wSheet.Cells(1, i).Value = rs.Fields(i - 1).Name
            Next

            wSheet.Range("a2").CopyFromRecordset(rs)
            rs.Close()

            wSheet.Rows.WrapText = False
            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(NombreArchivo)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(NombreArchivo) Then
                System.IO.File.Delete(NombreArchivo)
            End If

            wBook.SaveAs(NombreArchivo)

            If AbrirArchivo Then
                ExcelAPP.Workbooks.Open(NombreArchivo)
                ExcelAPP.Visible = True
            Else
                wBook.Close()
                ExcelAPP.Workbooks.Close()
                ExcelAPP.Quit()

                releaseObject(wBook)
                releaseObject(wSheet)
                releaseObject(ExcelAPP)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)

        End Try
    End Sub

    'Public Function ObtenerPeriodo(Fecha As Date) As String
    '    Dim dtPer As New DataTable
    '    Try
    '        dtPer = sqlExecute("SELECT periodo FROM periodos WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
    '        ObtenerPeriodo = dtPer.Rows(0).Item("periodo")
    '    Catch ex As Exception
    '        ObtenerPeriodo = ""
    '    End Try
    'End Function

    Public Function ObtenerPeriodo(Fecha As Date, Optional TipoPeriodo As String = "S") As String
        Dim dtPer As New DataTable
        Try
            Select Case TipoPeriodo
                Case "S"
                    dtPer = sqlExecute("SELECT periodo FROM periodos WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
                Case "C"
                    '  dtPer = sqlExecute("SELECT periodo FROM periodos_catorcenal WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
                    dtPer = sqlExecute("SELECT periodo FROM periodos WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
                Case "Q"
                    dtPer = sqlExecute("SELECT periodo FROM periodos_quincenal WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
                Case "M"
                    dtPer = sqlExecute("SELECT periodo FROM periodos_mensual WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
            End Select
            ObtenerPeriodo = dtPer.Rows(0).Item("periodo")
        Catch ex As Exception
            ObtenerPeriodo = ""
        End Try
    End Function


    Public Function DataTableTORecordset(ByRef table As DataTable) As ADODB.Recordset '
        Try
            Dim result As New ADODB.Recordset
            result.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Dim resultFields As ADODB.Fields = result.Fields
            Dim col As DataColumn
            For Each col In table.Columns
                resultFields.Append(col.ColumnName, TranslateType(col.DataType), col.MaxLength, col.AllowDBNull = ADODB.FieldAttributeEnum.adFldIsNullable)
            Next
            'result.Open(table, System.Reflection.Missing.Value, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0)
            result.Open()
            For Each row As DataRow In table.Rows
                result.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)
                For i As Integer = 0 To table.Columns.Count - 1
                    If Not IsDBNull(row(i)) Then
                        resultFields(i).Value = row(i)
                    End If
                Next
            Next
            Return result
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TranslateType(ByRef type As Type) As ADODB.DataTypeEnum
        Try
            Select Case type.UnderlyingSystemType.ToString
                Case "System.Boolean"
                    Return ADODB.DataTypeEnum.adBoolean
                Case "System.Byte"
                    Return ADODB.DataTypeEnum.adUnsignedTinyInt
                Case "System.Char"
                    Return ADODB.DataTypeEnum.adChar
                Case "System.DateTime"
                    Return ADODB.DataTypeEnum.adDate
                Case "System.Decimal"
                    Return ADODB.DataTypeEnum.adCurrency
                Case "System.Double"
                    Return ADODB.DataTypeEnum.adDouble
                Case "System.Int16"
                    Return ADODB.DataTypeEnum.adSmallInt
                Case "System.Int32"
                    Return ADODB.DataTypeEnum.adInteger
                Case "System.Int64"
                    Return ADODB.DataTypeEnum.adBigInt
                Case "System.SByte"
                    Return ADODB.DataTypeEnum.adTinyInt
                Case "System.Single"
                    Return ADODB.DataTypeEnum.adSingle
                Case "System.UInt16"
                    Return ADODB.DataTypeEnum.adUnsignedSmallInt
                Case "System.UInt32"
                    Return ADODB.DataTypeEnum.adUnsignedInt
                Case "System.UInt64"
                    Return ADODB.DataTypeEnum.adUnsignedBigInt
                Case "System.String" 'case default
                    Return ADODB.DataTypeEnum.adVarWChar
                Case Else
                    Return ADODB.DataTypeEnum.adVariant
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ADODB.DataTypeEnum.adVariant
        End Try
    End Function

    Public Function UnMapDrive(ByVal DriveLetter As String) As Boolean
        Dim rc As Integer
        rc = WNetCancelConnection2(DriveLetter & ":", 0, ForceDisconnect)

        If rc = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Redondeo truncado hacia arriba.
    ''' P.Ej. 3.33333 -> 3.34
    ''' P.Ej. 1.00111 -> 1.01
    ''' </summary>
    Public Function RoundUp(ByVal Num As Double, ByVal Dec As Integer) As Double
        Try
            Dim N As Double
            Dim I As Integer
            Dim C As Integer = 1
            For I = 1 To Dec
                C = C * 10
            Next
            N = Math.Ceiling(Num * C) / C
            Return N
        Catch ex As Exception
            Return -1
        End Try
    End Function


    'Public Function ObtenerAnoPeriodo(Fecha As Date) As String
    '    Dim dtPer As New DataTable
    '    Try
    '        dtPer = sqlExecute("SELECT ano,periodo FROM periodos WHERE '" & FechaSQL(Fecha) & "' BETWEEN fecha_ini AND fecha_fin", "TA")
    '        Return dtPer.Rows(0).Item("ano") & dtPer.Rows(0).Item("periodo")
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function

    '**** REEMPLAZAR FUNCION

    Public Function obteneranoperiodocorte(fecha As Date, Optional TipoPeriodo As String = "S", Optional especial As Boolean = False) As String
        Dim dtPer As New DataTable
        Try
            Select Case TipoPeriodo
                Case "S"
                    dtPer = sqlExecute("SELECT top(1) ano+periodo as anoper FROM periodos WHERE '" & FechaSQL(fecha) & "' < fecha_corte" & IIf(especial, " order by ano+periodo asc", " and periodo_especial = '0' order by ano+periodo asc"), "TA")
                Case "Q"
                    dtPer = sqlExecute("SELECT top(1) ano+periodo as anoper FROM periodos_quincenal WHERE '" & FechaSQL(fecha) & "' < fecha_corte" & IIf(especial, " order by ano+periodo asc", " and periodo_especial = '0' order by ano+periodo asc"), "TA")
                Case "M"
                    dtPer = sqlExecute("SELECT ano+periodo as anoper FROM periodos_mensual WHERE '" & FechaSQL(fecha) & "' BETWEEN fecha_ini AND fecha_fin" & IIf(especial, "", " and periodo_especial = '0'"), "TA")
            End Select
            obteneranoperiodocorte = dtPer.Rows(0).Item("anoper")
        Catch ex As Exception
            obteneranoperiodocorte = ""
        End Try
    End Function
    Public Function ObtenerAnoPeriodo(fecha As Date, Optional TipoPeriodo As String = "S", Optional especial As Boolean = False) As String
        Dim dtPer As New DataTable
        Try
            Select Case TipoPeriodo
                Case "S"
                    dtPer = sqlExecute("SELECT ano+periodo as anoper FROM periodos WHERE '" & FechaSQL(fecha) & "' BETWEEN fecha_ini AND fecha_fin" & IIf(especial, "", " and periodo_especial = '0'"), "TA")
                Case "Q"
                    dtPer = sqlExecute("SELECT ano+periodo as anoper FROM periodos_quincenal WHERE '" & FechaSQL(fecha) & "' BETWEEN fecha_ini AND fecha_fin" & IIf(especial, "", " and periodo_especial = '0'"), "TA")
                Case "M"
                    dtPer = sqlExecute("SELECT ano+periodo as anoper FROM periodos_mensual WHERE '" & FechaSQL(fecha) & "' BETWEEN fecha_ini AND fecha_fin" & IIf(especial, "", " and periodo_especial = '0'"), "TA")
            End Select
            ObtenerAnoPeriodo = dtPer.Rows(0).Item("anoper")
        Catch ex As Exception
            ObtenerAnoPeriodo = ""
        End Try
    End Function

    Public Function DiferenciaPeriodos(ByVal Periodo1 As String, ByVal Periodo2 As String) As Integer
        Dim dtPer As New DataTable
        Dim SumPer As Integer = 0
        Dim DifPer As Integer
        Dim PeriodoIni As String
        Dim PeriodoFin As String

        Dim Ano1 As Integer
        Dim Per1 As Integer
        Dim Ano2 As Integer
        Dim Per2 As Integer
        Try
            'Si la longitud entre periodos es diferente entre ellos, o que no sea ni 2 ni 6, no se puede comparar
            If Periodo1.Length <> Periodo2.Length Then Return -1
            If Periodo1.Length <> 6 And Periodo1.Length <> 2 Then Return -1

            'El periodo mayor es el final, independientemente del orden en que se capturaron
            If Periodo1 > Periodo2 Then
                PeriodoIni = Periodo2
                PeriodoFin = Periodo1
            Else
                PeriodoIni = Periodo1
                PeriodoFin = Periodo2
            End If

            If PeriodoIni.Length = 2 Then
                'Si la longitud = 2, solo es el periodo, no el año
                Return Val(PeriodoFin) - Val(PeriodoIni)
            ElseIf PeriodoIni.Length = 6 Then
                'Si la longitud es 6, quiere decir que es ANO+PERIODO
                'Obtener el valor numérico para año y periodo de ambos
                Ano1 = Val(PeriodoIni.Substring(0, 4))
                Ano2 = Val(PeriodoFin.Substring(0, 4))
                Per1 = Val(PeriodoIni.Substring(4, 2))
                Per2 = Val(PeriodoFin.Substring(4, 2))

                'Determinar el número de semanas de cada año en el rango, y acumularlos
                For DifPer = 0 To (Ano2 - Ano1) - 1
                    dtPer = sqlExecute("SELECT MAX(periodo) as semanas FROM periodos WHERE ano = '" & (Ano1 + DifPer) & "' AND periodo<=55", "ta")
                    If dtPer.Rows.Count > 0 Then
                        SumPer = SumPer + dtPer.Rows(0).Item("semanas")
                    End If
                Next
                'El número de semanas de cada año transcurrido, más las semanas del rango final, menos las del rango inicial
                'Es el total de semanas transcurridas entre ambos periodos
                SumPer = SumPer + Per2 - Per1
            End If
            Return SumPer
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function VacacionesDevengadas(ByVal Reloj As String, ByVal Fecha As Date) As Double
        Try
            Dim _dDias As Double
            Dim dtEmp As New DataTable

            dtEmp = sqlExecute("SELECT alta,ALTA_VACACION,baja,cod_comp,ISNULL(cod_tipo,'') AS cod_tipo FROM personal WHERE reloj = '" & Reloj & "'")
            If dtEmp.Rows.Count = 0 Then
                Return -1
            End If

            If Not IsDBNull(dtEmp.Rows(0).Item("baja")) Then
                If dtEmp.Rows(0).Item("baja") <= Fecha Then
                    Return 0
                End If
            End If

            _dDias = ProporcionVacaciones(dtEmp.Rows(0).Item("alta"), Now, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"))

            Return _dDias
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function ValidaRFC(ByVal RFC As String) As Boolean
        Dim Resultado As Boolean = True
        Try
            Resultado = Len(RFC.Trim) = 13
            Resultado = Resultado And System.Text.RegularExpressions.Regex.IsMatch(RFC.Substring(0, 4), "^[a-zA-Z]")
            Resultado = Resultado And IsNumeric(RFC.Substring(4, 6))

            Return Resultado
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ValidaCURP(ByVal CURP As String) As Boolean
        Dim Resultado As Boolean = True
        Try
            Resultado = Len(CURP.Trim) = 18
            Resultado = Resultado And System.Text.RegularExpressions.Regex.IsMatch(CURP.Substring(0, 4), "^[a-zA-Z]")
            Resultado = Resultado And IsNumeric(CURP.Substring(4, 6))
            Resultado = Resultado And IsDate(DateSerial(CURP.Substring(4, 2), CURP.Substring(6, 2), CURP.Substring(8, 2)))
            Resultado = Resultado And (CURP.Substring(10, 1) = "M" Or CURP.Substring(10, 1) = "H")
            Resultado = Resultado And Array.IndexOf(New String() {"AS", "MS", "BC", "NT", "BS", "NL", "CC", "OC", "CL", "PL", "CM", "QT", "CS", "QR", "CH", "SP", "DF", "SL", "DG", "SR", "GT", "TC", "GR", "TS", "HG", "TL", "JC", "VZ", "MC", "YN", "MN", "ZS", "NE"}, CURP.Substring(11, 2)) <> -1
            Resultado = Resultado And System.Text.RegularExpressions.Regex.IsMatch(CURP.Substring(13, 3), "^[a-zA-Z]")
            Resultado = Resultado And (IsNumeric(CURP.Substring(16, 1)) Or System.Text.RegularExpressions.Regex.IsMatch(CURP.Substring(16, 1), "^[a-zA-Z]"))
            Resultado = Resultado And (IsNumeric(CURP.Substring(17, 1)) Or System.Text.RegularExpressions.Regex.IsMatch(CURP.Substring(17, 1), "^[a-zA-Z]"))

            Return Resultado
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean
        Dim IsAlpha As Boolean = False
        If System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^[a-zA-Z]") Then
            IsAlpha = True
        Else
            IsAlpha = False
        End If
        Return IsAlpha
    End Function
    Public Function PeriodoAnterior(ByVal AnoPeriodo As String) As String
        Dim A As String
        Dim P As String
        Dim F As Date
        Dim AP As String

        Dim dtPer As New DataTable
        Try
            'Separar año y periodo, para facilitar la búsqueda
            A = AnoPeriodo.Substring(0, 4)
            P = AnoPeriodo.Substring(4, 2)
            'Buscar en tabla de periodos, el valor actual
            dtPer = sqlExecute("SELECT fecha_ini FROM periodos WHERE ano ='" & A & "' AND periodo = '" & P & "'", "TA")
            'Tomar la fecha de inicio de este periodo
            F = dtPer.Rows(0).Item("fecha_ini")
            'Día anterior a la fecha de inicio (ya es periodo anterior)
            F = DateAdd(DateInterval.Day, -1, F)
            'Buscar el periodo al que corresponde esta fecha
            AP = ObtenerAnoPeriodo(F)

            Return AP
        Catch ex As Exception
            Return "ERROR"
        End Try

    End Function
    Public Function FechaDMY(ByVal Fecha As Date) As String
        Dim F As String
        Try
            F = Fecha.Day.ToString.PadLeft(2, "0") & Fecha.Month.ToString.PadLeft(2, "0") & Fecha.Year.ToString.PadLeft(4, "0")
            Return F
        Catch ex As Exception
            F = "Error"
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
        Return F
    End Function

    Public Function CadenaFiltro(ByRef Tabla As DataTable, ByRef SGrid As DevComponents.DotNetBar.SuperGrid.SuperGridControl) As OrdenFiltro
        Dim Parametros As OrdenFiltro

        Try
            Dim d As Double
            d = Tabla.Rows.Count
            d = SGrid.PrimaryGrid.Rows.Count
            'Variable F se inicializa a 1=1, para que siempre sea verdadero, y no interfiera con el filtro
            Dim F As String = "1=1"
            Dim O As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim Campo As String = ""
            Dim Expresion As String = ""

            For Each c As DevComponents.DotNetBar.SuperGrid.GridColumn In SGrid.PrimaryGrid.Columns
                If Not IsNothing(c.FilterExpr) Then
                    Expresion = c.FilterExpr.ToUpper
                    i = Expresion.IndexOf("]")
                    j = Expresion.IndexOf("[")

                    If Expresion.ToUpper.Contains(c.DataPropertyName.ToUpper) Then
                        If Expresion.ToUpper.Contains("YEAR") And i > 0 Then
                            Campo = Expresion.Substring(j + 1, i - j - 1)
                            F = F & " AND (" & Campo & " >= '" & FechaSQL(DateSerial(Year(Now), 1, 1)) & "' AND " & Campo & " <= '" & FechaSQL(DateSerial(Year(Now), 12, 31)) & "')"
                        Else
                            F = F & " AND " & Expresion

                        End If
                    Else
                        If Expresion.ToUpper.Substring(0, IIf(Expresion.Length > 3, 3, Expresion.Length)) = "IS " Then
                            Expresion = " " & Expresion
                            Dim ExP As String = ""
                            i = 0
                            j = 0
                            Do
                                i = Expresion.IndexOf(" IS ", i + 1)
                                If i > 0 Then
                                    ExP = ExP & " " & c.DataPropertyName & " LIKE " & Expresion.Substring(j, i - j).Replace("IS ", "") & "%%"
                                Else
                                    ExP = ExP & " " & c.DataPropertyName & " LIKE " & Expresion.Substring(j + 1).Replace("IS ", "") & "%%"

                                    Exit Do
                                End If

                                j = i
                            Loop
                            ExP = ExP.Replace("'%%", "%'")
                            ExP = ExP.Replace("  ", " ")
                            ExP = ExP.Replace("%%", "")
                            ExP = ExP.Replace("LIKE NOT", "NOT LIKE")
                            ExP = ExP.Replace("NOT LIKE NULL", "IS NOT NULL")
                            ExP = ExP.Replace("LIKE NULL", "IS NULL")
                            F = F & " AND (" & ExP & ")"
                        Else
                            If i >= 0 Then
                                F = F & " AND (" & c.DataPropertyName & " " & Expresion.Substring(i + 1).Replace("'", "%'").Replace(" %'", " '") & ")"
                            ElseIf i < 0 And j < 0 Then
                                F = F & " AND (" & Expresion.Replace("=", c.DataPropertyName & " LIKE ").Replace("'", "%'").Replace(" %'", " '%") & ")"
                            Else
                                F = F & " AND (" & c.DataPropertyName & " " & Expresion.Replace("'", "%'").Replace(" %'", " '") & ")"
                            End If
                        End If

                    End If
                End If
                If c.IsSortColumn Then
                    O = O & IIf(O.Length = 0, "", ",") & c.DataPropertyName & " " & IIf(c.SortDirection = DevComponents.DotNetBar.SuperGrid.SortDirection.Ascending, "ASC", "DESC")
                End If
            Next
            F = F.ToUpper
            F = F.Replace("[", "")
            F = F.Replace("]", "")
            F = F.Replace("*", "%")
            F = F.Replace("YEAR()", Year(Now))
            F = F.Replace(Chr(34), "'")
            F = F.ToUpper.Replace(" = NULL", " IS NULL")
            F = F.ToUpper.Replace(" != NULL", " IS NOT NULL")
            Parametros.Orden = O
            Parametros.Filtro = F
            Return Parametros
        Catch ex As Exception
            Parametros.Orden = ""
            Parametros.Filtro = "1=2"
            Return Parametros
        End Try
    End Function

    Public Sub PlaneacionCursada(ByVal Reloj As String, ByVal Curso As String, ByVal Fecha As Date)
        'Indicar la fecha del curso en la planeación... en caso de que sea curso planeado, si no, lo ignora
        'dentro de planeación, buscar la fecha más reciente para el curso seleccionado (en caso de que hubiera más de uno), 
        'y que no se haya cursado
        Try
            sqlExecute("UPDATE planeacion_empleados SET " & _
                       "fecha_curso = '" & FechaSQL(Fecha) & _
                       "' WHERE reloj = '" & Reloj & "' AND cod_curso = '" & Curso & _
                       "' AND fecha_curso IS NULL AND ano + mes = (SELECT MIN(ano+mes) FROM planeacion_empleados as p " & _
                       "WHERE p.reloj = planeacion_empleados.reloj " & _
                       "AND p.cod_curso = planeacion_empleados.cod_curso " & _
                       "AND fecha_curso IS NULL)", "capacitacion")

        Catch ex As Exception

        End Try
    End Sub

    Public Function EliminaAcentos(ByVal Texto As String) As String
        Try
            Texto = Texto.Replace("á", "a")
            Texto = Texto.Replace("é", "e")
            Texto = Texto.Replace("í", "i")
            Texto = Texto.Replace("ó", "o")
            Texto = Texto.Replace("ú", "u")
            Texto = Texto.Replace("ü", "u")

            Texto = Texto.Replace("á".ToUpper, "A")
            Texto = Texto.Replace("é".ToUpper, "E")
            Texto = Texto.Replace("í".ToUpper, "I")
            Texto = Texto.Replace("ó".ToUpper, "O")
            Texto = Texto.Replace("ú".ToUpper, "U")
            Texto = Texto.Replace("ü".ToUpper, "U")

            Return Texto
        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function

    Public Function TiempoCompleto(ByVal Reloj As String) As Boolean
        Dim Completo As Boolean = False
        Dim Filtro As String
        Try
            dtTemporal = sqlExecute("SELECT ISNULL(FILTRO_TIEMPO_COMPLETO,'') AS FILTRO FROM CIAS_TA LEFT JOIN PERSONAL.DBO.PERSONAL " & _
                                    "ON cias_ta.COD_COMP = PERSONAL.COD_COMP WHERE RELOJ = '" & Reloj & "'", "TA")
            If dtTemporal.Rows.Count = 0 Then
                dtTemporal = sqlExecute("SELECT compania FROM personalVW where reloj = '" & Reloj & "'")
                'MessageBox.Show("La compañía " & dtTemporal.Rows(0).Item("compania").ToString.Trim & " no tiene registro en CIAS_TA, " & _
                '                "favor de verificar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Err.Raise(-1, Nothing, "Compañía " & dtTemporal.Rows(0).Item("compania").ToString.Trim & " no registrada en TA")
            End If
            Filtro = IIf(IsDBNull(dtTemporal.Rows.Item(0).Item("filtro")), "", dtTemporal.Rows(0).Item("filtro"))
            Filtro = IIf(Filtro = "NINGUNO", "", Filtro.Trim)
            If Filtro.Length = 0 Then
                Completo = False
            Else
                'Buscar si empleado cumple la condición indicada para aplicar tiempo completo
                dtTemporal = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & Reloj & "' AND " & Filtro)
                Completo = dtTemporal.Rows.Count > 0
            End If
            Return Completo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, Reloj)
            Return False
        End Try
    End Function

    'Public Function SemanaHorarioMixto(ByVal AnoPeriodo As String, ByVal Reloj As String) As DetalleSemana
    '    Dim Semana As DetalleSemana

    '    Try
    '        Dim dtHor As New DataTable
    '        Dim dtPer As New DataTable
    '        Dim Inicio As Integer
    '        Dim Partir As String
    '        Dim Dif As Integer
    '        Dim CodComp As String
    '        Dim CodHorario As String
    '        Dim Alta As Date
    '        If Reloj = "" Then Return Nothing

    '        dtPer = sqlExecute("SELECT alta,cod_comp,cod_hora FROM personal WHERE reloj = '" & Reloj & "'")
    '        CodComp = IIf(IsDBNull(dtPer.Rows(0).Item("cod_comp")), "", dtPer.Rows(0).Item("cod_comp"))
    '        CodHorario = IIf(IsDBNull(dtPer.Rows(0).Item("cod_hora")), "", dtPer.Rows(0).Item("cod_hora"))
    '        Alta = dtPer.Rows(0).Item("alta")

    '        dtHor = sqlExecute("SELECT mixto,inicio_mixto,partir_mixto,factor_semana1,factor_semana2 FROM horarios WHERE cod_comp = '" & CodComp & _
    '                           "' AND cod_hora = '" & CodHorario & "'")
    '        If dtHor.Rows.Count = 0 Then
    '            Err.Raise(-1, Nothing, "Horario no localizado " & CodComp & "-" & CodHorario)
    '        Else
    '            Semana.Mixto = IIf(IsDBNull(dtHor.Rows(0).Item("mixto")), False, dtHor.Rows(0).Item("mixto"))
    '            If Not Semana.Mixto Then
    '                Semana.Factor = 1
    '                Semana.NumSemana = 1
    '            Else
    '                Partir = IIf(IsDBNull(dtHor.Rows(0).Item("partir_mixto")), "P", dtHor.Rows(0).Item("partir_mixto"))
    '                Inicio = IIf(IsDBNull(dtHor.Rows(0).Item("inicio_mixto")), "1", dtHor.Rows(0).Item("inicio_mixto"))
    '                If Partir = "A" Then
    '                    Dif = DiferenciaPeriodos(AnoPeriodo, ObtenerAnoPeriodo(Alta))
    '                    If Dif Mod 2 = 0 Then
    '                        Semana.NumSemana = Inicio
    '                    Else
    '                        Semana.NumSemana = IIf(Inicio = "1", "2", "1")
    '                    End If
    '                Else
    '                    If CInt(AnoPeriodo.Substring(4, 2)) Mod 2 = 0 Then
    '                        Semana.NumSemana = IIf(Inicio = "1", "2", "1")
    '                    Else
    '                        Semana.NumSemana = Inicio
    '                    End If
    '                End If

    '                If Semana.NumSemana = 1 Then
    '                    Semana.Factor = IIf(IsDBNull(dtHor.Rows(0).Item("factor_semana1")), 1, dtHor.Rows(0).Item("factor_semana1"))
    '                Else
    '                    Semana.Factor = IIf(IsDBNull(dtHor.Rows(0).Item("factor_semana2")), 1, dtHor.Rows(0).Item("factor_semana2"))
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Semana.NumSemana = -1
    '        Semana.Mixto = False
    '        Semana.Factor = 0
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, Reloj)
    '    End Try
    '    Return Semana

    'End Function

    ''' <summary>
    ''' BRP - Procedimiento para obtener el comportamiento de la semana a analizar, en un horario mixto por rol
    ''' </summary>
    Public Function SemanaHorarioMixto(ByVal AnoPeriodo As String, ByVal Reloj As String) As DetalleSemana
        Dim Semana As DetalleSemana

        Try
            Dim dtHor As New DataTable
            Dim F As String
            Dim Factor() As String

            If Reloj = "" Then Return Nothing


            Dim dtPersonal As DataTable = sqlExecute("select * from personal where reloj = '" & Reloj & "'")
            Dim cod_hora As String = dtPersonal.Rows(0)("cod_hora")

            Dim dtBitacora As DataTable = sqlExecute("select * from bitacora_personal left join ta.dbo.periodos on bitacora_personal.fecha between periodos.FECHA_INI and periodos.FECHA_FIN where reloj = '" & Reloj & "' and campo = 'cod_hora' and ISNULL(periodos.periodo_especial, 0) = 0 and periodos.ANO+periodo > '" & AnoPeriodo & "' order by fecha asc")
            If dtBitacora.Rows.Count > 0 Then
                Dim anterior As String = dtBitacora.Rows(0)("valoranterior")
                cod_hora = anterior
            End If

            'dtHor = sqlExecute("select personal.cod_comp,personal.cod_hora,horarios.mixto,horarios.FACTOR_SEMANAL,semana FROM personal " & _
            '                   "LEFT JOIN horarios ON personal.cod_comp = horarios.cod_comp AND personal.cod_hora = horarios.cod_hora " & _
            '                   "LEFT JOIN rol_horarios ON rol_horarios.cod_comp = personal.cod_comp AND rol_horarios.cod_hora = personal.cod_hora " & _
            '                   "WHERE reloj = '" & Reloj & "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' and periodo = '" & AnoPeriodo.Substring(4, 2) & "'")


            dtHor = sqlExecute("select horarios.mixto, rol_horarios.semana, horarios.factor_semanal from horarios left join rol_horarios on rol_horarios.cod_comp = horarios.cod_comp and rol_horarios.cod_hora = horarios.cod_hora where horarios.cod_hora = '" & cod_hora & "' and rol_horarios.ano+periodo = '" & AnoPeriodo & "'")

            If dtHor.Rows.Count = 0 Then
                Err.Raise(-1, Nothing, "Horario no localizado EMPLEADO " & Reloj)
            Else
                Semana.Mixto = IIf(IsDBNull(dtHor.Rows(0).Item("mixto")), False, dtHor.Rows(0).Item("mixto"))
                Semana.NumSemana = IIf(IsDBNull(dtHor.Rows(0).Item("semana")), False, dtHor.Rows(0).Item("semana"))
                F = IIf(IsDBNull(dtHor.Rows(0).Item("factor_semanal")), "1.0000", dtHor.Rows(0).Item("factor_semanal")).ToString.Trim
                F = F.Replace(",", "|")
                If F.Substring(F.Length - 1) = "|" Then
                    F = F.Substring(0, F.Length - 1)
                End If
                Factor = F.Split("|")
                If Factor.Count < Semana.NumSemana Then
                    Semana.Factor = 1
                Else
                    Semana.Factor = Factor(Semana.NumSemana - 1)
                End If

                Semana.cod_hora = cod_hora

            End If
        Catch ex As Exception
            Semana.NumSemana = -1
            Semana.Mixto = False
            Semana.Factor = 0
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message, Reloj)
        End Try
        Return Semana

    End Function

    Public Function MontoConcepto(ByVal Reloj As String, ByVal Ano As String, ByVal Periodo As String, tipo_periodo As String, ByVal concepto As String) As Double
        Try
            Dim dtMovs As New DataTable
            Dim monto As Double
            dtMovs = sqlExecute("SELECT monto FROM movimientos WHERE ano = '" & Ano & "' AND periodo = '" & Periodo & _
                                "' AND reloj = '" & Reloj & "' and tipo_periodo = '" & tipo_periodo & "' AND concepto = '" & concepto & "'", "nomina")

            If dtMovs.Rows.Count = 0 Then
                monto = 0
            Else
                monto = IIf(IsDBNull(dtMovs.Rows(0).Item("monto")), 0, dtMovs.Rows(0).Item("monto"))
            End If
            Return monto

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)

            Return -1
        End Try
    End Function

    Public Function ColumnaExcel(ByVal NumCol As Integer) As String
        Try
            Dim Cl As String = "A"
            Dim Columna As String = ""
            Dim x As Integer
            Dim y As Integer = 0
            For x = 1 To NumCol - 1
                Cl = Chr(Asc(Cl) + 1)
                If Cl.Substring(Cl.Length - 1, 1) = "Z" And x < NumCol Then
                    Columna = Chr(Asc("A") + y)
                    y += 1
                    x += 1
                    Cl = "A"
                End If
            Next
            Cl = Columna & Cl
            Return Cl
        Catch ex As Exception
            Return "ERR"
        End Try
    End Function

    Public Function ValorBitacora(ByVal Reloj As String, ByVal Campo As String, ByVal Fecha As Date) As String
        Dim dtBitacora As New DataTable
        Dim Valor As String = ""
        Dim AnoPer As String
        Try
            AnoPer = ObtenerAnoPeriodo(Fecha)
            dtTemporal = sqlExecute("select (case when exists (select name from sys.columns WHERE Name = '" & Campo & "' and Object_ID = Object_ID(N'asist')) then 1 else 0 end) as campo", "TA")
            If dtTemporal.Rows(0).Item(0) = 1 Then
                'Si el campo existe en asist...
                dtBitacora = sqlExecute("SELECT TOP 1" & Campo & " FROM asist WHERE reloj = '" & Reloj & "' AND ano = '" & AnoPer.Substring(0, 4) & "' AND periodo = '" & AnoPer.Substring(4, 2) & "'", "TA")
                If dtBitacora.Rows.Count > 0 Then
                    Valor = dtBitacora.Rows(0).Item(0)
                Else
                    'Si no se localizó en asist, buscar en bitácora
                    'buscar si hay cambios en bitácora
                    dtBitacora = sqlExecute("SELECT TOP 1 ValorNuevo FROM bitacora_personal WHERE " & _
                                            "convert(char,fecha,120) < '" & FechaSQL(Fecha) & "'" & _
                                            " AND reloj = '" & Reloj & "' and campo = '" & Campo & _
                                            "' ORDER BY fecha DESC")
                    If dtBitacora.Rows.Count > 0 Then
                        'Si hubo registro, pasar el valor anterior a la tabla, para regresar al punto del mantenimiento
                        Valor = dtBitacora.Rows(0).Item("ValorNuevo").ToString
                    Else
                        'Si no se encontró en asist, ni en bitácora, pasar dato de personal (es el más actual)
                        dtBitacora = sqlExecute("SELECT " & Campo & " FROM personalVW WHERE reloj = '" & Reloj & "'")
                        If dtBitacora.Rows.Count > 0 Then
                            Valor = dtBitacora.Rows(0).Item(0)
                        End If
                    End If
                End If
            Else
                'Si el campo a filtrar no se localiza en asist
                'buscar en bitácora a la fecha requerida
                dtBitacora = sqlExecute("SELECT TOP 1 ValorNuevo FROM bitacora_personal WHERE " & _
                                        "convert(char,fecha,120) < '" & FechaSQL(Fecha) & "'" & _
                                        " AND reloj = '" & Reloj & "' and campo = '" & Campo & _
                                        "' ORDER BY fecha DESC")
                If dtBitacora.Rows.Count > 0 Then
                    'Si hubo registro, pasar el valor anterior a la tabla, para regresar al punto del mantenimiento
                    Valor = dtBitacora.Rows(0).Item("ValorNuevo").ToString
                Else
                    dtBitacora = sqlExecute("SELECT " & Campo & " FROM personalVW WHERE reloj = '" & Reloj & "'")
                    If dtBitacora.Rows.Count > 0 Then
                        Valor = IIf(IsDBNull(dtBitacora.Rows(0).Item(0)), "", dtBitacora.Rows(0).Item(0))
                    End If
                End If
            End If

            Return Valor
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return "ERROR"
        End Try

    End Function
    Public Sub GeneraArchivoSAP(ByVal frmName As Form)
        Dim strFileName As String = ""
        Dim GuardaArchivo As Boolean
        Dim Orden As String
        Dim Nombres As String

        Dim dtInfoArchivo As New DataTable
        Dim dtInfoTAlloc As New DataTable
        Dim oWrite As System.IO.StreamWriter
        Dim FechaCorte As Date
        Try
            dtTemporal = sqlExecute("SELECT fecha_corte_tAlloc FROM parametros")
            If dtTemporal.Rows.Count = 0 Then
                FechaCorte = DateAdd(DateInterval.Month, -1, DateSerial(Now.Year, Now.Month, 1))
            Else
                FechaCorte = IIf(IsDBNull(dtTemporal.Rows(0).Item("fecha_corte_talloc")), DateAdd(DateInterval.Month, -1, DateSerial(Now.Year, Now.Month, 1)), dtTemporal.Rows(0).Item("fecha_corte_talloc"))
            End If

            frmRangoFechas.frmRangoFechas_fecha_ini = FechaCorte
            frmRangoFechas.frmRangoFechas_fecha_fin = Now

            frmRangoFechas.ShowDialog()
            If IsNothing(FechaInicial) Or FechaInicial = New Date Then
                Exit Sub
            End If

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = ""
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If

            Try
                oWrite = System.IO.File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            If GuardaArchivo Then

                frmTrabajando.Text = "Archivo SAP"
                frmTrabajando.lblAvance.Text = "Preparando información"
                frmTrabajando.Avance.IsRunning = True
                frmTrabajando.Show(frmName)

                Dim dtParametros As New DataTable
                Dim FiltroTAlloc As String
                dtParametros = sqlExecute("SELECT fecha_corte_tAlloc,filtro_tAlloc FROM parametros")
                If dtParametros.Rows.Count = 0 Then
                    FechaCorte = DateSerial(2000, 1, 1)
                    FiltroTAlloc = ""
                Else
                    FechaCorte = IIf(IsDBNull(dtParametros.Rows(0).Item("fecha_corte_talloc")), DateSerial(200, 1, 1), dtParametros.Rows(0).Item("fecha_corte_talloc"))
                    FiltroTAlloc = IIf(IsDBNull(dtParametros.Rows(0).Item("filtro_tAlloc")), "", dtParametros.Rows(0).Item("filtro_tAlloc"))
                End If

                My.Application.DoEvents()
                'Solo exportar los registros que tengan departamento de 6 dígitos (incluye última letra)
                'Revisar nuevamente el filtro, por si algún empleado cambió de condiciones después de la captura
                dtInfoTAlloc = sqlExecute("SELECT reloj,nombres,cod_deptota,cod_turnota,fecha,cod_orden,nombre_orden,asignadas,cod_comp " & _
                                          "FROM TimeAllocationVW WHERE fecha BETWEEN '" & FechaSQL(FechaInicial) & "' AND '" & FechaSQL(FechaFinal) & "'" & _
                                          " AND NOT asignadas IS NULL AND asignadas >0 AND LEN(RTRIM(cod_deptoTA))>5 " & _
                                          IIf(FiltroTAlloc.Length > 0, " AND " & FiltroTAlloc, "") & _
                                          IIf(FiltroXUsuario.Length > 0, " AND " & FiltroXUsuario, ""), "TA")

                Dim dtArchivo As New DataTable
                dtArchivo.Columns.Add("unique", Type.GetType("System.String"))
                dtArchivo.Columns.Add("fecha", Type.GetType("System.String"))
                dtArchivo.Columns.Add("cod_deptota", Type.GetType("System.String"))
                dtArchivo.Columns.Add("cod_turnota", Type.GetType("System.String"))
                dtArchivo.Columns.Add("reloj", Type.GetType("System.String"))
                dtArchivo.Columns.Add("cod_orden", Type.GetType("System.String"))
                dtArchivo.Columns.Add("nombre_orden", Type.GetType("System.String"))
                dtArchivo.Columns.Add("asignadas", Type.GetType("System.String"))
                dtArchivo.Columns.Add("nombres", Type.GetType("System.String"))
                dtArchivo.Columns("unique").Unique = True

                For Each dRow As DataRow In dtInfoTAlloc.Select("", "fecha,cod_deptota,cod_orden,reloj")
                    Try
                        dtArchivo.Rows.Add(FechaSQL(dRow("fecha")) & dRow("reloj") & dRow("cod_orden"), FechaSQL(dRow("fecha")), dRow("cod_deptota"), _
                                           dRow("cod_turnota"), dRow("reloj"), dRow("cod_orden"), dRow("nombre_orden"), dRow("asignadas"), dRow("nombres"))
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try
                    My.Application.DoEvents()
                Next
                'For Each dRow As DataRow In dtInfoTAlloc.Select("LEN(TRIM(cod_deptoTA))>5", "fecha,cod_deptota,cod_orden,reloj")
                frmTrabajando.lblAvance.Text = "Exportando datos"
                For Each dRow As DataRow In dtArchivo.Rows
                    My.Application.DoEvents()

                    If dRow("nombre_orden").ToString.Trim.Length > 30 Then
                        Orden = dRow("nombre_orden").ToString.Trim.Substring(0, 30)
                    Else
                        Orden = dRow("nombre_orden").ToString.Trim.PadRight(30, " ")
                    End If

                    Nombres = dRow("nombres").ToString.Trim
                    Nombres = Nombres.Replace(",", " ")
                    Nombres = Nombres.Replace("Ñ", "N")
                    Nombres = Nombres.Replace("Á", "A")
                    Nombres = Nombres.Replace("É", "E")
                    Nombres = Nombres.Replace("Í", "I")
                    Nombres = Nombres.Replace("Ó", "O")
                    Nombres = Nombres.Replace("Ú", "U")
                    Nombres = Nombres.Replace("  ", " ")
                    If Nombres.Length > 40 Then
                        Nombres = Nombres.Substring(0, 40)
                    End If


                    oWrite.WriteLine(FechaSQL(dRow("fecha")).Replace("-", "") & _
                                     dRow("cod_deptota").ToString.Trim.PadRight(6, " ") & _
                                     Space(6) & _
                                     dRow("cod_turnota").ToString.Trim.PadLeft(2, "0") & _
                                     Space(2) & _
                                     dRow("reloj").ToString.Trim.PadRight(6, " ") & _
                                     Space(3) & _
                                     dRow("cod_orden").ToString.Trim.PadLeft(9, "0") & _
                                     Orden & _
                                     Space(3) & _
                                     String.Format("{00:00.00}", Math.Round(Double.Parse(dRow("asignadas")), 2)) & _
                                     Nombres.PadRight(40, " "))

                Next
                oWrite.Close()
                frmTrabajando.Hide()

                'If MessageBox.Show("El archivo fue satisfactoriamente creado como " & vbCrLf & strFileName & vbCrLf & vbCrLf & _
                ' "¿Desea registrar el " & FechaMediaLetra(FechaFinal) & " como nueva fecha de corte?", _
                ' "Archivo guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                'sqlExecute("UPDATE parametros SET fecha_corte_tAlloc = '" & FechaSQL(FechaFinal) & "'")
                ' End If
                'MessageBox.Show("El archivo fue satisfactoriamente creado como " & vbCrLf & strFileName & vbCrLf & vbCrLf, "Archivo Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                EncabezadoReporte = "Del " & FechaMediaLetra(FechaInicial) & " al " & FechaMediaLetra(FechaFinal)
                If dtInfoTAlloc.Rows.Count > 0 Then
                    frmVistaPrevia.LlamarReporte("Asignacion de horas por orden de trabajo", dtInfoTAlloc, dtInfoTAlloc.Rows(0).Item("cod_comp"))
                    frmVistaPrevia.ShowDialog()
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), frmName.Name, ex.HResult, ex.Message)
        Finally
            ActivoTrabajando = False
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()

        End Try
    End Sub


    Public Function DiasMes(fecha As Date) As Integer
        Select Case Month(fecha)
            Case 1
                Return 31
            Case 2
                Return 28
            Case 3
                Return 31
            Case 4
                Return 30
            Case 5
                Return 31
            Case 6
                Return 30
            Case 7
                Return 31
            Case 8
                Return 31
            Case 9
                Return 30
            Case 10
                Return 31
            Case 11
                Return 30
            Case 12
                Return 31
        End Select
        Return 30
    End Function


    ''' <summary>
    ''' MCR 19/OCT/2015 - Código para hacer excepciones a habilitar/ver controles de acuerdo al perfil
    ''' </summary>
    ''' <param name="frmControl"></param>
    ''' <remarks></remarks>
    Public Sub RevisaExcepciones(frmControl As Form, Optional ByVal Cia As String = "", Optional ByVal Revertir As Boolean = False)
        Try
            'Ultima modificación: MCR 1/dic/2015
            'Agregar parámetro opcional Revertir, para regresar los controles a visible/habilitado cuando no aplique la compañía

            'MCR 18 / Nov / 2015
            'Integrar campos bloqueados por SuccessFactor

            Dim dtExcepciones As New DataTable
            Dim NombreControl As String
            Dim NombreContenedor As String
            Dim Visible As Boolean
            Dim Habilitado As Boolean
            Dim Ctrl As Control
            Dim Contenedor As Control

            'Buscar las excepciones para el perfil actual, de la forma indicada
            'Buscar las excepciones para el perfil actual, de la forma indicada
            dtExcepciones = sqlExecute("SELECT nombre_control,visible,habilitado FROM excepciones WHERE " & _
                                       "(cod_perfil = 'GENERAL' OR cod_perfil " & Perfil & ") " & _
                                       "AND nombre_forma = '" & frmControl.Name & "' " & _
                                       IIf(Cia.Length > 0, " AND (cod_comp ='[]' OR cod_comp LIKE '%" & Cia & "%')", ""), "SEGURIDAD")


            For Each dCtrl As DataRow In dtExcepciones.Rows
                NombreControl = dCtrl("nombre_control").ToString.Trim
                Visible = IIf(IsDBNull(dCtrl("visible")), 0, dCtrl("visible")) = 1
                Habilitado = IIf(IsDBNull(dCtrl("habilitado")), 0, dCtrl("Habilitado")) = 1


                If NombreControl.Contains(".") Then
                    'Si el control está dentro de un contenedor que no es de System.Windows.Forms (básico del VB)
                    'es necesario especificar el parent, luego separar con punto el nombre del control
                    'EJEMPLO: rbnAcciones.btnAsistenciaPerfecta
                    NombreContenedor = NombreControl.Substring(0, NombreControl.IndexOf("."))
                    NombreControl = NombreControl.Substring(NombreControl.IndexOf(".") + 1)

                    If frmControl.Controls.Find(NombreContenedor, True).Count > 0 Then
                        Contenedor = frmControl.Controls.Find(NombreContenedor, True)(0)
                        If Not Contenedor Is Nothing Then
                            'Si lo encuentra, asignarlo tipo RibbonBar y su elemento como ButtonItem
                            If TypeOf Contenedor Is DevComponents.DotNetBar.RibbonBar Then
                                Dim rbnCont As DevComponents.DotNetBar.RibbonBar
                                Dim btnCtrl As DevComponents.DotNetBar.ButtonItem

                                rbnCont = Contenedor
                                For Each btnCtrl In rbnCont.Items
                                    If btnCtrl.Name = NombreControl Then
                                        btnCtrl.Visible = Visible Or Revertir
                                        btnCtrl.Enabled = Habilitado Or Revertir

                                        Exit For
                                    End If
                                Next
                            Else
                                'Agregar los diferentes tipos de contenedor cuando no sean de windows
                                Stop

                                MessageBox.Show("Es necesario especificar tipo de contenedor para " & NombreContenedor & " " & Contenedor.GetType.ToString)
                                If Contenedor.Controls.Find(NombreControl, True).Count > 0 Then
                                    Ctrl = Contenedor.Controls.Find(NombreControl, True)(0)
                                    If Not Ctrl Is Nothing Then
                                        'Si lo encuentra, cambiar propiedades
                                        Ctrl.Visible = Visible Or Revertir
                                        Ctrl.Enabled = Habilitado Or Revertir
                                    End If
                                End If
                            End If


                        End If
                    End If
                Else
                    'Buscar el control por nombre, dentro de la forma

                    If frmControl.Controls.Find(NombreControl, True).Count > 0 Then
                        Ctrl = frmControl.Controls.Find(NombreControl, True)(0)
                        If Not Ctrl Is Nothing Then
                            'Si lo encuentra, cambiar propiedades
                            Ctrl.Visible = Visible Or Revertir
                            Ctrl.Enabled = Habilitado Or Revertir
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), frmControl.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Public Function ObtenerFactor(ByRef cod_hora_rol As String, ByRef ano_rol As String, ByRef periodo_rol As String) As String

        Dim hora_fac As String
        Dim dtfactor As New DataTable

        dtfactor = sqlExecute("select * from rol_horarios where ano = '" & ano_rol & "' and periodo = '" & periodo_rol & "' and cod_hora = '" & cod_hora_rol & "'")

        If dtfactor.Rows.Count > 0 Then
            hora_fac = dtfactor.Rows(0).Item("factor")
        Else
            hora_fac = ""
        End If

        Return hora_fac
    End Function

    Public Function ConsultaBitacoraHorarios(ByVal dtTabla As DataTable, ByRef dRow As DataRow, ByVal FechaTope As Date, ByVal nombre_campo As String) As String
        Dim dtTurno As New DataTable
        Dim dtHorario As New DataTable
        Dim Campo As String
        Dim dtTemp As New DataTable
        Dim valor As String = ""

        FechaTope = FechaTope.AddDays(1) '--Le agregamos 1 día

        Try
            Dim Query As String = "SELECT top 1 CAMPO,VALORANTERIOR,VALORNUEVO FROM bitacora_personal WHERE reloj = '" & dRow("reloj") & " ' AND " & _
                "cast(FECHA as date) <='" & FechaSQL(FechaTope) & "' AND tipo_movimiento = 'C' and campo in('" & nombre_campo & "') ORDER BY fecha desc"

            dtTemp = sqlExecute(Query, "PERSONAL")
            If (Not dtTemp.Columns.Contains("Error") And dtTemp.Rows.Count > 0) Then
                '  Try : valor = dtTemp.Rows(0).Item("VALORANTERIOR").ToString.Trim : Catch ex As Exception : valor = "" : End Try ' Especial para wollsdorf
                Try : valor = dtTemp.Rows(0).Item("VALORNUEVO").ToString.Trim : Catch ex As Exception : valor = "" : End Try ' Normal com se hace
            End If

            If (valor = "") Then 'Tomarlo de personal
                Dim dtPers As DataTable = sqlExecute("select " & nombre_campo & " from personal where reloj='" & dRow("reloj") & "' and cod_comp='" & dRow("cod_comp") & "'", "PERSONAL")
                If (Not dtPers.Columns.Contains("Error") And dtPers.Rows.Count > 0) Then
                    Try : valor = dtPers.Rows(0).Item(nombre_campo).ToString.Trim : Catch ex As Exception : valor = "" : End Try
                End If
            End If

            Return valor
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return valor
        End Try

    End Function
    Public Function ConsultaBitacora(ByVal dtTabla As DataTable, ByRef dRow As DataRow, ByVal FechaTope As Date) As Boolean
        Dim dtPeriodos As New DataTable
        Dim dtBitacora As New DataTable
        Dim Campo As String

        Dim dtTemp As New DataTable

        Try
            'buscar si hay movimientos efectuados después del fin del periodo
            'si hay, tomar el valorAnterior del primero, que indica cómo estaba antes del cambio
            dtBitacora = sqlExecute("SELECT CAMPO,VALORANTERIOR FROM bitacora_personal WHERE reloj = '" & dRow("reloj") & _
                                    "' AND FECHA = " & _
                                    "(SELECT MIN(FECHA) AS FECHA FROM dbo.bitacora_personal AS BITACORA WHERE " & _
                                    "CAST(fecha AS DATE) > '" & FechaSQL(FechaTope) & "' AND campo = bitacora_personal.campo and reloj= bitacora_personal.reloj) " & _
                                    " AND tipo_movimiento = 'C' and campo not in('cod_hora','cod_turno') ORDER BY fecha")


            For Each dCol As DataRow In dtBitacora.Rows
                Campo = dCol("campo").ToString.ToLower.Trim
                If dtTabla.Columns.IndexOf(Campo) >= 0 Then
                    'MCR 2017-10-09
                    'Error cuando drow(Campo) estaba nulo

                    If dRow(Campo).ToString <> dCol("ValorAnterior").ToString Then
                        'If dRow(Campo) <> dCol("ValorAnterior").ToString Then
                        Select Case dtTabla.Columns(Campo).DataType
                            Case GetType(System.String)
                                dRow(Campo) = dCol("ValorAnterior").ToString.Trim
                            Case GetType(System.Boolean)
                                dRow(Campo) = CInt(dCol("ValorAnterior"))
                            Case Else
                                dRow(Campo) = dCol("ValorAnterior")
                        End Select

                        Select Case Campo
                            Case "cod_tipo"
                                If dtTabla.Columns.IndexOf("nombre_tipoEmp") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM tipo_emp WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_tipo = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_tipoEmp") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_tipoEmp") = ""
                                    End If
                                End If
                            Case "cod_clase"
                                If dtTabla.Columns.IndexOf("nombre_clase") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM clase WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_clase = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_clase") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_clase") = ""
                                    End If
                                End If
                            Case "cod_comp"
                                If dtTabla.Columns.IndexOf("compania") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM cias WHERE cod_comp = '" & dRow("cod_comp") & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("compania") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("compania") = ""
                                    End If
                                End If
                            Case "cod_area"
                                If dtTabla.Columns.IndexOf("nombre_area") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM areas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_area = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_area") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_area") = ""
                                    End If
                                End If
                            Case "cod_depto"
                                If dtTabla.Columns.IndexOf("nombre_depto") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM deptos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_depto = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_depto") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_depto") = ""
                                    End If
                                End If
                            Case "cod_super"
                                If dtTabla.Columns.IndexOf("nombre_super") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM super WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_super = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_super") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_super") = ""
                                    End If
                                End If
                            Case "cod_planta"
                                If dtTabla.Columns.IndexOf("nombre_planta") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM plantas WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_planta = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_planta") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_planta") = ""
                                    End If
                                End If
                            Case "cod_turno"
                                If dtTabla.Columns.IndexOf("nombre_turno") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM turnos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_turno = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_turno") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_turno") = ""
                                    End If
                                End If
                            Case "cod_puesto"
                                If dtTabla.Columns.IndexOf("nombre_puesto") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM puestos WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_puesto = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_puesto") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_puesto") = ""
                                    End If
                                End If
                            Case "cod_hora"
                                If dtTabla.Columns.IndexOf("nombre_horario") >= 0 Then
                                    dtTemp = sqlExecute("SELECT nombre FROM horarios WHERE cod_comp = '" & dRow("cod_comp") & "' AND cod_hora = '" & dRow(Campo) & "'")
                                    If dtTemp.Rows.Count > 0 Then
                                        dRow("nombre_horario") = dtTemp.Rows(0).Item("nombre")
                                    Else
                                        dRow("nombre_horario") = ""
                                    End If
                                End If
                        End Select
                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Public Sub GenerarRolHorarios(ByVal cod_comp As String, ByVal cod_hora As String, ByVal secuencia_rol As String, ByVal fecha_ini As Date, Optional ByVal fecha_fin As Date = Nothing)

        Dim sec As String
        Dim secuencia() As String
        Dim i As Integer = 0
        Dim s As Integer

        Dim ano As String
        Dim periodo As String
        Dim AnoPerIni As String
        Dim AnoPerFin As String

        Dim dtPeriodos As New DataTable


        If fecha_fin = Nothing Then
            fecha_fin = DateSerial(2199, 1, 1)
        End If
        Try

            sec = secuencia_rol
            sec = sec.Replace(",", "|")
            If sec.Substring(sec.Length - 1) = "|" Then
                sec = sec.Substring(0, sec.Length - 1)
            End If
            secuencia = sec.Split("|")
            s = secuencia.GetUpperBound(0)


            AnoPerIni = ObtenerAnoPeriodo(fecha_ini)
            AnoPerFin = ObtenerAnoPeriodo(fecha_fin)

            AnoPerIni = IIf(AnoPerIni = "", Year(Now) & "01", AnoPerIni)
            AnoPerFin = IIf(AnoPerFin = "", "219901", AnoPerFin)

            dtPeriodos = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin FROM periodos WHERE fecha_ini BETWEEN '" & FechaSQL(fecha_ini) & _
                                    "' AND '" & FechaSQL(fecha_fin) & "' AND (periodo_especial IS NULL OR periodo_especial = 0) ORDER BY fecha_ini", "TA")

            sqlExecute("DELETE FROM rol_horarios WHERE cod_comp = '" & cod_comp & "' and cod_hora = '" & cod_hora & "' and ano+periodo >= '" & _
                      AnoPerIni & "'AND ano+periodo <='" & AnoPerFin & "' ")
            i = 0
            For Each drPeriodo As DataRow In dtPeriodos.Rows
                ano = drPeriodo("ano")
                periodo = drPeriodo("periodo")

                sqlExecute("INSERT INTO rol_horarios (cod_comp, cod_hora, ano, periodo, semana, factor) VALUES " & _
                           " ('" & cod_comp & "','" & cod_hora & "','" & ano & "','" & periodo & "'," & secuencia(i) & ", 1)")
                i += 1
                If i > s Then i = 0
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Function GetColorFondoDisip(TipoDisip As String) As Integer
        Dim Color As Integer
        Dim dtColor As New DataTable
        Try
            dtColor = sqlExecute("SELECT color_back FROM tipo_disciplinaria WHERE COD_TIPO_ACCION = '" & TipoDisip & "'", "Personal")
            If dtColor.Rows.Count > 0 Then
                Color = IIf(IsDBNull(dtColor.Rows(0).Item("color_back")), FondoDefault, dtColor.Rows(0).Item("color_back"))
            Else
                Color = FondoDefault
            End If
            Return Color

        Catch ex As Exception
            Return FondoDefault
        End Try
    End Function
    Public Function GetColorLetraDisip(TipoDisip As String) As Integer
        Dim Color As Integer
        Dim dtColor As New DataTable
        Try
            dtColor = sqlExecute("SELECT color_letra FROM tipo_disciplinaria WHERE COD_TIPO_ACCION = '" & TipoDisip & "'", "Personal")
            If dtColor.Rows.Count > 0 Then
                Color = IIf(IsDBNull(dtColor.Rows(0).Item("color_letra")), LetraDefault, dtColor.Rows(0).Item("color_letra"))
            Else
                Color = LetraDefault
            End If
            Return Color

        Catch ex As Exception
            Return LetraDefault
        End Try
    End Function
    ''' <summary>
    ''' 'Función para abrir un archivo de excel, y pasar una lista de relojes a un arreglo
    ''' tomando la primer columna, de la primer hoja
    ''' </summary>
    ''' <param name="Archivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExcelTOArrayList(ByVal Archivo As String, Optional UltimaColumna As String = "B") As String(,)

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim arRango(,) As String
        Dim x As Integer
        Dim y As Integer
        Try
            xlApp.Workbooks.Open(Archivo)
            xlWorkBook = xlApp.ActiveWorkbook

            Dim lastrow As Excel.Range = xlApp.Rows.End(Excel.XlDirection.xlDown)
            Dim myRange As Excel.Range
            myRange = xlApp.Range("A1:" & UltimaColumna & lastrow.Row)

            Dim myArray As Object(,)
            myArray = myRange.Value

            'El arreglo myRange es a partir de 1, 
            'el arreglo myArray, inicia en 0
            If myArray(1, 1).ToString.ToLower = "reloj" Then
                'Si tiene encabezado, reducir 1 por la diferencia, más el del encabezado
                y = 2
            Else
                'Si no hay encabezado, solo reducir 1
                y = 1
            End If

            ReDim arRango(3, lastrow.Row - y)
            For x = y To lastrow.Row
                arRango(1, x - y) = myArray(x, 1)
                arRango(2, x - y) = myArray(x, 2)
                arRango(3, x - y) = myArray(x, 3)
            Next

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            Return arRango
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ObtenerSFID(reloj As String) As String
        Dim sf_id As String = "NA"
        Dim dtSF As DataTable = sqlExecute("select * from sf_hirings where reloj = '" & reloj & "'")
        If dtSF.Rows.Count > 0 Then
            sf_id = IIf(IsDBNull(dtSF.Rows(0)("sf_id")), "NA", dtSF.Rows(0)("sf_id"))
        End If
        Return sf_id.Trim
    End Function

    Public Function ObtenerReloj(sf_id As String) As String
        Dim reloj As String = "NA"
        Dim dtSF As DataTable = sqlExecute("select * from sf_hirings where sf_id = '" & sf_id & "'")
        If dtSF.Rows.Count > 0 Then
            reloj = IIf(IsDBNull(dtSF.Rows(0)("reloj")), "NA", dtSF.Rows(0)("reloj"))
        End If
        Return reloj.Trim
    End Function
    Public Sub HrsExtrasMiscelaneos(ByVal IDKey As String, ByVal Concepto As String, ByVal Tipo_periodo As String, ByVal FechaIncidencia As Date, ByVal R As String, ByVal Horas As Double, ByVal _AnoPer As String)

        Dim andtAjustes As New DataTable
        Dim andtPerQ As New DataTable
        Dim andtMovs As New DataTable
        Dim andtAist As New DataTable 'AOS --> Obtener hrs extras autorizadas de la tabla de asistencia
        Dim valRegPrevio As New DataTable  'AOS --> Validar si hay al menos un registro previo en Ajustes Nomina Miscelaneos
        Dim Sem As String = ""
        Dim anDoblesAnt As Double = 0
        Dim anTriplesAnt As Double = 0
        Dim anHoras As Double = 0
        Dim numSem As String = "" 'AOS -->  Se agrega prefijo NumSemana
        Dim hrsExtAutStr As String = ""
        Dim hrsExtAut As Double = 0 'AOS -->Se agrega Var que contendrá las hrs extras autorizadas de su analisis de asistencia en TA.Asist
        Dim cantDig As Integer 'Para validar la cant de digitos de las horas extras autorizadas que vienen como string
        ' Dim RecPrevio As Boolean
        Dim TotHrsDblesAju As Double = 0
        Dim TotHrsTripAju As Double = 0

        anDobles = 0
        anTriples = 0
        anDoblesAnt = 0
        anTriplesAnt = 0
        hrsExtAut = 0
        anComentario = ""
        anPerS = ""
        anSem = ""
        numSem = ""
        hrsExtAutStr = ""

        Dim concepSem As String = "'HR2SE1','HR3SE1','HRS2AN','HRS2ANA','HRS2ANB','HRS2ANC','HRS3AN','HRS3ANA','HRS3ANB','HRS3ANC'"
        Dim concepQuin As String = "'HR2SE1','HR2SE2','HR2SE3','HR3SE1','HR3SE2','HR3SE3','HRS2AN','HRS3AN','HRS2ANA','HRS2ANB','HRS2ANC','HRS3ANA','HRS3ANB','HRS3ANC'"

        '--------------PERIODO SEMANAL
        If Tipo_periodo = "S" Then 'Periodo semanal
            anPerS = ObtenerAnoPeriodo(FechaIncidencia, Tipo_periodo) 'AOS-->Obtiene el anio y periodo a partir de la fecha de incidencia que estes capturando en esta pantalla de AJ NOM Miscelaneos, ejemplo= 201834

            '--Obtener T.E pagado anterior en MOVIMIENTOS, en base a la fecha de incidencia que se está capturando, va a buscar si hay un pago por TE en esa semana
            andtMovs = sqlExecute("SELECT ISNULL(monto,0) AS monto,concepto FROM movimientos where per_calendario='" & anPerS.Trim & "' and RELOJ='" & R.Trim & "' and tipo_periodo='" & Tipo_periodo.Trim & "' " & _
                                  "AND CONCEPTO IN(" & concepSem & ")", "NOMINA")

            '--Obtener las horas dobles y triples que ya se pagaron anteriormente, que esta en la tabla MOVIMIENTOS
            If (Not andtMovs.Columns.Contains("ERROR") And andtMovs.Rows.Count > 0) Then
                For Each dr As DataRow In andtMovs.Rows
                    Dim _concSem As String = IIf(IsDBNull(dr("Concepto")), "", dr("Concepto"))
                    Dim _monto As Double = IIf(IsDBNull(dr("monto")), 0, Double.Parse(dr("monto")))
                    Select Case _concSem.Trim
                        Case "HR2SE1", "HRS2AN", "HRS2ANA", "HRS2ANB", "HRS2ANC"
                            anDoblesAnt = anDoblesAnt + _monto
                        Case "HR3SE1", "HRS3AN", "HRS3ANA", "HRS3ANB", "HRS3ANC"
                            anTriplesAnt = anTriplesAnt + _monto
                    End Select
                Next
            End If

            '--Obtener todo el tiempo de hrs dobles y triples que tiene ese empleado en ajustes_nom en esa semana calendario, sumado lo que tiene y si le estamos ingresando nuevos registros, que tambien los vaya sumando, en base a la fecha de incidencia,
            andtAjustes = sqlExecute("SELECT sum(HRS_DOBLES) as hrs_dobles,SUM(hrs_triples) AS hrs_triples  from ajustes_nom WHERE reloj ='" & R & "'" & _
                             " AND ANO+PERIODO='" & _AnoPer & "' AND semana_pago LIKE'%" & anPerS & "%' AND CONCEPTO IN ('HRSEXA','HRSEXT') AND tipo_periodo = '" & Tipo_periodo & "'", "NOMINA")
            '************************ENDS

        ElseIf Tipo_periodo = "Q" Then 'Periodo Quincenal
            anPerS = ObtenerAnoPeriodo(FechaIncidencia, "S") '-Obtener ano+per de la fecha de pago en base a calendario semanal

            anDoblesAnt = 0
            anTriplesAnt = 0
            TotHrsDblesAju = 0
            TotHrsTripAju = 0

            '--Obtener TE Pagado anterior registrado en Movimientos
            andtMovs = sqlExecute("SELECT ISNULL(monto,0) AS monto,concepto FROM movimientos where per_calendario='" & anPerS.Trim & "' and RELOJ='" & R.Trim & "' and tipo_periodo='" & Tipo_periodo.Trim & "' " & _
                                 "AND CONCEPTO IN(" & concepQuin & ")", "NOMINA")

            '-Obtener Horas dobles y triples anteriores que ya se pagaron y que estan en MOVIMIENTOS
            If (Not andtMovs.Columns.Contains("ERROR") And andtMovs.Rows.Count > 0) Then
                For Each drQuin As DataRow In andtMovs.Rows
                    Dim _concSem As String = IIf(IsDBNull(drQuin("Concepto")), "", drQuin("Concepto"))
                    Dim _monto As Double = IIf(IsDBNull(drQuin("monto")), 0, Double.Parse(drQuin("monto")))
                    Select Case _concSem.Trim
                        Case "HR2SE1", "HR2SE2", "HR2SE3", "HRS2AN", "HRS2ANA", "HRS2ANB", "HRS2ANC"
                            anDoblesAnt = anDoblesAnt + _monto
                        Case "HR3SE1", "HR3SE2", "HR3SE3", "HRS3AN", "HRS3ANA", "HRS3ANB", "HRS3ANC"
                            anTriplesAnt = anTriplesAnt + _monto
                    End Select
                Next
            End If

            andtPerQ = sqlExecute("SELECT CASE '" & anPerS & "' WHEN sem1 THEN 'SE1' WHEN sem2 THEN 'SE2' WHEN sem3 THEN 'SE3' " & _
                                "ELSE 'NO_LOCALIZADO' END AS CONCEPTO " & _
                                "FROM periodos_quincenal WHERE periodo_especial=0 AND '" & FechaIncidencia & _
                                "' BETWEEN fecha_ini_incidencia AND fecha_fin_incidencia AND (sem1 = '" & anPerS & _
                                "' or sem2 ='" & anPerS & "' or sem3 = '" & anPerS & "')", "TA")

            If andtPerQ.Rows.Count > 0 Then
                anSem = andtPerQ.Rows(0)(0)
            End If

            'AOS --> Add el numero de la semana al anio y al periodo, ejemplo: 201812_SEM1
            If (anSem.Length > 0) Then
                numSem = numSem & "_" & anSem
            End If

            '---Que busque los ajustes de movimientos solo del periodo en el que se está capturando en el momento, ya que los periodos anteriores ya se pagaron en Movimientos
            andtAjustes = sqlExecute("SELECT sum(HRS_DOBLES) as hrs_dobles,SUM(hrs_triples) AS hrs_triples  from ajustes_nom WHERE reloj ='" & R & "'" & _
                                     " AND ANO+PERIODO='" & _AnoPer & "' AND semana_pago='" & anPerS & numSem & "' AND CONCEPTO IN ('HRSEXA','HRSEXT') AND tipo_periodo = '" & Tipo_periodo & "'", "NOMINA")

        End If

        'AOS**********Sumar la diferencia de los registros nuevos que se vayan insertando en ajustes nom para esa fecha, por ejemplo, si ya teniamos 6 hrs pagadas en MOVIMIENTOS, y agregamos recientemente un registro de 3 horas, el total nos daría = 9,
        'entonces como el total son 9, y es mayor a lo que teniamos en mov, que  eran 6, entonces las horas dobles anteriores = 9, y estas 3 hrs que estamos insertando nuevas, ya se deben de ir para triples
        TotHrsDblesAju = IIf(IsDBNull(andtAjustes.Rows(0)("hrs_dobles")), 0, andtAjustes.Rows(0)("hrs_dobles")) '-Por ejemplo el total serian 9
        TotHrsTripAju = IIf(IsDBNull(andtAjustes.Rows(0)("hrs_triples")), 0, andtAjustes.Rows(0)("hrs_triples"))


        anDoblesAnt = IIf((anDoblesAnt + TotHrsDblesAju) <= 9, anDoblesAnt + TotHrsDblesAju, 9) '--Total de horas dobles entre lo pagado en per anteriores (MOVIMIENTOS) y los ajustes hechos del periodo a pagar (AJUSTES_NOM) nunca pasando de 9 horas
        anTriplesAnt = anTriplesAnt + TotHrsTripAju '--Total de horas triples entre lo pagado en per anteriores (MOVIMIENTOS) y los ajustes hechos del periodo a pagar (AJUSTES_NOM)

        '**********ENDS

        'AOS*********Evalua cuantas son dobles y triples finalmente, la variable "Horas" es la que que trae la cantidad que se ingresó en esta pantalla
        ' If anDoblesAnt + Horas + IIf(RecPrevio = False, hrsExtAut, 0) > 9 Then
        If (anDoblesAnt + Horas) > 9 Then
            anDobles = 9 - anDoblesAnt
            If anDobles < 0 Then anDobles = 0
            anTriples = Horas - anDobles
        Else
            anDobles = Horas
        End If
        '**********ENDS
        anComentario = "Hrs. dobles: " & Math.Round(anDobles, 2) & "; Hrs. triples: " & Math.Round(anTriples, 2)

    End Sub
    Public Function SaldosVacacionesQRO(ByVal fechaproy As Date) As DataTable
        Dim query = "" & _
             "WITH L0 AS ( " & _
             "   select " & _
             "      va.reloj, " & _
             "      va.nombres, " & _
             "      va.cod_tipo, " & _
             "      va.alta, " & _
             "      alta_antiguedad, " & _
             "      sueldo, " & _
             "      saldo_final as saldo_inicial, " & _
             "      DATEADD(dd,1,periodo_fin) as periodo_inicio, " & _
             "      CAST('" & FechaSQL(fechaproy) & "' AS date) as periodo_fin, " & _
             "      periodo_antiguedad + 1 as periodo_antiguedad, " & _
             "      case when exists (select top 1 dias from vac_especiales where vac_especiales.reloj = va.reloj and anos = periodo_antiguedad + 1) then (select top 1 dias from vac_especiales where vac_especiales.reloj = va.reloj and anos = periodo_antiguedad + 1) " & _
             "            else (select top 1 dias from vacaciones where cod_tipo = va.COD_TIPO and anos = va.periodo_antiguedad + 1) end as periodo_corresponden, " & _
             "      datediff(dd,DATEADD(dd,1,periodo_fin),'" & FechaSQL(fechaproy) & "') + 1 as periodo_dias, " & _
             "      ROW_NUMBER() OVER(PARTITION BY va.reloj ORDER BY periodo_inicio DESC) AS RowNum " & _
             "   from vac_aniversarios va " & _
             "        join personal p " & _
             "        on va.reloj = p.reloj " & _
             "        and (p.inactivo = 0 or p.inactivo is null) " & _
             "), " & _
             "L1 AS ( " & _
             "    select *, " & _
             "          cast((CAST(periodo_corresponden AS DECIMAL(5,2)) /365) * periodo_dias AS DECIMAL(5,2)) as periodo_proporcion, " & _
             "          coalesce((select count(a.reloj) " & _
             "		            from ta.dbo.ausentismo a " & _
             "		            where a.fecha between L0.periodo_inicio and L0.periodo_fin and a.tipo_aus='VAC' and a.reloj = L0.reloj " & _
             "		            group by a.reloj),0) as dias_tomados " & _
             "    from L0 where RowNum = 1 " & _
             ") " & _
             "select reloj,nombres,cod_tipo,alta,alta_antiguedad,sueldo,saldo_inicial,periodo_inicio,periodo_fin,periodo_antiguedad,periodo_dias,periodo_corresponden,periodo_proporcion,dias_tomados, " & _
             "   saldo_inicial + periodo_proporcion - dias_tomados as saldo_final " & _
             "from L1"

        Dim dtTemp As DataTable = sqlExecute(query)

        Dim query2 As String = "" & _
            "with L0 as ( " & _
            "select reloj, " & _
            "    rtrim(apaterno) + ', ' + rtrim(amaterno) + ', ' + rtrim(nombre) as nombres, " & _
            "    cod_tipo, " & _
            "    alta, " & _
            "    coalesce((CASE WHEN month(alta_vacacion) = 2 and day(alta_vacacion) = 29 then DATEADD(day,-1,alta_vacacion) else  alta_vacacion end),alta) AS ALTA_ANTIGUEDAD, " & _
            "    sactual as SUELDO, " & _
            "    coalesce((select DIAS from vac_inicial where reloj = personal.reloj),0) as saldo_inicial, " & _
            "    alta as periodo_inicio, " & _
            "    CAST('" & FechaSQL(fechaproy) & "' AS date) as periodo_fin " & _
            "from personal " & _
            "where baja is null and datediff(dd,alta,'" & FechaSQL(fechaproy) & "')<365 and (inactivo = 0 or inactivo is null)  and not exists(select reloj from vac_aniversarios where reloj = personal.reloj) " & _
            "), " & _
            "L1 as ( " & _
            "select *, " & _
            "    year(periodo_fin) - year(alta_antiguedad) as periodo_antiguedad " & _
            "from L0 " & _
            "), " & _
            "L2 as ( " & _
            "    select *, " & _
            "    datediff(dd,periodo_inicio,periodo_fin) + 1 as PERIODO_DIAS, " & _
            "    case when exists (select top 1 dias from vac_especiales where vac_especiales.reloj = L1.reloj and anos = periodo_antiguedad + 1) then (select top 1 dias from vac_especiales where vac_especiales.reloj = L1.reloj and anos = periodo_antiguedad + 1) " & _
            "         else (select top 1 dias from vacaciones where cod_tipo = L1.COD_TIPO and anos = periodo_antiguedad + 1) end as periodo_corresponden " & _
            "from L1 " & _
            "), " & _
            "L3 as ( " & _
            "select *, " & _
            "    cast((CAST(periodo_corresponden AS DECIMAL(5,2)) /365) * periodo_dias AS DECIMAL(5,2)) as periodo_proporcion, " & _
            "    coalesce((select count(a.reloj) " & _
            "		            from ta.dbo.ausentismo a " & _
            "		            where a.fecha between periodo_inicio and periodo_fin and a.tipo_aus='VAC' and a.reloj = L2.reloj " & _
            "		            group by a.reloj),0) as dias_tomados " & _
            "from L2 " & _
            ") " & _
            "select *, " & _
            "    SALDO_INICIAL + PERIODO_PROPORCION  - DIAS_TOMADOS as SALDO_FINAL " & _
            "from L3 " & _
            "order by reloj"
        Dim dtTemp2 As DataTable = sqlExecute(query2)

        dtTemp.Merge(dtTemp2, False, MissingSchemaAction.Ignore)

        dtTemp.DefaultView.Sort = "reloj ASC"
        dtTemp = dtTemp.DefaultView.ToTable

        Return dtTemp
    End Function
    Public Sub bitacora_tiempo_extra(_reloj As String, _fecha As Date, _valor_nuevo As String)
        Try

            Dim _valor_anterior As String = "00:00"
            Dim _orden As Integer = 1

            Dim dtMasReciente As DataTable = sqlExecute("select * from bitacora_te where reloj = '" & _reloj & "' and fecha = '" & FechaSQL(_fecha) & "' order by fecha_hora desc", "ta")
            If dtMasReciente.Rows.Count > 0 Then
                _valor_anterior = dtMasReciente.Rows(0)("valor_nuevo")
                _orden = dtMasReciente.Rows(0)("orden")
                _orden += 1
            End If

            sqlExecute("insert into bitacora_te (reloj, fecha, valor_anterior, valor_nuevo, usuario, fecha_hora, orden) values ('" & _reloj & "', '" & FechaSQL(_fecha) & "', '" & _valor_anterior & "', '" & _valor_nuevo & "', '" & Usuario & "', getdate(), '" & _orden & "')", "ta")

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    '== Se agrego nuevo parametro       11junio2021     Ernesto
    Public Sub ProcInsDiasVaAjNom(ByVal Reloj As String, DiasVa As Double, FiniPag As Date, FFinPag As Date, Optional tipoPer As String = "", Optional ByVal periodo_pago_nomina As String = "", Optional ByVal Comentario As String = "")
        Dim anio1 As String = "", per1 As String = "", fini1 As String = "", ffin1 As String = "", cantDias1 As Integer = 0
        Dim anio2 As String = "", per2 As String = "", fini2 As String = "", ffin2 As String = "", cantDias2 As Integer = 0
        Dim ClaveVa = "006"
        If Comentario = "" Then Comentario = "Días de vacaciones capturados desde MAESTRO"


        Dim EvaluaVariosPer As Boolean = False
        Dim dtFestivos As DataTable = sqlExecute("select * from FESTIVOS ", "TA")
        Dim _ano_pago_nom As String = "", _per_pago_nom As String = ""

        '----Obtener el periodo de pago para la nómina
        If periodo_pago_nomina.Trim <> "" And Len(periodo_pago_nomina.Trim) = 6 Then
            _ano_pago_nom = periodo_pago_nomina.Substring(0, 4)
            _per_pago_nom = periodo_pago_nomina.Substring(4, 2)
        End If

        '---Se agregó la fecha de inicio y fin de las vacaciones en el campo de ajustes_nom llamado "numcredito con fines informativos      30/ene/21   Ernesto
        Dim cadenaVac As String
        cadenaVac = FechaSQL(FiniPag) & " al " & FechaSQL(FFinPag)

        Try
            '== Aqui se seleccciona el periodo correcto de acuerdo al tipo de nomina del empleado(solo catorcenales)       11junio2021     Ernesto
            Dim dtPerFIni As DataTable : Dim dtPerFFin As DataTable
            If tipoPer = "C" Then
                dtPerFIni = sqlExecute("select * from ta.dbo.periodos_catorcenal where isnull(PERIODO_ESPECIAL,0)=0  and fecha_ini<='" & FechaSQL(FiniPag) & "' and FECHA_FIN>='" & FechaSQL(FiniPag) & "'")
                dtPerFFin = sqlExecute("select * from ta.dbo.periodos_catorcenal where isnull(PERIODO_ESPECIAL,0)=0  and fecha_ini<='" & FechaSQL(FFinPag) & "' and FECHA_FIN>='" & FechaSQL(FFinPag) & "'")
            Else
                dtPerFIni = sqlExecute("select * from periodos where PERIODO_ESPECIAL=0 and fecha_ini<='" & FechaSQL(FiniPag) & "' and FECHA_FIN>='" & FechaSQL(FiniPag) & "'", "TA")
                dtPerFFin = sqlExecute("select * from periodos where PERIODO_ESPECIAL=0 and fecha_ini<='" & FechaSQL(FFinPag) & "' and FECHA_FIN>='" & FechaSQL(FFinPag) & "'", "TA")
            End If
            '==

            If (Not dtPerFIni.Columns.Contains("Error") And dtPerFIni.Rows.Count > 0) Then
                Try : anio1 = dtPerFIni.Rows(0).Item("ANO").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try

                '== Aqui se evalua si es tipo catorcenal igualmente para obtener el periodo correcto    11junio2021     Ernesto
                Try : per1 = dtPerFIni.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                If tipoPer = "C" Then
                    per1 = PeriodoReal(per1, anio1)
                End If

                Try : fini1 = FechaSQL(dtPerFIni.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fini1 = "" : End Try
                Try : ffin1 = FechaSQL(dtPerFIni.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : ffin1 = "" : End Try
            End If

            If (Not dtPerFFin.Columns.Contains("Error") And dtPerFFin.Rows.Count > 0) Then
                Try : anio2 = dtPerFFin.Rows(0).Item("ANO").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try

                '== Aqui se evalua si es tipo catorcenal igualmente para obtener el periodo correcto    11junio2021     Ernesto
                Try : per2 = dtPerFFin.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                If tipoPer = "C" Then
                    per2 = PeriodoReal(per2, anio2)
                End If

                Try : fini2 = FechaSQL(dtPerFFin.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fini2 = "" : End Try
                Try : ffin2 = FechaSQL(dtPerFFin.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : ffin2 = "" : End Try
            End If

            If (per1 = per2) Then EvaluaVariosPer = False

            If (per1 <> per2) Then EvaluaVariosPer = True

            If _ano_pago_nom.Trim <> "" Then
                anio1 = _ano_pago_nom
                anio2 = _ano_pago_nom
                per1 = _per_pago_nom
                per2 = _per_pago_nom
            End If

            If (Not EvaluaVariosPer) Then ' Si solo va evaluar un solo periodo
                While FiniPag <= FFinPag

                    If (dtFestivos.Select("DIA_FESTIV='" & FechaSQL(FiniPag) & "'").Count > 0) Then ' Evaluar si cae en día festivo
                        GoTo NextRecord
                    End If

                    cantDias1 += 1
NextRecord:
                    FiniPag = FiniPag.AddDays(1)
                End While

                '---Se agregó la fecha de inicio y fin de las vacaciones en el campo de ajustes_nom llamado "numcredito con fines informativos      30/ene/21   Ernesto
                Dim QInsert As String = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha,numcredito) VALUES " & _
    "('" & Reloj & "','" & anio1 & "','" & per1 & "','P','" & ClaveVa & "'," & cantDias1 & ",'" & Comentario & "','DIASVA','" & Usuario & "','" & FechaSQL(FFinPag) & "'," & "'" & cadenaVac & "')"
                sqlExecute(QInsert, "NOMINA")
            End If

            cantDias1 = 0
            cantDias2 = 0
            If (EvaluaVariosPer) Then 'Evaluar para más de 1 periodo, recorrer cada uno de los días de vacaciones, partiendo del primer dia de pago
                While FiniPag <= ffin1 '- Evaluar 1er periodo
                    If (dtFestivos.Select("DIA_FESTIV='" & FechaSQL(FiniPag) & "'").Count > 0) Then ' Evaluar si cae en día festivo
                        GoTo SigDia
                    End If

                    Dim dia_sem As Integer = FiniPag.DayOfWeek
                    If (dia_sem = 6 Or dia_sem = 0) Then GoTo SigDia ' Si cae Sabado o Domingo no tomarlo en cuenta

                    cantDias1 += 1
SigDia:
                    FiniPag = FiniPag.AddDays(1)
                End While

                '---Se agregó la fecha de inicio y fin de las vacaciones en el campo de ajustes_nom llamado "numcredito con fines informativos      30/ene/21   Ernesto
                '---Insertar en Ajustes_nom los dias para el anio y per correspondiente (periodo presente)
                Dim Q1 As String = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha,numcredito) VALUES " & _
                    "('" & Reloj & "','" & anio1 & "','" & per1 & "','P','" & ClaveVa & "'," & cantDias1 & ",'" & Comentario & "','DIASVA','" & Usuario & "','" & FechaSQL(FFinPag) & "'," & "'" & cadenaVac & "')"
                sqlExecute(Q1, "NOMINA")

                '--Evaluar el 2do Periodo
                Dim FiniPer2 As Date = Date.Parse(fini2)
                While FiniPer2 <= FFinPag ' Partimos a partir de la fec inicial del 2do periodo hasta la fecha fin de pago de los dias de vacaciones

                    If (dtFestivos.Select("DIA_FESTIV='" & FechaSQL(FiniPer2) & "'").Count > 0) Then ' Evaluar si cae en día festivo
                        GoTo SigDia2
                    End If

                    Dim dia_sem As Integer = FiniPer2.DayOfWeek
                    If (dia_sem = 6 Or dia_sem = 0) Then GoTo SigDia2 ' Si cae Sabado o Domingo no tomarlo en cuenta

                    cantDias2 += 1

SigDia2:
                    FiniPer2 = FiniPer2.AddDays(1)
                End While

                '-- Evaluar si faltaron dias de pagar para registrarselos en el 2do Periodo que esté
                Dim TotCantDias As Double = cantDias1 + cantDias2
                Dim DiasFaltan As Double = DiasVa - TotCantDias
                If (DiasFaltan > 0) Then cantDias2 += DiasFaltan

                '---Se agregó la fecha de inicio y fin de las vacaciones en el campo de ajustes_nom llamado "numcredito con fines informativos      30/ene/21   Ernesto
                '---Insertar en Ajustes_nom los dias para el anio y per correspondiente (siguiente periodo)
                Dim Q2 As String = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha,numcredito) VALUES " & _
                    "('" & Reloj & "','" & anio2 & "','" & per2 & "','P','" & ClaveVa & "'," & cantDias2 & ",'" & Comentario & "','DIASVA','" & Usuario & "','" & FechaSQL(FFinPag) & "'," & "'" & cadenaVac & "')"
                sqlExecute(Q2, "NOMINA")
            End If


        Catch ex As Exception

        End Try
    End Sub

    '==Funcion para determinar el periodo correcto (en caso de los catorcenales)        11Junio2021     Ernesto
    Private Function PeriodoReal(periodo As String, anio As String) As String
        Try
            Dim dtPeriodo As DataTable
            dtPeriodo = sqlExecute("select * from ta.dbo.periodos where ano='" & anio & "' and isnull(PERIODO_ESPECIAL,0)=0 and NOMBRE='" & periodo & "'")
            If dtPeriodo.Rows.Count > 0 Then
                Return dtPeriodo.Rows(0)("periodo").ToString.Trim
            End If
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '== Dia de la semana letra      11junio2021     Ernesto
    Public Function DiaSemanaLetra(dia As String) As String
        Select Case dia
            Case "1"
                Return "Lunes"
            Case "2"
                Return "Martes"
            Case "3"
                Return "Miércoles"
            Case "4"
                Return "Jueves"
            Case "5"
                Return "Viernes"
            Case "6"
                Return "Sábado"
            Case "7"
                Return "Domingo"
        End Select
    End Function
    '==

    Public Function ValCamposVacios(ByVal C1 As String, ByVal NC1 As String, Optional C2 As String = "", Optional NC2 As String = "", Optional C3 As String = "", Optional NC3 As String = "",
                                    Optional C4 As String = "", Optional NC4 As String = "", Optional C5 As String = "", Optional NC5 As String = "", Optional C6 As String = "",
                                    Optional NC6 As String = "", Optional C7 As String = "", Optional NC7 As String = "", Optional C8 As String = "", Optional NC8 As String = "",
                                    Optional C9 As String = "", Optional NC9 As String = "", Optional C10 As String = "", Optional NC10 As String = "") As String
        Dim Mensaje As String = ""
        Try
            If (C1.Trim = "" And NC1.Trim <> "") Then
                Mensaje = "--" & NC1
            ElseIf (C2.Trim = "" And NC2.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC2
            ElseIf (C3.Trim = "" And NC3.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC3
            ElseIf (C4.Trim = "" And NC4.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC4
            ElseIf (C5.Trim = "" And NC5.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC5
            ElseIf (C6.Trim = "" And NC6.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC6
            ElseIf (C7.Trim = "" And NC7.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC7
            ElseIf (C8.Trim = "" And NC8.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC8
            ElseIf (C9.Trim = "" And NC9.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC9
            ElseIf (C10.Trim = "" And NC10.Trim <> "") Then
                Mensaje &= vbCrLf & "--" & NC10
            End If
            Return Mensaje
        Catch ex As Exception
            Return Mensaje
        End Try
    End Function

    Public Function validaFecha(ByRef _fecha As String) As Boolean 'Validar que la fecha venga en formato: 2018-12-01
        Try
            If (_fecha = "") Then 'A) Que no venga Vacía:
                Return False
            ElseIf (_fecha.Length <> 10) Then ' B) Que sean 10 dígitos 
                Return False
            ElseIf (_fecha.Substring(4, 1) <> "-") Then 'C) Que en la 4ta posicion tenga un "-"
                Return False
            ElseIf (_fecha.Substring(7, 1) <> "-") Then 'D) Que en la 7ta posicion tenga un "-"
                Return False
            ElseIf (Not validaAno(_fecha.Substring(0, 4))) Then 'E) Que el año sea igual al actual o mayor 1 año máximo
                Return False
            ElseIf (Not validaMes(_fecha.Substring(5, 2))) Then 'F) Que el mes sea válido esté dentro del 1 al 12
                Return False
            ElseIf (Not validaDia(_fecha.Substring(0, 4), _fecha.Substring(5, 2), _fecha.Substring(8, 2))) Then 'G)Validar que el dia sea correcto
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function validaAno(ByRef _ano As String) As Boolean
        Try
            If (_ano <> "") Then
                Dim Anio As Integer = Convert.ToInt32(_ano.ToString.Trim)
                Dim Anio_Actual As Integer = Convert.ToInt32(Now.Date.Year.ToString.Substring(0, 4))
                '--Solo si el año es igual al actual o un año mayor al actual solo es válido
                If ((Anio = Anio_Actual) Or (Anio_Actual + 1 >= Anio)) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validaMes(ByRef _mes As String) As Boolean
        Try
            If (_mes <> "") Then
                Dim Mes As Integer = Convert.ToInt32(_mes.ToString.Trim)
                If (Mes >= 1 And Mes <= 12) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function validaDia(ByRef _ano As String, ByRef _mes As String, ByRef _dia As String) As Boolean
        Try
            If (_ano <> "" And _mes <> "" And _dia <> "") Then
                Dim Anio As Integer = Convert.ToInt32(_ano.ToString.Trim)
                Dim Mes As Integer = Convert.ToInt32(_mes.ToString.Trim)
                Dim Dia As Integer = Convert.ToInt32(_dia.ToString.Trim)
                Dim EsBisiesto As Integer = Anio Mod 4
                If ((Mes >= 1 And Mes <= 12) And (Dia >= 1 And Dia <= 31)) Then
                    Select Case Mes
                        Case 2 ' Feb
                            If (Dia = 29 And EsBisiesto <> 0) Or (Dia >= 30) Then '--Valida si es año bisiesto o no
                                Return False
                            End If
                        Case 4, 6, 9, 11 ' Abril, Jun, Sept, Nov
                            If (Dia >= 31) Then
                                Return False
                            End If
                        Case 1, 3, 5, 7, 8, 10, 12 ' Ene, Mar,May,Jul,Ago,Oct,Dic
                            If (Dia < 1 Or Dia > 31) Then
                                Return False
                            End If
                        Case Else
                            Return False
                    End Select
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    '==FUNCION PARA REVISAR LOS PERFILES Y APLICAR LOS BLOQUEOS     Ernesto     modificada dic2021
    Public Function revisarPerfiles(perfilDetalle As String, frmControl As Form, varEditar As Boolean, Optional ByVal cia As String = "", Optional reloj_empleado As String = "")

        Dim excepciones As String
        Dim dtTabla As DataTable
        Dim cont As Integer = 0
        Dim varBoolean As Boolean = varEditar
        Dim ctrlNombre As String
        Dim BuscarControl As Control = Nothing
        Dim usuarioPerfil As String = ""

        Try
            'De acuerdo a la compañia
            Select Case cia
                Case "CIA" ' Aplicar para cualquier cia que no pueda visualizar ciertos botones
                    If perfilDetalle.Contains("SUPERV") Then
                        usuarioPerfil = "SUPERV"
                        'ElseIf perfilDetalle.Contains("GER_AREA") Then
                        '    usuarioPerfil = "GER_AREA"
                        'ElseIf perfilDetalle.Contains("SYS") Then
                        '    usuarioPerfil = "SYS"
                        'ElseIf perfilDetalle.Contains("GERENTE_MEDICO") Then
                        '    usuarioPerfil = "GERENTE_MEDICO"
                        'ElseIf perfilDetalle.Contains("SERV_MED") Then
                        '    usuarioPerfil = "SERV_MED"
                        'ElseIf perfilDetalle.Contains("LIDER") Then
                        '    usuarioPerfil = "LIDER"
                        'ElseIf perfilDetalle.Contains("ASIST") Then
                        '    usuarioPerfil = "ASIST"
                    End If

                    If perfilDetalle.Contains("CONTABILIDAD") Then
                        usuarioPerfil = "CONTABILIDAD"
                    End If

                    'De acuerdo al perfil seleccionado
                    Select Case usuarioPerfil
                        'Para perfil de usuario supervisor y gerencia de area, permitir editar solo el horario en frmMaestro  
                        Case usuarioPerfil

                            If usuarioPerfil.Contains("CONTABILIDAD") Then
                                '==============================TA (Activar o desactivar botones)
                                'Caso especia: Para los tabs de TA: filtros activos,historial en horas en bruto,registros de cafeteria,excepciones de horario
                                frmReporteador.btnNuevo.Enabled = False : frmReporteador.btnNuevo.Visible = False
                                frmTA.tabFiltros.Enabled = False : frmTA.tabFiltros.Visible = False
                                frmTA.tabHistorialHrsBrt.Enabled = False : frmTA.tabHistorialHrsBrt.Visible = False
                                frmTA.tabRegistrosCafeteria.Enabled = False : frmTA.tabRegistrosCafeteria.Visible = False
                                frmTA.tabExcepcionhrs.Enabled = False : frmTA.tabExcepcionhrs.Visible = False
                                frmTA.chkPares.Enabled = False : frmTA.chkPares.Visible = False
                                frmTA.cbBitacora.Enabled = False : frmTA.cbBitacora.Visible = False
                                frmTA.chkNotaUsuario.Enabled = False : frmTA.chkNotaUsuario.Visible = False
                                frmTA.ButtonX3.Enabled = False : frmTA.ButtonX3.Visible = False
                                ' frmTA.tabAusentismo.Enabled = False : frmTA.tabAusentismo.Visible = False
                                frmTA.gpPrimaDS.Enabled = False : frmTA.gpPrimaDS.Visible = False
                                frmReporteadorTA.btnNuevo.Enabled = False : frmReporteadorTA.btnNuevo.Visible = False
                                frmTA.txtHrsFel.Enabled = False
                                frmTA.txtHrsTriples.Enabled = False
                                frmTA.txtHrsDobles.Enabled = False
                                frmTA.txtHorasExtras.Enabled = False
                            End If

                            'Si el perfil es supervisor, gerente o lider
                            If usuarioPerfil.Contains("SUPERV") Or usuarioPerfil.Contains("GER_AREA") Or usuarioPerfil.Contains("LIDER") Or usuarioPerfil.Contains("ASIST") Then

                                'Consulta los controles para el perfil deseado
                                excepciones = "Select nombre_control, visible+habilitado as Disponible from excepciones where cod_perfil='" & usuarioPerfil & _
                                    "' and nombre_forma='" & frmControl.Name & "'"
                                dtTabla = sqlExecute(excepciones, "SEGURIDAD")

                                'Determinar propiedades de acuerdo al perfil
                                For Each x As DataRow In dtTabla.Rows
                                    'Buscar en frmMaestro, si existe, entonces deshabilitarlo o habilitarlo
                                    ctrlNombre = x.Item("nombre_control").ToString.Trim
                                    If frmControl.Controls.Find(ctrlNombre, True).Count > 0 Then
                                        BuscarControl = frmControl.Controls.Find(ctrlNombre, True)(0)
                                        If Not BuscarControl Is Nothing Then
                                            If x.Item("Disponible") = 2 Then
                                                BuscarControl.Enabled = True
                                                BuscarControl.Visible = True
                                            ElseIf x.Item("Disponible") = 0 Then
                                                BuscarControl.Enabled = False
                                                BuscarControl.Visible = False
                                            End If

                                            'Para habilitar el boton de aceptar a modo, de acuerdo al perfil
                                            If ctrlNombre = "btnNuevo" And varEditar Then
                                                BuscarControl.Enabled = True
                                                BuscarControl.Visible = True
                                            ElseIf ctrlNombre = "btnNuevo" And varEditar = False Then
                                                BuscarControl.Enabled = False
                                                BuscarControl.Visible = False
                                            End If
                                        End If
                                        cont += 1
                                    Else
                                        cont += 1
                                    End If
                                Next

                                '============================PERSONAL o RH (Activar o desactivar botones)
                                'Caso especial: Para los tabs de tipo DevComponents que no son detectados como tipo "Control"

                                frmMaestro.SuperTabItem1.Enabled = False : frmMaestro.SuperTabItem1.Visible = False
                                frmMaestro.tabBaja.Enabled = False : frmMaestro.tabBaja.Visible = False
                                frmMaestro.tabBeneficiarios.Enabled = False : frmMaestro.tabBeneficiarios.Visible = False
                                frmMaestro.tabComentarios.Enabled = False : frmMaestro.tabComentarios.Visible = False
                                frmMaestro.tabInfonavit.Enabled = False : frmMaestro.tabInfonavit.Visible = False
                                frmMaestro.tabTarjetas.Enabled = False : frmMaestro.tabTarjetas.Visible = False
                                frmReporteador.btnNuevo.Enabled = False : frmReporteador.btnNuevo.Visible = False


                                '==============================TA (Activar o desactivar botones)
                                'Caso especia: Para los tabs de TA: filtros activos,historial en horas en bruto,registros de cafeteria,excepciones de horario
                                frmTA.tabFiltros.Enabled = False : frmTA.tabFiltros.Visible = False
                                frmTA.tabHistorialHrsBrt.Enabled = False : frmTA.tabHistorialHrsBrt.Visible = False
                                frmTA.tabRegistrosCafeteria.Enabled = False : frmTA.tabRegistrosCafeteria.Visible = False
                                frmTA.tabExcepcionhrs.Enabled = False : frmTA.tabExcepcionhrs.Visible = False
                                frmTA.chkPares.Enabled = False : frmTA.chkPares.Visible = False
                                frmTA.cbBitacora.Enabled = False : frmTA.cbBitacora.Visible = False
                                frmTA.chkNotaUsuario.Enabled = False : frmTA.chkNotaUsuario.Visible = False
                                frmTA.ButtonX3.Enabled = False : frmTA.ButtonX3.Visible = False
                                frmTA.tabAusentismo.Enabled = False : frmTA.tabAusentismo.Visible = False
                                frmTA.gpPrimaDS.Enabled = False : frmTA.gpPrimaDS.Visible = False
                                frmReporteadorTA.btnNuevo.Enabled = False : frmReporteadorTA.btnNuevo.Visible = False
                                frmTA.txtHrsFel.Enabled = False
                                frmTA.txtHrsTriples.Enabled = False
                                frmTA.txtHrsDobles.Enabled = False
                                frmTA.txtHorasExtras.Enabled = False

                                'Si se llega hasta esta instancia y todos los controles del perfil están a disposición de utilizarse
                                If cont = dtTabla.Rows.Count Then
                                    If varEditar Then
                                        varBoolean = False
                                    End If
                                Else
                                    varBoolean = varEditar
                                End If
                            End If

                            '--Si son de sistemas
                            If usuarioPerfil.Contains("SYS") Or usuarioPerfil.Contains("SERV_MED") Then
                                'Consulta los controles para el perfil deseado
                                excepciones = "Select nombre_control, visible+habilitado as Disponible from excepciones where cod_perfil='" & usuarioPerfil & _
                                    "' and nombre_forma='" & frmControl.Name & "'"
                                dtTabla = sqlExecute(excepciones, "SEGURIDAD")

                                'Obtener el nombre de los controles
                                For Each x As DataRow In dtTabla.Rows
                                    ctrlNombre = x.Item("nombre_control").ToString.Trim
                                    If frmControl.Controls.Find(ctrlNombre, True).Count > 0 Then
                                        BuscarControl = frmControl.Controls.Find(ctrlNombre, True)(0)
                                        If Not BuscarControl Is Nothing Then
                                            If x.Item("Disponible") = 0 Then
                                                BuscarControl.Enabled = False
                                                BuscarControl.Visible = False
                                            End If
                                        End If
                                    End If
                                Next

                                'Caso especial: Para los tabs de tipo DevComponents que no son detectados como tipo "Control"
                                frmMaestro.SuperTabItem1.Enabled = False : frmMaestro.SuperTabItem1.Visible = False
                                frmMaestro.tabBaja.Enabled = False : frmMaestro.tabBaja.Visible = False
                                frmMaestro.tabBeneficiarios.Enabled = False : frmMaestro.tabBeneficiarios.Visible = False
                                frmMaestro.tabComentarios.Enabled = False : frmMaestro.tabComentarios.Visible = False
                                frmMaestro.tabInfonavit.Enabled = False : frmMaestro.tabInfonavit.Visible = False
                                frmMaestro.tabTarjetas.Enabled = False : frmMaestro.tabTarjetas.Visible = False

                                'Caso especia: Para los tabs de TA: filtros activos,historial en horas en bruto,registros de cafeteria,excepciones de horario
                                frmTA.tabFiltros.Enabled = False : frmTA.tabFiltros.Visible = False
                                frmTA.tabHistorialHrsBrt.Enabled = False : frmTA.tabHistorialHrsBrt.Visible = False
                                frmTA.tabRegistrosCafeteria.Enabled = False : frmTA.tabRegistrosCafeteria.Visible = False
                                frmTA.tabExcepcionhrs.Enabled = False : frmTA.tabExcepcionhrs.Visible = False
                            End If

                            '==Si es perfil de gerente de servicios medicos     junio2021       Ernesto
                            If usuarioPerfil.Contains("GERENTE_MEDICO") Then
                                Dim ver As Boolean = False
                                excepciones = "SELECT p.reloj,s.COD_SUPER FROM PERSONAL.dbo.super s left join PERSONAL.dbo.personal p on p.COD_SUPER=s.COD_SUPER " & _
                                                     "where s.RELOJ in (select reloj from SEGURIDAD.dbo.appuser where USERNAME = '" & Usuario & "')"
                                dtTabla = sqlExecute(excepciones)
                                If dtTabla.Rows.Count > 0 Then
                                    For Each x As DataRow In dtTabla.Select("reloj = '" & reloj_empleado & "'")
                                        ver = True
                                    Next
                                    frmMaestro.gpSueldos.Visible = ver
                                    frmMaestro.tabVacaciones.Visible = ver
                                    frmMaestro.chkShowSalary.Visible = ver

                                    '==Solo se puede generar reportes de los empleados a su cargo en TA     29julio2021     ernesto
                                    frmTA.btnReporte.Visible = ver
                                    frmTA.btnReporte.Enabled = ver

                                    '==Visualizar vacaciones solo de su personal a cargo            2mayo2022       Ernesto
                                    frmMaestro.tabVacaciones.Visible = ver
                                End If

                                'Consulta los controles para el perfil deseado
                                excepciones = "Select nombre_control, visible+habilitado as Disponible from excepciones where cod_perfil='" & usuarioPerfil & _
                                    "' and nombre_forma='" & frmControl.Name & "'"
                                dtTabla = sqlExecute(excepciones, "SEGURIDAD")

                                'Obtener el nombre de los controles
                                For Each x As DataRow In dtTabla.Rows
                                    ctrlNombre = x.Item("nombre_control").ToString.Trim
                                    If frmControl.Controls.Find(ctrlNombre, True).Count > 0 Then
                                        BuscarControl = frmControl.Controls.Find(ctrlNombre, True)(0)
                                        If Not BuscarControl Is Nothing Then
                                            If x.Item("Disponible") = 0 Then
                                                BuscarControl.Enabled = False
                                                BuscarControl.Visible = False
                                            End If
                                        End If
                                    End If
                                Next

                                'Caso especial: Para los tabs de tipo DevComponents que no son detectados como tipo "Control"
                                frmMaestro.SuperTabItem1.Enabled = False : frmMaestro.SuperTabItem1.Visible = False
                                frmMaestro.tabBaja.Enabled = False : frmMaestro.tabBaja.Visible = False
                                frmMaestro.tabBeneficiarios.Enabled = False : frmMaestro.tabBeneficiarios.Visible = False
                                frmMaestro.tabComentarios.Enabled = False : frmMaestro.tabComentarios.Visible = False
                                frmMaestro.tabInfonavit.Enabled = False : frmMaestro.tabInfonavit.Visible = False
                                frmMaestro.tabTarjetas.Enabled = False : frmMaestro.tabTarjetas.Visible = False

                                'Caso especia: Para los tabs de TA: filtros activos,historial en horas en bruto,registros de cafeteria,excepciones de horario
                                frmTA.tabFiltros.Enabled = False : frmTA.tabFiltros.Visible = False
                                frmTA.tabHistorialHrsBrt.Enabled = False : frmTA.tabHistorialHrsBrt.Visible = False
                                frmTA.tabRegistrosCafeteria.Enabled = False : frmTA.tabRegistrosCafeteria.Visible = False
                                frmTA.tabExcepcionhrs.Enabled = False : frmTA.tabExcepcionhrs.Visible = False
                            End If

                            'Para casos de perfil generales
                        Case "GENERAL"
                            varBoolean = varEditar
                    End Select
            End Select
        Catch ex As Exception
            'Si se fracaso en algun punto o no es el perfil seleccionado
            varBoolean = varEditar
        End Try

        Return varBoolean

    End Function


    '== Función para actualizar los campos de la tabla reportes_Recientes de ta (estatus)               6oct2021
    Public Sub ActualizaEstatusTabla(NombreTabla As String, campo As String, valor As Date, Optional condicion As String = "")
        Try
            Dim qryCadena As String = ""
            qryCadena = "UPDATE " & NombreTabla & " SET " & campo & "='" & valor & "' " & condicion
            sqlExecute(qryCadena)
        Catch ex As Exception : End Try
    End Sub

    '== Registra los accesos a sistema PIDA             15oct2021
    Public Sub BitacoraSeguridad(ByVal perfil As String, tipo_cambio As String, tipo As String, nombre As String,
                                 ByVal usuario As String, fecha As Date, modificacion As String)
        Try
            Dim Qry As String = "INSERT INTO SEGURIDAD.dbo.bitacora_seguridad (PERFIL,TIPO_CAMBIO,TIPO,NOMBRE,USUARIO,FECHA,MODIFICACION_A) " & _
                                                "VALUES('" & perfil & "','" & tipo_cambio & "','" & tipo & "','" & nombre & "','" & usuario & "','" & fecha & "','" & modificacion & "')"
            sqlExecute(Qry)
        Catch ex As Exception

        End Try
    End Sub

    <Extension()>
    Public Function ToTitleCase(ByVal aString As String) As String
        If Not aString = Nothing Then
            If aString.Length >= 1 Then
                Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(aString)
            End If
        End If
        Return ""
    End Function

    Public Function CalcPrimaVacacional(ByVal rl As String, ByVal fAlta As Date, ByVal fVacs As Date, ByVal TipoEmp As String, ByVal CodComp As String, ByVal tipo_periodo As String) As Decimal

        Dim Resultado As Double = 0.0
        Dim dtVac As New DataTable

        Try

            Dim _aniv As New Date(fVacs.Year, fAlta.Month, fAlta.Day) ' Aniversario del anio a cumplir
            Dim _aniv_Ant As New Date(fVacs.Year - 1, fAlta.Month, fAlta.Day) ' Aniv del anio anterior si aplica
            Dim _anos As Integer = 0
            Dim AntigDias As Decimal = 0.0
            Dim _dias As Decimal = 0.0
            Dim _prima As Decimal = 0.0
            Dim _dias_prima As Decimal = 0.0

            Dim _TaTipoPer As String = ""

            Select Case tipo_periodo.Trim.ToUpper
                Case "S"
                    _TaTipoPer = "TA.dbo.periodos"
                Case "Q"
                    _TaTipoPer = "TA.dbo.periodos_quincenal"
                Case "C"
                    _TaTipoPer = "TA.dbo.periodos_catorcenal"
                Case Else
                    _TaTipoPer = "TA.dbo.periodos"
            End Select

            '*** LUA 2021-10-12
            Dim _dias_prima_vac_pag As Double = 0.0
            Dim QDiasPVacPagdas As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'acumAnioDiaPVac' from movimientos where RELOJ='" & rl.Trim & "' and ANO='" & fVacs.ToString("yyyy") & "' and concepto='DIASPV' and isnull(tipo_nomina,'')<>'F' and periodo in" & vbCrLf & _
                "(select PERIODO from " & _TaTipoPer & IIf(_TaTipoPer.Contains("periodos_quincenal"), " where PERIODO <= '24')", " where isnull(PERIODO_ESPECIAL,0) = 0)")

            '--Segun Luis Andrade, con el sig Query obtenemos los dias de prima vac de acuerdo a su ultima alta, en caso de ser reingreso, por
            '        Dim QDiasPVacPagdas As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'acumAnioDiaPVac' from movimientos where RELOJ='" & rl.Trim & "' and ANO='" & fVacs.ToString("yyyy") & "' and concepto='DIASPV' and isnull(tipo_nomina,'')<>'F' and ano+periodo >=" & vbCrLf & _
            '"(select top 1 (ano+periodo) from " & _TaTipoPer & " where '" & FechaSQL(fAlta) & "' between FECHA_INI and FECHA_FIN)"


            Dim dtPVacPagada As DataTable = sqlExecute(QDiasPVacPagdas, "NOMINA")

            If ((dtPVacPagada.Columns.Contains("Error")) Or (Not dtPVacPagada.Columns.Contains("Error") And dtPVacPagada.Rows.Count = 0)) Then
                _dias_prima_vac_pag = 0.0
            Else
                _dias_prima_vac_pag = IIf(IsDBNull(dtPVacPagada.Rows(0).Item("acumAnioDiaPVac")), 0.0, dtPVacPagada.Rows(0).Item("acumAnioDiaPVac"))
            End If

            If (_aniv > fVacs) Then              ' Si aun no es su aniversario (Fecha de baja < Aniv Anio Actual)
                AntigDias = Antiguedad_Dias(_aniv_Ant, fVacs) + 1
            Else                                 ' Si ya cumplieron el aniversario
                AntigDias = Antiguedad_Dias(_aniv, fVacs) + 1
            End If

            _anos = AntiguedadVac(fAlta, fVacs) + 1

            dtVac = sqlExecute("SELECT top 2 * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos <= " & _anos & " order by anos desc ", "PERSONAL")

            If dtVac.Rows.Count > 0 Then
                _dias = dtVac.Rows.Item(0).Item("dias")
                _prima = IIf(IsDBNull(dtVac.Rows.Item(0).Item("por_prima")), 25, dtVac.Rows.Item(0).Item("por_prima"))
            Else
                _dias = 0
                _prima = 0
            End If

            _dias_prima = ((_dias * AntigDias) / 365.25D) * (_prima / 100D)

            Dim FechaActual As Date = Now.Date

            If _aniv >= FechaActual.Date And _aniv <= fVacs Then

                If _aniv = fVacs.Date And _dias_prima_vac_pag <> 0.0 Then
                    'Si la fecha de proyección es el aniversario pero la prima ya se pago
                    _dias = 0
                    _prima = 0
                ElseIf _aniv = fVacs.Date And _dias_prima_vac_pag = 0.0 Then

                    Try
                        Dim drVac As DataRow = dtVac.Select("anos < " & _anos.ToString, "anos desc")(0)
                        _dias = drVac("dias")
                        _prima = IIf(IsDBNull(drVac("por_prima")), 25, drVac("por_prima"))
                    Catch ex As Exception
                        _dias = 0
                        _prima = 0
                    End Try

                ElseIf _dias_prima_vac_pag <> 0.0 Then
                    _dias = 0
                    _prima = 0

                ElseIf _dias_prima_vac_pag = 0.0 Then

                    Try
                        Dim drVac As DataRow = dtVac.Select("anos < " & _anos.ToString, "anos desc")(0)
                        _dias = drVac("dias")
                        _prima = IIf(IsDBNull(drVac("por_prima")), 25, drVac("por_prima"))
                    Catch ex As Exception
                        _dias = 0
                        _prima = 0
                    End Try

                End If

            ElseIf _aniv < FechaActual.Date Then
                'Si el aniversario ya pasó

                If _dias_prima_vac_pag <> 0.0 Then
                    _dias = 0
                    _prima = 0
                Else
                    Try
                        Dim drVac As DataRow = dtVac.Select("anos < " & _anos.ToString, "anos desc")(0)
                        _dias = drVac("dias")
                        _prima = IIf(IsDBNull(drVac("por_prima")), 25, drVac("por_prima"))
                    Catch ex As Exception
                        _dias = 0
                        _prima = 0
                    End Try
                End If

                _dias_prima = _dias_prima + ((_dias * _prima) / 100D)

            End If

            Resultado = Math.Round(_dias_prima, 2)

        Catch ex As Exception
            Resultado = 0.0
        End Try

        Return Resultado

    End Function

    ''' <summary>
    ''' Función para crear datatables (solo columnas sin información). Retorna un valor tipo datatable.
    ''' Autor: Ernesto G.  Fecha: 5 abril 2022
    ''' </summary>
    ''' <param name="nombresCol">Nombres de las columnas</param>
    ''' <param name="tipoCol">Tipo de columnas</param>
    ''' <remarks></remarks>
    Public Function creaDt(ByVal nombresCol As String, ByVal tipoCol As String) As DataTable
        Try
            Dim dtTablaCol As New DataTable
            Dim infoN() As String = Split(nombresCol, ",")
            Dim infoT() As String = Split(tipoCol, ",")
            Dim cont As Integer = infoN.Count

            If infoN.Count = infoT.Count Then
                For i As Integer = 0 To cont - 1
                    Dim colN As New DataColumn
                    colN.ColumnName = infoN(i)
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
                        Case "Bool"
                            dtTablaCol.Columns(infoN(i)).DataType = GetType(Boolean)
                    End Select
                Next
            End If

            Return dtTablaCol
        Catch ex As Exception : End Try
    End Function

    Public Function DiferenciaFecha(ByVal fecha_ini As DateTime, ByVal fecha_fin As DateTime) As Integer

        Dim resultado As Integer = 0
        Dim incremento As Integer = 0

        ' definir el número de días de mes;
        ' índice 0 => enero y 11 => diciembre
        ' febrero contiene 28 o 29 días, por eso aquí el valor es -1
        ' que se calculará más tarde
        Dim MesDia() As Integer = New Integer(11) {31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}

        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Dim anio As Integer = 0
        Dim mes As Integer = 0
        Dim dia As Integer = 0

        Try

            If fecha_ini > fecha_fin Then

                FechaInicio = fecha_fin
                FechaFin = fecha_ini

            Else

                FechaInicio = fecha_ini
                FechaFin = fecha_fin

            End If

            '*** Calculo dias ***
            If FechaInicio.Day > FechaFin.Day Then
                incremento = MesDia(FechaInicio.Month - 1)
            End If

            'Si es el mes de febrero
            'Si hoy es un dia menos que la fecha inicio
            If incremento = -1 Then
                If DateTime.IsLeapYear(FechaInicio.Year) Then
                    'Año bisiesto febrero contiene 29 dias
                    incremento = 29
                Else
                    incremento = 28
                End If
            End If

            If incremento <> 0 Then
                dia = (FechaFin.Day + incremento) - FechaInicio.Day
                incremento = 1
            Else
                dia = FechaFin.Day - FechaInicio.Day
            End If

            '*** Calculo meses ***
            If (FechaInicio.Month + incremento) > FechaFin.Month Then
                mes = (FechaFin.Month + 12) - (FechaInicio.Month + incremento)
                incremento = 1
            Else
                mes = (FechaFin.Month) - (FechaInicio.Month + incremento)
                incremento = 0
            End If

            '*** Calculo años ***
            anio = FechaFin.Year - (FechaInicio.Year + incremento)

            resultado = anio

        Catch ex As Exception
            resultado = -1
        End Try

        Return resultado

    End Function

    ''' <summary>
    ''' Función para generar el numero consecutivo de algun campo
    ''' Autor: Ing. Adrian Ortega S. el 2024-05-31
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GenConsec(ByRef Campo As String, ByRef Tabla As String, ByRef BD As String, Optional CerosAgrear As String = "") As String
        Dim NumSig As String = ""
        Dim dtUltCod As DataTable = sqlExecute("SELECT TOP 1 ISNULL( MAX(" & Campo & "),'X') as ult_cod from " & Tabla & "", "" & BD & "")
        If (Not dtUltCod.Columns.Contains("Error") And dtUltCod.Rows.Count > 0) Then ' Si existe un numero

            Dim UltCodStr As String = IIf(IsDBNull(dtUltCod.Rows(0).Item("ult_cod")), "", dtUltCod.Rows(0).Item("ult_cod"))
            If (UltCodStr.Trim = "X") Then ' Significa que sería el primer registro
                NumSig = CerosAgrear & "1"
                GoTo Fin
            End If
            Dim CodSigInt As Integer = IIf(UltCodStr.Trim = "", 0, Convert.ToInt32(UltCodStr)) + 1 ' Convertir a Integer
            Dim CerosAdd As String = AddZeros(Len(UltCodStr.Trim), Len(CodSigInt.ToString.Trim)) ' Determina la cantidad de ceros a agregar
            NumSig = CerosAdd & CodSigInt.ToString.Trim
Fin:
            Return NumSig
        End If
        Return NumSig
    End Function

    ''' <summary>
    ''' Validar palabras restringidas de formas activas
    ''' </summary>
    ''' <param name="formaActiva"></param>
    ''' <remarks></remarks>
    Public Sub ValidaPalabrasRestringidas(formaActiva As System.Windows.Forms.Form)
        Try
            controlActivo = formaActiva.ActiveControl

            If Not controlActivo Is Nothing Then
                If TypeOf (controlActivo) Is TextBox Or TypeOf (controlActivo) Is ComboBox Or TypeOf (controlActivo) Is DevComponents.DotNetBar.Controls.TextBoxX Or
                    TypeOf (controlActivo) Is DevComponents.DotNetBar.Controls.ComboBoxEx Or TypeOf (controlActivo) Is DevComponents.DotNetBar.Controls.ComboTree Or
                    TypeOf (controlActivo) Is ComboBox Or TypeOf (controlActivo) Is DevComponents.DotNetBar.Controls.ComboBoxEx Or
                    TypeOf (controlActivo) Is DevComponents.DotNetBar.Controls.ComboTree Then

                    Dim txt = controlActivo.Text.ToString

                    Console.WriteLine(formaActiva.Name & " - " & controlActivo.name)

                    If txt.Length > 0 Then
                        Dim txtUpper = txt.ToUpper
                        For Each r In dtPalabrasReservadas.Rows
                            If txtUpper.Contains(r("nombres")) Then
                                controlActivo.Text = ""
                                MessageBox.Show("USO DE PALABRA RESERVADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        Next
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

#Region "Funciones para encriptar y desencriptar -- AES"

    ''' <summary>
    ''' Encriptacion
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="pass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AES_Encriptar(input As String, pass As String) As String
        Try

            Dim inputBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(input)
            Dim aes As New AesCryptoServiceProvider

            aes.Key = ASCIIEncoding.ASCII.GetBytes(pass)
            aes.IV = ASCIIEncoding.ASCII.GetBytes(StrReverse(pass.ToString.Substring(0, 16)))

            Dim en As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
            Dim ms As MemoryStream = New MemoryStream()
            Dim cs As CryptoStream = New CryptoStream(ms, en, CryptoStreamMode.Write)

            cs.Write(inputBytes, 0, inputBytes.Length)
            cs.FlushFinalBlock()
            cs.Close()

            Return Convert.ToBase64String(ms.ToArray)

        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Desencriptacion
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="pass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AES_Desencriptar(input As String, pass As String) As String
        Try
            Dim inputBytes() As Byte = Convert.FromBase64String(input)
            Dim aes As New AesCryptoServiceProvider

            aes.Key = ASCIIEncoding.ASCII.GetBytes(pass)
            aes.IV = ASCIIEncoding.ASCII.GetBytes(StrReverse(pass.ToString.Substring(0, 16)))

            Dim de As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
            Dim ms As MemoryStream = New MemoryStream()
            Dim cs As CryptoStream = New CryptoStream(ms, de, CryptoStreamMode.Write)

            cs.Write(inputBytes, 0, inputBytes.Length)
            cs.FlushFinalBlock()
            cs.Close()

            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)

        Catch ex As Exception : End Try
    End Function
#End Region

End Module

