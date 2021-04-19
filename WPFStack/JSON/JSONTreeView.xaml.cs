using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace WPFStack.JSON
{
    public static class Serialize
    {
        public static string ToJson<T>(this List<T> self) => JsonConvert.SerializeObject(self);

        public static List<T> FromJson<T>(string json) => JsonConvert.DeserializeObject<List<T>>(json);
        public static T FromJsonNonList<T>(this string json) => JsonConvert.DeserializeObject<T>(json);

    }

    /// <summary>
    /// Interaction logic for JSONTreeView.xaml
    /// </summary>
    public partial class JSONTreeView : UserControl
    {


        private BatchChange _Detail;

        public BatchChange Detail
        {
            get { return _Detail; }
            set { _Detail = value; OnPropertyChanged(nameof(Detail)); }
        }        
        

        public JSONTreeView()
        {
            var json =
                @"{""BatchId"":0,""AccessionChanges"":[{""LabId"":156686437,""InstanceChanges"":[{""Property"":""Note"",""ChangedTo"":""Overwritten by this"",""UniqueId"":null,""AccessionDetailsSummaryInstance"":null},{""Property"":""Instrument"",""ChangedTo"":""instrumented"",""UniqueId"":null,""AccessionDetailsSummaryInstance"":null}],""DetailChanges"":[{""Property"":""Comments"",""ChangedTo"":""2nd Comment"",""UniqueId"":null,""AccessionDetailsSummaryInstance"":null},{""Property"":""CC"",""ChangedTo"":""XXX"",""UniqueId"":null,""AccessionDetailsSummaryInstance"":null}]}]}";

            InitializeComponent();

            Detail = json.FromJsonNonList<BatchChange>();
        }

        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }



public class BatchChange
{
    public int BatchId { get; set; }
    public Accessionchange[] AccessionChanges { get; set; }
}

public class Accessionchange
{
    public int LabId { get; set; }
    public Instancechange[] InstanceChanges { get; set; }
    public Detailchange[] DetailChanges { get; set; }
}

public class Instancechange
{
    public string Property { get; set; }
    public string ChangedTo { get; set; }
    public object UniqueId { get; set; }
    public object AccessionDetailsSummaryInstance { get; set; }
}

public class Detailchange
{
    public string Property { get; set; }
    public string ChangedTo { get; set; }
    public object UniqueId { get; set; }
    public object AccessionDetailsSummaryInstance { get; set; }
}




}