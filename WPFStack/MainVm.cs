using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using WPFStack.Controls;
using WPFStack.Model;
using WPFStack.Operations;

namespace WPFStack
{



    public class MainVm : INotifyPropertyChanged
    {

        #region Variables
        private List<ITreeEntity> _Ships;
        private List<ITreeEntity> _Groups;
        private List<ITreeEntity> _Viewables;
        private List<ITreeEntity> _Passages;
        private List<int> _VersionNumbers;
        private List<Order> _Orders;
        private Dictionary<string, string> _myDictionary;
        private int _SliderSeleciton;

        private string  JSONRaw = "";
        #endregion

        #region Properties


        public OperationCommand DeleteItem { get; set; }
        public OperationCommand CopyItem { get; set; }

        

        public Dictionary<string,string> myDictionary
        {
            get { return _myDictionary; }
            set { _myDictionary = value; OnPropertyChanged(); }
        }

        public List<Order> Orders
        {
            get { return _Orders; }
            set { _Orders = value; OnPropertyChanged("Orders"); }
        }

        public List<int> VersionNumbers
        {
            get { return _VersionNumbers; }
            set { _VersionNumbers = value; OnPropertyChanged("VersionNumbers"); }
        }

        private decimal _TargetDecimal;

        public decimal TargetDecimal
        {
            get { return _TargetDecimal; }
            set
            {
                _TargetDecimal = value;
                OnPropertyChanged("TargetDecimal");
                OnPropertyChanged("TargetValueTruncated");
            }

        }


        public string TargetValueTruncated
        {
            get { return Regex.Match(_TargetDecimal.ToString(), @"\d+\.\d\d\d").Value; }
        }


        private string _ComboSelected;

        public string ComboSelected
        {
            get { return _ComboSelected; }
            set { _ComboSelected = value; OnPropertyChanged("ComboSelected"); }
        }

        public List<ITreeEntity> Groups
        {
            get { return _Groups; }
            set { _Groups = value; OnPropertyChanged("Groups"); }
        }

        public List<ITreeEntity> Ships
        {
            get { return _Ships; }
            set { _Ships = value; OnPropertyChanged("Ships"); }
        }


        public List<ITreeEntity> Passages
        {
            get { return _Passages; }
            set { _Passages = value; OnPropertyChanged("Passages"); }
        }


        public List<ITreeEntity> Viewables
        {
            get { return _Viewables; }
            set { _Viewables = value; OnPropertyChanged("Viewables"); }
        }



        public int SliderSeleciton
        {
            get { return _SliderSeleciton; }
            set { _SliderSeleciton = value; OnPropertyChanged("SliderSeleciton"); }
        }


        private Passage _SelectedPassage;

        public Passage SelectedPassage
        {
            get { return _SelectedPassage; }
            set { _SelectedPassage = value; OnPropertyChanged("SelectedPassage"); }
        }



        private List<HelpItem> _Helps;

        public List<HelpItem> Helps
        {
            get { return _Helps; }
            set { _Helps = value; OnPropertyChanged("Helps"); }
        }

    private CompositeCollection _MyCompositeCollection;

    public CompositeCollection MyCompositeCollection
    {
        get { return _MyCompositeCollection; }
        set { _MyCompositeCollection = value; OnPropertyChanged("MyCompositeCollection"); }
    }



    private ObservableCollection<ITreeEntity>  _OBSCollection;

    public ObservableCollection<ITreeEntity>  OBSCollection
    {
        get { return _OBSCollection; }
        set { _OBSCollection = value; OnPropertyChanged("OBSCollection"); }
    }


    private List<PointCollection> _AllPoints;

    public List<PointCollection> AllPoints
    {
        get { return _AllPoints; }
        set { _AllPoints = value; OnPropertyChanged("AllPoints"); }
    }



        private List<HighLightItem> _Highlights;

        public List<HighLightItem> Highlights
        {
            get { return _Highlights; }
            set { _Highlights = value; OnPropertyChanged("Highlights"); }
        }


        private List<Tuple<string,int>> _Tuples;

        public List<Tuple<string,int>> Tuples
        {
            get { return _Tuples; }
            set { _Tuples = value; OnPropertyChanged(nameof(Tuples)); }
        }


        private List<string> _OrderStatus;

