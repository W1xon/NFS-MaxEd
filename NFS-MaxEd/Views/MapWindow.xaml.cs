using System;
using System.Windows;
using System.Windows.Input;

namespace NFSMaxEd.Views
{
    public partial class MapWindow : Window
    {
        private Point lastMousePosition;
        private bool isDragging = false;
        private double currentZoom = 1.0;
        private const double MinZoom = 0.1;
        private const double MaxZoom = 5.0;
        private const double ZoomStep = 0.1;

        public MapWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded; 
            UpdateZoomLabel();
        }
        
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CenterAndZoomOut();
        }
        
        
        
        
        private void CenterAndZoomOut()
        {
            currentZoom = 0.1;
            ScaleTransform.ScaleX = currentZoom;
            ScaleTransform.ScaleY = currentZoom;
        
            
            double canvasWidth = MapCanvas.ActualWidth;
            double canvasHeight = MapCanvas.ActualHeight;
            double imageWidth = MapImage.ActualWidth;
            double imageHeight = MapImage.ActualHeight;
        
            
            if (canvasWidth > 0 && canvasHeight > 0 && imageWidth > 0 && imageHeight > 0)
            {
                TranslateTransform.X = (canvasWidth - imageWidth * currentZoom) / 2;
                TranslateTransform.Y = (canvasHeight - imageHeight * currentZoom) / 2;
            }
        
            UpdateZoomLabel();
        }


        
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void MapCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(MapCanvas);
            MapCanvas.CaptureMouse();
            MapCanvas.Cursor = Cursors.SizeAll;
        }

        
        private void MapCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            MapCanvas.ReleaseMouseCapture();
            MapCanvas.Cursor = Cursors.Arrow;
        }

        
        private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(MapCanvas);
                double offsetX = currentPosition.X - lastMousePosition.X;
                double offsetY = currentPosition.Y - lastMousePosition.Y;

                TranslateTransform.X += offsetX;
                TranslateTransform.Y += offsetY;

                lastMousePosition = currentPosition;
            }
        }

        
        private void MapCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePos = e.GetPosition(MapImage);
            
            double zoomFactor = e.Delta > 0 ? 1.1 : 0.9;
            double newZoom = currentZoom * zoomFactor;

            
            if (newZoom < MinZoom) newZoom = MinZoom;
            if (newZoom > MaxZoom) newZoom = MaxZoom;

            if (Math.Abs(newZoom - currentZoom) > 0.001)
            {
                
                double scaleChange = newZoom / currentZoom;
                
                TranslateTransform.X = mousePos.X - (mousePos.X - TranslateTransform.X) * scaleChange;
                TranslateTransform.Y = mousePos.Y - (mousePos.Y - TranslateTransform.Y) * scaleChange;

                currentZoom = newZoom;
                ScaleTransform.ScaleX = currentZoom;
                ScaleTransform.ScaleY = currentZoom;

                UpdateZoomLabel();
            }
        }

        
        
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            ApplyZoom(currentZoom + ZoomStep);
        }


        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            ApplyZoom(currentZoom - ZoomStep);
        }


        private void ApplyZoom(double newZoom)
        {
            if (newZoom < MinZoom) newZoom = MinZoom;
            if (newZoom > MaxZoom) newZoom = MaxZoom;

            if (Math.Abs(newZoom - currentZoom) < 0.001)
                return;

            
            Point center = new Point(MapCanvas.ActualWidth / 2, MapCanvas.ActualHeight / 2);

            
            Point imageCenter = MapImage.TransformToVisual(MapCanvas).Transform(center);

            double scaleChange = newZoom / currentZoom;

            
            TranslateTransform.X = imageCenter.X - (imageCenter.X - TranslateTransform.X) * scaleChange;
            TranslateTransform.Y = imageCenter.Y - (imageCenter.Y - TranslateTransform.Y) * scaleChange;

            currentZoom = newZoom;
            ScaleTransform.ScaleX = currentZoom;
            ScaleTransform.ScaleY = currentZoom;

            UpdateZoomLabel();
        }


        
        private void ResetZoom_Click(object sender, RoutedEventArgs e)
        {
            currentZoom = 1.0;
            ScaleTransform.ScaleX = currentZoom;
            ScaleTransform.ScaleY = currentZoom;
            TranslateTransform.X = 0;
            TranslateTransform.Y = 0;
            UpdateZoomLabel();
        }

        
        private void UpdateZoomLabel()
        {
            if (ZoomLabel != null)
            {
                ZoomLabel.Text = $"Zoom: {(int)(currentZoom * 100)}%";
            }
        }
    }
}