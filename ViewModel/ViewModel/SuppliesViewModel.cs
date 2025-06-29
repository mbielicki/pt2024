﻿using Model.Model.Entities;
using Presentation.Model;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class SuppliesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ISupply> _supplies;
        private ISupply? _currentSupply;
        private IModelLayer _modelLayer;

        public IEnumerable<ISupply> Supplies => _supplies;

        public ISupply? CurrentSupply
        {
            get => _currentSupply;
            set
            {
                _currentSupply = value;
                OnPropertyChanged();
            }
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }


        public SuppliesViewModel(NavigationBarViewModel navigationBarViewModel, IModelLayer modelLayer)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _modelLayer = modelLayer;
            _supplies = _modelLayer.getSuppliesObservable();
        }
    }
}