        public List<string> OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; OnPropertyChanged(nameof(OrderStatus)); }
        }



        #endregion

        #region Construction/Initialization
        public MainVm()
        {

            OrderStatus = new List<string>() {"None", "New", "Processing", "Shipped", "Received"};
            Highlights = new List<HighLightItem>()
            {
                new HighLightItem(2, 3, Brushes.Red)
                , new HighLightItem(7, 10, Brushes.Fuchsia)
            };

                        SliderSeleciton = 3;
            TargetDecimal = 5.3557M;


        
        Orders = new List<Order>()
            {
                new Order() { OrderId=1, CustomerName="Alpha", Status = Model.OrderStatus.New, strStatus = "New"},
                new Order() { OrderId=2, CustomerName="Beta", InProgress = true, Status = Model.OrderStatus.Processing, strStatus = "Processing"},
                new Order() { OrderId=3, CustomerName="Omega",  Status = Model.OrderStatus.Shipped, strStatus = "Shipped"},

            };


            Passages = new List<ITreeEntity>() { new Passage() { Name = "Alpha", PortFrom = "FromPort", PortTo = "ToPort"}, 
                new Passage() { Name = "Beta",  PortFrom = "Flagstaff", PortTo = "Detriot"}, 
                new Passage() { Name = "Gamma", PortFrom = "Chicago", PortTo = "Los Angeles"}, 
                new Passage() { Name = "I-25", PortFrom = "Flagstaff", PortTo = "Winona" } };


            myDictionary = new Dictionary<string, string>()
                            {
                                {"Alpha", "The First Letter"},
                                {"Beta", "The Second Letter"},
                                {"Omega", "Omega Letter"},
                            };

            Ships = new List<ITreeEntity>() { new Ship() { Name = "Pacific Silver" }, new Ship() { Name = "Mt Orthis" } };

            Ships[0].Children = Passages.Take(2).ToList();
            Ships[1].Children = Passages.Skip(2).ToList();

            Ships[0].Children.ForEach(chld => chld.Parent = Ships[0]);
            Ships[1].Children.ForEach(chld => chld.Parent = Ships[1]);

            Tuples = new List<Tuple<string, int>>()
            {
                new Tuple<string,int>("Alpha", 123),
                new Tuple<string,int>("New York", 89),
                new Tuple<string,int>("Colorado", 266)
            }   ;

            Groups = new List<ITreeEntity>() 
            {
                new Group() { Name = "Jabberwocky", Children = Ships.ToList() },
                new Group() { Name = "Deux", Children = Ships.Take(1).ToList() },
                new Group() { Name = "Nada", }
            };

            ChangeSelection();

            var temp  = new CompositeCollection();


            var T2 = new ObservableCollection<ITreeEntity>();

            Ships.ForEach(sh => T2.Add(sh));
            Passages.ForEach(ps => T2.Add(ps));


            OBSCollection = T2;

            SetupHelp();

            SetupPoints();


            Ships.ForEach(sh => temp.Add(sh));
            Passages.ForEach(ps => temp.Add(ps));
            AllPoints.ForEach( pt => temp.Add(pt));

            MyCompositeCollection = temp;

            VersionNumbers = new List<int>() { 12, 13, 14 };

        }

      

        private void SetupPoints()
        {

            AllPoints = new List<PointCollection>()
            {
                new PointCollection(new[] {new Point(1, 2), new Point(34, 12), new Point(12, 99)}),
                new PointCollection(new[] {new Point(9, 9), new Point(8, 8)}),
            };

        }

        private void SetupHelp()
        {
            List<string> Headers = new List<string>() { "Date Start", "Date End", "Description", "Summary", "Long PlaceHolder" };

            Random rnd = new Random();
            int month = rnd.Next(1, 13);
            Helps = Enumerable.Range(0, 25)
                              .Select(index => new HelpItem()
                              {
                                  Header = Headers[rnd.Next(0, Headers.Count - 1)],
                                  Description = NLipsum.Core.LipsumGenerator.Generate(rnd.Next(1, 6))
                              })
                              .ToList();

        }
        #endregion

        #region Methods

        public void ChangeSelection()
        {

            switch (SliderSeleciton)
            {

            case 2: Viewables = Ships; break;
            case 3: Viewables = Passages; break;
            case 4: Viewables = Groups; break;

            }
            
        }

        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName = "")
        {

 
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion

    }
}
