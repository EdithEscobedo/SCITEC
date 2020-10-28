Imports System
Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class BaseDatos
    Private cnx As MySqlConnection

    'Variables para la creacion de la cadena de conexion
    Private db_server As String = "server="
    Private db_user As String = "user="
    Private db_database As String = "database="
    Private db_port As String = "port="
    Private db_password As String = "password="

    'Metodo para establecer la conexión a la BD
    Public Sub New()
        ' Inicializar variables de conexion
        db_server = db_server & "localhost" & ";"
        db_user = db_user & "scitecadmin" & ";"
        db_database = db_database & "scitec" & ";"
        db_port = db_port & "3306" & ";"
        db_password = db_password & "scitecadmin123" & ";"

        ' Con esta cadena preparamos la conexión a Oracle con el Usuario  y contraseña dueño de las tablas 
        cnx = New MySqlConnection(db_server & db_user & db_database & db_port & db_password)
    End Sub

    Private Sub AbrirConexion()
        Try
            cnx.Open() 'Abrir la base de datos en caso de que la conexión sea exitosa
        Catch ex As Exception
            Throw New Exception("No se puedo conectar a la Base de Datos, contacte al D.B.A.", ex)
        End Try
    End Sub

    Private Sub CerrarConexion()
        Try
            cnx.Close()
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        End Try
    End Sub

    'Metodo de insercion que retorna un valor booleano cuando la insercion se realizo de forma correcta.
    Public Function Insertar(tabla As String, columnas As String(), valores As String()) As Boolean
        AbrirConexion()
        If columnas.Length <> valores.Length Then
            CerrarConexion()
            Throw New Exception("Error: Columnas y Valores no corresponden.")
        End If
        Dim queryStr = "INSERT INTO " & tabla & " (" & String.Join(",", columnas) & ") " &
                       "VALUES " & "(" & String.Join(",", valores) & ")"
        Dim sqlcmd As New MySqlCommand(queryStr, cnx)

        Dim rows As Integer

        Try
            rows = sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally
            sqlcmd.Dispose()
            CerrarConexion()
        End Try

        If rows > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Metodo de eliminacion que retorna un valor booleano cuando el registro fue eliminado correctamente.
    Public Function Eliminar(tabla As String, condiciones As String()) As Boolean
        AbrirConexion()
        Dim queryStr As String = "DELETE FROM " & tabla & " WHERE " & String.Join(",", condiciones)
        Dim sqlcmd As New MySqlCommand(queryStr, cnx)

        Dim rows As Integer

        Try
            rows = sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try

        If rows > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ' Metodo que permite actualizar una tabla y retorna un valor booleano en caso de que la ejecucion sea correcta
    Public Function Actualizar(tabla As String, columnas As String(), valores As String(), condiciones As String()) As Boolean
        AbrirConexion()
        Dim valuesStr(columnas.Length - 1) As String
        If columnas.Length <> valores.Length Then
            CerrarConexion()
            Throw New Exception("Error: Columnas y Valores no corresponden.")
        Else
            For index = 0 To columnas.Length - 1
                valuesStr(index) = columnas(index) & "=" & valores(index)
            Next
        End If

        Dim queryStr As String = "UPDATE " & tabla & " SET " & String.Join(",", valuesStr) & " WHERE " & String.Join(",", condiciones)
        Dim sqlcmd As New MySqlCommand(queryStr, cnx)

        Dim rows As Integer

        Try
            rows = sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try

        If rows > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Metodo que ejecuta una consulta sobre la base de datos y retorna los valore dentro de un objeto DataTable
    Public Function Buscar(tabla As String(), columnas As String(), condiciones As String()) As DataTable
        AbrirConexion()
        Dim dataAdapter As MySqlDataAdapter
        Dim dataTable As DataTable

        Dim queryStr As String = "SELECT " & String.Join(",", columnas) & " FROM " & String.Join(",", tabla)
        If condiciones.Length > 0 Then
            queryStr += " WHERE " & String.Join(" AND ", condiciones)
        End If

        Try
            dataAdapter = New MySqlDataAdapter(queryStr, cnx)
            dataTable = New DataTable
            dataAdapter.Fill(dataTable)
            dataAdapter.Dispose()
            CerrarConexion()
            Return dataTable 'retorna el conjunto de dato
        Catch ex As Exception
            CerrarConexion()
            Throw New Exception("Error: " & ex.Message)
            'Finally
        Finally
            CerrarConexion()
        End Try
    End Function
    Public Function Buscar(tabla As String(), columnas As String(), joins As String(), condiciones As String()) As DataTable
        AbrirConexion()
        Dim dataAdapter As MySqlDataAdapter
        Dim dataTable As DataTable

        Dim queryStr As String = "SELECT " & String.Join(",", columnas) & " FROM " & String.Join(",", tabla)
        If joins.Length > 0 Then
            queryStr += " " & String.Join(" ", joins)
        End If
        If condiciones.Length > 0 Then
            queryStr += " WHERE " & String.Join(" AND ", condiciones)
        End If

        Try
            dataAdapter = New MySqlDataAdapter(queryStr, cnx)
            dataTable = New DataTable
            dataAdapter.Fill(dataTable)
            dataAdapter.Dispose()
            CerrarConexion()
            Return dataTable 'retorna el conjunto de dato
        Catch ex As Exception
            CerrarConexion()
            Throw New Exception("Error: " & ex.Message)
            'Finally
        Finally
            CerrarConexion()
        End Try
    End Function

End Class
