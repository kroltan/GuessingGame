using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace GuessingGame.Interface {
	public partial class PromptPage : Page, INotifyPropertyChanged {
		private string _label;

		public event Action<string> OnSubmit;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Label {
			get => _label;
			set {
				_label = value;
				OnPropertyChanged();
			}
		}

		public PromptPage() {
			InitializeComponent();
			Answer.Focus();
		}

		private void Submit_OnClick(object sender, RoutedEventArgs e) {
			OnSubmit?.Invoke(Answer.Text);
		}

		private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
