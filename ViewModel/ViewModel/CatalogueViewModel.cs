﻿using Presentation.Commands;
using Model.Model.Entities;
using Presentation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class CatalogueViewModel : ViewModelBase
    {
        private ObservableCollection<IBook> _catalogue;
        private IBook? _currentBook;
        private IModelLayer _modelLayer;

        public ICommand UpdateBookCommand { get; }
        public AddBookCommand AddBookCommand { get; }

        public IEnumerable<IBook> Catalogue => _catalogue;

        public IBook? CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public CatalogueViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _catalogue = _modelLayer.getBooksObservable();

            UpdateBookCommand = new UpdateBookCommand(this, _modelLayer);
            AddBookCommand = new AddBookCommand(this, _modelLayer);
        }

        internal void AddEmptyRow()
        {
            _catalogue.Add(new SimpleBook()
            {
                Id = _catalogue.Count
            });
            OnPropertyChanged(nameof(Catalogue));
        }
    }
}
