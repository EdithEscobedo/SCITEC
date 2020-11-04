Public Class CategoriaProducto
    Private Const tabla As String = "cat_producto"
    Private idcat_producto As Integer
    Private nom_catP As String
    Public Sub New()

    End Sub
    Public Sub New(idcat_producto As Integer, nom_catP As String)
        Me.idcat_producto = idcat_producto
        Me.nom_catP = nom_catP
    End Sub
    Public Function GetIdCategoriaProducto() As Integer
        Return Me.idcat_producto
    End Function
    Public Function GetNombreCategoria() As String
        Return Me.nom_catP
    End Function
    Public Sub SetNombreCategoria(nom_catP As String)
        Me.nom_catP = nom_catP
    End Sub
    Public Sub SetIdCategoriaProducto(idcat_producto As Integer)
        Me.idcat_producto = idcat_producto
    End Sub
    Public Function RegistrarCategoria() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcat_producto", "nom_catP"}
        Dim valores As String() = {BuscarCategoriaId() + 1, "'" & Me.nom_catP & "'"}
        Dim result = database.Insertar(tabla, columnas, valores)
        Return result
    End Function
    Public Function BuscarCategoriaId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idcat_producto) AS idcat_producto"}

        Dim result As DataTable

        result = database.Buscar({tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idcat_producto")) Then
            Return CInt(result.Rows(0)("idcat_producto"))
        Else
            Return 0
        End If
    End Function
    Public Function BuscarCategoria() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcat_producto", "nom_catP"}
        Dim result As DataTable = database.Buscar({tabla}, columnas, {})
        result.DefaultView.Sort = "idcat_producto ASC"

        Return result
    End Function
    Public Sub PoblarComboCategoria(cbCategoria As ComboBox)
        cbCategoria.DisplayMember = "Value"
        cbCategoria.ValueMember = "Key"
        Dim categoriaProducto As DataTable = BuscarCategoria()
        categoriaProducto.DefaultView.Sort = "idcat_producto ASC"
        categoriaProducto = categoriaProducto.DefaultView.ToTable()

        If categoriaProducto.Rows.Count > 0 Then
            Dim tipoUDictionary As New Dictionary(Of Integer, String)
            For index = 0 To categoriaProducto.Rows.Count - 1
                tipoUDictionary.Add(categoriaProducto.Rows(index)("idcat_producto"), categoriaProducto.Rows(index)("nom_catP"))
            Next
            cbCategoria.DataSource = New BindingSource(tipoUDictionary, Nothing)
        Else
            cbCategoria.DataSource = Nothing
        End If
    End Sub
End Class
