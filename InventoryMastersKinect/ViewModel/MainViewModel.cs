using InventoryMastersKinect.Commands;
using InventoryMastersKinect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryMastersKinect.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly KinectService _kinectService;

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private string _volumeTexto;
        public string VolumeTexto
        {
            get => _volumeTexto;
            set
            {
                _volumeTexto = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand LigarKinectCommand { get; }
        public ICommand DesligarKinectCommand { get; }

        public MainViewModel()
        {
            _kinectService = new KinectService();

            Status = "Sistema iniciado";
            VolumeTexto = "Volume: 0 cm³";

            // Commands
            LigarKinectCommand =
                new RelayCommand(LigarKinect);

            DesligarKinectCommand =
                new RelayCommand(DesligarKinect);
        }

        private void LigarKinect()
        {
            bool conectado = _kinectService.InicializarKinect();

            if (conectado)
            {
                Status = "Kinect conectado";
            }
            else
            {
                Status = "Kinect não encontrado";
            }
        }

        private void DesligarKinect()
        {
            _kinectService.DesligarKinect();

            Status = "Kinect desligado";
        }
    }

}
