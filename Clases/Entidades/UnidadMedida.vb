Public Class UnidadMedida
    Private Const tabla As String = "unidad_medida"
    Private idunidadM As Integer
    Private nom_unidadM As String
    Public Sub New()

    End Sub
    Public Sub New(idunidadM As Integer, nom_unidadM As String)
        Me.idunidadM = idunidadM
        Me.nom_unidadM = nom_unidadM
    End Sub
    Public Function GetIdUnidadMedida() As Integer
        Return Me.idunidadM
    End Function
    Public Function GetNombreUnidadMedida() As String
        Return Me.nom_unidadM
    End Function
    Public Sub SetNombreUnidadMedida(nom_unidadM As String)
        Me.nom_unidadM = nom_unidadM
    End Sub
    Public Sub SetIdUnidadMedida(idunidadM As Integer)
        Me.idunidadM = idunidadM
    End Sub
    Public Function RegistrarUnidadMedida() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idunidadM", "nom_unidadM"}
        Dim valores As String() = {BuscarUnidadMedidaId() + 1, "'" & Me.nom_unidadM & "'"}
        Dim result = database.Insertar(tabla, columnas, valores)
        Return result
    End Function
    Public Function BuscarUnidadMedidaId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idunidadM) AS idunidadM"}

        Dim result As DataTable

        result = database.Buscar({tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idunidadM")) Then
            Return CInt(result.Rows(0)("idunidadM"))
        Else
            Return 0
        End If
    End Function
    Public Function BuscarUnidadMedida() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idunidadM", "nom_unidadM"}
        Dim result As DataTable = database.Buscar({tabla}, columnas, {})
        result.DefaultView.Sort = "idunidadM ASC"

        Return result
    End Function
    Public Sub PoblarComboUnidadMedida(cbUnidadM As ComboBox)
        cbUnidadM.DisplayMember = "Value"
        cbUnidadM.ValueMember = "Key"
        Dim unidadMedida As DataTable = BuscarUnidadMedida()
        unidadMedida.DefaultView.Sort = "idunidadM ASC"
        unidadMedida = unidadMedida.DefaultView.ToTable()

        If unidadMedida.Rows.Count > 0 Then
            Dim tipoUDictionary As New Dictionary(Of Integer, String)
            For index = 0 To unidadMedida.Rows.Count - 1
                tipoUDictionary.Add(unidadMedida.Rows(index)("idunidadM"), unidadMedida.Rows(index)("nom_unidadM"))
            Next
            cbUnidadM.DataSource = New BindingSource(tipoUDictionary, Nothing)
        Else
            cbUnidadM.DataSource = Nothing
        End If
    End Sub
End Class
