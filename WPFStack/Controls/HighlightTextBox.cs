using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFStack.Controls
{

    public class HighLightItem : Run
    {
        public SolidColorBrush Brush { get; set; }

        public int Start { get; set; }
        public int Stop { get; set; }

        public string OriginalText { get; set; }

        public HighLightItem()
        {
            Brush = Brushes.Black;
        }

        public HighLightItem(int start, int stop) : this()
        {
            Start = start;
            Stop = stop;
        }

        public HighLightItem(int start, int stop, string text) : this()
        {
            Start = start;
            Stop = stop;
            GenerateText(text, false);
        }

        public HighLightItem(int start, int stop, Color color) : this(start, stop, new SolidColorBrush(color)) { }


        public HighLightItem(int start, int stop, SolidColorBrush solidColorBrush) : this(start, stop)
        {
            Brush = solidColorBrush;
        }

        /// <summary>
        /// Take the current string reference and push it onto the Text property. 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="colorToBackground"></param>
        /// <remarks>Sets to to white backround and black text.</remarks>
        /// <returns></returns>
        public Run GenerateText(string text, bool colorToBackground = true)
        {
            Text = text.Substring(Start, (Stop - Start) + 1);

            if (colorToBackground)
                Background = Brush;
            else
                base.Foreground = Brush;

            return this;
        }
    }


    public class HighlightTextBox : TextBlock
    {
        public HighlightTextBox() : base() { }

        #region public List<HighLightItem> Highlights
        /// <summary>
        /// 
        /// </summary>
        public List<HighLightItem> Highlights
        {
            get { return GetValue(HighlightsProperty) as List<HighLightItem>; }
            set { SetValue(HighlightsProperty, value); }
        }

        /// <summary>
        /// Identifies the Highlights dependency property.
        /// </summary>
        public static readonly DependencyProperty HighlightsProperty =
            DependencyProperty.Register(
                "Highlights",
                typeof(List<HighLightItem>),
                typeof(HighlightTextBox),
                new PropertyMetadata(null, OnHighlightsPropertyChanged));

        /// <summary>
        /// HighlightsProperty property changed handler.
        /// </summary>
        /// <param name="d">HighlightTextBox that changed its Highlights.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnHighlightsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HighlightTextBox source = d as HighlightTextBox;
            List<HighLightItem> highlights = e.NewValue as List<HighLightItem>;

            var totalLength = source.Text.Length;

            if (totalLength == 0)
                return;

            source.Inlines.Clear();

            if (highlights.Any())
            {
                highlights.ForEach(hg => hg.GenerateText(source.Text));

                highlights.Union(Gaps(highlights, source.Text))
                          .OrderBy(itm => itm.Start)
                          .ToList()
                          .ForEach(itm => source.Inlines.Add(itm));


            }
            
            //var one = new HighLightItem(0, highlights[0].Start, source.Text);
            //source.Inlines.Add(one);
            //source.Inlines.Add(highlights[0].GenerateText(source.Text));

        }
        #endregion public List<HighLightItem> Highlights


        public static IEnumerable<HighLightItem> Gaps(List<HighLightItem> locations, string text)
        {

            var gaps = new List<HighLightItem>();
            int max = text.Length - 1;
            int lastIndex = locations.Count - 1;

            if (locations.Any())
            {
                // First Possible Gap
                if (locations[0].Start != 0)
                    gaps.Add(new HighLightItem(0, locations[0].Start - 1, text));

                // Last Possible Gap
                if ((lastIndex >= 0) && (locations[lastIndex].Stop != max))
                    gaps.Add(new HighLightItem(locations[lastIndex].Stop + 1, max, text));

                locations.Aggregate((current, next) =>
                           {
                                if (current.Stop + 1 != next.Start) // Gap found
                                    gaps.Add(new HighLightItem(current.Stop + 1, next.Start - 1, text));
                          
                                return next;
                            }
                );


                return gaps; // = locations.Union(gaps).OrderBy(l => l.Start);

            }


            return null;
        }


        //private static void OnDataChanged(DependencyObject source,
        //                                  DependencyPropertyChangedEventArgs e)
        //{
        //    TextBlock tb = (TextBlock)source;

        //    if (tb.Text.Length == 0)
        //        return;

        //    string textUpper = tb.Text.ToUpper();
        //    String toFind = ((String)e.NewValue).ToUpper();
        //    int firstIndex = textUpper.IndexOf(toFind);
        //    String firstStr = tb.Text.Substring(0, firstIndex);
        //    String foundStr = tb.Text.Substring(firstIndex, toFind.Length);
        //    String endStr = tb.Text.Substring(firstIndex + toFind.Length,
        //                                     tb.Text.Length - (firstIndex + toFind.Length));

        //    tb.Inlines.Clear();
        //    var run = new Run();
        //    run.Text = firstStr;
        //    tb.Inlines.Add(run);
        //    run = new Run();
        //    run.Background = Brushes.Yellow;
        //    run.Text = foundStr;
        //    tb.Inlines.Add(run);
        //    run = new Run();
        //    run.Text = endStr;

        //    tb.Inlines.Add(run);
        //}

    }


}
