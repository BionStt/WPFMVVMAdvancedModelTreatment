﻿using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel //TODO
    {
        private readonly IEventAggregator _eventAggregator;
        private IFriendEditViewModel _selectedFriendEditViewModel;
        //TODO
        private Func<IFriendEditViewModel> _friendEditViewModelCreator;
        //TODO

        public MainViewModel(IEventAggregator eventAggregator,
            INavigationViewModel navigationViewModel,
            Func<IFriendEditViewModel> friendEditViewCreator) //TODO
        {
            _eventAggregator = eventAggregator;
            //TODO
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                .Subscribe(OnOpenFriendTab);
            //TODO
            NavigationViewModel = navigationViewModel;
            _friendEditViewModelCreator = friendEditViewCreator;
            //TODO
            FriendEditViewModels
                = new ObservableCollection<IFriendEditViewModel>();
            //TODO
        }

        internal void Load()
        {
            NavigationViewModel.Load();
        }

        public ICommand CloseFriendTabCommand { get; private set; }

        public ICommand AddFriendCommand { get; set; }

        public INavigationViewModel NavigationViewModel { get; private set; }

        // Those ViewModes represent the Tab-Pages in the UI
        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels
        { get; private set; }

        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get { return _selectedFriendEditViewModel; }
            set
            {
                _selectedFriendEditViewModel = value;
                //TODO
            }
        }

        //TODO

        private void OnOpenFriendTab(int friendId)
        {
            var viewModel = FriendEditViewModels
                .SingleOrDefault(vm => vm.Friend.Id == friendId);
            if (viewModel == null)
            {
                viewModel = _friendEditViewModelCreator();
                FriendEditViewModels.Add(viewModel);
                viewModel.Load(friendId);
            }
            SelectedFriendEditViewModel = viewModel;
        }

        //TODO
    }
}
