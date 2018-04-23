Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Xml.Serialization
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_Filtering
	Partial Public Class MainPage
		Inherits UserControl
        Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
            Dim assembly As System.Reflection.Assembly = _
                System.Reflection.Assembly.GetExecutingAssembly()
            Dim stream As Stream = assembly.GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub
		Private Sub LayoutRoot_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

			' Locks the control to prevent excessive updates 
			' when multiple properties are modified.
			pivotGridControl1.BeginUpdate()
			Try

				' Clears the filter value collection and add two items to it.
				fieldYear.FilterValues.Clear()
				fieldYear.FilterValues.Add(1994)
				fieldYear.FilterValues.Add(1995)

				' Specifies that the control should only display the records 
				' which contain the specified values in the Country field.
				fieldYear.FilterValues.FilterType = FieldFilterType.Included
			Finally

				' Unlocks the control.
				pivotGridControl1.EndUpdate()
			End Try

		End Sub
	End Class
End Namespace