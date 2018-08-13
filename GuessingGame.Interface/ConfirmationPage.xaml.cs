using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GuessingGame.Interface {
	public partial class ConfirmationPage : Page, INotifyPropertyChanged {
		private string _message;

		public event PropertyChangedEventHandler PropertyChanged;

		public event Action OnYes;

		public event Action OnNo;

		public string Message {
			get => _message;
			set {
				_message = value;
				OnPropertyChanged();
			}
		}

		public ConfirmationPage() {
			InitializeComponent();
		}

		private void Yes_OnClick(object sender, RoutedEventArgs e) {
			OnYes?.Invoke();
		}

		private void No_OnClick(object sender, RoutedEventArgs e) {
			OnNo?.Invoke();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
