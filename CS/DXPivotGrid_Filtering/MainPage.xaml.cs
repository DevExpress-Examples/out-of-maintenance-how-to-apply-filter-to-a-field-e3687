using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_Filtering {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_Filtering.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e) {

            // Locks the control to prevent excessive updates 
            // when multiple properties are modified.
            pivotGridControl1.BeginUpdate();
            try {

                // Clears the filter value collection and add two items to it.
                fieldYear.FilterValues.Clear();
                fieldYear.FilterValues.Add(1994);
                fieldYear.FilterValues.Add(1995);

                // Specifies that the control should only display the records 
                // which contain the specified values in the Country field.
                fieldYear.FilterValues.FilterType = FieldFilterType.Included;
            }
            finally {

                // Unlocks the control.
                pivotGridControl1.EndUpdate();
            }

        }
    }
}