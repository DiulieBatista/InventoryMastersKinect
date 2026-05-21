using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMastersKinect.Service
{
     public class KinectService
    {

        public KinectSensor Sensor { get; private set; }

        public bool InicializarKinect()
        {
            Sensor = KinectSensor.KinectSensors
                .FirstOrDefault(s => s.Status == KinectStatus.Connected);

            if (Sensor == null)
                return false;

            Sensor.ColorStream.Enable(
                ColorImageFormat.RgbResolution640x480Fps30);

            Sensor.DepthStream.Enable(
                DepthImageFormat.Resolution320x240Fps30);

            Sensor.Start();

            return true;
        }

        public void DesligarKinect()
        {
            if (Sensor != null && Sensor.IsRunning)
            {
                Sensor.Stop();
            }
        }
    }
}

