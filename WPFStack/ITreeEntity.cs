using System;
namespace WPFStack
{
    public interface ITreeEntity
    {
        System.Collections.Generic.List<ITreeEntity> Children { get; set; }
        bool IsSelected { get; set; }
        string Name { get; set; }
        ITreeEntity Parent { get; set; }
    }
}
