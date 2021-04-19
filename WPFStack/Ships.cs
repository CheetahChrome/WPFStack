using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace WPFStack
{
    public class Entity : WPFStack.ITreeEntity
    {
        private List<ITreeEntity> _Children;

        public string Name { get; set; }

        public ITreeEntity Parent { get; set; }

        public bool IsSelected { get; set; }


        public List<ITreeEntity> Children
        {
            get
            {
                var result = new List<ITreeEntity>();

                if ((_Children != null) && (_Children.Any()))
                    _Children.ForEach(child =>
                        {
                            result.Add(child);
                        });

                return result;
            }

            set
            {
                _Children = value;
            }
        }



        public override string ToString() { return Name; }
    }


    //public class Parent<T> : Entity
    //{


    //}


    public class Group : Entity
    {


    }

    public class Ship : Entity
    {


    }



    public class Passage : Entity
    {

        public string PortFrom { get; set; }
        public string PortTo { get; set; }
        
    }


    public class HelpItem
    {
        public string Header { get; set; }
        public string Description { get; set; }

    }


}
