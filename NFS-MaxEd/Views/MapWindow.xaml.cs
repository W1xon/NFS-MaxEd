using System.Windows;
using System.Windows.Input;

namespace NFSMaxEd.Views
{
    public partial class MapWindow : Window
    {
        private double _zoomFactor = 1.0;
        private const double ZoomSpeed = 1.1; 
        private const double MinZoom = 0.1;
        private const double MaxZoom = 10.0;
        
        private bool _isDragging = false;
        private Point _lastPanPoint;

        public MapWindow()
        {
            InitializeComponent();
            
            this.Loaded += MapWindow_Loaded;
        }

        private void MapWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CenterImage();
        }

        private void CenterImage()
        {
            if (MapImage.Source != null)
            {
                var canvasWidth = MapCanvas.ActualWidth;
                var canvasHeight = MapCanvas.ActualHeight;
                var imageWidth = MapImage.Source.Width;
                var imageHeight = MapImage.Source.Height;

                var centerX = (canvasWidth - imageWidth) / 2;
                var centerY = (canvasHeight - imageHeight) / 2;

                TranslateTransform.X = centerX;
                TranslateTransform.Y = centerY;
            }
        }

        private void MapCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var delta = e.Delta > 0 ? ZoomSpeed : 1.0 / ZoomSpeed;
            var newZoomFactor = _zoomFactor * delta;

            if (newZoomFactor < MinZoom || newZoomFactor > MaxZoom)
                return;

            var mousePosition = e.GetPosition(MapCanvas);

            var currentX = TranslateTransform.X;
            var currentY = TranslateTransform.Y;

            var newX = mousePosition.X - (mousePosition.X - currentX) * delta;
            var newY = mousePosition.Y - (mousePosition.Y - currentY) * delta;

            ScaleTransform.ScaleX = newZoomFactor;
            ScaleTransform.ScaleY = newZoomFactor;
            TranslateTransform.X = newX;
            TranslateTransform.Y = newY;

            _zoomFactor = newZoomFactor;
        }

        private void MapCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _lastPanPoint = e.GetPosition(MapCanvas);
            MapCanvas.CaptureMouse();
            MapCanvas.Cursor = Cursors.Hand;
        }

        private void MapCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            MapCanvas.ReleaseMouseCapture();
            MapCanvas.Cursor = Cursors.Arrow;
        }

        private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var currentPoint = e.GetPosition(MapCanvas);
                var deltaX = currentPoint.X - _lastPanPoint.X;
                var deltaY = currentPoint.Y - _lastPanPoint.Y;

                TranslateTransform.X += deltaX;
                TranslateTransform.Y += deltaY;

                _lastPanPoint = currentPoint;
            }
        }
    }
}