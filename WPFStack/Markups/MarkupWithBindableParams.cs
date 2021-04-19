using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFStack.Markups
{
    public class MarkupExtensionWithBindableParam : MarkupExtension
    {
        // Its necessary to set parameter type as BindingBase to avoid exception 
        // that binding can't be used with non DependencyProperty
        public string Param1 { get; set; }

        private BindingBase Param1BindingBase { get; set; }

        private static DependencyProperty Param1BindingSinkProperty = 
            DependencyProperty.RegisterAttached("Param1BindingSink" 
                                              , typeof(object)// set the desired type of Param1 for at least runtime type safety check
                                              , typeof(MarkupExtensionWithBindableParam)
                                              , new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public MarkupExtensionWithBindableParam()
        {
            
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
         //   DependencyObject  targetObject;
            DependencyProperty targetProperty;

            if (target?.TargetObject is DependencyObject && target.TargetProperty is DependencyProperty)
            {
           //     targetControl = (DependencyObject)target.TargetObject;
                targetProperty = (DependencyProperty)target.TargetProperty;

                var control = target.TargetObject as Control;

                var notPropChange = control?.DataContext as INotifyPropertyChanged;

                if (notPropChange != null)
                {

                    //notPropChange.PropertyChanged += (sender, args) =>
                    //{
                    //    if (args.PropertyName == Param1)
                    //}


                }
            }
            else
            {
                return this; // magic
            }

            return this; // ???

            //// Bind the Param1 to attached property Param1BindingSinkProperty 
            //BindingOperations.SetBinding(targetObject, MarkupExtensionWithBindableParam.Param1BindingSinkProperty, Param1BindingBase);

            ////// Now you can use Param1

            //// Param1 direct access example:
            //object param1Value = targetObject.GetValue(Param1BindingSinkProperty);

            //// Param1 use in binding example:
            //var param1InnerBinding = new Binding()
            //{
            //    Source = targetObject,
            //    Path = new PropertyPath("(0).SomeInnerProperty", Param1BindingSinkProperty)
            //}; // binding to Param1.SomeInnerProperty

            //return param1InnerBinding.ProvideValue(serviceProvider); // return binding to Param1.SomeInnerProperty

            // return "Alpha";
        }


        //public override object ProvideValue(IServiceProvider serviceProvider)
        //{
        //    IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        //    DependencyObject targetObject;
        //    DependencyProperty targetProperty;

        //    if (target?.TargetObject is DependencyObject && target.TargetProperty is DependencyProperty)
        //    {
        //        targetObject = (DependencyObject)target.TargetObject;
        //        targetProperty = (DependencyProperty)target.TargetProperty;
        //    }
        //    else
        //    {
        //        return this; // magic
        //    }

        //    // Bind the Param1 to attached property Param1BindingSinkProperty 
        //    BindingOperations.SetBinding(targetObject, MarkupExtensionWithBindableParam.Param1BindingSinkProperty, Param1BindingBase);

        //    //// Now you can use Param1

        //    // Param1 direct access example:
        //    object param1Value = targetObject.GetValue(Param1BindingSinkProperty);

        //    // Param1 use in binding example:
        //    var param1InnerBinding = new Binding()
        //    {
        //        Source = targetObject,
        //        Path = new PropertyPath("(0).SomeInnerProperty", Param1BindingSinkProperty)
        //    }; // binding to Param1.SomeInnerProperty

        //    return param1InnerBinding.ProvideValue(serviceProvider); // return binding to Param1.SomeInnerProperty

        //    // return "Alpha";
        //}


    }
}
